<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.vote,XYECOM.Page" %>
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
	XYBody.Append("    <title>���ߵ���</title>\r\n");
	XYBody.Append("    <link rel=\"stylesheet\" href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/css/vote.css\" type=\"text/css\"/>\r\n");
	XYBody.Append("</head>\r\n");
	XYBody.Append("<body>\r\n");
	XYBody.Append("<br/>\r\n");
	XYBody.Append("<h1>");	XYBody.Append(title.ToString());	XYBody.Append("</h1>\r\n");
	XYBody.Append("<h2>");	XYBody.Append(desc.ToString());	XYBody.Append("</h2>\r\n");
	XYBody.Append("<div class=\"rst\">\r\n");
	XYBody.Append("    <form action=\"\" method=\"post\">\r\n");
	XYBody.Append("    <table cellpadding=\"1\" cellspacing=\"0\">\r\n");

	int data__loop__id=0;
	foreach(DataRow data in subject.Rows)
	{
		data__loop__id++;

	XYBody.Append("        <tr>\r\n");
	XYBody.Append("            <th>" + data["subject"].ToString().Trim() + "</th>\r\n");
	XYBody.Append("        </tr>\r\n");
	XYBody.Append("        <tr>\r\n");
	XYBody.Append("            <td>\r\n");
	 str = GetInputHTML(data["subjectId"].ToString(),data["type"].ToString());;
	
	XYBody.Append("             ");	XYBody.Append(str.ToString());	XYBody.Append("\r\n");
	XYBody.Append("            </td>\r\n");
	XYBody.Append("        </tr>\r\n");

	}	//end loop

	XYBody.Append("    <tr>\r\n");
	XYBody.Append("        <td>\r\n");
	XYBody.Append("            <input type=\"submit\" value=\"�ύ\"/>\r\n");
	XYBody.Append("        </td>\r\n");
	XYBody.Append("    </tr>\r\n");
	XYBody.Append("    </table>\r\n");
	XYBody.Append("    </form>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("</body>\r\n");
	XYBody.Append("</html>\r\n");

	XYBody.Append(IsCopyright());
	Response.Write(XYBody.ToString());
}
</script>
