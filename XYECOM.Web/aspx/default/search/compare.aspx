<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.search.compare,XYECOM.Page" %>
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
	XYBody.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\" >\r\n");
	XYBody.Append("<head>\r\n");
	XYBody.Append("	<title> 信息图片 - ");	XYBody.Append(config.webname);	XYBody.Append("</title>\r\n");
	XYBody.Append("	<meta name=\"description\" content=\"xyecom\" />\r\n");
	XYBody.Append("	<meta name=\"keywords\" content=\"xyecom\" />\r\n");
	XYBody.Append("	<meta name=\"robots\" content=\"all\"  />\r\n");
	XYBody.Append("	<meta http-equiv=\"Content-Type\" content=\"text/html; charset=gb2312\" />\r\n");
	XYBody.Append("	<link href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("common/css/xylib.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n");
	XYBody.Append("	<link href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/css/global.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n");
	XYBody.Append("	<link href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/css/search.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n");
	XYBody.Append("	<script type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("common/js/base.js\" language=\"javascript\"></" + "script>\r\n");
	XYBody.Append("	<script type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/js/login.js\" language=\"javascript\"></" + "script>\r\n");
	XYBody.Append("	<script type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/js/ShowImg.js\" language=\"javascript\"></" + "script>\r\n");
	XYBody.Append("</head>\r\n");
	XYBody.Append("<body>\r\n");
	XYBody.Append("<div id=\"wrapper\">\r\n");

	XYBody.Append("<div id=\"hd_info\">\r\n");
	XYBody.Append("    <div id=\"cnts\">\r\n");
	XYBody.Append("        <div id=\"site_cang\">\r\n");
	XYBody.Append("            <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/ico_idx.gif\" width=\"16\"\r\n");
	XYBody.Append("                height=\"16\" alt=\"\" align=\"absmiddle\" />\r\n");
	XYBody.Append("            <a href=\"#\" onclick=\"this.style.behavior='url(#default#homepage)';this.setHomePage('");	XYBody.Append(config.WebURL);	XYBody.Append("');\">\r\n");
	XYBody.Append("                设为首页</a>&nbsp;&nbsp;\r\n");
	XYBody.Append("            <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/ico_cang.gif\" width=\"16\"\r\n");
	XYBody.Append("                height=\"16\" alt=\"\" align=\"absmiddle\" />\r\n");
	XYBody.Append("            <a style=\"cursor: hand\" onclick=\"window.external.addFavorite('");	XYBody.Append(config.WebURL);	XYBody.Append("','纵横易商软件')\">\r\n");
	XYBody.Append("                加为收藏</a>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <div id=\"log_info\">\r\n");
	XYBody.Append("            <div id=\"login\">\r\n");
	XYBody.Append("                用户名：<input type=\"text\" class=\"com\" name=\"top_username\" id=\"top_username\" onkeydown=\"_xy_KeyNext('top_password');\" />\r\n");
	XYBody.Append("                密码：<input type=\"password\" name=\"top_password\" class=\"com\" id=\"top_password\" onkeydown=\"_xy_KeyPress('_btnTopLogin');\" />\r\n");

	if (config.IsEnabledVCode("login"))
	{

	XYBody.Append("                验证码： ");	XYBody.Append(pageinfo.GetValidateCodeHTML("top_vcode","top_vimg"));	XYBody.Append("\r\n");

	}	//end if

	XYBody.Append("                <input id=\"_btnTopLogin\" type=\"button\" class=\"top_login\" onclick=\"return xy_TopLogin();\" />\r\n");
	XYBody.Append("                &nbsp;&nbsp;<a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("register.");	XYBody.Append(config.Suffix);	XYBody.Append("\">注册</a> | <a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("getPassword.");	XYBody.Append(config.Suffix);	XYBody.Append("\">\r\n");
	XYBody.Append("                    忘记密码</a> | <a href=\"##\">[VIP会员]</a> | <a href=\"##\">帮助中心</a>| <a style=\"color:Red\" href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("quickbuy.");	XYBody.Append(config.Suffix);	XYBody.Append("\">快速发布求购</a>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <span id=\"logined\" style=\"display: none;\">欢迎您，<font id=\"uname\"></font> | <a id=\"ucenter\">\r\n");
	XYBody.Append("            我的用户中心</a>| <a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("logout.");	XYBody.Append(config.suffix);	XYBody.Append("\">[退出]</a> <font id=\"logined_user\"\r\n");
	XYBody.Append("                style=\"display: none;\">企业用户相关内容</font> <font id=\"logined_person\" style=\"display: none;\">\r\n");
	XYBody.Append("                    个人用户相关内容</font> </span>\r\n");
	XYBody.Append("        <div class=\"clr\">\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<div class=\"clr\">\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<script>    Login2();</" + "script>\r\n");


	XYBody.Append("	<div id=\"gq_guide\">\r\n");
	XYBody.Append("		您现在的位置：<a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("\">首页</a> > 图片展示\r\n");
	XYBody.Append("	</div>\r\n");
	XYBody.Append("    <div id=\"s_body\">\r\n");

	if (pageinfo.ModuleFlag=="offer")
	{

	XYBody.Append("<!--供求信息-->\r\n");
	XYBody.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"compareTab\">\r\n");
	XYBody.Append("    <tr>\r\n");
	XYBody.Append("        <td valign=\"top\">\r\n");
	XYBody.Append("            <table>\r\n");
	XYBody.Append("                    <!--类别 -->\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <th class=\"title\">信息标题</th>     \r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <!--类别内容 --> \r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <td style=\"height:110px;\">信息图片\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                         <td class=\"gray\">价格</td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <!--类别 -->     \r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                         <th class=\"title\">基本参数</th>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                         <td>信息类别</td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                         <td class=\"graybg\">最小起定量</td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                     <tr>\r\n");
	XYBody.Append("                        <td>货物数量</td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                    <td class=\"graybg\">发布时间</td>\r\n");
	XYBody.Append("                    </tr> \r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <td>有效时间</td>\r\n");
	XYBody.Append("                    </tr>   \r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <td class=\"graybg\">信息描述</td>\r\n");
	XYBody.Append("                    </tr>         \r\n");
	XYBody.Append("            </table>\r\n");
	XYBody.Append("        </td>\r\n");

	int info__loop__id=0;
	foreach(SupplyInfo info in list)
	{
		info__loop__id++;

	XYBody.Append("        <td valign=\"top\">\r\n");
	XYBody.Append("            <table>\r\n");
	XYBody.Append("                    <!--类别 -->\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <th class=\"title\">\r\n");
	XYBody.Append( Method.filter(info.UserID.ToString().Trim(),info.Title.ToString().Trim()));
	XYBody.Append("</th>     \r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <!--类别内容 --> \r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <td style=\"height:110px;\">\r\n");

	if (info.SmallImg[0].ToString().Trim()=="")
	{

	XYBody.Append("                            <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/WelcomeInfro_32.gif\" alt=\"pro\" />\r\n");

	}
	else
	{

	XYBody.Append("                            <img width=\"110px\" height=\"100px;\" src=\"" + info.SmallImg[0].ToString().Trim() + "\" alt=\"pro\" /> \r\n");

	}	//end if

	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                         <td class=\"gray\">\r\n");

	if ((Convert.ToInt32(info.Price)).ToString()=="0")
	{

	XYBody.Append("                            面议\r\n");

	}
	else
	{

	XYBody.Append("                            ");	XYBody.Append(info.Price.ToString().ToString());	XYBody.Append(" 元\r\n");

	}	//end if

	XYBody.Append("                         </td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <!--类别 -->     \r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                         <th class=\"title\">基本参数</th>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                         <td>");	XYBody.Append(info.SortName.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                         <td class=\"graybg\">");	XYBody.Append(info.LeastNum.ToString());	XYBody.Append("");	XYBody.Append(info.Unit.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                     <tr>\r\n");
	XYBody.Append("                        <td>");	XYBody.Append(info.CountNum.ToString());	XYBody.Append("");	XYBody.Append(info.Unit.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                    <td class=\"graybg\">");	XYBody.Append(info.PublishTime.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("                    </tr> \r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <td>");	XYBody.Append(info.UseFulDate.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("                    </tr>   \r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <td class=\"graybg\">\r\n");
	XYBody.Append( Method.filter(info.UserID.ToString().Trim(),info.InfoContent.ToString().Trim()));
	XYBody.Append("</td>\r\n");
	XYBody.Append("                    </tr>         \r\n");
	XYBody.Append("            </table>\r\n");
	XYBody.Append("        </td>\r\n");

	}	//end loop

	XYBody.Append("    </tr>\r\n");
	XYBody.Append("</table>\r\n");

	}	//end if

	XYBody.Append("<!-- 加工 -->\r\n");

	if (pageinfo.ModuleFlag=="venture")
	{

	XYBody.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"compareTab\">\r\n");
	XYBody.Append("    <tr>\r\n");
	XYBody.Append("        <td valign=\"top\">\r\n");
	XYBody.Append("            <table>\r\n");
	XYBody.Append("                    <!--类别 -->\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <th class=\"title\">信息标题</th>     \r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <!--类别内容 --> \r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <td style=\"height:110px;\">信息图片\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                         <td class=\"gray\">价格</td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <!--类别 -->     \r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                         <th class=\"title\">基本参数</th>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                         <td>信息类别</td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                         <td class=\"graybg\">最小起定量</td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                     <tr>\r\n");
	XYBody.Append("                        <td>货物数量</td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                    <td class=\"graybg\">发布时间</td>\r\n");
	XYBody.Append("                    </tr> \r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <td>有效时间</td>\r\n");
	XYBody.Append("                    </tr>   \r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <td class=\"graybg\">信息描述</td>\r\n");
	XYBody.Append("                    </tr>         \r\n");
	XYBody.Append("            </table>\r\n");
	XYBody.Append("        </td>\r\n");

	int dinfo__loop__id=0;
	foreach(DemandInfo dinfo in list)
	{
		dinfo__loop__id++;

	XYBody.Append("            <td valign=\"top\">\r\n");
	XYBody.Append("            <table>\r\n");
	XYBody.Append("                    <!--类别 -->\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <th class=\"title\">\r\n");
	XYBody.Append( Method.filter(dinfo.UserID.ToString().Trim(),dinfo.Title.ToString().Trim()));
	XYBody.Append("</th>     \r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <!--类别内容 --> \r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <td style=\"height:110px;\">\r\n");

	if (dinfo.SmallImg[0].ToString().Trim()=="")
	{

	XYBody.Append("                            <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/WelcomeInfro_32.gif\" alt=\"pro\" />\r\n");

	}
	else
	{

	XYBody.Append("                            <img width=\"110px\" height=\"100px;\" src=\"" + dinfo.SmallImg[0].ToString().Trim() + "\" alt=\"pro\" /> \r\n");

	}	//end if

	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                         <td class=\"gray\">\r\n");

	if ((Convert.ToInt32(dinfo.Price)).ToString()=="0")
	{

	XYBody.Append("                            面议\r\n");

	}
	else
	{

	XYBody.Append("                            ");	XYBody.Append(dinfo.Price.ToString().ToString());	XYBody.Append(" 元\r\n");

	}	//end if

	XYBody.Append("                         </td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <!--类别 -->     \r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                         <th class=\"title\">基本参数</th>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                         <td>");	XYBody.Append(dinfo.SortName.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                         <td class=\"graybg\">");	XYBody.Append(dinfo.LeastNum.ToString());	XYBody.Append("");	XYBody.Append(dinfo.Unit.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                     <tr>\r\n");
	XYBody.Append("                        <td>");	XYBody.Append(dinfo.CountNum.ToString());	XYBody.Append("");	XYBody.Append(dinfo.Unit.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                    <td class=\"graybg\">");	XYBody.Append(dinfo.PublishTime.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("                    </tr> \r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <td>");	XYBody.Append(dinfo.UseFulDate.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("                    </tr>   \r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <td class=\"graybg\">\r\n");
	XYBody.Append( Method.filter(dinfo.UserID.ToString().Trim(),dinfo.InfoContent.ToString().Trim()));
	XYBody.Append("</td>\r\n");
	XYBody.Append("                    </tr>         \r\n");
	XYBody.Append("            </table>\r\n");
	XYBody.Append("        </td>\r\n");

	}	//end loop

	XYBody.Append("    </tr>\r\n");
	XYBody.Append("</table>\r\n");

	}	//end if


	if (pageinfo.ModuleFlag=="investment")
	{

	XYBody.Append("<!--招商代理信息-->\r\n");
	XYBody.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"compareTab\">\r\n");
	XYBody.Append("    <tr>\r\n");
	XYBody.Append("        <td valign=\"top\">\r\n");
	XYBody.Append("            <table>\r\n");
	XYBody.Append("                    <!--类别 -->\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <th class=\"title\">信息标题</th>     \r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <!--类别内容 --> \r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <td style=\"height:110px;\">信息图片\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                         <td class=\"gray\">信息类别</td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <!--类别 -->     \r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                         <th class=\"title\">基本参数</th>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                         <td>招商区域</td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <td>发布时间</td>\r\n");
	XYBody.Append("                    </tr> \r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <td class=\"graybg\">有效时间</td>\r\n");
	XYBody.Append("                    </tr>   \r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <td>信息描述</td>\r\n");
	XYBody.Append("                    </tr>         \r\n");
	XYBody.Append("            </table>\r\n");
	XYBody.Append("        </td>\r\n");

	int iinfo__loop__id=0;
	foreach(XYECOM.Model.InviteBusinessmanInfo iinfo in list)
	{
		iinfo__loop__id++;

	XYBody.Append("        <td valign=\"top\">\r\n");
	XYBody.Append("            <table>\r\n");
	XYBody.Append("                    <!--类别 -->\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <th class=\"title\">\r\n");
	XYBody.Append( Method.filter(iinfo.UserID.ToString().Trim(),iinfo.Title.ToString().Trim()));
	XYBody.Append("</th>     \r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <!--类别内容 --> \r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <td style=\"height:110px;\">\r\n");

	if (iinfo.SmallImg[0].ToString().Trim()=="")
	{

	XYBody.Append("                            <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/WelcomeInfro_32.gif\" alt=\"pro\" />\r\n");

	}
	else
	{

	XYBody.Append("                            <img width=\"110px\" height=\"100px;\" src=\"" + iinfo.SmallImg[0].ToString().Trim() + "\" alt=\"pro\" /> \r\n");

	}	//end if

	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                         <td class=\"gray\">");	XYBody.Append(iinfo.SortName.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <!--类别 -->     \r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                         <th class=\"title\">基本参数</th>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <tr>\r\n");

	if (iinfo.A_Area=="")
	{

	XYBody.Append("                        <td>没有填写</td>\r\n");

	}
	else
	{

	XYBody.Append("                         <td>");	XYBody.Append(iinfo.A_Area.ToString());	XYBody.Append("</td>\r\n");

	}	//end if

	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <td>");	XYBody.Append(iinfo.PublishTime.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("                    </tr> \r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <td  class=\"graybg\">");	XYBody.Append(iinfo.UseFulDate.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("                    </tr>   \r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <td>\r\n");
	XYBody.Append( Method.filter(iinfo.UserID.ToString().Trim(),iinfo.InfoContent.ToString().Trim()));
	XYBody.Append("</td>\r\n");
	XYBody.Append("                    </tr>         \r\n");
	XYBody.Append("            </table>\r\n");
	XYBody.Append("        </td>\r\n");

	}	//end loop

	XYBody.Append("    </tr>\r\n");
	XYBody.Append("</table>\r\n");

	}	//end if


	if (pageinfo.ModuleFlag=="service")
	{

	XYBody.Append("<!--服务信息-->\r\n");
	XYBody.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"compareTab\">\r\n");
	XYBody.Append("    <tr>\r\n");
	XYBody.Append("        <td valign=\"top\">\r\n");
	XYBody.Append("            <table>\r\n");
	XYBody.Append("                    <!--类别 -->\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <th class=\"title\">信息标题</th>     \r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <!--类别内容 --> \r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <td style=\"height:110px;\">信息图片\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <!--类别 -->     \r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                         <th class=\"title\">基本参数</th>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                         <td>信息类别</td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                    <td class=\"graybg\">发布时间</td>\r\n");
	XYBody.Append("                    </tr> \r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <td>有效时间</td>\r\n");
	XYBody.Append("                    </tr>   \r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <td class=\"graybg\">信息描述</td>\r\n");
	XYBody.Append("                    </tr>         \r\n");
	XYBody.Append("            </table>\r\n");
	XYBody.Append("        </td>\r\n");

	int seinfo__loop__id=0;
	foreach(XYECOM.Model.ServiecInfo seinfo in list)
	{
		seinfo__loop__id++;

	XYBody.Append("        <td valign=\"top\">\r\n");
	XYBody.Append("            <table>\r\n");
	XYBody.Append("                    <!--类别 -->\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <th class=\"title\">\r\n");
	XYBody.Append( Method.filter(seinfo.UserID.ToString().Trim(),seinfo.Title.ToString().Trim()));
	XYBody.Append("</th>     \r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <!--类别内容 --> \r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <td style=\"height:110px;\">\r\n");

	if (seinfo.SmallImg[0].ToString().Trim()=="")
	{

	XYBody.Append("                            <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/WelcomeInfro_32.gif\" alt=\"pro\" />\r\n");

	}
	else
	{

	XYBody.Append("                            <img width=\"110px\" height=\"100px;\" src=\"" + seinfo.SmallImg[0].ToString().Trim() + "\" alt=\"pro\" /> \r\n");

	}	//end if

	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <!--类别 -->     \r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                         <th class=\"title\">基本参数</th>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                         <td>");	XYBody.Append(seinfo.SortName.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                    <td class=\"graybg\">");	XYBody.Append(seinfo.PublishTime.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("                    </tr> \r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <td>");	XYBody.Append(seinfo.UseFulDate.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("                    </tr>   \r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <td class=\"graybg\">\r\n");
	XYBody.Append( Method.filter(seinfo.UserID.ToString().Trim(),seinfo.InfoContent.ToString().Trim()));
	XYBody.Append("</td>\r\n");
	XYBody.Append("                    </tr>         \r\n");
	XYBody.Append("            </table>\r\n");
	XYBody.Append("        </td>\r\n");

	}	//end loop

	XYBody.Append("    </tr>\r\n");
	XYBody.Append("</table>\r\n");

	}	//end if


	if (pageinfo.ModuleFlag=="brand")
	{

	XYBody.Append("<!--品牌信息-->\r\n");
	XYBody.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"compareTab\">\r\n");
	XYBody.Append("    <tr>\r\n");
	XYBody.Append("        <td valign=\"top\">\r\n");
	XYBody.Append("            <table>\r\n");
	XYBody.Append("                    <!--类别 -->\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <th class=\"title\">信息标题</th>     \r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <!--类别内容 --> \r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <td style=\"height:110px;\">信息图片\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <!--类别 -->     \r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                         <th class=\"title\">基本参数</th>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                         <td>信息类别</td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                    <td class=\"graybg\">发布时间</td>\r\n");
	XYBody.Append("                    </tr>    \r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <td>信息描述</td>\r\n");
	XYBody.Append("                    </tr>         \r\n");
	XYBody.Append("            </table>\r\n");
	XYBody.Append("        </td>\r\n");

	int binfo__loop__id=0;
	foreach(BrandInfo binfo in list)
	{
		binfo__loop__id++;

	XYBody.Append("        <td valign=\"top\">\r\n");
	XYBody.Append("            <table>\r\n");
	XYBody.Append("                    <!--类别 -->\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <th class=\"title\">\r\n");
	XYBody.Append( Method.filter(binfo.UserID.ToString().Trim(),binfo.Title.ToString().Trim()));
	XYBody.Append("</th>     \r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <!--类别内容 --> \r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <td style=\"height:110px;\">\r\n");

	if (binfo.SmallImg[0].ToString().Trim()=="")
	{

	XYBody.Append("                            <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/WelcomeInfro_32.gif\" alt=\"pro\" />\r\n");

	}
	else
	{

	XYBody.Append("                            <img width=\"110px\" height=\"100px;\" src=\"" + binfo.SmallImg[0].ToString().Trim() + "\" alt=\"pro\" /> \r\n");

	}	//end if

	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <!--类别 -->     \r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                         <th class=\"title\">基本参数</th>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                         <td>");	XYBody.Append(binfo.SortName.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                    <td class=\"graybg\">");	XYBody.Append(binfo.PublishTime.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("                    </tr>    \r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <td>\r\n");
	XYBody.Append( Method.filter(binfo.UserID.ToString().Trim(),binfo.InfoContent.ToString().Trim()));
	XYBody.Append("</td>\r\n");
	XYBody.Append("                    </tr>         \r\n");
	XYBody.Append("            </table>\r\n");
	XYBody.Append("        </td>\r\n");

	}	//end loop

	XYBody.Append("    </tr>\r\n");
	XYBody.Append("</table>\r\n");

	}	//end if

	XYBody.Append("</div>\r\n");

	XYBody.Append("	<div id=\"footer\">\r\n");
	XYBody.Append("		<a href=\"\">集团首页</a> | <a href=\"/about/index.htm\" target=\"_blank\">关于我们</a> | <a href=\"\">免责声明</a> | <a href=\"\">媒体报道</a> | <a href=\"\">诚聘英才</a> | <a href=\"\">代理专区</a> | <a href=\"\">广告专区</a> | <a href=\"\">友情链接</a> | <a href=\"\">联系我们</a> | <a href=\"\">网站地图</a>\r\n");
	XYBody.Append("	</div>\r\n");
	XYBody.Append("	<div id=\"copyright\">\r\n");
	XYBody.Append("		<div id=\"copy_info\">\r\n");
	XYBody.Append("			<ul>\r\n");
	XYBody.Append("				<li>Copyright &copy; 2005-2009  &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<a href=\"#\" target=\"_blank\">京ICP备05003331号</a></li>\r\n");
	XYBody.Append("				<li><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/ico_phone.gif\" align=\"absmiddle\">电话：86-010-62669815 传真：86-010-86818791  <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/ico_email.gif\" />E-Mail：<a href=\"#\">info@xyecom.com </a></li>\r\n");
	XYBody.Append("				<li>版权所有　纵横易商软件 - 致力于中小企业电子商务应用技术服务　未经授权请勿转载</li>\r\n");
	XYBody.Append("			</ul>			\r\n");
	XYBody.Append("		</div>\r\n");
	XYBody.Append("		<div class=\"copyright_i\">\r\n");
	XYBody.Append("		 <div class=\"com copyright_i1\"><p class=\"p\"><a href=\"#\" target=\"_blank\">深圳网络警察报警平台</a></p></div>\r\n");
	XYBody.Append("		 <div class=\"com copyright_i2\"><p class=\"p\">公共信息安全网络监察</p></div>\r\n");
	XYBody.Append("		 <div class=\"com copyright_i3\"><p class=\"p\"><a href=\"#\" target=\"_blank\">经营性网站备案信息</a></p></div>\r\n");
	XYBody.Append("		 <div class=\"com copyright_i4\"><p class=\"p\"><a href=\"#\" target=\"_blank\">不良信息举报中心</a></p></div>\r\n");
	XYBody.Append("		</div>\r\n");
	XYBody.Append("	 </div>\r\n");


	XYBody.Append("</div>\r\n");
	XYBody.Append("</body>\r\n");
	XYBody.Append("</html>\r\n");

	XYBody.Append(IsCopyright());
	Response.Write(XYBody.ToString());
}
</script>
