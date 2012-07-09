<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.shop.index,XYECOM.Page" %>
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
	XYBody.Append("<meta name=\"Copyright\" content=\"copyright (c) www.xyecs.com.��Ȩ����.\" />\r\n");
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
	XYBody.Append("<!--ͷ������ header-->\r\n");
	XYBody.Append("<div id=\"head\">\r\n");
	XYBody.Append("    <div id=\"TopInfo\"><span>\r\n");
	XYBody.Append("    ");	XYBody.Append(pageinfo.LoginStatus);	XYBody.Append("\r\n");
	XYBody.Append("    |<a href=\"http://www.yylm.org/contents/859/11418.html\">��ϵ����</a></span><a href=\"http://www.yylm.org\" target=\"_blank\" style=\"color:#00f;text-decoration: underline;;\">�й�Ӫ������</a>�����й�Ӫ��������ҵ�����һƷ��</div>\r\n");
	XYBody.Append("	<div id=\"htop\">\r\n");
	XYBody.Append("		<a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("\"><img src=\"");	XYBody.Append(config.WebLogo);	XYBody.Append("\" alt=\"������ҳ\" /></a>\r\n");
	XYBody.Append("		<div id=\"hri\">\r\n");
	XYBody.Append("		   <ul id=\"nav\">\r\n");
	XYBody.Append("		    <li id=\"ssoffer\" class=\"on\"><a href=\"javascript:shoptopflag(1);\">����</a></li>\r\n");
	XYBody.Append("			<li id=\"ssmachining\" ><a href=\"javascript:shoptopflag(2);\">�ӹ�</a></li>\r\n");
	XYBody.Append("			<li id=\"ssinvestment\" ><a href=\"javascript:shoptopflag(3);\">����</a></li>\r\n");
	XYBody.Append("			<li id=\"ssservice\" ><a href=\"javascript:shoptopflag(4);\">����</a></li>\r\n");
	XYBody.Append("			<li id=\"ssexhibition\" ><a href=\"javascript:shoptopflag(5);\">չ��</a></li>\r\n");
	XYBody.Append("			<li id=\"ssbrand\" ><a href=\"javascript:shoptopflag(6);\">Ʒ��</a></li>\r\n");
	XYBody.Append("		   </ul>\r\n");
	XYBody.Append("		   <ul id=\"nav2\">\r\n");
	XYBody.Append("		    <li><input type=\"text\" class=\"button_text1\" size=\"43\" maxlength=\"50\" id=\"shopsearchkey\" /> <input type=\"button\" class=\"button_search1 button\" value=\"����\" onclick=\"shoptopsearch();\" /></li>\r\n");
	XYBody.Append("		   </ul>\r\n");
	XYBody.Append("		</div>\r\n");
	XYBody.Append("	</div>\r\n");
	XYBody.Append("    <div id=\"hcen\">");	XYBody.Append(shopuserinfo.unitname.ToString());	XYBody.Append("</div>\r\n");
	XYBody.Append("	<div id=\"hbot\">\r\n");
	XYBody.Append("		<em class=\"colorFF7B00\"><a href=\"javascript:Favorite();\">�����ղ�</a></em>\r\n");
	XYBody.Append("		<span>\r\n");

	if (shopuserinfo.gradeimgurl!="")
	{

	XYBody.Append("		    <img src=\"");	XYBody.Append(shopuserinfo.gradeimgurl.ToString());	XYBody.Append("\" alt=\"\"  width =\"17px\" height =\"19px\"/>��\r\n");

	}
	else
	{

	XYBody.Append("	        <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/WelcomeInfro_32.gif\" alt=\"\"  width =\"17px\" height =\"19px\"/>\r\n");

	}	//end if

	XYBody.Append("	    ");	XYBody.Append(shopuserinfo.gradename.ToString());	XYBody.Append(" \r\n");
	XYBody.Append("	    �� <span class=\"colorFF7B00s\">");	XYBody.Append(year.ToString());	XYBody.Append("</span> �� </span>		\r\n");
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


	XYBody.Append("	<div id=\"ubox\">\r\n");
	XYBody.Append("<!--��ߵ���-->\r\n");
	XYBody.Append("<div id=\"uleftnav\">\r\n");

	 str = GetLinkPrefix();
	
	XYBody.Append("<div>\r\n");
	XYBody.Append("    <a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("index.");	XYBody.Append(config.Suffix);	XYBody.Append("\">������ҳ</a></div>\r\n");
	XYBody.Append("<div>\r\n");
	XYBody.Append("    <a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("introduction.");	XYBody.Append(config.Suffix);	XYBody.Append("\">��˾���</a></div>\r\n");
	XYBody.Append("<div>\r\n");
	XYBody.Append("    <a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("product.");	XYBody.Append(config.Suffix);	XYBody.Append("\">��Ʒչʾ</a></div>\r\n");
	XYBody.Append("<div>\r\n");
	XYBody.Append("    <a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("venturelist.");	XYBody.Append(config.Suffix);	XYBody.Append("\">Ͷ������Ϣ</a></div>\r\n");
	XYBody.Append("<div>\r\n");
	XYBody.Append("    <a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("cred.");	XYBody.Append(config.Suffix);	XYBody.Append("\">���ŵ���</a></div>\r\n");
	XYBody.Append("<div>\r\n");
	XYBody.Append("    <a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("brandlist.");	XYBody.Append(config.Suffix);	XYBody.Append("\">Ʒ�ƽ���</a></div>\r\n");
	XYBody.Append("<div>\r\n");
	XYBody.Append("    <a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("newslist.");	XYBody.Append(config.Suffix);	XYBody.Append("\">��˾��̬</a></div>\r\n");
	XYBody.Append("<div>\r\n");
	XYBody.Append("    <a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("joblist.");	XYBody.Append(config.Suffix);	XYBody.Append("\">�˲���Ƹ</a></div>\r\n");
	XYBody.Append("<div>\r\n");
	XYBody.Append("    <a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("contact.");	XYBody.Append(config.Suffix);	XYBody.Append("\">��ϵ��ʽ</a>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<div>\r\n");
	XYBody.Append("    <a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("list----.");	XYBody.Append(config.Suffix);	XYBody.Append("\">�Ź���Ϣ</a>\r\n");
	XYBody.Append("</div>\r\n");


	XYBody.Append("</div>\r\n");
	XYBody.Append("<!--��ߵ���  end-->\r\n");
	XYBody.Append("<!--�ұ���Ҫ����-->\r\n");
	XYBody.Append("<div id=\"uright\">\r\n");
	XYBody.Append("	<!--�Ƽ���Ʒ-->\r\n");
	XYBody.Append("	<div class=\"rcon topimg pb15\">\r\n");
	XYBody.Append("	 <h2>���²�Ʒ</h2>\r\n");
	XYBody.Append("	    <ul>\r\n");
	 data = GetNewPro(10);
	

	int newdata__loop__id=0;
	foreach(DataRow newdata in data.Rows)
	{
		newdata__loop__id++;

	 str = GetInfoUrl("offer",newdata["InfoFlag"],newdata["InfoId"],newdata["htmlpage"]);
	
	 str1 = GetInfoImgHref("offer",newdata["InfoId"]);
	
	XYBody.Append("			<li>\r\n");
	XYBody.Append("           <a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("\"><em><img src=\"");	XYBody.Append(str1.ToString());	XYBody.Append("\" alt=\"" + newdata["infoTitle"].ToString().Trim() + "\" width=\"120\" height=\"120\" /></em></a><br/>\r\n");
	XYBody.Append("           <a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("\" class=\"font12s\">\r\n");
	XYBody.Append( Method.left(newdata["infoTitle"].ToString().Trim(),15));
	XYBody.Append("			</a>\r\n");
	XYBody.Append("			</li>\r\n");

	if (newdata__loop__id%5==0)
	{

	XYBody.Append("			</ul>\r\n");
	XYBody.Append("		    <ul>\r\n");

	}	//end if


	}	//end loop

	XYBody.Append("		</ul>	\r\n");
	XYBody.Append("	</div>\r\n");
	XYBody.Append("	<!--��˾����-->\r\n");
	XYBody.Append("	<div class=\"rcon\">\r\n");
	XYBody.Append("	<h2>��˾����</h2>\r\n");
	XYBody.Append("	<p class=\"font142\">\r\n");

	if (shopuserinfo.imgurl!="")
	{

	XYBody.Append("<img alt=\"");	XYBody.Append(shopuserinfo.unitname.ToString());	XYBody.Append("\" src=\"");	XYBody.Append(shopuserinfo.imgurl.ToString());	XYBody.Append("\" />\r\n");

	}
	else
	{

	XYBody.Append("<img alt=\"");	XYBody.Append(shopuserinfo.unitname.ToString());	XYBody.Append("\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/WelcomeInfro_32.gif\" />\r\n");

	}	//end if

	XYBody.Append("");	XYBody.Append(shopuserinfo.synopsis.ToString());	XYBody.Append("</p>\r\n");
	XYBody.Append("<div class=\"txtlink\">\r\n");

	if (config.IsDomain==true)
	{

	XYBody.Append("<a href=\"introduction.");	XYBody.Append(config.Suffix);	XYBody.Append("\">\r\n");

	}
	else
	{


	if (config.BogusStatic==true)
	{

	XYBody.Append("<a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("shop/");	XYBody.Append(shopuserinfo.loginname.ToString());	XYBody.Append("/introduction.");	XYBody.Append(config.Suffix);	XYBody.Append("\">\r\n");

	}
	else
	{

	XYBody.Append("<a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("shop/introduction.");	XYBody.Append(config.Suffix);	XYBody.Append("?u_name=");	XYBody.Append(shopuserinfo.loginname.ToString());	XYBody.Append("\">\r\n");

	}	//end if


	}	//end if

	XYBody.Append("�鿴��ϸ����</a></div>\r\n");
	XYBody.Append("<table class=\"table_value\">\r\n");
	XYBody.Append("<tr>\r\n");
	XYBody.Append("    <th class=\"line1\">��˾��ҳ��</th>\r\n");
	XYBody.Append("    <td>\r\n");
	XYBody.Append("    <a href=\"");	XYBody.Append(shopuserinfo.homepage.ToString());	XYBody.Append("\">");	XYBody.Append(shopuserinfo.homepage.ToString());	XYBody.Append("</a>\r\n");
	XYBody.Append("    </td>\r\n");
	XYBody.Append("	<th class=\"line1\">��˾���ʣ�</th>\r\n");
	XYBody.Append("    <td>");	XYBody.Append(shopuserinfo.character.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("  </tr>\r\n");
	XYBody.Append("   <tr>\r\n");
	XYBody.Append("    <th class=\"line1 colorFF7300\">��ҵ���ͣ�</th>\r\n");
	XYBody.Append("    <td>");	XYBody.Append(shopuserinfo.unittype.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("    <th class=\"line1 colorFF7300\">��ϵ�ˣ�</th>\r\n");
	XYBody.Append("        <td>");	XYBody.Append(shopuserinfo.linkman.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("  </tr>\r\n");
	XYBody.Append("  <tr>\r\n");
	XYBody.Append("    <th class=\"line1\">Ա��������</th>\r\n");
	XYBody.Append("    <td>");	XYBody.Append(shopuserinfo.employeetotal.ToString());	XYBody.Append("��</td>\r\n");
	XYBody.Append("	<th class=\"line1 colorFF7300\">��˾���ڵأ�</th>\r\n");
	XYBody.Append("    <td>");	XYBody.Append(shopuserinfo.regarea.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("  </tr>\r\n");
	XYBody.Append("</table>\r\n");
	XYBody.Append("	</div>\r\n");
	XYBody.Append("	<!--��Ӧ���󹺣�����-->\r\n");
	XYBody.Append("	<div class=\"rcon\">\r\n");
	XYBody.Append("	 <div class=\"rtit\">\r\n");
	XYBody.Append("	 ");	XYBody.Append(pageinfo.InfoListLink);	XYBody.Append("\r\n");
	XYBody.Append("	 </div>\r\n");
	XYBody.Append("	 <div id=\"rtxt\">\r\n");
	 data = GetShopIndexPro(10);
	

	int info__loop__id=0;
	foreach(DataRow info in data.Rows)
	{
		info__loop__id++;

	 str = GetInfoUrl("offer",info["InfoFlag"],info["InfoId"],info["htmlpage"]);
	
	 str1 = GetInfoImgHref("offer",info["InfoId"]);
	
	XYBody.Append("            <div class=\"rtxtq\">\r\n");
	XYBody.Append("           <a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("\"><em><img src=\"");	XYBody.Append(str1.ToString());	XYBody.Append("\" alt=\"" + info["InfoTitle"].ToString().Trim() + "\" /></em>\r\n");
	XYBody.Append("	  </a>\r\n");
	XYBody.Append("	  <ul>\r\n");
	XYBody.Append("	  <li class=\"bg\">\r\n");
	XYBody.Append("	  <span class=\"font14s\"><a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("\"> \r\n");
	XYBody.Append( Method.left(info["InfoTitle"].ToString().Trim(),50));
	XYBody.Append("</a></span>\r\n");
	XYBody.Append("	  ( ����ʱ�䣺 " + info["addtime"].ToString().Trim() + " )\r\n");
	XYBody.Append("	  </li>\r\n");
	XYBody.Append("	  <li class=\"border\">\r\n");
	XYBody.Append( Method.left(info["details"].ToString().Trim(),200));
	XYBody.Append("</li>\r\n");
	XYBody.Append("	  </ul>\r\n");
	XYBody.Append("	 </div>\r\n");

	}	//end loop

	XYBody.Append("	 </div>\r\n");
	XYBody.Append("	</div>\r\n");
	XYBody.Append("	<!--��ϵ��ʽ-->\r\n");
	XYBody.Append("	<div class=\"rcon\">\r\n");
	XYBody.Append("	<h2>��ϵ��ʽ</h2>\r\n");
	XYBody.Append("	 <div id=\"linkmessage\"></div>\r\n");
	XYBody.Append("     <div><em id=\"clicknum\" style=\"display :none \"></em><em id=\"msy\" style=\"display :none \"></em><em id=\"clicknum1\" style=\"display :none \"></em><em id=\"messnum\" style=\"display :none \"></em> </div>\r\n");
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
	XYBody.Append("                                    <tr><td align=\"middle\">��˾��ַ��");	XYBody.Append(shopuserinfo.address.ToString());	XYBody.Append("</td></tr><br/>\r\n");
	XYBody.Append("                                    <tr>\r\n");
	XYBody.Append("                                    <td align=\"middle\">\r\n");
	XYBody.Append("                                        <a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("\" target=\"_blank\"> �й�Ӫ������-�ṩƽ̨֧��</a> | \r\n");
	XYBody.Append("                            <a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("feedback.");	XYBody.Append(config.suffix);	XYBody.Append("\" target=\"_blank\">�������</a> | \r\n");
	XYBody.Append("                                        <a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("login.");	XYBody.Append(config.suffix);	XYBody.Append("\" target=\"_blank\">������վ</a>\r\n");
	XYBody.Append("      <br/>	\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<!--foot end-->	\r\n");
	XYBody.Append("</body>\r\n");
	XYBody.Append("</html>\r\n");


	XYBody.Append("<hr />\r\n");
	XYBody.Append("" +  XYECOMCreateHTML("XY_tbtest").ToString() + "\r\n");

	XYBody.Append("");
	Response.Write(XYBody.ToString());
}
</script>
