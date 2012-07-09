using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Business
{
    public class Utils
    {
        /// <summary>
        /// ��־��¼
        /// </summary>
        /// <param name="ex"></param>
        public static void WriteLog(Exception ex)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("Error");
            log.Error("", ex);
        }

        #region �ʼ��������
        /// <summary>
        /// �����ʼ���Ĭ������ΪHTML�ı�
        /// </summary>
        /// <param name="toMails">�����ʼ��б�</param>
        /// <param name="body">�ʼ�����</param>
        /// <param name="title">����</param>
        /// <returns>true�����ͳɹ���false������ʧ��</returns>
        public static bool SendMail(string toMails, string title, string body)
        {
            return SendMail(toMails, title,body, true, null);
        }

        /// <summary>
        /// �����ʼ�
        /// </summary>
        /// <param name="toMails">�������ʼ��б�</param>
        /// <param name="body">�ʼ�����</param>
        /// <param name="title">����</param>
        /// <param name="isHtml">�����Ƿ�ΪHTML��ʽ</param>
        /// <param name="attachment">����</param>
        /// <returns>true�����ͳɹ���false������ʧ��</returns>
        public static bool SendMail(string toMails, string title, string body, bool isHtml, System.Net.Mail.Attachment attachment)
        {
            XYECOM.Core.Web.MailServerInfo mailServerInfo = null;

            XYECOM.Configuration.WebInfo webInfo = XYECOM.Configuration.WebInfo.Instance;

            if (webInfo!=null)
            {
                mailServerInfo                  = new XYECOM.Core.Web.MailServerInfo();
                mailServerInfo.Email            = webInfo.Email; 
                mailServerInfo.MailServerName   = webInfo.EmailServer; 
                mailServerInfo.UserLoginName    = webInfo.EmailLoginName; 
                mailServerInfo.Password         = webInfo.EmailPwd; 
                mailServerInfo.DisplayName      = webInfo.WebName;
                mailServerInfo.MailServerPort = webInfo.EmailServerPort;
            }

            if (mailServerInfo == null)
            {
                WriteLog(new Exception("�ʼ�����ʧ�ܣ��ʼ�������δ���ã�"));
                return false;
            }

            bool result = false;
            try
            {
                result = XYECOM.Core.Web.WebUtil.SendMail(toMails, body, title, isHtml, attachment, mailServerInfo);
            }
            catch (Exception ex)
            {
                WriteLog(ex);
            }

            return result;
        }
        #endregion 

        /// <summary>
        /// ��ȡ��ҳ����
        /// </summary>
        /// <param name="tableName">�����ͼ��</param>
        /// <param name="primaryKey">����</param>
        /// <param name="fieldNames">��ȡ�ֶ��б�</param>
        /// <param name="orderFields">�����ֶ��б�(֧�ֶ��,eg. field1 desc,field2 asc)</param>
        /// <param name="where">����</param>
        /// <param name="pageSize">��ǰҳ</param>
        /// <param name="pageIndex">ÿҳ����</param>
        /// <param name="totalRecord">�ܼ�¼����</param>
        /// <returns></returns>
        public static System.Data.DataTable GetPaginationData(string tableName, string primaryKey, string fieldNames, string orderFields, string where, int pageSize, int pageIndex, out int totalRecord)
        {
            return XYECOM.SQLServer.Utils.GetPaginationData(tableName.Trim(),primaryKey, fieldNames,orderFields,where, pageSize, pageIndex, out totalRecord);
        }

        /// <summary>
        /// �����ƶ���������������
        /// </summary>
        /// <param name="tableName">����</param>
        /// <param name="primaryKey">����</param>
        /// <param name="where">����</param>
        /// <returns></returns>
        public static int GetTotalRecotd(string tableName, string primaryKey, string where)
        {
            return XYECOM.SQLServer.Utils.GetTotalRecotd(tableName, primaryKey, where);
        }

        /// <summary>
        /// ��ȡ����Ƶ����ѯ����
        /// </summary>
        /// <param name="selectChanneId">��ǰѡ�е���ĿId</param>
        /// <returns></returns>
        public static string GetNewsChannelQueryWhere(int selectChanneId)
        {
            if (selectChanneId <= 0) return "";

            string[] subIds = XYECOM.Business.XYClass.GetSubIds("news", selectChanneId).Split(',');

            string strWhere = "";
            foreach (string s in subIds)
            {
                if (strWhere.Equals(""))
                    strWhere += " charindex('," + s + ",',nt_id)>0";
                else
                    strWhere += " or charindex('," + s + ",',nt_id)>0";
            }

            return strWhere;
        }

        /// <summary>
        /// ���ر����ʽ������
        /// </summary>
        /// <param name="tableName">�����ͼ��</param>
        /// <param name="colums">����</param>
        /// <param name="where">����</param>
        /// <param name="order">�����ֶ�</param>
        /// <param name="topNumber">top</param>
        /// <returns></returns>
        public static System.Data.DataTable ExecuteTable(string tableName,string colums,string where,string order,int topNumber)
        {
            return XYECOM.SQLServer.Utils.ExecuteTable(tableName, colums, where, order, topNumber);
        }

        public static string GetFullid(string ename, string id)
        {
            if (string.IsNullOrEmpty(ename))
                return "";
            return XYECOM.SQLServer.Utils.GetFullid(ename, id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName">��������ͼ��</param>
        /// <param name="columns">��ȡ����</param>
        /// <param name="p_3">����</param>
        /// <returns></returns>
        public static System.Data.DataTable ExecuteTable(string tableName, string columns, string where)
        {
            return XYECOM.SQLServer.Utils.ExecuteTable(tableName, columns, where);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="p_2"></param>
        /// <param name="p_3"></param>
        /// <param name="p_4"></param>
        public static void UpdateColumuByWhere(string p, string p_2, string p_3, string p_4)
        {
            XYECOM.SQLServer.Utils.UpdateColumuByWhere(p, p_2, p_3, p_4);
        }
    }
}
