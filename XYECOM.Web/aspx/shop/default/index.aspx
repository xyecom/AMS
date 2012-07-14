<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.shop.index,XYECOM.Page" %>
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
	XYBody.Append("11111111111111\r\n");
	XYBody.Append("");	XYBody.Append(shopuserinfo.LayerName.ToString());	XYBody.Append("\r\n");
	XYBody.Append("<br />\r\n");
	XYBody.Append("");	XYBody.Append(shopuserinfo.userid.ToString());	XYBody.Append("\r\n");
	XYBody.Append("<br />\r\n");
	XYBody.Append("");	XYBody.Append(shopuserinfo.LoginName.ToString());	XYBody.Append("\r\n");

	XYBody.Append("");
	Response.Write(XYBody.ToString());
}
</script>
