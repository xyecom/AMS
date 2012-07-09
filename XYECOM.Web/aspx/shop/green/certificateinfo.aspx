<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.shop.certificateinfo,XYECOM.Page" %>
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
	XYBody.Append("<title>");	XYBody.Append(seo.Title);	XYBody.Append("</title>\r\n");
	XYBody.Append("<meta name=\"description\" content=\"");	XYBody.Append(seo.Description);	XYBody.Append("\" />\r\n");
	XYBody.Append("<meta name=\"keywords\" content=\"");	XYBody.Append(seo.Keywords);	XYBody.Append("\"  />\r\n");

	if (seo.Robots==true)
	{

	XYBody.Append("<meta name=\"robots\" content=\"all\"  />\r\n");

	}	//end if

	XYBody.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=gb2312\" />\r\n");
	XYBody.Append("<meta http-equiv=\"Content-Language\" content=\"zh-CN\" />\r\n");
	XYBody.Append("<meta name=\"author\" content=\"www.xyecs.com\" />\r\n");
	XYBody.Append("<meta name=\"Copyright\" content=\"copyright (c) www.xyecs.com.版权所有.\" />\r\n");
	XYBody.Append("<link rel=\"stylesheet\" href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/css/cue.css\" type=\"text/css\" media=\"screen\" />\r\n");
	XYBody.Append("<link rel=\"stylesheet\" href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/_shop/green/css/netshop.css\" type=\"text/css\" media=\"screen\" />\r\n");
	XYBody.Append("<link rel=\"stylesheet\" href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("common/css/XYLib.css\" type=\"text/css\" media=\"screen\" />\r\n");
	XYBody.Append("<script type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("common/js/base.js\" language=\"javascript\"></" + "script>\r\n");
	XYBody.Append("<script type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("common/js/alert.js\" language=\"javascript\"></" + "script>\r\n");
	XYBody.Append("<script type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/js/login.js\" language=\"javascript\"></" + "script>\r\n");
	XYBody.Append("<script type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/js/validate.js\" language=\"javascript\"></" + "script>\r\n");
	XYBody.Append("<script type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/js/treetype.js\" language=\"javascript\"></" + "script>\r\n");
	XYBody.Append("<script type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/js/date.js\" language=\"javascript\"></" + "script>\r\n");
	XYBody.Append("</head>\r\n");


	XYBody.Append("<body>\r\n");
	XYBody.Append("<div class=\"k\">\r\n");
	XYBody.Append(" <ul class=\"top\"><li class=\"tl\"></li><li class=\"t\"></li><li class=\"tr\"></li></ul>\r\n");
	XYBody.Append(" <ul class=\"main\">\r\n");
	XYBody.Append("  <li class=\"l\"></li>\r\n");
	XYBody.Append("  <li class=\"c\">\r\n");
	XYBody.Append("   <img src=\"");	XYBody.Append(imgurl.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("  </li>\r\n");
	XYBody.Append("  <li class=\"r\"></li>\r\n");
	XYBody.Append(" </ul>\r\n");
	XYBody.Append(" <ul class=\"bot\"><li class=\"bl\"></li><li class=\"b\"></li><li class=\"br\"></li></ul>\r\n");
	XYBody.Append("</div>\r\n");

	XYBody.Append("<!--foot-->\r\n");
	XYBody.Append("<div id=\"foot\">\r\n");
	XYBody.Append("<input type =\"hidden\" id=\"type\" value =\"");	XYBody.Append(infotype.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("<input type =\"hidden\" id=\"ids\" value =\"");	XYBody.Append(infoid.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("<input type =\"hidden\" id=\"isshop\" value =\"");	XYBody.Append(shopuserinfo.isshop.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("<input type =\"hidden\" id=\"uids\" value =\"");	XYBody.Append(shopuserinfo.userid.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("<input type =\"hidden\" id =\"linktype\"  value =\"");	XYBody.Append(linktype.ToString());	XYBody.Append("\"/>\r\n");
	XYBody.Append("<input type =\"hidden\" id =\"isaudited\"  value =\"");	XYBody.Append(shopuserinfo.isaudited.ToString());	XYBody.Append("\"/>\r\n");
	XYBody.Append("<tr><td align=\"middle\">");	XYBody.Append(shopuserinfo.unitname.ToString());	XYBody.Append("</td></tr><br/>\r\n");
	XYBody.Append("                                    <tr><td align=\"middle\">公司地址：");	XYBody.Append(shopuserinfo.address.ToString());	XYBody.Append("</td></tr><br/>\r\n");
	XYBody.Append("                                    <tr>\r\n");
	XYBody.Append("                                    <td align=\"middle\">\r\n");
	XYBody.Append("                                        <a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("\" target=\"_blank\"> 中国营养联盟-提供平台支持</a> | \r\n");
	XYBody.Append("                            <a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("feedback.");	XYBody.Append(config.suffix);	XYBody.Append("\" target=\"_blank\">意见反馈</a> | \r\n");
	XYBody.Append("                                        <a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("login.");	XYBody.Append(config.suffix);	XYBody.Append("\" target=\"_blank\">管理网站</a>\r\n");
	XYBody.Append("      <br/>	\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<!--foot end-->	\r\n");
	XYBody.Append("</body>\r\n");
	XYBody.Append("</html>\r\n");



	XYBody.Append("");
	Response.Write(XYBody.ToString());
}
</script>
