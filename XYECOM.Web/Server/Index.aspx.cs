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
using XYECOM.Business.AMS;
using XYECOM.Model.AMS;
namespace XYECOM.Web.Server
{
    public partial class Index : XYECOM.Web.AppCode.UserCenter.Server
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void BindData()
        {
            BindOtherInfo();
            BindZqInfo();
        }

        void BindZqInfo()
        {
            this.lblZqMessage.Text = "";
            int totalRecord = 0;
            StringBuilder strWhere = new StringBuilder(" 1=1 and LayerId = " + userinfo.userid);
            DataTable dt = XYECOM.Business.Utils.GetPaginationData("TenderInfo", "TenderId", "*", " TenderDate desc", strWhere.ToString(), 20, 1, out totalRecord);

            if (dt.Rows.Count > 0)
            {
                this.rptList.DataSource = dt;
                this.rptList.DataBind();
            }
            else
            {
                this.lblZqMessage.Text = "没有相关信息记录";
                this.rptList.DataBind();
            }
        }

        void BindOtherInfo()
        {
            this.imgPicture.ImageUrl = userinfo.LayerPicture;
            this.imgSj.ImageUrl = userinfo.IsBoundMobile ? "/Other/images/sjyes.gif" : "/Other/images/sjno.gif";
            this.imgYx.ImageUrl = userinfo.IsBoundEmail ? "/Other/images/yxyes.gif" : "/Other/images/yxno.gif";
            this.ltlSjMessage.Text = userinfo.IsBoundMobile ? "手机已绑定" : "手机未绑定";
            this.ltlYxMessage.Text = userinfo.IsBoundEmail ? "邮箱已绑定" : "邮箱未绑定";

            this.labCanCount.Text = Utitl.GetInfoCount("TenderInfo", "LayerId=" + userinfo.userid).ToString();
            this.ltlCompanyName.Text = userinfo.CompanyName;
            this.labZhongCount.Text = Utitl.GetInfoCount("TenderInfo", "LayerId=" + userinfo.userid + " and IsSuccess = 1").ToString();
            this.ltlLastLoginTime.Text = new Business.UserLogin().GetItem(userinfo.userid).LastLoginDate;
            this.ltlMessageCount.Text = Utitl.GetInfoCount("XYV_RecverManage", "UR_ID=" + userinfo.userid).ToString();
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

        /// <summary>
        /// 根据债权ID获取债权信息
        /// </summary>
        /// <param name="credID"></param>
        /// <returns></returns>
        public CreditInfo GetCreditInfoByCredID(object credID)
        {
            int id = XYECOM.Core.MyConvert.GetInt32(credID.ToString());
            CreditInfo info = new CreditInfo();
            if (id <= 0)
            {
                return info;
            }
            return new CreditInfoManager().GetCreditInfoById(id);

        }
        /// <summary>
        /// 根据债权编号获取债权状态
        /// </summary>
        /// <param name="credID"></param>
        /// <returns></returns>
        protected string GetApprovaStatus(object credID)
        {
            int id = MyConvert.GetInt32(credID.ToString());
            CreditInfo info = this.GetCreditInfoByCredID(id);
            int stateId = MyConvert.GetInt32(info.ApprovaStatus.ToString());
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
        /// 获取投标状态
        /// </summary>
        /// <param name="stateId"></param>
        /// <returns></returns>
        protected string GetTenderState(object stateId)
        {
            Model.AMS.TenderState sta = (Model.AMS.TenderState)stateId;
            string name = "";
            switch (sta)
            {
                case TenderState.Failure:
                    name = "未中标";
                    break;
                case TenderState.Success:
                    name = "中标";
                    break;
                case TenderState.Tender:
                    name = "投标中";
                    break;
            }
            return name;
        }

        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hidTenderId = (HiddenField)e.Item.FindControl("hidTenderId");//当前投标编号
                if (hidTenderId == null) return;
                int tenderId = MyConvert.GetInt32(hidTenderId.Value);
                TenderInfo tenderInfo = new TenderInfoManager().GetTenderInfoByID(tenderId);
                if (tenderInfo == null)
                {
                    return;
                }

                if (tenderInfo.IsSuccess != (int)TenderState.Success)
                {
                    return;
                }

                HiddenField hidCreditId = (HiddenField)e.Item.FindControl("hidCreditInfoId");//当前案件编号
                if (hidCreditId == null) return;
                int creditId = MyConvert.GetInt32(hidCreditId.Value);
                CreditInfo info = new CreditInfoManager().GetCreditInfoById(creditId);

                int stateId = info.ApprovaStatus;
                HyperLink hlEvaluate = (HyperLink)e.Item.FindControl("hlEvaluate");//评价          

                LinkButton lbtnCreditConfirm = (LinkButton)e.Item.FindControl("lbtnCreditConfirm");//服务商确认案件完成          

                Model.CreditState sta = (Model.CreditState)stateId;
                if (sta == Model.CreditState.CreditEnd && !info.IsServerEvaluation)
                {
                    hlEvaluate.Visible = true;
                }
                else
                {
                    hlEvaluate.Visible = false;
                }
                if (sta == Model.CreditState.InProgress)
                {
                    lbtnCreditConfirm.Visible = true;
                }
                else
                {
                    lbtnCreditConfirm.Visible = false;
                }
            }
        }

        /// <summary>
        /// 服务商确认案件完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnCreditConfirm_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)(sender as LinkButton);
            if (linkButton != null)
            {
                int Id = XYECOM.Core.MyConvert.GetInt32(linkButton.CommandArgument);
                if (Id > 0)
                {
                    CreditInfoManager credManage = new CreditInfoManager();
                    int result = credManage.UpdateApprovaStatusByID(Id, XYECOM.Model.CreditState.CreditConfirm);
                    if (result > 0)
                    {
                        BindData();
                    }
                }
            }
        }
    }
}