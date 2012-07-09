using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace XYECOM.Business
{

    /// <summary>
    /// ��ǩ���ҵ����
    /// </summary>
    public class LabelType
    {
        private static readonly XYECOM.SQLServer.LabelType DAL = new XYECOM.SQLServer.LabelType();

        #region ��ӱ�ǩ���
        /// <summary>
        /// ��ӱ�ǩ���
        /// </summary>
        /// <param name="elt">��ǩ������������</param>
        /// <returns>���֡�����0��ʾ��ӳɹ�</returns>
        public int Insert(XYECOM.Model.LabelTypeInfo elt)
        {
            return DAL.Insert(elt);
        }
        #endregion

        #region �޸ı�ǩ���
        /// <summary>
        /// �޸ı�ǩ���
        /// </summary>
        /// <param name="elt">��ǩ������������</param>
        /// <returns>���֡�����0��ʾ�޸ĳɹ�</returns>
        public int Update(XYECOM.Model.LabelTypeInfo elt)
        {
            return DAL.Update(elt);
        }
        #endregion

        #region ɾ����ǩ���
        /// <summary>
        /// ɾ����ǩ���
        /// </summary>
        /// <param name="LT_ID">��ǩ�����</param>
        /// <returns>Ӱ������</returns>
        public int Delete(int LT_ID)
        {
            return DAL.Delete(LT_ID);
        }
        #endregion

        #region ��ȡ��ǩ���
        /// <summary>
        /// ��ȡָ���������
        /// </summary>
        /// <param name="LT_ID">�����</param>
        /// <returns>�������</returns>
        public string GetLTName(int LT_ID)
        {
            return DAL.GetLTName(LT_ID);

        }

        /// <summary>
        /// ��ȡָ�������Ϣ
        /// </summary>
        /// <param name="LT_ID">�����</param>
        /// <returns>�����Ϣ</returns>
        public XYECOM.Model.LabelTypeInfo GetItem(int LT_ID)
        {
            return DAL.GetItem(LT_ID);
        }

        /// <summary>
        /// ��ȡָ�������������Ϣ
        /// </summary>
        /// <param name="strWhere">ɸѡ����</param>
        /// <returns>�����Ϣ��</returns>
        public DataTable GetDataTable(string strWhere)
        {
            return DAL.GetDataTable(strWhere);
        }
        #endregion
    }

}
