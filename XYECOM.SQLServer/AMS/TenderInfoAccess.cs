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
    /// 投标数据访问类
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

        /// <summary>
        /// 判断某服务商是否已经对某债权信息投标
        /// </summary>
        /// <param name="credId"></param>
        /// <returns></returns>
        public bool CheckTenderByCredID(int credId,int serId)
        {
            string sql = "select count(*) from tenderInfo where CreditInfoId= " + credId + " and LayerId = "+serId;
            int count = (int)SqlHelper.ExecuteScalar(CommandType.Text, sql, null);
            if (count > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 根据投标编号获取投标信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TenderInfo GetTenderInfoByID(int id)
        {
            string sql = "select * from tenderInfo where TenderId=@Id";
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@Id",id),
            };
            TenderInfo info = null;

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                if (reader.Read())
                {
                    info = new TenderInfo();

                    info.TenderId = id;
                    info.Message = reader["Message"].ToString();
                    info.CreditInfoId = Core.MyConvert.GetInt32(reader["CreditInfoId"].ToString());
                    info.TenderDate = Core.MyConvert.GetDateTime(reader["TenderDate"].ToString());
                    info.LayerId = Core.MyConvert.GetInt32(reader["LayerId"].ToString());
                    info.IsSuccess = Core.MyConvert.GetInt32(reader["IsSuccess"].ToString());
                }
            }
            return info;
        }
    }
}
