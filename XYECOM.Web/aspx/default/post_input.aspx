<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.post_input,XYECOM.Page" %>
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
	XYBody.Append("<div class=\"head\">\r\n");
	XYBody.Append("    <div class=\"logo\"><a href=\"/\"><img src=\"");	XYBody.Append(config.weblogo);	XYBody.Append("\" alt=\"������ҳ\" border=\"0\" /></a></div>\r\n");
	XYBody.Append("    <div class=\"nav\"><a href=\"/\">��վ��ҳ</a>|");	XYBody.Append(pageinfo.LoginStatus);	XYBody.Append("</div>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<form action=\"post_result.");	XYBody.Append(config.suffix);	XYBody.Append("\" method=\"post\" id=\"frmQuickPostInfo\">\r\n");
	XYBody.Append("<div class=\"guest_post\">\r\n");
	XYBody.Append("    <div class=\"step_title\">�ڶ���:¼����ϸ��Ϣ</div>\r\n");
	XYBody.Append("    <div>\r\n");
	XYBody.Append("    <table  class=\"tab_step2\" onkeydown=\"if(event.keyCode == 13) $('btnNext').onclick();\">\r\n");
	XYBody.Append("    <tr>\r\n");
	XYBody.Append("        <th>��Ϣ���ͣ�<em>*</em></th>\r\n");
	XYBody.Append("        <td>\r\n");

	int item__loop__id=0;
	foreach(ModuleItemInfo item in module.Item)
	{
		item__loop__id++;


	if (item__loop__id==1)
	{

	 initvalue = item.Prefix;
	
	 infotypestr = item.InfoTypeStr;
	
	XYBody.Append("                <input type=\"radio\" name=\"items\" value=\"");	XYBody.Append(item.ID.ToString());	XYBody.Append("\"  checked =\"checked\" onclick=\"SetElementValue('infotitle,hidInfoType','");	XYBody.Append(item.Prefix.ToString());	XYBody.Append("');InitInfoAddPageForm('");	XYBody.Append(module.EName.ToString());	XYBody.Append("','");	XYBody.Append(module.PEName.ToString());	XYBody.Append("','");	XYBody.Append(item.InfoTypeStr.ToString());	XYBody.Append("');\"/>");	XYBody.Append(item.Prefix.ToString());	XYBody.Append("");	XYBody.Append(item.Postfix.ToString());	XYBody.Append("\r\n");

	}
	else
	{

	XYBody.Append("                <input type=\"radio\" name=\"items\" value=\"");	XYBody.Append(item.ID.ToString());	XYBody.Append("\" onclick=\"SetElementValue('infotitle,hidInfoType','");	XYBody.Append(item.Prefix.ToString());	XYBody.Append("');InitInfoAddPageForm('");	XYBody.Append(module.EName.ToString());	XYBody.Append("','");	XYBody.Append(module.PEName.ToString());	XYBody.Append("','");	XYBody.Append(item.InfoTypeStr.ToString());	XYBody.Append("');\"/>");	XYBody.Append(item.Prefix.ToString());	XYBody.Append("");	XYBody.Append(item.Postfix.ToString());	XYBody.Append("\r\n");

	}	//end if


	}	//end loop

	XYBody.Append("        </td>\r\n");
	XYBody.Append("      </tr>   \r\n");
	XYBody.Append("      <tr id=\"ptname\">\r\n");
	XYBody.Append("       <th>��Ϣ���ƣ�<em>*</em></th>\r\n");
	XYBody.Append("       <td  class=\"two\"><input id=\"infotitle\" name=\"infotitle\" type=\"text\" size=\"35\"  maxlength=\"40\" value=\"");	XYBody.Append(initvalue.ToString());	XYBody.Append("\"/>\r\n");
	XYBody.Append("       <em id=\"txt0\" class=\"three\">��Ϣ������������������ַ���</em>\r\n");
	XYBody.Append("       </td>\r\n");
	XYBody.Append("      </tr>\r\n");
	XYBody.Append("  <tr id=\"prodpt\">\r\n");
	XYBody.Append("  <input type=\"hidden\" name=\"hidInfoTypeStr\" id=\"hidInfoTypeStr\" value=\"");	XYBody.Append(infotypestr.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("  <input type=\"hidden\" name=\"hidInfoType\" id=\"hidInfoType\" value=\"");	XYBody.Append(initvalue.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("  <input type=\"hidden\" name=\"hidModuleName\" id=\"hidModuleName\" value=\"");	XYBody.Append(module.EName.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("  <input type=\"hidden\" name=\"hidTypeId\" id=\"hidTypeId\"  name=\"hidTypeId\"/>\r\n");
	XYBody.Append("   <th>ѡ����Ϣ���<em>*</em></th>\r\n");
	XYBody.Append("   <td>\r\n");
	XYBody.Append("   <div id=\"classType\"></div>\r\n");
	XYBody.Append("    <script type=\"text/javascript\">\r\n");
	XYBody.Append("    var cla = new ClassType(\"cla\",'hidModuleName','classType','hidTypeId');\r\n");
	XYBody.Append("    cla.Mode =\"select\";\r\n");
	XYBody.Append("    cla.OnChange = GetFieldInnerHTML;\r\n");
	XYBody.Append("    cla.Init();\r\n");
	XYBody.Append("    </" + "script>\r\n");
	XYBody.Append("   </td>\r\n");
	XYBody.Append("  </tr>\r\n");
	XYBody.Append("  <tr>\r\n");
	XYBody.Append("<th> ��Ϣ���ԣ�<em>*</em></th>\r\n");
	XYBody.Append("<td id=\"tabFieldBody\">\r\n");
	XYBody.Append("</td>\r\n");
	XYBody.Append("</tr>\r\n");
	XYBody.Append(" <tr>\r\n");
	XYBody.Append(" <th>��ϸ˵����<em>*</em></th>\r\n");
	XYBody.Append(" <td>\r\n");
	XYBody.Append("<script language =\"javascript\" type=\"text/javascript\"  src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("common/fckeditor/fckeditor.js\"></" + "script>\r\n");
	XYBody.Append("  <script language=\"javascript\" type=\"text/javascript\">\r\n");
	XYBody.Append("var oFCKeditor = new FCKeditor('xyecom') ;\r\n");
	XYBody.Append("oFCKeditor.BasePath = '/Common/fckeditor/' ;\r\n");
	XYBody.Append("oFCKeditor.ToolbarSet = 'Basic' ;\r\n");
	XYBody.Append("oFCKeditor.Width = '100%' ;\r\n");
	XYBody.Append("oFCKeditor.Height = '300' ;\r\n");
	XYBody.Append("oFCKeditor.Value = '' ;\r\n");
	XYBody.Append("oFCKeditor.Create() ;\r\n");
	XYBody.Append(" </" + "script>\r\n");
	XYBody.Append(" </td>\r\n");
	XYBody.Append(" </tr>\r\n");
	XYBody.Append("<tr>\r\n");
	XYBody.Append("<th>�ϴ�ͼƬ��</th>\r\n");
	XYBody.Append("<td >\r\n");

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


	XYBody.Append("</td>\r\n");
	XYBody.Append("</tr>\r\n");

	if (config.DateType==false)
	{

	XYBody.Append("<tr>\r\n");
	XYBody.Append("<th>��Ϣ��Ч�ڣ�<em class=\"red\">*</em></th>\r\n");
	XYBody.Append("<td > \r\n");
	XYBody.Append("<input onclick=\"getDateString(this);\" id=\"EndDate\" maxlength=\"15\" readonly=\"readonly\" name =\"EndDate\" readonly=\"readonly\"/>\r\n");
	XYBody.Append("</td>\r\n");
	XYBody.Append("</tr>\r\n");

	}
	else
	{

	XYBody.Append("<tr>\r\n");
	XYBody.Append("<th>��Ϣ��Ч�ڣ�<em class=\"red\">*</em></th>\r\n");
	XYBody.Append("<td ><input  type =\"radio\"  value =\"10\" name =\"rad\"/>10��\r\n");
	XYBody.Append("<input  type =\"radio\"   value =\"20\"  name =\"rad\"/>20��\r\n");
	XYBody.Append("<input  type =\"radio\"  value =\"30\"  name =\"rad\"/>1����\r\n");
	XYBody.Append("<input  type =\"radio\"  value =\"90\"  name =\"rad\"/>3����\r\n");
	XYBody.Append("<input  type =\"radio\"  value =\"180\"  name =\"rad\" checked =\"checked\"/>6����\r\n");
	XYBody.Append("<input id=\"Text1\"  readonly=\"readonly\" style=\"display:none;\" />\r\n");
	XYBody.Append("</td>\r\n");
	XYBody.Append("</tr>\r\n");

	}	//end if

	XYBody.Append("</table>\r\n");
	XYBody.Append("<input id=\"datetype\"  type=\"hidden\" value=\"");	XYBody.Append(config.DateType);	XYBody.Append("\" />\r\n");

	if (module.EName=="offer"||module.PEName=="offer")
	{

	XYBody.Append("<table class=\"tab_step2 mt8\">\r\n");
	XYBody.Append("<tr>\r\n");
	XYBody.Append("<th >���ۣ�</th>\r\n");
	XYBody.Append("<td><input maxlength=\"10\"  name =\"txtsprice\" id=\"txtsprice\" value=\"0\"/>Ԫ<em>ע����0λ���飬ֻ�������֣�</em></td>\r\n");
	XYBody.Append("</tr>\r\n");
	XYBody.Append("<tr>\r\n");
	XYBody.Append("<th >������λ��</th>\r\n");
	XYBody.Append("<td><input maxlength=\"10\"  name =\"txtsunit\"/></td>\r\n");
	XYBody.Append("</tr>\r\n");
	XYBody.Append("<tr>\r\n");
	XYBody.Append("<th >��С������</th>\r\n");
	XYBody.Append("<td><input maxlength=\"6\"  id =\"txtssmallnum\" name =\"txtssmallnum\" value=\"0\"/><em>ע����0Ϊ��������ֻ�������֣�</em></td>\r\n");
	XYBody.Append("</tr>\r\n");
	XYBody.Append("<tr>\r\n");
	XYBody.Append("<th >����������</th>\r\n");
	XYBody.Append("<td><input maxlength=\"6\"  id =\"txtscountnum\" name =\"txtscountnum\" value=\"0\"/><em>ע����0Ϊ��������ֻ�������֣�</em></td>\r\n");
	XYBody.Append("</tr>\r\n");

	if (ispayment==true)
	{

	XYBody.Append("<tr>\r\n");
	XYBody.Append("<th >�Ƿ�֧�����߽��ף�<em class=\"red\">*</em></th>\r\n");
	XYBody.Append("<td><input type=\"radio\" value=\"1\" name=\"rbIsPayMent\" />֧��<input type=\"radio\" value=\"0\" name=\"rbIsPayMent\" checked=\"checked\" />��֧��</td>\r\n");
	XYBody.Append("</tr>\r\n");

	}	//end if

	XYBody.Append("</table>\r\n");

	}	//end if


	if (module.EName=="venture"||module.PEName=="venture")
	{

	XYBody.Append("<table class=\"tab_step2 mt8\">\r\n");
	XYBody.Append("<tr>\r\n");
	XYBody.Append("<th >���ۣ�<em class=\"red\">*</em></th>\r\n");
	XYBody.Append("<td><input maxlength=\"10\" id=\"txtcprice\"  name =\"txtcprice\" value=\"0\"/>Ԫ<em>ע����0Ϊ���飬ֻ�������֣�</em></td>\r\n");
	XYBody.Append("</tr>\r\n");
	XYBody.Append("<tr>\r\n");
	XYBody.Append("<th >������λ��<em class=\"red\">*</em></th>\r\n");
	XYBody.Append("<td><input maxlength=\"10\"  name =\"txtcunit\"/></td>\r\n");
	XYBody.Append("</tr>\r\n");
	XYBody.Append("<tr>\r\n");
	XYBody.Append("<th >��С������<em class=\"red\">*</em></th>\r\n");
	XYBody.Append("<td><input maxlength=\"6\"  name =\"txtcsmallnum\" value=\"0\"/><em>ע����0Ϊ��������ֻ�������֣�</em></td>\r\n");
	XYBody.Append("</tr>\r\n");
	XYBody.Append("<tr>\r\n");
	XYBody.Append("<th >����������<em class=\"red\">*</em></th>\r\n");
	XYBody.Append("<td><input maxlength=\"6\"  name =\"txtccountnum\" value=\"0\"/><em>ע����0Ϊ��������ֻ�������֣�</em></td>\r\n");
	XYBody.Append("</tr>\r\n");
	XYBody.Append("</table>\r\n");

	}	//end if


	if (module.EName=="investment"||module.PEName=="investment")
	{

	XYBody.Append("<table class=\"tab_step2 mt8\" >\r\n");
	XYBody.Append("<tr>\r\n");
	XYBody.Append("<th>׼������(����)�ĵ�����</th>\r\n");
	XYBody.Append("<td>\r\n");
	XYBody.Append("    <input type=\"radio\"  id=\"citys\" name =\"citys\" onclick =\"showcityname(1);\" checked value =\"ȫ��\"/>ȫ��\r\n");
	XYBody.Append("    <input type=\"radio\" id=\"cityl\"  name=\"cityl\"  onclick =\"showcityname(2);\" value=\"\"/> ����</td>\r\n");
	XYBody.Append(" </tr>\r\n");
	XYBody.Append("<tr style =\"display :none\" id=\"cityls\">\r\n");
	XYBody.Append("    <td></td>\r\n");
	XYBody.Append("      <td id=\"divarea\">\r\n");
	XYBody.Append("     <input type =\"hidden\" id=\"city\"  name=\"city\"/>\r\n");
	XYBody.Append("     </td>\r\n");
	XYBody.Append("</tr>\r\n");
	XYBody.Append("</table>\r\n");
	XYBody.Append("<script type=\"text/javascript\">\r\n");
	XYBody.Append("var claarea = new ClassTypes(\"claarea\",'area','divarea','city');\r\n");
	XYBody.Append("claarea.Init();\r\n");
	XYBody.Append("</" + "script>\r\n");
	XYBody.Append("<table class=\"tab_step2\" id=\"tabInvestmentSell\" style=\"display:none; border-top:0px;\">\r\n");
	XYBody.Append("<tr>\r\n");
	XYBody.Append("<th >����֧�֣�</th>\r\n");
	XYBody.Append("<td>\r\n");
	XYBody.Append("    <textarea id=\"txtsupport\" name =\"txtsupport\" cols=\"80\" rows=\"7\"></textarea></td>\r\n");
	XYBody.Append("</tr>\r\n");
	XYBody.Append("<tr>\r\n");
	XYBody.Append("<th >����Ҫ��</th>\r\n");
	XYBody.Append("<td> <textarea id=\"txtdemand\" name =\"txtdemand\" cols=\"80\" rows=\"7\"></textarea></td>\r\n");
	XYBody.Append("</tr>\r\n");
	XYBody.Append("<tr>\r\n");
	XYBody.Append("<th >չʾ��ַ��</th>\r\n");
	XYBody.Append("<td><input maxlength=\"95\"  name =\"pageurl\" id=\"pageurl\"/></td>\r\n");
	XYBody.Append("</tr>\r\n");
	XYBody.Append("</table>\r\n");
	XYBody.Append("<table class=\"tab_step2\" id=\"tabInvestmentBuy\" style=\"display:none;border-top:0px;\">\r\n");
	XYBody.Append("<tr>\r\n");
	XYBody.Append("<th >�������Ʒ�ƣ�</th>\r\n");
	XYBody.Append("<td><input type=\"text\"  name =\"txtbrand\" style=\"width: 255px\" id=\"txtbrand\"/></td>\r\n");
	XYBody.Append("</tr>\r\n");
	XYBody.Append("</table>\r\n");

	}	//end if

	XYBody.Append(" <!--����Ҫ������ɾ��-->\r\n");
	XYBody.Append(" <script language=\"javascript\" type=\"text/javascript\">\r\n");
	XYBody.Append("    InitInfoAddPageForm('");	XYBody.Append(module.EName.ToString());	XYBody.Append("','");	XYBody.Append(module.PEName.ToString());	XYBody.Append("','");	XYBody.Append(infotypestr.ToString());	XYBody.Append("');\r\n");
	XYBody.Append(" </" + "script>\r\n");

	if (config.IsEnabledVCode("quickpost"))
	{

	XYBody.Append("<table class=\"tab_step2\">\r\n");
	XYBody.Append("<tr>\r\n");
	XYBody.Append("    <th>��֤�룺<em>*</em></th>\r\n");
	XYBody.Append("    <td>\r\n");
	XYBody.Append("        ");	XYBody.Append(pageinfo.GetValidateCodeHTML());	XYBody.Append("\r\n");
	XYBody.Append("    </td>\r\n");
	XYBody.Append("</tr>\r\n");
	XYBody.Append("</table>\r\n");

	}	//end if

	XYBody.Append("    </div>    \r\n");
	XYBody.Append("    <div class=\"step_next\">\r\n");
	XYBody.Append("    <input type=\"button\" value=\"�ύ��Ϣ\" id=\"btnStep2\" onclick =\"return CheckInfoEditFrom('");	XYBody.Append(module.EName.ToString());	XYBody.Append("','");	XYBody.Append(module.PEName.ToString());	XYBody.Append("');\"/>\r\n");
	XYBody.Append("    <input type=\"button\" value=\"����\" id=\"btnBack\" onclick=\"history.back();\" />\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("</form>\r\n");
	XYBody.Append("Copyright &copy; 2008 " +  XYECOMCreateHTML("XY_Copyright").ToString() + ".All right reserved. \r\n");
	XYBody.Append("</body>\r\n");
	XYBody.Append("</html>\r\n");

	XYBody.Append(IsCopyright());
	Response.Write(XYBody.ToString());
}
</script>
