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
    public partial class PageRecord : XYECOM.Web.BasePage.ManagePage
    {
        UserReg userRegBLL = new UserReg();
        UserInfo userInfoBLL = new UserInfo();
        PageRecordManager pageRecordBLL = new PageRecordManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("Statistics");

            if (!IsPostBack)
            {
                this.Page1.PageSize = 50;

                SetValueByquery(Page1, "Page1");
                SetValueByquery(DllFlag, "pageflag");
                SetValueByquery(txtuserName, "username");
                SetValueByquery(begindate, "bgdate");
                SetValueByquery(enddate, "egdate");

                gvDataBind();
            }
        }
        #region 绑定数据
        protected void gvDataBind()
        {
            string strOrder = " group by UserId";
            this.lblMessage.Text = "";
            string strTableName = " XY_PageRecord ";
            string str = " count(*) as num,max(UserId) as UserId ";
            string strWhere = " 1=1 ";

            BegDate = this.begindate.Value;
            EndDate = this.enddate.Value;
            PagePram = Page1.CurPage.ToString();

            if (BegDate != "")
            {
                strWhere += " and (Date > '" + BegDate + "') ";
            }

            if (EndDate != "")
            {
                strWhere += " and (Date < '" + XYECOM.Core.MyConvert.GetDateTime(EndDate).AddDays(1) + "') ";
            }
            
            PageFlag = this.DllFlag.SelectedValue;
            UserName = this.txtuserName.Text.Trim();
            
            if (UserName != "")
            {
                XYECOM.Model.UserRegInfo userRegInfo = userRegBLL.GetItem(UserName);

                if (userRegInfo != null)
                {
                    strWhere += " and UserId=" + userRegInfo.UserId;
                }
                else 
                {
                    strWhere += " and UserId=-1";
                }
            }

            if (PageFlag != "-1")
            {
                strWhere += " and Flag=" + PageFlag;
            }

            string sqlStr = string.Format("select{0}from{1}where{2}{3}", str, strTableName, strWhere, strOrder);
            DataTable dt = pageRecordBLL.GetPageRecordBystrWhere(sqlStr);
            
            this.Page1.RecTotal = dt.Rows.Count;
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

        #region 查询
        protected void BtnSearch_Click(object sender, EventArgs e)
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

        public string GetUserName(string UserId)
        {
            if (UserId == "0")
            {
                return "平台网站";
            }
            XYECOM.Model.UserRegInfo userRegInfo = userRegBLL.GetItem(XYECOM.Core.MyConvert.GetInt32(UserId));
            if (userRegInfo != null)
            {
                return userRegInfo.LoginName;
            }
            return "无数据";
        }

        public string GetCorpName(string UserId)
        {
            if (UserId == "0")
            {
                return "平台网站";
            }

            XYECOM.Model.UserInfo userInfo = userInfoBLL.GetItem(XYECOM.Core.MyConvert.GetInt32(UserId));
            if (userInfo != null)
            {
                return userInfo.Name + "</br>" + userInfo.HomePage;
            }
            return "无数据";
        }

        public string GetLastDate(string UserId)
        {
            if (UserId != "")
            {
                int UId = XYECOM.Core.MyConvert.GetInt32(UserId);
                return pageRecordBLL.GetLastDate(UId);
            }
            return "无数据";
        }

        public string GetShopFlagNum(string UserId)
        {
            string sqlStr ="select count(*) from XY_PageRecord where UserId=" + UserId +" and Flag=" + (int)XYECOM.Model.PageRecord.ShopRecord;

            DataTable TableInfo = pageRecordBLL.GetPageRecordBystrWhere(sqlStr);

            return TableInfo.Rows[0][0].ToString();
        }

        protected void btnBlank_Click(object sender, EventArgs e)
        {
            this.begindate.Value = "";
            this.enddate.Value = "";
            this.DllFlag.SelectedValue = "-1";
           
            gvDataBind();
        }

        public string BegDate
        {
            get;
            set;
        }

        public string EndDate
        {
            get;
            set;
        }
        public string PageFlag
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }

        public string PagePram
        {
            get;
            set;
        }
    }
}