<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.post_result,XYECOM.Page" %>
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
	XYBody.Append("    <title>����¼����ҵ��Ϣ</title>\r\n");
	XYBody.Append("    <link href=\"/common/css/XYLib.css\" type=\"text/css\" rel=\"Stylesheet\" />\r\n");
	XYBody.Append("    <link href=\"/templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/css/global.css\" type=\"text/css\" rel=\"Stylesheet\" />\r\n");
	XYBody.Append("    <link href=\"/templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/css/post.css\" type=\"text/css\" rel=\"Stylesheet\" />\r\n");
	XYBody.Append("    <script language =\"javascript\" type =\"text/javascript\" src =\"/common/js/base.js\"></" + "script> \r\n");
	XYBody.Append("    <script language =\"javascript\" type=\"text/javascript\"  src=\"/common/js/UploadControl.js\"></" + "script>\r\n");
	XYBody.Append("    <script language =\"javascript\" type=\"text/javascript\"  src=\"/templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/js/post.js\"></" + "script>\r\n");
	XYBody.Append("    <script language =\"javascript\" type =\"text/javascript\" src =\"/templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/js/login.js\"></" + "script>\r\n");
	XYBody.Append("</head>\r\n");
	XYBody.Append("<body>\r\n");
	XYBody.Append("<div class=\"head\">\r\n");
	XYBody.Append("    <div class=\"logo\"><a href=\"/\"><img src=\"");	XYBody.Append(config.weblogo);	XYBody.Append("\" alt=\"������ҳ\" border=\"0\" /></a></div>\r\n");
	XYBody.Append("    <div class=\"nav\"><a href=\"/\">��վ��ҳ</a>|");	XYBody.Append(pageinfo.LoginStatus);	XYBody.Append("</div>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<div class=\"guest_post\">\r\n");
	XYBody.Append("    <input type=\"hidden\" name=\"_param_step\" value=\"3\"/>\r\n");
	XYBody.Append("    <div  class=\"step_title\">������:��Ϣ�������</div>\r\n");
	XYBody.Append("    <div class=\"step_result\">\r\n");
	XYBody.Append("        <ul>\r\n");
	XYBody.Append("            <li class=\"msg\">");	XYBody.Append(message.ToString());	XYBody.Append("</li>\r\n");

	if (usertype=="user")
	{

	XYBody.Append("            <li>\r\n");
	XYBody.Append("                <a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("user/\">�����ҵĻ�Ա����</a>\r\n");
	XYBody.Append("            </li>\r\n");

	}	//end if


	if (usertype=="guest")
	{

	XYBody.Append("            <li>\r\n");
	XYBody.Append("                <a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("user/\">�����ҵĻ�Ա����,�����ҵ����ϣ����ܸ����ԱȨ��</a>\r\n");
	XYBody.Append("            </li>\r\n");

	}	//end if

	XYBody.Append("        </ul>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <div  class=\"step_next\">\r\n");
	XYBody.Append("    <input type=\"button\" onclick=\"window.close();\" value=\"�ر�ҳ��\" />\r\n");
	XYBody.Append("    <input type=\"button\" onclick=\"location.href='");	XYBody.Append(config.weburl);	XYBody.Append("post.");	XYBody.Append(config.suffix);	XYBody.Append("';\" value=\"����������Ϣ\" />\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("Copyright &copy; 2008 " +  XYECOMCreateHTML("XY_Copyright").ToString() + ".All right reserved. \r\n");
	XYBody.Append("</body>\r\n");
	XYBody.Append("</html>\r\n");

	XYBody.Append(IsCopyright());
	Response.Write(XYBody.ToString());
}
</script>
