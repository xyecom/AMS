using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using XYECOM.Core.Data;
using XYECOM.Core;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// 服务信息数据处理类
    /// </summary>
    public class ServiceInfo
    {
        #region 添加服务信息
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <param name="es">数据对象</param>
        /// <param name="S_ID">返回的记录Id</param>
        /// <returns>影响行数</returns>
        public int Insert(XYECOM.Model.ServiecInfo es, out int S_ID)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@S_ID",SqlDbType.Int),
                new SqlParameter("@S_Title",es.Title),
                new SqlParameter("@U_ID",es.UserID),
                new SqlParameter("@ST_ID",es.SortID),
                new SqlParameter("@S_Content",es.InfoContent),
                new SqlParameter ("@S_EndDate",es.UseFulDate ),
                new SqlParameter("@S_EndTime",es.EndTime),
                new SqlParameter("@P_ID",es.FieldID),
                new SqlParameter ("@S_Flag",es.InfoType)
            };

            parm[0].Direction = ParameterDirection.Output;
            int rowAffected = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"XYP_InsertService", parm);

            if (rowAffected >= 0)
            {
                if (parm[0].Value != null && parm[0].Value.ToString() != "")
                    S_ID = (int)parm[0].Value;
                else
                    S_ID = 0;
            }
            else
            {
                S_ID = -1;
            }

            return rowAffected;
        }
        #endregion 

        #region 修改服务信息
        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="info">数据对象</param>
        /// <returns>影响行数</returns>
        public int Update(XYECOM.Model.ServiecInfo info)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@S_ID",info.InfoID),
                new SqlParameter("@S_Title",info.Title),
                new SqlParameter("@U_ID",info.UserID),
                new SqlParameter("@ST_ID",info.SortID),
                new SqlParameter("@S_Content",info.InfoContent),
                new SqlParameter("@S_EndTime",info.EndTime),
                new SqlParameter("@P_ID",info.FieldID),
                new SqlParameter ("@S_Flag",info.InfoType),
                new SqlParameter ("@S_EndDate",info.UseFulDate)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"XYP_UpdateService", parm);
        }
        #endregion 

        #region 读一条服务信息
        /// <summary>
        /// 获取数据对象
        /// </summary>
        /// <param name="infoId">记录Id</param>
        /// <returns>数据对象</returns>
        public XYECOM.Model.ServiecInfo GetItem(int infoId)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@strWhere"," Where S_ID=" + infoId.ToString()),
                new SqlParameter("@strTableName","XYV_ServiceInfo"),
                new SqlParameter("@strOrder","")
            };

            XYECOM.Model.ServiecInfo info = null;

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure,"XYP_SelectByWhere", parm))
            {
                if (reader.Read())
                {
                    info = new XYECOM.Model.ServiecInfo();
                    info.InfoID = infoId;

                    if (reader["AuditingState"].ToString() != "")
                    {
                        if (reader["AuditingState"].ToString().Equals("1"))
                            info.AuditingState = XYECOM.Model.AuditingState.Passed;
                        else
                            info.AuditingState = XYECOM.Model.AuditingState.NoPass;
                    }
                    else
                    {
                        info.AuditingState = XYECOM.Model.AuditingState.Null;
                    }

                    //新增的父类属性 刘甲 2008-10-18
                    info.ModuleFlag = reader["ModuleName"].ToString();
                    info.Title = reader["S_Title"].ToString();
                    info.PublishTime = Core.MyConvert.GetDateTime(reader["S_AddTime"].ToString());
                    info.EndTime = Core.MyConvert.GetDateTime(reader["S_EndTime"].ToString());
                    info.InfoContent = reader["S_Content"].ToString();
                    info.UserID = Core.MyConvert.GetInt64(reader["U_ID"].ToString());
                    info.SortID = Core.MyConvert.GetInt64(reader["ST_ID"].ToString());
                    info.SortName = reader["ST_Name"].ToString();
                    info.HtmlPage = reader["S_HTMLPage"].ToString();
                    info.ClickNum = Core.MyConvert.GetInt64(reader["S_ClickNum"].ToString());
                    info.IsCommend = reader["S_Vouch"].ToString() == "1";
                    info.MessageNum = Core.MyConvert.GetInt32(reader["S_MessageNum"].ToString());
                    info.NotReadingNum = Core.MyConvert.GetInt32(reader["S_NoMessageNum"].ToString());
                    info.UseFulDate = Core.MyConvert.GetInt32(reader["S_EndDate"].ToString());
                    info.InfoType = Core.MyConvert.GetInt32(reader["S_Flag"].ToString());
                    info.FieldID = Core.MyConvert.GetInt64(reader["P_ID"].ToString());
                    info.IsPause = Core.MyConvert.GetBoolean(reader["S_Pause"].ToString());
                    //设置附件信息
                    info.AttachInfo = new Attachment().GetItems(info.InfoID, "i_serviceinfo");
                    //Attachment.SetAttachmentInfo(info, reader);
                }
            }
            return info;
        }
        #endregion  

        #region  删除多条记录
        /// <summary>
        /// 删除多条记录
        /// </summary>
        /// <param name="ids">Id字符串，多个用逗号隔开</param>
        /// <returns>影响行数</returns>
        public int Deletes(string ids)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where S_ID in ("+ids+")"),
                new SqlParameter("@strTableName","i_ServiceInfo")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }
        #endregion

        #region 修改推荐信息
        /// <summary>
        /// 更新推荐状态
        /// </summary>
        /// <param name="es">数据对象</param>
        /// <returns>影响行数</returns>
        public int UpdateVouch(XYECOM.Model.ServiecInfo es)
        {
            SqlParameter[] param = new SqlParameter[] 
            {
                new SqlParameter("@S_Vouch",SqlDbType.Bit),
                new SqlParameter("@S_ID",SqlDbType.BigInt )
            };

            param[0].Value = es.IsCommend;
            param[1].Value = es.InfoID;

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"XYP_UpdateServiceVouch", param);
        }
        #endregion

        #region  修改暂停信
        /// <summary>
        /// 更新暂停状态
        /// </summary>
        /// <param name="S_ID">记录Id</param>
        /// <returns>影响行数</returns>
        public int UpdatePause(string S_ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            {
                new SqlParameter("@strwhere","where S_ID in ("+S_ID+")") 
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"XYP_UpdateServicePause", param);
        }
        #endregion

        #region 批量移动
        /// <summary>
        /// 批量移动
        /// </summary>
        /// <returns></returns>
        public int MoveService(String strwhere, String content)
        {
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@strwhere",strwhere),
                new SqlParameter("@tablename","i_ServiceInfo"),
                new SqlParameter("@content",content)
            };
            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "usp_PublicUpdate", param);
        }

        #endregion
    }
}