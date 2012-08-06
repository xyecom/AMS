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
	XYBody.Append("                公司介绍</h2>\r\n");
	XYBody.Append("            <p class=\"font142\">\r\n");

	if (shopuserinfo.imgurl!="")
	{

	XYBody.Append("<img alt=\"");	XYBody.Append(shopuserinfo.loginname.ToString());	XYBody.Append("\" src=\"");	XYBody.Append(shopuserinfo.imgurl.ToString());	XYBody.Append("\" />\r\n");

	}
	else
	{

	XYBody.Append("<img\r\n");
	XYBody.Append("                    alt=\"");	XYBody.Append(shopuserinfo.loginname.ToString());	XYBody.Append("\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/WelcomeInfro_32.gif\" />\r\n");

	}	//end if

	XYBody.Append("                ");	XYBody.Append(shopuserinfo.synopsis.ToString());	XYBody.Append("\r\n");
	XYBody.Append("            </p>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <div class=\"rcon\">\r\n");
	XYBody.Append("            <h2>\r\n");
	XYBody.Append("                详细信息</h2>\r\n");
	XYBody.Append("            <div class=\"rcont\">\r\n");
	XYBody.Append("                <table class=\"table_infos\">\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <th class=\"line1\">\r\n");
	XYBody.Append("                            公司名称：\r\n");
	XYBody.Append("                        </th>\r\n");
	XYBody.Append("                        <td>\r\n");
	XYBody.Append("                            ");	XYBody.Append(shopuserinfo.unitname.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                        <th class=\"line1\">\r\n");
	XYBody.Append("                            成立时间：\r\n");
	XYBody.Append("                        </th>\r\n");
	XYBody.Append("                        <td>\r\n");
	XYBody.Append("                            ");	XYBody.Append(shopuserinfo.regyear.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <th class=\"line1\">\r\n");
	XYBody.Append("                            经营模式：\r\n");
	XYBody.Append("                        </th>\r\n");
	XYBody.Append("                        <td>\r\n");
	XYBody.Append("                            ");	XYBody.Append(shopuserinfo.mode.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                        <th class=\"line1\">\r\n");
	XYBody.Append("                            供应的产品和服务：\r\n");
	XYBody.Append("                        </th>\r\n");
	XYBody.Append("                        <td>\r\n");
	XYBody.Append("                            ");	XYBody.Append(shopuserinfo.supplypro.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <th class=\"line1\">\r\n");
	XYBody.Append("                            公司主页：\r\n");
	XYBody.Append("                        </th>\r\n");
	XYBody.Append("                        <td>\r\n");
	XYBody.Append("                            <a href=\"");	XYBody.Append(shopuserinfo.homepage.ToString());	XYBody.Append("\">");	XYBody.Append(shopuserinfo.homepage.ToString());	XYBody.Append("</a>\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                        <th class=\"line1\">\r\n");
	XYBody.Append("                            注册资本：\r\n");
	XYBody.Append("                        </th>\r\n");
	XYBody.Append("                        <td>\r\n");
	XYBody.Append("                            ");	XYBody.Append(shopuserinfo.registeredcapital.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <th class=\"line1 colorFF7300\">\r\n");
	XYBody.Append("                            企业类型：\r\n");
	XYBody.Append("                        </th>\r\n");
	XYBody.Append("                        <td>\r\n");
	XYBody.Append("                            ");	XYBody.Append(shopuserinfo.unittype.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                        <th class=\"line1 colorFF7300\">\r\n");
	XYBody.Append("                            公司性质：\r\n");
	XYBody.Append("                        </th>\r\n");
	XYBody.Append("                        <td>\r\n");
	XYBody.Append("                            ");	XYBody.Append(shopuserinfo.character.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <th class=\"line1\">\r\n");
	XYBody.Append("                            员工人数：\r\n");
	XYBody.Append("                        </th>\r\n");
	XYBody.Append("                        <td>\r\n");
	XYBody.Append("                            ");	XYBody.Append(shopuserinfo.employeetotal.ToString());	XYBody.Append("人\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                        <th class=\"line1 colorFF7300\">\r\n");
	XYBody.Append("                            公司注册地：\r\n");
	XYBody.Append("                        </th>\r\n");
	XYBody.Append("                        <td>\r\n");
	XYBody.Append("                            ");	XYBody.Append(shopuserinfo.regarea.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                </table>\r\n");
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
