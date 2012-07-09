<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DBManage.aspx.cs" Inherits="XYECOM.Web.xymanage.Global.DBManage" %>

<%@ Register Src="../UserControl/top.ascx" TagName="top" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>管理员管理</title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script language ="javascript" type ="text/javascript" src ="../javascript/CheckedAll.js"></script>
</head>
<body>
<form id="Form1" method="post" runat="server">
<h1><a href="../index.aspx">后台管理首页</a> >> 数据库维护</h1>
<table  width="100%" >
<tr>
<!-- right -->
<td class="right">
<!--后台导航 -->
    


<div class="main-setting">

<div class="itemtitle"><h3>执行SQL语句</h3></div>

<table width="100%" class="xy_tb xy_tb2 infotable border_buttom0">

<tr ><td>
    <span>提示：此功能请慎用，误操作将引起数据丢失等严重后果<br />
</span></td></tr>
<tr>

 <td><asp:TextBox ID="txtSQL" runat="server"  Rows="6" TextMode="MultiLine" CssClass="sqlText"></asp:TextBox></td> </tr><tr>
<td style="height: 20px;">
<asp:Button ID="btnExexSql" runat="server" Text="执行SQL语句" CssClass ="button" OnClick="btnExexSql_Click" />
    <br /><h1><label id="lblExecSqlResult" runat="server"></label></h1>
    </td></tr>
</table>

<br/>
<div class="itemtitle"><h3>数据库备份</h3></div>
<table width="100%" class="xy_tb xy_tb2 infotable border_buttom0">
<tr>
<td>
    <asp:Button ID="btnBackUpDatabase" runat="server" Text="开始备份数据库" CssClass ="button" OnClick="btnBackUpDatabase_Click" />
    &nbsp;&nbsp;
    <asp:Label ID="Label2" runat="server"></asp:Label>
    <br />
    提示：备份数据库成功后请尽快下载备份文件并将服务器备份文件删除。
    </td>
</tr>
</table>

<br/>
<div class="itemtitle"><h3>备份文件管理</h3></div>
<table width="100%" class="xy_tb xy_tb2 infotable border_buttom0">
<tr >
<td width="20%">
    <asp:ListBox ID="ddlBakFileList" runat="server" Width="300px"></asp:ListBox>
</td>
<td width="80%" align="left" class="back">
      <asp:Button ID="btnDeleteBackFile" runat="server" CssClass="button"
        Text=" 删除备份文件 " OnClick="btnDeleteBackFile_Click"/><br />
      <asp:Button ID="btnDownloadBackFile" runat="server" CssClass="button"
        Text=" 下载备份文件 " OnClick="btnDownloadBackFile_Click"/>
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


