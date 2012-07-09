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

public partial class xymanage_Certificate_certificatelist : XYECOM.Web.BasePage.ManagePage
{
    #region  页面加载
    public int A_ID;
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("certificate");

        if (!Page.IsPostBack)
        {
           
        }
    }
    #endregion

    #region 绑定数据
    protected override void BindData()
    {
        if (XYECOM.Core.XYRequest.GetQueryString("key") != "")
            this.TextBox1.Text = XYECOM.Core.XYRequest.GetQueryString("key");
        if (XYECOM.Core.XYRequest.GetQueryString("star") != "")
            this.ddlState.SelectedValue = XYECOM.Core.XYRequest.GetQueryString("star");
        if (XYECOM.Core.XYRequest.GetQueryString("type") != "")
            this.ddlType.SelectedValue = XYECOM.Core.XYRequest.GetQueryString("type");

        if (XYECOM.Core.XYRequest.GetQueryString("bgdata") != "")
        {
            this.bgdate.Value = XYECOM.Core.XYRequest.GetQueryString("bgdata");
        }
        if (XYECOM.Core.XYRequest.GetQueryString("enddata") != "")
        {
            this.egdate.Value = XYECOM.Core.XYRequest.GetQueryString("enddata");
        }
        this.Btndel.Attributes.Add("onclick", "javascript:return del();");
        this.Page1.PageSize = 20; 

        backURL = XYECOM.Core.Utils.JSEscape("../Certificate/certificatelist.aspx?key=" + this.TextBox1.Text + "&star=" + this.ddlState.SelectedValue + "&type=" + this.ddlType.SelectedValue + "&bgdata=" +this.bgdate.Value + "&enddata=" + this.egdate.Value );
        string strwhere = " 1=1 ";
        if (this.TextBox1.Text != "")
        {
            strwhere += " and U_Name like '%" + this.TextBox1.Text.Trim() + "%' ";
        }

        string begindate = this.bgdate.Value;
        string enddate = this.egdate.Value;
        try
        {
            DateTime bgdate = Convert.ToDateTime(begindate);
        }
        catch (Exception)
        {
            begindate = "";
        }
        try
        {
            DateTime eddate = Convert.ToDateTime(enddate);
        }
        catch (Exception)
        {
            enddate = "";
        }

        if (begindate != "" && enddate != "")
        {
            strwhere += " and (CE_Addtime between '" + begindate + "' and '" + enddate + "')";
        }

        string aduStr = this.ddlState.SelectedValue.Trim();
        if (aduStr != "")
        {
            if (aduStr.Equals("null"))
                strwhere += " and AuditingState  is null";
            else
                strwhere += " and AuditingState = " + this.ddlState.SelectedValue;
        }

        if(this.ddlType.SelectedValue != "0"){
            strwhere += " and CE_Type = " + this.ddlType.SelectedValue;
        }

        int totalRecord = 0;

        DataTable dt = XYECOM.Business.Utils.GetPaginationData("XYV_Certificate", "CE_ID", "U_Name,CE_ID,U_ID,CE_Name,CE_Type,AuditingState,CE_Addtime", "CE_ID desc", strwhere, this.Page1.PageSize, this.Page1.CurPage, out totalRecord);

        this.Page1.RecTotal = totalRecord;

        if (dt.Rows.Count > 0)
        {
            this.lbmanage.Text = "";
            this.GV1.DataSource = dt;
            this.GV1.DataBind();
        }
        else
        {
            this.lbmanage.Text = "没有相关记录";
            this.GV1.DataBind();
        }
    }
    #endregion

    #region 翻页
    private void Page1_PageChanged(object sender, EventArgs e)
    {
        BindData();
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

    #region 删除操作
    protected void Btndel_Click(object sender, EventArgs e)
    {
        string CE_IDs = "";

        foreach (GridViewRow GR in this.GV1.Rows)
        {
            if (((CheckBox)(GR.FindControl("chkExport"))).Checked == true)
            {
                CE_IDs += "," + GV1.DataKeys[GR.DataItemIndex].Value.ToString();
            }
        }
        if (CE_IDs.IndexOf(",") == 0)
        {
            CE_IDs = CE_IDs.Substring(1);

            
            XYECOM.Business.Certificate bce = new XYECOM.Business.Certificate();
            int i  = bce.Deletes(CE_IDs);
            string url = "certificatelist.aspx";
            if (i >= 0)
            {
                Alert("删除成功！", url);
                BindData();
            }
            else
            {
                Alert("删除失败！", url);
            }
        }
        else
        {
            BindData();
        }
    }
    #endregion

    #region 审核操作
    protected void GV1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int iRowNo = Convert.ToInt32(e.CommandArgument);

        long userId = 0;
        int ceId = 0;

        if (e.CommandName == "shenhe")
        {
            ceId = Convert.ToInt32(GV1.DataKeys[iRowNo].Value);

            LinkButton linkBtn = (LinkButton)GV1.Rows[iRowNo].Cells[6].Controls[0];

            if (GV1.DataKeys[Convert.ToInt32(e.CommandArgument)]["U_ID"].ToString() != "")
            {
                userId = Convert.ToInt64(GV1.DataKeys[Convert.ToInt32(e.CommandArgument)]["U_ID"].ToString());
            }
          
            XYECOM.Business.Auditing audBLL = new Auditing();

            if (linkBtn.Text == "通过审核")
            {
                int t = 0;

                t = audBLL.UpdatesAuditing(ceId, "U_Certificate", XYECOM.Model.AuditingState.NoPass);
                
                if (t >= 0)new XYECOM.Business.UserReg().UpdateUserPerfectPercent(userId);
            }
            else if (linkBtn.Text == "审核未通过" || linkBtn.Text == "未审核")
            {
                int j = 0;

                j = audBLL.UpdatesAuditing(ceId, "U_Certificate", XYECOM.Model.AuditingState.Passed);

                if (j >= 0) new XYECOM.Business.UserReg().UpdateUserPerfectPercent(userId);
            }
        }

        BindData();
    }
    #endregion

    #region 绑定
    protected void GV1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "javascript:__XY_GV_Row_MouseOver(this)");
            e.Row.Attributes.Add("onmouseout", "javascript:__XY_GV_Row_MouseOut(this);");

            LinkButton lb = (LinkButton)e.Row.Cells[6].Controls[0];

            if (lb.Text.Trim() == "1") lb.Text = "通过审核";
            else if (lb.Text.Trim() == "0") lb.Text = "审核未通过";
            else lb.Text = "未审核";

            if (e.Row.Cells[4].Text == "1")
                e.Row.Cells[4].Text = "营业执照";
            else if (e.Row.Cells[4].Text == "3")
                e.Row.Cells[4].Text = "经营许可类";
            else if (e.Row.Cells[4].Text == "2")
                e.Row.Cells[4].Text = "税务登记类";
            else
                e.Row.Cells[4].Text = "其它类";
        }
    }
    #endregion

    #region 搜索
    protected void Button1_Click(object sender, EventArgs e)
    {
        BindData();
    }
    #endregion
}
