<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.search.buy,XYECOM.Page" %>
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
	XYBody.Append("	<meta http-equiv=\"Content-Type\" content=\"text/html;\" charset=\"gb2312\" />\r\n");
	XYBody.Append("	<link rel=\"stylesheet\" href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("common/css/XYLib.css\" type=\"text/css\" media=\"screen\" />\r\n");
	XYBody.Append("	<link href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/css/global.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n");
	XYBody.Append("    <link href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/css/index.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n");
	XYBody.Append("    <link href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/css/gongqiu.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n");
	XYBody.Append("	<link href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/css/search.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n");
	XYBody.Append("    <script type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("common/js/base.js\" language=\"javascript\"></" + "script>	\r\n");
	XYBody.Append("<script type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("common/js/date.js\" language=\"javascript\"></" + "script>\r\n");
	XYBody.Append("	<script type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/js/login.js\" language=\"javascript\"></" + "script>\r\n");
	XYBody.Append("    <script type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/js/validate.js\" language=\"javascript\"></" + "script>\r\n");
	XYBody.Append("    <script type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/js/search.js\" language=\"javascript\"></" + "script>\r\n");
	XYBody.Append("    <script type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/js/onlinejoin.js\" language=\"javascript\"></" + "script>\r\n");


	XYBody.Append("</head>\r\n");
	XYBody.Append("<body onload=\"");	XYBody.Append(pageinfo.OnLoadEvents);	XYBody.Append("\">\r\n");
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



	if (pageinfo.ModuleFlag=="offer")
	{


	XYBody.Append("	<div id=\"gq_guide\">\r\n");
	XYBody.Append("		<a href=\"\">");	XYBody.Append(pageinfo.Navigation);	XYBody.Append("\r\n");
	XYBody.Append("	</div>\r\n");
	 tempuser = GetUserInfo();
	
	XYBody.Append("	<div id=\"layout\">\r\n");
	XYBody.Append("		<div id=\"layoutLeft\">\r\n");
	XYBody.Append("			<div id=\"LeftProBorder\">\r\n");
	XYBody.Append("				<div id=\"ProTitle\">");	XYBody.Append(offerinfo.Title.ToString());	XYBody.Append("</div>\r\n");
	XYBody.Append("				<div id=\"ProText\">\r\n");
	XYBody.Append("					<div id=\"ProPic\">\r\n");
	XYBody.Append("						<div id=\"ProPicBorder\">\r\n");
	XYBody.Append("							<a href=\"");	XYBody.Append(offerinfo.MorePicUrl.ToString());	XYBody.Append("\" id=\"viewbigURL\" target=\"_blank\">\r\n");
	XYBody.Append("							<img src=\"" + offerinfo.SmallImg[2].ToString().Trim() + "\" alt=\"");	XYBody.Append(offerinfo.Title.ToString());	XYBody.Append("\" border=\"0\" id=\"viewbigpic\" onload=\"LoadImg(280,280,this)\" /></a>\r\n");
	XYBody.Append("						</div>\r\n");
	XYBody.Append("						<div id=\"ProPicName\">\r\n");
	XYBody.Append("						    <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/big.gif\" style=\"vertical-align:middle\" /> \r\n");
	XYBody.Append("						    <a href=\"");	XYBody.Append(offerinfo.MorePicUrl.ToString());	XYBody.Append("\" target=\"_blank\">");	XYBody.Append(offerinfo.Title.ToString());	XYBody.Append("</a>\r\n");
	XYBody.Append("						</div>\r\n");
	XYBody.Append("					</div>\r\n");
	XYBody.Append("					<div id=\"ProInfo\">\r\n");
	XYBody.Append("						<div id=\"ProInfoA\">\r\n");
	XYBody.Append("							<a href=\"");	XYBody.Append(tempuser.shopindex.ToString());	XYBody.Append("\" class=\"blueLink Font14\"><strong>");	XYBody.Append(tempuser.unitname.ToString());	XYBody.Append("</strong></a>&nbsp;&nbsp;<a href=\"");	XYBody.Append(tempuser.shopindex.ToString());	XYBody.Append("\" target=\"_blank\"><img src=\"");	XYBody.Append(tempuser.gradeimgurl.ToString());	XYBody.Append("\" border=\"0\" style=\"position:relative;top:1px;\" /></a>&nbsp;&nbsp;<strong class=\"Font14\">第<span class=\"MemberYear\">");	XYBody.Append(tempuser.years.ToString());	XYBody.Append("</span>年</strong>\r\n");
	XYBody.Append("							<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"fontGray\">\r\n");
	XYBody.Append("								<tr>\r\n");
	XYBody.Append("									<td height=\"10\" colspan=\"2\"></td>\r\n");
	XYBody.Append("								</tr>\r\n");
	XYBody.Append("								<tr>\r\n");
	XYBody.Append("									<td height=\"33\" colspan=\"2\">\r\n");
	XYBody.Append("									    <a href=\"");	XYBody.Append(tempuser.shopindex.ToString());	XYBody.Append("\" target=\"_blank\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/enterWEB.gif\" alt=\"进入企业网站\" width=\"112\" height=\"21\" border=\"0\" /></a>&nbsp;&nbsp;&nbsp;\r\n");
	XYBody.Append("									    <a href=\"");	XYBody.Append(tempuser.contactus.ToString());	XYBody.Append("\" target=\"_blank\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/enterContact.gif\" alt=\"查看联系方式\" width=\"112\" height=\"21\" border=\"0\" /></a></td>\r\n");
	XYBody.Append("									</tr>\r\n");
	XYBody.Append("								<tr>\r\n");
	XYBody.Append("									<td width=\"50%\" height=\"22\">企业类型：");	XYBody.Append(tempuser.character.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("									<td width=\"50%\">员工人数：");	XYBody.Append(tempuser.employeetotal.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("								</tr>\r\n");
	XYBody.Append("								<tr>\r\n");
	XYBody.Append("									<td height=\"22\">经营模式：");	XYBody.Append(tempuser.mode.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("									<td>注册资金：");	XYBody.Append(tempuser.registeredcapital.ToString());	XYBody.Append("万</td>\r\n");
	XYBody.Append("								</tr>\r\n");
	XYBody.Append("							</table>\r\n");
	XYBody.Append("						</div>\r\n");
	XYBody.Append("						<div id=\"ProInfoB\">\r\n");
	XYBody.Append("							<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	XYBody.Append("									<tr>\r\n");
	XYBody.Append("										<td  height=\"24\" colspan=\"2\">\r\n");

	if (offerinfo.Price==0)
	{

	XYBody.Append("                                            求 购 价：<span>面议</span>");	XYBody.Append(offerinfo.Unit.ToString());	XYBody.Append("\r\n");

	}
	else
	{

	XYBody.Append("                                            求 购 价：<span>");	XYBody.Append(offerinfo.Price.ToString());	XYBody.Append("</span> 元/");	XYBody.Append(offerinfo.Unit.ToString());	XYBody.Append(" \r\n");

	}	//end if

	XYBody.Append("                                        &nbsp;&nbsp;&nbsp;&nbsp;\r\n");
	XYBody.Append("										</td>\r\n");
	XYBody.Append("									</tr>\r\n");
	XYBody.Append("									<tr>\r\n");
	XYBody.Append("									    <td width=\"50%\">最小起订：");	XYBody.Append(offerinfo.LeastNum.ToString());	XYBody.Append(" ");	XYBody.Append(offerinfo.Unit.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("										<td width=\"50%\">需求总量：");	XYBody.Append(offerinfo.CountNum.ToString());	XYBody.Append(" ");	XYBody.Append(offerinfo.Unit.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("									</tr>\r\n");
	XYBody.Append("									<tr>\r\n");
	XYBody.Append("										<td height=\"24\">有效期至：");	XYBody.Append(offerinfo.EndTime.ToShortDateString().ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("										<td>发布时间：");	XYBody.Append(offerinfo.PublishTime.ToShortDateString().ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("									</tr>\r\n");
	XYBody.Append("									<tr>\r\n");
	XYBody.Append("										<td height=\"24\" colspan=\"3\">联 系 人：");	XYBody.Append(tempuser.linkman.ToString());	XYBody.Append("&nbsp;&nbsp;<img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/icon_tianjiasy.gif\" width=\"13\" height=\"12\" style=\"position:relative;top:1px;\" /> <a href=\"javascript:void(null);\" onclick=\"Favorite();\" class=\"orange\">添加为商业伙伴</a></td>\r\n");
	XYBody.Append("									</tr>\r\n");
	XYBody.Append("							</table>\r\n");
	XYBody.Append("						</div>\r\n");
	XYBody.Append("						<div class=\"blank5\"></div>\r\n");
	XYBody.Append("						<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	XYBody.Append("							<tr>\r\n");
	XYBody.Append("								<td height=\"60\"><a href=\"#message\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/inquire2.gif\" width=\"139\" height=\"36\" border=\"0\" /></a> </td>\r\n");
	XYBody.Append("								<td style=\"text-align:center;\"><span class=\"Font14\">或联系</span>：<strong class=\"orange\" class=\"TempTele\">86-010-62669815</strong></td>\r\n");
	XYBody.Append("								<td width=\"23%\"></td>\r\n");
	XYBody.Append("							</tr>\r\n");
	XYBody.Append("						</table>\r\n");
	XYBody.Append("					</div>\r\n");
	XYBody.Append("					<div class=\"clr\"></div>\r\n");
	XYBody.Append("					<div id=\"ProDesTitle\"><strong>详细信息:</strong></div>\r\n");
	XYBody.Append("					<div class=\"ProDesText\">\r\n");
	XYBody.Append("					     <table width=\"95%\" border=\"0\" align=\"center\" cellpadding=\"1\" cellspacing=\"1\" class=\"typelist\">");	XYBody.Append(fieldbody.ToString());	XYBody.Append("</table>\r\n");
	XYBody.Append("					     ");	XYBody.Append(offerinfo.InfoContent.ToString());	XYBody.Append("\r\n");
	XYBody.Append("					</div>\r\n");
	XYBody.Append("					<div id=\"ProDesTitle\">\r\n");
	XYBody.Append("					    <strong>联系方式:</strong>\r\n");
	XYBody.Append("					</div>\r\n");
	XYBody.Append("					<div class=\"ProDesText\" id=\"linkmessage\"></div>\r\n");
	XYBody.Append("				</div>\r\n");
	XYBody.Append("			</div>\r\n");
	XYBody.Append("			<div id=\"ProFind\">\r\n");
	XYBody.Append("			    <span>\r\n");
	XYBody.Append("			    <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/icon1.gif\" width=\"20\" height=\"14\" /><a href=\"javascript:void(null);\" onclick=\"Favorite();\">收藏此信息</a>&nbsp;&nbsp;&nbsp;\r\n");
	XYBody.Append("			    <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/icon2.gif\" width=\"21\" height=\"11\" /><a href=\"#\">推荐给朋友</a>&nbsp;&nbsp;&nbsp;\r\n");
	XYBody.Append("			    <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/icon3.gif\" height=\"16\" /><a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("feedback.");	XYBody.Append(config.suffix);	XYBody.Append("\">举报此信息</a>\r\n");
	XYBody.Append("			    </span>\r\n");
	XYBody.Append("			    <strong class=\"orange\">还没有找到合适的产品?</strong>  赶快<a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("user/\" target=\"_blank\">发布求购信息</a>，让供应商主动来找您！\r\n");
	XYBody.Append("    	    </div>\r\n");
	XYBody.Append("			<input type =\"hidden\" id=\"_param_message_module\" value=\"");	XYBody.Append(module.EName.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("            <input type =\"hidden\" id=\"_param_message_title\" value=\"");	XYBody.Append(titleinfo.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("            <input type =\"hidden\" id=\"_param_message_parent_module\" value =\"");	XYBody.Append(pageinfo.ModuleFlag);	XYBody.Append("\" />\r\n");
	XYBody.Append("            <input type =\"hidden\" id=\"_param_message_infoid\" value =\"");	XYBody.Append(offerinfo.InfoID.ToString());	XYBody.Append("\"/>\r\n");
	XYBody.Append("            <input type =\"hidden\" id=\"_param_message_userid\" value =\"");	XYBody.Append(offerinfo.UserID.ToString());	XYBody.Append("\" />\r\n");

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


	XYBody.Append("		 </form>\r\n");
	XYBody.Append("			<div id=\"SayInfo\">\r\n");
	XYBody.Append("				<strong>免责声明</strong>：以上信息由相关企业自行提供，该企业负责信息内容的真实性、准确性和合法性。\r\n");
	XYBody.Append("				<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");	XYBody.Append(config.webname);	XYBody.Append("对此不承担任何保证责任。\r\n");
	XYBody.Append("			</div>\r\n");
	XYBody.Append("		</div>\r\n");
	XYBody.Append("	    <div id=\"layoutRight\">\r\n");
	XYBody.Append("			<div id=\"content\">\r\n");
	XYBody.Append("                <input type =\"hidden\" id=\"_param_userinfo_parent_module\" value =\"");	XYBody.Append(pageinfo.ModuleFlag);	XYBody.Append("\" />\r\n");
	XYBody.Append("                <input type =\"hidden\" id=\"_param_userinfo_infoid\" value =\"");	XYBody.Append(offerinfo.InfoID.ToString());	XYBody.Append("\"/>\r\n");
	XYBody.Append("                <input type =\"hidden\" id=\"_param_userinfo_userid\" value =\"");	XYBody.Append(offerinfo.UserID.ToString());	XYBody.Append("\" />\r\n");

	XYBody.Append("<!--完整显示信息--> \r\n");
	XYBody.Append("<div class=\"w290\" id=\"loginuser\" style=\"display:none;\">  \r\n");
	XYBody.Append("    <ul>\r\n");
	XYBody.Append("        <li id=\"loginuseruginfo\"></li>\r\n");
	XYBody.Append("        <li class=\"line\"><a id=\"loginuserurl\" href=\"\" class=\"link14\"></a></li>\r\n");
	XYBody.Append("        <li>公司资料完成率 <span id=\"ConsummatePercent\"></span></li>\r\n");
	XYBody.Append("        <li><div class=\"cr\"><img id=\"PercentForImg\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/rate.gif\" alt=\" \"  height=\"15px\" /></div></li>\r\n");
	XYBody.Append("        <li><a href=\"#\" id=\"NewOfferPage\">最新供应</a> | <a href=\"#\" id=\"GoodFaithFile\">诚信档案</a> | <a href=\"#\" id=\"UserIntro\">公司介绍</a></li>\r\n");
	XYBody.Append("        <li>联系人：<a href=\"#\" id=\"Contact\"><span id=\"LinkManName\">不详</span></a> 先生 <span id=\"IMOnline\"></span></li>\r\n");
	XYBody.Append("        <li><hr /></li>\r\n");
	XYBody.Append("        <li>加入时间：第 <span id=\"loginuseryearnum\"></span> 年</li>\r\n");
	XYBody.Append("        <li> <a href=\"javascript:;\" onclick =\"Favorite();\">收藏此信息</a> <a href=\"#\" id=\"memessage\">给我留言</a> <a href=\"#\" id=\"linkme\">联系方式</a></li>  \r\n");
	XYBody.Append("    </ul>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<!--要求登陆后查看-->\r\n");
	XYBody.Append("<div class=\"w290\" id=\"UserNoLogin\" style=\"display:none;\">\r\n");
	XYBody.Append("    <ul class=\"login\">\r\n");
	XYBody.Append("        <li><h4>已经是会员请登陆</h4></li>\r\n");
	XYBody.Append("        <li>用户名：<input type=\"text\" name=\"\" tabindex=\"1\"  id=\"username\" name=\"username\" onkeydown =\"KeyDown();\" maxlength=\"50\" /></li>\r\n");
	XYBody.Append("        <li>密&nbsp;&nbsp;&nbsp;码：<input type =\"password\" maxlength=\"20\" tabindex=\"2\" id=\"password\"  name=\"password\" onkeydown =\"KeyDown();\" /></li>\r\n");

	if (config.IsEnabledVCode("login"))
	{

	XYBody.Append("        <li>验证码：");	XYBody.Append(pageinfo.GetValidateCodeHTML());	XYBody.Append("</li>\r\n");

	}	//end if

	XYBody.Append("        <li><input type=\"button\" class=\"button\" value=\"登录\" onclick=\"return InfoLogin();\"/><a href=\"/GetPassword.");	XYBody.Append(config.Suffix);	XYBody.Append("\">忘记密码？</a></li>\r\n");
	XYBody.Append("        <li><hr /></li>\r\n");
	XYBody.Append("        <ll>你还不是会员，请<a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("register.");	XYBody.Append(config.Suffix);	XYBody.Append("\">立刻免费注册</a></li>\r\n");
	XYBody.Append("        <li>\r\n");
	XYBody.Append("            <div class=\"contactus\">\r\n");
	XYBody.Append("                <ul>\r\n");
	XYBody.Append("                <li><h3>如有任何疑问请与我们联系</h3></li>\r\n");
	XYBody.Append("                <li>在线客服：<img src=\"/templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/kefu.gif\" /> <img src=\"/templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/kefu.gif\" /></li>\r\n");
	XYBody.Append("                <li>客户热线：010-8681 8791</li>\r\n");
	XYBody.Append("                </ul>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </li>      \r\n");
	XYBody.Append("    </ul>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<!--要求升级后查看-->\r\n");
	XYBody.Append("<div class=\"w290\" id=\"loginnouser\" style=\"display:none;\">\r\n");
	XYBody.Append("    <h3><span id=\"loginnouseruginfo\"></span></h3>\r\n");
	XYBody.Append("    <ul class=\"upgrade\">\r\n");
	XYBody.Append("        <li><span>您目前所在的会员组，无法查看信息。</span></li>\r\n");
	XYBody.Append("        <li><a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("user/postadministratormessage.");	XYBody.Append(config.Suffix);	XYBody.Append("\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/update.gif\" border=\"0\"/></a></li>\r\n");
	XYBody.Append("        <li><a href=\"\">点此查看会员等级与权限>></a></li>\r\n");
	XYBody.Append("        <li>\r\n");
	XYBody.Append("            <div class=\"contactus\">\r\n");
	XYBody.Append("                <ul>\r\n");
	XYBody.Append("                <li><h3>如有任何疑问请与我们联系</h3></li>\r\n");
	XYBody.Append("                <li>在线客服：<img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/kefu.gif\" /> <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/kefu.gif\" /></li>\r\n");
	XYBody.Append("                <li>客户热线：010-8681 8791</li>\r\n");
	XYBody.Append("                </ul>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </li>\r\n");
	XYBody.Append("        <li><a href=\"javascript:;\" onclick =\"Favorite();\">收藏此信息</a></li>\r\n");
	XYBody.Append("    </ul>\r\n");
	XYBody.Append("</div>  \r\n");


	XYBody.Append("			</div>\r\n");
	XYBody.Append("			<div class=\"MTitle_01\">\r\n");
	XYBody.Append("				<center><a target=\"_blank\" href=\"#\" class=\"red\"><strong>加入我们，享受更多服务</strong></a></center>\r\n");
	XYBody.Append("			</div>\r\n");
	XYBody.Append("			<div class=\"Mblk_01\">\r\n");
	XYBody.Append("				<div id=\"jointous\">\r\n");
	XYBody.Append("					<ul>\r\n");
	XYBody.Append("						<li><a href=\"\">· 结交贸易伙伴，拓展网络商圈</a></li>\r\n");
	XYBody.Append("						<li><a href=\"\">· 成为会员，免费发布供求信息</a></li>\r\n");
	XYBody.Append("						<li><a href=\"\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/btn_gq_reg.gif\" width=\"130\" height=\"29\" alt=\"\" /></a></li>\r\n");
	XYBody.Append("					</ul>\r\n");
	XYBody.Append("				</div>\r\n");
	XYBody.Append("			</div>\r\n");
	XYBody.Append("	</div>\r\n");
	XYBody.Append("	</div>\r\n");



	}	//end if


	if (pageinfo.ModuleFlag=="venture")
	{


	XYBody.Append("	<div id=\"gq_guide\">\r\n");
	XYBody.Append("		<a href=\"\">");	XYBody.Append(pageinfo.Navigation);	XYBody.Append("\r\n");
	XYBody.Append("	</div>\r\n");
	 tempuser = GetUserInfo();
	
	XYBody.Append("	<div id=\"layout\">\r\n");
	XYBody.Append("		<div id=\"layoutLeft\">\r\n");
	XYBody.Append("			<div id=\"LeftProBorder\">\r\n");
	XYBody.Append("				<div id=\"ProTitle\">\r\n");
	XYBody.Append("				    ");	XYBody.Append(machininginfo.Title.ToString());	XYBody.Append("\r\n");
	XYBody.Append("				</div>\r\n");
	XYBody.Append("				<div id=\"ProText\">\r\n");
	XYBody.Append("					<div id=\"ProPic\">\r\n");
	XYBody.Append("						<div id=\"ProPicBorder\">\r\n");
	XYBody.Append("							<a href=\"");	XYBody.Append(machininginfo.MorePicUrl.ToString());	XYBody.Append("\" id=\"viewbigURL\" target=\"_blank\">\r\n");
	XYBody.Append("							<img src=\"" + machininginfo.SmallImg[2].ToString().Trim() + "\" alt=\"");	XYBody.Append(machininginfo.Title.ToString());	XYBody.Append("\" border=\"0\" id=\"viewbigpic\" onload=\"LoadImg(280,280,this)\" /></a>\r\n");
	XYBody.Append("						</div>\r\n");
	XYBody.Append("						<div id=\"ProPicName\">\r\n");
	XYBody.Append("						    <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/big.gif\" style=\"vertical-align:middle\" /> \r\n");
	XYBody.Append("						    <a href=\"");	XYBody.Append(machininginfo.MorePicUrl.ToString());	XYBody.Append("\" target=\"_blank\">");	XYBody.Append(machininginfo.Title.ToString());	XYBody.Append("</a>\r\n");
	XYBody.Append("						</div>\r\n");
	XYBody.Append("					</div>\r\n");
	XYBody.Append("					<div id=\"ProInfo\">\r\n");
	XYBody.Append("						<div id=\"ProInfoA\">\r\n");
	XYBody.Append("							<a href=\"");	XYBody.Append(tempuser.shopindex.ToString());	XYBody.Append("\" class=\"blueLink Font14\"><strong>");	XYBody.Append(tempuser.unitname.ToString());	XYBody.Append("</strong></a>&nbsp;&nbsp;<a href=\"");	XYBody.Append(tempuser.shopindex.ToString());	XYBody.Append("\" target=\"_blank\"><img src=\"");	XYBody.Append(tempuser.gradeimgurl.ToString());	XYBody.Append("\" border=\"0\" style=\"position:relative;top:1px;\" /></a>&nbsp;&nbsp;<strong class=\"Font14\">第<span class=\"MemberYear\">");	XYBody.Append(tempuser.years.ToString());	XYBody.Append("</span>年</strong>\r\n");
	XYBody.Append("							<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"fontGray\">\r\n");
	XYBody.Append("								<tr>\r\n");
	XYBody.Append("									<td height=\"10\" colspan=\"2\"></td>\r\n");
	XYBody.Append("								</tr>\r\n");
	XYBody.Append("								<tr>\r\n");
	XYBody.Append("									<td height=\"33\" colspan=\"2\">\r\n");
	XYBody.Append("									    <a href=\"");	XYBody.Append(tempuser.shopindex.ToString());	XYBody.Append("\" target=\"_blank\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/enterWEB.gif\" alt=\"进入企业网站\" width=\"112\" height=\"21\" border=\"0\" /></a>&nbsp;&nbsp;&nbsp;\r\n");
	XYBody.Append("									    <a href=\"");	XYBody.Append(tempuser.contactus.ToString());	XYBody.Append("\" target=\"_blank\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/enterContact.gif\" alt=\"查看联系方式\" width=\"112\" height=\"21\" border=\"0\" /></a></td>\r\n");
	XYBody.Append("									</tr>\r\n");
	XYBody.Append("								<tr>\r\n");
	XYBody.Append("									<td width=\"50%\" height=\"22\">企业类型：");	XYBody.Append(tempuser.character.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("									<td width=\"50%\">员工人数：");	XYBody.Append(tempuser.employeetotal.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("								</tr>\r\n");
	XYBody.Append("								<tr>\r\n");
	XYBody.Append("									<td height=\"22\">经营模式：");	XYBody.Append(tempuser.mode.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("									<td>注册资金：");	XYBody.Append(tempuser.registeredcapital.ToString());	XYBody.Append("万</td>\r\n");
	XYBody.Append("								</tr>\r\n");
	XYBody.Append("							</table>\r\n");
	XYBody.Append("						</div>\r\n");
	XYBody.Append("						<div id=\"ProInfoB\">\r\n");
	XYBody.Append("							<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	XYBody.Append("									<tr>\r\n");
	XYBody.Append("										<td  height=\"24\" colspan=\"2\">\r\n");

	if (machininginfo.Price==0)
	{

	XYBody.Append("                                            当 前 价：<span>面议</span>");	XYBody.Append(machininginfo.Unit.ToString());	XYBody.Append("\r\n");

	}
	else
	{

	XYBody.Append("                                            当 前 价：<span>");	XYBody.Append(machininginfo.Price.ToString());	XYBody.Append("</span> 元/");	XYBody.Append(machininginfo.Unit.ToString());	XYBody.Append(" \r\n");

	}	//end if

	XYBody.Append("                                        &nbsp;&nbsp;&nbsp;&nbsp;\r\n");
	XYBody.Append("										</td>\r\n");
	XYBody.Append("									</tr>\r\n");
	XYBody.Append("									<tr>\r\n");
	XYBody.Append("									    <td width=\"50%\">最小起订：");	XYBody.Append(machininginfo.LeastNum.ToString());	XYBody.Append(" ");	XYBody.Append(machininginfo.Unit.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("										<td width=\"50%\">货物总量：");	XYBody.Append(machininginfo.CountNum.ToString());	XYBody.Append(" ");	XYBody.Append(machininginfo.Unit.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("									</tr>\r\n");
	XYBody.Append("									<tr>\r\n");
	XYBody.Append("										<td height=\"24\">有效期至：");	XYBody.Append(machininginfo.EndTime.ToShortDateString().ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("										<td>发布时间：");	XYBody.Append(machininginfo.PublishTime.ToShortDateString().ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("									</tr>\r\n");
	XYBody.Append("									<tr>\r\n");
	XYBody.Append("										<td height=\"24\" colspan=\"3\">联 系 人：");	XYBody.Append(tempuser.linkman.ToString());	XYBody.Append("&nbsp;&nbsp;<img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/icon_tianjiasy.gif\" width=\"13\" height=\"12\" style=\"position:relative;top:1px;\" /> <a href=\"javascript:void(null);\" onclick=\"Favorite();\" class=\"orange\">添加为商业伙伴</a></td>\r\n");
	XYBody.Append("									</tr>\r\n");
	XYBody.Append("							</table>\r\n");
	XYBody.Append("						</div>\r\n");
	XYBody.Append("						<div class=\"blank5\"></div>\r\n");
	XYBody.Append("						<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	XYBody.Append("							<tr>\r\n");
	XYBody.Append("								<td height=\"60\"><a href=\"#message\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/inquire2.gif\" width=\"139\" height=\"36\" border=\"0\" /></a> </td>\r\n");
	XYBody.Append("								<td style=\"text-align:center;\"><span class=\"Font14\">或联系</span>：<strong class=\"orange\" class=\"TempTele\">86-010-62669815</strong></td>\r\n");
	XYBody.Append("								<td width=\"23%\"></td>\r\n");
	XYBody.Append("							</tr>\r\n");
	XYBody.Append("						</table>\r\n");
	XYBody.Append("					</div>\r\n");
	XYBody.Append("					<div class=\"clr\"></div>\r\n");
	XYBody.Append("					<div id=\"ProDesTitle\"><strong>详细信息:</strong></div>\r\n");
	XYBody.Append("					<div class=\"ProDesText\">\r\n");
	XYBody.Append("					     <table width=\"95%\" border=\"0\" align=\"center\" cellpadding=\"1\" cellspacing=\"1\" class=\"typelist\">");	XYBody.Append(fieldbody.ToString());	XYBody.Append("</table>\r\n");
	XYBody.Append("					     ");	XYBody.Append(machininginfo.InfoContent.ToString());	XYBody.Append("\r\n");
	XYBody.Append("					</div>\r\n");
	XYBody.Append("					<div id=\"ProDesTitle\">\r\n");
	XYBody.Append("					    <strong>联系方式:</strong>\r\n");
	XYBody.Append("					</div>\r\n");
	XYBody.Append("					<div class=\"ProDesText\" id=\"linkmessage\"></div>\r\n");
	XYBody.Append("				</div>\r\n");
	XYBody.Append("			</div>\r\n");
	XYBody.Append("			<div id=\"ProFind\">\r\n");
	XYBody.Append("			    <span>\r\n");
	XYBody.Append("			    <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/icon1.gif\" width=\"20\" height=\"14\" /><a href=\"javascript:void(null);\" onclick=\"Favorite();\">收藏此信息</a>&nbsp;&nbsp;&nbsp;\r\n");
	XYBody.Append("			    <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/icon2.gif\" width=\"21\" height=\"11\" /><a href=\"#\">推荐给朋友</a>&nbsp;&nbsp;&nbsp;\r\n");
	XYBody.Append("			    <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/icon3.gif\" height=\"16\" /><a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("feedback.");	XYBody.Append(config.suffix);	XYBody.Append("\">举报此信息</a>\r\n");
	XYBody.Append("			    </span>\r\n");
	XYBody.Append("			    <strong class=\"orange\">还没有找到合适的产品?</strong>  赶快<a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("user/\" target=\"_blank\">发布求购信息</a>，让供应商主动来找您！\r\n");
	XYBody.Append("    	    </div>\r\n");
	XYBody.Append("			<input type =\"hidden\" id=\"_param_message_module\" value=\"");	XYBody.Append(module.EName.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("            <input type =\"hidden\" id=\"_param_message_title\" value=\"");	XYBody.Append(titleinfo.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("            <input type =\"hidden\" id=\"_param_message_parent_module\" value =\"");	XYBody.Append(pageinfo.ModuleFlag);	XYBody.Append("\" />\r\n");
	XYBody.Append("            <input type =\"hidden\" id=\"_param_message_infoid\" value =\"");	XYBody.Append(machininginfo.InfoID.ToString());	XYBody.Append("\"/>\r\n");
	XYBody.Append("            <input type =\"hidden\" id=\"_param_message_userid\" value =\"");	XYBody.Append(machininginfo.UserID.ToString());	XYBody.Append("\" />\r\n");

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


	XYBody.Append("		 </form>\r\n");
	XYBody.Append("			<div id=\"SayInfo\">\r\n");
	XYBody.Append("				<strong>免责声明</strong>：以上信息由相关企业自行提供，该企业负责信息内容的真实性、准确性和合法性。\r\n");
	XYBody.Append("				<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");	XYBody.Append(config.webname);	XYBody.Append("对此不承担任何保证责任。\r\n");
	XYBody.Append("			</div>\r\n");
	XYBody.Append("		</div>\r\n");
	XYBody.Append("	    <div id=\"layoutRight\">\r\n");
	XYBody.Append("			<div id=\"content\">\r\n");
	XYBody.Append("                <input type =\"hidden\" id=\"_param_userinfo_parent_module\" value =\"");	XYBody.Append(pageinfo.ModuleFlag);	XYBody.Append("\" />\r\n");
	XYBody.Append("                <input type =\"hidden\" id=\"_param_userinfo_infoid\" value =\"");	XYBody.Append(machininginfo.InfoID.ToString());	XYBody.Append("\"/>\r\n");
	XYBody.Append("                <input type =\"hidden\" id=\"_param_userinfo_userid\" value =\"");	XYBody.Append(machininginfo.UserID.ToString());	XYBody.Append("\" />\r\n");

	XYBody.Append("<!--完整显示信息--> \r\n");
	XYBody.Append("<div class=\"w290\" id=\"loginuser\" style=\"display:none;\">  \r\n");
	XYBody.Append("    <ul>\r\n");
	XYBody.Append("        <li id=\"loginuseruginfo\"></li>\r\n");
	XYBody.Append("        <li class=\"line\"><a id=\"loginuserurl\" href=\"\" class=\"link14\"></a></li>\r\n");
	XYBody.Append("        <li>公司资料完成率 <span id=\"ConsummatePercent\"></span></li>\r\n");
	XYBody.Append("        <li><div class=\"cr\"><img id=\"PercentForImg\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/rate.gif\" alt=\" \"  height=\"15px\" /></div></li>\r\n");
	XYBody.Append("        <li><a href=\"#\" id=\"NewOfferPage\">最新供应</a> | <a href=\"#\" id=\"GoodFaithFile\">诚信档案</a> | <a href=\"#\" id=\"UserIntro\">公司介绍</a></li>\r\n");
	XYBody.Append("        <li>联系人：<a href=\"#\" id=\"Contact\"><span id=\"LinkManName\">不详</span></a> 先生 <span id=\"IMOnline\"></span></li>\r\n");
	XYBody.Append("        <li><hr /></li>\r\n");
	XYBody.Append("        <li>加入时间：第 <span id=\"loginuseryearnum\"></span> 年</li>\r\n");
	XYBody.Append("        <li> <a href=\"javascript:;\" onclick =\"Favorite();\">收藏此信息</a> <a href=\"#\" id=\"memessage\">给我留言</a> <a href=\"#\" id=\"linkme\">联系方式</a></li>  \r\n");
	XYBody.Append("    </ul>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<!--要求登陆后查看-->\r\n");
	XYBody.Append("<div class=\"w290\" id=\"UserNoLogin\" style=\"display:none;\">\r\n");
	XYBody.Append("    <ul class=\"login\">\r\n");
	XYBody.Append("        <li><h4>已经是会员请登陆</h4></li>\r\n");
	XYBody.Append("        <li>用户名：<input type=\"text\" name=\"\" tabindex=\"1\"  id=\"username\" name=\"username\" onkeydown =\"KeyDown();\" maxlength=\"50\" /></li>\r\n");
	XYBody.Append("        <li>密&nbsp;&nbsp;&nbsp;码：<input type =\"password\" maxlength=\"20\" tabindex=\"2\" id=\"password\"  name=\"password\" onkeydown =\"KeyDown();\" /></li>\r\n");

	if (config.IsEnabledVCode("login"))
	{

	XYBody.Append("        <li>验证码：");	XYBody.Append(pageinfo.GetValidateCodeHTML());	XYBody.Append("</li>\r\n");

	}	//end if

	XYBody.Append("        <li><input type=\"button\" class=\"button\" value=\"登录\" onclick=\"return InfoLogin();\"/><a href=\"/GetPassword.");	XYBody.Append(config.Suffix);	XYBody.Append("\">忘记密码？</a></li>\r\n");
	XYBody.Append("        <li><hr /></li>\r\n");
	XYBody.Append("        <ll>你还不是会员，请<a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("register.");	XYBody.Append(config.Suffix);	XYBody.Append("\">立刻免费注册</a></li>\r\n");
	XYBody.Append("        <li>\r\n");
	XYBody.Append("            <div class=\"contactus\">\r\n");
	XYBody.Append("                <ul>\r\n");
	XYBody.Append("                <li><h3>如有任何疑问请与我们联系</h3></li>\r\n");
	XYBody.Append("                <li>在线客服：<img src=\"/templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/kefu.gif\" /> <img src=\"/templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/kefu.gif\" /></li>\r\n");
	XYBody.Append("                <li>客户热线：010-8681 8791</li>\r\n");
	XYBody.Append("                </ul>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </li>      \r\n");
	XYBody.Append("    </ul>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<!--要求升级后查看-->\r\n");
	XYBody.Append("<div class=\"w290\" id=\"loginnouser\" style=\"display:none;\">\r\n");
	XYBody.Append("    <h3><span id=\"loginnouseruginfo\"></span></h3>\r\n");
	XYBody.Append("    <ul class=\"upgrade\">\r\n");
	XYBody.Append("        <li><span>您目前所在的会员组，无法查看信息。</span></li>\r\n");
	XYBody.Append("        <li><a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("user/postadministratormessage.");	XYBody.Append(config.Suffix);	XYBody.Append("\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/update.gif\" border=\"0\"/></a></li>\r\n");
	XYBody.Append("        <li><a href=\"\">点此查看会员等级与权限>></a></li>\r\n");
	XYBody.Append("        <li>\r\n");
	XYBody.Append("            <div class=\"contactus\">\r\n");
	XYBody.Append("                <ul>\r\n");
	XYBody.Append("                <li><h3>如有任何疑问请与我们联系</h3></li>\r\n");
	XYBody.Append("                <li>在线客服：<img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/kefu.gif\" /> <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/kefu.gif\" /></li>\r\n");
	XYBody.Append("                <li>客户热线：010-8681 8791</li>\r\n");
	XYBody.Append("                </ul>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </li>\r\n");
	XYBody.Append("        <li><a href=\"javascript:;\" onclick =\"Favorite();\">收藏此信息</a></li>\r\n");
	XYBody.Append("    </ul>\r\n");
	XYBody.Append("</div>  \r\n");


	XYBody.Append("			</div>\r\n");
	XYBody.Append("			<div class=\"MTitle_01\">\r\n");
	XYBody.Append("				<center><a target=\"_blank\" href=\"#\" class=\"red\"><strong>加入我们，享受更多服务</strong></a></center>\r\n");
	XYBody.Append("			</div>\r\n");
	XYBody.Append("			<div class=\"Mblk_01\">\r\n");
	XYBody.Append("				<div id=\"jointous\">\r\n");
	XYBody.Append("					<ul>\r\n");
	XYBody.Append("						<li><a href=\"\">· 结交贸易伙伴，拓展网络商圈</a></li>\r\n");
	XYBody.Append("						<li><a href=\"\">· 成为会员，免费发布供求信息</a></li>\r\n");
	XYBody.Append("						<li><a href=\"\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/btn_gq_reg.gif\" width=\"130\" height=\"29\" alt=\"\" /></a></li>\r\n");
	XYBody.Append("					</ul>\r\n");
	XYBody.Append("				</div>\r\n");
	XYBody.Append("			</div>\r\n");
	XYBody.Append("	</div>\r\n");
	XYBody.Append("	</div>\r\n");



	}	//end if


	if (pageinfo.ModuleFlag=="investment")
	{


	XYBody.Append("	<div id=\"gq_guide\">\r\n");
	XYBody.Append("		<a href=\"\">");	XYBody.Append(pageinfo.Navigation);	XYBody.Append("\r\n");
	XYBody.Append("	</div>\r\n");
	 tempuser = GetUserInfo();
	
	XYBody.Append("	<div id=\"layout\">\r\n");
	XYBody.Append("		<div id=\"layoutLeft\">\r\n");
	XYBody.Append("			<div id=\"LeftProBorder\">\r\n");
	XYBody.Append("				<div id=\"ProTitle\">\r\n");
	XYBody.Append("				    ");	XYBody.Append(investmentinfo.Title.ToString());	XYBody.Append("\r\n");
	XYBody.Append("				</div>\r\n");
	XYBody.Append("				<div id=\"ProText\">\r\n");
	XYBody.Append("					<div id=\"ProPic\">\r\n");
	XYBody.Append("						<div id=\"ProPicBorder\">\r\n");
	XYBody.Append("							<a href=\"");	XYBody.Append(investmentinfo.MorePicUrl.ToString());	XYBody.Append("\" id=\"viewbigURL\" target=\"_blank\">\r\n");
	XYBody.Append("							<img src=\"" + investmentinfo.SmallImg[2].ToString().Trim() + "\" alt=\"");	XYBody.Append(investmentinfo.Title.ToString());	XYBody.Append("\" border=\"0\" id=\"viewbigpic\" onload=\"LoadImg(280,280,this)\" /></a>\r\n");
	XYBody.Append("						</div>\r\n");
	XYBody.Append("						<div id=\"ProPicName\">\r\n");
	XYBody.Append("						    <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/big.gif\" style=\"vertical-align:middle\" /> \r\n");
	XYBody.Append("						    <a href=\"");	XYBody.Append(investmentinfo.MorePicUrl.ToString());	XYBody.Append("\" target=\"_blank\">");	XYBody.Append(investmentinfo.Title.ToString());	XYBody.Append("</a>\r\n");
	XYBody.Append("						</div>\r\n");
	XYBody.Append("					</div>\r\n");
	XYBody.Append("					<div id=\"ProInfo\">\r\n");
	XYBody.Append("						<div id=\"ProInfoA\">\r\n");
	XYBody.Append("							<a href=\"");	XYBody.Append(tempuser.shopindex.ToString());	XYBody.Append("\" class=\"blueLink Font14\"><strong>");	XYBody.Append(tempuser.unitname.ToString());	XYBody.Append("</strong></a>&nbsp;&nbsp;<a href=\"");	XYBody.Append(tempuser.shopindex.ToString());	XYBody.Append("\" target=\"_blank\"><img src=\"");	XYBody.Append(tempuser.gradeimgurl.ToString());	XYBody.Append("\" border=\"0\" style=\"position:relative;top:1px;\" /></a>&nbsp;&nbsp;<strong class=\"Font14\">第<span class=\"MemberYear\">");	XYBody.Append(tempuser.years.ToString());	XYBody.Append("</span>年</strong>\r\n");
	XYBody.Append("							<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"fontGray\">\r\n");
	XYBody.Append("								<tr>\r\n");
	XYBody.Append("									<td height=\"10\" colspan=\"2\"></td>\r\n");
	XYBody.Append("								</tr>\r\n");
	XYBody.Append("								<tr>\r\n");
	XYBody.Append("									<td height=\"33\" colspan=\"2\">\r\n");
	XYBody.Append("									    <a href=\"");	XYBody.Append(tempuser.shopindex.ToString());	XYBody.Append("\" target=\"_blank\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/enterWEB.gif\" alt=\"进入企业网站\" width=\"112\" height=\"21\" border=\"0\" /></a>&nbsp;&nbsp;&nbsp;\r\n");
	XYBody.Append("									    <a href=\"");	XYBody.Append(tempuser.contactus.ToString());	XYBody.Append("\" target=\"_blank\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/enterContact.gif\" alt=\"查看联系方式\" width=\"112\" height=\"21\" border=\"0\" /></a></td>\r\n");
	XYBody.Append("									</tr>\r\n");
	XYBody.Append("								<tr>\r\n");
	XYBody.Append("									<td width=\"50%\" height=\"22\">企业类型：");	XYBody.Append(tempuser.character.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("									<td width=\"50%\">员工人数：");	XYBody.Append(tempuser.employeetotal.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("								</tr>\r\n");
	XYBody.Append("								<tr>\r\n");
	XYBody.Append("									<td height=\"22\">经营模式：");	XYBody.Append(tempuser.mode.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("									<td>注册资金：");	XYBody.Append(tempuser.registeredcapital.ToString());	XYBody.Append("万</td>\r\n");
	XYBody.Append("								</tr>\r\n");
	XYBody.Append("							</table>\r\n");
	XYBody.Append("						</div>\r\n");
	XYBody.Append("						<div id=\"ProInfoB\">\r\n");
	XYBody.Append("							<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	XYBody.Append("									<tr>\r\n");
	XYBody.Append("										<td  height=\"24\" colspan=\"2\">曾代理过的品牌：");	XYBody.Append(investmentinfo.QuondamProduct.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("									</tr>\r\n");
	XYBody.Append("									<tr>\r\n");
	XYBody.Append("										<td height=\"24\">有效期至：");	XYBody.Append(investmentinfo.EndTime.ToShortDateString().ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("										<td>发布时间：");	XYBody.Append(investmentinfo.PublishTime.ToShortDateString().ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("									</tr>\r\n");
	XYBody.Append("									<tr>\r\n");
	XYBody.Append("										<td height=\"24\" colspan=\"3\">联 系 人：");	XYBody.Append(tempuser.linkman.ToString());	XYBody.Append("&nbsp;&nbsp;<img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/icon_tianjiasy.gif\" width=\"13\" height=\"12\" style=\"position:relative;top:1px;\" /> <a href=\"javascript:void(null);\" onclick=\"Favorite();\" class=\"orange\">添加为商业伙伴</a></td>\r\n");
	XYBody.Append("									</tr>\r\n");
	XYBody.Append("							</table>\r\n");
	XYBody.Append("						</div>\r\n");
	XYBody.Append("						<div class=\"blank5\"></div>\r\n");
	XYBody.Append("						<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	XYBody.Append("							<tr>\r\n");
	XYBody.Append("								<td height=\"60\"><a href=\"#message\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/inquire2.gif\" width=\"139\" height=\"36\" border=\"0\" /></a> </td>\r\n");
	XYBody.Append("								<td style=\"text-align:center;\"><span class=\"Font14\">或联系</span>：<strong class=\"orange\" class=\"TempTele\">86-010-62669815</strong></td>\r\n");
	XYBody.Append("								<td width=\"23%\"></td>\r\n");
	XYBody.Append("							</tr>\r\n");
	XYBody.Append("						</table>\r\n");
	XYBody.Append("					</div>\r\n");
	XYBody.Append("					<div class=\"clr\"></div>\r\n");
	XYBody.Append("					<div id=\"ProDesTitle\"><strong>详细信息:</strong></div>\r\n");
	XYBody.Append("					<div class=\"ProDesText\">\r\n");
	XYBody.Append("					     <table width=\"95%\" border=\"0\" align=\"center\" cellpadding=\"1\" cellspacing=\"1\" class=\"typelist\">");	XYBody.Append(fieldbody.ToString());	XYBody.Append("</table>\r\n");
	XYBody.Append("					     ");	XYBody.Append(investmentinfo.InfoContent.ToString());	XYBody.Append("\r\n");
	XYBody.Append("					</div>\r\n");
	XYBody.Append("					<div id=\"ProDesTitle\">\r\n");
	XYBody.Append("					    <strong>联系方式:</strong>\r\n");
	XYBody.Append("					</div>\r\n");
	XYBody.Append("					<div class=\"ProDesText\" id=\"linkmessage\"></div>\r\n");
	XYBody.Append("				</div>\r\n");
	XYBody.Append("			</div>\r\n");
	XYBody.Append("			<div id=\"ProFind\">\r\n");
	XYBody.Append("			    <span>\r\n");
	XYBody.Append("			    <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/icon1.gif\" width=\"20\" height=\"14\" /><a href=\"javascript:void(null);\" onclick=\"Favorite();\">收藏此信息</a>&nbsp;&nbsp;&nbsp;\r\n");
	XYBody.Append("			    <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/icon2.gif\" width=\"21\" height=\"11\" /><a href=\"#\">推荐给朋友</a>&nbsp;&nbsp;&nbsp;\r\n");
	XYBody.Append("			    <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/icon3.gif\" height=\"16\" /><a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("feedback.");	XYBody.Append(config.suffix);	XYBody.Append("\">举报此信息</a>\r\n");
	XYBody.Append("			    </span>\r\n");
	XYBody.Append("			    <strong class=\"orange\">还没有找到合适的产品?</strong>  赶快<a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("user/\" target=\"_blank\">发布求购信息</a>，让供应商主动来找您！\r\n");
	XYBody.Append("    	    </div>\r\n");
	XYBody.Append("			<input type =\"hidden\" id=\"_param_message_module\" value=\"");	XYBody.Append(module.EName.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("            <input type =\"hidden\" id=\"_param_message_title\" value=\"");	XYBody.Append(titleinfo.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("            <input type =\"hidden\" id=\"_param_message_parent_module\" value =\"");	XYBody.Append(pageinfo.ModuleFlag);	XYBody.Append("\" />\r\n");
	XYBody.Append("            <input type =\"hidden\" id=\"_param_message_infoid\" value =\"");	XYBody.Append(investmentinfo.InfoID.ToString());	XYBody.Append("\"/>\r\n");
	XYBody.Append("            <input type =\"hidden\" id=\"_param_message_userid\" value =\"");	XYBody.Append(investmentinfo.UserID.ToString());	XYBody.Append("\" />\r\n");

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


	XYBody.Append("		 </form>\r\n");
	XYBody.Append("			<div id=\"SayInfo\">\r\n");
	XYBody.Append("				<strong>免责声明</strong>：以上信息由相关企业自行提供，该企业负责信息内容的真实性、准确性和合法性。\r\n");
	XYBody.Append("				<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");	XYBody.Append(config.webname);	XYBody.Append("对此不承担任何保证责任。\r\n");
	XYBody.Append("			</div>\r\n");
	XYBody.Append("		</div>\r\n");
	XYBody.Append("	    <div id=\"layoutRight\">\r\n");
	XYBody.Append("			<div id=\"content\">\r\n");
	XYBody.Append("                <input type =\"hidden\" id=\"_param_userinfo_parent_module\" value =\"");	XYBody.Append(pageinfo.ModuleFlag);	XYBody.Append("\" />\r\n");
	XYBody.Append("                <input type =\"hidden\" id=\"_param_userinfo_infoid\" value =\"");	XYBody.Append(investmentinfo.InfoID.ToString());	XYBody.Append("\"/>\r\n");
	XYBody.Append("                <input type =\"hidden\" id=\"_param_userinfo_userid\" value =\"");	XYBody.Append(investmentinfo.UserID.ToString());	XYBody.Append("\" />\r\n");

	XYBody.Append("<!--完整显示信息--> \r\n");
	XYBody.Append("<div class=\"w290\" id=\"loginuser\" style=\"display:none;\">  \r\n");
	XYBody.Append("    <ul>\r\n");
	XYBody.Append("        <li id=\"loginuseruginfo\"></li>\r\n");
	XYBody.Append("        <li class=\"line\"><a id=\"loginuserurl\" href=\"\" class=\"link14\"></a></li>\r\n");
	XYBody.Append("        <li>公司资料完成率 <span id=\"ConsummatePercent\"></span></li>\r\n");
	XYBody.Append("        <li><div class=\"cr\"><img id=\"PercentForImg\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/rate.gif\" alt=\" \"  height=\"15px\" /></div></li>\r\n");
	XYBody.Append("        <li><a href=\"#\" id=\"NewOfferPage\">最新供应</a> | <a href=\"#\" id=\"GoodFaithFile\">诚信档案</a> | <a href=\"#\" id=\"UserIntro\">公司介绍</a></li>\r\n");
	XYBody.Append("        <li>联系人：<a href=\"#\" id=\"Contact\"><span id=\"LinkManName\">不详</span></a> 先生 <span id=\"IMOnline\"></span></li>\r\n");
	XYBody.Append("        <li><hr /></li>\r\n");
	XYBody.Append("        <li>加入时间：第 <span id=\"loginuseryearnum\"></span> 年</li>\r\n");
	XYBody.Append("        <li> <a href=\"javascript:;\" onclick =\"Favorite();\">收藏此信息</a> <a href=\"#\" id=\"memessage\">给我留言</a> <a href=\"#\" id=\"linkme\">联系方式</a></li>  \r\n");
	XYBody.Append("    </ul>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<!--要求登陆后查看-->\r\n");
	XYBody.Append("<div class=\"w290\" id=\"UserNoLogin\" style=\"display:none;\">\r\n");
	XYBody.Append("    <ul class=\"login\">\r\n");
	XYBody.Append("        <li><h4>已经是会员请登陆</h4></li>\r\n");
	XYBody.Append("        <li>用户名：<input type=\"text\" name=\"\" tabindex=\"1\"  id=\"username\" name=\"username\" onkeydown =\"KeyDown();\" maxlength=\"50\" /></li>\r\n");
	XYBody.Append("        <li>密&nbsp;&nbsp;&nbsp;码：<input type =\"password\" maxlength=\"20\" tabindex=\"2\" id=\"password\"  name=\"password\" onkeydown =\"KeyDown();\" /></li>\r\n");

	if (config.IsEnabledVCode("login"))
	{

	XYBody.Append("        <li>验证码：");	XYBody.Append(pageinfo.GetValidateCodeHTML());	XYBody.Append("</li>\r\n");

	}	//end if

	XYBody.Append("        <li><input type=\"button\" class=\"button\" value=\"登录\" onclick=\"return InfoLogin();\"/><a href=\"/GetPassword.");	XYBody.Append(config.Suffix);	XYBody.Append("\">忘记密码？</a></li>\r\n");
	XYBody.Append("        <li><hr /></li>\r\n");
	XYBody.Append("        <ll>你还不是会员，请<a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("register.");	XYBody.Append(config.Suffix);	XYBody.Append("\">立刻免费注册</a></li>\r\n");
	XYBody.Append("        <li>\r\n");
	XYBody.Append("            <div class=\"contactus\">\r\n");
	XYBody.Append("                <ul>\r\n");
	XYBody.Append("                <li><h3>如有任何疑问请与我们联系</h3></li>\r\n");
	XYBody.Append("                <li>在线客服：<img src=\"/templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/kefu.gif\" /> <img src=\"/templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/kefu.gif\" /></li>\r\n");
	XYBody.Append("                <li>客户热线：010-8681 8791</li>\r\n");
	XYBody.Append("                </ul>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </li>      \r\n");
	XYBody.Append("    </ul>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<!--要求升级后查看-->\r\n");
	XYBody.Append("<div class=\"w290\" id=\"loginnouser\" style=\"display:none;\">\r\n");
	XYBody.Append("    <h3><span id=\"loginnouseruginfo\"></span></h3>\r\n");
	XYBody.Append("    <ul class=\"upgrade\">\r\n");
	XYBody.Append("        <li><span>您目前所在的会员组，无法查看信息。</span></li>\r\n");
	XYBody.Append("        <li><a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("user/postadministratormessage.");	XYBody.Append(config.Suffix);	XYBody.Append("\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/update.gif\" border=\"0\"/></a></li>\r\n");
	XYBody.Append("        <li><a href=\"\">点此查看会员等级与权限>></a></li>\r\n");
	XYBody.Append("        <li>\r\n");
	XYBody.Append("            <div class=\"contactus\">\r\n");
	XYBody.Append("                <ul>\r\n");
	XYBody.Append("                <li><h3>如有任何疑问请与我们联系</h3></li>\r\n");
	XYBody.Append("                <li>在线客服：<img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/kefu.gif\" /> <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/kefu.gif\" /></li>\r\n");
	XYBody.Append("                <li>客户热线：010-8681 8791</li>\r\n");
	XYBody.Append("                </ul>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </li>\r\n");
	XYBody.Append("        <li><a href=\"javascript:;\" onclick =\"Favorite();\">收藏此信息</a></li>\r\n");
	XYBody.Append("    </ul>\r\n");
	XYBody.Append("</div>  \r\n");


	XYBody.Append("			</div>\r\n");
	XYBody.Append("			<div class=\"MTitle_01\">\r\n");
	XYBody.Append("				<center><a target=\"_blank\" href=\"#\" class=\"red\"><strong>加入我们，享受更多服务</strong></a></center>\r\n");
	XYBody.Append("			</div>\r\n");
	XYBody.Append("			<div class=\"Mblk_01\">\r\n");
	XYBody.Append("				<div id=\"jointous\">\r\n");
	XYBody.Append("					<ul>\r\n");
	XYBody.Append("						<li><a href=\"\">· 结交贸易伙伴，拓展网络商圈</a></li>\r\n");
	XYBody.Append("						<li><a href=\"\">· 成为会员，免费发布供求信息</a></li>\r\n");
	XYBody.Append("						<li><a href=\"\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/btn_gq_reg.gif\" width=\"130\" height=\"29\" alt=\"\" /></a></li>\r\n");
	XYBody.Append("					</ul>\r\n");
	XYBody.Append("				</div>\r\n");
	XYBody.Append("			</div>\r\n");
	XYBody.Append("	</div>\r\n");
	XYBody.Append("	</div>\r\n");



	}	//end if


	if (pageinfo.ModuleFlag=="service")
	{


	XYBody.Append("	<div id=\"gq_guide\">\r\n");
	XYBody.Append("		<a href=\"\">");	XYBody.Append(pageinfo.Navigation);	XYBody.Append("\r\n");
	XYBody.Append("	</div>\r\n");
	 tempuser = GetUserInfo();
	
	XYBody.Append("	<div id=\"layout\">\r\n");
	XYBody.Append("		<div id=\"layoutLeft\">\r\n");
	XYBody.Append("			<div id=\"LeftProBorder\">\r\n");
	XYBody.Append("				<div id=\"ProTitle\">\r\n");
	XYBody.Append("				    ");	XYBody.Append(serviceinfo.Title.ToString());	XYBody.Append("\r\n");
	XYBody.Append("				</div>\r\n");
	XYBody.Append("				<div id=\"ProText\">\r\n");
	XYBody.Append("					<div id=\"ProPic\">\r\n");
	XYBody.Append("						<div id=\"ProPicBorder\">\r\n");
	XYBody.Append("							<a href=\"");	XYBody.Append(serviceinfo.MorePicUrl.ToString());	XYBody.Append("\" id=\"viewbigURL\" target=\"_blank\">\r\n");
	XYBody.Append("							<img src=\"" + serviceinfo.SmallImg[2].ToString().Trim() + "\" alt=\"");	XYBody.Append(serviceinfo.Title.ToString());	XYBody.Append("\" border=\"0\" id=\"viewbigpic\" onload=\"LoadImg(280,280,this)\" /></a>\r\n");
	XYBody.Append("						</div>\r\n");
	XYBody.Append("						<div id=\"ProPicName\">\r\n");
	XYBody.Append("						    <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/big.gif\" style=\"vertical-align:middle\" /> \r\n");
	XYBody.Append("						    <a href=\"");	XYBody.Append(serviceinfo.MorePicUrl.ToString());	XYBody.Append("\" target=\"_blank\">");	XYBody.Append(serviceinfo.Title.ToString());	XYBody.Append("</a>\r\n");
	XYBody.Append("						</div>\r\n");
	XYBody.Append("					</div>\r\n");
	XYBody.Append("					<div id=\"ProInfo\">\r\n");
	XYBody.Append("						<div id=\"ProInfoA\">\r\n");
	XYBody.Append("							<a href=\"");	XYBody.Append(tempuser.shopindex.ToString());	XYBody.Append("\" class=\"blueLink Font14\"><strong>");	XYBody.Append(tempuser.unitname.ToString());	XYBody.Append("</strong></a>&nbsp;&nbsp;<a href=\"");	XYBody.Append(tempuser.shopindex.ToString());	XYBody.Append("\" target=\"_blank\"><img src=\"");	XYBody.Append(tempuser.gradeimgurl.ToString());	XYBody.Append("\" border=\"0\" style=\"position:relative;top:1px;\" /></a>&nbsp;&nbsp;<strong class=\"Font14\">第<span class=\"MemberYear\">");	XYBody.Append(tempuser.years.ToString());	XYBody.Append("</span>年</strong>\r\n");
	XYBody.Append("							<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"fontGray\">\r\n");
	XYBody.Append("								<tr>\r\n");
	XYBody.Append("									<td height=\"10\" colspan=\"2\"></td>\r\n");
	XYBody.Append("								</tr>\r\n");
	XYBody.Append("								<tr>\r\n");
	XYBody.Append("									<td height=\"33\" colspan=\"2\">\r\n");
	XYBody.Append("									    <a href=\"");	XYBody.Append(tempuser.shopindex.ToString());	XYBody.Append("\" target=\"_blank\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/enterWEB.gif\" alt=\"进入企业网站\" width=\"112\" height=\"21\" border=\"0\" /></a>&nbsp;&nbsp;&nbsp;\r\n");
	XYBody.Append("									    <a href=\"");	XYBody.Append(tempuser.contactus.ToString());	XYBody.Append("\" target=\"_blank\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/enterContact.gif\" alt=\"查看联系方式\" width=\"112\" height=\"21\" border=\"0\" /></a></td>\r\n");
	XYBody.Append("									</tr>\r\n");
	XYBody.Append("								<tr>\r\n");
	XYBody.Append("									<td width=\"50%\" height=\"22\">企业类型：");	XYBody.Append(tempuser.character.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("									<td width=\"50%\">员工人数：");	XYBody.Append(tempuser.employeetotal.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("								</tr>\r\n");
	XYBody.Append("								<tr>\r\n");
	XYBody.Append("									<td height=\"22\">经营模式：");	XYBody.Append(tempuser.mode.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("									<td>注册资金：");	XYBody.Append(tempuser.registeredcapital.ToString());	XYBody.Append("万</td>\r\n");
	XYBody.Append("								</tr>\r\n");
	XYBody.Append("							</table>\r\n");
	XYBody.Append("						</div>\r\n");
	XYBody.Append("						<div id=\"ProInfoB\">\r\n");
	XYBody.Append("							<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	XYBody.Append("									<tr>\r\n");
	XYBody.Append("										<td height=\"24\">有效期至：");	XYBody.Append(serviceinfo.EndTime.ToShortDateString().ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("										<td>发布时间：");	XYBody.Append(serviceinfo.PublishTime.ToShortDateString().ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("									</tr>\r\n");
	XYBody.Append("									<tr>\r\n");
	XYBody.Append("										<td height=\"24\" colspan=\"3\">联 系 人：");	XYBody.Append(tempuser.linkman.ToString());	XYBody.Append("&nbsp;&nbsp;<img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/icon_tianjiasy.gif\" width=\"13\" height=\"12\" style=\"position:relative;top:1px;\" /> <a href=\"javascript:void(null);\" onclick=\"Favorite();\" class=\"orange\">添加为商业伙伴</a></td>\r\n");
	XYBody.Append("									</tr>\r\n");
	XYBody.Append("							</table>\r\n");
	XYBody.Append("						</div>\r\n");
	XYBody.Append("						<div class=\"blank5\"></div>\r\n");
	XYBody.Append("						<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	XYBody.Append("							<tr>\r\n");
	XYBody.Append("								<td height=\"60\"><a href=\"#message\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/inquire2.gif\" width=\"139\" height=\"36\" border=\"0\" /></a> </td>\r\n");
	XYBody.Append("								<td style=\"text-align:center;\"><span class=\"Font14\">或联系</span>：<strong class=\"orange\" class=\"TempTele\">86-010-62669815</strong></td>\r\n");
	XYBody.Append("								<td width=\"23%\"></td>\r\n");
	XYBody.Append("							</tr>\r\n");
	XYBody.Append("						</table>\r\n");
	XYBody.Append("					</div>\r\n");
	XYBody.Append("					<div class=\"clr\"></div>\r\n");
	XYBody.Append("					<div id=\"ProDesTitle\"><strong>详细信息:</strong></div>\r\n");
	XYBody.Append("					<div class=\"ProDesText\">\r\n");
	XYBody.Append("					     <table width=\"95%\" border=\"0\" align=\"center\" cellpadding=\"1\" cellspacing=\"1\" class=\"typelist\">");	XYBody.Append(fieldbody.ToString());	XYBody.Append("</table>\r\n");
	XYBody.Append("					     ");	XYBody.Append(serviceinfo.InfoContent.ToString());	XYBody.Append("\r\n");
	XYBody.Append("					</div>\r\n");
	XYBody.Append("					<div id=\"ProDesTitle\">\r\n");
	XYBody.Append("					    <strong>联系方式:</strong>\r\n");
	XYBody.Append("					</div>\r\n");
	XYBody.Append("					<div class=\"ProDesText\" id=\"linkmessage\"></div>\r\n");
	XYBody.Append("				</div>\r\n");
	XYBody.Append("			</div>\r\n");
	XYBody.Append("			<div id=\"ProFind\">\r\n");
	XYBody.Append("			    <span>\r\n");
	XYBody.Append("			    <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/icon1.gif\" width=\"20\" height=\"14\" /><a href=\"javascript:void(null);\" onclick=\"Favorite();\">收藏此信息</a>&nbsp;&nbsp;&nbsp;\r\n");
	XYBody.Append("			    <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/icon2.gif\" width=\"21\" height=\"11\" /><a href=\"#\">推荐给朋友</a>&nbsp;&nbsp;&nbsp;\r\n");
	XYBody.Append("			    <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/icon3.gif\" height=\"16\" /><a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("feedback.");	XYBody.Append(config.suffix);	XYBody.Append("\">举报此信息</a>\r\n");
	XYBody.Append("			    </span>\r\n");
	XYBody.Append("			    <strong class=\"orange\">还没有找到合适的产品?</strong>  赶快<a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("user/\" target=\"_blank\">发布求购信息</a>，让供应商主动来找您！\r\n");
	XYBody.Append("    	    </div>\r\n");
	XYBody.Append("			<input type =\"hidden\" id=\"_param_message_module\" value=\"");	XYBody.Append(module.EName.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("            <input type =\"hidden\" id=\"_param_message_title\" value=\"");	XYBody.Append(titleinfo.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("            <input type =\"hidden\" id=\"_param_message_parent_module\" value =\"");	XYBody.Append(pageinfo.ModuleFlag);	XYBody.Append("\" />\r\n");
	XYBody.Append("            <input type =\"hidden\" id=\"_param_message_infoid\" value =\"");	XYBody.Append(serviceinfo.InfoID.ToString());	XYBody.Append("\"/>\r\n");
	XYBody.Append("            <input type =\"hidden\" id=\"_param_message_userid\" value =\"");	XYBody.Append(serviceinfo.UserID.ToString());	XYBody.Append("\" />\r\n");

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


	XYBody.Append("		 </form>\r\n");
	XYBody.Append("			<div id=\"SayInfo\">\r\n");
	XYBody.Append("				<strong>免责声明</strong>：以上信息由相关企业自行提供，该企业负责信息内容的真实性、准确性和合法性。\r\n");
	XYBody.Append("				<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");	XYBody.Append(config.webname);	XYBody.Append("对此不承担任何保证责任。\r\n");
	XYBody.Append("			</div>\r\n");
	XYBody.Append("		</div>\r\n");
	XYBody.Append("	    <div id=\"layoutRight\">\r\n");
	XYBody.Append("			<div id=\"content\">\r\n");
	XYBody.Append("                <input type =\"hidden\" id=\"_param_userinfo_parent_module\" value =\"");	XYBody.Append(pageinfo.ModuleFlag);	XYBody.Append("\" />\r\n");
	XYBody.Append("                <input type =\"hidden\" id=\"_param_userinfo_infoid\" value =\"");	XYBody.Append(serviceinfo.InfoID.ToString());	XYBody.Append("\"/>\r\n");
	XYBody.Append("                <input type =\"hidden\" id=\"_param_userinfo_userid\" value =\"");	XYBody.Append(serviceinfo.UserID.ToString());	XYBody.Append("\" />\r\n");

	XYBody.Append("<!--完整显示信息--> \r\n");
	XYBody.Append("<div class=\"w290\" id=\"loginuser\" style=\"display:none;\">  \r\n");
	XYBody.Append("    <ul>\r\n");
	XYBody.Append("        <li id=\"loginuseruginfo\"></li>\r\n");
	XYBody.Append("        <li class=\"line\"><a id=\"loginuserurl\" href=\"\" class=\"link14\"></a></li>\r\n");
	XYBody.Append("        <li>公司资料完成率 <span id=\"ConsummatePercent\"></span></li>\r\n");
	XYBody.Append("        <li><div class=\"cr\"><img id=\"PercentForImg\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/rate.gif\" alt=\" \"  height=\"15px\" /></div></li>\r\n");
	XYBody.Append("        <li><a href=\"#\" id=\"NewOfferPage\">最新供应</a> | <a href=\"#\" id=\"GoodFaithFile\">诚信档案</a> | <a href=\"#\" id=\"UserIntro\">公司介绍</a></li>\r\n");
	XYBody.Append("        <li>联系人：<a href=\"#\" id=\"Contact\"><span id=\"LinkManName\">不详</span></a> 先生 <span id=\"IMOnline\"></span></li>\r\n");
	XYBody.Append("        <li><hr /></li>\r\n");
	XYBody.Append("        <li>加入时间：第 <span id=\"loginuseryearnum\"></span> 年</li>\r\n");
	XYBody.Append("        <li> <a href=\"javascript:;\" onclick =\"Favorite();\">收藏此信息</a> <a href=\"#\" id=\"memessage\">给我留言</a> <a href=\"#\" id=\"linkme\">联系方式</a></li>  \r\n");
	XYBody.Append("    </ul>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<!--要求登陆后查看-->\r\n");
	XYBody.Append("<div class=\"w290\" id=\"UserNoLogin\" style=\"display:none;\">\r\n");
	XYBody.Append("    <ul class=\"login\">\r\n");
	XYBody.Append("        <li><h4>已经是会员请登陆</h4></li>\r\n");
	XYBody.Append("        <li>用户名：<input type=\"text\" name=\"\" tabindex=\"1\"  id=\"username\" name=\"username\" onkeydown =\"KeyDown();\" maxlength=\"50\" /></li>\r\n");
	XYBody.Append("        <li>密&nbsp;&nbsp;&nbsp;码：<input type =\"password\" maxlength=\"20\" tabindex=\"2\" id=\"password\"  name=\"password\" onkeydown =\"KeyDown();\" /></li>\r\n");

	if (config.IsEnabledVCode("login"))
	{

	XYBody.Append("        <li>验证码：");	XYBody.Append(pageinfo.GetValidateCodeHTML());	XYBody.Append("</li>\r\n");

	}	//end if

	XYBody.Append("        <li><input type=\"button\" class=\"button\" value=\"登录\" onclick=\"return InfoLogin();\"/><a href=\"/GetPassword.");	XYBody.Append(config.Suffix);	XYBody.Append("\">忘记密码？</a></li>\r\n");
	XYBody.Append("        <li><hr /></li>\r\n");
	XYBody.Append("        <ll>你还不是会员，请<a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("register.");	XYBody.Append(config.Suffix);	XYBody.Append("\">立刻免费注册</a></li>\r\n");
	XYBody.Append("        <li>\r\n");
	XYBody.Append("            <div class=\"contactus\">\r\n");
	XYBody.Append("                <ul>\r\n");
	XYBody.Append("                <li><h3>如有任何疑问请与我们联系</h3></li>\r\n");
	XYBody.Append("                <li>在线客服：<img src=\"/templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/kefu.gif\" /> <img src=\"/templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/kefu.gif\" /></li>\r\n");
	XYBody.Append("                <li>客户热线：010-8681 8791</li>\r\n");
	XYBody.Append("                </ul>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </li>      \r\n");
	XYBody.Append("    </ul>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<!--要求升级后查看-->\r\n");
	XYBody.Append("<div class=\"w290\" id=\"loginnouser\" style=\"display:none;\">\r\n");
	XYBody.Append("    <h3><span id=\"loginnouseruginfo\"></span></h3>\r\n");
	XYBody.Append("    <ul class=\"upgrade\">\r\n");
	XYBody.Append("        <li><span>您目前所在的会员组，无法查看信息。</span></li>\r\n");
	XYBody.Append("        <li><a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("user/postadministratormessage.");	XYBody.Append(config.Suffix);	XYBody.Append("\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/update.gif\" border=\"0\"/></a></li>\r\n");
	XYBody.Append("        <li><a href=\"\">点此查看会员等级与权限>></a></li>\r\n");
	XYBody.Append("        <li>\r\n");
	XYBody.Append("            <div class=\"contactus\">\r\n");
	XYBody.Append("                <ul>\r\n");
	XYBody.Append("                <li><h3>如有任何疑问请与我们联系</h3></li>\r\n");
	XYBody.Append("                <li>在线客服：<img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/kefu.gif\" /> <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/kefu.gif\" /></li>\r\n");
	XYBody.Append("                <li>客户热线：010-8681 8791</li>\r\n");
	XYBody.Append("                </ul>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </li>\r\n");
	XYBody.Append("        <li><a href=\"javascript:;\" onclick =\"Favorite();\">收藏此信息</a></li>\r\n");
	XYBody.Append("    </ul>\r\n");
	XYBody.Append("</div>  \r\n");


	XYBody.Append("			</div>\r\n");
	XYBody.Append("			<div class=\"MTitle_01\">\r\n");
	XYBody.Append("				<center><a target=\"_blank\" href=\"#\" class=\"red\"><strong>加入我们，享受更多服务</strong></a></center>\r\n");
	XYBody.Append("			</div>\r\n");
	XYBody.Append("			<div class=\"Mblk_01\">\r\n");
	XYBody.Append("				<div id=\"jointous\">\r\n");
	XYBody.Append("					<ul>\r\n");
	XYBody.Append("						<li><a href=\"\">· 结交贸易伙伴，拓展网络商圈</a></li>\r\n");
	XYBody.Append("						<li><a href=\"\">· 成为会员，免费发布供求信息</a></li>\r\n");
	XYBody.Append("						<li><a href=\"\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/btn_gq_reg.gif\" width=\"130\" height=\"29\" alt=\"\" /></a></li>\r\n");
	XYBody.Append("					</ul>\r\n");
	XYBody.Append("				</div>\r\n");
	XYBody.Append("			</div>\r\n");
	XYBody.Append("	</div>\r\n");
	XYBody.Append("	</div>\r\n");



	}	//end if


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
