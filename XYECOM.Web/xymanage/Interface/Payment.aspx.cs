using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace XYECOM.Web.xymanage.Interface
{
    public partial class Payment : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("interface");

            if (!IsPostBack)
            {
                InitPage();
            }
        }

        private void InitPage()
        {
            XYECOM.Configuration.Payment payment = XYECOM.Configuration.Payment.Instance;

            this.txtPartnerId.Text = payment.AlipayInfo.Partner;
            this.txtEmail.Text = payment.AlipayInfo.Email;
            this.txtSecurityCode.Text = payment.AlipayInfo.SecurityCode;
            this.service.Value = payment.AlipayInfo.Service;
            if (payment.AlipayInfo.IsEnabled)
            {
                this.rdoAlipay.Items[0].Selected = true;
            }
            else
            {
                this.rdoAlipay.Items[1].Selected = true;
                this.pnlAlipay.Enabled = false;
            }

            this.txtV_MId.Text = payment.ChinaBankInfo.V_Mid;
            this.txtKey.Text = payment.ChinaBankInfo.Key;
            if (payment.ChinaBankInfo.IsEnabled)
            {
                this.rdoChinaBank.Items[0].Selected = true;
            }
            else
            {
                this.rdoChinaBank.Items[1].Selected = true;
                this.pnlChinaBank.Enabled = false;
            }

            this.txtMerchant_Id.Text = payment.__99BillInfo.Merchant_Id;
            this.txtMerchant_Key.Text = payment.__99BillInfo.Merchant_Key;
            if (payment.__99BillInfo.IsEnabled)
            {
                this.rdo99Bill.Items[0].Selected = true;
            }
            else
            {
                this.rdo99Bill.Items[1].Selected = true;
                this.pnl99Bill.Enabled = false;
            }
        }

        protected void rdo_SelectedChanged(object sender, EventArgs e)
        {
            RadioButtonList obj = (RadioButtonList)sender;

            if (obj.ID.Equals("rdoAlipay"))
            {
                if (obj.Items[0].Selected == true)
                {
                    this.pnlAlipay.Enabled = true;
                }
                else
                {
                    this.pnlAlipay.Enabled = false;
                }
            }

            if (obj.ID.Equals("rdoChinaBank"))
            {
                if (obj.Items[0].Selected == true)
                {
                    this.pnlChinaBank.Enabled = true;
                }
                else
                {
                    this.pnlChinaBank.Enabled = false;
                }
            }

            if (obj.ID.Equals("rdo99Bill"))
            {
                if (obj.Items[0].Selected == true)
                {
                    this.pnl99Bill.Enabled = true;
                }
                else
                {
                    this.pnl99Bill.Enabled = false;
                }
            }
        }

        private bool CheckForm()
        {
            string err = "[支付宝参数]";
            if (rdoAlipay.Items[0].Selected == true)
            {
                if (this.txtPartnerId.Text.Trim().Equals(""))
                {
                    lblMsg.Text = err + "合作者Id不能为空！";
                    return false;
                }

                if (this.txtEmail.Text.Trim().Equals(""))
                {
                    lblMsg.Text = err + "支付宝帐号不能为空！";
                    return false;
                }

                if (this.txtSecurityCode.Text.Trim().Equals(""))
                {
                    lblMsg.Text = err + "安全校验码不能为空！";
                    return false;
                }
            }

            err = "[网银在线参数]";

            if (rdoChinaBank.Items[0].Selected == true)
            {
                if (this.txtV_MId.Text.Trim().Equals(""))
                {
                    lblMsg.Text = err +"商户编号不能空！";
                    return false;
                }

                if (this.txtKey.Text.Trim().Equals(""))
                {
                    lblMsg.Text = err +"密钥不能为空！";
                    return false;
                }
            }

            err = "[快钱参数]";

            if (rdo99Bill.Items[0].Selected == true)
            {
                if (this.txtMerchant_Id.Text.Trim().Equals(""))
                {
                    lblMsg.Text = err + "商户编号不能空！";
                    return false;
                }

                if (this.txtMerchant_Key.Text.Trim().Equals(""))
                {
                    lblMsg.Text = err + "商户密钥不能为空！";
                    return false;
                }
            }

            lblMsg.Text = "";
            return true;

        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (!CheckForm()) return;

            XYECOM.Configuration.Payment payment = XYECOM.Configuration.Payment.Instance;
            if (rdoAlipay.Items[0].Selected == true)
                payment.AlipayInfo.IsEnabled = true;
            else
                payment.AlipayInfo.IsEnabled = false;

            payment.AlipayInfo.Partner = this.txtPartnerId.Text.Trim();
            payment.AlipayInfo.Email = this.txtEmail.Text.Trim();
            payment.AlipayInfo.SecurityCode = this.txtSecurityCode.Text.Trim();
            payment.AlipayInfo.Service = this.service.Value;

            if (rdoChinaBank.Items[0].Selected == true)
                payment.ChinaBankInfo.IsEnabled = true;
            else
                payment.ChinaBankInfo.IsEnabled = false;
            payment.ChinaBankInfo.V_Mid = this.txtV_MId.Text.Trim();
            payment.ChinaBankInfo.Key = this.txtKey.Text.Trim();

            if (rdo99Bill.Items[0].Selected == true)
                payment.__99BillInfo.IsEnabled = true;
            else
                payment.__99BillInfo.IsEnabled = false;

            payment.__99BillInfo.Merchant_Id = this.txtMerchant_Id.Text.Trim();
            payment.__99BillInfo.Merchant_Key = this.txtMerchant_Key.Text.Trim();

            bool result = payment.Update();

            if (result)
                lblMsg.Text = "设置成功！";
            else
                lblMsg.Text = "设置失败,请检查<Config>目录写权限！";
        }
    }
}
