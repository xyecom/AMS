<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.shop.newsinfo,XYECOM.Page" %>
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



	XYBody.Append("<div id=\"ubox\">\r\n");
	XYBody.Append("    <!--��ߵ���-->\r\n");
	XYBody.Append("    <div id=\"uleftnav\">\r\n");

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


	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <!--��ߵ���  end-->\r\n");
	XYBody.Append("    <!--�ұ���Ҫ����-->\r\n");
	XYBody.Append("    <div id=\"uright\">\r\n");
	XYBody.Append("        <!--վ�㵼��-->\r\n");
	XYBody.Append("        <div style=\"display: none;\">\r\n");
	XYBody.Append("            <em id=\"clicknum1\" style=\"display: none\"></em><em id=\"clicknum\" style=\"display: none\">\r\n");
	XYBody.Append("            </em><em id=\"linkmessage\" style=\"display: none\"></em><em id=\"msy\" style=\"display: none\">\r\n");
	XYBody.Append("            </em><em id=\"messnum\" style=\"display: none\"></em>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <!--��˾����-->\r\n");
	XYBody.Append("        <div class=\"rcon font14\">\r\n");
	XYBody.Append("            <h2>\r\n");
	XYBody.Append("                ��˾��̬</h2>\r\n");
	XYBody.Append("            <div class=\"news font14\">\r\n");
	XYBody.Append("                <h3 class=\"font14\">\r\n");
	XYBody.Append("                    ");	XYBody.Append(news.Title.ToString());	XYBody.Append("</h3>\r\n");
	XYBody.Append("                ");	XYBody.Append(news.Content.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                <div class=\"txtlink\">\r\n");
	XYBody.Append("                    ");	XYBody.Append(news.AddTime.ToString());	XYBody.Append("</div>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("</div>\r\n");

	XYBody.Append("<div id=\"footer\">\r\n");
	XYBody.Append("    ����֧�֣�<a href=\"#\" target=\"_blank\"> ������ծȨ������</a>&nbsp;&nbsp;��Ȩ���У�<a href='#'> ��������</a>&nbsp;&nbsp;\r\n");
	XYBody.Append("    ��ʦִҵ֤�ţ�3270205110055 �绰��132323232323 QQ��454547676<br />\r\n");
	XYBody.Append("    ���ǵ�787λ�˿� ��վ��վ��<a href=\"#\" target=\"_blank\"> www.baoqt.cn</a> <a href=\"#\" target=\"_blank\">\r\n");
	XYBody.Append("        EMAIL��hpbqt@163.com</a>\r\n");
	XYBody.Append("    <br />\r\n");
	XYBody.Append("    <a href=\"#\" target=\"_blank\">������Ϣ��ҵ������ ��ICP��05047375 �������й���������֧�ӱ�����37010009000020��</a>\r\n");
	XYBody.Append("</div>\r\n");



	XYBody.Append("");
	Response.Write(XYBody.ToString());
}
</script>
