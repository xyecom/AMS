<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.post,XYECOM.Page" %>
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

	XYBody.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n");
	XYBody.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\" >\r\n");
	XYBody.Append("<head>\r\n");
	XYBody.Append("    <title>����¼����ҵ��Ϣ</title>\r\n");
	XYBody.Append("    <link href=\"/common/css/XYLib.css\" type=\"text/css\" rel=\"Stylesheet\" />\r\n");
	XYBody.Append("    <link href=\"/templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/css/global.css\" type=\"text/css\" rel=\"Stylesheet\" />\r\n");
	XYBody.Append("    <link href=\"/templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/css/post.css\" type=\"text/css\" rel=\"Stylesheet\" />\r\n");
	XYBody.Append("    <script language =\"javascript\" type =\"text/javascript\" src =\"/common/js/base.js\"></" + "script> \r\n");
	XYBody.Append("    <script language =\"javascript\" type=\"text/javascript\"  src=\"/common/js/UploadControl.js\"></" + "script>\r\n");
	XYBody.Append("    <script language =\"javascript\" type=\"text/javascript\"  src=\"/templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/js/post.js\"></" + "script>\r\n");
	XYBody.Append("    <script language =\"javascript\" type =\"text/javascript\" src =\"/templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/js/login.js\"></" + "script>\r\n");
	XYBody.Append("</head>\r\n");
	XYBody.Append("<body>\r\n");
	XYBody.Append("    <div class=\"head\">\r\n");
	XYBody.Append("        <div class=\"logo\"><a href=\"/\"><img src=\"");	XYBody.Append(config.weblogo);	XYBody.Append("\" alt=\"������ҳ\" border=\"0\" /></a></div>\r\n");
	XYBody.Append("        <div class=\"nav\"><a href=\"/\">��վ��ҳ</a>|");	XYBody.Append(pageinfo.LoginStatus);	XYBody.Append("</div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <form action=\"post_input.");	XYBody.Append(config.suffix);	XYBody.Append("\" method=\"post\" id=\"frmQuickPostInfo\">\r\n");
	XYBody.Append("    <div class=\"guest_post\">\r\n");
	XYBody.Append("        <!--��ģ����������0ʱ��ʾ-->\r\n");

	if (moduleItems.Count>0)
	{

	XYBody.Append("            <div class=\"step_title\">��һ��:��ѡ����Ϣ����</div>\r\n");
	XYBody.Append("                <div class=\"step_select\">\r\n");
	XYBody.Append("                    <p>��ѡ��Ҫ��������Ϣ���ͣ�</p>\r\n");
	XYBody.Append("                    <ul>\r\n");

	int item__loop__id=0;
	foreach(XYECOM.Configuration.ModuleInfo item in moduleItems)
	{
		item__loop__id++;

	XYBody.Append("                        <li>\r\n");

	if (item__loop__id==1)
	{

	XYBody.Append("                            <input type=\"radio\" id=\"rado");	XYBody.Append(item.EName.ToString());	XYBody.Append("\" name=\"module\" checked=\"checked\" value=\"");	XYBody.Append(item.EName.ToString());	XYBody.Append("\");\"><span>");	XYBody.Append(item.CName.ToString());	XYBody.Append("</span> ( ");	XYBody.Append(item.Description.ToString());	XYBody.Append(" )\r\n");

	}
	else
	{

	XYBody.Append("                            <input type=\"radio\" id=\"Radio1\" name=\"module\" value=\"");	XYBody.Append(item.EName.ToString());	XYBody.Append("\" ><span>");	XYBody.Append(item.CName.ToString());	XYBody.Append("</span>( ");	XYBody.Append(item.Description.ToString());	XYBody.Append(" )\r\n");

	}	//end if

	XYBody.Append("                        </li>\r\n");

	}	//end loop

	XYBody.Append("                </ul>\r\n");
	XYBody.Append("            </div>\r\n");

	}
	else
	{

	XYBody.Append("            <input type=\"hidden\" name=\"module\" value=\"");	XYBody.Append(moduleName.ToString());	XYBody.Append("\"/>\r\n");

	}	//end if


	if (null==userinfo)
	{

	XYBody.Append("        <div class=\"step_link\">�������û���Ϣ</div>\r\n");
	XYBody.Append("        <!--�ο���ϵ��Ϣ-->\r\n");
	XYBody.Append("        <table class=\"tab_step2\">\r\n");
	XYBody.Append("        <tr>\r\n");
	XYBody.Append("        <th>������ݣ�</th>\r\n");
	XYBody.Append("        <td>\r\n");
	XYBody.Append("            <input type=\"radio\" name=\"usertype\" value=\"guest\" checked=\"checked\" onclick=\"SelectUser('guest');\"/>�����ο�\r\n");
	XYBody.Append("            <input type=\"radio\" name=\"usertype\" value=\"user\"  onclick=\"SelectUser('user');\"/>���Ѿ���ע���Ա\r\n");
	XYBody.Append("        </td>\r\n");
	XYBody.Append("        </tr>\r\n");
	XYBody.Append("        </table>\r\n");
	XYBody.Append("        <!--��Ϣ��ʾ��-->\r\n");
	XYBody.Append("        <div id=\"step_msg\" class=\"step_msg\">\r\n");
	XYBody.Append("            ������������Ϣ����ɻ�Ա����ע��\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <!--��Ա��¼��-->\r\n");
	XYBody.Append("        <table class=\"tab_step2\" id=\"tab_user_info\" style=\"display:none;\">\r\n");
	XYBody.Append("            <tr>\r\n");
	XYBody.Append("                <th>�û�����<em>*</em></th>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    <input type=\"text\" name=\"username\" id=\"username\"  maxlength=\"25\" size=\"20\"/>  \r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("            </tr>\r\n");
	XYBody.Append("            <tr>\r\n");
	XYBody.Append("                <th>���룺<em>*</em></th>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    <input type=\"password\" name=\"userpwd\" id=\"userpwd\"  maxlength=\"25\" size=\"21\"/>\r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("            </tr>\r\n");
	XYBody.Append("         </table>\r\n");
	XYBody.Append("        <!--�ο�¼����Ϣ����-->\r\n");
	XYBody.Append("        <table class=\"tab_step2\" id=\"tab_guest_info\" style=\"display:;\">\r\n");
	XYBody.Append("            <tr>\r\n");
	XYBody.Append("                <th>�û�����<em>*</em></th>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    <input type=\"text\" name=\"guestusername\" maxlength=\"25\" size=\"20\" /><br/><em>4-15λ,ֻ������(0-9)��Ӣ��(a-z)</em>\r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("            </tr>\r\n");
	XYBody.Append("            <tr>\r\n");
	XYBody.Append("                <th>���룺<em>*</em></th>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    <input type=\"password\" name=\"guestuserpwd\" maxlength=\"25\" size=\"20\" /><br/><em>6-20λ���������û�����ͬ��ֻ��Ӣ����ĸ(a-z)������(0-9) </em>\r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("            </tr>\r\n");
	XYBody.Append("            <tr>\r\n");
	XYBody.Append("                <th>��ҵ���ƣ�<em>*</em></th>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    <input type=\"text\" name=\"unitname\" maxlength=\"100\" size=\"50\" />\r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("            </tr>    \r\n");
	XYBody.Append("            <tr>\r\n");
	XYBody.Append("                <th>��ϵ�ˣ�<em>*</em></th>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    <input type=\"text\" name=\"linkman\" maxlength=\"20\" size=\"10\" />\r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("            </tr>    \r\n");
	XYBody.Append("            <tr>\r\n");
	XYBody.Append("                <th>�̶��绰��<em>*</em></th>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    <input type=\"text\" name=\"telephone\" maxlength=\"100\" size=\"50\" /><br/><em>�������֮����,�Ÿ���;��ʽ��010-88888888</em>\r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("            </tr>\r\n");
	XYBody.Append("            <tr>\r\n");
	XYBody.Append("                <th>�ֻ���<em>*</em></th>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    <input type=\"text\" name=\"mobile\" maxlength=\"100\" size=\"50\" /><br/><em>�̶��绰���ֻ�������һ��</em>\r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("            </tr>\r\n");
	XYBody.Append("            <tr>\r\n");
	XYBody.Append("                <th>�������䣺<em>*</em></th>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    <input type=\"text\" name=\"email\" maxlength=\"50\" size=\"50\" />\r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("            </tr>\r\n");
	XYBody.Append("        </table>\r\n");

	if (config.IsEnabledVCode("quickpost"))
	{

	XYBody.Append("            <table class=\"tab_step2\">\r\n");
	XYBody.Append("            <tr>\r\n");
	XYBody.Append("                <th>��֤�룺<em>*</em></th>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    ");	XYBody.Append(pageinfo.GetValidateCodeHTML());	XYBody.Append("\r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("            </tr>\r\n");
	XYBody.Append("            </table>\r\n");

	}	//end if


	}	//end if

	XYBody.Append("	      <div class=\"step_next\"><input type=\"button\" value=\"��һ��\" id=\"btnStep1\" onclick=\"return UserInfoCheck();\"/></div>\r\n");
	XYBody.Append("     </div>\r\n");
	XYBody.Append("    </form>\r\n");
	XYBody.Append("    Copyright &copy; 2008 " +  XYECOMCreateHTML("XY_Copyright").ToString() + ".All right reserved. \r\n");
	XYBody.Append("</body>\r\n");
	XYBody.Append("</html>\r\n");

	XYBody.Append(IsCopyright());
	Response.Write(XYBody.ToString());
}
</script>
