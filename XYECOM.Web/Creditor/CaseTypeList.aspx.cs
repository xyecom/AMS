using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace XYECOM.Web.Creditor
{
    public partial class CaseTypeList : XYECOM.Web.AppCode.UserCenter.Creditor
    {
        XYECOM.Business.CompanyProductTypeManager pt = new XYECOM.Business.CompanyProductTypeManager();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void BindData()
        {
            string sql = string.Empty;

            if (!userinfo.IsPrimary)
            {
                sql = @"select id,ptName,userid,remark,u.LayerName from XY_CompanyProductType t inner join u_user u on t.userid=u.u_id where t.userid=" + userinfo.userid;
            }
            else
            {
                sql = @"select id,ptName,userid,remark,ISNULL(u.LayerName,'主账户') LayerName  from XY_CompanyProductType t inner join u_user u
on t.userid=u.u_id where t.ParentId=" + userinfo.userid;
            }

            DataTable table = XYECOM.Core.Data.SqlHelper.ExecuteTable(sql);
            this.GridView1.DataSource = table;
            this.GridView1.DataBind();
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {

            LinkButton btn = sender as LinkButton;

            int res = pt.DeleteByIds(btn.CommandArgument);

            if (res > 0)
            {
                BindData();
            }
        }
    }
}