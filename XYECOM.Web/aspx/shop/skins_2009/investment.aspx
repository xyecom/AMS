<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.shop.investment,XYECOM.Page" %>
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
	XYBody.Append("<body onload=\"");	XYBody.Append(pageinfo.OnLoadEvents);	XYBody.Append("\">\r\n");

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


	XYBody.Append("        <div class=layout950_100 style=\"BACKGROUND-IMAGE: url(");	XYBody.Append(config.WebURL);	XYBody.Append("templates/_shop/skins_2009/");	XYBody.Append(shopuserinfo.template.ToString());	XYBody.Append("/images/stylebg1.jpg)\">\r\n");

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


	XYBody.Append("    <div class=\"clr\"></div>\r\n");
	XYBody.Append("    <div class=layout950>\r\n");

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


	XYBody.Append("    <div class=\"clr\"></div>\r\n");
	XYBody.Append("    <div class=where>�����ڵ�λ�ã���ҳ &gt; ���̼���</div>\r\n");

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


	XYBody.Append("    <!--��Ӧ��Ϣ-->\r\n");
	XYBody.Append("    <div id=bodyright>\r\n");
	XYBody.Append("        <div class=leftkuang>\r\n");
	XYBody.Append("            <div class=\"infotitle\">\r\n");
	XYBody.Append("                <ul>\r\n");
	XYBody.Append("                    ");	XYBody.Append(pageinfo.InfoListLink);	XYBody.Append("\r\n");
	XYBody.Append("                </ul>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("            <div class=\"infolist\">\r\n");
	XYBody.Append("                <ul>\r\n");

	int info__loop__id=0;
	foreach(DataRow info in infolist.Rows)
	{
		info__loop__id++;

	 str = GetInfoUrl("investment",info["InfoFlag"],info["InfoId"],info["HtmlPage"]);
	
	 str1 = GetInfoImgHref("investment",info["InfoId"]);
	
	XYBody.Append("                    <li>\r\n");
	XYBody.Append("                        <div class=\"pBox\"><a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("\" target=\"_blank\"><img src=\"");	XYBody.Append(str1.ToString());	XYBody.Append("\" border=\"0\" alt=\"" + info["infoTitle"].ToString().Trim() + "\" onload='SetImgSize(this,70,70);'/></a></div>\r\n");
	XYBody.Append("                        <div class=\"tBox\">\r\n");
	XYBody.Append("                            <h2><a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("\" target=\"_blank\">" + info["infoTitle"].ToString().Trim() + "</a> <span>(����ʱ�䣺" + info["addtime"].ToString().Trim() + ")</span></h2>\r\n");
	XYBody.Append( Method.left(info["details"].ToString().Trim(),300));
	XYBody.Append("                        </div>\r\n");
	XYBody.Append("                    </li>\r\n");

	}	//end loop

	XYBody.Append("                </ul>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("            <div class=\"clr\"></div>\r\n");
	XYBody.Append("            <div class=page>\r\n");
	XYBody.Append("                ��");	XYBody.Append(pageinfo.PageCount);	XYBody.Append("ҳ ");	XYBody.Append(pageinfo.FirstPage);	XYBody.Append("&nbsp;");	XYBody.Append(pageinfo.PreviousPage);	XYBody.Append("&nbsp;");	XYBody.Append(pageinfo.NextPage);	XYBody.Append("&nbsp;");	XYBody.Append(pageinfo.LastPage);	XYBody.Append("\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("            <div class=\"clr\"></div>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div><!--��Ӧ��Ϣ����-->\r\n");
	XYBody.Append("    <div class=\"clr\">\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    </div>\r\n");

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
	XYBody.Append("</body>\r\n");
	XYBody.Append("</html>\r\n");

	XYBody.Append("");
	Response.Write(XYBody.ToString());
}
</script>
