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

namespace XYECOM.Web.xymanage.Global
{
    public partial class CustomConfigField : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("customconfigfield");
        }

        protected override void BindData()
        {
            DataTable dt = XYECOM.Configuration.CustomConfigField.Instance.ToTable;

            this.gvlist.DataSource = dt;
            this.gvlist.DataBind();
        }

        protected void lnkDel_Click(object sender, EventArgs e)
        {
            string keys = "";
            foreach (GridViewRow row in this.gvlist.Rows)
            {
                if (((CheckBox)(row.FindControl("chkExport"))).Checked == true)
                    keys += "," + this.gvlist.DataKeys[row.DataItemIndex].Value.ToString();
            }

            if (keys.IndexOf(",") == 0)
                keys = keys.Substring(1);

            if (!XYECOM.Configuration.CustomConfigField.Instance.Deletes(keys))
            {
                Alert("É¾³ýÊ§°Ü,Çë¼ì²é/Config/Ä¿Â¼¿ÉÐ´È¨ÏÞ£¡");
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
