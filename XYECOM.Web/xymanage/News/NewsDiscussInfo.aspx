<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_news_NewsDiscussInfo" Codebehind="NewsDiscussInfo.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>�鿴��Ѷ����</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/XYLib.css" type="text/css" rel="Stylesheet" />
    <script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
</head>
<body>
<form id="form1" runat="server">
<h1><a href="../index.aspx">��̨������ҳ</a> >> �鿴��Ѷ����</h1>
<table width="100%">
<tr>
<td class="right">

<div class="main-setting">
<div class="itemtitle"><h3 id="caption" runat="server">�鿴��Ѷ����</h3></div>

<table class="xy_tb xy_tb2">
<tr class="nobg">
  <td colspan="2" class="td27">�����ˣ�</td>
</tr>
<tr>
    <td class="vtop" colspan="2">
    <asp:Label ID="lbname" runat="server"></asp:Label>
    </td>
</tr>
<tr class="nobg">
  <td colspan="2" class="td27">����ʱ�䣺</td>
</tr>
<tr>
   <td class="vtop" colspan="2">
    <asp:Label ID="lbtime" runat="server"></asp:Label>
   </td>
</tr>
<tr class="nobg">
  <td colspan="2" class="td27">�������ݣ�</td>
</tr>
<tr>
   <td class="vtop" colspan="2">
    <asp:Label ID="tbcontent" runat="server"></asp:Label>
   </td>
</tr>
<tr class="nobg">
  <td colspan="2" class="td27">�Ƿ���ʾ��</td>
</tr>
<tr>
   <td class="vtop" colspan="2">
    <asp:RadioButton ID="rbisshowtrue" GroupName="rbisshow" runat="server" Text="��ʾ" CssClass="input" />
    <asp:RadioButton ID="rbisshowfalse" GroupName="rbisshow" runat="server" Text="����ʾ" CssClass="input" />
   </td>
</tr>
</table>
<table width="100%" class="content_action">
<tr>
<th></th>
<td class="center"><label><asp:Button ID="btsub" runat="server" CssClass="button" Text="ȷ ��" OnClick="btsub_Click" />
  <input id="btcancel" runat="server" class="button" type="button" value="�� ��" onserverclick="btcancel_ServerClick" /></label></td>
</tr>
</table>
</div>
</td>
</tr>
</table>    
</form>
</body>
</html>
