using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XYECOM.Web.Server
{
    public partial class CertificateAdd : XYECOM.Web.AppCode.UserCenter.Server
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        XYECOM.Business.Certificate cerBLL = new XYECOM.Business.Certificate();
        protected override void BindData()
        {
            long infoId = XYECOM.Core.XYRequest.GetQueryInt64("ce_id");

            this.hidInfoId.Value = infoId.ToString();

            this.reason.Visible = false;
            this.advice.Visible = false;

            Model.CertificateInfo mce = cerBLL.GetItem(infoId);
            //获取证书信息
            if (mce != null)
            {

                this.UploadImage1.InfoID = infoId;

                this.txtname.Text = mce.CE_Name;
                this.txtorgan.Text = mce.CE_Organ;
                this.txtbegin.Text = mce.CE_Begin.ToString("yyyy-MM-dd");
                this.txtupto.Text = mce.CE_Upto.ToString("yyyy-MM-dd");
                this.txttype.SelectedValue = mce.CE_Type.ToString();

                if (mce.AuditingState != XYECOM.Model.AuditingState.Passed)
                {
                    //获取审核信息
                    XYECOM.Model.AuditingInfo audInfo = new XYECOM.Business.Auditing().GetItem(mce.CE_ID.ToString(), "u_Certificate");

                    if (audInfo != null)
                    {
                        this.reason.Visible = true;
                        this.advice.Visible = true;

                        this.txtCausation.InnerHtml = audInfo.A_Reason;
                        this.txtAdvice.InnerHtml = audInfo.A_Advice;
                    }
                }
            }
            else
            {
                this.UploadImage1.InfoID = 0;
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            long infoId = 0;
            infoId = XYECOM.Core.MyConvert.GetInt64(this.hidInfoId.Value);
            XYECOM.Model.CertificateInfo car = null;
            if (infoId > 0)
            {
                car = cerBLL.GetItem(infoId);
            }
            else
            {
                car = new XYECOM.Model.CertificateInfo();
            }


            car.U_ID = userinfo.CompanyId;
            car.CE_Name = txtname.Text;
            car.CE_Organ = txtorgan.Text;
            car.CE_Type = Core.MyConvert.GetInt32(txttype.SelectedValue);
            try
            {
                car.CE_Upto = Convert.ToDateTime(Request.Form["ctl00$ctl00$content$ContentPlaceHolder2$txtupto"]);
            }
            catch
            {
                car.CE_Upto = DateTime.Now.ToLocalTime();
            }
            try
            {
                car.CE_Begin = Convert.ToDateTime(Request.Form["ctl00$ctl00$content$ContentPlaceHolder2$txtbegin"]);
            }
            catch
            {
                car.CE_Begin = DateTime.Now.ToLocalTime();
            }
            car.CE_Isopen = true;
            car.AuditingState = Model.AuditingState.Null;

            if (car.CE_ID > 0)
            {
                cerBLL.Update(car);
            }
            else
            {
                int i = cerBLL.Insert(car, out infoId);
                this.UploadImage1.InfoID = infoId;
            }

            this.UploadImage1.Update();

            Response.Redirect("/Server/CertificateList.aspx");
        }
    }
}