using System;
using System.Collections.Generic;
using System.Text;
using XYECOM.Model;
using System.Data;

namespace XYECOM.Business
{
    /// <summary>
    /// �����ؼ��ֵ�ҵ���߼���
    /// </summary>
    public class SearchKey
    {
        private static readonly XYECOM.SQLServer.SearchKey DAL = new XYECOM.SQLServer.SearchKey();

        /// <summary>
        /// ����µ����������ؼ��ֶ���
        /// </summary>
        /// <param name="si">�ؼ��ֶ���</param>
        /// <returns>����,���ڻ����0��ɹ�,С��0��ʧ��</returns>
        public int Insert(SearchKeyInfo sk)
        {
            if (object.Equals(null, sk))
                return -1;

            return DAL.Insert(sk);
        }

        /// <summary>
        /// �޸�ָ�������Źؼ��ֶ���
        /// </summary>
        /// <param name="si">Ҫ�޸ĵĹؼ��ֶ���</param>
        /// <returns>����,���ڻ����0��ɹ�,С��0��ʧ��</returns>
        public int Update(SearchKeyInfo sk)
        {
            if (object.Equals(null, sk))
                return -1;

            return DAL.Update(sk);
        }

        /// <summary>
        /// ɾ��ָ����ŵ����Źؼ���
        /// </summary>
        /// <param name="siids">ָ���ı��</param>
        /// <returns>����,���ڻ����0��ɹ�,С��0��ʧ��</returns>
        public int Delete(string skids)
        {
            if (string.IsNullOrEmpty(skids))
                return -1;

            return DAL.Delete(skids);
        }

        /// <summary>
        /// ��ȡָ����ŵ����Źؼ��ֶ���
        /// </summary>
        /// <param name="kiid">ָ���Ķ�����</param>
        /// <returns>�ñ�Ŷ�Ӧ�����Źؼ��ֶ���</returns>
        public SearchKeyInfo GetItem(long keyId)
        {
            if (keyId <= 0) return null;

            return DAL.GetItem(keyId);
        }

        /// <summary>
        /// ��ȡָ���ؼ�����Ϣ
        /// </summary>
        /// <param name="keyword">�ؼ���</param>
        /// <returns>�ñ�Ŷ�Ӧ�����Źؼ��ֶ���</returns>
        public SearchKeyInfo GetRankingItem(string keyword)
        {
            if (String.IsNullOrEmpty(keyword)) return null;

            keyword = keyword.Trim();

            if (keyword.Equals("")) return null;

            return DAL.GetRankingItem(keyword);
        }

        /// <summary>
        /// ��ȡ����ָ�����͵�ǰN���ȴʼ�¼��
        /// </summary>
        /// <param name="type">ָ�����ȴ�����</param>
        /// <returns>����ָ���������ȴʼ�</returns>
        public DataTable GetTopDataTable(string type, int topNumber)
        {
            string strWhere ="SK_IsCommend=1";

            if (!string.IsNullOrEmpty(type) && !type.Equals(""))
                strWhere += " and SK_Sort='" + type.ToString() + "'";

            string strOrderBy = " SK_Count desc";
            string strColumuName = " SK_ID,SK_Name,SK_Count,SK_Sort";

            return Utils.ExecuteTable("b_searchkey", strColumuName, strWhere, strOrderBy, topNumber);
        }

        /// <summary>
        /// ��ȡ���������ؼ���
        /// </summary>
        /// <param name="topNumber"></param>
        /// <returns></returns>
        public DataTable GetHotKeyword(int topNumber)
        {
            string strWhere = " SK_IsRanking ='1'";

            string strOrderBy = " SK_Count desc";

            string strColumuName = " SK_ID,SK_Name,SK_Count";

            return XYECOM.Business.Utils.ExecuteTable("b_searchkey", strColumuName, strWhere, strOrderBy, topNumber);
        }

        /// <summary>
        /// ��ȡ���������ؼ���
        /// </summary>
        /// <param name="topNumber"></param>
        /// <returns></returns>
        public DataTable GetNewKeyword(int topNumber)
        {
            string strWhere = " SK_IsRanking ='1'";

            string strOrderBy = " SK_ID desc";

            string strColumuName = " SK_ID,SK_Name,SK_Count";

            return XYECOM.Business.Utils.ExecuteTable("b_searchkey", strColumuName, strWhere, strOrderBy, topNumber);
        }

        /// <summary>
        /// ��ȡ���������Ĺؼ���
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public DataTable GetRankingKeyword(string key)
        {
            if (string.IsNullOrEmpty(key)) return new DataTable();

            key = key.Replace("'", "��").Trim();

            string strWhere = " SK_IsRanking ='1'  and SK_Name like'%" + key + "%'";

            string strOrderBy = " SK_Count desc";

            string strColumuName = " SK_ID,SK_Name,SK_CustomPrice";

            return Utils.ExecuteTable("b_searchkey",strColumuName,strWhere, strOrderBy,0);
        }

        /// <summary>
        /// ǰ̨�����ȴʴ���(����ôʴ���,���һ,���򲻴���)
        /// </summary>
        /// <param name="keyName">�ؼ���(�����Ƕ�������֮���Զ��Ÿ���)</param>
        /// <param name="moduleName">����ģ��</param>
        /// <returns>������ȴʴ���,������������һ������true,���򷵻�false</returns>
        public static bool UpdateNumberOfSearches(string keyName, string moduleName)
        {
            if (string.IsNullOrEmpty(keyName) 
                || string.IsNullOrEmpty(moduleName))
                return false;

            if (keyName.Trim().Equals("")
            || moduleName.Trim().Equals(""))
                return false;

            if (keyName.StartsWith(",")) keyName = keyName.Substring(1);

            string[] keys = keyName.Split(',');

            bool isAutoGather = XYECOM.Configuration.WebInfo.Instance.IsAutoGatherSearchKey;

            foreach (string k in keys)
            {
                DAL.UpdateNumberOfSearches(keyName, moduleName, isAutoGather);
            }
            return true;
        }

        public bool IsExistsOnUpdate(SearchKeyInfo info)
        {
            return DAL.IsExistsOnUpdate(info);
        }
    }
}
