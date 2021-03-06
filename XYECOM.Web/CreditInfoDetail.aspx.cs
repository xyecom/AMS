﻿using System;
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
using XYECOM.Model;

namespace XYECOM.Web
{
    public partial class CreditInfoDetail : ForeBasePage
    {
        CreditInfoManager manage = new CreditInfoManager();

        Business.UserInfo userInfoManage = new Business.UserInfo();

        TenderInfoManager tenderManage = new TenderInfoManager();

        #region 页面加载
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!Business.CheckUser.CheckUserLogin())
                {
                    GotoMsgBoxPageForDynamicPage("登录后才能访问详情页面！", 2, "Login.aspx?backurl=" + Request.Url.PathAndQuery);
                    return;
                }
                int Id = XYECOM.Core.XYRequest.GetQueryInt("ID", 0);
                if (Id <= 0)
                {
                    GotoMsgBoxPageForDynamicPage("该债权信息不存在！", 1, "IndexCreditList.aspx");
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
                GotoMsgBoxPageForDynamicPage("该债权信息不存在！", 1, "IndexCreditList.aspx");
            }

            if (null != info)
            {
                this.labAge.Text = info.Age.ToString();
                this.labAreaId.Text = new Area().GetItem(info.AreaId).FullNameAll;
                this.labCreateDate.Text = info.CreateDate.ToString("yyyy-MM-dd");
                this.labCompanyName.Text = userInfoManage.GetCompNameByUId(info.UserId);
                this.labUserName.Text = userInfoManage.GetUserNameByID(info.DepartId);
                this.labTitle.Text = info.Title;
                this.labArrears.Text = info.Arrears.ToString();
                this.labBounty.Text = info.Bounty.ToString();
                this.labCollectionPeriod.Text = info.CollectionPeriod;
                this.labDebtObligation.Text = info.DebtObligation;
                XYECOM.Model.GeneralUserInfo userInfo = Business.CheckUser.UserInfo;
                TenderInfo tenderInfo = new TenderInfoManager().GetTenderByCredId(info.CreditId);
                if ((tenderInfo != null && userInfo.userid == tenderInfo.LayerId) || userInfo.userid == info.DepartId)
                {
                    this.labDebtorTelpone.Text = info.DebtorTelpone;
                    this.labDebtorName.Text = info.DebtorName;
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
                else
                {
                    if (!string.IsNullOrEmpty(info.DebtorName) && info.DebtorName.Length > 1)
                    {
                        this.labDebtorName.Text = info.DebtorName.Substring(0, 1) + "**";
                    }
                    else
                    {
                        this.labDebtorName.Text = info.DebtorName;
                    }
                    if (!string.IsNullOrEmpty(info.DebtorTelpone) && info.DebtorTelpone.Length > 1)
                    {
                        this.labDebtorTelpone.Text = info.DebtorTelpone.Substring(0, 6) + "**";
                    }
                    else
                    {
                        this.labDebtorTelpone.Text = info.DebtorTelpone;
                    }
                }


                this.labDebtorReason.Text = info.DebtorReason;
                this.labIntroduction.Text = info.Introduction;
                this.labState.Text = GetApprovaStatus(info.ApprovaStatus);
                this.labIsConfirm.Text = info.IsConfirm ? "确认" : "不确认";
                this.labIsInLitigation.Text = info.IsInLitigation ? "是" : "否";
                this.labIsLitigationed.Text = info.IsLitigationed ? "是" : "否";
                this.labIsSelfCollection.Text = info.IsSelfCollection ? "是" : "否";
                this.hidStae.Value = info.ApprovaStatus.ToString();
                this.aShow.HRef = "showEvaluation.aspx?UserId=" + info.DepartId;

                this.litTitle.Text = info.Title;
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

        protected void btnTender_Click(object sender, EventArgs e)
        {
            int state = MyConvert.GetInt32(this.hidStae.Value);
            XYECOM.Model.CreditState cState = (XYECOM.Model.CreditState)state;
            if (cState != XYECOM.Model.CreditState.Tender)
            {
                GotoMsgBoxPageForDynamicPage("该债权信息不能进行投标！", 1, "IndexCreditList.aspx");
            }
            XYECOM.Model.GeneralUserInfo userInfo = Business.CheckUser.UserInfo;
            if (userInfo == null)
            {
                GotoMsgBoxPageForDynamicPage("请登录后进行投标！", 1, "IndexCreditList.aspx");
            }
            if (userInfo.UserType != XYECOM.Model.UserType.Layer && userInfo.UserType != XYECOM.Model.UserType.NotLayer)
            {
                GotoMsgBoxPageForDynamicPage("债权帐号不能进行投标！", 1, "IndexCreditList.aspx");
            }
            int credId = MyConvert.GetInt32(this.hidID.Value);
            //检查该服务商是否已经投标
            bool isCheckTender = tenderManage.CheckTenderByCredID(credId, (int)userInfo.userid);
            if (isCheckTender)
            {
                GotoMsgBoxPageForDynamicPage("不能重复投标，请耐心等待债权人选择！", 1, "IndexCreditList.aspx");
            }
            TenderInfo info = new TenderInfo();
            info.CreditInfoId = credId;
            info.IsSuccess = (int)TenderState.Tender;
            info.LayerId = (int)userInfo.userid;
            info.Message = this.txtRemark.Text.Trim();
            info.TenderDate = DateTime.Now;
            int result = new TenderInfoManager().InsertTenderInfo(info);
            if (result > 0)
            {
                GotoMsgBoxPageForDynamicPage("投标成功！", 1, "CreditInfoDetail.aspx?Id=" + credId);
            }
            else
            {
                GotoMsgBoxPageForDynamicPage("投标失败！", 1, "CreditInfoDetail.aspx?Id=" + credId);
            }
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
                        GotoMsgBoxPageForDynamicPage("该投标信息不存在！", 1, "CreditInfoDetail.aspx");
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
        #region 分页相关代码

        protected void Page1_PageChanged(object sender, System.EventArgs e)
        {
            int credId = MyConvert.GetInt32(this.hidID.Value);
            this.BindData(credId);
        }
        #endregion

        public string GetFileName(object filePath)
        {
            string path = filePath.ToString();
            int index = path.LastIndexOf("/");
            string name = string.Empty;
            if (path.Length > 0)
            {
                name = path.Substring(index + 1);
            }
            return name;
        }
    }
}