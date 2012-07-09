using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace XYECOM.Business
{
    /// <summary>
    /// ��������ҵ����
    /// </summary>
    public class FriendLink
    {
        private static readonly XYECOM.SQLServer.FriendLink DAL = new XYECOM.SQLServer.FriendLink();

        #region �����������
        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="efl">�����������������</param>
        /// <returns>���֡����ڵ���0��ʾ��ӳɹ�</returns>
        public int Insert(XYECOM.Model.FriendLinkInfo efl,out short FL_ID)
        {
            return DAL.Insert(efl, out FL_ID);
        }
        #endregion

        #region �޸���������
        /// <summary>
        /// �޸���������
        /// </summary>
        /// <param name="efl">�����������������</param>
        /// <returns>���֡����ڵ���0��ʾ�޸ĳɹ�</returns>
        public int Update(XYECOM.Model.FriendLinkInfo efl)
        {
            return DAL.Update(efl);
        }
        /// <summary>
        /// �޸����������Ƽ�״̬
        /// </summary>
        /// <param name="FL_ID">�������ӱ��</param>
        /// <param name="FL_Flag">�Ƽ�״̬</param>
        /// <returns>���֡����ڵ���0��ʾ�޸ĳɹ�</returns>
        public int UpdateForFlag(short FL_ID, bool FL_Flag)
        {
            return DAL.UpdateForFlag(FL_ID,FL_Flag);
        }
        /// <summary>
        /// �޸��Ƽ�
        /// </summary>
        /// <param name="FL_ID">�������ӱ��</param>
        /// <param name="isCommend">�Ƿ��Ƽ�</param>
        /// <returns>Ӱ������</returns>
        public int UpdateIsCommend(short FL_ID, bool isCommend)
        {
            return DAL.UpdateIsCommend(FL_ID, isCommend);
        }

        #endregion

        #region ɾ����������
        /// <summary>
        /// ɾ����������
        /// </summary>
        /// <param name="FL_IDs">�������ӱ���ַ���</param>
        /// <returns>���֡����ڵ���0��ʾɾ���ɹ�</returns>
        public int Delete(string FL_IDs)
        {
            return DAL.Delete(FL_IDs);
        }
        #endregion

        #region ��ȡ��������
        /// <summary>
        /// ��ȡ�ƶ���������
        /// </summary>
        /// <param name="FL_ID">�������ӱ��</param>
        /// <returns>�����������������</returns>
        public XYECOM.Model.FriendLinkInfo GetItem(short FL_ID)
        {
            return DAL.GetItem(FL_ID);
        }
        /// <summary>
        /// ��ȡ������������������
        /// </summary>
        /// <param name="strWhere">��ѯ����</param>
        /// <param name="strOrderBy">����</param>
        /// <returns>���������������ӵ���Ϣ</returns>
        public DataTable GetDataTable(string strWhere,string strOrderBy)
        {
            return DAL.GetDataTable(strWhere,strOrderBy);
        }
        #endregion
    }
}
