using System;
using System.Collections.Generic;
using System.Text;
using XYECOM.Model;
using System.Data;

namespace XYECOM.Business
{
    /// <summary>
    /// 搜索关键字的业务逻辑类
    /// </summary>
    public class SearchKey
    {
        private static readonly XYECOM.SQLServer.SearchKey DAL = new XYECOM.SQLServer.SearchKey();

        /// <summary>
        /// 添加新的热门搜索关键字对象
        /// </summary>
        /// <param name="si">关键字对象</param>
        /// <returns>数字,大于或等于0表成功,小于0表失败</returns>
        public int Insert(SearchKeyInfo sk)
        {
            if (object.Equals(null, sk))
                return -1;

            return DAL.Insert(sk);
        }

        /// <summary>
        /// 修改指定的热门关键字对象
        /// </summary>
        /// <param name="si">要修改的关键字对象</param>
        /// <returns>数字,大于或等于0表成功,小于0表失败</returns>
        public int Update(SearchKeyInfo sk)
        {
            if (object.Equals(null, sk))
                return -1;

            return DAL.Update(sk);
        }

        /// <summary>
        /// 删除指定编号的热门关键字
        /// </summary>
        /// <param name="siids">指定的编号</param>
        /// <returns>数字,大于或等于0表成功,小于0表失败</returns>
        public int Delete(string skids)
        {
            if (string.IsNullOrEmpty(skids))
                return -1;

            return DAL.Delete(skids);
        }

        /// <summary>
        /// 获取指定编号的热门关键字对象
        /// </summary>
        /// <param name="kiid">指定的对象编号</param>
        /// <returns>该编号对应的热门关键字对象</returns>
        public SearchKeyInfo GetItem(long keyId)
        {
            if (keyId <= 0) return null;

            return DAL.GetItem(keyId);
        }

        /// <summary>
        /// 获取指定关键词信息
        /// </summary>
        /// <param name="keyword">关键词</param>
        /// <returns>该编号对应的热门关键字对象</returns>
        public SearchKeyInfo GetRankingItem(string keyword)
        {
            if (String.IsNullOrEmpty(keyword)) return null;

            keyword = keyword.Trim();

            if (keyword.Equals("")) return null;

            return DAL.GetRankingItem(keyword);
        }

        /// <summary>
        /// 获取满足指定类型的前N条热词记录集
        /// </summary>
        /// <param name="type">指定的热词类型</param>
        /// <returns>满足指定条件的热词集</returns>
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
        /// 获取热门排名关键词
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
        /// 获取最新排名关键词
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
        /// 获取参与排名的关键词
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public DataTable GetRankingKeyword(string key)
        {
            if (string.IsNullOrEmpty(key)) return new DataTable();

            key = key.Replace("'", "‘").Trim();

            string strWhere = " SK_IsRanking ='1'  and SK_Name like'%" + key + "%'";

            string strOrderBy = " SK_Count desc";

            string strColumuName = " SK_ID,SK_Name,SK_CustomPrice";

            return Utils.ExecuteTable("b_searchkey",strColumuName,strWhere, strOrderBy,0);
        }

        /// <summary>
        /// 前台搜索热词处理(如果该词存在,则加一,否则不处理)
        /// </summary>
        /// <param name="keyName">关键词(可以是多个，多个之间以逗号隔开)</param>
        /// <param name="moduleName">所属模块</param>
        /// <returns>如果该热词存在,在搜索次数加一并返回true,否则返回false</returns>
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
