<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.shop.cred,XYECOM.Page" %>
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
	XYBody.Append("    <title>服务商个人主页</title>\r\n");
	XYBody.Append("    <link href=\"/Other/css/serverinfo.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n");
	XYBody.Append("    <script src=\"/Other/js/jquery.js\" type=\"text/javascript\"></" + "script>\r\n");
	XYBody.Append("</head>\r\n");
	XYBody.Append("<body>\r\n");
	XYBody.Append("    <!--top start-->\r\n");

	XYBody.Append("<div id=\"top\">\r\n");

	if (islogin)
	{

	XYBody.Append("    <div id=\"top1\">\r\n");
	XYBody.Append("        您好，欢迎&nbsp;&nbsp;<strong>");	XYBody.Append(loginname.ToString());	XYBody.Append("</strong>&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"");	XYBody.Append(editinfourl.ToString());	XYBody.Append("\">修改资料</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a\r\n");
	XYBody.Append("            href=\"");	XYBody.Append(modifypwdurl.ToString());	XYBody.Append("\">修改密码</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a href=\"/\">网站首页</a></div>\r\n");
	XYBody.Append("    <div id=\"top2\">\r\n");
	XYBody.Append("        <a href=\"/LogOut.aspx\">【退出系统】</a></div>\r\n");

	}
	else
	{

	XYBody.Append("    <div id=\"top1\">\r\n");
	XYBody.Append("        <a href=\"/login.aspx\">登陆</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a href=\"/Register.aspx\">注册</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a\r\n");
	XYBody.Append("            href=\"/\">网站首页</a></div>\r\n");

	}	//end if

	XYBody.Append("</div>\r\n");


	XYBody.Append("    <!--top end-->\r\n");

	XYBody.Append("<div id=\"banner\">\r\n");
	XYBody.Append("    <p>\r\n");
	XYBody.Append("        欢迎光临<strong>");	XYBody.Append(shopuserinfo.CompanyName.ToString());	XYBody.Append("</strong>的法律工作室</p>\r\n");
	XYBody.Append("    <font>咨询热线：");	XYBody.Append(shopuserinfo.Telphone.ToString());	XYBody.Append("</font>\r\n");
	XYBody.Append("</div>\r\n");


	XYBody.Append("    <!--menu start-->\r\n");

	XYBody.Append("<div id=\"menu\">\r\n");
	XYBody.Append("    <ul>\r\n");
	XYBody.Append("        <li class='m_li_a'><a href=\"#\">首页</a></li>\r\n");
	XYBody.Append("        <li class=\"m_line\">\r\n");
	XYBody.Append("            <img src=\"/Other/images/line1.gif\" /></li>\r\n");
	XYBody.Append("        <li class='m_li' onmouseover='mover(2);' onmouseout='mout(2);'><a href=\"/shop/");	XYBody.Append(shopuserinfo.LoginName.ToString());	XYBody.Append("/Cred.aspx\">诚信档案</a></li>\r\n");
	XYBody.Append("        <li class=\"m_line\">\r\n");
	XYBody.Append("            <img src=\"/Other/images/line1.gif\" /></li>\r\n");
	XYBody.Append("        <li class='m_li' onmouseover='mover(3);' onmouseout='mout(3);'><a href=\"#\">在线互动</a></li>\r\n");
	XYBody.Append("        <li class=\"m_line\">\r\n");
	XYBody.Append("            <img src=\"/Other/images/line1.gif\" /></li>\r\n");
	XYBody.Append("        <li class='m_li' onmouseover='mover(4);' onmouseout='mout(4);'><a href=\"#\">成功案例</a></li>\r\n");
	XYBody.Append("    </ul>\r\n");
	XYBody.Append("</div>\r\n");


	XYBody.Append("    <!--menu end-->\r\n");
	XYBody.Append("    <!--middle start-->\r\n");
	XYBody.Append("    <div id=\"middle\">\r\n");
	XYBody.Append("        <!--left start-->\r\n");

	XYBody.Append("<div id=\"left\">\r\n");
	XYBody.Append("    <div id=\"leftlszl\">\r\n");
	XYBody.Append("        <div id=\"lszl\">\r\n");
	XYBody.Append("            <p style=\"height: 110px; width: 91px; float: left; line-height: 120px\">\r\n");
	XYBody.Append("                <img src=\"");	XYBody.Append(shopuserinfo.LayerPicture.ToString());	XYBody.Append("\" style=\"height: 76px; width: 86px\" /></p>\r\n");
	XYBody.Append("            <p style=\"height: 96px; width: 138px; float: left; padding-top: 10px\">\r\n");
	XYBody.Append("                <strong>");	XYBody.Append(shopuserinfo.LayerName.ToString());	XYBody.Append("</strong><br />\r\n");
	XYBody.Append("                所在地区：");	XYBody.Append(shopuserinfo.AreaName.ToString());	XYBody.Append("<br />\r\n");
	XYBody.Append("                电话：");	XYBody.Append(shopuserinfo.Telphone.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                <br />\r\n");
	XYBody.Append("            </p>\r\n");
	XYBody.Append("            ~~~~~~~~~~~~~~~~~~~~~~~~<br />\r\n");
	XYBody.Append("            执业证号： ");	XYBody.Append(shopuserinfo.LayerId.ToString());	XYBody.Append("<br />\r\n");
	XYBody.Append("            执业机构： ");	XYBody.Append(shopuserinfo.CompanyName.ToString());	XYBody.Append("<br />\r\n");
	XYBody.Append("            E-mail： ");	XYBody.Append(shopuserinfo.Email.ToString());	XYBody.Append("\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <div id=\"leftpj\">\r\n");
	XYBody.Append("        <div id=\"menutop\">\r\n");
	XYBody.Append("            <h1>\r\n");
	XYBody.Append("                用户评级</h1>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <p>\r\n");
	XYBody.Append("            <strong>华众物流</strong> 共解决案件<strong>");	XYBody.Append(shopuserinfo.Point.ToString());	XYBody.Append("</strong>条<br />\r\n");
	XYBody.Append("            其中：好评：");	XYBody.Append(shopuserinfo.GoodTimes.ToString());	XYBody.Append("个 差评：");	XYBody.Append(shopuserinfo.BadTimes.ToString());	XYBody.Append("个\r\n");
	XYBody.Append("        </p>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("</div>\r\n");


	XYBody.Append("        <!--left end-->\r\n");
	XYBody.Append("        <!--right start-->\r\n");
	XYBody.Append("        <div id=\"right\">\r\n");
	XYBody.Append("            <div id=\"uright\">\r\n");
	XYBody.Append("                <div class=\"rcon pb15\">\r\n");
	XYBody.Append("                    <h2>\r\n");
	XYBody.Append("                        诚信档案</h2>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <div class=\"rcon pb15\">\r\n");
	XYBody.Append("                    <h2>\r\n");
	XYBody.Append("                        <span>证书信息</span></h2>\r\n");
	XYBody.Append("                    <div class=\"list_zs\">\r\n");
	XYBody.Append("                        <ul class=\"bg\">\r\n");
	XYBody.Append("                            <li>证书图片</li><li>证书名称</li><li>发证机构</li><li>生效日期</li><li>截至日期</li>\r\n");
	XYBody.Append("                        </ul>\r\n");
	 data = GetCertificate();
	

	int info__loop__id=0;
	foreach(DataRow info in data.Rows)
	{
		info__loop__id++;

	 str = GetInfoImgHref(info["CE_ID"]);
	
	XYBody.Append("                        <ul class=\"c\">\r\n");
	XYBody.Append("                            <li><a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("\">\r\n");
	XYBody.Append("                                <img src=\"");	XYBody.Append(str.ToString());	XYBody.Append("\" alt=\"证书\" /></a></li>\r\n");
	XYBody.Append("                            <li><a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("\">" + info["CE_Name"].ToString().Trim() + "</a></li>\r\n");
	XYBody.Append("                            <li>" + info["CE_Organ"].ToString().Trim() + "</li>\r\n");
	XYBody.Append("                            <li>\r\n");
	XYBody.Append( Method.formatdatetime(info["CE_Begin"].ToString().Trim(),"yyyy-MM-dd"));
	XYBody.Append("</li>\r\n");
	XYBody.Append("                            <li>\r\n");
	XYBody.Append( Method.formatdatetime(info["CE_Upto"].ToString().Trim(),"yyyy-MM-dd"));
	XYBody.Append("</li>\r\n");
	XYBody.Append("                        </ul>\r\n");

	}	//end loop

	XYBody.Append("                    </div>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <!--right end-->\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <!--middle end-->\r\n");

	XYBody.Append("<div id=\"footer\">\r\n");
	XYBody.Append("    技术支持：<a href=\"#\" target=\"_blank\"> 包青天债权管理网</a>&nbsp;&nbsp;版权所有：<a href='#'> 华众物流</a>&nbsp;&nbsp;\r\n");
	XYBody.Append("    律师执业证号：3270205110055 电话：132323232323 QQ：454547676<br />\r\n");
	XYBody.Append("    您是第787位顾客 总站网站：<a href=\"#\" target=\"_blank\"> www.baoqt.cn</a> <a href=\"#\" target=\"_blank\">\r\n");
	XYBody.Append("        EMAIL：hpbqt@163.com</a>\r\n");
	XYBody.Append("    <br />\r\n");
	XYBody.Append("    <a href=\"#\" target=\"_blank\">国家信息产业部备案 陕ICP备05047375 【西安市公安局网警支队备案：37010009000020】</a>\r\n");
	XYBody.Append("</div>\r\n");


	XYBody.Append("</body>\r\n");
	XYBody.Append("</html>\r\n");

	XYBody.Append("");
	Response.Write(XYBody.ToString());
}
</script>
