using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace XYECOM.Business
{
    /// <summary>
    /// ��ɫҵ����
    /// </summary>
    public class Role
    {
        private static readonly XYECOM.SQLServer.Role DAL = new XYECOM.SQLServer.Role();
        
        /// <summary>
        /// ��ӽ�ɫ
        /// </summary>
        /// <param name="er">ʵ����</param>
        /// <returns>��Ӱ�������</returns>
        public int Insert(XYECOM.Model.RoleInfo er)
        {
            return DAL.Insert(er);   
        }
        
        /// <summary>
        /// �޸Ľ�ɫ��Ϣ
        /// </summary>
        /// <param name="er">ʵ����</param>
        /// <returns>��Ӱ�������</returns>
        public int Update(XYECOM.Model.RoleInfo er)
        {
            return DAL.Update(er);
        }

        /// <summary>
        /// ɾ����ɫ
        /// </summary>
        /// <param name="UR_ID">��ɫ���</param>
        /// <returns>��Ӱ�������</returns>
        public int Delete(int UR_ID)
        {
            return DAL.Delete(UR_ID);
        }
       
        /// <summary>
        /// ��ȡһ����¼
        /// </summary>
        /// <param name="UR_ID">��¼���</param>
        /// <returns>һ����¼</returns>
        public XYECOM.Model.RoleInfo GetItem(int UR_ID)
        {
            return DAL.GetItem(UR_ID);
        }
        
        /// <summary>
        /// ��ȡ���м�¼
        /// </summary>
        /// <returns>��¼��</returns>
        public DataTable GetDataTable()
        {
            return DAL.GetDataTable();
        }        
    }
}
