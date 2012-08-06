<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.shop.offerlist,XYECOM.Page" %>
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


	XYBody.Append("<link rel=\"stylesheet\" type=\"text/css\" href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/_shop/store/css/content.css\" />\r\n");

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


	XYBody.Append("<!--main start-->\r\n");
	XYBody.Append("<div class=\"main\">\r\n");
	XYBody.Append("    <!-- 导航条 -->\r\n");
	XYBody.Append("    <div id=\"daohang\">\r\n");
	XYBody.Append("        <a href=\"./\">首页</a> &gt; <a href=\"\">童装/母婴</a> &gt; <a href=\"\">儿童服装</a> &gt; 商品详情\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <div id=\"main_left\">\r\n");
	XYBody.Append("        <div id=\"spfl\">\r\n");
	XYBody.Append("            <!-- 商品分类 -->\r\n");
	XYBody.Append("            <div id=\"spfl_top\">\r\n");
	XYBody.Append("                <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/_shop/store/images/g_01.jpg\" width=\"220\" height=\"31\"\r\n");
	XYBody.Append("                    border=\"0\" />\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("            <div id=\"spfl_box\">\r\n");
	XYBody.Append("                <div class=\"spfl_title\">\r\n");
	XYBody.Append("                    <strong>小商品</strong>\r\n");
	XYBody.Append("                    <div class=\"spfl_all\">\r\n");
	XYBody.Append("                        <a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("category.");	XYBody.Append(config.suffix);	XYBody.Append("\" class=\"red\">所有分类</a>\r\n");
	XYBody.Append("                    </div>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <div class=\"spfl_list\">\r\n");
	XYBody.Append("                    <div class=\"spfl_list_left2\">\r\n");
	XYBody.Append("                        <a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\">工艺礼品</a>\r\n");
	XYBody.Append("                    </div>\r\n");
	XYBody.Append("                    <div class=\"detail d_hide\">\r\n");
	XYBody.Append("                        <div class=\"d_list\">\r\n");
	XYBody.Append("                            <div class=\"d_title\">\r\n");
	XYBody.Append("                                <a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\" target=\"_blank\">\r\n");
	XYBody.Append("                                    广告促销</a>\r\n");
	XYBody.Append("                            </div>\r\n");
	XYBody.Append("                            <div class=\"d_box\">\r\n");
	XYBody.Append("                                <ul>\r\n");
	XYBody.Append("                                    <li><a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\"\r\n");
	XYBody.Append("                                        target=\"_blank\">广告杯</a></li>\r\n");
	XYBody.Append("                                    <li><a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\"\r\n");
	XYBody.Append("                                        target=\"_blank\">广告扇</a></li>\r\n");
	XYBody.Append("                                    <li><a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\"\r\n");
	XYBody.Append("                                        target=\"_blank\">广告伞</a></li>\r\n");
	XYBody.Append("                                    <li><a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\"\r\n");
	XYBody.Append("                                        target=\"_blank\">广告笔</a></li>\r\n");
	XYBody.Append("                                    <li><a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\"\r\n");
	XYBody.Append("                                        target=\"_blank\">礼品灯</a></li>\r\n");
	XYBody.Append("                                    <li><a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\"\r\n");
	XYBody.Append("                                        target=\"_blank\">礼品餐具</a></li>\r\n");
	XYBody.Append("                                    <li><a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\"\r\n");
	XYBody.Append("                                        target=\"_blank\">冰箱贴</a></li>\r\n");
	XYBody.Append("                                    <li><a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\"\r\n");
	XYBody.Append("                                        target=\"_blank\">开瓶器</a></li>\r\n");
	XYBody.Append("                                </ul>\r\n");
	XYBody.Append("                            </div>\r\n");
	XYBody.Append("                        </div>\r\n");
	XYBody.Append("                        <div class=\"d_line\">\r\n");
	XYBody.Append("                        </div>\r\n");
	XYBody.Append("                        <div class=\"d_list\">\r\n");
	XYBody.Append("                            <div class=\"d_title\">\r\n");
	XYBody.Append("                                <a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\" target=\"_blank\">\r\n");
	XYBody.Append("                                    冬季促销</a>\r\n");
	XYBody.Append("                            </div>\r\n");
	XYBody.Append("                            <div class=\"d_box\">\r\n");
	XYBody.Append("                                <ul>\r\n");
	XYBody.Append("                                    <li><a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\"\r\n");
	XYBody.Append("                                        target=\"_blank\">礼品口杯</a></li>\r\n");
	XYBody.Append("                                    <li><a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\"\r\n");
	XYBody.Append("                                        target=\"_blank\">礼品冰杯</a></li>\r\n");
	XYBody.Append("                                    <li><a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\"\r\n");
	XYBody.Append("                                        target=\"_blank\">礼品水壶</a></li>\r\n");
	XYBody.Append("                                    <li><a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\"\r\n");
	XYBody.Append("                                        target=\"_blank\">礼品冰垫</a></li>\r\n");
	XYBody.Append("                                    <li><a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\"\r\n");
	XYBody.Append("                                        target=\"_blank\">pp扇子</a></li>\r\n");
	XYBody.Append("                                    <li><a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\"\r\n");
	XYBody.Append("                                        target=\"_blank\">宫扇</a></li>\r\n");
	XYBody.Append("                                    <li><a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\"\r\n");
	XYBody.Append("                                        target=\"_blank\">礼品化妆镜</a></li>\r\n");
	XYBody.Append("                                    <li><a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\"\r\n");
	XYBody.Append("                                        target=\"_blank\">usb电池</a></li>\r\n");
	XYBody.Append("                                </ul>\r\n");
	XYBody.Append("                            </div>\r\n");
	XYBody.Append("                        </div>\r\n");
	XYBody.Append("                        <div class=\"d_line\">\r\n");
	XYBody.Append("                        </div>\r\n");
	XYBody.Append("                        <div class=\"d_list\">\r\n");
	XYBody.Append("                            <div class=\"d_title\">\r\n");
	XYBody.Append("                                <a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\" target=\"_blank\">\r\n");
	XYBody.Append("                                    商务办公</a>\r\n");
	XYBody.Append("                            </div>\r\n");
	XYBody.Append("                            <div class=\"d_box\">\r\n");
	XYBody.Append("                                <ul>\r\n");
	XYBody.Append("                                    <li><a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\"\r\n");
	XYBody.Append("                                        target=\"_blank\">商务套装</a></li>\r\n");
	XYBody.Append("                                    <li><a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\"\r\n");
	XYBody.Append("                                        target=\"_blank\">文化礼品</a></li>\r\n");
	XYBody.Append("                                    <li><a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\"\r\n");
	XYBody.Append("                                        target=\"_blank\">商务馈赠</a></li>\r\n");
	XYBody.Append("                                    <li><a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\"\r\n");
	XYBody.Append("                                        target=\"_blank\">会展礼品</a></li>\r\n");
	XYBody.Append("                                    <li><a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\"\r\n");
	XYBody.Append("                                        target=\"_blank\">礼品计算器</a></li>\r\n");
	XYBody.Append("                                    <li><a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\"\r\n");
	XYBody.Append("                                        target=\"_blank\">礼品相框</a></li>\r\n");
	XYBody.Append("                                    <li><a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\"\r\n");
	XYBody.Append("                                        target=\"_blank\">礼品笔</a></li>\r\n");
	XYBody.Append("                                    <li><a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\"\r\n");
	XYBody.Append("                                        target=\"_blank\">上海世贸商</a></li>\r\n");
	XYBody.Append("                                </ul>\r\n");
	XYBody.Append("                            </div>\r\n");
	XYBody.Append("                        </div>\r\n");
	XYBody.Append("                        <div class=\"d_line\">\r\n");
	XYBody.Append("                        </div>\r\n");
	XYBody.Append("                        <div class=\"d_list\">\r\n");
	XYBody.Append("                            <div class=\"d_title\">\r\n");
	XYBody.Append("                                <a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\" target=\"_blank\">\r\n");
	XYBody.Append("                                    节庆礼品</a>\r\n");
	XYBody.Append("                            </div>\r\n");
	XYBody.Append("                            <div class=\"d_box\">\r\n");
	XYBody.Append("                                <ul>\r\n");
	XYBody.Append("                                    <li><a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\"\r\n");
	XYBody.Append("                                        target=\"_blank\">生日</a></li>\r\n");
	XYBody.Append("                                    <li><a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\"\r\n");
	XYBody.Append("                                        target=\"_blank\">婚庆</a></li>\r\n");
	XYBody.Append("                                    <li><a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\"\r\n");
	XYBody.Append("                                        target=\"_blank\">情侣</a></li>\r\n");
	XYBody.Append("                                    <li><a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\"\r\n");
	XYBody.Append("                                        target=\"_blank\">春节</a></li>\r\n");
	XYBody.Append("                                    <li><a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\"\r\n");
	XYBody.Append("                                        target=\"_blank\">助威道具</a></li>\r\n");
	XYBody.Append("                                    <li><a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\"\r\n");
	XYBody.Append("                                        target=\"_blank\">气球</a></li>\r\n");
	XYBody.Append("                                    <li><a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\"\r\n");
	XYBody.Append("                                        target=\"_blank\">旗帜</a></li>\r\n");
	XYBody.Append("                                    <li><a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\"\r\n");
	XYBody.Append("                                        target=\"_blank\">贺卡</a></li>\r\n");
	XYBody.Append("                                </ul>\r\n");
	XYBody.Append("                            </div>\r\n");
	XYBody.Append("                        </div>\r\n");
	XYBody.Append("                        <div class=\"d_line\">\r\n");
	XYBody.Append("                        </div>\r\n");
	XYBody.Append("                        <div class=\"d_list\">\r\n");
	XYBody.Append("                            <div class=\"d_title\">\r\n");
	XYBody.Append("                                <a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\" target=\"_blank\">\r\n");
	XYBody.Append("                                    传统工艺</a>\r\n");
	XYBody.Append("                            </div>\r\n");
	XYBody.Append("                            <div class=\"d_box\">\r\n");
	XYBody.Append("                                <ul>\r\n");
	XYBody.Append("                                    <li><a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\"\r\n");
	XYBody.Append("                                        target=\"_blank\">珠宝玉器</a></li>\r\n");
	XYBody.Append("                                    <li><a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\"\r\n");
	XYBody.Append("                                        target=\"_blank\">艺术品</a></li>\r\n");
	XYBody.Append("                                    <li><a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\"\r\n");
	XYBody.Append("                                        target=\"_blank\">书画</a></li>\r\n");
	XYBody.Append("                                    <li><a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\"\r\n");
	XYBody.Append("                                        target=\"_blank\">收藏品</a></li>\r\n");
	XYBody.Append("                                    <li><a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\"\r\n");
	XYBody.Append("                                        target=\"_blank\">民间工艺</a></li>\r\n");
	XYBody.Append("                                    <li><a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\"\r\n");
	XYBody.Append("                                        target=\"_blank\">灯笼</a></li>\r\n");
	XYBody.Append("                                    <li><a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\"\r\n");
	XYBody.Append("                                        target=\"_blank\">中国结</a></li>\r\n");
	XYBody.Append("                                    <li><a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\"\r\n");
	XYBody.Append("                                        target=\"_blank\">古玩古董</a></li>\r\n");
	XYBody.Append("                                </ul>\r\n");
	XYBody.Append("                            </div>\r\n");
	XYBody.Append("                        </div>\r\n");
	XYBody.Append("                    </div>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <div class=\"spfl_xiao\">\r\n");
	XYBody.Append("                    <ul>\r\n");
	XYBody.Append("                        <li><a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\">节日用品</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\">婚庆</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\">创意杯子</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\">手表</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\">打火机</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\">家用电器</a></li>\r\n");
	XYBody.Append("                    </ul>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <div id=\"spfl_gengduo\">\r\n");
	XYBody.Append("                    <a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("category.");	XYBody.Append(config.suffix);	XYBody.Append("\">查看更多分类</a>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </div>\r\n");

	XYBody.Append("<div id=\"xzpp\">\r\n");
	XYBody.Append("    <!-- 选择品牌 -->\r\n");
	XYBody.Append("    <div id=\"xzpp_top\">\r\n");
	XYBody.Append("        选择品牌\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <div id=\"xzpp_all\">\r\n");
	XYBody.Append("        <a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("brandlist.");	XYBody.Append(config.suffix);	XYBody.Append("\">所有品牌</a>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <div id=\"xzpp_box\">\r\n");
	XYBody.Append("        <ul>\r\n");

	int brand__loop__id=0;
	foreach(DataRow brand in brandlist.Rows)
	{
		brand__loop__id++;

	XYBody.Append("            <li><a href='");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("brandlist-" + brand["Id"].ToString().Trim() + ".");	XYBody.Append(config.suffix);	XYBody.Append("'\r\n");
	XYBody.Append("                target=\"_self\">" + brand["BrandName"].ToString().Trim() + " </a></li>\r\n");

	if (brand__loop__id==10)
	{

	 break;

	}	//end if


	}	//end loop

	XYBody.Append("        </ul>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("</div>\r\n");


	XYBody.Append("        <div id=\"zjll\">\r\n");
	XYBody.Append("            <!-- 最近浏览的商品 -->\r\n");
	XYBody.Append("            <div id=\"zjll_top\">\r\n");
	XYBody.Append("                我最近浏览的商品\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("            <div id=\"zjll_clear\">\r\n");
	XYBody.Append("                <a href=\"\">清除</a>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("            <div id=\"zjll_box\">\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <div id=\"main_right\">\r\n");
	XYBody.Append("        <div class=\"rcon\">\r\n");
	XYBody.Append("            <div class=\"rtit\">\r\n");
	XYBody.Append("                ");	XYBody.Append(pageinfo.InfoListLink);	XYBody.Append("\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("            <div id=\"rtxt\">\r\n");

	int info__loop__id=0;
	foreach(DataRow info in infolist.Rows)
	{
		info__loop__id++;

	XYBody.Append("                <div class=\"rtxtq\">\r\n");
	 str = GetProductUrl(info["InfoId"],info["HtmlPage"]);
	
	 str1 = GetInfoImgHref("offer",info["InfoId"]);
	
	XYBody.Append("                    <a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("\"><em>\r\n");
	XYBody.Append("                        <img src=\"");	XYBody.Append(str1.ToString());	XYBody.Append("\" alt=\"" + info["infoTitle"].ToString().Trim() + "\" /></em> </a>\r\n");
	XYBody.Append("                    <ul>\r\n");
	XYBody.Append("                        <li class=\"bg\"><span class=\"font14s\"><a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("\">" + info["infoTitle"].ToString().Trim() + "</a></span> (\r\n");
	XYBody.Append("                            发布时间：" + info["addtime"].ToString().Trim() + " )</li>\r\n");
	XYBody.Append("                        <li class=\"border\">\r\n");
	XYBody.Append( Method.left(info["details"].ToString().Trim(),300));
	XYBody.Append("</li>\r\n");
	XYBody.Append("                    </ul>\r\n");
	XYBody.Append("                </div>\r\n");

	}	//end loop

	XYBody.Append("            </div>\r\n");
	XYBody.Append("            <div class=\"pg\">\r\n");
	XYBody.Append("                当前是第 <span class=\"colorf00s\">");	XYBody.Append(pageinfo.PageIndex);	XYBody.Append("</span> 页(共 ");	XYBody.Append(pageinfo.PageCount);	XYBody.Append("\r\n");
	XYBody.Append("                页)");	XYBody.Append(pageinfo.FirstPage);	XYBody.Append("&nbsp;");	XYBody.Append(pageinfo.PreviousPage);	XYBody.Append("&nbsp;");	XYBody.Append(pageinfo.NextPage);	XYBody.Append("&nbsp;");	XYBody.Append(pageinfo.LastPage);	XYBody.Append("</div>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <div class=\"clear\">\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<!--main end-->\r\n");

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
