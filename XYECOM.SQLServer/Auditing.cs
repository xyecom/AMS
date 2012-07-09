using System;
using System.Collections.Generic;
using System.Text;

using XYECOM.Core.Data;
using System.Data;
using System.Data.SqlClient;
using XYECOM.Core;

namespace XYECOM.SQLServer
{
   /// <summary>
   /// 信息审核数据处理类
   /// </summary>
    public class Auditing
    {
        /// <summary>
        /// 添加审核信息
        /// </summary>
        /// <param name="info">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Insert(XYECOM.Model.AuditingInfo info)
        {
            SqlParameter[] param = new SqlParameter[] 
            {
                new SqlParameter("@DescTabID",SqlDbType.Int),
                new SqlParameter("@DescTabName",SqlDbType.VarChar),
                new SqlParameter("@A_Reason",SqlDbType.VarChar),
                new SqlParameter("@A_Advice",SqlDbType.VarChar),
            };

            param[0].Value = info.DescTabID;
            param[1].Value = info.DescTabName;
            param[2].Value = info.A_Reason;
            param[3].Value = info.A_Advice;


            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertAuditingInfo", param);
        }

        /// <summary>
        /// 修改审核信息
        /// </summary>
        /// <param name="info">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Update(XYECOM.Model.AuditingInfo info)
        {
            SqlParameter[] param = new SqlParameter[] 
            {
                new SqlParameter("@DescTabID",SqlDbType.Int),
                new SqlParameter("@DescTabName",SqlDbType.VarChar),
                new SqlParameter("@A_Reason",SqlDbType.VarChar),
                new SqlParameter("@A_Advice",SqlDbType.VarChar)
            };

            param[0].Value = info.DescTabID;
            param[1].Value = info.DescTabName;
            param[2].Value = info.A_Reason;
            param[3].Value = info.A_Advice;
 
            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateAuditingInfo", param);
        }

        /// <summary>
        /// 获取一条记录[已过时]
        /// </summary>
        /// <param name="A_ID">记录编号</param>
        /// <returns>一条记录</returns>
        public XYECOM.Model.AuditingInfo GetItem(int A_ID)
        {
            XYECOM.Model.AuditingInfo aut = null;
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," Where A_ID=" + A_ID.ToString()),
                new SqlParameter("@strTableName","pl_Auditing"),
                new SqlParameter("@strOrder","")
            };
            using (SqlDataReader rdr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (rdr.Read())
                {
                    aut = new XYECOM.Model.AuditingInfo();
                    aut.A_Advice = rdr["A_Advice"].ToString();
                    aut.A_ID = Int64.Parse(rdr["A_ID"].ToString());
                    aut.A_Reason = rdr["A_Reason"].ToString();
                    aut.DescTabID = Int64.Parse(rdr["DescTabID"].ToString());
                    aut.DescTabName = rdr["DescTabName"].ToString();
                }
            }
            return aut;
        }

        /// <summary>
        /// 获取指定信息的审核信息
        /// </summary>
        /// <param name="DescTabID">信息Id</param>
        /// <param name="DescTabName">信息标识表名称</param>
        /// <returns></returns>
        public XYECOM.Model.AuditingInfo GetItem(string DescTabID, string DescTabName)
        {
            XYECOM.Model.AuditingInfo aut = null;
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," Where DescTabID=" + DescTabID.ToString() + " and DescTabName='" + DescTabName + "' "),
                new SqlParameter("@strTableName","pl_Auditing"),
                new SqlParameter("@strOrder","")
            };
            using (SqlDataReader rdr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (rdr.Read())
                {
                    aut = new XYECOM.Model.AuditingInfo();
                    aut.A_Advice = rdr["A_Advice"].ToString();
                    aut.A_ID = Int64.Parse(rdr["A_ID"].ToString());
                    aut.A_Reason = rdr["A_Reason"].ToString();
                    aut.DescTabID = Int64.Parse(rdr["DescTabID"].ToString());
                    aut.DescTabName = rdr["DescTabName"].ToString();
                }
            }
            return aut;
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="A_ID">记录编号</param>
        /// <returns>受影响的行数</returns>
        public int Delete(int A_ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where A_ID="+A_ID.ToString()),
                new SqlParameter("@strTableName","pl_Auditing")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }

        
        #region 获取记录
        /// <summary>
        /// 获取多条记录
        /// </summary>
        /// <param name="DescTabID">信息Id</param>
        /// <param name="DescTabName">信息标识表名称</param>
        /// <returns>表对象</returns>
        public DataTable GetDataTable(long DescTabID, string DescTabName)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strwhere","where DescTabID="+DescTabID.ToString()+"and DescTabName='"+DescTabName.ToString ()+"'"),
                new SqlParameter("@strtableName","pl_Auditing"),
                new SqlParameter("@strOrder"," ")
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "XYP_SelectByWhere", param);
        }
        #endregion

        /// <summary>
        /// 修改审核状态--多条
        /// </summary>
        /// <param name="DescTabID">id</param>
        /// <param name="DescTabName">信息标识表名称</param>
        /// <param name="AuditingState">审核状态</param>
        /// <returns>受影响的行数</returns>
        public int UpdatesAuditing(long DescTabID, String DescTabName, XYECOM.Model.AuditingState AuditingState)
        {
            int AuditState = 0;
            
            if (AuditingState == XYECOM.Model.AuditingState.Passed)
            {
                AuditState = 1;
            }
            
            if (AuditingState == XYECOM.Model.AuditingState.NoPass)
            {
                AuditState = 0;
            }
            
            if (AuditingState == XYECOM.Model.AuditingState.Null)
            {
                AuditState = -1;
            }

            SqlParameter[] param = new SqlParameter[]
                {
                new SqlParameter("@DescTabID",DescTabID),
                new SqlParameter("@DescTabName",DescTabName),
                new SqlParameter("@Auditingstate",AuditState)
                };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdatesAuditing", param);
        }
    }
}
