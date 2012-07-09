<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LabelIn.aspx.cs" Inherits="XYECOM.Web.xymanage.LabelManage.LabelIn" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>标签导入导出</title>
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
</head>
<body>
<form id="Form1" method="post" runat="server">

<h1><a href="../index.aspx">后台管理首页</a> >> 标签导入</h1>

<table width="100%">
<tr>
<td class="right">

<div class="main-setting">
<div class="itemtitle"><h3>标签导入导出</h3>
    <ul class="tab1" id="Ul1">
        <li><a href="LabelOut.aspx"><span>标签导出</span></a></li>
        <li class="current"><a href="#"><span>标签导入</span></a></li>
    </ul>
</div>


<!-- content  -->
<table class="xy_tb xy_tb2">
<tr>
<td>
 选择要导入的标签备份文件：
</td>
<td>
<br/> 
<asp:FileUpload ID="FileUpload1" runat="server" Width="400px"/>
</td>
</tr>
<tr>
<td> 遇到同名标签:</td>
<td><br/>
        <asp:RadioButton runat="server" ID="rbton" Checked="true" GroupName="rbtgroup" Text="覆盖"/>
        <asp:RadioButton runat="server" ID="rbtnext" GroupName="rbtgroup" Text="跳过"/>
    </td> 
</tr>
<tr>
 <td></td>
 <td>
                    <asp:Button ID="btnupload" runat="server" Text="导入" CssClass="button" OnClick="btnupload_Click" />
            <asp:Label ID="Label1" runat="server" ForeColor="Red" Text=""></asp:Label>
    </td>
</tr>
<tr>
<td colspan="2">
    <asp:Panel runat="server" ID="pnlresult" Visible="false">
            <asp:Label ID="Label5" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="Label2" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="Label3" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="Label4" runat="server" Text=""></asp:Label><br />
    </asp:Panel>
</td>
</tr>
</table>


</td>
</tr>
</table>
</form>
</body>
</html>