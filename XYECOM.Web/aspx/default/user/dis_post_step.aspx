<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.user.dis_post_step,XYECOM.Page" %>
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

	XYBody.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n");
	XYBody.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n");
	XYBody.Append("<head>\r\n");
	XYBody.Append("    <title>");	XYBody.Append(userinfo.name.ToString());	XYBody.Append("</title>\r\n");
	XYBody.Append("    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=gb2312\">\r\n");
	XYBody.Append("    <meta content=\"个人中心\" name=\"keywords\">\r\n");
	XYBody.Append("    <meta content=\"\" name=\"description\">\r\n");
	XYBody.Append("    <link href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/user/css/main.css\" rel=\"stylesheet\"\r\n");
	XYBody.Append("        type=\"text/css\" />\r\n");
	XYBody.Append("    <link href=\"/common/css/XYLib.css\" type=\"text/css\" rel=\"Stylesheet\" />\r\n");
	XYBody.Append("    <script language=\"javascript\" type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("config/js/config.js\"></" + "script>\r\n");
	XYBody.Append("    <script language=\"javascript\" type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("common/js/base.js\"></" + "script>\r\n");
	XYBody.Append("    <script language=\"javascript\" type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("common/js/UploadControl.js\"></" + "script>\r\n");
	XYBody.Append("    <script language=\"javascript\" type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("common/js/date.js\"></" + "script>\r\n");
	XYBody.Append("    <script language=\"javascript\" type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/user/js/common.js\"></" + "script>\r\n");
	XYBody.Append("    <script language=\"javascript\" type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/user/js/validate.js\"></" + "script>\r\n");
	XYBody.Append("    ");	XYBody.Append(pageinfo.Meta);	XYBody.Append("\r\n");
	XYBody.Append("</head>\r\n");
	XYBody.Append("<body onload=\"");	XYBody.Append(pageinfo.OnLoadEvents);	XYBody.Append("\">\r\n");
	XYBody.Append("    <div class=\"div_body\">\r\n");
	XYBody.Append("        <div class=\"New_top\">\r\n");
	XYBody.Append("            <div class=\"more\">\r\n");
	XYBody.Append("                <ul>\r\n");
	XYBody.Append("                    <li><a class=\"zeroc\" href=\"");	XYBody.Append(config.weburl);	XYBody.Append("\">首页</a> </li>\r\n");
	XYBody.Append("                    <li><a class=\"zeroc\" href=\"");	XYBody.Append(config.weburl);	XYBody.Append("news/\">行业资讯</a> </li>\r\n");
	XYBody.Append("                    <li><a class=\"zeroc\" href=\"");	XYBody.Append(config.weburl);	XYBody.Append("offer/\">产品库</a> </li>\r\n");
	XYBody.Append("                    <li><a class=\"zeroc\" href=\"");	XYBody.Append(config.weburl);	XYBody.Append("investment/\">招商加盟</a> </li>\r\n");
	XYBody.Append("                    <li><a class=\"zeroc\" href=\"");	XYBody.Append(config.weburl);	XYBody.Append("exhibition/\">展会</a> </li>\r\n");
	XYBody.Append("                    <li><a class=\"zeroc\" href=\"");	XYBody.Append(config.weburl);	XYBody.Append("job/\">人才</a> </li>\r\n");
	XYBody.Append("                </ul>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("            <div class=\"r\">\r\n");
	XYBody.Append("                <a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("user/index.");	XYBody.Append(config.suffix);	XYBody.Append("\" style=\"font-weight: bold; text-decoration: underline;\">\r\n");
	XYBody.Append("                    ");	XYBody.Append(userinfo.loginname.ToString());	XYBody.Append("</a> | <a href=\"");	XYBody.Append(userinfo.shopindex.ToString());	XYBody.Append("\" target=\"_blank\">我的商铺</a>\r\n");
	XYBody.Append("                | <a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("logout.");	XYBody.Append(config.suffix);	XYBody.Append("\">退出</a> | <a href=\"\">帮助</a>&nbsp;\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <div class=\"Head\">\r\n");
	XYBody.Append("        <div class=\"Head_1\">\r\n");
	XYBody.Append("            <img src=\"/templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/user/images/logo.gif\" /></div>\r\n");
	XYBody.Append("        <div class=\"Head_2 mt8\">\r\n");
	XYBody.Append("            ");	XYBody.Append(userinfo.name.ToString());	XYBody.Append("</div>\r\n");
	XYBody.Append("        <div class=\"Head_3\">\r\n");
	XYBody.Append("            <input value=\"\" id=\"txtsearchkey\" /><a href=\"#\" onclick=\"searchClick();\">搜索</a>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <div class=\"Head_4\">\r\n");
	XYBody.Append("            <div class=\"index\">\r\n");
	XYBody.Append("                <div class=\"act\" id=\"_m_index\">\r\n");
	XYBody.Append("                    <a href=\"index.");	XYBody.Append(config.suffix);	XYBody.Append("\">主 页</a></div>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("            <div onmouseover=\"document.getElementById('frend').style.display='block';\" onmouseout=\"document.getElementById('frend').style.display='none';\">\r\n");
	XYBody.Append("                <div>\r\n");
	XYBody.Append("                    <div class=\"menu\" id=\"frend\" style=\"z-index: 999;\">\r\n");
	XYBody.Append("                        <a href=\"infoselect.");	XYBody.Append(config.suffix);	XYBody.Append("\">发布信息</a> <a href=\"addnews.");	XYBody.Append(config.suffix);	XYBody.Append("\">发布资讯</a>\r\n");
	XYBody.Append("                        <a href=\"engageadd.");	XYBody.Append(config.suffix);	XYBody.Append("\">发布招聘</a> <a href=\"cashacount.");	XYBody.Append(config.suffix);	XYBody.Append("\">账户管理</a>\r\n");
	XYBody.Append("                    </div>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <div class=\"nor\" id=\"_m_quick\">\r\n");
	XYBody.Append("                    <a class=\"more\" id=\"f_a\" href=\"infoselect.");	XYBody.Append(config.suffix);	XYBody.Append("\">快捷菜单</a></div>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("            <div onmouseover=\"document.getElementById('msg').style.display='block';\" onmouseout=\"document.getElementById('msg').style.display='none';\">\r\n");
	XYBody.Append("                <div>\r\n");
	XYBody.Append("                    <div class=\"menu\" id=\"msg\" style=\"z-index: 999\">\r\n");
	XYBody.Append("                        <a href=\"receivemessagelist.");	XYBody.Append(config.suffix);	XYBody.Append("\">收件箱</a> <a href=\"sendmessagelist.");	XYBody.Append(config.suffix);	XYBody.Append("\">\r\n");
	XYBody.Append("                            已发送消息</a> <a href=\"postadministratormessage.");	XYBody.Append(config.suffix);	XYBody.Append("\">给管理员留言</a> <a href=\"joinlist.");	XYBody.Append(config.suffix);	XYBody.Append("\">\r\n");
	XYBody.Append("                                收加盟信息</a> <a href=\"joinlist.");	XYBody.Append(config.suffix);	XYBody.Append("?type=send\">已发加盟信息</a>\r\n");
	XYBody.Append("                    </div>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <div class=\"nor\" id=\"_m_msg\">\r\n");
	XYBody.Append("                    <a class=\"more\" id=\"m_a\" href=\"receivemessagelist.");	XYBody.Append(config.suffix);	XYBody.Append("\">短消息(");	XYBody.Append(userinfo.messagecount.ToString());	XYBody.Append(")</a></div>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("            <div class=\"nor\" id=\"_m_userinfo\">\r\n");
	XYBody.Append("                <a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("user/edituserinfo.");	XYBody.Append(config.suffix);	XYBody.Append("\">企业资料</a></div>\r\n");
	XYBody.Append("            <div class=\"nor\" id=\"_m_safe\">\r\n");
	XYBody.Append("                <a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("user/edituserpassword.");	XYBody.Append(config.suffix);	XYBody.Append("\">安全设置</a></div>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <script>xy_Sel_CurTopMenu();</" + "script>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <div class=\"div_body\" style=\"width: 994px\">\r\n");
	XYBody.Append("        <div class=\"body_bg\">\r\n");
	XYBody.Append("            <div>\r\n");
	XYBody.Append("                <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/user/images/p1.jpg\"></div>\r\n");
	XYBody.Append("            <div class=\"bodyW\">\r\n");


	XYBody.Append("<div class=\"location fia\"><a href=\"index.");	XYBody.Append(config.Suffix);	XYBody.Append("\">商务中心</a> &gt;  发布商业信息</div>\r\n");

	XYBody.Append("<!--\r\n");
	XYBody.Append("    添加链接时，请链接一定需写成 ****绝对路径****\r\n");
	XYBody.Append("    -->\r\n");
	XYBody.Append("<div class=\"Al\">\r\n");
	XYBody.Append("    <div class=\"Al_1\">\r\n");
	XYBody.Append("        会员服务列表:</div>\r\n");
	XYBody.Append("    <div class=\"Al_2\">\r\n");
	XYBody.Append("        <dl>\r\n");
	XYBody.Append("            <dt><a style=\"padding-right: 10px\" id=\"a_1\" onclick=\"javascript:switchShow('1')\"\r\n");
	XYBody.Append("                href=\"javascript:void(0);\">\r\n");
	XYBody.Append("                <img src=\"/user/image/a9.gif\">\r\n");
	XYBody.Append("                我的商业信息 </a></dt>\r\n");
	XYBody.Append("            <dd style=\"display: block\" id=\"div_1\">\r\n");
	XYBody.Append("                <a href=\"/user/infoselect.aspx\">发布商业信息</a><br />\r\n");
	XYBody.Append("                <a href=\"/user/adv_postbuy.aspx\">发布求购信息</a><br />\r\n");
	XYBody.Append("                <a href=\"/user/supplybuy.aspx\">管理求购信息</a><br />\r\n");
	XYBody.Append("                <a href=\"/user/SupplyPubList.aspx\">管理供应信息</a><br />\r\n");
	XYBody.Append("                <a href=\"/user/teambuy/TeamBuyPublishList.aspx\">管理团购信息</a><br />\r\n");
	XYBody.Append("                <a href=\"/user/ContractSupplyPubList.aspx\">管理合同担保交易</a><br />\r\n");
	XYBody.Append("                <a href=\"/user/Venture/FinancingList.aspx\">管理融资信息</a><br />\r\n");
	XYBody.Append("                <a href=\"/user/Venture/InvestmentList.aspx\">管理投资信息</a><br />\r\n");
	XYBody.Append("                <a href=\"/user/ReceiveAddressList.aspx\">收货人信息管理</a><br />\r\n");
	XYBody.Append("                <a href=\"/user/DepotList.aspx\">库房信息管理</a><br />\r\n");
	XYBody.Append("                <a href=\"/user/businesslist.aspx?ename=investment\">管理招商代理</a><br />\r\n");
	XYBody.Append("                <a href=\"/user/surrogatelist.aspx?ename=service\">管理服务信息</a><br />\r\n");
	XYBody.Append("                <a href=\"/user/userbrandlist.aspx\">管理品牌信息</a><br />\r\n");
	XYBody.Append("                <a href=\"/user/SupplyTypeList.aspx\">自定义分类管理</a><br />\r\n");
	XYBody.Append("            </dd>\r\n");
	XYBody.Append("        </dl>\r\n");
	XYBody.Append("        <dl>\r\n");
	XYBody.Append("            <dt><a style=\"padding-right: 10px\" id=\"a_2\" onclick=\"javascript:switchShow('2')\"\r\n");
	XYBody.Append("                href=\"javascript:void(0);\">\r\n");
	XYBody.Append("                <img src=\"/user/image/1.gif\">\r\n");
	XYBody.Append("                关键词排名 </a></dt>\r\n");
	XYBody.Append("            <dd style=\"display: none\" id=\"div_2\">\r\n");
	XYBody.Append("                <a href=\"/user/searchkeyword.aspx\">搜索关键字</a><br />\r\n");
	XYBody.Append("                <a href=\"/user/curranking.aspx\">正在参与的关键字</a><br />\r\n");
	XYBody.Append("                <a href=\"/user/historyranking.aspx\">排名历史记录</a><br />\r\n");
	XYBody.Append("            </dd>\r\n");
	XYBody.Append("        </dl>\r\n");
	XYBody.Append("        <dl>\r\n");
	XYBody.Append("            <dt><a style=\"padding-right: 10px\" id=\"a_3\" onclick=\"javascript:switchShow('3')\"\r\n");
	XYBody.Append("                href=\"javascript:void(0);\">\r\n");
	XYBody.Append("                <img src=\"/user/image/5.gif\">\r\n");
	XYBody.Append("                我的商铺设置 </a></dt>\r\n");
	XYBody.Append("            <dd style=\"display: none\" id=\"div_3\">\r\n");
	XYBody.Append("                <a href=\"/user/selectshoptemp.aspx\">选择商铺模板</a><br />\r\n");
	XYBody.Append("                <a href=\"/user/uploadlogo.aspx\">上传商铺图片</a><br />\r\n");
	XYBody.Append("                <a href=\"/user/UploadVideo.aspx\">上传形象视频</a><br />\r\n");
	XYBody.Append("                <a href=\"/user/SlidesInfoList.aspx\">幻灯片管理</a><br />\r\n");
	XYBody.Append("                <a href=\"/user/bindingdomain.aspx\">绑定顶级域名</a><br />\r\n");
	XYBody.Append("                <a href=\"/user/userfirendlink.aspx\">友情链接管理</a><br />\r\n");
	XYBody.Append("                <a href=\"/user/userannounce.aspx\">商铺公告管理</a><br />\r\n");
	XYBody.Append("                <a href=\"/user/newlist.aspx\">企业资讯管理</a><br />\r\n");
	XYBody.Append("                <a href=\"/user/engagelist.aspx\">招聘信息管理</a><br />\r\n");
	XYBody.Append("                <a href=\"/user/certificatelist.aspx\">企业证书管理</a><br />\r\n");
	XYBody.Append("                <a href=\"/user/partlist.aspx\">企业专栏管理</a><br />\r\n");
	XYBody.Append("                <a href=\"/user/usertitleinfolist.aspx\">资讯栏目管理</a><br />\r\n");
	XYBody.Append("                <a href=\"/user/newlist.aspx\">资讯信息管理</a><br />\r\n");
	XYBody.Append("                <a href=\"/user/SEO.aspx\">网店SEO设置</a><br />\r\n");
	XYBody.Append("            </dd>\r\n");
	XYBody.Append("        </dl>\r\n");
	XYBody.Append("        <dl>\r\n");
	XYBody.Append("            <dt><a style=\"padding-right: 10px\" id=\"a_8\" onclick=\"javascript:switchShow('8')\"\r\n");
	XYBody.Append("                href=\"javascript:void(0);\">\r\n");
	XYBody.Append("                <img src=\"/user/image/3.gif\">\r\n");
	XYBody.Append("                我的交易信息 </a></dt>\r\n");
	XYBody.Append("            <dd style=\"display: none\" id=\"div_8\">\r\n");
	XYBody.Append("                <a href=\"/user/BuyerOrderList.aspx\">采购管理</a><br />\r\n");
	XYBody.Append("                <a href=\"/user/SellerOrderList.aspx\">销售管理</a><br />\r\n");
	XYBody.Append("                <a href=\"/user/Contract/ListBuyerContract.aspx\">作为买家的合同</a><br />\r\n");
	XYBody.Append("                <a href=\"/user/Contract/ListSellerContract.aspx\">作为卖家的合同</a><br />\r\n");
	XYBody.Append("                <a href=\"/user/TeamBuy/TeamSellerOrderList.aspx\">卖家的团购订单</a><br />\r\n");
	XYBody.Append("                <a href=\"/user/TeamBuy/TeamBuyerOrderList.aspx\">买家的团购订单</a><br />\r\n");
	XYBody.Append("            </dd>\r\n");
	XYBody.Append("        </dl>\r\n");
	XYBody.Append("        <dl>\r\n");
	XYBody.Append("            <dt><a style=\"padding-right: 10px\" id=\"a_4\" onclick=\"javascript:switchShow('4')\"\r\n");
	XYBody.Append("                href=\"javascript:void(0);\">\r\n");
	XYBody.Append("                <img src=\"/user/image/a9.gif\" alt=\"\" />\r\n");
	XYBody.Append("                分类广告位 </a></dt>\r\n");
	XYBody.Append("            <dd style=\"display: none\" id=\"div_4\">\r\n");
	XYBody.Append("                <a href=\"/user/buyclassads.aspx\">购买分类广告</a><br />\r\n");
	XYBody.Append("                <a href=\"/user/curclassads.aspx\">正在参与的广告</a><br />\r\n");
	XYBody.Append("                <a href=\"/user/hisclassads.aspx\">历史参与的广告</a><br />\r\n");
	XYBody.Append("            </dd>\r\n");
	XYBody.Append("        </dl>\r\n");
	XYBody.Append("        <dl>\r\n");
	XYBody.Append("            <dt><a style=\"padding-right: 10px\" id=\"a_5\" onclick=\"javascript:switchShow('5')\"\r\n");
	XYBody.Append("                href=\"javascript:void(0);\">\r\n");
	XYBody.Append("                <img src=\"/user/image/a10.gif\" alt=\"\" />\r\n");
	XYBody.Append("                我的财务信息 </a></dt>\r\n");
	XYBody.Append("            <dd style=\"display: none\" id=\"div_5\">\r\n");
	XYBody.Append("                <a href=\"/user/cashacount.aspx\">现金消费明细</a><br />\r\n");
	XYBody.Append("                <a href=\"/user/ContractMargin/SupplementConMargin.aspx\">充值合同保证金</a><br />\r\n");
	XYBody.Append("                <a href=\"/user/inputmoney.aspx\">充值明细</a><br />\r\n");
	XYBody.Append("                <a href=\"/user/invoicelist.aspx\">发票列表</a><br />\r\n");
	XYBody.Append("                <a href=\"/user/invoice.aspx\">申请发票</a><br />\r\n");
	XYBody.Append("                <a href=\"/user/remit.aspx\">汇款确认</a><br />\r\n");
	XYBody.Append("                <a href=\"/user/FictitiouConsumptionInfo.aspx\">网站币消费明细</a><br />\r\n");
	XYBody.Append("            </dd>\r\n");
	XYBody.Append("        </dl>\r\n");
	XYBody.Append("        <dl>\r\n");
	XYBody.Append("            <dt><a style=\"padding-right: 10px\" id=\"a_9\" onclick=\"javascript:switchShow('9')\"\r\n");
	XYBody.Append("                href=\"javascript:void(0);\">\r\n");
	XYBody.Append("                <img src=\"/user/image/a9.gif\">\r\n");
	XYBody.Append("                礼品兑换 </a></dt>\r\n");
	XYBody.Append("            <dd style=\"display: none\" id=\"div_9\">\r\n");
	XYBody.Append("                <a href=\"/user/getgift.aspx\">礼品列表</a><br />\r\n");
	XYBody.Append("                <a href=\"/user/mygift.aspx\">我的礼品</a><br />\r\n");
	XYBody.Append("            </dd>\r\n");
	XYBody.Append("        </dl>\r\n");
	XYBody.Append("        <dl>\r\n");
	XYBody.Append("            <dt><a style=\"padding-right: 10px\" id=\"a_7\" onclick=\"javascript:switchShow('7')\"\r\n");
	XYBody.Append("                href=\"javascript:void(0);\">\r\n");
	XYBody.Append("                <img src=\"/user/image/buyer.gif\">\r\n");
	XYBody.Append("                我收藏的信息 </a></dt>\r\n");
	XYBody.Append("            <dd style=\"display: none\" id=\"div_7\">\r\n");
	XYBody.Append("                <a href=\"/user/companys.aspx\">收藏企业管理</a><br />\r\n");
	XYBody.Append("                <a href=\"/user/favoritelist.aspx\">收藏的商业信息</a><br />\r\n");
	XYBody.Append("            </dd>\r\n");
	XYBody.Append("        </dl>\r\n");
	XYBody.Append("        <dl>\r\n");
	XYBody.Append("            <dt><a style=\"padding-right: 10px\" id=\"a_6\" onclick=\"javascript:switchShow('6')\"\r\n");
	XYBody.Append("                href=\"javascript:void(0);\">\r\n");
	XYBody.Append("                <img src=\"/user/image/a6.gif\">\r\n");
	XYBody.Append("                我的账户信息 </a></dt>\r\n");
	XYBody.Append("            <dd style=\"display: none\" id=\"div_6\">\r\n");
	XYBody.Append("                <a href=\"/user/registerinfo.aspx\">查看注册信息</a><br />\r\n");
	XYBody.Append("                <a href=\"/user/edituserinfo.aspx\">修改注册信息</a><br />\r\n");
	XYBody.Append("                <a href=\"/user/edituserinfomore.aspx\">补充企业资料</a><br />\r\n");
	XYBody.Append("                <a href=\"/user/edituserpassword.aspx\">修改登陆密码</a><br />\r\n");
	XYBody.Append("                <a href=\"/user/editpaypassword.aspx\">修改支付密码</a><br />\r\n");
	XYBody.Append("            </dd>\r\n");
	XYBody.Append("        </dl>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <script type=\"text/javascript\">\r\n");
	XYBody.Append("        xy_Sel_CurLeftMenu();\r\n");
	XYBody.Append("    </" + "script>\r\n");
	XYBody.Append("</div>\r\n");


	XYBody.Append(" <div id=\"right\">\r\n");
	XYBody.Append("  <form  action=\"#\" method=\"post\">\r\n");
	XYBody.Append("  <h3>发布");	XYBody.Append(infoname.ToString());	XYBody.Append("</h3>\r\n");
	XYBody.Append(" <table  class=\"contentl\">\r\n");
	XYBody.Append("    <tr>\r\n");
	XYBody.Append("        <th>信息类型：<em>*</em></th>\r\n");
	XYBody.Append("        <td>\r\n");

	int item__loop__id=0;
	foreach(ModuleItemInfo item in module.Item)
	{
		item__loop__id++;


	if (item__loop__id==1)
	{

	 initvalue = item.Prefix;
	
	 infotypestr = item.InfoTypeStr;
	
	XYBody.Append("                <input type=\"radio\" name=\"items\" value=\"");	XYBody.Append(item.ID.ToString());	XYBody.Append("\"  checked =\"checked\" onclick=\"SetElementValue('infotitle,hidInfoType','");	XYBody.Append(item.Prefix.ToString());	XYBody.Append("');InitInfoAddPageForm('");	XYBody.Append(module.EName.ToString());	XYBody.Append("','");	XYBody.Append(module.PEName.ToString());	XYBody.Append("','");	XYBody.Append(item.InfoTypeStr.ToString());	XYBody.Append("');\"/>");	XYBody.Append(item.Prefix.ToString());	XYBody.Append("");	XYBody.Append(item.Postfix.ToString());	XYBody.Append("\r\n");

	}
	else
	{

	XYBody.Append("                <input type=\"radio\" name=\"items\" value=\"");	XYBody.Append(item.ID.ToString());	XYBody.Append("\" onclick=\"SetElementValue('infotitle,hidInfoType','");	XYBody.Append(item.Prefix.ToString());	XYBody.Append("');InitInfoAddPageForm('");	XYBody.Append(module.EName.ToString());	XYBody.Append("','");	XYBody.Append(module.PEName.ToString());	XYBody.Append("','");	XYBody.Append(item.InfoTypeStr.ToString());	XYBody.Append("');\"/>");	XYBody.Append(item.Prefix.ToString());	XYBody.Append("");	XYBody.Append(item.Postfix.ToString());	XYBody.Append("\r\n");

	}	//end if


	}	//end loop

	XYBody.Append("        </td>\r\n");
	XYBody.Append("    </tr>   \r\n");
	XYBody.Append("  <tr id=\"ptname\">\r\n");
	XYBody.Append("   <th>信息名称：<em>*</em></th>\r\n");
	XYBody.Append("   <td  class=\"two\"><input id=\"infotitle\" name=\"infotitle\" type=\"text\" size=\"35\"  maxlength=\"40\" value=\"");	XYBody.Append(initvalue.ToString());	XYBody.Append("\"/>\r\n");
	XYBody.Append("   <em id=\"txt0\" class=\"three\">信息标题中请勿出现特殊字符。</em>\r\n");
	XYBody.Append("   </td>\r\n");
	XYBody.Append("  </tr>\r\n");

	if (module.EName=="offer"||module.PEName=="offer")
	{


	if (userinfo.iscompanyprotype==true)
	{

	XYBody.Append("    <tr>\r\n");
	XYBody.Append("    <th>自定义产品分类：</th>\r\n");
	XYBody.Append("    <td  class=\"two\">\r\n");
	XYBody.Append("         <div id=\"customerType\">\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <input id=\"upt\" name=\"upt\" type=\"hidden\" value=\"\" />\r\n");
	XYBody.Append("                <input id=\"flag\" type=\"hidden\" value=\"companytype\" />\r\n");
	XYBody.Append("                <script type=\"text/javascript\">\r\n");
	XYBody.Append("                    var cla2 = new ClassType(\"cla2\", 'flag', 'customerType', 'upt', 999, 'xy001', 'uid:\r\n");
	XYBody.Append("<%=userinfo.userid %>\r\n");
	XYBody.Append("');\r\n");
	XYBody.Append("                    cla2.Mode = \"select\";\r\n");
	XYBody.Append("                    cla2.Init();\r\n");
	XYBody.Append("                </" + "script>\r\n");
	XYBody.Append("    <em id=\"Em1\" class=\"three\">选择自定义产品分类。</em>\r\n");
	XYBody.Append("    </td></tr>\r\n");

	}	//end if


	}	//end if

	XYBody.Append("  <tr id=\"prodpt\">\r\n");
	XYBody.Append("  <input type=\"hidden\" id=\"hidInfoTypeStr\" value=\"");	XYBody.Append(infotypestr.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("  <input type=\"hidden\" id=\"hidInfoType\" value=\"");	XYBody.Append(initvalue.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("  <input type=\"hidden\" id=\"hidModuleName\" value=\"");	XYBody.Append(module.EName.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("  <input type=\"hidden\" id=\"hidTypeId\"  name=\"hidTypeId\"/>\r\n");
	XYBody.Append("   <th>选择信息类别：<em>*</em></th>\r\n");
	XYBody.Append("   <td>\r\n");
	XYBody.Append("   <div id=\"classType\"></div>\r\n");
	XYBody.Append("    <script type=\"text/javascript\">\r\n");
	XYBody.Append("    var cla = new ClassType(\"cla\",'hidModuleName','classType','hidTypeId',null,null,\"tradeids:");	XYBody.Append(userinfo.tradeids.ToString());	XYBody.Append("\");\r\n");
	XYBody.Append("    cla.Mode = \"select\";\r\n");
	XYBody.Append("    cla.OnChange = GetFieldInnerHTML;\r\n");
	XYBody.Append("    cla.Init();\r\n");
	XYBody.Append("    </" + "script>\r\n");
	XYBody.Append("   </td>\r\n");
	XYBody.Append("  </tr>\r\n");
	XYBody.Append("  <tr>\r\n");
	XYBody.Append("<th> 信息属性：<em>*</em></th>\r\n");
	XYBody.Append("<td id=\"tabFieldBody\">\r\n");
	XYBody.Append("</td>\r\n");
	XYBody.Append("</tr>\r\n");
	XYBody.Append(" <tr>\r\n");
	XYBody.Append(" <th>详细说明：<em>*</em></th>\r\n");
	XYBody.Append(" <td>\r\n");
	XYBody.Append("<script language =\"javascript\" type=\"text/javascript\"  src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("common/fckeditor/fckeditor.js\"></" + "script>\r\n");
	XYBody.Append("  <script language=\"javascript\" type=\"text/javascript\">\r\n");
	XYBody.Append("var oFCKeditor = new FCKeditor('xyecom');\r\n");
	XYBody.Append("oFCKeditor.BasePath = '/Common/fckeditor/';\r\n");
	XYBody.Append("oFCKeditor.ToolbarSet = 'BaiKe';\r\n");
	XYBody.Append("oFCKeditor.Width = \"100%\";\r\n");
	XYBody.Append("oFCKeditor.Height = \"400\";\r\n");
	XYBody.Append("oFCKeditor.Value = '';\r\n");
	XYBody.Append("oFCKeditor.Create();\r\n");
	XYBody.Append(" </" + "script>\r\n");
	XYBody.Append(" </td>\r\n");
	XYBody.Append(" </tr>\r\n");
	XYBody.Append("<tr>\r\n");
	XYBody.Append("<th>上传图片：</th>\r\n");
	XYBody.Append("<td >\r\n");

	XYBody.Append(" <div id=\"UploadFile\">\r\n");
	XYBody.Append("    <input id=\"Upload_TabName\" name=\"Upload_TabName\" type=\"hidden\" value=\"");	XYBody.Append(tablename.ToString());	XYBody.Append("\"/>\r\n");
	XYBody.Append("    <input id=\"Upload_IDs\" name=\"Upload_IDs\" type=\"hidden\" value=\"");	XYBody.Append(ids.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("    <input id=\"Upload_Files\" name=\"Upload_Files\" type=\"hidden\" value=\"");	XYBody.Append(files.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("    <input id=\"Upload_DelIDs\" name=\"Upload_DelIDs\" type=\"hidden\" />\r\n");
	XYBody.Append("    <input id=\"Upload_UpIDs\" name=\"Upload_UpIDs\" type=\"hidden\" />\r\n");
	XYBody.Append("    <input id=\"Upload_MaxAmount\" name=\"Upload_MaxAmount\" type=\"hidden\" value=\"");	XYBody.Append(maxamount.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("    <input id=\"Upload_IsWaterMark\" name=\"Upload_IsWaterMark\" type=\"hidden\" value=\"");	XYBody.Append(iswatermark.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("    <script language=\"javascript\" type=\"text/javascript\">UploadInit();</" + "script>\r\n");
	XYBody.Append("</div>\r\n");


	XYBody.Append("</td>\r\n");
	XYBody.Append("</tr>\r\n");

	if (config.DateType==false)
	{

	XYBody.Append("<tr>\r\n");
	XYBody.Append("<th>信息有效期：<em class=\"red\">*</em></th>\r\n");
	XYBody.Append("<td > \r\n");
	XYBody.Append("<input onclick=\"getDateString(this);\" id=\"EndDate\" maxlength=\"15\" readonly=\"readonly\" name =\"EndDate\"/>\r\n");
	XYBody.Append("</td>\r\n");
	XYBody.Append("</tr>\r\n");

	}
	else
	{

	XYBody.Append("<tr>\r\n");
	XYBody.Append("<th>信息有效期：<em class=\"red\">*</em></th>\r\n");
	XYBody.Append("<td ><input  type =\"radio\"  value =\"10\" name =\"rad\"/>10天\r\n");
	XYBody.Append("<input  type =\"radio\"   value =\"20\"  name =\"rad\"/>20天\r\n");
	XYBody.Append("<input  type =\"radio\"  value =\"30\"  name =\"rad\"/>1个月\r\n");
	XYBody.Append("<input  type =\"radio\"  value =\"90\"  name =\"rad\"/>3个月\r\n");
	XYBody.Append("<input  type =\"radio\"  value =\"180\"  name =\"rad\" checked =\"checked\"/>6个月\r\n");
	XYBody.Append("<input id=\"EndDate\"  readonly=\"readonly\" style=\"display:none;\" />\r\n");
	XYBody.Append("</td>\r\n");
	XYBody.Append("</tr>\r\n");

	}	//end if

	XYBody.Append("</table>\r\n");
	XYBody.Append("<input id=\"datetype\"  type=\"hidden\" value=\"");	XYBody.Append(config.DateType);	XYBody.Append("\" />\r\n");

	if (module.EName=="offer"||module.PEName=="offer")
	{

	XYBody.Append("<table class=\"contentl mt8\">\r\n");
	XYBody.Append("<tr>\r\n");
	XYBody.Append("<th >单价：</th>\r\n");
	XYBody.Append("<td><input maxlength=\"10\"  name =\"txtsprice\" id=\"txtsprice\" value=\"0\"/>元<em>注：（0位面议，只能填数字）</em></td>\r\n");
	XYBody.Append("</tr>\r\n");
	XYBody.Append("<tr>\r\n");
	XYBody.Append("<th >计量单位：</th>\r\n");
	XYBody.Append("<td><input maxlength=\"10\"  name =\"txtsunit\"/></td>\r\n");
	XYBody.Append("</tr>\r\n");
	XYBody.Append("<tr>\r\n");
	XYBody.Append("<th >最小起定量：</th>\r\n");
	XYBody.Append("<td><input maxlength=\"6\"  name =\"txtssmallnum\" value=\"1\"/><em>注：（0为无限量，只能填数字）</em></td>\r\n");
	XYBody.Append("</tr>\r\n");
	XYBody.Append("<tr>\r\n");
	XYBody.Append("<th >货物总量：</th>\r\n");
	XYBody.Append("<td><input maxlength=\"6\"  name =\"txtscountnum\" value=\"0\"/><em>注：（0为无限量，只能填数字）</em></td>\r\n");
	XYBody.Append("</tr>\r\n");

	if (ispayment==true)
	{

	XYBody.Append("<tr>\r\n");
	XYBody.Append("<th >是否支持在线交易：<em class=\"red\">*</em></th>\r\n");
	XYBody.Append("<td><input type=\"radio\" value=\"1\" name=\"rbIsPayMent\" />支持<input type=\"radio\" value=\"0\" name=\"rbIsPayMent\" checked=\"checked\" />不支持</td>\r\n");
	XYBody.Append("</tr>\r\n");

	}	//end if

	XYBody.Append("</table>\r\n");

	}	//end if


	if (module.EName=="venture"||module.PEName=="venture")
	{

	XYBody.Append("<table class=\"contentl mt8\">\r\n");
	XYBody.Append("<tr>\r\n");
	XYBody.Append("<th >单价：<em class=\"red\">*</em></th>\r\n");
	XYBody.Append("<td><input maxlength=\"10\" id=\"txtcprice\"  name =\"txtcprice\" value=\"0\"/>元<em>注：（0为面议，只能填数字）</em></td>\r\n");
	XYBody.Append("</tr>\r\n");
	XYBody.Append("<tr>\r\n");
	XYBody.Append("<th >计量单位：<em class=\"red\">*</em></th>\r\n");
	XYBody.Append("<td><input maxlength=\"10\"  name =\"txtcunit\"/></td>\r\n");
	XYBody.Append("</tr>\r\n");
	XYBody.Append("<tr>\r\n");
	XYBody.Append("<th >最小起定量：<em class=\"red\">*</em></th>\r\n");
	XYBody.Append("<td><input maxlength=\"6\"  id =\"txtcsmallnum\" name =\"txtcsmallnum\" value=\"1\"/><em>注：（0为无限量，只能填数字）</em></td>\r\n");
	XYBody.Append("</tr>\r\n");
	XYBody.Append("<tr>\r\n");
	XYBody.Append("<th >货物总量：<em class=\"red\">*</em></th>\r\n");
	XYBody.Append("<td><input maxlength=\"6\"  id =\"txtccountnum\" name =\"txtccountnum\" value=\"0\"/><em>注：（0为无限量，只能填数字）</em></td>\r\n");
	XYBody.Append("</tr>\r\n");
	XYBody.Append("</table>\r\n");

	}	//end if


	if (module.EName=="investment"||module.PEName=="investment")
	{

	XYBody.Append("<table class=\"contentl mt8\">\r\n");
	XYBody.Append("    <tr>\r\n");
	XYBody.Append("        <th>准备代理(招商)的地区：</th>\r\n");
	XYBody.Append("        <td>\r\n");
	XYBody.Append("            <input  type=\"radio\"  id=\"citys\" name =\"rbcity\" onclick =\"showcityname(1);\" checked=\"checked\" value =\"全国\"/>全国\r\n");
	XYBody.Append("            <input id=\"cityl\" type=\"radio\" name=\"rbcity\"  onclick =\"showcityname(2);\" value=\"\"/> 其它\r\n");
	XYBody.Append("        </td>\r\n");
	XYBody.Append("    </tr>\r\n");
	XYBody.Append("    <tr style=\"display:none\" id=\"cityls\">\r\n");
	XYBody.Append("        <th>&nbsp;</th>\r\n");
	XYBody.Append("        <td id=\"divarea\"><input type =\"hidden\" id=\"city\"  name=\"city\"/></td>\r\n");
	XYBody.Append("    </tr>\r\n");
	XYBody.Append("</table>\r\n");
	XYBody.Append("<script type=\"text/javascript\">\r\n");
	XYBody.Append("    var claarea = new ClassTypes(\"claarea\",'area','divarea','city');\r\n");
	XYBody.Append("    claarea.Init();\r\n");
	XYBody.Append("</" + "script>\r\n");
	XYBody.Append("<table  class=\"contentl\" id=\"tabInvestmentSell\" style=\"display:none; border-top:0px;\">\r\n");
	XYBody.Append("    <tr>\r\n");
	XYBody.Append("        <th >招商支持：</th>\r\n");
	XYBody.Append("        <td><textarea id=\"txtsupport\" name =\"txtsupport\" cols=\"80\" rows=\"7\"></textarea></td>\r\n");
	XYBody.Append("    </tr>\r\n");
	XYBody.Append("    <tr>\r\n");
	XYBody.Append("        <th >招商要求：</th>\r\n");
	XYBody.Append("        <td> <textarea id=\"txtdemand\" name =\"txtdemand\" cols=\"80\" rows=\"7\"></textarea></td>\r\n");
	XYBody.Append("    </tr>\r\n");
	XYBody.Append("    <tr>\r\n");
	XYBody.Append("        <th >展示网址：</th>\r\n");
	XYBody.Append("        <td><input maxlength=\"95\"  name =\"pageurl\" id=\"pageurl\"/></td>\r\n");
	XYBody.Append("    </tr>\r\n");
	XYBody.Append("</table>\r\n");
	XYBody.Append("<table class=\"contentl\" id=\"tabInvestmentBuy\" style=\"display:none;border-top:0px;\">\r\n");
	XYBody.Append("    <tr>\r\n");
	XYBody.Append("        <th >代理过的品牌：</th>\r\n");
	XYBody.Append("        <td><input type=\"text\"  name =\"txtbrand\" style=\"width: 255px\" id=\"txtbrand\"/></td>\r\n");
	XYBody.Append("    </tr>\r\n");
	XYBody.Append("</table>\r\n");

	}	//end if

	XYBody.Append("<input type =\"hidden\" id=\"title\" />\r\n");
	XYBody.Append(" <div class=\"content_action\">\r\n");
	XYBody.Append("<input  type=\"submit\" value=\"同意服务条款，我要发布\"   class =\"button\" onclick =\"return CheckInfoEditFrom('");	XYBody.Append(module.EName.ToString());	XYBody.Append("','");	XYBody.Append(module.PEName.ToString());	XYBody.Append("');\" />\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<br/>\r\n");
	XYBody.Append("<table class=\"contentl top5\">\r\n");
	XYBody.Append("<caption>\r\n");
	XYBody.Append("    <i><img src=\"/templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/user/images/indexpoint.gif\" /> <a href=\"/user/edituserinfo.");	XYBody.Append(config.Suffix);	XYBody.Append("\" target=\"_blank\">点此修改</a></i>  \r\n");
	XYBody.Append("    联系方式的确认与修改  <span>若有误，您发布的信息将无法通过审核！</span>\r\n");
	XYBody.Append("</caption>\r\n");
	XYBody.Append("<tr>\r\n");
	XYBody.Append("<th>姓名：</th>\r\n");
	XYBody.Append("<td>");	XYBody.Append(userinfo.linkman.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("</tr>\r\n");
	XYBody.Append("<tr>\r\n");
	XYBody.Append("<th>公司名称：</th>\r\n");
	XYBody.Append("<td>");	XYBody.Append(userinfo.unitname.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("</tr>\r\n");
	XYBody.Append("<tr>\r\n");
	XYBody.Append("<th>电话：</th>\r\n");
	XYBody.Append("<td>");	XYBody.Append(userinfo.telephone.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("</tr>\r\n");
	XYBody.Append("<tr>\r\n");
	XYBody.Append("<th>传真：</th>\r\n");
	XYBody.Append("<td>");	XYBody.Append(userinfo.fax.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("</tr>\r\n");
	XYBody.Append("<tr>\r\n");
	XYBody.Append("<th>电子邮件：</th>\r\n");
	XYBody.Append("<td>");	XYBody.Append(userinfo.email.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("</tr>\r\n");
	XYBody.Append("</table>\r\n");
	XYBody.Append(" </form>\r\n");
	XYBody.Append("</div> \r\n");
	XYBody.Append(" <!--很重要，不能删除-->\r\n");
	XYBody.Append(" <script language=\"javascript\" type=\"text/javascript\">\r\n");
	XYBody.Append("    InitInfoAddPageForm('");	XYBody.Append(module.EName.ToString());	XYBody.Append("','");	XYBody.Append(module.PEName.ToString());	XYBody.Append("','");	XYBody.Append(infotypestr.ToString());	XYBody.Append("');\r\n");
	XYBody.Append(" </" + "script>\r\n");

	XYBody.Append("</div>\r\n");
	XYBody.Append("<div>\r\n");
	XYBody.Append("    <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/user/images/p2.jpg\"></div>\r\n");
	XYBody.Append("<br style=\"font: 0px/0 arial\" clear=\"all\" />\r\n");
	XYBody.Append("<div class=\"foot\">\r\n");
	XYBody.Append("    针对");	XYBody.Append(config.webname);	XYBody.Append("商务中心您有任何使用问题和建议 您可以 <a href=\"\">联系个人中心管理员</a> 或 <a href=\"\">查看帮助</a>\r\n");
	XYBody.Append("    <br>\r\n");
	XYBody.Append("    <a href=\"http://www.xyecom.com\">XYECOM 简介</a> | <a href=\"\">用户注册</a> | <a class=\"lan12i\"\r\n");
	XYBody.Append("        href=\"\" target=\"_top\">广告服务</a> | <a class=\"lan12i\" href=\"\" target=\"_top\">招聘</a>\r\n");
	XYBody.Append("    | <a class=\"lan12i\" href=\"\" target=\"_top\">站点地图</a> | <a class=\"lan12i\" href=\"\" target=\"_top\">\r\n");
	XYBody.Append("        联系方式</a> | <a class=\"lan12i\" href=\"\" target=\"_top\">欢迎投稿 </a>| <a href=\"\">图库\r\n");
	XYBody.Append("    </a>| <a class=\"lan12i\" href=\"\" target=\"_top\">RSS订阅</a>\r\n");
	XYBody.Append("    <br>\r\n");
	XYBody.Append("    Copyright &copy; 2005 - 2009 XYECOM. All rights reserved. ");	XYBody.Append(config.webname);	XYBody.Append(" 版权所有.\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<br style=\"clear: both\">\r\n");
	XYBody.Append("</div> </div> </body> </html> \r\n");



	XYBody.Append(IsCopyright());
	Response.Write(XYBody.ToString());
}
</script>
