<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.feedback,XYECOM.Page" %>
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

	if (pageinfo.PageError==1)
	{


	XYBody.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n");
	XYBody.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n");
	XYBody.Append("<head>\r\n");
	XYBody.Append("<title>��Ϣ��ʾ</title>\r\n");
	XYBody.Append("");	XYBody.Append(pageinfo.Meta);	XYBody.Append("\r\n");
	XYBody.Append("<link rel=\"stylesheet\" href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/css/global.css\" type=\"text/css\" media=\"screen\" />\r\n");
	XYBody.Append("</head>\r\n");
	XYBody.Append("<body style=\"background-color:#f2f2f2\">\r\n");
	XYBody.Append("<div id=\"sysMsgbox\">\r\n");
	XYBody.Append("	<ul>\r\n");
	XYBody.Append("	    <li class=\"msg\">");	XYBody.Append(pageinfo.MsgboxText);	XYBody.Append("</li>\r\n");
	XYBody.Append("        <li><a href=\"");	XYBody.Append(pageinfo.MsgboxURL);	XYBody.Append("\">");	XYBody.Append(pageinfo.MsgboxURL);	XYBody.Append("</a></li>\r\n");
	XYBody.Append("         <li><a href=\"#\" onclick=\"history.back();\">���ؼ�������</a></li>\r\n");
	XYBody.Append("        <li><a href=\"/\">������ҳ</a> | <a href=\"#\" onclick=\"window.close();\">�رձ�ҳ</a></li>\r\n");
	XYBody.Append("    </ul>\r\n");
	XYBody.Append("    <div id=\"r_f\">2000-2009��" +  XYECOMCreateHTML("XY_Copyright").ToString() + "����Ȩ���С��ݺ��������</div>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("</body>\r\n");
	XYBody.Append("</html>\r\n");



	Response.Write(XYBody.ToString());
System.Web.HttpContext.Current.Response.End();
	

	}	//end if

	XYBody.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n");
	XYBody.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\" >\r\n");
	XYBody.Append("<head>\r\n");
	XYBody.Append("    <title>�������</title>\r\n");
	XYBody.Append("    <link href=\"/common/css/XYLib.css\" type=\"text/css\" rel=\"Stylesheet\" />\r\n");
	XYBody.Append("    <link href=\"/templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/css/global.css\" type=\"text/css\" rel=\"Stylesheet\" />\r\n");
	XYBody.Append("    <link href=\"/templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/css/post.css\" type=\"text/css\" rel=\"Stylesheet\" />\r\n");
	XYBody.Append("    <script language =\"javascript\" type =\"text/javascript\" src =\"/common/js/base.js\"></" + "script> \r\n");
	XYBody.Append("    <script language =\"javascript\" type=\"text/javascript\"  src=\"/templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/js/post.js\"></" + "script>\r\n");
	XYBody.Append("    <script language =\"javascript\" type =\"text/javascript\" src =\"/templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/js/login.js\"></" + "script>\r\n");
	XYBody.Append("    <script language =\"javascript\" type =\"text/javascript\" src =\"/templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/js/validate.js\"></" + "script> \r\n");
	XYBody.Append("</head>\r\n");
	XYBody.Append("<body>\r\n");
	XYBody.Append("<div class=\"head\">\r\n");
	XYBody.Append("    <div class=\"logo\"><a href=\"/\"><img src=\"");	XYBody.Append(config.weblogo);	XYBody.Append("\" alt=\"������ҳ\" border=\"0\" /></a></div>\r\n");
	XYBody.Append("    <div class=\"nav\"><a href=\"/\">��վ��ҳ</a>|");	XYBody.Append(pageinfo.LoginStatus);	XYBody.Append("</div>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<div class=\"guest_post\">\r\n");
	XYBody.Append("    <div class=\"step_title\">�û�Ͷ��</div> \r\n");
	XYBody.Append("<form method =\"post\" action=\"");	XYBody.Append(config.WebURL);	XYBody.Append("feedback.");	XYBody.Append(config.Suffix);	XYBody.Append("\" > \r\n");
	XYBody.Append("<table class=\"tab_step2\">\r\n");
	XYBody.Append("<tr>\r\n");
	XYBody.Append("<th>���ͣ�<em class=\"red\">*</em></th>\r\n");
	XYBody.Append("<td>\r\n");
	XYBody.Append("<input type=\"radio\" name=\"type\" value=\"1\"/>����\r\n");
	XYBody.Append("<input type=\"radio\" name=\"type\" value=\"2\"/>����\r\n");
	XYBody.Append("<input type=\"radio\" name=\"type\" value=\"3\" checked=\"checked\"/>Ͷ��\r\n");
	XYBody.Append("<input type=\"radio\" name=\"type\" value=\"4\"/>����\r\n");
	XYBody.Append("<input type=\"radio\" name=\"type\" value=\"5\"/>ҵ����ϵ\r\n");
	XYBody.Append("</td>\r\n");
	XYBody.Append("</tr>\r\n");
	XYBody.Append("    <tr>\r\n");
	XYBody.Append("        <th>���⣺<em class=\"red\">*</em></th>\r\n");
	XYBody.Append("        <td><input  name=\"title\"  type =\"text\" id=\"title\" maxlength=\"100\" size=\"50\" /> </td>\r\n");
	XYBody.Append("    </tr>\r\n");
	XYBody.Append("    <tr>\r\n");
	XYBody.Append("        <th>������<em class=\"red\">*</em></th>\r\n");
	XYBody.Append("        <td><input name=\"Name\" type=\"text\" id=\"Name\" maxlength=\"100\" size=\"50\" /></td>\r\n");
	XYBody.Append("    </tr>\r\n");
	XYBody.Append("    <tr>\r\n");
	XYBody.Append("        <th>�绰��<em class=\"red\">*</em></th>\r\n");
	XYBody.Append("        <td><input name=\"telephone\" type=\"text\" id=\"telephone\" maxlength=\"100\" size=\"50\"/></td>\r\n");
	XYBody.Append("    </tr>\r\n");
	XYBody.Append("    <tr>\r\n");
	XYBody.Append("        <th>E-Mail��<em class=\"red\">*</em></th>\r\n");
	XYBody.Append("        <td><input  name=\"email\"  type =\"text\" id=\"email\" maxlength=\"100\" size=\"50\"/></td>\r\n");
	XYBody.Append("    </tr>\r\n");
	XYBody.Append("    <tr>\r\n");
	XYBody.Append("        <th>���ݣ�<em class=\"red\">*</em></th>\r\n");
	XYBody.Append("        <td><textarea name=\"xyecom\" rows=\"8\" cols=\"60\" id=\"xyecom\"></textarea>\r\n");
	XYBody.Append("    </td>\r\n");
	XYBody.Append("    </tr>\r\n");
	XYBody.Append(" </table>\r\n");
	XYBody.Append("<input id=\"userId\" name=\"userId\" type=\"hidden\" value=\"");	XYBody.Append(ComplaintId.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("<input id=\"infoFlag\" name=\"infoFlag\" type=\"hidden\" value=\"");	XYBody.Append(infoFlag.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("<input id=\"infoId\" name=\"infoId\" type=\"hidden\" value=\"");	XYBody.Append(infoId.ToString());	XYBody.Append("\" />\r\n");

	if (config.IsEnabledVCode("quickpost"))
	{

	XYBody.Append("<table class=\"tab_step2\">\r\n");
	XYBody.Append("<tr>\r\n");
	XYBody.Append("    <th>��֤�룺<em>*</em></th>\r\n");
	XYBody.Append("    <td>\r\n");
	XYBody.Append("        ");	XYBody.Append(pageinfo.GetValidateCodeHTML());	XYBody.Append("\r\n");
	XYBody.Append("    </td>\r\n");
	XYBody.Append("</tr>\r\n");
	XYBody.Append("</table>\r\n");

	}	//end if

	XYBody.Append("    <div class=\"step_next\">\r\n");
	XYBody.Append("     <input name=\"\" type =\"submit\" value=\" ȷ��\" onclick =\"return CheckFeedback();\" class =\"button\" />\r\n");
	XYBody.Append("<input name=\"but02\" type=\"button\" value=\"ȡ��\" onclick =\"window.location.href='");	XYBody.Append(config.WebURL);	XYBody.Append("';\"  class =\"button\"/>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("</form>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("Copyright &copy; 2008 " +  XYECOMCreateHTML("XY_Copyright").ToString() + ".All right reserved. \r\n");
	XYBody.Append("</body>\r\n");
	XYBody.Append("</html>\r\n");

	XYBody.Append(IsCopyright());
	Response.Write(XYBody.ToString());
}
</script>
