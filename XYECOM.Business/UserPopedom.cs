using System;
using System.Collections.Generic;
using System.Data;
using System.Text;


namespace XYECOM.Business
{
   
    /// <summary>
    /// ����ԱȨ��ҵ����
    /// </summary>
    public class UserPopedom
    {

        private static readonly XYECOM.SQLServer.UserPopedom DAL = new XYECOM.SQLServer.UserPopedom();

        /// <summary>
        /// ��ȡ����ԱȨ����Ϣ
        /// </summary>
        /// <param name="UR_ID">����Ա��ɫ���</param>
        /// <returns>����ԱȨ����Ϣ</returns>
        public DataTable GetDataTable(int UR_ID)
        {
            return DAL.GetDataTable(UR_ID);
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="UR_ID">����Ա��ɫ���</param>
        /// <returns>Ӱ������</returns>
        public int Delete(int UR_ID)
        {
            return DAL.Delete(UR_ID);
        }

        /// <summary>
        /// �ж��û��Ƿ���ָ��ģ���Ȩ��
        /// </summary>
        /// <param name="tablename">ģ���ʶ������</param>
        /// <param name="UM_ID">����Ա���Id</param>
        /// <returns>true:��Ȩ��,false:��Ȩ��</returns>
        public bool IsUser(string tablename, long UM_ID)
        {
            return DAL.IsUser(tablename, UM_ID);
        }
    }
}
