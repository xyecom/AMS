//------------------------------------------------------------------------------
//
// file name：PageRecordManager.cs
// author: wangzhen
// create date：2011-6-2 11:51:41
//
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace XYECOM.Business
{
    /// <summary>
    /// Business logic for dbo.XY_PageRecord.
    /// </summary>
    /// 
    public partial class PageRecordManager
    {
        private static readonly XYECOM.SQLServer.PageRecordAccess DAL = new SQLServer.PageRecordAccess();

        /// <summary>
        /// 访问记录
        /// </summary>
        /// <param name="PageFlag">访问页面类型</param>
        /// <param name="Guest">用户登录实体</param>
        /// <param name="ShopUserId">所访问网店的用户ID</param>
        /// <param name="InfoId">访问详细信息页面编号</param>
        /// <returns>null</returns>
        public void InsertPageRecord(int PageFlag, XYECOM.Model.GeneralUserInfo Guest,int ShopUserId,int InfoId)
        {
            string Url = XYECOM.Core.XYRequest.GetUrl();
            string Str1 = XYECOM.Core.Utils.GetCookie("pageflag").ToString();
            string Str2 = XYECOM.Core.Utils.GetCookie("pageurl").ToString();
            
            if (Str1 != PageFlag.ToString() || Str2 != Url)
            {
                XYECOM.Core.Utils.WriteCookie("pageflag", PageFlag.ToString(), 2, "");
                XYECOM.Core.Utils.WriteCookie("pageurl", Url, 2,"");
            }
            else 
            {
                return;
            }

            XYECOM.Model.PageRecordInfo pageRecordInfo = new Model.PageRecordInfo();

            pageRecordInfo.UserId = ShopUserId;
            
            //判断用户或游客
            if (Guest == null)
            {
                pageRecordInfo.Guest = "0";
            }
            else 
            {
                pageRecordInfo.Guest = Guest.userid.ToString();
            }


            if (InfoId == 0)
            {
                pageRecordInfo.FlagInfo = 0;
            }
            else
            {
                pageRecordInfo.FlagInfo = InfoId;
            }

            pageRecordInfo.IP = XYECOM.Core.XYRequest.GetIP();
            pageRecordInfo.Date = DateTime.Now;

            if (Str1 == "" && Str2 == "")
            {
                //记录网店
                pageRecordInfo.Flag = (int)XYECOM.Model.PageRecord.ShopRecord;
                //获取页面标识描述
                pageRecordInfo.PageName = GetPageName((int)XYECOM.Model.PageRecord.ShopRecord);
                DAL.Insert(pageRecordInfo);
            }
            
            //页面标识
            pageRecordInfo.Flag = PageFlag;
            //获取页面标识描述
            pageRecordInfo.PageName = GetPageName(PageFlag);

            DAL.Insert(pageRecordInfo);
        }

        /// <summary>
        /// 获取一条最后访问时间的实体
        /// </summary>
        /// <param name="UserId">用户ID</param>
        public string GetLastDate(int UserId)
        {
           XYECOM.Model.PageRecordInfo pageRegInfo =  DAL.GetTopItemById(UserId);
           if (pageRegInfo != null)
           {
               return pageRegInfo.Date.ToString("yyyy-MM-dd hh:mm:ss");
           }
           return "无数据";
        }

        /// <summary>
        /// 获取用户记录信息
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns></returns>
        public DataTable GetPageRecordBystrWhere(string strWhere)
        {
            return DAL.GetPageRecordBystrWhere(strWhere);
        }
        /// <summary>
        /// 获取页面描述信息
        /// </summary>
        /// <param name="PageFlag">页面标识枚举</param>
        /// <returns></returns>
        public string GetPageName(int PageFlag)
        {
            string Str = "";

            switch (PageFlag)
            {
                case (int)XYECOM.Model.PageRecord.BrandRecord:
                    Str = "品牌信息页";
                    break;
                case (int)XYECOM.Model.PageRecord.InvestmentRecord:
                    Str = "代理信息页面";
                    break;
                case (int)XYECOM.Model.PageRecord.NewsRecord:
                    Str = "资讯信息页";
                    break;
                case (int)XYECOM.Model.PageRecord.OtherRecord:
                    Str = "网店其他页面(网店首页,列表页,分类页等)";
                    break;
                case (int)XYECOM.Model.PageRecord.ProRecord:
                    Str = "产品信息页";
                    break;
                case (int)XYECOM.Model.PageRecord.ServiceRecord:
                    Str = "服务信息页面";
                    break;
                case (int)XYECOM.Model.PageRecord.ShopRecord:
                    Str = "网店页";
                    break;
                case (int)XYECOM.Model.PageRecord.VentureRecord:
                    Str = "融资信息页面";
                    break;
            }

            return Str;
        }
    }
}

