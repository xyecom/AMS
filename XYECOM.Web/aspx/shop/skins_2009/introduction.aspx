<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.shop.introduction,XYECOM.Page" %>
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
	XYBody.Append("<meta content=\"");	XYBody.Append(shopuserinfo.unitname.ToString());	XYBody.Append("成立于");	XYBody.Append(shopuserinfo.regyear.ToString());	XYBody.Append("年,位于");	XYBody.Append(shopuserinfo.areaname.ToString());	XYBody.Append("\" name=\"description\"/>\r\n");
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
	XYBody.Append("            <a onclick=\"javascript:this.style.behavior='url(#default#homepage)';this.setHomePage('");	XYBody.Append(str.ToString());	XYBody.Append("');\"   href=\"#\" target=\"_self\">设为首页</a> |\r\n");
	XYBody.Append("            <a href=\"javascript:window.external.addFavorite('");	XYBody.Append(str.ToString());	XYBody.Append("','");	XYBody.Append(shopuserinfo.unitname.ToString());	XYBody.Append("')\">添加到收藏夹</a> \r\n");
	XYBody.Append("        </li>\r\n");
	XYBody.Append("        <li class=\"glass_right\">\r\n");
	XYBody.Append("            ");	XYBody.Append(pageinfo.LoginStatus);	XYBody.Append(" | \r\n");
	XYBody.Append("            <a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("user\">发布产品信息</a> | \r\n");
	XYBody.Append("            <a href=\"http://www.yylm.org/contents/859/11418.html\" target=\"_blank\">联系我们</a>\r\n");
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
	XYBody.Append("        <p>主营产品：");	XYBody.Append(shopuserinfo.supplypro.ToString());	XYBody.Append("</p>\r\n");
	XYBody.Append("        <div class=\"gold_year\">\r\n");
	XYBody.Append("            <div class=\"gold_wz\">\r\n");
	XYBody.Append("                <table cellSpacing=\"0\" cellPadding=\"0\" width=\"100%\" border=\"0\">\r\n");
	XYBody.Append("                <tbody>\r\n");
	XYBody.Append("                <tr>\r\n");
	XYBody.Append("                    <td align=\"left\" width=\"52%\" style=\"padding-left:4px; padding-top:5px;\"><font color=\"#9a2502\">");	XYBody.Append(shopuserinfo.gradename.ToString());	XYBody.Append("</font></a></td>\r\n");
	XYBody.Append("                    <td align=\"middle\" width=\"6%\">&nbsp;</td>\r\n");
	XYBody.Append("                    <td align=\"middle\" width=\"45%\" class=\"year\">第<span>");	XYBody.Append(shopuserinfo.years.ToString());	XYBody.Append("</span>年</td>\r\n");
	XYBody.Append("                </tr>\r\n");
	XYBody.Append("                </tbody>\r\n");
	XYBody.Append("                </table>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div>\r\n");


	XYBody.Append("    <div class=\"clr\"></div>\r\n");
	XYBody.Append("    <div class=\"layout950\">\r\n");

	XYBody.Append("<div class=\"nav\">\r\n");
	XYBody.Append("    <ul id=\"_shop_menu_list\">\r\n");
	 str = GetLinkPrefix();
	
	XYBody.Append("        <li id=\"_shop_menu_index\" class=\"hover\"><a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("index.");	XYBody.Append(config.Suffix);	XYBody.Append("\">首页</a> </li>\r\n");
	XYBody.Append("        <li id=\"_shop_menu_introduction\"><a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("introduction.");	XYBody.Append(config.Suffix);	XYBody.Append("\">单位信息</a> </li>\r\n");
	XYBody.Append("        <li id=\"_shop_menu_product\"><a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("product.");	XYBody.Append(config.Suffix);	XYBody.Append("\">产品列表</a> </li>\r\n");
	XYBody.Append("        <li id=\"_shop_menu_offer\"><a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("offer.");	XYBody.Append(config.Suffix);	XYBody.Append("\">商情列表</a> </li>\r\n");
	XYBody.Append("        <li id=\"_shop_menu_newslist\"><a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("newslist.");	XYBody.Append(config.Suffix);	XYBody.Append("\">企业动态</a> </li>\r\n");
	XYBody.Append("        <li id=\"_shop_menu_brandlist\"><a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("brandlist.");	XYBody.Append(config.Suffix);	XYBody.Append("\">品牌介绍</a> </li>\r\n");
	XYBody.Append("        <li id=\"_shop_menu_cred\"><a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("cred.");	XYBody.Append(config.Suffix);	XYBody.Append("\">荣誉资质</a> </li>\r\n");
	XYBody.Append("        <li id=\"_shop_menu_joblist\"><a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("joblist.");	XYBody.Append(config.Suffix);	XYBody.Append("\">招聘中心</a> </li>\r\n");
	XYBody.Append("        <li id=\"_shop_menu_contact\"><a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("contact.");	XYBody.Append(config.Suffix);	XYBody.Append("\">联系方式</a> </li>\r\n");
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
	XYBody.Append("    <div class=\"where\">你现在的位置：首页 &gt; 单位介绍</div>\r\n");

	XYBody.Append("<div id=\"bodyleft\">\r\n");
	XYBody.Append("    <div class=\"leftkuang\">\r\n");
	XYBody.Append("        <div class=\"lefttitle\">网站公告</div>\r\n");
	XYBody.Append("        <div class=\"gonggaoContContent\">\r\n");
	XYBody.Append("            <marquee onmouseover=this.stop() onmouseout=this.start() scrollAmount=1 scrollDelay=0 direction=up height=80 align=\"center\">");	XYBody.Append(shopuserinfo.shopannounce.ToString());	XYBody.Append("</marquee>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <div class=\"leftkuang\">\r\n");
	XYBody.Append("        <div class=\"lefttitle\">产品分类</div>\r\n");
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
	XYBody.Append("        <div class=\"lefttitle\">联系方式</div>\r\n");
	XYBody.Append("        <div class=\"linksContContent\">\r\n");
	XYBody.Append("            <ul>\r\n");
	XYBody.Append("                <li>联系人：");	XYBody.Append(shopuserinfo.linkman.ToString());	XYBody.Append("</li> \r\n");
	XYBody.Append("                <li>手  机：");	XYBody.Append(shopuserinfo.mobile.ToString());	XYBody.Append(" </li>\r\n");
	XYBody.Append("                <li>电  话：");	XYBody.Append(shopuserinfo.telephone.ToString());	XYBody.Append("</li>\r\n");
	XYBody.Append("                <li>传  真：");	XYBody.Append(shopuserinfo.fax.ToString());	XYBody.Append("</li>\r\n");
	XYBody.Append("            </ul>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <div class=\"leftkuang\">\r\n");
	XYBody.Append("        <div class=\"lefttitle\">友情链接</div>\r\n");
	XYBody.Append("        <div class=\"linksContContent\">\r\n");
	XYBody.Append("            <ul>\r\n");
	XYBody.Append("                <li title=\"中国营养联盟\">·<a href=\"http://www.yylm.org\" target=\"_blank\">中国营养联盟</a></li>\r\n");
	XYBody.Append("                <li title=\"成员展示平台\">·<a href=\"http://cy.yylm.org\" target=\"_blank\">成员展示平台</a></li>\r\n");
	 data = GetLink();
	

	int link__loop__id=0;
	foreach(DataRow link in data.Rows)
	{
		link__loop__id++;

	XYBody.Append("                <li title=\"" + link["SiteName"].ToString().Trim() + "\">·<a href=\"" + link["Url"].ToString().Trim() + "\" target=\"_blank\">" + link["SiteName"].ToString().Trim() + "</a></li>\r\n");

	}	//end loop

	XYBody.Append("            </ul>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <div class=\"leftkuang\">\r\n");
	XYBody.Append("        <div class=\"lefttitle\">站内搜索</div>\r\n");
	XYBody.Append("        <div class=\"bodyContContent\">\r\n");
	XYBody.Append("            <input  size=\"13\" value=\"\" name=\"Products\" id=\"Products\"/>\r\n");
	XYBody.Append("            <input name=\"button\" type=\"button\" onclick=\"xy_Shop_Search();\" value=\"搜索\"/>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("</div>\r\n");


	XYBody.Append("    <!--单位介绍-->\r\n");
	XYBody.Append("    <div id=\"bodyright\">\r\n");
	XYBody.Append("        <div class=\"leftkuang\">\r\n");
	XYBody.Append("            <div class=\"righttitle\">\r\n");
	XYBody.Append("                <ul>\r\n");
	XYBody.Append("                    <li>单位介绍</li>\r\n");
	XYBody.Append("                </ul>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("            <div class=\"tuijian_company\">\r\n");
	XYBody.Append("                <div class=\"picbox1\">\r\n");
	XYBody.Append("                <img alt=\"");	XYBody.Append(shopuserinfo.unitname.ToString());	XYBody.Append("\" src=\"");	XYBody.Append(shopuserinfo.imgurl.ToString());	XYBody.Append("\"/>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <p>");	XYBody.Append(shopuserinfo.synopsis.ToString());	XYBody.Append("</p>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("            <div class=\"clr\"></div>\r\n");
	XYBody.Append("            <div class=\"righttitle\">\r\n");
	XYBody.Append("                <ul>\r\n");
	XYBody.Append("                    <li>\r\n");
	XYBody.Append("                        详细信息\r\n");
	XYBody.Append("                    </li>\r\n");
	XYBody.Append("                </ul>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("            <table cellSpacing=\"1\" cellPadding=\"4\" width=\"100%\" align=\"center\" bgColor=\"#ffffff\" border=\"0\">\r\n");
	XYBody.Append("            <tbody>\r\n");
	XYBody.Append("            <tr>\r\n");
	XYBody.Append("                <td width=\"18%\" bgColor=\"#f0f0f0\" height=\"25\"><div align=\"right\"><strong>主营产品或服务：</strong></div></td>\r\n");
	XYBody.Append("                <td width=\"35%\" bgColor=\"#ffffff\">");	XYBody.Append(shopuserinfo.supplypro.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("                <td width=\"16%\" bgColor=\"#f0f0f0\"><div align=right> <strong>企业类型：</strong> </div></td>\r\n");
	XYBody.Append("                <td width=\"31%\" bgColor=\"#ffffff\">");	XYBody.Append(shopuserinfo.character.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("            </tr>\r\n");
	XYBody.Append("            <tr>\r\n");
	XYBody.Append("                <td bgColor=#f0f0f0 height=25><div align=right><strong>经营模式：</strong></div></td>\r\n");
	XYBody.Append("                <td bgColor=#ffffff>");	XYBody.Append(shopuserinfo.mode.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("                <td bgColor=#f0f0f0><div align=right> <strong>注册资本： </strong></div></td>\r\n");
	XYBody.Append("                <td bgColor=#ffffff>");	XYBody.Append(shopuserinfo.registeredcapital.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("            </tr>\r\n");
	XYBody.Append("            <tr>\r\n");
	XYBody.Append("                <td bgColor=#f0f0f0 height=25><div align=right><strong>单位成立时间：</strong></div></td>\r\n");
	XYBody.Append("                <td bgColor=#ffffff>");	XYBody.Append(shopuserinfo.regyear.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("                <td bgColor=#f0f0f0><div align=right><strong>员工人数：</strong></div></td>\r\n");
	XYBody.Append("                <td bgColor=#ffffff>");	XYBody.Append(shopuserinfo.employeetotal.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("            </tr>\r\n");
	XYBody.Append("            <tr>\r\n");
	XYBody.Append("                <td bgColor=#f0f0f0 height=25><div align=right><strong>主要市场：</FONT></strong> </div></td>\r\n");
	XYBody.Append("                <td bgColor=#ffffff>");	XYBody.Append(shopuserinfo.manageaddress.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("                <td align=right bgColor=#f0f0f0><strong>单位主页：</strong></td>\r\n");
	XYBody.Append("                <td bgColor=#ffffff><a href=\"");	XYBody.Append(shopuserinfo.homepage.ToString());	XYBody.Append("\" target=_blank>");	XYBody.Append(shopuserinfo.homepage.ToString());	XYBody.Append("</a></td>\r\n");
	XYBody.Append("            </tr>\r\n");
	XYBody.Append("            </tbody>\r\n");
	XYBody.Append("            </table>\r\n");
	XYBody.Append("            <div class=\"clr\"></div>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <!--单位介绍结束-->\r\n");
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
	XYBody.Append("                                    <tr><td align=\"middle\">单位地址：");	XYBody.Append(shopuserinfo.address.ToString());	XYBody.Append("</td></tr>\r\n");
	XYBody.Append("                                    <tr>\r\n");
	XYBody.Append("                                    <td align=\"middle\">\r\n");
	XYBody.Append("                                        <a href=\"http://www.yylm.org\" target=\"_blank\">中国营养联盟：提供平台支持</a> | \r\n");
	XYBody.Append("                                        <a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("feedback.");	XYBody.Append(config.suffix);	XYBody.Append("\" target=\"_blank\">意见反馈</a> | \r\n");
	XYBody.Append("                                        <a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("login.");	XYBody.Append(config.suffix);	XYBody.Append("\" target=\"_blank\">管理网站</a>\r\n");
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
