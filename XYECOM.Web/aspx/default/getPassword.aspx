<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.getpassword,XYECOM.Page" %>
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



	XYBody.Append("	<link href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/css/login.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n");
	XYBody.Append("</head>\r\n");
	XYBody.Append("<body onload=\"");	XYBody.Append(pageinfo.OnLoadEvents);	XYBody.Append("\">\r\n");
	XYBody.Append("<div id=\"wrapper\">\r\n");




	XYBody.Append("<div id=\"header\">\r\n");
	XYBody.Append("    <div id=\"local_channel\">\r\n");
	XYBody.Append("        <span class=\"fright\"><a href=\"#\" onclick=\"div_opennew('_xy_div_allarea',200,100);return false;\">\r\n");
	XYBody.Append("            所有地区</a>\r\n");
	XYBody.Append("            <div id=\"_xy_div_allarea\" style=\"display: none\" onmouseover=\"div_mouseover('_xy_div_allarea')\"\r\n");
	XYBody.Append("                onmouseout=\"div_mouseout('_xy_div_allarea');\">\r\n");
	XYBody.Append("                <a href=\"\">山东</a> <a href=\"\">四川</a> <a href=\"\">陕西</a> <a href=\"\">广东</a>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </span><strong>地区频道：</strong>" +  XYECOMCreateHTML("XY_ASN_shandong").ToString() + " | <a href=\"#\" class=\"waiting\" title=\"暂未开通\">\r\n");
	XYBody.Append("            河南农业网</a> | <a href=\"#\" class=\"waiting\" title=\"暂未开通\">湖南农业网</a> | <a href=\"#\" class=\"waiting\"\r\n");
	XYBody.Append("                title=\"暂未开通\">沈阳农业网</a> | <a href=\"#\" class=\"waiting\" title=\"暂未开通\">广东农业网</a>\r\n");
	XYBody.Append("        | <a href=\"#\" class=\"waiting\" title=\"暂未开通\">四川农业网</a>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <div class=\"clr\">\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <div id=\"mains\">\r\n");
	XYBody.Append("        <div id=\"left\">\r\n");
	XYBody.Append("            <div id=\"logo\">\r\n");
	XYBody.Append("                <a href=\"/\">\r\n");
	XYBody.Append("                    <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/logo.gif\" width=\"219\"\r\n");
	XYBody.Append("                        height=\"50\" alt=\"\" border=\"0\" /></a></div>\r\n");
	XYBody.Append("            <div id=\"site_tube\">\r\n");
	XYBody.Append("                [ &nbsp;&nbsp;<a href=\"\" class=\"orange\">中国农业网主站</a> &nbsp; <a href=\"#\" onclick=\"div_opennew('_xy_div_alltrade',200,100);return false;\"\r\n");
	XYBody.Append("                    class=\"gray\">切换其它站点</a> <a href=\"#\" onclick=\"div_opennew('_xy_div_alltrade',200,100);return false;\">\r\n");
	XYBody.Append("                        <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/ico_site_chg.gif\"\r\n");
	XYBody.Append("                            width=\"11\" height=\"11\" alt=\"\" align=\"absmiddle\" /></a>&nbsp;&nbsp; ]\r\n");
	XYBody.Append("                <div id=\"_xy_div_alltrade\" style=\"display: none\" onmouseover=\"div_mouseover('_xy_div_alltrade')\"\r\n");
	XYBody.Append("                    onmouseout=\"div_mouseout('_xy_div_alltrade');\">\r\n");
	XYBody.Append("                    <a href=\"\">分站1</a> <a href=\"\">分站2</a> <a href=\"\">分站3</a> <a href=\"\">分站4</a>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <div id=\"right\">\r\n");
	XYBody.Append("            <div id=\"site_nav\">\r\n");
	XYBody.Append("                <div class=\"c_name\">\r\n");
	XYBody.Append("                    行业频道</div>\r\n");
	XYBody.Append("                <div class=\"text\">\r\n");
	XYBody.Append("                    <ul>\r\n");
	XYBody.Append("                        <li><a href=\"\">天气</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">男人</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">女人</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">新娘</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">母婴</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">健康</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">吃喝</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">旅游</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">出国</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">教育</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">留学</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">读书</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">教育</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">原创</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">财经</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">留学</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">财经</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">留学</a></li>\r\n");
	XYBody.Append("                    </ul>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <div class=\"c_name\">\r\n");
	XYBody.Append("                    新闻资讯</div>\r\n");
	XYBody.Append("                <div class=\"text\">\r\n");
	XYBody.Append("                    <ul>\r\n");
	XYBody.Append("                        <li><a href=\"\">天气</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">男人</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">女人</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">新娘</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">母婴</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">健康</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">吃喝</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">旅游</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">出国</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">教育</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">留学</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">读书</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">教育</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">原创</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">财经</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">留学</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">财经</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">留学</a></li>\r\n");
	XYBody.Append("                    </ul>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("            <div id=\"hd_bnr\">\r\n");
	XYBody.Append("                <a href=\"\">\r\n");
	XYBody.Append("                    <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/temp_bnr_1.gif\" width=\"163\"\r\n");
	XYBody.Append("                        height=\"76\" alt=\"\" /></a>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <div class=\"clr\">\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <div class=\"clr\">\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<div class=\"clr\">\r\n");
	XYBody.Append("</div>\r\n");


	XYBody.Append("	<div class=\"clr\"></div>\r\n");
	XYBody.Append("	<div class=\"clr\"></div>\r\n");
	XYBody.Append("	<br />\r\n");
	XYBody.Append("	<div id=\"reg_nav\">\r\n");
	XYBody.Append("		<strong>您现在的位置：</strong> <a href=\"\" class=\"blue\">网站首页</a> &raquo; <a href=\"\" class=\"blue\">找回密码</a>\r\n");
	XYBody.Append("	</div>\r\n");
	XYBody.Append("    <!--基本信息-->\r\n");
	XYBody.Append("    <div class=\"regBg\">\r\n");
	XYBody.Append("     <table width=\"880\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\">\r\n");
	XYBody.Append("        <tr><td>&nbsp;</td></tr>\r\n");
	XYBody.Append("        <tr>\r\n");
	XYBody.Append("            <td height=\"26\" align=\"right\" style=\"border-bottom:1px solid #ccc;\"><strong class=\"Font14_1\">找回密码</strong>&nbsp;&nbsp;</td>\r\n");
	XYBody.Append("        </tr>\r\n");
	XYBody.Append("        <tr><td>&nbsp;</td></tr>\r\n");
	XYBody.Append("    </table>\r\n");
	XYBody.Append("     <table width=\"880\" border=\"0\" align=\"center\" cellpadding=\"6\" cellspacing=\"0\">\r\n");
	XYBody.Append("		<tr>\r\n");
	XYBody.Append("			<td align=\"right\" valign=\"top\" width=\"130\" style=\"padding-top:12px;\" align=\"left\"><strong class=\"Font14_1\">通过邮箱找回密码</strong> <span class=\"red\">*</span></td>\r\n");
	XYBody.Append("			<td width=\"293\" valign=\"top\">\r\n");
	XYBody.Append("			    <input type=\"text\" name=\"email\" id=\"email\" size=\"28\" maxlength=\"30\" class=\"regOutInput\"/>\r\n");
	XYBody.Append("                 <br/>\r\n");
	XYBody.Append("                <input type=\"button\" id=\"btnFindPwd\" value=\"找回密码\" onclick=\"RetakePasswordByEmail();\"/>\r\n");
	XYBody.Append("           </td>\r\n");
	XYBody.Append("			<td width=\"432\" valign=\"top\"><div id=\"Div1\" class=\"regOutTip\">请输入您在本站的注册邮箱。</td>\r\n");
	XYBody.Append("		</tr>\r\n");
	XYBody.Append("	  </table>\r\n");
	XYBody.Append("        <table width=\"880\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\">\r\n");
	XYBody.Append("            <tr><td>&nbsp;</td></tr>\r\n");
	XYBody.Append("            <tr>\r\n");
	XYBody.Append("                <td height=\"26\" align=\"right\" style=\"border-bottom:1px solid #ccc;\"><strong class=\"Font14_1\">重设密码</strong>&nbsp;&nbsp;</td>\r\n");
	XYBody.Append("            </tr>\r\n");
	XYBody.Append("            <tr><td>&nbsp;</td></tr>\r\n");
	XYBody.Append("        </table>\r\n");
	XYBody.Append("        <table width=\"880\" border=\"0\" align=\"center\" cellpadding=\"6\" cellspacing=\"0\">\r\n");
	XYBody.Append("            <tr>\r\n");
	XYBody.Append("                <td align=\"right\" valign=\"top\" width=\"130\" style=\"padding-top:12px;\" align=\"left\"><strong class=\"Font14_1\">请输入您用户名</strong> <span class=\"red\">*</span></td>\r\n");
	XYBody.Append("                <td width=\"293\" valign=\"top\">\r\n");
	XYBody.Append("                    <input name=\"\" type=\"text\" size=\"28\" id=\"username\" class=\"regOutInput\" maxlength =\"100\" onblur=\"chktxtPassword('0');\" onfocus=\"fsm('0');\"/>\r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("                <td width=\"432\" valign=\"top\" id =\"txt0\" class=\"regOutTip\">请输入您注册的用户名。</td>\r\n");
	XYBody.Append("            </tr>\r\n");
	XYBody.Append("            <tr>\r\n");
	XYBody.Append("                <td align=\"right\" valign=\"top\" width=\"130\" style=\"padding-top:12px;\" align=\"left\"><strong class=\"Font14_1\">密码提示问题</strong> <span class=\"red\">*</span></td>\r\n");
	XYBody.Append("                <td width=\"293\" valign=\"top\">\r\n");
	XYBody.Append("                    <input name=\"\" type=\"text\" size=\"28\"  id =\"question\" onblur=\"chktxtPassword('1');\" onfocus=\"fsm('1');\" class=\"regOutInput\" readonly=\"readonly\" disabled/>\r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("                <td width=\"432\" valign=\"top\" class=\"regOutTip\" id=\"txt1\">您注册时填写的密码提示问题。</td>\r\n");
	XYBody.Append("            </tr>\r\n");
	XYBody.Append("            <tr>\r\n");
	XYBody.Append("                <td align=\"right\" valign=\"top\" width=\"130\" style=\"padding-top:12px;\" align=\"left\"><strong class=\"Font14_1\">密码提示答案</strong> <span class=\"red\">*</span></td>\r\n");
	XYBody.Append("                <td width=\"293\" valign=\"top\">\r\n");
	XYBody.Append("                    <input name=\"\" type=\"text\" size=\"28\"  id=\"answer\" onblur=\"chktxtPassword('2');\" onfocus=\"fsm('2');\" class=\"regOutInput\"/>\r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("                <td width=\"432\" valign=\"top\"  id =\"txt2\" class=\"regOutTip\">请输入您注册时填写的密码提示问题答案。</td>\r\n");
	XYBody.Append("            </tr>\r\n");
	XYBody.Append("            <tr>\r\n");
	XYBody.Append("                <td align=\"right\" valign=\"top\" width=\"130\" style=\"padding-top:12px;\" align=\"left\"><strong class=\"Font14_1\">输入新密码</strong> <span class=\"red\">*</span></td>\r\n");
	XYBody.Append("                <td width=\"293\" valign=\"top\">\r\n");
	XYBody.Append("                    <input name=\"\" type=\"password\" size=\"28\"  id=\"newpwd\" onblur=\"chktxtPassword('3');\" onfocus=\"fsm('3');\" class=\"regOutInput\"/>\r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("                <td width=\"432\" valign=\"top\" id=\"txt3\" class=\"regOutTip\">6-20位(不能包含汉字), 不能与用户名相同。</td>\r\n");
	XYBody.Append("            </tr>\r\n");
	XYBody.Append("             <tr>\r\n");
	XYBody.Append("                <td align=\"right\" valign=\"top\" width=\"130\" style=\"padding-top:12px;\" align=\"left\"><strong class=\"Font14_1\">确认密码</strong> <span class=\"red\">*</span></td>\r\n");
	XYBody.Append("                <td width=\"293\" valign=\"top\">\r\n");
	XYBody.Append("                    <input name=\"\" type=\"password\" size=\"28\"   id=\"npassword\" onblur=\"chktxtPassword('4');\" class=\"regOutInput\" onfocus=\"fsm('4');\"/>\r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("                <td width=\"432\" valign=\"top\" id=\"txt4\" class=\"regOutTip\">请再输入一遍上面填写的密码</td>\r\n");
	XYBody.Append("            </tr>\r\n");
	XYBody.Append("            <tr>\r\n");
	XYBody.Append("                <td></td>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    <input type=\"button\" id=\"btnResetPwd\" value=\"重设密码\"  onclick =\"return checkpassword();\" disabled=\"disabled\"/>\r\n");
	XYBody.Append("                    <input type=\"reset\"  value=\" 取消 \" onclick =\"window.location.href='");	XYBody.Append(config.WebURL);	XYBody.Append("/index.");	XYBody.Append(config.Suffix);	XYBody.Append("'\"/></td>\r\n");
	XYBody.Append("                <td></td>\r\n");
	XYBody.Append("            </tr>\r\n");
	XYBody.Append("        </table>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("</body>\r\n");
	XYBody.Append("</html>\r\n");




	XYBody.Append(IsCopyright());
	Response.Write(XYBody.ToString());
}
</script>
