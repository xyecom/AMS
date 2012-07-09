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
    /// 资讯数据处理类
    /// </summary>
    public class News
    {
        #region 添加新闻

        /// <summary>
        /// 添加新闻
        /// </summary>
        /// <param name="info">实体类news</param>
        /// <param name="lastNewsId">所添加新闻的ID</param>
        /// <returns>数字，大于或等于0表示添加成功</returns>
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

        #region 修改新闻信息
        /// <summary>
        /// 更新新闻新闻
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>数字，大于或等于0表示修改成功</returns>
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

        #region 获取一条新闻信息
        /// <summary>
        /// 根据指定的ID获得对应的一条新闻记录
        /// </summary>
        /// <param name="nsid">指定的新闻ID值</param>
        /// <returns>对应的该新闻记录</returns>
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
                    //设置附件信息
                    //Attachment.SetAttachmentInfo(info, reader);
                }
            }

            return info;
        }
        #endregion

        #region 获得定制的新闻信息
        /// <summary>
        /// 获得定制的新闻信息
        /// </summary>
        /// <param name="colums">列名</param>
        /// <param name="where">条件</param>
        /// <param name="order">排序</param>
        /// <param name="topNumber">记录条数</param>
        /// <returns></returns>
        public DataTable ExecuteTable(string colums, string where, string order, int topNumber)
        {
            return Utils.ExecuteTable("XYV_News", colums, where, order, topNumber);
        }
        #endregion

        #region 删除指定的新闻信息
        /// <summary>
        /// 删除指定ID的新闻信息
        /// </summary>
        /// <param name="ns_ids"0>所要删除的新闻信息的ID</param>
        /// <returns>数字，大于或等于0表示删除成功</returns>
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
        /// 对指定的新闻信息修改推荐状态
        /// </summary>
        /// <param name="ns_id">指定ID的新闻信息</param>
        /// <param name="ns_command">要更改的推荐状态</param>
        /// <returns>数字，大于或者等于0表示修改成功</returns>
        public int UpdateForCommand(Int64 ns_id, bool ns_command)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@NS_ID",ns_id),
                new SqlParameter("@NS_IsCommand",ns_command)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateNewsForCommend", param);
        }

        #region 获取新闻标题
        /// <summary>
        /// 获取新闻标题
        /// </summary>
        /// <param name="nsid">新闻编号</param>
        /// <returns>该编号的新闻标题</returns>
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

        #region 批量移动
        /// <summary>
        /// 批量移动
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
        /// 获取统计数据
        /// </summary>
        /// <param name="nt_id">栏目Id</param>
        /// <param name="um_id">管理员Id</param>
        /// <param name="state">状态</param>
        /// <param name="bgtime">开始时间</param>
        /// <param name="egtime">结束时间</param>
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
        /// 获取统计数据
        /// </summary>
        /// <param name="nt_id">栏目Id</param>
        /// <param name="state">状态</param>
        /// <param name="bgtime">开始时间</param>
        /// <param name="egtime">结束时间</param>
        /// <param name="AreaIds">地区Id列表</param>
        /// <param name="TradeIds">行业Id列表</param>
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
