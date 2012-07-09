using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace XYECOM.Business
{
    /// <summary>
    /// ��Ƹ��λҵ���߼���
    /// </summary>
    public class Post
    {
        private static readonly XYECOM.SQLServer.Post DAL = new XYECOM.SQLServer.Post();

        /// <summary>
        /// ��Ӹ�λ��Ϣ
        /// </summary>
        /// <param name="enp">��λ��Ϣ���������</param>
        /// <returns>��Ӱ�������</returns>
        public int Insert(XYECOM.Model.PostInfo enp)
        {
            return DAL.Insert(enp);
        }

        /// <summary>
        /// �޸ĸ�λ��Ϣ
        /// </summary>
        /// <param name="enp">��λ��Ϣ���������</param>
        /// <returns>��Ӱ�������</returns>
        public int Update(XYECOM.Model.PostInfo enp)
        {
            return DAL.Update(enp);
        }

        /// <summary>
        /// ɾ����λ��Ϣ
        /// </summary>
        /// <param name="P_ID">��λ���</param>
        /// <returns>��Ӱ�������</returns>
        public int Delete(int P_ID)
        {
            return DAL.Delete(P_ID);
        }

        /// <summary>
        /// ɾ�������Ƹ��λ��Ϣ
        /// </summary>
        /// <param name="P_IDs">��Ƹ��λ��ż���</param>
        /// <returns>Ӱ������</returns>
        public int Delete(string P_IDs)
        {
            return DAL.Delete(P_IDs);
        }

        /// <summary>
        /// ��ȡָ����λ��Ϣ
        /// </summary>
        /// <param name="P_ID">��λ��Ϣ���</param>
        /// <returns>��λ��Ϣ���������</returns>
        public XYECOM.Model.PostInfo GetItem(int P_ID)
        {
            return DAL.GetItem(P_ID);
            
        }

        /// <summary>
        /// ���ݸ���Id�õ���Ƹ��λ����Ϣ
        /// </summary>
        /// <param name="P_ParentID">����Id</param>
        /// <returns>��Ƹ��λ����Ϣ</returns>
        public DataTable GetDataTableForParentID(int P_ParentID)
        {
            return DAL.GetDataTableForParentID(P_ParentID);
        }

        /// <summary>
        /// ������Ƹ��λ���id�õ���Ƹ��λ��Ϣ
        /// </summary>
        /// <param name="P_ID">��Ƹ��λ���Id</param>
        /// <returns>��Ƹ��λ��Ϣ</returns>
        public DataTable GetDataTable(int P_ID)
        {
            return DAL.GetDataTable(P_ID);
        }

        /// <summary>
        /// ������Ƹ��λ��ŵļ��ϵõ���Ƹ��λ����Ϣ
        /// </summary>
        /// <param name="P_IDs">��Ƹ��λ��ż���</param>
        /// <returns>��Ƹ��λ��Ϣ</returns>
        public DataTable GetDataTable(string P_IDs)
        {
            return DAL.GetDataTable(P_IDs);
        }
    }
}
