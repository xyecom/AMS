<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.user.paymentreturn,XYECOM.Page" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="XYECOM.Core" %>
<%@ Import namespace="XYECOM.Model" %>
<%@ Import namespace="XYECOM.Business" %>
<%@ Import namespace="XYECOM.Template" %>
<%@ Import namespace="XYECOM.Configuration" %>
<script runat="server">
protected override void OnLoad(EventArgs e)
{
	base.OnLoad(e);
	XYBody.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n");
	XYBody.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\" >\r\n");
	XYBody.Append("<head>\r\n");
	XYBody.Append("    <title>在线支付结果反馈</title>\r\n");
	XYBody.Append("    <link href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/user/css/UserManage.css\" type=\"text/css\" rel=\"Stylesheet\" />\r\n");
	XYBody.Append("</head>\r\n");
	XYBody.Append("<body>\r\n");
	XYBody.Append("    <div class=\"p_result\">\r\n");
	XYBody.Append("    ");	XYBody.Append(result.ToString());	XYBody.Append("<br/>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <div>    <input type=\"button\" value=\"关闭页面\" onclick=\"window.close();\" /></div>\r\n");
	XYBody.Append("    <div class=\"p_footer\">");	XYBody.Append(config.webname);	XYBody.Append(" -- Powered by " +  XYECOMCreateHTML("XY_Copyright").ToString() + " </div>\r\n");
	XYBody.Append("</body>\r\n");
	XYBody.Append("</html>\r\n");

	XYBody.Append(IsCopyright());
	Response.Write(XYBody.ToString());
}
</script>
