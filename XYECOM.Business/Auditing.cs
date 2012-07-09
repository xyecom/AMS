using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace XYECOM.Business
{
    /// <summary>
    /// ���ҵ����
    /// </summary>
    public class Auditing
    {
        private static readonly XYECOM.SQLServer.Auditing DAL = new XYECOM.SQLServer.Auditing();
        /// <summary>
        /// ��������Ϣ
        /// </summary>
        /// <param name="ea">ʵ����</param>
        /// <returns>��Ӱ�������</returns>
        public int Insert(XYECOM.Model.AuditingInfo info)
        {
            if (info == null) return 0;

            return DAL.Insert(info);
        }

        /// <summary>
        /// �޸������Ϣ
        /// </summary>
        /// <param name="ea">ʵ����</param>
        /// <returns>��Ӱ�������</returns>
        public int Update(XYECOM.Model.AuditingInfo info)
        {
            if (info == null) return 0;

            return DAL.Update(info);
        }

        /// <summary>
        /// ��ȡһ����¼
        /// </summary>
        /// <param name="A_ID">��¼���</param>
        /// <returns>һ����¼</returns>
        public XYECOM.Model.AuditingInfo GetItem(int A_ID)
        {
            return DAL.GetItem (A_ID);
        }

        public XYECOM.Model.AuditingInfo GetItem(string descTabID, string descTabName)
        {
            if (String.IsNullOrEmpty(descTabID) || string.IsNullOrEmpty(descTabName)) return null;

            return DAL.GetItem(descTabID, descTabName);
        }

        /// <summary>
        /// ɾ��һ����¼
        /// </summary>
        /// <param name="A_ID">��¼���</param>
        /// <returns>��Ӱ�������</returns>
        public int Delete(int A_ID)
        {
            if (A_ID <= 0) return 0;

            return DAL.Delete(A_ID);
        }
        /// <summary>
        /// ��ȡ������¼
        /// </summary>
        /// <param name="��_ID">������ѯ</param>
        /// <returns>������¼</returns>
        public DataTable GetDataTable(long DescTabID, string DescTabName)
        {
            return DAL.GetDataTable(DescTabID, DescTabName);
        }


        /// <summary>
        /// �޸����״̬--����
        /// </summary>
        /// <param name="DescTabID">id</param>
        /// <param name="DescTabName">����</param>
        /// <param name="AuditingState">���״̬</param>
        /// <returns>�Ƿ�ɹ�</returns>
        public int UpdatesAuditing(long DescTabID, String DescTabName, XYECOM.Model.AuditingState AuditingState)
        {
            return DAL.UpdatesAuditing(DescTabID, DescTabName, AuditingState);
        }
    }
}
