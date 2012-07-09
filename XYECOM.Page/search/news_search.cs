using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Page.search
{
    /// <summary>
    ///  ģ�� search/news_search.htm ������
    /// </summary>
    public class news_search : ForeBasePage
    {
        //get������
        protected string showstyle = "";//��ʽ��ͼƬ/����
        protected string type;
        protected string typeId;//�б���
        private string custom;
        private string strsearchkey;//�����ؼ���
        private string times;//����ʱ���
        private string pageindex;//��ҳ�ĵ�ǰҳ
        private string pagesize;//��ҳһҳ��ʾ�ļ�¼��
        private string strseokey;
        private string strsqlkey1;//��sql����еĲ��ҹؼ���
        private string strsqlkey2 = "";//��sql����е�ɸѡ�ؼ���

        private string whereBackUp = "";

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!pageinfo.IsPost)
            {
                showstyle = XYECOM.Core.XYRequest.GetQueryString("showstyle");//��ʽ��ͼƬ/����

                type = XYECOM.Core.XYRequest.GetQueryString("type");//�б���
                typeId = XYECOM.Core.XYRequest.GetQueryString("typeid");//�б���
                strsearchkey = XYECOM.Core.XYRequest.GetQueryString("keyword");//�����ؼ���
                times = XYECOM.Core.XYRequest.GetQueryString("date");//����ʱ���
                pageindex = XYECOM.Core.XYRequest.GetQueryString("pageindex").ToString();
                pagesize = XYECOM.Core.XYRequest.GetQueryString("pagesize");
                custom = XYECOM.Core.XYRequest.GetQueryString("custom");

                pageinfo.SearchKey = strsearchkey;
                strseokey = strsearchkey.Replace(',', '_');
                strsqlkey1 = strsearchkey;
                if ("" == typeId)
                    typeId = "0";

                //���¹ؼ�����������
                Business.SearchKey.UpdateNumberOfSearches(strsearchkey, "news");

                if (strsearchkey.IndexOf(",") == 0)
                {
                    strsqlkey1 = strsqlkey1.Replace(",", "");
                    strseokey = strsqlkey1;
                    pageinfo.SearchKey = strsqlkey1;
                }
                else if (strsearchkey.IndexOf(",") > 0)
                {
                    string[] tmparr = strsearchkey.Split(',');
                    strsqlkey1 = tmparr[0];
                    strsqlkey2 = tmparr[1];
                    pageinfo.SearchKey = tmparr[0];
                    if (tmparr[1] != "")
                    {
                        pageinfo.SearchKey = tmparr[1];
                    }
                }

                if (pagesize != "") this.pageinfo.CustomPageSize = Core.MyConvert.GetInt32(pagesize);

                SetSeoInfo("news");

                string strWhere = " AuditingState = 1 and nt_isshow = '1' ";
                string strKeyWhere = "";
                string url = "";

                if (typeId != "0" && typeId != "" && XYECOM.Core.Utils.IsNumber(typeId))
                {
                    strWhere += " and (" + Business.Utils.GetNewsChannelQueryWhere(Core.MyConvert.GetInt32(typeId)) + ")";
                }

                if (!custom.Equals("") && XYECOM.Core.Utils.IsNumber(custom))
                {
                    strWhere += " and NS_IsCommand= '" + custom + "'";
                }

                if (!type.Equals("") && XYECOM.Core.Utils.IsNumber(type))
                {
                    strWhere += " and NS_Type=" + type;
                }

                strWhere += GetTitleWhere("NS_NewsName", ref strKeyWhere);
                strWhere += GetTimeWhere("NS_AddTime");

                if (pagesize != "" && XYECOM.Core.Utils.IsNumber(pagesize))
                    base.pageinfo.PageSize = XYECOM.Core.MyConvert.GetInt32(pagesize);

                if (pageindex != "" && XYECOM.Core.Utils.IsNumber(pageindex))
                    base.pageinfo.PageIndex = XYECOM.Core.MyConvert.GetInt32(pageindex);

                url += GetPageURL();

                //�������û�з����ı�����Ҫ���¶�ȡ���ݿ�
                if (whereBackUp != strWhere)
                {
                    //pageinfo.TotalRecord = XYECOM.Business.Utils.GetTotalRecotd("XYV_News", "ns_id", strWhere);
                    whereBackUp = strWhere;
                }

                base.pageinfo.StrPageSeachWhere = strWhere;

                if (config.BogusStatic)
                {
                    pageinfo.PageURL = config.WebURL + "search/news_search" + XYECOM.Core.Utils.UrlEncode(url);
                }
                else
                {
                    pageinfo.PageURL = System.Web.HttpContext.Current.Request.RawUrl;
                    if (pageinfo.PageURL.IndexOf("pageindex") > 0)
                        pageinfo.PageURL = pageinfo.PageURL.Remove(pageinfo.PageURL.IndexOf("pageindex") - 1, pageinfo.PageURL.Substring(pageinfo.PageURL.IndexOf("pageindex")).Length + 1);
                }

                pageinfo.OnLoadEvents += "SetNewsDefaultValue();SetNewsClassList('" + typeId + "')";

                UpdateNavigation();
            }
        }
        /// <summary>
        /// ��ȡ��ͷ
        /// </summary>
        /// <param name="strColumns">��</param>
        /// <param name="strKeyWhere">����</param>
        /// <returns></returns>
        private string GetTitleWhere(string strColumns, ref string strKeyWhere)
        {
            string Where = "";
            if (strsearchkey != "")
            {
                Where += " and " + strColumns + " like '%" + strsqlkey1 + "%'";
                //ɸѡ
                Where += ("" != strsqlkey2 ? " and " + strColumns + " like '%" + strsqlkey2 + "%'" : "");
                strKeyWhere += " and " + strColumns + " like '%" + (strsqlkey2 != "" ? strsqlkey2 : strsqlkey1) + "%' ";
            }
            return Where;
        }
        /// <summary>
        /// ��ȡʱ��
        /// </summary>
        /// <param name="dataColumns">��</param>
        /// <returns>ʱ��</returns>
        private string GetTimeWhere(string dataColumns)
        {
            if (times != "")
            {
                string t = times.ToLower().Replace("to", "|");

                string[] ts = t.Split('|');

                if (ts.Length < 2) return "";

                return " and " + dataColumns + " between '" + ts[0] + "' and '" + ts[1] + "' ";
            }
            return "";
        }
        /// <summary>
        /// ��ȡҳ���ַ
        /// </summary>
        /// <returns>ҳ���ַ</returns>
        private string GetPageURL()
        {
            string url = "-";

            if (type != "" && XYECOM.Core.Utils.IsNumber(type))
            {
                url += type;
                pageinfo.StrSearchWhere += config.BogusStatic ? "-" + type : "&type=" + type;
            }
            else
            {
                if (config.BogusStatic)
                    pageinfo.StrSearchWhere += "-";
            }

            url += "-";
            if (typeId != "0" && typeId != "" && XYECOM.Core.Utils.IsNumber(typeId))
            {
                url += typeId;
                pageinfo.StrSearchWhere += config.BogusStatic ? "-" + typeId : "&typeid=" + typeId;
            }
            else
            {
                if (config.BogusStatic)
                    pageinfo.StrSearchWhere += "-";
            }
            url += "-";
            if (strsearchkey != "")
            {
                url += strsearchkey;
                pageinfo.StrSearchWhere += config.BogusStatic ? "-" + strsearchkey : "&keyword=" + strsearchkey;
            }
            else
            {
                if (config.BogusStatic)
                    pageinfo.StrSearchWhere += "-";
            }

            url += "-";
            if (times != "")
            {
                url += times;
                pageinfo.StrSearchWhere += config.BogusStatic ? "-" + times : "&date=" + times;
            }
            else
            {
                if (config.BogusStatic)
                    pageinfo.StrSearchWhere += "-";
            }

            url += "-";
            if (config.BogusStatic)
            {
                if (XYECOM.Core.XYRequest.GetQueryString("showstyle") != "")
                {
                    url += showstyle;
                    pageinfo.StrSearchWhere += "-" + showstyle;
                }
                else
                    pageinfo.StrSearchWhere += "-";

                if (XYECOM.Core.XYRequest.GetQueryString("pagesize") != "")
                {
                    url += "-" + pageinfo.CustomPageSize;
                    pageinfo.StrSearchWhere += "-" + pageinfo.CustomPageSize;
                }
                else
                {
                    url += "-";
                    pageinfo.StrSearchWhere += "-";
                }

                if (XYECOM.Core.XYRequest.GetQueryString("pageindex") != "")
                {
                    url += "-{p}";
                    pageinfo.StrSearchWhere += "-" + pageinfo.PageIndex;
                }
                else
                {
                    url += "-{p}";
                    pageinfo.StrSearchWhere += "-";
                }
            }

            url += "-";

            if (custom != "")
            {
                url += custom;
                pageinfo.StrSearchWhere += config.BogusStatic ? "-" + custom : "&custom=" + custom;
            }
            else
            {
                if (config.BogusStatic)
                    pageinfo.StrSearchWhere += "-";
            }

            return url;
        }

        #region ���µ������
        /// <summary>
        /// ���µ������
        /// </summary>
        private void UpdateNavigation()
        {
            string strTypeId = typeId;
            string moduleName = "news";

            StringBuilder val = new StringBuilder();
            val.Append("<a href='/'>��վ��ҳ</a>");
            val.Append(" > ");
            val.Append("<a href='" + GetHref(0) + "'>");
            val.Append("��Ѷ��Ϣ");
            val.Append("</a>");

            long _TypeId = XYECOM.Core.MyConvert.GetInt64(strTypeId);

            if (_TypeId != 0)
            {
                List<Model.XYClassInfo> parentInfos = Business.XYClass.GetParentClassInfos(moduleName, _TypeId);
                parentInfos.Reverse();
                foreach (Model.XYClassInfo info in parentInfos)
                {
                    val.Append(" > ");
                    val.Append("<a href='" + GetHref(info.ClassId) + "'>");
                    val.Append(info.ClassName);
                    val.Append("</a>");
                }
            }

            pageinfo.Navigation = val.ToString();
        }
        /// <summary>
        /// ����������Ϣ
        /// </summary>
        /// <param name="ename">ģ������</param>
        private void SetSeoInfo(string ename)
        {
            XYECOM.Configuration.SEOInfo seoInfo = SEO.GetListPageSEO(ename);

            Int64 classId = Core.MyConvert.GetInt64(typeId);

            string className = GetAllClassNameForSEO(ename, classId);
            string key = "";

            if (seoInfo != null && seoInfo.IsMatch && !pageinfo.SearchKey.Equals(""))
                key = pageinfo.SearchKey;

            if (!className.Equals(""))
            {
                if (!key.Equals(""))
                    key += "_" + className;
                else
                    key = className;
            }

            if (seoInfo != null)
            {
                seo.Title = seoInfo.Title.Replace("{keyword}", key);
                seo.Description += seoInfo.Description.Replace("{keyword}", key);
                seo.Keywords = seoInfo.Keywords.Replace("{keyword}", key);
            }

            if (SEO.IsAppendWebName)
            {
                seo.Title = seo.Title + "_" + webInfo.WebName;
                seo.Description = seo.Description + "," + webInfo.WebName;
                seo.Keywords = seo.Keywords + "," + webInfo.WebName;
            }
        }

        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <param name="typeId">�����</param>
        /// <returns>����</returns>
        private string GetHref(long typeId)
        {
            string linkUrl = config.WebURL + "search/news_search." + config.suffix + "?typeid={0}";
            string bogueStaticLinkUrl = config.WebURL + "search/news_search--{0}------." + config.suffix;

            string strTypeId = typeId.ToString();

            if (typeId == 0) strTypeId = "";

            if (webInfo.IsBogusStatic)
            {
                return String.Format(bogueStaticLinkUrl, strTypeId);
            }

            return String.Format(linkUrl, strTypeId);
        }
        #endregion
    }
}
