<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AreaAdd.aspx.cs" Inherits="XYECOM.Web.xymanage.basic.AreaAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>地区信息管理</title>
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script type="text/javascript" src="../javascript/CheckedAll.js" ></script>
</head>
<body>
    <form id="form1" runat="server">
    
    <h1><a href="../index.aspx">后台管理首页</a>  &gt;&gt; <a href="arealist.aspx">地区管理</a><asp:Label ID="lbPath" runat="server"></asp:Label></h1>
    
<table width="100%" >
<tr>

<td class="right">
<!--后台导航 -->
    


<table width="100%" class="contentl" >
<caption id="title" runat="server"></caption>
<tr>
<td>
<table width="100%" >
<tr>
    <th>
        地区名称：</th>
    <td><asp:TextBox ID="txtName" Columns="80" runat="server" CssClass="input" MaxLength="20" Rows="4" TextMode="MultiLine"></asp:TextBox></td>
</tr>

<tr>
<th>&nbsp;</th>
<td class="content_action"><label><asp:button id="btnok" runat="server" CssClass="button" Text="保存" OnClick="btnok_Click"  ></asp:button>&nbsp;<input id="Button1" class="button" type="button" value="返 回" onclick="javascript:history.go(-1);" /></label></td>
</tr>
</table>
</td></tr></table>
</td>
</tr>
</table>
    </form>
</body>
</html>
