using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Data;

namespace XYECOM.Label
{
    /**************************************************
     * XYECOM.Label.ContentLabelManager.cs
     * 创建标识：TC 20080618
     * 
     * 功能描述：内容标签处理类
     * 
     *************************************************/

    /// <summary>
    /// 内容标签解析父类
    /// </summary>
    public class ContentLabelManager : LabelManger, IPaging
    {
        //private ContentLabelManager instance = null;

        //标签信息
        private XYECOM.Model.LabelInfo _labelInfo = null;
        //标签原始参数
        private LabelParameterInfo paramInfo = null;
        //数据查询参数
        private LabelQueryParameterInfo queryParamInfo = null;

        static object lockHelper = new object();

        /// <summary>
        /// 获取标签解析对象实例
        /// </summary>
        /// <param name="labelName"></param>
        /// <returns></returns>
        public ContentLabelManager GetInstance(string labelName)
        {
            //去掉标签前面的XY_
            labelName = labelName.Substring(3);

            _labelInfo = new XYECOM.Business.Label().GetItem(labelName);


            if (_labelInfo == null)
            {
                throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + "发生异常！LabelName:【" + labelName + "】不存在");
            }

            //分析原始参数
            paramInfo = AnalysesParameter(_labelInfo.LabelContent);

            //加载具体处理类(根据不同标签加载不同的对象实例)
            string className = "XYECOM.Label." + paramInfo.LabelFlagName;

            ContentLabelManager instance = null;

            lock (lockHelper)
            {
                instance = (XYECOM.Label.ContentLabelManager)Assembly.Load("XYECOM.Label").CreateInstance(className);
            }

            if (instance != null)
            {
                instance._LabelInfo = _labelInfo;
                instance.ParamInfo = paramInfo;
            }

            return instance;
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        /// <returns></returns>
        public override string CreateHTML()
        {
            if (_labelInfo.LabelContent.Equals(""))
            {
                WriteLog("内容标签解析错误，标签 " + _labelInfo.LabelName + " 参数不存在。");
                return "您的标签设置有误!";
            }

            string result = GetResult();

            return result;
        }

        /// <summary>
        /// 获取最终分析替换的字符串结果
        /// </summary>
        /// <param name="labelInfo">标签信息对象</param>
        /// <returns></returns>
        public string GetResult()
        {
            //获取具体数据库查询参数
            queryParamInfo = GetQueryParameter();
            //根据参数获取数据
            System.Data.DataTable table = GetDataResult();

            StringBuilder strHTML = new StringBuilder("");

            strHTML.Append(_labelInfo.LabelStyleHead);   //样式头部标记

            FieldManager fm = new FieldManager();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string result = fm.ReplaceField(i + 1, paramInfo.LabelFlagName, _labelInfo.LabelStyleContent, table.Rows[i], queryParamInfo);
                strHTML.Append(result);
            }

            strHTML.Append(_labelInfo.LabelStyleFooter);
            strHTML.Replace('"', '\"');

            return strHTML.ToString();
        }

        /// <summary>
        /// 分解分析原始参数
        /// </summary>
        /// <param name="labelParam">标签参数字符串</param>
        /// <returns></returns>
        protected static LabelParameterInfo AnalysesParameter(string labelParam)
        {
            LabelParameterInfo info = null;

            //去掉参数左边的 "{" 和右边的"}"
            labelParam = labelParam.Substring(1).Substring(0, labelParam.Length - 2);

            //分解参数
            string[] labelParams = labelParam.Split('┆');

            if (labelParams.Length > 0) info = new LabelParameterInfo();

            for (int i = 0; i < labelParams.Length; i++)
            {
                if (i == 0)
                {
                    info.LabelFlagName = labelParams[0].ToString().Split('$')[1].ToString();
                    continue;
                }

                //分析其他参数，并将其放入集合
                string key = labelParams[i].ToString().Split('$')[0].ToString();
                string value = labelParams[i].ToString().Split('$')[1].ToString();

                info.ParamList.Add(key, value);
            }

            return info;
        }

        /// <summary>
        /// 获取标签中的所有字段名称
        /// </summary>
        /// <param name="labelBody">标签体</param>
        /// <returns></returns>
        protected string GetColumnNames(string labelBody)
        {
            return new FieldManager().GetColumnName(labelBody);
        }

        #region 属性

        /// <summary>
        /// 标签参数
        /// </summary>
        protected LabelParameterInfo ParamInfo
        {
            set { paramInfo = value; }
            get { return paramInfo; }
        }

        /// <summary>
        /// 标签数据查询参数
        /// </summary>
        protected LabelQueryParameterInfo QueryParamInfo
        {
            set { queryParamInfo = value; }
            get { return queryParamInfo; }
        }

        /// <summary>
        /// 标签信息
        /// </summary>
        protected Model.LabelInfo _LabelInfo
        {
            set { _labelInfo = value; }
            get { return _labelInfo; }
        }

        private ContentLabelType labelContentType = ContentLabelType.Normal;

        /// <summary>
        /// 标签内容类型
        /// </summary>
        public ContentLabelType LabelContentType
        {
            get { return labelContentType; }
            set { this.labelContentType = value; }
        }

        #endregion

        #region 抽象方法
        /// <summary>
        /// 根据标签参数获取
        /// </summary>
        /// <returns></returns>
        protected virtual string GetCondition() { return ""; }
        /// <summary>
        /// 分析并获取标签查询参数
        /// </summary>
        /// <returns></returns>
        protected virtual LabelQueryParameterInfo GetQueryParameter() { return null; }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        protected virtual System.Data.DataTable GetDataResult()
        {

            if (_LabelInfo != null && _LabelInfo.LabelRange != Model.LabelRange.System)
            {
                QueryParamInfo.Condition += GetLabelRangeCondition();
            }

            DataTable table = new DataTable();
            switch (LabelContentType)
            {
                case ContentLabelType.Normal:
                    table = XYECOM.Core.Function.GetDataTableForTop(PageSize,
                                      QueryParamInfo.Columns,
                                      QueryParamInfo.DataSourceName,
                                      QueryParamInfo.Condition,
                                      QueryParamInfo.Order);
                    break;
                case ContentLabelType.Pagination:
                    int totalRecord = 0;

                    if (CustomPageSize != 0) PageSize = CustomPageSize;

                    table = XYECOM.Business.Utils.GetPaginationData(
                       QueryParamInfo.DataSourceName,
                       QueryParamInfo.PrimaryKey,
                       QueryParamInfo.Columns,
                       QueryParamInfo.SortFields,
                       QueryParamInfo.Condition,
                       PageSize,
                       PageIndex,
                       out totalRecord);

                    TotalRecord = totalRecord;

                    SetPagination(PageIndex, PageURL, SearchPageList, ModuleFlag);

                    break;
                case ContentLabelType.Ranking:
                    //如果没有信息是返回空表格
                    if (!string.IsNullOrEmpty(StrKeySearchWhere))
                    {
                        PageSize = 1;

                        table = XYECOM.Business.Utils.GetPaginationData(
                           QueryParamInfo.DataSourceName,
                           QueryParamInfo.PrimaryKey,
                           QueryParamInfo.Columns,
                           QueryParamInfo.SortFields,
                           QueryParamInfo.Condition,
                           PageSize,
                           PageIndex,
                           out totalRecord);
                    }
                    break;
                default:
                    break;
            }
            return table;
        }
        #endregion

        protected virtual string ModuleFlag
        {
            get
            {
                return string.Empty;
            }
        }

        public virtual SEARCH_PAGE_LIST SearchPageList
        {
            get
            {
                return SEARCH_PAGE_LIST.SEARCH_SELLER_SEARCH;
            }
        }

        /// <summary>
        /// 获取排名信息Id
        /// </summary>
        /// <param name="rankKeyId">排名关键词Id</param>
        /// <param name="rank">名次</param>
        /// <param name="moduleName">模块名称</param>
        /// <returns></returns>
        protected long GetRankingInfoId(long rankKeyId, short rank, string moduleName)
        {
            if (rankKeyId <= 0) return 0;

            if (rank <= 0 || rank > XYECOM.Configuration.Ranking.Instance.Total) return 0;

            Model.RankingInfo rankingInfo = new Business.Ranking().GetItem(rankKeyId, rank);

            if (rankingInfo == null) return 0;

            long infoId = rankingInfo.GetInfoId(moduleName);

            return infoId;
        }

        #region 分页参数(实现IPaging接口)

        private int pageSize;
        private int customPageSize;
        private int totalRecord;
        private int pageCount;
        private int pageIndex;
        private string pageURL;
        private string nextPage;
        private string firstPage;
        private string lastPage;
        private string previousPage;
        private string numPage;
        private string strPageSearchWhere;
        private string strKeySearchWhere;

        #endregion

        #region IPaging 成员
        public int PageSize
        {
            get
            {
                if (pageSize < 0) pageSize = 0;
                return pageSize;
            }
            set
            {
                if (value >= 0)
                    this.pageSize = value;
                else
                    pageSize = 0;
            }
        }

        public int CustomPageSize
        {
            get
            {
                return customPageSize;
            }
            set
            {
                if (value >= 0)
                    this.customPageSize = value;
                else
                    customPageSize = 0;
            }
        }

        public int TotalRecord
        {
            get
            {
                return totalRecord;
            }

            set
            {
                totalRecord = value;
            }
        }

        public int PageCount
        {
            get
            {
                return pageCount;
            }
            set
            {
                pageCount = value;
            }
        }

        public int PageIndex
        {
            get
            {
                if (pageIndex <= 0) pageIndex = 1;

                return pageIndex;
            }
            set
            {
                pageIndex = value;
            }
        }

        public string PageURL
        {
            get
            {
                return pageURL;
            }
            set
            {
                pageURL = value;
            }
        }

        public string PreviousPage
        {
            get
            {
                if (String.IsNullOrEmpty(previousPage) || previousPage == null)
                    return "";

                return previousPage;
            }
            set
            {
                previousPage = value;
            }
        }

        public string NextPage
        {
            get
            {
                if (String.IsNullOrEmpty(nextPage) || nextPage == null)
                    return "";

                return nextPage;
            }
            set
            {
                nextPage = value;
            }
        }

        public string FirstPage
        {
            get
            {
                if (String.IsNullOrEmpty(firstPage) || firstPage == null)
                    return "";

                return firstPage;
            }
            set
            {
                firstPage = value;
            }
        }

        public string LastPage
        {
            get
            {
                if (String.IsNullOrEmpty(lastPage) || lastPage == null)
                    return "";

                return lastPage;
            }
            set
            {
                lastPage = value;
            }
        }

        public string NumPage
        {
            get
            {
                if (String.IsNullOrEmpty(numPage) || numPage == null)
                    return "";

                return numPage;
            }
            set
            {
                numPage = value;
            }
        }

        public string StrPageSearchWhere
        {
            get
            {
                if (string.IsNullOrEmpty(strPageSearchWhere) || strPageSearchWhere == null)
                    return "";

                return strPageSearchWhere;
            }
            set
            {
                strPageSearchWhere = value;
            }
        }

        public string StrKeySearchWhere
        {
            get
            {
                if (string.IsNullOrEmpty(strKeySearchWhere) || strKeySearchWhere == null)
                    return "";

                return strKeySearchWhere;
            }
            set
            {
                strKeySearchWhere = value;
            }
        }

        private string GetDefultSearchPage(string pageUrl, SEARCH_PAGE_LIST default_page, string moduleFlag)
        {
            XYECOM.Configuration.WebInfo webInfo = XYECOM.Configuration.WebInfo.Instance;

            string pageChar = XYECOM.Core.Utils.UrlEncode("{p}");

            if (default_page == SEARCH_PAGE_LIST.SEARCH_SELLER_SEARCH)
            {
                if (pageUrl.IndexOf("search/seller_search") != -1
                    || pageUrl.IndexOf("search/buyer_search") != -1
                    ) return pageUrl;

                if (webInfo.IsBogusStatic)
                    return "/search/seller_search-" + moduleFlag + "---------" + pageChar;
                else
                    return "/search/seller_search." + webInfo.WebSuffix + "?flag=" + moduleFlag;
            }

            if (default_page == SEARCH_PAGE_LIST.SEARCH_NEWS_SEARCH)
            {
                if (pageUrl.IndexOf("channel") != -1) return pageUrl;

                if (pageUrl.IndexOf("search/news_search") != -1) return pageUrl;

                if (webInfo.IsBogusStatic)
                    return "/search/news_search-------" + pageChar + "-";
                else
                    return "/search/news_search." + webInfo.WebSuffix;
            }

            if (default_page == SEARCH_PAGE_LIST.BAIKE_LIST)
            {
                if (webInfo.IsBogusStatic)
                    return "/baike/list---" + pageChar;
                else
                    return "/baike/list." + webInfo.WebSuffix;
            }
            //if (default_page == SEARCH_PAGE_LIST.NEWS_CHANNEL)
            //{


            //    if (webInfo.IsBogusStatic)
            //        return "/search/news_search-------" + pageChar + "-";
            //    else
            //        return "/search/news_search." + webInfo.WebSuffix;  
            //}

            if (default_page == SEARCH_PAGE_LIST.JOB_LIST)
            {
                if (pageUrl.IndexOf("/job/list") != -1) return pageUrl;

                if (webInfo.IsBogusStatic)
                    return "/job/list-------" + pageChar + "-";
                else
                    return "/job/list." + webInfo.WebSuffix;

            }

            if (default_page == SEARCH_PAGE_LIST.JOB_RESUMELIST)
            {
                if (pageUrl.IndexOf("/job/resumelist") != -1) return pageUrl;

                if (webInfo.IsBogusStatic)
                    return "/job/resumelist---------" + pageChar + "-";
                else
                    return "/job/resumelist." + webInfo.WebSuffix;

            }

            return pageUrl;
        }



        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageUrl">目标页面URL</param>
        /// <param name="default_page">目标页面URL无法匹配时使用的默认页面(主要解决将分页标签放到非分页页面的其他页面上时分页的链接问题)</param>
        /// <param name="moduleFlag">模块标识</param>
        public void SetPagination(int pageIndex, string pageUrl, SEARCH_PAGE_LIST default_page, string moduleFlag)
        {
            if (this.TotalRecord < 1) return;

            string url = string.Empty;

            lock (this)
            {
                //是否需要转换
                bool exchange = config.IsBogusStatic;

                if (default_page == SEARCH_PAGE_LIST.TEAMBUY_LIST_SHOP)
                {
                    //如果是网店连接，则不需要按照伪静态规则转换，否则需要按照为静态链接格式转换
                    config.IsBogusStatic = true;
                    url = pageUrl;
                }
                else if (default_page == SEARCH_PAGE_LIST.SEARCH_BUY)
                {
                    config.IsBogusStatic = false;
                    url = pageUrl;
                }
                else
                {
                    url = GetDefultSearchPage(pageUrl, default_page, moduleFlag);
                }

                int num = 0;
                bool flag = true;
                this.PreviousPage = "";

                this.PageCount = ((this.TotalRecord + this.PageSize - 1) / this.PageSize);

                #region 上下页
                if (pageIndex > this.PageCount)
                {
                    this.NextPage = "<span>下一页</span>";
                    if (config.IsBogusStatic)
                    {
                        this.PreviousPage += "<a href=\"" + url.Replace("{p}", (pageIndex - 1) + "") + "." + config.WebSuffix + "\">上一页</a>";
                    }
                    else
                    {
                        if (url.IndexOf('?') > 0)
                            this.PreviousPage += "<a href=\"" + url + "&pageindex=" + (pageIndex - 1) + "\">上一页</a>";
                        else
                            this.PreviousPage += "<a href=\"" + url + "?pageindex=" + (pageIndex - 1) + "\">上一页</a>";
                    }
                }
                else if (pageIndex <= 1 && pageIndex != this.PageCount)
                {
                    this.PreviousPage = "<span>上一页</span>";
                    if (config.IsBogusStatic)
                    {
                        this.NextPage = "<a href=\"" + url.Replace("{p}", (pageIndex + 1) + "") + "." + config.WebSuffix + "\">下一页</a>";
                    }
                    else
                    {
                        if (url.IndexOf('?') > 0)
                            this.NextPage = "<a href=\"" + url + "&pageindex=" + (pageIndex + 1) + "\">下一页</a>";
                        else
                            this.NextPage = "<a href=\"" + url + "?pageindex=" + (pageIndex + 1) + "\">下一页</a>";
                    }
                }
                else if (pageIndex > 1 && pageIndex < this.PageCount)
                {
                    if (config.IsBogusStatic)
                    {
                        this.NextPage = "<a href=\"" + url.Replace("{p}", (pageIndex + 1) + "") + "." + config.WebSuffix + "\">下一页</a>";
                        this.PreviousPage += "<a href=\"" + url.Replace("{p}", (pageIndex - 1) + "") + "." + config.WebSuffix + "\">上一页</a>";
                    }
                    else
                    {
                        if (url.IndexOf('?') > 0)
                        {
                            this.NextPage = "<a href=\"" + url + "&pageindex=" + (pageIndex + 1) + "\">下一页</a>";
                            this.PreviousPage += "<a href=\"" + url + "&pageindex=" + (pageIndex - 1) + "\">上一页</a>";
                        }
                        else
                        {
                            this.NextPage = "<a href=\"" + url + "?pageindex=" + (pageIndex + 1) + "\">下一页</a>";
                            this.PreviousPage += "<a href=\"" + url + "?pageindex=" + (pageIndex - 1) + "\">上一页</a>";
                        }
                    }
                }
                else if (pageIndex == this.PageCount && this.PageCount != 1)
                {
                    this.NextPage = "<span>下一页</span>";

                    if (config.IsBogusStatic)
                    {
                        this.PreviousPage += "<a href=\"" + url.Replace("{p}", (pageIndex - 1) + "") + "." + config.WebSuffix + "\">上一页</a>";
                    }
                    else
                    {
                        if (url.IndexOf('?') > 0)
                            this.PreviousPage += "<a href=\"" + url + "&pageindex=" + (pageIndex - 1) + "\">上一页</a>";
                        else
                            this.PreviousPage += "<a href=\"" + url + "?pageindex=" + (pageIndex - 1) + "\">上一页</a>";
                    }
                }
                else if (pageIndex == this.PageCount && this.PageCount == 1)
                {
                    this.PreviousPage += "<span>上一页</span>";
                    this.NextPage = "<span>下一页</span>";
                }
                #endregion

                #region 数字页面
                for (int i = 1; i <= this.PageCount; i++)
                {
                    if (pageIndex <= 10)
                    {
                        if (num < 10)
                        {
                            if (i == pageIndex)
                                this.NumPage += "<span>" + i + "</span>";
                            else
                            {
                                if (config.IsBogusStatic)
                                {
                                    this.NumPage += "<a href=\"" + url.Replace("{p}", i + "") + "." + config.WebSuffix + "\">" + i + "</a>";
                                }
                                else
                                {
                                    if (url.IndexOf('?') > 0)
                                        this.NumPage += "<a href=\"" + url + "&pageindex=" + i + "\">" + i + "</a>";
                                    else
                                        this.NumPage += "<a href=\"" + url + "?pageindex=" + i + "\">" + i + "</a>";
                                }
                            }
                        }
                    }
                    else
                    {
                        if (num < 3)
                        {
                            if (config.IsBogusStatic)
                            {
                                this.NumPage += "<a href=\"" + url.Replace("{p}", i + "") + "." + config.WebSuffix + "\">" + i + "</a>";
                            }
                            else
                            {
                                if (url.IndexOf('?') > 0)
                                    this.NumPage += "<a href=\"" + url + "&pageindex=" + i + "\">" + i + "</a>";
                                else
                                    this.NumPage += "<a href=\"" + url + "?pageindex=" + i + "\">" + i + "</a>";
                            }
                        }
                        else
                        {
                            if (pageIndex == this.PageCount - 4)
                            {
                                flag = false;
                            }
                            if (pageIndex == this.PageCount - 3)
                            {
                                flag = false;
                            }
                            if (i == pageIndex)
                            {
                                this.NumPage += "<span>" + i + "</span>";
                            }

                            else if (i == pageIndex - 1 && i != this.PageCount - 1)
                            {
                                this.NumPage += "．．．";

                                if (config.IsBogusStatic)
                                {
                                    this.NumPage += "<a href=\"" + url.Replace("{p}", i + "") + "." + config.WebSuffix + "\">" + i + "</a>";
                                }
                                else
                                {
                                    if (url.IndexOf('?') > 0)
                                        this.NumPage += "<a href=\"" + url + "&pageindex=" + i + "\">" + i + "</a>";
                                    else
                                        this.NumPage += "<a href=\"" + url + "?pageindex=" + i + "\">" + i + "</a>";
                                }
                            }
                            else if (i == this.PageCount - 2 && i != pageIndex - 1)
                            {
                                if (flag)
                                    this.NumPage += "．．．";
                                if (config.IsBogusStatic)
                                {
                                    this.NumPage += "<a href=\"" + url.Replace("{p}", i + "") + "." + config.WebSuffix + "\">" + i + "</a>";
                                }
                                else
                                {
                                    if (url.IndexOf('?') > 0)
                                        this.NumPage += "<a href=\"" + url + "&pageindex=" + i + "\">" + i + "</a>";
                                    else
                                        this.NumPage += "<a href=\"" + url + "?pageindex=" + i + "\">" + i + "</a>";
                                }
                                flag = true;
                            }
                            else if (i == this.PageCount - 2 && i == pageIndex - 1)
                            {
                                if (config.IsBogusStatic)
                                {
                                    this.NumPage += "<a href=\"" + url + "-" + i + "." + config.WebSuffix + "\">" + i + "</a>";
                                }
                                else
                                {
                                    if (url.IndexOf('?') > 0)
                                        this.NumPage += "<a href=\"" + url + "&pageindex=" + i + "\">" + i + "</a>";
                                    else
                                        this.NumPage += "<a href=\"" + url + "?pageindex=" + i + "\">" + i + "</a>";
                                }
                            }
                            else if (i == this.PageCount || i == pageIndex + 1)
                            {
                                if (config.IsBogusStatic)
                                {
                                    this.NumPage += "<a href=\"" + url.Replace("{p}", i + "") + "." + config.WebSuffix + "\">" + i + "</a>";
                                }
                                else
                                {
                                    if (url.IndexOf('?') > 0)
                                        this.NumPage += "<a href=\"" + url + "&pageindex=" + i + "\">" + i + "</a>";
                                    else
                                        this.NumPage += "<a href=\"" + url + "?pageindex=" + i + "\">" + i + "</a>";
                                }

                            }
                            else if (i == this.PageCount - 1)
                            {
                                if (config.IsBogusStatic)
                                {
                                    this.NumPage += "<a href=\"" + url.Replace("{p}", i + "") + "." + config.WebSuffix + "\">" + i + "</a>";
                                }
                                else
                                {
                                    if (url.IndexOf('?') > 0)
                                        this.NumPage += "<a href=\"" + url + "&pageindex=" + i + "\">" + i + "</a>";
                                    else
                                        this.NumPage += "<a href=\"" + url + "?pageindex=" + i + "\">" + i + "</a>";
                                }
                            }
                        }

                    }

                    num++;
                }
                #endregion
                config.IsBogusStatic = exchange;
            }
        }
        #endregion


        protected virtual string GetLabelRangeCondition()
        {
            return string.Empty;
        }
        private bool _isPlatForm = true;

        public bool IsPlatForm
        {
            get;
            set;
        }
    }
}