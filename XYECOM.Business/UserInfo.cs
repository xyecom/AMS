using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace XYECOM.Business
{
    /// <summary>
    /// �û�ҵ����
    /// </summary>
    public class UserInfo
    {
        private static readonly XYECOM.SQLServer.UserInfo DAL = new XYECOM.SQLServer.UserInfo();

        #region ����û�
        /// <summary>
        /// ����û�
        /// </summary>
        /// <param name="eui">ʵ�����</param>
        /// <returns>Ӱ������</returns>
        public int Insert(XYECOM.Model.UserInfo eui)
        {
            return DAL.Insert(eui);
        }
        #endregion

        #region �޸��û���Ϣ
        /// <summary>
        /// �����û���Ϣ
        /// </summary>
        /// <param name="eui">ʵ�����</param>
        /// <returns>Ӱ������</returns>
        public int Update(XYECOM.Model.UserInfo eui)
        {
            return DAL.Update(eui);
        }
        #endregion

        #region ��ȡһ����¼
        /// <summary>
        /// ��ȡһ����¼
        /// </summary>
        /// <param name="userId">�û����Id</param>
        /// <returns>ʵ�����</returns>
        public XYECOM.Model.UserInfo GetItem(long userId)
        {
            if (userId <= 0) return null;

            return DAL.GetItem(userId);
        }
        #endregion

        #region  �����û�����U_ID
        /// <summary>
        /// �����û�����ȡ�û���Ϣ
        /// </summary>
        /// <param name="username">�û�����</param>
        /// <returns>ʵ�����</returns>
        public XYECOM.Model.UserInfo GetItem(string username)
        {
            Model.UserRegInfo regInfo = new Business.UserReg().GetItem(username);

            if (regInfo == null) return null;

            return GetItem(regInfo.UserId);
        }
        #endregion

        #region ɾ���û�
        /// <summary>
        /// ɾ���û�
        /// </summary>
        /// <param name="U_ID">���Id</param>
        /// <returns>Ӱ������</returns>
        public int Delete(string U_ID)
        {
            return DAL.Delete(U_ID);
        }
        #endregion
                
        #region �޸��û��ȼ�ID
        /// <summary>
        /// �޸��û��ȼ�
        /// </summary>
        /// <param name="U_ID">�û����</param>
        /// <param name="UG_ID">�û��ȼ����</param>
        /// <returns>Ӱ������</returns>
        public int UpdateUGID(long U_ID, int UG_ID)
        {
            return DAL.UpdateUGID(U_ID, UG_ID);
        }
        #endregion

        /// <summary>
        /// ��ȡ�û���������Ϣ����
        /// </summary>
        /// <param name="viewname">�����ͼ����</param>
        /// <param name="useridfieldname">�û�Id�ֶ�����</param>
        /// <param name="userid">�û�id</param>
        /// <param name="datefieldname">�����ֶ�����</param>
        /// <param name="startime">��ʼʱ��</param>
        /// <param name="endtime">����ʱ��</param>
        /// <param name="infoidfieldname">��ϢId�ֶ�����</param>
        /// <param name="modulename">ģ������</param>
        /// <returns></returns>
        public int InfoAddNum(String tablename, String useridfieldname, long userid, String datefieldname, String startime, String endtime, String infoidfieldname, String modulename)
        {
            return DAL.InfoAddNum(tablename, useridfieldname, userid, datefieldname, startime, endtime, infoidfieldname, modulename);
        }

        /// <summary>
        /// ר�÷������������ñ�ǩ��Χ
        /// </summary>
        /// <param name="userIds"></param>
        /// <returns></returns>
        public DataTable GetUserNamesByIds(string userIds)
        {
            return DAL.GetUserNamesByIds(userIds);
        }

        /// <summary>
        /// �����û���Ż�ȡ��˾���� ������ӣ�2011-04-15��
        /// </summary>
        /// <param name="uid">�û����</param>
        /// <returns>��˾����</returns>
        public string GetCompNameByUId(int uid)
        {
            if (uid <= 0)
            {
                return string.Empty;
            }
            return DAL.GetCompNameByUId(uid);
        }
    }
}

