<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.shop.buyloglist,XYECOM.Page" %>
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
	XYBody.Append("            <div id=\"gmjl\">\r\n");
	XYBody.Append("                <!--购买记录-->\r\n");
	XYBody.Append("                <div id=\"gmjl_top\">\r\n");
	XYBody.Append("                    购买记录\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <div id=\"gmjl_box\">\r\n");
	XYBody.Append("                    <div id=\"gm_title\">\r\n");
	XYBody.Append("                        <div class=\"gm_r\">\r\n");
	XYBody.Append("                            购买人\r\n");
	XYBody.Append("                        </div>\r\n");
	XYBody.Append("                        <div class=\"gm_j\">\r\n");
	XYBody.Append("                            购买价格\r\n");
	XYBody.Append("                        </div>\r\n");
	XYBody.Append("                        <div class=\"gm_s\">\r\n");
	XYBody.Append("                            数量\r\n");
	XYBody.Append("                        </div>\r\n");
	XYBody.Append("                        <div class=\"gm_d\">\r\n");
	XYBody.Append("                            购买时间\r\n");
	XYBody.Append("                        </div>\r\n");
	XYBody.Append("                    </div>\r\n");
	XYBody.Append("                    <ul>\r\n");

	int buyItem__loop__id=0;
	foreach(DataRow buyItem in infolist.Rows)
	{
		buyItem__loop__id++;

	XYBody.Append("                        <li>\r\n");
	XYBody.Append("                            <div class=\"gm_r\">\r\n");
	XYBody.Append("                                " + buyItem["u_name"].ToString().Trim() + "\r\n");
	XYBody.Append("                            </div>\r\n");
	XYBody.Append("                            <div class=\"gm_j\">\r\n");
	XYBody.Append("                                " + buyItem["Price"].ToString().Trim() + "\r\n");
	XYBody.Append("                            </div>\r\n");
	XYBody.Append("                            <div class=\"gm_s\">\r\n");
	XYBody.Append("                                " + buyItem["Quantity"].ToString().Trim() + "\r\n");
	XYBody.Append("                            </div>\r\n");
	XYBody.Append("                            <div class=\"gm_d\">\r\n");
	XYBody.Append("                                " + buyItem["OrderDate"].ToString().Trim() + "\r\n");
	XYBody.Append("                            </div>\r\n");
	XYBody.Append("                        </li>\r\n");

	}	//end loop

	XYBody.Append("                    </ul>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <div id=\"gmjl_bottom\">\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("            <div class=\"pg\">\r\n");
	XYBody.Append("                当前是第<span class=\"colorf00s\">");	XYBody.Append(pageinfo.PageIndex);	XYBody.Append("</span>页(共");	XYBody.Append(pageinfo.PageCount);	XYBody.Append("页)");	XYBody.Append(pageinfo.FirstPage);	XYBody.Append("&nbsp;");	XYBody.Append(pageinfo.PreviousPage);	XYBody.Append("&nbsp;");	XYBody.Append(pageinfo.NextPage);	XYBody.Append("&nbsp;");	XYBody.Append(pageinfo.LastPage);	XYBody.Append("</div>\r\n");
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
