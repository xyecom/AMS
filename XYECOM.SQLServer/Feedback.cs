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
    /// ����������ݴ�����
    /// </summary>
    public class Feedback
    {
        /// <summary>
        /// �����������������
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

        #region ��������ѯ���������Ϣ

        /// <summary>
        /// ��ָ��������ȡ����
        /// </summary>
        /// <param name="strWhere">����</param>
        /// <returns>�����</returns>
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
        /// ��ȡ���ݶ���
        /// </summary>
        /// <param name="FeedbackID">��ϢId</param>
        /// <returns>ʵ�����</returns>
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

        #region ɾ���������
        /// <summary>
        /// ɾ���������������
        /// </summary>
        /// <param name="FeedbackID">��ϢId</param>
        /// <returns>��Ӱ������</returns>
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

        #region ���·������
        public int UpdateFeedBackById(int Id, int IsAdminAgree)
        {
            string sql = "update XY_Feedback set IsAdminAgree=" + IsAdminAgree + " where FeedbackID=" + Id;
            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(sql);
        }
        #endregion
    }
}
