using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace XYECOM.Business
{
  
    /// <summary>
    /// �����ʼ�ҵ����
    /// </summary>
    public class SendEmail
    {
        private static readonly XYECOM.SQLServer.SendEmail DAL = new XYECOM.SQLServer.SendEmail();

        /// <summary>
        /// ���
        /// </summary>
        /// <param name="se">�����ʼ���ʵ�����</param>
        /// <returns>Ӱ������</returns>
        public int Insert(XYECOM.Model.SendEmailInfo se)
        {
            return DAL.Insert(se);
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="E_ID">�ʼ����Id</param>
        /// <returns>Ӱ�������</returns>
        public int Delete(int E_ID)
        {
            return DAL.Delete(E_ID);
        }

        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="se">�ʼ���ʵ�����</param>
        /// <returns>Ӱ������</returns>
        public int Update(XYECOM.Model.SendEmailInfo se)
        {
            return DAL.Update(se);
        }
        /// <summary>
        /// �õ�һ���ʼ���Ϣ
        /// </summary>
        /// <param name="E_ID">�ʼ����Id</param>
        /// <returns>�ʼ���ʵ�����</returns>
        public XYECOM.Model.SendEmailInfo GetItem(int E_ID)
        {
            return DAL.GetItem(E_ID);
        }

        #region ɾ������ʼ���Ϣ
        /// <summary>
        /// ɾ������ʼ���Ϣ
        /// </summary>
        /// <param name="E_ID">�ʼ���ż���</param>
        /// <returns>Ӱ������</returns>
        public int Deletes(string E_ID)
        {
            return DAL.Deletes(E_ID);
        }
        #endregion
    }
}
