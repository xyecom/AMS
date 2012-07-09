using System;
using System.Collections.Generic;
using System.Text;

using System.Data;


namespace XYECOM.Business
{
    /// <summary>
    /// ����ҵ����
    /// </summary>
    public class News
    {
        private static readonly XYECOM.SQLServer.News DAL = new XYECOM.SQLServer.News();

        #region �������
          /// <summary>
          /// �������
          /// </summary>
          /// <param name="ns">ʵ����news</param>
          /// <param name="ns_id">��������ŵ�IDֵ</param>
        /// <returns>���֣����ڻ����0��ʾ��ӳɹ�</returns>
        public int Insert(XYECOM.Model.NewsInfo ns, out Int64 ns_id)
        {
            return DAL.Insert(ns, out ns_id);
        }
        #endregion

        #region �޸�������Ϣ
          /// <summary>
          /// �޸���������
          /// </summary>
          /// <param name="ns">ʵ����NewsInfo</param>
          /// <returns>���֣����ڻ����0��ʾ�޸ĳɹ�</returns>
        public int Update(XYECOM.Model.NewsInfo info)
        {
            if (info == null) return 0;

            return DAL.Update(info);
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
            if (newsId <= 0) return null;

            return DAL.GetItem(newsId);
        }
        #endregion

        #region ɾ��ָ����������Ϣ
          /// <summary>
          /// ɾ��ָ��ID��������Ϣ
          /// </summary>
          /// <param name="ns_ids"0>��Ҫɾ����������Ϣ��ID</param>
          /// <returns>���֣����ڻ����0��ʾɾ���ɹ�</returns>
        public int Delete(string newsIds)
        {
            new XYECOM.Business.Attachment().Delete(newsIds, XYECOM.Model.AttachmentItem.News, XYECOM.Model.UploadFileType.All);

            return DAL.Delete(newsIds);
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
            return DAL.UpdateForCommand(ns_id, ns_command);
        }


        /// <summary>
        /// ��ȡ���ű���
        /// </summary>
        /// <param name="nsid">���ű��</param>
        /// <returns>�ñ�ŵ����ű���</returns>
        public string GetNewsName(Int64 nsid)
        {
            return DAL.GetNewsName(nsid);
        }

        /// <summary>
        /// ��ȡ�������
        /// </summary>
        /// <param name="newsID">����ID</param>
        /// <param name="topNumber">��ȡ��������</param>
        /// <returns>��������������</returns>
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
        /// ����ת����Ϣ
        /// </summary>
        /// <param name="strwhere">����</param>
        /// <param name="content">Ԥ������ŵ������</param>
        /// <returns>Ӱ������</returns>
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
