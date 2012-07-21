using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using XYECOM.Page.Upload;

namespace XYECOM.Web.AppCode
{
    public class CaseUploadManager
    {
        const string CASEROOTFOLDER = "Case";

        /// <summary>
        /// 判断文件类型是否允许上传
        /// </summary>
        /// <param name="fieleType">文件类型</param>
        /// <returns>是否允许上传</returns>
        private static bool CheckFileType(string fieleType)
        {
            string[] ftypes = new string[] { "aspx", "js", "asp", "php", "jsp", "vbs", "html", "htm", "shtml", "shtm", "cgi", "asa", "asax" };
            foreach (string f in ftypes)
            {
                if (f == fieleType) return false;
            }

            return true;
        }

        public static string UpLoadFile(long companyId, long partId, int typeId, HttpPostedFile file)
        {
            string filePath = string.Empty;


            string filename = Path.GetFileName(file.FileName);
            string fileFormat = Path.GetExtension(file.FileName).Substring(1);

            if (!CheckFileType(fileFormat))
            {
                return filePath;
            }

            string folderPath = string.Empty;

            string DateFolderName = DateTime.Now.ToString("yy-MM-dd");
            string folderFmt = "{0}\\{1}\\{2}\\{3}\\{4}";//"files\\" + TabName + "\\" + DateFolderName;
            folderPath = string.Format(folderFmt, CASEROOTFOLDER, companyId, partId, typeId, DateFolderName);
            string physicalFolderPath = HttpContext.Current.Server.MapPath("/") + folderPath;

            if (!Directory.Exists(physicalFolderPath))
            {
                Directory.CreateDirectory(physicalFolderPath);
            }

            if (!Directory.Exists(physicalFolderPath))
            {
                return string.Empty;
            }

            string fileNewName = filename;

            string SFolderFullPath = physicalFolderPath + "\\" + fileNewName;

            if (File.Exists(SFolderFullPath))
            {
                fileNewName = Path.GetFileNameWithoutExtension(file.FileName) + "(" + (new Random().Next(10, 99)) + ")." + fileFormat;
                SFolderFullPath = physicalFolderPath + "\\" + fileNewName;
            }

            file.SaveAs(SFolderFullPath);

            return ("\\" + folderPath + "\\" + fileNewName).Replace("\\", "/");
        }

        public static string UpLoadFile(long companyId, long partId, int typeId)
        {
            if (HttpContext.Current.Request.Files.Count < 1)
            {
                return string.Empty;
            }
            HttpFileCollection files = HttpContext.Current.Request.Files;
            HttpPostedFile f = files[0];

            return UpLoadFile(companyId, partId, typeId, f);
        }
    }
}