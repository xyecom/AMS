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
	XYBody.Append("    <title>网站首页</title>\r\n");
	XYBody.Append("    <link href=\"/Other/css/style.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n");
	XYBody.Append("    <script src=\"/Other/js/zu.js\" type=\"text/javascript\"></" + "script>\r\n");
	XYBody.Append("    <script src=\"/Other/js/update8.js\" type=\"text/javascript\"></" + "script>\r\n");
	XYBody.Append("</head>\r\n");
	XYBody.Append("<body>\r\n");
	XYBody.Append("    <!--头部开始-->\r\n");
	XYBody.Append("    <div id=\"header\">\r\n");
	XYBody.Append("        <div class=\"logo\">\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <div class=\"loginmiddle\">\r\n");
	XYBody.Append("            <h3>\r\n");
	XYBody.Append("                陕西</h3>\r\n");
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
	XYBody.Append("    <!--头部结束-->\r\n");
	XYBody.Append("    <!--中间开始-->\r\n");
	XYBody.Append("    <div id=\"middle\">\r\n");
	XYBody.Append("        <!--left开始-->\r\n");
	XYBody.Append("        <div id=\"left\">\r\n");
	XYBody.Append("            <!--left1开始-->\r\n");
	XYBody.Append("            <div id=\"left1\">\r\n");
	XYBody.Append("                <div id=\"fader\">\r\n");
	XYBody.Append("                    <ul>\r\n");
	XYBody.Append("                        <li>\r\n");
	XYBody.Append("                            <img src=\"/Other/images/1.gif\" alt=\"债权管理方案\"></li>\r\n");
	XYBody.Append("                        <li>\r\n");
	XYBody.Append("                            <img src=\"/Other/images/2.gif\" alt=\"抵债管理方案\"></li>\r\n");
	XYBody.Append("                        <li>\r\n");
	XYBody.Append("                            <img src=\"/Other/images/3.gif\" alt=\"优质服务\" /></li>\r\n");
	XYBody.Append("                    </ul>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <script type=\"text/javascript\">\r\n");
	XYBody.Append("                    var fader = new Hongru.fader.init('fader', {\r\n");
	XYBody.Append("                        id: 'fader'\r\n");
	XYBody.Append("                    });\r\n");
	XYBody.Append("                </" + "script>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("            <!--left1结束-->\r\n");
	XYBody.Append("            <!-- left3开始-->\r\n");
	XYBody.Append("            <div id=\"left3\">\r\n");
	XYBody.Append("                <div style=\"background: url('/Other/images/erji_titlebg.gif'); background-repeat: repeat-x;\r\n");
	XYBody.Append("                    height: auto; overflow: hidden;\">\r\n");
	XYBody.Append("                    <div style=\"width: 100px; line-height: 38px; margin-left: 55px; float: left; font-size: 14px\">\r\n");
	XYBody.Append("                        <strong>债权资讯</strong></div>\r\n");
	XYBody.Append("                    <div style=\"width: 514px; float: right; height: 40px; line-height: 35px; text-align: center\">\r\n");
	XYBody.Append("                    <form id=\"frmzq\" name=\"frmzq\">\r\n");
	XYBody.Append("                        <table width=\"512\" style=\"height: 31px; width: 480px; float: left\">\r\n");
	XYBody.Append("                            <tr>\r\n");
	XYBody.Append("                                <td width=\"50\">\r\n");
	XYBody.Append("                                    标的额\r\n");
	XYBody.Append("                                </td>\r\n");
	XYBody.Append("                                <td width=\"92\">\r\n");
	XYBody.Append("                                    <select id=\"ddlBounty\">\r\n");
	XYBody.Append("                                        <option value=\"1\">1万以下</option>\r\n");
	XYBody.Append("                                        <option value=\"10-50\">10~50万</option>\r\n");
	XYBody.Append("                                    </select>\r\n");
	XYBody.Append("                                </td>\r\n");
	XYBody.Append("                                <td width=\"92\">\r\n");
	XYBody.Append("                                    <input name=\"btnZq\" type=\"submit\" value=\"搜索\"  style=\"background: url(/Other/images/yes.gif);\r\n");
	XYBody.Append("                                        width: 80px; height: 25px; border: none; cursor: pointer; color: #FFF\" />\r\n");
	XYBody.Append("                                </td>\r\n");
	XYBody.Append("                                <td width=\"44\">\r\n");
	XYBody.Append("                                    <a href=\"/zqlist.aspx\">更多>></a>\r\n");
	XYBody.Append("                                </td>\r\n");
	XYBody.Append("                            </tr>\r\n");
	XYBody.Append("                        </table>\r\n");
	XYBody.Append("                        </form>\r\n");
	XYBody.Append("                    </div>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <table id=\"zqlist1\">\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <td height=\"23\" class=\"tdtitle\">\r\n");
	XYBody.Append("                            债权标题\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                        <td class=\"tdprice\">\r\n");
	XYBody.Append("                            悬赏金额\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                        <td class=\"tdarea\">\r\n");
	XYBody.Append("                            所在地区\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                        <td class=\"tdtime\">\r\n");
	XYBody.Append("                            发布时间\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                        <td class=\"tdnumber\">\r\n");
	XYBody.Append("                            投标人数\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                </table>\r\n");
	XYBody.Append("                <table width=\"702\" id=\"zqtj\">\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <td class=\"tdtitle\">\r\n");
	XYBody.Append("                            <img src=\"/Other/images/jian.gif\" /><a href=\"#\">与xxx企业的业务往来</a>\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                        <td class=\"tdprice\">\r\n");
	XYBody.Append("                            12，234.00\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                        <td class=\"tdarea\">\r\n");
	XYBody.Append("                            陕西·西安\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                        <td class=\"tdtime\">\r\n");
	XYBody.Append("                            2012-6-10\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                        <td class=\"tdnumber\">\r\n");
	XYBody.Append("                            4\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <td class=\"tdtitle\">\r\n");
	XYBody.Append("                            <img src=\"/Other/images/jian.gif\" /><a href=\"#\">与xxx企业的业务往来</a>\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                        <td class=\"tdprice\">\r\n");
	XYBody.Append("                            12，234.00\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                        <td class=\"tdarea\">\r\n");
	XYBody.Append("                            陕西·西安\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                        <td class=\"tdtime\">\r\n");
	XYBody.Append("                            2012-6-10\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                        <td class=\"tdnumber\">\r\n");
	XYBody.Append("                            4\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <td class=\"tdtitle\">\r\n");
	XYBody.Append("                            <img src=\"/Other/images/jian.gif\" /><a href=\"#\">与xxx企业的业务往来</a>\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                        <td class=\"tdprice\">\r\n");
	XYBody.Append("                            12，234.00\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                        <td class=\"tdarea\">\r\n");
	XYBody.Append("                            陕西·西安\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                        <td class=\"tdtime\">\r\n");
	XYBody.Append("                            2012-6-10\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                        <td class=\"tdnumber\">\r\n");
	XYBody.Append("                            4\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                </table>\r\n");
	XYBody.Append("                <div class=\"box\" id=\"marqueebox1\">\r\n");
	XYBody.Append("                    <table id=\"zqlist2\">\r\n");

	int info__loop__id=0;
	foreach(DataRow info in zqdata.Rows)
	{
		info__loop__id++;

	XYBody.Append("                        <tr>\r\n");
	XYBody.Append("                            <td class=\"tdtitle\">\r\n");
	XYBody.Append("                                <a href=\"/zqdetail.aspx?id=" + info["CreditId"].ToString().Trim() + "\">" + info["title"].ToString().Trim() + "</a>\r\n");
	XYBody.Append("                            </td>\r\n");
	XYBody.Append("                            <td class=\"tdprice\">\r\n");
	XYBody.Append("                               " + info["Bounty"].ToString().Trim() + "\r\n");
	XYBody.Append("                            </td>\r\n");
	XYBody.Append("                            <td class=\"tdarea\">\r\n");
	XYBody.Append("                               " + info["AreaName"].ToString().Trim() + "\r\n");
	XYBody.Append("                            </td>\r\n");
	XYBody.Append("                            <td class=\"tdtime\">\r\n");
	XYBody.Append("                               " + info["PassDate"].ToString().Trim() + "\r\n");
	XYBody.Append("                            </td>\r\n");
	XYBody.Append("                            <td class=\"tdnumber\">\r\n");
	XYBody.Append("                                " + info["TenderCount"].ToString().Trim() + "\r\n");
	XYBody.Append("                            </td>\r\n");
	XYBody.Append("                        </tr>\r\n");

	}	//end loop

	XYBody.Append("                    </table>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <script type=\"text/javascript\">\r\n");
	XYBody.Append("                    function startmarquee(lh, speed, delay, index) {\r\n");
	XYBody.Append("                        var t;\r\n");
	XYBody.Append("                        var p = false;\r\n");
	XYBody.Append("                        var o = document.getElementById(\"marqueebox\" + index);\r\n");
	XYBody.Append("                        o.innerHTML += o.innerHTML;\r\n");
	XYBody.Append("                        o.onmouseover = function () { p = true }\r\n");
	XYBody.Append("                        o.onmouseout = function () { p = false }\r\n");
	XYBody.Append("                        o.scrollTop = 0;\r\n");
	XYBody.Append("                        function start() {\r\n");
	XYBody.Append("                            t = setInterval(scrolling, speed);\r\n");
	XYBody.Append("                            if (!p) { o.scrollTop += 1; }\r\n");
	XYBody.Append("                        }\r\n");
	XYBody.Append("                        function scrolling() {\r\n");
	XYBody.Append("                            if (o.scrollTop % lh != 0) {\r\n");
	XYBody.Append("                                o.scrollTop += 1;\r\n");
	XYBody.Append("                                if (o.scrollTop >= o.scrollHeight / 2) o.scrollTop = 0;\r\n");
	XYBody.Append("                            } else {\r\n");
	XYBody.Append("                                clearInterval(t);\r\n");
	XYBody.Append("                                setTimeout(start, delay);\r\n");
	XYBody.Append("                            }\r\n");
	XYBody.Append("                        }\r\n");
	XYBody.Append("                        setTimeout(start, delay);\r\n");
	XYBody.Append("                    }\r\n");
	XYBody.Append("                    startmarquee(25, 40, 0, 1);\r\n");
	XYBody.Append("                </" + "script>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("            <!--left3 结束-->\r\n");
	XYBody.Append("            <!--left4开始-->\r\n");
	XYBody.Append("            <div id=\"left4\">\r\n");
	XYBody.Append("                <div style=\"background: url('/Other/images/erji_titlebg.gif'); background-repeat: repeat-x;\r\n");
	XYBody.Append("                    height: auto; overflow: hidden;\">\r\n");
	XYBody.Append("                    <div style=\"width: 100px; line-height: 38px; margin-left: 55px; float: left; font-size: 14px\">\r\n");
	XYBody.Append("                        <strong>抵债物品资讯</strong></div>\r\n");
	XYBody.Append("                    <div style=\"width: 514px; float: right; height: 40px; line-height: 35px; text-align: center\">\r\n");
	XYBody.Append("                        <table width=\"512\" style=\"height: 31px; width: 480px; float: left\">\r\n");
	XYBody.Append("                            <tr>\r\n");
	XYBody.Append("                                <td width=\"60\">\r\n");
	XYBody.Append("                                    物品类型\r\n");
	XYBody.Append("                                </td>\r\n");
	XYBody.Append("                                <td width=\"92\">\r\n");
	XYBody.Append("                                    <select id=\"Select1\">\r\n");
	XYBody.Append("                                        <option>车子</option>\r\n");
	XYBody.Append("                                        <option>房子</option>\r\n");
	XYBody.Append("                                        <option>其他</option>\r\n");
	XYBody.Append("                                    </select>\r\n");
	XYBody.Append("                                </td>\r\n");
	XYBody.Append("                                <td width=\"39\">\r\n");
	XYBody.Append("                                    地区\r\n");
	XYBody.Append("                                </td>\r\n");
	XYBody.Append("                                <td width=\"76\">\r\n");
	XYBody.Append("                                    <select id=\"Select2\">\r\n");
	XYBody.Append("                                        <option>陕西</option>\r\n");
	XYBody.Append("                                        <option>湖南</option>\r\n");
	XYBody.Append("                                    </select>\r\n");
	XYBody.Append("                                </td>\r\n");
	XYBody.Append("                                <td width=\"92\">\r\n");
	XYBody.Append("                                    <input name=\"搜索\" type=\"button\" value=\"搜索\" style=\"background: url(/Other/images/yes.gif);\r\n");
	XYBody.Append("                                        width: 80px; height: 25px; border: none; cursor: pointer; color: #FFF\" />\r\n");
	XYBody.Append("                                </td>\r\n");
	XYBody.Append("                                <td width=\"44\">\r\n");
	XYBody.Append("                                    <a href=\"#\">更多>></a>\r\n");
	XYBody.Append("                                </td>\r\n");
	XYBody.Append("                            </tr>\r\n");
	XYBody.Append("                        </table>\r\n");
	XYBody.Append("                    </div>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <div style=\"height: auto; width: 721px;\">\r\n");
	XYBody.Append("                    <table id=\"dztb\">\r\n");
	XYBody.Append("                        <tr>\r\n");
	XYBody.Append("                            <td>\r\n");
	XYBody.Append("                                <img src=\"/Other/images/left1.gif\" />\r\n");
	XYBody.Append("                                <p>\r\n");
	XYBody.Append("                                    <strong>新建复式楼</strong><br />\r\n");
	XYBody.Append("                                </p>\r\n");
	XYBody.Append("                                <p>\r\n");
	XYBody.Append("                                    <font>物品底价：￥12,123.00</font></p>\r\n");
	XYBody.Append("                                <p>\r\n");
	XYBody.Append("                                    <font>物品所在地：陕西·西安</font></p>\r\n");
	XYBody.Append("                                <p>\r\n");
	XYBody.Append("                                    <a href=\"#\">查看详情>></a></p>\r\n");
	XYBody.Append("                            </td>\r\n");
	XYBody.Append("                            <td>\r\n");
	XYBody.Append("                                <img src=\"/Other/images/left1.gif\" />\r\n");
	XYBody.Append("                                <p>\r\n");
	XYBody.Append("                                    <strong>新建复式楼</strong><br />\r\n");
	XYBody.Append("                                </p>\r\n");
	XYBody.Append("                                <p>\r\n");
	XYBody.Append("                                    <font>物品底价：￥12,123.00</font></p>\r\n");
	XYBody.Append("                                <p>\r\n");
	XYBody.Append("                                    <font>物品所在地：陕西·西安</font></p>\r\n");
	XYBody.Append("                                <p>\r\n");
	XYBody.Append("                                    <a href=\"#\">查看详情>></a></p>\r\n");
	XYBody.Append("                            </td>\r\n");
	XYBody.Append("                        </tr>\r\n");
	XYBody.Append("                        <tr>\r\n");
	XYBody.Append("                            <td>\r\n");
	XYBody.Append("                                <img src=\"/Other/images/left1.gif\" />\r\n");
	XYBody.Append("                                <p>\r\n");
	XYBody.Append("                                    <strong>新建复式楼</strong><br />\r\n");
	XYBody.Append("                                </p>\r\n");
	XYBody.Append("                                <p>\r\n");
	XYBody.Append("                                    <font>物品底价：￥12,183.00</font></p>\r\n");
	XYBody.Append("                                <p>\r\n");
	XYBody.Append("                                    <font>物品所在地：陕西·西安</font></p>\r\n");
	XYBody.Append("                                <p>\r\n");
	XYBody.Append("                                    <a href=\"#\">查看详情>></a></p>\r\n");
	XYBody.Append("                            </td>\r\n");
	XYBody.Append("                            <td>\r\n");
	XYBody.Append("                                <img src=\"/Other/images/left1.gif\" />\r\n");
	XYBody.Append("                                <p>\r\n");
	XYBody.Append("                                    <strong>新建复式楼</strong><br />\r\n");
	XYBody.Append("                                </p>\r\n");
	XYBody.Append("                                <p>\r\n");
	XYBody.Append("                                    <font>物品底价：￥12,123.00</font></p>\r\n");
	XYBody.Append("                                <p>\r\n");
	XYBody.Append("                                    <font>物品所在地：陕西·西安</font></p>\r\n");
	XYBody.Append("                                <p>\r\n");
	XYBody.Append("                                    <a href=\"#\">查看详情>></a></p>\r\n");
	XYBody.Append("                            </td>\r\n");
	XYBody.Append("                        </tr>\r\n");
	XYBody.Append("                    </table>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("            <!--left4结束-->\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <!--left结束-->\r\n");
	XYBody.Append("        <!--right开始-->\r\n");
	XYBody.Append("        <div id=\"right\">\r\n");
	XYBody.Append("            <!--right1开始-->\r\n");
	XYBody.Append("            <div id=\"right1\">\r\n");
	XYBody.Append("                <strong style=\"margin-left: 20px;\">快速了解包青天</strong>\r\n");
	XYBody.Append("                <div class=\"qul\">\r\n");
	XYBody.Append("                    <ul>\r\n");
	XYBody.Append("                        <li><font>【新手攻略】</font><a href=\"#\"> 债权人如何对外发布债权信息</a></li>\r\n");
	XYBody.Append("                        <li><font>【新手攻略】</font><a href=\"#\"> 债权人如何使用存储系统</a></li>\r\n");
	XYBody.Append("                        <li><font>【常见问题】</font><a href=\"#\"> 企业总账号如何管理部门</a></li>\r\n");
	XYBody.Append("                        <li><font>【常见问题】</font><a href=\"#\"> 如何承接抵债物品</a></li>\r\n");
	XYBody.Append("                        <li><font>【安全须知】</font><a href=\"#\"> 发布债权信息须知</a></li>\r\n");
	XYBody.Append("                        <li><font>【常见问题】</font><a href=\"#\"> 债权人如何对外发布债权信息</a></li>\r\n");
	XYBody.Append("                        <li><font>【常见问题】</font><a href=\"#\"> 债权人如何对外发布债权信息</a></li>\r\n");
	XYBody.Append("                    </ul>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("            <!--right1结束-->\r\n");
	XYBody.Append("            <!--right2开始-->\r\n");
	XYBody.Append("            <div id=\"right2\">\r\n");
	XYBody.Append("                <strong style=\"margin-left: 20px;\">企业纪事</strong>\r\n");
	XYBody.Append("                <div class=\"qul\">\r\n");
	XYBody.Append("                    <ul>\r\n");
	XYBody.Append("                        <li><font>【2011年3月】</font> 公司策划开始···</li>\r\n");
	XYBody.Append("                        <li><font>【2011年3月】</font> 公司策划开始···</li>\r\n");
	XYBody.Append("                        <li><font>【2011年3月】</font> 公司策划开始···</li>\r\n");
	XYBody.Append("                        <li><font>【2011年3月】</font> 公司策划开始···</li>\r\n");
	XYBody.Append("                        <li><font>【2011年3月】</font> 公司策划开始···</li>\r\n");
	XYBody.Append("                    </ul>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("            <!--right2结束-->\r\n");
	XYBody.Append("            <!--right3开始-->\r\n");
	XYBody.Append("            <div id=\"right3\">\r\n");
	XYBody.Append("                <img src=\"/Other/images/1212.gif\" />\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("            <!--right3结束-->\r\n");
	XYBody.Append("            <!--right4开始-->\r\n");
	XYBody.Append("            <div id=\"right4\">\r\n");
	XYBody.Append("                <strong style=\"margin-left: 20px; height: 35px; line-height: 35px;\">媒体报道</strong>\r\n");
	XYBody.Append("                <div style=\"margin: 2px 10px\">\r\n");
	XYBody.Append("                    <img src=\"/Other/images/cctv.gif\" style=\"float: left\" /><img src=\"/Other/images/zk.jpg\" /></div>\r\n");
	XYBody.Append("                <div class=\"qul\">\r\n");
	XYBody.Append("                    <ul>\r\n");
	XYBody.Append("                        <li><font>【陕西电视台】</font> \"包青天\"为数万债权人···</li>\r\n");
	XYBody.Append("                        <li><font>【山西日报】</font> 律师的集结地</li>\r\n");
	XYBody.Append("                        <li><font>【湖南卫视】</font> \"包青天\"为数万债权人···</li>\r\n");
	XYBody.Append("                        <li><font>【重庆时报】</font> 律师的集结地···</li>\r\n");
	XYBody.Append("                    </ul>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("            <!--right4结束-->\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <!--right结束-->\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <!--中间结束-->\r\n");
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
