<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.shop.contact,XYECOM.Page" %>
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

	XYBody.Append("<title>");	XYBody.Append(shopuserinfo.unitname.ToString());	XYBody.Append("</title>\r\n");
	XYBody.Append("<meta content=\"");	XYBody.Append(shopuserinfo.unitname.ToString());	XYBody.Append("������");	XYBody.Append(shopuserinfo.regyear.ToString());	XYBody.Append("��,λ��");	XYBody.Append(shopuserinfo.areaname.ToString());	XYBody.Append("\" name=\"description\"/>\r\n");
	XYBody.Append("<meta content=\"");	XYBody.Append(shopuserinfo.unitname.ToString());	XYBody.Append("\" name=\"keywords\"/>\r\n");
	XYBody.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=gb2312\">\r\n");
	XYBody.Append("<link rel=\"stylesheet\" href=\"/common/css/XYLib.css\" type=\"text/css\" media=\"screen\" />\r\n");
	XYBody.Append("<link href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/_shop/skins_2009/");	XYBody.Append(shopuserinfo.template.ToString());	XYBody.Append("/css/Style.css\" type=\"text/css\" rel=\"stylesheet\">\r\n");
	XYBody.Append("<script type=\"text/javascript\" src=\"/common/js/base.js\" language=\"javascript\"></" + "script>\r\n");
	XYBody.Append("<script type=\"text/javascript\" src=\"/templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/js/login.js\" language=\"javascript\"></" + "script>\r\n");
	XYBody.Append("<script type=\"text/javascript\" src=\"/templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/js/validate.js\" language=\"javascript\"></" + "script>\r\n");


	XYBody.Append("</head>\r\n");
	XYBody.Append("<body  onload=\"");	XYBody.Append(pageinfo.OnLoadEvents);	XYBody.Append("\">\r\n");

	XYBody.Append("    <div class=\"glass\">\r\n");
	XYBody.Append("        <ul>\r\n");
	 str = GetLinkPrefix();
	
	XYBody.Append("        <li class=\"glass_left\">\r\n");
	XYBody.Append("            <a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("\" target=_blank>");	XYBody.Append(config.webname);	XYBody.Append(" </a>| \r\n");
	XYBody.Append("            <a onclick=\"javascript:this.style.behavior='url(#default#homepage)';this.setHomePage('");	XYBody.Append(str.ToString());	XYBody.Append("');\"   href=\"#\" target=\"_self\">��Ϊ��ҳ</a> |\r\n");
	XYBody.Append("            <a href=\"javascript:window.external.addFavorite('");	XYBody.Append(str.ToString());	XYBody.Append("','");	XYBody.Append(shopuserinfo.unitname.ToString());	XYBody.Append("')\">��ӵ��ղؼ�</a> \r\n");
	XYBody.Append("        </li>\r\n");
	XYBody.Append("        <li class=\"glass_right\">\r\n");
	XYBody.Append("            ");	XYBody.Append(pageinfo.LoginStatus);	XYBody.Append(" | \r\n");
	XYBody.Append("            <a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("user\">������Ʒ��Ϣ</a> | \r\n");
	XYBody.Append("            <a href=\"http://www.yylm.org/contents/859/11418.html\" target=\"_blank\">��ϵ����</a>\r\n");
	XYBody.Append("        </li>\r\n");
	XYBody.Append("        </ul>\r\n");
	XYBody.Append("    </div>\r\n");


	XYBody.Append("    <div class=layout950_100 style=\"BACKGROUND-IMAGE: url(");	XYBody.Append(config.WebURL);	XYBody.Append("templates/_shop/skins_2009/");	XYBody.Append(shopuserinfo.template.ToString());	XYBody.Append("/images/stylebg1.jpg)\">\r\n");

	XYBody.Append("    <div class=\"head\" id=DIV1>\r\n");

	if (shopuserinfo.logo!="")
	{

	XYBody.Append("            <div class=\"logo\"><IMG src=\"");	XYBody.Append(shopuserinfo.logo.ToString());	XYBody.Append("\" onload='SetImgSize(this,60,60);' ></div>\r\n");

	}	//end if

	XYBody.Append("        <h1>");	XYBody.Append(shopuserinfo.unitname.ToString());	XYBody.Append("</h1>\r\n");
	XYBody.Append("        <p>��Ӫ��Ʒ��");	XYBody.Append(shopuserinfo.supplypro.ToString());	XYBody.Append("</p>\r\n");
	XYBody.Append("        <div class=\"gold_year\">\r\n");
	XYBody.Append("            <div class=\"gold_wz\">\r\n");
	XYBody.Append("                <table cellSpacing=\"0\" cellPadding=\"0\" width=\"100%\" border=\"0\">\r\n");
	XYBody.Append("                <tbody>\r\n");
	XYBody.Append("                <tr>\r\n");
	XYBody.Append("                    <td align=\"left\" width=\"52%\" style=\"padding-left:4px; padding-top:5px;\"><font color=\"#9a2502\">");	XYBody.Append(shopuserinfo.gradename.ToString());	XYBody.Append("</font></a></td>\r\n");
	XYBody.Append("                    <td align=\"middle\" width=\"6%\">&nbsp;</td>\r\n");
	XYBody.Append("                    <td align=\"middle\" width=\"45%\" class=\"year\">��<span>");	XYBody.Append(shopuserinfo.years.ToString());	XYBody.Append("</span>��</td>\r\n");
	XYBody.Append("                </tr>\r\n");
	XYBody.Append("                </tbody>\r\n");
	XYBody.Append("                </table>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div>\r\n");


	XYBody.Append("        <div class=\"clr\"></div>\r\n");
	XYBody.Append("        <div class=\"layout950\">\r\n");

	XYBody.Append("<div class=\"nav\">\r\n");
	XYBody.Append("    <ul id=\"_shop_menu_list\">\r\n");
	 str = GetLinkPrefix();
	
	XYBody.Append("        <li id=\"_shop_menu_index\" class=\"hover\"><a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("index.");	XYBody.Append(config.Suffix);	XYBody.Append("\">��ҳ</a> </li>\r\n");
	XYBody.Append("        <li id=\"_shop_menu_introduction\"><a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("introduction.");	XYBody.Append(config.Suffix);	XYBody.Append("\">��λ��Ϣ</a> </li>\r\n");
	XYBody.Append("        <li id=\"_shop_menu_product\"><a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("product.");	XYBody.Append(config.Suffix);	XYBody.Append("\">��Ʒ�б�</a> </li>\r\n");
	XYBody.Append("        <li id=\"_shop_menu_offer\"><a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("offer.");	XYBody.Append(config.Suffix);	XYBody.Append("\">�����б�</a> </li>\r\n");
	XYBody.Append("        <li id=\"_shop_menu_newslist\"><a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("newslist.");	XYBody.Append(config.Suffix);	XYBody.Append("\">��ҵ��̬</a> </li>\r\n");
	XYBody.Append("        <li id=\"_shop_menu_brandlist\"><a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("brandlist.");	XYBody.Append(config.Suffix);	XYBody.Append("\">Ʒ�ƽ���</a> </li>\r\n");
	XYBody.Append("        <li id=\"_shop_menu_cred\"><a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("cred.");	XYBody.Append(config.Suffix);	XYBody.Append("\">��������</a> </li>\r\n");
	XYBody.Append("        <li id=\"_shop_menu_joblist\"><a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("joblist.");	XYBody.Append(config.Suffix);	XYBody.Append("\">��Ƹ����</a> </li>\r\n");
	XYBody.Append("        <li id=\"_shop_menu_contact\"><a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("contact.");	XYBody.Append(config.Suffix);	XYBody.Append("\">��ϵ��ʽ</a> </li>\r\n");
	XYBody.Append("    </ul>\r\n");
	XYBody.Append("    <script type=\"text/javascript\">xy_Shop_SetMenu();</" + "script>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<div class=\"banner\">\r\n");

	if (shopuserinfo.banner!="")
	{

	XYBody.Append("        <img src=\"");	XYBody.Append(shopuserinfo.banner.ToString());	XYBody.Append("\" width=\"950px;\" height=\"200px\" alt=\"\"/>\r\n");

	}	//end if

	XYBody.Append("</div>\r\n");


	XYBody.Append("        <div class=\"clr\"></div>\r\n");
	XYBody.Append("        <div class=\"where\">�����ڵ�λ�ã���ҳ &gt; ��ϵ����</div>\r\n");

	XYBody.Append("<div id=\"bodyleft\">\r\n");
	XYBody.Append("    <div class=\"leftkuang\">\r\n");
	XYBody.Append("        <div class=\"lefttitle\">��վ����</div>\r\n");
	XYBody.Append("        <div class=\"gonggaoContContent\">\r\n");
	XYBody.Append("            <marquee onmouseover=this.stop() onmouseout=this.start() scrollAmount=1 scrollDelay=0 direction=up height=80 align=\"center\">");	XYBody.Append(shopuserinfo.shopannounce.ToString());	XYBody.Append("</marquee>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <div class=\"leftkuang\">\r\n");
	XYBody.Append("        <div class=\"lefttitle\">��Ʒ����</div>\r\n");
	XYBody.Append("        <div class=\"bodyContContent\">\r\n");
	XYBody.Append("            <ul>\r\n");
	 data = GetCompanyProType();
	

	int type__loop__id=0;
	foreach(DataRow type in data.Rows)
	{
		type__loop__id++;

	XYBody.Append("		        <li>\r\n");
	XYBody.Append("			        <a href=\"javascript:pturls(" + type["id"].ToString().Trim() + ",'");	XYBody.Append(shopuserinfo.loginname.ToString());	XYBody.Append("')\">" + type["ptname"].ToString().Trim() + "</a>\r\n");
	XYBody.Append("		        </li>\r\n");

	}	//end loop

	XYBody.Append("            </ul>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <div class=\"leftkuang\">\r\n");
	XYBody.Append("        <div class=\"lefttitle\">��ϵ��ʽ</div>\r\n");
	XYBody.Append("        <div class=\"linksContContent\">\r\n");
	XYBody.Append("            <ul>\r\n");
	XYBody.Append("                <li>��ϵ�ˣ�");	XYBody.Append(shopuserinfo.linkman.ToString());	XYBody.Append("</li> \r\n");
	XYBody.Append("                <li>��  ����");	XYBody.Append(shopuserinfo.mobile.ToString());	XYBody.Append(" </li>\r\n");
	XYBody.Append("                <li>��  ����");	XYBody.Append(shopuserinfo.telephone.ToString());	XYBody.Append("</li>\r\n");
	XYBody.Append("                <li>��  �棺");	XYBody.Append(shopuserinfo.fax.ToString());	XYBody.Append("</li>\r\n");
	XYBody.Append("            </ul>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <div class=\"leftkuang\">\r\n");
	XYBody.Append("        <div class=\"lefttitle\">��������</div>\r\n");
	XYBody.Append("        <div class=\"linksContContent\">\r\n");
	XYBody.Append("            <ul>\r\n");
	XYBody.Append("                <li title=\"�й�Ӫ������\">��<a href=\"http://www.yylm.org\" target=\"_blank\">�й�Ӫ������</a></li>\r\n");
	XYBody.Append("                <li title=\"��Աչʾƽ̨\">��<a href=\"http://cy.yylm.org\" target=\"_blank\">��Աչʾƽ̨</a></li>\r\n");
	 data = GetLink();
	

	int link__loop__id=0;
	foreach(DataRow link in data.Rows)
	{
		link__loop__id++;

	XYBody.Append("                <li title=\"" + link["SiteName"].ToString().Trim() + "\">��<a href=\"" + link["Url"].ToString().Trim() + "\" target=\"_blank\">" + link["SiteName"].ToString().Trim() + "</a></li>\r\n");

	}	//end loop

	XYBody.Append("            </ul>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <div class=\"leftkuang\">\r\n");
	XYBody.Append("        <div class=\"lefttitle\">վ������</div>\r\n");
	XYBody.Append("        <div class=\"bodyContContent\">\r\n");
	XYBody.Append("            <input  size=\"13\" value=\"\" name=\"Products\" id=\"Products\"/>\r\n");
	XYBody.Append("            <input name=\"button\" type=\"button\" onclick=\"xy_Shop_Search();\" value=\"����\"/>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("</div>\r\n");


	XYBody.Append("        <!--��λ����-->\r\n");
	XYBody.Append("        <div id=\"bodyright\">\r\n");
	XYBody.Append("            <div class=\"leftkuang\">\r\n");
	XYBody.Append("                <div class=\"righttitle\">\r\n");
	XYBody.Append("                    <ul>\r\n");
	XYBody.Append("                        <li>��ϵ��ʽ</li>\r\n");
	XYBody.Append("                    </ul>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <div id=\"linkmessage\"></div>\r\n");
	XYBody.Append("                <div class=\"message\">\r\n");
	XYBody.Append("                    <!-- ����ģ����� -->\r\n");
	XYBody.Append("                    <input type =\"hidden\" id=\"_param_message_module\" value=\"company\" />\r\n");
	XYBody.Append("                    <input type =\"hidden\" id=\"_param_message_title\" value=\"�ҶԹ�������й�Ӫ�����˷����ķ�����Ϣ�ܸ���Ȥ\" />\r\n");
	XYBody.Append("                    <input type =\"hidden\" id=\"_param_message_parent_module\" value =\"");	XYBody.Append(infotype.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("                    <input type =\"hidden\" id=\"_param_message_infoid\" value =\"");	XYBody.Append(infoid.ToString());	XYBody.Append("\"/>\r\n");
	XYBody.Append("                    <input type =\"hidden\" id=\"_param_message_userid\" value =\"");	XYBody.Append(shopuserinfo.userid.ToString());	XYBody.Append("\" />\r\n");

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


	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <div class=\"clr\"></div>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </div><!--��λ���ܽ���-->\r\n");
	XYBody.Append("        <div class=\"clr\"></div>\r\n");
	XYBody.Append("        </div>\r\n");

	XYBody.Append("<div class=\"copyright\">\r\n");
	XYBody.Append("    <table width=\"100%\">\r\n");
	XYBody.Append("        <tbody>\r\n");
	XYBody.Append("            <tr>\r\n");
	XYBody.Append("            <td align=\"middle\" width=\"100%\">\r\n");
	XYBody.Append("                <table width=\"100%\">\r\n");
	XYBody.Append("                    <tbody>\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                            <td align=\"middle\" width=\"54%\">\r\n");
	XYBody.Append("                            <table width=\"100%\">\r\n");
	XYBody.Append("                                <tbody>\r\n");
	XYBody.Append("                                    <tr><td align=\"middle\">");	XYBody.Append(shopuserinfo.unitname.ToString());	XYBody.Append("</td></tr>\r\n");
	XYBody.Append("                                    <tr><td align=\"middle\">��λ��ַ��");	XYBody.Append(shopuserinfo.address.ToString());	XYBody.Append("</td></tr>\r\n");
	XYBody.Append("                                    <tr>\r\n");
	XYBody.Append("                                    <td align=\"middle\">\r\n");
	XYBody.Append("                                        <a href=\"http://www.yylm.org\" target=\"_blank\">�й�Ӫ�����ˣ��ṩƽ̨֧��</a> | \r\n");
	XYBody.Append("                                        <a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("feedback.");	XYBody.Append(config.suffix);	XYBody.Append("\" target=\"_blank\">�������</a> | \r\n");
	XYBody.Append("                                        <a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("login.");	XYBody.Append(config.suffix);	XYBody.Append("\" target=\"_blank\">������վ</a>\r\n");
	XYBody.Append("                                    </td>\r\n");
	XYBody.Append("                                    </tr>\r\n");
	XYBody.Append("                                </tbody>\r\n");
	XYBody.Append("                            </table>\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                       </tr>\r\n");
	XYBody.Append("                    </tbody>\r\n");
	XYBody.Append("                </table>\r\n");
	XYBody.Append("            </td>\r\n");
	XYBody.Append("            </tr>\r\n");
	XYBody.Append("        </tbody>\r\n");
	XYBody.Append("    </table>\r\n");
	XYBody.Append("</div>\r\n");


	XYBody.Append("    </div>\r\n");
	XYBody.Append("</BODY>\r\n");
	XYBody.Append("</html>\r\n");

	XYBody.Append("");
	Response.Write(XYBody.ToString());
}
</script>
