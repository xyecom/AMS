using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace XYECOM.Web.Server
{
    public partial class CertificateList : XYECOM.Web.AppCode.UserCenter.Server
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string GetTypeName(object typeId)
        {
            string type = typeId.ToString();
            string result = string.Empty;

            switch (type)
            {
                case "1":
                    result = "营业执照";
                    break;
                case "2":
                    result = "税务登记类";
                    break;
                case "3":
                    result = "经营许可类";
                    break;

                case "4":
                default:
                    result = "其它类";
                    break;
            }

            return result;
        }

        protected string AuditingState(object adstate)
        {
            string state = adstate.ToString();
            if (state == "1")
            {
                return "已审核";
            }
            if (state == "0")
            {
                return "未通过审核";
            }
            if (state == "")
            {
                return "审核中...";
            }
            return string.Empty;
        }

        protected override void BindData()
        {
            string strwhere = " U_ID=" + userinfo.userid;

            if (this.txttype.SelectedValue != "")
            {
                strwhere += " and CE_Type=" + this.txttype.SelectedValue;
            }

            base.pageinfo.PageSize = 10;

            this.pageinfo.PageIndex = XYECOM.Core.XYRequest.GetInt("PageIndex", 1);

            int totalRecord = 0;

            DataTable table = XYECOM.Business.Utils.GetPaginationData("XYV_Certificate ", "CE_ID", "*", "CE_Addtime desc", strwhere, 100, 1, out totalRecord);
            this.Repeater1.DataSource = table;
            this.Repeater1.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }

        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            XYECOM.Business.Certificate Ber = new XYECOM.Business.Certificate();

            Ber.Deletes((sender as LinkButton).CommandArgument);

            BindData();
        }
    }
}