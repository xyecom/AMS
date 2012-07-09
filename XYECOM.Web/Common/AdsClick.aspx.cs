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

namespace XYECOM.Web.Common
{
    public partial class AdsClick : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string IP = XYECOM.Core.XYRequest.GetIP();

            long adsId =XYECOM.Core.MyConvert.GetInt64(XYECOM.Core.XYRequest.GetQueryString("ad"));

            string url = new XYECOM.Business.AdTrafficLog().Insert(adsId, IP);

            Response.Redirect(url);
        }
    }
}
