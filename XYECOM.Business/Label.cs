using System;
using System.Collections.Generic;
using System.Text;

using System.Data;


namespace XYECOM.Business
{

    /// <summary>
    /// ���ݱ�ǩҵ����
    /// </summary>
    public class Label
    {
        private static readonly XYECOM.SQLServer.Label DAL = new XYECOM.SQLServer.Label();

        #region ��ӱ�ǩ��Ϣ
        /// <summary>
        /// ��ӱ�ǩ��Ϣ
        /// </summary>
        /// <param name="el">��ǩ��Ϣ���������</param>
        /// <returns>���֡�����0��ʾ��ӳɹ�</returns>
        public int Insert(XYECOM.Model.LabelInfo el)
        {
            return DAL.Insert(el);
        }
        #endregion

        #region �޸ı�ǩ��Ϣ
        /// <summary>
        /// �޸ı�ǩ��Ϣ
        /// </summary>
        /// <param name="el">��ǩ��Ϣ���������</param>
        /// <returns>���֡�����0��ʾ��ӳɹ�</returns>
        public int Update(XYECOM.Model.LabelInfo el)
        {
            return DAL.Update(el);
        }
        #endregion

        #region ɾ����ǩ��Ϣ
        /// <summary>
        /// ɾ����ǩ��Ϣ
        /// </summary>
        /// <param name="L_ID">��ǩ���</param>
        /// <returns>���֡�����0��ʾɾ���ɹ�</returns>
        public int Delete(long L_ID)
        {
            return DAL.Delete(L_ID);
        }
        public int Delete(string L_IDs)
        {
            return DAL.Delete(L_IDs);
        }
        #endregion

        #region ��ȡ��ǩ��Ϣ
        /// <summary>
        /// ��ȡ��ǩ��Ϣ
        /// </summary>
        /// <param name="L_Name">��ǩ��</param>
        /// <returns>���ݱ�ǩʵ�����</returns>
        public XYECOM.Model.LabelInfo GetItem(string L_Name)
        {
            return DAL.GetItem(L_Name);
        }

        /// <summary>
        /// �������ݱ�ǩ���Id�������ݱ�ǩ��Ϣ
        /// </summary>
        /// <param name="L_ID">���id</param>
        /// <returns>���ݱ�ǩʵ�����</returns>
        public XYECOM.Model.LabelInfo GetItem(long L_ID)
        {
            return DAL.GetItem(L_ID);
        }
        #endregion
    }
}
