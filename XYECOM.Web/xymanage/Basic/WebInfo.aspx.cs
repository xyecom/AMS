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
using System.Data.SqlClient;
using System.IO;
using XYECOM.Business;
using XYECOM.Core;


public partial class xymanage_basic_WebInfo : XYECOM.Web.BasePage.ManagePage
{
    #region 页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("basic");
    }
    #endregion

    #region 读取要修改的基本信息
    protected override void BindData()
    {
        this.btnok.Attributes.Add("onclick", "javascript:return WebInfoInput()");

        this.tbwebname.Text = webInfo.WebName;
        this.txtWebLogo.Text = webInfo.WebLogo;
        this.tbweburl.Text = webInfo.WebDomain;

        this.tbwebsuffix.Text = webInfo.WebSuffix;
        this.ddlstaticpagesuffix.SelectedValue = webInfo.StaticPageSuffix;
        rbbogusstatic.Text = webInfo.IsBogusStatic.ToString().ToLower();

        this.webmoney.Text = webInfo.WebMoneyName;

        this.CookieDomain.Text = webInfo.CookieDomain;

        rbdomain.Checked = webInfo.IsDomain;
        rbnewsdomain.Checked = webInfo.IsNewsDomain;
        rdoTradeDomain.Checked = webInfo.IsTradeDomain;
        rdoAreaDomain.Checked = webInfo.IsAreaDomain;
        rdoTopicDomain.Checked = webInfo.IsTopicDomain;
        rdoProtypeDomain.Checked = webInfo.IsProTypeDomain;

        if (webInfo.IsRun)
            rdoSiteStateOpen.Checked = true;
        else
            rdoSiteStateClose.Checked = true;

        txtSiteCloseTips.Text = webInfo.SiteCloseTip;
    }
    #endregion

    #region 单击设置按钮事件
    protected void btnok_Click(object sender, EventArgs e)
    {
        string oldSuffix = webInfo.WebSuffix;

        webInfo.WebName = this.tbwebname.Text.Trim();
        webInfo.WebLogo = this.txtWebLogo.Text.Trim();
        webInfo.WebDomain = this.tbweburl.Text.Trim();
        webInfo.WebSuffix = this.tbwebsuffix.Text.Trim();
        webInfo.StaticPageSuffix = this.ddlstaticpagesuffix.SelectedValue;

        webInfo.IsBogusStatic = XYECOM.Core.MyConvert.GetBoolean(rbbogusstatic.Text.Trim());

        webInfo.WebMoneyName = this.webmoney.Text.Trim();

        //是否启用二级域名
        webInfo.IsDomain = rbdomain.Checked;
        webInfo.IsNewsDomain = rbnewsdomain.Checked;
        webInfo.IsTradeDomain = rdoTradeDomain.Checked;
        webInfo.IsAreaDomain = rdoAreaDomain.Checked;
        webInfo.IsTopicDomain = rdoTopicDomain.Checked;
        webInfo.IsProTypeDomain = rdoProtypeDomain.Checked;

        webInfo.CookieDomain = CookieDomain.Text.Trim();

        if (rdoSiteStateOpen.Checked)
            webInfo.IsRun = true;
        else
            webInfo.IsRun = false;

        webInfo.SiteCloseTip = this.txtSiteCloseTips.Text.Trim();

        //实例化网站设置方法类以及登录日志类
        XYECOM.Business.Log l = new XYECOM.Business.Log();
        XYECOM.Model.LogInfo el = new XYECOM.Model.LogInfo();

        bool result = webInfo.Update();

        string url = "WebInfo.aspx";

        if (result)
        {
            el.L_Title = "网站设置";
            el.L_Content = "设置网站信息成功";
            el.L_MF = "系统信息设置";

            {
                el.UM_ID = AdminId;
            }
            l.Insert(el);
            Alert("设置成功！", url);
        }
        else
        {
            el.L_Title = "网站设置";
            el.L_Content = "设置网站信息失败";
            el.L_MF = "系统信息设置";

            {
                el.UM_ID = AdminId;
            }
            l.Insert(el);
            Alert("设置失败！请检查/Config/目录写权限！", url);
        }

        string suffix = this.tbwebsuffix.Text.Trim();

        if (!suffix.Equals(oldSuffix))
        {
            ///Update web.config file
            XYECOM.Configuration.WebConfig.UpdateWebConfigForSuffix(suffix);

            //根据伪后缀名生成栏目目录的文件            
            string strfolderNames = "job,company,brand,news,user,person,shop,exhibition,trade,area";

            foreach (XYECOM.Configuration.ModuleInfo info in XYECOM.Configuration.Module.Instance.ModuleItems)
            {
                strfolderNames += "," + info.SEName;
            }

            if (!oldSuffix.Equals("aspx"))
            {
                try
                {
                    File.Delete(Server.MapPath("/Index." + oldSuffix));
                }
                catch { }
            }

            string[] folderNames = strfolderNames.Split(',');
            for (int i = 0; i < folderNames.Length; i++)
            {
                try
                {
                    File.Delete(Server.MapPath("/" + folderNames[i] + "/Index." + oldSuffix));
                }
                catch { }
            }

            string message = "";

            bool ok = false;

            if (!suffix.Equals("aspx"))
            {
                ok = CreateIndexPage("/");
                if (ok == false) message += "目录写权限不足，生成自定义后缀系统首页文件(/index." + suffix + ")失败！可以手动拷贝/index.aspx 为 /index." + suffix + "<br/>";
            }

            for (int i = 0; i < folderNames.Length; i++)
            {
                ok = CreateIndexPage("/" + folderNames[i] + "/");

                if (ok == false) message += "目录写权限不足，生成自定义后缀频道首页(/" + folderNames[i] + "/index." + suffix + ")失败！可以手动拷贝/index.aspx 为 /" + folderNames[i] + "/index." + suffix + "<br/>";
            }


            if (!oldSuffix.Equals("aspx"))
            {
                try
                {
                    File.Delete(Server.MapPath("/UploadImage." + oldSuffix));
                }
                catch { }
            }

            if (!suffix.Equals("aspx"))
            {
                try
                {
                    File.Copy(Server.MapPath("/UploadImage.aspx"), Server.MapPath("/UploadImage." + suffix), true);
                }
                catch (Exception ex)
                {
                    WriteLog("xymanage_basic_WebInfo.btnok_Click", ex);
                    message += "目录写权限不足，生成自定义后缀图片上传文件(/UploadImage." + suffix + ")失败！可以手动拷贝/UploadImage.aspx 为 /UploadImage." + suffix + "<br/>";
                }
            }

            if (!message.Equals("")) throw new Exception(message);
        }

        try
        {
            //生成对应的js配置信息
            using (StreamWriter sw = new StreamWriter(Server.MapPath("/config/js/config.js"), false, System.Text.Encoding.Default))
            {
                FileInfo ff = new FileInfo(Server.MapPath("/config/js/config.js"));
                ff.Attributes = FileAttributes.Normal;
                System.Text.StringBuilder strconfig = new System.Text.StringBuilder();
                strconfig.AppendLine("function WebConfig() {");
                strconfig.AppendLine("  return {");
                strconfig.AppendLine("      BogusStatic:" + webInfo.IsBogusStatic.ToString().ToLower() + ",");
                strconfig.AppendLine("      IsDomain:" + webInfo.IsDomain.ToString().ToLower() + ",");
                strconfig.AppendLine("      IsNewsDomain:" + webInfo.IsNewsDomain.ToString().ToLower() + ",");
                strconfig.AppendLine("      Suffix:\"" + webInfo.WebSuffix + "\",");
                strconfig.AppendLine("      WebName:\"" + webInfo.WebName + "\",");
                strconfig.AppendLine("      WebURL:\"" + webInfo.WebDomain + "\",");
                strconfig.AppendLine("      TemplatePath:\"\"");
                strconfig.AppendLine("  };");
                strconfig.AppendLine("}");
                strconfig.AppendLine("var config = new WebConfig();");
                sw.Write(strconfig.ToString());
                sw.Flush();
            }
        }
        catch (Exception ex)
        {
            WriteLog("生成JS配置信息失败！请检查/Config/目录写权限！", ex);
        }
    }
    #endregion
}
