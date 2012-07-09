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

namespace XYECOM.Web.xymanage.Basic
{
    public partial class SecuritySet : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("basic");
            if (!IsPostBack)
            {
                PageInit();
            }
        }

        private void PageInit()
        {
            XYECOM.Configuration.Security securityInfo = XYECOM.Configuration.Security.Instance;

            if (securityInfo.IsEnabledValidateCode(XYECOM.Configuration.ValidateCodeItem.Register))
                this.chkIsVCodeForRegister.Checked = true;

            if (securityInfo.IsEnabledValidateCode(XYECOM.Configuration.ValidateCodeItem.Login))
                this.chkIsVCodeForUserLogin.Checked = true;

            if (securityInfo.IsEnabledValidateCode(XYECOM.Configuration.ValidateCodeItem.Comment))
                this.chkIsVCodeForNewsComment.Checked = true;

            if (securityInfo.IsEnabledValidateCode(XYECOM.Configuration.ValidateCodeItem.Message))
                this.chkIsVCodeForMessage.Checked = true;

            if (securityInfo.IsEnabledValidateCode(XYECOM.Configuration.ValidateCodeItem.MakeTheOrder))
                this.chkIsVCodeForOrder.Checked = true;

            if (securityInfo.IsEnabledValidateCode(XYECOM.Configuration.ValidateCodeItem.QuickPost))
                this.chkIsVCodeForQuickPost.Checked = true;


            txtForbidIP.Text = securityInfo.ForbidIP;

            txtVCodeLength.Text = securityInfo.VCodeLength.ToString();
            ddlVCodeTortuosity.Text = securityInfo.VCodeTortuosity.ToString();
            txtVCodeCharPool.Text = securityInfo.VCodeCharPool;

        }

        protected void btnok_Click(object sender, EventArgs e)
        {
            XYECOM.Configuration.Security securityInfo = XYECOM.Configuration.Security.Instance;

            securityInfo.SetValidateCodeIsEnabled(XYECOM.Configuration.ValidateCodeItem.Register, this.chkIsVCodeForRegister.Checked);

            securityInfo.SetValidateCodeIsEnabled(XYECOM.Configuration.ValidateCodeItem.Login, this.chkIsVCodeForUserLogin.Checked);

            securityInfo.SetValidateCodeIsEnabled(XYECOM.Configuration.ValidateCodeItem.Comment, this.chkIsVCodeForNewsComment.Checked);

            securityInfo.SetValidateCodeIsEnabled(XYECOM.Configuration.ValidateCodeItem.Message, this.chkIsVCodeForMessage.Checked);

            securityInfo.SetValidateCodeIsEnabled(XYECOM.Configuration.ValidateCodeItem.MakeTheOrder, this.chkIsVCodeForOrder.Checked);

            securityInfo.SetValidateCodeIsEnabled(XYECOM.Configuration.ValidateCodeItem.QuickPost, this.chkIsVCodeForQuickPost.Checked);

            securityInfo.ForbidIP = txtForbidIP.Text.Trim();

            int vCodeLength = Core.MyConvert.GetInt32(txtVCodeLength.Text);

            if (vCodeLength < 2 || vCodeLength > 15) vCodeLength = 6;

            securityInfo.VCodeLength = vCodeLength;

            int vCodeTortuosity = Core.MyConvert.GetInt32(ddlVCodeTortuosity.SelectedValue);

            if(vCodeTortuosity<1 || vCodeTortuosity >5 )vCodeTortuosity =3;

            securityInfo.VCodeTortuosity = vCodeTortuosity;

            string vCodeCharPool = txtVCodeCharPool.Text.Trim();

            vCodeCharPool = vCodeCharPool.Replace("，",",").Replace(",,",",");

            if (vCodeCharPool.StartsWith(",")) vCodeCharPool = vCodeCharPool.Substring(1);

            if (vCodeCharPool.EndsWith(",")) vCodeCharPool = vCodeCharPool.Substring(0, vCodeCharPool.Length-1);

            if (vCodeCharPool.Equals("")) vCodeCharPool = "2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,j,k,m,n,p,q,r,s,t,u,v,w,x,y,z,A,B,C,D,E,F,G,H,J,K,L,M,N,P,Q,R,S,T,U,V,W,X,Y,Z";

            securityInfo.VCodeCharPool = vCodeCharPool;

            if (!securityInfo.Update())
                Alert("设置失败，请检查/Config/目录可写属性！");
            else
                Alert("设置成功！");
        }
    }
}
