<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BatchManage.aspx.cs" Inherits="XYECOM.Web.xymanage.News.BatchManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
 <title>批量管理</title>
 <link href="../css/style.css" type="text/css" rel="stylesheet" />
 <link href="/common/css/XYLib.css" type="text/css" rel="Stylesheet" />
 <script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
 <script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
</head>
<body>
<form id="form1" runat="server">
<h1><a href="../index.aspx">后台管理首页</a> &gt;&gt; 批量管理</h1>
<table width="100%">
<tr>
<td class="right">

<div class="main-setting">
<div class="itemtitle"><h3>批量管理</h3></div>

<table class="xy_tb xy_tb2">
<tr>
<td align="center">
<br />

<div style="width:60%; text-align:left; line-height:200%;">
<asp:ListBox ID="ListBox1" runat="server" Width="200px" Rows="15"></asp:ListBox>
   &nbsp;&gt;&gt;&nbsp;
<asp:ListBox ID="ListBox2" runat="server" Width="200px" Rows="15"></asp:ListBox>
<br/><br/>
<b>转移选项：</b><br/>
<asp:RadioButton ID="rbtone" runat="server" Checked="True" GroupName="rbt" Text="仅转移单一栏目资讯" />(仅属于一个栏目的资讯)
    <br />
    <asp:RadioButton ID="rbtmany" runat="server" GroupName="rbt" Text="转移全部栏目资讯" />(属于一个栏目和多个栏目的资讯)
    
    <br/><br/>
    <asp:Button ID="btnok" runat="server" Text="转移" CssClass="button" OnClick="btnok_Click"/>
    <input type="button" onclick="location.href='TitleList.aspx';" value="返回" class="button"/>
    <br/>
    <asp:Label ID="lblMessage" runat="server"  ForeColor="Red"></asp:Label>
</div>
</td>
</tr>
</table>
</div>

</td>
</tr>
</table>
</form>
</body>
</html>

