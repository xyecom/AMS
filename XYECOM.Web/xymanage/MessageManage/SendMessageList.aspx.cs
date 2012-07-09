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
using XYECOM.Core;
using XYECOM.Business;

public partial class xymanage_MessageManage_SendMessageList :XYECOM.Web.BasePage.ManagePage
{
    #region 初始化页面
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("sysmessage");

        if (!IsPostBack)
        {
            this.Page1.PageSize = 20;
            this.gvlistDataBind();
            this.Button2.Attributes.Add("onclick", "javascript:return del();");
        }
    }
    #endregion

    #region 绑定数据
    private void gvlistDataBind()
    {
        string strWhere = "";
        string strTableName = " XYV_MessageByAdmin ";
        string strOrder = " order by M_AddTime desc ";
        string strColumuName = " M_ID,M_AddTime,Title,M_HasReply ,M_Title";

        this.Page1.RecTotal = Function.GetRows(strTableName, "M_ID", strWhere);

        DataTable dt = Function.GetPages(this.Page1.PageSize, this.Page1.CurPage, strWhere, strOrder, strTableName, strColumuName, "M_ID");

        if (dt.Rows.Count > 0)
        {
            this.gvlist.DataSource = dt;
            this.gvlist.DataBind();
        }
        else
        {
            this.lblMessage.Text = "没有相关数据";
            this.gvlist.DataBind();
        }
    }
    #endregion

    #region 数据绑定
    protected void gvlist_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "javascript:__XY_GV_Row_MouseOver(this)");
            e.Row.Attributes.Add("onmouseout", "javascript:__XY_GV_Row_MouseOut(this);");

            if (e.Row.Cells[4].Text.ToLower() == "true")
                e.Row.Cells[4].Text = "已查看";
            else
                e.Row.Cells[4].Text = "未查看";

            e.Row.Cells[2].Text = XYECOM.Core.Utils.IsLength(40, e.Row.Cells[2].Text);
        }

    }
    #endregion

    #region Web 窗体设计器生成的代码
    override protected void OnInit(EventArgs e)
    {
        this.Load += new System.EventHandler(this.Page_Load);
        this.Page1.PageChanged += new xymanage_UserControl_page.EventHandler(Page1_PageChanged);
        base.OnInit(e);
    }
    #endregion

    #region 翻页
    void Page1_PageChanged(object sender, EventArgs e)
    {
        this.gvlistDataBind();
    }
    #endregion
 
    protected void Button2_Click(object sender, EventArgs e)
    {
        string ids = "";

        XYECOM.Business.Message m = new XYECOM.Business.Message();

        foreach (GridViewRow GR in this.gvlist.Rows)
        {
            if (((CheckBox)(GR.FindControl("chkExport"))).Checked ==true)
            {
                ids += "," + this.gvlist.DataKeys[GR.DataItemIndex].Value.ToString();
            }
        }
        if (ids.IndexOf(",") == 0)
            ids = ids.Substring(1);

        int rowAffected = m.Deletes(ids);
        if (rowAffected >= 0)
        {
            Alert("删除成功！", "SendMessageList.aspx");
        }
        else
        {
            Alert("删除失败！", "SendMessageList.aspx");
        }
    }
}
