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
	XYBody.Append("<title>消息提示</title>\r\n");
	XYBody.Append("");	XYBody.Append(pageinfo.Meta);	XYBody.Append("\r\n");
	XYBody.Append("<link rel=\"stylesheet\" href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/css/global.css\" type=\"text/css\" media=\"screen\" />\r\n");
	XYBody.Append("</head>\r\n");
	XYBody.Append("<body style=\"background-color:#f2f2f2\">\r\n");
	XYBody.Append("<div id=\"sysMsgbox\">\r\n");
	XYBody.Append("	<ul>\r\n");
	XYBody.Append("	    <li class=\"msg\">");	XYBody.Append(pageinfo.MsgboxText);	XYBody.Append("</li>\r\n");
	XYBody.Append("        <li><a href=\"");	XYBody.Append(pageinfo.MsgboxURL);	XYBody.Append("\">");	XYBody.Append(pageinfo.MsgboxURL);	XYBody.Append("</a></li>\r\n");
	XYBody.Append("         <li><a href=\"#\" onclick=\"history.back();\">返回继续操作</a></li>\r\n");
	XYBody.Append("        <li><a href=\"/\">返回首页</a> | <a href=\"#\" onclick=\"window.close();\">关闭本页</a></li>\r\n");
	XYBody.Append("    </ul>\r\n");
	XYBody.Append("    <div id=\"r_f\">2000-2009　" +  XYECOMCreateHTML("XY_Copyright").ToString() + "　版权所有　</div>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("</body>\r\n");
	XYBody.Append("</html>\r\n");



	Response.Write(XYBody.ToString());
System.Web.HttpContext.Current.Response.End();
	

	}	//end if

	XYBody.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n");
	XYBody.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\" >\r\n");
	XYBody.Append("<head>\r\n");
	XYBody.Append("    <title>快速录入商业信息</title>\r\n");
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
	XYBody.Append("        <div class=\"logo\"><a href=\"/\"><img src=\"");	XYBody.Append(config.weblogo);	XYBody.Append("\" alt=\"返回首页\" border=\"0\" /></a></div>\r\n");
	XYBody.Append("        <div class=\"nav\"><a href=\"/\">网站首页</a>|");	XYBody.Append(pageinfo.LoginStatus);	XYBody.Append("</div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <form action=\"post_input.");	XYBody.Append(config.suffix);	XYBody.Append("\" method=\"post\" id=\"frmQuickPostInfo\">\r\n");
	XYBody.Append("    <div class=\"guest_post\">\r\n");
	XYBody.Append("        <!--当模块数量大于0时显示-->\r\n");

	if (moduleItems.Count>0)
	{

	XYBody.Append("            <div class=\"step_title\">第一步:请选择信息类型</div>\r\n");
	XYBody.Append("                <div class=\"step_select\">\r\n");
	XYBody.Append("                    <p>请选择要发布的信息类型：</p>\r\n");
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

	XYBody.Append("        <div class=\"step_link\">请输入用户信息</div>\r\n");
	XYBody.Append("        <!--游客联系信息-->\r\n");
	XYBody.Append("        <table class=\"tab_step2\">\r\n");
	XYBody.Append("        <tr>\r\n");
	XYBody.Append("        <th>您的身份：</th>\r\n");
	XYBody.Append("        <td>\r\n");
	XYBody.Append("            <input type=\"radio\" name=\"usertype\" value=\"guest\" checked=\"checked\" onclick=\"SelectUser('guest');\"/>我是游客\r\n");
	XYBody.Append("            <input type=\"radio\" name=\"usertype\" value=\"user\"  onclick=\"SelectUser('user');\"/>我已经是注册会员\r\n");
	XYBody.Append("        </td>\r\n");
	XYBody.Append("        </tr>\r\n");
	XYBody.Append("        </table>\r\n");
	XYBody.Append("        <!--信息提示区-->\r\n");
	XYBody.Append("        <div id=\"step_msg\" class=\"step_msg\">\r\n");
	XYBody.Append("            请输入以下信息，完成会员快速注册\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <!--会员登录区-->\r\n");
	XYBody.Append("        <table class=\"tab_step2\" id=\"tab_user_info\" style=\"display:none;\">\r\n");
	XYBody.Append("            <tr>\r\n");
	XYBody.Append("                <th>用户名：<em>*</em></th>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    <input type=\"text\" name=\"username\" id=\"username\"  maxlength=\"25\" size=\"20\"/>  \r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("            </tr>\r\n");
	XYBody.Append("            <tr>\r\n");
	XYBody.Append("                <th>密码：<em>*</em></th>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    <input type=\"password\" name=\"userpwd\" id=\"userpwd\"  maxlength=\"25\" size=\"21\"/>\r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("            </tr>\r\n");
	XYBody.Append("         </table>\r\n");
	XYBody.Append("        <!--游客录入信息区域-->\r\n");
	XYBody.Append("        <table class=\"tab_step2\" id=\"tab_guest_info\" style=\"display:;\">\r\n");
	XYBody.Append("            <tr>\r\n");
	XYBody.Append("                <th>用户名：<em>*</em></th>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    <input type=\"text\" name=\"guestusername\" maxlength=\"25\" size=\"20\" /><br/><em>4-15位,只限数字(0-9)或英文(a-z)</em>\r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("            </tr>\r\n");
	XYBody.Append("            <tr>\r\n");
	XYBody.Append("                <th>密码：<em>*</em></th>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    <input type=\"password\" name=\"guestuserpwd\" maxlength=\"25\" size=\"20\" /><br/><em>6-20位，不能与用户名相同；只限英文字母(a-z)和数字(0-9) </em>\r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("            </tr>\r\n");
	XYBody.Append("            <tr>\r\n");
	XYBody.Append("                <th>企业名称：<em>*</em></th>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    <input type=\"text\" name=\"unitname\" maxlength=\"100\" size=\"50\" />\r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("            </tr>    \r\n");
	XYBody.Append("            <tr>\r\n");
	XYBody.Append("                <th>联系人：<em>*</em></th>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    <input type=\"text\" name=\"linkman\" maxlength=\"20\" size=\"10\" />\r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("            </tr>    \r\n");
	XYBody.Append("            <tr>\r\n");
	XYBody.Append("                <th>固定电话：<em>*</em></th>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    <input type=\"text\" name=\"telephone\" maxlength=\"100\" size=\"50\" /><br/><em>多个号码之间用,号隔开;格式：010-88888888</em>\r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("            </tr>\r\n");
	XYBody.Append("            <tr>\r\n");
	XYBody.Append("                <th>手机：<em>*</em></th>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    <input type=\"text\" name=\"mobile\" maxlength=\"100\" size=\"50\" /><br/><em>固定电话和手机至少填一项</em>\r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("            </tr>\r\n");
	XYBody.Append("            <tr>\r\n");
	XYBody.Append("                <th>电子邮箱：<em>*</em></th>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    <input type=\"text\" name=\"email\" maxlength=\"50\" size=\"50\" />\r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("            </tr>\r\n");
	XYBody.Append("        </table>\r\n");

	if (config.IsEnabledVCode("quickpost"))
	{

	XYBody.Append("            <table class=\"tab_step2\">\r\n");
	XYBody.Append("            <tr>\r\n");
	XYBody.Append("                <th>验证码：<em>*</em></th>\r\n");
	XYBody.Append("                <td>\r\n");
	XYBody.Append("                    ");	XYBody.Append(pageinfo.GetValidateCodeHTML());	XYBody.Append("\r\n");
	XYBody.Append("                </td>\r\n");
	XYBody.Append("            </tr>\r\n");
	XYBody.Append("            </table>\r\n");

	}	//end if


	}	//end if

	XYBody.Append("	      <div class=\"step_next\"><input type=\"button\" value=\"下一步\" id=\"btnStep1\" onclick=\"return UserInfoCheck();\"/></div>\r\n");
	XYBody.Append("     </div>\r\n");
	XYBody.Append("    </form>\r\n");
	XYBody.Append("    Copyright &copy; 2008 " +  XYECOMCreateHTML("XY_Copyright").ToString() + ".All right reserved. \r\n");
	XYBody.Append("</body>\r\n");
	XYBody.Append("</html>\r\n");

	XYBody.Append(IsCopyright());
	Response.Write(XYBody.ToString());
}
</script>
