<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.contributor,XYECOM.Page" %>
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
	XYBody.Append("<title>消息提示</title>\r\n");
	XYBody.Append("");
	XYBody.Append(pageinfo.Meta);
	XYBody.Append("\r\n");
	XYBody.Append("<link rel=\"stylesheet\" href=\"");
	XYBody.Append(config.WebURL);
	XYBody.Append("templates/");
	XYBody.Append(config.TemplatePath);
	XYBody.Append("/css/global.css\" type=\"text/css\" media=\"screen\" />\r\n");
	XYBody.Append("</head>\r\n");
	XYBody.Append("<body style=\"background-color:#f2f2f2\">\r\n");
	XYBody.Append("<div id=\"sysMsgbox\">\r\n");
	XYBody.Append("	<ul>\r\n");
	XYBody.Append("	    <li class=\"msg\">");
	XYBody.Append(pageinfo.MsgboxText);
	XYBody.Append("</li>\r\n");
	XYBody.Append("        <li><a href=\"");
	XYBody.Append(pageinfo.MsgboxURL);
	XYBody.Append("\">");
	XYBody.Append(pageinfo.MsgboxURL);
	XYBody.Append("</a></li>\r\n");
	XYBody.Append("         <li><a href=\"#\" onclick=\"history.back();\">返回继续操作</a></li>\r\n");
	XYBody.Append("        <li><a href=\"/\">返回首页</a> | <a href=\"#\" onclick=\"window.close();\">关闭本页</a></li>\r\n");
	XYBody.Append("    </ul>\r\n");
	XYBody.Append("    <div id=\"r_f\">2000-2009　" +  XYECOMCreateHTML("XY_Copyright").ToString() + "　版权所有　纵横易商软件</div>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("</body>\r\n");
	XYBody.Append("</html>\r\n");



	Response.Write(XYBody.ToString());
System.Web.HttpContext.Current.Response.End();
	

	}	//end if

	XYBody.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n");
	XYBody.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\" >\r\n");
	XYBody.Append("<head>\r\n");
	XYBody.Append("    <title>资讯投稿</title>\r\n");
	XYBody.Append("    <link href=\"/common/css/XYLib.css\" type=\"text/css\" rel=\"Stylesheet\" />\r\n");
	XYBody.Append("    <link href=\"/templates/");
	XYBody.Append(config.TemplatePath);
	XYBody.Append("/css/global.css\" type=\"text/css\" rel=\"Stylesheet\" />\r\n");
	XYBody.Append("    <link href=\"/templates/");
	XYBody.Append(config.TemplatePath);
	XYBody.Append("/css/post.css\" type=\"text/css\" rel=\"Stylesheet\" />\r\n");
	XYBody.Append("    <script language=\"javascript\" type=\"text/javascript\" src=\"");
	XYBody.Append(config.WebURL);
	XYBody.Append("config/js/config.js\"></" + "script>\r\n");
	XYBody.Append("    <script language =\"javascript\" type =\"text/javascript\" src =\"/common/js/base.js\"></" + "script> \r\n");
	XYBody.Append("    <script language =\"javascript\" type=\"text/javascript\"  src=\"/templates/");
	XYBody.Append(config.TemplatePath);
	XYBody.Append("/js/post.js\"></" + "script>\r\n");
	XYBody.Append("    <script language =\"javascript\" type =\"text/javascript\" src =\"/templates/");
	XYBody.Append(config.TemplatePath);
	XYBody.Append("/js/login.js\"></" + "script>\r\n");
	XYBody.Append("    <script language =\"javascript\" type =\"text/javascript\" src =\"/templates/");
	XYBody.Append(config.TemplatePath);
	XYBody.Append("/js/news.js\"></" + "script> \r\n");
	XYBody.Append("</head>\r\n");
	XYBody.Append("<body>\r\n");
	XYBody.Append("<div class=\"head\">\r\n");
	XYBody.Append("    <div class=\"logo\"><a href=\"/\"><img src=\"");
	XYBody.Append(config.weblogo);
	XYBody.Append("\" alt=\"返回首页\" border=\"0\" /></a></div>\r\n");
	XYBody.Append("    <div class=\"nav\"><a href=\"/\">网站首页</a>|");
	XYBody.Append(pageinfo.LoginStatus);
	XYBody.Append("</div>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<div class=\"guest_post\">\r\n");
	XYBody.Append("    <div class=\"step_title\">资讯投稿</div> \r\n");
	XYBody.Append("<form method =\"post\" action=\"");
	XYBody.Append(config.WebURL);
	XYBody.Append("contributor.");
	XYBody.Append(config.Suffix);
	XYBody.Append("\" > \r\n");
	XYBody.Append("<table class=\"tab_step2\">\r\n");
	XYBody.Append("<tr>\r\n");
	XYBody.Append(" <th>标题：<em class=\"red\">*</em></th>\r\n");
	XYBody.Append(" <td>\r\n");
	XYBody.Append("  <input  name=\"title\"  type =\"text\" id=\"title\" maxlength=\"100\" size=\"50\" /> </td>\r\n");
	XYBody.Append("  </tr>\r\n");
	XYBody.Append("    <tr>\r\n");
	XYBody.Append("        <th>选择栏目：<em class=\"red\">*</em></th>\r\n");
	XYBody.Append("         <td>\r\n");
	XYBody.Append("            <input id=\"hidTypeId\"  name=\"hidTypeId\" type=\"hidden\" />\r\n");
	XYBody.Append("            <input type=\"hidden\" id=\"hidMoueleName\" />\r\n");
	XYBody.Append("            <div id=\"classType\"></div>\r\n");
	XYBody.Append("            <script type=\"text/javascript\">\r\n");
	XYBody.Append("            var cla = new ClassType(\"cla\",'news','classType','hidTypeId',null,null,\"contribut:0|hidden:0\");\r\n");
	XYBody.Append("            cla.Mode=\"select\";\r\n");
	XYBody.Append("            cla.Init();\r\n");
	XYBody.Append("            </" + "script>\r\n");
	XYBody.Append("         </td>\r\n");
	XYBody.Append("    </tr>\r\n");
	XYBody.Append("    <tr>\r\n");
	XYBody.Append("        <th>关键字：<em class=\"red\">*</em></th>\r\n");
	XYBody.Append("        <td><input name=\"newskeyword\" type=\"text\" id=\"newskeyword\" maxlength=\"100\" size=\"50\" />       多个请以“,”隔开</td>\r\n");
	XYBody.Append("    </tr>\r\n");
	XYBody.Append("    <tr>\r\n");
	XYBody.Append("        <th>新闻作者：<em class=\"red\">*</em></th>\r\n");
	XYBody.Append("        <td><input name=\"author\" type=\"text\" id=\"author\" maxlength=\"100\" size=\"50\" value=\"");
	XYBody.Append(author.ToString());
	XYBody.Append("\" /></td>\r\n");
	XYBody.Append("    </tr>\r\n");
	XYBody.Append("    <tr>\r\n");
	XYBody.Append("        <th>新闻来源：<em class=\"red\">*</em></th>\r\n");
	XYBody.Append("        <td><input  name=\"origin\"  type =\"text\" id=\"laiyuan\" maxlength=\"100\" size=\"50\" value=\"");
	XYBody.Append(origin.ToString());
	XYBody.Append("\"/></td>\r\n");
	XYBody.Append("    </tr>\r\n");
	XYBody.Append("    <tr>\r\n");
	XYBody.Append("        <th>是否容许评论：</th>\r\n");
	XYBody.Append("        <td><input  type=\"checkbox\" id=\"iscomment\" name=\"iscomment\" checked value=\"1\"/></td>\r\n");
	XYBody.Append("    </tr>\r\n");
	XYBody.Append("  <tr>\r\n");
	XYBody.Append(" <th>内容：<em class=\"red\">*</em></th>\r\n");
	XYBody.Append(" <td><div>\r\n");
	XYBody.Append("<script language =\"javascript\" type=\"text/javascript\"  src=\"");
	XYBody.Append(config.WebURL);
	XYBody.Append("Common/fckeditor/fckeditor.js\"></" + "script>\r\n");
	XYBody.Append("  <script language=\"javascript\" type=\"text/javascript\">\r\n");
	XYBody.Append("var oFCKeditor = new FCKeditor('xyecom') ;\r\n");
	XYBody.Append("oFCKeditor.BasePath = '/Common/fckeditor/' ;\r\n");
	XYBody.Append("oFCKeditor.ToolbarSet = 'Basic' ;\r\n");
	XYBody.Append("oFCKeditor.Width = '100%' ;\r\n");
	XYBody.Append("oFCKeditor.Height = '400' ;\r\n");
	XYBody.Append("oFCKeditor.Value = '';\r\n");
	XYBody.Append("oFCKeditor.Create() ;\r\n");
	XYBody.Append(" </" + "script></div>\r\n");
	XYBody.Append(" </td>\r\n");
	XYBody.Append(" </tr>\r\n");
	XYBody.Append(" </table>\r\n");

	if (config.IsEnabledVCode("quickpost"))
	{

	XYBody.Append("<table class=\"tab_step2\">\r\n");
	XYBody.Append("<tr>\r\n");
	XYBody.Append("    <th>验证码：<em>*</em></th>\r\n");
	XYBody.Append("    <td>\r\n");
	XYBody.Append("        ");
	XYBody.Append(pageinfo.GetValidateCodeHTML());
	XYBody.Append("\r\n");
	XYBody.Append("    </td>\r\n");
	XYBody.Append("</tr>\r\n");
	XYBody.Append("</table>\r\n");

	}	//end if

	XYBody.Append("    <div class=\"step_next\">\r\n");
	XYBody.Append("     <input name=\"\" type =\"submit\" value=\" 确定\" onclick =\"return CheckContributorNews();\" class =\"button\" />\r\n");
	XYBody.Append("<input name=\"but02\" type=\"button\" value=\"取消\" onclick =\"window.location.href='");
	XYBody.Append(config.WebURL);
	XYBody.Append("';\"  class =\"button\"/>\r\n");
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
