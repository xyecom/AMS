using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using XYECOM.Model;

namespace XYECOM.Business
{
    /// <summary>
    /// �������۵�ҵ���߼�
    /// </summary>
    public class NewsDiscuss
    {
        /// <summary>
        /// ʹ�ó��󹤳��õ�һ���������۵�DAL
        /// </summary>
        private static readonly XYECOM.SQLServer.NewsDiscuss DAL = new XYECOM.SQLServer.NewsDiscuss();

        /// <summary>
        /// �����µ����۶���
        /// </summary>
        /// <param name="nd">Ҫ������������۶���</param>
        /// <param name="ndid">����ɹ�������۱��</param>
        /// <returns>����,���ڻ����0�����ɹ�,�����ʧ��</returns>
        public int Insert(NewsDiscussInfo nd)
        {
            return DAL.Insert(nd);
        }

        #region ����ָ������������
        /// <summary>
        /// ����ָ�����������۶���
        /// </summary>
        /// <param name="nd">Ҫ���µ���������</param>
        /// <returns>����,���ڻ����0����³ɹ�,����ʧ��</returns>
        public int Update(NewsDiscussInfo nd)
        {
            return DAL.Update(nd);
        }
        #endregion

        #region �õ�����ָ��������DataTable���͵���������
        /// <summary>
        /// �õ�����ָ��������DataTable���͵���������
        /// </summary>
        /// <param name="strWhere">ָ����Where����</param>
        /// <param name="strOrderBy">ָ������������</param>
        /// <returns>������������������</returns>
        public DataTable GetDataTable(string strWhere, string strOrderBy)
        {
            return DAL.GetDataTable(strWhere, strOrderBy);
        }
        #endregion

        #region ɾ��ָ����ŵ���������
        /// <summary>
        /// ɾ��ָ����ŵ���������
        /// </summary>
        /// <param name="ndids">ָ�����������۱��</param>
        /// <returns>����,���ڻ����0��ɾ���ɹ�</returns>
        public int Delete(string ndids)
        {
            return DAL.Delete(ndids);
        }
        #endregion

        #region ����ָ����Ż�ȡһ����������
        /// <summary>
        /// ����ָ����Ż�ȡһ����������
        /// </summary>
        /// <param name="ndid">ָ�������ű��</param>
        /// <returns>�ñ�ŵ��������۶���</returns>
        public NewsDiscussInfo GetItem(Int64 ndid)
        {
            return DAL.GetItem(ndid);
        }
        #endregion

        #region �����������۵���ʾ״̬
        /// <summary>
        /// �����������۵���ʾ״̬
        /// </summary>
        /// <param name="ndid">Ҫ���ĵ��������۱��</param>
        /// <param name="IsShow">Ҫ���ĵ�����״̬</param>
        /// <returns>����,���ڵ���0����ĳɹ�,�������ʧ��.</returns>
        public int SetIsShow(Int64 ndid, bool IsShow)
        {
            return DAL.SetIsShow(ndid, IsShow);
        }
        #endregion

        #region ��ȡǰn����������
        /// <summary>
        /// ��ȡǰn����������
        /// </summary>
        /// <param name="ndid"></param>
        /// <param name="strOrderBy">ָ������������</param>
        /// <param name="strColumuName">ָ�����ֶ�</param>
        /// <param name="TopNum">Ҫ��ȡ��ǰn����Ŀ</param>
        /// <returns>����������DataTable���͵ļ�¼</returns>
        public DataTable GetDataTable(string ndid, string strOrderBy, string strColumuName, int TopNum)
        {
            string strOrder = "";
            if (string.IsNullOrEmpty(strOrderBy))
                strOrder = " order by ND_ID desc ";

            string strWhere = " where ND_IsShow=1 ";
            if (ndid != "")
                strWhere += " and NS_ID =" + ndid;
            return DAL.GetDataTable(strWhere, strOrder, strColumuName, TopNum);
        }
        #endregion
    }
}
