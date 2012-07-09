using System;
using System.Collections.Generic;
using System.Text;

using System.Data;


namespace XYECOM.Business
{
    /// <summary>
    /// 新闻业务类
    /// </summary>
    public class News
    {
        private static readonly XYECOM.SQLServer.News DAL = new XYECOM.SQLServer.News();

        #region 添加新闻
          /// <summary>
          /// 添加新闻
          /// </summary>
          /// <param name="ns">实体类news</param>
          /// <param name="ns_id">所添加新闻的ID值</param>
        /// <returns>数字，大于或等于0表示添加成功</returns>
        public int Insert(XYECOM.Model.NewsInfo ns, out Int64 ns_id)
        {
            return DAL.Insert(ns, out ns_id);
        }
        #endregion

        #region 修改新闻信息
          /// <summary>
          /// 修改新闻新闻
          /// </summary>
          /// <param name="ns">实体类NewsInfo</param>
          /// <returns>数字，大于或等于0表示修改成功</returns>
        public int Update(XYECOM.Model.NewsInfo info)
        {
            if (info == null) return 0;

            return DAL.Update(info);
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
            if (newsId <= 0) return null;

            return DAL.GetItem(newsId);
        }
        #endregion

        #region 删除指定的新闻信息
          /// <summary>
          /// 删除指定ID的新闻信息
          /// </summary>
          /// <param name="ns_ids"0>所要删除的新闻信息的ID</param>
          /// <returns>数字，大于或等于0表示删除成功</returns>
        public int Delete(string newsIds)
        {
            new XYECOM.Business.Attachment().Delete(newsIds, XYECOM.Model.AttachmentItem.News, XYECOM.Model.UploadFileType.All);

            return DAL.Delete(newsIds);
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
            return DAL.UpdateForCommand(ns_id, ns_command);
        }


        /// <summary>
        /// 获取新闻标题
        /// </summary>
        /// <param name="nsid">新闻编号</param>
        /// <returns>该编号的新闻标题</returns>
        public string GetNewsName(Int64 nsid)
        {
            return DAL.GetNewsName(nsid);
        }

        /// <summary>
        /// 获取相关新闻
        /// </summary>
        /// <param name="newsID">新闻ID</param>
        /// <param name="topNumber">获取几条新闻</param>
        /// <returns>符合条件的新闻</returns>
        public DataTable GetAboutNews(long newsID, int topNumber)
        {
            XYECOM.Model.NewsInfo info = DAL.GetItem(newsID);

            if (info == null) return null;

            string[] keys = info.Keyword.Split(new char[] { ','});

            string where = " (";
            for (int i = 0; i < keys.Length; i++)
            {
                if(i<keys.Length-1)
                    where += " charindex('" + keys[i] + "',ns_newsName) >0 or charindex('" + keys[i] + "',NS_KeyWord) >0 or  ";
                else
                    where += " charindex('" + keys[i] + "',ns_newsName) >0 ";
            }

            where += ") and AuditingState = 1 and ns_id <> " + newsID + " ";

            return DAL.ExecuteTable("nt_id,nt_name,ns_id,ns_newsname,ns_addTime,NS_HTMLPage", where, "ns_id desc", topNumber);
        }

        /// <summary>
        /// 批量转移信息
        /// </summary>
        /// <param name="strwhere">条件</param>
        /// <param name="content">预设改新闻点击次数</param>
        /// <returns>影响行数</returns>
        public int MoveNews(String strwhere, String content)
        {
            return DAL.MoveNews(strwhere, content);
        }



        public static DataTable GetStatSendInfo(string nt_id, string state, string bgtime, string egtime, string AreaIds, string TradeIds)
        {
            return XYECOM.SQLServer.News.GetStatSendInfo(nt_id, state, bgtime, egtime, AreaIds, TradeIds);
        }

        public static DataTable GetStatisticsData(string nt_id, string um_id, string state, string bgtime, string egtime)
        {
            return XYECOM.SQLServer.News.GetStatisticsData(nt_id, um_id, state, bgtime, egtime);
        }
    }
}
