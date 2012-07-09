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
using XYECOM.Core;

namespace XYECOM.Web.xymanage.LabelManage
{
    public partial class ClassLabelList : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            CheckRole("label");
        }

        protected override void BindData()
        {
            this.page1.PageSize = 20;
            this.btndelete.Attributes.Add("onclick", "javascript:return del();");

            //设置编辑或查看后要返回当前页面的状态
            backURL = XYECOM.Core.Utils.JSEscape("ClassLabelList.aspx?page=" + page1.CurPage.ToString());

            int totalRecord = 0;

            DataTable dt = XYECOM.Business.Utils.GetPaginationData("XY_ClassLabel", "ID", "ID,Name,CNName", "ID desc","", this.page1.PageSize, this.page1.CurPage, out totalRecord);

            this.page1.RecTotal = totalRecord;

            if (dt.Rows.Count > 0)
            {
                this.gvClassLabel.DataSource = dt;
                this.gvClassLabel.DataBind();
            }
            else
            {
                this.gvClassLabel.DataBind();
                this.lblMessage.Text = "没有相关信息";
            }
        }

        protected void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               e.Row.Attributes.Add("onmouseover", "javascript:__XY_GV_Row_MouseOver(this)");
               e.Row.Attributes.Add("onmouseout", "javascript:__XY_GV_Row_MouseOut(this);");

               e.Row.Cells[2].Text = "{" + e.Row.Cells[2].Text + "}";
            }
        }

        protected void Page1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Business.ClassLabel DAL = new XYECOM.Business.ClassLabel();

            foreach (GridViewRow row in this.gvClassLabel.Rows)
            {
                if (((CheckBox)(row.FindControl("chkExport"))).Checked == true)
                {
                    //ids += "," + this.gvList.DataKeys[row.DataItemIndex].Value.ToString();
                    DAL.Delete(Convert.ToInt32(gvClassLabel.DataKeys[row.DataItemIndex].Value.ToString()));
                }
            }
            Alert("操作成功！", "ClassLabelList.aspx");
        }
    }
}
