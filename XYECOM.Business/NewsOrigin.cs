using System;
using System.Collections.Generic;
using System.Text;

using System.Data;


namespace XYECOM.Business
{

    /// <summary>
    /// ������Դҵ����
    /// </summary>
    public class NewsOrigin
    {
        private static readonly XYECOM.SQLServer.NewsOrigin DAL = new XYECOM.SQLServer.NewsOrigin();

        #region ���������Դ
        /// <summary>
        /// ���������Դ��Ϣ
        /// </summary>
        /// <param name="no">Ҫ��ӵ�������Դ����</param>
        /// <param name="no_id">��ӳɹ����������Դ�����ڱ��е�IDֵ</param>
        /// <returns>���֣����ڻ����0����ӳɹ�</returns>
        public int Insert(XYECOM.Model.NewsOriginInfo no, out int no_id)
        {
            return DAL.Insert(no, out no_id);
        }
        #endregion

        #region �޸�ָ����������Դ
        /// <summary>
        /// �޸�ָ����������Դ��Ϣ
        /// </summary>
        /// <param name="no">Ҫ�޸ĵ�������Դ��Ϣ����</param>
        /// <returns>���֣����ڻ����0���޸ĳɹ�</returns>
        public int Update(XYECOM.Model.NewsOriginInfo no)
        {
            return DAL.Update(no);
        }
        #endregion

        #region �õ�����������������Դ��ϢDataTable�б�
        /// <summary>
        /// �õ�����������������Դ��Ϣ����
        /// </summary>
        /// <param name="strWhere">ָ����Where��ѯ����</param>
        /// <param name="strOrderBy">ָ������������</param>
        /// <returns>����������������Դ��Ϣ����</returns>
        public DataTable GetDataTable(string strWhere, string strOrderBy)
        {
            return DAL.GetDataTable(strWhere, strOrderBy);
        }
        #endregion

        #region ɾ��ָ����������Դ��Ϣ����
        /// <summary>
        /// ɾ��ָ����������Դ��Ϣ
        /// </summary>
        /// <param name="no_ids">ָ����������Դ��Ϣ����IDֵ</param>
        /// <returns>���֣����ڻ����0��ɾ���ɹ�</returns>
        public int Delete(string no_ids)
        {
            return DAL.Delete(no_ids);
        }
        #endregion
    }
}
