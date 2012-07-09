<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MoreText.aspx.cs" Inherits="XYECOM.Web.xymanage.VoteManage.MoreText" %>

<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>提交文本列表</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
    <script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
</head>
<body>
    <form id="form1" runat="server">
<div class="main-setting">
<div class="itemtitle"><h3>提交文本列表</h3>
<ul id="mainMenus0" runat="server" class="tab1">
<li>【 <asp:Label ID="lblVoteTitle" runat="server"></asp:Label>  >  <asp:Label ID="lblSubjectText" runat="server"></asp:Label> 】</li>
</ul>
</div>


<table class="xy_tb xy_tb2">
<tr>
<td>
<asp:GridView ID="gvList" HeaderStyle-CssClass="gv_header_style" Width="100%" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvList_RowDataBound" DataKeyNames="TextId" GridLines="None">
<Columns>
<asp:BoundField Visible="False" DataField="TextId" >
    <ItemStyle Width="1%" VerticalAlign="Top"/>
</asp:BoundField>
<asp:TemplateField HeaderText="选择"> 
    <ItemTemplate>
    <asp:CheckBox ID="chkExport" runat="server" />    
    </ItemTemplate>
    <ItemStyle Width="5%" VerticalAlign="Top"/>
</asp:TemplateField>

<asp:BoundField HeaderText="内容" DataField="Body" >
    <ItemStyle Width="95%" CssClass="gvLeft" VerticalAlign="Top"/>
    <HeaderStyle  CssClass="gvLeft" Width="95%" />
</asp:BoundField>

   
</Columns>
</asp:GridView>
<p style="text-align:center;"><asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></p>
</td>
</tr>
<tr>
<td class="content_action"><input id="chkAll" onclick="chkAll_true()" type="checkbox" name="chkAll" runat="server" />全选
    <asp:Button ID="btndelete" runat="server" CssClass="button" OnClick="btnDelete_Click"
        Text="删除" />
     <input type="button"  class="button" value="关闭" onclick="window.close();" />
     <input type="button" class="button" value="打印" onclick="window.print();" />
    </td>
</tr>
</table>
    <uc1:page ID="page1" runat="server" />
</div>

    </form>
</body>
</html>