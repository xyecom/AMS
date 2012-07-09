using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace XYECOM.Business
{
    /// <summary>
    /// �û������˻�ҵ����
    /// </summary>
    public class UserFictitiouCount
    {
        private static readonly XYECOM.SQLServer.UserFictitiouCount DAL = new XYECOM.SQLServer.UserFictitiouCount();

        /// <summary>
        /// ���
        /// </summary>
        /// <param name="efc">ʵ�����</param>
        /// <returns>Ӱ������</returns>
        public int Insert(XYECOM.Model.UserFictitiouCountInfo efc)
        {
            return DAL.Insert(efc);
        }

        /// <summary>
        /// ��ȡһ�������˻���Ϣ
        /// </summary>
        /// <param name="userId">�û����Id</param>
        /// <returns>ʵ�����</returns>
        public Model.UserFictitiouCountInfo GetItem(long userId)
        {
            if (userId <= 0) return null;
            
            return DAL.GetItem(userId);
        }

        //public DataTable GetDataTable(long U_ID)
        //{
        //    return DAL.GetDataTable(U_ID);
        //}

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="U_ID">�û����Id</param>
        /// <param name="Money">���</param>
        /// <returns>Ӱ������</returns>
        public int UpdateUserFictitiouCount(long U_ID, decimal Money)
        {
            return DAL.UpdateUserFictitiouCount(U_ID, Money);
        }

        /// <summary>
        /// �۳��û��������
        /// </summary>
        /// <param name="userId">�û�Id</param>
        /// <param name="amount">���</param>
        /// <returns>Ӱ������</returns>
        public int DeductUserUUFictitiouCount(long userId, decimal amount)
        {
            return DAL.DeductUserUUFictitiouCount(userId, amount);
        }
    }
}
