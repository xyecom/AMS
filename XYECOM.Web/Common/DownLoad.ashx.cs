using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace XYECOM.Web.Common
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class DownLoad : IHttpHandler
    {
        static System.Web.HttpContext context = null;

        public void ProcessRequest(HttpContext c)
        {
            context = c;

            string ip = XYECOM.Core.XYRequest.GetIP();

            //IP判断
            if (XYECOM.Configuration.Security.Instance._ForbidIP.Contains(ip))
            {
                context.Response.Write("-禁止访问-");
                context.Response.End();
            }

            string strId = XYECOM.Core.XYRequest.GetQueryString("f");

            strId = strId.Substring(37,strId.Length-40);

            long Id = XYECOM.Core.MyConvert.GetInt64(strId);

            if (Id <= 0)
            {
                context.Response.Write("-无效参数-");
                context.Response.End();
            }

            XYECOM.Model.AttachmentInfo info = new XYECOM.Business.Attachment().GetItem(Id);

            if (null == info)
            {
                context.Response.Write("-文件不存在或已经被删除-");
                context.Response.End();
            }

            //XYECOM.Model.ServerInfo serverInfo = new XYECOM.Business.Server().GetItem(info.S_ID);

            string filePath = context.Server.MapPath("/upload/" + info.At_Path);

            System.IO.FileInfo fileInfo = new System.IO.FileInfo(filePath);

            if (!fileInfo.Exists)
            {
                context.Response.Write("-文件不存在或已经被删除-");
                context.Response.End();
            }

            try
            {
                context.Response.Clear();
                context.Response.ClearHeaders();
                context.Response.BufferOutput = false;

                context.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(System.IO.Path.GetFileName(filePath), System.Text.Encoding.UTF8));
                context.Response.AppendHeader("Content-Length", fileInfo.Length.ToString());
                context.Response.ContentType = "application/octet-stream";
                context.Response.WriteFile(filePath);
                context.Response.Flush();
                context.Response.End();
            }
            catch
            {
                context.Response.Write("-下载失败！-");
                context.Response.End();
            }
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
