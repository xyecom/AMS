using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace XYECOM.Business
{

    /// <summary>
    /// ��������ҵ����
    /// </summary>
    public class NewsAuthor
    {
        private static readonly XYECOM.SQLServer.NewsAuthor DAL = new XYECOM.SQLServer.NewsAuthor();

        #region
         /// <summary>
         /// ����������߲���
         /// </summary>
         /// <param name="na">Ҫ��ӵ��������߶���</param>
         /// <param name="na_id">����������ߺ�ö����IDֵ</param>
         /// <returns>���֣����ڻ����0��ʾ��ӳɹ�</returns>
        public int Insert(XYECOM.Model.NewsAuthorInfo na , out int na_id)
        {
            return DAL.Insert(na,out na_id);
        }
        #endregion


        #region �޸�����������Ϣ
        /// <summary>
        /// �޸�����������Ϣ����
        /// </summary>
        /// <param name="na">Ҫ�޸ĵ�������Ϣ����</param>
        /// <returns>���֣����ڻ��ߵ���0��ʾ�޸ĳɹ�</returns>
        public int Update(XYECOM.Model.NewsAuthorInfo na)
        {
            return DAL.Update(na);
        }
        #endregion

        #region
        /// <summary>
        /// �õ�����ָ����������������DataTable
        /// </summary>
        /// <param name="strWhere">ָ���Ĳ�ѯ����</param>
        /// <param name="strOrderBy">ָ������������</param>
        /// <returns>����������DataTable������������Ϣ</returns>
        public DataTable GetDataTable(string strWhere, string strOrderBy)
        {
            return DAL.GetDataTable(strWhere, strOrderBy);
        }
        #endregion

        #region
        /// <summary>
        /// ɾ��ָ��������������Ϣ
        /// </summary>
        /// <param name="na_ids">ָ������������IDֵ</param>
        /// <returns>���֣����ڻ����0��ʾɾ���ɹ�</returns>
        public int Delete(string na_ids)
        {
            return DAL.Delete(na_ids);
        }
        #endregion
    }
}
