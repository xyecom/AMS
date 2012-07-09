using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace XYECOM.Business
{
    /// <summary>
    /// ���λ���ҵ����
    /// </summary>
    public class AdPlaceType
    {
        private static readonly XYECOM.SQLServer.AdPlaceType DAL = new XYECOM.SQLServer.AdPlaceType();
         /// <summary>
         /// ��ӹ��λ���
         /// </summary>
         /// <param name="at">���λ���ʵ����</param>
         /// <param name="at_id">�����ʵ�����IDֵ</param>
         /// <returns>����,����0��ʾ��ӳɹ�</returns>
        public int Insert(XYECOM.Model.AdPlaceTypeInfo at, out int at_id)
        {
            return DAL.Insert(at,out at_id);
        }        

        #region �޸�ָ�����λ�����Ϣ
         /// <summary>
         /// �޸�ָ�����λ�����Ϣ
         /// </summary>
         /// <param name="at">Ҫ�޸ĵ�ָ�����λ����</param>
        /// <returns>���֣����ڻ����0��ʾ�޸ĳɹ�</returns>
        public int Update(XYECOM.Model.AdPlaceTypeInfo at)
        {
            return DAL.Update(at);
        }
        #endregion

        #region ɾ��ָ�����λ�����Ϣ
         /// <summary>
         /// ɾ��ָ���Ĺ��λ�����Ϣ
         /// </summary>
         /// <param name="at_ids">Ҫɾ���Ĺ��λ���ID��</param>
         /// <returns>���֣����ڻ����0��ɾ���ɹ�</returns>
        public int Delete(string at_ids)
        {
            return DAL.Delete(at_ids);
        }
        #endregion

        #region �жϸ���������Ƿ��������
        /// <summary>
        /// ����ID�ж�Ҫɾ����������Ƿ��������
        /// </summary>
        /// <param name="at_ids">ָ����IDֵ</param>
        /// <returns>����,����0��ʾ���������,����0��ʾ�������</returns>
        public int GetSonType(string at_ids)
        {
            return DAL.GetSonType(at_ids);
        }
        #endregion

        #region ���ָ���Ĺ��λ����DataTable
        /// <summary>
         /// ���ָ����DataTable���͵Ĺ��λ���
         /// </summary>
         /// <param name="strWhere">ָ���Ĺ��λ���</param>
        /// <param name="strOrderBy">ָ���Ĺ��λ��������Ϣ</param>
         /// <returns>DataTable���͵����������Ĺ��λ�����Ϣ</returns>
        public DataTable GetDataTable(string strWhere, string strOrderBy)
        {
            return DAL.GetDataTable(strWhere, strOrderBy);
        }
        #endregion
        
        #region ���ݹ��λ���ID��ȡ�ù��λ��������
        /// <summary>
        /// ���ݹ��λID��ȡ�ù��λ������
         /// </summary>
         /// <param name="atid">���λID</param>
         /// <returns>�ù��λID��Ӧ�Ĺ��λ����</returns>
        public string GetAdPlaceTypeName(int atid)
        {
            return DAL.GetAdPlaceTypeName(atid);
        }
        #endregion

        #region ���ݹ�������ID��ȡ�ù������������
        /// <summary>
        /// ���ݹ��λID��ȡ�ù��λ������
        /// </summary>
        /// <param name="atid">���λID</param>
        /// <returns>�ù��λID��Ӧ�Ĺ��λ����</returns>
        public string GetAdPlaceTypeNames(int atid)
        {
            return DAL.GetAdPlaceTypeNames(atid);
        }
        #endregion
    }

}
