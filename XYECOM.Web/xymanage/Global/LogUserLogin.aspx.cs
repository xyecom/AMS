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
    public partial class LogUserLogin : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("log");

            if (!Page.IsPostBack)
            {                
                this.Page1.PageSize = 20;
                gvDataBind();
            }
        }

        #region 绑定数据
        private void gvDataBind()
        {
            string strWhere = " where 1=1 ";
            string strOrder = "order by LastLoginDate desc  ";
            this.lblMessage.Text = "";
            string strTableName = "XY_UserLoginLog";
            SetValueByquery(Page1, "page");
            SetValueByquery(txtname, "KeyWord");
            SetValueByquery(bgdate, "bgdate");
            SetValueByquery(egdate, "egdate");
            if (this.txtname.Text != "")
            {
                UserReg userRegBLL = new UserReg();
                XYECOM.Model.UserRegInfo userRegInfo = userRegBLL.GetItem(this.txtname.Text.Trim());
                if (userRegInfo != null)
                {
                    strWhere += " and U_ID=" + userRegInfo.UserId;
                }
                else
                {
                    strWhere += " and U_ID=0";
                }
            }
            this.gvlist.PageSize = this.Page1.PageSize;
       


            backURL = XYECOM.Core.Utils.JSEscape("LogUserLogin.aspx?page=" + Page1.CurPage.ToString() +
                "&KeyWord=" + txtname.Text.Trim() +

                "&bgdate=" + bgdate.Value.Trim() +
                "&egdate=" + egdate.Value.Trim() 
                );

            this.lblMessage.Text = "";
         

           string begindate = this.bgdate.Value;
           string enddate = this.egdate.Value;
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
           
            if (begindate != "")
            {
                strWhere += " and (LastLoginDate > '" + begindate + "') ";
            }
            if (enddate != "")
            {
                strWhere += " and (LastLoginDate < '" + XYECOM.Core.MyConvert.GetDateTime(enddate).AddDays(1) + "') ";
            }    
          

            this.Page1.RecTotal = Function.GetRows(strTableName, "UL_ID", strWhere);
            DataTable dt = Function.GetPages(this.Page1.PageSize, this.Page1.CurPage, strWhere, strOrder, strTableName, " * ", "UL_ID");
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

        #region 删除
        protected void Button1_Click(object sender, EventArgs e)
        {
            gvDataBind();
        }
        #endregion

        public string GetUserName(int Userid)
        {
            UserReg userRegBLL = new UserReg();
            XYECOM.Model.UserRegInfo userRegInfo = userRegBLL.GetItem(Userid);
            if (userRegInfo == null)
                return "未知";
            return userRegInfo.LoginName + "/ " + userRegInfo.Email;
        }
    }
}