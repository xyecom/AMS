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

namespace XYECOM.Web.xymanage.Ranking
{
    public partial class LogList : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("rank");

            if (!IsPostBack)
            {
                SetValueByquery(Page1, "page");
                SetValueByquery(txtkey, "keyword");
                SetValueByquery(txtBeginTimeStart, "begintimestart");
                SetValueByquery(txtBeginTimeEnd, "begintimeend");
                SetValueByquery(txtEndTimeStart, "endtimestart");
                SetValueByquery(txtEndTimeEnd, "endtimeend");
                SetValueByquery(txtUserIdOrName, "uname");

                Page1.CurPage = XYECOM.Core.XYRequest.GetQueryInt("page", 1);
            }

            this.btnDelete.Attributes.Add("onclick", "javascript:return del();");
        }

        protected override void BindData()
        {
            //设置编辑或查看后要返回当前页面的状态
            backURL = XYECOM.Core.Utils.JSEscape("../Ranking/Loglist.aspx?keyword=" + txtkey.Text.Trim() +
                "&begintimestart=" + txtBeginTimeStart.Value.Trim() +
                "&begintimeend=" + txtBeginTimeEnd.Value.Trim() +
                "&endtimestart=" + txtEndTimeStart.Value.Trim() +
                "&endtimeend=" + txtEndTimeEnd.Value.Trim() +
                "&uname=" + txtUserIdOrName.Text.Trim()) +
                "&page=" + Page1.CurPage.ToString();

            string strwhere = "1=1";
            //标题
            if (this.txtkey.Text.Trim() != "")
            {
                strwhere += " and  keyword like '%" + this.txtkey.Text.Trim() + "%' ";
            }
            //开始日期(开始)
            if (txtBeginTimeStart.Value.Trim() != "")
            {
                strwhere += " and  begintime >= '" + txtBeginTimeStart.Value.Trim() + "' ";
            }
            //开始日期(结束)
            if (txtBeginTimeEnd.Value.Trim() != "")
            {
                strwhere += " and  begintime <= '" + txtBeginTimeEnd.Value.Trim() + "' ";
            }

            //结束日期(开始)
            if (txtEndTimeStart.Value.Trim() != "")
            {
                strwhere += " and endtime >= '" + txtEndTimeStart.Value.Trim() + "' ";
            }

            //结束日期(开始)
            if (txtEndTimeEnd.Value.Trim() != "")
            {
                strwhere += " and endtime <= '" + txtEndTimeEnd.Value.Trim() + "' ";
            }

            //账号或企业名称
            if (txtUserIdOrName.Text.Trim() != "")
            {
                strwhere += " and (u_name like '%" + txtUserIdOrName.Text.Trim() + "%' or ui_name like '%" + txtUserIdOrName.Text.Trim() + "%')";
            }

            int totalRecord = 0;

            DataTable dt = XYECOM.Business.Utils.GetPaginationData("XYV_RankingLog", "LogId", "LogId,keyword,UI_Name,beginTime,endtime,RealEndTime,Rank,userID,KeyId,Amount", "LogId desc", strwhere, Page1.PageSize, this.Page1.CurPage, out totalRecord);

            this.Page1.RecTotal = totalRecord;

            if (dt.Rows.Count > 0)
            {
                this.gvList.DataSource = dt;
                this.gvList.DataBind();
            }
            else
            {
                this.gvList.DataBind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            this.txtkey.Text = "";
            this.txtUserIdOrName.Text = "";
            this.txtBeginTimeStart.Value = "";
            this.txtBeginTimeEnd.Value = "";
            this.txtEndTimeStart.Value = "";
            this.txtEndTimeEnd.Value = "";

            BindData();
        }

        #region 定义分页事件
        protected override void OnInit(EventArgs e)
        {
            this.Load += new System.EventHandler(this.Page_Load);
            this.Page1.PageChanged += new xymanage_UserControl_page.EventHandler(Page1_PageChanged);
            base.OnInit(e);
        }

        private void Page1_PageChanged(object sender, System.EventArgs e)
        {
            BindData();
        }
        #endregion

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string ids = "";
            foreach (GridViewRow GR in this.gvList.Rows)
            {
                if (((CheckBox)(GR.FindControl("chkExport"))).Checked == true)
                {
                    ids += "," + gvList.DataKeys[GR.DataItemIndex].Value.ToString();
                }
            }

            if (ids.IndexOf(",") == 0)
            {
                ids = ids.Substring(1);

                int i = new Business.RankingLog().Delete(ids);

                if (i >= 0)
                    BindData();
                else
                    Alert("删除失败！");
            }
        }
    }
}
