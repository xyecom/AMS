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
    /// 意见反馈数据处理类
    /// </summary>
    public class Feedback
    {
        /// <summary>
        /// 插入意见反馈的数据
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int Insert(XYECOM.Model.FeedbackInfo info)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@Type",info.Type),
                new SqlParameter("@Title",info.Title),
                new SqlParameter("@Name",info.Name),
                new SqlParameter("@telephone",info.Telephone),
                new SqlParameter("@Email",info.Email),
                new SqlParameter("@Centent",info.Centent),
                new SqlParameter("@addtime",info.Addtime),
                new SqlParameter("@ComplaintId",info.ComplaintId),
                new SqlParameter("@DefendantId",info.DefendantId),
                new SqlParameter("@InfoFlag",info.InfoFlag),
                new SqlParameter("@InfoId",info.InfoId),
                new SqlParameter("@IsAdminAgree",info.IsAdminAgree),
            };
            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertFeedback", parm);
        }

        #region 按条件查询意见反馈信息

        /// <summary>
        /// 按指定条件获取数据
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns>表对象</returns>
        public DataTable GetDataTable(string strWhere)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere",strWhere),
                new SqlParameter("@strTableName","XY_Feedback"),
                new SqlParameter("@strOrder","")
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "XYP_SelectByWhere", param);
        }

        /// <summary>
        /// 获取数据对象
        /// </summary>
        /// <param name="FeedbackID">信息Id</param>
        /// <returns>实体对象</returns>
        public Model.FeedbackInfo GetItem(long FeedbackID)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," where FeedbackID="+FeedbackID.ToString ()),
                new SqlParameter("@strTableName","XY_Feedback"),
                new SqlParameter("@strOrder","")
            };
            XYECOM.Model.FeedbackInfo info = null;
            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (reader.Read())
                {
                    info = new XYECOM.Model.FeedbackInfo();
                    info.FeedbackID = Core.MyConvert.GetInt64(reader["FeedbackID"].ToString());
                    info.Type = Convert.ToInt32(reader["Type"].ToString());
                    info.Title = reader["Title"].ToString();
                    info.Name = reader["Name"].ToString();
                    info.Telephone = reader["telephone"].ToString();
                    info.Email = reader["Email"].ToString();
                    info.Centent = reader["Centent"].ToString();
                    info.Addtime = reader["addtime"].ToString();
                    info.ComplaintId = Convert.ToInt32(reader["ComplaintId"].ToString());
                    info.DefendantId = Convert.ToInt32(reader["DefendantId"].ToString());
                    info.InfoFlag = Convert.ToInt32(reader["InfoFlag"].ToString());
                    info.InfoId = Convert.ToInt32(reader["InfoId"].ToString());
                    info.IsAdminAgree = Convert.ToInt32(reader["IsAdminAgree"].ToString());
                }
            }
            return info;
        }
        #endregion

        #region 删除反馈意见
        /// <summary>
        /// 删除反馈意见的数据
        /// </summary>
        /// <param name="FeedbackID">信息Id</param>
        /// <returns>受影响行数</returns>
        public int Delete(string FeedbackID)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where FeedbackID in ("+FeedbackID+")"),
                new SqlParameter("@strTableName","XY_Feedback")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }
        #endregion

        #region 更新反馈意见
        public int UpdateFeedBackById(int Id, int IsAdminAgree)
        {
            string sql = "update XY_Feedback set IsAdminAgree=" + IsAdminAgree + " where FeedbackID=" + Id;
            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(sql);
        }
        #endregion
    }
}
