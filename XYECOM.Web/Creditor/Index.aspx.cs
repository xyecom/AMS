using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XYECOM.Core;
using XYECOM.Web.AppCode;
using System.Text;
using XYECOM.Model;
using System.Data;

namespace XYECOM.Web.Creditor
{
    public partial class Index : XYECOM.Web.AppCode.UserCenter.Creditor
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void BindData()
        {
            BindOtherInfo();
            BindZqInfo();
            BindDzInfo();
        }

        void BindDzInfo()
        {
            this.lblDzMessage.Text = "";

            StringBuilder strWhere = new StringBuilder(" 1=1 and (State = " + (int)AuditingState.Passed + ") and (DepartmentId = " + userinfo.userid + ")");

            int totalRecord = 0;
            DataTable dt = XYECOM.Business.Utils.GetPaginationData("ForeclosedInfo", "ForeclosedId", "*", " CreateDate desc", strWhere.ToString(), 10, 1, out totalRecord);

            if (dt.Rows.Count > 0)
            {
                this.dltDz.DataSource = dt;
                this.dltDz.DataBind();
            }
            else
            {
                this.dltDz.Visible = false;
                this.lblDzMessage.Text = "没有相关信息记录";
            }
        }

        void BindZqInfo()
        {
            this.lblZqMessage.Text = "";

            StringBuilder strWhere = new StringBuilder(" 1=1 and (DepartId = " + userinfo.userid + ") and ( ApprovaStatus ! =7)");

            int totalRecord = 0;
            DataTable dt = XYECOM.Business.Utils.GetPaginationData("CreditInfo", "CreditId", "*", " CreateDate desc", strWhere.ToString(), 10, 1, out totalRecord);


            if (dt.Rows.Count > 0)
            {
                this.rptCreadit.DataSource = dt;
                this.rptCreadit.DataBind();
            }
            else
            {
                this.lblZqMessage.Text = "没有相关信息记录";
                this.rptCreadit.Visible = false;
            }
        }

        void BindOtherInfo()
        {
            this.imgPic.ImageUrl = userinfo.LayerPicture;
            this.imgSj.ImageUrl = userinfo.IsBoundMobile ? "/Other/images/sjyes.gif" : "/Other/images/sjno.gif";
            this.imgYx.ImageUrl = userinfo.IsBoundEmail ? "/Other/images/yxyes.gif" : "/Other/images/yxno.gif";
            this.ltlSjMessage.Text = userinfo.IsBoundMobile ? "手机已绑定" : "手机未绑定";
            this.ltlYxMessage.Text = userinfo.IsBoundEmail ? "邮箱已绑定" : "邮箱未绑定";

            this.ltlCaseCount.Text = Utitl.GetInfoCount("CaseInfo", "CompanyId=" + userinfo.userid).ToString();
            this.ltlCompanyName.Text = userinfo.LoginName;
            this.ltlCreditInfoCount.Text = Utitl.GetInfoCount("CreditInfo", "UserId=" + userinfo.userid + " and ApprovaStatus in (2,3,4)").ToString();
            this.ltlDraftCount.Text = Utitl.GetInfoCount("CreditInfo", "UserId=" + userinfo.userid + " and ApprovaStatus=0").ToString();
            this.ltlLastLoginTime.Text = new Business.UserLogin().GetItem(userinfo.userid).LastLoginDate;
            this.ltlMessageCount.Text = Utitl.GetInfoCount("XYV_RecverManage", "UR_ID=" + userinfo.userid).ToString();
            this.ltlPartCount.Text = Utitl.GetInfoCount("u_user", "CompanyId=" + userinfo.userid + " and IsPrimary=0").ToString();
        }

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
        public string GetEndDate(object endDate)
        {
            DateTime date = XYECOM.Core.MyConvert.GetDateTime(endDate.ToString());
            if (date.CompareTo(DateTime.Now) < 0)
            {
                return "已过期";
            }
            else
            {
                return date.ToString("yyyy-MM-dd");
            }
        }

        /// <summary>
        /// 获取物品地址
        /// </summary>
        /// <param name="areaId"></param>
        /// <returns></returns>
        public string GetAreaIdFull(object areaId)
        {
            int aId = MyConvert.GetInt32(areaId.ToString());
            return new XYECOM.Business.Area().GetItem(aId).FullNameAll;
        }

        /// <summary>
        /// 获取默认图片
        /// </summary>
        /// <param name="foreId"></param>
        /// <returns></returns>
        public string GetInfoImgHref(object foreId)
        {
            int id = MyConvert.GetInt32(foreId.ToString());
            return XYECOM.Business.Attachment.GetInfoDefaultImgHref(XYECOM.Model.AttachmentItem.ForeclosedInfo, id);
        }
    }
}