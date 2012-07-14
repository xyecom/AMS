using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using XYECOM.Core.Data;
using XYECOM.Core;
using XYECOM.Model.AMS;

namespace XYECOM.SQLServer.AMS
{
    /// <summary>
    /// 竞价
    /// </summary>
    public class BidInfoAccess
    {
        /// <summary>
        /// 新增报价信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int InserBidInfo(BidInfo info)
        {
            string sql = @"insert into bidinfo (Price,ForeclosedId,PriceDate,FromAddress,Contact,Remark)
                                    values (@Price,@ForeclosedId,@PriceDate,@FromAddress,@Contact,@Remark)";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Price",info.Price),
                new SqlParameter("@ForeclosedId",info.ForeclosedId),
                new SqlParameter("@PriceDate",info.PriceDate),
                new SqlParameter("@FromAddress",info.FromAddress),
                new SqlParameter("@Contact",info.Contact),
                new SqlParameter("@Remark",info.Remark)
            };
            int rowAffected = SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
            if (rowAffected > 0)
            {
                sql = "UPDATE dbo.ForeclosedInfo SET HighPrice=(select top 1 Price from bidinfo where foreclosedid = " + info.ForeclosedId + " order by price desc) WHERE ForeclosedId=" + info.ForeclosedId;
                rowAffected = SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
            }
            return rowAffected;
        }

        /// <summary>
        /// 获取领先信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetLingXian(int ForeclosedId)
        {
            string sql = "select top 3 * from bidinfo where ForeclosedId = " + ForeclosedId + " order by Price desc";
            return SqlHelper.ExecuteTable(CommandType.Text, sql, null);
        }

        /// <summary>
        /// 根据抵债信息编号获取该抵债信息的竞价个数
        /// </summary>
        /// <param name="ForeID"></param>
        /// <returns></returns>
        public int GetBidInfoCountByForeID(int ForeID)
        {
            string sql = "select count(*) from bidInfo where foreclosedid = "+ForeID;
            int count = (int)SqlHelper.ExecuteScalar(CommandType.Text, sql, null);
            return count;
        }
    }
}
