using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using XYECOM.Model;

namespace XYECOM.Business
{
    /// <summary>
    /// ���̴������ҵ����
    /// </summary>
    public class InviteBusinessType
    {
        // ����DAL������������Ҫ������̴���������
        private XYECOM.SQLServer.InviteBusinessType DAL = new XYECOM.SQLServer.InviteBusinessType();

        /// <summary>
        /// ���һ���µ����̴���������
        /// </summary>
        /// <param name="ct">Ҫ��ӵ����̴���������</param>
        /// <returns>����,���ڻ����0��ɹ�,�����ʧ��,-1��������ͬ���</returns>
        public int Insert(InviteBusinessTypeInfo it)
        {
            if (object.Equals(null, it))
                return -2;

            return DAL.Insert(it);
        }

        /// <summary>
        /// ����ָ�������̴���������
        /// </summary>
        /// <param name="ct">Ҫ���ĵ����̴���������</param>
        /// <returns>����,���ڻ����0��ɹ�,�����ʧ��</returns>
        public int Update(InviteBusinessTypeInfo it)
        {
            if (object.Equals(null, it))
                return -2;

            return DAL.Update(it);
        }
        /// <summary>
        /// ɾ��ָ����ŵ����̴������
        /// </summary>
        /// <param name="ctids">Ҫɾ�������̴�������ż�</param>
        /// <returns>����,���ڻ����0��ɹ�</returns>
        public int Delete(string itids)
        {
            if (string.IsNullOrEmpty(itids))
                return -2;

            return DAL.Delete(itids);
        }

        /// <summary>
        /// ��ȡָ����ŵ����̴���������
        /// </summary>
        /// <param name="ctid">Ҫ��ȡ�����̴���������ı��</param>
        /// <returns>�ñ���µ����̴���������</returns>
        public InviteBusinessTypeInfo GetItem(Int64 itid)
        {
            InviteBusinessTypeInfo ibtinfo = null;
            if (itid <= 0)
                return ibtinfo;

            return DAL.GetItem(itid);
        }

        /// <summary>
        /// ��ȡ����ָ�����������̴���������
        /// </summary>
        /// <param name="strWhere">ָ����where����</param>
        /// <param name="strOrder">ָ����order����</param>
        /// <returns>����ָ�����������̴���������</returns>
        public DataTable GetDataTable(string strWhere, string strOrder)
        {
            if (string.IsNullOrEmpty(strWhere))
                strWhere = "";

            if (string.IsNullOrEmpty(strOrder))
                strOrder = "";

            return DAL.GetDataTable(strWhere, strOrder);
        }

        /// <summary>
        /// ��ȡ����ָ�����������̴���������
        /// </summary>
        /// <param name="parentID">�������Id</param>
        /// <param name="moduleName">ģ������</param>
        /// <returns>����ָ�����������̴���������</returns>
        public DataTable GetDataTable(int parentID, string moduleName)
        {
            string where = " where 1=1 ";

            if (parentID >= 0)
            {
                where += " and IT_ParentID=" + parentID.ToString();
            }

            if (!moduleName.Equals(""))
            {
                where += " and moduleName='" + moduleName + "'";
            }

            return GetDataTable(where, "");
        }

        /// <summary>
        /// �ж�ָ������������Ƿ��������
        /// </summary>
        /// <param name="ctid">Ҫ�ж��Ƿ�������������ż�</param>
        /// <returns>����,����0��������,�����������</returns>
        public int IsHaveSonType(string itid)
        {
            if (string.IsNullOrEmpty(itid))
                return 1;

            return DAL.IsHaveSonType(itid);
        }

        /// <summary>
        /// �������̴��������Ż�ȡ������������
        /// </summary>
        /// <param name="ctid">Ҫ��ȡ���Ƶ����̴������ı��</param>
        /// <returns>����������</returns>
        public string GetInviteBusinessTypeName(Int64 itid)
        {
            if (itid <= 0)
                return "";

            return DAL.GetInviteBusinessTypeName(itid);
        }
    }
}
