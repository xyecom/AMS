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
    public partial class LogUserbehavior : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("log");

            if (!Page.IsPostBack)
            {
                this.Page1.PageSize = 50;
                SetValueByquery(Page1, "Page1");
                SetValueByquery(txtname, "txtname");
                SetValueByquery(DDLoperate, "DDLoperate");
                SetValueByquery(bgdate, "bgdate");
                SetValueByquery(egdate, "egdate");

                gvDataBind();
            }
        }

        #region 绑定数据
        private void gvDataBind()
        {
            //设置编辑或查看评论后要返回当前页面的状态
            backURL = XYECOM.Core.Utils.JSEscape(
            "LogUserbehavior.aspx?Page1=" + Page1.CurPage.ToString() +
            "&txtname=" + txtname.Text.Trim() +
            "&DDLoperate=" + DDLoperate.SelectedValue +
            "&bgdate=" + bgdate.Value +
            "&egdate=" + egdate.Value
            );

            string strOrder = " order by AccountId desc";
            this.lblMessage.Text = "";
            string strTableName = "XY_AccountDetails";
            string strWhere = " where 1=1";
            string begindate = this.bgdate.Value;
            string enddate = this.egdate.Value;
            string Operate = this.DDLoperate.SelectedValue;

            if (Operate == "-1" || Operate == "")
            {
                strWhere += " and (Operate=" + (int)XYECOM.Model.AccountOperate.ContractMargin;
                strWhere += " or Operate=" + (int)XYECOM.Model.AccountOperate.InputMoney;
                strWhere += " or Operate=" + (int)XYECOM.Model.AccountOperate.PayContractMargin;
                strWhere += " or Operate=" + (int)XYECOM.Model.AccountOperate.PayOrders;
                strWhere += " or Operate=" + (int)XYECOM.Model.AccountOperate.PaySupMargin;
                strWhere += ")";
            }
            else
            {
                strWhere += " and Operate=" + XYECOM.Core.MyConvert.GetInt32(Operate);
            }

            if (begindate != "")
            {
                strWhere += " and (OperateDate > '" + begindate + "') ";
            }

            if (enddate != "")
            {
                strWhere += " and (OperateDate < '" + XYECOM.Core.MyConvert.GetDateTime(enddate).AddDays(1) + "') ";
            }
            
            if (this.txtname.Text != "")
            {
                UserReg userRegBLL = new UserReg();
                XYECOM.Model.UserRegInfo userRegInfo = userRegBLL.GetItem(this.txtname.Text.Trim());

                strOrder = "order by OperateDate desc";
                if (userRegInfo != null)
                {
                    strWhere += " and AccountId=" + userRegInfo.AccountId;
                }
                else
                {
                    strWhere += " and AccountId=0";
                }
            }
            this.Page1.RecTotal = Function.GetRows(strTableName, "ID", strWhere);
            DataTable dt = Function.GetPages(this.Page1.PageSize, this.Page1.CurPage, strWhere, strOrder, strTableName, " * ", "ID");
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
        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            gvDataBind();
        }
        #endregion

        public string GetUserName(string AccountId)
        {
            UserReg userRegBLL = new UserReg();
            XYECOM.Model.UserRegInfo userRegInfo = userRegBLL.GetItem(AccountId);
            if (userRegInfo == null)
                return "未知";
            return userRegInfo.LoginName + "/ " + userRegInfo.Email;
        }
    }
}