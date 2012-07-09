<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.user.curranking,XYECOM.Page" %>
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


	XYBody.Append("<div class=\"location fia\">\r\n");
	XYBody.Append("    <a href=\"index.");	XYBody.Append(config.Suffix);	XYBody.Append("\">商务中心</a> &gt; 我参与的关键词排名</div>\r\n");

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


	XYBody.Append("<div id=\"right\">\r\n");
	XYBody.Append("    <form method=\"post\">\r\n");
	XYBody.Append("    <h3>\r\n");
	XYBody.Append("        当前参与的排名</h3>\r\n");
	XYBody.Append("    <table class=\"content\">\r\n");
	XYBody.Append("        <thead>\r\n");
	XYBody.Append("            <tr>\r\n");
	XYBody.Append("                <th width=\"15%\">\r\n");
	XYBody.Append("                    关键词\r\n");
	XYBody.Append("                </th>\r\n");
	XYBody.Append("                <th width=\"10%\">\r\n");
	XYBody.Append("                    名次\r\n");
	XYBody.Append("                </th>\r\n");
	XYBody.Append("                <th width=\"10%\">\r\n");
	XYBody.Append("                    开始时间\r\n");
	XYBody.Append("                </th>\r\n");
	XYBody.Append("                <th width=\"10%\">\r\n");
	XYBody.Append("                    结束时间\r\n");
	XYBody.Append("                </th>\r\n");
	XYBody.Append("                <th width=\"40%\">\r\n");
	XYBody.Append("                    相关信息\r\n");
	XYBody.Append("                </th>\r\n");
	XYBody.Append("                <th width=\"15%\">\r\n");
	XYBody.Append("                    重新匹配\r\n");
	XYBody.Append("                </th>\r\n");
	XYBody.Append("            </tr>\r\n");
	XYBody.Append("        </thead>\r\n");
	XYBody.Append("        <tbody>\r\n");

	if (infolist.Rows.Count>0)
	{


	int rank__loop__id=0;
	foreach(DataRow rank in infolist.Rows)
	{
		rank__loop__id++;

	XYBody.Append("            <tr>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    " + rank["keyword"].ToString().Trim() + "\r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    " + rank["rank"].ToString().Trim() + "\r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append( Method.formatdatetime(rank["begintime"].ToString().Trim(),"yyyy-MM-dd"));
	XYBody.Append("                </td>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append( Method.formatdatetime(rank["endtime"].ToString().Trim(),"yyyy-MM-dd"));
	XYBody.Append("                </td>\r\n");
	XYBody.Append("                <td>\r\n");
	 str = GetAboutInfo(rank["infoIds"].ToString());
	
	XYBody.Append("                    ");	XYBody.Append(str.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                     <a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("user/rematching.");	XYBody.Append(config.Suffix);	XYBody.Append("?rid=" + rank["rid"].ToString().Trim() + "&rank=" + rank["rank"].ToString().Trim() + "\">重新匹配/自定义</a>\r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("            </tr>\r\n");

	}	//end loop


	}	//end if

	XYBody.Append("        </tbody>\r\n");
	XYBody.Append("    </table>\r\n");
	XYBody.Append("    </form>\r\n");
	XYBody.Append("</div>\r\n");

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
