using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using XYECOM.Web.AppCode;

namespace XYECOM.Web.Creditor
{
    public partial class CaseList : XYECOM.Web.AppCode.UserCenter.Creditor
    {
        Business.CaseManager caseManager = new Business.CaseManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindParts();
            }
        }

        void BindParts()
        {
            this.ddlPart.Items.Clear();
            if (userinfo.UserType == Model.UserType.CreditorEnterprise)
            {
                if (userinfo.IsPrimary)
                {
                    DataTable table = Utitl.GetSubUsers(userinfo.userid);
                    this.ddlPart.DataTextField = "LayerName";
                    this.ddlPart.DataValueField = "U_ID";
                    this.ddlPart.DataSource = table;
                    this.ddlPart.DataBind();

                    this.ddlPart.Items.Insert(0, new ListItem("请选择…", ""));
                }
                else
                {
                    this.ddlPart.Items.Insert(0, new ListItem(userinfo.LayerName, userinfo.userid.ToString()));
                }
            }
            else if (userinfo.UserType == Model.UserType.CreditorIndividual)
            {
                this.ddlPart.Items.Insert(0, new ListItem("请选择…", ""));
                this.ddlPart.Enabled = false;
            }
        }

        protected override void BindData()
        {
            string sql = string.Empty;

            int typeId = XYECOM.Core.XYRequest.GetQueryInt("ID", 0);

            string selpart = this.ddlPart.SelectedValue;
            string key = this.txtKey.Value.Trim();

            if (userinfo.IsPrimary)
            {
                sql = @"select * from CaseInfo where CompanyId=" + userinfo.userid;

                if (!string.IsNullOrEmpty(selpart))
                {
                    sql += " and partid=" + selpart;
                }
            }
            else
            {
                sql = @"select * from CaseInfo where partid=" + userinfo.userid;
            }

            if (!string.IsNullOrEmpty(key) && key != "请输入关键字")
            {
                sql += " and CaseName like '%" + key + "%'";
            }

            if (typeId > 0)
            {
                sql += " and CaseTypeID=" + typeId;
            }

            DataTable table = Core.Data.SqlHelper.ExecuteTable(sql);

            this.rptList.DataSource = table;
            this.rptList.DataBind();
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            if (btn == null) return;

            string[] data = btn.CommandArgument.Split(new char[] { '|' });

            if (data.Length != 2) return;
            //判断是否有 抵债或债权信息使用此档案
            int result = caseManager.Delete(data[0]);
            if (result > 0)
            {
                string physicalPath = Server.MapPath(data[1]);

                if (File.Exists(physicalPath))
                {
                    File.Delete(physicalPath);
                }
            }

            BindData();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void Page1_PageChanged(object sender, System.EventArgs e)
        {
            BindData();
        }
    }
}