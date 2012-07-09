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
	XYBody.Append("    <div id=\"r_f\">2000-2009　" +  XYECOMCreateHTML("XY_Copyright").ToString() + "　版权所有　纵横易商软件</div>\r\n");
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
	XYBody.Append("<div class=\"head\">\r\n");
	XYBody.Append("    <div class=\"logo\"><a href=\"/\"><img src=\"");	XYBody.Append(config.weblogo);	XYBody.Append("\" alt=\"返回首页\" border=\"0\" /></a></div>\r\n");
	XYBody.Append("    <div class=\"nav\"><a href=\"/\">网站首页</a>|");	XYBody.Append(pageinfo.LoginStatus);	XYBody.Append("</div>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<form action=\"post_result.");	XYBody.Append(config.suffix);	XYBody.Append("\" method=\"post\" id=\"frmQuickPostInfo\">\r\n");
	XYBody.Append("<div class=\"guest_post\">\r\n");
	XYBody.Append("    <div class=\"step_title\">第二步:录入详细信息</div>\r\n");
	XYBody.Append("    <div>\r\n");
	XYBody.Append("    <table  class=\"tab_step2\" onkeydown=\"if(event.keyCode == 13) $('btnNext').onclick();\">\r\n");
	XYBody.Append("    <tr>\r\n");
	XYBody.Append("        <th>信息类型：<em>*</em></th>\r\n");
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
	XYBody.Append("       <th>信息名称：<em>*</em></th>\r\n");
	XYBody.Append("       <td  class=\"two\"><input id=\"infotitle\" name=\"infotitle\" type=\"text\" size=\"35\"  maxlength=\"40\" value=\"");	XYBody.Append(initvalue.ToString());	XYBody.Append("\"/>\r\n");
	XYBody.Append("       <em id=\"txt0\" class=\"three\">信息标题中请勿出现特殊字符。</em>\r\n");
	XYBody.Append("       </td>\r\n");
	XYBody.Append("      </tr>\r\n");
	XYBody.Append("  <tr id=\"prodpt\">\r\n");
	XYBody.Append("  <input type=\"hidden\" name=\"hidInfoTypeStr\" id=\"hidInfoTypeStr\" value=\"");	XYBody.Append(infotypestr.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("  <input type=\"hidden\" name=\"hidInfoType\" id=\"hidInfoType\" value=\"");	XYBody.Append(initvalue.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("  <input type=\"hidden\" name=\"hidModuleName\" id=\"hidModuleName\" value=\"");	XYBody.Append(module.EName.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("  <input type=\"hidden\" name=\"hidTypeId\" id=\"hidTypeId\"  name=\"hidTypeId\"/>\r\n");
	XYBody.Append("   <th>选择信息类别：<em>*</em></th>\r\n");
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
	XYBody.Append("<th> 信息属性：<em>*</em></th>\r\n");
	XYBody.Append("<td id=\"tabFieldBody\">\r\n");
	XYBody.Append("</td>\r\n");
	XYBody.Append("</tr>\r\n");
	XYBody.Append(" <tr>\r\n");
	XYBody.Append(" <th>详细说明：<em>*</em></th>\r\n");
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
	XYBody.Append("<th>上传图片：</th>\r\n");
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
	XYBody.Append("<th>信息有效期：<em class=\"red\">*</em></th>\r\n");
	XYBody.Append("<td > \r\n");
	XYBody.Append("<input onclick=\"getDateString(this);\" id=\"EndDate\" maxlength=\"15\" readonly=\"readonly\" name =\"EndDate\" readonly=\"readonly\"/>\r\n");
	XYBody.Append("</td>\r\n");
	XYBody.Append("</tr>\r\n");

	}
	else
	{

	XYBody.Append("<tr>\r\n");
	XYBody.Append("<th>信息有效期：<em class=\"red\">*</em></th>\r\n");
	XYBody.Append("<td ><input  type =\"radio\"  value =\"10\" name =\"rad\"/>10天\r\n");
	XYBody.Append("<input  type =\"radio\"   value =\"20\"  name =\"rad\"/>20天\r\n");
	XYBody.Append("<input  type =\"radio\"  value =\"30\"  name =\"rad\"/>1个月\r\n");
	XYBody.Append("<input  type =\"radio\"  value =\"90\"  name =\"rad\"/>3个月\r\n");
	XYBody.Append("<input  type =\"radio\"  value =\"180\"  name =\"rad\" checked =\"checked\"/>6个月\r\n");
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
	XYBody.Append("<th >单价：</th>\r\n");
	XYBody.Append("<td><input maxlength=\"10\"  name =\"txtsprice\" id=\"txtsprice\" value=\"0\"/>元<em>注：（0位面议，只能填数字）</em></td>\r\n");
	XYBody.Append("</tr>\r\n");
	XYBody.Append("<tr>\r\n");
	XYBody.Append("<th >计量单位：</th>\r\n");
	XYBody.Append("<td><input maxlength=\"10\"  name =\"txtsunit\"/></td>\r\n");
	XYBody.Append("</tr>\r\n");
	XYBody.Append("<tr>\r\n");
	XYBody.Append("<th >最小起定量：</th>\r\n");
	XYBody.Append("<td><input maxlength=\"6\"  id =\"txtssmallnum\" name =\"txtssmallnum\" value=\"0\"/><em>注：（0为无限量，只能填数字）</em></td>\r\n");
	XYBody.Append("</tr>\r\n");
	XYBody.Append("<tr>\r\n");
	XYBody.Append("<th >货物总量：</th>\r\n");
	XYBody.Append("<td><input maxlength=\"6\"  id =\"txtscountnum\" name =\"txtscountnum\" value=\"0\"/><em>注：（0为无限量，只能填数字）</em></td>\r\n");
	XYBody.Append("</tr>\r\n");

	if (ispayment==true)
	{

	XYBody.Append("<tr>\r\n");
	XYBody.Append("<th >是否支持在线交易：<em class=\"red\">*</em></th>\r\n");
	XYBody.Append("<td><input type=\"radio\" value=\"1\" name=\"rbIsPayMent\" />支持<input type=\"radio\" value=\"0\" name=\"rbIsPayMent\" checked=\"checked\" />不支持</td>\r\n");
	XYBody.Append("</tr>\r\n");

	}	//end if

	XYBody.Append("</table>\r\n");

	}	//end if


	if (module.EName=="venture"||module.PEName=="venture")
	{

	XYBody.Append("<table class=\"tab_step2 mt8\">\r\n");
	XYBody.Append("<tr>\r\n");
	XYBody.Append("<th >单价：<em class=\"red\">*</em></th>\r\n");
	XYBody.Append("<td><input maxlength=\"10\" id=\"txtcprice\"  name =\"txtcprice\" value=\"0\"/>元<em>注：（0为面议，只能填数字）</em></td>\r\n");
	XYBody.Append("</tr>\r\n");
	XYBody.Append("<tr>\r\n");
	XYBody.Append("<th >计量单位：<em class=\"red\">*</em></th>\r\n");
	XYBody.Append("<td><input maxlength=\"10\"  name =\"txtcunit\"/></td>\r\n");
	XYBody.Append("</tr>\r\n");
	XYBody.Append("<tr>\r\n");
	XYBody.Append("<th >最小起定量：<em class=\"red\">*</em></th>\r\n");
	XYBody.Append("<td><input maxlength=\"6\"  name =\"txtcsmallnum\" value=\"0\"/><em>注：（0为无限量，只能填数字）</em></td>\r\n");
	XYBody.Append("</tr>\r\n");
	XYBody.Append("<tr>\r\n");
	XYBody.Append("<th >货物总量：<em class=\"red\">*</em></th>\r\n");
	XYBody.Append("<td><input maxlength=\"6\"  name =\"txtccountnum\" value=\"0\"/><em>注：（0为无限量，只能填数字）</em></td>\r\n");
	XYBody.Append("</tr>\r\n");
	XYBody.Append("</table>\r\n");

	}	//end if


	if (module.EName=="investment"||module.PEName=="investment")
	{

	XYBody.Append("<table class=\"tab_step2 mt8\" >\r\n");
	XYBody.Append("<tr>\r\n");
	XYBody.Append("<th>准备代理(招商)的地区：</th>\r\n");
	XYBody.Append("<td>\r\n");
	XYBody.Append("    <input type=\"radio\"  id=\"citys\" name =\"citys\" onclick =\"showcityname(1);\" checked value =\"全国\"/>全国\r\n");
	XYBody.Append("    <input type=\"radio\" id=\"cityl\"  name=\"cityl\"  onclick =\"showcityname(2);\" value=\"\"/> 其它</td>\r\n");
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
	XYBody.Append("<th >招商支持：</th>\r\n");
	XYBody.Append("<td>\r\n");
	XYBody.Append("    <textarea id=\"txtsupport\" name =\"txtsupport\" cols=\"80\" rows=\"7\"></textarea></td>\r\n");
	XYBody.Append("</tr>\r\n");
	XYBody.Append("<tr>\r\n");
	XYBody.Append("<th >招商要求：</th>\r\n");
	XYBody.Append("<td> <textarea id=\"txtdemand\" name =\"txtdemand\" cols=\"80\" rows=\"7\"></textarea></td>\r\n");
	XYBody.Append("</tr>\r\n");
	XYBody.Append("<tr>\r\n");
	XYBody.Append("<th >展示网址：</th>\r\n");
	XYBody.Append("<td><input maxlength=\"95\"  name =\"pageurl\" id=\"pageurl\"/></td>\r\n");
	XYBody.Append("</tr>\r\n");
	XYBody.Append("</table>\r\n");
	XYBody.Append("<table class=\"tab_step2\" id=\"tabInvestmentBuy\" style=\"display:none;border-top:0px;\">\r\n");
	XYBody.Append("<tr>\r\n");
	XYBody.Append("<th >代理过的品牌：</th>\r\n");
	XYBody.Append("<td><input type=\"text\"  name =\"txtbrand\" style=\"width: 255px\" id=\"txtbrand\"/></td>\r\n");
	XYBody.Append("</tr>\r\n");
	XYBody.Append("</table>\r\n");

	}	//end if

	XYBody.Append(" <!--很重要，不能删除-->\r\n");
	XYBody.Append(" <script language=\"javascript\" type=\"text/javascript\">\r\n");
	XYBody.Append("    InitInfoAddPageForm('");	XYBody.Append(module.EName.ToString());	XYBody.Append("','");	XYBody.Append(module.PEName.ToString());	XYBody.Append("','");	XYBody.Append(infotypestr.ToString());	XYBody.Append("');\r\n");
	XYBody.Append(" </" + "script>\r\n");

	if (config.IsEnabledVCode("quickpost"))
	{

	XYBody.Append("<table class=\"tab_step2\">\r\n");
	XYBody.Append("<tr>\r\n");
	XYBody.Append("    <th>验证码：<em>*</em></th>\r\n");
	XYBody.Append("    <td>\r\n");
	XYBody.Append("        ");	XYBody.Append(pageinfo.GetValidateCodeHTML());	XYBody.Append("\r\n");
	XYBody.Append("    </td>\r\n");
	XYBody.Append("</tr>\r\n");
	XYBody.Append("</table>\r\n");

	}	//end if

	XYBody.Append("    </div>    \r\n");
	XYBody.Append("    <div class=\"step_next\">\r\n");
	XYBody.Append("    <input type=\"button\" value=\"提交信息\" id=\"btnStep2\" onclick =\"return CheckInfoEditFrom('");	XYBody.Append(module.EName.ToString());	XYBody.Append("','");	XYBody.Append(module.PEName.ToString());	XYBody.Append("');\"/>\r\n");
	XYBody.Append("    <input type=\"button\" value=\"返回\" id=\"btnBack\" onclick=\"history.back();\" />\r\n");
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
