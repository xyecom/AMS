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
using XYECOM.Business;
using XYECOM.Core;

public partial class xymanage_LabelManage_List : XYECOM.Web.BasePage.ManagePage
{
    #region 页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("label");       

        if (!IsPostBack)
        {
            if (XYECOM.Core.XYRequest.GetQueryInt("page", 0) > 0)
                this.Page1.CurPage = XYECOM.Core.XYRequest.GetQueryInt("page", 0);

            this.TextBox1.Text = XYECOM.Core.XYRequest.GetQueryString("keyword");

            if (XYECOM.Core.XYRequest.GetQueryString("state") != "")
                this.ddlclassID.SelectedValue = XYECOM.Core.XYRequest.GetQueryString("state");

            this.Page1.PageSize = 20;

            this.ddlclassID.DataSource = new XYECOM.Business.LabelType().GetDataTable(" where LT_ParentID=0 ");
            this.ddlclassID.DataTextField = "LT_Name";
            this.ddlclassID.DataValueField = "LT_ID";
            this.ddlclassID.DataBind();
            if (XYRequest.GetQueryString("LT_ID") != "")
                this.ddlclassID.Text = XYRequest.GetQueryString("LT_ID");
            this.ddlclassID.Items.Insert(0, new ListItem("所有的", ""));
            this.btndelete.Attributes.Add("onclick", "javascript:return del();");
        }
    }
    #endregion

    #region 生成数据源
    protected override void BindData()
    {
        this.ddlclassID.Attributes["onchange"] = "'' == this.value ? location='?' : location='?LT_ID=' + this.value";
        //设置编辑或查看后要返回当前页面的状态
        backURL = XYECOM.Core.Utils.JSEscape("page=" + Page1.CurPage.ToString() + "&State=" + ddlclassID.SelectedValue + "&KeyWord=" + TextBox1.Text.Trim());

        string querytext = this.TextBox1.Text;
        this.lblMessage.Text = "";
        string strWhere = " (1=1) ";
        string strTableName = "  b_LabelType inner join b_Label ON b_LabelType.LT_ID = b_Label.LT_ID ";
        string strColumuName = " L_ID,L_Name,L_CName,L_Content,LT_Name ";
        string strOrderBy = " L_ID DESC ";
        string typeId = XYRequest.GetQueryString("LT_ID");
        if (!string.IsNullOrEmpty(typeId))
        {
            strWhere += " and (b_LabelType.LT_ID=" + typeId + ")";
        }

        if (!string.IsNullOrEmpty(querytext))
        {
            strWhere += " and (b_Label.L_Name like '%" + querytext + "%')";
        }

        int total = 0;

        DataTable dt = XYECOM.Business.Utils.GetPaginationData(strTableName, "L_ID", strColumuName, strOrderBy, strWhere, this.Page1.PageSize, this.Page1.CurPage, out total);
        this.Page1.RecTotal = total;
        if (dt.Rows.Count > 0)
        {
            gvList.DataSource = dt;
            gvList.DataBind();
        }
        else
        {
            this.lblMessage.Text = "没有标签信息";
            gvList.DataBind();
        }
    }
    #endregion

    #region 数据绑定
    protected void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "javascript:__XY_GV_Row_MouseOver(this)");
            e.Row.Attributes.Add("onmouseout", "javascript:__XY_GV_Row_MouseOut(this);");

            e.Row.Cells[2].Text = "{" + Function.LabelPrefix + e.Row.Cells[2].Text + "}";
        }
    }
    #endregion

    #region 翻页
    protected void Page1_PageChanged(object sender, EventArgs e)
    {
        BindData();
    }
    #endregion

    #region 删除多条
    protected void btndelete_Click(object sender, EventArgs e)
    {
        string ids = "";
        XYECOM.Business.Label le = new XYECOM.Business.Label();
        foreach (GridViewRow row in this.gvList.Rows)
        {
            if (((CheckBox)(row.FindControl("chkExport"))).Checked == true)
                ids += "," + this.gvList.DataKeys[row.DataItemIndex].Value.ToString();
        }
        if (ids.IndexOf(",") == 0)
            ids = ids.Substring(1);
        int err = le.Delete(ids);
        if (err <= 0)
        {
            Alert("标签删除失败！", "List.aspx");
        }        
    }
    #endregion

    #region 查询按钮
    protected void Button1_Click(object sender, EventArgs e)
    {
        BindData();
    }
    #endregion

    protected string GetLabelOfMemberInfo(object labelId)
    {
        return string.Empty;
    }
}
