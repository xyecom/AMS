using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace XYECOM.Business
{
    /// <summary>
    /// �������ӷ���ҵ����
    /// </summary>
    public class FriendLinkSort
    {
        private static readonly XYECOM.SQLServer.FriendLinkSort DAL = new XYECOM.SQLServer.FriendLinkSort();

        #region ���һ�������������
         /// <summary>
         /// �����������������
         /// </summary>
         /// <param name="fs">��������������</param>
         /// <param name="fs_id">�����������������IDֵ</param>
         /// <returns>����,����0��ʾ��ӳɹ�</returns>
        public int Insert(XYECOM.Model.FriendLinkSortInfo fs, out int fs_id)
        {
            return DAL.Insert(fs, out fs_id);
        }
        #endregion

        #region �޸�һ���������������Ϣ
         /// <summary>
         /// �޸�һ���������������Ϣ
         /// </summary>
         /// <param name="fs">Ҫ�޸ĵ���������������</param>
         /// <returns>����,����0��ʾ�޸ĳɹ�</returns>
        public int Update(XYECOM.Model.FriendLinkSortInfo fs)
        {
            return DAL.Update(fs);
        }
        #endregion

        #region ɾ��ָ�����������������Ϣ
         /// <summary>
         /// ɾ��ָ�����������������Ϣ
         /// </summary>
         /// <param name="fs_ids">Ҫɾ���������������ID��</param>
         /// <returns>���֣�����0��ɾ���ɹ�</returns>
        public int Delete(string fs_ids)
        {
            return DAL.Delete(fs_ids);
        }
        #endregion

        /// <summary>
        /// �õ������������ӷ���
        /// </summary>
        /// <returns>�����������ӷ���</returns>
        public List<Model.FriendLinkSortInfo> GetItems()
        {
            return DAL.GetItems();
        }
         
        #region ���ָ����������������DataTable
        /// <summary>
        /// �õ�����������DataTable���͵��������������Ϣ
        /// </summary>
        /// <param name="strWhere">�����������������Ϣ��Where����</param>
        /// <param name="strOrderBy">�����������������Ϣ��OrderBy����</param>
        /// <returns>DataTable���͵������ѯ�������������������Ϣ</returns>
        public DataTable GetDataTable(string strWhere, string strOrderBy)
        {
            return DAL.GetDataTable(strWhere, strOrderBy);
        }
        #endregion

        #region ����ID�жϸ���������Ƿ��������
        /// <summary>
        /// ����ָ��IDֵ�жϸ���������Ǹ����������
        /// </summary>
        /// <param name="fs_ids">ָ�������IDֵ</param>
        /// <returns>����,����0���������,������������</returns>
        public int GetSonType(string fs_ids)
        {
            return DAL.GetSonType(fs_ids);
        }
        #endregion

        #region ���������������ID��ȡ����������������
        /// <summary>
        /// ���������������ID��ȡ����������������
         /// </summary>
         /// <param name="fsid">Ҫ��ȡ��������������ID</param>
         /// <returns>������������������</returns>
        public string GetFriendLinkName(int fsid)
        {
            return DAL.GetFriendLinkName(fsid);
        }
        #endregion
    }
}
