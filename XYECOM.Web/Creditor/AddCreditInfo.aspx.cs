using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XYECOM.Model.AMS;
using XYECOM.Core;
using XYECOM.Model;
using XYECOM.Business.AMS;
using XYECOM.Business;
using XYECOM.Web.AppCode;

namespace XYECOM.Web.Creditor
{
    public partial class AddCreditInfo : XYECOM.Web.AppCode.UserCenter.Creditor
    {

        CreditInfoManager credManage = new CreditInfoManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!userinfo.IsReal)
                {
                    this.radSelect.Enabled = false;
                }
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            string goUrl = string.Empty;
            CreditInfo info = new CreditInfo();
            info.Title = this.txtTitle.Text.Trim();
            info.Age = this.txtAge.Text.Trim();
            string radSelect = this.radSelect.SelectedValue;
            if (radSelect == "草稿")
            {
                goUrl = "DraftCreditList.aspx";
                info.ApprovaStatus = (int)CreditState.Draft;
            }
            else
            {
                goUrl = "CreditInfoList.aspx";
                info.ApprovaStatus = (int)CreditState.Null;
            }
            info.AreaId = MyConvert.GetInt32(this.areaid.Value);
            info.Arrears = MyConvert.GetDecimal(this.txtArrears.Text.Trim());
            info.Bounty = MyConvert.GetDecimal(this.txtBounty.Text.Trim());
            info.CollectionPeriod = this.txtCollectionPeriod.Text.Trim();
            info.CreateDate = DateTime.Now;
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
            info.DebtorType = this.rdDebtorType.SelectedValue;
            info.DepartId = MyConvert.GetInt32(userinfo.userid.ToString());
            info.Introduction = this.txtIntroduction.Text.Trim();
            info.IsConfirm = this.radIsConfirm.SelectedValue == "1" ? true : false;
            info.IsInLitigation = this.radIsInLitigation.SelectedValue == "1" ? true : false;
            info.IsLitigationed = this.radIsLitigationed.SelectedValue == "1" ? true : false;
            info.IsSelfCollection = this.radIsSelfCollection.SelectedValue == "1" ? true : false;
            info.LicenseType = this.rdLicenseType.SelectedValue;
            info.Remark = this.txtRemark.Text.Trim();
            info.IsDraft = false;
            info.UserId = MyConvert.GetInt32(userinfo.CompanyId.ToString());
            int credId = 0;
            int result = credManage.InsertCreditInfo(info, out credId);

            string caseType = Request.Form["case"];

            if (caseType == "1")
            {
                //添加选择的档案信息
                RelatedCaseInfoManager relateManage = new RelatedCaseInfoManager();
                string strCase = this.hdgetid.Value;
                string[] cases = strCase.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                relateManage.RelatedInfo(TableInfoType.ZqInfo, credId, userinfo.userid, userinfo.CompanyId, cases);
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

                RelatedCaseInfoManager relateManage = new RelatedCaseInfoManager();

                relateManage.RelatedInfo(TableInfoType.ZqInfo, credId, userinfo.userid, userinfo.CompanyId, infoId);
            }

            if (result > 0)
            {
                this.udCreditInfo.InfoID = credId;
                this.udCreditInfo.Update();
                GotoMsgBoxPageForDynamicPage("添加债权信息成功！", 1, goUrl);
            }
            else
            {
                GotoMsgBoxPageForDynamicPage("添加债权信息失败！", 1, goUrl);
            }
        }
    }
}