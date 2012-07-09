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
    /// 留言数据处理类
    /// </summary>
    public class Message
    {
        /// <summary>
        /// 添加留言信息
        /// </summary>
        /// <param name="ea">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Insert(XYECOM.Model.MessageInfo info)
        {
            SqlParameter[] param = new SqlParameter[] 
            {                             
                new SqlParameter("@M_UserName",info.M_UserName ),                 
                new SqlParameter("@M_Moblie",info.M_Moblie),
                new SqlParameter("@M_Content",info.M_Content),
                new SqlParameter("@UR_ID",info.UR_ID),
                new SqlParameter("@M_RecverType",info.M_RecverType ),
                new SqlParameter("@U_ID",info.U_ID),
                new SqlParameter("@M_PHMa",info.M_PHMa),
                new SqlParameter("@M_FHM",info.M_FHM),
                new SqlParameter("@M_Adress",info.M_Adress),
                new SqlParameter("@M_Title",info.M_Title),
                new SqlParameter("@M_Email",info.M_Email),
                new SqlParameter("@M_SenderType",info.M_SenderType ),
                new SqlParameter("@M_UserType",info.M_UserType ),
                new SqlParameter("@M_CompanyName",info.M_CompanyName ),
                new SqlParameter("@M_Sex",info.M_Sex ),
                new SqlParameter("@M_Restore",info.M_Restore ),
                new SqlParameter("@Area_ID",info.Area_ID ),
                new SqlParameter("@InfoID",info.InfoId )
            };

            int rowAffected = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertMessage", param);
            return rowAffected;
        }


        /// <summary>
        /// 修改留言信息
        /// </summary>
        /// <param name="ea">实体类</param>
        /// <returns>受影响的行数</returns>
        public int UpdateMess(long M_ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            {        
                new SqlParameter ("@M_ID",M_ID )
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateMessage", param);
        }

        /// <summary>
        /// 修改留言信息查看状态
        /// </summary>
        /// <param name="infoId">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Update(long infoId)
        {
            SqlParameter[] param = new SqlParameter[] 
            {  
                new SqlParameter("@M_ID",infoId),                                   
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateMessageIsReply", param);
        }

        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="M_ID">记录编号</param>
        /// <returns>一条记录</returns>
        public XYECOM.Model.MessageInfo GetItem(long M_ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," Where M_ID=" + M_ID.ToString()),
                new SqlParameter("@strTableName","pl_Message"),
                new SqlParameter("@strOrder","")
            };

            XYECOM.Model.MessageInfo info = null;

            using (SqlDataReader dr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (dr.Read())
                {
                    info = new XYECOM.Model.MessageInfo();

                    if (dr["Area_ID"].ToString() != "")
                    {
                        info.Area_ID = Convert.ToInt32(dr["Area_ID"].ToString());
                    }
                    else
                    {
                        info.Area_ID = 0;
                    }
                    if (dr["M_Adress"].ToString() != "")
                    {
                        info.M_Adress = dr["M_Adress"].ToString();
                    }
                    else
                    {
                        info.M_Adress = "";
                    }
                    if (dr["M_CompanyName"].ToString() != "")
                    {
                        info.M_CompanyName = dr["M_CompanyName"].ToString();
                    }
                    else
                    {
                        info.M_CompanyName = "";
                    }
                    if (dr["M_Content"].ToString() != "")
                    {
                        info.M_Content = dr["M_Content"].ToString();
                    }
                    else
                    {
                        info.M_Content = "";
                    }
                    if (dr["M_Email"].ToString() != "")
                    {
                        info.M_Email = dr["M_Email"].ToString();
                    }
                    else
                    {
                        info.M_Email = "";
                    }
                    if (dr["M_FHM"].ToString() != "")
                    {
                        info.M_FHM = dr["M_FHM"].ToString();
                    }
                    else
                    {
                        info.M_FHM = "";
                    }
                    if (dr["M_HasReply"].ToString() != "")
                    {
                        if (Convert.ToBoolean(dr["M_HasReply"].ToString().ToLower()) == true)
                        {
                            info.M_HasReply = true;
                        }
                        else
                        {
                            info.M_HasReply = false;
                        }
                    }
                    else
                    {
                        info.M_HasReply = false;
                    }
                    if (dr["M_Moblie"].ToString() != "")
                    {
                        info.M_Moblie = dr["M_Moblie"].ToString();
                    }
                    else
                    {
                        info.M_Moblie = "";
                    }

                    if (dr["M_PHMa"].ToString() != "")
                    {
                        info.M_PHMa = dr["M_PHMa"].ToString();
                    }
                    else
                    {
                        info.M_PHMa = "";
                    }
                    if (dr["M_RecverType"].ToString() != "")
                    {
                        info.M_RecverType = dr["M_RecverType"].ToString();
                    }
                    else
                    {
                        info.M_RecverType = "";
                    }
                    if (dr["M_Restore"].ToString() != "")
                    {
                        if (Convert.ToBoolean(dr["M_Restore"].ToString().ToLower()) == true)
                        {
                            info.M_Restore = true;
                        }
                        else
                        {
                            info.M_Restore = false;
                        }
                    }
                    else
                    {
                        info.M_Restore = false;
                    }
                    if (dr["M_SenderType"].ToString() != "")
                    {
                        info.M_SenderType = dr["M_SenderType"].ToString();
                    }
                    else
                    {
                        info.M_SenderType = "";
                    }

                    if (dr["M_Sex"].ToString() != "")
                    {
                        if (Convert.ToBoolean(dr["M_Sex"].ToString().ToLower()) == true)
                        {
                            info.M_Sex = true;
                        }
                        else
                        {
                            info.M_Sex = false;
                        }
                    }
                    else
                    {
                        info.M_Sex = false;
                    }
                    if (dr["M_Title"].ToString() != "")
                    {
                        info.M_Title = dr["M_Title"].ToString();
                    }
                    else
                    {
                        info.M_Title = "";
                    }
                    if (dr["M_UserName"].ToString() != "")
                    {
                        info.M_UserName = dr["M_UserName"].ToString();
                    }
                    else
                    {
                        info.M_UserName = "";
                    }

                    if (dr["M_UserType"].ToString() != "")
                    {
                        if (Convert.ToBoolean(dr["M_UserType"].ToString().ToLower()) == true)
                        {
                            info.M_UserType = true;
                        }
                        else
                        {
                            info.M_UserType = false;
                        }
                    }
                    else
                    {
                        info.M_UserType = false;
                    }
                    if (dr["U_ID"].ToString() != "")
                    {
                        info.U_ID = Convert.ToInt32(dr["U_ID"].ToString());
                    }
                    else
                    {
                        info.U_ID = 0;
                    }
                    if (dr["UR_ID"].ToString() != "")
                    {
                        info.UR_ID = Convert.ToInt32(dr["UR_ID"].ToString());
                    }
                    else
                    {
                        info.UR_ID = 0;
                    }
                    if (dr["M_AddTime"].ToString() != "")
                    {
                        info.M_AddTime = Convert.ToDateTime(dr["M_AddTime"].ToString());
                    }
                }
            }

            return info;
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="infoId">记录编号</param>
        /// <returns>受影响的行数</returns>
        public int Delete(long infoId)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where M_ID="+infoId),
                new SqlParameter("@strTableName","pl_Message")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }

        /// <summary>
        /// 删除多条记录
        /// </summary>
        /// <param name="ids">记录Id集，多个用逗号隔开</param>
        /// <returns>受影响行数</returns>
        public int Deletes(string ids)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where M_ID in (" + ids +")"),
                new SqlParameter("@strTableName","pl_Message")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }
    }
}
