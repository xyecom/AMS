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

public partial class xymanage_UserManage_UserListManger : XYECOM.Web.BasePage.ManagePage
{
    public int A_ID;
    public XYECOM.Business.UserLogin login = new UserLogin();
    protected string loginnum = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("user");
        if (this.txtPageSize.Text != "")
        {
            this.Page1.PageSize = XYECOM.Core.MyConvert.GetInt32(this.txtPageSize.Text);
        }
        else
        {
            this.Page1.PageSize = 20;
        }
        if (!Page.IsPostBack)
        {
            this.btnDelete.Attributes.Add("onclick", "javascript:return del();");

            SetValueByquery(Page1, "page");
            SetValueByquery(txtKeyWord, "KeyWord");
            SetValueByquery(txtcompany, "company");
            SetValueByquery(areatypeid, "areatypeid");
            SetValueByquery(txtPageSize, "pagesize");
            SetValueByquery(txtdays, "isdays");
            SetValueByquery(cbdays, "cbday", "1");
        }
    }

    #region 绑定数据
    protected override void BindData()
    {
        backURL = XYECOM.Core.Utils.JSEscape("UserListManger.aspx?page=" + Page1.CurPage.ToString() +
            "&KeyWord=" + txtKeyWord.Text.Trim() +
            "&company=" + txtcompany.Text.Trim() +
            "&areatypeid=" + areatypeid.Value.Trim() +
            "&pagesize=" + txtPageSize.Text +
            "&isdays=" + txtdays.Text +
            "&cbday=" + cbdays.Checked.ToString().ToLower()
            );

        this.lblMessage.Text = "";

        string strWhere = "1=1 ";

        if (XYECOM.Core.XYRequest.GetQueryString("username") != "")
        {
            strWhere += " and U_Name like '" + XYECOM.Core.XYRequest.GetQueryString("username") + "' ";
        }
        if (this.txtKeyWord.Text != "")
        {
            strWhere += " and U_Name like '%" + this.txtKeyWord.Text + "%'";
        }
        if (this.txtcompany.Text != "")
        {
            strWhere += " and UI_Name like '%" + this.txtcompany.Text + "%'";
        }

        if (!this.areatypeid.Value.Equals(""))
        {
            strWhere += " and Area_ID=" + this.areatypeid.Value;
        }

        string orderField = "u_id";

        if (this.txtdays.Text != "" && this.cbdays.Checked)
        {
            strWhere += " and datediff(day,U_RegDate,getdate())<=" + (XYECOM.Core.MyConvert.GetInt32(this.txtdays.Text) - 1) + " and datediff(day,U_RegDate,getdate())>=0 ";
        }

        int totalRecord = 0;
        DataTable dt = XYECOM.Business.Utils.GetPaginationData("XYV_UserInfo", "U_ID", "U_ID,UI_Name,U_Name,U_RegDate,U_Email,UserType", orderField + " desc", strWhere, this.Page1.PageSize, this.Page1.CurPage, out totalRecord);

        this.Page1.RecTotal = totalRecord;

        if (dt.Rows.Count > 0)
        {
            this.gvlist.DataSource = dt;
            this.gvlist.DataBind();
        }
        else
        {
            this.lblMessage.Text = "没有相关信息记录";
            this.gvlist.DataBind();
        }
    }
    #endregion

    #region 分页相关代码
    override protected void OnInit(EventArgs e)
    {
        this.Load += new System.EventHandler(this.Page_Load);
        this.Page1.PageChanged += new xymanage_UserControl_page.EventHandler(Page1_PageChanged);
        base.OnInit(e);
    }

    private void Page1_PageChanged(object sender, System.EventArgs e)
    {
        this.BindData();
    }
    #endregion

    #region 绑定数据
    protected void gvlist_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "javascript:__XY_GV_Row_MouseOver(this)");
            e.Row.Attributes.Add("onmouseout", "javascript:__XY_GV_Row_MouseOut(this);");

            if (e.Row.Cells[2].Text.Length > 30)
            {
                e.Row.Cells[2].Text = XYECOM.Core.Utils.IsLength(30, e.Row.Cells[2].Text);
            }
        }
    }
    #endregion

    #region 删除操作
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        XYECOM.Business.Log l = new XYECOM.Business.Log();
        XYECOM.Model.LogInfo el = new XYECOM.Model.LogInfo();
        XYECOM.Business.UserReg ur = new XYECOM.Business.UserReg();

        string ids = "";

        foreach (GridViewRow GR in this.gvlist.Rows)
        {
            if (((CheckBox)(GR.FindControl("chkExport"))).Checked == true)
            {
                ids += "," + this.gvlist.DataKeys[GR.DataItemIndex].Value.ToString();
            }
        }

        if (ids.IndexOf(",") == 0)
        {
            ids = ids.Substring(1);
            int i = 0;
            i = ur.Delete(ids);
            if (i >= 0)
            {
                el.L_Title = "用户管理";
                el.L_Content = "删除用户信息成功";
                el.L_MF = "用户管理";
                el.UM_ID = AdminId;
                l.Insert(el);
                BindData();
            }
            else
            {
                el.L_Title = "用户管理";
                el.L_Content = "删除用户信息失败";
                el.L_MF = "用户管理";
                el.UM_ID = AdminId;
                l.Insert(el);
                Alert("删除失败！");
            }
        }
    }
    #endregion

    protected string SetUrl(object Flag, object Uid)
    {
        return "UserInfo.aspx?U_ID=" + Uid.ToString();
    }

    #region 搜索
    protected void Button2_Click(object sender, EventArgs e)
    {
        BindData();
    }
    #endregion

    protected string GetUserTypeName(object usertype)
    {
        int iType = XYECOM.Core.MyConvert.GetInt32(usertype.ToString());

        XYECOM.Model.UserType utype = (XYECOM.Model.UserType)iType;

        string result = "";
        switch (utype)
        {
            case XYECOM.Model.UserType.CreditorEnterprise:
                result = "债权人 企业";
                break;
            case XYECOM.Model.UserType.CreditorIndividual:
                result = "债权人 个人";
                break;
            case XYECOM.Model.UserType.Layer:
                result = "服务商 律师";
                break;
            case XYECOM.Model.UserType.NotLayer:
                result = "服务商 非律师";
                break;
            default:
                result = "其他";
                break;
        }
        return result;
    }
    protected string GetSubUserUrl(object userId, object usertype)
    {
        string result = "";
        int iType = XYECOM.Core.MyConvert.GetInt32(usertype.ToString());

        XYECOM.Model.UserType utype = (XYECOM.Model.UserType)iType;
        switch (utype)
        {
            case XYECOM.Model.UserType.CreditorEnterprise:
            case XYECOM.Model.UserType.CreditorIndividual:
                result = "SubUserList.aspx?userid=" + userId;
                break;
            case XYECOM.Model.UserType.Layer:
            case XYECOM.Model.UserType.NotLayer:
            default:
                result = "#";
                break;
        }
        return result;
    }
}
