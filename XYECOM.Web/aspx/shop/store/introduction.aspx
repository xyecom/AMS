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

	XYBody.Append("    <title>");	XYBody.Append(seo.Title);	XYBody.Append("</title>\r\n");
	XYBody.Append("	<meta name=\"description\" content=\"");	XYBody.Append(seo.Description);	XYBody.Append("\" />\r\n");
	XYBody.Append("	<meta name=\"keywords\" content=\"");	XYBody.Append(seo.Keywords);	XYBody.Append("\" />\r\n");
	XYBody.Append("	<meta name=\"robots\" content=\"all\"  />\r\n");
	XYBody.Append("	<meta http-equiv=\"Content-Type\" content=\"text/html;\" charset=\"gb2312\" />	\r\n");
	XYBody.Append("	<link rel=\"stylesheet\" href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("common/css/XYLib.css\" type=\"text/css\" media=\"screen\" />\r\n");
	XYBody.Append("	<link href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/css/global.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n");
	XYBody.Append("	<link href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/css/Survey.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n");
	XYBody.Append("	<script type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("common/js/base.js\" language=\"javascript\"></" + "script>\r\n");
	XYBody.Append("	<script type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/js/login.js\" language=\"javascript\"></" + "script>\r\n");
	XYBody.Append("    <script type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/js/validate.js\" language=\"javascript\"></" + "script>\r\n");
	XYBody.Append("<link href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/css/index.css\" rel=\"stylesheet\" type=\"text/css\" />	\r\n");


	XYBody.Append("<div id=\"ubox\">\r\n");
	XYBody.Append("    <!--��ߵ���-->\r\n");
	XYBody.Append("    <div id=\"uleftnav\">\r\n");



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
	XYBody.Append("        <div class=\"rcon\">\r\n");
	XYBody.Append("            <h2>\r\n");
	XYBody.Append("                ��˾����</h2>\r\n");
	XYBody.Append("            <p class=\"font142\">\r\n");

	if (shopuserinfo.imgurl!="")
	{

	XYBody.Append("<img alt=\"");	XYBody.Append(shopuserinfo.loginname.ToString());	XYBody.Append("\" src=\"");	XYBody.Append(shopuserinfo.imgurl.ToString());	XYBody.Append("\" />\r\n");

	}
	else
	{

	XYBody.Append("<img\r\n");
	XYBody.Append("                    alt=\"");	XYBody.Append(shopuserinfo.loginname.ToString());	XYBody.Append("\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/WelcomeInfro_32.gif\" />\r\n");

	}	//end if

	XYBody.Append("                ");	XYBody.Append(shopuserinfo.synopsis.ToString());	XYBody.Append("\r\n");
	XYBody.Append("            </p>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <div class=\"rcon\">\r\n");
	XYBody.Append("            <h2>\r\n");
	XYBody.Append("                ��ϸ��Ϣ</h2>\r\n");
	XYBody.Append("            <div class=\"rcont\">\r\n");
	XYBody.Append("                <table class=\"table_infos\">\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <th class=\"line1\">\r\n");
	XYBody.Append("                            ��˾���ƣ�\r\n");
	XYBody.Append("                        </th>\r\n");
	XYBody.Append("                        <td>\r\n");
	XYBody.Append("                            ");	XYBody.Append(shopuserinfo.unitname.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                        <th class=\"line1\">\r\n");
	XYBody.Append("                            ����ʱ�䣺\r\n");
	XYBody.Append("                        </th>\r\n");
	XYBody.Append("                        <td>\r\n");
	XYBody.Append("                            ");	XYBody.Append(shopuserinfo.regyear.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <th class=\"line1\">\r\n");
	XYBody.Append("                            ��Ӫģʽ��\r\n");
	XYBody.Append("                        </th>\r\n");
	XYBody.Append("                        <td>\r\n");
	XYBody.Append("                            ");	XYBody.Append(shopuserinfo.mode.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                        <th class=\"line1\">\r\n");
	XYBody.Append("                            ��Ӧ�Ĳ�Ʒ�ͷ���\r\n");
	XYBody.Append("                        </th>\r\n");
	XYBody.Append("                        <td>\r\n");
	XYBody.Append("                            ");	XYBody.Append(shopuserinfo.supplypro.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <th class=\"line1\">\r\n");
	XYBody.Append("                            ��˾��ҳ��\r\n");
	XYBody.Append("                        </th>\r\n");
	XYBody.Append("                        <td>\r\n");
	XYBody.Append("                            <a href=\"");	XYBody.Append(shopuserinfo.homepage.ToString());	XYBody.Append("\">");	XYBody.Append(shopuserinfo.homepage.ToString());	XYBody.Append("</a>\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                        <th class=\"line1\">\r\n");
	XYBody.Append("                            ע���ʱ���\r\n");
	XYBody.Append("                        </th>\r\n");
	XYBody.Append("                        <td>\r\n");
	XYBody.Append("                            ");	XYBody.Append(shopuserinfo.registeredcapital.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <th class=\"line1 colorFF7300\">\r\n");
	XYBody.Append("                            ��ҵ���ͣ�\r\n");
	XYBody.Append("                        </th>\r\n");
	XYBody.Append("                        <td>\r\n");
	XYBody.Append("                            ");	XYBody.Append(shopuserinfo.unittype.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                        <th class=\"line1 colorFF7300\">\r\n");
	XYBody.Append("                            ��˾���ʣ�\r\n");
	XYBody.Append("                        </th>\r\n");
	XYBody.Append("                        <td>\r\n");
	XYBody.Append("                            ");	XYBody.Append(shopuserinfo.character.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                    <tr>\r\n");
	XYBody.Append("                        <th class=\"line1\">\r\n");
	XYBody.Append("                            Ա��������\r\n");
	XYBody.Append("                        </th>\r\n");
	XYBody.Append("                        <td>\r\n");
	XYBody.Append("                            ");	XYBody.Append(shopuserinfo.employeetotal.ToString());	XYBody.Append("��\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                        <th class=\"line1 colorFF7300\">\r\n");
	XYBody.Append("                            ��˾ע��أ�\r\n");
	XYBody.Append("                        </th>\r\n");
	XYBody.Append("                        <td>\r\n");
	XYBody.Append("                            ");	XYBody.Append(shopuserinfo.regarea.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                        </td>\r\n");
	XYBody.Append("                    </tr>\r\n");
	XYBody.Append("                </table>\r\n");
	XYBody.Append("            </div>\r\n");
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
