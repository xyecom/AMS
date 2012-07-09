using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using XYECOM.Model;

namespace XYECOM.Business
{
    /// <summary>
    /// �շ��������ýӿ�ҵ����
    /// </summary>
    public class ChargeNewsSet
    {
        //ͨ�����󹤳���ȡ����Ҫ��ĳ�����
        private static readonly XYECOM.SQLServer.ChargeNewsSet DAL = new XYECOM.SQLServer.ChargeNewsSet();

        /// <summary>
        /// ���һ���µ��������ö���
        /// </summary>
        /// <param name="ci">Ҫ��ӵ��������ö���</param>
        /// <returns>����,���ڻ����0��ɹ�,����-1������ͬ����,������ʧ��</returns>
        public int Insert(ChargeNewsSetInfo ci)
        {
            if (object.Equals(null, ci))
                return -2;

            return  DAL.Insert(ci);
        }

        /// <summary>
        /// ����ָ���������ö���
        /// </summary>
        /// <param name="ci">Ҫ�޸ĵ��������ö���</param>
        /// <returns>����,���ڻ����0��ɹ�,�����ʧ��</returns>
        public int Update(ChargeNewsSetInfo ci)
        {
            if (object.Equals(null, ci))
                return -2;

            return DAL.Update(ci);
        }

        /// <summary>
        /// ɾ��ָ����ż����շ���������
        /// </summary>
        /// <param name="ciids">Ҫɾ�����շ����ű�ż�</param>
        /// <returns>����,���ڻ����0��ɹ�,�����ʧ��</returns>
        public int Delete(string newsIds)
        {
            if (string.IsNullOrEmpty(newsIds))
                return -2;

            return DAL.Delete(newsIds);
        }

                /// <summary>
        /// ����Ա�ȼ�ɾ���շ������ʷ���Ϣ
        /// </summary>
        /// <param name="userGradeId"></param>
        /// <returns></returns>
        public int DeleteByUserGradeId(int userGradeId)
        {
            if (userGradeId <= 0) return 0;

            return DAL.DeleteByUserGradeId(userGradeId);
        }

        /// <summary>
        /// ��ȡ����ָ���������շ��������ö���
        /// </summary>
        /// <param name="strWhere">ָ����Where����</param>
        /// <param name="Oder">ָ������������</param>
        /// <returns>����ָ���������շ��������ö���</returns>
        public DataTable GetDataTable(string strWhere, string Order)
        {
            DataTable dt = null;
            if (string.IsNullOrEmpty(strWhere))
                return dt;

            if (object.Equals(null, Order))
                Order = "";

            return DAL.GetDataTable(strWhere, Order);
        }

        /// <summary>
        /// ��ȡָ����ŵ��շ����Ŷ���
        /// </summary>
        /// <param name="ciid">ָ�����շ����ű��</param>
        /// <returns>�ñ�Ŷ�Ӧ���շ����Ŷ���</returns>
        public ChargeNewsSetInfo GetItem(Int64 ciid)
        {
            ChargeNewsSetInfo cnsinfo = null;
            if (ciid <= 0)
                return cnsinfo;

            return DAL.GetItem(ciid);
        }
        /// <summary>
        /// ��ȡָ����Ѷ��ź��û��ȼ����շ����Ŷ���
        /// </summary>
        /// <param name="newsId">����id</param>
        /// <param name="userGradeId">�ȼ�id</param>
        /// <returns>�շ�����ʵ�����</returns>
        public ChargeNewsSetInfo GetItem(long newsId, int userGradeId)
        {
            if (newsId <= 0 || userGradeId <= 0) return null;

            return DAL.GetItem(newsId, userGradeId);
        }

        /// <summary>
        /// ��ȡ����ָ���������ֶεļ���
        /// </summary>
        /// <param name="strWhere">ָ����Where����</param>
        /// <param name="Field">Ҫ��ȡ���ֶ�</param>
        /// <returns>�����������ֶεļ���</returns>
        public DataTable GetDataTableForField(string strWhere, string Field)
        {
            DataTable dt = null;
            if (string.IsNullOrEmpty(strWhere) || string.IsNullOrEmpty(Field))
                return dt;

            return DAL.GetDataTable(strWhere, Field);
        }
        /// <summary>
        /// ��ȡ����ָ���������ֶεļ���
        /// </summary>
        /// <param name="newID">���ű��</param>
        /// <returns>����ָ�������ֶμ���</returns>
        public string GetGreadIDByNewID(string newID)
        {
            DataTable dt = DAL.GetDataTableForField(" where NS_ID=" + newID.ToString(), "CN_VisitPopedom");
            string result = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                result += result == "" ? "" : ",";
                result += dt.Rows[i]["CN_VisitPopedom"].ToString();
            }
            return result;
        }
    }
}
