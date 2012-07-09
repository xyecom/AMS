<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubjectManage.aspx.cs" Inherits="XYECOM.Web.xymanage.VoteManage.SubjectManage" %>

<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>调查问题管理</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
    <script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
</head>
<body>
    <form id="form1" runat="server">
<h1><a href="../index.aspx">后台管理首页</a> >> 调查问题管理</h1>
<div class="main-setting">
<div class="itemtitle"><h3>调查问题管理</h3>
<ul id="mainMenus0" runat="server" class="tab1">
<li>【 主题：<asp:Label ID="lblVoteTitle" runat="server"></asp:Label>】</li>
</ul>
<input type="button" class="addbtn" value="新增问题" onclick="location='AddSubject.aspx?voteid=<%=VoteId%>&backURL1=<%=backURL1%>';" />

</div>


<table class="xy_tb xy_tb2">
<tr>
<td>
<asp:GridView ID="gvList" HeaderStyle-CssClass="gv_header_style" Width="100%" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvList_RowDataBound" DataKeyNames="SubjectId" GridLines="None">
<Columns>
<asp:BoundField Visible="False" DataField="SubjectId" >
    <ItemStyle Width="1%" />
</asp:BoundField>
<asp:TemplateField HeaderText="选择"> 
    <ItemTemplate>
    <asp:CheckBox ID="chkExport" runat="server" />    
    </ItemTemplate>
    <ItemStyle Width="5%" VerticalAlign="Top"/>
</asp:TemplateField>

<asp:BoundField HeaderText="问题" DataField="Subject" >
    <ItemStyle Width="40%" CssClass="gvLeft" VerticalAlign="Top"/>
    <HeaderStyle  CssClass="gvLeft" Width="40%" />
</asp:BoundField>


<asp:TemplateField HeaderText="类型">
    <ItemStyle Width="10%" VerticalAlign="Top"/>
        <ItemTemplate>
            <%#GetTypeName(DataBinder.Eval(Container,"DataItem.Type").ToString()) %>
        </ItemTemplate>
    </asp:TemplateField> 
    

<asp:TemplateField HeaderText="选项" >
    <ItemStyle Width="30%" VerticalAlign="Top"/>
    <ItemTemplate>
         <%#GetOptions(DataBinder.Eval(Container,"DataItem.Type").ToString(),DataBinder.Eval(Container,"DataItem.SubjectId").ToString()) %>
    </ItemTemplate>
</asp:TemplateField>

        
   <asp:TemplateField HeaderText="修改">
    <ItemStyle Width="10%" VerticalAlign="Top"/>
        <ItemTemplate>
            <a href='EditSubject.aspx?VoteId=<%=VoteId%>&SubjectId=<%# Eval("SubjectId") %>&backURL=<%# backURL %>&backURL1=<%=backURL1%>'><img src="../images/look.GIF" alt="修改" /></a>
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
     <input type="button"  class="button" type="button" value="返回" onclick="location.href='<%=backURL%>';" />
    </td>
</tr>
</table>
    <uc1:page ID="page1" runat="server" />
</div>

    </form>
</body>
</html>