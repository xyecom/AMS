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
using XYECOM.Core;
using XYECOM.Business;

public partial class xymanage_TemplatesManage_AddTemplate : XYECOM.Web.BasePage.ManagePage
{
    private string path = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //防止调用页面缓存
        Response.Buffer = true;
        Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
        Response.Expires = 0;
        Response.CacheControl = "no-cache";

        CheckRole("template");

        string msg = "";
        if (Session["A_Name"] == null)
        {
            msg = "nologin";
        }
        else
        {
            #region 模板入库

            if (XYRequest.GetQueryString("T_ID") != "")
            {
                try
                {
                    string text = XYRequest.GetQueryString("T_ID");
                    if (text != "")
                    {
                        int tempId = XYECOM.Core.MyConvert.GetInt32(text);
                        XYECOM.Model.TemplateInfo info = new XYECOM.Business.Template().GetTemplateItem(tempId);

                        if (info != null)
                        {
                            msg = "模板已经入库,本次操作无效！";
                        }
                        else
                        {
                            this.path = XYECOM.Core.Utils.GetMapPath(@"..\..\templates\");
                            int num = new XYECOM.Business.Template().SelectMaxID("b_Template", "T_ID");
                            foreach (DataRow row in this.buildGridData().Select(string.Concat(new object[] { "T_ID IN(", text, ") AND T_ID>", num })))
                            {
                                string commandText = string.Format("INSERT INTO [b_Template] ([T_name]," +
                                    "[T_Path],[T_copyright],[T_author],[T_Adddate],[T_ver]) VALUES('{0}','{1}'" +
                                    ",'{2}','{3}','{4}','{5}')", new object[] { row["T_name"].ToString().Trim(), 
                                    row["T_Path"].ToString().Trim(), row["T_copyright"].ToString().Trim(),
                                    row["T_author"].ToString().Trim(), row["T_Adddate"].ToString().Trim(),
                                    row["T_ver"].ToString().Trim() });
                                try
                                {
                                    XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(commandText);
                                    msg = "模板入库成功！";
                                }
                                catch
                                {
                                    msg = "无法更新数据库！";
                                }
                                this.CreateTemplateByDirectory(row["T_Path"].ToString().Trim());
                            }
                         
                        }
                    }
                    else
                    {
                        msg = "此次提交无法执行";
                    }
                }
                catch
                {
                    //msg = "模板入库失败！请稍候再试！";
                }
            }
            #endregion

            #region 生成模板
            else if (XYRequest.GetQueryString("TempNames") != "" && XYRequest.GetQueryString("path") != "" && XYRequest.GetQueryString("delete") == "")
            {
                try
                {
                    string templateNames = XYRequest.GetQueryString("TempNames");
                    if (templateNames == "all|")
                    {
                        string skinName = XYRequest.GetQueryString("path");
                        string[] skins = skinName.Split('|');

                        int fileall = 0;
                        int num = 0;
                        foreach (string s in skins)
                        {
                            fileall = 0;
                            num = 0;
                            Createtemps(s, "", ref fileall, ref num);
                            msg +=  "成功生成" + num + "个模板文件！<br/>";
                        }
                    }
                    else
                    {
                        string skinName = XYRequest.GetQueryString("path");
                        string pathName = XYRequest.GetQueryString("pathName");
                        int num2 = 0;
                        int ControlsNum = 0;
                        XYECOM.Template.WebPageTemplate template = new XYECOM.Template.WebPageTemplate();

                        string[] textArray = templateNames.Split(',');

                        for (int i = 0; i < textArray.Length; i++)
                        {
                            if (!textArray[i].ToString().StartsWith("_"))
                            {
                                template.GetTemplate(skinName, textArray[i].ToString(), 1, skinName, pathName, XYECOM.Core.XYRequest.GetQueryString("ppathname"));
                                num2++;
                            }
                            else
                            {
                                ControlsNum++;
                            }
                        }
                        msg = msg = "成功生成" + num2 + "个模板文件！失败" + (textArray.Length - num2 - ControlsNum) + "个模板文件！";
                    }
                }
                catch (IOException ex)
                {
                    msg = "生成模板失败，请检查 /aspx/ 目录写权限！<br/>" + ex.Message;
                    base.WriteLog("生成模板失败!<br/>生成路径访问权限不足。", ex);
                }
                catch (Exception ex1)
                {
                    msg = "生成模板失败！<br/>" + ex1.Message;
                    base.WriteLog("生成模板失败!", ex1);
                }
            }
            #endregion

            #region 删除模板
            else if (XYRequest.GetQueryString("TempNames") != "" && XYRequest.GetQueryString("path") != "" && XYRequest.GetQueryString("delete") != "")
            {
                try
                {
                    string templateNames = XYRequest.GetQueryString("TempNames");

                    string[] textArray = templateNames.Split(',');

                    int num = 0;
                    for (int i = 0; i < textArray.Length; i++)
                    {
                        string url = Server.MapPath("../../templates/" + XYRequest.GetQueryString("path") + "/" + textArray[i].ToString() + ".htm");

                        if (XYECOM.Core.Utils.FileExists(url))
                        {
                            File.Delete(url);
                            num++;
                        }
                    }
                    msg = "共删除成功" + num + "个模板文件！";

                }
                catch (Exception ex)
                {
                    msg = "删除模板失败，请检查 /aspx/ 目录写权限！<br/>" + ex.Message;
                    base.WriteLog("删除模板失败", ex);
                }
            }
            #endregion

        }
        //Alert(msg,"",true);
        Response.Write(msg);
    }

    /// <summary>
    /// 生成模板页
    /// </summary>
    private void Createtemps(string skinName, string folderName, ref int fileAll, ref int num)
    {
        if (skinName.IndexOf("/") != -1 && folderName.Equals(""))
        {
            string[] ts = skinName.Split('/');
            skinName = ts[0];
            folderName = ts[1];
        }

        DirectoryInfo info = new DirectoryInfo(Server.MapPath("../../templates/" + skinName + "/" + folderName));
        XYECOM.Template.WebPageTemplate template = new XYECOM.Template.WebPageTemplate();
        string filename = "";

        foreach(DirectoryInfo ff in info.GetDirectories())
        {
            Createtemps(skinName, ("" == folderName ? "" : (folderName + "/")) + ff.Name, ref fileAll, ref num);
        }
        foreach (FileSystemInfo info2 in info.GetFileSystemInfos())
        {
            if (info2 != null)
            {
                if (info2.Extension.Length > 0 && info2.Extension.Substring(1).ToLower() == "htm")
                {
                    filename = info2.Name.Substring(0, info2.Name.LastIndexOf("."));

                    if (!filename.StartsWith("_"))
                    {
                        string ppath = "";
                        if (folderName.IndexOf("/") > -1)
                            ppath = folderName.Split('/')[0];

                        template.GetTemplate(skinName, filename, 1, skinName, folderName, ppath);
                        num++;
                    }
                    fileAll++;
                }
            }
        }
    }

    private DataTable buildGridData()
    {
        return new XYECOM.Business.Template().GetAllTemplateList(this.path);
    }

    #region 生成模板
    private void CreateTemplateByDirectory(string directorypath)
    {
        DirectoryInfo info = new DirectoryInfo(base.Server.MapPath("../../templates/" + directorypath + "/"));
        XYECOM.Template.WebPageTemplate template = new XYECOM.Template.WebPageTemplate();

        XYECOM.Configuration.ModuleInfo moduleInfo = null;
        int num = 0;
        string T_Name = new XYECOM.Business.Template().GetAllTemplateList(XYECOM.Core.Utils.GetMapPath(@"..\..\templates\")).Select("T_Path='" + directorypath + "'")[0]["T_Name"].ToString();
        if (Directory.Exists(base.Server.MapPath("../../templates/" + directorypath)))
        {
            foreach (FileSystemInfo info2 in info.GetFileSystemInfos())
            {
                if (((info2 != null) && info2.Extension.ToLower().Equals(".htm")) && (info2.Name.IndexOf("_") != 0))
                {
                    string templateName = info2.Name.Split(new char[] { '.' })[0];
                    template.GetTemplate(directorypath, templateName, 1, T_Name.Trim(), "", "");
                    num++;
                }
            }
        }

        moduleInfo = moduleConfig.GetItem("offer");
        if (Directory.Exists(base.Server.MapPath("../../templates/" + directorypath + "/" + moduleInfo.SEName)))
        {
            info = new DirectoryInfo(base.Server.MapPath("../../templates/" + directorypath + "/" + moduleInfo.SEName + "/"));

            foreach (FileSystemInfo info2 in info.GetFileSystemInfos())
            {
                if (((info2 != null) && info2.Extension.ToLower().Equals(".htm")) && (info2.Name.IndexOf("_") != 0))
                {
                    string templateName = info2.Name.Split(new char[] { '.' })[0];
                    template.GetTemplate(directorypath, templateName, 1, T_Name.Trim(), moduleInfo.SEName, "");
                    num++;
                }
            }
        }

        moduleInfo = moduleConfig.GetItem("venture");
        if (Directory.Exists(base.Server.MapPath("../../templates/" + directorypath + "/" + moduleInfo.SEName)))
        {
            info = new DirectoryInfo(base.Server.MapPath("../../templates/" + directorypath + "/" + moduleInfo.SEName + "/"));
            foreach (FileSystemInfo info2 in info.GetFileSystemInfos())
            {
                if (((info2 != null) && info2.Extension.ToLower().Equals(".htm")) && (info2.Name.IndexOf("_") != 0))
                {
                    string templateName = info2.Name.Split(new char[] { '.' })[0];
                    template.GetTemplate(directorypath, templateName, 1, T_Name.Trim(), moduleInfo.SEName, "");
                    num++;
                }
            }
        }
        moduleInfo = moduleConfig.GetItem("investment");
        if (Directory.Exists(base.Server.MapPath("../../templates/" + directorypath + "/" + moduleInfo.SEName)))
        {
            info = new DirectoryInfo(base.Server.MapPath("../../templates/" + directorypath + "/" + moduleInfo.SEName + "/"));
            foreach (FileSystemInfo info2 in info.GetFileSystemInfos())
            {
                if (((info2 != null) && info2.Extension.ToLower().Equals(".htm")) && (info2.Name.IndexOf("_") != 0))
                {
                    string templateName = info2.Name.Split(new char[] { '.' })[0];
                    template.GetTemplate(directorypath, templateName, 1, T_Name.Trim(), moduleInfo.SEName, "");
                    num++;
                }
            }
        }
        moduleInfo = moduleConfig.GetItem("service");
        if (Directory.Exists(base.Server.MapPath("../../templates/" + directorypath + "/" + moduleInfo.SEName)))
        {
            info = new DirectoryInfo(base.Server.MapPath("../../templates/" + directorypath + "/" + moduleInfo.SEName + "/"));
            foreach (FileSystemInfo info2 in info.GetFileSystemInfos())
            {
                if (((info2 != null) && info2.Extension.ToLower().Equals(".htm")) && (info2.Name.IndexOf("_") != 0))
                {
                    string templateName = info2.Name.Split(new char[] { '.' })[0];
                    template.GetTemplate(directorypath, templateName, 1, T_Name.Trim(), moduleInfo.SEName, "");
                    num++;
                }
            }
        }
        moduleInfo = moduleConfig.GetItem("exhibition");
        if (Directory.Exists(base.Server.MapPath("../../templates/" + directorypath + "/" + moduleInfo.SEName)))
        {
            info = new DirectoryInfo(base.Server.MapPath("../../templates/" + directorypath + "/" + moduleInfo.SEName + "/"));
            foreach (FileSystemInfo info2 in info.GetFileSystemInfos())
            {
                if (((info2 != null) && info2.Extension.ToLower().Equals(".htm")) && (info2.Name.IndexOf("_") != 0))
                {
                    string templateName = info2.Name.Split(new char[] { '.' })[0];
                    template.GetTemplate(directorypath, templateName, 1, T_Name.Trim(), moduleInfo.SEName, "");
                    num++;
                }
            }
        }
        if (Directory.Exists(base.Server.MapPath("../../templates/" + directorypath + "/job")))
        {
            info = new DirectoryInfo(base.Server.MapPath("../../templates/" + directorypath + "/job/"));
            foreach (FileSystemInfo info2 in info.GetFileSystemInfos())
            {
                if (((info2 != null) && info2.Extension.ToLower().Equals(".htm")) && (info2.Name.IndexOf("_") != 0))
                {
                    string templateName = info2.Name.Split(new char[] { '.' })[0];
                    template.GetTemplate(directorypath, templateName, 1, T_Name.Trim(), "job", "");
                    num++;
                }
            }
        }
        if (Directory.Exists(base.Server.MapPath("../../templates/" + directorypath + "/brand")))
        {
            info = new DirectoryInfo(base.Server.MapPath("../../templates/" + directorypath + "/brand/"));
            foreach (FileSystemInfo info2 in info.GetFileSystemInfos())
            {
                if (((info2 != null) && info2.Extension.ToLower().Equals(".htm")) && (info2.Name.IndexOf("_") != 0))
                {
                    string templateName = info2.Name.Split(new char[] { '.' })[0];
                    template.GetTemplate(directorypath, templateName, 1, T_Name.Trim(), "brand", "");
                    num++;
                }
            }
        }
        if (Directory.Exists(base.Server.MapPath("../../templates/" + directorypath + "/company")))
        {
            info = new DirectoryInfo(base.Server.MapPath("../../templates/" + directorypath + "/company/"));
            foreach (FileSystemInfo info2 in info.GetFileSystemInfos())
            {
                if (((info2 != null) && info2.Extension.ToLower().Equals(".htm")) && (info2.Name.IndexOf("_") != 0))
                {
                    string templateName = info2.Name.Split(new char[] { '.' })[0];
                    template.GetTemplate(directorypath, templateName, 1, T_Name.Trim(), "company", "");
                    num++;
                }
            }
        }
        if (Directory.Exists(base.Server.MapPath("../../templates/" + directorypath + "/news")))
        {
            info = new DirectoryInfo(base.Server.MapPath("../../templates/" + directorypath + "/news/"));
            foreach (FileSystemInfo dinfo in info.GetFileSystemInfos())
            {
                if (dinfo.GetType().Name == "DirectoryInfo")
                {
                    DirectoryInfo dinfo2 = new DirectoryInfo(base.Server.MapPath("../../templates/" + directorypath + "/news/" + dinfo.Name));

                    foreach (FileSystemInfo info2 in dinfo2.GetFileSystemInfos())
                    {
                        if (((info2 != null) && info2.Extension.ToLower().Equals(".htm")) && (info2.Name.IndexOf("_") != 0))
                        {
                            string templateName = info2.Name.Split(new char[] { '.' })[0];
                            template.GetTemplate(directorypath, templateName, 1, T_Name.Trim(), "news/" + dinfo.Name, "");
                            num++;
                        }
                    }
                }
            }
        }
        if (Directory.Exists(base.Server.MapPath("../../templates/" + directorypath + "/shop")))
        {
            info = new DirectoryInfo(base.Server.MapPath("../../templates/" + directorypath + "/shop/"));
            foreach (FileSystemInfo dinfo in info.GetFileSystemInfos())
            {
                if (dinfo.GetType().Name == "DirectoryInfo")
                {
                    DirectoryInfo dinfo2 = new DirectoryInfo(base.Server.MapPath("../../templates/" + directorypath + "/shop/" + dinfo.Name));
                    foreach (FileSystemInfo info2 in dinfo2.GetFileSystemInfos())
                    {
                        if (((info2 != null) && info2.Extension.ToLower().Equals(".htm")) && (info2.Name.IndexOf("_") != 0))
                        {
                            string templateName = info2.Name.Split(new char[] { '.' })[0];
                            template.GetTemplate(directorypath, templateName, 1, T_Name.Trim(), "shop/" + dinfo.Name, "");
                            num++;
                        }
                    }
                }
            }
        }
        if (Directory.Exists(base.Server.MapPath("../../templates/" + directorypath + "/user")))
        {
            info = new DirectoryInfo(base.Server.MapPath("../../templates/" + directorypath + "/user/"));
            foreach (FileSystemInfo info2 in info.GetFileSystemInfos())
            {
                if (((info2 != null) && info2.Extension.ToLower().Equals(".htm")) && (info2.Name.IndexOf("_") != 0))
                {
                    string templateName = info2.Name.Split(new char[] { '.' })[0];
                    template.GetTemplate(directorypath, templateName, 1, T_Name.Trim(), "user", "");
                    num++;
                }
            }
        }
        if (Directory.Exists(base.Server.MapPath("../../templates/" + directorypath + "/person")))
        {
            info = new DirectoryInfo(base.Server.MapPath("../../templates/" + directorypath + "/person/"));
            foreach (FileSystemInfo info2 in info.GetFileSystemInfos())
            {
                if (((info2 != null) && info2.Extension.ToLower().Equals(".htm")) && (info2.Name.IndexOf("_") != 0))
                {
                    string templateName = info2.Name.Split(new char[] { '.' })[0];
                    template.GetTemplate(directorypath, templateName, 1, T_Name.Trim(), "person", "");
                    num++;
                }
            }
        }
    }
    #endregion

}
