using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using Microsoft.VisualBasic;
using System.Reflection;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Net;

namespace XYECOM.Business
{
    public class AdTrafficLog
    {
        private static readonly XYECOM.SQLServer.AdTrafficLog DAL = new XYECOM.SQLServer.AdTrafficLog();
        private static readonly XYECOM.SQLServer.Ad DALad = new XYECOM.SQLServer.Ad(); 

        #region 添加一条广告日志信息
        public string Insert(long adsId, string IP)
        {
            DataTable dt = DALad.GetDataTable("where ad_id=" + adsId.ToString(), "");
            
            if (XYECOM.Core.Utils.GetCookie("_xy_ads_chs_10_"+adsId.ToString() + "_aa") != "")
            {
                return dt.Rows[0]["AD_LinkURL"].ToString();
            }
            else
            {
               int j =  DAL.Insert(adsId, IP);
               if (j > 0)
               {
                   HttpCookie cookie = HttpContext.Current.Request.Cookies["_xy_ads_chs_10_" + adsId.ToString() + "_aa"];
                   if (cookie == null)
                   {
                       cookie = new HttpCookie("_xy_ads_chs_10_" + adsId.ToString() + "_aa");
                   }
                   cookie.Value = XYECOM.Core.Utils.JSEscape(XYECOM.Core.SecurityUtil.AESEncrypt(DateTime.Now.ToString(), XYECOM.Configuration.Security.Instance.AESKey));
                   cookie.Expires = DateTime.Now.AddHours(24);
                   HttpContext.Current.Response.AppendCookie(cookie);
                   return dt.Rows[0]["AD_LinkURL"].ToString();
               }
               else
               {
                   HttpCookie cookie = HttpContext.Current.Request.Cookies["_xy_ads_chs_10_" + adsId.ToString() + "_aa"];
                   if (cookie == null)
                   {
                       cookie = new HttpCookie("_xy_ads_chs_10_" + adsId.ToString() + "_aa");
                   }
                   cookie.Value = XYECOM.Core.Utils.JSEscape(XYECOM.Core.SecurityUtil.AESEncrypt(DateTime.Now.ToString(), XYECOM.Configuration.Security.Instance.AESKey));
                   cookie.Expires = DateTime.Now.AddHours(24);
                   HttpContext.Current.Response.AppendCookie(cookie);
                   return dt.Rows[0]["AD_LinkURL"].ToString();
               }

            }
        }
        #endregion

        #region  删除指定广告日志信息
        public int DeleteByids(string adids)
        {
            if (adids == "")
                return -1;

            return DAL.DeleteByids(adids);
           
        }
        #endregion

    }
}
