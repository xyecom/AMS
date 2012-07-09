<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.index,XYECOM.Page" %>
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
	XYBody.Append("q2222222222asd\r\n");

	XYBody.Append(IsCopyright());
	Response.Write(XYBody.ToString());
}
</script>
