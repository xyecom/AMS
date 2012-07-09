<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_basic_ReceiveEmaiinfo" Codebehind="ReceiveEmaiinfo.aspx.cs" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>收到短信详细信息</title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script language ="javascript" src ="../javascript/CheckedAll.js" type ="text/javascript" >function Button1_onclick() {

}

</script>
</head>
<body >
<form id="Form1" method="post" runat="server">
<h1><a href="../index.aspx">后台管理首页</a> >> 收到短信详细信息</h1>
<table  width="100%" >
<tr>
<!-- right -->
<td class="right">
<!--后台导航 -->
    



<div class="main-setting">

<div class="itemtitle"><h3>收到留言详细信息</h3></div>

<table width="100%" class="xy_tb xy_tb2 infotable border_buttom0" id="companyinfo">
<tr>
<th>联系人：</th>
<td id="username" runat="server"></td>
</tr>
<tr>
<th>联系电话：</th>
<td id="phone" runat="server"></td>
</tr>
<tr>
<th>手机：</th>
<td id="moblie" runat="server"></td>
</tr>
<tr>
<th>内容：</th>
<td id="info" runat="server"></td>
</tr>

<tr>
<th>
    日期 ：</th>
<td id="addtime" runat="server"></td>
</tr>

<tr>
<th>&nbsp;</th>
<td><label>
    <asp:Button ID="btn_back" runat="server" CssClass="button" 
        Text="返回" OnClick="btn_back_Click" /></label>
        
        <input id="U_ID" runat="server" type="hidden" />
        </td>
</tr>
</table>

<br/>
<div class="itemtitle"><h3>回复留言</h3></div>
<table width="100%" class="xy_tb xy_tb2 infotable border_buttom0" id="Table1">

<tr>
<th>
    标题：</th>
<td  runat="server">
    <asp:TextBox ID="title" runat="server" Width="442px"  MaxLength ="900" ReadOnly="True"></asp:TextBox></td>
</tr>
<tr>
<th>
    内容：</th>
<td  runat="server">
    <asp:TextBox ID="content" runat="server" Height="160px" TextMode="MultiLine" Width="443px"  MaxLength ="1500"></asp:TextBox></td>
</tr>
<tr>
<th style="height: 40px">&nbsp;</th>
<td style="height: 40px">
    <asp:Button ID="Button3" runat="server" Text="确定"  CssClass ="button" OnClick="Button3_Click"/><asp:Button ID="btn_back2" runat="server" CssClass="button" 
        Text="取消" OnClick="btn_back2_Click" /></td>
</tr>
</table>

</div>

</td>
</tr>
</table>
</form>
</body>
</html>
