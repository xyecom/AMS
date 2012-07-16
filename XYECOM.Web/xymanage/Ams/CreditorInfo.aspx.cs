using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using XYECOM.Business.AMS;
using XYECOM.Business;
using XYECOM.Core;

namespace XYECOM.Web.xymanage
{
    public partial class CreditorInfo : XYECOM.Web.BasePage.ManagePage
    {
        CreditInfoManager manage = new CreditInfoManager();

        #region 页面加载
        protected void Page_Load(object sender, EventArgs e)
        {
            backURL = XYECOM.Core.XYRequest.GetQueryString("backURL");

            int Id = XYECOM.Core.XYRequest.GetQueryInt("ID", 0);
            if (Id <= 0)
            {
                Alert("该债权信息不存在！", backURL);
            }
            if (!IsPostBack)
            {
                this.hidID.Value = Id.ToString();
                BindData(Id);
            }
        }
        #endregion

        #region 获取数据
        public void BindData(int id)
        {
            XYECOM.Model.AMS.CreditInfo info = manage.GetCreditInfoById(id);
            if (info == null)
            {
                Alert("该抵债信息不存在！", backURL);
            }

            if (null != info)
            {
                this.labAge.Text = info.Age.ToString();
                this.labAreaId.Text = new Area().GetItem(info.AreaId).FullNameAll;
                this.labCreateDate.Text = info.CreateDate.ToString();
                this.labCompanyName.Text = GetCompanyName(info.UserId);
                this.labUserName.Text = GetUserName(info.DepartId);
                this.labTitle.Text = info.Title;
                this.labArrears.Text = info.Arrears.ToString();
                this.labBounty.Text = info.Bounty.ToString();
                this.labCollectionPeriod.Text = info.CollectionPeriod;
                this.labDebtObligation.Text = info.DebtObligation;
                this.labDebtorName.Text = info.DebtorName;
                this.labDebtorReason.Text = info.DebtorReason;
                this.labDebtorTelpone.Text = info.DebtorTelpone;
                this.labIntroduction.Text = info.Introduction;
                this.labState.Text = GetApprovaStatus(info.ApprovaStatus);
                this.labIsConfirm.Text = info.IsConfirm?"确认":"不确认";
                this.labIsInLitigation.Text = info.IsInLitigation ? "是" : "否";
                this.labIsLitigationed.Text = info.IsLitigationed ? "是" : "否";
                this.labIsSelfCollection.Text = info.IsSelfCollection ? "是" : "否";
                this.hidUserId.Value = info.DepartId.ToString();
            }
        }
        #endregion
        protected string GetApprovaStatus(object state)
        {
            int stateId = MyConvert.GetInt32(state.ToString());
            Model.CreditState sta = (Model.CreditState)stateId;
            string name = "";
            switch (sta)
            {
                case XYECOM.Model.CreditState.Draft:
                    name = "草稿";
                    break;
                case XYECOM.Model.CreditState.Null:
                    name = "未审核";
                    break;
                case XYECOM.Model.CreditState.NoPass:
                    name = "审核未通过";
                    break;
                case XYECOM.Model.CreditState.Tender:
                    name = "投标中";
                    break;
                case XYECOM.Model.CreditState.InProgress:
                    name = "案件进行中";
                    break;
                case XYECOM.Model.CreditState.CreditConfirm:
                    name = "服务商案件完成等待债权人确认";
                    break;
                case XYECOM.Model.CreditState.CreditEnd:
                    name = "案件结束";
                    break;
                case XYECOM.Model.CreditState.Canceled:
                    name = "债权人取消案件";
                    break;
            }
            return name;
        }
        /// <summary>
        /// 根据用户编号获取用户名称
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        protected string GetUserName(object userID)
        {
            int uId = MyConvert.GetInt32(userID.ToString());
            return new Business.UserInfo().GetCompNameByUId(uId);
        }

        #region 返回
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect(backURL);
        }
        #endregion

        #region 审核商业信息失败给用户留言
        private void SendToMessage(long U_ID)
        {
            if (webInfo.IsAuditingInfoMessage)
            {
                XYECOM.Model.MessageInfo em = new XYECOM.Model.MessageInfo();
                XYECOM.Business.Message m = new Message();
                em.M_Adress = "";
                em.M_CompanyName = "";
                em.M_Email = "";
                em.M_FHM = "";
                em.M_HasReply = false;
                em.M_Moblie = "";
                em.M_PHMa = "";
                em.M_RecverType = "administrator";
                em.M_Restore = false;
                em.M_SenderType = "user";

                em.M_Title = webInfo.AuditingInfoMessageTitle;
                em.M_Content = webInfo.AuditingInfoMessageContent;

                em.M_UserName = "";
                em.M_UserType = false;
                em.U_ID = -1;
                em.UR_ID = U_ID;
                m.Insert(em);
            }
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
            int id = MyConvert.GetInt32(this.hidID.Value);
            int i = manage.UpdateApprovaStatusByID(id, XYECOM.Model.CreditState.Tender);
            if (i > 0)
            {
                Alert("审核成功", backURL);
            }
            else
            {
                Alert("审核失败", backURL);
            }
        }

        /// <summary>
        /// 不通过审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnNoPass_Click(object sender, EventArgs e)
        {
            int id = MyConvert.GetInt32(this.hidID.Value);
            int i = manage.UpdateApprovaStatusByID(id, XYECOM.Model.CreditState.NoPass);
            if (i > 0)
            {
                long UserId = MyConvert.GetInt64(this.hidUserId.Value);
                string emial = new UserInfo().GetEmailByID((int)UserId);
                SendToMessage(UserId);
                SendEmail("债权信息 审核不通过通知", emial);
                Alert("审核成功", backURL);

            }
            else
            {
                Alert("审核失败", backURL);
            }
        }
    }
}