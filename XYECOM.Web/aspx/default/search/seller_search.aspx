<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.search.seller_search,XYECOM.Page" %>
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


	XYBody.Append("        <div id=\"search_nav\">\r\n");
	XYBody.Append("            <strong>您现在的位置：</strong> ");	XYBody.Append(pageinfo.Navigation);	XYBody.Append("\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <div id=\"search_main\">\r\n");
	XYBody.Append("            <div id=\"left\">\r\n");
	XYBody.Append("                <div class=\"sch_cates\" id=\"xy_PClassList\">\r\n");
	XYBody.Append("                    <h2>\r\n");
	XYBody.Append("                        <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/bg_invest_tit.gif\"\r\n");
	XYBody.Append("                            width=\"12\" height=\"12\" alt=\"\" align=\"absmiddle\" />\r\n");
	XYBody.Append("                        类目选择：</h2>\r\n");
	XYBody.Append("                    <div class=\"sch_cnts\" id=\"xy_ClassList\">\r\n");
	XYBody.Append("                    </div>\r\n");
	XYBody.Append("                </div>\r\n");

	if (pageinfo.ModuleFlag=="offer")
	{

	XYBody.Append("                <div class=\"sch_cates\">\r\n");
	XYBody.Append("                    <h2>\r\n");
	XYBody.Append("                        <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/bg_invest_tit.gif\"\r\n");
	XYBody.Append("                            width=\"12\" height=\"12\" alt=\"\" align=\"absmiddle\" />\r\n");
	XYBody.Append("                        属性选择：</h2>\r\n");
	XYBody.Append("                    <div class=\"sch_cnts\" id=\"xy_fleldList\">\r\n");
	XYBody.Append("                    </div>\r\n");
	XYBody.Append("                    <script type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("common/js/base.js\" language=\"javascript\"></" + "script>\r\n");
	XYBody.Append("                    <script type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/js/attribute.js\"\r\n");
	XYBody.Append("                        language=\"javascript\"></" + "script>\r\n");
	XYBody.Append("                    <input type=\"hidden\" name=\"hidProductTypeId\" id=\"hidProductTypeId\" value=\"");	XYBody.Append(ptid.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("                    <input type=\"hidden\" name=\"hidProductTypeIdAndAttribute\" id=\"hidProductTypeIdAndAttribute\"\r\n");
	XYBody.Append("                        value=\"");	XYBody.Append(p_id.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("                </div>\r\n");

	}	//end if

	XYBody.Append("                <div id=\"FilterDiv\">\r\n");
	XYBody.Append("                    <div id=\"FilterDivA\">\r\n");
	XYBody.Append("                        <span>每页显示数量:\r\n");
	XYBody.Append("                            <select name=\"pageNum\" id=\"pageNum\" onchange=\"funpagesize(this.options[this.selectedIndex].value);\">\r\n");
	XYBody.Append("                                <option value=\"10\">10</option>\r\n");
	XYBody.Append("                                <option value=\"20\" selected=\"selected\">20</option>\r\n");
	XYBody.Append("                                <option value=\"30\">30</option>\r\n");
	XYBody.Append("                                <option value=\"50\">50</option>\r\n");
	XYBody.Append("                            </select>\r\n");
	XYBody.Append("                        </span><strong class=\"Font14 redLink\">缩小范围:</strong>\r\n");
	XYBody.Append("                        <label id=\"classType\">\r\n");
	XYBody.Append("                        </label>\r\n");
	XYBody.Append("                        <input type=\"hidden\" id=\"areatypeid\" name=\"areatypeid\" />\r\n");
	XYBody.Append("                        <script type=\"text/javascript\">\r\n");
	XYBody.Append("                            var cla = new ClassType(\"cla\", 'area', 'classType', 'areatypeid', 1);\r\n");
	XYBody.Append("                            cla.Mode = \"select\";\r\n");
	XYBody.Append("                        </" + "script>\r\n");
	XYBody.Append("                        <select name=\"postTime\" id=\"selectlistdid\">\r\n");
	XYBody.Append("                            <option value=\"\">产品发布时间</option>\r\n");
	XYBody.Append("                            <option value=\"1\">显示今日最新</option>\r\n");
	XYBody.Append("                            <option value=\"3\">显示最近3天</option>\r\n");
	XYBody.Append("                            <option value=\"5\">显示最近5天</option>\r\n");
	XYBody.Append("                            <option value=\"7\">显示最近7天</option>\r\n");
	XYBody.Append("                            <option value=\"15\">显示最近15天</option>\r\n");
	XYBody.Append("                            <option value=\"30\">显示最近30天</option>\r\n");
	XYBody.Append("                            <option value=\"60\">显示最近60天</option>\r\n");
	XYBody.Append("                            <option value=\"180\">显示最近半年</option>\r\n");
	XYBody.Append("                            <option value=\"1000\">显示所有产品</option>\r\n");
	XYBody.Append("                        </select>\r\n");
	XYBody.Append("                        <input type=\"text\" size=\"8\" id=\"txtkeyword\" onkeydown=\"listSearchKeyDown();\" />\r\n");
	XYBody.Append("                        <input type=\"button\" name=\"Submit\" value=\"筛选\" onclick=\"listsearch()\" />\r\n");
	XYBody.Append("                    </div>\r\n");
	XYBody.Append("                    <div id=\"FilterDivB\">\r\n");
	XYBody.Append("                        <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	XYBody.Append("                            <tr>\r\n");
	XYBody.Append("                                <!--只有商业信息对比功能才能使用-->\r\n");

	if (pageinfo.ModuleFlag=="offer"||pageinfo.ModuleFlag=="venture"||pageinfo.ModuleFlag=="investment"||pageinfo.ModuleFlag=="service")
	{

	XYBody.Append("                                <td width=\"4%\" style=\"padding-left: 4px;\">\r\n");
	XYBody.Append("                                    <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/list_than.gif\" width=\"13\"\r\n");
	XYBody.Append("                                        height=\"13\" />\r\n");
	XYBody.Append("                                </td>\r\n");
	XYBody.Append("                                <td width=\"14%\">\r\n");
	XYBody.Append("                                    <input type=\"button\" value=\"对比产品\" onclick=\"compareinfo();\" />\r\n");
	XYBody.Append("                                </td>\r\n");

	}	//end if

	XYBody.Append("                                <td width=\"51%\">\r\n");
	XYBody.Append("                                    <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/list_Order_icon.gif\" /><a\r\n");
	XYBody.Append("                                        href=\"javascript:void(null);\" onclick=\"xy_setOrder('');\">默认排序</a>&nbsp;\r\n");
	XYBody.Append("                                    <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/list_Order_icon.gif\" /><a\r\n");
	XYBody.Append("                                        href=\"javascript:void(null);\" onclick=\"xy_setOrder('grade');\">按会员级别</a>&nbsp;\r\n");
	XYBody.Append("                                    <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/list_Order_icon.gif\" /><a\r\n");
	XYBody.Append("                                        href=\"javascript:void(null);\" onclick=\"xy_setOrder('time');\">按发布时间</a>&nbsp;\r\n");
	XYBody.Append("                                    <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/list_Order_icon.gif\" /><a\r\n");
	XYBody.Append("                                        href=\"javascript:void(null);\" onclick=\"xy_setOrder('active');\">按活跃数</a>\r\n");
	XYBody.Append("                                </td>\r\n");
	XYBody.Append("                                <td width=\"31%\" align=\"right\">\r\n");
	XYBody.Append("                                    <a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("keyword/\" class=\"orange\" target=\"_blank\">申请固定排名,让您的产品排在前三位</a>\r\n");
	XYBody.Append("                                </td>\r\n");
	XYBody.Append("                            </tr>\r\n");
	XYBody.Append("                        </table>\r\n");
	XYBody.Append("                    </div>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <!--很重要，不能删除-->\r\n");
	XYBody.Append("                <input type=\"hidden\" id=\"orderby\" value=\"\" />\r\n");
	XYBody.Append("                <input type=\"hidden\" id=\"hidmoduleflag\" value=\"");	XYBody.Append(pageinfo.ModuleFlag);	XYBody.Append("\" />\r\n");
	XYBody.Append("                <script language=\"javascript\">\r\n");
	XYBody.Append("                    window.onload = function () {\r\n");
	XYBody.Append("                        ");	XYBody.Append(pageinfo.OnLoadEvents);	XYBody.Append("\r\n");
	XYBody.Append("                    }\r\n");
	XYBody.Append("                </" + "script>\r\n");
	XYBody.Append("                <!--供求信息-->\r\n");
	XYBody.Append("                <div id=\"FixName\">\r\n");
	XYBody.Append("                </div>\r\n");

	if (pageinfo.ModuleFlag=="offer")
	{

	XYBody.Append("                <div id=\"FixText\">\r\n");
	XYBody.Append("                    " +  XYECOMCreateHTML("XY_SellOfferSaleNo1").ToString() + " " +  XYECOMCreateHTML("XY_SellOfferSaleNo2").ToString() + " " +  XYECOMCreateHTML("XY_SellOfferSaleNo3").ToString() + "\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <div id=\"ProDiv\">\r\n");
	XYBody.Append("                    " +  XYECOMCreateHTML("XY_OfferList").ToString() + "\r\n");
	XYBody.Append("                </div>\r\n");

	}	//end if

	XYBody.Append("                <!--加工信息-->\r\n");

	if (pageinfo.ModuleFlag=="venture")
	{

	XYBody.Append("                <div id=\"FixName\">\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <div id=\"FixText\">\r\n");
	XYBody.Append("                    " +  XYECOMCreateHTML("XY_MachiningNo1").ToString() + " " +  XYECOMCreateHTML("XY_MachiningNo2").ToString() + "\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <div id=\"ProDiv\">\r\n");
	XYBody.Append("                    " +  XYECOMCreateHTML("XY_MachiningList").ToString() + "\r\n");
	XYBody.Append("                </div>\r\n");

	}	//end if

	XYBody.Append("                <!--招商信息-->\r\n");

	if (pageinfo.ModuleFlag=="investment")
	{

	XYBody.Append("                <div id=\"FixName\">\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <div id=\"FixText\">\r\n");
	XYBody.Append("                    " +  XYECOMCreateHTML("XY_InvestmentNo1").ToString() + " " +  XYECOMCreateHTML("XY_InvestmentNo2").ToString() + "\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <div id=\"ProDiv\">\r\n");
	XYBody.Append("                    " +  XYECOMCreateHTML("XY_InvestmentList").ToString() + "\r\n");
	XYBody.Append("                </div>\r\n");

	}	//end if

	XYBody.Append("                <!--服务信息-->\r\n");

	if (pageinfo.ModuleFlag=="service")
	{

	XYBody.Append("                <div id=\"FixName\">\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <div id=\"FixText\">\r\n");
	XYBody.Append("                    " +  XYECOMCreateHTML("XY_ServiceNo1").ToString() + " " +  XYECOMCreateHTML("XY_ServiceNo2").ToString() + "\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <div id=\"ProDiv\">\r\n");
	XYBody.Append("                    " +  XYECOMCreateHTML("XY_ServiceList").ToString() + "\r\n");
	XYBody.Append("                </div>\r\n");

	}	//end if

	XYBody.Append("                <!--展会信息-->\r\n");

	if (pageinfo.ModuleFlag=="exhibition")
	{

	XYBody.Append("                <div id=\"ProDiv\">\r\n");
	XYBody.Append("                    " +  XYECOMCreateHTML("XY_ExhibitionList").ToString() + "\r\n");
	XYBody.Append("                </div>\r\n");

	}	//end if

	XYBody.Append("                <!--品牌信息-->\r\n");

	if (pageinfo.ModuleFlag=="brand")
	{

	XYBody.Append("                <div id=\"ProDiv\">\r\n");
	XYBody.Append("                    " +  XYECOMCreateHTML("XY_BrandList").ToString() + "\r\n");
	XYBody.Append("                </div>\r\n");

	}	//end if

	XYBody.Append("                <!--企业信息-->\r\n");

	if (pageinfo.ModuleFlag=="company")
	{

	XYBody.Append("                <div id=\"ProDiv\">\r\n");
	XYBody.Append("                    " +  XYECOMCreateHTML("XY_CompanyList").ToString() + "\r\n");
	XYBody.Append("                </div>\r\n");

	}	//end if

	XYBody.Append("                <!--普通列表结束-->\r\n");
	XYBody.Append("                <div id=\"ProFind\">\r\n");
	XYBody.Append("                    <strong class=\"orange\">还没有找到合适的产品?</strong> 赶快<a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("user/\" target=\"_blank\">发布求购信息</a>，让供应商主动来找您！</div>\r\n");
	XYBody.Append("                <div id=\"ProThan\">\r\n");
	XYBody.Append("                    <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	XYBody.Append("                        <tr>\r\n");
	XYBody.Append("                            <!--只有商业信息对比功能才能使用-->\r\n");

	if (pageinfo.ModuleFlag=="offer"||pageinfo.ModuleFlag=="venture"||pageinfo.ModuleFlag=="investment"||pageinfo.ModuleFlag=="service")
	{

	XYBody.Append("                            <td width=\"4%\" style=\"padding-left: 4px;\">\r\n");
	XYBody.Append("                                <span style=\"padding-left: 4px;\">\r\n");
	XYBody.Append("                                    <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/list_than.gif\" width=\"13\"\r\n");
	XYBody.Append("                                        height=\"13\" /></span>\r\n");
	XYBody.Append("                            </td>\r\n");
	XYBody.Append("                            <td width=\"57%\">\r\n");
	XYBody.Append("                                <input type=\"button\" value=\"对比产品\" onclick=\"compareinfo();\" />\r\n");
	XYBody.Append("                            </td>\r\n");

	}	//end if

	XYBody.Append("                        </tr>\r\n");
	XYBody.Append("                    </table>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                </form>\r\n");
	XYBody.Append("                <div id=\"splitPage\">\r\n");
	XYBody.Append("                    <div id=\"Pages\">\r\n");
	XYBody.Append("                        ");	XYBody.Append(pageinfo.PreviousPage);	XYBody.Append("");	XYBody.Append(pageinfo.NumPage);	XYBody.Append("");	XYBody.Append(pageinfo.NextPage);	XYBody.Append(" &nbsp;&nbsp;&nbsp;\r\n");
	XYBody.Append("                        直接转到&nbsp;\r\n");
	XYBody.Append("                        <input name=\"pageformat\" type=\"hidden\" value=\".html\">\r\n");
	XYBody.Append("                        <input name=\"page\" id=\"cpage\" size=\"3\" maxlength=\"3\" style=\"height: 13px;\" value=\"");	XYBody.Append(pageinfo.PageIndex);	XYBody.Append("\">&nbsp;页&nbsp;\r\n");
	XYBody.Append("                        <input type=\"submit\" value=\"确定>>\" style=\"height: 20px;\" onclick=\"xy_GoToPage(cpage.value);\">\r\n");
	XYBody.Append("                        <input type=\"hidden\" id=\"totalPage\" value=\"");	XYBody.Append(pageinfo.PageCount);	XYBody.Append("\" />\r\n");
	XYBody.Append("                    </div>\r\n");
	XYBody.Append("                    <span style=\"font-size: 14px;\">共 <strong class=\"orange\">");	XYBody.Append(pageinfo.TotalRecord);	XYBody.Append("</strong>\r\n");
	XYBody.Append("                        条记录&nbsp;&nbsp;&nbsp;当前为第 <strong class=\"orange\">");	XYBody.Append(pageinfo.PageIndex);	XYBody.Append("</strong> 页&nbsp;&nbsp;&nbsp;共\r\n");
	XYBody.Append("                        <strong class=\"orange\">");	XYBody.Append(pageinfo.PageCount);	XYBody.Append("</strong> 页&nbsp;&nbsp;&nbsp;</span>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <!-- 左侧结束 -->\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("            <div id=\"right\">\r\n");
	XYBody.Append("                <div class=\"MTitle_01\">\r\n");
	XYBody.Append("                    <center>\r\n");
	XYBody.Append("                        <a target=\"_blank\" href=\"#\" class=\"red big\"><strong>黄金展位</strong></a></center>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <div class=\"Mblk_01\">\r\n");
	XYBody.Append("                    <br />\r\n");
	XYBody.Append("                    <div class=\"news_exhi\">\r\n");
	XYBody.Append("                        <ul>\r\n");
	 data = GetClassAds();
	

	int ads__loop__id=0;
	foreach(DataRow ads in data.Rows)
	{
		ads__loop__id++;

	XYBody.Append("                            <li><a href=\"" + ads["link"].ToString().Trim() + "\" target=\"_blank\">\r\n");
	XYBody.Append("                                <img src=\"" + ads["imageurl"].ToString().Trim() + "\" alt='" + ads["desc"].ToString().Trim() + "' width=\"150\" height=\"100\" /></a></li>\r\n");

	}	//end loop

	XYBody.Append("                            <div class=\"clr\">\r\n");
	XYBody.Append("                            </div>\r\n");
	XYBody.Append("                        </ul>\r\n");
	XYBody.Append("                    </div>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <div class=\"MTitle_01\">\r\n");
	XYBody.Append("                    <h2 id=\"h201\" class=\"\">\r\n");
	XYBody.Append("                        <a target=\"_blank\" href=\"#\"><strong>怎样推广我的产品？</strong></a></h2>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <div id=\"con01\" class=\"Mblk_01\">\r\n");
	XYBody.Append("                    <div class=\"com_pages\">\r\n");
	XYBody.Append("                        <ul>\r\n");
	XYBody.Append("                            <li><a target=\"_blank\" href=\"#\">多国暴发甲型H1N1流感</a></li>\r\n");
	XYBody.Append("                            <li><a target=\"_blank\" href=\"#\">胡锦涛出席上合峰会</a></li>\r\n");
	XYBody.Append("                            <li><a target=\"_blank\" href=\"#\">伊朗大选引发政局动荡</a></li>\r\n");
	XYBody.Append("                            <li><a target=\"_blank\" href=\"#\">成都公交车发生燃烧</a></li>\r\n");
	XYBody.Append("                            <li><a target=\"_blank\" href=\"#\">法航空客A330客机坠毁</a></li>\r\n");
	XYBody.Append("                            <li><a target=\"_blank\" href=\"#\">成都公交车发生燃烧</a></li>\r\n");
	XYBody.Append("                            <li><a target=\"_blank\" href=\"#\">法航空客A330客机坠毁</a></li>\r\n");
	XYBody.Append("                        </ul>\r\n");
	XYBody.Append("                    </div>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <div class=\"MTitle_01\">\r\n");
	XYBody.Append("                    <h2 id=\"h2_1\" class=\"\">\r\n");
	XYBody.Append("                        <a target=\"_blank\" href=\"#\"><strong>展会技巧</strong></a></h2>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <div id=\"Div1\" class=\"Mblk_01\">\r\n");
	XYBody.Append("                    <div class=\"com_pages\">\r\n");
	XYBody.Append("                        <ul>\r\n");
	XYBody.Append("                            <li><a target=\"_blank\" href=\"#\">多国暴发甲型H1N1流感</a></li>\r\n");
	XYBody.Append("                            <li><a target=\"_blank\" href=\"#\">胡锦涛出席上合峰会</a></li>\r\n");
	XYBody.Append("                            <li><a target=\"_blank\" href=\"#\">伊朗大选引发政局动荡</a></li>\r\n");
	XYBody.Append("                            <li><a target=\"_blank\" href=\"#\">成都公交车发生燃烧</a></li>\r\n");
	XYBody.Append("                            <li><a target=\"_blank\" href=\"#\">法航空客A330客机坠毁</a></li>\r\n");
	XYBody.Append("                            <li><a target=\"_blank\" href=\"#\">成都公交车发生燃烧</a></li>\r\n");
	XYBody.Append("                            <li><a target=\"_blank\" href=\"#\">法航空客A330客机坠毁</a></li>\r\n");
	XYBody.Append("                        </ul>\r\n");
	XYBody.Append("                    </div>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("            <div class=\"clr\">\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </div>\r\n");

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


	XYBody.Append("    </div>\r\n");
	XYBody.Append("</body>\r\n");
	XYBody.Append("</html>\r\n");

	XYBody.Append(IsCopyright());
	Response.Write(XYBody.ToString());
}
</script>
