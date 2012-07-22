using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using XYECOM.Web.AppCode;

namespace XYECOM.Web.Creditor
{
    public partial class UploadCase : XYECOM.Web.AppCode.UserCenter.Creditor
    {
        Business.CaseManager caseManager = new Business.CaseManager();
        XYECOM.Business.CompanyProductTypeManager pt = new XYECOM.Business.CompanyProductTypeManager();
        Model.CaseInfo info = null;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void BindData()
        {
            int infoid = XYECOM.Core.XYRequest.GetQueryInt("id", 0);

            if (infoid > 0)
            {
                info = caseManager.GetItem(infoid);
            }
            if (info != null)
            {
                this.txtCaseName.Text = info.CaseName;
                this.txtDescription.Text = info.Description;
                this.ddlType.SelectedValue = info.CaseTypeId.ToString();
                this.hidInfoId.Value = infoid.ToString();
                this.divfile.Visible = false;
                this.ddlType.Visible = false;
            }
            else
            {
                DataTable table = pt.GetListByUserId(userinfo.userid);
                this.ddlType.DataSource = table;
                this.ddlType.DataTextField = "PtName";
                this.ddlType.DataValueField = "Id";
                this.ddlType.DataBind();
                this.ddlType.Items.Insert(0, new ListItem("默认分类", "0"));
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string strInfoId = this.hidInfoId.Value;
            int infoId = 0;
            if (!string.IsNullOrEmpty(strInfoId))
            {
                infoId = XYECOM.Core.MyConvert.GetInt32(strInfoId);
            }

            if (infoId > 0)
            {
                info = caseManager.GetItem(infoId);
            }

            if (info == null)
            {
                info = new Model.CaseInfo();
            }

            info.CaseName = this.txtCaseName.Text.Trim();
            info.Description = this.txtDescription.Text.Trim();

            if (info.Id > 0)
            {
                caseManager.Update(info);
            }
            else
            {
                string selType = this.ddlType.SelectedValue;
                if (!string.IsNullOrEmpty(selType))
                {
                    info.CaseTypeName = ddlType.SelectedItem.Text;
                    info.CaseTypeId = XYECOM.Core.MyConvert.GetInt32(selType);
                }
                else
                {
                    info.CaseTypeId = 0;
                    info.CaseTypeName = "默认分类";
                }
                string filePath = CaseUploadManager.UpLoadFile(userinfo.CompanyId, userinfo.userid, info.CaseTypeId);
                if (!string.IsNullOrEmpty(filePath))
                {
                    int id = 0;
                    info.PartId = userinfo.userid;
                    info.CompanyId = userinfo.CompanyId;
                    info.PartName = userinfo.LayerName;
                    info.CompanyName = userinfo.CompanyName;
                    info.CreateDate = DateTime.Now;
                    info.FilePath = filePath;
                    caseManager.Insert(info, out id);
                }
                else
                {
                    GotoMsgBoxPageForDynamicPage("档案文件上传失败！", 1, "/Creditor/CaseList.aspx");
                    return;
                }
            }

            Response.Redirect("/Creditor/CaseList.aspx");
        }
    }
}