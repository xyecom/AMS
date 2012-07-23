using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XYECOM.Model.AMS;
using XYECOM.Core;
using XYECOM.Model;
using XYECOM.Business.AMS;
using System.Text;
using System.Data;
using XYECOM.Business;

namespace XYECOM.Web.Creditor
{
    public partial class CreditDetils : XYECOM.Web.AppCode.UserCenter.Creditor
    {
        CreditInfoManager manage = new CreditInfoManager();

        Business.UserInfo userInfoManage = new Business.UserInfo();

        TenderInfoManager tenderManage = new TenderInfoManager();

        #region 页面加载
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int Id = XYECOM.Core.XYRequest.GetQueryInt("ID", 0);
                if (Id <= 0)
                {
                    GotoMsgBoxPageForDynamicPage("该债权信息不存在！", 1, "CreditInfoList.aspx");
                }
                this.hidID.Value = Id.ToString();
                BindData(Id);
            }
        }
        #endregion

        #region 获取数据
        public void BindData(int id)
        {
            CreditInfo info = manage.GetCreditInfoById(id);
            if (info == null)
            {
                GotoMsgBoxPageForDynamicPage("该债权信息不存在！", 1, "CreditInfoList.aspx");
            }

            if (null != info)
            {
                this.labAge.Text = info.Age.ToString();
                this.labCreateDate.Text = info.CreateDate.ToString("yyyy-MM-dd");
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
                this.labIsConfirm.Text = info.IsConfirm ? "确认" : "不确认";
                this.labIsInLitigation.Text = info.IsInLitigation ? "是" : "否";
                this.labIsLitigationed.Text = info.IsLitigationed ? "是" : "否";
                this.labIsSelfCollection.Text = info.IsSelfCollection ? "是" : "否";
                this.labCount.Text = GetTenderCountByCreditID(info.CreditId).ToString();
                this.labDebtorType.Text = info.DebtorType;
            }

            StringBuilder strWhere = new StringBuilder(" 1=1 and  CreditInfoId = " + id);
            int totalRecord = 0;
            DataTable dt = XYECOM.Business.Utils.GetPaginationData("TenderInfo", "TenderId", "*", " TenderDate desc", strWhere.ToString(), this.Page1.PageSize, this.Page1.CurPage, out totalRecord);
            this.Page1.RecTotal = totalRecord;

            if (dt.Rows.Count > 0)
            {
                this.rptList.DataSource = dt;
                this.rptList.DataBind();
            }
            else
            {
                this.lblMessage.Text = "还没有人进行投标";
                this.rptList.DataBind();
            }

            DataTable price = XYECOM.Business.Attachment.GetAllImgHref(AttachmentItem.CreditInfo, info.CreditId);
            if (price.Rows.Count > 0)
            {
                this.rpPrice.DataSource = price;
                this.rpPrice.DataBind();
            }
            DataTable ralaCases = new RelatedCaseInfoManager().GetFilePaths(info.CreditId, Model.TableInfoType.ZqInfo);
            if (ralaCases.Rows.Count > 0)
            {
                this.rpfile.DataSource = ralaCases;
                this.rpfile.DataBind();
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

        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hidInfoId = (HiddenField)e.Item.FindControl("hidCreditInfoId");//当前案件编号
                if (hidInfoId == null) return;
                int creditId = MyConvert.GetInt32(hidInfoId.Value);
                CreditInfo info = new CreditInfoManager().GetCreditInfoById(creditId);

                int stateId = info.ApprovaStatus;
                LinkButton lbtnOk = (LinkButton)e.Item.FindControl("lbtnConfirm");//选择服务商
                System.Web.UI.WebControls.Label labelMessage = (System.Web.UI.WebControls.Label)e.Item.FindControl("labTenderMessage");
                System.Web.UI.WebControls.Label labelTender = (System.Web.UI.WebControls.Label)e.Item.FindControl("labToTender");
                XYECOM.Model.GeneralUserInfo userInfo = Business.CheckUser.UserInfo;    //判断当前登录帐号信息

                Model.CreditState sta = (Model.CreditState)stateId;
                if (sta == Model.CreditState.Tender)
                {
                    if (userInfo != null && info.DepartId == userInfo.userid)
                    {
                        lbtnOk.Visible = true;
                        labelTender.Visible = false;
                    }
                    else
                    {
                        labelTender.Visible = true;
                        lbtnOk.Visible = false;
                    }
                    labelMessage.Visible = false;
                }
                else if (sta != Model.CreditState.Tender)
                {
                    lbtnOk.Visible = false;
                    labelMessage.Visible = true;
                    labelTender.Visible = false;
                }
            }
        }

        /// <summary>
        /// 选择某服务商给债权执行者
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnOK_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)(sender as LinkButton);
            if (linkButton != null)
            {
                int Id = XYECOM.Core.MyConvert.GetInt32(linkButton.CommandArgument);
                if (Id > 0)
                {
                    TenderInfo info = tenderManage.GetTenderInfoByID(Id);
                    int result = tenderManage.UpdateTenderByID(Id, info.CreditInfoId);
                    if (info == null)
                    {
                        GotoMsgBoxPageForDynamicPage("该投标信息不存在！", 1, "CreditInfoList.aspx");
                    }
                    if (result > 0)
                    {
                        result = manage.UpdateApprovaStatusByID(info.CreditInfoId, XYECOM.Model.CreditState.InProgress);
                    }
                    if (result > 0)
                    {
                        BindData(info.CreditInfoId);
                    }
                }
            }
        }
        /// <summary>
        /// 根据债权信息ID获取该债权信息的投标个数
        /// </summary>
        /// <param name="CreditID"></param>
        /// <returns></returns>
        public int GetTenderCountByCreditID(object CreditID)
        {
            int id = MyConvert.GetInt32(CreditID.ToString());
            return new TenderInfoManager().GetTenderCountByCreditID(id);
        }
        #region 分页相关代码

        protected void Page1_PageChanged(object sender, System.EventArgs e)
        {
            int credId = MyConvert.GetInt32(this.hidID.Value);
            this.BindData(credId);
        }

        public string GetInfoImgHref(object userId)
        {
            int id = MyConvert.GetInt32(userId.ToString());
            return XYECOM.Business.Attachment.GetInfoDefaultImgHref(AttachmentItem.User, id);
        }

        public string GetAreaName(object userId)
        {
            int UserId = MyConvert.GetInt32(userId.ToString());
            XYECOM.Model.GeneralUserInfo userInfo = Business.CheckUser.GetUserInfo(UserId);
            return userInfo.AreaName;
        }
        #endregion

        public string GetFileName(object filePath)
        {
            string path = filePath.ToString();
            int index = path.LastIndexOf("/");
            string name = string.Empty;
            if (path.Length > 0)
            {
                name =path.Substring(index+1);
            }
            return name;
        }
    }
}