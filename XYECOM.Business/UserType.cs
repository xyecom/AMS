using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace XYECOM.Business
{
    /// <summary>
    /// �û�����ҵ����
    /// </summary>
    public class UserType
    {
        private static readonly XYECOM.SQLServer.UserType DAL = new XYECOM.SQLServer.UserType();

        /// <summary>
        /// ����û�����
        /// </summary>
        /// <param name="eut">ʵ����</param>
        /// <returns>��Ӱ�������</returns>
        public int Insert(XYECOM.Model.UserTypeInfo eut)
        {
            return DAL.Insert(eut);
        }
        
        /// <summary>
        /// �޸��û�������Ϣ
        /// </summary>
        /// <param name="eut">ʵ����</param>
        /// <returns>��Ӱ�������</returns>
        public int Update(XYECOM.Model.UserTypeInfo eut)
        {
            return DAL.Update(eut);
        }
      
        /// <summary>
        /// ɾ��һ����¼
        /// </summary>
        /// <param name="UT_ID">��¼���</param>
        /// <returns>һ����¼</returns>
        public int Delete(long UT_ID)
        {
            return DAL.Delete(UT_ID);
        }

        /// <summary>
        /// ɾ��������¼
        /// </summary>
        /// <param name="UT_IDs">��ż���</param>
        /// <returns>Ӱ������</returns>
        public int Delete(string UT_IDs)
        {
            return DAL.Delete(UT_IDs);
        }

        /// <summary>
        /// ��ȡһ����¼
        /// </summary>
        /// <param name="UT_ID">��¼���</param>
        /// <returns>һ����¼</returns>
        public XYECOM.Model.UserTypeInfo GetItem(long userTypeId)
        {
            if (userTypeId <= 0) return null;

            return DAL.GetItem(userTypeId);
        }

        /// <summary>
        /// ��ȡһ����¼
        /// </summary>
        /// <param name="UT_ID">��¼���</param>
        /// <returns>һ����¼</returns>
        public XYECOM.Model.UserTypeInfo GetItem(string typeName)
        {
            if (string.IsNullOrEmpty(typeName)) return null;

            return DAL.GetItem(typeName);
        } 
        
        /// <summary>
        /// ��ȡ�û�������Ϣ
        /// </summary>
        /// <param name="UT_PID">
        /// ��� UT_PID ���ڵ��� 0 ����һ����������Ϣ
        /// ���� ��������������Ϣ
        /// </param>
        /// <returns></returns>
        public DataTable GetDataTable(long userTypeId)
        {
            return DAL.GetDataTable(userTypeId);
        }

       
    }
}
