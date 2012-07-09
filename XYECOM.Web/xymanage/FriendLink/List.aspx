<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_FriendLink_List" Codebehind="List.aspx.cs" %>

<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc2" %>

<%@ Register Src="../UserControl/top.ascx" TagName="top" TagPrefix="uc1" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>���������б�</title>
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
</head>
<body>
<form id="Form1" method="post" runat="server">
<h1><a href="../index.aspx">��̨������ҳ</a> >> �������ӹ���</h1>
<table width="100%" >
<tr>
<td class="right">

<div class="main-setting">
<div class="itemtitle"><h3>�������ӹ��� </h3>
<ul class="tab1">
<li class="current"><a href="List.aspx"><span>�������ӹ��� </span></a></li>
<li><a href="FriendLinkList.aspx"><span>�������ӷ������</span></a></li>
</ul>
<asp:Button ID="lnkAdd" runat="server" CssClass="addbtn" Text="������������" OnClick="lnkAdd_Click1" />
</div>

<table class="xy_tb xy_tb2">
<tr>
<td class="content_action">
�������ͣ�<asp:DropDownList ID="LinkType" runat="server">
<asp:ListItem Value="-1">��ѡ��</asp:ListItem>
<asp:ListItem Value="0">��������</asp:ListItem>
<asp:ListItem Value="1">ͼƬ����</asp:ListItem>
</asp:DropDownList>
<asp:Button ID="btnFind" runat="server" CssClass="button" Text="����" OnClick="btnFind_Click" /></td>
</tr>
<tr>
<td>
<asp:GridView ID="gvList" HeaderStyle-CssClass="gv_header_style" Width="100%" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvList_RowDataBound" OnRowCommand="gvList_RowCommand" DataKeyNames="FL_ID" GridLines="None">
<Columns>
<asp:BoundField Visible="False" DataField="FL_ID" />
<asp:TemplateField HeaderText="ѡ��">                
<ItemTemplate>
<asp:CheckBox ID="chkExport" runat="server" />
</ItemTemplate>
    <ItemStyle Width="5%" />
</asp:TemplateField>
<asp:TemplateField HeaderText="����"><ItemTemplate><asp:Label runat="server" Text='<%#GetPic(DataBinder.Eval(Container,"DataItem.FL_Type").ToString()) %>'></asp:Label></ItemTemplate>
    <ItemStyle Width="5%" />
</asp:TemplateField>
<asp:BoundField HeaderText="��������" DataField="FL_Font" >
    <ItemStyle Width="20%" CssClass="gvLeft" />
    <HeaderStyle CssClass="gvLeft" />
</asp:BoundField>
<asp:BoundField HeaderText="���ӵ�ַ" DataField="FL_URL" >
    <ItemStyle Width="20%" CssClass="gvLeft" />
    <HeaderStyle CssClass="gvLeft" />
</asp:BoundField>
<asp:BoundField HeaderText="������ʾ" DataField="FL_Alt" >
    <ItemStyle Width="15%" CssClass="gvLeft" />
    <HeaderStyle CssClass="gvLeft" />
</asp:BoundField>
<asp:BoundField HeaderText="�������" DataField="FS_Name" >
    <ItemStyle Width="10%" CssClass="gvLeft" />
    <HeaderStyle CssClass="gvLeft" />
</asp:BoundField>
<asp:ButtonField  HeaderText="��ʾ" DataTextField="FL_Flag" CommandName="ChangeFlag" ><ItemStyle CssClass="action" Width="5%" /></asp:ButtonField>
<asp:ButtonField  HeaderText="�Ƽ�" DataTextField="FL_IsCommend" CommandName="SetCommend" ><ItemStyle CssClass="action" Width="5%" /></asp:ButtonField>

    <asp:TemplateField HeaderText="�༭">
    <ItemStyle Width="5%" />
        <ItemTemplate>
            <a href='AddNewLink.aspx?id=<%# Eval("FL_ID") %>&backURL=<%# backURL %>'><img src="../images/edit.GIF" alt="�༭" /></a>
        </ItemTemplate>
    </asp:TemplateField>

</Columns>
</asp:GridView>
<p style="text-align:center;"><asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></p>
</td>
</tr>
<tr>
<td class="content_action">
<input id="chkAll" onclick="chkAll_true()" type="checkbox" name="chkAll" runat="server" />ȫѡ
<asp:Button ID="lnkDel" runat="server" CssClass="button" Text="ɾ��" OnClick="lnkDel_Click1" />
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
