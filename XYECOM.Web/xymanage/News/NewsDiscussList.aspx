<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_news_NewsDiscussList" Codebehind="NewsDiscussList.aspx.cs" %>
<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc2" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>��Ѷ�����б�</title>
    <link href="../css/style.css" type="text/css" rel="Stylesheet" />
    <link href="/common/css/XYLib.css" type="text/css" rel="Stylesheet" />
    <script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
    <script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
</head>
<body>
<form id="NewsDiscussList" runat="server">
<h1><a href="../index.aspx">��̨��ҳ</a> >> ��Ѷ�����б�</h1>
<table width="100%">
<tr>
<td class="right">

<div class="main-setting">
<div class="itemtitle"><h3 id="caption" runat="server">��ǰ��Ѷ�������б�</h3></div>

<table class="xy_tb xy_tb2">
  <tr>
   <td>
   <asp:GridView  ID="gvlist" HeaderStyle-CssClass="gv_header_style" Width="100%" runat="server" AutoGenerateColumns="False" DataKeyNames="ND_ID,NS_ID" GridLines="None" OnRowDataBound="gvlist_RowDataBound" OnRowCommand="gvlist_RowCommand">
   <Columns>
   <asp:BoundField Visible="False" DataField="ND_ID" />
   <asp:TemplateField HeaderText="ѡ��">
   <ItemTemplate>
   <asp:CheckBox ID="chkExport" runat="server" />
   </ItemTemplate>
       <ItemStyle Width="5%" />
   </asp:TemplateField>
   <asp:BoundField HeaderText="�û����" DataField="U_ID" Visible="False" />
   <asp:BoundField HeaderText="�û��ǳ�" DataField="U_Name" >
       <ItemStyle Width="10%" CssClass="gvLeft" />
       <HeaderStyle CssClass="gvLeft" />
   </asp:BoundField>
   <asp:BoundField HeaderText="��������" DataField="ND_Content" >
       <ItemStyle Width="55%" CssClass="gvLeft" />
       <HeaderStyle CssClass="gvLeft" />
   </asp:BoundField>
   <asp:BoundField HeaderText="����ʱ��" DataField="ND_AddTime"  DataFormatString="{0:yyyy-MM-dd}">
       <ItemStyle Width="15%" />
   </asp:BoundField>
   <asp:ButtonField HeaderText="�Ƿ���ʾ" DataTextField="ND_IsShow" CommandName="SetIsShow">
       <ItemStyle Width="10%" />
   </asp:ButtonField>
   <asp:BoundField DataField="NS_ID" Visible="False" HeaderText="��Ѷ���" />
   <asp:HyperLinkField DataNavigateUrlFields="ND_ID,NS_ID" DataNavigateUrlFormatString="NewsDiscussInfo.aspx?ND_ID={0}&amp;NS_ID={1}"
    HeaderText="�鿴" Text="&lt;img src=&quot;../images/look.gif&quot; /&gt;" >
       <ItemStyle Width="5%" />
   </asp:HyperLinkField>
    
   </Columns>
   </asp:GridView>
   <p style="text-align:center;"><asp:Label ID="lblMessage" runat="server" ForeColor="red"></asp:Label></p>
   </td>
  </tr>
  <tr>
  <td class="content_action">
  <input id="chkAll" onclick="chkAll_true()" type="checkbox" name="chkAll" runat="server" />ȫѡ
  <asp:Button ID="lnkDel" runat="server" CssClass="button" Text="ɾ��" OnClick="lnkDel_Click" />
  <asp:Button CssClass="button" ID="btnBack" runat="server" Text="����" OnClick="btnBack_Click"/>
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
