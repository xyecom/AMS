using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Data;

namespace XYECOM.Label
{
    /**************************************************
     * XYECOM.Label.ContentLabelManager.cs
     * ������ʶ��TC 20080618
     * 
     * �������������ݱ�ǩ������
     * 
     *************************************************/

    /// <summary>
    /// ���ݱ�ǩ��������
    /// </summary>
    public class ContentLabelManager : LabelManger, IPaging
    {
        //private ContentLabelManager instance = null;

        //��ǩ��Ϣ
        private XYECOM.Model.LabelInfo _labelInfo = null;
        //��ǩԭʼ����
        private LabelParameterInfo paramInfo = null;
        //���ݲ�ѯ����
        private LabelQueryParameterInfo queryParamInfo = null;

        static object lockHelper = new object();

        /// <summary>
        /// ��ȡ��ǩ��������ʵ��
        /// </summary>
        /// <param name="labelName"></param>
        /// <returns></returns>
        public ContentLabelManager GetInstance(string labelName)
        {
            //ȥ����ǩǰ���XY_
            labelName = labelName.Substring(3);

            _labelInfo = new XYECOM.Business.Label().GetItem(labelName);


            if (_labelInfo == null)
            {
                throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + "�����쳣��LabelName:��" + labelName + "��������");
            }

            //����ԭʼ����
            paramInfo = AnalysesParameter(_labelInfo.LabelContent);

            //���ؾ��崦����(���ݲ�ͬ��ǩ���ز�ͬ�Ķ���ʵ��)
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
        /// ��ȡ���
        /// </summary>
        /// <returns></returns>
        public override string CreateHTML()
        {
            if (_labelInfo.LabelContent.Equals(""))
            {
                WriteLog("���ݱ�ǩ�������󣬱�ǩ " + _labelInfo.LabelName + " ���������ڡ�");
                return "���ı�ǩ��������!";
            }

            string result = GetResult();

            return result;
        }

        /// <summary>
        /// ��ȡ���շ����滻���ַ������
        /// </summary>
        /// <param name="labelInfo">��ǩ��Ϣ����</param>
        /// <returns></returns>
        public string GetResult()
        {
            //��ȡ�������ݿ��ѯ����
            queryParamInfo = GetQueryParameter();
            //���ݲ�����ȡ����
            System.Data.DataTable table = GetDataResult();

            StringBuilder strHTML = new StringBuilder("");

            strHTML.Append(_labelInfo.LabelStyleHead);   //��ʽͷ�����

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
        /// �ֽ����ԭʼ����
        /// </summary>
        /// <param name="labelParam">��ǩ�����ַ���</param>
        /// <returns></returns>
        protected static LabelParameterInfo AnalysesParameter(string labelParam)
        {
            LabelParameterInfo info = null;

            //ȥ��������ߵ� "{" ���ұߵ�"}"
            labelParam = labelParam.Substring(1).Substring(0, labelParam.Length - 2);

            //�ֽ����
            string[] labelParams = labelParam.Split('��');

            if (labelParams.Length > 0) info = new LabelParameterInfo();

            for (int i = 0; i < labelParams.Length; i++)
            {
                if (i == 0)
                {
                    info.LabelFlagName = labelParams[0].ToString().Split('$')[1].ToString();
                    continue;
                }

                //����������������������뼯��
                string key = labelParams[i].ToString().Split('$')[0].ToString();
                string value = labelParams[i].ToString().Split('$')[1].ToString();

                info.ParamList.Add(key, value);
            }

            return info;
        }

        /// <summary>
        /// ��ȡ��ǩ�е������ֶ�����
        /// </summary>
        /// <param name="labelBody">��ǩ��</param>
        /// <returns></returns>
        protected string GetColumnNames(string labelBody)
        {
            return new FieldManager().GetColumnName(labelBody);
        }

        #region ����

        /// <summary>
        /// ��ǩ����
        /// </summary>
        protected LabelParameterInfo ParamInfo
        {
            set { paramInfo = value; }
            get { return paramInfo; }
        }

        /// <summary>
        /// ��ǩ���ݲ�ѯ����
        /// </summary>
        protected LabelQueryParameterInfo QueryParamInfo
        {
            set { queryParamInfo = value; }
            get { return queryParamInfo; }
        }

        /// <summary>
        /// ��ǩ��Ϣ
        /// </summary>
        protected Model.LabelInfo _LabelInfo
        {
            set { _labelInfo = value; }
            get { return _labelInfo; }
        }

        private ContentLabelType labelContentType = ContentLabelType.Normal;

        /// <summary>
        /// ��ǩ��������
        /// </summary>
        public ContentLabelType LabelContentType
        {
            get { return labelContentType; }
            set { this.labelContentType = value; }
        }

        #endregion

        #region ���󷽷�
        /// <summary>
        /// ���ݱ�ǩ������ȡ
        /// </summary>
        /// <returns></returns>
        protected virtual string GetCondition() { return ""; }
        /// <summary>
        /// ��������ȡ��ǩ��ѯ����
        /// </summary>
        /// <returns></returns>
        protected virtual LabelQueryParameterInfo GetQueryParameter() { return null; }
        /// <summary>
        /// ��ȡ����
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
                    //���û����Ϣ�Ƿ��ؿձ��
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
        /// ��ȡ������ϢId
        /// </summary>
        /// <param name="rankKeyId">�����ؼ���Id</param>
        /// <param name="rank">����</param>
        /// <param name="moduleName">ģ������</param>
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

        #region ��ҳ����(ʵ��IPaging�ӿ�)

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

        #region IPaging ��Ա
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
        /// ��ҳ
        /// </summary>
        /// <param name="pageIndex">ҳ��</param>
        /// <param name="pageUrl">Ŀ��ҳ��URL</param>
        /// <param name="default_page">Ŀ��ҳ��URL�޷�ƥ��ʱʹ�õ�Ĭ��ҳ��(��Ҫ�������ҳ��ǩ�ŵ��Ƿ�ҳҳ�������ҳ����ʱ��ҳ����������)</param>
        /// <param name="moduleFlag">ģ���ʶ</param>
        public void SetPagination(int pageIndex, string pageUrl, SEARCH_PAGE_LIST default_page, string moduleFlag)
        {
            if (this.TotalRecord < 1) return;

            string url = string.Empty;

            lock (this)
            {
                //�Ƿ���Ҫת��
                bool exchange = config.IsBogusStatic;

                if (default_page == SEARCH_PAGE_LIST.TEAMBUY_LIST_SHOP)
                {
                    //������������ӣ�����Ҫ����α��̬����ת����������Ҫ����Ϊ��̬���Ӹ�ʽת��
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

                #region ����ҳ
                if (pageIndex > this.PageCount)
                {
                    this.NextPage = "<span>��һҳ</span>";
                    if (config.IsBogusStatic)
                    {
                        this.PreviousPage += "<a href=\"" + url.Replace("{p}", (pageIndex - 1) + "") + "." + config.WebSuffix + "\">��һҳ</a>";
                    }
                    else
                    {
                        if (url.IndexOf('?') > 0)
                            this.PreviousPage += "<a href=\"" + url + "&pageindex=" + (pageIndex - 1) + "\">��һҳ</a>";
                        else
                            this.PreviousPage += "<a href=\"" + url + "?pageindex=" + (pageIndex - 1) + "\">��һҳ</a>";
                    }
                }
                else if (pageIndex <= 1 && pageIndex != this.PageCount)
                {
                    this.PreviousPage = "<span>��һҳ</span>";
                    if (config.IsBogusStatic)
                    {
                        this.NextPage = "<a href=\"" + url.Replace("{p}", (pageIndex + 1) + "") + "." + config.WebSuffix + "\">��һҳ</a>";
                    }
                    else
                    {
                        if (url.IndexOf('?') > 0)
                            this.NextPage = "<a href=\"" + url + "&pageindex=" + (pageIndex + 1) + "\">��һҳ</a>";
                        else
                            this.NextPage = "<a href=\"" + url + "?pageindex=" + (pageIndex + 1) + "\">��һҳ</a>";
                    }
                }
                else if (pageIndex > 1 && pageIndex < this.PageCount)
                {
                    if (config.IsBogusStatic)
                    {
                        this.NextPage = "<a href=\"" + url.Replace("{p}", (pageIndex + 1) + "") + "." + config.WebSuffix + "\">��һҳ</a>";
                        this.PreviousPage += "<a href=\"" + url.Replace("{p}", (pageIndex - 1) + "") + "." + config.WebSuffix + "\">��һҳ</a>";
                    }
                    else
                    {
                        if (url.IndexOf('?') > 0)
                        {
                            this.NextPage = "<a href=\"" + url + "&pageindex=" + (pageIndex + 1) + "\">��һҳ</a>";
                            this.PreviousPage += "<a href=\"" + url + "&pageindex=" + (pageIndex - 1) + "\">��һҳ</a>";
                        }
                        else
                        {
                            this.NextPage = "<a href=\"" + url + "?pageindex=" + (pageIndex + 1) + "\">��һҳ</a>";
                            this.PreviousPage += "<a href=\"" + url + "?pageindex=" + (pageIndex - 1) + "\">��һҳ</a>";
                        }
                    }
                }
                else if (pageIndex == this.PageCount && this.PageCount != 1)
                {
                    this.NextPage = "<span>��һҳ</span>";

                    if (config.IsBogusStatic)
                    {
                        this.PreviousPage += "<a href=\"" + url.Replace("{p}", (pageIndex - 1) + "") + "." + config.WebSuffix + "\">��һҳ</a>";
                    }
                    else
                    {
                        if (url.IndexOf('?') > 0)
                            this.PreviousPage += "<a href=\"" + url + "&pageindex=" + (pageIndex - 1) + "\">��һҳ</a>";
                        else
                            this.PreviousPage += "<a href=\"" + url + "?pageindex=" + (pageIndex - 1) + "\">��һҳ</a>";
                    }
                }
                else if (pageIndex == this.PageCount && this.PageCount == 1)
                {
                    this.PreviousPage += "<span>��һҳ</span>";
                    this.NextPage = "<span>��һҳ</span>";
                }
                #endregion

                #region ����ҳ��
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
                                this.NumPage += "������";

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
                                    this.NumPage += "������";
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