using System;
using System.Collections.Generic;

using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace XYECOM.Business
{
    /// <summary>
    /// �����Ϣҵ����
    /// </summary>
    public class UserRemit
    {
        private static readonly XYECOM.SQLServer.UserRemit DAL = new XYECOM.SQLServer.UserRemit();

        /// <summary>
        /// ���
        /// </summary>
        /// <param name="er">ʵ�����</param>
        /// <returns>Ӱ������</returns>
        public int Insert(XYECOM.Model.UserRemitInfo er)
        {
            return DAL.Insert(er);
        }
        
      
        //public DataTable  GetDataTable(int  R_ID)
        //{
        //    return DAL.GetDataTable(R_ID);  
        //}

        /// <summary>
        /// ��ȡһ�������Ϣ
        /// </summary>
        /// <param name="R_ID">���Id</param>
        /// <returns>ʵ�����</returns>
        public XYECOM.Model.UserRemitInfo GetItem(int R_ID)
        {
            return DAL.GetItem(R_ID);
        }
        
        /// <summary>
        /// ɾ��һ�������Ϣ
        /// </summary>
        /// <param name="R_ID">���Id</param>
        /// <returns>Ӱ������</returns>
        public int Delete(int R_ID)
        {
            return DAL.Delete(R_ID);
        }
        #region ɾ��������ȷ����Ϣ
        /// <summary>
        /// ɾ����������Ϣ
        /// </summary>
        /// <param name="R_ID">��ż���</param>
        /// <returns>Ӱ������</returns>
        public int Deletes(string R_ID)
        {
            return DAL.Deletes(R_ID);
        }
        #endregion

        /// <summary>
        /// �޸��û��ֽ��˻�
        /// </summary>
        /// <param name="U_ID">�û����Id</param>
        /// <param name="Money">���</param>
        /// <returns>Ӱ������</returns>
        public  int UpdateMoney(long U_ID, Decimal Money)
        {
            return DAL.UpdateMoney(U_ID, Money);
        }

        /// <summary>
        /// �޸��Ƿ��ֵ
        /// </summary>
        /// <param name="R_ID">���Id</param>
        /// <returns>Ӱ������</returns>
        public int UpdateIsPay(long R_ID)
        {
            return DAL.UpdateIsPay(R_ID);
        }
        #region �۳��û��ĳ���ָ��
        /// <summary>
        /// �۳��û��ĳ���ָ��
        /// </summary>
        /// <param name="U_ID">�û����Id</param>
        /// <param name="Money">����ָ��</param>
        /// <returns>Ӱ������</returns>
        public int DeductFaithMongy(long U_ID,int Money)
        {
            return DAL.DeductFaithMongy(U_ID, Money);
        }
        #endregion
    }
}
