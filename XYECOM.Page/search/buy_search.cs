using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace XYECOM.Page.search
{
    /// <summary>
    /// 模板 search/buyer_search.htm 代码类
    /// </summary>
    public class buy_search : ForeBasePage
    {
        //get的数据
        protected string showstyle = "";    //样式。图片/文字
        private string keyWord;    //关键字
        private string publishdate;            //发布时间段
        private int pageindex;       //分页的当前页
        private int pagesize;        //分页一页显示的记录数
        private string jinji;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            showstyle = XYECOM.Core.XYRequest.GetQueryString("style");//样式。图片/文字
            keyWord = XYECOM.Core.XYRequest.GetQueryString("keyword");//搜索关键字
            jinji = XYECOM.Core.XYRequest.GetQueryString("jinji");//紧急求购
            publishdate = XYECOM.Core.XYRequest.GetQueryString("date");//发布时间
            pageindex = XYECOM.Core.XYRequest.GetQueryInt("pageindex", 0);
            pagesize = XYECOM.Core.XYRequest.GetQueryInt("pagesize", 0);

            if (pagesize > 0)
            {
                pageinfo.CustomPageSize = pagesize;
            }
            else
            {
                pageinfo.CustomPageSize = 20;
            }
             
            if (pageindex > 0) 
            {
                pageinfo.PageIndex = pageindex;
            }
            else
            {
                pageinfo.PageIndex = 1;
            }

            pageinfo.SearchKey = keyWord;

            if (!pageinfo.IsPost)
            {
                pageinfo.SearchKey = keyWord;               
                pageinfo.StrPageSeachWhere = GetStrSearchWhere();//补充搜索条件 
                pageinfo.PageURL = webInfo.WebDomain + "search/buy_search" + GetPageURL();
                pageinfo.Navigation = GetNavigation();
            }
        }
        /// <summary>
        /// 获取导航
        /// </summary>
        /// <returns></returns>
        private string GetNavigation()
        {

            StringBuilder val = new StringBuilder();
            val.Append("<a href='/'>首页</a>");
            val.Append(" > ");

            val.Append("<a href='" + webInfo.WebDomain + "search/buy_search.aspx" + "'>");
            val.Append("求购信息");
            val.Append("</a>");
            return val.ToString() ;
        }

        /// <summary>
        /// 获取页面地址
        /// </summary>
        /// <param name="type">类别</param>
        /// <returns>页面地址</returns>
        private string GetPageURL()
        {
            string url = ".aspx?keyword=" + keyWord;
            //keyword=$1^jinji=$2^data=$3^pagesize=$4^style=$5^pageindex=$6               
          
            if (jinji != "0")
            {
                url += "&jinji=" + jinji;
            }

            if (!string.IsNullOrEmpty(publishdate))
            {
                url += "&date=" + publishdate;
            }
            if (pagesize>0)
            {
                url += "&pagesize=" + pagesize;
            }
            if (!string.IsNullOrEmpty(showstyle))
            {
                url += "&style=" + showstyle;
            }
            return url;
        }

        /// <summary>
        /// 获取过滤条件
        /// </summary>
        /// <returns></returns>
        private string GetStrSearchWhere()
        {
            string where = "  AuditingState=1 ";
            if (keyWord != "")
            {
                where += " and title like '%" + keyWord + "%' or keyword like '%" + keyWord + "%'";
            }
            if (publishdate != "")
            {
                where += GetTimeWhere("publishdate");
            }
            if (jinji != "" && jinji != "0")
            {
                where += " and Emergency =" + jinji + " ";
            }
            return where;
        }
        /// <summary>
        /// 获取时间
        /// </summary>
        /// <param name="dataColumns">列</param>
        /// <returns>时间</returns>
        private string GetTimeWhere(string dataColumns)
        {
            int d = XYECOM.Core.MyConvert.GetInt32(publishdate);

            if (d > 0)
            {
                return " and datediff(dd," + dataColumns + ",getdate()) < " + d + " ";
            }
            return "";
        }
        /// <summary>
        /// 获取单条信息
        /// </summary>
        /// <param name="strColumn">列</param>
        /// <returns>单条信息</returns>
        private string GetItemWhere(string strColumn)
        {
            XYECOM.Configuration.ModuleInfo moduleInfo = XYECOM.Configuration.Module.Instance.GetItem(pageinfo.ModuleFlag);
            string itemwhere = "";
            foreach (XYECOM.Configuration.ModuleItemInfo item in moduleInfo.Item)
            {
                if (item.InfoType == XYECOM.Configuration.InfoType.Buy)
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





        protected DataTable GetClassAds()
        {
            Business.ClassAds classAdsBLL = new XYECOM.Business.ClassAds();
            DataTable table = new DataTable();

            string keyword = XYECOM.Core.XYRequest.GetQueryString("keyword");

            int keyTypeId = 0;



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
