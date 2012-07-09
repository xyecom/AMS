<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.shop.introduction,XYECOM.Page" %>
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


	XYBody.Append("<body onLoad=\"");	XYBody.Append(pageinfo.OnLoadEvents);	XYBody.Append("\">\r\n");
	XYBody.Append("<!--头部搜索 header-->\r\n");
	XYBody.Append("<div id=\"head\">\r\n");
	XYBody.Append("    <div id=\"TopInfo\"><span>\r\n");
	XYBody.Append("    ");	XYBody.Append(pageinfo.LoginStatus);	XYBody.Append("\r\n");
	XYBody.Append("    |<a href=\"http://www.yylm.org/contents/859/11418.html\">联系我们</a></span><a href=\"http://www.yylm.org\" target=\"_blank\" style=\"color:#00f;text-decoration: underline;;\">中国营养联盟</a>——中国营养健康行业服务第一品牌</div>\r\n");
	XYBody.Append("	<div id=\"htop\">\r\n");
	XYBody.Append("		<a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("\"><img src=\"");	XYBody.Append(config.WebLogo);	XYBody.Append("\" alt=\"返回首页\" /></a>\r\n");
	XYBody.Append("		<div id=\"hri\">\r\n");
	XYBody.Append("		   <ul id=\"nav\">\r\n");
	XYBody.Append("		    <li id=\"ssoffer\" class=\"on\"><a href=\"javascript:shoptopflag(1);\">供求</a></li>\r\n");
	XYBody.Append("			<li id=\"ssmachining\" ><a href=\"javascript:shoptopflag(2);\">加工</a></li>\r\n");
	XYBody.Append("			<li id=\"ssinvestment\" ><a href=\"javascript:shoptopflag(3);\">招商</a></li>\r\n");
	XYBody.Append("			<li id=\"ssservice\" ><a href=\"javascript:shoptopflag(4);\">服务</a></li>\r\n");
	XYBody.Append("			<li id=\"ssexhibition\" ><a href=\"javascript:shoptopflag(5);\">展会</a></li>\r\n");
	XYBody.Append("			<li id=\"ssbrand\" ><a href=\"javascript:shoptopflag(6);\">品牌</a></li>\r\n");
	XYBody.Append("		   </ul>\r\n");
	XYBody.Append("		   <ul id=\"nav2\">\r\n");
	XYBody.Append("		    <li><input type=\"text\" class=\"button_text1\" size=\"43\" maxlength=\"50\" id=\"shopsearchkey\" /> <input type=\"button\" class=\"button_search1 button\" value=\"搜索\" onclick=\"shoptopsearch();\" /></li>\r\n");
	XYBody.Append("		   </ul>\r\n");
	XYBody.Append("		</div>\r\n");
	XYBody.Append("	</div>\r\n");
	XYBody.Append("    <div id=\"hcen\">");	XYBody.Append(shopuserinfo.unitname.ToString());	XYBody.Append("</div>\r\n");
	XYBody.Append("	<div id=\"hbot\">\r\n");
	XYBody.Append("		<em class=\"colorFF7B00\"><a href=\"javascript:Favorite();\">加入收藏</a></em>\r\n");
	XYBody.Append("		<span>\r\n");

	if (shopuserinfo.gradeimgurl!="")
	{

	XYBody.Append("		    <img src=\"");	XYBody.Append(shopuserinfo.gradeimgurl.ToString());	XYBody.Append("\" alt=\"\"  width =\"17px\" height =\"19px\"/>、\r\n");

	}
	else
	{

	XYBody.Append("	        <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/WelcomeInfro_32.gif\" alt=\"\"  width =\"17px\" height =\"19px\"/>\r\n");

	}	//end if

	XYBody.Append("	    ");	XYBody.Append(shopuserinfo.gradename.ToString());	XYBody.Append(" \r\n");
	XYBody.Append("	    第 <span class=\"colorFF7B00s\">");	XYBody.Append(year.ToString());	XYBody.Append("</span> 年 </span>		\r\n");
	XYBody.Append("        <input type =\"hidden\" id=\"_param_userinfo_parent_module\" value =\"company\" />\r\n");
	XYBody.Append("<input type =\"hidden\" id=\"_param_userinfo_infoid\" value =\"");	XYBody.Append(infoid.ToString());	XYBody.Append("\"/>\r\n");
	XYBody.Append("<input type =\"hidden\" id=\"_param_userinfo_userid\" value =\"");	XYBody.Append(shopuserinfo.userid.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("    <input id=\"weburl\" name =\"weburl\" type =\"hidden\" value =\"");	XYBody.Append(config.WebURL);	XYBody.Append("\" />\r\n");
	XYBody.Append("     <input id=\"suffix\" name =\"suffix\" type =\"hidden\" value =\"");	XYBody.Append(config.Suffix);	XYBody.Append("\" />	\r\n");
	XYBody.Append("     <input id=\"hidlinkmodule\" name=\"suffix\" type=\"hidden\" value=\"company\" />\r\n");
	XYBody.Append("     <input id=\"bogusstatic\" name=\"suffix\" type=\"hidden\" value=\"");	XYBody.Append(config.BogusStatic);	XYBody.Append("\" />\r\n");
	XYBody.Append("     <input id=\"hidshopsearchflag\" type=\"hidden\" value=\"offer\" />\r\n");
	XYBody.Append("     <input id=\"_param_message_parent_module\" type=\"hidden\" value=\"company\" />\r\n");
	XYBody.Append("     <input id=\"_param_message_infoid\" type=\"hidden\" value=\"");	XYBody.Append(infoid.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("     <input id=\"_param_message_userid\" type=\"hidden\" value=\"");	XYBody.Append(shopuserinfo.userid.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("	</div>\r\n");
	XYBody.Append("</div>\r\n");


	XYBody.Append("<div id=\"ubox\">\r\n");
	XYBody.Append("<!--左边导航-->\r\n");
	XYBody.Append("<div id=\"uleftnav\">\r\n");

	 str = GetLinkPrefix();
	
	XYBody.Append("<div>\r\n");
	XYBody.Append("    <a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("index.");	XYBody.Append(config.Suffix);	XYBody.Append("\">网店首页</a></div>\r\n");
	XYBody.Append("<div>\r\n");
	XYBody.Append("    <a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("introduction.");	XYBody.Append(config.Suffix);	XYBody.Append("\">公司简介</a></div>\r\n");
	XYBody.Append("<div>\r\n");
	XYBody.Append("    <a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("product.");	XYBody.Append(config.Suffix);	XYBody.Append("\">产品展示</a></div>\r\n");
	XYBody.Append("<div>\r\n");
	XYBody.Append("    <a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("offer.");	XYBody.Append(config.Suffix);	XYBody.Append("\">供求商机</a></div>\r\n");
	XYBody.Append("<div>\r\n");
	XYBody.Append("    <a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("venturelist.");	XYBody.Append(config.Suffix);	XYBody.Append("\">投融资信息</a></div>\r\n");
	XYBody.Append("<div>\r\n");
	XYBody.Append("    <a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("cred.");	XYBody.Append(config.Suffix);	XYBody.Append("\">诚信档案</a></div>\r\n");
	XYBody.Append("<div>\r\n");
	XYBody.Append("    <a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("brandlist.");	XYBody.Append(config.Suffix);	XYBody.Append("\">品牌介绍</a></div>\r\n");
	XYBody.Append("<div>\r\n");
	XYBody.Append("    <a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("newslist.");	XYBody.Append(config.Suffix);	XYBody.Append("\">公司动态</a></div>\r\n");
	XYBody.Append("<div>\r\n");
	XYBody.Append("    <a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("joblist.");	XYBody.Append(config.Suffix);	XYBody.Append("\">人才招聘</a></div>\r\n");
	XYBody.Append("<div>\r\n");
	XYBody.Append("    <a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("contact.");	XYBody.Append(config.Suffix);	XYBody.Append("\">联系方式</a></div>\r\n");


	XYBody.Append("</div>\r\n");
	XYBody.Append("<!--左边导航  end-->\r\n");
	XYBody.Append("<!--右边主要内容-->\r\n");
	XYBody.Append("<div id=\"uright\">\r\n");
	XYBody.Append("    <!--站点导航-->\r\n");
	XYBody.Append("	<div style=\"display:none;\"><em id=\"clicknum1\" style =\"display :none\"></em> <em id=\"clicknum\" style =\"display :none\"></em><em id=\"linkmessage\" style =\"display :none\"></em><em id=\"msy\" style =\"display :none\"></em><em id=\"messnum\" style =\"display :none\"></em></div>\r\n");
	XYBody.Append("	<!--公司介绍-->\r\n");
	XYBody.Append("	<div class=\"rcon\">\r\n");
	XYBody.Append("	<h2>公司介绍</h2>\r\n");
	XYBody.Append("	<p class=\"font142\">\r\n");

	if (shopuserinfo.imgurl!="")
	{

	XYBody.Append("<img alt=\"");	XYBody.Append(shopuserinfo.loginname.ToString());	XYBody.Append("\" src=\"");	XYBody.Append(shopuserinfo.imgurl.ToString());	XYBody.Append("\" />\r\n");

	}
	else
	{

	XYBody.Append("<img alt=\"");	XYBody.Append(shopuserinfo.loginname.ToString());	XYBody.Append("\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/WelcomeInfro_32.gif\" />\r\n");

	}	//end if

	XYBody.Append("	");	XYBody.Append(shopuserinfo.synopsis.ToString());	XYBody.Append("\r\n");
	XYBody.Append("</p>\r\n");
	XYBody.Append("	</div>\r\n");
	XYBody.Append("	<div class=\"rcon\">\r\n");
	XYBody.Append("	<h2>详细信息</h2>\r\n");
	XYBody.Append("	<div class=\"rcont\">\r\n");
	XYBody.Append("        <table class=\"table_infos\">\r\n");
	XYBody.Append("            <tr>\r\n");
	XYBody.Append("                <th class=\"line1\">\r\n");
	XYBody.Append("                    公司名称：</th>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    ");	XYBody.Append(shopuserinfo.unitname.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("                <th class=\"line1\">\r\n");
	XYBody.Append("                    成立时间：</th>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    ");	XYBody.Append(shopuserinfo.regyear.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("            </tr>\r\n");
	XYBody.Append("            <tr>\r\n");
	XYBody.Append("                <th class=\"line1\">\r\n");
	XYBody.Append("                    经营模式：</th>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    ");	XYBody.Append(shopuserinfo.mode.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("                <th class=\"line1\">\r\n");
	XYBody.Append("                    供应的产品和服务：</th>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    ");	XYBody.Append(shopuserinfo.supplypro.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("            </tr>\r\n");
	XYBody.Append("            <tr>\r\n");
	XYBody.Append("                <th class=\"line1\">\r\n");
	XYBody.Append("                    公司主页：</th>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    <a href=\"");	XYBody.Append(shopuserinfo.homepage.ToString());	XYBody.Append("\">");	XYBody.Append(shopuserinfo.homepage.ToString());	XYBody.Append("</a>\r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("                <th class=\"line1\">\r\n");
	XYBody.Append("                    注册资本：</th>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    ");	XYBody.Append(shopuserinfo.registeredcapital.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("            </tr>\r\n");
	XYBody.Append("            <tr>\r\n");
	XYBody.Append("                <th class=\"line1 colorFF7300\">\r\n");
	XYBody.Append("                    企业类型：</th>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    ");	XYBody.Append(shopuserinfo.unittype.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("                <th class=\"line1 colorFF7300\">\r\n");
	XYBody.Append("                    公司性质：</th>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    ");	XYBody.Append(shopuserinfo.character.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("            </tr>\r\n");
	XYBody.Append("            <tr>\r\n");
	XYBody.Append("                <th class=\"line1\">\r\n");
	XYBody.Append("                    员工人数：</th>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    ");	XYBody.Append(shopuserinfo.employeetotal.ToString());	XYBody.Append("人</td>\r\n");
	XYBody.Append("                <th class=\"line1 colorFF7300\">\r\n");
	XYBody.Append("                    公司注册地：</th>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    ");	XYBody.Append(shopuserinfo.regarea.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("            </tr>\r\n");
	XYBody.Append("        </table>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("	</div>\r\n");
	XYBody.Append("</div>\r\n");
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
