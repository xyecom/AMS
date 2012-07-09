using System;
using System.Collections.Generic;
using System.Text;

using System.Data;



namespace XYECOM.Business
{
    /// <summary>
   /// �û��ֽ��˻�ҵ����
   /// </summary>
    public class UserAccount
    {
        private static readonly XYECOM.SQLServer.UserAccount DAL = new XYECOM.SQLServer.UserAccount();
        
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="UGR_ID">�ֽ��˻����Id</param>
        /// <returns>Ӱ������</returns>
        public int DeleteAcount(int UGR_ID)
        {
            return DAL.DeleteAcount(UGR_ID);
        }

        /// <summary>
        /// �����û���ŵõ����û��ֽ��˻�����Ϣ
        /// </summary>
        /// <param name="U_ID">�û����Id</param>
        /// <returns>�û��ֽ��˻�Id</returns>
        public DataTable GetDataTable(long U_ID)
        {
            return DAL.GetDataTable(U_ID);
        }

        /// <summary>
        /// ����ָ���û��˻���Ϣ
        /// </summary>
        /// <param name="userId">�û����Id</param>
        /// <returns>�û��ֽ��˻�ʵ�����</returns>
        public Model.UserAccountInfo GetItem(long userId)
        {
            if (userId <= 0) return null;

            return DAL.GetItem(userId);
        }

        #region ʣ���Ǯ���û����˻�
        /// <summary>
        /// ʣ���Ǯ���û�����
        /// </summary>
        /// <param name="U_ID">�û����Id</param>
        /// <param name="Money">�û�ʣ���Ǯ</param>
        /// <returns>Ӱ������</returns>
        public int AddAccountMoney(long U_ID, decimal Money)
        {
            return DAL.AddAccountMoney(U_ID, Money);
        }
        #endregion
        
        #region �۳��û��˻����
        /// <summary>
        /// �۳��û��˻����
        /// </summary>
        /// <param name="U_ID">�û����Id</param>
        /// <param name="Money">�۳��û��Ľ��</param>
        /// <returns>Ӱ������</returns>
        public int DeductAccountMoney(long U_ID, decimal Money)
        {
            return DAL.DeductAccountMoney(U_ID, Money);
        }
        #endregion    
    }
}
