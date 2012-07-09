using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace XYECOM.Web.xymanage.Basic
{
    public partial class CreaditLeavlList : XYECOM.Web.BasePage.ManagePage
    {
        protected XYECOM.Business.CreditLeavlManager creditLeavlManager = new Business.CreditLeavlManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void BindData()
        {
            this.lblMessage.Text = string.Empty;
            DataTable table = creditLeavlManager.Select();
            if (table.Rows.Count < 1)
            {
                this.lblMessage.Text = "没有数据";
            }
            else
            {
                this.gvlist.DataSource = table;
                this.gvlist.DataBind();
            }
        }

        protected string GetPoint(object down, object up)
        {
            if (up.ToString() != "-1")
            {
                return string.Format("{0}～{1}", down, up);
            }

            return string.Format(">={0}", down);
        }

        protected void ibtnDel_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = sender as ImageButton;
            if (ibtn == null) return;
            if (string.IsNullOrEmpty(ibtn.CommandArgument)) return;

            int infoId = XYECOM.Core.MyConvert.GetInt32(ibtn.CommandArgument);

            if (infoId < 1) return;
            //调用业务方法，删除这个信用等级，同时更新最后一个信用等级的UpPoint为-1
            creditLeavlManager.Delete(infoId);
            Model.CreditLeavlInfo info = creditLeavlManager.GetLastItem();
            info.UpPoint = -1;
            creditLeavlManager.Update(info);

            Response.Redirect("CreaditLeavlList.aspx");
        }

        protected void gvlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "javascript:__XY_GV_Row_MouseOver(this)");
                e.Row.Attributes.Add("onmouseout", "javascript:__XY_GV_Row_MouseOut(this);");
            }
        }
    }
}