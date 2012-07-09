<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.teambuy.details,XYECOM.Page" %>
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

	XYBody.Append("    <title>");	XYBody.Append(seo.Title);	XYBody.Append("</title>\r\n");
	XYBody.Append("	<meta name=\"description\" content=\"");	XYBody.Append(seo.Description);	XYBody.Append("\" />\r\n");
	XYBody.Append("	<meta name=\"keywords\" content=\"");	XYBody.Append(seo.Keywords);	XYBody.Append("\" />\r\n");
	XYBody.Append("	<meta name=\"robots\" content=\"all\"  />\r\n");
	XYBody.Append("	<meta http-equiv=\"Content-Type\" content=\"text/html;\" charset=\"gb2312\" />	\r\n");
	XYBody.Append("	<link rel=\"stylesheet\" href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("common/css/XYLib.css\" type=\"text/css\" media=\"screen\" />\r\n");
	XYBody.Append("	<link href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/css/global.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n");
	XYBody.Append("	<link href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/css/Survey.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n");
	XYBody.Append("	<script type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("common/js/base.js\" language=\"javascript\"></" + "script>\r\n");
	XYBody.Append("	<script type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/js/login.js\" language=\"javascript\"></" + "script>\r\n");
	XYBody.Append("    <script type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/js/validate.js\" language=\"javascript\"></" + "script>\r\n");
	XYBody.Append("<link href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/css/index.css\" rel=\"stylesheet\" type=\"text/css\" />	\r\n");


	XYBody.Append("    <link rel=\"stylesheet\" type=\"text/css\" href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/_shop/store/css/tuangou.css\" />\r\n");
	XYBody.Append("</head>\r\n");
	XYBody.Append("<script type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/_shop/store/js/jquery.js\"></" + "script>\r\n");
	XYBody.Append("<script type=\"text/javascript\">\r\n");
	XYBody.Append("    $(document).ready(function () {\r\n");

	if (tbinfo.SupplyCount>tbinfo.SellCount)
	{

	XYBody.Append("        var endtime = new Date('");	XYBody.Append(enddate.ToString());	XYBody.Append("'); // 结束日期  \r\n");
	XYBody.Append("        var thisTime = new Date('");	XYBody.Append(now.ToString());	XYBody.Append("'); // 当前服务器时间 \r\n");
	XYBody.Append("        var nowtime = thisTime.getTime(); // 服务器当前时间总的秒数  \r\n");
	XYBody.Append("        var leftsecond = 0;\r\n");
	XYBody.Append("        var sh;\r\n");
	XYBody.Append("        function _fresh() {\r\n");
	XYBody.Append("            nowtime = nowtime + 1000; //间隔1秒，毫秒加1000  \r\n");
	XYBody.Append("            leftsecond = parseInt((endtime.getTime() - nowtime) / 1000);\r\n");
	XYBody.Append("            __d = parseInt(leftsecond / 3600 / 24) <= 9 ? +\"0\" + parseInt(leftsecond / 3600 / 24).toString() : parseInt(leftsecond / 3600 / 24);\r\n");
	XYBody.Append("            __h = parseInt((leftsecond / 3600) % 24) <= 9 ? +\"0\" + parseInt((leftsecond / 3600) % 24).toString() : parseInt((leftsecond / 3600) % 24);\r\n");
	XYBody.Append("            __m = parseInt((leftsecond / 60) % 60) <= 9 ? +\"0\" + parseInt((leftsecond / 60) % 60).toString() : parseInt((leftsecond / 60) % 60);\r\n");
	XYBody.Append("            __s = parseInt(leftsecond % 60) <= 9 ? +\"0\" + parseInt(leftsecond % 60).toString() : parseInt(leftsecond % 60);\r\n");
	XYBody.Append("            $(\"#clearInterval\").html(\"\" + __d + \"天\" + __h + \"时\" + __m + \"分\" + __s + \"秒\");\r\n");
	XYBody.Append("            if (leftsecond <= 0) {\r\n");
	XYBody.Append("                $(\"#clearInterval\").html(\"特价已结束\");\r\n");
	XYBody.Append("                $(\"#orderbuy\").html(\"特价已结束\");\r\n");
	XYBody.Append("                clearInterval(sh);\r\n");
	XYBody.Append("            }\r\n");
	XYBody.Append("        }\r\n");
	XYBody.Append("        _fresh()\r\n");
	XYBody.Append("        sh = setInterval(_fresh, 1000);\r\n");

	}
	else
	{

	XYBody.Append("            $(\"#orderbuy\").html(\"賣光了\");\r\n");
	XYBody.Append("            $(\"#clearInterval\").html(\"特价已结束\");                \r\n");

	}	//end if

	XYBody.Append("    });\r\n");
	XYBody.Append("</" + "script>\r\n");
	XYBody.Append("</" + "script>\r\n");
	XYBody.Append("<body>\r\n");
	XYBody.Append("    <div id=\"wrapper\">\r\n");

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



	XYBody.Append("	<div class=\"search\">\r\n");
	XYBody.Append("		<div class=\"sh_tab\">\r\n");
	XYBody.Append("			<div class=\"order\">\r\n");
	XYBody.Append("				<a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("keyword/\">订购固定排名</a>\r\n");
	XYBody.Append("			</div>\r\n");
	XYBody.Append("			<ul id=\"_xy_big_menu_box\">\r\n");
	XYBody.Append("				<li><a id=\"_xymenu_index\" href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("\" class=\"tabactive\"><span>首 页</span></a></li>\r\n");
	XYBody.Append("				<li><a id=\"_xymenu_news\" href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("news/index.aspx\"><span>新闻资讯</span></a></li>\r\n");
	XYBody.Append("				<li><a id=\"_xymenu_offer\" href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("offer/index.aspx\"><span>产品中心</span></a></li>\r\n");
	XYBody.Append("				<li><a id=\"_xymenu_investment\" href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("investment/index.aspx\"><span>招商加盟</span></a></li>\r\n");
	XYBody.Append("				<li><a id=\"_xymenu_company\" href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("company/index.aspx\"><span>行业公司</span></a></li>\r\n");
	XYBody.Append("				<li><a id=\"_xymenu_job\" href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("job/index.aspx\"><span>人才招聘</span></a></li>\r\n");
	XYBody.Append("				<li><a id=\"_xymenu_brand\" href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("brand/index.aspx\"><span>行业品牌</span></a></li>				\r\n");
	XYBody.Append("				<li><a id=\"_xymenu_exhibition\" href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("exhibition/index.aspx\"><span>展会信息</span></a></li>\r\n");
	XYBody.Append("				<li><a id=\"_xymenu_survey\" href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("survey/index.aspx\"><span>调查问卷</span></a></li>\r\n");
	XYBody.Append("				<li style=\"display:none;\"><a href=\"#\"><span>社区交流</span></a></li>\r\n");
	XYBody.Append("				<div class=\"clr\"></div>\r\n");
	XYBody.Append("			</ul>\r\n");
	XYBody.Append("			<script type=\"text/javascript\">xy_Sel_CurBigMenu();</" + "script>\r\n");
	XYBody.Append("		</div>\r\n");
	XYBody.Append("		<div class=\"sh_cnt\">\r\n");
	XYBody.Append("			<div id=\"main\">\r\n");
	XYBody.Append("				<input type=\"text\" id=\"txtsearchkey\" name=\"sch_text\" class=\"textsearch\" onkeydown=\"_xy_KeyPress('DoSearch');\"/>\r\n");
	XYBody.Append("				<div class=\"soSelect\" onclick=\"xy_ShowSearchMenu();\">\r\n");
	XYBody.Append("					<div class=\"option_current\" id=\"headSlected\" >产品</div>\r\n");
	XYBody.Append("					<div class=\"option_arrow\">\r\n");
	XYBody.Append("						<a href=\"#\"><span class=\"arrow\"></span></a>\r\n");
	XYBody.Append("					</div>\r\n");
	XYBody.Append("					<div class=\"clr\"></div>\r\n");
	XYBody.Append("					<ul onmouseover=\"drop_mouseover('head')\" onmouseout=\"drop_mouseout('head');\" style=\"display: none;\" class=\"options\" id=\"headSel\">\r\n");
	XYBody.Append("					    <li><a href=\"#\" onclick=\"xy_SelectSearchMenu('产品','offer','sell');\">产品</a></li>\r\n");
	XYBody.Append("					    <li><a href=\"#\" onclick=\"xy_SelectSearchMenu('求购','buy','buy');\">求购</a></li>\r\n");
	XYBody.Append("					    <li><a href=\"#\" onclick=\"xy_SelectSearchMenu('招商','investment','sell');\">招商</a></li>\r\n");
	XYBody.Append("					    <li><a href=\"#\" onclick=\"xy_SelectSearchMenu('加盟','investment','buy');\">加盟</a></li>\r\n");
	XYBody.Append("					    <li><a href=\"#\" onclick=\"xy_SelectSearchMenu('融资','venture','sell');\">融资</a></li>\r\n");
	XYBody.Append("					    <li><a href=\"#\" onclick=\"xy_SelectSearchMenu('服务','service','sell');\">服务</a></li>\r\n");
	XYBody.Append("					    <li><a href=\"#\" onclick=\"xy_SelectSearchMenu('企业','company','sell');\">企业</a></li>\r\n");
	XYBody.Append("					    <li><a href=\"#\" onclick=\"xy_SelectSearchMenu('资讯','news','');\">资讯</a></li>\r\n");
	XYBody.Append("					    <li><a href=\"#\" onclick=\"xy_SelectSearchMenu('人才','job','');\">人才</a></li>\r\n");
	XYBody.Append("					    <li><a href=\"#\" onclick=\"xy_SelectSearchMenu('品牌','brand','');\">品牌</a></li>\r\n");
	XYBody.Append("					    <li><a href=\"#\" onclick=\"xy_SelectSearchMenu('展会','exhibition','');\">展会</a></li>\r\n");
	XYBody.Append("					</ul>\r\n");
	XYBody.Append("				</div>\r\n");
	XYBody.Append("				<input type=\"hidden\" id=\"xy_FlagName\" value=\"offer\"/>\r\n");
	XYBody.Append("				<input type=\"hidden\" id=\"xy_InfoType\" value=\"sell\"/>\r\n");
	XYBody.Append("				<button value=\"搜索\" id=\"DoSearch\" name=\"DoSearch\" class=\"btsearch\" onclick=\"xy_search();\"/>搜索</button>\r\n");
	XYBody.Append("				<a href=\"/search/advanced_search.");	XYBody.Append(config.Suffix);	XYBody.Append("\" class=\"black\">[高级搜索]</a>\r\n");
	XYBody.Append("				<a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("contributor.");	XYBody.Append(config.Suffix);	XYBody.Append("\" class=\"black\">[投稿]</a>\r\n");
	XYBody.Append("				<a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("post.");	XYBody.Append(config.Suffix);	XYBody.Append("\" class=\"black\">[发布信息]</a>\r\n");
	XYBody.Append("				<a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("baike/index.");	XYBody.Append(config.Suffix);	XYBody.Append("\" class=\"black\">[百科]</a>\r\n");
	XYBody.Append("			</div>\r\n");
	XYBody.Append("			<div id=\"sch_bnr\"><a href=\"\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/temp_pic_5.jpg\" width=\"170\" height=\"77\" alt=\"\" /></a></div>\r\n");
	XYBody.Append("			<div id=\"hot_schs\">\r\n");
	XYBody.Append("				<ul>\r\n");
	XYBody.Append("					<li><strong>热门搜索词：</strong></li>\r\n");
	XYBody.Append("					<li>\r\n");
	XYBody.Append("						<ul>\r\n");
	XYBody.Append("							" +  XYECOMCreateHTML("XY_Index_ReMenSouSuoGuanjianzi").ToString() + "\r\n");
	XYBody.Append("						</ul>\r\n");
	XYBody.Append("					</li>\r\n");
	XYBody.Append("				</ul>\r\n");
	XYBody.Append("			</div>\r\n");
	XYBody.Append("		</div>\r\n");
	XYBody.Append("	</div>\r\n");


	XYBody.Append("        <div id=\"main\">\r\n");
	XYBody.Append("            <!--left start-->\r\n");
	XYBody.Append("            <div class=\"i_fl\">\r\n");
	XYBody.Append("                <!-- 商品主介绍 -->\r\n");
	XYBody.Append("                <div class=\"main\">\r\n");
	XYBody.Append("                    <h2>\r\n");
	XYBody.Append("                        <span class=\"c2\">济南团购：</span>");	XYBody.Append(tbinfo.Title.ToString());	XYBody.Append("</h2>\r\n");
	XYBody.Append("                    <div class=\"mmain\">\r\n");
	XYBody.Append("                        <div class=\"lmain\">\r\n");
	XYBody.Append("                            <table class=\"discount\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	XYBody.Append("                                <tbody>\r\n");
	XYBody.Append("                                    <tr>\r\n");
	XYBody.Append("                                        <th>\r\n");
	XYBody.Append("                                            原价\r\n");
	XYBody.Append("                                        </th>\r\n");
	XYBody.Append("                                        <th>\r\n");
	XYBody.Append("                                            折扣\r\n");
	XYBody.Append("                                        </th>\r\n");
	XYBody.Append("                                        <th>\r\n");
	XYBody.Append("                                            节省\r\n");
	XYBody.Append("                                        </th>\r\n");
	XYBody.Append("                                    </tr>\r\n");
	XYBody.Append("                                    <tr>\r\n");
	XYBody.Append("                                        <td>\r\n");
	XYBody.Append("                                            ￥");	XYBody.Append(tbinfo.MarketPrice.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                                        </td>\r\n");
	XYBody.Append("                                        <td>\r\n");
	XYBody.Append("                                            ");	XYBody.Append(tbinfo.Discount.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                                        </td>\r\n");
	XYBody.Append("                                        <td>\r\n");
	XYBody.Append("                                            <span class=\"c2\">￥");	XYBody.Append(tbinfo.Saved.ToString());	XYBody.Append("</span>\r\n");
	XYBody.Append("                                        </td>\r\n");
	XYBody.Append("                                    </tr>\r\n");
	XYBody.Append("                                </tbody>\r\n");
	XYBody.Append("                            </table>\r\n");
	XYBody.Append("                            <div class=\"buyinfo\">\r\n");
	XYBody.Append("                                <p class=\"buynum\">\r\n");
	XYBody.Append("                                    <span class=\"c2\">");	XYBody.Append(tbinfo.CurrentJoin.ToString());	XYBody.Append("</span>人已购买<br />\r\n");
	XYBody.Append("                                    数量有限，下单要快哟</p>\r\n");
	XYBody.Append("                                <p class=\"timeleft\">\r\n");
	XYBody.Append("                                    距离本次团购结束还有：<br />\r\n");
	XYBody.Append("                                    <span id=\"clearInterval\" class=\"showTime\"></span>\r\n");
	XYBody.Append("                                </p>\r\n");
	XYBody.Append("                                <p class=\"waiting\">\r\n");
	XYBody.Append("                                    成团人数：");	XYBody.Append(tbinfo.SucPeopleNum.ToString());	XYBody.Append(",当前参与：");	XYBody.Append(tbinfo.CurrentJoin.ToString());	XYBody.Append("有效期至(");	XYBody.Append(tbinfo.EndDate.ToString());	XYBody.Append(")\r\n");
	XYBody.Append("                                </p>\r\n");

	if (tbinfo.CurrentJoin>=tbinfo.SucPeopleNum)
	{

	XYBody.Append("                                <p class=\"success\">\r\n");
	XYBody.Append("                                    团购已成功，可继续购买</p>\r\n");

	}
	else
	{

	XYBody.Append("                                <p class=\"failed\">\r\n");
	XYBody.Append("                                    人数不足，不能成团</p>\r\n");

	}	//end if

	XYBody.Append("                                <p class=\"failed\" style=\"display: none;\">\r\n");
	XYBody.Append("                                    卖光了</p>\r\n");
	XYBody.Append("                            </div>\r\n");
	XYBody.Append("                            <div class=\"order buy\" id=\"orderbuy\">\r\n");
	XYBody.Append("                                <a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("MyTeamOrder.");	XYBody.Append(config.suffix);	XYBody.Append("?teamId=");	XYBody.Append(tbinfo.Id.ToString());	XYBody.Append("\">抢购</a><em>￥");	XYBody.Append(tbinfo.CurrentPrice.ToString());	XYBody.Append("</em></div>\r\n");
	XYBody.Append("                            <input type=\"hidden\" name=\"IsOverflag\" value='");	XYBody.Append(flag.ToString());	XYBody.Append("' />\r\n");
	XYBody.Append("                        </div>\r\n");
	XYBody.Append("                        <div class=\"rmain\">\r\n");
	XYBody.Append("                            <img src=\"");	XYBody.Append(tbinfo.ImagePath.ToString());	XYBody.Append("\" width=\"440\" height=\"267\" alt=\"\" />\r\n");
	XYBody.Append("                            <div class=\"buytips\">\r\n");
	XYBody.Append("                                <div class=\"quote\">\r\n");
	XYBody.Append("                                    <span style=\"color: #333333\">★ 多种款式，五种样式任选<br />\r\n");
	XYBody.Append("                                        ★ 麦斯特蛋糕，儿童之首选<br />\r\n");
	XYBody.Append("                                        ★ 市区二环以内免费送货</span></div>\r\n");
	XYBody.Append("                            </div>\r\n");
	XYBody.Append("                        </div>\r\n");
	XYBody.Append("                        <div class=\"clear\">\r\n");
	XYBody.Append("                        </div>\r\n");
	XYBody.Append("                    </div>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <!-- 商品主介绍 end -->\r\n");
	XYBody.Append("                <!-- 商品详情 -->\r\n");
	XYBody.Append("                <div class=\"xq\">\r\n");
	XYBody.Append("                    <ul class=\"xqlist c3\">\r\n");
	XYBody.Append("                        <li class=\"cur\"><a>商品详情</a></li></ul>\r\n");
	XYBody.Append("                    <div class=\"details\">\r\n");
	XYBody.Append("                        ");	XYBody.Append(tbinfo.Description.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                    </div>\r\n");
	XYBody.Append("                    <div class=\"buy-bottom\">\r\n");
	XYBody.Append("                        <dl class=\"item-prices\">\r\n");
	XYBody.Append("                            <dt class=\"price\">原 价</dt>\r\n");
	XYBody.Append("                            <dt class=\"juprice\">折 扣</dt>\r\n");
	XYBody.Append("                            <dt class=\"save\">节 省</dt>\r\n");
	XYBody.Append("                            <dd class=\"price\">\r\n");
	XYBody.Append("                                <del>￥");	XYBody.Append(tbinfo.MarketPrice.ToString());	XYBody.Append("</del></dd>\r\n");
	XYBody.Append("                            <dd class=\"juprice\">\r\n");
	XYBody.Append("                                ");	XYBody.Append(tbinfo.Discount.ToString());	XYBody.Append("</dd>\r\n");
	XYBody.Append("                            <dd class=\"save\">\r\n");
	XYBody.Append("                                ￥");	XYBody.Append(tbinfo.Saved.ToString());	XYBody.Append("</dd>\r\n");
	XYBody.Append("                        </dl>\r\n");
	XYBody.Append("                        <!-- 购买按钮 -->\r\n");
	XYBody.Append("                        <div class=\"item-buy avil\">\r\n");
	XYBody.Append("                            价格：<span>");	XYBody.Append(tbinfo.CurrentPrice.ToString());	XYBody.Append("</span> <strong class=\"J_juPrices\"><b>￥</b>");	XYBody.Append(tbinfo.CurrentPrice.ToString());	XYBody.Append("</strong>\r\n");
	XYBody.Append("                            <form id=\"frmjointeam\" method=\"post\" action=\"/common/initcart.");	XYBody.Append(config.suffix);	XYBody.Append("\">\r\n");
	XYBody.Append("                            <input type=\"hidden\" name=\"count\" value=\"1\" />\r\n");
	XYBody.Append("                            <input value=\"");	XYBody.Append(tbinfo.ProductId.ToString());	XYBody.Append("\" type=\"hidden\" name=\"pid\" />\r\n");
	XYBody.Append("                            <input value=\"");	XYBody.Append(tbinfo.Id.ToString());	XYBody.Append("\" type=\"hidden\" name=\"teamid\" />\r\n");
	XYBody.Append("                            <input type=\"image\" class=\"buy\" title=\"参团\" />\r\n");
	XYBody.Append("                            </form>\r\n");
	XYBody.Append("                        </div>\r\n");
	XYBody.Append("                    </div>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <!-- 商品详情 end -->\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("            <!--left end-->\r\n");
	XYBody.Append("            <!--right start-->\r\n");
	XYBody.Append("            <div class=\"i_fr\">\r\n");
	XYBody.Append("                <div id=\"plist\" class=\"rbox\">\r\n");
	XYBody.Append("                    <h3>\r\n");
	XYBody.Append("                        今日其它团购</h3>\r\n");
	XYBody.Append("                    <ul>\r\n");
	XYBody.Append("                        <li>\r\n");
	XYBody.Append("                            <h2>\r\n");
	XYBody.Append("                                <a title=\"仅12元！原价50元麦幼优儿童乐园门票1张（1位宝宝+1位陪同家长），5店通用\" href=\"#\">\r\n");
	XYBody.Append("                                    <img alt=\"\" src=\"/templates/_shop/store/images/n_11377854508036.jpg\" width=\"210\"\r\n");
	XYBody.Append("                                        height=\"142\">仅12元！原价50元麦幼优儿童乐园门票1张（1位宝宝+1位陪同家长），5店通用</a></h2>\r\n");
	XYBody.Append("                            <p>\r\n");
	XYBody.Append("                                <a href=\"#\">去看看</a>团购价：<span>12</span></p>\r\n");
	XYBody.Append("                        </li>\r\n");
	XYBody.Append("                        <li>\r\n");
	XYBody.Append("                            <h2>\r\n");
	XYBody.Append("                                <a title=\"仅43元/75元/86元！原价90元/156元/178元稻香村3种口味粽子大礼盒\" href=\"#\">\r\n");
	XYBody.Append("                                    <img alt=\"\" src=\"/templates/_shop/store/images/n_11160666832132.jpg\" width=\"210\"\r\n");
	XYBody.Append("                                        height=\"142\">仅43元/75元/86元！原价90元/156元/178元稻香村3种口味粽子大礼盒</a></h2>\r\n");
	XYBody.Append("                            <p>\r\n");
	XYBody.Append("                                <a href=\"#\">去看看</a>团购价：<span>43</span></p>\r\n");
	XYBody.Append("                        </li>\r\n");
	XYBody.Append("                        <li>\r\n");
	XYBody.Append("                            <h2>\r\n");
	XYBody.Append("                                <a title=\"仅29元！原价198元精装儿童图书（3套任选其1）赠送精美礼盒包装，仅限北京购买\" href=\"#\">\r\n");
	XYBody.Append("                                    <img alt=\"\" src=\"/templates/_shop/store/images/n_11317794891524.jpg\" width=\"210\"\r\n");
	XYBody.Append("                                        height=\"142\">仅29元！原价198元精装儿童图书（3套任选其1）赠送精美礼盒包装，仅限北京购买</a></h2>\r\n");
	XYBody.Append("                            <p>\r\n");
	XYBody.Append("                                <a href=\"#\">去看看</a>团购价：<span>29</span></p>\r\n");
	XYBody.Append("                        </li>\r\n");
	XYBody.Append("                        <li>\r\n");
	XYBody.Append("                            <h2>\r\n");
	XYBody.Append("                                <a title=\"仅19元/5斤！原价50元/5斤狂飙乐园采摘杏优惠！第一波新鲜采摘，无需预约\" href=\"#\">\r\n");
	XYBody.Append("                                    <img alt=\"\" src=\"/templates/_shop/store/images/n_11227208592388.jpg\" width=\"210\"\r\n");
	XYBody.Append("                                        height=\"142\">仅19元/5斤！原价50元/5斤狂飙乐园采摘杏优惠！第一波新鲜采摘，无需预约</a></h2>\r\n");
	XYBody.Append("                            <p>\r\n");
	XYBody.Append("                                <a href=\"#\">去看看</a>团购价：<span>19</span></p>\r\n");
	XYBody.Append("                        </li>\r\n");
	XYBody.Append("                        <li>\r\n");
	XYBody.Append("                            <h2>\r\n");
	XYBody.Append("                                <a title=\"仅9元！原价792元戴尔国际少儿英语庆双节无敌大礼包,5大学习中心通用\" href=\"#\">\r\n");
	XYBody.Append("                                    <img alt=\"\" src=\"/templates/_shop/store/images/n_11297475728900.jpg\" width=\"210\"\r\n");
	XYBody.Append("                                        height=\"142\">仅9元！原价792元戴尔国际少儿英语庆双节无敌大礼包,5大学习中心通用</a></h2>\r\n");
	XYBody.Append("                            <p>\r\n");
	XYBody.Append("                                <a href=\"#\">去看看</a>团购价：<span>9</span></p>\r\n");
	XYBody.Append("                        </li>\r\n");
	XYBody.Append("                        <li>\r\n");
	XYBody.Append("                            <h2>\r\n");
	XYBody.Append("                                <a title=\"仅388元！原价755元美年健康体检套餐！三大分院通用！\" href=\"#\">\r\n");
	XYBody.Append("                                    <img alt=\"\" src=\"/templates/_shop/store/images/n_11275221331972.jpg\" width=\"210\"\r\n");
	XYBody.Append("                                        height=\"142\">仅388元！原价755元美年健康体检套餐！三大分院通用！</a></h2>\r\n");
	XYBody.Append("                            <p>\r\n");
	XYBody.Append("                                <a href=\"#\">去看看</a>团购价：<span>388</span></p>\r\n");
	XYBody.Append("                        </li>\r\n");
	XYBody.Append("                        <li>\r\n");
	XYBody.Append("                            <h2>\r\n");
	XYBody.Append("                                <a title=\"仅499元！原价3680元奢华儿童摄影套餐，喜迎“六一”，3店通用！\" href=\"#\">\r\n");
	XYBody.Append("                                    <img alt=\"\" src=\"/templates/_shop/store/images/n_11271905270788.jpg\" width=\"210\"\r\n");
	XYBody.Append("                                        height=\"142\">仅499元！原价3680元奢华儿童摄影套餐，喜迎“六一”，3店通用！</a></h2>\r\n");
	XYBody.Append("                            <p>\r\n");
	XYBody.Append("                                <a href=\"#\">去看看</a>团购价：<span>499</span></p>\r\n");
	XYBody.Append("                        </li>\r\n");
	XYBody.Append("                        <li>\r\n");
	XYBody.Append("                            <h2>\r\n");
	XYBody.Append("                                <a title=\"仅59元！原价99元向阳坊蛋糕咕咕鸡或乖乖牛（2选1），7店通用\" href=\"#\">\r\n");
	XYBody.Append("                                    <img alt=\"\" src=\"/templates/_shop/store/images/n_11274815611908.jpg\" width=\"210\"\r\n");
	XYBody.Append("                                        height=\"142\">仅59元！原价99元向阳坊蛋糕咕咕鸡或乖乖牛（2选1），7店通用</a></h2>\r\n");
	XYBody.Append("                            <p>\r\n");
	XYBody.Append("                                <a href=\"#\">去看看</a>团购价：<span>59</span></p>\r\n");
	XYBody.Append("                        </li>\r\n");
	XYBody.Append("                    </ul>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("            <!--right end-->\r\n");
	XYBody.Append("        </div>\r\n");

	int item__loop__id=0;
	foreach(XYECOM.Model.TeamBuyPriceRangeInfo item in tbinfo.TeamBuyPriceRanges)
	{
		item__loop__id++;

	XYBody.Append("        <div class=\"jg_list\">\r\n");
	XYBody.Append("            <div class=\"jg_num\">\r\n");

	if (item.OrderUpNum!=-1)
	{

	XYBody.Append("                ");	XYBody.Append(item.OrderNum.ToString());	XYBody.Append("-");	XYBody.Append(item.OrderUpNum.ToString());	XYBody.Append("\r\n");

	}
	else
	{

	XYBody.Append("                >=");	XYBody.Append(item.OrderNum.ToString());	XYBody.Append("\r\n");

	}	//end if

	XYBody.Append("            </div>\r\n");
	XYBody.Append("            <div class=\"jg_price\">\r\n");
	XYBody.Append("                <span>");	XYBody.Append(item.Price.ToString());	XYBody.Append("</span>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </div>\r\n");

	}	//end loop

	XYBody.Append("    </div>\r\n");

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


	XYBody.Append("</body>\r\n");
	XYBody.Append("</html>\r\n");

	XYBody.Append(IsCopyright());
	Response.Write(XYBody.ToString());
}
</script>
