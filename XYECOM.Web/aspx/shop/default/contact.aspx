<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.shop.contact,XYECOM.Page" %>
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
	XYBody.Append("<title>");	XYBody.Append(UserSEO.Title.ToString());	XYBody.Append("</title>\r\n");
	XYBody.Append("<meta name=\"description\" content=\"");	XYBody.Append(UserSEO.Description.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("<meta name=\"keywords\" content=\"");	XYBody.Append(UserSEO.Keywords.ToString());	XYBody.Append("\"  />\r\n");

	if (seo.Robots==true)
	{

	XYBody.Append("<meta name=\"robots\" content=\"all\"  />\r\n");

	}	//end if

	XYBody.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=gb2312\" />\r\n");
	XYBody.Append("<meta http-equiv=\"Content-Language\" content=\"zh-CN\" />\r\n");
	XYBody.Append("<meta name=\"author\" content=\"www.xyecs.com\" />\r\n");
	XYBody.Append("<meta name=\"Copyright\" content=\"copyright (c) www.xyecs.com.版权所有.\" />\r\n");
	XYBody.Append("<link rel=\"stylesheet\" href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/css/cue.css\" type=\"text/css\" media=\"screen\" />\r\n");
	XYBody.Append("<link rel=\"stylesheet\" href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/_shop/default/css/netshop.css\" type=\"text/css\" media=\"screen\" />\r\n");
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
	XYBody.Append("    <a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("contact.");	XYBody.Append(config.Suffix);	XYBody.Append("\">联系方式</a>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<div>\r\n");
	XYBody.Append("    <a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("list----.");	XYBody.Append(config.Suffix);	XYBody.Append("\">团购信息</a>\r\n");
	XYBody.Append("</div>\r\n");


	XYBody.Append("</div>\r\n");
	XYBody.Append("<!--左边导航  end-->\r\n");
	XYBody.Append("<!--右边主要内容-->\r\n");
	XYBody.Append("<div id=\"uright\">\r\n");
	XYBody.Append("<div class=\"rcon\">\r\n");
	XYBody.Append("<h2>联系方式</h2>\r\n");
	XYBody.Append("<!--联系方式-->\r\n");
	XYBody.Append("<div  class=\"infoAbout\">\r\n");
	XYBody.Append(" <a name=\"link\"></a>\r\n");
	XYBody.Append(" <div id=\"linkmessage\"></div>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<input type =\"hidden\" id=\"infotype\"  value =\"5\"/>\r\n");
	XYBody.Append("<!--- 留言模块参数 ---->\r\n");
	XYBody.Append("<input type =\"hidden\" id=\"_param_message_module\" value=\"company\" />\r\n");
	XYBody.Append("<input type =\"hidden\" id=\"_param_message_title\" value=\"");	XYBody.Append(titleinfo.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("<input type =\"hidden\" id=\"_param_message_parent_module\" value =\"");	XYBody.Append(infotype.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("<input type =\"hidden\" id=\"_param_message_infoid\" value =\"");	XYBody.Append(infoid.ToString());	XYBody.Append("\"/>\r\n");
	XYBody.Append("<input type =\"hidden\" id=\"_param_message_userid\" value =\"");	XYBody.Append(shopuserinfo.userid.ToString());	XYBody.Append("\" />\r\n");

	XYBody.Append("<!--网站评论-->\r\n");
	XYBody.Append("<div  class=\"infoAbout  commentTitle\">\r\n");
	XYBody.Append("<a name=\"message\"></a>\r\n");
	XYBody.Append("<form action=\"\" method=\"post\">\r\n");
	XYBody.Append("    <ul class=\"comment\">\r\n");
	XYBody.Append("        <li id=\"msg_tab1\"><a href=\"javascript:;\" onclick=\"xy_selectBox(2,1,'msg','now')\">游客咨询</a></li>\r\n");
	XYBody.Append("        <li class=\"now\" id=\"msg_tab2\"><a href=\"javascript:;\" onclick=\"xy_selectBox(2,2,'msg','now')\">会员咨询</a></li>\r\n");
	XYBody.Append("    </ul>\r\n");
	XYBody.Append("    <div id=\"msg_box1\" style=\"display: none;\">\r\n");
	XYBody.Append("        <div class=\"commentList\">\r\n");
	XYBody.Append("            <p>\r\n");
	XYBody.Append("                <input type=\"radio\" checked=\"checked\"  value =\"1\" id=\"companyid\"  name =\"sinfo\"/>公 司 \r\n");
	XYBody.Append("                <input name=\"sinfo\" type=\"radio\" value=\"0\" id=\"useridad\" />个人\r\n");
	XYBody.Append("                <span>如果您已经是会员，请<a href=\"javascript:geturl();\" class=\"orangelink\">点此登录</a>；如果您还不是本站会员，请<a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("register.");	XYBody.Append(config.Suffix);	XYBody.Append("\" class=\"orangelink\">点此注册</a></span>\r\n");
	XYBody.Append("            </p>\r\n");
	XYBody.Append("            <h3>联系方式</h3>\r\n");
	XYBody.Append("            <ul  class=\"line\">   \r\n");
	XYBody.Append("                <li><label>联系人：<em>*</em></label><input type=\"text\" size=\"25\" id=\"linkman\" onblur=\"checkinfo('1');\" onfocus=\"fs('1');\"  maxlength =\"50\"/><input id=\"nsex\" name=\"\" type=\"radio\" value=\"1\" checked =\"checked\" />先生 <input id=\"girl\" name=\"\" type=\"radio\" value=\"0\" />女士<span id=\"txt1\"></span></li>       \r\n");
	XYBody.Append("                <li><label>电子信箱：<em>*</em></label><input type=\"text\" size=\"25\"  id=\"email\" onblur=\"checkinfo('2');\" onfocus=\"fs('2');\" maxlength =\"50\" /><span  id=\"txt2\"></span></li>\r\n");
	XYBody.Append("                <li><label>电话号码：</label><input name=\"\" type=\"text\" size=\"25\" id=\"mobile\" onblur=\"checkinfo('11');\" onfocus=\"fs('11');\" maxlength =\"13\"/><span  id=\"txt11\"></span></li>\r\n");
	XYBody.Append("            </ul>\r\n");
	XYBody.Append("            <h3>留言内容</h3>\r\n");
	XYBody.Append("            <ul>\r\n");
	XYBody.Append("                <li><label>留言标题：<em>*</em></label><input type=\"text\" size=\"60\" id=\"title\" name=\"title\" onblur=\"checkinfo('14');\" onfocus=\"fs('14');\" maxlength =\"100\" /><span  id =\"txt14\"></span><br /><i>请尽量采用简洁的语言，标题最多20个汉字，内容最多300个汉字。</i></li>\r\n");
	XYBody.Append("                <li><div class=\"left\"><label>留言内容：<em>*</em></label> <textarea name=\"neirong\" cols=\"60\" rows=\"5\" id =\"neirong\" onblur=\"checkinfo('15');\" onfocus=\"fs('15');\"></textarea><span  id=\"txt15\"></span></div>\r\n");
	XYBody.Append("                <div class=\"ks\" id=\"ks1\"></div>\r\n");
	XYBody.Append("                </li>\r\n");

	if (config.IsEnabledVCode("message"))
	{

	XYBody.Append("                <li><label >验证码：<em>*</em></label>");	XYBody.Append(pageinfo.GetValidateCodeHTML("guestVCode","guestVCodeImg"));	XYBody.Append("</li>   \r\n");

	}	//end if

	XYBody.Append("                <li>\r\n");
	XYBody.Append("                    <input name=\"\" type=\"button\" class=\"button\" value=\"确 定\"  onclick =\"checkmessage();\"/> \r\n");
	XYBody.Append("                    <input type=\"button\" name=\"button\"  class=\"button\" value=\"清空\" onclick =\"ykrewrite();\"  />\r\n");
	XYBody.Append("                </li>\r\n");
	XYBody.Append("            </ul>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div> \r\n");
	XYBody.Append("    <div id=\"msg_box2\" style=\"display: block;\">\r\n");
	XYBody.Append("        <div class=\"commentList\">\r\n");
	XYBody.Append("            <ul>\r\n");
	XYBody.Append("                <li><label>留言标题：<em>*</em></label><input type=\"text\" size=\"60\" id=\"txtTitle\" name=\"txtTitle\"  maxlength =\"200\" /></li>\r\n");
	XYBody.Append("                <li><div class=\"left\"><label>留言内容：<em>*</em></label> <textarea name=\"txtContent\" cols=\"60\" rows=\"5\" id=\"txtContent\"></textarea></div>\r\n");
	XYBody.Append("                <div class=\"ks\" id=\"ks2\"></div>\r\n");
	XYBody.Append("                </li>\r\n");

	if (config.IsEnabledVCode("message"))
	{

	XYBody.Append("                <li><label>验证码：<em>*</em></label>");	XYBody.Append(pageinfo.GetValidateCodeHTML("userVCode","userVCodeImg"));	XYBody.Append("</li>\r\n");

	}	//end if

	XYBody.Append("                <li>\r\n");
	XYBody.Append("                    <input name=\"\" type=\"button\" class=\"button\" value=\"确 定\" onclick =\"checkusermessage();\"/> \r\n");
	XYBody.Append("                    <input type=\"button\" name=\"Submit\"  class=\"button\" value=\"清 空\"   onclick=\"hrrewrite();\" />\r\n");
	XYBody.Append("                </li>\r\n");
	XYBody.Append("            </ul>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("</form> \r\n");
	XYBody.Append("</div> \r\n");
	XYBody.Append(" <script type=\"text/javascript\" language=\"javascript\">UserMessageInit();</" + "script>\r\n");


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
