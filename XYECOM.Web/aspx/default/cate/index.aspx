<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.cate.index,XYECOM.Page" %>
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
	XYBody.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\" >\r\n");
	XYBody.Append("<head>\r\n");
	XYBody.Append("    <title>Untitled Page</title>\r\n");
	XYBody.Append("</head>\r\n");
	XYBody.Append("<body>\r\n");
	XYBody.Append("");	XYBody.Append(protypename.ToString());	XYBody.Append("<br/>\r\n");
	XYBody.Append("<ul>\r\n");
	XYBody.Append("" +  XYECOMCreateHTML("XY_OfferInfoByPage").ToString() + "\r\n");
	XYBody.Append("</ul>\r\n");
	XYBody.Append("<br/>\r\n");
	XYBody.Append("<ul>\r\n");
	XYBody.Append("" +  XYECOMCreateHTML("XY_NewsInfoByPage").ToString() + "\r\n");
	XYBody.Append("</ul>\r\n");
	XYBody.Append("</body>\r\n");
	XYBody.Append("</html>\r\n");

	XYBody.Append(IsCopyright());
	Response.Write(XYBody.ToString());
}
</script>
