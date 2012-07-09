<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.shop.tbindex,XYECOM.Page" %>
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
	XYBody.Append("    <div id=\"r_f\">2000-2009　" +  XYECOMCreateHTML("XY_Copyright").ToString() + "　版权所有　纵横易商软件</div>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("</body>\r\n");
	XYBody.Append("</html>\r\n");



	Response.Write(XYBody.ToString());
System.Web.HttpContext.Current.Response.End();
	

	}	//end if

	XYBody.Append("</head>\r\n");


	XYBody.Append("<style type=\"text/css\">\r\n");
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
	XYBody.Append("        background: url(images/navtab1.gif) no-repeat scroll 0 0 transparent;\r\n");
	XYBody.Append("        color: #333;\r\n");
	XYBody.Append("        padding-top: 5px;\r\n");
	XYBody.Append("    }\r\n");
	XYBody.Append("    .Menubox li.hover\r\n");
	XYBody.Append("    {\r\n");
	XYBody.Append("        color: #fff;\r\n");
	XYBody.Append("        text-decoration: none;\r\n");
	XYBody.Append("        background-attachment: scroll;\r\n");
	XYBody.Append("        background-color: transparent;\r\n");
	XYBody.Append("        background-image: url(images/navtab.gif);\r\n");
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
	XYBody.Append("    .main\r\n");
	XYBody.Append("    {\r\n");
	XYBody.Append("        background: none repeat scroll 0 0 #FFFFFF;\r\n");
	XYBody.Append("        border: 3px solid #FA9B4D;\r\n");
	XYBody.Append("        position: relative;\r\n");
	XYBody.Append("        width: 978px;\r\n");
	XYBody.Append("    }\r\n");
	XYBody.Append("    #plist ul\r\n");
	XYBody.Append("    {\r\n");
	XYBody.Append("        display: table-row-group;\r\n");
	XYBody.Append("    }\r\n");
	XYBody.Append("    #plist li\r\n");
	XYBody.Append("    {\r\n");
	XYBody.Append("        display: table-cell;\r\n");
	XYBody.Append("        list-style: none;\r\n");
	XYBody.Append("        margin-left: 20px;\r\n");
	XYBody.Append("        margin-top: 30px;\r\n");
	XYBody.Append("        margin-bottom: 30px;\r\n");
	XYBody.Append("        float: left;\r\n");
	XYBody.Append("        width: 220px;\r\n");
	XYBody.Append("        text-align: center;\r\n");
	XYBody.Append("    }\r\n");
	XYBody.Append("</style>\r\n");
	XYBody.Append("<script type=\"text/javascript\" src=\"/Common/js/forebase.js\"></" + "script>\r\n");
	XYBody.Append("<link rel=\"stylesheet\" href=\"/common/css/XYLib.css\" type=\"text/css\" media=\"screen\" />\r\n");
	XYBody.Append("<script type=\"text/javascript\">\r\n");
	XYBody.Append("    $(document).ready(function () {\r\n");
	XYBody.Append("        var size = '");	XYBody.Append(pagesize.ToString());	XYBody.Append("'\r\n");
	XYBody.Append("        if (size == '0') {\r\n");
	XYBody.Append("            size = 20;\r\n");
	XYBody.Append("        }\r\n");
	XYBody.Append("        $(\"#txtpagesize\").val(size);\r\n");
	XYBody.Append("        $(\"#txtText\").val('");	XYBody.Append(keyword.ToString());	XYBody.Append("');\r\n");
	XYBody.Append("    });\r\n");
	XYBody.Append("    function bntSearch(style) {\r\n");
	XYBody.Append("        var url = '");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("' + \"tbindex\";\r\n");
	XYBody.Append("        var keyword = $(\"#txtText\").val();\r\n");
	XYBody.Append("        var pagesize = $(\"#txtpagesize\").val();\r\n");
	XYBody.Append("        var pageindex = $(\"#cpage\").val();\r\n");
	XYBody.Append("        if (keyword != '') {\r\n");
	XYBody.Append("            url += \"-\" + keyword;\r\n");
	XYBody.Append("        } else {\r\n");
	XYBody.Append("            url += \"-\";\r\n");
	XYBody.Append("        }\r\n");
	XYBody.Append("        if (style != '') {\r\n");
	XYBody.Append("            url += \"-\" + style;\r\n");
	XYBody.Append("        } else {\r\n");
	XYBody.Append("            url += \"-");	XYBody.Append(showstyle.ToString());	XYBody.Append("\";\r\n");
	XYBody.Append("        }\r\n");
	XYBody.Append("        if (pagesize != '') {\r\n");
	XYBody.Append("            if (!IsNum(pagesize)) {\r\n");
	XYBody.Append("                return alertmsg(false, '每页显示页数必须是数字！');\r\n");
	XYBody.Append("            }\r\n");
	XYBody.Append("            url += \"-\" + pagesize;\r\n");
	XYBody.Append("        } else {\r\n");
	XYBody.Append("            url += \"-");	XYBody.Append(pagesize.ToString());	XYBody.Append("\";\r\n");
	XYBody.Append("        }\r\n");
	XYBody.Append("        if (pageindex != '') {\r\n");
	XYBody.Append("            url += \"-\" + pageindex;\r\n");
	XYBody.Append("        } else {\r\n");
	XYBody.Append("            url += \"-");	XYBody.Append(pageindex.ToString());	XYBody.Append("\";\r\n");
	XYBody.Append("        }\r\n");
	XYBody.Append("        window.location.href = url + \".\" + config.Suffix;\r\n");
	XYBody.Append("    }\r\n");
	XYBody.Append("</" + "script>\r\n");

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


	XYBody.Append("<div id=\"ubox\">\r\n");
	XYBody.Append("    <!--左边导航-->\r\n");
	XYBody.Append("    <div id=\"uleftnav\">\r\n");



	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <!--左边导航  end-->\r\n");
	XYBody.Append("    <!--右边主要内容-->\r\n");
	XYBody.Append("    <div id=\"uright\">\r\n");
	XYBody.Append("        <!--站点导航-->\r\n");
	XYBody.Append("        <div style=\"display: none;\">\r\n");
	XYBody.Append("            <em id=\"clicknum1\" style=\"display: none\"></em><em id=\"clicknum\" style=\"display: none\">\r\n");
	XYBody.Append("            </em><em id=\"linkmessage\" style=\"display: none\"></em><em id=\"msy\" style=\"display: none\">\r\n");
	XYBody.Append("            </em><em id=\"messnum\" style=\"display: none\"></em>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <!--公司介绍-->\r\n");
	XYBody.Append("        <div class=\"rcon\">\r\n");
	XYBody.Append("            <h2>\r\n");
	XYBody.Append("                团购信息</h2>\r\n");
	XYBody.Append("            <div class=\"newslist\">\r\n");
	XYBody.Append("                <div class=\"tabcon cur\">\r\n");
	XYBody.Append("                    请输入团购关键字\r\n");
	XYBody.Append("                    <input id=\"txtText\" name=\"txtText\" type=\"text\" />\r\n");
	XYBody.Append("                    每页显示条数<input id=\"txtpagesize\" name=\"txtpagesize\" type=\"text\" />\r\n");
	XYBody.Append("                    <input id=\"btnSearch\" type=\"button\" value=\"搜索\" onclick=\"bntSearch('')\" />\r\n");
	XYBody.Append("                    <br />\r\n");
	XYBody.Append("                    <input id=\"Text1\" type=\"button\" onclick=\"bntSearch('1')\" value=\"样式1\" />\r\n");
	XYBody.Append("                    <input id=\"Text2\" type=\"button\" onclick=\"bntSearch('2')\" value=\"样式2\" />\r\n");
	XYBody.Append("                    <input id=\"Text3\" type=\"button\" onclick=\"bntSearch('3')\" value=\"样式3\" />\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <div class=\"main\">\r\n");
	XYBody.Append("                    <div id=\"plist\" class=\"rbox\" style=\"overflow: hidden; width: 978px;\">\r\n");
	XYBody.Append("                        <ul>\r\n");
	XYBody.Append("                            " +  XYECOMCreateHTML("XY_团购_团购信息").ToString() + "\r\n");
	XYBody.Append("                        </ul>\r\n");
	XYBody.Append("                    </div>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <div class=\"clear\">\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("            <div class=\"pg\">\r\n");
	XYBody.Append("                <div id=\"splitPage\">\r\n");
	XYBody.Append("                    ");	XYBody.Append(pageinfo.PreviousPage);	XYBody.Append("");	XYBody.Append(pageinfo.NumPage);	XYBody.Append("");	XYBody.Append(pageinfo.NextPage);	XYBody.Append(" &nbsp;&nbsp;&nbsp;\r\n");
	XYBody.Append("                    直接转到&nbsp;\r\n");
	XYBody.Append("                    <input name=\"pageformat\" type=\"hidden\" value=\".html /\">\r\n");
	XYBody.Append("                    <input name=\"page\" id=\"cpage\" size=\"3\" maxlength=\"3\" style=\"height: 13px;\" value=\"");	XYBody.Append(pageinfo.PageIndex);	XYBody.Append("\" />&nbsp;页&nbsp;\r\n");
	XYBody.Append("                    <input type=\"submit\" value=\"确定>>\" style=\"height: 20px;\" onclick=\"xy_GoToPage(cpage.value);\" />\r\n");
	XYBody.Append("                    <input type=\"hidden\" id=\"totalPage\" value=\"");	XYBody.Append(pageinfo.PageCount);	XYBody.Append("\" />\r\n");
	XYBody.Append("                    <span style=\"font-size: 14px;\">共 <strong class=\"orange\">");	XYBody.Append(pageinfo.TotalRecord);	XYBody.Append("</strong>\r\n");
	XYBody.Append("                        条记录&nbsp;&nbsp;&nbsp;当前为第 <strong class=\"orange\">");	XYBody.Append(pageinfo.PageIndex);	XYBody.Append("</strong> 页&nbsp;&nbsp;&nbsp;共\r\n");
	XYBody.Append("                        <strong class=\"orange\">");	XYBody.Append(pageinfo.PageCount);	XYBody.Append("</strong> 页&nbsp;&nbsp;&nbsp;</span>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("</div>\r\n");

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



	XYBody.Append("");
	Response.Write(XYBody.ToString());
}
</script>
