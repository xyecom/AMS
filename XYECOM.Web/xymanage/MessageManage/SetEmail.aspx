<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_MessageManage_Default" Codebehind="SetEmail.aspx.cs" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>发送邮件</title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script language ="javascript" src ="../javascript/CheckedAll.js" type ="text/javascript" ></script>
</head>
<body>
<form id="Form1" method="post" runat="server">
<h1><a href="../index.aspx">后台管理首页</a> >> 设置邮箱</h1>
<table  width="100%" >
<tr>
<!-- right -->
<td class="right">
<!--后台导航 -->
<!-- 表格 -->
<table class="contentl">
<caption>
    设置邮箱</caption>
<tr>
<td>
<table width="100%" >
<tr>
<th >
    邮箱名称：</th>
<td ><label><asp:textbox id="lbemail" runat="server" Width="250" CssClass="input"  MaxLength="500"></asp:textbox></label></td>
</tr>
<tr>
<th >
    邮箱密码：</th>
<td ><label><asp:textbox id="lbpassword" runat="server" Columns="40" CssClass="input"  MaxLength="500" TextMode="Password" Width="248px"></asp:textbox></label></td>
</tr>
<tr  class="content_action">
<th style="height: 10px">&nbsp;</th>
<td style="height: 10px"><label>
    <asp:Button ID="Button1" runat="server" Text="确定"　 CssClass ="button" OnClick="Button1_Click" /></label></td>
</tr>
</table>

</td></tr>
</table>
</td>
</tr>
</table>
</form>
</body>
</html>
