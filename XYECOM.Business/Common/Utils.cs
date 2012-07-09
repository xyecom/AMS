using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Business
{
    public class Utils
    {
        /// <summary>
        /// 日志记录
        /// </summary>
        /// <param name="ex"></param>
        public static void WriteLog(Exception ex)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("Error");
            log.Error("", ex);
        }

        #region 邮件发送相关
        /// <summary>
        /// 发送邮件，默认内容为HTML文本
        /// </summary>
        /// <param name="toMails">发送邮件列表</param>
        /// <param name="body">邮件主体</param>
        /// <param name="title">标题</param>
        /// <returns>true：发送成功，false：发送失败</returns>
        public static bool SendMail(string toMails, string title, string body)
        {
            return SendMail(toMails, title,body, true, null);
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="toMails">接收着邮件列表</param>
        /// <param name="body">邮件主体</param>
        /// <param name="title">标题</param>
        /// <param name="isHtml">内容是否为HTML格式</param>
        /// <param name="attachment">附件</param>
        /// <returns>true：发送成功，false：发送失败</returns>
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
                WriteLog(new Exception("邮件发送失败！邮件服务器未设置！"));
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
        /// 获取分页数据
        /// </summary>
        /// <param name="tableName">表或视图名</param>
        /// <param name="primaryKey">主键</param>
        /// <param name="fieldNames">读取字段列表</param>
        /// <param name="orderFields">排序字段列表(支持多个,eg. field1 desc,field2 asc)</param>
        /// <param name="where">条件</param>
        /// <param name="pageSize">当前页</param>
        /// <param name="pageIndex">每页条数</param>
        /// <param name="totalRecord">总记录条数</param>
        /// <returns></returns>
        public static System.Data.DataTable GetPaginationData(string tableName, string primaryKey, string fieldNames, string orderFields, string where, int pageSize, int pageIndex, out int totalRecord)
        {
            return XYECOM.SQLServer.Utils.GetPaginationData(tableName.Trim(),primaryKey, fieldNames,orderFields,where, pageSize, pageIndex, out totalRecord);
        }

        /// <summary>
        /// 返回制定条件的数据条数
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="primaryKey">主健</param>
        /// <param name="where">条件</param>
        /// <returns></returns>
        public static int GetTotalRecotd(string tableName, string primaryKey, string where)
        {
            return XYECOM.SQLServer.Utils.GetTotalRecotd(tableName, primaryKey, where);
        }

        /// <summary>
        /// 获取新闻频道查询条件
        /// </summary>
        /// <param name="selectChanneId">当前选中的栏目Id</param>
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
        /// 返回表格形式的数据
        /// </summary>
        /// <param name="tableName">表或视图名</param>
        /// <param name="colums">列名</param>
        /// <param name="where">条件</param>
        /// <param name="order">排序字段</param>
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
        /// <param name="tableName">表名或视图名</param>
        /// <param name="columns">获取的列</param>
        /// <param name="p_3">条件</param>
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
