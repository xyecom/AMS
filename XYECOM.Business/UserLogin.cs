using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace XYECOM.Business
{
    /// <summary>
    /// ��Ա��¼��־ҵ����
    /// </summary>
    public class UserLogin
    {
        private static readonly XYECOM.SQLServer.UserLogin DAL = new XYECOM.SQLServer.UserLogin();

        /// <summary>
        /// ����û���¼��Ϣ
        /// </summary>
        /// <param name="el">ʵ����</param>
        /// <returns>��Ӱ�������</returns>
        //public int InsertOrUpdate(long userId)
        //{
        //    XYECOM.Model.UserLoginInfo userLoginInfo = new XYECOM.Model.UserLoginInfo();
        //    userLoginInfo.UserId = userId;
        //    userLoginInfo.RegIP = XYECOM.Core.XYRequest.GetIP();

        //    return DAL.Insert(userLoginInfo);
        //}

        /// <summary>
        /// ����û���¼��Ϣ
        /// </summary>
        /// <param name="el">ʵ����</param>
        /// <returns>��Ӱ�������</returns>
        public int Insert(long userId, string ip, string Flag)
        {
            XYECOM.Model.UserLoginInfo userLoginInfo = new XYECOM.Model.UserLoginInfo();

            if (Flag == XYECOM.Model.UserLog.Register.ToString())
            {
                userLoginInfo.UserId = userId;
                userLoginInfo.RegIP = ip;
                userLoginInfo.LastLoginIP = ip;

                userLoginInfo.LastLoginDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"); ;
                userLoginInfo.FirstLoginDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"); ;
            }
            else
            {
                userLoginInfo.UserId = userId;
                userLoginInfo.RegIP = "";
                userLoginInfo.LastLoginIP = ip;
                userLoginInfo.LastLoginDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"); ;
                userLoginInfo.FirstLoginDate = "";
            }
            return DAL.Insert(userLoginInfo);
        }

        /// <summary>
        /// ��ȡ�û���¼��Ϣ
        /// </summary>
        /// <param name="userId">�û����Id</param>
        /// <returns>ʵ�����</returns>
        public Model.UserLoginInfo GetItem(long userId)
        {
            if (userId <= 0) return null;

            return DAL.GetItem(userId);
        }


        /// <summary>
        /// ��ȡĳ�û���¼��������Ϣ
        /// </summary>
        /// <param name="U_ID">�û����</param>
        /// <returns>��¼��</returns>
        public DataTable GetDataTable(long U_ID)
        {
            return DAL.GetDataTable(U_ID);
        }

        /// <summary>
        /// ��ȡ�û���¼��Ϣ
        /// </summary>
        /// <param name="U_ID">�û����Id</param>
        /// <param name="dt">��һ�ε�¼ʱ��</param>
        /// <param name="IP">ע��IP</param>
        /// <returns>�û���¼��Ϣ</returns>
        public DataTable GetDataTable(long U_ID, string dt, string IP)
        {
            return DAL.GetDataTable(U_ID, dt, IP);
        }
        /// <summary>
        /// ��ȡĳ�û���¼��½����[��������]
        /// </summary>
        /// <param name="beginDate">��ʼ����[��Ϊ��]</param>
        /// <param name="endDate">��������[��Ϊ��]</param>
        /// <param name="u_id">�û�id[]</param>
        /// <returns>���ص�½����</returns>
        public string GetUserLoginNumByDate(string beginDate, string endDate, string u_id)
        {

            string num = "[�û�ID�쳣]";
            int uid = XYECOM.Core.MyConvert.GetInt32(u_id);
            if (uid > 0)
            {
                string strWhere = " where u_id = " + u_id;

                if (beginDate != "")
                {
                    strWhere += " and (LastLoginDate > '" + beginDate + "') ";
                }
                if (endDate != "")
                {
                    strWhere += " and (LastLoginDate < '" + XYECOM.Core.MyConvert.GetDateTime(endDate).AddDays(1) + "') ";
                }

                num = DAL.GetUserLoginNumByDate(strWhere);
            }
            return num;

        }
        /// <summary>
        /// ��ȡĳ�û���¼��½����[��������]����Ծ������
        /// </summary>
        /// <param name="strWhere">���ϲ�ѯ����</param>
        /// <param name="strWhere2">���ղ�ѯ����</param>
        /// <returns></returns>
        public DataTable GetUserLoginNumsByDate(string where)
        {
            return DAL.GetUserLoginNumsByDate(where);
        }
    }
}
