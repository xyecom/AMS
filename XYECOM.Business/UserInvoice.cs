using System;
using System.Collections.Generic;

using System.Data.SqlClient;
using System.Data ;
using System.Text;


namespace XYECOM.Business
{
    /// <summary>
    /// �û����뷢Ʊҵ����
    /// </summary>
    public class UserInvoice
    {
        private static readonly XYECOM.SQLServer.UserInvoice DAL = new XYECOM.SQLServer.UserInvoice();

        /// <summary>
        /// ���
        /// </summary>
        /// <param name="ei">ʵ�����</param>
        /// <returns>Ӱ������</returns>
        public int Insert(XYECOM.Model.UserInvoiceInfo ei)
        {
            return DAL.Insert(ei);
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="I_ID">���Id</param>
        /// <returns>Ӱ������</returns>
        public int Delete(int I_ID)
        {
            return DAL.Delete(I_ID);
        }

        /// <summary>
        /// ��ȡ��Ʊ��Ϣ
        /// </summary>
        /// <param name="I_ID">���Id</param>
        /// <returns>ʵ�����</returns>
        public XYECOM.Model.UserInvoiceInfo GetItem(int I_ID)
        {
            return DAL.GetItem(I_ID);
        }

        #region ɾ��������뷢Ʊ��Ϣ
        /// <summary>
        /// ɾ��������뷢Ʊ��Ϣ
        /// </summary>
        /// <param name="I_ID">��ż���</param>
        /// <returns>Ӱ������</returns>
        public int Deletes(string I_ID)
        {
            return DAL.Deletes(I_ID);
        }
        #endregion

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="I_ID">���뷢Ʊ���</param>
        /// <param name="I_IsFlag">��Ʊ��ʶ</param>
        /// <param name="I_Advice">����</param>
        /// <param name="I_Reason">ԭ��</param>
        /// <returns>Ӱ������</returns>
        public int Update(int I_ID, System.Int16 I_IsFlag, string I_Advice, string I_Reason)
        {
            return DAL.Update(I_ID, I_IsFlag, I_Advice, I_Reason);
        }
    }
}
