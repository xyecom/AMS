using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace XYECOM.Web.xymanage.Interface
{
    public partial class JsInterface : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("interface");
        }

        protected override void BindData()
        {
            DataTable dt = XYECOM.Configuration.JsInterface.Instance.ToTable;

            this.gvlist.DataSource = dt;
            this.gvlist.DataBind();
        }

        protected void lnkDel_Click(object sender, EventArgs e)
        {
            string keys = "";
            foreach (GridViewRow row in this.gvlist.Rows)
            {                
                HtmlInputCheckBox ck = row.FindControl("chkExport") as HtmlInputCheckBox;
                if (ck != null && ck.Checked) 
                {
                    keys += "," + ck.Value;
                }                    
            }

            if (keys.IndexOf(",") == 0)
                keys = keys.Substring(1);

            if (!XYECOM.Configuration.JsInterface.Instance.Deletes(keys))
            {
                Alert("删除失败,请检查/Config/目录可写权限！");
            }

            BindData();
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
