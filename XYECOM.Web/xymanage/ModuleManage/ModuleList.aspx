<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_ModuleManage_ModuleList" Codebehind="ModuleList.aspx.cs" %>

<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>自定义字段管理</title>
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
</head>
<body>
<form id="Form1" method="post" runat="server">
<h1><a href="../index.aspx">后台设置首页</a> >> 自定义模块管理</h1>
<table width="100%" >
<tr>
<td class="right">

<div class="main-setting">
<div class="itemtitle"><h3>自定义模块管理</h3>

</div>

<table class="xy_tb xy_tb2">
<tr>
<td>
<asp:GridView ID="gvList" HeaderStyle-CssClass="gv_header_style" Width="100%" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvList_RowDataBound" DataKeyNames="EName,PEName" GridLines="None" OnRowCommand="gvList_RowCommand">
<Columns>
<asp:BoundField HeaderText="模块英文名" DataField="SEName" >
    <HeaderStyle CssClass="gvLeft" />
    <ItemStyle Width="15%" CssClass="gvLeft"  />
</asp:BoundField>
<asp:BoundField HeaderText="模块中文名" DataField="CName" >
<HeaderStyle CssClass="gvLeft" />
    <ItemStyle Width="15%" CssClass="gvLeft"  />
</asp:BoundField>
    <asp:BoundField HeaderText="模块说明" DataField="Description">
    <HeaderStyle CssClass="gvLeft" />
    <ItemStyle Width="25%" CssClass="gvLeft"  />
    </asp:BoundField>
    <asp:BoundField DataField="PCName" HeaderText="父模块名称" >
    <HeaderStyle CssClass="gvLeft" />
    <ItemStyle Width="10%"  CssClass="gvLeft" /></asp:BoundField>
    <asp:BoundField HeaderText="排序" DataField="Order" Visible="False" />
    <asp:HyperLinkField HeaderText="创建子模块" >
        <ItemStyle Width="10%" />
    </asp:HyperLinkField>
    <asp:HyperLinkField HeaderText="模板管理" >
        <ItemStyle Width="10%" />
    </asp:HyperLinkField>
    <asp:TemplateField HeaderText="状态" ShowHeader="False">
        <ItemTemplate>
            <asp:LinkButton CommandArgument='<%# Eval("EName") %>' ID="btnState" runat="server" CausesValidation="false" CommandName="state"
                OnClick="btnState_Click" Text='<%# "true" == Eval("State").ToString().ToLower() ? "启用" : "停止" %>'></asp:LinkButton>
        </ItemTemplate>
        <ItemStyle Width="5%" />
    </asp:TemplateField>
    <asp:HyperLinkField DataNavigateUrlFields="EName" DataNavigateUrlFormatString="ModuleEdit.aspx?EName={0}"
        HeaderText="编辑" Text="编辑" >
        <ItemStyle Width="5%" />
    </asp:HyperLinkField>
    <asp:ButtonField CommandName="del" HeaderText="删除" Text="删除" >
        <ItemStyle Width="5%" />
    </asp:ButtonField>
</Columns>
</asp:GridView>
<p style="text-align:center;"><asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></p>
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
