using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XYECOM.Page;
using System.Text;
using System.Data;
using XYECOM.Core;
using XYECOM.Business.AMS;
using XYECOM.Business;
using XYECOM.Model.AMS;

namespace XYECOM.Web
{
    public partial class showEvaluation : ForeBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int isServer = XYECOM.Core.XYRequest.GetQueryInt("isServer", 0);
                if (isServer == 1)
                {
                    this.labTitle.Text = "服务商基本信息";
                    this.labTitle1.Text = "服务商基本信息";
                }
                else
                {
                    this.labTitle.Text = "债权商基本信息";
                    this.labTitle1.Text = "债权商基本信息";
                }
                int userId = XYECOM.Core.XYRequest.GetQueryInt("UserId", 0);
                if (userId <= 0)
                {
                    GotoMsgBoxPageForDynamicPage("请选择要查看的用户！", 1, "Index.aspx");
                }
                this.hidId.Value = userId.ToString();
                BindData(userId);
            }
        }

        public void BindData(int id)
        {
            XYECOM.Model.GeneralUserInfo userInfo = Business.CheckUser.GetUserInfo(id);
            XYECOM.Model.GeneralUserInfo loginUserInfo = Business.CheckUser.UserInfo;
            if (userInfo == null)
            {
                GotoMsgBoxPageForDynamicPage("请选择要查看的用户！", 1, "Index.aspx");
            }
            this.labAreaId.Text = userInfo.AreaName;
            this.labCompName.Text = userInfo.CompanyName;
            this.labUserName.Text = userInfo.LoginName;
            if (loginUserInfo != null)
            {
                this.labEmail.Text = userInfo.Email;
                this.labPhone.Text = userInfo.Telphone;
            }
            StringBuilder strWhere = new StringBuilder(" 1=1 and (User2Id= " + id + ")");
            int totalRecord = 0;
            DataTable dt = XYECOM.Business.Utils.GetPaginationData("Evaluation", "EvaluationId", "*", " EvaluationId desc", strWhere.ToString(), this.Page1.PageSize, this.Page1.CurPage, out totalRecord);
            this.Page1.RecTotal = totalRecord;

            if (dt.Rows.Count > 0)
            {
                this.rptList.DataSource = dt;
                this.rptList.DataBind();
            }
            else
            {
                this.lblMessage.Text = "还没人对其评价";
                this.rptList.DataBind();
            }
        }


        /// <summary>
        /// 获取债权标题
        /// </summary>
        /// <param name="credId"></param>
        /// <returns></returns>
        protected string GetCreditTitle(object credId)
        {
            int id = MyConvert.GetInt32(credId.ToString());
            return new CreditInfoManager().GetCreditInfoById(id).Title;
        }

        #region 分页相关代码

        protected void Page1_PageChanged(object sender, System.EventArgs e)
        {
            int id = MyConvert.GetInt32(this.hidId.Value);
            this.BindData(id);
        }
        #endregion
    }
}