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
            info.DebtorType = this.txtDebtorType.Text.Trim();
            info.DepartId =MyConvert.GetInt32(userinfo.userid.ToString());
            info.Introduction = this.txtIntroduction.Text.Trim();
            info.IsConfirm = this.radIsConfirm.SelectedValue == "1" ? true : false;
            info.IsInLitigation = this.radIsInLitigation.SelectedValue == "1" ? true : false;
            info.IsLitigationed = this.radIsLitigationed.SelectedValue == "1" ? true : false;
            info.IsSelfCollection = this.radIsSelfCollection.SelectedValue == "1" ? true : false;
            info.LicenseType = this.txtLicenseType.Text.Trim();
            info.Remark = this.txtRemark.Text.Trim();
            info.UserId = MyConvert.GetInt32(userinfo.CompanyId.ToString());
            int credId = 0;
            int result = credManage.InsertCreditInfo(info,out credId);
            if (result>0)
            {
                this.udCreditInfo.InfoID = credId;
                this.udCreditInfo.Update();
                GotoMsgBoxPageForDynamicPage("添加债权信息成功！", 1, "Index.aspx");
            }
            else
            {
                GotoMsgBoxPageForDynamicPage("添加债权信息失败！", 1, "Index.aspx");
            }

            //添加选择的档案信息
            string strCase = this.hdgetid.Value;
        }
    }
}