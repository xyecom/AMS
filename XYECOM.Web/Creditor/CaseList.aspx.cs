using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace XYECOM.Web.Creditor
{
    public partial class CaseList : XYECOM.Web.AppCode.UserCenter.Creditor
    {
        Business.CaseManager caseManager = new Business.CaseManager();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void BindData()
        {
            string sql = string.Empty;

            int typeId = XYECOM.Core.XYRequest.GetQueryInt("ID", 0);


            if (userinfo.IsPrimary)
            {
                sql = @"select * from CaseInfo where CompanyId=" + userinfo.userid;
            }
            else
            {
                sql = @"select * from CaseInfo where partid=" + userinfo.userid;
            }


            if (typeId > 0)
            {
                sql += " and CaseTypeID=" + typeId;
            }

            DataTable table = Core.Data.SqlHelper.ExecuteTable(sql);

            this.GridView1.DataSource = table;
            this.GridView1.DataBind();
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
    }
}