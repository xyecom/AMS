<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.news.comment,XYECOM.Page" %>
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

	XYBody.Append("	<title>");	XYBody.Append(seo.Title);	XYBody.Append("</title>\r\n");
	XYBody.Append("	<meta name=\"description\" content=\"");	XYBody.Append(seo.Description);	XYBody.Append("\" />\r\n");
	XYBody.Append("	<meta name=\"keywords\" content=\"");	XYBody.Append(seo.Keywords);	XYBody.Append("\" />\r\n");
	XYBody.Append("	<meta name=\"robots\" content=\"all\"/>\r\n");
	XYBody.Append("	<meta http-equiv=\"Content-Type\" content=\"text/html; charset=\"gb2312\" />\r\n");
	XYBody.Append("	<link rel=\"stylesheet\" href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("common/css/XYLib.css\" type=\"text/css\" media=\"screen\" />\r\n");
	XYBody.Append("	<link href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/css/global.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n");
	XYBody.Append("	<link href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/css/channel.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n");
	XYBody.Append("	<link href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/css/news.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n");
	XYBody.Append("    <link href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/css/index.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n");
	XYBody.Append("    <script type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("common/js/base.js\" language=\"javascript\"></" + "script>	\r\n");
	XYBody.Append("	<script type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/js/login.js\" language=\"javascript\"></" + "script>\r\n");
	XYBody.Append("    <script type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/js/validate.js\" language=\"javascript\"></" + "script>\r\n");
	XYBody.Append("    <script type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/js/news.js\" language=\"javascript\"></" + "script>\r\n");


	XYBody.Append("</head>\r\n");
	XYBody.Append("<body  onload=\"");	XYBody.Append(pageinfo.OnLoadEvents);	XYBody.Append("\">\r\n");
	XYBody.Append("<div class=\"wrapper\">\r\n");
	XYBody.Append("    <div id=\"hd_info\">\r\n");
	XYBody.Append("		<div class=\"smpMenu\">\r\n");
	XYBody.Append("	            <a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("\" class=\"tabactive\">�� ҳ</a> | \r\n");
	XYBody.Append("				<a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("news/\">������Ѷ</a> | \r\n");
	XYBody.Append("				<a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("offer/\">��Ʒ����</a> | \r\n");
	XYBody.Append("				<a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("investment/\">���̼���</a> | \r\n");
	XYBody.Append("				<a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("company/\">��ҵ��˾</a> | \r\n");
	XYBody.Append("				<a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("job/\">�˲���Ƹ</a> | \r\n");
	XYBody.Append("				<a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("brand/\">��ҵƷ��</a> | \r\n");
	XYBody.Append("				<a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("exhibition/\">չ����Ϣ</a>\r\n");
	XYBody.Append("			<div class=\"clr\"></div>\r\n");
	XYBody.Append("		</div>\r\n");
	XYBody.Append("	</div>\r\n");
	XYBody.Append("	<div class=\"clr\"></div>\r\n");
	XYBody.Append("	<div class=\"cmtBody\">\r\n");
	XYBody.Append("    <div class=\"cmtNav\">\r\n");
	XYBody.Append("		 �����ڵ�λ�ã�");	XYBody.Append(pageinfo.Navigation);	XYBody.Append(" &gt; �����б�\r\n");
	XYBody.Append("	</div>\r\n");
	XYBody.Append("    <h2>���⣺\r\n");

	if (config.BogusStatic==true)
	{

	XYBody.Append("	  <a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("news/content-");	XYBody.Append(NewsID.ToString());	XYBody.Append(".");	XYBody.Append(config.Suffix);	XYBody.Append("\">\r\n");

	}
	else
	{

	XYBody.Append("	  <a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("news/content.");	XYBody.Append(config.Suffix);	XYBody.Append("?ns_id=");	XYBody.Append(NewsID.ToString());	XYBody.Append("\">\r\n");

	}	//end if

	XYBody.Append("");	XYBody.Append(nsname.ToString());	XYBody.Append("\r\n");
	XYBody.Append("	</a>\r\n");
	XYBody.Append("	</h2>\r\n");
	XYBody.Append("    <div class=\"comments\">\r\n");
	XYBody.Append("            <div>   \r\n");
	XYBody.Append("             <dl>\r\n");

	int nsdis__loop__id=0;
	foreach(DataRow nsdis in nsdislist.Rows)
	{
		nsdis__loop__id++;

	XYBody.Append("            <dd><span>" + nsdis["ND_AddTime"].ToString().Trim() + "</span>\r\n");

	if (nsdis["U_ID"].ToString().Trim()=="0")
	{

	XYBody.Append("<strong>" + nsdis["U_Name"].ToString().Trim() + "</strong>(�ο�)\r\n");

	}	//end if


	if (nsdis["U_ID"].ToString().Trim()!="0")
	{


	if (nsdis["U_Flag"].ToString().Trim()=="True")
	{


	if (nsdis["U_HtmlPage"].ToString().Trim()=="")
	{


	if (config.IsDomain==true)
	{

	XYBody.Append("                   <strong><a href=\"http://" + nsdis["U_Name"].ToString().Trim() + "");	XYBody.Append(pageinfo.DomainHost);	XYBody.Append("/\" target=\"_blank\">" + nsdis["U_Name"].ToString().Trim() + "</a></strong>\r\n");

	}
	else
	{

	XYBody.Append("                   <strong><a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("shop/" + nsdis["U_Name"].ToString().Trim() + "/index.");	XYBody.Append(config.Suffix);	XYBody.Append("\" target=\"_blank\">" + nsdis["U_Name"].ToString().Trim() + "</a></strong>\r\n");

	}	//end if


	}	//end if


	if (nsdis["U_HtmlPage"].ToString().Trim()!="")
	{

	XYBody.Append("                   <strong><a href=\"" + nsdis["U_HtmlPage"].ToString().Trim() + "\">" + nsdis["U_Name"].ToString().Trim() + "</a></strong>\r\n");

	}	//end if


	}
	else
	{

	XYBody.Append("		            " + nsdis["U_Name"].ToString().Trim() + "(���˻�Ա)\r\n");

	}	//end if


	}	//end if

	XYBody.Append("                 </dd>\r\n");
	XYBody.Append("                <dt>" + nsdis["ND_Content"].ToString().Trim() + "</dt>	\r\n");

	}	//end loop

	XYBody.Append("        </dl>\r\n");
	XYBody.Append("   <div id=\"page\">");	XYBody.Append(pageinfo.PreviousPage);	XYBody.Append(" ");	XYBody.Append(pageinfo.NumPage);	XYBody.Append(" ");	XYBody.Append(pageinfo.NextPage);	XYBody.Append("</div>\r\n");
	XYBody.Append("  </div>\r\n");
	XYBody.Append("	<div class=\"clear\"></div>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<br/>\r\n");
	XYBody.Append("<div class=\"contentbox\"><h2><span>��������</span></h2>  </div>\r\n");
	XYBody.Append("<div class=\"content\">\r\n");
	XYBody.Append("  <table width=\"80%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	XYBody.Append("  <tr>\r\n");
	XYBody.Append("    <td class=\"comment\"><label>\r\n");
	XYBody.Append("      <textarea cols=\"70\" maxlength=\"4000\" rows=\"6\" id=\"CommentBody\"></textarea>\r\n");
	XYBody.Append("    </label>     \r\n");
	XYBody.Append("      <input type=\"hidden\" id=\"NewsId\" value=\"");	XYBody.Append(NewsID.ToString());	XYBody.Append("\" name=\"NID\" /></td>\r\n");
	XYBody.Append("  </tr>\r\n");
	XYBody.Append("  <tr>\r\n");
	XYBody.Append("    <td class=\"con_tdr\"><label>\r\n");
	XYBody.Append("      &nbsp;&nbsp;<input id=\"IsHiddenIP\" type=\"checkbox\" value=\"\"/>����IP&nbsp;<input name=\"post\" type=\"button\" class='myinput' value=\"���ٷ�������\" onclick=\"InsertComment();window.location.reload();\"/> \r\n");
	XYBody.Append("    </label></td>\r\n");
	XYBody.Append("  </tr>\r\n");
	XYBody.Append("</table>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("    </div>\r\n");

	XYBody.Append("	<div id=\"footer\">\r\n");
	XYBody.Append("		<a href=\"\">������ҳ</a> | <a href=\"/about/index.htm\" target=\"_blank\">��������</a> | <a href=\"\">��������</a> | <a href=\"\">ý�屨��</a> | <a href=\"\">��ƸӢ��</a> | <a href=\"\">����ר��</a> | <a href=\"\">���ר��</a> | <a href=\"\">��������</a> | <a href=\"\">��ϵ����</a> | <a href=\"\">��վ��ͼ</a>\r\n");
	XYBody.Append("	</div>\r\n");
	XYBody.Append("	<div id=\"copyright\">\r\n");
	XYBody.Append("		<div id=\"copy_info\">\r\n");
	XYBody.Append("			<ul>\r\n");
	XYBody.Append("				<li>Copyright &copy; 2005-2009  &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<a href=\"#\" target=\"_blank\">��ICP��05003331��</a></li>\r\n");
	XYBody.Append("				<li><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/ico_phone.gif\" align=\"absmiddle\">�绰��86-010-62669815 ���棺86-010-86818791  <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/ico_email.gif\" />E-Mail��<a href=\"#\">info@xyecom.com </a></li>\r\n");
	XYBody.Append("				<li>��Ȩ���С��ݺ�������� - ��������С��ҵ��������Ӧ�ü�������δ����Ȩ����ת��</li>\r\n");
	XYBody.Append("			</ul>			\r\n");
	XYBody.Append("		</div>\r\n");
	XYBody.Append("		<div class=\"copyright_i\">\r\n");
	XYBody.Append("		 <div class=\"com copyright_i1\"><p class=\"p\"><a href=\"#\" target=\"_blank\">�������羯�챨��ƽ̨</a></p></div>\r\n");
	XYBody.Append("		 <div class=\"com copyright_i2\"><p class=\"p\">������Ϣ��ȫ������</p></div>\r\n");
	XYBody.Append("		 <div class=\"com copyright_i3\"><p class=\"p\"><a href=\"#\" target=\"_blank\">��Ӫ����վ������Ϣ</a></p></div>\r\n");
	XYBody.Append("		 <div class=\"com copyright_i4\"><p class=\"p\"><a href=\"#\" target=\"_blank\">������Ϣ�ٱ�����</a></p></div>\r\n");
	XYBody.Append("		</div>\r\n");
	XYBody.Append("	 </div>\r\n");


	XYBody.Append("</div>\r\n");
	XYBody.Append("</body>\r\n");
	XYBody.Append("</html>\r\n");

	XYBody.Append(IsCopyright());
	Response.Write(XYBody.ToString());
}
</script>
