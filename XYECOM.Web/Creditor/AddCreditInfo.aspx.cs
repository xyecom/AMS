using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XYECOM.Model.AMS;
using XYECOM.Core;
using XYECOM.Model;
using XYECOM.Business.AMS;

namespace XYECOM.Web.Creditor
{
    public partial class AddCreditInfo : XYECOM.Web.AppCode.UserCenter.Creditor
    {

        CreditInfoManager credManage = new CreditInfoManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            CreditInfo info = new CreditInfo();
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
            info.Arrears =MyConvert.GetDecimal(this.txtArrears.Text.Trim());
            info.Bounty = MyConvert.GetDecimal(this.txtBounty.Text.Trim());
            info.CollectionPeriod = this.txtCollectionPeriod.Text.Trim();
            info.CreateDate = DateTime.Now;
            info.DebtObligation = this.cheDebtObligation.SelectedValue;
            info.DebtorName = this.txtDebtorName.Text.Trim();
            info.DebtorReason = this.txtDebtorReason.Text.Trim();
            info.DebtorTelpone = this.txtDebtorTelpone.Text.Trim();
            info.DebtorType = this.txtDebtorType.Text.Trim();
            info.DepartId = userinfo.userid;
            info.Introduction = this.txtIntroduction.Text.Trim();
            info.IsConfirm = MyConvert.GetBoolean(this.radIsConfirm.SelectedValue);
            info.IsCreditEvaluation = false;
            info.IsInLitigation = MyConvert.GetBoolean(this.radIsInLitigation.SelectedValue);
            info.IsLitigationed = MyConvert.GetBoolean(this.radIsLitigationed.SelectedValue);
            info.IsSelfCollection = MyConvert.GetBoolean(this.radIsSelfCollection.SelectedValue);
            info.IsServerEvaluation = false;
            info.LicenseType = this.txtLicenseType.Text.Trim();
            info.Remark = this.txtRemark.Text.Trim();
            info.UserId = MyConvert.GetInt32(userinfo.CompanyId.ToString());
            bool isok = credManage.InsertCreditInfo(info);
            if (isok)
            {
                GotoMsgBoxPageForDynamicPage("添加债权信息成功！", 1, "Index.aspx");
            }
            else
            {
                Alert("添加债权信息失败！");
            }
        }
    }
}