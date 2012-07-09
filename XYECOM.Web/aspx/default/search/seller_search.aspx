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


	XYBody.Append("        <div id=\"search_nav\">\r\n");
	XYBody.Append("            <strong>�����ڵ�λ�ã�</strong> ");	XYBody.Append(pageinfo.Navigation);	XYBody.Append("\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <div id=\"search_main\">\r\n");
	XYBody.Append("            <div id=\"left\">\r\n");
	XYBody.Append("                <div class=\"sch_cates\" id=\"xy_PClassList\">\r\n");
	XYBody.Append("                    <h2>\r\n");
	XYBody.Append("                        <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/bg_invest_tit.gif\"\r\n");
	XYBody.Append("                            width=\"12\" height=\"12\" alt=\"\" align=\"absmiddle\" />\r\n");
	XYBody.Append("                        ��Ŀѡ��</h2>\r\n");
	XYBody.Append("                    <div class=\"sch_cnts\" id=\"xy_ClassList\">\r\n");
	XYBody.Append("                    </div>\r\n");
	XYBody.Append("                </div>\r\n");

	if (pageinfo.ModuleFlag=="offer")
	{

	XYBody.Append("                <div class=\"sch_cates\">\r\n");
	XYBody.Append("                    <h2>\r\n");
	XYBody.Append("                        <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/bg_invest_tit.gif\"\r\n");
	XYBody.Append("                            width=\"12\" height=\"12\" alt=\"\" align=\"absmiddle\" />\r\n");
	XYBody.Append("                        ����ѡ��</h2>\r\n");
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
	XYBody.Append("                        <span>ÿҳ��ʾ����:\r\n");
	XYBody.Append("                            <select name=\"pageNum\" id=\"pageNum\" onchange=\"funpagesize(this.options[this.selectedIndex].value);\">\r\n");
	XYBody.Append("                                <option value=\"10\">10</option>\r\n");
	XYBody.Append("                                <option value=\"20\" selected=\"selected\">20</option>\r\n");
	XYBody.Append("                                <option value=\"30\">30</option>\r\n");
	XYBody.Append("                                <option value=\"50\">50</option>\r\n");
	XYBody.Append("                            </select>\r\n");
	XYBody.Append("                        </span><strong class=\"Font14 redLink\">��С��Χ:</strong>\r\n");
	XYBody.Append("                        <label id=\"classType\">\r\n");
	XYBody.Append("                        </label>\r\n");
	XYBody.Append("                        <input type=\"hidden\" id=\"areatypeid\" name=\"areatypeid\" />\r\n");
	XYBody.Append("                        <script type=\"text/javascript\">\r\n");
	XYBody.Append("                            var cla = new ClassType(\"cla\", 'area', 'classType', 'areatypeid', 1);\r\n");
	XYBody.Append("                            cla.Mode = \"select\";\r\n");
	XYBody.Append("                        </" + "script>\r\n");
	XYBody.Append("                        <select name=\"postTime\" id=\"selectlistdid\">\r\n");
	XYBody.Append("                            <option value=\"\">��Ʒ����ʱ��</option>\r\n");
	XYBody.Append("                            <option value=\"1\">��ʾ��������</option>\r\n");
	XYBody.Append("                            <option value=\"3\">��ʾ���3��</option>\r\n");
	XYBody.Append("                            <option value=\"5\">��ʾ���5��</option>\r\n");
	XYBody.Append("                            <option value=\"7\">��ʾ���7��</option>\r\n");
	XYBody.Append("                            <option value=\"15\">��ʾ���15��</option>\r\n");
	XYBody.Append("                            <option value=\"30\">��ʾ���30��</option>\r\n");
	XYBody.Append("                            <option value=\"60\">��ʾ���60��</option>\r\n");
	XYBody.Append("                            <option value=\"180\">��ʾ�������</option>\r\n");
	XYBody.Append("                            <option value=\"1000\">��ʾ���в�Ʒ</option>\r\n");
	XYBody.Append("                        </select>\r\n");
	XYBody.Append("                        <input type=\"text\" size=\"8\" id=\"txtkeyword\" onkeydown=\"listSearchKeyDown();\" />\r\n");
	XYBody.Append("                        <input type=\"button\" name=\"Submit\" value=\"ɸѡ\" onclick=\"listsearch()\" />\r\n");
	XYBody.Append("                    </div>\r\n");
	XYBody.Append("                    <div id=\"FilterDivB\">\r\n");
	XYBody.Append("                        <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	XYBody.Append("                            <tr>\r\n");
	XYBody.Append("                                <!--ֻ����ҵ��Ϣ�Աȹ��ܲ���ʹ��-->\r\n");

	if (pageinfo.ModuleFlag=="offer"||pageinfo.ModuleFlag=="venture"||pageinfo.ModuleFlag=="investment"||pageinfo.ModuleFlag=="service")
	{

	XYBody.Append("                                <td width=\"4%\" style=\"padding-left: 4px;\">\r\n");
	XYBody.Append("                                    <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/list_than.gif\" width=\"13\"\r\n");
	XYBody.Append("                                        height=\"13\" />\r\n");
	XYBody.Append("                                </td>\r\n");
	XYBody.Append("                                <td width=\"14%\">\r\n");
	XYBody.Append("                                    <input type=\"button\" value=\"�ԱȲ�Ʒ\" onclick=\"compareinfo();\" />\r\n");
	XYBody.Append("                                </td>\r\n");

	}	//end if

	XYBody.Append("                                <td width=\"51%\">\r\n");
	XYBody.Append("                                    <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/list_Order_icon.gif\" /><a\r\n");
	XYBody.Append("                                        href=\"javascript:void(null);\" onclick=\"xy_setOrder('');\">Ĭ������</a>&nbsp;\r\n");
	XYBody.Append("                                    <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/list_Order_icon.gif\" /><a\r\n");
	XYBody.Append("                                        href=\"javascript:void(null);\" onclick=\"xy_setOrder('grade');\">����Ա����</a>&nbsp;\r\n");
	XYBody.Append("                                    <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/list_Order_icon.gif\" /><a\r\n");
	XYBody.Append("                                        href=\"javascript:void(null);\" onclick=\"xy_setOrder('time');\">������ʱ��</a>&nbsp;\r\n");
	XYBody.Append("                                    <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/list_Order_icon.gif\" /><a\r\n");
	XYBody.Append("                                        href=\"javascript:void(null);\" onclick=\"xy_setOrder('active');\">����Ծ��</a>\r\n");
	XYBody.Append("                                </td>\r\n");
	XYBody.Append("                                <td width=\"31%\" align=\"right\">\r\n");
	XYBody.Append("                                    <a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("keyword/\" class=\"orange\" target=\"_blank\">����̶�����,�����Ĳ�Ʒ����ǰ��λ</a>\r\n");
	XYBody.Append("                                </td>\r\n");
	XYBody.Append("                            </tr>\r\n");
	XYBody.Append("                        </table>\r\n");
	XYBody.Append("                    </div>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <!--����Ҫ������ɾ��-->\r\n");
	XYBody.Append("                <input type=\"hidden\" id=\"orderby\" value=\"\" />\r\n");
	XYBody.Append("                <input type=\"hidden\" id=\"hidmoduleflag\" value=\"");	XYBody.Append(pageinfo.ModuleFlag);	XYBody.Append("\" />\r\n");
	XYBody.Append("                <script language=\"javascript\">\r\n");
	XYBody.Append("                    window.onload = function () {\r\n");
	XYBody.Append("                        ");	XYBody.Append(pageinfo.OnLoadEvents);	XYBody.Append("\r\n");
	XYBody.Append("                    }\r\n");
	XYBody.Append("                </" + "script>\r\n");
	XYBody.Append("                <!--������Ϣ-->\r\n");
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

	XYBody.Append("                <!--�ӹ���Ϣ-->\r\n");

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

	XYBody.Append("                <!--������Ϣ-->\r\n");

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

	XYBody.Append("                <!--������Ϣ-->\r\n");

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

	XYBody.Append("                <!--չ����Ϣ-->\r\n");

	if (pageinfo.ModuleFlag=="exhibition")
	{

	XYBody.Append("                <div id=\"ProDiv\">\r\n");
	XYBody.Append("                    " +  XYECOMCreateHTML("XY_ExhibitionList").ToString() + "\r\n");
	XYBody.Append("                </div>\r\n");

	}	//end if

	XYBody.Append("                <!--Ʒ����Ϣ-->\r\n");

	if (pageinfo.ModuleFlag=="brand")
	{

	XYBody.Append("                <div id=\"ProDiv\">\r\n");
	XYBody.Append("                    " +  XYECOMCreateHTML("XY_BrandList").ToString() + "\r\n");
	XYBody.Append("                </div>\r\n");

	}	//end if

	XYBody.Append("                <!--��ҵ��Ϣ-->\r\n");

	if (pageinfo.ModuleFlag=="company")
	{

	XYBody.Append("                <div id=\"ProDiv\">\r\n");
	XYBody.Append("                    " +  XYECOMCreateHTML("XY_CompanyList").ToString() + "\r\n");
	XYBody.Append("                </div>\r\n");

	}	//end if

	XYBody.Append("                <!--��ͨ�б����-->\r\n");
	XYBody.Append("                <div id=\"ProFind\">\r\n");
	XYBody.Append("                    <strong class=\"orange\">��û���ҵ����ʵĲ�Ʒ?</strong> �Ͽ�<a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("user/\" target=\"_blank\">��������Ϣ</a>���ù�Ӧ��������������</div>\r\n");
	XYBody.Append("                <div id=\"ProThan\">\r\n");
	XYBody.Append("                    <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	XYBody.Append("                        <tr>\r\n");
	XYBody.Append("                            <!--ֻ����ҵ��Ϣ�Աȹ��ܲ���ʹ��-->\r\n");

	if (pageinfo.ModuleFlag=="offer"||pageinfo.ModuleFlag=="venture"||pageinfo.ModuleFlag=="investment"||pageinfo.ModuleFlag=="service")
	{

	XYBody.Append("                            <td width=\"4%\" style=\"padding-left: 4px;\">\r\n");
	XYBody.Append("                                <span style=\"padding-left: 4px;\">\r\n");
	XYBody.Append("                                    <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/list_than.gif\" width=\"13\"\r\n");
	XYBody.Append("                                        height=\"13\" /></span>\r\n");
	XYBody.Append("                            </td>\r\n");
	XYBody.Append("                            <td width=\"57%\">\r\n");
	XYBody.Append("                                <input type=\"button\" value=\"�ԱȲ�Ʒ\" onclick=\"compareinfo();\" />\r\n");
	XYBody.Append("                            </td>\r\n");

	}	//end if

	XYBody.Append("                        </tr>\r\n");
	XYBody.Append("                    </table>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                </form>\r\n");
	XYBody.Append("                <div id=\"splitPage\">\r\n");
	XYBody.Append("                    <div id=\"Pages\">\r\n");
	XYBody.Append("                        ");	XYBody.Append(pageinfo.PreviousPage);	XYBody.Append("");	XYBody.Append(pageinfo.NumPage);	XYBody.Append("");	XYBody.Append(pageinfo.NextPage);	XYBody.Append(" &nbsp;&nbsp;&nbsp;\r\n");
	XYBody.Append("                        ֱ��ת��&nbsp;\r\n");
	XYBody.Append("                        <input name=\"pageformat\" type=\"hidden\" value=\".html\">\r\n");
	XYBody.Append("                        <input name=\"page\" id=\"cpage\" size=\"3\" maxlength=\"3\" style=\"height: 13px;\" value=\"");	XYBody.Append(pageinfo.PageIndex);	XYBody.Append("\">&nbsp;ҳ&nbsp;\r\n");
	XYBody.Append("                        <input type=\"submit\" value=\"ȷ��>>\" style=\"height: 20px;\" onclick=\"xy_GoToPage(cpage.value);\">\r\n");
	XYBody.Append("                        <input type=\"hidden\" id=\"totalPage\" value=\"");	XYBody.Append(pageinfo.PageCount);	XYBody.Append("\" />\r\n");
	XYBody.Append("                    </div>\r\n");
	XYBody.Append("                    <span style=\"font-size: 14px;\">�� <strong class=\"orange\">");	XYBody.Append(pageinfo.TotalRecord);	XYBody.Append("</strong>\r\n");
	XYBody.Append("                        ����¼&nbsp;&nbsp;&nbsp;��ǰΪ�� <strong class=\"orange\">");	XYBody.Append(pageinfo.PageIndex);	XYBody.Append("</strong> ҳ&nbsp;&nbsp;&nbsp;��\r\n");
	XYBody.Append("                        <strong class=\"orange\">");	XYBody.Append(pageinfo.PageCount);	XYBody.Append("</strong> ҳ&nbsp;&nbsp;&nbsp;</span>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <!-- ������ -->\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("            <div id=\"right\">\r\n");
	XYBody.Append("                <div class=\"MTitle_01\">\r\n");
	XYBody.Append("                    <center>\r\n");
	XYBody.Append("                        <a target=\"_blank\" href=\"#\" class=\"red big\"><strong>�ƽ�չλ</strong></a></center>\r\n");
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
	XYBody.Append("                        <a target=\"_blank\" href=\"#\"><strong>�����ƹ��ҵĲ�Ʒ��</strong></a></h2>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <div id=\"con01\" class=\"Mblk_01\">\r\n");
	XYBody.Append("                    <div class=\"com_pages\">\r\n");
	XYBody.Append("                        <ul>\r\n");
	XYBody.Append("                            <li><a target=\"_blank\" href=\"#\">�����������H1N1����</a></li>\r\n");
	XYBody.Append("                            <li><a target=\"_blank\" href=\"#\">�����γ�ϯ�ϺϷ��</a></li>\r\n");
	XYBody.Append("                            <li><a target=\"_blank\" href=\"#\">���ʴ�ѡ�������ֶ���</a></li>\r\n");
	XYBody.Append("                            <li><a target=\"_blank\" href=\"#\">�ɶ�����������ȼ��</a></li>\r\n");
	XYBody.Append("                            <li><a target=\"_blank\" href=\"#\">�����տ�A330�ͻ�׹��</a></li>\r\n");
	XYBody.Append("                            <li><a target=\"_blank\" href=\"#\">�ɶ�����������ȼ��</a></li>\r\n");
	XYBody.Append("                            <li><a target=\"_blank\" href=\"#\">�����տ�A330�ͻ�׹��</a></li>\r\n");
	XYBody.Append("                        </ul>\r\n");
	XYBody.Append("                    </div>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <div class=\"MTitle_01\">\r\n");
	XYBody.Append("                    <h2 id=\"h2_1\" class=\"\">\r\n");
	XYBody.Append("                        <a target=\"_blank\" href=\"#\"><strong>չ�Ἴ��</strong></a></h2>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <div id=\"Div1\" class=\"Mblk_01\">\r\n");
	XYBody.Append("                    <div class=\"com_pages\">\r\n");
	XYBody.Append("                        <ul>\r\n");
	XYBody.Append("                            <li><a target=\"_blank\" href=\"#\">�����������H1N1����</a></li>\r\n");
	XYBody.Append("                            <li><a target=\"_blank\" href=\"#\">�����γ�ϯ�ϺϷ��</a></li>\r\n");
	XYBody.Append("                            <li><a target=\"_blank\" href=\"#\">���ʴ�ѡ�������ֶ���</a></li>\r\n");
	XYBody.Append("                            <li><a target=\"_blank\" href=\"#\">�ɶ�����������ȼ��</a></li>\r\n");
	XYBody.Append("                            <li><a target=\"_blank\" href=\"#\">�����տ�A330�ͻ�׹��</a></li>\r\n");
	XYBody.Append("                            <li><a target=\"_blank\" href=\"#\">�ɶ�����������ȼ��</a></li>\r\n");
	XYBody.Append("                            <li><a target=\"_blank\" href=\"#\">�����տ�A330�ͻ�׹��</a></li>\r\n");
	XYBody.Append("                        </ul>\r\n");
	XYBody.Append("                    </div>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("            <div class=\"clr\">\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </div>\r\n");

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


	XYBody.Append("    </div>\r\n");
	XYBody.Append("</body>\r\n");
	XYBody.Append("</html>\r\n");

	XYBody.Append(IsCopyright());
	Response.Write(XYBody.ToString());
}
</script>
