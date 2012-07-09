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

namespace XYECOM.Web.Common
{
    public partial class XYOutInvoke : XYECOM.Page.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ip = XYECOM.Core.XYRequest.GetIP();

            //IP判断
            if (XYECOM.Configuration.Security.Instance._ForbidIP.Contains(ip))
            {
                Response.Write(ip + " 被禁止访问");
                return;
            }

            //this.content = ct;

            string lblName = Request.QueryString["lblName"];
            string res = "";
            if (string.IsNullOrEmpty(lblName))
            {
                res = "<参数错误>";
            }
            else
            {
                string lbl = XYECOM.Core.Utils.JSunescape(lblName);
                res = XYECOMCreateHTML("xy_" + lbl);
            }            
            res = res.Replace("\"", "'");
            res = res.Replace("\r\n", "");
            //Response.Write("<script language=\"javascript\" type=\"text/javascript\">");
            Response.Write("document.write(\"" + res + "\")");
            //Response.Write("</script>");
        }
    }
}
