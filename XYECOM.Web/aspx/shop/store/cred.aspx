<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.shop.cred,XYECOM.Page" %>
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


	XYBody.Append("<script type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("common/js/base.js\" language=\"javascript\"></" + "script>\r\n");
	XYBody.Append("<script src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/_shop/store/js/Cred.js\" type=\"text/javascript\"></" + "script>\r\n");

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


	XYBody.Append("<div class=\"main\">\r\n");
	XYBody.Append("    <!--�ұ���Ҫ����-->\r\n");
	XYBody.Append("    <div id=\"uright\">\r\n");
	XYBody.Append("        <!--վ�㵼��-->\r\n");
	XYBody.Append("        <div style=\"display: none;\">\r\n");
	XYBody.Append("            <em id=\"linkmessage\" style=\"display: none\"></em><em id=\"clicknum\" style=\"display: none\">\r\n");
	XYBody.Append("            </em><em id=\"msy\" style=\"display: none\"></em><em id=\"clicknum1\" style=\"display: none\">\r\n");
	XYBody.Append("            </em><em id=\"messnum\" style=\"display: none\"></em>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <script language=\"javascript\">\r\n");
	XYBody.Append("            window.onload = function () {\r\n");
	XYBody.Append("                changPage('');\r\n");
	XYBody.Append("            }\r\n");
	XYBody.Append("        </" + "script>\r\n");
	XYBody.Append("        <div class=\"rcon pb15\">\r\n");
	XYBody.Append("            <h2>\r\n");
	XYBody.Append("                ���ŵ���</h2>\r\n");
	XYBody.Append("            <div class=\" rcont\">\r\n");
	XYBody.Append("                <table class=\"table_value\">\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <th class=\"line1\">\r\n");
	XYBody.Append("                            ��ҵ���������ʣ�\r\n");
	XYBody.Append("                        </th>\r\n");
	XYBody.Append("                        <td class=\"line2\">\r\n");
	XYBody.Append("                            <label>\r\n");
	XYBody.Append("                                <img alt=\"��ҵ����������\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/_shop/store/images/rate.gif\" width=\"");	XYBody.Append(formation);	XYBody.Append("\" /></label><i>(\r\n");
	XYBody.Append("                                    ");	XYBody.Append(shopuserinfo.infoperfectpercent.ToString());	XYBody.Append("% )</i>\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <th class=\"line1\">\r\n");
	XYBody.Append("                            ��Ա���ޣ�\r\n");
	XYBody.Append("                        </th>\r\n");
	XYBody.Append("                        <td class=\"line2\">\r\n");
	XYBody.Append("                            ");	XYBody.Append(config.WebName);	XYBody.Append(" ");	XYBody.Append(shopuserinfo.gradename.ToString());	XYBody.Append(" �� <span class=\"f_f00\">");	XYBody.Append(year.ToString());	XYBody.Append("</span> ��\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <th class=\"line1\">\r\n");
	XYBody.Append("                            ������Ϣ��\r\n");
	XYBody.Append("                        </th>\r\n");
	XYBody.Append("                        <td class=\"line2\">\r\n");
	XYBody.Append("                            ������д���� <span class=\"f_f00\">");	XYBody.Append(shopuserinfo.maliceerr.ToString());	XYBody.Append("</span> �Σ� ������д���� <span class=\"f_f00\">\r\n");
	XYBody.Append("                                ");	XYBody.Append(shopuserinfo.commonerr.ToString());	XYBody.Append("</span> ��\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                </table>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <div class=\"rcon pb15\">\r\n");
	XYBody.Append("            <h2>\r\n");
	XYBody.Append("                <span>֤����Ϣ</span></h2>\r\n");
	XYBody.Append("            <div class=\"list_zs\">\r\n");
	XYBody.Append("                <ul class=\"bg\">\r\n");
	XYBody.Append("                    <li>֤��ͼƬ</li><li>֤������</li><li>��֤����</li><li>��Ч����</li><li>��������</li>\r\n");
	XYBody.Append("                </ul>\r\n");
	 data = GetCertificate();
	

	int info__loop__id=0;
	foreach(DataRow info in data.Rows)
	{
		info__loop__id++;

	 str = GetInfoImgHref("certificate",info["CE_ID"]);
	
	XYBody.Append("                <ul class=\"c\">\r\n");
	XYBody.Append("                    <li><a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("\">\r\n");
	XYBody.Append("                        <img src=\"");	XYBody.Append(str.ToString());	XYBody.Append("\" alt=\"֤��\" /></a></li>\r\n");
	XYBody.Append("                    <li><a href=\"");	XYBody.Append(str.ToString());	XYBody.Append("\">" + info["CE_Name"].ToString().Trim() + "</a></li>\r\n");
	XYBody.Append("                    <li>" + info["CE_Organ"].ToString().Trim() + "</li>\r\n");
	XYBody.Append("                    <li>\r\n");
	XYBody.Append( Method.formatdatetime(info["CE_Begin"].ToString().Trim(),"yyyy-MM-dd"));
	XYBody.Append("</li>\r\n");
	XYBody.Append("                    <li>\r\n");
	XYBody.Append( Method.formatdatetime(info["CE_Upto"].ToString().Trim(),"yyyy-MM-dd"));
	XYBody.Append("</li>\r\n");
	XYBody.Append("                </ul>\r\n");

	}	//end loop

	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <!--��ά��������-->\r\n");
	XYBody.Append("        <div>\r\n");
	XYBody.Append("            <ul>\r\n");
	XYBody.Append("                <li>��Ʒ������֣�");	XYBody.Append(avgProductsgrade.ToString());	XYBody.Append("��</li>\r\n");
	XYBody.Append("                <li>�����֣�");	XYBody.Append(avgDeliverygrade.ToString());	XYBody.Append("��</li>\r\n");
	XYBody.Append("                <li>������֣� ");	XYBody.Append(avgServicegrade.ToString());	XYBody.Append("��</li>\r\n");
	XYBody.Append("            </ul>\r\n");
	XYBody.Append("            <select id=\"selectDate\" name=\"selectDate\" style=\"display: none\">\r\n");
	XYBody.Append("                <option value=\"7\" selected=\"selected\">���һ��</option>\r\n");
	XYBody.Append("                <option value=\"30\">���һ��</option>\r\n");
	XYBody.Append("                <option value=\"180\">�������</option>\r\n");
	XYBody.Append("                <option value=\"0\">����</option>\r\n");
	XYBody.Append("            </select>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <div>\r\n");
	XYBody.Append("            <h3>\r\n");
	XYBody.Append("                ���������ã�");	XYBody.Append(shopuserinfo.creditintegral.ToString());	XYBody.Append("");	XYBody.Append(credImag.ToString());	XYBody.Append("</h3>\r\n");
	XYBody.Append("            <ul>\r\n");
	XYBody.Append("                <li style=\"float: left\">����</li>\r\n");
	XYBody.Append("                <li style=\"float: left\">����</li>\r\n");
	XYBody.Append("                <li>����</li>\r\n");
	XYBody.Append("                 <li style=\"float: left\">");	XYBody.Append(goodNum.ToString());	XYBody.Append("</li>\r\n");
	XYBody.Append("                <li style=\"float: left\">");	XYBody.Append(mediumNum.ToString());	XYBody.Append("</li>\r\n");
	XYBody.Append("                <li>");	XYBody.Append(poorNum.ToString());	XYBody.Append("</li>\r\n");
	XYBody.Append("            </ul>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <input type=\"hidden\" value=\"");	XYBody.Append(shopuserinfo.userid.ToString());	XYBody.Append("\" id=\"sellerId\" />\r\n");
	XYBody.Append("        <input type=\"hidden\" value=\"");	XYBody.Append(pageSize.ToString());	XYBody.Append("\" id=\"pageSize\" />\r\n");
	XYBody.Append("        <input type=\"hidden\" value=\"1\" id=\"pageCount\" />\r\n");
	XYBody.Append("        <input type=\"hidden\" value=\"");	XYBody.Append(pageIndex.ToString());	XYBody.Append("\" id=\"pageIndex\" />\r\n");
	XYBody.Append("        <!--�����б�-->\r\n");
	XYBody.Append("        <div>\r\n");
	XYBody.Append("            <ul>\r\n");
	XYBody.Append("                <li style=\"float: left\">\r\n");
	XYBody.Append("                    <select id=\"selectCred\" style=\"margin-right: 15px\" onchange=\"SelectChang(this);\">\r\n");
	XYBody.Append("                        <option selected=\"selected\" value=\"\">ȫ������</option>\r\n");
	XYBody.Append("                        <option value=\"1\">����</option>\r\n");
	XYBody.Append("                        <option value=\"0\">����</option>\r\n");
	XYBody.Append("                        <option value=\"-1\">����</option>\r\n");
	XYBody.Append("                    </select>\r\n");
	XYBody.Append("                </li>\r\n");
	XYBody.Append("                <li style=\"float: left\">������ </li>\r\n");
	XYBody.Append("                <li>������Ϣ </li>\r\n");
	XYBody.Append("            </ul>\r\n");
	XYBody.Append("            <ul id=\"credList\">\r\n");
	XYBody.Append("            </ul>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <div>\r\n");
	XYBody.Append("            <span style=\"cursor: pointer;\" onclick=\"javascript:changPage('top')\">��һҳ</span>\r\n");
	XYBody.Append("            <span style=\"cursor: pointer;\" onclick=\"javascript:changPage('up')\">��һҳ</span> <span\r\n");
	XYBody.Append("                style=\"cursor: pointer;\" onclick=\"javascript:changPage('dw')\">��һҳ</span> <span style=\"cursor: pointer;\"\r\n");
	XYBody.Append("                    onclick=\"javascript:changPage('end')\">βҳ </span>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("</div>\r\n");

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
