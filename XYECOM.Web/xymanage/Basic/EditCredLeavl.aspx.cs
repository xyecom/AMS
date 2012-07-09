using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XYECOM.Web.xymanage.Basic
{
    public partial class EditCredLeavl : XYECOM.Web.BasePage.ManagePage
    {
        protected XYECOM.Business.CreditLeavlManager creditLeavlManager = new Business.CreditLeavlManager();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void BindData()
        {
            XYECOM.Model.CreditLeavlInfo info = creditLeavlManager.GetLastItem();
            string strInfoId = XYECOM.Core.XYRequest.GetQueryString("type").ToLower();
            if (!string.IsNullOrEmpty(strInfoId) && strInfoId == "modify" && info != null)
            {
                //修改
                this.hidType.Value = "modfiy";
                this.txtDownPoint.Text = info.DownPoint.ToString();
                this.txtImagePath.Text = info.ImagePath;
                this.txtLeavlName.Text = info.LeavlName;
                this.hidDownPoint.Value = (info.DownPoint + 1).ToString();
            }
            else
            {
                //新增
                this.hidType.Value = "add";
                if (info == null)
                {
                    this.hidDownPoint.Value = "1";
                }
                else 
                {
                    this.hidDownPoint.Value = (info.DownPoint + 1).ToString();
                    this.txtDownPoint.Text = (info.DownPoint + 1).ToString();
                }                
            }

            lblMinValue.Text = this.hidDownPoint.Value;
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            string type = this.hidType.Value;

            int downPoint = XYECOM.Core.MyConvert.GetInt32(this.txtDownPoint.Text);
            Model.CreditLeavlInfo lastInfo = creditLeavlManager.GetLastItem();
            
            if (type == "add")
            {
                Model.CreditLeavlInfo info = new Model.CreditLeavlInfo();    

                if (lastInfo == null)
                {
                    info.Leavl = 1;
                }
                else 
                {
                    info.Leavl = lastInfo.Leavl + 1;
                    lastInfo.UpPoint = downPoint - 1;
                }

                info.LeavlName = this.txtLeavlName.Text;
                info.ImagePath = this.txtImagePath.Text;
                info.DownPoint = downPoint;
                info.UpPoint = -1;
                creditLeavlManager.Insert(info);
            }
            else 
            {
                lastInfo = creditLeavlManager.GetLastItem();

                lastInfo.LeavlName = this.txtLeavlName.Text;
                lastInfo.ImagePath = this.txtImagePath.Text;
                lastInfo.UpPoint = -1;
                lastInfo.DownPoint = downPoint;
            }

            creditLeavlManager.Update(lastInfo);

            Response.Redirect("CreaditLeavlList.aspx");
        }
    }
}