using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace XYECOM.Web.xymanage.Foreclosed
{
    public partial class ForeclosedInfo : XYECOM.Web.BasePage.ManagePage
    {
        #region 页面加载
        public int productId = 0;
        public string title = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            backURL = XYECOM.Core.XYRequest.GetQueryString("backURL");

            productId = XYECOM.Core.XYRequest.GetQueryInt("ID", 0);

            if (!IsPostBack)
            {
                XYECOM.Business.Server s = new XYECOM.Business.Server();

                XYECOM.Model.ServerInfo es = s.GetItem(s.GetCurrentServerID());

                this.Email.Value = es.S_URL.ToString();
                if (productId > 0)
                {
                    BindData(productId);
                }
            }
        }
        #endregion

        #region 获取数据
        public void BindData(int SD_ID)
        {
            XYECOM.Model.SupplyInfo info = new XYECOM.Business.Supply().GetSupplyById(SD_ID);

            if (null != info)
            {
                txtTitle.Text = info.Title;
                txtContent.Value = info.InfoContent;
                txtSummary.Text = info.Summary;
                supplyImages.InfoID = info.InfoID;

                //初始化加载分类属性相关的信息
                //BindProductProperty(info.FieldValues, "1");

                //初始化加载分类相关的计量单位
                //this.ddlLeastOrderUnit.DataSource = new XYECOM.Business.MeasuringUnitManager().GetUnitByProdTypId(XYECOM.Core.MyConvert.GetInt32(info.SortID.ToString()));
                //this.ddlLeastOrderUnit.DataTextField = "MeasuringUnitName";
                //this.ddlLeastOrderUnit.DataValueField = "id";
                //this.ddlLeastOrderUnit.DataBind();

                if (webInfo.InfoEndTimeType)
                {
                    rblUseFulDate.Text = info.UseFulDate.ToString();
                    txtEndTime.Visible = false;
                }
                else
                {
                    txtEndTime.Text = info.EndTime.ToShortDateString();
                    rblUseFulDate.Visible = false;
                    cbIsUpdateEndTime.Visible = false;
                }
                txtPrice.Text = info.MarketPrice.ToString();
                //ddlLeastOrderUnit.SelectedValue = info.MeasuringUnitId.ToString();
                txtCountNum.Text = info.CountNum.ToString();

                if (info.AuditingState == XYECOM.Model.AuditingState.Null)
                {
                    lblMessage.Text = "未审核";
                }
                else if (info.AuditingState == XYECOM.Model.AuditingState.NoPass)
                {
                    btnNoPass.Visible = false;
                    lblMessage.Text = "未通过审核";
                }
                else
                {
                    btnPass.Visible = false;
                    lblMessage.Text = "通过审核";
                }
            }

            XYECOM.Model.UserInfo uinfo = new XYECOM.Business.UserInfo().GetItem(info.UserID);
            if (null != uinfo)
            {
                linkCompany.NavigateUrl = "../UserManage/UserInfo.aspx?U_ID=" + uinfo.UserId.ToString() + "&backURL=" + XYECOM.Core.Utils.JSEscape("../Supply/LookSupply.aspx?SD_ID=" + SD_ID.ToString() + "&backURL=" + XYECOM.Core.Utils.JSEscape(XYECOM.Core.XYRequest.GetQueryString("backURL")));
                linkCompany.Text = uinfo.Name;
                lbUI_Telephone.Text = uinfo.Telephone;
                lbUI_Fax.Text = uinfo.Fax;
                lbUI_Mobil.Text = uinfo.Mobile;
                U_ID.Value = uinfo.UserId.ToString();
                Email.Value = uinfo.RegInfo.Email;
            }

            string strwhere = " where SD_ID=" + SD_ID.ToString();
            //DataTable DT = Function.GetDataTable(strwhere, "", " XYV_Supply");
        }
        #endregion


        #region 审核操作
        protected void Button1_Click(object sender, EventArgs e)//拒绝通过审核
        {
            XYECOM.Business.UserReg ur = new XYECOM.Business.UserReg();
            XYECOM.Business.UserFictitiouCount uft = new XYECOM.Business.UserFictitiouCount();

            string reason = this.tbA_Reason.Text.Trim();
            string advice = this.tbA_Advice.Text.Trim();
            int i = NotPassAudit("i_Supply", productId, reason, advice);

            if (i > 0)
            {
                //给用户留言
                if (this.U_ID.Value != "")
                {
                    string url = webInfo.WebDomain + "user/adv_post." + webInfo.WebSuffix + "?ename=offer&flag=1&info_ID=" + productId;
                    SendMessage(Convert.ToInt64(this.U_ID.Value), url, reason, advice, this.txtTitle.Text.Trim());
                }

                //给用户发短信
                if (this.Email.Value != "")
                {
                    SendEmail(txtTitle.Text, this.Email.Value);
                }
                XYECOM.Business.FaithSet fs = new XYECOM.Business.FaithSet();
                DataTable dt = fs.GetDataTable();
                if (rbcommonerror.Checked == true)//普通错误扣除的诚信指数和UU币
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["BF_ErrFath"].ToString() != "")//扣除UU币
                        {
                            uft.DeductUserUUFictitiouCount(Convert.ToInt64(this.U_ID.Value), Convert.ToInt32(dt.Rows[0]["BF_ErrMoney"].ToString()));
                        }
                    }
                    ur.AddUserCommonErr(Convert.ToInt64(this.U_ID.Value), 1); //普通错误处罚的次数
                }
                else if (rbgravenesserror.Checked == true)//恶意错误扣除的诚信指数和UU币
                {
                    if (dt.Rows.Count > 0)
                    {

                        if (dt.Rows[0]["BF_Fath"].ToString() != "")//普通错误处罚的次数
                        {
                            ur.DeductFaithMongy(Convert.ToInt64(this.U_ID.Value), Convert.ToInt32(dt.Rows[0]["BF_Fath"].ToString()));
                        }
                        if (dt.Rows[0]["BF_Money"].ToString() != "")
                        {
                            uft.DeductUserUUFictitiouCount(Convert.ToInt64(this.U_ID.Value), Convert.ToDecimal(dt.Rows[0]["BF_Money"].ToString()));

                        }
                    }
                    ur.AddUserMaliceErr(Convert.ToInt64(this.U_ID.Value), 1);//恶意处罚的次数
                }
                Alert("操作成功！", Request.Url.PathAndQuery);
            }
            else
            {
                Alert("操作失败！", Request.Url.PathAndQuery);
            }
        }

        #endregion

        #region 返回
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect(backURL);
        }
        #endregion

        #region  审核失败给用户发送邮件
        private void SendEmail(string title, string Email)
        {
            if (webInfo.IsAuditingInfoEmail)
            {
                string messtitle = "商业信息审核报告";

                string[] a = new string[] { webInfo.WebName, webInfo.WebDomain, title, webInfo.WebDomain + "login." + webInfo.WebSuffix };
                string[] ac = new string[] { "{$WI_Name$}", "{$WI_url$}", "{$title$}", "{$pdateurl$}" };
                string strcont = XYECOM.Core.TemplateEmail.GetContent(a, ac, "/templateEmail/AuditingInfo.htm");
                if (strcont != "-1")
                {
                    XYECOM.Business.Utils.SendMail(Email, messtitle, strcont);
                }
            }
        }
        #endregion



        /// <summary>
        /// 通过审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPass_Click(object sender, EventArgs e)
        {
            int i = new XYECOM.Business.Auditing().UpdatesAuditing(productId, "i_Supply", XYECOM.Model.AuditingState.Passed);

            Response.Redirect(Request.Url.PathAndQuery);
        }

        /// <summary>
        /// 不通过审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnNoPass_Click(object sender, EventArgs e)
        {
            int i = new XYECOM.Business.Auditing().UpdatesAuditing(productId, "i_Supply", XYECOM.Model.AuditingState.NoPass);

            Response.Redirect(Request.Url.PathAndQuery);
        }
    }
}