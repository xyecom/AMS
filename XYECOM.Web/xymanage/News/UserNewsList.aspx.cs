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

namespace XYECOM.Web.xymanage.News
{
    public partial class UserNewsList : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("usernews");

            if (this.txtPageSize.Text != "")
            {
                this.page1.PageSize = XYECOM.Core.MyConvert.GetInt32(this.txtPageSize.Text);
            }
            else
            {
                this.page1.PageSize = 20;
            }
            if (!IsPostBack)
            {
                #region 设置初始值

                if (XYECOM.Core.XYRequest.GetQueryString("IsAuditing") != "")
                {
                    this.ddlState.SelectedValue = XYECOM.Core.XYRequest.GetQueryString("IsAuditing");
                }

                SetValueByquery(page1, "page1");
                SetValueByquery(txtTitle, "Title");
                SetValueByquery(txtUserName, "UserName");
                SetValueByquery(bgdate, "bgdate");
                SetValueByquery(egdate, "egdate");
                SetValueByquery(ddlState, "IsAuditing");
                SetValueByquery(txtPageSize, "pagesize");
                SetValueByquery(txtdays, "isdays");
                SetValueByquery(cbdays, "cbday", "1");

                int page = XYECOM.Core.XYRequest.GetQueryInt("Page1", 0);

                if (page > 0) page1.CurPage = page;

                #endregion

                this.lnkDel.Attributes.Add("onclick", "javascript:return del();");
            }
        }


        #region 数据绑定
        /// <summary>
        /// 定义数据绑定事件
        /// </summary>
        protected override void BindData()
        {
            //设置编辑或查看评论后要返回当前页面的状态
            backURL = XYECOM.Core.Utils.JSEscape(
            "UserNewsList.aspx?page1=" + page1.CurPage.ToString() +
            "&Title=" + txtTitle.Text.Trim() +
            "&UserName=" + txtUserName.Text.Trim() +
            "&IsAuditing=" + this.ddlState.SelectedValue +
            "&pagesize=" + txtPageSize.Text +
            "&isdays=" + txtdays.Text +
            "&cbday=" + cbdays.Checked.ToString().ToLower() +
            "&bgdate=" + bgdate.Value +
            "&egdate=" + egdate.Value
            );

            string strWhere = " 1=1";

            if (this.txtTitle.Text != "")
                strWhere += " and N_Title like '%" + this.txtTitle.Text + "%'";

            if (txtUserName.Text.Trim() != "")
            {
                strWhere += " and (u_name like '%" + txtUserName.Text.Trim() + "%' or ui_name like '%" + txtUserName.Text.Trim() + "%')";
            }

            if (this.txtdays.Text != "" && this.cbdays.Checked)
                strWhere += " and datediff(day,N_AddTime,getdate())<=" + (XYECOM.Core.MyConvert.GetInt32(this.txtdays.Text) - 1) + " and datediff(day,N_AddTime,getdate())>=0 ";

            if (this.ddlState.SelectedValue != "-1")
                strWhere += " and " + this.ddlState.SelectedValue;

            string begindate = this.bgdate.Value;
            string enddate = this.egdate.Value;
            try
            {
                DateTime begdate = Convert.ToDateTime(begindate);
            }
            catch (Exception)
            {
                begindate = "";
            }
            try
            {
                DateTime endate = Convert.ToDateTime(enddate);
            }
            catch (Exception)
            {
                enddate = "";
            }
            //开始日期
            if (begindate != "")
            {
                strWhere += " and (N_AddTime >= '" + begindate + "')";
            }
            //结束日期
            if (enddate != "")
            {
                strWhere += " and (N_AddTime <= '" + enddate + "')";
            }

            int totalRecord = 0;

            DataTable usernews = XYECOM.Business.Utils.GetPaginationData("XYV_Usernews", "N_ID", "N_ID,N_Title,U_ID,N_addtime,UI_Name,U_Name,AuditingState,State", "N_ID desc", strWhere, XYECOM.Core.MyConvert.GetInt32(this.txtPageSize.Text), this.page1.CurPage, out totalRecord);

            this.page1.RecTotal = totalRecord;

            if (usernews.Rows.Count > 0)
            {
                this.GV1.DataSource = usernews;
                this.GV1.DataBind();
            }
            else
            {
                this.GV1.DataBind();
                this.lblMessage.Text = "没有相关新闻!";
            }
        }
        #endregion



        protected void GV1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "javascript:__XY_GV_Row_MouseOver(this)");
                e.Row.Attributes.Add("onmouseout", "javascript:__XY_GV_Row_MouseOut(this);");

                LinkButton lb = (LinkButton)e.Row.Cells[5].Controls[0];
                if (lb.Text == "1")
                    lb.Text = "通过审核";
                else if (lb.Text == "0" || lb.Text == "")
                    lb.Text = "审核未通过";
            }
        }

        #region 定义过滤字查询事件
        protected void btnFind_Click(object sender, EventArgs e)
        {
            //this.page1.CurPage = 1;
            lblMessage.Text = "";
            this.BindData();
        }
        #endregion


        #region 定义删除新闻事件
        protected void lnkDel_Click(object sender, EventArgs e)
        {
            string id = "";
            XYECOM.Business.UserNews en = new XYECOM.Business.UserNews();
            foreach (GridViewRow row in this.GV1.Rows)
            {
                if (((CheckBox)(row.FindControl("chkExport"))).Checked == true)
                    id += "," + this.GV1.DataKeys[row.DataItemIndex].Value.ToString();
            }

            if (id.IndexOf(",") == 0)
                id = id.Substring(1);

            int rowAffected = en.Delete(id);

            if (rowAffected >= 0)
            {
            }
            else
            {
                Alert("删除失败,可重新操作.");
            }
            BindData();
        }
        #endregion


        #region 定义分页事件
        private void Page1_PageChanged(object sender, System.EventArgs e)
        {
            BindData();
        }
        #endregion


        #region Web窗体设计器生成的代码
        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(this.Page_Load);
            this.page1.PageChanged += new xymanage_UserControl_page.EventHandler(Page1_PageChanged);
            base.OnInit(e);
        }
        #endregion

        #region 审核
        protected void GV1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //对记录信息进行审核操作
            XYECOM.Business.Auditing audBLL = new XYECOM.Business.Auditing();

            //获取该行的行号
            int iRowNo = Convert.ToInt32(e.CommandArgument);
            int N_ID = 0;

            //获取该行的主键
            N_ID = Convert.ToInt32(GV1.DataKeys[iRowNo].Value);

            if (GV1.DataKeys[Convert.ToInt32(e.CommandArgument)]["N_ID"].ToString() != "")
            {
                N_ID = XYECOM.Core.MyConvert.GetInt16(GV1.DataKeys[Convert.ToInt32(e.CommandArgument)]["N_ID"].ToString());
            }
            if (e.CommandName == "shenhe")
            {
                LinkButton LB = (LinkButton)GV1.Rows[iRowNo].Cells[5].Controls[0];

                if (LB.Text == "通过审核")
                {
                    int JJ = audBLL.UpdatesAuditing(N_ID, "U_news", XYECOM.Model.AuditingState.NoPass);
                }
                else if (LB.Text == "审核未通过" || LB.Text == "未审核" || LB.Text.ToString() == "")
                {
                    audBLL.UpdatesAuditing(N_ID, "U_news", XYECOM.Model.AuditingState.Passed);
                }

                BindData();
            }
        }
        #endregion

        public string GetStateName(string State)
        {
            int state = XYECOM.Core.MyConvert.GetInt32(State);
            string str = "";

            switch (state)
            {
                case 1:
                    str = "未推荐,未置顶";
                    break;
                case 2:
                    str = "已推荐,未置顶";
                    break;
                case 3:
                    str = "未推荐,已置顶";
                    break;
                case 6:
                    str = "已推荐,已置顶";
                    break;
            }
            return str;
        }
    }
}
