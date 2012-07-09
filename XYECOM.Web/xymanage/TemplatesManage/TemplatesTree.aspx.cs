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


public partial class xymanage_TemplatesManage_TemplatesTree : XYECOM.Web.BasePage.ManagePage
{
    #region 页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        //防止调用页面缓存
        Response.Buffer = true;
        Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
        Response.Expires = 0;
        Response.CacheControl = "no-cache";

        CheckRole("template");

        if (!this.Page.IsPostBack)
        {
            this.PageInit();
        }

    }
    #endregion


    private void PageInit()
    {
        //this.hidT_ID.Value = XYRequest.GetInt("T_ID", 1).ToString();
        this.hidpath.Value = XYRequest.GetString("path").Trim();

        #region 根目录文件
        SetTemplates("", "default");
        #endregion

        #region 资讯
        SetTemplates("/news", "news");
        #endregion

        #region CSS
        SetTemplates("/css", "css");
        #endregion

        #region 地方站
        SetTemplates("/area", "area");
        #endregion
    }


    private void SetTemplates(string strPath, string moduleName)
    {
        DirectoryInfo info = null;
        string text = XYRequest.GetString("path");

        DataTable dtfolder = new DataTable("tempnewslist");
        dtfolder.Columns.Add("id", Type.GetType("System.Int32"));
        dtfolder.Columns.Add("filename", Type.GetType("System.String"));
        dtfolder.Columns.Add("filepath", Type.GetType("System.String"));

        DataTable dtfile = new DataTable();
        dtfile.Columns.Add("id", Type.GetType("System.Int32"));
        dtfile.Columns.Add("filename", Type.GetType("System.String"));
        dtfile.Columns.Add("extension", Type.GetType("System.String"));
        dtfile.Columns.Add("parentid", Type.GetType("System.String"));
        dtfile.Columns.Add("filepath", Type.GetType("System.String"));
        dtfile.Columns.Add("fileallpath", Type.GetType("System.String"));
        dtfile.Columns.Add("filedescription", Type.GetType("System.String"));

        if (!Directory.Exists(base.Server.MapPath("../../templates/" + text + strPath)))
            SetHtmlValue(moduleName, "<ul>/templates/" + text + strPath + "文件夹不存在！</ul>");
        else
        {
            int filenum = 1;
            int foldernum = 1;
            info = new DirectoryInfo(base.Server.MapPath("../../templates/" + text + strPath));
            foreach (FileSystemInfo info2 in info.GetFileSystemInfos())
            {
                if (info2 != null)
                {
                    if (info2.Extension.Length > 0 && (info2.Extension.Substring(1).ToLower() == "htm" || info2.Extension.Substring(1).ToLower() == "css"))
                    {
                        DataRow row = dtfile.NewRow();
                        row["id"] = filenum;
                        row["filename"] = info2.Name.Substring(0, info2.Name.LastIndexOf("."));
                        row["extension"] = info2.Extension.ToLower();
                        row["parentid"] = "0";
                        row["filepath"] = text;
                        row["fileallpath"] = "../../templates/" + text + strPath + "/" + row["filename"] + row["extension"];
                        row["filedescription"] = "";
                        dtfile.Rows.Add(row);
                        filenum++;
                    }

                    if (info2.GetType().Name == "DirectoryInfo")
                    {
                        DataRow trow = dtfolder.NewRow();
                        trow["id"] = foldernum;
                        trow["filename"] = info2.Name;
                        trow["filepath"] = text;
                        dtfolder.Rows.Add(trow);
                        foldernum++;
                    }
                }
            }

            dtfolder.DefaultView.Sort = " filename asc ";
            createtemplistInnerHTML(dtfolder.DefaultView, moduleName);

            dtfile.DefaultView.Sort = " filename asc ";
            createaspxlistInnerHTML(dtfile.DefaultView, moduleName);
        }
    }

    #region 生成模板信息列表
    private void createaspxlistInnerHTML(DataView dv, string strType)
    {
        System.Text.StringBuilder sbhtml = new System.Text.StringBuilder();

        string chkDisabled = "";

        sbhtml.Append("<ul>");
        for (int i = 0; i < dv.Count; i++)
        {
            chkDisabled = "";

            sbhtml.Append("<li><img src=\"../images/temp.GIF\" alt=\"模版\">[<a href=\"javascript:TemplatesEdit('" + dv[i]["fileallpath"].ToString() + "');\">编辑</a>]<input id=\"chkaspx\" name=\"");
            sbhtml.Append(strType);

            if (dv[i]["filename"].ToString().StartsWith("_"))
            {
                chkDisabled = " disabled='disabled' ";
            }

            sbhtml.Append("\" type=\"checkbox\" " + chkDisabled + " value=\"" + dv[i]["filename"].ToString() + "\"><label for=\"temp01\">" + dv[i]["filename"].ToString() + "</label></li>");
        }
        sbhtml.Append("</ul>");

        SetHtmlValue(strType, sbhtml.ToString());
    }

    private void SetHtmlValue(string moduleName, string value)
    {
        switch (moduleName)
        {
            case "default":
                this.defaultlist.InnerHtml = value;
                break;
            case "news":
                this.newsdefaultlist.InnerHtml = value;
                break;            
            case "area":
                this.areasitedefaultlist.InnerHtml = value;
                break;            
            case "css":
                this.csslist.InnerHtml = value;
                break;
        }
    }
    #endregion

    #region 生成模板文件夹信息列表
    void createtemplistInnerHTML(DataView dv, string strType)
    {
        System.Text.StringBuilder sbhtml = new System.Text.StringBuilder();
        if (dv.Count > 0)
        {
            sbhtml.Append("<ul>");
            for (int i = 0; i < dv.Count; i++)
            {
                sbhtml.Append("<li><img src=\"../images/temp02.GIF\" alt=\"模版\"><label for=\"temp01\"><a href=\"PublicTemplateTree.aspx?temppath=");
                sbhtml.Append(XYRequest.GetString("path"));
                sbhtml.Append("&ppath=" + strType + "&path=");
                sbhtml.Append(dv[i]["filename"].ToString());
                sbhtml.Append("\">");
                sbhtml.Append(dv[i]["filename"].ToString());
                sbhtml.Append("</a></label></li>");
            }
            sbhtml.Append("</ul>");
        }
        SetfolderValue(strType, sbhtml.ToString());
    }

    private void SetfolderValue(string moduleName, string value)
    {
        switch (moduleName)
        {
            case "news":
                if ("" != value)
                    this.newsinfolist.InnerHtml = value;
                else
                    this.newsinfolist.Visible = false;
                break;
        }
    }
    #endregion

    #region 生成网店模板
    void createshoplistInnerHTML(DataView dv)
    {
        //System.Text.StringBuilder sbhtml = new System.Text.StringBuilder();
        //string templateName = "";
        //sbhtml.Append("<ul>");
        //for (int i = 0; i < dv.Count; i++)
        //{
        //    templateName = dv[i]["filename"].ToString();

        //    XYECOM.Template.ShopAboutInfo shopAbout = XYECOM.Template.ShopAbout.GetItem(XYRequest.GetString("path"), dv[i]["filename"].ToString());
        //    sbhtml.Append("<li><a href=\"PublicTemplateTree.aspx?temppath=");
        //    sbhtml.Append(XYRequest.GetString("path"));
        //    sbhtml.Append("&ppath=shop&path=");
        //    sbhtml.Append(dv[i]["filename"].ToString() );
        //    sbhtml.Append("\">");
        //    if (shopAbout != null)
        //    {
        //        sbhtml.Append(" <span>模板名称：");
        //        sbhtml.Append(shopAbout.Name);
        //        sbhtml.Append("<br/>模板中文名：");
        //        sbhtml.Append(shopAbout.CName);
        //        sbhtml.Append("<br/>模板性质：");
        //        sbhtml.Append(shopAbout.Access == XYECOM.Template.ShopTemplateAccess.Private?"独享":"公共");
        //        sbhtml.Append("<br/>模板作者：");
        //        sbhtml.Append(shopAbout.Author);
        //        sbhtml.Append("<br/>模板创建日期：");
        //        sbhtml.Append(shopAbout.CreateDate);
        //        sbhtml.Append("<br/>模板版本：");
        //        sbhtml.Append(shopAbout.Ver);
        //        sbhtml.Append("<br/>模板版权：");
        //        sbhtml.Append(shopAbout.Copyright);
        //        sbhtml.Append("</span>");

        //        templateName = shopAbout.CName;
        //    }
        //    sbhtml.Append("<img src=\"");
        //    sbhtml.Append(dv[i]["img"].ToString());
        //    sbhtml.Append("\">");
        //    sbhtml.Append("</a>");
        //    sbhtml.Append("<div>");
        //    sbhtml.Append(templateName);
        //    sbhtml.Append("[<a href='javascript:ShopTemplatesSetting(\"" + XYRequest.GetString("path") + "\",\"" + dv[i]["filename"] + "\");'>设置</a>]</div>");
        //    sbhtml.Append("</li>");  

        //}
        //sbhtml.Append("</ul>");

        //this.shoplist.InnerHtml = sbhtml.ToString();

    }
    #endregion
}
