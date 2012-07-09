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
    public partial class PageRecordInfo : XYECOM.Web.BasePage.ManagePage
    {
        UserReg userRegBLL = new UserReg();
  
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("Statistics");

            if (!Page.IsPostBack)
            {
                this.Page1.PageSize = 50;

                string[] urlarry = XYECOM.Core.XYRequest.GetUrl().Split('?');
                string url = "/xymanage/Global/PageRecord.aspx?" + urlarry[1].ToString();
                
                ltBackUrl.Text = "<a href='" + url + "'><span>返回上页面</span></a>";

                gvDataBind();
            }
        }

        #region 绑定数据
        private void gvDataBind()
        {
            string strOrder = " order by Date desc";
            this.lblMessage.Text = "";
            string strTableName = "XY_PageRecord";
            string strWhere = " where 1=1";
            string PageFlag = this.DllFlag.SelectedValue;

            string BegDate = this.begindate.Value;
            string EndDate = this.enddate.Value;

            try
            {
                DateTime BDate = Convert.ToDateTime(BegDate);
                BegDate = BDate.ToString("yyyy-MM-dd");
            }
            catch (Exception)
            {
                BegDate = "";
            }

            try
            {
                DateTime EDate = Convert.ToDateTime(EndDate);
                EndDate = EDate.ToString("yyyy-MM-dd");
            }
            catch (Exception)
            {
                EndDate = "";
            }
           
            string GuestFlag = this.guestType.SelectedValue;

            SetValueByquery(Page1, "page");
            SetValueByquery(begindate, "bgdate");
            SetValueByquery(enddate, "egdate");
            SetValueByquery(DllFlag, "pageflag");

            strWhere += " and UserId=" + XYECOM.Core.XYRequest.GetQueryString("UserId");

            if (BegDate != "")
            {
                strWhere += " and (Date > '" + BegDate + "') ";
            }

            if (EndDate != "")
            {
                strWhere += " and (Date < '" + XYECOM.Core.MyConvert.GetDateTime(EndDate).AddDays(1) + "') ";
            }
           
            if (PageFlag != "-1")
            {
                strWhere += " and Flag=" + PageFlag;
            }

            if (GuestFlag == "1")
            {
                strWhere += " and Guest>0";
            }

            if (GuestFlag == "2")
            {
                strWhere += " and Guest=0";
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            gvDataBind();
        }

        protected void btnBlank_Click(object sender, EventArgs e)
        {
            this.DllFlag.SelectedValue = "-1";
            this.begindate.Value = "";
            this.enddate.Value = "";
            this.guestType.SelectedValue = "-1";

            gvDataBind();
        }

        public string GetUserName(string UserId)
        {
            if (UserId == "0")
            {
                return "游客";
            }
            XYECOM.Model.UserRegInfo userRegInfo = userRegBLL.GetItem(XYECOM.Core.MyConvert.GetInt32(UserId));
            if (userRegInfo != null)
            {
                return userRegInfo.LoginName;
            }
            return "无数据";
        }

        public string GetInfo(string InfoId, string Flag)
        {
            if (InfoId == "0")
            {
                return "网店页面";
            }
            if (Flag != "0")
            {
                return "信息页面";
            }
            return "无数据";
        }
    }
}