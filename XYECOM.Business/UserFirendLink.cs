using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace XYECOM.Business
{
    /// <summary>
    /// ��������ҵ����
    /// </summary>
    public class UserFirendLink
    {
        private static readonly XYECOM.SQLServer.UserFirendLink DAL = new XYECOM.SQLServer.UserFirendLink();

        #region �����������
        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="efl">�����������������</param>
        /// <returns>���֡����ڵ���0��ʾ��ӳɹ�</returns>
        public int Insert(XYECOM.Model.UserFirendLinkinfo info)
        {
            if (info != null) return DAL.Insert(info);
            else return -1;               
        }
        #endregion

        #region �޸���������
        /// <summary>
        /// �޸���������
        /// </summary>
        /// <param name="efl">�����������������</param>
        /// <returns>���֡����ڵ���0��ʾ�޸ĳɹ�</returns>
        public int Update(XYECOM.Model.UserFirendLinkinfo info)
        {
            if (info != null) return DAL.Update(info);
            else return -1; 
        }

        #endregion

        #region ɾ����������
        /// <summary>
        /// ɾ����������
        /// </summary>
        /// <param name="FL_IDs">�������ӱ���ַ���</param>
        /// <returns>���֡����ڵ���0��ʾɾ���ɹ�</returns>
        public int Delete(string UFL_IDs)
        {
            if (UFL_IDs != null) return DAL.Delete(UFL_IDs);
            else return -1; 
        }
        #endregion

        #region ��ȡ��������
        /// <summary>
        /// ��ȡ�ƶ���������
        /// </summary>
        /// <param name="FL_ID">�������ӱ��</param>
        /// <returns>�����������������</returns>
        public XYECOM.Model.UserFirendLinkinfo GetItem(long UserID)
        {
            if (UserID <= 0) return null;

            return DAL.GetItem(UserID);
        }

        /// <summary>
        /// ��ȡһ������������Ϣ
        /// </summary>
        /// <param name="linkid">�������ӱ��Id</param>
        /// <returns>ʵ�����</returns>
        public XYECOM.Model.UserFirendLinkinfo GetItem(int linkid)
        {
            if (linkid <= 0) return null;

            return DAL.GetItem(linkid);
        }

        /// <summary>
        /// ��ȡĳһ�û�����������Ϣ
        /// </summary>
        /// <param name="userId">�û����Id</param>
        /// <returns>ĳһ�û�����������Ϣ</returns>
        public DataTable GetDataTable(long userId)
        {
            if (userId <= 0) return new DataTable();

            return DAL.GetDataTable(userId);
        }
        #endregion

    }
}
    


