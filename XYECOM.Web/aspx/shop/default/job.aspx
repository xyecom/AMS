<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.shop.job,XYECOM.Page" %>
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
	XYBody.Append("    <!--站点导航-->\r\n");
	XYBody.Append("	<div style=\"display:none;\"><em id=\"clicknum\" style=\"display :none \"></em><em id=\"msy\" style=\"display :none \"></em><em id=\"clicknum1\" style=\"display :none \"></em><em id=\"messnum\" style=\"display :none \"></em> </div>\r\n");
	XYBody.Append("	<!--公司介绍职位-->\r\n");
	XYBody.Append("	<div class=\"rcon\">\r\n");
	XYBody.Append("	<h2>职位介绍</h2>\r\n");
	XYBody.Append("		<table class=\"table_infos\">\r\n");
	XYBody.Append("  <tr>\r\n");
	XYBody.Append("    <th class=\"line1\">职位名称：</th>\r\n");
	XYBody.Append("    <td>");	XYBody.Append(jobinfo.JobTitle.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("	<th class=\"line1\">招聘人数：</th>\r\n");
	XYBody.Append("    <td>");	XYBody.Append(jobinfo.Number.ToString());	XYBody.Append(" 人</td>\r\n");
	XYBody.Append("  </tr>\r\n");
	XYBody.Append("   <tr>\r\n");
	XYBody.Append("    <th class=\"line1\">工作性质：</th>\r\n");
	XYBody.Append("    <td>");	XYBody.Append(jobinfo.JobType.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("	<th class=\"line1\">性别要求：</th>\r\n");
	XYBody.Append("    <td>");	XYBody.Append(jobinfo.Sex.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("  </tr>\r\n");
	XYBody.Append("  <tr>\r\n");
	XYBody.Append("    <th class=\"line1\">学历要求：</th>\r\n");
	XYBody.Append("    <td>");	XYBody.Append(jobinfo.Education.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("	<th class=\"line1\">年龄要求：</th>\r\n");
	XYBody.Append("    <td>");	XYBody.Append(jobinfo.Age.ToString());	XYBody.Append(" 岁</td>\r\n");
	XYBody.Append("  </tr>\r\n");
	XYBody.Append("   <tr>\r\n");
	XYBody.Append("    <th class=\"line1\">工作经验：</th>\r\n");
	XYBody.Append("    <td>");	XYBody.Append(jobinfo.Experience.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("	<th class=\"line1\">待遇：</th>\r\n");
	XYBody.Append("    <td>");	XYBody.Append(jobinfo.Pay.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("  </tr>\r\n");
	XYBody.Append("  <tr>\r\n");
	XYBody.Append("    <th class=\"line1\">工作地点：</th>\r\n");
	XYBody.Append("    <td>");	XYBody.Append(jobinfo.WorkAreaInfo.FullName.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("	<th class=\"line1\">结束时间：</th>\r\n");
	XYBody.Append("    <td>");	XYBody.Append(jobinfo.EndDate.ToShortDateString().ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("  </tr>\r\n");
	XYBody.Append("  <tr>\r\n");
	XYBody.Append("    <th class=\"line1\">职位说明：</th>\r\n");
	XYBody.Append("    <td class=\"w650\" colspan=\"3\">");	XYBody.Append(jobinfo.Request.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("  </tr>\r\n");
	XYBody.Append("  <tr>\r\n");
	XYBody.Append("    <th></th>\r\n");
	XYBody.Append("    <td class=\"w650\" colspan=\"3\"><a href=\"javascript:ApplyJob();\">申请该职位</a></td>\r\n");
	XYBody.Append("  </tr>\r\n");
	XYBody.Append("</table>\r\n");
	XYBody.Append("     <h4>该企业其它职位</h4>\r\n");
	XYBody.Append("	 <div class=\"jobqt\"> \r\n");
	 data = GetOtherJob();
	

	int job__loop__id=0;
	foreach(DataRow job in data.Rows)
	{
		job__loop__id++;

	 infourl = GetInfoUrl("job",job["EI_ID"],job["EI_HTMLPage"]);
	
	XYBody.Append("	 <span>\r\n");
	XYBody.Append("    <a href=\"");	XYBody.Append(infourl.ToString());	XYBody.Append("\">" + job["EI_Job"].ToString().Trim() + "</a></span>\r\n");

	}	//end loop

	XYBody.Append("	 </div>\r\n");
	XYBody.Append("	</div>\r\n");
	XYBody.Append("		<!--联系方式-->\r\n");
	XYBody.Append("    <div class=\"rcon\">\r\n");
	XYBody.Append("    <h2>联系方式</h2>\r\n");
	XYBody.Append("    <!--联系方式-->\r\n");
	XYBody.Append("    <div  class=\"infoAbout\">\r\n");
	XYBody.Append("     <a name=\"link\"></a>\r\n");
	XYBody.Append("     <div id=\"linkmessage\"></div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("	 <!--推荐给好友-->\r\n");
	XYBody.Append("	<div class=\"rcon pb15\">\r\n");
	XYBody.Append("     <h2>推荐给好友</h2>\r\n");
	XYBody.Append("     <div class=\"commentList\">\r\n");
	XYBody.Append("      <ul>\r\n");
	XYBody.Append("        <li><label>您的姓名：<em>*</em></label><input type=\"text\" size=\"30\" id=\"txtFromName\"  maxlength =\"200\"/></li>\r\n");
	XYBody.Append("        <li><label>\r\n");
	XYBody.Append("        您的邮箱：<em>*</em></label><input type=\"text\" size=\"30\" id=\"txtFromEmail\"  maxlength =\"200\"/></li>\r\n");
	XYBody.Append("        <li><label>您朋友邮箱：<em>*</em></label><input type=\"text\" size=\"30\" id=\"txtToEmail\"  maxlength =\"200\"/><i> 多个邮箱以\",\"隔开</i></li>\r\n");
	XYBody.Append("        <li><input name=\"\" type=\"button\" class=\"button\" value=\"确 定\" onclick =\"CommendJob();\"/> \r\n");
	XYBody.Append("        <input type=\"button\" name=\"Submit\"  class=\"button\" value=\"清 空\"   onclick =\"emptycommend();\" /></li>\r\n");
	XYBody.Append("  </ul>\r\n");
	XYBody.Append(" </div> \r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<input type=\"hidden\" id =\"JobId\" value=\"");	XYBody.Append(jobinfo.JobId.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("<input type=\"hidden\" id=\"txtjobname\" value=\"");	XYBody.Append(jobinfo.JobTitle.ToString());	XYBody.Append("\" />\r\n");
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
