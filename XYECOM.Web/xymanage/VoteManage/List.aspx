<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="XYECOM.Web.xymanage.VoteManage.List" %>

<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>网上调查管理</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
    <script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
</head>
<body>
    <form id="form1" runat="server">
<h1><a href="../index.aspx">后台管理首页</a> >> 网上调查列表</h1>
<div class="main-setting">
<div class="itemtitle"><h3>网上调查列表</h3>
<ul id="mainMenus0" runat="server" class="tab1">
</ul>
<input type="button" class="addbtn" value="新增调查" onclick="location='AddVote.aspx';" />

</div>


<table class="xy_tb xy_tb2">
<tr>
<td>
<asp:GridView ID="gvList" HeaderStyle-CssClass="gv_header_style" Width="100%" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvList_RowDataBound" DataKeyNames="VoteId" GridLines="None">
<Columns>
<asp:BoundField Visible="False" DataField="Voteid" >
    <ItemStyle Width="1%" />
</asp:BoundField>
<asp:TemplateField HeaderText="选择"> 
    <ItemTemplate>
    <asp:CheckBox ID="chkExport" runat="server" />    
    </ItemTemplate>
    <ItemStyle Width="5%" />
</asp:TemplateField>

<asp:BoundField HeaderText="调查标题" DataField="Title" >
    <ItemStyle Width="55%" CssClass="gvLeft"/>
    <HeaderStyle  CssClass="gvLeft" Width="55%" />
</asp:BoundField>

<asp:TemplateField HeaderText="问题管理" >
    <ItemStyle Width="10%"  />
    <ItemTemplate>
        <a href='SubjectManage.aspx?VoteId=<%# Eval("VoteId") %>&backURL=<%# backURL %>'>问题管理</a>
    </ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="结果分析" >
    <ItemStyle Width="10%"  />
    <ItemTemplate>
        <a href='VoteResult.aspx?VoteId=<%# Eval("VoteId") %>&backURL=<%# backURL %>'>结果分析</a>
    </ItemTemplate>
</asp:TemplateField>

        
   <asp:TemplateField HeaderText="预览">
    <ItemStyle Width="10%" />
        <ItemTemplate>
            <a href="<%#GetViewHref(DataBinder.Eval(Container,"DataItem.VoteId").ToString()) %>" target="_blank">预览</a>
        </ItemTemplate>
    </asp:TemplateField> 
    
   <asp:TemplateField HeaderText="修改">
    <ItemStyle Width="10%" />
        <ItemTemplate>
            <a href='EditVote.aspx?VoteId=<%# Eval("VoteId") %>&backURL=<%# backURL %>'><img src="../images/look.GIF" alt="修改" /></a>
        </ItemTemplate>
    </asp:TemplateField>    
        
</Columns>
</asp:GridView>
<p style="text-align:center;"><asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></p>
</td>
</tr>
<tr>
<td class="content_action"><input id="chkAll" onclick="chkAll_true()" type="checkbox" name="chkAll" runat="server" />全选
    <asp:Button ID="btndelete" runat="server" CssClass="button" OnClick="btnDelete_Click"
        Text="删除" />
    </td>
</tr>
</table>
    <uc1:page ID="page1" runat="server" />
</div>

    </form>
</body>
</html>