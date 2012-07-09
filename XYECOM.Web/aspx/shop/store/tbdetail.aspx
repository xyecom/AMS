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
	XYBody.Append("    <meta name=\"Copyright\" content=\"copyright (c) www.xyecs.com.��Ȩ����.\" />\r\n");
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
	XYBody.Append("<title>��Ϣ��ʾ</title>\r\n");
	XYBody.Append("");	XYBody.Append(pageinfo.Meta);	XYBody.Append("\r\n");
	XYBody.Append("<link rel=\"stylesheet\" href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/css/global.css\" type=\"text/css\" media=\"screen\" />\r\n");
	XYBody.Append("</head>\r\n");
	XYBody.Append("<body style=\"background-color:#f2f2f2\">\r\n");
	XYBody.Append("<div id=\"sysMsgbox\">\r\n");
	XYBody.Append("	<ul>\r\n");
	XYBody.Append("	    <li class=\"msg\">");	XYBody.Append(pageinfo.MsgboxText);	XYBody.Append("</li>\r\n");
	XYBody.Append("        <li><a href=\"");	XYBody.Append(pageinfo.MsgboxURL);	XYBody.Append("\">");	XYBody.Append(pageinfo.MsgboxURL);	XYBody.Append("</a></li>\r\n");
	XYBody.Append("         <li><a href=\"#\" onclick=\"history.back();\">���ؼ�������</a></li>\r\n");
	XYBody.Append("        <li><a href=\"/\">������ҳ</a> | <a href=\"#\" onclick=\"window.close();\">�رձ�ҳ</a></li>\r\n");
	XYBody.Append("    </ul>\r\n");
	XYBody.Append("    <div id=\"r_f\">2000-2009��" +  XYECOMCreateHTML("XY_Copyright").ToString() + "����Ȩ���С��ݺ��������</div>\r\n");
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

	XYBody.Append("        var endtime = new Date('");	XYBody.Append(enddate.ToString());	XYBody.Append("'); // ��������  \r\n");
	XYBody.Append("        var thisTime = new Date('");	XYBody.Append(now.ToString());	XYBody.Append("'); // ��ǰ������ʱ�� \r\n");
	XYBody.Append("        var nowtime = thisTime.getTime(); // ��������ǰʱ���ܵ�����  \r\n");
	XYBody.Append("        var leftsecond = 0;\r\n");
	XYBody.Append("        var sh;\r\n");
	XYBody.Append("        function _fresh() {\r\n");
	XYBody.Append("            nowtime = nowtime + 1000; //���1�룬�����1000  \r\n");
	XYBody.Append("            leftsecond = parseInt((endtime.getTime() - nowtime) / 1000);\r\n");
	XYBody.Append("            __d = parseInt(leftsecond / 3600 / 24) <= 9 ? +\"0\" + parseInt(leftsecond / 3600 / 24).toString() : parseInt(leftsecond / 3600 / 24);\r\n");
	XYBody.Append("            __h = parseInt((leftsecond / 3600) % 24) <= 9 ? +\"0\" + parseInt((leftsecond / 3600) % 24).toString() : parseInt((leftsecond / 3600) % 24);\r\n");
	XYBody.Append("            __m = parseInt((leftsecond / 60) % 60) <= 9 ? +\"0\" + parseInt((leftsecond / 60) % 60).toString() : parseInt((leftsecond / 60) % 60);\r\n");
	XYBody.Append("            __s = parseInt(leftsecond % 60) <= 9 ? +\"0\" + parseInt(leftsecond % 60).toString() : parseInt(leftsecond % 60);\r\n");
	XYBody.Append("            $(\"#clearInterval\").html(\"\" + __d + \"��\" + __h + \"ʱ\" + __m + \"��\" + __s + \"��\");\r\n");
	XYBody.Append("            if (leftsecond <= 0) {\r\n");
	XYBody.Append("                $(\"#clearInterval\").html(\"�ؼ��ѽ���\");\r\n");
	XYBody.Append("                $(\"#orderbuy\").html(\"�ؼ��ѽ���\");\r\n");
	XYBody.Append("                clearInterval(sh);\r\n");
	XYBody.Append("            }\r\n");
	XYBody.Append("        }\r\n");
	XYBody.Append("        _fresh()\r\n");
	XYBody.Append("        sh = setInterval(_fresh, 1000);\r\n");

	}
	else
	{

	XYBody.Append("            $(\"#orderbuy\").html(\"�u����\");\r\n");
	XYBody.Append("            $(\"#clearInterval\").html(\"�ؼ��ѽ���\");                \r\n");

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

	XYBody.Append("            <!--�ѵ�½-->\r\n");
	XYBody.Append("            ����");	XYBody.Append(userinfo.loginname.ToString());	XYBody.Append("����ӭ�����ڼ��̳ǣ�<a href=\"/logout.aspx\" target=\"_self\">[�˳�]</a>&nbsp;&nbsp;&nbsp;&nbsp;<a\r\n");
	XYBody.Append("                href=\"/user/index.aspx\" target=\"_blank\">�ҵ��ʻ�</a> | <a href=\"/user/BuyerOrderList.aspx\"\r\n");
	XYBody.Append("                    target=\"_blank\">�ҵĶ���</a> | <a href=\"#\" target=\"_blank\">��������</a>\r\n");

	}
	else
	{

	XYBody.Append("            <!--δ��½-->\r\n");
	XYBody.Append("            ���ã���ӭ�����ڼ��̳ǣ�<a href=\"/login.aspx\" target=\"_blank\">[���½]</a><a href=\"/register.aspx\"\r\n");
	XYBody.Append("                target=\"_blank\">[���ע��]</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"/user/index.aspx\" target=\"_blank\">�ҵ��ʻ�</a>\r\n");
	XYBody.Append("            | <a href=\"/user/BuyerOrderList.aspx\" target=\"_self\">�ҵĶ���</a> | <a href=\"#\" target=\"_blank\">\r\n");
	XYBody.Append("                ��������</a>\r\n");

	}	//end if

	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <div class=\"dh\">\r\n");
	XYBody.Append("            <ul>\r\n");
	XYBody.Append("                <li>\r\n");
	XYBody.Append("                    <h1 class=\"h1\">\r\n");
	XYBody.Append("                        <a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("product.");	XYBody.Append(config.suffix);	XYBody.Append("\" target=\"_self\" class=\"h1\">�̳ǹ���</a></h1>\r\n");
	XYBody.Append("                </li>\r\n");
	XYBody.Append("                <li>\r\n");
	XYBody.Append("                    <h1>\r\n");
	XYBody.Append("                        <a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("brandlist.");	XYBody.Append(config.suffix);	XYBody.Append("\" target=\"_self\" class=\"h1\">Ʒ��ר��</a></h1>\r\n");
	XYBody.Append("                </li>\r\n");
	XYBody.Append("                <li>\r\n");
	XYBody.Append("                    <h1>\r\n");
	XYBody.Append("                        <a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("tbindex----.");	XYBody.Append(config.suffix);	XYBody.Append("\" target=\"_self\" class=\"h1\">�Ź���Ʒ</a></h1>\r\n");
	XYBody.Append("                </li>\r\n");
	XYBody.Append("                <li>\r\n");
	XYBody.Append("                    <h1>\r\n");
	XYBody.Append("                        <a href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("offerlist-------.");	XYBody.Append(config.suffix);	XYBody.Append("\" target=\"_self\" class=\"h1\">���ֻ���</a></h1>\r\n");
	XYBody.Append("                </li>\r\n");
	XYBody.Append("            </ul>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <div style=\"clear: both\">\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("</div>\r\n");


	XYBody.Append("        <!--����-->\r\n");

	XYBody.Append("<!--����-->\r\n");
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
	XYBody.Append("                target=\"_blank\" class=\"menu\">������Ϣ</a></li>\r\n");
	XYBody.Append("            <li><a href='");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("category.");	XYBody.Append(config.suffix);	XYBody.Append("'\r\n");
	XYBody.Append("                target=\"_blank\" class=\"menu\">���з���</a></li>\r\n");
	XYBody.Append("        </ul>\r\n");
	XYBody.Append("        <div class=\"list\" style=\"_overflow: hidden\">\r\n");
	XYBody.Append("            <div class=\"listcart\">\r\n");
	XYBody.Append("                <a href=\"#\" target=\"_blank\" id=\"showCard\">�鿴���ﳵȥ���� </a>\r\n");
	XYBody.Append("                <div class=\"listCartDetail\" id=\"listCartDetail\">\r\n");
	XYBody.Append("                    <p>\r\n");
	XYBody.Append("                        ��һ��ѡ���� <em>");	XYBody.Append(mycart.SupplyCount.ToString());	XYBody.Append("</em> ����Ʒ,���� <em>");	XYBody.Append(mycart.OrderAllPrice.ToString());	XYBody.Append("</em>Ԫ</p>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<div class=\"clear\">\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<!--���� end-->\r\n");


	XYBody.Append("        <div class=\"clear\">\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <!--���� end-->\r\n");
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
	XYBody.Append("                        target=\"_blank\">���ֻ���</a></h3>\r\n");
	XYBody.Append("            </li>\r\n");
	XYBody.Append("            <li>\r\n");
	XYBody.Append("                <h4>\r\n");
	XYBody.Append("                    <a href=\"#\" class=\"font12redA\" target=\"_blank\">������Ʒ</a></h4>\r\n");
	XYBody.Append("            </li>\r\n");
	XYBody.Append("            <li>\r\n");
	XYBody.Append("                <h4>\r\n");
	XYBody.Append("                    <a class=\"font12redA\" href=\"#\" target=\"_blank\">������Ʒ</a></h4>\r\n");
	XYBody.Append("            </li>\r\n");
	XYBody.Append("            <li>\r\n");
	XYBody.Append("                <h4>\r\n");
	XYBody.Append("                    <a class=\"font12redA\" href=\"#\" target=\"_blank\">�̳ǹ���</a></h4>\r\n");
	XYBody.Append("            </li>\r\n");
	XYBody.Append("        </ul>\r\n");
	XYBody.Append("        <div class=\"sous\">\r\n");
	XYBody.Append("            <form action=\"\" method=\"get\">\r\n");
	XYBody.Append("            <div class=\"s1\">\r\n");
	XYBody.Append("                <input name=\"keyword\" id=\"txtkeyword\" type=\"text\" value=\"");	XYBody.Append(keyword.ToString());	XYBody.Append("\" /></div>\r\n");
	XYBody.Append("            <div class=\"s2\">\r\n");
	XYBody.Append("                <input type=\"button\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/_shop/store/images/btn_35.jpg\"\r\n");
	XYBody.Append("                    id=\"btnsearch\" value=\"sousuo\"></div>\r\n");
	XYBody.Append("            <a href=\"#\" target=\"_blank\">�߼�����</a>\r\n");
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
	XYBody.Append("        <!-- ��Ʒ������ -->\r\n");
	XYBody.Append("        <div class=\"main\">\r\n");
	XYBody.Append("            <h2>\r\n");
	XYBody.Append("                <span class=\"c2\">�����Ź���</span>");	XYBody.Append(info.Title.ToString());	XYBody.Append("</h2>\r\n");
	XYBody.Append("            <div class=\"mmain\">\r\n");
	XYBody.Append("                <div class=\"lmain\">\r\n");
	XYBody.Append("                    <table class=\"discount\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	XYBody.Append("                        <tbody>\r\n");
	XYBody.Append("                            <tr>\r\n");
	XYBody.Append("                                <th>\r\n");
	XYBody.Append("                                    ԭ��\r\n");
	XYBody.Append("                                </th>\r\n");
	XYBody.Append("                                <th>\r\n");
	XYBody.Append("                                    �ۿ�\r\n");
	XYBody.Append("                                </th>\r\n");
	XYBody.Append("                                <th>\r\n");
	XYBody.Append("                                    ��ʡ\r\n");
	XYBody.Append("                                </th>\r\n");
	XYBody.Append("                            </tr>\r\n");
	XYBody.Append("                            <tr>\r\n");
	XYBody.Append("                                <td>\r\n");
	XYBody.Append("                                    ��");	XYBody.Append(info.MarketPrice.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                                </td>\r\n");
	XYBody.Append("                                <td>\r\n");
	XYBody.Append("                                    ");	XYBody.Append(info.Discount.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                                </td>\r\n");
	XYBody.Append("                                <td>\r\n");
	XYBody.Append("                                    <span class=\"c2\">��");	XYBody.Append(info.Saved.ToString());	XYBody.Append("</span>\r\n");
	XYBody.Append("                                </td>\r\n");
	XYBody.Append("                            </tr>\r\n");
	XYBody.Append("                        </tbody>\r\n");
	XYBody.Append("                    </table>\r\n");
	XYBody.Append("                    <div class=\"buyinfo\">\r\n");
	XYBody.Append("                        <p class=\"buynum\">\r\n");
	XYBody.Append("                            <span class=\"c2\">");	XYBody.Append(info.CurrentJoin.ToString());	XYBody.Append("</span>���ѹ���<br />\r\n");
	XYBody.Append("                            �������ޣ��µ�Ҫ��Ӵ</p>\r\n");
	XYBody.Append("                        <p class=\"timeleft\">\r\n");
	XYBody.Append("                            ���뱾���Ź��������У�<br />\r\n");
	XYBody.Append("                            <span id=\"clearInterval\" class=\"showTime\"></span>\r\n");
	XYBody.Append("                        </p>\r\n");
	XYBody.Append("                        <p class=\"waiting\">\r\n");
	XYBody.Append("                            ����������");	XYBody.Append(info.SucPeopleNum.ToString());	XYBody.Append(",��ǰ���룺");	XYBody.Append(info.CurrentJoin.ToString());	XYBody.Append("��Ч����(");	XYBody.Append(info.EndDate.ToString());	XYBody.Append(")\r\n");
	XYBody.Append("                        </p>\r\n");

	if (info.CurrentJoin>=info.SucPeopleNum)
	{

	XYBody.Append("                        <p class=\"success\">\r\n");
	XYBody.Append("                            �Ź��ѳɹ����ɼ�������</p>\r\n");

	}
	else
	{

	XYBody.Append("                        <p class=\"failed\">\r\n");
	XYBody.Append("                            �������㣬���ܳ���</p>\r\n");

	}	//end if

	XYBody.Append("                        <p class=\"failed\" style=\"display: none;\">\r\n");
	XYBody.Append("                            ������</p>\r\n");
	XYBody.Append("                    </div>\r\n");
	XYBody.Append("                    <div class=\"order buy\" id=\"orderbuy\">\r\n");
	XYBody.Append("                        <a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("MyTeamOrder.");	XYBody.Append(config.suffix);	XYBody.Append("?teamId=");	XYBody.Append(info.Id.ToString());	XYBody.Append("\">����</a><em>��");	XYBody.Append(info.CurrentPrice.ToString());	XYBody.Append("</em></div>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <div class=\"rmain\">\r\n");
	XYBody.Append("                    <img src=\"");	XYBody.Append(info.ImagePath.ToString());	XYBody.Append("\" width=\"440\" height=\"267\" alt=\"\" />\r\n");
	XYBody.Append("                    <div class=\"buytips\">\r\n");
	XYBody.Append("                        <div class=\"quote\">\r\n");
	XYBody.Append("                            <span style=\"color: #333333\">�� ���ֿ�ʽ��������ʽ��ѡ<br />\r\n");
	XYBody.Append("                                �� ��˹�ص��⣬��֮ͯ��ѡ<br />\r\n");
	XYBody.Append("                                �� ����������������ͻ�</span></div>\r\n");
	XYBody.Append("                    </div>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <div class=\"clear\">\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <!-- ��Ʒ������ end -->\r\n");
	XYBody.Append("        <!-- ��Ʒ���� -->\r\n");
	XYBody.Append("        <div class=\"xq\">\r\n");
	XYBody.Append("            <ul class=\"xqlist c3\">\r\n");
	XYBody.Append("                <li class=\"cur\"><a>��Ʒ����</a></li></ul>\r\n");
	XYBody.Append("            <div class=\"details\">\r\n");
	XYBody.Append("                ");	XYBody.Append(info.Description.ToString());	XYBody.Append("\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("            <div class=\"buy-bottom\">\r\n");
	XYBody.Append("                <dl class=\"item-prices\">\r\n");
	XYBody.Append("                    <dt class=\"price\">ԭ ��</dt>\r\n");
	XYBody.Append("                    <dt class=\"juprice\">�� ��</dt>\r\n");
	XYBody.Append("                    <dt class=\"save\">�� ʡ</dt>\r\n");
	XYBody.Append("                    <dd class=\"price\">\r\n");
	XYBody.Append("                        <del>��");	XYBody.Append(info.MarketPrice.ToString());	XYBody.Append("</del></dd>\r\n");
	XYBody.Append("                    <dd class=\"juprice\">\r\n");
	XYBody.Append("                        ");	XYBody.Append(info.Discount.ToString());	XYBody.Append("</dd>\r\n");
	XYBody.Append("                    <dd class=\"save\">\r\n");
	XYBody.Append("                        ��");	XYBody.Append(info.Saved.ToString());	XYBody.Append("</dd>\r\n");
	XYBody.Append("                </dl>\r\n");
	XYBody.Append("                <!-- ����ť -->\r\n");
	XYBody.Append("                <div class=\"item-buy avil\">\r\n");
	XYBody.Append("                    �۸�<span>");	XYBody.Append(info.CurrentPrice.ToString());	XYBody.Append("</span> <strong class=\"J_juPrices\"><b>��</b>");	XYBody.Append(info.CurrentPrice.ToString());	XYBody.Append("</strong>\r\n");
	XYBody.Append("                    <form id=\"frmjointeam\" method=\"post\" action=\"/common/initcart.");	XYBody.Append(config.suffix);	XYBody.Append("\">\r\n");
	XYBody.Append("                    <input type=\"hidden\" name=\"count\" value=\"1\" />\r\n");
	XYBody.Append("                    <input value=\"");	XYBody.Append(info.ProductId.ToString());	XYBody.Append("\" type=\"hidden\" name=\"pid\" />\r\n");
	XYBody.Append("                    <input value=\"");	XYBody.Append(info.Id.ToString());	XYBody.Append("\" type=\"hidden\" name=\"teamid\" />\r\n");
	XYBody.Append("                    <input type=\"image\" class=\"buy\" title=\"����\" />\r\n");
	XYBody.Append("                    </form>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <!-- ��Ʒ���� end -->\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <!--left end-->\r\n");
	XYBody.Append("    <!--right start-->\r\n");
	XYBody.Append("    <div class=\"i_fr\">\r\n");
	XYBody.Append("        <div id=\"plist\" class=\"rbox\">\r\n");
	XYBody.Append("            <h3>\r\n");
	XYBody.Append("                ���������Ź�</h3>\r\n");
	XYBody.Append("            <ul>\r\n");
	XYBody.Append("                " +  XYECOMCreateHTML("XY_�Ź�_�����Ź�").ToString() + "\r\n");
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
	XYBody.Append("            <li><a href=\"#\">��������</a></li>\r\n");
	XYBody.Append("            <li><a href=\"#\">��Ա�ƶ�</a></li>\r\n");
	XYBody.Append("            <li><a href=\"#\">��������</a></li>\r\n");
	XYBody.Append("            <li><a href=\"#\">��������</a></li>\r\n");
	XYBody.Append("        </ul>\r\n");
	XYBody.Append("        <ul>\r\n");
	XYBody.Append("            <li><a href=\"#\">��������</a></li>\r\n");
	XYBody.Append("            <li><a href=\"#\">��Ʒǩ��</a></li>\r\n");
	XYBody.Append("        </ul>\r\n");
	XYBody.Append("        <ul>\r\n");
	XYBody.Append("            <li><a href=\"#\">��������</a></li>\r\n");
	XYBody.Append("            <li><a href=\"#\">����֧��</a></li>\r\n");
	XYBody.Append("            <li><a href=\"#\">���е��</a></li>\r\n");
	XYBody.Append("            <li><a href=\"#\">��Ʊ�ƶ�</a></li>\r\n");
	XYBody.Append("        </ul>\r\n");
	XYBody.Append("        <ul>\r\n");
	XYBody.Append("            <li><a href=\"#\">�˻�������</a></li>\r\n");
	XYBody.Append("            <li><a href=\"#\">�˻�����</a></li>\r\n");
	XYBody.Append("            <li><a href=\"#\">��������</a></li>\r\n");
	XYBody.Append("            <li><a href=\"#\">��ϵ����</a></li>\r\n");
	XYBody.Append("        </ul>\r\n");
	XYBody.Append("        <ul>\r\n");
	XYBody.Append("            <li><a href=\"#\">��������</a></li>\r\n");
	XYBody.Append("            <li><a href=\"#\">�Ż�ȯ</a></li>\r\n");
	XYBody.Append("            <li><a href=\"#\">�һ�����</a></li>\r\n");
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
	XYBody.Append("    <a href=\"#\">��ҳ</a> | <a href=\"#\">��������</a> | <a href=\"#\">�����Ź�</a> | <a href=\"#\">��������</a>\r\n");
	XYBody.Append("    | <a href=\"#\">��ȫ˵��</a> | <a href=\"#\">��˽����</a> | <a href=\"#\">��վ����</a> | <a href=\"#\">��������</a>\r\n");
	XYBody.Append("    <br />\r\n");
	XYBody.Append("    ��ϵ�绰��0531-83532658 ���棺0531-83532658 E-mail��sdyjsw@163.com ��ַ�������ж�����·3966�Ŷ������ʹ㳡B��1301<br />\r\n");
	XYBody.Append("    ��Ȩ���� ɽ���ڼ�����������޹�˾ All Rights Reserved ³ICP��00000000��\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<!--footer end-->\r\n");
	XYBody.Append("</body> </html>\r\n");



	XYBody.Append("");
	Response.Write(XYBody.ToString());
}
</script>
