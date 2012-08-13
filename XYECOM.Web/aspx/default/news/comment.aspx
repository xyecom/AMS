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

	XYBody.Append("	<title>");
	XYBody.Append("	<meta name=\"description\" content=\"");
	XYBody.Append("	<meta name=\"keywords\" content=\"");
	XYBody.Append("	<meta name=\"robots\" content=\"all\"/>\r\n");
	XYBody.Append("	<meta http-equiv=\"Content-Type\" content=\"text/html; charset=\"gb2312\" />\r\n");
	XYBody.Append("	<link rel=\"stylesheet\" href=\"");
	XYBody.Append("	<link href=\"");
	XYBody.Append("	<link href=\"");
	XYBody.Append("	<link href=\"");
	XYBody.Append("    <link href=\"");
	XYBody.Append("    <script type=\"text/javascript\" src=\"");
	XYBody.Append("	<script type=\"text/javascript\" src=\"");
	XYBody.Append("    <script type=\"text/javascript\" src=\"");
	XYBody.Append("    <script type=\"text/javascript\" src=\"");


	XYBody.Append("</head>\r\n");
	XYBody.Append("<body  onload=\"");
	XYBody.Append("<div class=\"wrapper\">\r\n");
	XYBody.Append("    <div id=\"hd_info\">\r\n");
	XYBody.Append("		<div class=\"smpMenu\">\r\n");
	XYBody.Append("	            <a href=\"");
	XYBody.Append("				<a href=\"");
	XYBody.Append("				<a href=\"");
	XYBody.Append("				<a href=\"");
	XYBody.Append("				<a href=\"");
	XYBody.Append("				<a href=\"");
	XYBody.Append("				<a href=\"");
	XYBody.Append("				<a href=\"");
	XYBody.Append("			<div class=\"clr\"></div>\r\n");
	XYBody.Append("		</div>\r\n");
	XYBody.Append("	</div>\r\n");
	XYBody.Append("	<div class=\"clr\"></div>\r\n");
	XYBody.Append("	<div class=\"cmtBody\">\r\n");
	XYBody.Append("    <div class=\"cmtNav\">\r\n");
	XYBody.Append("		 �����ڵ�λ�ã�");
	XYBody.Append("	</div>\r\n");
	XYBody.Append("    <h2>���⣺\r\n");

	if (config.BogusStatic==true)
	{

	XYBody.Append("	  <a href=\"");

	}
	else
	{

	XYBody.Append("	  <a href=\"");

	}	//end if

	XYBody.Append("");
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

	XYBody.Append("                   <strong><a href=\"http://" + nsdis["U_Name"].ToString().Trim() + "");

	}
	else
	{

	XYBody.Append("                   <strong><a href=\"");

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
	XYBody.Append("   <div id=\"page\">");
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
	XYBody.Append("      <input type=\"hidden\" id=\"NewsId\" value=\"");
	XYBody.Append("  </tr>\r\n");
	XYBody.Append("  <tr>\r\n");
	XYBody.Append("    <td class=\"con_tdr\"><label>\r\n");
	XYBody.Append("      &nbsp;&nbsp;<input id=\"IsHiddenIP\" type=\"checkbox\" value=\"\"/>����IP&nbsp;<input name=\"post\" type=\"button\" class='myinput' value=\"���ٷ�������\" onclick=\"InsertComment();window.location.reload();\"/> \r\n");
	XYBody.Append("    </label></td>\r\n");
	XYBody.Append("  </tr>\r\n");
	XYBody.Append("</table>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("    </div>\r\n");



	XYBody.Append("</div>\r\n");
	XYBody.Append("</body>\r\n");
	XYBody.Append("</html>\r\n");

	XYBody.Append(IsCopyright());
	Response.Write(XYBody.ToString());
}
</script>