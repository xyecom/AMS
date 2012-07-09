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
using System.IO;

public partial class xymanage_err : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string key = XYECOM.Core.XYRequest.GetQueryString("key");
        string msg = XYECOM.Core.XYRequest.GetQueryString("msg");

        string msgBody = "";

        switch (key)
        {
            case "001":
                msgBody = "您当前的操作权限不足，请联系管理员！";
                break;
            //数据库错误
            case "002":
                msgBody = "数据库错误！";
                break;
            //系统错误
            case "003":
                msgBody = "系统错误！";
                break;
            case "9999":
                msgBody = "授权证书验证失败！";
                break;
            default:
                break;
        }

        if (msgBody != "")
            msgBody = msgBody + "<br/>" + msg;
        else
            msgBody = "<br/>"+msg;

        this.errinfo.InnerHtml = msgBody;
    }
}
