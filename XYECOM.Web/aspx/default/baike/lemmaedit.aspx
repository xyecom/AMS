<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.baike.lemmaedit,XYECOM.Page" %>
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
	XYBody.Append("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01 Transitional//EN\" \"http://www.w3.org/TR/html4/loose.dtd\">\r\n");
	XYBody.Append("<html>\r\n");
	XYBody.Append("<head>\r\n");


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

	XYBody.Append("<title>");	XYBody.Append(seo.Title);	XYBody.Append("</title>\r\n");
	XYBody.Append("<meta name=\"description\" content=\"");	XYBody.Append(seo.Description);	XYBody.Append("\" />\r\n");
	XYBody.Append("<meta name=\"keywords\" content=\"");	XYBody.Append(seo.Keywords);	XYBody.Append("\" />\r\n");
	XYBody.Append("<meta name=\"robots\" content=\"all\" />\r\n");
	XYBody.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=gb2312\" />\r\n");
	XYBody.Append("<link rel=\"stylesheet\" href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("common/css/XYLib.css\" type=\"text/css\"\r\n");
	XYBody.Append("    media=\"screen\" />\r\n");
	XYBody.Append("<link href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/css/global.css\" rel=\"stylesheet\"\r\n");
	XYBody.Append("    type=\"text/css\" />\r\n");
	XYBody.Append("<link href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/css/baike.css\" rel=\"stylesheet\"\r\n");
	XYBody.Append("    type=\"text/css\" />\r\n");
	XYBody.Append("<script type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("common/js/base.js\" language=\"javascript\"></" + "script>\r\n");
	XYBody.Append("<script type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/js/login.js\"\r\n");
	XYBody.Append("    language=\"javascript\"></" + "script>\r\n");
	XYBody.Append("<script type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/js/validate.js\"\r\n");
	XYBody.Append("    language=\"javascript\"></" + "script>\r\n");
	XYBody.Append("<script language=\"javascript\" type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("common/js/UploadControl.js\"></" + "script>\r\n");


	XYBody.Append("</head>\r\n");
	XYBody.Append("<body>\r\n");
	XYBody.Append("    <!--��¼��-->\r\n");

	XYBody.Append("<div id=\"hd_info\">\r\n");
	XYBody.Append("    <div id=\"cnts\">\r\n");
	XYBody.Append("        <div id=\"site_cang\">\r\n");
	XYBody.Append("            <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/ico_idx.gif\" width=\"16\"\r\n");
	XYBody.Append("                height=\"16\" alt=\"\" align=\"absmiddle\" />\r\n");
	XYBody.Append("            <a href=\"#\" onclick=\"this.style.behavior='url(#default#homepage)';this.setHomePage('");	XYBody.Append(config.WebURL);	XYBody.Append("');\">\r\n");
	XYBody.Append("                ��Ϊ��ҳ</a>&nbsp;&nbsp;\r\n");
	XYBody.Append("            <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/ico_cang.gif\" width=\"16\"\r\n");
	XYBody.Append("                height=\"16\" alt=\"\" align=\"absmiddle\" />\r\n");
	XYBody.Append("            <a style=\"cursor: hand\" onclick=\"window.external.addFavorite('");	XYBody.Append(config.WebURL);	XYBody.Append("','�ݺ��������')\">\r\n");
	XYBody.Append("                ��Ϊ�ղ�</a>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <div id=\"log_info\">\r\n");
	XYBody.Append("            <div id=\"login\">\r\n");
	XYBody.Append("                �û�����<input type=\"text\" class=\"com\" name=\"top_username\" id=\"top_username\" onkeydown=\"_xy_KeyNext('top_password');\" />\r\n");
	XYBody.Append("                ���룺<input type=\"password\" name=\"top_password\" class=\"com\" id=\"top_password\" onkeydown=\"_xy_KeyPress('_btnTopLogin');\" />\r\n");

	if (config.IsEnabledVCode("login"))
	{

	XYBody.Append("                ��֤�룺 ");	XYBody.Append(pageinfo.GetValidateCodeHTML("top_vcode","top_vimg"));	XYBody.Append("\r\n");

	}	//end if

	XYBody.Append("                <input id=\"_btnTopLogin\" type=\"button\" class=\"top_login\" onclick=\"return xy_TopLogin();\" />\r\n");
	XYBody.Append("                &nbsp;&nbsp;<a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("register.");	XYBody.Append(config.Suffix);	XYBody.Append("\">ע��</a> | <a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("getPassword.");	XYBody.Append(config.Suffix);	XYBody.Append("\">\r\n");
	XYBody.Append("                    ��������</a> | <a href=\"##\">[VIP��Ա]</a> | <a href=\"##\">��������</a>| <a style=\"color:Red\" href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("quickbuy.");	XYBody.Append(config.Suffix);	XYBody.Append("\">���ٷ�����</a>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <span id=\"logined\" style=\"display: none;\">��ӭ����<font id=\"uname\"></font> | <a id=\"ucenter\">\r\n");
	XYBody.Append("            �ҵ��û�����</a>| <a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("logout.");	XYBody.Append(config.suffix);	XYBody.Append("\">[�˳�]</a> <font id=\"logined_user\"\r\n");
	XYBody.Append("                style=\"display: none;\">��ҵ�û��������</font> <font id=\"logined_person\" style=\"display: none;\">\r\n");
	XYBody.Append("                    �����û��������</font> </span>\r\n");
	XYBody.Append("        <div class=\"clr\">\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<div class=\"clr\">\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<script>    Login2();</" + "script>\r\n");


	XYBody.Append("    <!--���ݿ�ʼ-->\r\n");
	XYBody.Append("    <div id=\"index\">\r\n");
	XYBody.Append("        <!--ͷ��-->\r\n");
	XYBody.Append("        <div id=\"reg_nav\">\r\n");
	XYBody.Append("            <strong>�����ڵ�λ�ã�</strong> <a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("\" class=\"blue\">��վ��ҳ</a> &raquo;<a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("baike/index.");	XYBody.Append(config.Suffix);	XYBody.Append("\" class=\"blue\">��վ�ٿ�</a> &raquo;<a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("baike/list.");	XYBody.Append(config.Suffix);	XYBody.Append("\">�ٿ��б�</a> &raquo;<a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("baike/view.");	XYBody.Append(config.Suffix);	XYBody.Append("?lid=");	XYBody.Append(info.LemmaId.ToString());	XYBody.Append("\">����</a>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("            <form action=\"\" method=\"post\" id=\"frmlemma\">\r\n");
	XYBody.Append("			<div class=\"table_left\">\r\n");
	XYBody.Append("            <table width=\"290\" align=\"center\" cellpadding=\"6\" cellspacing=\"5\">\r\n");
	XYBody.Append("                <tr>\r\n");
	XYBody.Append("                    <td width=\"293\" valign=\"top\">\r\n");
	XYBody.Append("					 ��������<span class=\"red\">*</span></br>\r\n");
	XYBody.Append("                        <input class=\"input_1\" name=\"lemmaname\" readonly=\"readonly\" type=\"text\" size=\"31\" id=\"lemmaname\" maxlength=\"20\" class=\"regOutInput\" value=\"");	XYBody.Append(info.LemmaName.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("                    </td>\r\n");
	XYBody.Append("                </tr>\r\n");
	XYBody.Append("				  <tr>\r\n");
	XYBody.Append("                    <td width=\"293\" valign=\"top\">\r\n");
	XYBody.Append("					Ӣ�ķ���</br>\r\n");
	XYBody.Append("                        <input class=\"input_1\" name=\"enname\" type=\"text\" size=\"31\" maxlength=\"20\" class=\"regOutInput\" value=\"");	XYBody.Append(info.EnName.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("                    </td>\r\n");
	XYBody.Append("                </tr>\r\n");
	XYBody.Append("                <tr>\r\n");
	XYBody.Append("                    <td width=\"293\" valign=\"top\">\r\n");
	XYBody.Append("				  ��������<span class=\"red\">*</span></br>\r\n");
	XYBody.Append("                        <div id=\"divtitle\">\r\n");
	XYBody.Append("                        </div>\r\n");
	XYBody.Append("                        <input id=\"typeId\" name=\"typeIds\" type=\"text\" style=\"display: none\" value=\"");	XYBody.Append(XYECOM.Core.Utils.RemoveComma(info.LemmaCategory).ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("                        <script type=\"text/javascript\">\r\n");
	XYBody.Append("                            var cla = new ClassTypes(\"cla\",'baike','divtitle','typeId');\r\n");
	XYBody.Append("                            cla.Init();\r\n");
	XYBody.Append("                        </" + "script>\r\n");
	XYBody.Append("                    </td>\r\n");
	XYBody.Append("                </tr>\r\n");
	XYBody.Append("                <tr>  \r\n");
	XYBody.Append("                    <td width=\"293\" valign=\"top\">\r\n");
	XYBody.Append("			          ͬ���</br>\r\n");
	XYBody.Append("                        <input class=\"input_1\" name=\"synonyms\" type=\"text\" size=\"31\" id=\"txt1\" maxlength=\"20\" class=\"regOutInput\"\r\n");
	XYBody.Append("                            value=\"");	XYBody.Append(info.Synonyms.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("                    </td>\r\n");
	XYBody.Append("                </tr>\r\n");
	XYBody.Append("                <!--<tr>\r\n");
	XYBody.Append("                    <td align=\"right\" valign=\"top\" style=\"padding-top: 12px;\">\r\n");
	XYBody.Append("                        <strong class=\"Font14_1\">����</strong> <span class=\"red\">*</span>\r\n");
	XYBody.Append("                    </td>\r\n");
	XYBody.Append("                    <td valign=\"top\">\r\n");
	XYBody.Append("                        <textarea id=\"_content_body\" style=\"display: none;\" cols=\"0\" rows=\"0\">");	XYBody.Append(info.Content.ToString());	XYBody.Append("</textarea>\r\n");
	XYBody.Append("                        <script language=\"javascript\" type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("common/fckeditor/fckeditor.js\"></" + "script>\r\n");
	XYBody.Append("                        <script language=\"javascript\" type=\"text/javascript\">\r\n");
	XYBody.Append("                            var oFCKeditor = new FCKeditor('xyecom') ;\r\n");
	XYBody.Append("                            oFCKeditor.BasePath = '/Common/fckeditor/' ;\r\n");
	XYBody.Append("                            oFCKeditor.ToolbarSet = 'BaiKe';\r\n");
	XYBody.Append("                            oFCKeditor.Width = '100%' ;\r\n");
	XYBody.Append("                            oFCKeditor.Height = '400' ;\r\n");
	XYBody.Append("                            oFCKeditor.Value = document.getElementById(\"_content_body\").value;\r\n");
	XYBody.Append("                            oFCKeditor.Create() ;\r\n");
	XYBody.Append("                        </" + "script>\r\n");
	XYBody.Append("                    </td>\r\n");
	XYBody.Append("                </tr>-->\r\n");
	XYBody.Append("                <!--<tr>\r\n");
	XYBody.Append("                    <td align=\"right\">\r\n");
	XYBody.Append("                        <strong class=\"Font14_1\">�ϴ�ͼƬ</strong> <span class=\"red\">*</span>\r\n");
	XYBody.Append("                    </td>\r\n");
	XYBody.Append("                    <td>\r\n");

	XYBody.Append(" <div id=\"UploadFile\">\r\n");
	XYBody.Append("    <input id=\"Upload_TabName\" name=\"Upload_TabName\" type=\"hidden\" value=\"");	XYBody.Append(tablename.ToString());	XYBody.Append("\"/>\r\n");
	XYBody.Append("    <input id=\"Upload_IDs\" name=\"Upload_IDs\" type=\"hidden\" value=\"");	XYBody.Append(ids.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("    <input id=\"Upload_Files\" name=\"Upload_Files\" type=\"hidden\" value=\"");	XYBody.Append(files.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("    <input id=\"Upload_DelIDs\" name=\"Upload_DelIDs\" type=\"hidden\" />\r\n");
	XYBody.Append("    <input id=\"Upload_UpIDs\" name=\"Upload_UpIDs\" type=\"hidden\" />\r\n");
	XYBody.Append("    <input id=\"Upload_MaxAmount\" name=\"Upload_MaxAmount\" type=\"hidden\" value=\"");	XYBody.Append(maxamount.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("    <input id=\"Upload_IsWaterMark\" name=\"Upload_IsWaterMark\" type=\"hidden\" value=\"");	XYBody.Append(iswatermark.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("    <script language=\"javascript\" type=\"text/javascript\">UploadInit();</" + "script>\r\n");
	XYBody.Append("</div>\r\n");


	XYBody.Append("                </tr>-->\r\n");
	XYBody.Append("                <tr>  \r\n");
	XYBody.Append("                    <td>\r\n");
	XYBody.Append("					�ο�����</br>\r\n");
	XYBody.Append("                        <textarea name=\"reference\" rows=\"6\" cols=\"50\" class=\"regOutInput\">");	XYBody.Append(info.Reference.ToString());	XYBody.Append("</textarea>\r\n");
	XYBody.Append("                    </td>\r\n");
	XYBody.Append("                </tr>\r\n");
	XYBody.Append("                <tr>\r\n");
	XYBody.Append("                    <td>\r\n");
	XYBody.Append("                       ��չ�Ķ�</br>\r\n");
	XYBody.Append("                        <textarea name=\"extendread\" rows=\"6\" cols=\"50\" class=\"regOutInput\">");	XYBody.Append(info.ExtendRead.ToString());	XYBody.Append("</textarea>\r\n");
	XYBody.Append("                    </td>\r\n");
	XYBody.Append("                </tr>\r\n");
	XYBody.Append("                <tr>\r\n");
	XYBody.Append("                    <td>\r\n");
	XYBody.Append("                        �޸�ԭ��</br>\r\n");
	XYBody.Append("                        <textarea name=\"modifyReason\" id=\"modifyReason\" rows=\"4\" cols=\"50\" class=\"regOutInput\"></textarea>\r\n");
	XYBody.Append("                    </td>\r\n");
	XYBody.Append("                </tr>\r\n");
	XYBody.Append("				<tr>\r\n");
	XYBody.Append("				<td>\r\n");
	XYBody.Append("				<input class=\"tijiao\" name=\"\" type=\"button\" value=\" �ύ \" id=\"btnBasicSubmit\" onclick=\"return lemmaedit() ;\" />&nbsp;&nbsp;\r\n");
	XYBody.Append("               <input class=\"quxiao\" name=\"\" type=\"reset\" value=\" ȡ�� \" id=\"Reset4\" onclick=\"window.location.href='");	XYBody.Append(config.WebURL);	XYBody.Append("index.");	XYBody.Append(config.Suffix);	XYBody.Append("'\" />\r\n");
	XYBody.Append("				</td>\r\n");
	XYBody.Append("				</tr>\r\n");
	XYBody.Append("            </table>\r\n");
	XYBody.Append("			</div>\r\n");
	XYBody.Append("			<div style=\"float:left\">\r\n");
	XYBody.Append("			<table width=\"1020\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\">\r\n");
	XYBody.Append("			<tr>\r\n");
	XYBody.Append("			<textarea id=\"_content_body\" style=\"display: none;\" cols=\"0\" rows=\"0\">");	XYBody.Append(info.Content.ToString());	XYBody.Append("</textarea>\r\n");
	XYBody.Append("                        <script language=\"javascript\" type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("common/fckeditor/fckeditor.js\"></" + "script>\r\n");
	XYBody.Append("                        <script language=\"javascript\" type=\"text/javascript\">\r\n");
	XYBody.Append("                            var oFCKeditor = new FCKeditor('xyecom') ;\r\n");
	XYBody.Append("                            oFCKeditor.BasePath = '/Common/fckeditor/' ;\r\n");
	XYBody.Append("                            oFCKeditor.ToolbarSet = 'BaiKe';\r\n");
	XYBody.Append("                            oFCKeditor.Width = '100%' ;\r\n");
	XYBody.Append("                            oFCKeditor.Height = '625' ;\r\n");
	XYBody.Append("                            oFCKeditor.Value = document.getElementById(\"_content_body\").value;\r\n");
	XYBody.Append("                            oFCKeditor.Create() ;\r\n");
	XYBody.Append("                        </" + "script>\r\n");
	XYBody.Append("			</tr>\r\n");
	XYBody.Append("		</table>\r\n");
	XYBody.Append("	    </div>\r\n");
	XYBody.Append("            </form>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("</body>\r\n");
	XYBody.Append("</html>\r\n");

	XYBody.Append(IsCopyright());
	Response.Write(XYBody.ToString());
}
</script>
