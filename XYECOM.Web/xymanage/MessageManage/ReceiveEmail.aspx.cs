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

public partial class xymanage_basic_ReceiveEmail : XYECOM.Web.BasePage.ManagePage
{
    #region 页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("sysmessage");

        if (!Page.IsPostBack)
        {

            SetValueByquery(Page1, "page");
            SetValueByquery(txtTitle, "M_Title");
            SetValueByquery(ddlType,"Type");
            SetValueByquery(U_Name, "U_Name");
            SetValueByquery(txtBeginDate, "begindate");
            SetValueByquery(txtEndDate, "enddate");
            SetValueByquery(txtPageSize, "pagesize");
            SetValueByquery(txtdays, "isdays");
            SetValueByquery(cbdays, "cbday", "1");
            
            this.lnkDel.Attributes.Add("onclick", "javascript:return del();");
        }
    }
    #endregion 

    #region 数据绑定
    protected override void BindData()
    {
        if (this.txtPageSize.Text != "")
        {
            this.Page1.PageSize = XYECOM.Core.MyConvert.GetInt32(this.txtPageSize.Text);
        }
        else
        {
            this.Page1.PageSize = 20;
        }

        backURL=XYECOM.Core.Utils.JSEscape(
            "ReceiveEmail.aspx?"+
            "page=" + Page1.CurPage.ToString() +
            "&M_Title=" + txtTitle.Text.Trim() +
            "&Type=" + ddlType.SelectedValue +
            "&begindate=" + txtBeginDate.Text.Trim() +
            "&enddate=" + txtEndDate.Text.Trim() +
            "&U_Name=" + U_Name.Text.Trim() +
            "&pagesize=" + txtPageSize.Text +
            "&cbday=" + cbdays.Checked.ToString().ToLower() +
            "&isdays=" + txtdays.Text + "");

        string strWhere = " M_SenderType='administrator'";

        this.lblMessage.Text = "";

        int totalRecord = 0;

        if (this.ddlType.SelectedValue != "0")
        {
            switch(this.ddlType.SelectedValue)
            {
                case "1":
                    strWhere += " and M_Title like '%[求助]%'";
                    break;
                case "2":
                    strWhere += " and M_Title like '%[建议]%'";                   
                    break;
                case "3":
                    strWhere += " and M_Title like '%[投诉]%'";   
                    break;
                case "4":
                    strWhere += " and M_Title like '%[表扬]%'";   
                    break;
                case "5":
                    strWhere += " and M_Title like '%[业务联系]%'";   
                    break;
                case "6":
                    strWhere += " and M_Title like '%[升级会员]%'";   
                    break;
            }

        }
         
        if (this.ddlshifouchakan.SelectedValue != "")
            strWhere += " and M_HasReply = '" + this.ddlshifouchakan.SelectedValue + "'";

        if (this.txtTitle.Text.Trim() != "")
            strWhere += " and M_Title like '%" + this.txtTitle.Text.Trim() + "%' ";

        if (this.U_Name.Text.Trim() != "")
            strWhere += " and U_Name = '" + this.U_Name.Text.Trim() + "'";

        //开始日期
        if (this.txtBeginDate.Text.Trim() != "")
        {
            strWhere += " and  M_Addtime >= '" + this.txtBeginDate.Text.Trim() + "' ";
        }
        //结束日期
        if (this.txtEndDate.Text.Trim() != "")
        {
            strWhere += " and M_Addtime <= '" + this.txtEndDate.Text.Trim() + "' ";
        }


        if (this.txtdays.Text != "" && this.cbdays.Checked)
        {
            strWhere += " and datediff(day,M_Addtime,getdate())<=" + (XYECOM.Core.MyConvert.GetInt32(this.txtdays.Text) - 1) + " and datediff(day,M_Addtime,getdate())>=0 ";
        }


        DataTable dt = XYECOM.Business.Utils.GetPaginationData("XYV_MessageWebRecver", "M_ID", " U_ID,M_ID,M_UserName,M_Addtime,M_PHMa,UI_Mobil,U_Email,U_Name,M_HasReply,M_UserType,M_Title ", "M_ID desc",strWhere, this.Page1.PageSize, this.Page1.CurPage, out totalRecord);

        this.Page1.RecTotal = totalRecord;

        if (dt.Rows.Count > 0)
        {
            this.gvlist.DataSource = dt;
            this.gvlist.DataBind();
        }
        else
        {
            this.lblMessage.Text = "没有相关记录";
            this.gvlist.DataBind();
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
    private void Page1_PageChanged(object sender, EventArgs e)
    {
        BindData();
    }
    #endregion 

    #region 绑定序号
    protected void gvlist_RowDataBound(object sender, GridViewRowEventArgs e)
    {
         //判断是否数据行
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "javascript:__XY_GV_Row_MouseOver(this)");
            e.Row.Attributes.Add("onmouseout", "javascript:__XY_GV_Row_MouseOut(this);");

            if (e.Row.Cells[8].Text.ToLower() == "true")
                e.Row.Cells[8].Text = "已查看";
            else
                e.Row.Cells[8].Text = "未查看";
        }
    }
    #endregion

    #region 删除多条
    protected void lnkDel_Click1(object sender, EventArgs e)
    {
        string ids = "";

        XYECOM.Business.Message m = new XYECOM.Business.Message();
        foreach (GridViewRow row in this.gvlist.Rows)
        {
            if (((CheckBox)(row.FindControl("chkExport"))).Checked == true)
                ids += "," + this.gvlist.DataKeys[row.DataItemIndex].Value.ToString();
        }
        if (ids.IndexOf(",") == 0)
            ids = ids.Substring(1);
        string url = "ReceiveEmail.aspx";
        int rowAffected = m.Deletes(ids);
        if (rowAffected >= 0)
        {
            Alert("删除成功！", url);
        }
        else
        {
            Alert("删除失败！", url);
        }
    }
    #endregion

    protected void btn_select_Click(object sender, EventArgs e)
    {
        this.lblMessage.Text = "";
        BindData();
    }
}
