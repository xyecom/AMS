using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

namespace XYECOM.Web.xymanage.TemplatesManage
{
    public partial class ShopTemplateTree : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("template");
        }

        protected override void BindData()
        {
            string path = XYECOM.Core.XYRequest.GetQueryString("path").Trim();

            if (path.Equals("")) throw new Exception("路径参数为空！");

            this.hidpathname.Value = path;

            ShowFile(path);
            this.fileList_box2.InnerHtml = ShowDir(path, "");
        }

        private bool IsShowDir(FileSystemInfo info)
        {
            DirectoryInfo dir = (DirectoryInfo)info;
            bool isShow = false;
            foreach (FileSystemInfo subDir in dir.GetFileSystemInfos())
            {
                if (subDir.GetType().Name == "DirectoryInfo")
                {
                    isShow = IsShowDir(subDir);

                    if (isShow) return isShow;
                }
                else
                {
                    if (subDir.Extension.Equals(".htm") || subDir.Extension.Equals(".css")) return true;
                }
            }
            return false;
        }

        private string ShowDir(string dirName, string str)
        {
            string fullName = "/templates/_shop/" + dirName;

            fullName = Server.MapPath(fullName);

            DirectoryInfo dirInfo = new DirectoryInfo(fullName);

            System.Text.StringBuilder sbhtml = new System.Text.StringBuilder("");

            foreach (FileSystemInfo subDir in dirInfo.GetFileSystemInfos())
            {
                if (subDir.GetType().Name == "DirectoryInfo")
                {
                    if (!IsShowDir(subDir)) continue;
                    sbhtml.Append("<li>" + str + "<img src=\"../images/temp02.GIF\" alt=\"文件夹\">" + subDir.Name + "</li>");

                    sbhtml.Append(ShowDir(dirName + "/" + subDir.Name, "--" + str));
                }
                else
                {
                    if (str.Equals("")) continue;

                    if (subDir.Extension != ".htm" && subDir.Extension != ".css") continue;

                    sbhtml.Append("<li>" + str + "<img src=\"../images/temp.GIF\" alt=\"模版\">[<a href=\"javascript:TemplatesEdit('../../templates/_shop/" + dirName + "/" + subDir.Name + "');\">编辑</a>]");
                    sbhtml.Append("<label for=\"temp01\">" + subDir.Name + "</label></li>");
                }
            }

            return sbhtml.ToString();
        }

        private void ShowFile(string dirName)
        {
            string fullName = "/templates/_shop/" + dirName;

            fullName = Server.MapPath(fullName);

            DirectoryInfo dirInfo = new DirectoryInfo(fullName);

            System.Text.StringBuilder sbhtml = new System.Text.StringBuilder("");

            foreach (FileInfo file in dirInfo.GetFiles())
            {
                if (file.Extension != ".htm" && file.Extension != ".css") continue;

                sbhtml.Append("<li><img src=\"../images/temp.GIF\" alt=\"模版\">[<a href=\"javascript:TemplatesEdit('../../templates/_shop/" + dirName + "/" + file.Name + "');\">编辑</a>]<input id=\"chkaspx\" name=\"");
                sbhtml.Append(dirName);
                sbhtml.Append("\" type=\"checkbox\" value=\"" + file.Name.Substring(0, file.Name.LastIndexOf(".")) + "\"><label for=\"temp01\">" + file.Name + "</label></li>");
            }

            this.fileList_box1.InnerHtml = sbhtml.ToString();
        }
    }
}
