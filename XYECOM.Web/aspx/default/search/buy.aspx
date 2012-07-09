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
	XYBody.Append("                ��Ϊ��ҳ</a>&nbsp;&nbsp;\r\n");
	XYBody.Append("            <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/ico_cang.gif\" width=\"16\"\r\n");
	XYBody.Append("                height=\"16\" alt=\"\" align=\"absmiddle\" />\r\n");
	XYBody.Append("            <a style=\"cursor: hand\" onclick=\"window.external.addFavorite('");	XYBody.Append(config.WebURL);	XYBody.Append("','�ݺ��������')\">\r\n");
	XYBody.Append("                ��Ϊ�ղ�</a>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <div id=\"log_info\">\r\n");
	XYBody.Append("            <div id=\"login\">\r\n");
	XYBody.Append("                �û�����<input type=\"text\" class=\"com\" name=\"top_username\" id=\"top_username\" onkeydown=\"_xy_KeyNext('top_password');\" />\r\n");
	XYBody.Append("                ���룺<input type=\"password\" name=\"top_password\" class=\"com\" id=\"top_password\" onkeydown=\"_xy_KeyPress('_btnTopLogin');\" />\r\n");

	if (config.IsEnabledVCode("login"))
	{

	XYBody.Append("                ��֤�룺 ");	XYBody.Append(pageinfo.GetValidateCodeHTML("top_vcode","top_vimg"));	XYBody.Append("\r\n");

	}	//end if

	XYBody.Append("                <input id=\"_btnTopLogin\" type=\"button\" class=\"top_login\" onclick=\"return xy_TopLogin();\" />\r\n");
	XYBody.Append("                &nbsp;&nbsp;<a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("register.");	XYBody.Append(config.Suffix);	XYBody.Append("\">ע��</a> | <a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("getPassword.");	XYBody.Append(config.Suffix);	XYBody.Append("\">\r\n");
	XYBody.Append("                    ��������</a> | <a href=\"##\">[VIP��Ա]</a> | <a href=\"##\">��������</a>| <a style=\"color:Red\" href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("quickbuy.");	XYBody.Append(config.Suffix);	XYBody.Append("\">���ٷ�����</a>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <span id=\"logined\" style=\"display: none;\">��ӭ����<font id=\"uname\"></font> | <a id=\"ucenter\">\r\n");
	XYBody.Append("            �ҵ��û�����</a>| <a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("logout.");	XYBody.Append(config.suffix);	XYBody.Append("\">[�˳�]</a> <font id=\"logined_user\"\r\n");
	XYBody.Append("                style=\"display: none;\">��ҵ�û��������</font> <font id=\"logined_person\" style=\"display: none;\">\r\n");
	XYBody.Append("                    �����û��������</font> </span>\r\n");
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
	XYBody.Append("            ���е���</a>\r\n");
	XYBody.Append("            <div id=\"_xy_div_allarea\" style=\"display: none\" onmouseover=\"div_mouseover('_xy_div_allarea')\"\r\n");
	XYBody.Append("                onmouseout=\"div_mouseout('_xy_div_allarea');\">\r\n");
	XYBody.Append("                <a href=\"\">ɽ��</a> <a href=\"\">�Ĵ�</a> <a href=\"\">����</a> <a href=\"\">�㶫</a>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </span><strong>����Ƶ����</strong>" +  XYECOMCreateHTML("XY_ASN_shandong").ToString() + " | <a href=\"#\" class=\"waiting\" title=\"��δ��ͨ\">\r\n");
	XYBody.Append("            ����ũҵ��</a> | <a href=\"#\" class=\"waiting\" title=\"��δ��ͨ\">����ũҵ��</a> | <a href=\"#\" class=\"waiting\"\r\n");
	XYBody.Append("                title=\"��δ��ͨ\">����ũҵ��</a> | <a href=\"#\" class=\"waiting\" title=\"��δ��ͨ\">�㶫ũҵ��</a>\r\n");
	XYBody.Append("        | <a href=\"#\" class=\"waiting\" title=\"��δ��ͨ\">�Ĵ�ũҵ��</a>\r\n");
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
	XYBody.Append("                [ &nbsp;&nbsp;<a href=\"\" class=\"orange\">�й�ũҵ����վ</a> &nbsp; <a href=\"#\" onclick=\"div_opennew('_xy_div_alltrade',200,100);return false;\"\r\n");
	XYBody.Append("                    class=\"gray\">�л�����վ��</a> <a href=\"#\" onclick=\"div_opennew('_xy_div_alltrade',200,100);return false;\">\r\n");
	XYBody.Append("                        <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/ico_site_chg.gif\"\r\n");
	XYBody.Append("                            width=\"11\" height=\"11\" alt=\"\" align=\"absmiddle\" /></a>&nbsp;&nbsp; ]\r\n");
	XYBody.Append("                <div id=\"_xy_div_alltrade\" style=\"display: none\" onmouseover=\"div_mouseover('_xy_div_alltrade')\"\r\n");
	XYBody.Append("                    onmouseout=\"div_mouseout('_xy_div_alltrade');\">\r\n");
	XYBody.Append("                    <a href=\"\">��վ1</a> <a href=\"\">��վ2</a> <a href=\"\">��վ3</a> <a href=\"\">��վ4</a>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <div id=\"right\">\r\n");
	XYBody.Append("            <div id=\"site_nav\">\r\n");
	XYBody.Append("                <div class=\"c_name\">\r\n");
	XYBody.Append("                    ��ҵƵ��</div>\r\n");
	XYBody.Append("                <div class=\"text\">\r\n");
	XYBody.Append("                    <ul>\r\n");
	XYBody.Append("                        <li><a href=\"\">����</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">����</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">Ů��</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">����</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">ĸӤ</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">����</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">�Ժ�</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">����</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">����</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">����</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">��ѧ</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">����</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">����</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">ԭ��</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">�ƾ�</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">��ѧ</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">�ƾ�</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">��ѧ</a></li>\r\n");
	XYBody.Append("                    </ul>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <div class=\"c_name\">\r\n");
	XYBody.Append("                    ������Ѷ</div>\r\n");
	XYBody.Append("                <div class=\"text\">\r\n");
	XYBody.Append("                    <ul>\r\n");
	XYBody.Append("                        <li><a href=\"\">����</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">����</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">Ů��</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">����</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">ĸӤ</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">����</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">�Ժ�</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">����</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">����</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">����</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">��ѧ</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">����</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">����</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">ԭ��</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">�ƾ�</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">��ѧ</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">�ƾ�</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">��ѧ</a></li>\r\n");
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
	XYBody.Append("				<a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("keyword/\">�����̶�����</a>\r\n");
	XYBody.Append("			</div>\r\n");
	XYBody.Append("			<ul id=\"_xy_big_menu_box\">\r\n");
	XYBody.Append("				<li><a id=\"_xymenu_index\" href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("\" class=\"tabactive\"><span>�� ҳ</span></a></li>\r\n");
	XYBody.Append("				<li><a id=\"_xymenu_news\" href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("news/index.aspx\"><span>������Ѷ</span></a></li>\r\n");
	XYBody.Append("				<li><a id=\"_xymenu_offer\" href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("offer/index.aspx\"><span>��Ʒ����</span></a></li>\r\n");
	XYBody.Append("				<li><a id=\"_xymenu_investment\" href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("investment/index.aspx\"><span>���̼���</span></a></li>\r\n");
	XYBody.Append("				<li><a id=\"_xymenu_company\" href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("company/index.aspx\"><span>��ҵ��˾</span></a></li>\r\n");
	XYBody.Append("				<li><a id=\"_xymenu_job\" href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("job/index.aspx\"><span>�˲���Ƹ</span></a></li>\r\n");
	XYBody.Append("				<li><a id=\"_xymenu_brand\" href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("brand/index.aspx\"><span>��ҵƷ��</span></a></li>				\r\n");
	XYBody.Append("				<li><a id=\"_xymenu_exhibition\" href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("exhibition/index.aspx\"><span>չ����Ϣ</span></a></li>\r\n");
	XYBody.Append("				<li><a id=\"_xymenu_survey\" href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("survey/index.aspx\"><span>�����ʾ�</span></a></li>\r\n");
	XYBody.Append("				<li style=\"display:none;\"><a href=\"#\"><span>��������</span></a></li>\r\n");
	XYBody.Append("				<div class=\"clr\"></div>\r\n");
	XYBody.Append("			</ul>\r\n");
	XYBody.Append("			<script type=\"text/javascript\">xy_Sel_CurBigMenu();</" + "script>\r\n");
	XYBody.Append("		</div>\r\n");
	XYBody.Append("		<div class=\"sh_cnt\">\r\n");
	XYBody.Append("			<div id=\"main\">\r\n");
	XYBody.Append("				<input type=\"text\" id=\"txtsearchkey\" name=\"sch_text\" class=\"textsearch\" onkeydown=\"_xy_KeyPress('DoSearch');\"/>\r\n");
	XYBody.Append("				<div class=\"soSelect\" onclick=\"xy_ShowSearchMenu();\">\r\n");
	XYBody.Append("					<div class=\"option_current\" id=\"headSlected\" >��Ʒ</div>\r\n");
	XYBody.Append("					<div class=\"option_arrow\">\r\n");
	XYBody.Append("						<a href=\"#\"><span class=\"arrow\"></span></a>\r\n");
	XYBody.Append("					</div>\r\n");
	XYBody.Append("					<div class=\"clr\"></div>\r\n");
	XYBody.Append("					<ul onmouseover=\"drop_mouseover('head')\" onmouseout=\"drop_mouseout('head');\" style=\"display: none;\" class=\"options\" id=\"headSel\">\r\n");
	XYBody.Append("					    <li><a href=\"#\" onclick=\"xy_SelectSearchMenu('��Ʒ','offer','sell');\">��Ʒ</a></li>\r\n");
	XYBody.Append("					    <li><a href=\"#\" onclick=\"xy_SelectSearchMenu('��','buy','buy');\">��</a></li>\r\n");
	XYBody.Append("					    <li><a href=\"#\" onclick=\"xy_SelectSearchMenu('����','investment','sell');\">����</a></li>\r\n");
	XYBody.Append("					    <li><a href=\"#\" onclick=\"xy_SelectSearchMenu('����','investment','buy');\">����</a></li>\r\n");
	XYBody.Append("					    <li><a href=\"#\" onclick=\"xy_SelectSearchMenu('����','venture','sell');\">����</a></li>\r\n");
	XYBody.Append("					    <li><a href=\"#\" onclick=\"xy_SelectSearchMenu('����','service','sell');\">����</a></li>\r\n");
	XYBody.Append("					    <li><a href=\"#\" onclick=\"xy_SelectSearchMenu('��ҵ','company','sell');\">��ҵ</a></li>\r\n");
	XYBody.Append("					    <li><a href=\"#\" onclick=\"xy_SelectSearchMenu('��Ѷ','news','');\">��Ѷ</a></li>\r\n");
	XYBody.Append("					    <li><a href=\"#\" onclick=\"xy_SelectSearchMenu('�˲�','job','');\">�˲�</a></li>\r\n");
	XYBody.Append("					    <li><a href=\"#\" onclick=\"xy_SelectSearchMenu('Ʒ��','brand','');\">Ʒ��</a></li>\r\n");
	XYBody.Append("					    <li><a href=\"#\" onclick=\"xy_SelectSearchMenu('չ��','exhibition','');\">չ��</a></li>\r\n");
	XYBody.Append("					</ul>\r\n");
	XYBody.Append("				</div>\r\n");
	XYBody.Append("				<input type=\"hidden\" id=\"xy_FlagName\" value=\"offer\"/>\r\n");
	XYBody.Append("				<input type=\"hidden\" id=\"xy_InfoType\" value=\"sell\"/>\r\n");
	XYBody.Append("				<button value=\"����\" id=\"DoSearch\" name=\"DoSearch\" class=\"btsearch\" onclick=\"xy_search();\"/>����</button>\r\n");
	XYBody.Append("				<a href=\"/search/advanced_search.");	XYBody.Append(config.Suffix);	XYBody.Append("\" class=\"black\">[�߼�����]</a>\r\n");
	XYBody.Append("				<a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("contributor.");	XYBody.Append(config.Suffix);	XYBody.Append("\" class=\"black\">[Ͷ��]</a>\r\n");
	XYBody.Append("				<a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("post.");	XYBody.Append(config.Suffix);	XYBody.Append("\" class=\"black\">[������Ϣ]</a>\r\n");
	XYBody.Append("				<a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("baike/index.");	XYBody.Append(config.Suffix);	XYBody.Append("\" class=\"black\">[�ٿ�]</a>\r\n");
	XYBody.Append("			</div>\r\n");
	XYBody.Append("			<div id=\"sch_bnr\"><a href=\"\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/temp_pic_5.jpg\" width=\"170\" height=\"77\" alt=\"\" /></a></div>\r\n");
	XYBody.Append("			<div id=\"hot_schs\">\r\n");
	XYBody.Append("				<ul>\r\n");
	XYBody.Append("					<li><strong>���������ʣ�</strong></li>\r\n");
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
	XYBody.Append("							<a href=\"");	XYBody.Append(tempuser.shopindex.ToString());	XYBody.Append("\" class=\"blueLink Font14\"><strong>");	XYBody.Append(tempuser.unitname.ToString());	XYBody.Append("</strong></a>&nbsp;&nbsp;<a href=\"");	XYBody.Append(tempuser.shopindex.ToString());	XYBody.Append("\" target=\"_blank\"><img src=\"");	XYBody.Append(tempuser.gradeimgurl.ToString());	XYBody.Append("\" border=\"0\" style=\"position:relative;top:1px;\" /></a>&nbsp;&nbsp;<strong class=\"Font14\">��<span class=\"MemberYear\">");	XYBody.Append(tempuser.years.ToString());	XYBody.Append("</span>��</strong>\r\n");
	XYBody.Append("							<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"fontGray\">\r\n");
	XYBody.Append("								<tr>\r\n");
	XYBody.Append("									<td height=\"10\" colspan=\"2\"></td>\r\n");
	XYBody.Append("								</tr>\r\n");
	XYBody.Append("								<tr>\r\n");
	XYBody.Append("									<td height=\"33\" colspan=\"2\">\r\n");
	XYBody.Append("									    <a href=\"");	XYBody.Append(tempuser.shopindex.ToString());	XYBody.Append("\" target=\"_blank\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/enterWEB.gif\" alt=\"������ҵ��վ\" width=\"112\" height=\"21\" border=\"0\" /></a>&nbsp;&nbsp;&nbsp;\r\n");
	XYBody.Append("									    <a href=\"");	XYBody.Append(tempuser.contactus.ToString());	XYBody.Append("\" target=\"_blank\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/enterContact.gif\" alt=\"�鿴��ϵ��ʽ\" width=\"112\" height=\"21\" border=\"0\" /></a></td>\r\n");
	XYBody.Append("									</tr>\r\n");
	XYBody.Append("								<tr>\r\n");
	XYBody.Append("									<td width=\"50%\" height=\"22\">��ҵ���ͣ�");	XYBody.Append(tempuser.character.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("									<td width=\"50%\">Ա��������");	XYBody.Append(tempuser.employeetotal.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("								</tr>\r\n");
	XYBody.Append("								<tr>\r\n");
	XYBody.Append("									<td height=\"22\">��Ӫģʽ��");	XYBody.Append(tempuser.mode.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("									<td>ע���ʽ�");	XYBody.Append(tempuser.registeredcapital.ToString());	XYBody.Append("��</td>\r\n");
	XYBody.Append("								</tr>\r\n");
	XYBody.Append("							</table>\r\n");
	XYBody.Append("						</div>\r\n");
	XYBody.Append("						<div id=\"ProInfoB\">\r\n");
	XYBody.Append("							<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	XYBody.Append("									<tr>\r\n");
	XYBody.Append("										<td  height=\"24\" colspan=\"2\">\r\n");

	if (offerinfo.Price==0)
	{

	XYBody.Append("                                            �� �� �ۣ�<span>����</span>");	XYBody.Append(offerinfo.Unit.ToString());	XYBody.Append("\r\n");

	}
	else
	{

	XYBody.Append("                                            �� �� �ۣ�<span>");	XYBody.Append(offerinfo.Price.ToString());	XYBody.Append("</span> Ԫ/");	XYBody.Append(offerinfo.Unit.ToString());	XYBody.Append(" \r\n");

	}	//end if

	XYBody.Append("                                        &nbsp;&nbsp;&nbsp;&nbsp;\r\n");
	XYBody.Append("										</td>\r\n");
	XYBody.Append("									</tr>\r\n");
	XYBody.Append("									<tr>\r\n");
	XYBody.Append("									    <td width=\"50%\">��С�𶩣�");	XYBody.Append(offerinfo.LeastNum.ToString());	XYBody.Append(" ");	XYBody.Append(offerinfo.Unit.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("										<td width=\"50%\">����������");	XYBody.Append(offerinfo.CountNum.ToString());	XYBody.Append(" ");	XYBody.Append(offerinfo.Unit.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("									</tr>\r\n");
	XYBody.Append("									<tr>\r\n");
	XYBody.Append("										<td height=\"24\">��Ч������");	XYBody.Append(offerinfo.EndTime.ToShortDateString().ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("										<td>����ʱ�䣺");	XYBody.Append(offerinfo.PublishTime.ToShortDateString().ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("									</tr>\r\n");
	XYBody.Append("									<tr>\r\n");
	XYBody.Append("										<td height=\"24\" colspan=\"3\">�� ϵ �ˣ�");	XYBody.Append(tempuser.linkman.ToString());	XYBody.Append("&nbsp;&nbsp;<img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/icon_tianjiasy.gif\" width=\"13\" height=\"12\" style=\"position:relative;top:1px;\" /> <a href=\"javascript:void(null);\" onclick=\"Favorite();\" class=\"orange\">���Ϊ��ҵ���</a></td>\r\n");
	XYBody.Append("									</tr>\r\n");
	XYBody.Append("							</table>\r\n");
	XYBody.Append("						</div>\r\n");
	XYBody.Append("						<div class=\"blank5\"></div>\r\n");
	XYBody.Append("						<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	XYBody.Append("							<tr>\r\n");
	XYBody.Append("								<td height=\"60\"><a href=\"#message\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/inquire2.gif\" width=\"139\" height=\"36\" border=\"0\" /></a> </td>\r\n");
	XYBody.Append("								<td style=\"text-align:center;\"><span class=\"Font14\">����ϵ</span>��<strong class=\"orange\" class=\"TempTele\">86-010-62669815</strong></td>\r\n");
	XYBody.Append("								<td width=\"23%\"></td>\r\n");
	XYBody.Append("							</tr>\r\n");
	XYBody.Append("						</table>\r\n");
	XYBody.Append("					</div>\r\n");
	XYBody.Append("					<div class=\"clr\"></div>\r\n");
	XYBody.Append("					<div id=\"ProDesTitle\"><strong>��ϸ��Ϣ:</strong></div>\r\n");
	XYBody.Append("					<div class=\"ProDesText\">\r\n");
	XYBody.Append("					     <table width=\"95%\" border=\"0\" align=\"center\" cellpadding=\"1\" cellspacing=\"1\" class=\"typelist\">");	XYBody.Append(fieldbody.ToString());	XYBody.Append("</table>\r\n");
	XYBody.Append("					     ");	XYBody.Append(offerinfo.InfoContent.ToString());	XYBody.Append("\r\n");
	XYBody.Append("					</div>\r\n");
	XYBody.Append("					<div id=\"ProDesTitle\">\r\n");
	XYBody.Append("					    <strong>��ϵ��ʽ:</strong>\r\n");
	XYBody.Append("					</div>\r\n");
	XYBody.Append("					<div class=\"ProDesText\" id=\"linkmessage\"></div>\r\n");
	XYBody.Append("				</div>\r\n");
	XYBody.Append("			</div>\r\n");
	XYBody.Append("			<div id=\"ProFind\">\r\n");
	XYBody.Append("			    <span>\r\n");
	XYBody.Append("			    <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/icon1.gif\" width=\"20\" height=\"14\" /><a href=\"javascript:void(null);\" onclick=\"Favorite();\">�ղش���Ϣ</a>&nbsp;&nbsp;&nbsp;\r\n");
	XYBody.Append("			    <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/icon2.gif\" width=\"21\" height=\"11\" /><a href=\"#\">�Ƽ�������</a>&nbsp;&nbsp;&nbsp;\r\n");
	XYBody.Append("			    <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/icon3.gif\" height=\"16\" /><a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("feedback.");	XYBody.Append(config.suffix);	XYBody.Append("\">�ٱ�����Ϣ</a>\r\n");
	XYBody.Append("			    </span>\r\n");
	XYBody.Append("			    <strong class=\"orange\">��û���ҵ����ʵĲ�Ʒ?</strong>  �Ͽ�<a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("user/\" target=\"_blank\">��������Ϣ</a>���ù�Ӧ��������������\r\n");
	XYBody.Append("    	    </div>\r\n");
	XYBody.Append("			<input type =\"hidden\" id=\"_param_message_module\" value=\"");	XYBody.Append(module.EName.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("            <input type =\"hidden\" id=\"_param_message_title\" value=\"");	XYBody.Append(titleinfo.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("            <input type =\"hidden\" id=\"_param_message_parent_module\" value =\"");	XYBody.Append(pageinfo.ModuleFlag);	XYBody.Append("\" />\r\n");
	XYBody.Append("            <input type =\"hidden\" id=\"_param_message_infoid\" value =\"");	XYBody.Append(offerinfo.InfoID.ToString());	XYBody.Append("\"/>\r\n");
	XYBody.Append("            <input type =\"hidden\" id=\"_param_message_userid\" value =\"");	XYBody.Append(offerinfo.UserID.ToString());	XYBody.Append("\" />\r\n");

	XYBody.Append("<!--��վ����-->\r\n");
	XYBody.Append("<div  class=\"infoAbout  commentTitle\">\r\n");
	XYBody.Append("<a name=\"message\"></a>\r\n");
	XYBody.Append("<form action=\"\" method=\"post\">\r\n");
	XYBody.Append("    <ul class=\"comment\">\r\n");
	XYBody.Append("        <li id=\"msg_tab1\"><a href=\"javascript:;\" onclick=\"xy_selectBox(2,1,'msg','now')\">�ο���ѯ</a></li>\r\n");
	XYBody.Append("        <li class=\"now\" id=\"msg_tab2\"><a href=\"javascript:;\" onclick=\"xy_selectBox(2,2,'msg','now')\">��Ա��ѯ</a></li>\r\n");
	XYBody.Append("    </ul>\r\n");
	XYBody.Append("    <div id=\"msg_box1\" style=\"display: none;\">\r\n");
	XYBody.Append("        <div class=\"commentList\">\r\n");
	XYBody.Append("            <p>\r\n");
	XYBody.Append("                <input type=\"radio\" checked=\"checked\"  value =\"1\" id=\"companyid\"  name =\"sinfo\"/>�� ˾ \r\n");
	XYBody.Append("                <input name=\"sinfo\" type=\"radio\" value=\"0\" id=\"useridad\" />����\r\n");
	XYBody.Append("                <span>������Ѿ��ǻ�Ա����<a href=\"javascript:geturl();\" class=\"orangelink\">��˵�¼</a>������������Ǳ�վ��Ա����<a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("register.");	XYBody.Append(config.Suffix);	XYBody.Append("\" class=\"orangelink\">���ע��</a></span>\r\n");
	XYBody.Append("            </p>\r\n");
	XYBody.Append("            <h3>��ϵ��ʽ</h3>\r\n");
	XYBody.Append("            <ul  class=\"line\">   \r\n");
	XYBody.Append("                <li><label>��ϵ�ˣ�<em>*</em></label><input type=\"text\" size=\"25\" id=\"linkman\" onblur=\"checkinfo('1');\" onfocus=\"fs('1');\"  maxlength =\"50\"/><input id=\"nsex\" name=\"\" type=\"radio\" value=\"1\" checked =\"checked\" />���� <input id=\"girl\" name=\"\" type=\"radio\" value=\"0\" />Ůʿ<span id=\"txt1\"></span></li>       \r\n");
	XYBody.Append("                <li><label>�������䣺<em>*</em></label><input type=\"text\" size=\"25\"  id=\"email\" onblur=\"checkinfo('2');\" onfocus=\"fs('2');\" maxlength =\"50\" /><span  id=\"txt2\"></span></li>\r\n");
	XYBody.Append("                <li><label>�绰���룺</label><input name=\"\" type=\"text\" size=\"25\" id=\"mobile\" onblur=\"checkinfo('11');\" onfocus=\"fs('11');\" maxlength =\"13\"/><span  id=\"txt11\"></span></li>\r\n");
	XYBody.Append("            </ul>\r\n");
	XYBody.Append("            <h3>��������</h3>\r\n");
	XYBody.Append("            <ul>\r\n");
	XYBody.Append("                <li><label>���Ա��⣺<em>*</em></label><input type=\"text\" size=\"60\" id=\"title\" name=\"title\" onblur=\"checkinfo('14');\" onfocus=\"fs('14');\" maxlength =\"100\" /><span  id =\"txt14\"></span><br /><i>�뾡�����ü������ԣ��������20�����֣��������300�����֡�</i></li>\r\n");
	XYBody.Append("                <li><div class=\"left\"><label>�������ݣ�<em>*</em></label> <textarea name=\"neirong\" cols=\"60\" rows=\"5\" id =\"neirong\" onblur=\"checkinfo('15');\" onfocus=\"fs('15');\"></textarea><span  id=\"txt15\"></span></div>\r\n");
	XYBody.Append("                <div class=\"ks\" id=\"ks1\"></div>\r\n");
	XYBody.Append("                </li>\r\n");

	if (config.IsEnabledVCode("message"))
	{

	XYBody.Append("                <li><label >��֤�룺<em>*</em></label>");	XYBody.Append(pageinfo.GetValidateCodeHTML("guestVCode","guestVCodeImg"));	XYBody.Append("</li>   \r\n");

	}	//end if

	XYBody.Append("                <li>\r\n");
	XYBody.Append("                    <input name=\"\" type=\"button\" class=\"button\" value=\"ȷ ��\"  onclick =\"checkmessage();\"/> \r\n");
	XYBody.Append("                    <input type=\"button\" name=\"button\"  class=\"button\" value=\"���\" onclick =\"ykrewrite();\"  />\r\n");
	XYBody.Append("                </li>\r\n");
	XYBody.Append("            </ul>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div> \r\n");
	XYBody.Append("    <div id=\"msg_box2\" style=\"display: block;\">\r\n");
	XYBody.Append("        <div class=\"commentList\">\r\n");
	XYBody.Append("            <ul>\r\n");
	XYBody.Append("                <li><label>���Ա��⣺<em>*</em></label><input type=\"text\" size=\"60\" id=\"txtTitle\" name=\"txtTitle\"  maxlength =\"200\" /></li>\r\n");
	XYBody.Append("                <li><div class=\"left\"><label>�������ݣ�<em>*</em></label> <textarea name=\"txtContent\" cols=\"60\" rows=\"5\" id=\"txtContent\"></textarea></div>\r\n");
	XYBody.Append("                <div class=\"ks\" id=\"ks2\"></div>\r\n");
	XYBody.Append("                </li>\r\n");

	if (config.IsEnabledVCode("message"))
	{

	XYBody.Append("                <li><label>��֤�룺<em>*</em></label>");	XYBody.Append(pageinfo.GetValidateCodeHTML("userVCode","userVCodeImg"));	XYBody.Append("</li>\r\n");

	}	//end if

	XYBody.Append("                <li>\r\n");
	XYBody.Append("                    <input name=\"\" type=\"button\" class=\"button\" value=\"ȷ ��\" onclick =\"checkusermessage();\"/> \r\n");
	XYBody.Append("                    <input type=\"button\" name=\"Submit\"  class=\"button\" value=\"�� ��\"   onclick=\"hrrewrite();\" />\r\n");
	XYBody.Append("                </li>\r\n");
	XYBody.Append("            </ul>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("</form> \r\n");
	XYBody.Append("</div> \r\n");
	XYBody.Append(" <script type=\"text/javascript\" language=\"javascript\">UserMessageInit();</" + "script>\r\n");


	XYBody.Append("		 </form>\r\n");
	XYBody.Append("			<div id=\"SayInfo\">\r\n");
	XYBody.Append("				<strong>��������</strong>��������Ϣ�������ҵ�����ṩ������ҵ������Ϣ���ݵ���ʵ�ԡ�׼ȷ�ԺͺϷ��ԡ�\r\n");
	XYBody.Append("				<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");	XYBody.Append(config.webname);	XYBody.Append("�Դ˲��е��κα�֤���Ρ�\r\n");
	XYBody.Append("			</div>\r\n");
	XYBody.Append("		</div>\r\n");
	XYBody.Append("	    <div id=\"layoutRight\">\r\n");
	XYBody.Append("			<div id=\"content\">\r\n");
	XYBody.Append("                <input type =\"hidden\" id=\"_param_userinfo_parent_module\" value =\"");	XYBody.Append(pageinfo.ModuleFlag);	XYBody.Append("\" />\r\n");
	XYBody.Append("                <input type =\"hidden\" id=\"_param_userinfo_infoid\" value =\"");	XYBody.Append(offerinfo.InfoID.ToString());	XYBody.Append("\"/>\r\n");
	XYBody.Append("                <input type =\"hidden\" id=\"_param_userinfo_userid\" value =\"");	XYBody.Append(offerinfo.UserID.ToString());	XYBody.Append("\" />\r\n");

	XYBody.Append("<!--������ʾ��Ϣ--> \r\n");
	XYBody.Append("<div class=\"w290\" id=\"loginuser\" style=\"display:none;\">  \r\n");
	XYBody.Append("    <ul>\r\n");
	XYBody.Append("        <li id=\"loginuseruginfo\"></li>\r\n");
	XYBody.Append("        <li class=\"line\"><a id=\"loginuserurl\" href=\"\" class=\"link14\"></a></li>\r\n");
	XYBody.Append("        <li>��˾��������� <span id=\"ConsummatePercent\"></span></li>\r\n");
	XYBody.Append("        <li><div class=\"cr\"><img id=\"PercentForImg\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/rate.gif\" alt=\" \"  height=\"15px\" /></div></li>\r\n");
	XYBody.Append("        <li><a href=\"#\" id=\"NewOfferPage\">���¹�Ӧ</a> | <a href=\"#\" id=\"GoodFaithFile\">���ŵ���</a> | <a href=\"#\" id=\"UserIntro\">��˾����</a></li>\r\n");
	XYBody.Append("        <li>��ϵ�ˣ�<a href=\"#\" id=\"Contact\"><span id=\"LinkManName\">����</span></a> ���� <span id=\"IMOnline\"></span></li>\r\n");
	XYBody.Append("        <li><hr /></li>\r\n");
	XYBody.Append("        <li>����ʱ�䣺�� <span id=\"loginuseryearnum\"></span> ��</li>\r\n");
	XYBody.Append("        <li> <a href=\"javascript:;\" onclick =\"Favorite();\">�ղش���Ϣ</a> <a href=\"#\" id=\"memessage\">��������</a> <a href=\"#\" id=\"linkme\">��ϵ��ʽ</a></li>  \r\n");
	XYBody.Append("    </ul>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<!--Ҫ���½��鿴-->\r\n");
	XYBody.Append("<div class=\"w290\" id=\"UserNoLogin\" style=\"display:none;\">\r\n");
	XYBody.Append("    <ul class=\"login\">\r\n");
	XYBody.Append("        <li><h4>�Ѿ��ǻ�Ա���½</h4></li>\r\n");
	XYBody.Append("        <li>�û�����<input type=\"text\" name=\"\" tabindex=\"1\"  id=\"username\" name=\"username\" onkeydown =\"KeyDown();\" maxlength=\"50\" /></li>\r\n");
	XYBody.Append("        <li>��&nbsp;&nbsp;&nbsp;�룺<input type =\"password\" maxlength=\"20\" tabindex=\"2\" id=\"password\"  name=\"password\" onkeydown =\"KeyDown();\" /></li>\r\n");

	if (config.IsEnabledVCode("login"))
	{

	XYBody.Append("        <li>��֤�룺");	XYBody.Append(pageinfo.GetValidateCodeHTML());	XYBody.Append("</li>\r\n");

	}	//end if

	XYBody.Append("        <li><input type=\"button\" class=\"button\" value=\"��¼\" onclick=\"return InfoLogin();\"/><a href=\"/GetPassword.");	XYBody.Append(config.Suffix);	XYBody.Append("\">�������룿</a></li>\r\n");
	XYBody.Append("        <li><hr /></li>\r\n");
	XYBody.Append("        <ll>�㻹���ǻ�Ա����<a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("register.");	XYBody.Append(config.Suffix);	XYBody.Append("\">�������ע��</a></li>\r\n");
	XYBody.Append("        <li>\r\n");
	XYBody.Append("            <div class=\"contactus\">\r\n");
	XYBody.Append("                <ul>\r\n");
	XYBody.Append("                <li><h3>�����κ���������������ϵ</h3></li>\r\n");
	XYBody.Append("                <li>���߿ͷ���<img src=\"/templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/kefu.gif\" /> <img src=\"/templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/kefu.gif\" /></li>\r\n");
	XYBody.Append("                <li>�ͻ����ߣ�010-8681 8791</li>\r\n");
	XYBody.Append("                </ul>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </li>      \r\n");
	XYBody.Append("    </ul>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<!--Ҫ��������鿴-->\r\n");
	XYBody.Append("<div class=\"w290\" id=\"loginnouser\" style=\"display:none;\">\r\n");
	XYBody.Append("    <h3><span id=\"loginnouseruginfo\"></span></h3>\r\n");
	XYBody.Append("    <ul class=\"upgrade\">\r\n");
	XYBody.Append("        <li><span>��Ŀǰ���ڵĻ�Ա�飬�޷��鿴��Ϣ��</span></li>\r\n");
	XYBody.Append("        <li><a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("user/postadministratormessage.");	XYBody.Append(config.Suffix);	XYBody.Append("\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/update.gif\" border=\"0\"/></a></li>\r\n");
	XYBody.Append("        <li><a href=\"\">��˲鿴��Ա�ȼ���Ȩ��>></a></li>\r\n");
	XYBody.Append("        <li>\r\n");
	XYBody.Append("            <div class=\"contactus\">\r\n");
	XYBody.Append("                <ul>\r\n");
	XYBody.Append("                <li><h3>�����κ���������������ϵ</h3></li>\r\n");
	XYBody.Append("                <li>���߿ͷ���<img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/kefu.gif\" /> <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/kefu.gif\" /></li>\r\n");
	XYBody.Append("                <li>�ͻ����ߣ�010-8681 8791</li>\r\n");
	XYBody.Append("                </ul>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </li>\r\n");
	XYBody.Append("        <li><a href=\"javascript:;\" onclick =\"Favorite();\">�ղش���Ϣ</a></li>\r\n");
	XYBody.Append("    </ul>\r\n");
	XYBody.Append("</div>  \r\n");


	XYBody.Append("			</div>\r\n");
	XYBody.Append("			<div class=\"MTitle_01\">\r\n");
	XYBody.Append("				<center><a target=\"_blank\" href=\"#\" class=\"red\"><strong>�������ǣ����ܸ������</strong></a></center>\r\n");
	XYBody.Append("			</div>\r\n");
	XYBody.Append("			<div class=\"Mblk_01\">\r\n");
	XYBody.Append("				<div id=\"jointous\">\r\n");
	XYBody.Append("					<ul>\r\n");
	XYBody.Append("						<li><a href=\"\">�� �ύó�׻�飬��չ������Ȧ</a></li>\r\n");
	XYBody.Append("						<li><a href=\"\">�� ��Ϊ��Ա����ѷ���������Ϣ</a></li>\r\n");
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
	XYBody.Append("							<a href=\"");	XYBody.Append(tempuser.shopindex.ToString());	XYBody.Append("\" class=\"blueLink Font14\"><strong>");	XYBody.Append(tempuser.unitname.ToString());	XYBody.Append("</strong></a>&nbsp;&nbsp;<a href=\"");	XYBody.Append(tempuser.shopindex.ToString());	XYBody.Append("\" target=\"_blank\"><img src=\"");	XYBody.Append(tempuser.gradeimgurl.ToString());	XYBody.Append("\" border=\"0\" style=\"position:relative;top:1px;\" /></a>&nbsp;&nbsp;<strong class=\"Font14\">��<span class=\"MemberYear\">");	XYBody.Append(tempuser.years.ToString());	XYBody.Append("</span>��</strong>\r\n");
	XYBody.Append("							<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"fontGray\">\r\n");
	XYBody.Append("								<tr>\r\n");
	XYBody.Append("									<td height=\"10\" colspan=\"2\"></td>\r\n");
	XYBody.Append("								</tr>\r\n");
	XYBody.Append("								<tr>\r\n");
	XYBody.Append("									<td height=\"33\" colspan=\"2\">\r\n");
	XYBody.Append("									    <a href=\"");	XYBody.Append(tempuser.shopindex.ToString());	XYBody.Append("\" target=\"_blank\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/enterWEB.gif\" alt=\"������ҵ��վ\" width=\"112\" height=\"21\" border=\"0\" /></a>&nbsp;&nbsp;&nbsp;\r\n");
	XYBody.Append("									    <a href=\"");	XYBody.Append(tempuser.contactus.ToString());	XYBody.Append("\" target=\"_blank\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/enterContact.gif\" alt=\"�鿴��ϵ��ʽ\" width=\"112\" height=\"21\" border=\"0\" /></a></td>\r\n");
	XYBody.Append("									</tr>\r\n");
	XYBody.Append("								<tr>\r\n");
	XYBody.Append("									<td width=\"50%\" height=\"22\">��ҵ���ͣ�");	XYBody.Append(tempuser.character.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("									<td width=\"50%\">Ա��������");	XYBody.Append(tempuser.employeetotal.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("								</tr>\r\n");
	XYBody.Append("								<tr>\r\n");
	XYBody.Append("									<td height=\"22\">��Ӫģʽ��");	XYBody.Append(tempuser.mode.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("									<td>ע���ʽ�");	XYBody.Append(tempuser.registeredcapital.ToString());	XYBody.Append("��</td>\r\n");
	XYBody.Append("								</tr>\r\n");
	XYBody.Append("							</table>\r\n");
	XYBody.Append("						</div>\r\n");
	XYBody.Append("						<div id=\"ProInfoB\">\r\n");
	XYBody.Append("							<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	XYBody.Append("									<tr>\r\n");
	XYBody.Append("										<td  height=\"24\" colspan=\"2\">\r\n");

	if (machininginfo.Price==0)
	{

	XYBody.Append("                                            �� ǰ �ۣ�<span>����</span>");	XYBody.Append(machininginfo.Unit.ToString());	XYBody.Append("\r\n");

	}
	else
	{

	XYBody.Append("                                            �� ǰ �ۣ�<span>");	XYBody.Append(machininginfo.Price.ToString());	XYBody.Append("</span> Ԫ/");	XYBody.Append(machininginfo.Unit.ToString());	XYBody.Append(" \r\n");

	}	//end if

	XYBody.Append("                                        &nbsp;&nbsp;&nbsp;&nbsp;\r\n");
	XYBody.Append("										</td>\r\n");
	XYBody.Append("									</tr>\r\n");
	XYBody.Append("									<tr>\r\n");
	XYBody.Append("									    <td width=\"50%\">��С�𶩣�");	XYBody.Append(machininginfo.LeastNum.ToString());	XYBody.Append(" ");	XYBody.Append(machininginfo.Unit.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("										<td width=\"50%\">����������");	XYBody.Append(machininginfo.CountNum.ToString());	XYBody.Append(" ");	XYBody.Append(machininginfo.Unit.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("									</tr>\r\n");
	XYBody.Append("									<tr>\r\n");
	XYBody.Append("										<td height=\"24\">��Ч������");	XYBody.Append(machininginfo.EndTime.ToShortDateString().ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("										<td>����ʱ�䣺");	XYBody.Append(machininginfo.PublishTime.ToShortDateString().ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("									</tr>\r\n");
	XYBody.Append("									<tr>\r\n");
	XYBody.Append("										<td height=\"24\" colspan=\"3\">�� ϵ �ˣ�");	XYBody.Append(tempuser.linkman.ToString());	XYBody.Append("&nbsp;&nbsp;<img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/icon_tianjiasy.gif\" width=\"13\" height=\"12\" style=\"position:relative;top:1px;\" /> <a href=\"javascript:void(null);\" onclick=\"Favorite();\" class=\"orange\">���Ϊ��ҵ���</a></td>\r\n");
	XYBody.Append("									</tr>\r\n");
	XYBody.Append("							</table>\r\n");
	XYBody.Append("						</div>\r\n");
	XYBody.Append("						<div class=\"blank5\"></div>\r\n");
	XYBody.Append("						<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	XYBody.Append("							<tr>\r\n");
	XYBody.Append("								<td height=\"60\"><a href=\"#message\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/inquire2.gif\" width=\"139\" height=\"36\" border=\"0\" /></a> </td>\r\n");
	XYBody.Append("								<td style=\"text-align:center;\"><span class=\"Font14\">����ϵ</span>��<strong class=\"orange\" class=\"TempTele\">86-010-62669815</strong></td>\r\n");
	XYBody.Append("								<td width=\"23%\"></td>\r\n");
	XYBody.Append("							</tr>\r\n");
	XYBody.Append("						</table>\r\n");
	XYBody.Append("					</div>\r\n");
	XYBody.Append("					<div class=\"clr\"></div>\r\n");
	XYBody.Append("					<div id=\"ProDesTitle\"><strong>��ϸ��Ϣ:</strong></div>\r\n");
	XYBody.Append("					<div class=\"ProDesText\">\r\n");
	XYBody.Append("					     <table width=\"95%\" border=\"0\" align=\"center\" cellpadding=\"1\" cellspacing=\"1\" class=\"typelist\">");	XYBody.Append(fieldbody.ToString());	XYBody.Append("</table>\r\n");
	XYBody.Append("					     ");	XYBody.Append(machininginfo.InfoContent.ToString());	XYBody.Append("\r\n");
	XYBody.Append("					</div>\r\n");
	XYBody.Append("					<div id=\"ProDesTitle\">\r\n");
	XYBody.Append("					    <strong>��ϵ��ʽ:</strong>\r\n");
	XYBody.Append("					</div>\r\n");
	XYBody.Append("					<div class=\"ProDesText\" id=\"linkmessage\"></div>\r\n");
	XYBody.Append("				</div>\r\n");
	XYBody.Append("			</div>\r\n");
	XYBody.Append("			<div id=\"ProFind\">\r\n");
	XYBody.Append("			    <span>\r\n");
	XYBody.Append("			    <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/icon1.gif\" width=\"20\" height=\"14\" /><a href=\"javascript:void(null);\" onclick=\"Favorite();\">�ղش���Ϣ</a>&nbsp;&nbsp;&nbsp;\r\n");
	XYBody.Append("			    <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/icon2.gif\" width=\"21\" height=\"11\" /><a href=\"#\">�Ƽ�������</a>&nbsp;&nbsp;&nbsp;\r\n");
	XYBody.Append("			    <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/icon3.gif\" height=\"16\" /><a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("feedback.");	XYBody.Append(config.suffix);	XYBody.Append("\">�ٱ�����Ϣ</a>\r\n");
	XYBody.Append("			    </span>\r\n");
	XYBody.Append("			    <strong class=\"orange\">��û���ҵ����ʵĲ�Ʒ?</strong>  �Ͽ�<a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("user/\" target=\"_blank\">��������Ϣ</a>���ù�Ӧ��������������\r\n");
	XYBody.Append("    	    </div>\r\n");
	XYBody.Append("			<input type =\"hidden\" id=\"_param_message_module\" value=\"");	XYBody.Append(module.EName.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("            <input type =\"hidden\" id=\"_param_message_title\" value=\"");	XYBody.Append(titleinfo.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("            <input type =\"hidden\" id=\"_param_message_parent_module\" value =\"");	XYBody.Append(pageinfo.ModuleFlag);	XYBody.Append("\" />\r\n");
	XYBody.Append("            <input type =\"hidden\" id=\"_param_message_infoid\" value =\"");	XYBody.Append(machininginfo.InfoID.ToString());	XYBody.Append("\"/>\r\n");
	XYBody.Append("            <input type =\"hidden\" id=\"_param_message_userid\" value =\"");	XYBody.Append(machininginfo.UserID.ToString());	XYBody.Append("\" />\r\n");

	XYBody.Append("<!--��վ����-->\r\n");
	XYBody.Append("<div  class=\"infoAbout  commentTitle\">\r\n");
	XYBody.Append("<a name=\"message\"></a>\r\n");
	XYBody.Append("<form action=\"\" method=\"post\">\r\n");
	XYBody.Append("    <ul class=\"comment\">\r\n");
	XYBody.Append("        <li id=\"msg_tab1\"><a href=\"javascript:;\" onclick=\"xy_selectBox(2,1,'msg','now')\">�ο���ѯ</a></li>\r\n");
	XYBody.Append("        <li class=\"now\" id=\"msg_tab2\"><a href=\"javascript:;\" onclick=\"xy_selectBox(2,2,'msg','now')\">��Ա��ѯ</a></li>\r\n");
	XYBody.Append("    </ul>\r\n");
	XYBody.Append("    <div id=\"msg_box1\" style=\"display: none;\">\r\n");
	XYBody.Append("        <div class=\"commentList\">\r\n");
	XYBody.Append("            <p>\r\n");
	XYBody.Append("                <input type=\"radio\" checked=\"checked\"  value =\"1\" id=\"companyid\"  name =\"sinfo\"/>�� ˾ \r\n");
	XYBody.Append("                <input name=\"sinfo\" type=\"radio\" value=\"0\" id=\"useridad\" />����\r\n");
	XYBody.Append("                <span>������Ѿ��ǻ�Ա����<a href=\"javascript:geturl();\" class=\"orangelink\">��˵�¼</a>������������Ǳ�վ��Ա����<a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("register.");	XYBody.Append(config.Suffix);	XYBody.Append("\" class=\"orangelink\">���ע��</a></span>\r\n");
	XYBody.Append("            </p>\r\n");
	XYBody.Append("            <h3>��ϵ��ʽ</h3>\r\n");
	XYBody.Append("            <ul  class=\"line\">   \r\n");
	XYBody.Append("                <li><label>��ϵ�ˣ�<em>*</em></label><input type=\"text\" size=\"25\" id=\"linkman\" onblur=\"checkinfo('1');\" onfocus=\"fs('1');\"  maxlength =\"50\"/><input id=\"nsex\" name=\"\" type=\"radio\" value=\"1\" checked =\"checked\" />���� <input id=\"girl\" name=\"\" type=\"radio\" value=\"0\" />Ůʿ<span id=\"txt1\"></span></li>       \r\n");
	XYBody.Append("                <li><label>�������䣺<em>*</em></label><input type=\"text\" size=\"25\"  id=\"email\" onblur=\"checkinfo('2');\" onfocus=\"fs('2');\" maxlength =\"50\" /><span  id=\"txt2\"></span></li>\r\n");
	XYBody.Append("                <li><label>�绰���룺</label><input name=\"\" type=\"text\" size=\"25\" id=\"mobile\" onblur=\"checkinfo('11');\" onfocus=\"fs('11');\" maxlength =\"13\"/><span  id=\"txt11\"></span></li>\r\n");
	XYBody.Append("            </ul>\r\n");
	XYBody.Append("            <h3>��������</h3>\r\n");
	XYBody.Append("            <ul>\r\n");
	XYBody.Append("                <li><label>���Ա��⣺<em>*</em></label><input type=\"text\" size=\"60\" id=\"title\" name=\"title\" onblur=\"checkinfo('14');\" onfocus=\"fs('14');\" maxlength =\"100\" /><span  id =\"txt14\"></span><br /><i>�뾡�����ü������ԣ��������20�����֣��������300�����֡�</i></li>\r\n");
	XYBody.Append("                <li><div class=\"left\"><label>�������ݣ�<em>*</em></label> <textarea name=\"neirong\" cols=\"60\" rows=\"5\" id =\"neirong\" onblur=\"checkinfo('15');\" onfocus=\"fs('15');\"></textarea><span  id=\"txt15\"></span></div>\r\n");
	XYBody.Append("                <div class=\"ks\" id=\"ks1\"></div>\r\n");
	XYBody.Append("                </li>\r\n");

	if (config.IsEnabledVCode("message"))
	{

	XYBody.Append("                <li><label >��֤�룺<em>*</em></label>");	XYBody.Append(pageinfo.GetValidateCodeHTML("guestVCode","guestVCodeImg"));	XYBody.Append("</li>   \r\n");

	}	//end if

	XYBody.Append("                <li>\r\n");
	XYBody.Append("                    <input name=\"\" type=\"button\" class=\"button\" value=\"ȷ ��\"  onclick =\"checkmessage();\"/> \r\n");
	XYBody.Append("                    <input type=\"button\" name=\"button\"  class=\"button\" value=\"���\" onclick =\"ykrewrite();\"  />\r\n");
	XYBody.Append("                </li>\r\n");
	XYBody.Append("            </ul>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div> \r\n");
	XYBody.Append("    <div id=\"msg_box2\" style=\"display: block;\">\r\n");
	XYBody.Append("        <div class=\"commentList\">\r\n");
	XYBody.Append("            <ul>\r\n");
	XYBody.Append("                <li><label>���Ա��⣺<em>*</em></label><input type=\"text\" size=\"60\" id=\"txtTitle\" name=\"txtTitle\"  maxlength =\"200\" /></li>\r\n");
	XYBody.Append("                <li><div class=\"left\"><label>�������ݣ�<em>*</em></label> <textarea name=\"txtContent\" cols=\"60\" rows=\"5\" id=\"txtContent\"></textarea></div>\r\n");
	XYBody.Append("                <div class=\"ks\" id=\"ks2\"></div>\r\n");
	XYBody.Append("                </li>\r\n");

	if (config.IsEnabledVCode("message"))
	{

	XYBody.Append("                <li><label>��֤�룺<em>*</em></label>");	XYBody.Append(pageinfo.GetValidateCodeHTML("userVCode","userVCodeImg"));	XYBody.Append("</li>\r\n");

	}	//end if

	XYBody.Append("                <li>\r\n");
	XYBody.Append("                    <input name=\"\" type=\"button\" class=\"button\" value=\"ȷ ��\" onclick =\"checkusermessage();\"/> \r\n");
	XYBody.Append("                    <input type=\"button\" name=\"Submit\"  class=\"button\" value=\"�� ��\"   onclick=\"hrrewrite();\" />\r\n");
	XYBody.Append("                </li>\r\n");
	XYBody.Append("            </ul>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("</form> \r\n");
	XYBody.Append("</div> \r\n");
	XYBody.Append(" <script type=\"text/javascript\" language=\"javascript\">UserMessageInit();</" + "script>\r\n");


	XYBody.Append("		 </form>\r\n");
	XYBody.Append("			<div id=\"SayInfo\">\r\n");
	XYBody.Append("				<strong>��������</strong>��������Ϣ�������ҵ�����ṩ������ҵ������Ϣ���ݵ���ʵ�ԡ�׼ȷ�ԺͺϷ��ԡ�\r\n");
	XYBody.Append("				<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");	XYBody.Append(config.webname);	XYBody.Append("�Դ˲��е��κα�֤���Ρ�\r\n");
	XYBody.Append("			</div>\r\n");
	XYBody.Append("		</div>\r\n");
	XYBody.Append("	    <div id=\"layoutRight\">\r\n");
	XYBody.Append("			<div id=\"content\">\r\n");
	XYBody.Append("                <input type =\"hidden\" id=\"_param_userinfo_parent_module\" value =\"");	XYBody.Append(pageinfo.ModuleFlag);	XYBody.Append("\" />\r\n");
	XYBody.Append("                <input type =\"hidden\" id=\"_param_userinfo_infoid\" value =\"");	XYBody.Append(machininginfo.InfoID.ToString());	XYBody.Append("\"/>\r\n");
	XYBody.Append("                <input type =\"hidden\" id=\"_param_userinfo_userid\" value =\"");	XYBody.Append(machininginfo.UserID.ToString());	XYBody.Append("\" />\r\n");

	XYBody.Append("<!--������ʾ��Ϣ--> \r\n");
	XYBody.Append("<div class=\"w290\" id=\"loginuser\" style=\"display:none;\">  \r\n");
	XYBody.Append("    <ul>\r\n");
	XYBody.Append("        <li id=\"loginuseruginfo\"></li>\r\n");
	XYBody.Append("        <li class=\"line\"><a id=\"loginuserurl\" href=\"\" class=\"link14\"></a></li>\r\n");
	XYBody.Append("        <li>��˾��������� <span id=\"ConsummatePercent\"></span></li>\r\n");
	XYBody.Append("        <li><div class=\"cr\"><img id=\"PercentForImg\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/rate.gif\" alt=\" \"  height=\"15px\" /></div></li>\r\n");
	XYBody.Append("        <li><a href=\"#\" id=\"NewOfferPage\">���¹�Ӧ</a> | <a href=\"#\" id=\"GoodFaithFile\">���ŵ���</a> | <a href=\"#\" id=\"UserIntro\">��˾����</a></li>\r\n");
	XYBody.Append("        <li>��ϵ�ˣ�<a href=\"#\" id=\"Contact\"><span id=\"LinkManName\">����</span></a> ���� <span id=\"IMOnline\"></span></li>\r\n");
	XYBody.Append("        <li><hr /></li>\r\n");
	XYBody.Append("        <li>����ʱ�䣺�� <span id=\"loginuseryearnum\"></span> ��</li>\r\n");
	XYBody.Append("        <li> <a href=\"javascript:;\" onclick =\"Favorite();\">�ղش���Ϣ</a> <a href=\"#\" id=\"memessage\">��������</a> <a href=\"#\" id=\"linkme\">��ϵ��ʽ</a></li>  \r\n");
	XYBody.Append("    </ul>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<!--Ҫ���½��鿴-->\r\n");
	XYBody.Append("<div class=\"w290\" id=\"UserNoLogin\" style=\"display:none;\">\r\n");
	XYBody.Append("    <ul class=\"login\">\r\n");
	XYBody.Append("        <li><h4>�Ѿ��ǻ�Ա���½</h4></li>\r\n");
	XYBody.Append("        <li>�û�����<input type=\"text\" name=\"\" tabindex=\"1\"  id=\"username\" name=\"username\" onkeydown =\"KeyDown();\" maxlength=\"50\" /></li>\r\n");
	XYBody.Append("        <li>��&nbsp;&nbsp;&nbsp;�룺<input type =\"password\" maxlength=\"20\" tabindex=\"2\" id=\"password\"  name=\"password\" onkeydown =\"KeyDown();\" /></li>\r\n");

	if (config.IsEnabledVCode("login"))
	{

	XYBody.Append("        <li>��֤�룺");	XYBody.Append(pageinfo.GetValidateCodeHTML());	XYBody.Append("</li>\r\n");

	}	//end if

	XYBody.Append("        <li><input type=\"button\" class=\"button\" value=\"��¼\" onclick=\"return InfoLogin();\"/><a href=\"/GetPassword.");	XYBody.Append(config.Suffix);	XYBody.Append("\">�������룿</a></li>\r\n");
	XYBody.Append("        <li><hr /></li>\r\n");
	XYBody.Append("        <ll>�㻹���ǻ�Ա����<a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("register.");	XYBody.Append(config.Suffix);	XYBody.Append("\">�������ע��</a></li>\r\n");
	XYBody.Append("        <li>\r\n");
	XYBody.Append("            <div class=\"contactus\">\r\n");
	XYBody.Append("                <ul>\r\n");
	XYBody.Append("                <li><h3>�����κ���������������ϵ</h3></li>\r\n");
	XYBody.Append("                <li>���߿ͷ���<img src=\"/templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/kefu.gif\" /> <img src=\"/templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/kefu.gif\" /></li>\r\n");
	XYBody.Append("                <li>�ͻ����ߣ�010-8681 8791</li>\r\n");
	XYBody.Append("                </ul>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </li>      \r\n");
	XYBody.Append("    </ul>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<!--Ҫ��������鿴-->\r\n");
	XYBody.Append("<div class=\"w290\" id=\"loginnouser\" style=\"display:none;\">\r\n");
	XYBody.Append("    <h3><span id=\"loginnouseruginfo\"></span></h3>\r\n");
	XYBody.Append("    <ul class=\"upgrade\">\r\n");
	XYBody.Append("        <li><span>��Ŀǰ���ڵĻ�Ա�飬�޷��鿴��Ϣ��</span></li>\r\n");
	XYBody.Append("        <li><a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("user/postadministratormessage.");	XYBody.Append(config.Suffix);	XYBody.Append("\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/update.gif\" border=\"0\"/></a></li>\r\n");
	XYBody.Append("        <li><a href=\"\">��˲鿴��Ա�ȼ���Ȩ��>></a></li>\r\n");
	XYBody.Append("        <li>\r\n");
	XYBody.Append("            <div class=\"contactus\">\r\n");
	XYBody.Append("                <ul>\r\n");
	XYBody.Append("                <li><h3>�����κ���������������ϵ</h3></li>\r\n");
	XYBody.Append("                <li>���߿ͷ���<img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/kefu.gif\" /> <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/kefu.gif\" /></li>\r\n");
	XYBody.Append("                <li>�ͻ����ߣ�010-8681 8791</li>\r\n");
	XYBody.Append("                </ul>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </li>\r\n");
	XYBody.Append("        <li><a href=\"javascript:;\" onclick =\"Favorite();\">�ղش���Ϣ</a></li>\r\n");
	XYBody.Append("    </ul>\r\n");
	XYBody.Append("</div>  \r\n");


	XYBody.Append("			</div>\r\n");
	XYBody.Append("			<div class=\"MTitle_01\">\r\n");
	XYBody.Append("				<center><a target=\"_blank\" href=\"#\" class=\"red\"><strong>�������ǣ����ܸ������</strong></a></center>\r\n");
	XYBody.Append("			</div>\r\n");
	XYBody.Append("			<div class=\"Mblk_01\">\r\n");
	XYBody.Append("				<div id=\"jointous\">\r\n");
	XYBody.Append("					<ul>\r\n");
	XYBody.Append("						<li><a href=\"\">�� �ύó�׻�飬��չ������Ȧ</a></li>\r\n");
	XYBody.Append("						<li><a href=\"\">�� ��Ϊ��Ա����ѷ���������Ϣ</a></li>\r\n");
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
	XYBody.Append("							<a href=\"");	XYBody.Append(tempuser.shopindex.ToString());	XYBody.Append("\" class=\"blueLink Font14\"><strong>");	XYBody.Append(tempuser.unitname.ToString());	XYBody.Append("</strong></a>&nbsp;&nbsp;<a href=\"");	XYBody.Append(tempuser.shopindex.ToString());	XYBody.Append("\" target=\"_blank\"><img src=\"");	XYBody.Append(tempuser.gradeimgurl.ToString());	XYBody.Append("\" border=\"0\" style=\"position:relative;top:1px;\" /></a>&nbsp;&nbsp;<strong class=\"Font14\">��<span class=\"MemberYear\">");	XYBody.Append(tempuser.years.ToString());	XYBody.Append("</span>��</strong>\r\n");
	XYBody.Append("							<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"fontGray\">\r\n");
	XYBody.Append("								<tr>\r\n");
	XYBody.Append("									<td height=\"10\" colspan=\"2\"></td>\r\n");
	XYBody.Append("								</tr>\r\n");
	XYBody.Append("								<tr>\r\n");
	XYBody.Append("									<td height=\"33\" colspan=\"2\">\r\n");
	XYBody.Append("									    <a href=\"");	XYBody.Append(tempuser.shopindex.ToString());	XYBody.Append("\" target=\"_blank\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/enterWEB.gif\" alt=\"������ҵ��վ\" width=\"112\" height=\"21\" border=\"0\" /></a>&nbsp;&nbsp;&nbsp;\r\n");
	XYBody.Append("									    <a href=\"");	XYBody.Append(tempuser.contactus.ToString());	XYBody.Append("\" target=\"_blank\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/enterContact.gif\" alt=\"�鿴��ϵ��ʽ\" width=\"112\" height=\"21\" border=\"0\" /></a></td>\r\n");
	XYBody.Append("									</tr>\r\n");
	XYBody.Append("								<tr>\r\n");
	XYBody.Append("									<td width=\"50%\" height=\"22\">��ҵ���ͣ�");	XYBody.Append(tempuser.character.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("									<td width=\"50%\">Ա��������");	XYBody.Append(tempuser.employeetotal.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("								</tr>\r\n");
	XYBody.Append("								<tr>\r\n");
	XYBody.Append("									<td height=\"22\">��Ӫģʽ��");	XYBody.Append(tempuser.mode.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("									<td>ע���ʽ�");	XYBody.Append(tempuser.registeredcapital.ToString());	XYBody.Append("��</td>\r\n");
	XYBody.Append("								</tr>\r\n");
	XYBody.Append("							</table>\r\n");
	XYBody.Append("						</div>\r\n");
	XYBody.Append("						<div id=\"ProInfoB\">\r\n");
	XYBody.Append("							<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	XYBody.Append("									<tr>\r\n");
	XYBody.Append("										<td  height=\"24\" colspan=\"2\">���������Ʒ�ƣ�");	XYBody.Append(investmentinfo.QuondamProduct.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("									</tr>\r\n");
	XYBody.Append("									<tr>\r\n");
	XYBody.Append("										<td height=\"24\">��Ч������");	XYBody.Append(investmentinfo.EndTime.ToShortDateString().ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("										<td>����ʱ�䣺");	XYBody.Append(investmentinfo.PublishTime.ToShortDateString().ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("									</tr>\r\n");
	XYBody.Append("									<tr>\r\n");
	XYBody.Append("										<td height=\"24\" colspan=\"3\">�� ϵ �ˣ�");	XYBody.Append(tempuser.linkman.ToString());	XYBody.Append("&nbsp;&nbsp;<img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/icon_tianjiasy.gif\" width=\"13\" height=\"12\" style=\"position:relative;top:1px;\" /> <a href=\"javascript:void(null);\" onclick=\"Favorite();\" class=\"orange\">���Ϊ��ҵ���</a></td>\r\n");
	XYBody.Append("									</tr>\r\n");
	XYBody.Append("							</table>\r\n");
	XYBody.Append("						</div>\r\n");
	XYBody.Append("						<div class=\"blank5\"></div>\r\n");
	XYBody.Append("						<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	XYBody.Append("							<tr>\r\n");
	XYBody.Append("								<td height=\"60\"><a href=\"#message\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/inquire2.gif\" width=\"139\" height=\"36\" border=\"0\" /></a> </td>\r\n");
	XYBody.Append("								<td style=\"text-align:center;\"><span class=\"Font14\">����ϵ</span>��<strong class=\"orange\" class=\"TempTele\">86-010-62669815</strong></td>\r\n");
	XYBody.Append("								<td width=\"23%\"></td>\r\n");
	XYBody.Append("							</tr>\r\n");
	XYBody.Append("						</table>\r\n");
	XYBody.Append("					</div>\r\n");
	XYBody.Append("					<div class=\"clr\"></div>\r\n");
	XYBody.Append("					<div id=\"ProDesTitle\"><strong>��ϸ��Ϣ:</strong></div>\r\n");
	XYBody.Append("					<div class=\"ProDesText\">\r\n");
	XYBody.Append("					     <table width=\"95%\" border=\"0\" align=\"center\" cellpadding=\"1\" cellspacing=\"1\" class=\"typelist\">");	XYBody.Append(fieldbody.ToString());	XYBody.Append("</table>\r\n");
	XYBody.Append("					     ");	XYBody.Append(investmentinfo.InfoContent.ToString());	XYBody.Append("\r\n");
	XYBody.Append("					</div>\r\n");
	XYBody.Append("					<div id=\"ProDesTitle\">\r\n");
	XYBody.Append("					    <strong>��ϵ��ʽ:</strong>\r\n");
	XYBody.Append("					</div>\r\n");
	XYBody.Append("					<div class=\"ProDesText\" id=\"linkmessage\"></div>\r\n");
	XYBody.Append("				</div>\r\n");
	XYBody.Append("			</div>\r\n");
	XYBody.Append("			<div id=\"ProFind\">\r\n");
	XYBody.Append("			    <span>\r\n");
	XYBody.Append("			    <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/icon1.gif\" width=\"20\" height=\"14\" /><a href=\"javascript:void(null);\" onclick=\"Favorite();\">�ղش���Ϣ</a>&nbsp;&nbsp;&nbsp;\r\n");
	XYBody.Append("			    <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/icon2.gif\" width=\"21\" height=\"11\" /><a href=\"#\">�Ƽ�������</a>&nbsp;&nbsp;&nbsp;\r\n");
	XYBody.Append("			    <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/icon3.gif\" height=\"16\" /><a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("feedback.");	XYBody.Append(config.suffix);	XYBody.Append("\">�ٱ�����Ϣ</a>\r\n");
	XYBody.Append("			    </span>\r\n");
	XYBody.Append("			    <strong class=\"orange\">��û���ҵ����ʵĲ�Ʒ?</strong>  �Ͽ�<a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("user/\" target=\"_blank\">��������Ϣ</a>���ù�Ӧ��������������\r\n");
	XYBody.Append("    	    </div>\r\n");
	XYBody.Append("			<input type =\"hidden\" id=\"_param_message_module\" value=\"");	XYBody.Append(module.EName.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("            <input type =\"hidden\" id=\"_param_message_title\" value=\"");	XYBody.Append(titleinfo.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("            <input type =\"hidden\" id=\"_param_message_parent_module\" value =\"");	XYBody.Append(pageinfo.ModuleFlag);	XYBody.Append("\" />\r\n");
	XYBody.Append("            <input type =\"hidden\" id=\"_param_message_infoid\" value =\"");	XYBody.Append(investmentinfo.InfoID.ToString());	XYBody.Append("\"/>\r\n");
	XYBody.Append("            <input type =\"hidden\" id=\"_param_message_userid\" value =\"");	XYBody.Append(investmentinfo.UserID.ToString());	XYBody.Append("\" />\r\n");

	XYBody.Append("<!--��վ����-->\r\n");
	XYBody.Append("<div  class=\"infoAbout  commentTitle\">\r\n");
	XYBody.Append("<a name=\"message\"></a>\r\n");
	XYBody.Append("<form action=\"\" method=\"post\">\r\n");
	XYBody.Append("    <ul class=\"comment\">\r\n");
	XYBody.Append("        <li id=\"msg_tab1\"><a href=\"javascript:;\" onclick=\"xy_selectBox(2,1,'msg','now')\">�ο���ѯ</a></li>\r\n");
	XYBody.Append("        <li class=\"now\" id=\"msg_tab2\"><a href=\"javascript:;\" onclick=\"xy_selectBox(2,2,'msg','now')\">��Ա��ѯ</a></li>\r\n");
	XYBody.Append("    </ul>\r\n");
	XYBody.Append("    <div id=\"msg_box1\" style=\"display: none;\">\r\n");
	XYBody.Append("        <div class=\"commentList\">\r\n");
	XYBody.Append("            <p>\r\n");
	XYBody.Append("                <input type=\"radio\" checked=\"checked\"  value =\"1\" id=\"companyid\"  name =\"sinfo\"/>�� ˾ \r\n");
	XYBody.Append("                <input name=\"sinfo\" type=\"radio\" value=\"0\" id=\"useridad\" />����\r\n");
	XYBody.Append("                <span>������Ѿ��ǻ�Ա����<a href=\"javascript:geturl();\" class=\"orangelink\">��˵�¼</a>������������Ǳ�վ��Ա����<a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("register.");	XYBody.Append(config.Suffix);	XYBody.Append("\" class=\"orangelink\">���ע��</a></span>\r\n");
	XYBody.Append("            </p>\r\n");
	XYBody.Append("            <h3>��ϵ��ʽ</h3>\r\n");
	XYBody.Append("            <ul  class=\"line\">   \r\n");
	XYBody.Append("                <li><label>��ϵ�ˣ�<em>*</em></label><input type=\"text\" size=\"25\" id=\"linkman\" onblur=\"checkinfo('1');\" onfocus=\"fs('1');\"  maxlength =\"50\"/><input id=\"nsex\" name=\"\" type=\"radio\" value=\"1\" checked =\"checked\" />���� <input id=\"girl\" name=\"\" type=\"radio\" value=\"0\" />Ůʿ<span id=\"txt1\"></span></li>       \r\n");
	XYBody.Append("                <li><label>�������䣺<em>*</em></label><input type=\"text\" size=\"25\"  id=\"email\" onblur=\"checkinfo('2');\" onfocus=\"fs('2');\" maxlength =\"50\" /><span  id=\"txt2\"></span></li>\r\n");
	XYBody.Append("                <li><label>�绰���룺</label><input name=\"\" type=\"text\" size=\"25\" id=\"mobile\" onblur=\"checkinfo('11');\" onfocus=\"fs('11');\" maxlength =\"13\"/><span  id=\"txt11\"></span></li>\r\n");
	XYBody.Append("            </ul>\r\n");
	XYBody.Append("            <h3>��������</h3>\r\n");
	XYBody.Append("            <ul>\r\n");
	XYBody.Append("                <li><label>���Ա��⣺<em>*</em></label><input type=\"text\" size=\"60\" id=\"title\" name=\"title\" onblur=\"checkinfo('14');\" onfocus=\"fs('14');\" maxlength =\"100\" /><span  id =\"txt14\"></span><br /><i>�뾡�����ü������ԣ��������20�����֣��������300�����֡�</i></li>\r\n");
	XYBody.Append("                <li><div class=\"left\"><label>�������ݣ�<em>*</em></label> <textarea name=\"neirong\" cols=\"60\" rows=\"5\" id =\"neirong\" onblur=\"checkinfo('15');\" onfocus=\"fs('15');\"></textarea><span  id=\"txt15\"></span></div>\r\n");
	XYBody.Append("                <div class=\"ks\" id=\"ks1\"></div>\r\n");
	XYBody.Append("                </li>\r\n");

	if (config.IsEnabledVCode("message"))
	{

	XYBody.Append("                <li><label >��֤�룺<em>*</em></label>");	XYBody.Append(pageinfo.GetValidateCodeHTML("guestVCode","guestVCodeImg"));	XYBody.Append("</li>   \r\n");

	}	//end if

	XYBody.Append("                <li>\r\n");
	XYBody.Append("                    <input name=\"\" type=\"button\" class=\"button\" value=\"ȷ ��\"  onclick =\"checkmessage();\"/> \r\n");
	XYBody.Append("                    <input type=\"button\" name=\"button\"  class=\"button\" value=\"���\" onclick =\"ykrewrite();\"  />\r\n");
	XYBody.Append("                </li>\r\n");
	XYBody.Append("            </ul>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div> \r\n");
	XYBody.Append("    <div id=\"msg_box2\" style=\"display: block;\">\r\n");
	XYBody.Append("        <div class=\"commentList\">\r\n");
	XYBody.Append("            <ul>\r\n");
	XYBody.Append("                <li><label>���Ա��⣺<em>*</em></label><input type=\"text\" size=\"60\" id=\"txtTitle\" name=\"txtTitle\"  maxlength =\"200\" /></li>\r\n");
	XYBody.Append("                <li><div class=\"left\"><label>�������ݣ�<em>*</em></label> <textarea name=\"txtContent\" cols=\"60\" rows=\"5\" id=\"txtContent\"></textarea></div>\r\n");
	XYBody.Append("                <div class=\"ks\" id=\"ks2\"></div>\r\n");
	XYBody.Append("                </li>\r\n");

	if (config.IsEnabledVCode("message"))
	{

	XYBody.Append("                <li><label>��֤�룺<em>*</em></label>");	XYBody.Append(pageinfo.GetValidateCodeHTML("userVCode","userVCodeImg"));	XYBody.Append("</li>\r\n");

	}	//end if

	XYBody.Append("                <li>\r\n");
	XYBody.Append("                    <input name=\"\" type=\"button\" class=\"button\" value=\"ȷ ��\" onclick =\"checkusermessage();\"/> \r\n");
	XYBody.Append("                    <input type=\"button\" name=\"Submit\"  class=\"button\" value=\"�� ��\"   onclick=\"hrrewrite();\" />\r\n");
	XYBody.Append("                </li>\r\n");
	XYBody.Append("            </ul>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("</form> \r\n");
	XYBody.Append("</div> \r\n");
	XYBody.Append(" <script type=\"text/javascript\" language=\"javascript\">UserMessageInit();</" + "script>\r\n");


	XYBody.Append("		 </form>\r\n");
	XYBody.Append("			<div id=\"SayInfo\">\r\n");
	XYBody.Append("				<strong>��������</strong>��������Ϣ�������ҵ�����ṩ������ҵ������Ϣ���ݵ���ʵ�ԡ�׼ȷ�ԺͺϷ��ԡ�\r\n");
	XYBody.Append("				<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");	XYBody.Append(config.webname);	XYBody.Append("�Դ˲��е��κα�֤���Ρ�\r\n");
	XYBody.Append("			</div>\r\n");
	XYBody.Append("		</div>\r\n");
	XYBody.Append("	    <div id=\"layoutRight\">\r\n");
	XYBody.Append("			<div id=\"content\">\r\n");
	XYBody.Append("                <input type =\"hidden\" id=\"_param_userinfo_parent_module\" value =\"");	XYBody.Append(pageinfo.ModuleFlag);	XYBody.Append("\" />\r\n");
	XYBody.Append("                <input type =\"hidden\" id=\"_param_userinfo_infoid\" value =\"");	XYBody.Append(investmentinfo.InfoID.ToString());	XYBody.Append("\"/>\r\n");
	XYBody.Append("                <input type =\"hidden\" id=\"_param_userinfo_userid\" value =\"");	XYBody.Append(investmentinfo.UserID.ToString());	XYBody.Append("\" />\r\n");

	XYBody.Append("<!--������ʾ��Ϣ--> \r\n");
	XYBody.Append("<div class=\"w290\" id=\"loginuser\" style=\"display:none;\">  \r\n");
	XYBody.Append("    <ul>\r\n");
	XYBody.Append("        <li id=\"loginuseruginfo\"></li>\r\n");
	XYBody.Append("        <li class=\"line\"><a id=\"loginuserurl\" href=\"\" class=\"link14\"></a></li>\r\n");
	XYBody.Append("        <li>��˾��������� <span id=\"ConsummatePercent\"></span></li>\r\n");
	XYBody.Append("        <li><div class=\"cr\"><img id=\"PercentForImg\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/rate.gif\" alt=\" \"  height=\"15px\" /></div></li>\r\n");
	XYBody.Append("        <li><a href=\"#\" id=\"NewOfferPage\">���¹�Ӧ</a> | <a href=\"#\" id=\"GoodFaithFile\">���ŵ���</a> | <a href=\"#\" id=\"UserIntro\">��˾����</a></li>\r\n");
	XYBody.Append("        <li>��ϵ�ˣ�<a href=\"#\" id=\"Contact\"><span id=\"LinkManName\">����</span></a> ���� <span id=\"IMOnline\"></span></li>\r\n");
	XYBody.Append("        <li><hr /></li>\r\n");
	XYBody.Append("        <li>����ʱ�䣺�� <span id=\"loginuseryearnum\"></span> ��</li>\r\n");
	XYBody.Append("        <li> <a href=\"javascript:;\" onclick =\"Favorite();\">�ղش���Ϣ</a> <a href=\"#\" id=\"memessage\">��������</a> <a href=\"#\" id=\"linkme\">��ϵ��ʽ</a></li>  \r\n");
	XYBody.Append("    </ul>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<!--Ҫ���½��鿴-->\r\n");
	XYBody.Append("<div class=\"w290\" id=\"UserNoLogin\" style=\"display:none;\">\r\n");
	XYBody.Append("    <ul class=\"login\">\r\n");
	XYBody.Append("        <li><h4>�Ѿ��ǻ�Ա���½</h4></li>\r\n");
	XYBody.Append("        <li>�û�����<input type=\"text\" name=\"\" tabindex=\"1\"  id=\"username\" name=\"username\" onkeydown =\"KeyDown();\" maxlength=\"50\" /></li>\r\n");
	XYBody.Append("        <li>��&nbsp;&nbsp;&nbsp;�룺<input type =\"password\" maxlength=\"20\" tabindex=\"2\" id=\"password\"  name=\"password\" onkeydown =\"KeyDown();\" /></li>\r\n");

	if (config.IsEnabledVCode("login"))
	{

	XYBody.Append("        <li>��֤�룺");	XYBody.Append(pageinfo.GetValidateCodeHTML());	XYBody.Append("</li>\r\n");

	}	//end if

	XYBody.Append("        <li><input type=\"button\" class=\"button\" value=\"��¼\" onclick=\"return InfoLogin();\"/><a href=\"/GetPassword.");	XYBody.Append(config.Suffix);	XYBody.Append("\">�������룿</a></li>\r\n");
	XYBody.Append("        <li><hr /></li>\r\n");
	XYBody.Append("        <ll>�㻹���ǻ�Ա����<a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("register.");	XYBody.Append(config.Suffix);	XYBody.Append("\">�������ע��</a></li>\r\n");
	XYBody.Append("        <li>\r\n");
	XYBody.Append("            <div class=\"contactus\">\r\n");
	XYBody.Append("                <ul>\r\n");
	XYBody.Append("                <li><h3>�����κ���������������ϵ</h3></li>\r\n");
	XYBody.Append("                <li>���߿ͷ���<img src=\"/templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/kefu.gif\" /> <img src=\"/templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/kefu.gif\" /></li>\r\n");
	XYBody.Append("                <li>�ͻ����ߣ�010-8681 8791</li>\r\n");
	XYBody.Append("                </ul>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </li>      \r\n");
	XYBody.Append("    </ul>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<!--Ҫ��������鿴-->\r\n");
	XYBody.Append("<div class=\"w290\" id=\"loginnouser\" style=\"display:none;\">\r\n");
	XYBody.Append("    <h3><span id=\"loginnouseruginfo\"></span></h3>\r\n");
	XYBody.Append("    <ul class=\"upgrade\">\r\n");
	XYBody.Append("        <li><span>��Ŀǰ���ڵĻ�Ա�飬�޷��鿴��Ϣ��</span></li>\r\n");
	XYBody.Append("        <li><a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("user/postadministratormessage.");	XYBody.Append(config.Suffix);	XYBody.Append("\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/update.gif\" border=\"0\"/></a></li>\r\n");
	XYBody.Append("        <li><a href=\"\">��˲鿴��Ա�ȼ���Ȩ��>></a></li>\r\n");
	XYBody.Append("        <li>\r\n");
	XYBody.Append("            <div class=\"contactus\">\r\n");
	XYBody.Append("                <ul>\r\n");
	XYBody.Append("                <li><h3>�����κ���������������ϵ</h3></li>\r\n");
	XYBody.Append("                <li>���߿ͷ���<img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/kefu.gif\" /> <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/kefu.gif\" /></li>\r\n");
	XYBody.Append("                <li>�ͻ����ߣ�010-8681 8791</li>\r\n");
	XYBody.Append("                </ul>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </li>\r\n");
	XYBody.Append("        <li><a href=\"javascript:;\" onclick =\"Favorite();\">�ղش���Ϣ</a></li>\r\n");
	XYBody.Append("    </ul>\r\n");
	XYBody.Append("</div>  \r\n");


	XYBody.Append("			</div>\r\n");
	XYBody.Append("			<div class=\"MTitle_01\">\r\n");
	XYBody.Append("				<center><a target=\"_blank\" href=\"#\" class=\"red\"><strong>�������ǣ����ܸ������</strong></a></center>\r\n");
	XYBody.Append("			</div>\r\n");
	XYBody.Append("			<div class=\"Mblk_01\">\r\n");
	XYBody.Append("				<div id=\"jointous\">\r\n");
	XYBody.Append("					<ul>\r\n");
	XYBody.Append("						<li><a href=\"\">�� �ύó�׻�飬��չ������Ȧ</a></li>\r\n");
	XYBody.Append("						<li><a href=\"\">�� ��Ϊ��Ա����ѷ���������Ϣ</a></li>\r\n");
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
	XYBody.Append("							<a href=\"");	XYBody.Append(tempuser.shopindex.ToString());	XYBody.Append("\" class=\"blueLink Font14\"><strong>");	XYBody.Append(tempuser.unitname.ToString());	XYBody.Append("</strong></a>&nbsp;&nbsp;<a href=\"");	XYBody.Append(tempuser.shopindex.ToString());	XYBody.Append("\" target=\"_blank\"><img src=\"");	XYBody.Append(tempuser.gradeimgurl.ToString());	XYBody.Append("\" border=\"0\" style=\"position:relative;top:1px;\" /></a>&nbsp;&nbsp;<strong class=\"Font14\">��<span class=\"MemberYear\">");	XYBody.Append(tempuser.years.ToString());	XYBody.Append("</span>��</strong>\r\n");
	XYBody.Append("							<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"fontGray\">\r\n");
	XYBody.Append("								<tr>\r\n");
	XYBody.Append("									<td height=\"10\" colspan=\"2\"></td>\r\n");
	XYBody.Append("								</tr>\r\n");
	XYBody.Append("								<tr>\r\n");
	XYBody.Append("									<td height=\"33\" colspan=\"2\">\r\n");
	XYBody.Append("									    <a href=\"");	XYBody.Append(tempuser.shopindex.ToString());	XYBody.Append("\" target=\"_blank\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/enterWEB.gif\" alt=\"������ҵ��վ\" width=\"112\" height=\"21\" border=\"0\" /></a>&nbsp;&nbsp;&nbsp;\r\n");
	XYBody.Append("									    <a href=\"");	XYBody.Append(tempuser.contactus.ToString());	XYBody.Append("\" target=\"_blank\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/enterContact.gif\" alt=\"�鿴��ϵ��ʽ\" width=\"112\" height=\"21\" border=\"0\" /></a></td>\r\n");
	XYBody.Append("									</tr>\r\n");
	XYBody.Append("								<tr>\r\n");
	XYBody.Append("									<td width=\"50%\" height=\"22\">��ҵ���ͣ�");	XYBody.Append(tempuser.character.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("									<td width=\"50%\">Ա��������");	XYBody.Append(tempuser.employeetotal.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("								</tr>\r\n");
	XYBody.Append("								<tr>\r\n");
	XYBody.Append("									<td height=\"22\">��Ӫģʽ��");	XYBody.Append(tempuser.mode.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("									<td>ע���ʽ�");	XYBody.Append(tempuser.registeredcapital.ToString());	XYBody.Append("��</td>\r\n");
	XYBody.Append("								</tr>\r\n");
	XYBody.Append("							</table>\r\n");
	XYBody.Append("						</div>\r\n");
	XYBody.Append("						<div id=\"ProInfoB\">\r\n");
	XYBody.Append("							<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	XYBody.Append("									<tr>\r\n");
	XYBody.Append("										<td height=\"24\">��Ч������");	XYBody.Append(serviceinfo.EndTime.ToShortDateString().ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("										<td>����ʱ�䣺");	XYBody.Append(serviceinfo.PublishTime.ToShortDateString().ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("									</tr>\r\n");
	XYBody.Append("									<tr>\r\n");
	XYBody.Append("										<td height=\"24\" colspan=\"3\">�� ϵ �ˣ�");	XYBody.Append(tempuser.linkman.ToString());	XYBody.Append("&nbsp;&nbsp;<img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/icon_tianjiasy.gif\" width=\"13\" height=\"12\" style=\"position:relative;top:1px;\" /> <a href=\"javascript:void(null);\" onclick=\"Favorite();\" class=\"orange\">���Ϊ��ҵ���</a></td>\r\n");
	XYBody.Append("									</tr>\r\n");
	XYBody.Append("							</table>\r\n");
	XYBody.Append("						</div>\r\n");
	XYBody.Append("						<div class=\"blank5\"></div>\r\n");
	XYBody.Append("						<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	XYBody.Append("							<tr>\r\n");
	XYBody.Append("								<td height=\"60\"><a href=\"#message\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/inquire2.gif\" width=\"139\" height=\"36\" border=\"0\" /></a> </td>\r\n");
	XYBody.Append("								<td style=\"text-align:center;\"><span class=\"Font14\">����ϵ</span>��<strong class=\"orange\" class=\"TempTele\">86-010-62669815</strong></td>\r\n");
	XYBody.Append("								<td width=\"23%\"></td>\r\n");
	XYBody.Append("							</tr>\r\n");
	XYBody.Append("						</table>\r\n");
	XYBody.Append("					</div>\r\n");
	XYBody.Append("					<div class=\"clr\"></div>\r\n");
	XYBody.Append("					<div id=\"ProDesTitle\"><strong>��ϸ��Ϣ:</strong></div>\r\n");
	XYBody.Append("					<div class=\"ProDesText\">\r\n");
	XYBody.Append("					     <table width=\"95%\" border=\"0\" align=\"center\" cellpadding=\"1\" cellspacing=\"1\" class=\"typelist\">");	XYBody.Append(fieldbody.ToString());	XYBody.Append("</table>\r\n");
	XYBody.Append("					     ");	XYBody.Append(serviceinfo.InfoContent.ToString());	XYBody.Append("\r\n");
	XYBody.Append("					</div>\r\n");
	XYBody.Append("					<div id=\"ProDesTitle\">\r\n");
	XYBody.Append("					    <strong>��ϵ��ʽ:</strong>\r\n");
	XYBody.Append("					</div>\r\n");
	XYBody.Append("					<div class=\"ProDesText\" id=\"linkmessage\"></div>\r\n");
	XYBody.Append("				</div>\r\n");
	XYBody.Append("			</div>\r\n");
	XYBody.Append("			<div id=\"ProFind\">\r\n");
	XYBody.Append("			    <span>\r\n");
	XYBody.Append("			    <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/icon1.gif\" width=\"20\" height=\"14\" /><a href=\"javascript:void(null);\" onclick=\"Favorite();\">�ղش���Ϣ</a>&nbsp;&nbsp;&nbsp;\r\n");
	XYBody.Append("			    <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/icon2.gif\" width=\"21\" height=\"11\" /><a href=\"#\">�Ƽ�������</a>&nbsp;&nbsp;&nbsp;\r\n");
	XYBody.Append("			    <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/icon3.gif\" height=\"16\" /><a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("feedback.");	XYBody.Append(config.suffix);	XYBody.Append("\">�ٱ�����Ϣ</a>\r\n");
	XYBody.Append("			    </span>\r\n");
	XYBody.Append("			    <strong class=\"orange\">��û���ҵ����ʵĲ�Ʒ?</strong>  �Ͽ�<a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("user/\" target=\"_blank\">��������Ϣ</a>���ù�Ӧ��������������\r\n");
	XYBody.Append("    	    </div>\r\n");
	XYBody.Append("			<input type =\"hidden\" id=\"_param_message_module\" value=\"");	XYBody.Append(module.EName.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("            <input type =\"hidden\" id=\"_param_message_title\" value=\"");	XYBody.Append(titleinfo.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("            <input type =\"hidden\" id=\"_param_message_parent_module\" value =\"");	XYBody.Append(pageinfo.ModuleFlag);	XYBody.Append("\" />\r\n");
	XYBody.Append("            <input type =\"hidden\" id=\"_param_message_infoid\" value =\"");	XYBody.Append(serviceinfo.InfoID.ToString());	XYBody.Append("\"/>\r\n");
	XYBody.Append("            <input type =\"hidden\" id=\"_param_message_userid\" value =\"");	XYBody.Append(serviceinfo.UserID.ToString());	XYBody.Append("\" />\r\n");

	XYBody.Append("<!--��վ����-->\r\n");
	XYBody.Append("<div  class=\"infoAbout  commentTitle\">\r\n");
	XYBody.Append("<a name=\"message\"></a>\r\n");
	XYBody.Append("<form action=\"\" method=\"post\">\r\n");
	XYBody.Append("    <ul class=\"comment\">\r\n");
	XYBody.Append("        <li id=\"msg_tab1\"><a href=\"javascript:;\" onclick=\"xy_selectBox(2,1,'msg','now')\">�ο���ѯ</a></li>\r\n");
	XYBody.Append("        <li class=\"now\" id=\"msg_tab2\"><a href=\"javascript:;\" onclick=\"xy_selectBox(2,2,'msg','now')\">��Ա��ѯ</a></li>\r\n");
	XYBody.Append("    </ul>\r\n");
	XYBody.Append("    <div id=\"msg_box1\" style=\"display: none;\">\r\n");
	XYBody.Append("        <div class=\"commentList\">\r\n");
	XYBody.Append("            <p>\r\n");
	XYBody.Append("                <input type=\"radio\" checked=\"checked\"  value =\"1\" id=\"companyid\"  name =\"sinfo\"/>�� ˾ \r\n");
	XYBody.Append("                <input name=\"sinfo\" type=\"radio\" value=\"0\" id=\"useridad\" />����\r\n");
	XYBody.Append("                <span>������Ѿ��ǻ�Ա����<a href=\"javascript:geturl();\" class=\"orangelink\">��˵�¼</a>������������Ǳ�վ��Ա����<a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("register.");	XYBody.Append(config.Suffix);	XYBody.Append("\" class=\"orangelink\">���ע��</a></span>\r\n");
	XYBody.Append("            </p>\r\n");
	XYBody.Append("            <h3>��ϵ��ʽ</h3>\r\n");
	XYBody.Append("            <ul  class=\"line\">   \r\n");
	XYBody.Append("                <li><label>��ϵ�ˣ�<em>*</em></label><input type=\"text\" size=\"25\" id=\"linkman\" onblur=\"checkinfo('1');\" onfocus=\"fs('1');\"  maxlength =\"50\"/><input id=\"nsex\" name=\"\" type=\"radio\" value=\"1\" checked =\"checked\" />���� <input id=\"girl\" name=\"\" type=\"radio\" value=\"0\" />Ůʿ<span id=\"txt1\"></span></li>       \r\n");
	XYBody.Append("                <li><label>�������䣺<em>*</em></label><input type=\"text\" size=\"25\"  id=\"email\" onblur=\"checkinfo('2');\" onfocus=\"fs('2');\" maxlength =\"50\" /><span  id=\"txt2\"></span></li>\r\n");
	XYBody.Append("                <li><label>�绰���룺</label><input name=\"\" type=\"text\" size=\"25\" id=\"mobile\" onblur=\"checkinfo('11');\" onfocus=\"fs('11');\" maxlength =\"13\"/><span  id=\"txt11\"></span></li>\r\n");
	XYBody.Append("            </ul>\r\n");
	XYBody.Append("            <h3>��������</h3>\r\n");
	XYBody.Append("            <ul>\r\n");
	XYBody.Append("                <li><label>���Ա��⣺<em>*</em></label><input type=\"text\" size=\"60\" id=\"title\" name=\"title\" onblur=\"checkinfo('14');\" onfocus=\"fs('14');\" maxlength =\"100\" /><span  id =\"txt14\"></span><br /><i>�뾡�����ü������ԣ��������20�����֣��������300�����֡�</i></li>\r\n");
	XYBody.Append("                <li><div class=\"left\"><label>�������ݣ�<em>*</em></label> <textarea name=\"neirong\" cols=\"60\" rows=\"5\" id =\"neirong\" onblur=\"checkinfo('15');\" onfocus=\"fs('15');\"></textarea><span  id=\"txt15\"></span></div>\r\n");
	XYBody.Append("                <div class=\"ks\" id=\"ks1\"></div>\r\n");
	XYBody.Append("                </li>\r\n");

	if (config.IsEnabledVCode("message"))
	{

	XYBody.Append("                <li><label >��֤�룺<em>*</em></label>");	XYBody.Append(pageinfo.GetValidateCodeHTML("guestVCode","guestVCodeImg"));	XYBody.Append("</li>   \r\n");

	}	//end if

	XYBody.Append("                <li>\r\n");
	XYBody.Append("                    <input name=\"\" type=\"button\" class=\"button\" value=\"ȷ ��\"  onclick =\"checkmessage();\"/> \r\n");
	XYBody.Append("                    <input type=\"button\" name=\"button\"  class=\"button\" value=\"���\" onclick =\"ykrewrite();\"  />\r\n");
	XYBody.Append("                </li>\r\n");
	XYBody.Append("            </ul>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div> \r\n");
	XYBody.Append("    <div id=\"msg_box2\" style=\"display: block;\">\r\n");
	XYBody.Append("        <div class=\"commentList\">\r\n");
	XYBody.Append("            <ul>\r\n");
	XYBody.Append("                <li><label>���Ա��⣺<em>*</em></label><input type=\"text\" size=\"60\" id=\"txtTitle\" name=\"txtTitle\"  maxlength =\"200\" /></li>\r\n");
	XYBody.Append("                <li><div class=\"left\"><label>�������ݣ�<em>*</em></label> <textarea name=\"txtContent\" cols=\"60\" rows=\"5\" id=\"txtContent\"></textarea></div>\r\n");
	XYBody.Append("                <div class=\"ks\" id=\"ks2\"></div>\r\n");
	XYBody.Append("                </li>\r\n");

	if (config.IsEnabledVCode("message"))
	{

	XYBody.Append("                <li><label>��֤�룺<em>*</em></label>");	XYBody.Append(pageinfo.GetValidateCodeHTML("userVCode","userVCodeImg"));	XYBody.Append("</li>\r\n");

	}	//end if

	XYBody.Append("                <li>\r\n");
	XYBody.Append("                    <input name=\"\" type=\"button\" class=\"button\" value=\"ȷ ��\" onclick =\"checkusermessage();\"/> \r\n");
	XYBody.Append("                    <input type=\"button\" name=\"Submit\"  class=\"button\" value=\"�� ��\"   onclick=\"hrrewrite();\" />\r\n");
	XYBody.Append("                </li>\r\n");
	XYBody.Append("            </ul>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("</form> \r\n");
	XYBody.Append("</div> \r\n");
	XYBody.Append(" <script type=\"text/javascript\" language=\"javascript\">UserMessageInit();</" + "script>\r\n");


	XYBody.Append("		 </form>\r\n");
	XYBody.Append("			<div id=\"SayInfo\">\r\n");
	XYBody.Append("				<strong>��������</strong>��������Ϣ�������ҵ�����ṩ������ҵ������Ϣ���ݵ���ʵ�ԡ�׼ȷ�ԺͺϷ��ԡ�\r\n");
	XYBody.Append("				<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");	XYBody.Append(config.webname);	XYBody.Append("�Դ˲��е��κα�֤���Ρ�\r\n");
	XYBody.Append("			</div>\r\n");
	XYBody.Append("		</div>\r\n");
	XYBody.Append("	    <div id=\"layoutRight\">\r\n");
	XYBody.Append("			<div id=\"content\">\r\n");
	XYBody.Append("                <input type =\"hidden\" id=\"_param_userinfo_parent_module\" value =\"");	XYBody.Append(pageinfo.ModuleFlag);	XYBody.Append("\" />\r\n");
	XYBody.Append("                <input type =\"hidden\" id=\"_param_userinfo_infoid\" value =\"");	XYBody.Append(serviceinfo.InfoID.ToString());	XYBody.Append("\"/>\r\n");
	XYBody.Append("                <input type =\"hidden\" id=\"_param_userinfo_userid\" value =\"");	XYBody.Append(serviceinfo.UserID.ToString());	XYBody.Append("\" />\r\n");

	XYBody.Append("<!--������ʾ��Ϣ--> \r\n");
	XYBody.Append("<div class=\"w290\" id=\"loginuser\" style=\"display:none;\">  \r\n");
	XYBody.Append("    <ul>\r\n");
	XYBody.Append("        <li id=\"loginuseruginfo\"></li>\r\n");
	XYBody.Append("        <li class=\"line\"><a id=\"loginuserurl\" href=\"\" class=\"link14\"></a></li>\r\n");
	XYBody.Append("        <li>��˾��������� <span id=\"ConsummatePercent\"></span></li>\r\n");
	XYBody.Append("        <li><div class=\"cr\"><img id=\"PercentForImg\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/rate.gif\" alt=\" \"  height=\"15px\" /></div></li>\r\n");
	XYBody.Append("        <li><a href=\"#\" id=\"NewOfferPage\">���¹�Ӧ</a> | <a href=\"#\" id=\"GoodFaithFile\">���ŵ���</a> | <a href=\"#\" id=\"UserIntro\">��˾����</a></li>\r\n");
	XYBody.Append("        <li>��ϵ�ˣ�<a href=\"#\" id=\"Contact\"><span id=\"LinkManName\">����</span></a> ���� <span id=\"IMOnline\"></span></li>\r\n");
	XYBody.Append("        <li><hr /></li>\r\n");
	XYBody.Append("        <li>����ʱ�䣺�� <span id=\"loginuseryearnum\"></span> ��</li>\r\n");
	XYBody.Append("        <li> <a href=\"javascript:;\" onclick =\"Favorite();\">�ղش���Ϣ</a> <a href=\"#\" id=\"memessage\">��������</a> <a href=\"#\" id=\"linkme\">��ϵ��ʽ</a></li>  \r\n");
	XYBody.Append("    </ul>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<!--Ҫ���½��鿴-->\r\n");
	XYBody.Append("<div class=\"w290\" id=\"UserNoLogin\" style=\"display:none;\">\r\n");
	XYBody.Append("    <ul class=\"login\">\r\n");
	XYBody.Append("        <li><h4>�Ѿ��ǻ�Ա���½</h4></li>\r\n");
	XYBody.Append("        <li>�û�����<input type=\"text\" name=\"\" tabindex=\"1\"  id=\"username\" name=\"username\" onkeydown =\"KeyDown();\" maxlength=\"50\" /></li>\r\n");
	XYBody.Append("        <li>��&nbsp;&nbsp;&nbsp;�룺<input type =\"password\" maxlength=\"20\" tabindex=\"2\" id=\"password\"  name=\"password\" onkeydown =\"KeyDown();\" /></li>\r\n");

	if (config.IsEnabledVCode("login"))
	{

	XYBody.Append("        <li>��֤�룺");	XYBody.Append(pageinfo.GetValidateCodeHTML());	XYBody.Append("</li>\r\n");

	}	//end if

	XYBody.Append("        <li><input type=\"button\" class=\"button\" value=\"��¼\" onclick=\"return InfoLogin();\"/><a href=\"/GetPassword.");	XYBody.Append(config.Suffix);	XYBody.Append("\">�������룿</a></li>\r\n");
	XYBody.Append("        <li><hr /></li>\r\n");
	XYBody.Append("        <ll>�㻹���ǻ�Ա����<a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("register.");	XYBody.Append(config.Suffix);	XYBody.Append("\">�������ע��</a></li>\r\n");
	XYBody.Append("        <li>\r\n");
	XYBody.Append("            <div class=\"contactus\">\r\n");
	XYBody.Append("                <ul>\r\n");
	XYBody.Append("                <li><h3>�����κ���������������ϵ</h3></li>\r\n");
	XYBody.Append("                <li>���߿ͷ���<img src=\"/templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/kefu.gif\" /> <img src=\"/templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/kefu.gif\" /></li>\r\n");
	XYBody.Append("                <li>�ͻ����ߣ�010-8681 8791</li>\r\n");
	XYBody.Append("                </ul>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </li>      \r\n");
	XYBody.Append("    </ul>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<!--Ҫ��������鿴-->\r\n");
	XYBody.Append("<div class=\"w290\" id=\"loginnouser\" style=\"display:none;\">\r\n");
	XYBody.Append("    <h3><span id=\"loginnouseruginfo\"></span></h3>\r\n");
	XYBody.Append("    <ul class=\"upgrade\">\r\n");
	XYBody.Append("        <li><span>��Ŀǰ���ڵĻ�Ա�飬�޷��鿴��Ϣ��</span></li>\r\n");
	XYBody.Append("        <li><a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("user/postadministratormessage.");	XYBody.Append(config.Suffix);	XYBody.Append("\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/update.gif\" border=\"0\"/></a></li>\r\n");
	XYBody.Append("        <li><a href=\"\">��˲鿴��Ա�ȼ���Ȩ��>></a></li>\r\n");
	XYBody.Append("        <li>\r\n");
	XYBody.Append("            <div class=\"contactus\">\r\n");
	XYBody.Append("                <ul>\r\n");
	XYBody.Append("                <li><h3>�����κ���������������ϵ</h3></li>\r\n");
	XYBody.Append("                <li>���߿ͷ���<img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/kefu.gif\" /> <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/kefu.gif\" /></li>\r\n");
	XYBody.Append("                <li>�ͻ����ߣ�010-8681 8791</li>\r\n");
	XYBody.Append("                </ul>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </li>\r\n");
	XYBody.Append("        <li><a href=\"javascript:;\" onclick =\"Favorite();\">�ղش���Ϣ</a></li>\r\n");
	XYBody.Append("    </ul>\r\n");
	XYBody.Append("</div>  \r\n");


	XYBody.Append("			</div>\r\n");
	XYBody.Append("			<div class=\"MTitle_01\">\r\n");
	XYBody.Append("				<center><a target=\"_blank\" href=\"#\" class=\"red\"><strong>�������ǣ����ܸ������</strong></a></center>\r\n");
	XYBody.Append("			</div>\r\n");
	XYBody.Append("			<div class=\"Mblk_01\">\r\n");
	XYBody.Append("				<div id=\"jointous\">\r\n");
	XYBody.Append("					<ul>\r\n");
	XYBody.Append("						<li><a href=\"\">�� �ύó�׻�飬��չ������Ȧ</a></li>\r\n");
	XYBody.Append("						<li><a href=\"\">�� ��Ϊ��Ա����ѷ���������Ϣ</a></li>\r\n");
	XYBody.Append("						<li><a href=\"\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/btn_gq_reg.gif\" width=\"130\" height=\"29\" alt=\"\" /></a></li>\r\n");
	XYBody.Append("					</ul>\r\n");
	XYBody.Append("				</div>\r\n");
	XYBody.Append("			</div>\r\n");
	XYBody.Append("	</div>\r\n");
	XYBody.Append("	</div>\r\n");



	}	//end if


	XYBody.Append("	<div id=\"footer\">\r\n");
	XYBody.Append("		<a href=\"\">������ҳ</a> | <a href=\"/about/index.htm\" target=\"_blank\">��������</a> | <a href=\"\">��������</a> | <a href=\"\">ý�屨��</a> | <a href=\"\">��ƸӢ��</a> | <a href=\"\">����ר��</a> | <a href=\"\">���ר��</a> | <a href=\"\">��������</a> | <a href=\"\">��ϵ����</a> | <a href=\"\">��վ��ͼ</a>\r\n");
	XYBody.Append("	</div>\r\n");
	XYBody.Append("	<div id=\"copyright\">\r\n");
	XYBody.Append("		<div id=\"copy_info\">\r\n");
	XYBody.Append("			<ul>\r\n");
	XYBody.Append("				<li>Copyright &copy; 2005-2009  &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<a href=\"#\" target=\"_blank\">��ICP��05003331��</a></li>\r\n");
	XYBody.Append("				<li><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/ico_phone.gif\" align=\"absmiddle\">�绰��86-010-62669815 ���棺86-010-86818791  <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/ico_email.gif\" />E-Mail��<a href=\"#\">info@xyecom.com </a></li>\r\n");
	XYBody.Append("				<li>��Ȩ���С��ݺ�������� - ��������С��ҵ��������Ӧ�ü�������δ����Ȩ����ת��</li>\r\n");
	XYBody.Append("			</ul>			\r\n");
	XYBody.Append("		</div>\r\n");
	XYBody.Append("		<div class=\"copyright_i\">\r\n");
	XYBody.Append("		 <div class=\"com copyright_i1\"><p class=\"p\"><a href=\"#\" target=\"_blank\">�������羯�챨��ƽ̨</a></p></div>\r\n");
	XYBody.Append("		 <div class=\"com copyright_i2\"><p class=\"p\">������Ϣ��ȫ������</p></div>\r\n");
	XYBody.Append("		 <div class=\"com copyright_i3\"><p class=\"p\"><a href=\"#\" target=\"_blank\">��Ӫ����վ������Ϣ</a></p></div>\r\n");
	XYBody.Append("		 <div class=\"com copyright_i4\"><p class=\"p\"><a href=\"#\" target=\"_blank\">������Ϣ�ٱ�����</a></p></div>\r\n");
	XYBody.Append("		</div>\r\n");
	XYBody.Append("	 </div>\r\n");


	XYBody.Append("</div>\r\n");
	XYBody.Append("</body>\r\n");
	XYBody.Append("</html>\r\n");

	XYBody.Append(IsCopyright());
	Response.Write(XYBody.ToString());
}
</script>
