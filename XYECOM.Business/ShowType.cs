using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using XYECOM.Model;


namespace XYECOM.Business
{
    /// <summary>
    /// ����������ҵҵ����
    /// </summary>
    public class ShowType
    {
        // ����DAL������������Ҫ��ĺ���������
        private XYECOM.SQLServer.ShowType DAL = new XYECOM.SQLServer.ShowType();

        /// <summary>
        /// ���һ���µĺ�����Ϣ������
        /// </summary>
        /// <param name="ct">Ҫ��ӵĺ�����Ϣ������</param>
        /// <returns>����,���ڻ����0��ɹ�,�����ʧ��,-1��������ͬ���</returns>
        public int Insert(ShowTypeInfo sht)
        {
            if (object.Equals(null, sht))
                return -2;

            return DAL.Insert(sht);
        }

        /// <summary>
        /// ����ָ���ĺ�����Ϣ������
        /// </summary>
        /// <param name="ct">Ҫ���ĵĺ�����Ϣ������</param>
        /// <returns>����,���ڻ����0��ɹ�,�����ʧ��</returns>
        public int Update(ShowTypeInfo sht)
        {
            if (object.Equals(null, sht))
                return -2;

            return DAL.Update(sht);
        }

        /// <summary>
        /// ɾ��ָ����ŵĺ������
        /// </summary>
        /// <param name="ctids">Ҫɾ���ĺ�������ż�</param>
        /// <returns>����,���ڻ����0��ɹ�</returns>
        public int Delete(string shtids)
        {
            if (string.IsNullOrEmpty(shtids))
                return -2;

            return DAL.Delete(shtids);
        }

        /// <summary>
        /// ��ȡָ����ŵĺ���������
        /// </summary>
        /// <param name="ctid">Ҫ��ȡ�ĺ���������ı��</param>
        /// <returns>�ñ���µĺ���������</returns>
        public ShowTypeInfo GetItem(Int64 shtid)
        {
            ShowTypeInfo stinfo = null;
            if (shtid <= 0)
                return stinfo;

            return DAL.GetItem(shtid);
        }

        /// <summary>
        /// ��ȡ����ָ�������ĺ���������
        /// </summary>
        /// <param name="strWhere">ָ����where����</param>
        /// <param name="strOrder">ָ����order����</param>
        /// <returns>����ָ�������ĺ���������</returns>
        public DataTable GetDataTable(string strWhere, string strOrder)
        {
            if (string.IsNullOrEmpty(strWhere))
                strWhere = "";

            if (string.IsNullOrEmpty(strOrder))
                strOrder = "";

            return DAL.GetDataTable(strWhere, strOrder);
        }

        public DataTable GetDataTable(long parentID, string modulename)
        {
            string where = " where 1=1 ";

            if (parentID >= 0)
            {
                where += " and SHT_ParentID=" + parentID.ToString();
            }

            if (!modulename.Equals(""))
            {
                where += " and moduleName='" + modulename + "'";
            }

            return GetDataTable(where, "");
        }
        /// <summary>
        /// �ж�ָ������������Ƿ��������
        /// </summary>
        /// <param name="ctid">Ҫ�ж��Ƿ��������������</param>
        /// <returns>����,����0��������,�����������</returns>
        public int IsHaveSonType(string shtid)
        {
            if (string.IsNullOrEmpty(shtid))
                return -2;

            return DAL.IsHaveSonType(shtid);
        }

        /// <summary>
        /// ���ݺ�����Ϣ������Ż�ȡ������������
        /// </summary>
        /// <param name="infoid">Ҫ��ȡ���Ƶĺ������ı��</param>
        /// <returns>����������</returns>
        public string GetShowTypeName(int infoid)
        {
            if (infoid <= 0)
                return "";

            return DAL.GetCooperateTypeName(infoid);
        }
    }
}
