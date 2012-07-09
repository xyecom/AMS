<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExpressMessageList.aspx.cs" Inherits="XYECOM.Web.xymanage.Global.ExpressMessageList" %>

<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>系统快速留言列表</title>
    <link type="text/css" href="../css/style.css" rel="Stylesheet" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
    <script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
<script language ="javascript" type ="text/javascript" src ="../javascript/list.js"></script>
</head>
<body>
<form id="form1" runat="server">
<h1><a href="../index.aspx">后台管理首页</a> >> 系统快速留言列表</h1>
<table width="100%">
<tr>
<td class="right">


<div class="main-setting">
<div class="itemtitle"><h3>系统快速留言列表</h3>
<ul id="Ul1" runat="server" class="tab1">
</ul>
<asp:Button ID="lnkAdd" runat="server" CssClass="addbtn" Text="新增留言" OnClick="lnkAdd_Click" />
</div>

<table class="xy_tb xy_tb2" style="margin-top:0px;">
<tr>
<td class="content_action">
<asp:DropDownList ID="ddlModules" runat="server" CssClass="dropdownlist" AutoPostBack="True" OnSelectedIndexChanged="ddlModules_SelectedIndexChanged" >
</asp:DropDownList>&nbsp;
</td>
</tr>
<tr>
<td>
<asp:GridView ID="gvlist" HeaderStyle-CssClass="gv_header_style" Width="100%" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" GridLines="None"  OnRowDataBound="gvlist_RowDataBound">
<Columns>
<asp:BoundField Visible="False" DataField="ID" />
<asp:TemplateField HeaderText="选择"><ItemTemplate><asp:CheckBox ID="chkExport" runat="server" /></ItemTemplate>
    <ItemStyle Width="5%" />
</asp:TemplateField>
<asp:BoundField HeaderText="内容" DataField="Body" >
    <ItemStyle Width="75%" CssClass="gvLeft" />
    <HeaderStyle CssClass="gvLeft" />
</asp:BoundField>
<asp:TemplateField HeaderText="所属模块"><ItemTemplate><asp:Label ID="Label1" runat="server" Text='<%#GetExpMsgModuleName(DataBinder.Eval(Container,"DataItem.ModuleName").ToString()) %>'></asp:Label></ItemTemplate>
    <HeaderStyle CssClass="gvLeft" Width="10%" />
    <ItemStyle CssClass="gvLeft" Width="15%" />
</asp:TemplateField>

<asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="AddExpressMessage.aspx?sm_id={0}" HeaderText="编辑" Text='&lt;img src=&quot;../images/edit.GIF&quot;;alt=&quot;编辑&quot;; /&gt;' >
    <HeaderStyle Width="5%" />
    <ItemStyle Width="5%" />
</asp:HyperLinkField>
</Columns>
</asp:GridView>
<p style="text-align:center;"><asp:Label ID="lblMessage" runat="server" ForeColor="red"></asp:Label></p>
</td>
</tr>
<tr>
<td class="content_action">
<input id="chkAll" onclick="chkAll_true();" type="checkbox" name="chkAll" runat="server" />全选
<asp:Button ID="lnkDel" runat="server" CssClass="button" Text="删除" OnClick="lnkDel_Click" />

</td>
</tr>
</table>
<uc2:page ID="page1" runat="server" />
</div>
</td>
</tr>
</table>
</form>
</body>
</html>

