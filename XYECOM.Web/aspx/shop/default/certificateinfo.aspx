<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.shop.certificateinfo,XYECOM.Page" %>
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



	XYBody.Append("<body>\r\n");
	XYBody.Append("<div class=\"k\">\r\n");
	XYBody.Append(" <ul class=\"top\"><li class=\"tl\"></li><li class=\"t\"></li><li class=\"tr\"></li></ul>\r\n");
	XYBody.Append(" <ul class=\"main\">\r\n");
	XYBody.Append("  <li class=\"l\"></li>\r\n");
	XYBody.Append("  <li class=\"c\">\r\n");
	XYBody.Append("   <img src=\"");	XYBody.Append(imgurl.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("  </li>\r\n");
	XYBody.Append("  <li class=\"r\"></li>\r\n");
	XYBody.Append(" </ul>\r\n");
	XYBody.Append(" <ul class=\"bot\"><li class=\"bl\"></li><li class=\"b\"></li><li class=\"br\"></li></ul>\r\n");
	XYBody.Append("</div>\r\n");

	XYBody.Append("<div id=\"footer\">\r\n");
	XYBody.Append("    ����֧�֣�<a href=\"#\" target=\"_blank\"> ������ծȨ������</a>&nbsp;&nbsp;��Ȩ���У�<a href='#'> ��������</a>&nbsp;&nbsp;\r\n");
	XYBody.Append("    ��ʦִҵ֤�ţ�3270205110055 �绰��132323232323 QQ��454547676<br />\r\n");
	XYBody.Append("    ���ǵ�787λ�˿� ��վ��վ��<a href=\"#\" target=\"_blank\"> www.baoqt.cn</a> <a href=\"#\" target=\"_blank\">\r\n");
	XYBody.Append("        EMAIL��hpbqt@163.com</a>\r\n");
	XYBody.Append("    <br />\r\n");
	XYBody.Append("    <a href=\"#\" target=\"_blank\">������Ϣ��ҵ������ ��ICP��05047375 �������й���������֧�ӱ�����37010009000020��</a>\r\n");
	XYBody.Append("</div>\r\n");



	XYBody.Append("");
	Response.Write(XYBody.ToString());
}
</script>
