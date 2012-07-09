using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using XYECOM.Model;

namespace XYECOM.Business
{
    /// <summary>
    /// �������ҵ����
    /// </summary>
    public class ServiceType
    {
        // ����DAL������������Ҫ��ķ���������
        private static readonly XYECOM.SQLServer.ServiceType DAL = new XYECOM.SQLServer.ServiceType();

        /// <summary>
        /// ���һ���µķ�����Ϣ������
        /// </summary>
        /// <param name="ct">Ҫ��ӵķ�����Ϣ������</param>
        /// <returns>����,���ڻ����0��ɹ�,�����ʧ��,-1��������ͬ���</returns>
        public int Insert(ServiceTypeInfo st)
        {
            if (object.Equals(null, st))
                return -2;

            return DAL.Insert(st);
        }

        /// <summary>
        /// ����ָ���ķ�����Ϣ������
        /// </summary>
        /// <param name="ct">Ҫ���ĵķ�����Ϣ������</param>
        /// <returns>����,���ڻ����0��ɹ�,�����ʧ��</returns>
        public int Update(ServiceTypeInfo st)
        {
            if (object.Equals(null, st))
                return -2;

            return DAL.Update(st);
        }

        /// <summary>
        /// ɾ��ָ����ŵķ������
        /// </summary>
        /// <param name="ctids">Ҫɾ���ķ�������ż�</param>
        /// <returns>����,���ڻ����0��ɹ�</returns>
        public int Delete(string stids)
        {
            if (string.IsNullOrEmpty(stids))
                return -2;

            return DAL.Delete(stids);
        }

        /// <summary>
        /// ��ȡָ����ŵķ���������
        /// </summary>
        /// <param name="ctid">Ҫ��ȡ�ķ���������ı��</param>
        /// <returns>�ñ���µķ���������</returns>
        public ServiceTypeInfo GetItem(Int64 stid)
        {
            ServiceTypeInfo stifno = null;
            if (stid <= 0)
                return stifno;

            return DAL.GetItem(stid);
        }

        /// <summary>
        /// ��ȡ����ָ�������ķ���������
        /// </summary>
        /// <param name="strWhere">ָ����where����</param>
        /// <param name="strOrder">ָ����order����</param>
        /// <returns>����ָ�������ķ���������</returns>
        public DataTable GetDataTable(string strWhere, string strOrder)
        {
            if (string.IsNullOrEmpty(strWhere))
                strWhere = "";

            if (string.IsNullOrEmpty(strOrder))
                strOrder = "";

            return DAL.GetDataTable(strWhere, strOrder);
        }

        public DataTable GetDataTable(int parentID, string moduleName)
        {
            string where = " where 1=1 ";

            if (parentID >= 0)
            {
                where += " and ST_ParentID=" + parentID.ToString();
            }

            if (!moduleName.Equals(""))
            {
                where += " and moduleName='" + moduleName + "'";
            }

            return GetDataTable(where, "");
        }

        /// <summary>
        /// �ж�ָ���ķ�����������Ƿ��������
        /// </summary>
        /// <param name="ctid">Ҫ�ж��Ƿ�������������ż�</param>
        /// <returns>����,����0��������,�����������</returns>
        public int IsHaveSonType(string stid)
        {
            if (string.IsNullOrEmpty(stid))
                return 1;

            return DAL.IsHaveSonType(stid);
        }

        /// <summary>
        /// ���ݷ�����Ϣ������Ż�ȡ������������
        /// </summary>
        /// <param name="ctid">Ҫ��ȡ���Ƶķ������ı��</param>
        /// <returns>����������</returns>
        public string GetServiceTypeName(Int64 stid)
        {
            if (stid <= 0)
                return "";

            return DAL.GetServiceTypeName(stid);
        }
    }
}
