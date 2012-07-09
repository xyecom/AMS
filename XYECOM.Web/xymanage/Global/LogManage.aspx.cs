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

namespace XYECOM.Web.xymanage.Global
{
    public partial class LogManage : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("log");

            if (!Page.IsPostBack)
            {
                this.Button1.Attributes.Add("onclick", "javascript:return del();");
                this.Page1.PageSize = 20;

                string url = XYECOM.Core.XYRequest.GetUrl();

                SetValueByquery(Page1, "Page1");
                SetValueByquery(txtname, "txtname");
                SetValueByquery(txtadmin, "txtadmin");
                SetValueByquery(txtmould, "txtmould");
                SetValueByquery(begindate, "begindate");
                SetValueByquery(enddate, "enddate");

                gvDataBind();
            }
        }

        #region 绑定数据
        private void gvDataBind()
        {
            //设置编辑或查看评论后要返回当前页面的状态
            backURL = XYECOM.Core.Utils.JSEscape(
            "LogManage.aspx?Page1=" + Page1.CurPage.ToString() +
            "&txtname=" + txtname.Text.Trim() +
            "&txtadmin=" + txtadmin.Text.Trim() +
            "&txtmould=" + txtmould.Text.Trim() +
            "&begindate=" + begindate.Value +
            "&enddate=" + enddate.Value
            );

            string strWhere = " where 1=1 ";
            string strOrder = "order by L_addtime desc  ";
            this.lblMessage.Text = "";
            string strTableName = "XYV_Log";
            string BegDate = this.begindate.Value;
            string EndDate = this.enddate.Value;

            if (BegDate != "")
            {
                strWhere += " and (L_addtime > '" + BegDate + "') ";
            }

            if (EndDate != "")
            {
                strWhere += " and (L_addtime < '" + XYECOM.Core.MyConvert.GetDateTime(EndDate).AddDays(1) + "') ";
            }

            if (this.txtname.Text != "")
            {
                strWhere += "  and L_Title like '%" + this.txtname.Text + "%'";
            }
            else if (this.txtadmin.Text != "")
            {
                strWhere += "  and UM_Name like '%" + this.txtadmin.Text + "%'";

            }
            else if (this.txtmould.Text != "")
            {
                strWhere += " and L_MF like '%" + this.txtmould.Text + "%'";
            }
            this.Page1.RecTotal = Function.GetRows(strTableName, "L_ID", strWhere);
            DataTable dt = Function.GetPages(this.Page1.PageSize, this.Page1.CurPage, strWhere, strOrder, strTableName, " * ", "L_ID");
            if (dt.Rows.Count > 0)
            {
                this.gvlist.DataSource = dt;
                this.gvlist.DataBind();
            }
            else
            {
                this.lblMessage.Text = "没有相关信息";
                this.gvlist.DataBind();
            }

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
            }
        }
        #endregion

        #region 分页
        private void Page1_PageChanged(object sender, System.EventArgs e)
        {
            gvDataBind();
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

        #region 查询
        protected void Button4_Click(object sender, EventArgs e)
        {
            gvDataBind();
        }
        #endregion

        protected void Button1_Click(object sender, EventArgs e)
        {
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
                XYECOM.Business.Log l = new XYECOM.Business.Log();
                i = l.Delete(ids);
                string url = "LogManage.aspx";
                if (i >= 0)
                {
                    Alert("删除成功！", url);
                    gvDataBind();
                }
                else
                {
                    Alert("删除失败！", url);
                }
            }
        }

        protected void btnDelAll_Click(object sender, EventArgs e)
        {
            int result = new XYECOM.Business.Log().DeleteAll();
            if (result > 0)
                Alert("删除成功！共删除" + result.ToString() + "条记录！");
            else
                Alert("删除失败！");
        }
    }
}
