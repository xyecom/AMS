using System;
using System.Collections.Generic;

using System.Text;

namespace XYECOM.Service
{
    public class ServiceUtil
    {
        /// <summary>
        /// 日志记录逻辑
        /// </summary>
        /// <param name="ex"></param>
        public static void Error(string message, Exception ex)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("ServiceError");

            log.Error(message, ex);
        }

        public static void Info(string message)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("ServiceError");
            log.Info(message);
        }

        public static void Debug(string message)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("ServiceError");
            log.Debug(message);
        }
        public static void Warn(string message)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("ServiceError");
            log.Warn(message);
        }


        /// <summary>
        /// 发送站内信
        /// </summary>
        /// <param name="Title">标题</param>
        /// <param name="Content">内容</param>
        /// <param name="UserId">收信人</param>
        /// <returns></returns>
        public static int SenMessage(string Title, string Content, int UserId)
        {
            XYECOM.Model.MessageInfo em = new XYECOM.Model.MessageInfo();
            XYECOM.Business.Message m = new Business.Message();
            em.M_Adress = "";
            em.M_CompanyName = "";
            em.M_Email = "";
            em.M_FHM = "";
            em.M_HasReply = false;
            em.M_Moblie = "";
            em.M_PHMa = "";
            em.M_RecverType = "administrator";
            em.M_Restore = false;
            em.M_SenderType = "user";
            em.M_Title = Title;
            em.M_Content = Content;
            em.M_UserName = "";
            em.M_UserType = false;
            em.U_ID = -1;
            em.UR_ID = UserId;

            return m.Insert(em);
        }
    }
}
