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

public partial class xymanage_TemplatesManage_PublicTemplateTree : XYECOM.Web.BasePage.ManagePage
{
    public string TName = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("template");

        if (!IsPostBack)
        {
            listinit();
        }
    }

    #region  初始化页面数据
    private void listinit()
    {
        string mName = XYECOM.Core.XYRequest.GetQueryString("ename");
        
        //文件夹名称
        string strpath = "";
        //生成类文件路径
        string createpath = "";
        //文件路径
        string path = Server.MapPath("../../templates/");
        //this.hidpath.Value = XYRequest.GetString("path").Trim(); 
        //模板文件夹路径
        string temppath = "";

        this.hidT_ID.Value = XYECOM.Configuration.Template.Instance.ID.ToString();
        this.hidpath.Value = XYECOM.Configuration.Template.Instance.Path;

        path += XYECOM.Configuration.Template.Instance.Path + "/";

        if (!mName.Equals(""))
        {
            XYECOM.Configuration.ModuleInfo moduleInfo = moduleConfig.GetItem(mName);

            temppath = XYECOM.Configuration.Template.Instance.Path;
            strpath = moduleInfo.EName;
            TName = moduleInfo.CName;

            createpath = moduleInfo.PEName;
            //createpath = m.GetItem(mi.M_PID).M_EName;

            this.hidpathname.Value = moduleInfo.EName;
            this.hidppathname.Value = createpath;

            this.hidurl.Value = "../ModuleManage/ModuleList.aspx";
        }
        else if (XYECOM.Core.XYRequest.GetQueryString("ppath") != "" 
            && XYECOM.Core.XYRequest.GetQueryString("path") != "")
        {
            temppath = XYECOM.Core.XYRequest.GetString("temppath");
            path += XYECOM.Core.XYRequest.GetQueryString("ppath") + "/";
            strpath = XYECOM.Core.XYRequest.GetQueryString("path");

            createpath = XYECOM.Core.XYRequest.GetQueryString("ppath");

            this.hidpathname.Value = XYECOM.Core.XYRequest.GetQueryString("ppath") + "/" + strpath;

            TName = this.hidpathname.Value;

            this.hidppathname.Value = createpath;

            this.hidurl.Value = "TemplatesTree.aspx?path=" + XYECOM.Core.XYRequest.GetString("temppath");
        }
        
        #region 文件
        DirectoryInfo info = new DirectoryInfo(path + strpath);

        DataTable dt = new DataTable("filelist");
        dt.Columns.Add("id", Type.GetType("System.Int32"));
        dt.Columns.Add("filename", Type.GetType("System.String"));
        dt.Columns.Add("extension", Type.GetType("System.String"));
        dt.Columns.Add("parentid", Type.GetType("System.String"));
        dt.Columns.Add("filepath", Type.GetType("System.String"));
        dt.Columns.Add("fileallpath", Type.GetType("System.String"));
        dt.Columns.Add("filedescription", Type.GetType("System.String"));

        int num = 1;

        foreach (FileSystemInfo info2 in info.GetFileSystemInfos())
        {
            if (info2 != null)
            {
                if (info2.Extension.Length > 0 && info2.Extension.Substring(1).ToLower() == "htm")
                {
                    DataRow row = dt.NewRow();
                    row["id"] = num;
                    row["filename"] = info2.Name.Substring(0, info2.Name.LastIndexOf("."));
                    row["extension"] = info2.Extension.ToLower();
                    row["parentid"] = "0";
                    row["filepath"] = path;
                    row["filedescription"] = "";
                    row["fileallpath"] = "../../templates/" + temppath + "/" + XYECOM.Core.XYRequest.GetQueryString("ppath") + "/" + strpath + "/" + row["filename"] + row["extension"];

                    dt.Rows.Add(row);
                    num++;
                   
                }
            }
        }
        
        DataView dv = dt.DefaultView;
        dv.Sort = " filename asc ";

        System.Text.StringBuilder sbhtml = new System.Text.StringBuilder();
        
        sbhtml.Append("<ul>");

        for (int i = 0; i < dv.Count; i++)
        {
            sbhtml.Append("<li><img src=\"../images/temp.GIF\" alt=\"模版\">[<a href=\"javascript:TemplatesEdit('" + dv[i]["fileallpath"].ToString() + "');\">编辑</a>]<input id=\"chkaspx\" name=\"");
            sbhtml.Append(this.hidpathname.Value);
            sbhtml.Append("\" type=\"checkbox\" value=\"" + dv[i]["filename"].ToString() + "\"><label for=\"temp01\">" + dv[i]["filename"].ToString() + "</label></li>");
        }

        sbhtml.Append("</ul>");

        this.defaultlist.InnerHtml = sbhtml.ToString();

        #endregion
    }
    #endregion
}
