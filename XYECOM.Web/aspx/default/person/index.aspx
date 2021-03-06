<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.person.index,XYECOM.Page" %>
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


	XYBody.Append("    <div class=\"location fia\"><a href=\"index.");	XYBody.Append(config.suffix);	XYBody.Append("\">会员中心</a> &gt;  面板首页 </div>\r\n");

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
	XYBody.Append("<form action=\"#\" id=\"\">\r\n");
	XYBody.Append("    <div class=\"container\">\r\n");
	XYBody.Append("    <div class=\"containerImg\">\r\n");
	XYBody.Append("        <img src=\"");	XYBody.Append(userinfo.imgurl.ToString());	XYBody.Append("\"  alt=\"用户照片\"  width =\"130px\" height =\"130px\"/>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <div class=\"containerCue\">\r\n");
	XYBody.Append("    <ul>\r\n");
	XYBody.Append("	<li>欢迎您<em>(");	XYBody.Append(userinfo.realname.ToString());	XYBody.Append(")");	XYBody.Append(userinfo.sex.ToString());	XYBody.Append("</em>注：个人会员</li>\r\n");
	XYBody.Append("	<!--<li> 您的虚拟帐户现有： <em>");	XYBody.Append(dummymoney.ToString());	XYBody.Append("</em>个");	XYBody.Append(WI_WebMoney.ToString());	XYBody.Append("</li>-->\r\n");
	XYBody.Append("    <li>您的可用金额:<em>");	XYBody.Append(cash.ToString());	XYBody.Append("元</em><a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("person/accountrecharge.");	XYBody.Append(config.Suffix);	XYBody.Append("\">在线充值</a></li>\r\n");
	XYBody.Append("    <li>您的余额:<em>");	XYBody.Append(Balance.ToString());	XYBody.Append("元</em></li>\r\n");
	XYBody.Append("    <li>您的保证金(小额):<em>");	XYBody.Append(S_Margin.ToString());	XYBody.Append("元</em></li>\r\n");
	XYBody.Append("    <li>您的保证金(大额):<em>");	XYBody.Append(C_Margin.ToString());	XYBody.Append("元</em></li>\r\n");
	XYBody.Append("    <li>您现有留言<em>");	XYBody.Append(messagecount.ToString());	XYBody.Append("</em>条 未查看 <a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("person/receivemessagelist.");	XYBody.Append(config.Suffix);	XYBody.Append("?nosee=0\">立即查看</a></li>                  \r\n");
	XYBody.Append("	<li> 您已申请了<em>");	XYBody.Append(resumecounts.ToString());	XYBody.Append("</em>个职位  同意面试<em>");	XYBody.Append(resumecount.ToString());	XYBody.Append("</em><a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("person/resumesend.");	XYBody.Append(config.Suffix);	XYBody.Append("\">立即查看</a></li>\r\n");
	XYBody.Append("	<li>");	XYBody.Append(bbs.ToString());	XYBody.Append("</li>\r\n");
	XYBody.Append("	<li class=\"time\">开通时间：");	XYBody.Append(starttime.ToString());	XYBody.Append("</li>\r\n");
	XYBody.Append("	</ul>\r\n");
	XYBody.Append("  </div>\r\n");
	XYBody.Append(" </div>\r\n");
	XYBody.Append("    <div class=\"clear\"></div>\r\n");
	XYBody.Append(" </form> \r\n");
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
