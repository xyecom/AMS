<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogInfo.aspx.cs" Inherits="XYECOM.Web.xymanage.Global.LogInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>日志信息</title>
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
</head>
<body>

<form id="form1" runat="server">
<h1><a href="../index.aspx">后台管理首页</a> >> 日志信息</h1>
<table width="100%" >
<tr>
<td class="right">
<!--后台导航 -->
    



<div class="main-setting">

<div class="itemtitle"><h3>日志信息</h3></div>

<table width="100%" class="xy_tb xy_tb2 infotable">
<tr>
<th>标题：</th>
<td><asp:Label ID="lbtitle" runat="server"></asp:Label></td>
</tr>
<tr>
<th>
    管理员名称：</th>
<td><asp:Label ID="lbname" runat="server"></asp:Label></td>
</tr>
<tr>
<th>
    模块名：</th>
<td><asp:Label ID="lbmf" runat="server"></asp:Label></td>
</tr>
<tr>
<th>
    日期：</th>
<td><asp:Label ID="lbdate" runat="server"></asp:Label></td>
</tr>
<tr>
<th>
    内容：</th>
<td>
    <asp:Label ID="lbcontent" runat="server"></asp:Label></td>
</tr>
<tr>
<th style="height: 30px">&nbsp;</th>
<td class="content_action" ><label>  <asp:Button ID="Button1" runat="server" Text="返回"  CssClass ="button" OnClick="Button1_Click" /></label></td>
</tr>
</table>
</div>
</td></tr></table>
</form>
</body>
</html>