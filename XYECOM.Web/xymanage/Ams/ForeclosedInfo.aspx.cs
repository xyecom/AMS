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
    public partial class ForeclosedInfo : XYECOM.Web.BasePage.ManagePage
    {
        ForeclosedManager manage = new ForeclosedManager();

        #region 页面加载
        protected void Page_Load(object sender, EventArgs e)
        {
            backURL = XYECOM.Core.XYRequest.GetQueryString("backURL");

            int Id = XYECOM.Core.XYRequest.GetQueryInt("ID", 0);
            if (Id <= 0)
            {
                Alert("该抵债信息不存在！", backURL);
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
            XYECOM.Model.AMS.ForeclosedInfo info = manage.GetForeclosedInfoById(id);
            if (info == null)
            {
                Alert("该抵债信息不存在！", backURL);
            }

            if (null != info)
            {
                this.labAddress.Text = info.Address;
                this.labAreaId.Text = new Area().GetItem(info.AreaId).FullNameAll;
                this.labCreateDate.Text = info.CreateDate.ToString();
                this.labCompanyName.Text = GetCompanyName(info.CompanyId);
                this.labUserName.Text = GetUserName(info.DepartmentId);
                this.hidUserId.Value = info.DepartmentId.ToString();
                this.labTitle.Text = info.Title;
                this.labTypeName.Text = info.ForeColseTypeName;
                this.labIdentityNumber.Text = info.IdentityNumber;
                this.labEndDate.Text = info.EndDate.ToString();
                this.labHighPrice.Text = info.HighPrice.ToString();
                this.labLinePrice.Text = info.LinePrice.ToString();
                this.labState.Text = GetAuditingState(info.State);
                this.labDescription.Text = info.Description;
            }
        }
        #endregion

        /// <summary>
        /// 根据用户编号获取用户名称
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        protected string GetUserName(object userID)
        {
            int uId = MyConvert.GetInt32(userID.ToString());
            return new Business.UserInfo().GetUserNameByID(uId);
        }

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

                em.M_Title = "抵债信息审核不通过";
                em.M_Content = "请详细检查抵债信息，不可描述不清";

                em.M_UserName = "";
                em.M_UserType = false;
                em.U_ID = -1;
                em.UR_ID = U_ID;
                m.Insert(em);
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
            int i = manage.AuditById(id, true);
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
            int i = manage.AuditById(id, false);
            int userId = MyConvert.GetInt32(this.hidUserId.Value);
            if (i > 0)
            {
                SendToMessage(userId);
                Alert("审核成功", backURL);
            }
            else
            {
                Alert("审核失败", backURL);
            }
        }
    }
}