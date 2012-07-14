<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.person.adv_postbuy,XYECOM.Page" %>
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
	XYBody.Append("");	XYBody.Append(pageinfo.Meta);	XYBody.Append("\r\n");
	XYBody.Append("<link rel=\"stylesheet\" href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/css/global.css\" type=\"text/css\" media=\"screen\" />\r\n");
	XYBody.Append("</head>\r\n");
	XYBody.Append("<body style=\"background-color:#f2f2f2\">\r\n");
	XYBody.Append("<div id=\"sysMsgbox\">\r\n");
	XYBody.Append("	<ul>\r\n");
	XYBody.Append("	    <li class=\"msg\">");	XYBody.Append(pageinfo.MsgboxText);	XYBody.Append("</li>\r\n");
	XYBody.Append("        <li><a href=\"");	XYBody.Append(pageinfo.MsgboxURL);	XYBody.Append("\">");	XYBody.Append(pageinfo.MsgboxURL);	XYBody.Append("</a></li>\r\n");
	XYBody.Append("         <li><a href=\"#\" onclick=\"history.back();\">返回继续操作</a></li>\r\n");
	XYBody.Append("        <li><a href=\"/\">返回首页</a> | <a href=\"#\" onclick=\"window.close();\">关闭本页</a></li>\r\n");
	XYBody.Append("    </ul>\r\n");
	XYBody.Append("    <div id=\"r_f\">2000-2009　" +  XYECOMCreateHTML("XY_Copyright").ToString() + "　版权所有　</div>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("</body>\r\n");
	XYBody.Append("</html>\r\n");



	Response.Write(XYBody.ToString());
System.Web.HttpContext.Current.Response.End();
	

	}	//end if

	XYBody.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD html 4.01 Transitional//EN\" \"http://www.w3c.org/TR/1999/REC-html401-19991224/loose.dtd\">\r\n");
	XYBody.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n");
	XYBody.Append("<head>\r\n");
	XYBody.Append("<TITLE>个人中心</TITLE>\r\n");
	XYBody.Append("<meta http-equiv=Content-Type content=\"text/html; charset=gb2312\">\r\n");
	XYBody.Append("<meta content=\"个人中心\" name=\"keywords\">\r\n");
	XYBody.Append("<meta content=\"\" name=\"description\">\r\n");
	XYBody.Append("<link href=\"/common/css/XYLib.css\" type=\"text/css\" rel=\"Stylesheet\" />\r\n");
	XYBody.Append("<link href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/person/css/main.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n");
	XYBody.Append("<script language =\"javascript\" type=\"text/javascript\"  src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("common/js/base.js\"></" + "script>\r\n");
	XYBody.Append("<script language =\"javascript\" type=\"text/javascript\"  src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("common/js/UploadControl.js\"></" + "script>\r\n");
	XYBody.Append("<script language =\"javascript\" type=\"text/javascript\"  src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("common/js/date.js\"></" + "script>\r\n");
	XYBody.Append("<script language =\"javascript\" type=\"text/javascript\"  src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/person/js/common.js\"></" + "script>\r\n");
	XYBody.Append("<script language =\"javascript\" type=\"text/javascript\"  src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/person/js/validate.js\"></" + "script>\r\n");
	XYBody.Append("</head>\r\n");
	XYBody.Append("<body onload=\"");	XYBody.Append(pageinfo.OnLoadEvents);	XYBody.Append("\">\r\n");
	XYBody.Append("<div class=div_body>\r\n");
	XYBody.Append("    <div class=New_top>\r\n");
	XYBody.Append("        <div class=more>\r\n");
	XYBody.Append("            <ul>\r\n");
	XYBody.Append("              <li><a class=\"zeroc\" href=\"");	XYBody.Append(config.weburl);	XYBody.Append("\">首页</a> </li>\r\n");
	XYBody.Append("              <li><a class=\"zeroc\" href=\"");	XYBody.Append(config.weburl);	XYBody.Append("news/\">行业资讯</a> </li>\r\n");
	XYBody.Append("              <li><a class=\"zeroc\" href=\"");	XYBody.Append(config.weburl);	XYBody.Append("offer/\">产品库</a> </li>\r\n");
	XYBody.Append("              <li><a class=\"zeroc\" href=\"");	XYBody.Append(config.weburl);	XYBody.Append("investment/\">招商加盟</a> </li>\r\n");
	XYBody.Append("              <li><a class=\"zeroc\" href=\"");	XYBody.Append(config.weburl);	XYBody.Append("exhibition/\">展会</a> </li>\r\n");
	XYBody.Append("              <li><a class=\"zeroc\" href=\"");	XYBody.Append(config.weburl);	XYBody.Append("job/\">人才</a> </li>\r\n");
	XYBody.Append("            </ul>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <div class=\"r\">\r\n");
	XYBody.Append("            <a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("logout.");	XYBody.Append(config.suffix);	XYBody.Append("\">退出</a> | <a href=\"\">帮助</a>&nbsp; \r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<div class=Head>\r\n");
	XYBody.Append("    <div class=\"Head_4\"> \r\n");
	XYBody.Append("        <div class=\"index\"><div class=\"act\"><a href=\"index.");	XYBody.Append(config.suffix);	XYBody.Append("\">主 页</a></div></div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<div class=\"div_body\" style=\"WIDTH: 994px\">\r\n");
	XYBody.Append("    <div class=\"body_bg\">\r\n");
	XYBody.Append("        <div><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/person/images/p1.jpg\"></div>\r\n");
	XYBody.Append("        <div class=\"bodyW\">\r\n");



	XYBody.Append("<div class=\"Al\">\r\n");
	XYBody.Append("    <div class=\"Al_1\">\r\n");
	XYBody.Append("        个人服务列表:</div>\r\n");
	XYBody.Append("    <div class=\"Al_2\">\r\n");
	XYBody.Append("        <dl>\r\n");
	XYBody.Append("            <dt><a class=\"\" id=\"a1\" style=\"padding-right: 10px;\" href=\"javascript:void(0);\">\r\n");
	XYBody.Append("                <img src=\"");	XYBody.Append(config.weburl);	XYBody.Append("/templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/user/images/a9.gif\">\r\n");
	XYBody.Append("                会员账户管理 </a></dt>\r\n");
	XYBody.Append("            <dd id=\"div_1\" style=\"display: block\">\r\n");
	XYBody.Append("                <a href=\"/person/individuallist.");	XYBody.Append(config.Suffix);	XYBody.Append("\">查看注册信息</a><br />\r\n");
	XYBody.Append("                <a href=\"/person/individualinfo.");	XYBody.Append(config.Suffix);	XYBody.Append("\">维护个人资料</a><br />\r\n");
	XYBody.Append("                <a href=\"/person/resume.");	XYBody.Append(config.Suffix);	XYBody.Append("\">维护个人简历</a><br />\r\n");
	XYBody.Append("                <a href=\"/person/edituserpassword.");	XYBody.Append(config.Suffix);	XYBody.Append("\">修改登陆密码</a><br />\r\n");
	XYBody.Append("                <a href=\"/person/editpaypassword.aspx\">修改支付密码</a><br />\r\n");
	XYBody.Append("                <a href=\"/person/resumesend.");	XYBody.Append(config.Suffix);	XYBody.Append("\">职位申请记录</a><br />\r\n");
	XYBody.Append("            </dd>\r\n");
	XYBody.Append("        </dl>\r\n");
	XYBody.Append("        <dl>\r\n");
	XYBody.Append("            <dt><a class=\"\" id=\"a2\" style=\"padding-right: 10px;\" href=\"javascript:void(0);\">\r\n");
	XYBody.Append("                <img src=\"");	XYBody.Append(config.weburl);	XYBody.Append("/templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/user/images/1.gif\" />\r\n");
	XYBody.Append("                留言信息管理 </a></dt>\r\n");
	XYBody.Append("            <dd id=\"div_2\" style=\"display: block\">\r\n");
	XYBody.Append("                <a href=\"/person/receivemessagelist.");	XYBody.Append(config.Suffix);	XYBody.Append("\">我收到的留言信息</a><br />\r\n");
	XYBody.Append("                <a href=\"/person/sendmessagelist.");	XYBody.Append(config.Suffix);	XYBody.Append("\">我发出的留言信息</a><br />\r\n");
	XYBody.Append("                <a href=\"/person/postadministratormessage.");	XYBody.Append(config.Suffix);	XYBody.Append("\">给管理员留言</a><br />\r\n");
	XYBody.Append("            </dd>\r\n");
	XYBody.Append("        </dl>\r\n");
	XYBody.Append("        <dl>\r\n");
	XYBody.Append("            <dt><a class=\"\" id=\"a3\" style=\"padding-right: 10px;\" onclick=\"javascript:switchShow('3')\"\r\n");
	XYBody.Append("                href=\"javascript:void(0);\">\r\n");
	XYBody.Append("                <img src=\"");	XYBody.Append(config.weburl);	XYBody.Append("/templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/user/images/5.gif\" />\r\n");
	XYBody.Append("                财务管理 </a></dt>\r\n");
	XYBody.Append("            <dd id=\"div_3\" style=\"display: block\">\r\n");
	XYBody.Append("                <a href=\"/person/cashacount.");	XYBody.Append(config.Suffix);	XYBody.Append("\">帐户信息</a><br />                \r\n");
	XYBody.Append("                <a href=\"/person/invoice.");	XYBody.Append(config.Suffix);	XYBody.Append("\">申请发票</a><br />\r\n");
	XYBody.Append("                <a href=\"/person/remit.");	XYBody.Append(config.Suffix);	XYBody.Append("\">汇款确认</a><br />\r\n");
	XYBody.Append("            </dd>\r\n");
	XYBody.Append("        </dl>\r\n");
	XYBody.Append("        <dl>\r\n");
	XYBody.Append("            <dt><a class=\"\" id=\"a4\" style=\"padding-right: 10px;\" onclick=\"javascript:switchShow('4')\"\r\n");
	XYBody.Append("                href=\"javascript:void(0);\">\r\n");
	XYBody.Append("                <img src=\"");	XYBody.Append(config.weburl);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/user/images/5.gif\" />\r\n");
	XYBody.Append("                我的交易信息 </a></dt>\r\n");
	XYBody.Append("            <dd id=\"div_4\" style=\"display: block\">\r\n");
	XYBody.Append("                <a href=\"/person/BuyerOrderList.aspx\">采购管理</a><br />\r\n");
	XYBody.Append("                <a href=\"/person/ListBuyerContract.aspx\">合同管理</a><br />\r\n");
	XYBody.Append("                <a href=\"/person/TeamBuy/TeamBuyerOrderList.aspx\">团购订单管理</a><br />\r\n");
	XYBody.Append("            </dd>\r\n");
	XYBody.Append("        </dl>\r\n");
	XYBody.Append("        <dl>\r\n");
	XYBody.Append("            <dt><a class=\"\" id=\"a5\" style=\"padding-right: 10px;\" onclick=\"javascript:switchShow('5')\"\r\n");
	XYBody.Append("                href=\"javascript:void(0);\">\r\n");
	XYBody.Append("                <img src=\"");	XYBody.Append(config.weburl);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/user/images/5.gif\" />\r\n");
	XYBody.Append("                我的求购信息 </a></dt>\r\n");
	XYBody.Append("            <dd id=\"div_5\" style=\"display: block\">\r\n");
	XYBody.Append("                <a href=\"/person/adv_postbuy.aspx\">发布求购</a><br />\r\n");
	XYBody.Append("                <a href=\"/person/supplybuy.aspx\">采购管理</a><br />\r\n");
	XYBody.Append("            </dd>\r\n");
	XYBody.Append("        </dl>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("</div>\r\n");


	XYBody.Append("<div id=\"right\">\r\n");
	XYBody.Append("    <ul class=\"topNav\">\r\n");
	XYBody.Append("        <li><a href=\"index.");	XYBody.Append(config.Suffix);	XYBody.Append("\">商务中心</a> &gt; 发布求购信息 </li>\r\n");
	XYBody.Append("    </ul>\r\n");
	XYBody.Append("    <form action=\"#\" method=\"post\">\r\n");
	XYBody.Append("    <h3>\r\n");
	XYBody.Append("        发布求购信息</h3>\r\n");
	XYBody.Append("    <table class=\"contentl\" id=\"tab_guest_info\" width=\"80%\">\r\n");
	XYBody.Append("        <tr>\r\n");
	XYBody.Append("            <th>\r\n");
	XYBody.Append("                求购状态：<em>*</em>\r\n");
	XYBody.Append("            </th>\r\n");
	XYBody.Append("            <td>\r\n");

	if (id>0 && jinji==1)
	{

	XYBody.Append("                <input type=\"radio\" name=\"jinji\" id=\"jinji0\" value=\"0\">普通求购&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp\r\n");
	XYBody.Append("                <input type=\"radio\" name=\"jinji\" id=\"jinji1\" value=\"1\" checked=\"checked\">紧急求购\r\n");

	}
	else
	{

	XYBody.Append("                <input type=\"radio\" name=\"jinji\" id=\"jinji0\" value=\"0\" checked=\"checked\">普通求购&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp\r\n");
	XYBody.Append("                <input type=\"radio\" name=\"jinji\" id=\"jinji1\" value=\"1\">紧急求购\r\n");

	}	//end if

	XYBody.Append("                <br />\r\n");
	XYBody.Append("                <em>你要求购的产品标题，很重要，请正确填写。</em>\r\n");
	XYBody.Append("            </td>\r\n");
	XYBody.Append("        </tr>\r\n");
	XYBody.Append("        <tr>\r\n");
	XYBody.Append("            <th>\r\n");
	XYBody.Append("                标题：<em>*</em>\r\n");
	XYBody.Append("            </th>\r\n");
	XYBody.Append("            <td>\r\n");
	XYBody.Append("                <input type=\"text\" name=\"title\" id=\"title\" maxlength=\"45\" size=\"20\" style=\"width: 250px;\"\r\n");
	XYBody.Append("                    value=\"");	XYBody.Append(title.ToString());	XYBody.Append("\" /><br />\r\n");
	XYBody.Append("                <em>你要求购的产品标题，很重要，请正确填写。</em>\r\n");
	XYBody.Append("            </td>\r\n");
	XYBody.Append("        </tr>\r\n");
	XYBody.Append("        <tr>\r\n");
	XYBody.Append("            <th>\r\n");
	XYBody.Append("                关键字：<em>*</em>\r\n");
	XYBody.Append("            </th>\r\n");
	XYBody.Append("            <td>\r\n");
	XYBody.Append("                <input type=\"text\" name=\"keyword\" id=\"keyword\" maxlength=\"25\" size=\"20\" style=\"width: 250px;\"\r\n");
	XYBody.Append("                    value=\"");	XYBody.Append(keyword.ToString());	XYBody.Append("\" /><br />\r\n");
	XYBody.Append("                <em>尽量简短，正确描述，有利于商家搜索到你，如：压力变送器</em>\r\n");
	XYBody.Append("            </td>\r\n");
	XYBody.Append("        </tr>\r\n");
	XYBody.Append("        <tr>\r\n");
	XYBody.Append("            <th>\r\n");
	XYBody.Append("                数量：<em>*</em>\r\n");
	XYBody.Append("            </th>\r\n");
	XYBody.Append("            <td>\r\n");
	XYBody.Append("                <input type=\"text\" name=\"num\" id=\"num\" maxlength=\"25\" size=\"20\" value=\"");	XYBody.Append(num.ToString());	XYBody.Append("\" onblur=\"IsNum(this)\"\r\n");
	XYBody.Append("                    style=\"width: 250px;\" /><br />\r\n");
	XYBody.Append("                <em>求购数量</em>\r\n");
	XYBody.Append("            </td>\r\n");
	XYBody.Append("        </tr>\r\n");
	XYBody.Append("        <tr>\r\n");
	XYBody.Append("            <th>\r\n");
	XYBody.Append("                所在地区*\r\n");
	XYBody.Append("            </th>\r\n");
	XYBody.Append("            <td>\r\n");
	XYBody.Append("                <div id=\"classType\">\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <input type=\"hidden\" id=\"citytypeid\" name=\"citytypeid\" />\r\n");
	XYBody.Append("                <input type=\"hidden\" id=\"provinceid\" name=\"provinceid\" />\r\n");
	XYBody.Append("                <input type=\"hidden\" id=\"areatypeid\" name=\"areatypeid\" value=\"");	XYBody.Append(info.Area_id.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("                <script type=\"text/javascript\">\r\n");
	XYBody.Append("                    var cla = new ClassType(\"cla\", 'area', 'classType', 'areatypeid');\r\n");
	XYBody.Append("                    cla.Mode = \"select\";\r\n");
	XYBody.Append("                    cla.Init();\r\n");
	XYBody.Append("                </" + "script>\r\n");
	XYBody.Append("            </td>\r\n");
	XYBody.Append("        </tr>\r\n");
	XYBody.Append("        <tr>\r\n");
	XYBody.Append("            <th>\r\n");
	XYBody.Append("                产品要求：<em>*</em>\r\n");
	XYBody.Append("            </th>\r\n");
	XYBody.Append("            <td>\r\n");
	XYBody.Append("                <textarea cols=\"50\" rows=\"10\" name=\"contents\" id=\"contents\">");	XYBody.Append(contents.ToString());	XYBody.Append("</textarea>\r\n");
	XYBody.Append("                <br />\r\n");
	XYBody.Append("                <em>必填，描述清楚</em>\r\n");
	XYBody.Append("            </td>\r\n");
	XYBody.Append("        </tr>\r\n");
	XYBody.Append("        <tr>\r\n");
	XYBody.Append("            <th>\r\n");
	XYBody.Append("                联系人：<em>*</em>\r\n");
	XYBody.Append("            </th>\r\n");
	XYBody.Append("            <td>\r\n");
	XYBody.Append("                <input type=\"text\" name=\"linkman\" id=\"linkman\" maxlength=\"20\" size=\"10\" style=\"width: 250px;\"\r\n");
	XYBody.Append("                    value=\"");	XYBody.Append(linkMan.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("                <br />\r\n");
	XYBody.Append("                <em>必填，让客户联系到你</em>\r\n");
	XYBody.Append("            </td>\r\n");
	XYBody.Append("        </tr>\r\n");
	XYBody.Append("        <tr>\r\n");
	XYBody.Append("            <th>\r\n");
	XYBody.Append("                电话：<em>*</em>\r\n");
	XYBody.Append("            </th>\r\n");
	XYBody.Append("            <td>\r\n");
	XYBody.Append("                <input type=\"text\" name=\"tel\" id=\"tel\" maxlength=\"100\" size=\"50\" style=\"width: 250px;\"\r\n");
	XYBody.Append("                    value=\"");	XYBody.Append(tel.ToString());	XYBody.Append("\" /><br />\r\n");
	XYBody.Append("                <em>多个号码之间用,号隔开;格式：010-88888888</em>\r\n");
	XYBody.Append("            </td>\r\n");
	XYBody.Append("        </tr>\r\n");
	XYBody.Append("      <!--  <if !(ugpinfo!=null && !ugpinfo.IsUseQuession)%>\r\n");
	XYBody.Append("        <tr>\r\n");
	XYBody.Append("            <th align=\"right\">\r\n");
	XYBody.Append("                <strong class=\"Font14_1\">验证问题:</strong> <span class=\"red\">*</span>\r\n");
	XYBody.Append("            </th>\r\n");
	XYBody.Append("            <td>\r\n");
	XYBody.Append("                <div>\r\n");
	XYBody.Append("                    <span id=\"v_question\"></span><a href=\"javascript:void(0);\" onclick=\"reloadnewquestion();\">\r\n");
	XYBody.Append("                        换个问题 </a>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <div>\r\n");
	XYBody.Append("                    <input type=\"text\" id=\"txtValidateQuestion\" onmouseout=\"_checkanswer(this.value);\"\r\n");
	XYBody.Append("                        onblur=\"_checkanswer(this.value)\" name=\"txtValidateQuestion\" style=\"width: 255px\" />\r\n");
	XYBody.Append("                    <input type=\"hidden\" id=\"v_questionid\" />\r\n");
	XYBody.Append("                    <em id=\"errquestion\"></em>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("            </td>\r\n");
	XYBody.Append("        </tr>\r\n");
	XYBody.Append("        <script type=\"text/javascript\">\r\n");
	XYBody.Append("            var reloadnewquestion = function () {\r\n");
	XYBody.Append("                var ajax = new Ajax(\"xy201\", \"&rm=\" + Math.random());\r\n");
	XYBody.Append("                ajax.onSuccess = function () {\r\n");
	XYBody.Append("                    if (ajax.state.result == \"1\") {\r\n");
	XYBody.Append("                        document.getElementById(\"v_question\").innerHTML = ajax.data.Question;\r\n");
	XYBody.Append("                        document.getElementById(\"v_questionid\").value = ajax.data.QuestionId;\r\n");
	XYBody.Append("                    } else {\r\n");
	XYBody.Append("                        document.getElementById(\"v_question\").innerHTML = \"\";\r\n");
	XYBody.Append("                        document.getElementById(\"v_questionid\").value = \"\";\r\n");
	XYBody.Append("                    }\r\n");
	XYBody.Append("                }\r\n");
	XYBody.Append("            }\r\n");
	XYBody.Append("            reloadnewquestion();\r\n");
	XYBody.Append("            var _checkanswer = function (val) {\r\n");
	XYBody.Append("                var v_answer = document.getElementById(\"txtValidateQuestion\").value;\r\n");
	XYBody.Append("                if (v_answer.length < 1) {\r\n");
	XYBody.Append("                    document.getElementById(\"flag\").value = \"error\";\r\n");
	XYBody.Append("                    document.getElementById(\"errquestion\").innerHTML = \"请输入答案！\";\r\n");
	XYBody.Append("                    return false;\r\n");
	XYBody.Append("                } else {\r\n");
	XYBody.Append("                    document.getElementById(\"errquestion\").innerHTML = \"\";\r\n");
	XYBody.Append("                }\r\n");
	XYBody.Append("                var questionid = document.getElementById(\"v_questionid\").value;\r\n");
	XYBody.Append("                var ajax = new Ajax(\"xy202\", \"&questionid=\" + questionid + \"&answer=\" + v_answer + \"&rm=\" + Math.random());\r\n");
	XYBody.Append("                ajax.onSuccess = function () {\r\n");
	XYBody.Append("                    if (ajax.state.result != \"1\") {\r\n");
	XYBody.Append("                        document.getElementById(\"errquestion\").innerHTML = \"请输入正确答案！\";\r\n");
	XYBody.Append("                        document.getElementById(\"flag\").value = \"error\";\r\n");
	XYBody.Append("                    } else {\r\n");
	XYBody.Append("                        document.getElementById(\"errquestion\").innerHTML = \"\";\r\n");
	XYBody.Append("                        document.getElementById(\"flag\").value = \"\";\r\n");
	XYBody.Append("                    }\r\n");
	XYBody.Append("                }\r\n");
	XYBody.Append("                var msg = document.getElementById(\"flag\").value;\r\n");
	XYBody.Append("                if (msg == \"error\") {\r\n");
	XYBody.Append("                    return false;\r\n");
	XYBody.Append("                }\r\n");
	XYBody.Append("                return true;\r\n");
	XYBody.Append("            }\r\n");
	XYBody.Append("        </" + "script>\r\n");
	XYBody.Append("        /if%>\r\n");
	XYBody.Append("-->\r\n");
	XYBody.Append("     <!--   if !(ugpinfo!=null && !ugpinfo.IsUseCode)%>\r\n");
	XYBody.Append("-->\r\n");
	XYBody.Append("        <tr>\r\n");
	XYBody.Append("            <td colspan=\"2\" style=\"width: 1005\">\r\n");
	XYBody.Append("                <table class=\"contentl mt8\">\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <th align=\"right\">\r\n");
	XYBody.Append("                            <strong class=\"Font14_1\">验证码</strong> <span class=\"red\">*</span>\r\n");
	XYBody.Append("                        </th>\r\n");
	XYBody.Append("                        <td>\r\n");
	XYBody.Append("                            <input id=\"vcode\" type=\"text\" name=\"vcode\" style=\"width: 50px\" />\r\n");
	XYBody.Append("                            <img src=\"/Common/ValidateCode.ashx\" alt=\"看不清点我\" id=\"imgCode\" onclick=\"this.src='/Common/ValidateCode.ashx?='+Math.random();\"\r\n");
	XYBody.Append("                                style=\"cursor: pointer; vertical-align: middle;\" />\r\n");
	XYBody.Append("                            <em id=\"codeerror\"></em>\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                </table>\r\n");
	XYBody.Append("            </td>\r\n");
	XYBody.Append("        </tr>\r\n");
	XYBody.Append("        <script type=\"text/javascript\">\r\n");
	XYBody.Append("            var validateFun = function () {\r\n");
	XYBody.Append("                var val = document.getElementById(\"vcode\").value;\r\n");
	XYBody.Append("                if (val.length < 1) {\r\n");
	XYBody.Append("                    document.getElementById(\"codeflag\").value = \"error\";\r\n");
	XYBody.Append("                    document.getElementById(\"codeerror\").innerHTML = \"请输入验证码！\";\r\n");
	XYBody.Append("                    return false;\r\n");
	XYBody.Append("                } else {\r\n");
	XYBody.Append("                    document.getElementById(\"codeerror\").innerHTML = \"\";\r\n");
	XYBody.Append("                }\r\n");
	XYBody.Append("                var ajax = new Ajax(\"xy200\", \"&vcode=\" + val);\r\n");
	XYBody.Append("                ajax.onSuccess = function () {\r\n");
	XYBody.Append("                    if (ajax.state.result == 0 && ajax.data.content == \"err\") {\r\n");
	XYBody.Append("                        document.getElementById(\"codeflag\").value = \"error\";\r\n");
	XYBody.Append("                        document.getElementById(\"codeerror\").innerHTML = \"请输入正确验证码！\";\r\n");
	XYBody.Append("                    } else if (ajax.state.result == 1) {\r\n");
	XYBody.Append("                        document.getElementById(\"codeflag\").value = \"\";\r\n");
	XYBody.Append("                        document.getElementById(\"codeerror\").innerHTML = \"\";\r\n");
	XYBody.Append("                    }\r\n");
	XYBody.Append("                }\r\n");
	XYBody.Append("            }\r\n");
	XYBody.Append("            document.getElementById(\"vcode\").onmouseout = validateFun;\r\n");
	XYBody.Append("        </" + "script>\r\n");
	XYBody.Append("        <tr>\r\n");
	XYBody.Append("            <td colspan=\"2\" style=\"text-align: center\">\r\n");
	XYBody.Append("                <input type=\"hidden\" id=\"codeflag\" />\r\n");
	XYBody.Append("                <input type=\"hidden\" id=\"flag\" />\r\n");
	XYBody.Append("                <input type=\"submit\" value=\"写好了提交\" id=\"btnStep1\" class=\"button\" />\r\n");
	XYBody.Append("                <script type=\"text/javascript\">\r\n");
	XYBody.Append("                    document.getElementById(\"btnStep1\").onclick = function () {\r\n");
	XYBody.Append("                        var msg = document.getElementById(\"codeflag\").value;\r\n");
	XYBody.Append("                        var flag=document.getElementById(\"flag\").value;\r\n");
	XYBody.Append("                        var areaId=document.getElementById(\"areatypeid\").value;\r\n");
	XYBody.Append("                        if(CheckValuebuy()){\r\n");
	XYBody.Append("                        if (areaId=='0') {\r\n");
	XYBody.Append("                                 return alertmsg(false, '请选择求购地区！');\r\n");
	XYBody.Append("                            }\r\n");
	XYBody.Append("                             if (msg=='error') {         \r\n");
	XYBody.Append("                                return false;\r\n");
	XYBody.Append("                            }\r\n");
	XYBody.Append("                            return true;\r\n");
	XYBody.Append("                        }else{\r\n");
	XYBody.Append("                            return false;\r\n");
	XYBody.Append("                        }\r\n");
	XYBody.Append("                    }\r\n");
	XYBody.Append("                </" + "script>\r\n");
	XYBody.Append("            </td>\r\n");
	XYBody.Append("        </tr>\r\n");
	XYBody.Append("    </table>\r\n");
	XYBody.Append("    </form>\r\n");
	XYBody.Append("</div>\r\n");

	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <div><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/person/images/p2.jpg\"></div>\r\n");
	XYBody.Append("        <br style=\"FONT: 0px/0 arial\" clear=\"all\"/>\r\n");
	XYBody.Append("        <div class=\"foot\">\r\n");
	XYBody.Append("            针对");	XYBody.Append(config.webname);	XYBody.Append("个人中心您有任何使用问题和建议 您可以 <a  href=\"\">联系个人中心管理员</a> 或 <a href=\"\">查看帮助</a> <br><a href=\"http://www.xyecom.com\">XYECOM 简介</a> | <a href=\"\">用户注册</a> | <a class=lan12i href=\"\" target=_top>广告服务</a> | <a class=lan12i href=\"\" target=_top>招聘</a> | <a class=lan12i href=\"\" target=_top>站点地图</a> | <a class=lan12i href=\"\" target=_top>联系方式</a> | <a class=lan12i href=\"\" target=_top>欢迎投稿 </a>| <a href=\"\">图库 </a>| <a class=lan12i href=\"\" target=_top>RSS订阅</a> <br>Copyright &copy; 2005 - 2009 XYECOM. All rights reserved. ");	XYBody.Append(config.webname);	XYBody.Append(" 版权所有. \r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <br style=\"CLEAR: both\">\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("</body>\r\n");
	XYBody.Append("</html>\r\n");



	XYBody.Append(IsCopyright());
	Response.Write(XYBody.ToString());
}
</script>
