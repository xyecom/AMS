<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.shop.category,XYECOM.Page" %>
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
	XYBody.Append("    <title>");	XYBody.Append(UserSEO.Title.ToString());	XYBody.Append("</title>\r\n");
	XYBody.Append("    <meta name=\"description\" content=\"");	XYBody.Append(UserSEO.Description.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("    <meta name=\"keywords\" content=\"");	XYBody.Append(UserSEO.Keywords.ToString());	XYBody.Append("\" />\r\n");

	if (seo.Robots==true)
	{

	XYBody.Append("    <meta name=\"robots\" content=\"all\" />\r\n");

	}	//end if

	XYBody.Append("    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=gb2312\" />\r\n");
	XYBody.Append("    <meta http-equiv=\"Content-Language\" content=\"zh-CN\" />\r\n");
	XYBody.Append("    <meta name=\"author\" content=\"www.xyecs.com\" />\r\n");
	XYBody.Append("    <meta name=\"Copyright\" content=\"copyright (c) www.xyecs.com.版权所有.\" />\r\n");
	XYBody.Append("    <link rel=\"stylesheet\" charset=\"utf-8\" href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("common/css/css.css\" type=\"text/css\" />\r\n");
	XYBody.Append("    <script type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("common/js/jquery-1.4.2.js\"></" + "script>\r\n");
	XYBody.Append("    <script type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/_shop/store/js/search.js\"></" + "script>\r\n");
	XYBody.Append("    <script type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("common/js/forebase.js\" language=\"javascript\"></" + "script>	\r\n");
	XYBody.Append("    <script type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("common/js/date.js\" language=\"javascript\"></" + "script>\r\n");

	if (pageinfo.PageError==1)
	{


	XYBody.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n");
	XYBody.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n");
	XYBody.Append("<head>\r\n");
	XYBody.Append("<title>消息提示</title>\r\n");
	XYBody.Append("");	XYBody.Append(pageinfo.Meta);	XYBody.Append("\r\n");
	XYBody.Append("<link rel=\"stylesheet\" href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/css/global.css\" type=\"text/css\" media=\"screen\" />\r\n");
	XYBody.Append("</head>\r\n");
	XYBody.Append("<body style=\"background-color:#f2f2f2\">\r\n");
	XYBody.Append("<div id=\"sysMsgbox\">\r\n");
	XYBody.Append("	<ul>\r\n");
	XYBody.Append("	    <li class=\"msg\">");	XYBody.Append(pageinfo.MsgboxText);	XYBody.Append("</li>\r\n");
	XYBody.Append("        <li><a href=\"");	XYBody.Append(pageinfo.MsgboxURL);	XYBody.Append("\">");	XYBody.Append(pageinfo.MsgboxURL);	XYBody.Append("</a></li>\r\n");
	XYBody.Append("         <li><a href=\"#\" onclick=\"history.back();\">返回继续操作</a></li>\r\n");
	XYBody.Append("        <li><a href=\"/\">返回首页</a> | <a href=\"#\" onclick=\"window.close();\">关闭本页</a></li>\r\n");
	XYBody.Append("    </ul>\r\n");
	XYBody.Append("    <div id=\"r_f\">2000-2009　" +  XYECOMCreateHTML("XY_Copyright").ToString() + "　版权所有　</div>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("</body>\r\n");
	XYBody.Append("</html>\r\n");



	Response.Write(XYBody.ToString());
System.Web.HttpContext.Current.Response.End();
	

	}	//end if

	XYBody.Append("</head>\r\n");


	XYBody.Append("<style type=\"text/css\">\r\n");
	XYBody.Append("    /*选项卡 样式*/\r\n");
	XYBody.Append("    #Tab2\r\n");
	XYBody.Append("    {\r\n");
	XYBody.Append("        clear: both;\r\n");
	XYBody.Append("        width: 980px;\r\n");
	XYBody.Append("        margin: 0px;\r\n");
	XYBody.Append("        padding: 0px;\r\n");
	XYBody.Append("        margin: 0 auto;\r\n");
	XYBody.Append("    }\r\n");
	XYBody.Append("    .Menubox\r\n");
	XYBody.Append("    {\r\n");
	XYBody.Append("        width: 100%;\r\n");
	XYBody.Append("        height: 28px;\r\n");
	XYBody.Append("        line-height: 28px;\r\n");
	XYBody.Append("        border-bottom: 2px solid #b80733;\r\n");
	XYBody.Append("        height: 29px;\r\n");
	XYBody.Append("    }\r\n");
	XYBody.Append("    .Menubox ul\r\n");
	XYBody.Append("    {\r\n");
	XYBody.Append("        margin: 0px;\r\n");
	XYBody.Append("        padding: 0px;\r\n");
	XYBody.Append("    }\r\n");
	XYBody.Append("    .Menubox li\r\n");
	XYBody.Append("    {\r\n");
	XYBody.Append("        float: left;\r\n");
	XYBody.Append("        display: block;\r\n");
	XYBody.Append("        cursor: pointer;\r\n");
	XYBody.Append("        width: 90px;\r\n");
	XYBody.Append("        margin-right: 5px;\r\n");
	XYBody.Append("        height: 26px;\r\n");
	XYBody.Append("        text-align: center;\r\n");
	XYBody.Append("        background: url(");	XYBody.Append(config.WebURL);	XYBody.Append("templates/_shop/store/images/navtab1.gif) no-repeat scroll 0 0 transparent;\r\n");
	XYBody.Append("        color: #333;\r\n");
	XYBody.Append("        padding-top: 5px;\r\n");
	XYBody.Append("    }\r\n");
	XYBody.Append("    .Menubox li.hover\r\n");
	XYBody.Append("    {\r\n");
	XYBody.Append("        color: #fff;\r\n");
	XYBody.Append("        text-decoration: none;\r\n");
	XYBody.Append("        background-attachment: scroll;\r\n");
	XYBody.Append("        background-color: transparent;\r\n");
	XYBody.Append("        background-image: url(");	XYBody.Append(config.WebURL);	XYBody.Append("templates/_shop/store/images/navtab.gif);\r\n");
	XYBody.Append("        background-repeat: no-repeat;\r\n");
	XYBody.Append("        background-position: 0 0;\r\n");
	XYBody.Append("    }\r\n");
	XYBody.Append("    .Contentbox\r\n");
	XYBody.Append("    {\r\n");
	XYBody.Append("        clear: both;\r\n");
	XYBody.Append("        margin-top: 0px;\r\n");
	XYBody.Append("        border: 2px solid #b80733;\r\n");
	XYBody.Append("        border-top: none;\r\n");
	XYBody.Append("        text-align: center;\r\n");
	XYBody.Append("        padding-top: 8px;\r\n");
	XYBody.Append("    }\r\n");
	XYBody.Append("    #infolist div a.STYLE12\r\n");
	XYBody.Append("    {\r\n");
	XYBody.Append("        background: url(");	XYBody.Append(config.WebURL);	XYBody.Append("templates/_shop/store/images/arrowfl.gif) no-repeat scroll 0 17px transparent;\r\n");
	XYBody.Append("        border-bottom: 1px dashed #CCCCCC;\r\n");
	XYBody.Append("        color: #C50C0C;\r\n");
	XYBody.Append("        display: block;\r\n");
	XYBody.Append("        font-size: 14px;\r\n");
	XYBody.Append("        font-weight: 600;\r\n");
	XYBody.Append("        margin-left: 0;\r\n");
	XYBody.Append("        padding: 10px 0 5px 10px;\r\n");
	XYBody.Append("    }\r\n");
	XYBody.Append("</style>\r\n");

	XYBody.Append("<body>\r\n");
	XYBody.Append("    <input type=\"hidden\" id=\"shopuserloginname\" name=\"shopuserloginname\" value=\"");	XYBody.Append(shopuserinfo.loginname.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("    <div id=\"content\">\r\n");

	XYBody.Append("<div class=\"top\">\r\n");
	XYBody.Append("    <div class=\"logo\">\r\n");
	XYBody.Append("        <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("Common/Images/logo.jpg\" />\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <div class=\"submenu\">\r\n");
	XYBody.Append("        <div class=\"login\">\r\n");

	if (islogin)
	{

	XYBody.Append("            <!--已登陆-->\r\n");
	XYBody.Append("            您好");	XYBody.Append(userinfo.loginname.ToString());	XYBody.Append("，欢迎来到亿家商城！<a href=\"/logout.aspx\" target=\"_self\">[退出]</a>&nbsp;&nbsp;&nbsp;&nbsp;<a\r\n");
	XYBody.Append("                href=\"/user/index.aspx\" target=\"_blank\">我的帐户</a> | <a href=\"/user/BuyerOrderList.aspx\"\r\n");
	XYBody.Append("                    target=\"_blank\">我的订单</a> | <a href=\"#\" target=\"_blank\">帮助中心</a>\r\n");

	}
	else
	{

	XYBody.Append("            <!--未登陆-->\r\n");
	XYBody.Append("            您好，欢迎来到亿家商城！<a href=\"/login.aspx\" target=\"_blank\">[请登陆]</a><a href=\"/register.aspx\"\r\n");
	XYBody.Append("                target=\"_blank\">[免费注册]</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"/user/index.aspx\" target=\"_blank\">我的帐户</a>\r\n");
	XYBody.Append("            | <a href=\"/user/BuyerOrderList.aspx\" target=\"_self\">我的订单</a> | <a href=\"#\" target=\"_blank\">\r\n");
	XYBody.Append("                帮助中心</a>\r\n");

	}	//end if

	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <div class=\"dh\">\r\n");
	XYBody.Append("            <ul>\r\n");
	XYBody.Append("                <li>\r\n");
	XYBody.Append("                    <h1 class=\"h1\">\r\n");
	XYBody.Append("                        <a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("product.");	XYBody.Append(config.suffix);	XYBody.Append("\" target=\"_self\" class=\"h1\">商城购物</a></h1>\r\n");
	XYBody.Append("                </li>\r\n");
	XYBody.Append("                <li>\r\n");
	XYBody.Append("                    <h1>\r\n");
	XYBody.Append("                        <a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("brandlist.");	XYBody.Append(config.suffix);	XYBody.Append("\" target=\"_self\" class=\"h1\">品牌专区</a></h1>\r\n");
	XYBody.Append("                </li>\r\n");
	XYBody.Append("                <li>\r\n");
	XYBody.Append("                    <h1>\r\n");
	XYBody.Append("                        <a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("tbindex----.");	XYBody.Append(config.suffix);	XYBody.Append("\" target=\"_self\" class=\"h1\">团购商品</a></h1>\r\n");
	XYBody.Append("                </li>\r\n");
	XYBody.Append("                <li>\r\n");
	XYBody.Append("                    <h1>\r\n");
	XYBody.Append("                        <a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\" target=\"_self\" class=\"h1\">积分换购</a></h1>\r\n");
	XYBody.Append("                </li>\r\n");
	XYBody.Append("            </ul>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <div style=\"clear: both\">\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("</div>\r\n");


	XYBody.Append("        <!--导航-->\r\n");

	XYBody.Append("<!--导航-->\r\n");
	XYBody.Append("<div class=\"dh_full\">\r\n");
	XYBody.Append("    <div class=\"menu\">\r\n");
	XYBody.Append("        <ul class=\"cd\">\r\n");

	int row1__loop__id=0;
	foreach(DataRow row1 in customtypelist.Rows)
	{
		row1__loop__id++;

	XYBody.Append("            <li><a href='");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("category-" + row1["Id"].ToString().Trim() + ".");	XYBody.Append(config.suffix);	XYBody.Append("'\r\n");
	XYBody.Append("                target=\"_self\" class=\"menu\">" + row1["PtName"].ToString().Trim() + " </a></li>\r\n");

	}	//end loop

	XYBody.Append("            <li><a href='");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("venturelist.");	XYBody.Append(config.suffix);	XYBody.Append("'\r\n");
	XYBody.Append("                target=\"_blank\" class=\"menu\">融资信息</a></li>\r\n");
	XYBody.Append("            <li><a href='");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("category.");	XYBody.Append(config.suffix);	XYBody.Append("'\r\n");
	XYBody.Append("                target=\"_blank\" class=\"menu\">所有分类</a></li>\r\n");
	XYBody.Append("        </ul>\r\n");
	XYBody.Append("        <div class=\"list\" style=\"_overflow: hidden\">\r\n");
	XYBody.Append("            <div class=\"listcart\">\r\n");
	XYBody.Append("                <a href=\"#\" target=\"_blank\" id=\"showCard\">查看购物车去结账 </a>\r\n");
	XYBody.Append("                <div class=\"listCartDetail\" id=\"listCartDetail\">\r\n");
	XYBody.Append("                    <p>\r\n");
	XYBody.Append("                        您一共选购了 <em>");	XYBody.Append(mycart.SupplyCount.ToString());	XYBody.Append("</em> 件商品,共计 <em>");	XYBody.Append(mycart.OrderAllPrice.ToString());	XYBody.Append("</em>元</p>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<div class=\"clear\">\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<!--导航 end-->\r\n");


	XYBody.Append("        <div class=\"clear\">\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <!--导航 end-->\r\n");
	XYBody.Append("        <!--search start-->\r\n");

	XYBody.Append("<!--search start-->\r\n");
	XYBody.Append("<div class=\"search\">\r\n");
	XYBody.Append("    <div class=\"s-bg\">\r\n");
	XYBody.Append("        <img height=\"34\" alt=\"\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/_shop/store/images/search_29.jpg\"\r\n");
	XYBody.Append("            width=\"4\"></div>\r\n");
	XYBody.Append("    <div class=\"s-bg1\">\r\n");
	XYBody.Append("        <ul class=\"fs\">\r\n");
	XYBody.Append("            <li>\r\n");
	XYBody.Append("                <h3>\r\n");
	XYBody.Append("                    <a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("product.");	XYBody.Append(config.suffix);	XYBody.Append("\" class=\"font12redA\"\r\n");
	XYBody.Append("                        target=\"_blank\">积分换购</a></h3>\r\n");
	XYBody.Append("            </li>\r\n");
	XYBody.Append("            <li>\r\n");
	XYBody.Append("                <h4>\r\n");
	XYBody.Append("                    <a href=\"#\" class=\"font12redA\" target=\"_blank\">最新商品</a></h4>\r\n");
	XYBody.Append("            </li>\r\n");
	XYBody.Append("            <li>\r\n");
	XYBody.Append("                <h4>\r\n");
	XYBody.Append("                    <a class=\"font12redA\" href=\"#\" target=\"_blank\">热卖商品</a></h4>\r\n");
	XYBody.Append("            </li>\r\n");
	XYBody.Append("            <li>\r\n");
	XYBody.Append("                <h4>\r\n");
	XYBody.Append("                    <a class=\"font12redA\" href=\"#\" target=\"_blank\">商城公告</a></h4>\r\n");
	XYBody.Append("            </li>\r\n");
	XYBody.Append("        </ul>\r\n");
	XYBody.Append("        <div class=\"sous\">\r\n");
	XYBody.Append("            <form action=\"\" method=\"get\">\r\n");
	XYBody.Append("            <div class=\"s1\">\r\n");
	XYBody.Append("                <input name=\"keyword\" id=\"txtkeyword\" type=\"text\" value=\"");	XYBody.Append(keyword.ToString());	XYBody.Append("\" /></div>\r\n");
	XYBody.Append("            <div class=\"s2\">\r\n");
	XYBody.Append("                <input type=\"button\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/_shop/store/images/btn_35.jpg\"\r\n");
	XYBody.Append("                    id=\"btnsearch\" value=\"sousuo\"></div>\r\n");
	XYBody.Append("            <a href=\"#\" target=\"_blank\">高级搜索</a>\r\n");
	XYBody.Append("            </form>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <div class=\"s-bg\">\r\n");
	XYBody.Append("        <img height=\"34\" alt=\"\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/_shop/store/images/search_32.jpg\"\r\n");
	XYBody.Append("            width=\"6\" /></div>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<!--search end-->\r\n");


	XYBody.Append("        <!--search end-->\r\n");
	XYBody.Append("    </div>\r\n");


	XYBody.Append("<!--top end-->\r\n");
	XYBody.Append("<!--main start-->\r\n");
	XYBody.Append("<div class=\"mian\">\r\n");
	XYBody.Append("    <div class=\"clearfix2\">\r\n");
	XYBody.Append("        <span class=\"pos\">");	XYBody.Append(categoryTitle.ToString());	XYBody.Append("</span><a class=\"amore a2\" href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("brandlist.");	XYBody.Append(config.suffix);	XYBody.Append("\"\r\n");
	XYBody.Append("            target=\"_blank\">查看所有品牌</a>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <!--分类 start-->\r\n");
	XYBody.Append("    <div class=\"bor1 clearfix2\">\r\n");
	XYBody.Append("        <div class=\"headtitle\">\r\n");
	XYBody.Append("            <table class=\"tagli\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"99%\">\r\n");
	XYBody.Append("                <tbody>\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <td height=\"30\" valign=\"center\" align=\"middle\">\r\n");
	XYBody.Append("                            <div class=\"headtitle\">\r\n");
	XYBody.Append("                                商品目录\r\n");
	XYBody.Append("                            </div>\r\n");
	XYBody.Append("                        </td>\r\n");

	int rowitem__loop__id=0;
	foreach(DataRow rowitem in customtypelist.Rows)
	{
		rowitem__loop__id++;

	XYBody.Append("                        <td valign=\"center\" align=\"middle\">\r\n");
	XYBody.Append("                            <a href='");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("category-" + rowitem["Id"].ToString().Trim() + ".");	XYBody.Append(config.suffix);	XYBody.Append("'\r\n");
	XYBody.Append("                                target=\"_self\" class=\"menu\">" + rowitem["PtName"].ToString().Trim() + " </a>\r\n");
	XYBody.Append("                        </td>\r\n");

	}	//end loop

	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                </tbody>\r\n");
	XYBody.Append("            </table>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <div id=\"infolist\">\r\n");

	int row2__loop__id=0;
	foreach(DataRow row2 in parent.Rows)
	{
		row2__loop__id++;

	XYBody.Append("            <div class=\"fllist\" id=\"store-tablest\">\r\n");
	XYBody.Append("                <table class=\"store-item dis\" num=\"1\">\r\n");
	XYBody.Append("                    <tbody>\r\n");
	XYBody.Append("                        <tr>\r\n");
	XYBody.Append("                            <td align=\"left\">\r\n");
	XYBody.Append("                                <h2>\r\n");
	 tmplinkurl = GetInfoLink(row2["Id"],row2["SubCount"]);
	
	XYBody.Append("                                    <a class=\"STYLE12\" href='");	XYBody.Append(tmplinkurl.ToString());	XYBody.Append("'>" + row2["PtName"].ToString().Trim() + "</a></h2>\r\n");
	 subtype = GetSubTypeById(row2["Id"].ToString());
	

	int typeitem__loop__id=0;
	foreach(DataRow typeitem in subtype.Rows)
	{
		typeitem__loop__id++;

	 tmplinkurl = GetInfoLink(typeitem["Id"],typeitem["SubCount"]);
	

	if (typeitem__loop__id==1)
	{

	XYBody.Append("                                <a class=\"first\" href=\"");	XYBody.Append(tmplinkurl.ToString());	XYBody.Append("\" target=\"_blank\">" + typeitem["PtName"].ToString().Trim() + "</a>\r\n");

	}
	else
	{

	XYBody.Append("                                <a class=\"fb\" href=\"");	XYBody.Append(tmplinkurl.ToString());	XYBody.Append("\" rel=\"nofollow\">" + typeitem["PtName"].ToString().Trim() + "</a>\r\n");

	}	//end if


	}	//end loop

	XYBody.Append("                            </td>\r\n");
	XYBody.Append("                        </tr>\r\n");
	XYBody.Append("                    </tbody>\r\n");
	XYBody.Append("                </table>\r\n");
	XYBody.Append("            </div>\r\n");

	}	//end loop

	XYBody.Append("            <div class=\"morelink\">\r\n");
	XYBody.Append("                <ul>\r\n");
	XYBody.Append("                    <li>\r\n");
	XYBody.Append("                        <div class=\"morelinkinside\" align=\"left\">\r\n");
	XYBody.Append("                            <table width=\"97%\" align=\"center\">\r\n");
	XYBody.Append("                                <tbody>\r\n");
	XYBody.Append("                                    <tr>\r\n");
	XYBody.Append("                                        <td align=\"right\">\r\n");
	XYBody.Append("                                            <form method=\"get\" action=\"\">\r\n");
	XYBody.Append("                                            <fieldset>\r\n");
	XYBody.Append("                                                <span class=\"STYLE120\">\r\n");
	XYBody.Append("                                                    <div>\r\n");
	XYBody.Append("                                                        <span class=\"STYLE9\">热门搜索：亿家商城—</span> <a href=\"#\" target=\"_blank\">时尚</a> <a href=\"#\"\r\n");
	XYBody.Append("                                                            target=\"_blank\">烫钻</a> <a href=\"#\" target=\"_blank\">条纹</a> <a href=\"#\" target=\"_blank\">\r\n");
	XYBody.Append("                                                                纯棉</a> <a title=\"\" href=\"#\" target=\"_blank\">外套</a> <a href=\"#\" target=\"_blank\">围脖</a>\r\n");
	XYBody.Append("                                                        <a href=\"#\" target=\"_blank\">印花</a> <a href=\"#\" target=\"_blank\">点点</a> <a href=\"#\"\r\n");
	XYBody.Append("                                                            target=\"_blank\">面膜</a> <a href=\"#\" target=\"_blank\">美肤</a> <a href=\"#\" target=\"_blank\">\r\n");
	XYBody.Append("                                                                嫩白</a> <a href=\"#\" target=\"_blank\">沐浴</a> <a href=\"#\" target=\"_blank\">相宜本草</a>\r\n");
	XYBody.Append("                                                        <a href=\"#\" target=\"_blank\">薇姿</a> <a href=\"#\" target=\"_blank\">迷奇</a> <a href=\"#\"\r\n");
	XYBody.Append("                                                            target=\"_blank\">昭贵</a> <a href=\"#\" target=\"_blank\">PBA</a> <a href=\"#\" target=\"_blank\">\r\n");
	XYBody.Append("                                                                欧莱雅</a> <a href=\"#\" target=\"_blank\">资生堂</a> <a href=\"#\" target=\"_blank\">美容护肤</a>\r\n");
	XYBody.Append("                                                        <a href=\"#\" target=\"_blank\">按摩</a> <a href=\"#\" target=\"_blank\">BB霜</a> <a href=\"#\"\r\n");
	XYBody.Append("                                                            target=\"_blank\">瑜伽</a>\r\n");
	XYBody.Append("                                                    </div>\r\n");
	XYBody.Append("                                                </span>\r\n");
	XYBody.Append("                                                <input class=\"hd-text lower\" value=\"时尚 女装\" size=\"31\" type=\"text\" name=\"keyword\">\r\n");
	XYBody.Append("                                                <input style=\"border-bottom: medium none; border-left: medium none; border-top: medium none;\r\n");
	XYBody.Append("                                                    border-right: medium none\" class=\"hd-sbt\" value=\"搜索\" type=\"submit\">\r\n");
	XYBody.Append("                                                &nbsp;\r\n");
	XYBody.Append("                                            </fieldset>\r\n");
	XYBody.Append("                                            </form>\r\n");
	XYBody.Append("                                        </td>\r\n");
	XYBody.Append("                                    </tr>\r\n");
	XYBody.Append("                                </tbody>\r\n");
	XYBody.Append("                            </table>\r\n");
	XYBody.Append("                        </div>\r\n");
	XYBody.Append("                    </li>\r\n");
	XYBody.Append("                </ul>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <!--分类 end-->\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<!--main end-->\r\n");
	XYBody.Append("<!--footer start-->\r\n");

	XYBody.Append("<!--footer-->\r\n");
	XYBody.Append("<div class=\"indexHelp margin_top8\">\r\n");
	XYBody.Append("    <div class=\"helpList\">\r\n");
	XYBody.Append("        <ul>\r\n");
	XYBody.Append("            <li><a href=\"#\">怎样购物</a></li>\r\n");
	XYBody.Append("            <li><a href=\"#\">会员制度</a></li>\r\n");
	XYBody.Append("            <li><a href=\"#\">积分政策</a></li>\r\n");
	XYBody.Append("            <li><a href=\"#\">常见问题</a></li>\r\n");
	XYBody.Append("        </ul>\r\n");
	XYBody.Append("        <ul>\r\n");
	XYBody.Append("            <li><a href=\"#\">配送政策</a></li>\r\n");
	XYBody.Append("            <li><a href=\"#\">商品签收</a></li>\r\n");
	XYBody.Append("        </ul>\r\n");
	XYBody.Append("        <ul>\r\n");
	XYBody.Append("            <li><a href=\"#\">货到付款</a></li>\r\n");
	XYBody.Append("            <li><a href=\"#\">在线支付</a></li>\r\n");
	XYBody.Append("            <li><a href=\"#\">银行电汇</a></li>\r\n");
	XYBody.Append("            <li><a href=\"#\">发票制度</a></li>\r\n");
	XYBody.Append("        </ul>\r\n");
	XYBody.Append("        <ul>\r\n");
	XYBody.Append("            <li><a href=\"#\">退换货政策</a></li>\r\n");
	XYBody.Append("            <li><a href=\"#\">退货流程</a></li>\r\n");
	XYBody.Append("            <li><a href=\"#\">换货流程</a></li>\r\n");
	XYBody.Append("            <li><a href=\"#\">联系我们</a></li>\r\n");
	XYBody.Append("        </ul>\r\n");
	XYBody.Append("        <ul>\r\n");
	XYBody.Append("            <li><a href=\"#\">订单中心</a></li>\r\n");
	XYBody.Append("            <li><a href=\"#\">优惠券</a></li>\r\n");
	XYBody.Append("            <li><a href=\"#\">找回密码</a></li>\r\n");
	XYBody.Append("        </ul>\r\n");
	XYBody.Append("        <div class=\"clear\">\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <div class=\"indexEnsure\">\r\n");
	XYBody.Append("        <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/_shop/store/images/public_ensure.gif\" width=\"960\"\r\n");
	XYBody.Append("            height=\"45\">\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<div class=\"footer\">\r\n");
	XYBody.Append("    <a href=\"#\">首页</a> | <a href=\"#\">关于我们</a> | <a href=\"#\">批发团购</a> | <a href=\"#\">服务条款</a>\r\n");
	XYBody.Append("    | <a href=\"#\">安全说明</a> | <a href=\"#\">隐私声明</a> | <a href=\"#\">网站联盟</a> | <a href=\"#\">友情链接</a>\r\n");
	XYBody.Append("    <br />\r\n");
	XYBody.Append("    联系电话：0531-83532658 传真：0531-83532658 E-mail：sdyjsw@163.com 地址：济南市二环东路3966号东环国际广场B座1301<br />\r\n");
	XYBody.Append("    版权所有 山东亿家商务服务有限公司 All Rights Reserved 鲁ICP备00000000号\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<!--footer end-->\r\n");
	XYBody.Append("</body> </html>\r\n");


	XYBody.Append("<!--footer end-->\r\n");

	XYBody.Append("");
	Response.Write(XYBody.ToString());
}
</script>
