<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_LabelManage_LabelTypeList" Codebehind="LabelTypeList.aspx.cs" %>

<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>标签类别管理</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
    <script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
</head>
<body>
<form id="Form1" method="post" runat="server">
<h1><a href="../index.aspx">后台设置首页</a> >> 标签分类管理</h1>
<table width="100%" >
<tr>
<td class="right">


<div class="main-setting">
<div class="itemtitle"><h3>标签分类管理</h3>
<input id="btnadd" class="addbtn" type="button" value="新增分类" onclick="window.location.href='LabelTypeAdd.aspx?LT_ParentID=<%=LT_ParentID%>';" />
</div>

<table class="xy_tb xy_tb2">
<tr>
<td>
<asp:GridView ID="gvList" HeaderStyle-CssClass="gv_header_style" Width="100%" runat="server" AutoGenerateColumns="False"  DataKeyNames="LT_ID" GridLines="None" OnRowDeleting="gvList_RowDeleting" OnRowDataBound="gvlist_RowDataBound">
<Columns>
<asp:BoundField Visible="False" DataField="LT_ID" />
 <asp:HyperLinkField DataTextField="LT_Name" HeaderText="分类名称" DataNavigateUrlFields="LT_ID" DataNavigateUrlFormatString="LabelTypeList.aspx?LT_ParentID={0}">
 <HeaderStyle CssClass="gvLeft" />
 <ItemStyle CssClass="action gvLeft" Width="20%" />
 </asp:HyperLinkField>
<asp:BoundField HeaderText="描述" DataField="LT_Remark" >
 <HeaderStyle CssClass="gvLeft" />
    <ItemStyle Width="60%" CssClass="gvLeft" />
</asp:BoundField>    
    <asp:HyperLinkField HeaderText="编辑" DataNavigateUrlFields="LT_ID" DataNavigateUrlFormatString="LabelTypeAdd.aspx?LT_ID={0}" Text="&lt;img src=&quot;../images/edit.gif&quot; /&gt;" ><ItemStyle CssClass="action" Width="5%" /></asp:HyperLinkField>
    <asp:CommandField HeaderText="删除" ShowDeleteButton="True" DeleteText="&lt;img src=&quot;../images/delete.gif&quot; /&gt;" ><ItemStyle CssClass="action" Width="5%" /></asp:CommandField>
</Columns>
</asp:GridView>
<p style="text-align:center;"><asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></p>
</td>
</tr>
</table>
    <uc1:page ID="Page1" runat="server" />
</div>
</td>
</tr>
</table>
</form>
</body>
</html>
