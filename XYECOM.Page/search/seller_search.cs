using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;
using System.Collections;

namespace XYECOM.Page.search
{
    /// <summary>
    /// ģ�� search/seller_search.htm ������
    /// </summary>
    public class seller_search : ForeBasePage
    {
        public string linkmodule = "";

        //get������
        protected string showstyle = "";//��ʽ��ͼƬ/����

        protected string ptid;          //������
        private string tradeId;
        private string orderby = "";    //�Զ�������
        private string strsearchkey;    //�����ؼ���
        private string areaId;          //����ID
        private string date;            //����ʱ���
        private int pageindex;          //��ҳ�ĵ�ǰҳ
        private string pagesize;        //��ҳһҳ��ʾ�ļ�¼��
        private string flag;
        public string p_id;//����id+����ֵ
        private string strseokey;
        private string strsqlkey1;      //��sql����еĲ��ҹؼ���
        private string strsqlkey2 = ""; //��sql����е�ɸѡ�ؼ���

        private string rankKey = "";    //�����ؼ���(Ĭ��Ϊ�����ؼ��ʣ���������ؼ���Ϊ�գ��ҷ���Id��Ϊ��ʱ����Ϊ��������)

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!pageinfo.IsPost)
            {
                showstyle = XYECOM.Core.XYRequest.GetQueryString("showstyle");//��ʽ��ͼƬ/����
                p_id = XYECOM.Core.XYRequest.GetQueryString("typeid");//��ȡ��Ʒ�����ʽ
                string[] pidAndFiled = Regex.Split(p_id, "_", RegexOptions.IgnorePatternWhitespace);
                if (pidAndFiled != null)
                {
                    ptid = pidAndFiled[0];//�б���
                }
                else
                {
                    p_id = "0";
                }
                tradeId = XYECOM.Core.XYRequest.GetQueryString("tradeid");//����ҵId
                orderby = XYECOM.Core.XYRequest.GetQueryString("order");
                areaId = XYECOM.Core.XYRequest.GetQueryString("AreaId");
                date = XYECOM.Core.XYRequest.GetQueryString("date");//����ʱ���
                pageindex = XYECOM.Core.XYRequest.GetQueryInt("pageindex", 1);
                pagesize = XYECOM.Core.XYRequest.GetQueryString("pagesize");
                flag = XYECOM.Core.XYRequest.GetQueryString("flag").Trim();

                strsearchkey = XYECOM.Core.XYRequest.GetQueryString("keyword");//�����ؼ���
                pageinfo.SearchKey = strsearchkey;
                strseokey = strsearchkey.Replace(',', '_');
                strsqlkey1 = strsearchkey;

                if ("" == ptid) ptid = "0";

                //���¹ؼ�����������
                Business.SearchKey.UpdateNumberOfSearches(strsearchkey, flag);

                pageinfo.ModuleName = flag;

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

                    if (tmparr[1] != "") pageinfo.SearchKey = tmparr[1];
                }

                string url = "";

                string strWhere = "   AuditingState = 1  ";//��������
                string strKeyWhere = "   AuditingState = 1  ";//������������
                string strWhereByUser = " userAuditingState = 1 ";                
                if (pagesize != "") this.pageinfo.CustomPageSize = Core.MyConvert.GetInt32(pagesize);
                this.pageinfo.PageIndex = pageindex;
                XYECOM.Configuration.ModuleInfo moduleInfo = moduleConfig.GetItem(flag);
                string itemwhere = "";

                if (flag=="offer")
                {
                    pageinfo.OnLoadEvents += "AttributeSearch();";
                    pageinfo.ModuleFlag = "offer";
                    #region ��Ӧ��Ϣ

                    strWhere += " and UserAuditingState=1 and SD_IsSupply = '1' and datediff(mi,SD_EndDate,getdate()) < 0 ";
                    strKeyWhere += "  and UserAuditingState=1 and SD_IsSupply = '1' and datediff(mi,SD_EndDate,getdate()) < 0 ";

                    #region 2011-06-29 ƴ������ֵ����
                    string tempWhere = "";
                    string temp = " "; 
                    string filedId = "";
                    string fileValue = "";
                    //ƴ������ֵ����
                    XYECOM.Business.FieldManager fl = null;
                    XYECOM.Model.FieldInfo finfo;
                    Hashtable fieldValues = new Hashtable();
                    if (pidAndFiled.Length > 1 && flag == "offer")
                    {
                        for (int i = 1; i < pidAndFiled.Length; i++)
                        {
                            if (pidAndFiled[i] != "")
                            {
                                temp = pidAndFiled[i];
                                try
                                {
                                    filedId = temp.Substring(0, temp.IndexOf("."));
                                    fileValue = temp.Substring(temp.IndexOf(".") + 1);
                                    fl = new Business.FieldManager();
                                    finfo = fl.GetItem(XYECOM.Core.MyConvert.GetInt32(filedId));
                                    if (finfo != null)
                                    {
                                        string[] tempvalue = Regex.Split(finfo.InitValue, "_", RegexOptions.IgnorePatternWhitespace);
                                        fieldValues[filedId] = tempvalue[XYECOM.Core.MyConvert.GetInt32(fileValue)];
                                    }
                                }
                                catch
                                {
                                    Alert("��������");
                                    return;
                                }
                            }
                        }

                        if (fieldValues.Count > 0)
                        {
                            tempWhere = " and (sd_id in (select ProductId from xy_fieldvalue where 1=1 ";//�������ֵ��������

                            foreach (DictionaryEntry item in fieldValues)
                            {
                                tempWhere += string.Format(" and  ( fieldid={0} and fieldValue='{1}') ", item.Key.ToString(), item.Value.ToString());
                            }
                            strWhere += tempWhere + " )) ";
                        }
                    }
                    #endregion
                    if (ptid != "0" && ptid != "" && XYECOM.Core.Utils.IsNumber(ptid))
                    {
                        strWhere += " and (PT_ID = " + ptid + " Or Charindex('," + ptid + ",',FullId) > 0)";
                    }

                    //��ҵId
                    if (tradeId != "0" && tradeId != "" && XYECOM.Core.Utils.IsNumber(tradeId))
                    {
                        strWhere += " and TradeId = " + tradeId;
                    }

                    strWhere += GetTitleWhere("SD_Title", ref strKeyWhere);
                    strWhere += GetAreaWhere();
                    strWhere += GetTimeWhere("SD_PublishDate");
                    itemwhere = GetItemWhere();
                    strWhere += ("" == itemwhere ? "" : " and (" + itemwhere + ") ");

                    //SetKeyWord("offer", strsqlkey2 == "" ? strsqlkey1 : strsqlkey2, strKeyWhere, itemwhere);

                    base.pageinfo.StrPageSeachWhere = strWhere;
                    #endregion
                }

                if (flag=="venture")
                {
                    pageinfo.ModuleFlag = "venture";
                    #region �ӹ���Ϣ

                    strWhere += " and UserAuditingState=1 and SD_IsSupply = '1' and datediff(mi,SD_EndDate,getdate()) < 0 ";
                    strKeyWhere += " and UserAuditingState=1 and SD_IsSupply = '1' and datediff(mi,SD_EndDate ,getdate()) < 0 ";

                    if (ptid != "0" && ptid != "" && XYECOM.Core.Utils.IsNumber(ptid))
                    {
                        strWhere += " and (TypeId = " + ptid + ")";
                    }

                    strWhere += GetTitleWhere("SD_Title", ref strKeyWhere);
                    strWhere += GetAreaWhere();
                    strWhere += GetTimeWhere("SD_PublishDate");
                    itemwhere = GetItemWhere();
                    strWhere += ("" == itemwhere ? "" : " and (" + itemwhere + ") ");

                    base.pageinfo.StrPageSeachWhere = strWhere;
                    #endregion
                }
                if (moduleInfo != null)
                {
                    if (moduleInfo.EName.Equals("investment") || moduleInfo.PEName.Equals("investment"))
                    {
                        pageinfo.ModuleFlag = "investment";
                        #region ���̴�����Ϣ

                        strWhere += " and UserAuditingState=1 and IBI_Pause = '1' and datediff(mi,IBI_EndTime,getdate()) < 0 ";
                        strKeyWhere += " and UserAuditingState=1 and IBI_Pause = '1' and datediff(mi,IBI_EndTime ,getdate()) < 0 ";

                        if (ptid != "0" && ptid != "" && XYECOM.Core.Utils.IsNumber(ptid))
                        {
                            strWhere += " and (IT_ID = " + ptid + " Or Charindex('," + ptid + ",',FullId) > 0)";
                        }
                        else
                        {
                            strWhere += " and moduleName='" + moduleInfo.EName + "'";
                        }

                        strWhere += GetTitleWhere("IBI_Title", ref strKeyWhere);
                        strWhere += GetAreaWhere();
                        strWhere += GetTimeWhere("IBI_PublishDate");
                        itemwhere = GetItemWhere("IBI_Sign");
                        strWhere += ("" == itemwhere ? "" : " and (" + itemwhere + ") ");

                        base.pageinfo.StrPageSeachWhere = strWhere;
                        #endregion
                    }

                    if (moduleInfo.EName.Equals("service") || moduleInfo.PEName.Equals("service"))
                    {
                        pageinfo.ModuleFlag = "service";
                        #region ������Ϣ

                        strWhere += " and UserAuditingState=1 and S_Pause = '1' and datediff(mi,S_EndTime,getdate()) < 0 ";
                        strKeyWhere += " and UserAuditingState=1 and S_Pause = '1' and datediff(mi,S_EndTime,getdate()) < 0 ";

                        if (ptid != "0" && ptid != "" && XYECOM.Core.Utils.IsNumber(ptid))
                        {
                            strWhere += " and (ST_ID = " + ptid + " Or Charindex('," + ptid + ",',FullId) > 0)";
                        }
                        else
                        {
                            strWhere += " and moduleName='" + moduleInfo.EName + "'";
                        }

                        strWhere += GetTitleWhere("S_Title", ref strKeyWhere);
                        strWhere += GetAreaWhere();
                        strWhere += GetTimeWhere("S_AddTime");
                        itemwhere = GetItemWhere("S_Flag");
                        strWhere += ("" == itemwhere ? "" : " and (" + itemwhere + ") ");

                        base.pageinfo.StrPageSeachWhere = strWhere;
                        #endregion
                    }

                    SetSeoInfo(moduleInfo.EName);

                    url += GetPageURL("-" + moduleInfo.EName);

                    rankKey = pageinfo.SearchKey;

                    if (pageinfo.SearchKey.Equals("") && !ptid.Equals("0"))
                    {
                        XYECOM.Model.XYClassInfo clsInfo = Business.XYClass.GetItem(flag, Core.MyConvert.GetInt64(ptid));

                        if (clsInfo != null) rankKey = clsInfo.ClassName;
                    }

                    SetRankKeyId(rankKey);
                }


                if (flag.Equals("exhibition"))
                {
                    pageinfo.ModuleFlag = "exhibition";
                    #region չ����Ϣ

                    strWhere = " datediff(mi,EndTime,getdate()) < 0 ";
                    strKeyWhere = " datediff(mi,EndTime,getdate()) < 0 ";

                    if (ptid != "0" && ptid != "" && XYECOM.Core.Utils.IsNumber(ptid))
                    {
                        strWhere += " and (TypeID = " + ptid + " Or Charindex('," + ptid + ",',FullId) > 0)";
                    }

                    strWhere += GetTitleWhere("InfoTitle", ref strKeyWhere);
                    strWhere += GetAreaWhere();
                    strWhere += GetTimeWhere("AddInfoTime");

                    SetSeoInfo("exhibition");

                    url += GetPageURL("-exhibition");
                    base.pageinfo.StrPageSeachWhere = strWhere;
                    #endregion
                }


                if (flag.Equals("brand"))
                {
                    pageinfo.ModuleFlag = "brand";
                    #region Ʒ����Ϣ

                    strWhere += " and UserAuditingState=1 ";
                    strKeyWhere += " and UserAuditingState=1 ";

                    if (ptid != "0" && ptid != "" && XYECOM.Core.Utils.IsNumber(ptid))
                    {
                        strWhere += " and (PT_ID = " + ptid + " Or Charindex('," + ptid + ",',FullId) > 0)";
                    }

                    SetSeoInfo("brand");
                    strWhere += GetTitleWhere("B_Type", ref strKeyWhere);
                    strWhere += GetAreaWhere();
                    strWhere += GetTimeWhere("addtime");
                    url += GetPageURL("-brand");

                    base.pageinfo.StrPageSeachWhere = strWhere;
                    #endregion
                }

                if (flag.Equals("company"))
                {
                    pageinfo.ModuleFlag = "company";
                    #region ��ҵ��Ϣ

                    if (ptid != "0" && ptid != "" && XYECOM.Core.Utils.IsNumber(ptid))
                    {
                        strWhereByUser += " and (UT_ID = " + ptid + " Or Charindex('," + ptid + ",',UT_FullId) > 0)";
                    }

                    SetSeoInfo("company");

                    strWhereByUser += GetTitleWhere("UI_Name", ref strKeyWhere);
                    strWhereByUser += GetAreaWhere();
                    strWhereByUser += GetTimeWhere("U_RegDate");

                    url += GetPageURL("-company");

                    base.pageinfo.StrPageSeachWhere = strWhereByUser;
                    #endregion
                }

                //�����Զ��������ַ���
                SetOrderStr(pageinfo.ModuleFlag, orderby);

                if (pageinfo.SearchKey != null && pageinfo.SearchKey != "" && pageinfo.SearchKey.Length > 6)
                    pageinfo.SearchKey = XYECOM.Core.Utils.IsLength(12, pageinfo.SearchKey);


                if (config.BogusStatic)
                {
                    pageinfo.PageURL = config.WebURL + "search/seller_search" + XYECOM.Core.Utils.UrlEncode(url);
                }
                else
                {
                    pageinfo.PageURL = System.Web.HttpContext.Current.Request.RawUrl;
                    if (pageinfo.PageURL.IndexOf("pageindex") > 0)
                        pageinfo.PageURL = pageinfo.PageURL.Remove(pageinfo.PageURL.IndexOf("pageindex") - 1, pageinfo.PageURL.Substring(pageinfo.PageURL.IndexOf("pageindex")).Length + 1);
                }

                if (moduleInfo == null)
                {
                    pageinfo.OnLoadEvents += "SearchSetDefaultValue();SearchSetClassList('" + pageinfo.ModuleFlag + "','" + ptid + "')";
                    UpdateNavigation(pageinfo.ModuleFlag, Core.MyConvert.GetInt64(ptid));
                }
                else
                {
                    pageinfo.OnLoadEvents += "SearchSetDefaultValue();SearchSetClassList('" + moduleInfo.EName + "','" + ptid + "')";
                    UpdateNavigation(moduleInfo.EName, Core.MyConvert.GetInt64(ptid));
                }
            }
        }

        /// <summary>
        /// ��ȡҳ���ַ
        /// </summary>
        /// <param name="type">����</param>
        /// <returns>ҳ���ַ</returns>
        private string GetPageURL(string type)
        {
            string url = type + "-";
            if (ptid != "0" && ptid != "" && XYECOM.Core.Utils.IsNumber(ptid))
            {
                url += ptid;
                pageinfo.StrSearchWhere += config.BogusStatic ? "-" + ptid : "&typeid=" + ptid;
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
                if (config.BogusStatic) pageinfo.StrSearchWhere += "-";
            }

            //������ҵId����ҵ����id����
            //���Թ���������Ч
            url += "-";
            if (tradeId != "0" && tradeId != "" && XYECOM.Core.Utils.IsNumber(tradeId))
            {
                url += tradeId;
                pageinfo.StrSearchWhere += config.BogusStatic ? "-" + tradeId : "&tradeId=" + tradeId;
            }
            else
            {
                if (config.BogusStatic) pageinfo.StrSearchWhere += "-";
            }

            url += "-";
            if (orderby != "")
            {
                url += orderby;
                pageinfo.StrSearchWhere += config.BogusStatic ? "-" + orderby : "&order=" + orderby;
            }
            else
            {
                if (config.BogusStatic) pageinfo.StrSearchWhere += "-";
            }

            url += "-";
            if (areaId != "0" && areaId != "" && XYECOM.Core.Utils.IsNumber(areaId))
            {
                url += areaId;
                pageinfo.StrSearchWhere += config.BogusStatic ? "-" + areaId : "&AreaId=" + areaId;
            }
            else
            {
                if (config.BogusStatic)
                    pageinfo.StrSearchWhere += "-";
            }
            url += "-";
            if (date != "0" && date != "" && XYECOM.Core.Utils.IsNumber(date))
            {
                url += date;
                pageinfo.StrSearchWhere += config.BogusStatic ? "-" + date : "&date=" + date;
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
                {
                    pageinfo.StrSearchWhere += "-";
                }

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
            return url;
        }
        /// <summary>
        /// ��ȡʱ��
        /// </summary>
        /// <param name="dataColumns">��</param>
        /// <returns>ʱ��</returns>
        private string GetTimeWhere(string dataColumns)
        {
            int d = XYECOM.Core.MyConvert.GetInt32(date);

            if (d > 0)
            {
                return " and datediff(dd," + dataColumns + ",getdate()) < " + d + " ";
            }
            return "";
        }
        /// <summary>
        /// ��ȡǰ��׺��Ϣ
        /// </summary>
        /// <param name="strColumn">��</param>
        /// <returns>ǰ��׺��Ϣ</returns>
        private string GetItemWhere(string strColumn)
        {
            XYECOM.Configuration.ModuleInfo moduleInfo = XYECOM.Configuration.Module.Instance.GetItem(pageinfo.ModuleFlag);
            string itemwhere = "";
            foreach (XYECOM.Configuration.ModuleItemInfo item in moduleInfo.Item)
            {
                if (item.InfoType == XYECOM.Configuration.InfoType.Sell)
                {
                    if (itemwhere != "")
                    {
                        if (item.ID != 0)
                            itemwhere += " or " + strColumn + "=" + item.ID.ToString();
                    }
                    else
                    {
                        if (item.ID != 0)
                            itemwhere += " " + strColumn + "=" + item.ID.ToString();
                    }
                }
            }
            return itemwhere;
        }
        /// <summary>
        /// ��ȡǰ��׺��Ϣ
        /// </summary>
        /// <returns></returns>
        private string GetItemWhere()
        {
            return GetItemWhere("SD_Flag");
        }
        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <returns></returns>
        private string GetAreaWhere()
        {
            if (areaId != "0" && areaId != "" && XYECOM.Core.Utils.IsNumber(areaId))
            {
                int iAreaId = 0;
                if (areaId != "") iAreaId = XYECOM.Core.MyConvert.GetInt32(areaId);
                Business.Area areaBLL = new XYECOM.Business.Area();
                string subAreaIds = areaBLL.GetSubIds(iAreaId);

                if (subAreaIds != "")
                    return " and Area_ID in(" + subAreaIds + ")";
            }
            return "";
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
        /// ��ȡ������Ϣ
        /// </summary>
        /// <param name="ename">ģ������</param>
        private void SetSeoInfo(string ename)
        {
            XYECOM.Configuration.SEOInfo seoInfo = SEO.GetListPageSEO(ename);

            Int64 classId = Core.MyConvert.GetInt64(ptid);

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
                seo.Description = seoInfo.Description.Replace("{keyword}", key);
                seo.Keywords = seoInfo.Keywords.Replace("{keyword}", key);
            }

            if (SEO.IsAppendWebName)
            {
                seo.Title = seo.Title + "_" + webInfo.WebName;
                seo.Description = seo.Description + "," + webInfo.WebName;
                seo.Keywords = seo.Keywords + "," + webInfo.WebName;
            }
        }

        protected DataTable GetClassAds()
        {
            Business.ClassAds classAdsBLL = new XYECOM.Business.ClassAds();
            DataTable table = new DataTable();
            flag = XYECOM.Core.XYRequest.GetQueryString("flag").Trim();
            if (!flag.Equals("offer")) return table;

            int classId = Core.MyConvert.GetInt32(ptid);

            string keyword = XYECOM.Core.XYRequest.GetQueryString("keyword");

            int keyTypeId = 0;

            if (classId > 0)
            {
                table = classAdsBLL.GetItemsForFrontPage(classId);
            }

            if (table.Rows.Count < 1)
            {
                if (string.IsNullOrEmpty(keyword)) return table;

                XYECOM.Business.ProductType productTypeBLL = new XYECOM.Business.ProductType();
                Model.ProductTypeInfo info = productTypeBLL.GetItemByTypeName(keyword);

                if (info == null) return table;

                keyTypeId = (int)info.PT_ID;

                table = classAdsBLL.GetItemsForFrontPage(keyTypeId);
            }

            foreach (DataRow row in table.Rows)
            {
                if (row["imageUrl"].ToString().Equals(""))
                {
                    long adsId = Core.MyConvert.GetInt64(row["AdsId"].ToString());
                    row["imageUrl"] = Business.Attachment.GetInfoDefaultImgHref(XYECOM.Model.AttachmentItem.ClassAds, adsId);
                }
            }

            return table;
        }
    }
}
