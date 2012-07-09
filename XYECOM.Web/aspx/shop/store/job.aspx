<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.shop.job,XYECOM.Page" %>
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
	XYBody.Append("            <em id=\"clicknum\" style=\"display: none\"></em><em id=\"msy\" style=\"display: none\">\r\n");
	XYBody.Append("            </em><em id=\"clicknum1\" style=\"display: none\"></em><em id=\"messnum\" style=\"display: none\">\r\n");
	XYBody.Append("            </em>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <!--��˾����ְλ-->\r\n");
	XYBody.Append("        <div class=\"rcon\">\r\n");
	XYBody.Append("            <h2>\r\n");
	XYBody.Append("                ְλ����</h2>\r\n");
	XYBody.Append("            <table class=\"table_infos\">\r\n");
	XYBody.Append("                <tr>\r\n");
	XYBody.Append("                    <th class=\"line1\">\r\n");
	XYBody.Append("                        ְλ���ƣ�\r\n");
	XYBody.Append("                    </th>\r\n");
	XYBody.Append("                    <td>\r\n");
	XYBody.Append("                        ");	XYBody.Append(jobinfo.JobTitle.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                    </td>\r\n");
	XYBody.Append("                    <th class=\"line1\">\r\n");
	XYBody.Append("                        ��Ƹ������\r\n");
	XYBody.Append("                    </th>\r\n");
	XYBody.Append("                    <td>\r\n");
	XYBody.Append("                        ");	XYBody.Append(jobinfo.Number.ToString());	XYBody.Append(" ��\r\n");
	XYBody.Append("                    </td>\r\n");
	XYBody.Append("                </tr>\r\n");
	XYBody.Append("                <tr>\r\n");
	XYBody.Append("                    <th class=\"line1\">\r\n");
	XYBody.Append("                        �������ʣ�\r\n");
	XYBody.Append("                    </th>\r\n");
	XYBody.Append("                    <td>\r\n");
	XYBody.Append("                        ");	XYBody.Append(jobinfo.JobType.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                    </td>\r\n");
	XYBody.Append("                    <th class=\"line1\">\r\n");
	XYBody.Append("                        �Ա�Ҫ��\r\n");
	XYBody.Append("                    </th>\r\n");
	XYBody.Append("                    <td>\r\n");
	XYBody.Append("                        ");	XYBody.Append(jobinfo.Sex.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                    </td>\r\n");
	XYBody.Append("                </tr>\r\n");
	XYBody.Append("                <tr>\r\n");
	XYBody.Append("                    <th class=\"line1\">\r\n");
	XYBody.Append("                        ѧ��Ҫ��\r\n");
	XYBody.Append("                    </th>\r\n");
	XYBody.Append("                    <td>\r\n");
	XYBody.Append("                        ");	XYBody.Append(jobinfo.Education.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                    </td>\r\n");
	XYBody.Append("                    <th class=\"line1\">\r\n");
	XYBody.Append("                        ����Ҫ��\r\n");
	XYBody.Append("                    </th>\r\n");
	XYBody.Append("                    <td>\r\n");
	XYBody.Append("                        ");	XYBody.Append(jobinfo.Age.ToString());	XYBody.Append(" ��\r\n");
	XYBody.Append("                    </td>\r\n");
	XYBody.Append("                </tr>\r\n");
	XYBody.Append("                <tr>\r\n");
	XYBody.Append("                    <th class=\"line1\">\r\n");
	XYBody.Append("                        �������飺\r\n");
	XYBody.Append("                    </th>\r\n");
	XYBody.Append("                    <td>\r\n");
	XYBody.Append("                        ");	XYBody.Append(jobinfo.Experience.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                    </td>\r\n");
	XYBody.Append("                    <th class=\"line1\">\r\n");
	XYBody.Append("                        ������\r\n");
	XYBody.Append("                    </th>\r\n");
	XYBody.Append("                    <td>\r\n");
	XYBody.Append("                        ");	XYBody.Append(jobinfo.Pay.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                    </td>\r\n");
	XYBody.Append("                </tr>\r\n");
	XYBody.Append("                <tr>\r\n");
	XYBody.Append("                    <th class=\"line1\">\r\n");
	XYBody.Append("                        �����ص㣺\r\n");
	XYBody.Append("                    </th>\r\n");
	XYBody.Append("                    <td>\r\n");
	XYBody.Append("                        ");	XYBody.Append(jobinfo.WorkAreaInfo.FullName.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                    </td>\r\n");
	XYBody.Append("                    <th class=\"line1\">\r\n");
	XYBody.Append("                        ����ʱ�䣺\r\n");
	XYBody.Append("                    </th>\r\n");
	XYBody.Append("                    <td>\r\n");
	XYBody.Append("                        ");	XYBody.Append(jobinfo.EndDate.ToShortDateString().ToString());	XYBody.Append("\r\n");
	XYBody.Append("                    </td>\r\n");
	XYBody.Append("                </tr>\r\n");
	XYBody.Append("                <tr>\r\n");
	XYBody.Append("                    <th class=\"line1\">\r\n");
	XYBody.Append("                        ְλ˵����\r\n");
	XYBody.Append("                    </th>\r\n");
	XYBody.Append("                    <td class=\"w650\" colspan=\"3\">\r\n");
	XYBody.Append("                        ");	XYBody.Append(jobinfo.Request.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                    </td>\r\n");
	XYBody.Append("                </tr>\r\n");
	XYBody.Append("                <tr>\r\n");
	XYBody.Append("                    <th>\r\n");
	XYBody.Append("                    </th>\r\n");
	XYBody.Append("                    <td class=\"w650\" colspan=\"3\">\r\n");
	XYBody.Append("                        <a href=\"javascript:ApplyJob();\">�����ְλ</a>\r\n");
	XYBody.Append("                    </td>\r\n");
	XYBody.Append("                </tr>\r\n");
	XYBody.Append("            </table>\r\n");
	XYBody.Append("            <h4>\r\n");
	XYBody.Append("                ����ҵ����ְλ</h4>\r\n");
	XYBody.Append("            <div class=\"jobqt\">\r\n");
	 data = GetOtherJob();
	

	int job__loop__id=0;
	foreach(DataRow job in data.Rows)
	{
		job__loop__id++;

	 infourl = GetInfoUrl("job",job["EI_ID"],job["EI_HTMLPage"]);
	
	XYBody.Append("                <span><a href=\"");	XYBody.Append(infourl.ToString());	XYBody.Append("\">" + job["EI_Job"].ToString().Trim() + "</a></span>\r\n");

	}	//end loop

	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <!--��ϵ��ʽ-->\r\n");
	XYBody.Append("        <div class=\"rcon\">\r\n");
	XYBody.Append("            <h2>\r\n");
	XYBody.Append("                ��ϵ��ʽ</h2>\r\n");
	XYBody.Append("            <!--��ϵ��ʽ-->\r\n");
	XYBody.Append("            <div class=\"infoAbout\">\r\n");
	XYBody.Append("                <a name=\"link\"></a>\r\n");
	XYBody.Append("                <div id=\"linkmessage\">\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <!--�Ƽ�������-->\r\n");
	XYBody.Append("        <div class=\"rcon pb15\">\r\n");
	XYBody.Append("            <h2>\r\n");
	XYBody.Append("                �Ƽ�������</h2>\r\n");
	XYBody.Append("            <div class=\"commentList\">\r\n");
	XYBody.Append("                <ul>\r\n");
	XYBody.Append("                    <li>\r\n");
	XYBody.Append("                        <label>\r\n");
	XYBody.Append("                            ����������<em>*</em></label><input type=\"text\" size=\"30\" id=\"txtFromName\" maxlength=\"200\" /></li>\r\n");
	XYBody.Append("                    <li>\r\n");
	XYBody.Append("                        <label>\r\n");
	XYBody.Append("                            �������䣺<em>*</em></label><input type=\"text\" size=\"30\" id=\"txtFromEmail\" maxlength=\"200\" /></li>\r\n");
	XYBody.Append("                    <li>\r\n");
	XYBody.Append("                        <label>\r\n");
	XYBody.Append("                            ���������䣺<em>*</em></label><input type=\"text\" size=\"30\" id=\"txtToEmail\" maxlength=\"200\" /><i>\r\n");
	XYBody.Append("                                ���������\",\"����</i></li>\r\n");
	XYBody.Append("                    <li>\r\n");
	XYBody.Append("                        <input name=\"\" type=\"button\" class=\"button\" value=\"ȷ ��\" onclick=\"CommendJob();\" />\r\n");
	XYBody.Append("                        <input type=\"button\" name=\"Submit\" class=\"button\" value=\"�� ��\" onclick=\"emptycommend();\" /></li>\r\n");
	XYBody.Append("                </ul>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <input type=\"hidden\" id=\"JobId\" value=\"");	XYBody.Append(jobinfo.JobId.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("    <input type=\"hidden\" id=\"txtjobname\" value=\"");	XYBody.Append(jobinfo.JobTitle.ToString());	XYBody.Append("\" />\r\n");
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
