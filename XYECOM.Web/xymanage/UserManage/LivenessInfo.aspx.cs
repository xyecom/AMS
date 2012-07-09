using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using XYECOM.Business;

namespace XYECOM.Web.xymanage.UserManage
{
    public partial class LivenessInfo : XYECOM.Web.BasePage.ManagePage
    {
        public int A_ID;
        public string begindate = "";
        public string enddate = "";
        public XYECOM.Business.UserLogin login = new UserLogin();
        protected string loginnum = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("user");
        }

        #region 绑定数据
        protected override void BindData()
        {
            this.gvlist.PageSize = this.Page1.PageSize;

            SetValueByquery(Page1, "page");
            SetValueByquery(txtKeyWord, "KeyWord");
            SetValueByquery(ddlState, "State");
            SetValueByquery(bgdate, "bgdate");
            SetValueByquery(egdate, "egdate");

            backURL = XYECOM.Core.Utils.JSEscape("UserListManger.aspx?page=" + Page1.CurPage.ToString() +
                "&KeyWord=" + txtKeyWord.Text.Trim() +
                "&State=" + ddlState.SelectedValue +
                "&bgdate=" + bgdate.Value.Trim() +
                "&egdate=" + egdate.Value.Trim()
                );

            this.lblMessage.Text = "";

            string strWhere = " where (1=1) ";

            if (this.txtKeyWord.Text != "")
            {
                strWhere += " and (U_Name like '%" + this.txtKeyWord.Text + "%')";
            }

            if (this.ddlState.SelectedValue != "")
            {
                strWhere += " and (UserAuditingState = " + this.ddlState.SelectedValue + ")";
            }

            begindate = this.bgdate.Value;
            enddate = this.egdate.Value;
            try
            {
                DateTime begdate = XYECOM.Core.MyConvert.GetDateTime(begindate);
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

            //if (!string.IsNullOrEmpty(begindate) || !string.IsNullOrEmpty(enddate))
            //{
            //    if (string.IsNullOrEmpty(begindate) && !string.IsNullOrEmpty(enddate)) { }
            //    if (!string.IsNullOrEmpty(begindate) && string.IsNullOrEmpty(enddate)) { }
            //    if (!string.IsNullOrEmpty(begindate) && !string.IsNullOrEmpty(enddate)) { }
            //}

            if (begindate != "")
            {
                strWhere += " and (LastLoginDate > '" + begindate + "') ";
            }
            if (enddate != "")
            {
                strWhere += " and (LastLoginDate < '" + XYECOM.Core.MyConvert.GetDateTime(enddate).AddDays(1) + "') ";
            }

            DataTable loginInfo = new XYECOM.Business.UserLogin().GetUserLoginNumsByDate(strWhere);

            int totalRecord = loginInfo.Rows.Count;
            this.Page1.RecTotal = totalRecord;
            if (totalRecord > 0)
            {
                this.gvlist.DataSource = loginInfo;
                this.gvlist.DataBind();
            }
            else
            {
                this.lblMessage.Text = "没有相关信息记录";
                this.gvlist.DataBind();
            }
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
                    e.Row.Cells[2].Text = XYECOM.Core.Utils.IsLength(30, e.Row.Cells[2].Text);

            }
        }
        #endregion


        protected string SetUrl(object Flag, object Uid)
        {
            if (string.IsNullOrEmpty(Flag.ToString()) || string.IsNullOrEmpty(Uid.ToString()))
                return "#";
            if (Flag.ToString() == "False")
                return "IndividualInfo.aspx?U_ID=" + Uid.ToString();
            else
                return "UserInfo.aspx?U_ID=" + Uid.ToString();
        }

        #region 搜索
        protected void Button2_Click(object sender, EventArgs e)
        {
            BindData();
        }
        #endregion

        protected void Page1_PageChanged(object sender, System.EventArgs e)
        {
            this.gvlist.PageIndex = this.Page1.CurPage;

            BindData();
        }

    }
}