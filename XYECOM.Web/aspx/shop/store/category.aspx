<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.shop.category,XYECOM.Page" %>
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


	XYBody.Append("<style type=\"text/css\">\r\n");
	XYBody.Append("    /*ѡ� ��ʽ*/\r\n");
	XYBody.Append("    #Tab2\r\n");
	XYBody.Append("    {\r\n");
	XYBody.Append("        clear: both;\r\n");
	XYBody.Append("        width: 980px;\r\n");
	XYBody.Append("        margin: 0px;\r\n");
	XYBody.Append("        padding: 0px;\r\n");
	XYBody.Append("        margin: 0 auto;\r\n");
	XYBody.Append("    }\r\n");
	XYBody.Append("    .Menubox\r\n");
	XYBody.Append("    {\r\n");
	XYBody.Append("        width: 100%;\r\n");
	XYBody.Append("        height: 28px;\r\n");
	XYBody.Append("        line-height: 28px;\r\n");
	XYBody.Append("        border-bottom: 2px solid #b80733;\r\n");
	XYBody.Append("        height: 29px;\r\n");
	XYBody.Append("    }\r\n");
	XYBody.Append("    .Menubox ul\r\n");
	XYBody.Append("    {\r\n");
	XYBody.Append("        margin: 0px;\r\n");
	XYBody.Append("        padding: 0px;\r\n");
	XYBody.Append("    }\r\n");
	XYBody.Append("    .Menubox li\r\n");
	XYBody.Append("    {\r\n");
	XYBody.Append("        float: left;\r\n");
	XYBody.Append("        display: block;\r\n");
	XYBody.Append("        cursor: pointer;\r\n");
	XYBody.Append("        width: 90px;\r\n");
	XYBody.Append("        margin-right: 5px;\r\n");
	XYBody.Append("        height: 26px;\r\n");
	XYBody.Append("        text-align: center;\r\n");
	XYBody.Append("        background: url(");	XYBody.Append(config.WebURL);	XYBody.Append("templates/_shop/store/images/navtab1.gif) no-repeat scroll 0 0 transparent;\r\n");
	XYBody.Append("        color: #333;\r\n");
	XYBody.Append("        padding-top: 5px;\r\n");
	XYBody.Append("    }\r\n");
	XYBody.Append("    .Menubox li.hover\r\n");
	XYBody.Append("    {\r\n");
	XYBody.Append("        color: #fff;\r\n");
	XYBody.Append("        text-decoration: none;\r\n");
	XYBody.Append("        background-attachment: scroll;\r\n");
	XYBody.Append("        background-color: transparent;\r\n");
	XYBody.Append("        background-image: url(");	XYBody.Append(config.WebURL);	XYBody.Append("templates/_shop/store/images/navtab.gif);\r\n");
	XYBody.Append("        background-repeat: no-repeat;\r\n");
	XYBody.Append("        background-position: 0 0;\r\n");
	XYBody.Append("    }\r\n");
	XYBody.Append("    .Contentbox\r\n");
	XYBody.Append("    {\r\n");
	XYBody.Append("        clear: both;\r\n");
	XYBody.Append("        margin-top: 0px;\r\n");
	XYBody.Append("        border: 2px solid #b80733;\r\n");
	XYBody.Append("        border-top: none;\r\n");
	XYBody.Append("        text-align: center;\r\n");
	XYBody.Append("        padding-top: 8px;\r\n");
	XYBody.Append("    }\r\n");
	XYBody.Append("    #infolist div a.STYLE12\r\n");
	XYBody.Append("    {\r\n");
	XYBody.Append("        background: url(");	XYBody.Append(config.WebURL);	XYBody.Append("templates/_shop/store/images/arrowfl.gif) no-repeat scroll 0 17px transparent;\r\n");
	XYBody.Append("        border-bottom: 1px dashed #CCCCCC;\r\n");
	XYBody.Append("        color: #C50C0C;\r\n");
	XYBody.Append("        display: block;\r\n");
	XYBody.Append("        font-size: 14px;\r\n");
	XYBody.Append("        font-weight: 600;\r\n");
	XYBody.Append("        margin-left: 0;\r\n");
	XYBody.Append("        padding: 10px 0 5px 10px;\r\n");
	XYBody.Append("    }\r\n");
	XYBody.Append("</style>\r\n");

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


	XYBody.Append("<!--top end-->\r\n");
	XYBody.Append("<!--main start-->\r\n");
	XYBody.Append("<div class=\"mian\">\r\n");
	XYBody.Append("    <div class=\"clearfix2\">\r\n");
	XYBody.Append("        <span class=\"pos\">");	XYBody.Append(categoryTitle.ToString());	XYBody.Append("</span><a class=\"amore a2\" href=\"");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("brandlist.");	XYBody.Append(config.suffix);	XYBody.Append("\"\r\n");
	XYBody.Append("            target=\"_blank\">�鿴����Ʒ��</a>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <!--���� start-->\r\n");
	XYBody.Append("    <div class=\"bor1 clearfix2\">\r\n");
	XYBody.Append("        <div class=\"headtitle\">\r\n");
	XYBody.Append("            <table class=\"tagli\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"99%\">\r\n");
	XYBody.Append("                <tbody>\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <td height=\"30\" valign=\"center\" align=\"middle\">\r\n");
	XYBody.Append("                            <div class=\"headtitle\">\r\n");
	XYBody.Append("                                ��ƷĿ¼\r\n");
	XYBody.Append("                            </div>\r\n");
	XYBody.Append("                        </td>\r\n");

	int rowitem__loop__id=0;
	foreach(DataRow rowitem in customtypelist.Rows)
	{
		rowitem__loop__id++;

	XYBody.Append("                        <td valign=\"center\" align=\"middle\">\r\n");
	XYBody.Append("                            <a href='");	XYBody.Append(shopuserinfo.domain.ToString());	XYBody.Append("category-" + rowitem["Id"].ToString().Trim() + ".");	XYBody.Append(config.suffix);	XYBody.Append("'\r\n");
	XYBody.Append("                                target=\"_self\" class=\"menu\">" + rowitem["PtName"].ToString().Trim() + " </a>\r\n");
	XYBody.Append("                        </td>\r\n");

	}	//end loop

	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                </tbody>\r\n");
	XYBody.Append("            </table>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <div id=\"infolist\">\r\n");

	int row2__loop__id=0;
	foreach(DataRow row2 in parent.Rows)
	{
		row2__loop__id++;

	XYBody.Append("            <div class=\"fllist\" id=\"store-tablest\">\r\n");
	XYBody.Append("                <table class=\"store-item dis\" num=\"1\">\r\n");
	XYBody.Append("                    <tbody>\r\n");
	XYBody.Append("                        <tr>\r\n");
	XYBody.Append("                            <td align=\"left\">\r\n");
	XYBody.Append("                                <h2>\r\n");
	 tmplinkurl = GetInfoLink(row2["Id"],row2["SubCount"]);
	
	XYBody.Append("                                    <a class=\"STYLE12\" href='");	XYBody.Append(tmplinkurl.ToString());	XYBody.Append("'>" + row2["PtName"].ToString().Trim() + "</a></h2>\r\n");
	 subtype = GetSubTypeById(row2["Id"].ToString());
	

	int typeitem__loop__id=0;
	foreach(DataRow typeitem in subtype.Rows)
	{
		typeitem__loop__id++;

	 tmplinkurl = GetInfoLink(typeitem["Id"],typeitem["SubCount"]);
	

	if (typeitem__loop__id==1)
	{

	XYBody.Append("                                <a class=\"first\" href=\"");	XYBody.Append(tmplinkurl.ToString());	XYBody.Append("\" target=\"_blank\">" + typeitem["PtName"].ToString().Trim() + "</a>\r\n");

	}
	else
	{

	XYBody.Append("                                <a class=\"fb\" href=\"");	XYBody.Append(tmplinkurl.ToString());	XYBody.Append("\" rel=\"nofollow\">" + typeitem["PtName"].ToString().Trim() + "</a>\r\n");

	}	//end if


	}	//end loop

	XYBody.Append("                            </td>\r\n");
	XYBody.Append("                        </tr>\r\n");
	XYBody.Append("                    </tbody>\r\n");
	XYBody.Append("                </table>\r\n");
	XYBody.Append("            </div>\r\n");

	}	//end loop

	XYBody.Append("            <div class=\"morelink\">\r\n");
	XYBody.Append("                <ul>\r\n");
	XYBody.Append("                    <li>\r\n");
	XYBody.Append("                        <div class=\"morelinkinside\" align=\"left\">\r\n");
	XYBody.Append("                            <table width=\"97%\" align=\"center\">\r\n");
	XYBody.Append("                                <tbody>\r\n");
	XYBody.Append("                                    <tr>\r\n");
	XYBody.Append("                                        <td align=\"right\">\r\n");
	XYBody.Append("                                            <form method=\"get\" action=\"\">\r\n");
	XYBody.Append("                                            <fieldset>\r\n");
	XYBody.Append("                                                <span class=\"STYLE120\">\r\n");
	XYBody.Append("                                                    <div>\r\n");
	XYBody.Append("                                                        <span class=\"STYLE9\">�����������ڼ��̳ǡ�</span> <a href=\"#\" target=\"_blank\">ʱ��</a> <a href=\"#\"\r\n");
	XYBody.Append("                                                            target=\"_blank\">����</a> <a href=\"#\" target=\"_blank\">����</a> <a href=\"#\" target=\"_blank\">\r\n");
	XYBody.Append("                                                                ����</a> <a title=\"\" href=\"#\" target=\"_blank\">����</a> <a href=\"#\" target=\"_blank\">Χ��</a>\r\n");
	XYBody.Append("                                                        <a href=\"#\" target=\"_blank\">ӡ��</a> <a href=\"#\" target=\"_blank\">���</a> <a href=\"#\"\r\n");
	XYBody.Append("                                                            target=\"_blank\">��Ĥ</a> <a href=\"#\" target=\"_blank\">����</a> <a href=\"#\" target=\"_blank\">\r\n");
	XYBody.Append("                                                                �۰�</a> <a href=\"#\" target=\"_blank\">��ԡ</a> <a href=\"#\" target=\"_blank\">���˱���</a>\r\n");
	XYBody.Append("                                                        <a href=\"#\" target=\"_blank\">ޱ��</a> <a href=\"#\" target=\"_blank\">����</a> <a href=\"#\"\r\n");
	XYBody.Append("                                                            target=\"_blank\">�ѹ�</a> <a href=\"#\" target=\"_blank\">PBA</a> <a href=\"#\" target=\"_blank\">\r\n");
	XYBody.Append("                                                                ŷ����</a> <a href=\"#\" target=\"_blank\">������</a> <a href=\"#\" target=\"_blank\">���ݻ���</a>\r\n");
	XYBody.Append("                                                        <a href=\"#\" target=\"_blank\">��Ħ</a> <a href=\"#\" target=\"_blank\">BB˪</a> <a href=\"#\"\r\n");
	XYBody.Append("                                                            target=\"_blank\">�٤</a>\r\n");
	XYBody.Append("                                                    </div>\r\n");
	XYBody.Append("                                                </span>\r\n");
	XYBody.Append("                                                <input class=\"hd-text lower\" value=\"ʱ�� Ůװ\" size=\"31\" type=\"text\" name=\"keyword\">\r\n");
	XYBody.Append("                                                <input style=\"border-bottom: medium none; border-left: medium none; border-top: medium none;\r\n");
	XYBody.Append("                                                    border-right: medium none\" class=\"hd-sbt\" value=\"����\" type=\"submit\">\r\n");
	XYBody.Append("                                                &nbsp;\r\n");
	XYBody.Append("                                            </fieldset>\r\n");
	XYBody.Append("                                            </form>\r\n");
	XYBody.Append("                                        </td>\r\n");
	XYBody.Append("                                    </tr>\r\n");
	XYBody.Append("                                </tbody>\r\n");
	XYBody.Append("                            </table>\r\n");
	XYBody.Append("                        </div>\r\n");
	XYBody.Append("                    </li>\r\n");
	XYBody.Append("                </ul>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <!--���� end-->\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<!--main end-->\r\n");
	XYBody.Append("<!--footer start-->\r\n");

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


	XYBody.Append("<!--footer end-->\r\n");

	XYBody.Append("");
	Response.Write(XYBody.ToString());
}
</script>
