<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.activation,XYECOM.Page" %>
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
	XYBody.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n");
	XYBody.Append("<head>\r\n");
	XYBody.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=gb2312\" />\r\n");
	XYBody.Append("<title>验证结果</title>\r\n");
	XYBody.Append("<link type=\"text/css\" href=\"/templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/css/reger.css\" rel=\"stylesheet\" />\r\n");
	XYBody.Append("</head>\r\n");
	XYBody.Append("<body>\r\n");
	XYBody.Append("<div id=\"yanzheng\">\r\n");
	XYBody.Append("  ");	XYBody.Append(usernames.ToString());	XYBody.Append(" ");	XYBody.Append(useractivation.ToString());	XYBody.Append("  \r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<div id=\"r_f\">2000-2008　" +  XYECOMCreateHTML("XY_Copyright").ToString() + "　版权所有　纵横易商软件</div>\r\n");
	XYBody.Append("</body>\r\n");

	XYBody.Append(IsCopyright());
	Response.Write(XYBody.ToString());
}
</script>
