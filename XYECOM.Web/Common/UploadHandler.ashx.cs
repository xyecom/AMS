using System;
using System.Collections.Generic;

using System.Web;
using System.IO;

namespace XYECOM.Web.Common
{
    /// <summary>
    /// UploadHandler 的摘要说明
    /// </summary>
    public class UploadHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Charset = "utf-8";

            HttpPostedFile file = context.Request.Files["Filedata"];
            string type = context.Request.QueryString["type"];
            string[] typeUidinfoid = null;
            if (!string.IsNullOrEmpty(type))
            {
                typeUidinfoid = type.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
            }
            if (file != null && file.ContentLength > 0 && typeUidinfoid != null && typeUidinfoid.Length > 1 && typeUidinfoid.Length < 4)
            {
                string folder = context.Request["folder"];


                string uploadPath = HttpContext.Current.Server.MapPath(folder) + "\\";
                if (!string.IsNullOrEmpty(typeUidinfoid[0]))
                {
                    uploadPath += typeUidinfoid[0] + "\\";
                }
                string today = DateTime.Now.ToString("yy-MM-dd");
                uploadPath += today + "\\";
                if (!Directory.Exists(uploadPath))
                {
                    XYECOM.Core.Utils.CreateDir(uploadPath);
                }

                string fileName = file.FileName;
                string fileFormat = fileName.Substring(fileName.LastIndexOf(".") + 1).ToLower();
                string newFileName = DateTime.Now.ToString("yyMMddHHmmssFFF") + "." + fileFormat;
                XYECOM.Model.AttachmentInfo info = null;
                if (typeUidinfoid.Length == 3)
                {
                    new XYECOM.Business.Attachment().Delete(typeUidinfoid[2]);
                }

                string databaseFilename = string.Format("{0}/{1}/{2}", typeUidinfoid[0], today, newFileName);
                string fileFullName = string.Format("{0}/{1}", uploadPath, newFileName);
                info = new Model.AttachmentInfo();
                info.At_FileFormat = fileFormat;
                info.At_FileType = "file";
                info.At_Index = 1;
                info.At_Path = databaseFilename;
                info.At_PulishDate = DateTime.Now;
                info.At_Remark = "";
                info.DescTabID = XYECOM.Core.MyConvert.GetInt32(context.Request.Params["userid"]);
                info.DescTabName = "Video";
                info.S_ID = new XYECOM.Business.Server().GetCurrentServerID();
                long atid = 0;

                new XYECOM.Business.Attachment().Insert(info, out atid);

                file.SaveAs(fileFullName);
                //下面这句代码缺少的话，上传成功后上传队列的显示不会自动消失
                context.Response.Write("1");
            }
            else
            {
                context.Response.Write("0");
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