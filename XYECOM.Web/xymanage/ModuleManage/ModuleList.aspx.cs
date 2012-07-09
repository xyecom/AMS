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
using System.Collections.Generic;
public partial class xymanage_ModuleManage_ModuleList : XYECOM.Web.BasePage.ManagePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("module");

        if (!IsPostBack)
        {
            ListDataBind();
        }
    }

    #region 生成数据源
    private void ListDataBind()
    {
        this.lblMessage.Text = "";

        this.gvList.DataSource = moduleConfig.GetDataTable;
        this.gvList.DataBind();
    }
    #endregion

    #region 数据绑定
    protected void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "javascript:__XY_GV_Row_MouseOver(this)");
            e.Row.Attributes.Add("onmouseout", "javascript:__XY_GV_Row_MouseOut(this);");

            if (e.Row.Cells[3].Text == "")
                e.Row.Cells[3].Text = "基本模块";

            string ename = gvList.DataKeys[e.Row.RowIndex]["EName"].ToString();

            if (ename == "offer" || ename == "venture" || ename == "investment" || ename == "service")
            {
                e.Row.Cells[9].Enabled = false;
                e.Row.Cells[9].Text="--";
            }

            if (gvList.DataKeys[e.Row.RowIndex]["PEName"].ToString() == "")
            {               
                HyperLink hl = new HyperLink();
                hl.Text = "创建子模块";
                hl.NavigateUrl = "ModuleAdd.aspx?ename=" + gvList.DataKeys[e.Row.RowIndex]["EName"].ToString() + "&m_name=" + e.Row.Cells[1].Text;

                e.Row.Cells[5].Controls.Add(hl);

                e.Row.Cells[6].Text = "  --  ";
            }
            else
            {
                e.Row.Cells[5].Text = "  --  ";
                HyperLink hl = new HyperLink();
                hl.Text = "模板管理";
                hl.NavigateUrl = "../TemplatesManage/PublicTemplateTree.aspx?ename=" + gvList.DataKeys[e.Row.RowIndex]["EName"].ToString();

                e.Row.Cells[6].Controls.Add(hl);
            }
        }
    }
    #endregion

    #region 删除
    protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "del") 
        {

            string ename = this.gvList.DataKeys[Convert.ToInt32(e.CommandArgument)]["EName"].ToString();

            //String pename = this.gvList.DataKeys[Convert.ToInt32(e.CommandArgument)]["PEName"].ToString();

            List<XYECOM.Configuration.ModuleInfo> items = moduleConfig.ModuleItems;
            for (int i = 0; i < moduleConfig.ModuleItems.Count;i++ )
            {
                if (!items[i].PEName.Equals("") && items[i].PEName.Equals(ename))
                {
                    Alert("该模块下还有子模块！请先删除子模块！");
                    return;
                }
            }

            if (XYECOM.Business.XYClass.IsHasSubClass(ename, 0))
            {
                Alert("模块下已存在分类信息，不能删除！");
                return;
            }



            //从XML文档中删除
            if (!moduleConfig.Delete(ename))
            {
                Alert("模块信息删除失败！请检查/Config/目录读写权限！");
                return;
            }

            string message = "";

            //模板不删除，保留
            //string path = Server.MapPath("../../templates/" + XYECOM.Configuration.Template.Instance.Path + "/");
            //if (Directory.Exists(path + ename))
            //{
            //    Directory.Delete(path + ename, true);
            //}

            //删除生成的文件
            string path = Server.MapPath("../../aspx/" + XYECOM.Configuration.Template.Instance.Path + "/");
            if (Directory.Exists(path + ename))
            {
                try
                {
                    Directory.Delete(path + ename, true);
                }
                catch {
                    message += "目标页面删除失败！<br/>请手动删除/aspx/" + XYECOM.Configuration.Template.Instance.Path + "/" + ename + "/目录！<br/>";
                }
            }

            path = Server.MapPath("/" + ename + "/");

            if (Directory.Exists(path))
            {
                try
                {
                    Directory.Delete(path + ename, true);
                }
                catch
                {
                    message += "默认引导目录及页面删除失败！<br/>请手动删除/" + ename + "/目录！<br/>";
                }
            }

            if (message.Equals(""))
            {
                Response.Redirect("ModuleList.aspx");
            }
            else 
            {
                Alert(message, "ModuleList.aspx");
            }
        }
    }
    #endregion

    protected void btnState_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)sender;

        string ename = btn.CommandArgument.ToString();

        if ("启用" == btn.Text)
        {
            moduleConfig.GetItem(ename).State = false;
            moduleConfig.Update();
        }
        else
        {
            moduleConfig.GetItem(ename).State = true;
            moduleConfig.Update();
        }

        this.ClientScript.RegisterClientScriptBlock(GetType(), "01", "<script>window.location.href=window.location.href;</script>");
        ListDataBind();
    }
}
