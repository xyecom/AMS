using System;
using System.Collections.Generic;
using System.Web;
using XYECOM.Web.AppCode;

namespace XYECOM.Web.Common
{
    /// <summary>
    /// CaseUploadHandler 的摘要说明
    /// </summary>
    public class CaseUploadHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Charset = "utf-8";

            HttpPostedFile file = context.Request.Files["Filedata"];

            try
            {
                Model.GeneralUserInfo guInfo = XYECOM.Business.CheckUser.UserInfo;
                if (guInfo == null)
                {
                    context.Response.Write("尚未登录");
                    return;
                }

                string path = CaseUploadManager.UpLoadFile(guInfo.CompanyId, guInfo.userid, XYECOM.Core.XYRequest.GetQueryInt("typeid", 0), file);

                context.Response.Write(path);

            }
            catch { }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}