using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// 企业证书数据处理类
    /// </summary>
    public class Certificate
    {
        /// <summary>
        /// 插入证书信息
        /// </summary>
        /// <param name="Cet"></param>
        /// <param name="CE_ID">id</param>
        /// <returns></returns>
        public int Insert(XYECOM.Model.CertificateInfo info, out long ceInfoid)
        {
            SqlParameter[] Parame = new SqlParameter[]
            {
                new SqlParameter("@CE_ID",SqlDbType.BigInt),
                new SqlParameter("@U_ID",info.U_ID),
                new SqlParameter("@CE_Name",info.CE_Name),
                new SqlParameter("@CE_Organ",info.CE_Organ),
                new SqlParameter("@CE_Begin",info.CE_Begin),
                new SqlParameter("@CE_Upto",info.CE_Upto),
                new SqlParameter("@CE_Type",info.CE_Type),
                new SqlParameter("@CE_Isopen",info.CE_Isopen)

            };
           Parame[0].Direction = ParameterDirection.Output;

           int rowAffected = XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"XYP_InsertCertificate", Parame);

           if (rowAffected >= 0)
           {
               if (Parame[0].Value != null && Parame[0].Value.ToString() != "")
                   ceInfoid = (long)Parame[0].Value;
               else
                   ceInfoid = 0;
           }
           else
           {
               ceInfoid = -1;
           }

           return rowAffected;
        }

        /// <summary>
        /// 更新证书信息
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>受影响行数</returns>
        public int Update(XYECOM.Model.CertificateInfo info)
        {
            SqlParameter[] Parame = new SqlParameter[]
            {
                new SqlParameter("CE_ID",info.CE_ID),
                new SqlParameter("@U_ID",info.U_ID),
                new SqlParameter("@CE_Name",info.CE_Name),
                new SqlParameter("@CE_Organ",info.CE_Organ),
                new SqlParameter("@CE_Begin",info.CE_Begin),
                new SqlParameter("@CE_Upto",info.CE_Upto),
                new SqlParameter("@CE_Type",info.CE_Type),
                new SqlParameter("@CE_Isopen",info.CE_Isopen)
            };

            return  XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"XYP_UpdateCertificate", Parame);
        }

        /// <summary>
        /// 获取证书信息
        /// </summary>
        /// <param name="ceInfoid">证书信息Id</param>
        /// <returns>数据实体对象</returns>
        public XYECOM.Model.CertificateInfo GetItem(long ceInfoid)
        {
            XYECOM.Model.CertificateInfo info = null;

            SqlParameter[] Parame = new SqlParameter[]
            {
                new SqlParameter("@strWhere "," where CE_ID=" +ceInfoid.ToString()),
                new SqlParameter("@strTableName"," u_Certificate "),
                new SqlParameter("@strOrder","  " ),

            };

            using (SqlDataReader rdr = XYECOM.Core.Data.SqlHelper.ExecuteReader( CommandType.StoredProcedure, "XYP_SelectByWhere", Parame))
            {
                if (rdr.Read())
                {
                    info = new XYECOM.Model.CertificateInfo();

                    info.CE_ID = Core.MyConvert.GetInt64(rdr["CE_ID"].ToString());
                    info.U_ID = Core.MyConvert.GetInt64(rdr["U_ID"].ToString());
                    info.CE_Name = rdr["CE_Name"].ToString();
                    info.CE_Organ = rdr["CE_organ"].ToString();
                    info.CE_Begin = Core.MyConvert.GetDateTime(rdr["CE_Begin"].ToString());
                    info.CE_Upto = Core.MyConvert.GetDateTime(rdr["CE_Upto"].ToString());
                    info.CE_Addtime = Core.MyConvert.GetDateTime(rdr["CE_AddTime"].ToString());
                    info.CE_Type = Core.MyConvert.GetInt32(rdr["CE_Type"].ToString());
                    info.CE_Isopen = rdr["CE_Isopen"].ToString().ToLower().Equals("true") ? true : false;
                    info.AuditingState = rdr["AuditingState"].ToString().Equals("1") ? Model.AuditingState.Passed : XYECOM.Model.AuditingState.NoPass;
                }
            }

            return info; 
        }

        /// <summary>
        /// 删除多个证书数据
        /// </summary>
        /// <param name="ceInfoIds">以逗号隔开的Id集合</param>
        /// <returns></returns>
        public int Deletes(string ceInfoIds)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where CE_ID in ("+ceInfoIds+")"),
                new SqlParameter("@strTableName","u_Certificate")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }
        /// <summary>
        /// 修改启用
        /// </summary>
        /// <param name="ceInfoId">证书数据ID</param>
        /// <param name="isopen">ture false</param>
        /// <returns>受影响行数</returns>
        public int UpdateIsopen(long ceInfoId,bool isopen)
        {
            SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@CE_ID",ceInfoId),
                    new SqlParameter("@CE_Isopen",isopen)
                };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"XYP_UpdateCartificateIsOpen", param);
        }
    }
}
