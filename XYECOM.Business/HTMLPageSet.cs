using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace XYECOM.Business
{

    /// <summary>
    /// ��̬ҳ��ҵ����
    /// </summary>
    public class HTMLPageSet
    {
        private static readonly XYECOM.SQLServer.HTMLPageSet DAL = new XYECOM.SQLServer.HTMLPageSet();

        #region ��Ӿ�̬ҳ��������Ϣ
        /// <summary>
        /// ��Ӿ�̬ҳ��������Ϣ
        /// </summary>
        /// <param name="ehps">��̬ҳ��������Ϣ���������</param>
        /// <returns>���֡�����0��ʾ���óɹ�</returns>
        public int Insert(XYECOM.Model.HtmlPageSetInfo ehps)
        {
            return DAL.Insert(ehps);
        }
        #endregion

        #region �޸ľ�̬ҳ��������Ϣ
        /// <summary>
        /// �޸ľ�̬ҳ��������Ϣ
        /// </summary>
        /// <param name="ehps">��̬ҳ��������Ϣ���������</param>
        /// <returns>���֡�����0��ʾ�޸ĳɹ�</returns>
        public int Update(XYECOM.Model.HtmlPageSetInfo ehps)
        {

            return DAL.Update(ehps);
        }
        #endregion

        #region ��ȡ��̬ҳ��������Ϣ
        /// <summary>
        /// ��ȡ��̬ҳ��������Ϣ
        /// </summary>
        /// <param name="strWhere">��ѯ����</param>
        /// <param name="strOrderBy">��������</param>
        /// <returns>DataTable���ݼ�</returns>
        public DataTable GetDataTable(string strWhere, string strOrderBy)
        {
            return DAL.GetDataTable(strWhere, strOrderBy);
        }
        #endregion
    }
}
