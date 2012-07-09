using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace XYECOM.Business
{
    /// <summary>
    /// ϵͳ����Աҵ����
    /// </summary>
    public class Admin
    {
        private static readonly XYECOM.SQLServer.Admin DAL = new XYECOM.SQLServer.Admin();

        /// <summary>
        /// ��ӹ���Ա��Ϣ
        /// </summary>
        /// <param name="ea">ʵ����</param>
        /// <returns>��Ӱ�������</returns>
        public int Insert(XYECOM.Model.AdminInfo ea)
        {
            return DAL.Insert(ea);
        }

        /// <summary>
        /// �޸Ĺ���Ա��Ϣ
        /// </summary>
        /// <param name="ea">ʵ����</param>
        /// <returns>��Ӱ�������</returns>
        public int Update(XYECOM.Model.AdminInfo ea)
        {
            return DAL.Update(ea);
        }

        /// <summary>
        /// ��ȡһ����¼
        /// </summary>
        /// <param name="UM_ID">��¼���</param>
        /// <returns>һ����¼</returns>
        public XYECOM.Model.AdminInfo GetItem(int UM_ID)
        {
            return DAL.GetItem(UM_ID);
        }

        /// <summary>
        /// ��ȡ���м�¼
        /// </summary>
        /// <returns>��¼��</returns>
        public DataTable GetDataTable()
        {
            return DAL.GetDataTable();
        }

        /// <summary>
        /// ɾ��һ����¼
        /// </summary>
        /// <param name="UM_ID">��¼���</param>
        /// <returns>��Ӱ�������</returns>
        public int Delete(int UM_ID)
        {
            return DAL.Delete(UM_ID);
        }
        /// <summary>
        /// У���û��������Ƿ���ȷ
        /// </summary>
        /// <param name="UserName">�û�����</param>
        /// <param name="Password">�û�����</param>
        /// <returns>�������ʾ�û�����������ȷ��</returns>
        public int isMyUser(string UserName, string Password)
        {
            return DAL.isMyUser(UserName, Password);
        }


        /// <summary>
        /// ͨ���û����ƻ�ȡ����
        /// </summary>
        /// <param name="username">�û�����</param>
        /// <returns>����Աʵ�����</returns>
        public XYECOM.Model.AdminInfo GetItem(string username)
        {
            return DAL.GetItem(username);
        }
    }
}
