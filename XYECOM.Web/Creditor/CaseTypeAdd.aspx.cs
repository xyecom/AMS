using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XYECOM.Web.Creditor
{
    public partial class CaseTypeAdd : XYECOM.Web.AppCode.UserCenter.Creditor
    {
        XYECOM.Business.CompanyProductTypeManager pt = new XYECOM.Business.CompanyProductTypeManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        XYECOM.Model.CompanyProductTypeInfo ept = null;

        protected override void BindData()
        {
            //模块名称
            //type:0添加 / type:1编辑
            int infoId = XYECOM.Core.XYRequest.GetQueryInt("id", 0);

            if (infoId > 0)
            {
                ept = pt.GetItem(infoId);
            }

            if (ept != null)
            {
                this.hidInfoId.Value = ept.Id.ToString();
                this.txtName.Text = ept.PtName;
                this.txtRemark.Text = ept.Reamrk;
            }
        }

        #region 保存
        protected void btnok_Click(object sender, EventArgs e)
        {
            string strId = this.hidInfoId.Value;
            int infoId = 0;

            if (!string.IsNullOrEmpty(strId))
            {
                infoId = XYECOM.Core.MyConvert.GetInt32(strId);
            }

            if (infoId > 0)
            {
                ept = pt.GetItem(infoId);
            }

            if (ept == null)
            {
                ept = new Model.CompanyProductTypeInfo();
            }

            ept.PtName = this.txtName.Text.Trim();
            ept.Reamrk = this.txtRemark.Text.Trim();
            ept.UserId = userinfo.userid;
            ept.CompanyId = userinfo.CompanyId;
            if (ept.Id > 0)
            {
                pt.Update(ept);
            }
            else
            {
                pt.Insert(ept);
            }

            Response.Redirect("/Creditor/CaseTypeList.aspx");
        }

        #endregion
    }
}