<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.area.index,XYECOM.Page" %>
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
	XYBody.Append("    <title>服务商主页</title>\r\n");
	XYBody.Append("    <link href=\"/Other/css/sercss.css\" rel=\"Stylesheet\" type=\"text/css\" />\r\n");
	XYBody.Append("</head>\r\n");
	XYBody.Append("<body>\r\n");
	XYBody.Append("    <!--top start-->\r\n");
	XYBody.Append("    <div id=\"top\">\r\n");
	XYBody.Append("        <div id=\"top1\">\r\n");
	XYBody.Append("            您好，欢迎&nbsp;&nbsp;<strong>华众物流</strong>&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"#\">修改资料</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a\r\n");
	XYBody.Append("                href=\"#\">修改密码</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a href=\"#\">网站首页</a></div>\r\n");
	XYBody.Append("        <div id=\"top2\">\r\n");
	XYBody.Append("            <a href=\"#\">【退出系统】</a></div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <!--top end-->\r\n");
	XYBody.Append("    <!--header start-->\r\n");
	XYBody.Append("    <div id=\"header\">\r\n");
	XYBody.Append("        <div class=\"logo\">\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <div class=\"loginmiddle\">\r\n");
	XYBody.Append("            <h3>\r\n");
	XYBody.Append("                ");	XYBody.Append(areaname.ToString());	XYBody.Append("</h3>\r\n");
	XYBody.Append("            [<a href=\"#\">切换分站</a>]\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <div class=\"logoright\">\r\n");
	XYBody.Append("            <a href=\"#\">设为首页</a>&nbsp; |&nbsp; <a href=\"#\">加入收藏</a>&nbsp;&nbsp;\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <div id=\"menu\">\r\n");
	XYBody.Append("            <ul>\r\n");
	XYBody.Append("                <li class='m_li_a'><a href=\"#\">网站首页</a></li>\r\n");
	XYBody.Append("                <li class=\"m_line\">\r\n");
	XYBody.Append("                    <img src=\"/Other/images/line1.gif\" /></li>\r\n");
	XYBody.Append("                <li class='m_li' onmouseover='mover(2);' onmouseout='mout(2);'><a href=\"#\">债权资讯</a></li>\r\n");
	XYBody.Append("                <li class=\"m_line\">\r\n");
	XYBody.Append("                    <img src=\"/Other/images/line1.gif\" /></li>\r\n");
	XYBody.Append("                <li class='m_li' onmouseover='mover(3);' onmouseout='mout(3);'><a href=\"#\">优质服务商</a></li>\r\n");
	XYBody.Append("                <li class=\"m_line\">\r\n");
	XYBody.Append("                    <img src=\"/Other/images/line1.gif\" /></li>\r\n");
	XYBody.Append("                <li class='m_li' onmouseover='mover(4);' onmouseout='mout(4);'><a href=\"#\">抵债物品资讯</a></li>\r\n");
	XYBody.Append("                <li class=\"m_line\">\r\n");
	XYBody.Append("                    <img src=\"/Other/images/line1.gif\" /></li>\r\n");
	XYBody.Append("                <li class='m_li' onmouseover='mover(5);' onmouseout='mout(5);'><a href=\"#\">在线服务</a></li>\r\n");
	XYBody.Append("            </ul>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <!--header end-->\r\n");
	XYBody.Append("    <!--middle start-->\r\n");
	XYBody.Append("    <div id=\"middle\">\r\n");
	XYBody.Append("        <!--left start-->\r\n");
	XYBody.Append("        <div id=\"left\">\r\n");
	XYBody.Append("            <!--left1 start-->\r\n");
	XYBody.Append("            <div id=\"left1\">\r\n");
	XYBody.Append("                <div id=\"vertmenu\">\r\n");
	XYBody.Append("                    <h1>\r\n");
	XYBody.Append("                        基本设置</h1>\r\n");
	XYBody.Append("                    <ul>\r\n");
	XYBody.Append("                        <li><a href=\"#\" tabindex=\"1\">资料修改</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"#\" tabindex=\"2\">密码修改</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"#\" tabindex=\"3\">绑定手机</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"#\" tabindex=\"4\">信用管理</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"#\" tabindex=\"5\">认证管理</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"#\" tabindex=\"5\">头像修改</a></li>\r\n");
	XYBody.Append("                    </ul>\r\n");
	XYBody.Append("                    <h1>\r\n");
	XYBody.Append("                        案件管理</h1>\r\n");
	XYBody.Append("                    <ul>\r\n");
	XYBody.Append("                        <li><a href=\"#\">进行中案件</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"#\">已参与案件</a></li>\r\n");
	XYBody.Append("                        <h1>\r\n");
	XYBody.Append("                            案件资讯</h1>\r\n");
	XYBody.Append("                        <ul>\r\n");
	XYBody.Append("                            <li><a href=\"zqlist.htm\">系统推荐</a></li>\r\n");
	XYBody.Append("                        </ul>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("            <!--left1 end-->\r\n");
	XYBody.Append("            <!--left2 start-->\r\n");
	XYBody.Append("            <a href=\"#\">\r\n");
	XYBody.Append("                <img src=\"/Other/images/ads1.jpg\" width=\"158\" style=\"border: 1px solid #ddd\" /></a>\r\n");
	XYBody.Append("            <!--left2 end-->\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <!--left end-->\r\n");
	XYBody.Append("        <!--right start-->\r\n");
	XYBody.Append("        <div id=\"right\">\r\n");
	XYBody.Append("            <!--rightmsg start-->\r\n");
	XYBody.Append("            <div id=\"rightmsg\">\r\n");
	XYBody.Append("                <div id=\"msgimg\">\r\n");
	XYBody.Append("                    <img src=\"/Other/images/man.GIF\" /><br />\r\n");
	XYBody.Append("                    <br />\r\n");
	XYBody.Append("                    <a href=\"#\">修改头像</a>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <div id=\"line\">\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <div id=\"msgmain\">\r\n");
	XYBody.Append("                    <p>\r\n");
	XYBody.Append("                        <font>尊敬的&nbsp; </font><strong>华众物流</strong><font>，欢迎您！</font> <span style=\"float: right;\r\n");
	XYBody.Append("                            padding-right: 10px; padding-bottom: 10px;\">最近一次登录时间：2012-3-14 12:45</span></p>\r\n");
	XYBody.Append("                    <table id=\"msgtb\">\r\n");
	XYBody.Append("                        <tr>\r\n");
	XYBody.Append("                            <td width=\"60\">\r\n");
	XYBody.Append("                                账号状态\r\n");
	XYBody.Append("                            </td>\r\n");
	XYBody.Append("                            <td width=\"128\">\r\n");
	XYBody.Append("                                <img src=\"/Other/images/zhzt.gif\" />\r\n");
	XYBody.Append("                            </td>\r\n");
	XYBody.Append("                            <td width=\"100\">\r\n");
	XYBody.Append("                                <a href=\"#\">修改账户密码</a>\r\n");
	XYBody.Append("                            </td>\r\n");
	XYBody.Append("                            <td width=\"21\">\r\n");
	XYBody.Append("                                <img src=\"/Other/images/sjyes.gif\" />\r\n");
	XYBody.Append("                            </td>\r\n");
	XYBody.Append("                            <td width=\"83\">\r\n");
	XYBody.Append("                                手机已绑定\r\n");
	XYBody.Append("                            </td>\r\n");
	XYBody.Append("                            <td width=\"21\">\r\n");
	XYBody.Append("                                <img src=\"/Other/images/yxno.gif\" />\r\n");
	XYBody.Append("                            </td>\r\n");
	XYBody.Append("                            <td width=\"113\">\r\n");
	XYBody.Append("                                邮箱未验证\r\n");
	XYBody.Append("                            </td>\r\n");
	XYBody.Append("                        </tr>\r\n");
	XYBody.Append("                    </table>\r\n");
	XYBody.Append("                    <table id=\"msgtb2\">\r\n");
	XYBody.Append("                        <tr>\r\n");
	XYBody.Append("                            <td>\r\n");
	XYBody.Append("                                已参与案件数：23条\r\n");
	XYBody.Append("                            </td>\r\n");
	XYBody.Append("                            <td>\r\n");
	XYBody.Append("                                已中标数量：23条\r\n");
	XYBody.Append("                            </td>\r\n");
	XYBody.Append("                        </tr>\r\n");
	XYBody.Append("                        <tr>\r\n");
	XYBody.Append("                            <td>\r\n");
	XYBody.Append("                                关注案件：23条\r\n");
	XYBody.Append("                            </td>\r\n");
	XYBody.Append("                            <td>\r\n");
	XYBody.Append("                                共投标案件数：56条\r\n");
	XYBody.Append("                            </td>\r\n");
	XYBody.Append("                        </tr>\r\n");
	XYBody.Append("                        <tr>\r\n");
	XYBody.Append("                            <td>\r\n");
	XYBody.Append("                                已收邮件数：24条\r\n");
	XYBody.Append("                            </td>\r\n");
	XYBody.Append("                            <td>\r\n");
	XYBody.Append("                                站内消息：通知/提醒（<a href=\"#\"><font style=\"color: #f00\">38</font></a>条）\r\n");
	XYBody.Append("                            </td>\r\n");
	XYBody.Append("                        </tr>\r\n");
	XYBody.Append("                    </table>\r\n");
	XYBody.Append("                    <p>\r\n");
	XYBody.Append("                        账号余额：￥454.00 <a href=\"#\">提现</a></p>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("            <!--rightmsg end-->\r\n");
	XYBody.Append("            <!--rightzqlist start-->\r\n");
	XYBody.Append("            <div id=\"rightzqlist\">\r\n");
	XYBody.Append("                <h2>\r\n");
	XYBody.Append("                    正在进行中的案件</h2>\r\n");
	XYBody.Append("                <div class=\"rhr\">\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <!--列表 start-->\r\n");
	XYBody.Append("                <div id=\"list\">\r\n");
	XYBody.Append("                    <table>\r\n");
	XYBody.Append("                        <tr id=\"trtop\">\r\n");
	XYBody.Append("                            <td align=\"center\" width=\"40%\">\r\n");
	XYBody.Append("                                案件标题\r\n");
	XYBody.Append("                            </td>\r\n");
	XYBody.Append("                            <td align=\"center\" width=\"20%\">\r\n");
	XYBody.Append("                                发布时间\r\n");
	XYBody.Append("                            </td>\r\n");
	XYBody.Append("                            <td align=\"center\" width=\"15%\">\r\n");
	XYBody.Append("                                付款状态\r\n");
	XYBody.Append("                            </td>\r\n");
	XYBody.Append("                            <td align=\"center\" width=\"25%\">\r\n");
	XYBody.Append("                                操作菜单\r\n");
	XYBody.Append("                            </td>\r\n");
	XYBody.Append("                        </tr>\r\n");
	XYBody.Append("                        <tr id=\"trmidd\" style=\"height: 28px; border-top: 1px solid #ccc\" onmousemove=\"this.style.backgroundColor='#F7F7F7'\"\r\n");
	XYBody.Append("                            onmouseout=\"this.style.backgroundColor='#ffffff'\">\r\n");
	XYBody.Append("                            <td id=\"tdtitle\">\r\n");
	XYBody.Append("                                <a href=\"#\" title=\"与xxx企业的业务往来\">与xxx企业的业务往来</a>\r\n");
	XYBody.Append("                            </td>\r\n");
	XYBody.Append("                            <td>\r\n");
	XYBody.Append("                                2012-02-12\r\n");
	XYBody.Append("                            </td>\r\n");
	XYBody.Append("                            <td>\r\n");
	XYBody.Append("                                【已付款】\r\n");
	XYBody.Append("                            </td>\r\n");
	XYBody.Append("                            <td>\r\n");
	XYBody.Append("                                <a href=\"#\">详情</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"#\">删除</a>\r\n");
	XYBody.Append("                            </td>\r\n");
	XYBody.Append("                        </tr>\r\n");
	XYBody.Append("                        <tr id=\"trmidd\" style=\"height: 28px; border-top: 1px solid #ccc\" onmousemove=\"this.style.backgroundColor='#F7F7F7'\"\r\n");
	XYBody.Append("                            onmouseout=\"this.style.backgroundColor='#ffffff'\">\r\n");
	XYBody.Append("                            <td id=\"tdtitle\">\r\n");
	XYBody.Append("                                <a href=\"#\" title=\"李长春视察珠海产业园：三一是具有国际影响力的品牌\">李长春视察珠海产业园：三一是具有国际影响力的品牌</a>\r\n");
	XYBody.Append("                            </td>\r\n");
	XYBody.Append("                            <td>\r\n");
	XYBody.Append("                                2012-02-12\r\n");
	XYBody.Append("                            </td>\r\n");
	XYBody.Append("                            <td>\r\n");
	XYBody.Append("                                【已付款】\r\n");
	XYBody.Append("                            </td>\r\n");
	XYBody.Append("                            <td>\r\n");
	XYBody.Append("                                <a href=\"#\">详情</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"#\">删除</a>\r\n");
	XYBody.Append("                            </td>\r\n");
	XYBody.Append("                        </tr>\r\n");
	XYBody.Append("                        <tr id=\"trmidd\" style=\"height: 28px; border-top: 1px solid #ccc\" onmousemove=\"this.style.backgroundColor='#F7F7F7'\"\r\n");
	XYBody.Append("                            onmouseout=\"this.style.backgroundColor='#ffffff'\">\r\n");
	XYBody.Append("                            <td id=\"tdtitle\">\r\n");
	XYBody.Append("                                <a href=\"#\" title=\"梁稳根成中国双料“首富”\">梁稳根成中国双料“首富”</a>\r\n");
	XYBody.Append("                            </td>\r\n");
	XYBody.Append("                            <td>\r\n");
	XYBody.Append("                                2012-02-12\r\n");
	XYBody.Append("                            </td>\r\n");
	XYBody.Append("                            <td>\r\n");
	XYBody.Append("                                【已付款】\r\n");
	XYBody.Append("                            </td>\r\n");
	XYBody.Append("                            <td>\r\n");
	XYBody.Append("                                <a href=\"#\">详情</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"#\">删除</a>\r\n");
	XYBody.Append("                            </td>\r\n");
	XYBody.Append("                        </tr>\r\n");
	XYBody.Append("                        <tr id=\"trmidd\" style=\"height: 28px; border-top: 1px solid #ccc\" onmousemove=\"this.style.backgroundColor='#F7F7F7'\"\r\n");
	XYBody.Append("                            onmouseout=\"this.style.backgroundColor='#ffffff'\">\r\n");
	XYBody.Append("                            <td id=\"tdtitle\">\r\n");
	XYBody.Append("                                <a href=\"#\" title=\"依托过渡基地 三一海洋重工加速跑 20余台大港机实现交付\">依托过渡基地 三一海洋重工加速跑 20余台大港机··· </a>\r\n");
	XYBody.Append("                            </td>\r\n");
	XYBody.Append("                            <td>\r\n");
	XYBody.Append("                                2012-02-12\r\n");
	XYBody.Append("                            </td>\r\n");
	XYBody.Append("                            <td>\r\n");
	XYBody.Append("                                【已付款】\r\n");
	XYBody.Append("                            </td>\r\n");
	XYBody.Append("                            <td>\r\n");
	XYBody.Append("                                <a href=\"#\">详情</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"#\">删除</a>\r\n");
	XYBody.Append("                            </td>\r\n");
	XYBody.Append("                        </tr>\r\n");
	XYBody.Append("                    </table>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <!--列表 end-->\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("            <!--rightzqlist end-->\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <!--right end-->\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <!--middle end-->\r\n");
	XYBody.Append("    <!--bottom start-->\r\n");
	XYBody.Append("    <div id=\"bottom\">\r\n");
	XYBody.Append("        <ul>\r\n");
	XYBody.Append("            <li><strong>新手上路</strong></li>\r\n");
	XYBody.Append("            <li><a href=\"#\">了解本网</a></li>\r\n");
	XYBody.Append("            <li><a href=\"#\">注册债权人</a></li>\r\n");
	XYBody.Append("            <li><a href=\"#\">注册服务商</a></li>\r\n");
	XYBody.Append("            <li><a href=\"#\">帮助中心</a></li>\r\n");
	XYBody.Append("        </ul>\r\n");
	XYBody.Append("        <ul>\r\n");
	XYBody.Append("            <li><strong>交易指南</strong></li>\r\n");
	XYBody.Append("            <li><a href=\"#\">如何发布债权</a></li>\r\n");
	XYBody.Append("            <li><a href=\"#\">如何获取佣金</a></li>\r\n");
	XYBody.Append("            <li><a href=\"#\">交易安全</a></li>\r\n");
	XYBody.Append("            <li><a href=\"#\">服务中心</a></li>\r\n");
	XYBody.Append("        </ul>\r\n");
	XYBody.Append("        <ul>\r\n");
	XYBody.Append("            <li><strong>交易保障</strong></li>\r\n");
	XYBody.Append("            <li><a href=\"#\">担保交易</a></li>\r\n");
	XYBody.Append("            <li><a href=\"#\">诚信保障服务</a></li>\r\n");
	XYBody.Append("            <li><a href=\"#\">提供发票</a></li>\r\n");
	XYBody.Append("            <li><a href=\"#\">全假信息识别</a></li>\r\n");
	XYBody.Append("        </ul>\r\n");
	XYBody.Append("        <ul>\r\n");
	XYBody.Append("            <li><strong>支付方式</strong></li>\r\n");
	XYBody.Append("            <li><a href=\"#\">网银支付</a></li>\r\n");
	XYBody.Append("            <li><a href=\"#\">银行柜台支付</a></li>\r\n");
	XYBody.Append("            <li><a href=\"#\">支付宝担保交易</a></li>\r\n");
	XYBody.Append("            <li><a href=\"#\">账户余额支付</a></li>\r\n");
	XYBody.Append("        </ul>\r\n");
	XYBody.Append("        <div style=\"height: 90px; margin: 20px 10px; width: 187px; float: left\">\r\n");
	XYBody.Append("            <img src=\"/Other/images/tel.gif\" />\r\n");
	XYBody.Append("            <strong style=\"font-size: 18px; color: #f00\">400-100-1010</strong>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <!--bottom end-->\r\n");
	XYBody.Append("    <!--footer start-->\r\n");
	XYBody.Append("    <div id=\"footer\">\r\n");
	XYBody.Append("        <div style=\"height: 50px; text-align: center\">\r\n");
	XYBody.Append("            <table>\r\n");
	XYBody.Append("                <tr>\r\n");
	XYBody.Append("                    <td>\r\n");
	XYBody.Append("                        <img src=\"/Other/images/11.gif\" />\r\n");
	XYBody.Append("                    </td>\r\n");
	XYBody.Append("                    <td>\r\n");
	XYBody.Append("                        <h2>\r\n");
	XYBody.Append("                            不跨区·省时间</h2>\r\n");
	XYBody.Append("                    </td>\r\n");
	XYBody.Append("                    <td>\r\n");
	XYBody.Append("                        <img src=\"/Other/images/22.gif\" />\r\n");
	XYBody.Append("                    </td>\r\n");
	XYBody.Append("                    <td>\r\n");
	XYBody.Append("                        <h2>\r\n");
	XYBody.Append("                            大商品·低价卖</h2>\r\n");
	XYBody.Append("                    </td>\r\n");
	XYBody.Append("                    <td>\r\n");
	XYBody.Append("                        <img src=\"/Other/images/33.gif\" />\r\n");
	XYBody.Append("                    </td>\r\n");
	XYBody.Append("                    <td>\r\n");
	XYBody.Append("                        <h2>\r\n");
	XYBody.Append("                            多方案·优服务</h2>\r\n");
	XYBody.Append("                    </td>\r\n");
	XYBody.Append("                </tr>\r\n");
	XYBody.Append("            </table>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <p>\r\n");
	XYBody.Append("            <a href=\"\">网站地图</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a href=\"\">关于我们</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a\r\n");
	XYBody.Append("                href=\"\">合作洽谈</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a href=\"\">客户手册</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a\r\n");
	XYBody.Append("                    href=\"\">客服中心</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a href=\"\">加入我们</a></p>\r\n");
	XYBody.Append("        <p>\r\n");
	XYBody.Append("            网站24小时服务热线：400-100-1010 传真：029-12345678 地址：陕西省西安市高新园区一号大厦3楼</p>\r\n");
	XYBody.Append("        <p>\r\n");
	XYBody.Append("            Copyright 2005-2011 baoqt.cn 版权所有 <a href=\"#\" target=\"_blank\">陕ICP备10202274号</a></p>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <!--footer end-->\r\n");
	XYBody.Append("</body>\r\n");
	XYBody.Append("</html>\r\n");

	XYBody.Append(IsCopyright());
	Response.Write(XYBody.ToString());
}
</script>
