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
using XYECOM.Business;
using XYECOM.Core;


public partial class xymanage_TemplatesManage_List : XYECOM.Web.BasePage.ManagePage
{
    public string path;

    #region 页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("template");
    }
    #endregion

    private void InitPage()
    {
        this.path = XYECOM.Core.Utils.GetMapPath(@"..\..\templates\");
        string templateidlist = "0";
        foreach (DataRow row in new XYECOM.Business.Template().GetAllTemplateList(this.path).Select("valid = 1"))
        {
            DirectoryInfo info = new DirectoryInfo(this.path + row["T_Path"].ToString() + "/");
            if (!info.Exists)
            {
                //text = text + row["T_Path"].ToString() + " ,";
                templateidlist = templateidlist + "," + row["T_ID"].ToString();
            }
        }
    }

    #region 绑定数据
    protected override void BindData()
    {
        this.lnkDel.Attributes.Add("onclick", "javascript:return deltemp();");
        InitPage();

        this.gvList.DataSource = new XYECOM.Business.Template().GetAllTemplateList(this.path);
        this.gvList.DataBind();
    }
    #endregion

    #region 删除
    protected void lnkDel_Click(object sender, EventArgs e)
    {
        string templateidlist = XYRequest.GetString("T_ID");
        if (templateidlist != "")
        {
            string text2 = "," + templateidlist + ",";
            if (text2.IndexOf(",1,") >= 0)
            {
                Alert("默认模版不能删除！", "List.aspx");
            }
            else
            {
               XYECOM.Model.TemplateInfo ti = new XYECOM.Business.Template().GetTemplateItem(Convert.ToInt32(templateidlist));

               new XYECOM.Business.Template().DeleteTemplateItem(templateidlist);
               if (ti != null)
               {
                   Alert("从数据库中删除模版文件成功！", "list.aspx");
               }
               else
               {
                   Alert("模版还没有入库！", "list.aspx");
               }
            }
        }
        else
        {
            Alert("您未选中任何选项");
        }
    }
    #endregion

    #region 入库状态
    public string Valid(string valid)
    {
        if (valid == "1")
        {
            return "<div align=center><img src=../images/OK.gif /></div>";
        }

        return "<div align=center><img src=../images/Cancel.gif /></div>";
     }
    #endregion

    #region 启用状态
    public string IsFlag(string flag)
    {
        if (flag.ToLower() == "true")
        {
            return "<div style='display:inline;text-align:center;'><img src='../images/icon-tempuse.gif' /></div>";
        }

        return "<div style='display:inline;text-align:center;'><img src='../images/icon-tempnouse.gif' /></div>";

    }
    #endregion

    protected void btnUse_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)sender;

        int infoid = XYECOM.Core.MyConvert.GetInt32(btn.CommandArgument);

        try
        {
            XYECOM.Configuration.Template.Instance.ID = infoid;
            XYECOM.Configuration.Template.Instance.Path = new XYECOM.Business.Template().GetTemplateItem(infoid).Name.Trim();

            bool result  = XYECOM.Configuration.Template.Instance.Update();

            if (!result)
            {
                Alert("启用模板失败！请检查/config/template.config 文件写权限！");
            }
            else {
                new XYECOM.Business.Template().UpdateFlag(infoid);
            }

            InitPage();
            this.BindData();
        }
        catch
        {
            throw new Exception("请先将模板入库，然后进行启用模板操作！");
        }
    }
}
