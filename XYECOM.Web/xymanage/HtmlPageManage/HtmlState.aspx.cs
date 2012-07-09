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

namespace XYECOM.Web.xymanage.HtmlPageManage
{
    public partial class HtmlState : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("htmlpage");

            if (Html.HtmlManage.TaskList.Count > 0)            
            {
                string strscript = "<script language=\"javascript\" type=\"text/javascript\">";
                strscript += "var html=[";
                for (int i = 0; i < Html.HtmlManage.TaskList.Count; i++)
                {
                    Html.HtmlInfo info = Html.HtmlManage.TaskList[i];
                    strscript += 0 == i ? "" : ",";
                    strscript += "{index:" + info.PageIndex + ",name:'" + info.PageName + "',isdel:" + info.IsDel.ToString().ToLower() + "}";
                }
                strscript += "];\n";
                strscript += "SetHtmlState(html);\n";
                strscript += "</script>";
                litscript.Text = strscript;
            }
        }
    }
}
