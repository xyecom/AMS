using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XYECOM.Model.AMS;
using XYECOM.Core;
using XYECOM.Model;
using XYECOM.Business;
using XYECOM.Web.AppCode;

namespace XYECOM.Web.Creditor
{
    public partial class UpdateCreditInfo : XYECOM.Web.AppCode.UserCenter.Creditor
    {
        XYECOM.Business.AMS.CreditInfoManager manager = new Business.AMS.CreditInfoManager();
        RelatedCaseInfoManager relateManage = new RelatedCaseInfoManager();

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

                if (!userinfo.IsReal)
                {
                    this.radSelect.Enabled = false;
                }
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
            this.udCreditInfo.InfoID = info.CreditId;


            hdgetid.Value = relateManage.GetSelectCaseIds(info.CreditId, TableInfoType.ZqInfo);
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
            string debtObligation = string.Empty;
            for (int i = 0; i < this.cheDebtObligation.Items.Count; i++)
            {
                if (this.cheDebtObligation.Items[i].Selected == true)
                {
                    debtObligation += this.cheDebtObligation.Items[i].Value + ",";
                }
            }
            info.DebtObligation = debtObligation;
            info.DebtorName = this.txtDebtorName.Text.Trim();
            info.DebtorReason = this.txtDebtorReason.Text.Trim();
            info.DebtorTelpone = this.txtDebtorTelpone.Text.Trim();
            info.DebtorType = this.txtDebtorType.Text.Trim();
            info.Introduction = this.txtIntroduction.Text.Trim();
            info.IsConfirm = this.radIsConfirm.SelectedValue == "1" ? true : false;
            info.IsInLitigation = this.radIsInLitigation.SelectedValue == "1" ? true : false;
            info.IsLitigationed = this.radIsLitigationed.SelectedValue == "1" ? true : false;
            info.IsSelfCollection = this.radIsSelfCollection.SelectedValue == "1" ? true : false;
            info.LicenseType = this.txtLicenseType.Text.Trim();
            info.Remark = this.txtRemark.Text.Trim();
            info.UserId = MyConvert.GetInt32(userinfo.CompanyId.ToString());
            int result = manager.UpdateCreditInfoByID(info);

            relateManage.DeleteRelatedCaseInfo(info.CreditId, TableInfoType.ZqInfo);

            string caseType = Request.Form["case"];

            if (caseType == "1")
            {
                //添加选择的档案信息                
                string strCase = this.hdgetid.Value;
                string[] cases = strCase.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                relateManage.RelatedInfo(TableInfoType.ZqInfo, info.CreditId, userinfo.userid, userinfo.CompanyId, cases);
            }

            if (caseType == "0")
            {
                Business.CaseManager caseManager = new Business.CaseManager();

                string filePath = CaseUploadManager.UpLoadFile(userinfo.CompanyId, userinfo.userid, 0);

                CaseInfo caseInfo = new CaseInfo();
                caseInfo.CaseName = info.Title;
                caseInfo.CaseTypeId = 0;
                caseInfo.CaseTypeName = "默认分类";
                caseInfo.CompanyId = userinfo.CompanyId;
                caseInfo.CompanyName = userinfo.CompanyName;
                caseInfo.CreateDate = DateTime.Now;
                caseInfo.Description = info.Introduction;
                caseInfo.FilePath = filePath;
                caseInfo.PartId = userinfo.userid;
                caseInfo.PartName = userinfo.LayerName;
                int infoId = 0;

                caseManager.Insert(caseInfo, out infoId);

                relateManage.RelatedInfo(TableInfoType.ZqInfo, info.CreditId, userinfo.userid, userinfo.CompanyId, infoId);
            }



            if (result > 0)
            {
                this.udCreditInfo.InfoID = info.CreditId;
                this.udCreditInfo.Update();
                GotoMsgBoxPageForDynamicPage("修改债权信息成功！", 1, "CreditInfoList.aspx");
            }
            else
            {
                GotoMsgBoxPageForDynamicPage("修改债权信息失败！", 1, "CreditInfoList.aspx");
            }
        }
    }
}