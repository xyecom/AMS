<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.person.supplybuydoing,XYECOM.Page" %>
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

	XYBody.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD html 4.01 Transitional//EN\" \"http://www.w3c.org/TR/1999/REC-html401-19991224/loose.dtd\">\r\n");
	XYBody.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n");
	XYBody.Append("<head>\r\n");
	XYBody.Append("<TITLE>��������</TITLE>\r\n");
	XYBody.Append("<meta http-equiv=Content-Type content=\"text/html; charset=gb2312\">\r\n");
	XYBody.Append("<meta content=\"��������\" name=\"keywords\">\r\n");
	XYBody.Append("<meta content=\"\" name=\"description\">\r\n");
	XYBody.Append("<link href=\"/common/css/XYLib.css\" type=\"text/css\" rel=\"Stylesheet\" />\r\n");
	XYBody.Append("<link href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/person/css/main.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n");
	XYBody.Append("<script language =\"javascript\" type=\"text/javascript\"  src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("common/js/base.js\"></" + "script>\r\n");
	XYBody.Append("<script language =\"javascript\" type=\"text/javascript\"  src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("common/js/UploadControl.js\"></" + "script>\r\n");
	XYBody.Append("<script language =\"javascript\" type=\"text/javascript\"  src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("common/js/date.js\"></" + "script>\r\n");
	XYBody.Append("<script language =\"javascript\" type=\"text/javascript\"  src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/person/js/common.js\"></" + "script>\r\n");
	XYBody.Append("<script language =\"javascript\" type=\"text/javascript\"  src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/person/js/validate.js\"></" + "script>\r\n");
	XYBody.Append("</head>\r\n");
	XYBody.Append("<body onload=\"");	XYBody.Append(pageinfo.OnLoadEvents);	XYBody.Append("\">\r\n");
	XYBody.Append("<div class=div_body>\r\n");
	XYBody.Append("    <div class=New_top>\r\n");
	XYBody.Append("        <div class=more>\r\n");
	XYBody.Append("            <ul>\r\n");
	XYBody.Append("              <li><a class=\"zeroc\" href=\"");	XYBody.Append(config.weburl);	XYBody.Append("\">��ҳ</a> </li>\r\n");
	XYBody.Append("              <li><a class=\"zeroc\" href=\"");	XYBody.Append(config.weburl);	XYBody.Append("news/\">��ҵ��Ѷ</a> </li>\r\n");
	XYBody.Append("              <li><a class=\"zeroc\" href=\"");	XYBody.Append(config.weburl);	XYBody.Append("offer/\">��Ʒ��</a> </li>\r\n");
	XYBody.Append("              <li><a class=\"zeroc\" href=\"");	XYBody.Append(config.weburl);	XYBody.Append("investment/\">���̼���</a> </li>\r\n");
	XYBody.Append("              <li><a class=\"zeroc\" href=\"");	XYBody.Append(config.weburl);	XYBody.Append("exhibition/\">չ��</a> </li>\r\n");
	XYBody.Append("              <li><a class=\"zeroc\" href=\"");	XYBody.Append(config.weburl);	XYBody.Append("job/\">�˲�</a> </li>\r\n");
	XYBody.Append("            </ul>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <div class=\"r\">\r\n");
	XYBody.Append("            <a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("logout.");	XYBody.Append(config.suffix);	XYBody.Append("\">�˳�</a> | <a href=\"\">����</a>&nbsp; \r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<div class=Head>\r\n");
	XYBody.Append("    <div class=\"Head_4\"> \r\n");
	XYBody.Append("        <div class=\"index\"><div class=\"act\"><a href=\"index.");	XYBody.Append(config.suffix);	XYBody.Append("\">�� ҳ</a></div></div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<div class=\"div_body\" style=\"WIDTH: 994px\">\r\n");
	XYBody.Append("    <div class=\"body_bg\">\r\n");
	XYBody.Append("        <div><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/person/images/p1.jpg\"></div>\r\n");
	XYBody.Append("        <div class=\"bodyW\">\r\n");


	XYBody.Append("<!--<div class=\"location fia\">\r\n");
	XYBody.Append("    <a href=\"index.");	XYBody.Append(config.Suffix);	XYBody.Append("\">��������</a> &gt; ��ҵ��Ϣ &gt; ����Ϣ����</div>-->\r\n");

	XYBody.Append("<div class=\"Al\">\r\n");
	XYBody.Append("    <div class=\"Al_1\">\r\n");
	XYBody.Append("        ���˷����б�:</div>\r\n");
	XYBody.Append("    <div class=\"Al_2\">\r\n");
	XYBody.Append("        <dl>\r\n");
	XYBody.Append("            <dt><a class=\"\" id=\"a1\" style=\"padding-right: 10px;\" href=\"javascript:void(0);\">\r\n");
	XYBody.Append("                <img src=\"");	XYBody.Append(config.weburl);	XYBody.Append("/templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/user/images/a9.gif\">\r\n");
	XYBody.Append("                ��Ա�˻����� </a></dt>\r\n");
	XYBody.Append("            <dd id=\"div_1\" style=\"display: block\">\r\n");
	XYBody.Append("                <a href=\"/person/individuallist.");	XYBody.Append(config.Suffix);	XYBody.Append("\">�鿴ע����Ϣ</a><br />\r\n");
	XYBody.Append("                <a href=\"/person/individualinfo.");	XYBody.Append(config.Suffix);	XYBody.Append("\">ά����������</a><br />\r\n");
	XYBody.Append("                <a href=\"/person/resume.");	XYBody.Append(config.Suffix);	XYBody.Append("\">ά�����˼���</a><br />\r\n");
	XYBody.Append("                <a href=\"/person/edituserpassword.");	XYBody.Append(config.Suffix);	XYBody.Append("\">�޸ĵ�½����</a><br />\r\n");
	XYBody.Append("                <a href=\"/person/editpaypassword.aspx\">�޸�֧������</a><br />\r\n");
	XYBody.Append("                <a href=\"/person/resumesend.");	XYBody.Append(config.Suffix);	XYBody.Append("\">ְλ�����¼</a><br />\r\n");
	XYBody.Append("            </dd>\r\n");
	XYBody.Append("        </dl>\r\n");
	XYBody.Append("        <dl>\r\n");
	XYBody.Append("            <dt><a class=\"\" id=\"a2\" style=\"padding-right: 10px;\" href=\"javascript:void(0);\">\r\n");
	XYBody.Append("                <img src=\"");	XYBody.Append(config.weburl);	XYBody.Append("/templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/user/images/1.gif\" />\r\n");
	XYBody.Append("                ������Ϣ���� </a></dt>\r\n");
	XYBody.Append("            <dd id=\"div_2\" style=\"display: block\">\r\n");
	XYBody.Append("                <a href=\"/person/receivemessagelist.");	XYBody.Append(config.Suffix);	XYBody.Append("\">���յ���������Ϣ</a><br />\r\n");
	XYBody.Append("                <a href=\"/person/sendmessagelist.");	XYBody.Append(config.Suffix);	XYBody.Append("\">�ҷ�����������Ϣ</a><br />\r\n");
	XYBody.Append("                <a href=\"/person/postadministratormessage.");	XYBody.Append(config.Suffix);	XYBody.Append("\">������Ա����</a><br />\r\n");
	XYBody.Append("            </dd>\r\n");
	XYBody.Append("        </dl>\r\n");
	XYBody.Append("        <dl>\r\n");
	XYBody.Append("            <dt><a class=\"\" id=\"a3\" style=\"padding-right: 10px;\" onclick=\"javascript:switchShow('3')\"\r\n");
	XYBody.Append("                href=\"javascript:void(0);\">\r\n");
	XYBody.Append("                <img src=\"");	XYBody.Append(config.weburl);	XYBody.Append("/templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/user/images/5.gif\" />\r\n");
	XYBody.Append("                ������� </a></dt>\r\n");
	XYBody.Append("            <dd id=\"div_3\" style=\"display: block\">\r\n");
	XYBody.Append("                <a href=\"/person/cashacount.");	XYBody.Append(config.Suffix);	XYBody.Append("\">�ʻ���Ϣ</a><br />                \r\n");
	XYBody.Append("                <a href=\"/person/invoice.");	XYBody.Append(config.Suffix);	XYBody.Append("\">���뷢Ʊ</a><br />\r\n");
	XYBody.Append("                <a href=\"/person/remit.");	XYBody.Append(config.Suffix);	XYBody.Append("\">���ȷ��</a><br />\r\n");
	XYBody.Append("            </dd>\r\n");
	XYBody.Append("        </dl>\r\n");
	XYBody.Append("        <dl>\r\n");
	XYBody.Append("            <dt><a class=\"\" id=\"a4\" style=\"padding-right: 10px;\" onclick=\"javascript:switchShow('4')\"\r\n");
	XYBody.Append("                href=\"javascript:void(0);\">\r\n");
	XYBody.Append("                <img src=\"");	XYBody.Append(config.weburl);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/user/images/5.gif\" />\r\n");
	XYBody.Append("                �ҵĽ�����Ϣ </a></dt>\r\n");
	XYBody.Append("            <dd id=\"div_4\" style=\"display: block\">\r\n");
	XYBody.Append("                <a href=\"/person/BuyerOrderList.aspx\">�ɹ�����</a><br />\r\n");
	XYBody.Append("                <a href=\"/person/ListBuyerContract.aspx\">��ͬ����</a><br />\r\n");
	XYBody.Append("                <a href=\"/person/TeamBuy/TeamBuyerOrderList.aspx\">�Ź���������</a><br />\r\n");
	XYBody.Append("            </dd>\r\n");
	XYBody.Append("        </dl>\r\n");
	XYBody.Append("        <dl>\r\n");
	XYBody.Append("            <dt><a class=\"\" id=\"a5\" style=\"padding-right: 10px;\" onclick=\"javascript:switchShow('5')\"\r\n");
	XYBody.Append("                href=\"javascript:void(0);\">\r\n");
	XYBody.Append("                <img src=\"");	XYBody.Append(config.weburl);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/user/images/5.gif\" />\r\n");
	XYBody.Append("                �ҵ�����Ϣ </a></dt>\r\n");
	XYBody.Append("            <dd id=\"div_5\" style=\"display: block\">\r\n");
	XYBody.Append("                <a href=\"/person/adv_postbuy.aspx\">������</a><br />\r\n");
	XYBody.Append("                <a href=\"/person/supplybuy.aspx\">�ɹ�����</a><br />\r\n");
	XYBody.Append("            </dd>\r\n");
	XYBody.Append("        </dl>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("</div>\r\n");


	XYBody.Append("<div id=\"right\">\r\n");
	XYBody.Append(" <ul class=\"topNav\"><li>\r\n");
	XYBody.Append("  <a href=\"index.");	XYBody.Append(config.Suffix);	XYBody.Append("\">��������</a> &gt; ��ҵ��Ϣ &gt; ����Ϣ����\r\n");
	XYBody.Append("    </li></ul>\r\n");
	XYBody.Append("    <form action=\"#\" method=\"post\">\r\n");
	XYBody.Append("    <h2>\r\n");
	XYBody.Append("        <span>\r\n");
	XYBody.Append("            <input type=\"button\" class=\"button\" value=\"�����µ�����Ϣ\" onclick=\"window.location.href='");	XYBody.Append(config.WebURL);	XYBody.Append("person/adv_postbuy.aspx'\" />\r\n");
	XYBody.Append("        </span>��������Ϣ\r\n");
	XYBody.Append("    </h2>\r\n");
	XYBody.Append("    <div class=\"ly_100\">\r\n");
	XYBody.Append("        <div class=\"ly_tit3\">\r\n");
	XYBody.Append("            <ul>\r\n");
	XYBody.Append("                <li class=\"out\"><a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("user/supplybuy.aspx\">\r\n");
	XYBody.Append("                    �ѷ�������(");	XYBody.Append(auditedcount.ToString());	XYBody.Append(")</a></li>\r\n");
	XYBody.Append("                <li class=\"on\"><a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("user/supplybuydoing.aspx\">\r\n");
	XYBody.Append("                    �����(");	XYBody.Append(auditingcount.ToString());	XYBody.Append(")</a></li>\r\n");
	XYBody.Append("                <li class=\"out\"><a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("user/supplybuynopass.aspx\">\r\n");
	XYBody.Append("                    ���δͨ��(");	XYBody.Append(notauditedcount.ToString());	XYBody.Append(")</a></li>\r\n");
	XYBody.Append("            </ul>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <div class=\"ly_tit32\">\r\n");
	XYBody.Append("            ��Ʒ���ƣ�<input type=\"text\" id=\"key\" maxlength=\"50\" name=\"key\" value=\"");	XYBody.Append(key.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("            <select id=\"infotype\" name=\"infotype\">\r\n");
	XYBody.Append("                <option value=\"\">����</option>\r\n");
	XYBody.Append("                <option value=\"1\">������</option>\r\n");
	XYBody.Append("                <option value=\"0\">��ͨ��</option>\r\n");
	XYBody.Append("            </select>\r\n");
	XYBody.Append("            <input type=\"submit\" class=\"button\" name=\"submit_search\" value=\"��ѯ\" />\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <table class=\"ly_tab2 ly_w1\" id=\"supplyauditing\">\r\n");
	XYBody.Append("        <thead>\r\n");
	XYBody.Append("            <tr>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    ѡ��\r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    ����\r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    ��������\r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    ���״̬\r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    ��״̬\r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    ������\r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    �޸�\r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("            </tr>\r\n");
	XYBody.Append("        </thead>\r\n");
	XYBody.Append("        <tbody>\r\n");
	XYBody.Append("            <input name=\"sdid\" id=\"sdid\" type=\"hidden\" value=\"\" />\r\n");

	int SD__loop__id=0;
	foreach(DataRow SD in infolist.Rows)
	{
		SD__loop__id++;

	XYBody.Append("            <tr>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    <input name=\"sd_id\" id=\"sd_id\" type=\"checkbox\" value=\"" + SD["SD_ID"].ToString().Trim() + "\" />\r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("                <td valign=\"top\">\r\n");
	XYBody.Append("                    " + SD["Title"].ToString().Trim() + "\r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("                <td class=\"wbg_setTime\">\r\n");
	XYBody.Append("                    " + SD["PublishDate"].ToString().Trim() + "\r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("                <td >\r\n");
	 state = GetAuditingState(XYECOM.Core.MyConvert.GetInt32(SD["AuditingState"].ToString()));
	
	XYBody.Append("                    ");	XYBody.Append(state.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("                <td>\r\n");

	if (SD["Emergency"].ToString().Trim()=="True")
	{

	XYBody.Append("                    <span style=\"color:#f60;\">������</span>\r\n");

	}
	else
	{

	XYBody.Append("                    <span style=\"color: #336600; \">��ͨ��</span>\r\n");

	}	//end if

	XYBody.Append("                </td>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    " + SD["BuyNum"].ToString().Trim() + "\r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    <input type=\"button\" class=\"button\" value=\"�޸�\" onclick=\"location.href='");	XYBody.Append(config.WebURL);	XYBody.Append("user/adv_postbuy.aspx?ID=" + SD["SD_ID"].ToString().Trim() + "';\" />\r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("            </tr>\r\n");

	}	//end loop

	XYBody.Append("            <tr>\r\n");
	XYBody.Append("                <td colspan=\"7\">\r\n");
	XYBody.Append("                    <input id=\"chkAll\" name=\"chkAll\" type=\"checkbox\" value=\"\" onclick=\"CheckedAll();\" />ȫѡ&nbsp;&nbsp;&nbsp;\r\n");
	XYBody.Append("                    <input name=\"Supply\" class=\"button\" type=\"submit\" value=\"ɾ��\" onclick=\"return bntDelete()\" />&nbsp;\r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("            </tr>\r\n");
	XYBody.Append("        </tbody>\r\n");
	XYBody.Append("    </table>\r\n");
	XYBody.Append("    <div class=\"page\">\r\n");
	XYBody.Append("        ��ǰ�ǵ� <span>");	XYBody.Append(pageinfo.PageIndex);	XYBody.Append("</span> ҳ &nbsp;���� <span>");	XYBody.Append(pageinfo.PageCount);	XYBody.Append("</span>\r\n");
	XYBody.Append("        ҳ��&nbsp;");	XYBody.Append(pageinfo.FirstPage);	XYBody.Append("&nbsp;");	XYBody.Append(pageinfo.PreviousPage);	XYBody.Append("&nbsp;");	XYBody.Append(pageinfo.NextPage);	XYBody.Append("&nbsp;");	XYBody.Append(pageinfo.LastPage);	XYBody.Append("</div>\r\n");
	XYBody.Append("    <input type=\"hidden\" id=\"isSetPause\" name=\"isSetPause\" value=\"\" />\r\n");
	XYBody.Append("    <input type=\"hidden\" id=\"isDelete\" name=\"isDelete\" value=\"\" />\r\n");
	XYBody.Append("    </form>\r\n");
	XYBody.Append("</div>\r\n");

	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <div><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/person/images/p2.jpg\"></div>\r\n");
	XYBody.Append("        <br style=\"FONT: 0px/0 arial\" clear=\"all\"/>\r\n");
	XYBody.Append("        <div class=\"foot\">\r\n");
	XYBody.Append("            ���");	XYBody.Append(config.webname);	XYBody.Append("�������������κ�ʹ������ͽ��� ������ <a  href=\"\">��ϵ�������Ĺ���Ա</a> �� <a href=\"\">�鿴����</a> <br><a href=\"http://www.xyecom.com\">XYECOM ���</a> | <a href=\"\">�û�ע��</a> | <a class=lan12i href=\"\" target=_top>������</a> | <a class=lan12i href=\"\" target=_top>��Ƹ</a> | <a class=lan12i href=\"\" target=_top>վ���ͼ</a> | <a class=lan12i href=\"\" target=_top>��ϵ��ʽ</a> | <a class=lan12i href=\"\" target=_top>��ӭͶ�� </a>| <a href=\"\">ͼ�� </a>| <a class=lan12i href=\"\" target=_top>RSS����</a> <br>Copyright &copy; 2005 - 2009 XYECOM. All rights reserved. ");	XYBody.Append(config.webname);	XYBody.Append(" ��Ȩ����. \r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <br style=\"CLEAR: both\">\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("</body>\r\n");
	XYBody.Append("</html>\r\n");



	XYBody.Append(IsCopyright());
	Response.Write(XYBody.ToString());
}
</script>
