﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XYECOM.Model.AMS;
using XYECOM.Core;
using XYECOM.Model;

namespace XYECOM.Web.Creditor
{
    public partial class UpdateCreditInfo : XYECOM.Web.AppCode.UserCenter.Creditor
    {
        XYECOM.Business.AMS.CreditInfoManager manager = new Business.AMS.CreditInfoManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = XYECOM.Core.XYRequest.GetInt("Id", 0);
                if (id <= 0)
                {
                    GotoMsgBoxPageForDynamicPage("该债权信息不存在！", 1, "CreditInfoList.aspx");
                }
                this.hiddID.Value = id.ToString();
                BindData(id);
            }
        }

        public void BindData(int id)
        {
            CreditInfo info = manager.GetCreditInfoById(id);
            if (info == null)
            {
                GotoMsgBoxPageForDynamicPage("该债权信息不存在！", 1, "CreditInfoList.aspx");
            }
            this.txtTitle.Text = info.Title;
            this.areaid.Value = info.AreaId.ToString();
            this.txtArrears.Text = info.Arrears.ToString();
            this.txtBounty.Text = info.Bounty.ToString();
            this.txtCollectionPeriod.Text = info.CollectionPeriod;
            string[] debtObligation = info.DebtObligation.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string str in debtObligation)
            {
                for (int i = 0; i < cheDebtObligation.Items.Count; i++)
                {
                    if (this.cheDebtObligation.Items[i].Value == str)
                    {
                        this.cheDebtObligation.Items[i].Selected = true;
                    }
                }
            }
            this.txtAge.Text = info.Age.ToString();
            this.cheDebtObligation.SelectedValue = info.DebtObligation;
            this.txtDebtorName.Text = info.DebtorName;
            this.txtDebtorReason.Text = info.DebtorReason;
            this.txtDebtorTelpone.Text = info.DebtorTelpone;
            this.txtDebtorType.Text = info.DebtorType;
            this.txtIntroduction.Text = info.Introduction;
            this.radIsConfirm.SelectedValue = info.IsConfirm ? "1" : "0";
            this.radIsInLitigation.SelectedValue = info.IsInLitigation ? "1" : "0";
            this.radIsLitigationed.SelectedValue = info.IsLitigationed ? "1" : "0";
            this.radIsSelfCollection.SelectedValue = info.IsSelfCollection ? "1" : "0";
            this.txtLicenseType.Text = info.LicenseType;
            this.txtRemark.Text = info.Remark;
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            int id = MyConvert.GetInt32(this.hiddID.Value);
            if (id < 0)
            {
                GotoMsgBoxPageForDynamicPage("该债权信息不存在！", 1, "CreditInfoList.aspx");
            }
            CreditInfo info = manager.GetCreditInfoById(id);
            if (info == null)
            {
                GotoMsgBoxPageForDynamicPage("该债权信息不存在！", 1, "CreditInfoList.aspx");
            }
            info.Title = this.txtTitle.Text.Trim();
            info.Age = this.txtAge.Text.Trim();
            string radSelect = this.radSelect.SelectedValue;
            if (radSelect == "草稿")
            {
                info.ApprovaStatus = (int)CreditState.Draft;
            }
            else
            {
                info.ApprovaStatus = (int)CreditState.Null;
            }
            info.AreaId = MyConvert.GetInt32(this.areaid.Value);
            info.Arrears = MyConvert.GetDecimal(this.txtArrears.Text.Trim());
            info.Bounty = MyConvert.GetDecimal(this.txtBounty.Text.Trim());
            info.CollectionPeriod = this.txtCollectionPeriod.Text.Trim();
            info.DebtObligation = this.cheDebtObligation.SelectedValue;
            info.DebtorName = this.txtDebtorName.Text.Trim();
            info.DebtorReason = this.txtDebtorReason.Text.Trim();
            info.DebtorTelpone = this.txtDebtorTelpone.Text.Trim();
            info.DebtorType = this.txtDebtorType.Text.Trim();
            info.Introduction = this.txtIntroduction.Text.Trim();
            info.IsConfirm = MyConvert.GetBoolean(this.radIsConfirm.SelectedValue);
            info.IsInLitigation = MyConvert.GetBoolean(this.radIsInLitigation.SelectedValue);
            info.IsLitigationed = MyConvert.GetBoolean(this.radIsLitigationed.SelectedValue);
            info.IsSelfCollection = MyConvert.GetBoolean(this.radIsSelfCollection.SelectedValue);
            info.LicenseType = this.txtLicenseType.Text.Trim();
            info.Remark = this.txtRemark.Text.Trim();
            info.UserId = MyConvert.GetInt32(userinfo.CompanyId.ToString());
            int result = manager.UpdateCreditInfoByID(info);
            if (result > 0)
            {
                GotoMsgBoxPageForDynamicPage("修改债权信息成功！", 1, "CreditInfoList.aspx");
            }
            else
            {
                GotoMsgBoxPageForDynamicPage("修改债权信息失败！", 1, "CreditInfoList.aspx");
            }
        }
    }
}