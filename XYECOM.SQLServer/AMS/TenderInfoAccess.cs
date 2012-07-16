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
    /// 套标数据访问类
    /// </summary>
    public class TenderInfoAccess
    {
        /// <summary>
        /// 添加竞标信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int InsertTenderInfo(TenderInfo info)
        {
            string sql = @"Insert into TenderInfo (layerId,creditInfoId,Message,TenderDate,IsSuccess) values (@LayerId,@CreditInfoId,@Message,@TenderDate,@IsSuccess)";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@LayerId",info.LayerId),
                new SqlParameter("@CreditInfoId",info.CreditInfoId),
                new SqlParameter("@Message",info.Message),
                new SqlParameter("@TenderDate",info.TenderDate),
                new SqlParameter("@IsSuccess",info.IsSuccess)
            };
            int rowAffected = SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
            return rowAffected;
        }

        /// <summary>
        /// 根据债权信息编号获取投标个数
        /// </summary>
        /// <param name="CreditID"></param>
        /// <returns></returns>
        public int GetTenderCountByCreditID(int CreditID)
        {
            string sql = "select count(*) from TenderInfo where creditInfoId = "+CreditID;
            int count = (int)SqlHelper.ExecuteScalar(CommandType.Text, sql, null);
            return count;
        }
    }
}
