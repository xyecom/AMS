<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_FriendLink_List" Codebehind="List.aspx.cs" %>

<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc2" %>

<%@ Register Src="../UserControl/top.ascx" TagName="top" TagPrefix="uc1" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>友情链接列表</title>
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
</head>
<body>
<form id="Form1" method="post" runat="server">
<h1><a href="../index.aspx">后台设置首页</a> >> 友情链接管理</h1>
<table width="100%" >
<tr>
<td class="right">

<div class="main-setting">
<div class="itemtitle"><h3>友情链接管理 </h3>
<ul class="tab1">
<li class="current"><a href="List.aspx"><span>友情链接管理 </span></a></li>
<li><a href="FriendLinkList.aspx"><span>友情链接分类管理</span></a></li>
</ul>
<asp:Button ID="lnkAdd" runat="server" CssClass="addbtn" Text="新增友情链接" OnClick="lnkAdd_Click1" />
</div>

<table class="xy_tb xy_tb2">
<tr>
<td class="content_action">
链接类型：<asp:DropDownList ID="LinkType" runat="server">
<asp:ListItem Value="-1">请选择</asp:ListItem>
<asp:ListItem Value="0">文字链接</asp:ListItem>
<asp:ListItem Value="1">图片链接</asp:ListItem>
</asp:DropDownList>
<asp:Button ID="btnFind" runat="server" CssClass="button" Text="搜索" OnClick="btnFind_Click" /></td>
</tr>
<tr>
<td>
<asp:GridView ID="gvList" HeaderStyle-CssClass="gv_header_style" Width="100%" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvList_RowDataBound" OnRowCommand="gvList_RowCommand" DataKeyNames="FL_ID" GridLines="None">
<Columns>
<asp:BoundField Visible="False" DataField="FL_ID" />
<asp:TemplateField HeaderText="选择">                
<ItemTemplate>
<asp:CheckBox ID="chkExport" runat="server" />
</ItemTemplate>
    <ItemStyle Width="5%" />
</asp:TemplateField>
<asp:TemplateField HeaderText="类型"><ItemTemplate><asp:Label runat="server" Text='<%#GetPic(DataBinder.Eval(Container,"DataItem.FL_Type").ToString()) %>'></asp:Label></ItemTemplate>
    <ItemStyle Width="5%" />
</asp:TemplateField>
<asp:BoundField HeaderText="链接内容" DataField="FL_Font" >
    <ItemStyle Width="20%" CssClass="gvLeft" />
    <HeaderStyle CssClass="gvLeft" />
</asp:BoundField>
<asp:BoundField HeaderText="链接地址" DataField="FL_URL" >
    <ItemStyle Width="20%" CssClass="gvLeft" />
    <HeaderStyle CssClass="gvLeft" />
</asp:BoundField>
<asp:BoundField HeaderText="链接提示" DataField="FL_Alt" >
    <ItemStyle Width="15%" CssClass="gvLeft" />
    <HeaderStyle CssClass="gvLeft" />
</asp:BoundField>
<asp:BoundField HeaderText="链接类别" DataField="FS_Name" >
    <ItemStyle Width="10%" CssClass="gvLeft" />
    <HeaderStyle CssClass="gvLeft" />
</asp:BoundField>
<asp:ButtonField  HeaderText="显示" DataTextField="FL_Flag" CommandName="ChangeFlag" ><ItemStyle CssClass="action" Width="5%" /></asp:ButtonField>
<asp:ButtonField  HeaderText="推荐" DataTextField="FL_IsCommend" CommandName="SetCommend" ><ItemStyle CssClass="action" Width="5%" /></asp:ButtonField>

    <asp:TemplateField HeaderText="编辑">
    <ItemStyle Width="5%" />
        <ItemTemplate>
            <a href='AddNewLink.aspx?id=<%# Eval("FL_ID") %>&backURL=<%# backURL %>'><img src="../images/edit.GIF" alt="编辑" /></a>
        </ItemTemplate>
    </asp:TemplateField>

</Columns>
</asp:GridView>
<p style="text-align:center;"><asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></p>
</td>
</tr>
<tr>
<td class="content_action">
<input id="chkAll" onclick="chkAll_true()" type="checkbox" name="chkAll" runat="server" />全选
<asp:Button ID="lnkDel" runat="server" CssClass="button" Text="删除" OnClick="lnkDel_Click1" />
</td>
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
