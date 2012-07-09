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

	XYBody.Append("        var endtime = new Date('");	XYBody.Append(enddate.ToString());	XYBody.Append("'); // ��������  \r\n");
	XYBody.Append("        var thisTime = new Date('");	XYBody.Append(now.ToString());	XYBody.Append("'); // ��ǰ������ʱ�� \r\n");
	XYBody.Append("        var nowtime = thisTime.getTime(); // ��������ǰʱ���ܵ�����  \r\n");
	XYBody.Append("        var leftsecond = 0;\r\n");
	XYBody.Append("        var sh;\r\n");
	XYBody.Append("        function _fresh() {\r\n");
	XYBody.Append("            nowtime = nowtime + 1000; //���1�룬�����1000  \r\n");
	XYBody.Append("            leftsecond = parseInt((endtime.getTime() - nowtime) / 1000);\r\n");
	XYBody.Append("            __d = parseInt(leftsecond / 3600 / 24) <= 9 ? +\"0\" + parseInt(leftsecond / 3600 / 24).toString() : parseInt(leftsecond / 3600 / 24);\r\n");
	XYBody.Append("            __h = parseInt((leftsecond / 3600) % 24) <= 9 ? +\"0\" + parseInt((leftsecond / 3600) % 24).toString() : parseInt((leftsecond / 3600) % 24);\r\n");
	XYBody.Append("            __m = parseInt((leftsecond / 60) % 60) <= 9 ? +\"0\" + parseInt((leftsecond / 60) % 60).toString() : parseInt((leftsecond / 60) % 60);\r\n");
	XYBody.Append("            __s = parseInt(leftsecond % 60) <= 9 ? +\"0\" + parseInt(leftsecond % 60).toString() : parseInt(leftsecond % 60);\r\n");
	XYBody.Append("            $(\"#clearInterval\").html(\"\" + __d + \"��\" + __h + \"ʱ\" + __m + \"��\" + __s + \"��\");\r\n");
	XYBody.Append("            if (leftsecond <= 0) {\r\n");
	XYBody.Append("                $(\"#clearInterval\").html(\"�ؼ��ѽ���\");\r\n");
	XYBody.Append("                $(\"#orderbuy\").html(\"�ؼ��ѽ���\");\r\n");
	XYBody.Append("                clearInterval(sh);\r\n");
	XYBody.Append("            }\r\n");
	XYBody.Append("        }\r\n");
	XYBody.Append("        _fresh()\r\n");
	XYBody.Append("        sh = setInterval(_fresh, 1000);\r\n");

	}
	else
	{

	XYBody.Append("            $(\"#orderbuy\").html(\"�u����\");\r\n");
	XYBody.Append("            $(\"#clearInterval\").html(\"�ؼ��ѽ���\");                \r\n");

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


	XYBody.Append("        <div id=\"main\">\r\n");
	XYBody.Append("            <!--left start-->\r\n");
	XYBody.Append("            <div class=\"i_fl\">\r\n");
	XYBody.Append("                <!-- ��Ʒ������ -->\r\n");
	XYBody.Append("                <div class=\"main\">\r\n");
	XYBody.Append("                    <h2>\r\n");
	XYBody.Append("                        <span class=\"c2\">�����Ź���</span>");	XYBody.Append(tbinfo.Title.ToString());	XYBody.Append("</h2>\r\n");
	XYBody.Append("                    <div class=\"mmain\">\r\n");
	XYBody.Append("                        <div class=\"lmain\">\r\n");
	XYBody.Append("                            <table class=\"discount\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	XYBody.Append("                                <tbody>\r\n");
	XYBody.Append("                                    <tr>\r\n");
	XYBody.Append("                                        <th>\r\n");
	XYBody.Append("                                            ԭ��\r\n");
	XYBody.Append("                                        </th>\r\n");
	XYBody.Append("                                        <th>\r\n");
	XYBody.Append("                                            �ۿ�\r\n");
	XYBody.Append("                                        </th>\r\n");
	XYBody.Append("                                        <th>\r\n");
	XYBody.Append("                                            ��ʡ\r\n");
	XYBody.Append("                                        </th>\r\n");
	XYBody.Append("                                    </tr>\r\n");
	XYBody.Append("                                    <tr>\r\n");
	XYBody.Append("                                        <td>\r\n");
	XYBody.Append("                                            ��");	XYBody.Append(tbinfo.MarketPrice.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                                        </td>\r\n");
	XYBody.Append("                                        <td>\r\n");
	XYBody.Append("                                            ");	XYBody.Append(tbinfo.Discount.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                                        </td>\r\n");
	XYBody.Append("                                        <td>\r\n");
	XYBody.Append("                                            <span class=\"c2\">��");	XYBody.Append(tbinfo.Saved.ToString());	XYBody.Append("</span>\r\n");
	XYBody.Append("                                        </td>\r\n");
	XYBody.Append("                                    </tr>\r\n");
	XYBody.Append("                                </tbody>\r\n");
	XYBody.Append("                            </table>\r\n");
	XYBody.Append("                            <div class=\"buyinfo\">\r\n");
	XYBody.Append("                                <p class=\"buynum\">\r\n");
	XYBody.Append("                                    <span class=\"c2\">");	XYBody.Append(tbinfo.CurrentJoin.ToString());	XYBody.Append("</span>���ѹ���<br />\r\n");
	XYBody.Append("                                    �������ޣ��µ�Ҫ��Ӵ</p>\r\n");
	XYBody.Append("                                <p class=\"timeleft\">\r\n");
	XYBody.Append("                                    ���뱾���Ź��������У�<br />\r\n");
	XYBody.Append("                                    <span id=\"clearInterval\" class=\"showTime\"></span>\r\n");
	XYBody.Append("                                </p>\r\n");
	XYBody.Append("                                <p class=\"waiting\">\r\n");
	XYBody.Append("                                    ����������");	XYBody.Append(tbinfo.SucPeopleNum.ToString());	XYBody.Append(",��ǰ���룺");	XYBody.Append(tbinfo.CurrentJoin.ToString());	XYBody.Append("��Ч����(");	XYBody.Append(tbinfo.EndDate.ToString());	XYBody.Append(")\r\n");
	XYBody.Append("                                </p>\r\n");

	if (tbinfo.CurrentJoin>=tbinfo.SucPeopleNum)
	{

	XYBody.Append("                                <p class=\"success\">\r\n");
	XYBody.Append("                                    �Ź��ѳɹ����ɼ�������</p>\r\n");

	}
	else
	{

	XYBody.Append("                                <p class=\"failed\">\r\n");
	XYBody.Append("                                    �������㣬���ܳ���</p>\r\n");

	}	//end if

	XYBody.Append("                                <p class=\"failed\" style=\"display: none;\">\r\n");
	XYBody.Append("                                    ������</p>\r\n");
	XYBody.Append("                            </div>\r\n");
	XYBody.Append("                            <div class=\"order buy\" id=\"orderbuy\">\r\n");
	XYBody.Append("                                <a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("MyTeamOrder.");	XYBody.Append(config.suffix);	XYBody.Append("?teamId=");	XYBody.Append(tbinfo.Id.ToString());	XYBody.Append("\">����</a><em>��");	XYBody.Append(tbinfo.CurrentPrice.ToString());	XYBody.Append("</em></div>\r\n");
	XYBody.Append("                            <input type=\"hidden\" name=\"IsOverflag\" value='");	XYBody.Append(flag.ToString());	XYBody.Append("' />\r\n");
	XYBody.Append("                        </div>\r\n");
	XYBody.Append("                        <div class=\"rmain\">\r\n");
	XYBody.Append("                            <img src=\"");	XYBody.Append(tbinfo.ImagePath.ToString());	XYBody.Append("\" width=\"440\" height=\"267\" alt=\"\" />\r\n");
	XYBody.Append("                            <div class=\"buytips\">\r\n");
	XYBody.Append("                                <div class=\"quote\">\r\n");
	XYBody.Append("                                    <span style=\"color: #333333\">�� ���ֿ�ʽ��������ʽ��ѡ<br />\r\n");
	XYBody.Append("                                        �� ��˹�ص��⣬��֮ͯ��ѡ<br />\r\n");
	XYBody.Append("                                        �� ����������������ͻ�</span></div>\r\n");
	XYBody.Append("                            </div>\r\n");
	XYBody.Append("                        </div>\r\n");
	XYBody.Append("                        <div class=\"clear\">\r\n");
	XYBody.Append("                        </div>\r\n");
	XYBody.Append("                    </div>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <!-- ��Ʒ������ end -->\r\n");
	XYBody.Append("                <!-- ��Ʒ���� -->\r\n");
	XYBody.Append("                <div class=\"xq\">\r\n");
	XYBody.Append("                    <ul class=\"xqlist c3\">\r\n");
	XYBody.Append("                        <li class=\"cur\"><a>��Ʒ����</a></li></ul>\r\n");
	XYBody.Append("                    <div class=\"details\">\r\n");
	XYBody.Append("                        ");	XYBody.Append(tbinfo.Description.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                    </div>\r\n");
	XYBody.Append("                    <div class=\"buy-bottom\">\r\n");
	XYBody.Append("                        <dl class=\"item-prices\">\r\n");
	XYBody.Append("                            <dt class=\"price\">ԭ ��</dt>\r\n");
	XYBody.Append("                            <dt class=\"juprice\">�� ��</dt>\r\n");
	XYBody.Append("                            <dt class=\"save\">�� ʡ</dt>\r\n");
	XYBody.Append("                            <dd class=\"price\">\r\n");
	XYBody.Append("                                <del>��");	XYBody.Append(tbinfo.MarketPrice.ToString());	XYBody.Append("</del></dd>\r\n");
	XYBody.Append("                            <dd class=\"juprice\">\r\n");
	XYBody.Append("                                ");	XYBody.Append(tbinfo.Discount.ToString());	XYBody.Append("</dd>\r\n");
	XYBody.Append("                            <dd class=\"save\">\r\n");
	XYBody.Append("                                ��");	XYBody.Append(tbinfo.Saved.ToString());	XYBody.Append("</dd>\r\n");
	XYBody.Append("                        </dl>\r\n");
	XYBody.Append("                        <!-- ����ť -->\r\n");
	XYBody.Append("                        <div class=\"item-buy avil\">\r\n");
	XYBody.Append("                            �۸�<span>");	XYBody.Append(tbinfo.CurrentPrice.ToString());	XYBody.Append("</span> <strong class=\"J_juPrices\"><b>��</b>");	XYBody.Append(tbinfo.CurrentPrice.ToString());	XYBody.Append("</strong>\r\n");
	XYBody.Append("                            <form id=\"frmjointeam\" method=\"post\" action=\"/common/initcart.");	XYBody.Append(config.suffix);	XYBody.Append("\">\r\n");
	XYBody.Append("                            <input type=\"hidden\" name=\"count\" value=\"1\" />\r\n");
	XYBody.Append("                            <input value=\"");	XYBody.Append(tbinfo.ProductId.ToString());	XYBody.Append("\" type=\"hidden\" name=\"pid\" />\r\n");
	XYBody.Append("                            <input value=\"");	XYBody.Append(tbinfo.Id.ToString());	XYBody.Append("\" type=\"hidden\" name=\"teamid\" />\r\n");
	XYBody.Append("                            <input type=\"image\" class=\"buy\" title=\"����\" />\r\n");
	XYBody.Append("                            </form>\r\n");
	XYBody.Append("                        </div>\r\n");
	XYBody.Append("                    </div>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <!-- ��Ʒ���� end -->\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("            <!--left end-->\r\n");
	XYBody.Append("            <!--right start-->\r\n");
	XYBody.Append("            <div class=\"i_fr\">\r\n");
	XYBody.Append("                <div id=\"plist\" class=\"rbox\">\r\n");
	XYBody.Append("                    <h3>\r\n");
	XYBody.Append("                        ���������Ź�</h3>\r\n");
	XYBody.Append("                    <ul>\r\n");
	XYBody.Append("                        <li>\r\n");
	XYBody.Append("                            <h2>\r\n");
	XYBody.Append("                                <a title=\"��12Ԫ��ԭ��50Ԫ�����Ŷ�ͯ��԰��Ʊ1�ţ�1λ����+1λ��ͬ�ҳ�����5��ͨ��\" href=\"#\">\r\n");
	XYBody.Append("                                    <img alt=\"\" src=\"/templates/_shop/store/images/n_11377854508036.jpg\" width=\"210\"\r\n");
	XYBody.Append("                                        height=\"142\">��12Ԫ��ԭ��50Ԫ�����Ŷ�ͯ��԰��Ʊ1�ţ�1λ����+1λ��ͬ�ҳ�����5��ͨ��</a></h2>\r\n");
	XYBody.Append("                            <p>\r\n");
	XYBody.Append("                                <a href=\"#\">ȥ����</a>�Ź��ۣ�<span>12</span></p>\r\n");
	XYBody.Append("                        </li>\r\n");
	XYBody.Append("                        <li>\r\n");
	XYBody.Append("                            <h2>\r\n");
	XYBody.Append("                                <a title=\"��43Ԫ/75Ԫ/86Ԫ��ԭ��90Ԫ/156Ԫ/178Ԫ�����3�ֿ�ζ���Ӵ����\" href=\"#\">\r\n");
	XYBody.Append("                                    <img alt=\"\" src=\"/templates/_shop/store/images/n_11160666832132.jpg\" width=\"210\"\r\n");
	XYBody.Append("                                        height=\"142\">��43Ԫ/75Ԫ/86Ԫ��ԭ��90Ԫ/156Ԫ/178Ԫ�����3�ֿ�ζ���Ӵ����</a></h2>\r\n");
	XYBody.Append("                            <p>\r\n");
	XYBody.Append("                                <a href=\"#\">ȥ����</a>�Ź��ۣ�<span>43</span></p>\r\n");
	XYBody.Append("                        </li>\r\n");
	XYBody.Append("                        <li>\r\n");
	XYBody.Append("                            <h2>\r\n");
	XYBody.Append("                                <a title=\"��29Ԫ��ԭ��198Ԫ��װ��ͯͼ�飨3����ѡ��1�����;�����а�װ�����ޱ�������\" href=\"#\">\r\n");
	XYBody.Append("                                    <img alt=\"\" src=\"/templates/_shop/store/images/n_11317794891524.jpg\" width=\"210\"\r\n");
	XYBody.Append("                                        height=\"142\">��29Ԫ��ԭ��198Ԫ��װ��ͯͼ�飨3����ѡ��1�����;�����а�װ�����ޱ�������</a></h2>\r\n");
	XYBody.Append("                            <p>\r\n");
	XYBody.Append("                                <a href=\"#\">ȥ����</a>�Ź��ۣ�<span>29</span></p>\r\n");
	XYBody.Append("                        </li>\r\n");
	XYBody.Append("                        <li>\r\n");
	XYBody.Append("                            <h2>\r\n");
	XYBody.Append("                                <a title=\"��19Ԫ/5�ԭ��50Ԫ/5������԰��ժ���Żݣ���һ�����ʲ�ժ������ԤԼ\" href=\"#\">\r\n");
	XYBody.Append("                                    <img alt=\"\" src=\"/templates/_shop/store/images/n_11227208592388.jpg\" width=\"210\"\r\n");
	XYBody.Append("                                        height=\"142\">��19Ԫ/5�ԭ��50Ԫ/5������԰��ժ���Żݣ���һ�����ʲ�ժ������ԤԼ</a></h2>\r\n");
	XYBody.Append("                            <p>\r\n");
	XYBody.Append("                                <a href=\"#\">ȥ����</a>�Ź��ۣ�<span>19</span></p>\r\n");
	XYBody.Append("                        </li>\r\n");
	XYBody.Append("                        <li>\r\n");
	XYBody.Append("                            <h2>\r\n");
	XYBody.Append("                                <a title=\"��9Ԫ��ԭ��792Ԫ���������ٶ�Ӣ����˫���޵д����,5��ѧϰ����ͨ��\" href=\"#\">\r\n");
	XYBody.Append("                                    <img alt=\"\" src=\"/templates/_shop/store/images/n_11297475728900.jpg\" width=\"210\"\r\n");
	XYBody.Append("                                        height=\"142\">��9Ԫ��ԭ��792Ԫ���������ٶ�Ӣ����˫���޵д����,5��ѧϰ����ͨ��</a></h2>\r\n");
	XYBody.Append("                            <p>\r\n");
	XYBody.Append("                                <a href=\"#\">ȥ����</a>�Ź��ۣ�<span>9</span></p>\r\n");
	XYBody.Append("                        </li>\r\n");
	XYBody.Append("                        <li>\r\n");
	XYBody.Append("                            <h2>\r\n");
	XYBody.Append("                                <a title=\"��388Ԫ��ԭ��755Ԫ���꽡������ײͣ������Ժͨ�ã�\" href=\"#\">\r\n");
	XYBody.Append("                                    <img alt=\"\" src=\"/templates/_shop/store/images/n_11275221331972.jpg\" width=\"210\"\r\n");
	XYBody.Append("                                        height=\"142\">��388Ԫ��ԭ��755Ԫ���꽡������ײͣ������Ժͨ�ã�</a></h2>\r\n");
	XYBody.Append("                            <p>\r\n");
	XYBody.Append("                                <a href=\"#\">ȥ����</a>�Ź��ۣ�<span>388</span></p>\r\n");
	XYBody.Append("                        </li>\r\n");
	XYBody.Append("                        <li>\r\n");
	XYBody.Append("                            <h2>\r\n");
	XYBody.Append("                                <a title=\"��499Ԫ��ԭ��3680Ԫ�ݻ���ͯ��Ӱ�ײͣ�ϲӭ����һ����3��ͨ�ã�\" href=\"#\">\r\n");
	XYBody.Append("                                    <img alt=\"\" src=\"/templates/_shop/store/images/n_11271905270788.jpg\" width=\"210\"\r\n");
	XYBody.Append("                                        height=\"142\">��499Ԫ��ԭ��3680Ԫ�ݻ���ͯ��Ӱ�ײͣ�ϲӭ����һ����3��ͨ�ã�</a></h2>\r\n");
	XYBody.Append("                            <p>\r\n");
	XYBody.Append("                                <a href=\"#\">ȥ����</a>�Ź��ۣ�<span>499</span></p>\r\n");
	XYBody.Append("                        </li>\r\n");
	XYBody.Append("                        <li>\r\n");
	XYBody.Append("                            <h2>\r\n");
	XYBody.Append("                                <a title=\"��59Ԫ��ԭ��99Ԫ���������⹾������Թ�ţ��2ѡ1����7��ͨ��\" href=\"#\">\r\n");
	XYBody.Append("                                    <img alt=\"\" src=\"/templates/_shop/store/images/n_11274815611908.jpg\" width=\"210\"\r\n");
	XYBody.Append("                                        height=\"142\">��59Ԫ��ԭ��99Ԫ���������⹾������Թ�ţ��2ѡ1����7��ͨ��</a></h2>\r\n");
	XYBody.Append("                            <p>\r\n");
	XYBody.Append("                                <a href=\"#\">ȥ����</a>�Ź��ۣ�<span>59</span></p>\r\n");
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


	XYBody.Append("</body>\r\n");
	XYBody.Append("</html>\r\n");

	XYBody.Append(IsCopyright());
	Response.Write(XYBody.ToString());
}
</script>
