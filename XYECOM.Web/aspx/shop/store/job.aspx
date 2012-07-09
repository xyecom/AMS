<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.shop.job,XYECOM.Page" %>
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
	XYBody.Append("            <em id=\"clicknum\" style=\"display: none\"></em><em id=\"msy\" style=\"display: none\">\r\n");
	XYBody.Append("            </em><em id=\"clicknum1\" style=\"display: none\"></em><em id=\"messnum\" style=\"display: none\">\r\n");
	XYBody.Append("            </em>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <!--公司介绍职位-->\r\n");
	XYBody.Append("        <div class=\"rcon\">\r\n");
	XYBody.Append("            <h2>\r\n");
	XYBody.Append("                职位介绍</h2>\r\n");
	XYBody.Append("            <table class=\"table_infos\">\r\n");
	XYBody.Append("                <tr>\r\n");
	XYBody.Append("                    <th class=\"line1\">\r\n");
	XYBody.Append("                        职位名称：\r\n");
	XYBody.Append("                    </th>\r\n");
	XYBody.Append("                    <td>\r\n");
	XYBody.Append("                        ");	XYBody.Append(jobinfo.JobTitle.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                    </td>\r\n");
	XYBody.Append("                    <th class=\"line1\">\r\n");
	XYBody.Append("                        招聘人数：\r\n");
	XYBody.Append("                    </th>\r\n");
	XYBody.Append("                    <td>\r\n");
	XYBody.Append("                        ");	XYBody.Append(jobinfo.Number.ToString());	XYBody.Append(" 人\r\n");
	XYBody.Append("                    </td>\r\n");
	XYBody.Append("                </tr>\r\n");
	XYBody.Append("                <tr>\r\n");
	XYBody.Append("                    <th class=\"line1\">\r\n");
	XYBody.Append("                        工作性质：\r\n");
	XYBody.Append("                    </th>\r\n");
	XYBody.Append("                    <td>\r\n");
	XYBody.Append("                        ");	XYBody.Append(jobinfo.JobType.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                    </td>\r\n");
	XYBody.Append("                    <th class=\"line1\">\r\n");
	XYBody.Append("                        性别要求：\r\n");
	XYBody.Append("                    </th>\r\n");
	XYBody.Append("                    <td>\r\n");
	XYBody.Append("                        ");	XYBody.Append(jobinfo.Sex.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                    </td>\r\n");
	XYBody.Append("                </tr>\r\n");
	XYBody.Append("                <tr>\r\n");
	XYBody.Append("                    <th class=\"line1\">\r\n");
	XYBody.Append("                        学历要求：\r\n");
	XYBody.Append("                    </th>\r\n");
	XYBody.Append("                    <td>\r\n");
	XYBody.Append("                        ");	XYBody.Append(jobinfo.Education.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                    </td>\r\n");
	XYBody.Append("                    <th class=\"line1\">\r\n");
	XYBody.Append("                        年龄要求：\r\n");
	XYBody.Append("                    </th>\r\n");
	XYBody.Append("                    <td>\r\n");
	XYBody.Append("                        ");	XYBody.Append(jobinfo.Age.ToString());	XYBody.Append(" 岁\r\n");
	XYBody.Append("                    </td>\r\n");
	XYBody.Append("                </tr>\r\n");
	XYBody.Append("                <tr>\r\n");
	XYBody.Append("                    <th class=\"line1\">\r\n");
	XYBody.Append("                        工作经验：\r\n");
	XYBody.Append("                    </th>\r\n");
	XYBody.Append("                    <td>\r\n");
	XYBody.Append("                        ");	XYBody.Append(jobinfo.Experience.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                    </td>\r\n");
	XYBody.Append("                    <th class=\"line1\">\r\n");
	XYBody.Append("                        待遇：\r\n");
	XYBody.Append("                    </th>\r\n");
	XYBody.Append("                    <td>\r\n");
	XYBody.Append("                        ");	XYBody.Append(jobinfo.Pay.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                    </td>\r\n");
	XYBody.Append("                </tr>\r\n");
	XYBody.Append("                <tr>\r\n");
	XYBody.Append("                    <th class=\"line1\">\r\n");
	XYBody.Append("                        工作地点：\r\n");
	XYBody.Append("                    </th>\r\n");
	XYBody.Append("                    <td>\r\n");
	XYBody.Append("                        ");	XYBody.Append(jobinfo.WorkAreaInfo.FullName.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                    </td>\r\n");
	XYBody.Append("                    <th class=\"line1\">\r\n");
	XYBody.Append("                        结束时间：\r\n");
	XYBody.Append("                    </th>\r\n");
	XYBody.Append("                    <td>\r\n");
	XYBody.Append("                        ");	XYBody.Append(jobinfo.EndDate.ToShortDateString().ToString());	XYBody.Append("\r\n");
	XYBody.Append("                    </td>\r\n");
	XYBody.Append("                </tr>\r\n");
	XYBody.Append("                <tr>\r\n");
	XYBody.Append("                    <th class=\"line1\">\r\n");
	XYBody.Append("                        职位说明：\r\n");
	XYBody.Append("                    </th>\r\n");
	XYBody.Append("                    <td class=\"w650\" colspan=\"3\">\r\n");
	XYBody.Append("                        ");	XYBody.Append(jobinfo.Request.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                    </td>\r\n");
	XYBody.Append("                </tr>\r\n");
	XYBody.Append("                <tr>\r\n");
	XYBody.Append("                    <th>\r\n");
	XYBody.Append("                    </th>\r\n");
	XYBody.Append("                    <td class=\"w650\" colspan=\"3\">\r\n");
	XYBody.Append("                        <a href=\"javascript:ApplyJob();\">申请该职位</a>\r\n");
	XYBody.Append("                    </td>\r\n");
	XYBody.Append("                </tr>\r\n");
	XYBody.Append("            </table>\r\n");
	XYBody.Append("            <h4>\r\n");
	XYBody.Append("                该企业其它职位</h4>\r\n");
	XYBody.Append("            <div class=\"jobqt\">\r\n");
	 data = GetOtherJob();
	

	int job__loop__id=0;
	foreach(DataRow job in data.Rows)
	{
		job__loop__id++;

	 infourl = GetInfoUrl("job",job["EI_ID"],job["EI_HTMLPage"]);
	
	XYBody.Append("                <span><a href=\"");	XYBody.Append(infourl.ToString());	XYBody.Append("\">" + job["EI_Job"].ToString().Trim() + "</a></span>\r\n");

	}	//end loop

	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <!--联系方式-->\r\n");
	XYBody.Append("        <div class=\"rcon\">\r\n");
	XYBody.Append("            <h2>\r\n");
	XYBody.Append("                联系方式</h2>\r\n");
	XYBody.Append("            <!--联系方式-->\r\n");
	XYBody.Append("            <div class=\"infoAbout\">\r\n");
	XYBody.Append("                <a name=\"link\"></a>\r\n");
	XYBody.Append("                <div id=\"linkmessage\">\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <!--推荐给好友-->\r\n");
	XYBody.Append("        <div class=\"rcon pb15\">\r\n");
	XYBody.Append("            <h2>\r\n");
	XYBody.Append("                推荐给好友</h2>\r\n");
	XYBody.Append("            <div class=\"commentList\">\r\n");
	XYBody.Append("                <ul>\r\n");
	XYBody.Append("                    <li>\r\n");
	XYBody.Append("                        <label>\r\n");
	XYBody.Append("                            您的姓名：<em>*</em></label><input type=\"text\" size=\"30\" id=\"txtFromName\" maxlength=\"200\" /></li>\r\n");
	XYBody.Append("                    <li>\r\n");
	XYBody.Append("                        <label>\r\n");
	XYBody.Append("                            您的邮箱：<em>*</em></label><input type=\"text\" size=\"30\" id=\"txtFromEmail\" maxlength=\"200\" /></li>\r\n");
	XYBody.Append("                    <li>\r\n");
	XYBody.Append("                        <label>\r\n");
	XYBody.Append("                            您朋友邮箱：<em>*</em></label><input type=\"text\" size=\"30\" id=\"txtToEmail\" maxlength=\"200\" /><i>\r\n");
	XYBody.Append("                                多个邮箱以\",\"隔开</i></li>\r\n");
	XYBody.Append("                    <li>\r\n");
	XYBody.Append("                        <input name=\"\" type=\"button\" class=\"button\" value=\"确 定\" onclick=\"CommendJob();\" />\r\n");
	XYBody.Append("                        <input type=\"button\" name=\"Submit\" class=\"button\" value=\"清 空\" onclick=\"emptycommend();\" /></li>\r\n");
	XYBody.Append("                </ul>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <input type=\"hidden\" id=\"JobId\" value=\"");	XYBody.Append(jobinfo.JobId.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("    <input type=\"hidden\" id=\"txtjobname\" value=\"");	XYBody.Append(jobinfo.JobTitle.ToString());	XYBody.Append("\" />\r\n");
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
