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
    /// ��Ѷ���ݴ�����
    /// </summary>
    public class News
    {
        #region �������

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="info">ʵ����news</param>
        /// <param name="lastNewsId">��������ŵ�ID</param>
        /// <returns>���֣����ڻ����0��ʾ��ӳɹ�</returns>
        public int Insert(XYECOM.Model.NewsInfo info, out Int64 lastNewsId)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@NS_ID",SqlDbType.BigInt),
                new SqlParameter("@NS_Type",(int)info.Type),
                new SqlParameter("@NS_NewsName",info.Title),
                new SqlParameter("@NS_TwoName",info.SubTitle),
                new SqlParameter("@NS_TitleStyle",info.TitleStyle),
                new SqlParameter("@NT_ID",info.TypeIds),
                new SqlParameter("@NS_KeyWord",info.Keyword),
                new SqlParameter("@NS_LinkAddress",info.HeadlineNewsUrl),
                new SqlParameter("@NS_PicUrl",info.PicUrl),
                new SqlParameter("@NS_NewsAuthor",info.Author),
                new SqlParameter("@NS_NewsOrigin",info.Origin),
                new SqlParameter("@NS_NewsLess",info.Leadin),
                new SqlParameter("@NS_NewsNote",info.Content),
                new SqlParameter("@NS_AddTime",info.AddTime),
                new SqlParameter("@NS_Count",info.ClickNumber),
                new SqlParameter("@NS_IsCommand",info.IsCommend),
                new SqlParameter("@NS_HTMLPage",info.HTMLPage),
                new SqlParameter("@NS_IsDiscuss",info.IsAllowComment),
                new SqlParameter("@NS_IsTop",info.IsTop),
                new SqlParameter("@NS_IsHot",info.IsHot),
                new SqlParameter("@NS_IsSlide",info.IsSlide),
                new SqlParameter("@TopicType",info.TopicType),
                new SqlParameter("@Contributor",info.Contributor),
                new SqlParameter("@AuditingState",(int)info.State),
                new SqlParameter("@AreaIds",info.AreaIds),
                new SqlParameter("@TradeIds",info.TradeIds),
                new SqlParameter("@UM_ID",info.UM_ID),
                new SqlParameter("@FileUrl",info.FileUrl),
                new SqlParameter("@ProtypeIds",info.ProtypeIds),
                new SqlParameter("@ProIds",info.ProIds),
                new SqlParameter("@IsScheme",info.IsScheme)
                
            };

            param[0].Direction = ParameterDirection.Output;

            int rowAffected = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertNews", param);

            if (param[0].Value.ToString() != null && param[0].Value.ToString() != "")
            {
                lastNewsId = Convert.ToInt64(param[0].Value);
            }
            else
            {
                lastNewsId = -1;
            }

            return rowAffected;
        }
        #endregion

        #region �޸�������Ϣ
        /// <summary>
        /// ������������
        /// </summary>
        /// <param name="info">ʵ�����</param>
        /// <returns>���֣����ڻ����0��ʾ�޸ĳɹ�</returns>
        public int Update(XYECOM.Model.NewsInfo info)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@NS_ID",info.NewsId),
                new SqlParameter("@NS_Type",(int)info.Type),
                new SqlParameter("@NS_NewsName",info.Title),
                new SqlParameter("@NS_TwoName",info.SubTitle),
                new SqlParameter("@NS_TitleStyle",info.TitleStyle),
                new SqlParameter("@NT_ID",info.TypeIds),
                new SqlParameter("@NS_KeyWord",info.Keyword),
                new SqlParameter("@NS_LinkAddress",info.HeadlineNewsUrl),
                new SqlParameter("@NS_PicUrl",info.PicUrl),
                new SqlParameter("@NS_NewsAuthor",info.Author),
                new SqlParameter("@NS_NewsOrigin",info.Origin),
                new SqlParameter("@NS_NewsLess",info.Leadin),
                new SqlParameter("@NS_NewsNote",info.Content),
                new SqlParameter("@NS_AddTime",info.AddTime),
                new SqlParameter("@NS_Count",info.ClickNumber),
                new SqlParameter("@NS_IsCommand",info.IsCommend),
                new SqlParameter("@NS_HTMLPage",info.HTMLPage),
                new SqlParameter("@NS_IsDiscuss",info.IsAllowComment),
                new SqlParameter("@NS_IsTop",info.IsTop),
                new SqlParameter("@NS_IsHot",info.IsHot),
                new SqlParameter("@NS_IsSlide",info.IsSlide),
                new SqlParameter("@TopicType",info.TopicType),
                new SqlParameter("@Contributor",info.Contributor),
                new SqlParameter("@AuditingState",(int)info.State),
                new SqlParameter("@AreaIds",info.AreaIds),
                new SqlParameter("@TradeIds",info.TradeIds),
                new SqlParameter("@FileUrl",info.FileUrl),
                new SqlParameter("@ProtypeIds",info.ProtypeIds),
                new SqlParameter("@ProIds",info.ProIds),
                new SqlParameter("@IsScheme",info.IsScheme)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateNews", param);
        }
        #endregion

        #region ��ȡһ��������Ϣ
        /// <summary>
        /// ����ָ����ID��ö�Ӧ��һ�����ż�¼
        /// </summary>
        /// <param name="nsid">ָ��������IDֵ</param>
        /// <returns>��Ӧ�ĸ����ż�¼</returns>
        public XYECOM.Model.NewsInfo GetItem(long newsId)
        {
            SqlParameter[] parm = new SqlParameter[] 
            {
                new SqlParameter("@strWhere"," Where NS_ID="+newsId.ToString()),
                new SqlParameter("@strTableName","xyv_News"),
                new SqlParameter("@strOrder","")
            };

            XYECOM.Model.NewsInfo info = null;

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", parm))
            {
                if (reader.Read())
                {
                    info = new XYECOM.Model.NewsInfo();
                    info.NewsId = int.Parse(reader["NS_ID"].ToString());

                    info.Type = XYECOM.Model.NewsType.TextNews;

                    string newsType = reader["NS_Type"].ToString();
                    if (newsType.Equals("2"))
                        info.Type = XYECOM.Model.NewsType.ImageNews;
                    if (newsType.Equals("3"))
                        info.Type = XYECOM.Model.NewsType.HeadlineNews;

                    info.Title = reader["NS_NewsName"].ToString();

                    info.SubTitle = reader["NS_TwoName"].ToString();

                    info.TitleStyle = reader["NS_TitleStyle"].ToString();

                    info.TypeIds = reader["NT_ID"].ToString();

                    info.Keyword = reader["NS_KeyWord"].ToString();
                    info.Leadin = reader["NS_NewsLess"].ToString();
                    info.HeadlineNewsUrl = reader["NS_LinkAddress"].ToString();
                    info.PicUrl = reader["NS_PicUrl"].ToString();
                    info.Author = reader["NS_NewsAuthor"].ToString();
                    info.Origin = reader["NS_NewsOrigin"].ToString();

                    info.AddTime = reader["NS_AddTime"].ToString();

                    info.ClickNumber = XYECOM.Core.MyConvert.GetInt32(reader["NS_Count"].ToString());

                    info.Content = reader["NS_NewsNote"].ToString();

                    if (reader["AuditingState"].ToString() != "")
                    {
                        if (reader["AuditingState"].ToString().Equals("1"))
                            info.State = XYECOM.Model.AuditingState.Passed;
                        else
                            info.State = XYECOM.Model.AuditingState.NoPass;
                    }
                    else
                    {
                        info.State = XYECOM.Model.AuditingState.Null;
                    }


                    info.IsCommend = Convert.ToBoolean(reader["NS_IsCommand"].ToString());

                    info.HTMLPage = reader["NS_HTMLPage"].ToString();

                    info.IsAllowComment = Convert.ToBoolean(reader["NS_IsDiscuss"].ToString());

                    info.IsTop = Convert.ToBoolean(reader["NS_IsTop"].ToString());

                    info.IsHot = Convert.ToBoolean(reader["NS_IsHot"].ToString());

                    info.IsSlide = Convert.ToBoolean(reader["NS_IsSlide"].ToString());

                    info.TopicType = reader["TopicType"].ToString();

                    info.ChargeState = reader["IsChargeNews"].ToString();

                    info.Contributor = Convert.ToInt64(reader["Contributor"].ToString());

                    info.AreaIds = reader["AreaIds"].ToString();

                    info.TradeIds = reader["TradeIds"].ToString();
                    info.FileUrl = reader["FileUrl"].ToString();
                    info.ProtypeIds = reader["ProtypeIds"].ToString();

                    if (reader["ProIds"].ToString() != "")
                    {
                        info.ProIds = reader["ProIds"].ToString();
                    }
                    else
                    {
                        info.ProIds = null; 
                    }
                    info.IsScheme = Convert.ToInt32(reader["IsScheme"].ToString());
                    //���ø�����Ϣ
                    //Attachment.SetAttachmentInfo(info, reader);
                }
            }

            return info;
        }
        #endregion

        #region ��ö��Ƶ�������Ϣ
        /// <summary>
        /// ��ö��Ƶ�������Ϣ
        /// </summary>
        /// <param name="colums">����</param>
        /// <param name="where">����</param>
        /// <param name="order">����</param>
        /// <param name="topNumber">��¼����</param>
        /// <returns></returns>
        public DataTable ExecuteTable(string colums, string where, string order, int topNumber)
        {
            return Utils.ExecuteTable("XYV_News", colums, where, order, topNumber);
        }
        #endregion

        #region ɾ��ָ����������Ϣ
        /// <summary>
        /// ɾ��ָ��ID��������Ϣ
        /// </summary>
        /// <param name="ns_ids"0>��Ҫɾ����������Ϣ��ID</param>
        /// <returns>���֣����ڻ����0��ʾɾ���ɹ�</returns>
        public int Delete(string ns_ids)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere","where NS_ID in ("+ns_ids+")"),
                new SqlParameter("@strTableName","n_News")
            };
            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }
        #endregion

        /// <summary>
        /// ��ָ����������Ϣ�޸��Ƽ�״̬
        /// </summary>
        /// <param name="ns_id">ָ��ID��������Ϣ</param>
        /// <param name="ns_command">Ҫ���ĵ��Ƽ�״̬</param>
        /// <returns>���֣����ڻ��ߵ���0��ʾ�޸ĳɹ�</returns>
        public int UpdateForCommand(Int64 ns_id, bool ns_command)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@NS_ID",ns_id),
                new SqlParameter("@NS_IsCommand",ns_command)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateNewsForCommend", param);
        }

        #region ��ȡ���ű���
        /// <summary>
        /// ��ȡ���ű���
        /// </summary>
        /// <param name="nsid">���ű��</param>
        /// <returns>�ñ�ŵ����ű���</returns>
        public string GetNewsName(Int64 nsid)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere","where NS_ID="+nsid.ToString()),
                new SqlParameter("@strTableName","n_News"),
                new SqlParameter("strOrder","")
            };

            string newsname = "";

            using (SqlDataReader dr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (dr.Read())
                {
                    newsname = dr["NS_NewsName"].ToString();
                }
            }

            return newsname;
        }
        #endregion

        #region �����ƶ�
        /// <summary>
        /// �����ƶ�
        /// </summary>
        /// <returns></returns>
        public int MoveNews(String strwhere, String content)
        {
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@strwhere",strwhere),
                new SqlParameter("@tablename","n_News"),
                new SqlParameter("@content",content)
            };
            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "usp_PublicUpdate", param);
        }

        #endregion


        /// <summary>
        /// ��ȡͳ������
        /// </summary>
        /// <param name="nt_id">��ĿId</param>
        /// <param name="um_id">����ԱId</param>
        /// <param name="state">״̬</param>
        /// <param name="bgtime">��ʼʱ��</param>
        /// <param name="egtime">����ʱ��</param>
        /// <returns></returns>
        public static System.Data.DataTable GetStatisticsData(string nt_id, string um_id, string state, string bgtime, string egtime)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@nt_id",nt_id),
                new SqlParameter("@um_id",um_id),
                new SqlParameter("@state",state),
                new SqlParameter("@bgtime",bgtime),
                new SqlParameter("@egtime",egtime),
            };
            DataTable table = Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "[XYP_Statisticsnews]", param);
            return table;
        }

        /// <summary>
        /// ��ȡͳ������
        /// </summary>
        /// <param name="nt_id">��ĿId</param>
        /// <param name="state">״̬</param>
        /// <param name="bgtime">��ʼʱ��</param>
        /// <param name="egtime">����ʱ��</param>
        /// <param name="AreaIds">����Id�б�</param>
        /// <param name="TradeIds">��ҵId�б�</param>
        /// <returns></returns>
        public static System.Data.DataTable GetStatSendInfo(string nt_id, string state, string bgtime, string egtime, string AreaIds, string TradeIds)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@nt_id",nt_id),
                new SqlParameter("@state",state),
                new SqlParameter("@bgtime",bgtime),
                new SqlParameter("@egtime",egtime),
                new SqlParameter("@AreaIds",AreaIds),
                new SqlParameter("@TradeIds",TradeIds),
            };
            DataTable table = Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "[XYP_StatSendInfo]", param);
            return table;
        }

    }
}
