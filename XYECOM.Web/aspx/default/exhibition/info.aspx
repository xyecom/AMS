<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.exhibition.info,XYECOM.Page" %>
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

	XYBody.Append("    <title> xyecom 3.0 首页 </title>\r\n");
	XYBody.Append("	<meta name=\"description\" content=\"xyecom\" />\r\n");
	XYBody.Append("	<meta name=\"keywords\" content=\"xyecom\" />\r\n");
	XYBody.Append("	<meta name=\"robots\" content=\"all\"  />\r\n");
	XYBody.Append("	<meta http-equiv=\"Content-Type\" content=\"text/html; charset=gb2312\"\" />\r\n");
	XYBody.Append("	<link rel=\"stylesheet\" href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("common/css/XYLib.css\" type=\"text/css\" media=\"screen\" />\r\n");
	XYBody.Append("	<link href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/css/global.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n");
	XYBody.Append("	<link href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/css/index.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n");
	XYBody.Append("	<link href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/css/channel.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n");
	XYBody.Append("    <script type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("common/js/base.js\" language=\"javascript\"></" + "script>	\r\n");
	XYBody.Append("	<script type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/js/login.js\" language=\"javascript\"></" + "script>\r\n");
	XYBody.Append("    <script type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/js/validate.js\" language=\"javascript\"></" + "script>\r\n");


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


	XYBody.Append("	<div id=\"news_bread\" style=\"width:100%;border:0;margin-top:6px;\">\r\n");
	XYBody.Append("		<em>您现在的位置：");	XYBody.Append(pageinfo.Navigation);	XYBody.Append("</em>\r\n");
	XYBody.Append("	</div>\r\n");
	XYBody.Append("	<div id=\"idx_cnt2\">\r\n");
	XYBody.Append("		<div id=\"left\">\r\n");
	XYBody.Append("			<div class=\"exhi_pages\">\r\n");
	XYBody.Append("				<h1>");	XYBody.Append(showinfo.Infotitle.ToString());	XYBody.Append("</h1>\r\n");
	XYBody.Append("				<div class=\"cate\"><h2>展会基本信息</h2></div>\r\n");
	XYBody.Append("				<div class=\"main\">\r\n");
	XYBody.Append("					<table width=\"540\" border=\"0\" cellpadding=\"0\" cellspacing=\"1\" bgcolor=\"#c6c6c6\" style=\"padding:4px;\">\r\n");
	XYBody.Append("					<tr>\r\n");
	XYBody.Append("					<td width=\"16%\" bgcolor=\"#f5f5f5\">展会时间：</td>\r\n");
	XYBody.Append("					<td width=\"35%\" bgcolor=\"#f5f5f5\"> ");	XYBody.Append(showinfo.BeginTime.ToString());	XYBody.Append("至");	XYBody.Append(showinfo.EndTime.ToString());	XYBody.Append(" </td>\r\n");
	XYBody.Append("					<td width=\"16%\" bgcolor=\"#f5f5f5\">展会地点：</td>\r\n");
	XYBody.Append("					<td width=\"33%\" bgcolor=\"#f5f5f5\">");	XYBody.Append(showinfo.District.ToString());	XYBody.Append(" </td>\r\n");
	XYBody.Append("					</tr>\r\n");
	XYBody.Append("					<tr>\r\n");
	XYBody.Append("					<td bgcolor=\"#f5f5f5\">主办单位：</td>\r\n");
	XYBody.Append("					<td bgcolor=\"#f5f5f5\">");	XYBody.Append(showinfo.Sponsor.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("					<td bgcolor=\"#f5f5f5\">承办单位：</td>\r\n");
	XYBody.Append("					<td bgcolor=\"#f5f5f5\">");	XYBody.Append(showinfo.Undertake.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("					</tr>\r\n");
	XYBody.Append("					<tr>\r\n");
	XYBody.Append("					<td bgcolor=\"#f5f5f5\">展会类型：</td>\r\n");
	XYBody.Append("					<td bgcolor=\"#f5f5f5\">");	XYBody.Append(showinfo.Type.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("					<td bgcolor=\"#f5f5f5\">展会网址：</td>\r\n");
	XYBody.Append("					<td bgcolor=\"#f5f5f5\">");	XYBody.Append(showinfo.URL.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("					</tr>\r\n");
	XYBody.Append("					</table><br /><FONT face=Verdana>");	XYBody.Append(showinfo.Infotitle.ToString());	XYBody.Append("<p>一、展会时间：");	XYBody.Append(showinfo.BeginTime.ToString());	XYBody.Append("至");	XYBody.Append(showinfo.EndTime.ToString());	XYBody.Append(" <p>二、展会地点：");	XYBody.Append(showinfo.District.ToString());	XYBody.Append("\r\n");
	XYBody.Append("				</div>\r\n");
	XYBody.Append("				<div class=\"cate\"><h2>展会简介</h2></div>\r\n");
	XYBody.Append("				<div class=\"main\">\r\n");
	XYBody.Append("                    <p>");	XYBody.Append(showinfo.Contents.ToString());	XYBody.Append("</p>\r\n");
	XYBody.Append("				</div>\r\n");
	XYBody.Append("				<div class=\"clr\"></div>\r\n");
	XYBody.Append("			</div>\r\n");
	XYBody.Append("		</div>\r\n");
	XYBody.Append("		<div id=\"right\">\r\n");
	XYBody.Append("            <!--\r\n");
	XYBody.Append("			<div class=\"MTitle_01\" style=\"margin-top:6px;\">\r\n");
	XYBody.Append("				<h2 id=\"h201\" class=\"\"><a target=\"_blank\" href=\"#\"><strong>展会搜索</strong></a></h2>\r\n");
	XYBody.Append("			</div>\r\n");
	XYBody.Append("			<div id=\"con01\" class=\"Mblk_01\">\r\n");
	XYBody.Append("				<div class=\"expo_sch\">\r\n");
	XYBody.Append("					<div class=\"i\">\r\n");
	XYBody.Append("						类　别：\r\n");
	XYBody.Append("						<select id=\"\">\r\n");
	XYBody.Append("							<option value=\"\" selected=\"selected\">国内会展</option>\r\n");
	XYBody.Append("							<option value=\"\">国歪会展</option>\r\n");
	XYBody.Append("						</select>\r\n");
	XYBody.Append("					</div>\r\n");
	XYBody.Append("					<div class=\"i\">\r\n");
	XYBody.Append("						时　间：\r\n");
	XYBody.Append("						<select id=\"\">\r\n");
	XYBody.Append("							<option value=\"\" selected=\"selected\">年份</option>\r\n");
	XYBody.Append("						</select>\r\n");
	XYBody.Append("						<select id=\"\">\r\n");
	XYBody.Append("							<option value=\"\" selected=\"selected\">月份</option>\r\n");
	XYBody.Append("						</select>\r\n");
	XYBody.Append("					</div>\r\n");
	XYBody.Append("					<div class=\"i\">地　点：<input type=\"text\" class=\"inp\" id=\"\" /></div>\r\n");
	XYBody.Append("					<div class=\"i\">关键字：<input type=\"text\" class=\"inp\" id=\"\" /></div>\r\n");
	XYBody.Append("					<div class=\"i\">　　　　<img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/btn_expo_sch.gif\" /></div>\r\n");
	XYBody.Append("				</div>\r\n");
	XYBody.Append("			</div>\r\n");
	XYBody.Append("            -->\r\n");
	XYBody.Append("			<div class=\"MTitle_01\">\r\n");
	XYBody.Append("				<h2 id=\"h201\" class=\"\"><a target=\"_blank\" href=\"#\"><strong>会展服务</strong></a></h2>\r\n");
	XYBody.Append("			</div>\r\n");
	XYBody.Append("			<div id=\"exhi_service\" class=\"Mblk_01\">\r\n");
	XYBody.Append("				<ul>\r\n");
	XYBody.Append("					<li><a href=\"\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/pic_exhi_s_1.gif\" width=\"66\" height=\"56\" alt=\"\" /></a><div>展台设计</div></li>\r\n");
	XYBody.Append("					<li><a href=\"\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/pic_exhi_s_2.gif\" width=\"66\" height=\"56\" alt=\"\" /></a><div>展台设计</div></li>\r\n");
	XYBody.Append("					<li><a href=\"\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/pic_exhi_s_3.gif\" width=\"66\" height=\"56\" alt=\"\" /></a><div>展台设计</div></li>\r\n");
	XYBody.Append("					<li><a href=\"\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/pic_exhi_s_4.gif\" width=\"66\" height=\"56\" alt=\"\" /></a><div>展台设计</div></li>\r\n");
	XYBody.Append("					<li><a href=\"\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/pic_exhi_s_5.gif\" width=\"66\" height=\"56\" alt=\"\" /></a><div>展台设计</div></li>\r\n");
	XYBody.Append("					<li><a href=\"\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/pic_exhi_s_6.gif\" width=\"66\" height=\"56\" alt=\"\" /></a><div>展台设计</div></li>\r\n");
	XYBody.Append("					<li><a href=\"\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/pic_exhi_s_7.gif\" width=\"66\" height=\"56\" alt=\"\" /></a><div>展台设计</div></li>\r\n");
	XYBody.Append("					<li><a href=\"\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/pic_exhi_s_8.gif\" width=\"66\" height=\"56\" alt=\"\" /></a><div>展台设计</div></li>\r\n");
	XYBody.Append("					<li><a href=\"\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/pic_exhi_s_9.gif\" width=\"66\" height=\"56\" alt=\"\" /></a><div>展台设计</div></li>\r\n");
	XYBody.Append("				</ul>\r\n");
	XYBody.Append("				<div class=\"clr\"></div>\r\n");
	XYBody.Append("			</div>\r\n");
	XYBody.Append("			<div class=\"news_exhi\">\r\n");
	XYBody.Append("				<ul>\r\n");
	XYBody.Append("					<li><a href=\"#\" ><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/temp_meeting_1.gif\" alt='展会合作'></a></li>\r\n");
	XYBody.Append("					<li><a href=\"#\" ><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/temp_meeting_2.gif\" alt='展会合作'></a></li>\r\n");
	XYBody.Append("					<li><a href=\"#\" ><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/temp_meeting_3.gif\" alt='展会合作'></a></li>\r\n");
	XYBody.Append("				</ul>\r\n");
	XYBody.Append("			</div>\r\n");
	XYBody.Append("			<div class=\"MTitle_01\">\r\n");
	XYBody.Append("				<h2 id=\"h201\" class=\"\"><a target=\"_blank\" href=\"#\" class=\"big\"><strong>展会动态</strong></a></h2>\r\n");
	XYBody.Append("			</div>\r\n");
	XYBody.Append("			<div id=\"con01\" class=\"Mblk_01\">\r\n");
	XYBody.Append("				<div class=\"com_pages\">\r\n");
	XYBody.Append("					<ul>\r\n");
	XYBody.Append("						<li><a target=\"_blank\" href=\"#\">多国暴发甲型H1N1流感</a></li>\r\n");
	XYBody.Append("						<li><a target=\"_blank\" href=\"#\">胡锦涛出席上合峰会</a></li>\r\n");
	XYBody.Append("						<li><a target=\"_blank\" href=\"#\">伊朗大选引发政局动荡</a></li>\r\n");
	XYBody.Append("						<li><a target=\"_blank\" href=\"#\">成都公交车发生燃烧</a></li>\r\n");
	XYBody.Append("						<li><a target=\"_blank\" href=\"#\">法航空客A330客机坠毁</a></li>\r\n");
	XYBody.Append("						<li><a target=\"_blank\" href=\"#\">成都公交车发生燃烧</a></li>\r\n");
	XYBody.Append("						<li><a target=\"_blank\" href=\"#\">法航空客A330客机坠毁</a></li>\r\n");
	XYBody.Append("					</ul>\r\n");
	XYBody.Append("				</div>\r\n");
	XYBody.Append("			</div>\r\n");
	XYBody.Append("			<div class=\"MTitle_01\">\r\n");
	XYBody.Append("				<h2 id=\"h201\" class=\"\"><a target=\"_blank\" href=\"#\" class=\"big\"><strong>展会技巧</strong></a></h2>\r\n");
	XYBody.Append("			</div>\r\n");
	XYBody.Append("			<div id=\"con01\" class=\"Mblk_01\">\r\n");
	XYBody.Append("				<div class=\"com_pages\">\r\n");
	XYBody.Append("					<ul>\r\n");
	XYBody.Append("						<li><a target=\"_blank\" href=\"#\">多国暴发甲型H1N1流感</a></li>\r\n");
	XYBody.Append("						<li><a target=\"_blank\" href=\"#\">胡锦涛出席上合峰会</a></li>\r\n");
	XYBody.Append("						<li><a target=\"_blank\" href=\"#\">伊朗大选引发政局动荡</a></li>\r\n");
	XYBody.Append("						<li><a target=\"_blank\" href=\"#\">成都公交车发生燃烧</a></li>\r\n");
	XYBody.Append("						<li><a target=\"_blank\" href=\"#\">法航空客A330客机坠毁</a></li>\r\n");
	XYBody.Append("						<li><a target=\"_blank\" href=\"#\">成都公交车发生燃烧</a></li>\r\n");
	XYBody.Append("						<li><a target=\"_blank\" href=\"#\">法航空客A330客机坠毁</a></li>\r\n");
	XYBody.Append("					</ul>\r\n");
	XYBody.Append("				</div>\r\n");
	XYBody.Append("			</div>\r\n");
	XYBody.Append("		</div>\r\n");
	XYBody.Append("		<div class=\"clr\" style=\"height:10px;\"></div>\r\n");
	XYBody.Append("	</div>\r\n");
	XYBody.Append("	<div class=\"hy_brand clr\">\r\n");
	XYBody.Append("		<div class=\"tit\">行业推荐品牌</div>\r\n");
	XYBody.Append("		<div class=\"brand_pic\">\r\n");
	XYBody.Append("			<ul>\r\n");
	XYBody.Append("				<li>\r\n");
	XYBody.Append("					<a  target='_blank' href='/brand/brandInfo_4.html'><img alt='永平烘干设备' src='http://images.glass.cn/brand/20096/633801523524876250.jpg' /></a><span><a target='_blank' href='/brand/brandInfo_4.html'>永平烘干设备</a></span>\r\n");
	XYBody.Append("				</li>\r\n");
	XYBody.Append("				<li>\r\n");
	XYBody.Append("					<a  target='_blank' href='/brand/brandInfo_28.html'><img alt='福耀玻璃' src='http://images.glass.cn/brand/20096/633801557578938750.jpg' /></a><span><a target='_blank' href='/brand/brandInfo_28.html'>福耀玻璃</a></span>\r\n");
	XYBody.Append("				</li>\r\n");
	XYBody.Append("				<li>\r\n");
	XYBody.Append("					<a  target='_blank' href='/brand/brandInfo_16.html'><img alt='晶创玉石玻璃' src='http://images.glass.cn/brand/20096/633801541650032500.jpg' /></a><span><a target='_blank' href='/brand/brandInfo_16.html'>晶创玉石玻璃</a></span>\r\n");
	XYBody.Append("				</li>\r\n");
	XYBody.Append("				<li>\r\n");
	XYBody.Append("					<a  target='_blank' href='/brand/brandInfo_15.html'><img alt='德清三星玻璃' src='http://images.glass.cn/brand/20096/633801586130970000.jpg' /></a><span><a target='_blank' href='/brand/brandInfo_15.html'>德清三星玻璃</a></span>\r\n");
	XYBody.Append("				</li>\r\n");
	XYBody.Append("				<li>\r\n");
	XYBody.Append("					<a  target='_blank' href='/brand/brandInfo_25.html'><img alt='索奥斯' src='http://images.glass.cn/brand/20096/633801555128001250.jpg' /></a><span><a target='_blank' href='/brand/brandInfo_25.html'>索奥斯</a></span>\r\n");
	XYBody.Append("				</li>\r\n");
	XYBody.Append("				<li>\r\n");
	XYBody.Append("					<a  target='_blank' href='/brand/brandInfo_26.html'><img alt='犀马化工' src='http://images.glass.cn/brand/20096/633801556362532500.jpg' /></a><span><a target='_blank' href='/brand/brandInfo_26.html'>犀马化工</a></span>\r\n");
	XYBody.Append("				</li>\r\n");
	XYBody.Append("				<li>\r\n");
	XYBody.Append("					<a  target='_blank' href='/brand/brandInfo_29.html'><img alt='Glaston' src='http://images.glass.cn/brand/20096/633801559926751250.jpg' /></a><span><a target='_blank' href='/brand/brandInfo_29.html'>Glaston</a></span>\r\n");
	XYBody.Append("				</li>\r\n");
	XYBody.Append("				<li>\r\n");
	XYBody.Append("					<a  target='_blank' href='/brand/brandInfo_34.html'><img alt='贵友玻璃软件' src='http://images.glass.cn/brand/20096/633801564902376250.jpg' /></a><span><a target='_blank' href='/brand/brandInfo_34.html'>贵友玻璃软件</a></span>\r\n");
	XYBody.Append("				</li>\r\n");
	XYBody.Append("				<li>\r\n");
	XYBody.Append("					<a  target='_blank' href='/brand/brandInfo_37.html'><img alt='浙江大明玻璃' src='http://images.glass.cn/brand/20096/633801568250501250.jpg' /></a><span><a target='_blank' href='/brand/brandInfo_37.html'>浙江大明玻璃</a></span>\r\n");
	XYBody.Append("				</li>\r\n");
	XYBody.Append("				<li>\r\n");
	XYBody.Append("					<a  target='_blank' href='/brand/brandInfo_51.html'><img alt='飞鸿安全玻璃' src='http://images.glass.cn/brand/20096/633801581973157500.jpg' /></a><span><a target='_blank' href='/brand/brandInfo_51.html'>飞鸿安全玻璃</a></span>\r\n");
	XYBody.Append("				</li>\r\n");
	XYBody.Append("				<li>\r\n");
	XYBody.Append("					<a  target='_blank' href='/brand/brandInfo_56.html'><img alt='北玻集团' src='http://images.glass.cn/brand/20096/633801589480501250.jpg' /></a><span><a target='_blank' href='/brand/brandInfo_56.html'>北玻集团</a></span>\r\n");
	XYBody.Append("				</li>\r\n");
	XYBody.Append("				<li>\r\n");
	XYBody.Append("					<a  target='_blank' href='/brand/brandInfo_60.html'><img alt='洛阳唐人玻璃' src='http://images.glass.cn/brand/20096/633801593127220000.jpg' /></a><span><a target='_blank' href='/brand/brandInfo_60.html'>洛阳唐人玻璃</a></span>\r\n");
	XYBody.Append("				</li>\r\n");
	XYBody.Append("				<li>\r\n");
	XYBody.Append("					<a  target='_blank' href='/brand/brandInfo_69.html'><img alt='耀优工程玻璃' src='http://images.glass.cn/brand/20096/633801621142845000.jpg' /></a><span><a target='_blank' href='/brand/brandInfo_69.html'>耀优工程玻璃</a></span>\r\n");
	XYBody.Append("				</li>\r\n");
	XYBody.Append("				<li>\r\n");
	XYBody.Append("					<a  target='_blank' href='/brand/brandInfo_79.html'><img alt='上海多林化工' src='http://images.glass.cn/brand/20096/633801634062220000.jpg' /></a><span><a target='_blank' href='/brand/brandInfo_79.html'>上海多林化工</a></span>\r\n");
	XYBody.Append("				</li>\r\n");
	XYBody.Append("				<li>\r\n");
	XYBody.Append("					<a  target='_blank' href='/brand/brandInfo_87.html'><img alt='耀华皮尔金顿' src='http://images.glass.cn/brand/20096/633801643804251250.jpg' /></a><span><a target='_blank' href='/brand/brandInfo_87.html'>耀华皮尔金顿</a></span>\r\n");
	XYBody.Append("				</li>\r\n");
	XYBody.Append("				<li>\r\n");
	XYBody.Append("					<a  target='_blank' href='/brand/brandInfo_88.html'><img alt='深圳采时颜料' src='http://images.glass.cn/brand/20096/633801644419720000.jpg' /></a><span><a target='_blank' href='/brand/brandInfo_88.html'>深圳采时颜料</a></span>\r\n");
	XYBody.Append("				</li>\r\n");
	XYBody.Append("				<li>\r\n");
	XYBody.Append("					<a  target='_blank' href='/brand/brandInfo_94.html'><img alt='晶博特玻璃' src='http://images.glass.cn/brand/20096/633801649406126250.jpg' /></a><span><a target='_blank' href='/brand/brandInfo_94.html'>晶博特玻璃</a></span>\r\n");
	XYBody.Append("				</li>\r\n");
	XYBody.Append("				<li>\r\n");
	XYBody.Append("					<a  target='_blank' href='/brand/brandInfo_112.html'><img alt='浙江东亚玻璃' src='http://images.glass.cn/brand/20096/633801664486282500.jpg' /></a><span><a target='_blank' href='/brand/brandInfo_112.html'>浙江东亚玻璃</a></span>\r\n");
	XYBody.Append("				</li>\r\n");
	XYBody.Append("				<li>\r\n");
	XYBody.Append("					<a  target='_blank' href='/brand/brandInfo_123.html'><img alt='中山中益油墨' src='http://images.glass.cn/brand/20096/633801674279251250.jpg' /></a><span><a target='_blank' href='/brand/brandInfo_123.html'>中山中益油墨</a></span>\r\n");
	XYBody.Append("				</li>\r\n");
	XYBody.Append("				<li>\r\n");
	XYBody.Append("					<a  target='_blank' href='/brand/brandInfo_129.html'>\r\n");
	XYBody.Append("						<img alt='瑞宝绿色纳米' src='http://images.glass.cn/brand/20096/633803380612376250.jpg' /></a><span><a target='_blank' href='/brand/brandInfo_129.html'>瑞宝绿色纳米</a></span>\r\n");
	XYBody.Append("				</li>\r\n");
	XYBody.Append("				<div class=\"clr\"></div>\r\n");
	XYBody.Append("			</ul>\r\n");
	XYBody.Append("			<div class=\"clr\"></div>\r\n");
	XYBody.Append("		</div>\r\n");
	XYBody.Append("	</div>\r\n");

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
