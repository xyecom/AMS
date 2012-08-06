<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.shop.index,XYECOM.Page" %>
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
	XYBody.Append("    <title>�����̸�����ҳ</title>\r\n");
	XYBody.Append("    <link href=\"/Other/css/serverinfo.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n");
	XYBody.Append("    <script src=\"/Other/js/jquery.js\" type=\"text/javascript\"></" + "script>\r\n");
	XYBody.Append("</head>\r\n");
	XYBody.Append("<body>\r\n");
	XYBody.Append("    <!--top start-->\r\n");

	XYBody.Append("<div id=\"top\">\r\n");

	if (islogin)
	{

	XYBody.Append("    <div id=\"top1\">\r\n");
	XYBody.Append("        ���ã���ӭ&nbsp;&nbsp;<strong>");	XYBody.Append(loginname.ToString());	XYBody.Append("</strong>&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"");	XYBody.Append(editinfourl.ToString());	XYBody.Append("\">�޸�����</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a\r\n");
	XYBody.Append("            href=\"");	XYBody.Append(modifypwdurl.ToString());	XYBody.Append("\">�޸�����</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a href=\"/\">��վ��ҳ</a></div>\r\n");
	XYBody.Append("    <div id=\"top2\">\r\n");
	XYBody.Append("        <a href=\"/LogOut.aspx\">���˳�ϵͳ��</a></div>\r\n");

	}
	else
	{

	XYBody.Append("    <div id=\"top1\">\r\n");
	XYBody.Append("        <a href=\"/login.aspx\">��½</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a href=\"/Register.aspx\">ע��</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a\r\n");
	XYBody.Append("            href=\"/\">��վ��ҳ</a></div>\r\n");

	}	//end if

	XYBody.Append("</div>\r\n");


	XYBody.Append("    <!--top end-->\r\n");

	XYBody.Append("<div id=\"banner\">\r\n");
	XYBody.Append("    <p>\r\n");
	XYBody.Append("        ��ӭ����<strong>");	XYBody.Append(shopuserinfo.CompanyName.ToString());	XYBody.Append("</strong>�ķ��ɹ�����</p>\r\n");
	XYBody.Append("    <font>��ѯ���ߣ�");	XYBody.Append(shopuserinfo.Telphone.ToString());	XYBody.Append("</font>\r\n");
	XYBody.Append("</div>\r\n");


	XYBody.Append("    <!--menu start-->\r\n");

	XYBody.Append("<div id=\"menu\">\r\n");
	XYBody.Append("    <ul>\r\n");
	XYBody.Append("        <li class='m_li_a'><a href=\"#\">��ҳ</a></li>\r\n");
	XYBody.Append("        <li class=\"m_line\">\r\n");
	XYBody.Append("            <img src=\"/Other/images/line1.gif\" /></li>\r\n");
	XYBody.Append("        <li class='m_li' onmouseover='mover(2);' onmouseout='mout(2);'><a href=\"/shop/");	XYBody.Append(shopuserinfo.LoginName.ToString());	XYBody.Append("/Cred.aspx\">���ŵ���</a></li>\r\n");
	XYBody.Append("        <li class=\"m_line\">\r\n");
	XYBody.Append("            <img src=\"/Other/images/line1.gif\" /></li>\r\n");
	XYBody.Append("        <li class='m_li' onmouseover='mover(3);' onmouseout='mout(3);'><a href=\"#\">���߻���</a></li>\r\n");
	XYBody.Append("        <li class=\"m_line\">\r\n");
	XYBody.Append("            <img src=\"/Other/images/line1.gif\" /></li>\r\n");
	XYBody.Append("        <li class='m_li' onmouseover='mover(4);' onmouseout='mout(4);'><a href=\"#\">�ɹ�����</a></li>\r\n");
	XYBody.Append("    </ul>\r\n");
	XYBody.Append("</div>\r\n");


	XYBody.Append("    <!--menu end-->\r\n");
	XYBody.Append("    <!--middle start-->\r\n");
	XYBody.Append("    <div id=\"middle\">\r\n");
	XYBody.Append("        <!--left start-->\r\n");

	XYBody.Append("<div id=\"left\">\r\n");
	XYBody.Append("    <div id=\"leftlszl\">\r\n");
	XYBody.Append("        <div id=\"lszl\">\r\n");
	XYBody.Append("            <p style=\"height: 110px; width: 91px; float: left; line-height: 120px\">\r\n");
	XYBody.Append("                <img src=\"");	XYBody.Append(shopuserinfo.LayerPicture.ToString());	XYBody.Append("\" style=\"height: 76px; width: 86px\" /></p>\r\n");
	XYBody.Append("            <p style=\"height: 96px; width: 138px; float: left; padding-top: 10px\">\r\n");
	XYBody.Append("                <strong>");	XYBody.Append(shopuserinfo.LayerName.ToString());	XYBody.Append("</strong><br />\r\n");
	XYBody.Append("                ���ڵ�����");	XYBody.Append(shopuserinfo.AreaName.ToString());	XYBody.Append("<br />\r\n");
	XYBody.Append("                �绰��");	XYBody.Append(shopuserinfo.Telphone.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                <br />\r\n");
	XYBody.Append("            </p>\r\n");
	XYBody.Append("            ~~~~~~~~~~~~~~~~~~~~~~~~<br />\r\n");
	XYBody.Append("            ִҵ֤�ţ� ");	XYBody.Append(shopuserinfo.LayerId.ToString());	XYBody.Append("<br />\r\n");
	XYBody.Append("            ִҵ������ ");	XYBody.Append(shopuserinfo.CompanyName.ToString());	XYBody.Append("<br />\r\n");
	XYBody.Append("            E-mail�� ");	XYBody.Append(shopuserinfo.Email.ToString());	XYBody.Append("\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <div id=\"leftpj\">\r\n");
	XYBody.Append("        <div id=\"menutop\">\r\n");
	XYBody.Append("            <h1>\r\n");
	XYBody.Append("                �û�����</h1>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <p>\r\n");
	XYBody.Append("            <strong>��������</strong> ���������<strong>");	XYBody.Append(shopuserinfo.Point.ToString());	XYBody.Append("</strong>��<br />\r\n");
	XYBody.Append("            ���У�������");	XYBody.Append(shopuserinfo.GoodTimes.ToString());	XYBody.Append("�� ������");	XYBody.Append(shopuserinfo.BadTimes.ToString());	XYBody.Append("��\r\n");
	XYBody.Append("        </p>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("</div>\r\n");


	XYBody.Append("        <!--left end-->\r\n");
	XYBody.Append("        <!--right start-->\r\n");
	XYBody.Append("        <div id=\"right\">\r\n");
	XYBody.Append("            <div class=\"lsjs\">\r\n");
	XYBody.Append("                <div class=\"jsh\">\r\n");
	XYBody.Append("                    <img src=\"/Other/images/jshead.gif\" /></div>\r\n");
	XYBody.Append("                <p>\r\n");
	XYBody.Append("                    ��ʦ������");	XYBody.Append(shopuserinfo.LayerName.ToString());	XYBody.Append(" ��ʦִҵ֤�ţ�");	XYBody.Append(shopuserinfo.LayerId.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                </p>\r\n");
	XYBody.Append("                <!--             <p>\r\n");
	XYBody.Append("                    ������ַ����˾��ַ��http://www.jdflzx.com</p>-->\r\n");
	XYBody.Append("                <p>\r\n");
	XYBody.Append("                    �����������ض���˾����148���ɷ�����</p>\r\n");
	XYBody.Append("                <p>\r\n");
	XYBody.Append("                    ");	XYBody.Append(shopuserinfo.Description.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                </p>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("            <div class=\"lsjs\">\r\n");
	XYBody.Append("                <div class=\"jsh\">\r\n");
	XYBody.Append("                    <img src=\"/Other/images/ryjzs.gif\" /></div>\r\n");
	XYBody.Append("                <p>\r\n");

	int info__loop__id=0;
	foreach(DataRow info in data.Rows)
	{
		info__loop__id++;

	 str = GetInfoImgHref(info["CE_ID"]);
	
	XYBody.Append("                    <img src=\"");	XYBody.Append(str.ToString());	XYBody.Append("\" alt='" + info["CE_Name"].ToString().Trim() + "' style=\"width: 100px\" />\r\n");

	}	//end loop

	XYBody.Append("                </p>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <!--right end-->\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <!--middle end-->\r\n");

	XYBody.Append("<div id=\"footer\">\r\n");
	XYBody.Append("    ����֧�֣�<a href=\"#\" target=\"_blank\"> ������ծȨ������</a>&nbsp;&nbsp;��Ȩ���У�<a href='#'> ��������</a>&nbsp;&nbsp;\r\n");
	XYBody.Append("    ��ʦִҵ֤�ţ�3270205110055 �绰��132323232323 QQ��454547676<br />\r\n");
	XYBody.Append("    ���ǵ�787λ�˿� ��վ��վ��<a href=\"#\" target=\"_blank\"> www.baoqt.cn</a> <a href=\"#\" target=\"_blank\">\r\n");
	XYBody.Append("        EMAIL��hpbqt@163.com</a>\r\n");
	XYBody.Append("    <br />\r\n");
	XYBody.Append("    <a href=\"#\" target=\"_blank\">������Ϣ��ҵ������ ��ICP��05047375 �������й���������֧�ӱ�����37010009000020��</a>\r\n");
	XYBody.Append("</div>\r\n");


	XYBody.Append("</body>\r\n");
	XYBody.Append("</html>\r\n");

	XYBody.Append("");
	Response.Write(XYBody.ToString());
}
</script>
