<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.shop.introduction,XYECOM.Page" %>
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
	XYBody.Append("<!--��ߵ���-->\r\n");
	XYBody.Append("<div id=\"uleftnav\">\r\n");

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


	XYBody.Append("</div>\r\n");
	XYBody.Append("<!--��ߵ���  end-->\r\n");
	XYBody.Append("<!--�ұ���Ҫ����-->\r\n");
	XYBody.Append("<div id=\"uright\">\r\n");
	XYBody.Append("    <!--վ�㵼��-->\r\n");
	XYBody.Append("	<div style=\"display:none;\"><em id=\"clicknum1\" style =\"display :none\"></em> <em id=\"clicknum\" style =\"display :none\"></em><em id=\"linkmessage\" style =\"display :none\"></em><em id=\"msy\" style =\"display :none\"></em><em id=\"messnum\" style =\"display :none\"></em></div>\r\n");
	XYBody.Append("	<!--��˾����-->\r\n");
	XYBody.Append("	<div class=\"rcon\">\r\n");
	XYBody.Append("	<h2>��˾����</h2>\r\n");
	XYBody.Append("	<p class=\"font142\">\r\n");

	if (shopuserinfo.imgurl!="")
	{

	XYBody.Append("<img alt=\"");	XYBody.Append(shopuserinfo.loginname.ToString());	XYBody.Append("\" src=\"");	XYBody.Append(shopuserinfo.imgurl.ToString());	XYBody.Append("\" />\r\n");

	}
	else
	{

	XYBody.Append("<img alt=\"");	XYBody.Append(shopuserinfo.loginname.ToString());	XYBody.Append("\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/WelcomeInfro_32.gif\" />\r\n");

	}	//end if

	XYBody.Append("	");	XYBody.Append(shopuserinfo.synopsis.ToString());	XYBody.Append("\r\n");
	XYBody.Append("</p>\r\n");
	XYBody.Append("	</div>\r\n");
	XYBody.Append("	<div class=\"rcon\">\r\n");
	XYBody.Append("	<h2>��ϸ��Ϣ</h2>\r\n");
	XYBody.Append("	<div class=\"rcont\">\r\n");
	XYBody.Append("        <table class=\"table_infos\">\r\n");
	XYBody.Append("            <tr>\r\n");
	XYBody.Append("                <th class=\"line1\">\r\n");
	XYBody.Append("                    ��˾���ƣ�</th>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    ");	XYBody.Append(shopuserinfo.unitname.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("                <th class=\"line1\">\r\n");
	XYBody.Append("                    ����ʱ�䣺</th>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    ");	XYBody.Append(shopuserinfo.regyear.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("            </tr>\r\n");
	XYBody.Append("            <tr>\r\n");
	XYBody.Append("                <th class=\"line1\">\r\n");
	XYBody.Append("                    ��Ӫģʽ��</th>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    ");	XYBody.Append(shopuserinfo.mode.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("                <th class=\"line1\">\r\n");
	XYBody.Append("                    ��Ӧ�Ĳ�Ʒ�ͷ���</th>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    ");	XYBody.Append(shopuserinfo.supplypro.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("            </tr>\r\n");
	XYBody.Append("            <tr>\r\n");
	XYBody.Append("                <th class=\"line1\">\r\n");
	XYBody.Append("                    ��˾��ҳ��</th>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    <a href=\"");	XYBody.Append(shopuserinfo.homepage.ToString());	XYBody.Append("\">");	XYBody.Append(shopuserinfo.homepage.ToString());	XYBody.Append("</a>\r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("                <th class=\"line1\">\r\n");
	XYBody.Append("                    ע���ʱ���</th>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    ");	XYBody.Append(shopuserinfo.registeredcapital.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("            </tr>\r\n");
	XYBody.Append("            <tr>\r\n");
	XYBody.Append("                <th class=\"line1 colorFF7300\">\r\n");
	XYBody.Append("                    ��ҵ���ͣ�</th>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    ");	XYBody.Append(shopuserinfo.unittype.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("                <th class=\"line1 colorFF7300\">\r\n");
	XYBody.Append("                    ��˾���ʣ�</th>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    ");	XYBody.Append(shopuserinfo.character.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("            </tr>\r\n");
	XYBody.Append("            <tr>\r\n");
	XYBody.Append("                <th class=\"line1\">\r\n");
	XYBody.Append("                    Ա��������</th>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    ");	XYBody.Append(shopuserinfo.employeetotal.ToString());	XYBody.Append("��</td>\r\n");
	XYBody.Append("                <th class=\"line1 colorFF7300\">\r\n");
	XYBody.Append("                    ��˾ע��أ�</th>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    ");	XYBody.Append(shopuserinfo.regarea.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("            </tr>\r\n");
	XYBody.Append("        </table>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("	</div>\r\n");
	XYBody.Append("</div>\r\n");
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
