using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Page
{
    /// <summary>
    /// ǰ̨ҳ��ͨ�ø���
    /// </summary>
    public class ForeBasePage:BasePage
    {
        #region ���µ������
        /// <summary>
        /// ���µ���
        /// </summary>
        /// <param name="moduleName">ģ��Ӣ����</param>
        /// <param name="classId">���Id</param>
        protected void UpdateNavigation(string moduleName, long classId)
        {
            string typeId = classId.ToString();

            StringBuilder val = new StringBuilder();
            val.Append("<a href='/'>��ҳ</a>");
            val.Append(" > ");

            val.Append("<a href='" + GetHref(moduleName,0) + "'>");
            val.Append(GetModuleCNName(moduleName));
            val.Append("</a>");

            if (classId != 0)
            {
                List<Model.XYClassInfo> parentInfos = Business.XYClass.GetParentClassInfos(moduleName, classId);
                parentInfos.Reverse();
                foreach (Model.XYClassInfo info in parentInfos)
                {
                    val.Append(" > ");
                    val.Append("<a href='" + GetHref(moduleName, info.ClassId) + "'>");
                    val.Append(info.ClassName);
                    val.Append("</a>");
                }
            }

            //val.Append(" > ��ϸ��Ϣ");

            pageinfo.Navigation = val.ToString();
        }

        /// <summary>
        /// ��ȡ����������ָ����������ӵ�ַ������ʵ��ҳ����и�д
        /// </summary>
        /// <param name="moduleName">ģ������</param>
        /// <param name="typeId">����Id</param>
        /// <returns></returns>
        protected virtual string GetHref(string moduleName, long typeId)
        {
            string linkUrl = config.WebURL + "search/seller_search." + config.suffix + "?flag={0}&typeid={1}";
            string bogueStaticLinkUrl = config.WebURL + "search/seller_search-{0}-{1}--------." + config.suffix;

            string strTypeId = typeId.ToString();

            if (typeId == 0) strTypeId = "";
            
            if (webInfo.IsBogusStatic)
            {
                return String.Format(bogueStaticLinkUrl, moduleName, strTypeId);
            }

            return String.Format(linkUrl, moduleName, strTypeId);
        }
        #endregion

        /// <summary>
        /// ��ȡ��Ϣ���������ࣨ�����Ϣ���ڵ����������� ����������_��������_һ������ �� ��ʽ���أ���Ҫ����SEO��
        /// </summary>
        /// <param name="moduleName">ģ������</param>
        /// <param name="classId">����ID</param>
        /// <returns></returns>
        protected string GetAllClassNameForSEO(string moduleName, long classId)
        {
            string className = "";

            if (classId > 0)
            {
                List<Model.XYClassInfo> infos = Business.XYClass.GetParentClassInfos(moduleName, classId);

                foreach (Model.XYClassInfo info in infos)
                {
                    if (className.Equals(""))
                        className = info.ClassName;
                    else
                        className += "_" + info.ClassName;
                }
            }

            return className;
        }

        #region ��ҳ����(news/comments ҳ����)
        /// <summary>
        /// ��ҳ����
        /// ����urlҳ���������pageindex
        /// 
        /// ������α��̬������£�url����Ҫ�滻Ϊҳ�����ֵĲ�������{p}����
        /// �磺http://www.site.com/sell_search-offer---------{p}-.do
        /// �ڵ�ַ����֮�䣬����XYECOM.Core.Utils.UrlEncode()�����Ե�ַ���б���
        /// </summary>
        /// <param name="pageIndex">��ǰҳ��</param>
        /// <param name="pageUrl">ҳ���ַ</param>
        [Obsolete]
        public void ListPage(int pageindex, string _url)
        {
            string url = XYECOM.Core.Utils.UrlDecode(_url);

            int num = 0;
            bool flag = true;
            this.pageinfo.PreviousPage = "";

            //string nexthtmlurl = XYECOM.Core.XYRequest.GetQueryString("next");
            //string previoushtmlurl = XYECOM.Core.XYRequest.GetQueryString("previous");
            //string htmlurl = XYECOM.Core.XYRequest.GetQueryString("url");
            //string htmlsuffix = XYECOM.Core.XYRequest.GetQueryString("htmlsuffix");

            #region ��¼��������0
            if (pageinfo.TotalRecord > 0)
            {
                #region ҳ��Ϊ����
                if ((pageinfo.TotalRecord % pageinfo.PageSize) == 0)
                {
                    this.pageinfo.PageCount = (pageinfo.TotalRecord / pageinfo.PageSize);

                    #region ����ҳ
                    if (pageindex > pageinfo.PageCount)
                    {
                        this.pageinfo.NextPage = "<span>��һҳ</span>";
                        //if (previoushtmlurl == "")
                        //{
                        if (config.BogusStatic)
                        {
                            this.pageinfo.PreviousPage += "<a href=\"" + url.Replace("{p}", (pageindex - 1) + "") + "." + config.Suffix + "\">��һҳ</a>";
                        }
                        else
                        {
                            if (url.IndexOf('?') > 0)
                                this.pageinfo.PreviousPage += "<a href=\"" + url + "&pageindex=" + (pageindex - 1) + "\">��һҳ</a>";
                            else
                                this.pageinfo.PreviousPage += "<a href=\"" + url + "?pageindex=" + (pageindex - 1) + "\">��һҳ</a>";
                        }
                        //}
                        //else
                        //{
                        //    if (pageindex == 1)
                        //        this.pageinfo.PreviousPage += "<a href=\"" + htmlurl + "." + htmlsuffix + "\">��һҳ</a>";
                        //    else
                        //        this.pageinfo.PreviousPage += "<a href=\"" + previoushtmlurl + "\">��һҳ</a>";
                        //}
                    }
                    else if (pageindex <= 1 && pageindex != pageinfo.PageCount)
                    {
                        this.pageinfo.PreviousPage = "<span>��һҳ</span>";
                        //if (nexthtmlurl == "")
                        //{
                        if (config.BogusStatic)
                        {
                            this.pageinfo.NextPage = "<a href=\"" + url.Replace("{p}", (pageindex + 1) + "") + "." + config.Suffix + "\">��һҳ</a>";
                        }
                        else
                        {
                            if (url.IndexOf('?') > 0)
                                this.pageinfo.NextPage = "<a href=\"" + url + "&pageindex=" + (pageindex + 1) + "\">��һҳ</a>";
                            else
                                this.pageinfo.NextPage = "<a href=\"" + url + "?pageindex=" + (pageindex + 1) + "\">��һҳ</a>";
                        }
                        //}
                        //else
                        //    this.pageinfo.NextPage = "<a href=\"" + nexthtmlurl + "\">��һҳ</a>";
                    }
                    else if (pageindex > 1 && pageindex < pageinfo.PageCount)
                    {

                        //if (nexthtmlurl == "" && previoushtmlurl == "")
                        //{
                        if (config.BogusStatic)
                        {
                            this.pageinfo.NextPage = "<a href=\"" + url.Replace("{p}", (pageindex + 1).ToString()) + "." + config.Suffix + "\">��һҳ</a>";
                            this.pageinfo.PreviousPage += "<a href=\"" + url.Replace("{p}", (pageindex - 1).ToString()) + "." + config.Suffix + "\">��һҳ</a>";
                        }
                        else
                        {
                            if (url.IndexOf('?') > 0)
                            {
                                this.pageinfo.NextPage = "<a href=\"" + url + "&pageindex=" + (pageindex + 1) + "\">��һҳ</a>";
                                this.pageinfo.PreviousPage += "<a href=\"" + url + "&pageindex=" + (pageindex - 1) + "\">��һҳ</a>";
                            }
                            else
                            {
                                this.pageinfo.NextPage = "<a href=\"" + url + "?pageindex=" + (pageindex + 1) + "\">��һҳ</a>";
                                this.pageinfo.PreviousPage += "<a href=\"" + url + "?pageindex=" + (pageindex - 1) + "\">��һҳ</a>";
                            }
                        }
                        //}
                        //else
                        //{
                        //    if (pageindex == 1)
                        //        this.pageinfo.PreviousPage += "<a href=\"" + htmlurl + "." + htmlsuffix + "\">��һҳ</a>";
                        //    else
                        //        this.pageinfo.PreviousPage += "<a href=\"" + previoushtmlurl + "\">��һҳ</a>";
                        //    this.pageinfo.NextPage = "<a href=\"" + nexthtmlurl + "\">��һҳ</a>";
                        //}
                    }
                    else if (pageindex == pageinfo.PageCount && pageinfo.PageCount != 1)
                    {
                        this.pageinfo.NextPage = "<span>��һҳ</span>";
                        //if (previoushtmlurl == "")
                        //{
                        if (config.BogusStatic)
                        {
                            this.pageinfo.PreviousPage += "<a href=\"" + url.Replace("{p}", (pageindex - 1) + "") + "." + config.Suffix + "\">��һҳ</a>";
                        }
                        else
                        {
                            if (url.IndexOf('?') > 0)
                                this.pageinfo.PreviousPage += "<a href=\"" + url + "&pageindex=" + (pageindex - 1) + "\">��һҳ</a>";
                            else
                                this.pageinfo.PreviousPage += "<a href=\"" + url + "?pageindex=" + (pageindex - 1) + "\">��һҳ</a>";
                        }
                        //}
                        //else
                        //{
                        //    if (pageindex == 1)
                        //        this.pageinfo.PreviousPage += "<a href=\"" + htmlurl + "." + htmlsuffix + "\">��һҳ</a>";
                        //    else
                        //        this.pageinfo.PreviousPage += "<a href=\"" + previoushtmlurl + "\">��һҳ</a>";
                        //}

                    }
                    else if (pageindex == pageinfo.PageCount && pageinfo.PageCount == 1)
                    {
                        this.pageinfo.PreviousPage += "<span>��һҳ</span>";
                        this.pageinfo.NextPage = "<span>��һҳ</span>";
                    }
                    #endregion

                    #region ����ҳ��
                    for (int i = 1; i <= pageinfo.PageCount; i++)
                    {
                        if (pageindex <= 10)
                        {
                            if (num < 10)
                            {
                                if (i == pageindex)
                                    this.pageinfo.NumPage += "<span>" + i + "</span>";
                                else
                                {
                                    //if (htmlurl == "")
                                    //{
                                    if (config.BogusStatic)
                                    {
                                        this.pageinfo.NumPage += "<a href=\"" + url.Replace("{p}", i + "") + "." + config.Suffix + "\">" + i + "</a>";
                                    }
                                    else
                                    {
                                        if (url.IndexOf('?') > 0)
                                            this.pageinfo.NumPage += "<a href=\"" + url + "&pageindex=" + i + "\">" + i + "</a>";
                                        else
                                            this.pageinfo.NumPage += "<a href=\"" + url + "?pageindex=" + i + "\">" + i + "</a>";
                                    }

                                    //}
                                    //else
                                    //{
                                    //    if (i == 1)
                                    //        this.pageinfo.NumPage += "<a href=\"" + htmlurl + "." + htmlsuffix + "\">" + i + "</a>";
                                    //    else
                                    //        this.pageinfo.NumPage += "<a href=\"" + htmlurl + "_" + i + "." + htmlsuffix + "\">" + i + "</a>";

                                    //}
                                }
                            }

                        }
                        else
                        {
                            if (num < 3)
                            {
                                //if (htmlurl == "")
                                //{
                                if (config.BogusStatic)
                                {
                                    this.pageinfo.NumPage += "<a href=\"" + url.Replace("{p}", i + "") + "." + config.Suffix + "\">" + i + "</a>";
                                }
                                else
                                {
                                    if (url.IndexOf('?') > 0)
                                        this.pageinfo.NumPage += "<a href=\"" + url + "&pageindex=" + i + "\">" + i + "</a>";
                                    else
                                        this.pageinfo.NumPage += "<a href=\"" + url + "?pageindex=" + i + "\">" + i + "</a>";
                                }
                                //}
                                //else
                                //{
                                //    if (i == 1)
                                //        this.pageinfo.NumPage += "<a href=\"" + htmlurl + "." + htmlsuffix + "\">" + i + "</a>";
                                //    else
                                //        this.pageinfo.NumPage += "<a href=\"" + htmlurl + "_" + i + "." + htmlsuffix + "\">" + i + "</a>";
                                //}
                            }
                            else
                            {
                                if (pageindex == pageinfo.PageCount - 4)
                                {
                                    flag = false;
                                }
                                if (pageindex == pageinfo.PageCount - 3)
                                {
                                    flag = false;
                                }
                                if (i == pageindex)
                                {
                                    this.pageinfo.NumPage += "<span>" + i + "</span>";
                                }

                                else if (i == pageindex - 1 && i != pageinfo.PageCount - 1)
                                {
                                    this.pageinfo.NumPage += "������";
                                    //if (htmlurl == "")
                                    //{
                                    if (config.BogusStatic)
                                    {
                                        this.pageinfo.NumPage += "<a href=\"" + url.Replace("{p}", i + "") + "." + config.Suffix + "\">" + i + "</a>";
                                    }
                                    else
                                    {
                                        if (url.IndexOf('?') > 0)
                                            this.pageinfo.NumPage += "<a href=\"" + url + "&pageindex=" + i + "\">" + i + "</a>";
                                        else
                                            this.pageinfo.NumPage += "<a href=\"" + url + "?pageindex=" + i + "\">" + i + "</a>";
                                    }
                                    //}
                                    //else
                                    //    this.pageinfo.NumPage += "<a href=\"" + htmlurl + "_" + i + "." + htmlsuffix + "\">" + i + "</a>";
                                }
                                else if (i == pageinfo.PageCount - 2 && i != pageindex - 1)
                                {
                                    if (flag)
                                        this.pageinfo.NumPage += "������";
                                    //if (htmlurl == "")
                                    //{
                                    if (config.BogusStatic)
                                    {
                                        this.pageinfo.NumPage += "<a href=\"" + url.Replace("{p}", i + "") + "." + config.Suffix + "\">" + i + "</a>";
                                    }
                                    else
                                    {
                                        if (url.IndexOf('?') > 0)
                                            this.pageinfo.NumPage += "<a href=\"" + url + "&pageindex=" + i + "\">" + i + "</a>";
                                        else
                                            this.pageinfo.NumPage += "<a href=\"" + url + "?pageindex=" + i + "\">" + i + "</a>";
                                    }
                                    //}
                                    //else
                                    //    this.pageinfo.NumPage += "<a href=\"" + htmlurl + "_" + i + "." + htmlsuffix + "\">" + i + "</a>";
                                    flag = true;
                                }
                                else if (i == pageinfo.PageCount - 2 && i == pageindex - 1)
                                {
                                    //if (htmlurl == "")
                                    //{
                                    if (config.BogusStatic)
                                    {
                                        this.pageinfo.NumPage += "<a href=\"" + url.Replace("{p}", i + "") + "." + config.Suffix + "\">" + i + "</a>";
                                    }
                                    else
                                    {
                                        if (url.IndexOf('?') > 0)
                                            this.pageinfo.NumPage += "<a href=\"" + url + "&pageindex=" + i + "\">" + i + "</a>";
                                        else
                                            this.pageinfo.NumPage += "<a href=\"" + url + "?pageindex=" + i + "\">" + i + "</a>";
                                    }
                                    //}
                                    //else
                                    //    this.pageinfo.NumPage += "<a href=\"" + htmlurl + "_" + i + "." + htmlsuffix + "\">" + i + "</a>";
                                }
                                else if (i == pageinfo.PageCount || i == pageindex + 1)
                                {
                                    //if (htmlurl == "")
                                    //{
                                    if (config.BogusStatic)
                                    {
                                        this.pageinfo.NumPage += "<a href=\"" + url.Replace("{p}", i + "") + "." + config.Suffix + "\">" + i + "</a>";
                                    }
                                    else
                                    {
                                        if (url.IndexOf('?') > 0)
                                            this.pageinfo.NumPage += "<a href=\"" + url + "&pageindex=" + i + "\">" + i + "</a>";
                                        else
                                            this.pageinfo.NumPage += "<a href=\"" + url + "?pageindex=" + i + "\">" + i + "</a>";
                                    }
                                    //}
                                    //else
                                    //    this.pageinfo.NumPage += "<a href=\"" + htmlurl + "_" + i + "." + htmlsuffix + "\">" + i + "</a>";
                                }
                                else if (i == pageinfo.PageCount - 1)
                                {
                                    //if (htmlurl == "")
                                    //{
                                    if (config.BogusStatic)
                                    {
                                        this.pageinfo.NumPage += "<a href=\"" + url.Replace("{p}", i + "") + "." + config.Suffix + "\">" + i + "</a>";
                                    }
                                    else
                                    {
                                        if (url.IndexOf('?') > 0)
                                            this.pageinfo.NumPage += "<a href=\"" + url + "&pageindex=" + i + "\">" + i + "</a>";
                                        else
                                            this.pageinfo.NumPage += "<a href=\"" + url + "?pageindex=" + i + "\">" + i + "</a>";
                                    }
                                    //}
                                    //else
                                    //    this.pageinfo.NumPage += "<a href=\"" + htmlurl + "_" + i + "." + htmlsuffix + "\">" + i + "</a>";
                                }
                            }
                        }
                        num++;
                    }
                    #endregion
                }
                #endregion

                #region ҳ����������
                else if ((pageinfo.TotalRecord % pageinfo.PageSize) > 0)
                {
                    this.pageinfo.PageCount = (pageinfo.TotalRecord / pageinfo.PageSize) + 1;

                    #region ����ҳ
                    if (pageindex > pageinfo.PageCount)
                    {
                        this.pageinfo.NextPage = "<span>��һҳ</span>";
                        //if (previoushtmlurl == "")
                        //{
                        if (config.BogusStatic)
                        {
                            this.pageinfo.PreviousPage += "<a href=\"" + url.Replace("{p}", (pageindex - 1) + "") + "." + config.Suffix + "\">��һҳ</a>";
                        }
                        else
                        {
                            if (url.IndexOf('?') > 0)
                                this.pageinfo.PreviousPage += "<a href=\"" + url + "&pageindex=" + (pageindex - 1) + "\">��һҳ</a>";
                            else
                                this.pageinfo.PreviousPage += "<a href=\"" + url + "?pageindex=" + (pageindex - 1) + "\">��һҳ</a>";
                        }
                        //}
                        //else
                        //{
                        //    if (pageindex == 1)
                        //        this.pageinfo.PreviousPage += "<a href=\"" + htmlurl + "." + htmlsuffix + "\">��һҳ</a>";
                        //    else
                        //        this.pageinfo.PreviousPage += "<a href=\"" + previoushtmlurl + "\">��һҳ</a>";
                        //}
                    }
                    else if (pageindex <= 1 && pageindex != pageinfo.PageCount)
                    {
                        this.pageinfo.PreviousPage = "<span>��һҳ</span>";
                        //if (nexthtmlurl == "")
                        //{
                        if (config.BogusStatic)
                        {
                            this.pageinfo.NextPage = "<a href=\"" + url.Replace("{p}", (pageindex + 1) + "") + "." + config.Suffix + "\">��һҳ</a>";
                        }
                        else
                        {
                            if (url.IndexOf('?') > 0)
                                this.pageinfo.NextPage = "<a href=\"" + url + "&pageindex=" + (pageindex + 1) + "\">��һҳ</a>";
                            else
                                this.pageinfo.NextPage = "<a href=\"" + url + "?pageindex=" + (pageindex + 1) + "\">��һҳ</a>";
                        }
                        //}
                        //else
                        //    this.pageinfo.NextPage = "<a href=\"" + nexthtmlurl + "\">��һҳ</a>";
                    }
                    else if (pageindex > 1 && pageindex < pageinfo.PageCount)
                    {
                        //if (previoushtmlurl == "" && nexthtmlurl == "")
                        //{
                        if (config.BogusStatic)
                        {
                            this.pageinfo.NextPage = "<a href=\"" + url.Replace("{p}", (pageindex + 1) + "") + "." + config.Suffix + "\">��һҳ</a>";
                            this.pageinfo.PreviousPage += "<a href=\"" + url.Replace("{p}", (pageindex - 1) + "") + "." + config.Suffix + "\">��һҳ</a>";
                        }
                        else
                        {
                            if (url.IndexOf('?') > 0)
                            {
                                this.pageinfo.NextPage = "<a href=\"" + url + "&pageindex=" + (pageindex + 1) + "\">��һҳ</a>";
                                this.pageinfo.PreviousPage += "<a href=\"" + url + "&pageindex=" + (pageindex - 1) + "\">��һҳ</a>";
                            }
                            else
                            {
                                this.pageinfo.NextPage = "<a href=\"" + url + "?pageindex=" + (pageindex + 1) + "\">��һҳ</a>";
                                this.pageinfo.PreviousPage += "<a href=\"" + url + "?pageindex=" + (pageindex - 1) + "\">��һҳ</a>";
                            }
                        }
                        //}
                        //else
                        //{
                        //    if (pageindex == 1)
                        //        this.pageinfo.PreviousPage += "<a href=\"" + htmlurl + "." + htmlsuffix + "\">��һҳ</a>";
                        //    else
                        //        this.pageinfo.PreviousPage += "<a href=\"" + previoushtmlurl + "\">��һҳ</a>";
                        //    this.pageinfo.NextPage = "<a href=\"" + nexthtmlurl + "\">��һҳ</a>";
                        //}
                    }
                    else if (pageindex == pageinfo.PageCount && pageinfo.PageCount != 1)
                    {
                        this.pageinfo.NextPage = "<span>��һҳ</span>";
                        //if (previoushtmlurl == "")
                        //{
                        //    if (nexthtmlurl == "")
                        //    {
                        if (config.BogusStatic)
                        {
                            this.pageinfo.PreviousPage += "<a href=\"" + url.Replace("{p}", (pageindex - 1) + "") + "." + config.Suffix + "\">��һҳ</a>";
                        }
                        else
                        {
                            if (url.IndexOf('?') > 0)
                                this.pageinfo.PreviousPage += "<a href=\"" + url + "&pageindex=" + (pageindex - 1) + "\">��һҳ</a>";
                            else
                                this.pageinfo.PreviousPage += "<a href=\"" + url + "?pageindex=" + (pageindex - 1) + "\">��һҳ</a>";
                        }
                        //    }
                        //    else
                        //        this.pageinfo.NextPage = "<a href=\"" + nexthtmlurl + "\">��һҳ</a>";
                        //}
                        //else
                        //{
                        //    if (pageindex == 1)
                        //        this.pageinfo.PreviousPage += "<a href=\"" + htmlurl + "." + htmlsuffix + "\">��һҳ</a>";
                        //    else
                        //        this.pageinfo.PreviousPage += "<a href=\"" + previoushtmlurl + "\">��һҳ</a>";
                        //}
                    }
                    else if (pageindex == pageinfo.PageCount && pageinfo.PageCount == 1)
                    {
                        this.pageinfo.PreviousPage += "<span>��һҳ</span>";
                        this.pageinfo.NextPage = "<span>��һҳ</span>";
                    }
                    #endregion

                    #region ����ҳ��
                    for (int i = 1; i <= pageinfo.PageCount; i++)
                    {
                        if (pageindex <= 10)
                        {
                            if (num < 10)
                            {
                                if (i == pageindex)
                                    this.pageinfo.NumPage += "<span>" + i + "</span>";
                                else
                                {
                                    //if (htmlurl == "")
                                    //{
                                    if (config.BogusStatic)
                                    {
                                        this.pageinfo.NumPage += "<a href=\"" + url.Replace("{p}", i + "") + "." + config.Suffix + "\">" + i + "</a>";
                                    }
                                    else
                                    {
                                        if (url.IndexOf('?') > 0)
                                            this.pageinfo.NumPage += "<a href=\"" + url + "&pageindex=" + i + "\">" + i + "</a>";
                                        else
                                            this.pageinfo.NumPage += "<a href=\"" + url + "?pageindex=" + i + "\">" + i + "</a>";
                                    }
                                    //}
                                    //else
                                    //{
                                    //    if (i == 1)
                                    //        this.pageinfo.NumPage += "<a href=\"" + htmlurl + "." + htmlsuffix + "\">" + i + "</a>";
                                    //    else
                                    //        this.pageinfo.NumPage += "<a href=\"" + htmlurl + "_" + i + "." + htmlsuffix + "\">" + i + "</a>";
                                    //}
                                }
                            }
                        }
                        else
                        {
                            if (num < 3)
                            {
                                //if (htmlurl == "")
                                //{
                                if (config.BogusStatic)
                                {
                                    this.pageinfo.NumPage += "<a href=\"" + url.Replace("{p}", i + "") + "." + config.Suffix + "\">" + i + "</a>";
                                }
                                else
                                {
                                    if (url.IndexOf('?') > 0)
                                        this.pageinfo.NumPage += "<a href=\"" + url + "&pageindex=" + i + "\">" + i + "</a>";
                                    else
                                        this.pageinfo.NumPage += "<a href=\"" + url + "?pageindex=" + i + "\">" + i + "</a>";
                                }
                                //}
                                //else
                                //{
                                //    if (i == 1)
                                //        this.pageinfo.NumPage += "<a href=\"" + htmlurl + "." + htmlsuffix + "\">" + i + "</a>";
                                //    else
                                //        this.pageinfo.NumPage += "<a href=\"" + htmlurl + "_" + i + "." + htmlsuffix + "\">" + i + "</a>";
                                //}
                            }
                            else
                            {
                                if (pageindex == pageinfo.PageCount - 4)
                                {
                                    flag = false;
                                }
                                if (pageindex == pageinfo.PageCount - 3)
                                {
                                    flag = false;
                                }
                                if (i == pageindex)
                                {
                                    this.pageinfo.NumPage += "<span>" + i + "</span>";
                                }

                                else if (i == pageindex - 1 && i != pageinfo.PageCount - 1)
                                {
                                    this.pageinfo.NumPage += "������";
                                    //if (htmlurl == "")
                                    //{
                                    if (config.BogusStatic)
                                    {
                                        this.pageinfo.NumPage += "<a href=\"" + url.Replace("{p}", i + "") + "." + config.Suffix + "\">" + i + "</a>";
                                    }
                                    else
                                    {
                                        if (url.IndexOf('?') > 0)
                                            this.pageinfo.NumPage += "<a href=\"" + url + "&pageindex=" + i + "\">" + i + "</a>";
                                        else
                                            this.pageinfo.NumPage += "<a href=\"" + url + "?pageindex=" + i + "\">" + i + "</a>";
                                    }
                                    //}
                                    //else
                                    //{
                                    //    if (i == 1)
                                    //        this.pageinfo.NumPage += "<a href=\"" + htmlurl + "." + htmlsuffix + "\">" + i + "</a>";
                                    //    else
                                    //        this.pageinfo.NumPage += "<a href=\"" + htmlurl + "_" + i + "." + htmlsuffix + "\">" + i + "</a>";
                                    //}
                                }
                                else if (i == pageinfo.PageCount - 2 && i != pageindex - 1)
                                {
                                    if (flag)
                                        this.pageinfo.NumPage += "������";

                                    //if (htmlurl == "")
                                    //{
                                    if (config.BogusStatic)
                                    {
                                        this.pageinfo.NumPage += "<a href=\"" + url.Replace("{p}", i + "") + "." + config.Suffix + "\">" + i + "</a>";
                                    }
                                    else
                                    {
                                        if (url.IndexOf('?') > 0)
                                            this.pageinfo.NumPage += "<a href=\"" + url + "&pageindex=" + i + "\">" + i + "</a>";
                                        else
                                            this.pageinfo.NumPage += "<a href=\"" + url + "?pageindex=" + i + "\">" + i + "</a>";
                                    }
                                    //}
                                    //else
                                    //{
                                    //    if (i == 1)
                                    //        this.pageinfo.NumPage += "<a href=\"" + htmlurl + "." + htmlsuffix + "\">" + i + "</a>";
                                    //    else
                                    //        this.pageinfo.NumPage += "<a href=\"" + htmlurl + "_" + i + "." + htmlsuffix + "\">" + i + "</a>";
                                    //}
                                    flag = true;
                                }
                                else if (i == pageinfo.PageCount - 2 && i == pageindex - 1)
                                {
                                    //if (htmlurl == "")
                                    //{
                                    if (config.BogusStatic)
                                    {
                                        this.pageinfo.NumPage += "<a href=\"" + url + "-" + i + "." + config.Suffix + "\">" + i + "</a>";
                                    }
                                    else
                                    {
                                        if (url.IndexOf('?') > 0)
                                            this.pageinfo.NumPage += "<a href=\"" + url + "&pageindex=" + i + "\">" + i + "</a>";
                                        else
                                            this.pageinfo.NumPage += "<a href=\"" + url + "?pageindex=" + i + "\">" + i + "</a>";
                                    }
                                    //}
                                    //else
                                    //{
                                    //    if (i == 1)
                                    //        this.pageinfo.NumPage += "<a href=\"" + htmlurl + "." + htmlsuffix + "\">" + i + "</a>";
                                    //    else
                                    //        this.pageinfo.NumPage += "<a href=\"" + htmlurl + "_" + i + "." + htmlsuffix + "\">" + i + "</a>";
                                    //}
                                }
                                else if (i == pageinfo.PageCount || i == pageindex + 1)
                                {
                                    //if (htmlurl == "")
                                    //{
                                    if (config.BogusStatic)
                                    {
                                        this.pageinfo.NumPage += "<a href=\"" + url.Replace("{p}", i + "") + "." + config.Suffix + "\">" + i + "</a>";
                                    }
                                    else
                                    {
                                        if (url.IndexOf('?') > 0)
                                            this.pageinfo.NumPage += "<a href=\"" + url + "&pageindex=" + i + "\">" + i + "</a>";
                                        else
                                            this.pageinfo.NumPage += "<a href=\"" + url + "?pageindex=" + i + "\">" + i + "</a>";
                                    }
                                    //}
                                    //else
                                    //{
                                    //    if (i == 1)
                                    //        this.pageinfo.NumPage += "<a href=\"" + htmlurl + "." + htmlsuffix + "\">" + i + "</a>";
                                    //    else
                                    //        this.pageinfo.NumPage += "<a href=\"" + htmlurl + "_" + i + "." + htmlsuffix + "\">" + i + "</a>";
                                    //}

                                }
                                else if (i == pageinfo.PageCount - 1)
                                {
                                    //if (htmlurl == "")
                                    //{
                                    if (config.BogusStatic)
                                    {
                                        this.pageinfo.NumPage += "<a href=\"" + url.Replace("{p}", i + "") + "." + config.Suffix + "\">" + i + "</a>";
                                    }
                                    else
                                    {
                                        if (url.IndexOf('?') > 0)
                                            this.pageinfo.NumPage += "<a href=\"" + url + "&pageindex=" + i + "\">" + i + "</a>";
                                        else
                                            this.pageinfo.NumPage += "<a href=\"" + url + "?pageindex=" + i + "\">" + i + "</a>";
                                    }

                                    //}
                                    //else
                                    //{
                                    //    if (i == 1)
                                    //        this.pageinfo.NumPage += "<a href=\"" + htmlurl + "." + htmlsuffix + "\">" + i + "</a>";
                                    //    else
                                    //        this.pageinfo.NumPage += "<a href=\"" + htmlurl + "_" + i + "." + htmlsuffix + "\">" + i + "</a>";
                                    //}
                                }
                            }

                        }

                        num++;
                    }
                    #endregion
                }
                #endregion
            }
            #endregion
        }
        #endregion

        #region ���˹ؼ���
        protected void FilterKeyWord(Model.BaseInfo info)
        {
            Model.UserRegInfo regInfo = new Business.UserReg().GetItem(info.UserID);

            int userGradeId = 0;

            if (regInfo != null) userGradeId = regInfo.GradeId;

            info.Title = XYECOM.Business.FiltrateKeyWord.LeachKeyWord(userGradeId, info.Title);
            info.InfoContent = XYECOM.Business.FiltrateKeyWord.LeachKeyWord(userGradeId, info.InfoContent);
            //���������
            if (info.GetType().Equals(new XYECOM.Model.InviteBusinessmanInfo().GetType()))
            {
                XYECOM.Model.InviteBusinessmanInfo info2 = (XYECOM.Model.InviteBusinessmanInfo)info;
                info2.Support = XYECOM.Business.FiltrateKeyWord.LeachKeyWord(userGradeId, info2.Support);
                info2.Demand = XYECOM.Business.FiltrateKeyWord.LeachKeyWord(userGradeId, info2.Demand);
                info2.QuondamProduct = XYECOM.Business.FiltrateKeyWord.LeachKeyWord(userGradeId, info2.QuondamProduct);
            }
        }
        #endregion

        /// <summary>
        /// ���ҹؼ��ʶ�Ӧ��������Ϣ(����ҳ��ʹ��)
        /// </summary>
        /// <param name="keyword"></param>
        protected void SetRankKeyId(string keyword)
        {
            if (keyword.Trim().Equals("")) return;

            XYECOM.Model.SearchKeyInfo keyInfo = new Business.SearchKey().GetRankingItem(keyword);

            if (keyInfo != null) pageinfo.RankKeyId = keyInfo.SK_ID;
        }

        /// <summary>
        /// ��ȡ�Զ��������ֶ���Ϣ(����ҳ��ʹ��)
        /// </summary>
        /// <param name="moduleFlagName"></param>
        /// <param name="orderby"></param>
        protected void SetOrderStr(string moduleFlagName, string orderby)
        {
            if (!orderby.Equals("grade") && !orderby.Equals("time") && !orderby.Equals("active"))
            {
                pageinfo.OuterOrderStr = "";
                return;
            }

            if (orderby.Equals("grade"))
            {
                pageinfo.OuterOrderStr = "UG_Order asc";

                if (moduleFlagName.Equals("offer") || moduleFlagName.Equals("venture")) pageinfo.OuterOrderStr += ",SD_PublishDate desc";

                if (moduleFlagName.Equals("investment")) pageinfo.OuterOrderStr += ",IBI_PublishDate desc";

                if (moduleFlagName.Equals("service")) pageinfo.OuterOrderStr += ",S_AddTime desc";

                if (moduleFlagName.Equals("exhibition")) pageinfo.OuterOrderStr = "";

                if (moduleFlagName.Equals("brand")) pageinfo.OuterOrderStr += ",addTime desc";

                if (moduleFlagName.Equals("company")) pageinfo.OuterOrderStr += ",u_regdate desc";
            }

            if (orderby.Equals("time"))
            {
                pageinfo.OuterOrderStr = "";

                if (moduleFlagName.Equals("offer") || moduleFlagName.Equals("venture")) pageinfo.OuterOrderStr += "SD_PublishDate desc";

                if (moduleFlagName.Equals("investment")) pageinfo.OuterOrderStr += "IBI_PublishDate desc";

                if (moduleFlagName.Equals("service")) pageinfo.OuterOrderStr += "S_AddTime desc";

                if (moduleFlagName.Equals("exhibition")) pageinfo.OuterOrderStr = "AddInfoTime desc";

                if (moduleFlagName.Equals("brand")) pageinfo.OuterOrderStr += "addTime desc";

                if (moduleFlagName.Equals("company")) pageinfo.OuterOrderStr += "u_regdate desc";
            }


            if (orderby.Equals("active"))
            {
                pageinfo.OuterOrderStr = "";

                if (moduleFlagName.Equals("offer") 
                    || moduleFlagName.Equals("venture")
                    || moduleFlagName.Equals("investment")
                    || moduleFlagName.Equals("service")
                    || moduleFlagName.Equals("brand")
                    || moduleFlagName.Equals("company")
                    )
                    pageinfo.OuterOrderStr = "u_mark desc";

                if (moduleFlagName.Equals("exhibition")) pageinfo.OuterOrderStr = "";
            }
        }

    }
}
