<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditClassInfoLabel.aspx.cs" Inherits="XYECOM.Web.xymanage.LabelManage.EditClassInfoLabel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>编辑类别标签</title>
        <link href="../css/style.css" type="text/css" rel="stylesheet" />
        <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
        <script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
        <script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
</head>
<body>
<form id="form1" runat="server">
<h1><a href="../index.aspx">后台管理首页</a> &gt;&gt; <a href="ClassLabelList.aspx">分类信息标签管理</a></h1>
<table width="100%">
<tr>
<td class="right">



<div class="main-setting">

<div class="itemtitle"><h3>编辑分类标签</h3></div>

<table width="100%" class="xy_tb xy_tb2 infotable">
<tr>
<td style="text-align: left">
    &nbsp;<br/>
    <asp:TextBox ID="txtBody" runat="server" Height="350px" TextMode="MultiLine" Width="98%" CssClass="EditClassInfoLabelCss"></asp:TextBox>&nbsp;
<p style="text-align:center;">
    &nbsp;</p>
</td>
</tr>
<tr>
<td class="content_action">
    <asp:Button ID="btnEdit" runat="server" CssClass="button"
        Text="保存修改" OnClick="btnEdit_Click" />
        <input type="button" ID="btnBack" runat="server" class="button" value="返回" />
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
