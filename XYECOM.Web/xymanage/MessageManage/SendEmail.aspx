<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_basic_SendEmail" Codebehind="SendEmail.aspx.cs" %>

<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc2" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>发出邮件管理</title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script language ="javascript" type ="text/javascript" src ="../javascript/CheckedAll.js"></script>
</head>
<body>
<form id="Form1" method="post" runat="server">
<h1><a href="../index.aspx">后台管理首页</a> >> 发出邮件管理</h1>
<table width="100%">
<tr>
<td class="right">

<div class="main-setting">
<div class="itemtitle"><h3>邮件管理</h3>
    <ul class="tab1" id="mainMenus0">
        <li class="current"><a href="#"><span>发件箱</span></a></li>
        <li><a href="AddSendEmail.aspx"><span>发送邮件</span></a></li>
    </ul>
</div>


<table class="xy_tb xy_tb2">
<tr>
<td>
<asp:GridView HeaderStyle-CssClass="gv_header_style" ID="gvlist" runat="server" AutoGenerateColumns="False"  DataKeyNames="E_ID"  Width="100%"  PageSize="20" GridLines="None" OnRowCommand="gvlist_RowCommand" OnRowDataBound="gvlist_RowDataBound">
<Columns>
    <asp:BoundField DataField="E_ID" HeaderText="E_ID" Visible="False" />
    <asp:TemplateField HeaderText="选择">
 <ItemTemplate>
<asp:CheckBox ID="chkExport" runat="server" />
</ItemTemplate> 
        <ItemStyle Width="5%" />
    </asp:TemplateField>
    <asp:BoundField DataField="E_title" HeaderText="标题"  >
    <HeaderStyle CssClass="gvLeft" />
        <ItemStyle Width="70%" CssClass="gvLeft"  />
    </asp:BoundField>
    <asp:BoundField DataField="addtime" HeaderText="发送时间" >
        <ItemStyle Width="20%" />
    </asp:BoundField>
    <asp:HyperLinkField DataNavigateUrlFields="E_ID" DataNavigateUrlFormatString="SendEmailInfo.aspx?E_ID={0}" HeaderText="查看" NavigateUrl="SendEmailInfo.aspx?E_ID={0}" Text="&lt;img src=&quot;../images/look.gif&quot; /&gt;" >
        <ItemStyle Width="5%" />
    </asp:HyperLinkField>
</Columns>
</asp:GridView>
<p style="text-align:center;"><asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label></p>
</td>
</tr>
<tr>
<td class="content_action"><input class="list_td04" id="chkAll" onclick="chkAll_true()" type="checkbox" name="chkAll"
runat="server"/>全选
<asp:Button ID="Button1" runat="server" Text="删除"  CssClass ="button" OnClick="Button1_Click"/></td> 															
</tr>
</table>
<uc2:page ID="Page1" runat="server" />
</div>
</td>
</tr>
</table> 

</form>
</body>
</html>
