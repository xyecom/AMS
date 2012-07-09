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

public partial class xymanage_ModuleManage_ModuleAdd : XYECOM.Web.BasePage.ManagePage
{
    #region 页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("module");

        if (XYECOM.Core.XYRequest.IsPost())
        {
            string newModuleName = tbename.Text.Trim();


            if (newModuleName.Equals("job") || newModuleName.Equals("brand") || newModuleName.Equals("exhibition"))
            {
                Alert("系统内置模块，请尝试其他名称！");
                return;
            }

            if (null == moduleConfig.GetItem(newModuleName))
            {
                XYECOM.Configuration.ModuleInfo info = new XYECOM.Configuration.ModuleInfo();
                info.CName = tbcname.Text.Trim();
                info.Description = tbDescription.Text.Trim();
                info.EName = newModuleName;
                info.Order = moduleConfig.ModuleItems.Count + 1;
                info.PEName = XYECOM.Core.XYRequest.GetQueryString("EName");
                info.SEName = newModuleName;
                info.State = true;

                int total = XYECOM.Core.MyConvert.GetInt32(this.infoTypeTotal.Value.ToString());

                XYECOM.Configuration.ModuleItemInfo iteminfo = null;

                string prefix = "";
                string postfix = "";

                int index = 0;
                for (int i = 1; i <= total; i++)
                {
                    prefix = XYECOM.Core.XYRequest.GetFormString("tbprefix" + i);
                    postfix = XYECOM.Core.XYRequest.GetFormString("tbpostfix" + i);

                    if (prefix.Equals("") && postfix.Equals("")) continue;

                    iteminfo = new XYECOM.Configuration.ModuleItemInfo();
                    iteminfo.InfoTypeStr = XYECOM.Core.XYRequest.GetFormString("hidInfoType_" + i);

                    iteminfo.ID = index + 1;
                    iteminfo.Prefix = prefix;
                    iteminfo.Postfix = postfix;

                    info.Item.Add(iteminfo);
                    index++;
                }

                if (index == 0)
                {
                    Alert("模块必须包含至少一种信息类型！");
                    return;
                }

                XYECOM.Configuration.Module.Instance.Update();

                string msg = "";
                if (moduleConfig.Insert(info))
                {
                    msg = "<span style='float:left;text-align:left;padding:5px;'>";

                    if ("" != XYECOM.Core.XYRequest.GetQueryString("EName"))
                    {
                        msg += "“" + newModuleName + "”模块新增成功!<br/>";
                        msg += "新模块模板目录为:/templates/" + template.Path + "/" + newModuleName + "/<br/>";
                        msg += "新模块访问路径为:/" + newModuleName + "/<br/>";

                        CreateFile();

                        if (!CreateIndexPage("/" + newModuleName))
                        {
                            msg += "模块默认首页创建失败！请手动在站点根目录创建&lt;" + newModuleName + "&gt;文件夹，并拷贝/index." + webInfo.WebSuffix + "至目录下！ <br/>";
                        }
                        msg += "</span>";
                    }
                }
                Alert(msg, "ModuleList.aspx");
            }
            else
            {
                Alert("已经有“" + newModuleName + "”名称的模块，英文模块名必须保持唯一，请重新填写！");
            }

            return;
        }

        if (!IsPostBack)
        {
            if (XYECOM.Core.XYRequest.GetQueryString("ename").Equals("exhibition"))
            {
                this.pnlSEOSetting.Visible = false;
            }

            if (XYECOM.Core.XYRequest.GetQueryString("EName") != "")
            {
                this.lblName.Text = moduleConfig.GetItem(XYECOM.Core.XYRequest.GetQueryString("EName")).CName;
            }
            else
            {
                this.lblName.Text = "根模块";
            }
        }
    }
    #endregion

    #region 创建模板文件
    private bool CreateFile()
    {
        bool result = false;

        string path = Server.MapPath("../../templates/" + XYECOM.Configuration.Template.Instance.Path + "/");

        string parentPath = path + XYECOM.Core.XYRequest.GetQueryString("EName");

        string newPath = path + this.tbename.Text;

        DirectoryInfo di = new DirectoryInfo(parentPath);

        foreach (FileSystemInfo fsi in di.GetFileSystemInfos())
        {
            if (fsi != null)
            {
                if (!Directory.Exists(newPath))
                    Directory.CreateDirectory(newPath);

                string strExtension = fsi.Extension.ToLower();
                if (strExtension.IndexOf("htm") > 0)
                {

                    StreamReader sr = new StreamReader(parentPath + "/" + fsi.Name, System.Text.Encoding.Default);

                    string strInfo = sr.ReadToEnd();

                    sr.Close();

                    try
                    {
                        StreamWriter sw = new StreamWriter((Stream)File.OpenWrite(newPath + "/" + fsi.Name), System.Text.Encoding.Default);
                        sw.Write(strInfo);
                        sw.Flush();
                        sw.Close();
                        result = true;
                    }
                    catch { }
                }
            }
        }

        return result;
    }
    #endregion
}
