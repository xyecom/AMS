<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.shop.tbdetail,XYECOM.Page" %>
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


	XYBody.Append("<link rel=\"stylesheet\" type=\"text/css\" href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/_shop/store/css/tuangou.css\" />\r\n");
	XYBody.Append("<script type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/_shop/store/js/jquery.js\"></" + "script>\r\n");
	XYBody.Append("<script type=\"text/javascript\">\r\n");
	XYBody.Append("    $(document).ready(function () {\r\n");

	if (info.SupplyCount>info.SellCount)
	{

	XYBody.Append("        var endtime = new Date('");	XYBody.Append(enddate.ToString());	XYBody.Append("'); // 结束日期  \r\n");
	XYBody.Append("        var thisTime = new Date('");	XYBody.Append(now.ToString());	XYBody.Append("'); // 当前服务器时间 \r\n");
	XYBody.Append("        var nowtime = thisTime.getTime(); // 服务器当前时间总的秒数  \r\n");
	XYBody.Append("        var leftsecond = 0;\r\n");
	XYBody.Append("        var sh;\r\n");
	XYBody.Append("        function _fresh() {\r\n");
	XYBody.Append("            nowtime = nowtime + 1000; //间隔1秒，毫秒加1000  \r\n");
	XYBody.Append("            leftsecond = parseInt((endtime.getTime() - nowtime) / 1000);\r\n");
	XYBody.Append("            __d = parseInt(leftsecond / 3600 / 24) <= 9 ? +\"0\" + parseInt(leftsecond / 3600 / 24).toString() : parseInt(leftsecond / 3600 / 24);\r\n");
	XYBody.Append("            __h = parseInt((leftsecond / 3600) % 24) <= 9 ? +\"0\" + parseInt((leftsecond / 3600) % 24).toString() : parseInt((leftsecond / 3600) % 24);\r\n");
	XYBody.Append("            __m = parseInt((leftsecond / 60) % 60) <= 9 ? +\"0\" + parseInt((leftsecond / 60) % 60).toString() : parseInt((leftsecond / 60) % 60);\r\n");
	XYBody.Append("            __s = parseInt(leftsecond % 60) <= 9 ? +\"0\" + parseInt(leftsecond % 60).toString() : parseInt(leftsecond % 60);\r\n");
	XYBody.Append("            $(\"#clearInterval\").html(\"\" + __d + \"天\" + __h + \"时\" + __m + \"分\" + __s + \"秒\");\r\n");
	XYBody.Append("            if (leftsecond <= 0) {\r\n");
	XYBody.Append("                $(\"#clearInterval\").html(\"特价已结束\");\r\n");
	XYBody.Append("                $(\"#orderbuy\").html(\"特价已结束\");\r\n");
	XYBody.Append("                clearInterval(sh);\r\n");
	XYBody.Append("            }\r\n");
	XYBody.Append("        }\r\n");
	XYBody.Append("        _fresh()\r\n");
	XYBody.Append("        sh = setInterval(_fresh, 1000);\r\n");

	}
	else
	{

	XYBody.Append("            $(\"#orderbuy\").html(\"賣光了\");\r\n");
	XYBody.Append("            $(\"#clearInterval\").html(\"特价已结束\");                \r\n");

	}	//end if

	XYBody.Append("    });\r\n");
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


	XYBody.Append("<!--main start-->\r\n");
	XYBody.Append("<div id=\"main\">\r\n");
	XYBody.Append("    <!--left start-->\r\n");
	XYBody.Append("    <div class=\"i_fl\">\r\n");
	XYBody.Append("        <!-- 商品主介绍 -->\r\n");
	XYBody.Append("        <div class=\"main\">\r\n");
	XYBody.Append("            <h2>\r\n");
	XYBody.Append("                <span class=\"c2\">济南团购：</span>");	XYBody.Append(info.Title.ToString());	XYBody.Append("</h2>\r\n");
	XYBody.Append("            <div class=\"mmain\">\r\n");
	XYBody.Append("                <div class=\"lmain\">\r\n");
	XYBody.Append("                    <table class=\"discount\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	XYBody.Append("                        <tbody>\r\n");
	XYBody.Append("                            <tr>\r\n");
	XYBody.Append("                                <th>\r\n");
	XYBody.Append("                                    原价\r\n");
	XYBody.Append("                                </th>\r\n");
	XYBody.Append("                                <th>\r\n");
	XYBody.Append("                                    折扣\r\n");
	XYBody.Append("                                </th>\r\n");
	XYBody.Append("                                <th>\r\n");
	XYBody.Append("                                    节省\r\n");
	XYBody.Append("                                </th>\r\n");
	XYBody.Append("                            </tr>\r\n");
	XYBody.Append("                            <tr>\r\n");
	XYBody.Append("                                <td>\r\n");
	XYBody.Append("                                    ￥");	XYBody.Append(info.MarketPrice.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                                </td>\r\n");
	XYBody.Append("                                <td>\r\n");
	XYBody.Append("                                    ");	XYBody.Append(info.Discount.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                                </td>\r\n");
	XYBody.Append("                                <td>\r\n");
	XYBody.Append("                                    <span class=\"c2\">￥");	XYBody.Append(info.Saved.ToString());	XYBody.Append("</span>\r\n");
	XYBody.Append("                                </td>\r\n");
	XYBody.Append("                            </tr>\r\n");
	XYBody.Append("                        </tbody>\r\n");
	XYBody.Append("                    </table>\r\n");
	XYBody.Append("                    <div class=\"buyinfo\">\r\n");
	XYBody.Append("                        <p class=\"buynum\">\r\n");
	XYBody.Append("                            <span class=\"c2\">");	XYBody.Append(info.CurrentJoin.ToString());	XYBody.Append("</span>人已购买<br />\r\n");
	XYBody.Append("                            数量有限，下单要快哟</p>\r\n");
	XYBody.Append("                        <p class=\"timeleft\">\r\n");
	XYBody.Append("                            距离本次团购结束还有：<br />\r\n");
	XYBody.Append("                            <span id=\"clearInterval\" class=\"showTime\"></span>\r\n");
	XYBody.Append("                        </p>\r\n");
	XYBody.Append("                        <p class=\"waiting\">\r\n");
	XYBody.Append("                            成团人数：");	XYBody.Append(info.SucPeopleNum.ToString());	XYBody.Append(",当前参与：");	XYBody.Append(info.CurrentJoin.ToString());	XYBody.Append("有效期至(");	XYBody.Append(info.EndDate.ToString());	XYBody.Append(")\r\n");
	XYBody.Append("                        </p>\r\n");

	if (info.CurrentJoin>=info.SucPeopleNum)
	{

	XYBody.Append("                        <p class=\"success\">\r\n");
	XYBody.Append("                            团购已成功，可继续购买</p>\r\n");

	}
	else
	{

	XYBody.Append("                        <p class=\"failed\">\r\n");
	XYBody.Append("                            人数不足，不能成团</p>\r\n");

	}	//end if

	XYBody.Append("                        <p class=\"failed\" style=\"display: none;\">\r\n");
	XYBody.Append("                            卖光了</p>\r\n");
	XYBody.Append("                    </div>\r\n");
	XYBody.Append("                    <div class=\"order buy\" id=\"orderbuy\">\r\n");
	XYBody.Append("                        <a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("MyTeamOrder.");	XYBody.Append(config.suffix);	XYBody.Append("?teamId=");	XYBody.Append(info.Id.ToString());	XYBody.Append("\">抢购</a><em>￥");	XYBody.Append(info.CurrentPrice.ToString());	XYBody.Append("</em></div>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <div class=\"rmain\">\r\n");
	XYBody.Append("                    <img src=\"");	XYBody.Append(info.ImagePath.ToString());	XYBody.Append("\" width=\"440\" height=\"267\" alt=\"\" />\r\n");
	XYBody.Append("                    <div class=\"buytips\">\r\n");
	XYBody.Append("                        <div class=\"quote\">\r\n");
	XYBody.Append("                            <span style=\"color: #333333\">★ 多种款式，五种样式任选<br />\r\n");
	XYBody.Append("                                ★ 麦斯特蛋糕，儿童之首选<br />\r\n");
	XYBody.Append("                                ★ 市区二环以内免费送货</span></div>\r\n");
	XYBody.Append("                    </div>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <div class=\"clear\">\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <!-- 商品主介绍 end -->\r\n");
	XYBody.Append("        <!-- 商品详情 -->\r\n");
	XYBody.Append("        <div class=\"xq\">\r\n");
	XYBody.Append("            <ul class=\"xqlist c3\">\r\n");
	XYBody.Append("                <li class=\"cur\"><a>商品详情</a></li></ul>\r\n");
	XYBody.Append("            <div class=\"details\">\r\n");
	XYBody.Append("                ");	XYBody.Append(info.Description.ToString());	XYBody.Append("\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("            <div class=\"buy-bottom\">\r\n");
	XYBody.Append("                <dl class=\"item-prices\">\r\n");
	XYBody.Append("                    <dt class=\"price\">原 价</dt>\r\n");
	XYBody.Append("                    <dt class=\"juprice\">折 扣</dt>\r\n");
	XYBody.Append("                    <dt class=\"save\">节 省</dt>\r\n");
	XYBody.Append("                    <dd class=\"price\">\r\n");
	XYBody.Append("                        <del>￥");	XYBody.Append(info.MarketPrice.ToString());	XYBody.Append("</del></dd>\r\n");
	XYBody.Append("                    <dd class=\"juprice\">\r\n");
	XYBody.Append("                        ");	XYBody.Append(info.Discount.ToString());	XYBody.Append("</dd>\r\n");
	XYBody.Append("                    <dd class=\"save\">\r\n");
	XYBody.Append("                        ￥");	XYBody.Append(info.Saved.ToString());	XYBody.Append("</dd>\r\n");
	XYBody.Append("                </dl>\r\n");
	XYBody.Append("                <!-- 购买按钮 -->\r\n");
	XYBody.Append("                <div class=\"item-buy avil\">\r\n");
	XYBody.Append("                    价格：<span>");	XYBody.Append(info.CurrentPrice.ToString());	XYBody.Append("</span> <strong class=\"J_juPrices\"><b>￥</b>");	XYBody.Append(info.CurrentPrice.ToString());	XYBody.Append("</strong>\r\n");
	XYBody.Append("                    <form id=\"frmjointeam\" method=\"post\" action=\"/common/initcart.");	XYBody.Append(config.suffix);	XYBody.Append("\">\r\n");
	XYBody.Append("                    <input type=\"hidden\" name=\"count\" value=\"1\" />\r\n");
	XYBody.Append("                    <input value=\"");	XYBody.Append(info.ProductId.ToString());	XYBody.Append("\" type=\"hidden\" name=\"pid\" />\r\n");
	XYBody.Append("                    <input value=\"");	XYBody.Append(info.Id.ToString());	XYBody.Append("\" type=\"hidden\" name=\"teamid\" />\r\n");
	XYBody.Append("                    <input type=\"image\" class=\"buy\" title=\"参团\" />\r\n");
	XYBody.Append("                    </form>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <!-- 商品详情 end -->\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <!--left end-->\r\n");
	XYBody.Append("    <!--right start-->\r\n");
	XYBody.Append("    <div class=\"i_fr\">\r\n");
	XYBody.Append("        <div id=\"plist\" class=\"rbox\">\r\n");
	XYBody.Append("            <h3>\r\n");
	XYBody.Append("                今日其它团购</h3>\r\n");
	XYBody.Append("            <ul>\r\n");
	XYBody.Append("                " +  XYECOMCreateHTML("XY_团购_其他团购").ToString() + "\r\n");
	XYBody.Append("            </ul>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <!--right end-->\r\n");
	XYBody.Append("</div>\r\n");

	int item__loop__id=0;
	foreach(XYECOM.Model.TeamBuyPriceRangeInfo item in info.TeamBuyPriceRanges)
	{
		item__loop__id++;

	XYBody.Append("<div class=\"jg_list\">\r\n");
	XYBody.Append("    <div class=\"jg_num\">\r\n");

	if (item.OrderUpNum!=-1)
	{

	XYBody.Append("        ");	XYBody.Append(item.OrderNum.ToString());	XYBody.Append("-");	XYBody.Append(item.OrderUpNum.ToString());	XYBody.Append("\r\n");

	}
	else
	{

	XYBody.Append("        >=");	XYBody.Append(item.OrderNum.ToString());	XYBody.Append("\r\n");

	}	//end if

	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <div class=\"jg_price\">\r\n");
	XYBody.Append("        <span>");	XYBody.Append(item.Price.ToString());	XYBody.Append("</span>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("</div>\r\n");

	}	//end loop

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
