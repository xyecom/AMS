<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_FriendLink_FriendLinkList" Codebehind="FriendLinkList.aspx.cs" %>

<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc2" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>������������б�</title>
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
</head>
<body>
<form id="form1" runat="server">
<h1><a href="../index.aspx">��̨������ҳ</a> >> �������ӹ���</h1>
 <table width="100%">
 <tr>
 <td class="right">

<div class="main-setting">
<div class="itemtitle"><h3>�������ӹ��� </h3>
<ul class="tab1">
<li><a href="List.aspx"><span>�������ӹ��� </span></a></li>
<li class="current"><a href="FriendLinkList.aspx"><span>�������ӷ������</span></a></li>
</ul>
<asp:Button ID="lnkAdd" runat="server" CssClass="addbtn" Text="��������" OnClick="lnkAdd_Click" /> 
</div>



<table class="xy_tb xy_tb2">
  <tr>
  <td>
  <asp:GridView ID="gvlist" HeaderStyle-CssClass="gv_header_style" Width="100%" runat="server" AutoGenerateColumns="False" DataKeyNames="FS_ID" GridLines="None" OnRowDataBound="gvList_RowDataBound">
  <Columns>
  <asp:BoundField Visible="False" DataField="FS_ID" />
  <asp:TemplateField HeaderText="ѡ��">
  <ItemTemplate><asp:CheckBox ID="chkExport" runat="server" /></ItemTemplate>
      <ItemStyle HorizontalAlign="Center" Width="5%" />
  </asp:TemplateField>
<asp:HyperLinkField  DataTextField="FS_Name" HeaderText="��������" DataNavigateUrlFields="FS_ID" DataNavigateUrlFormatString="FriendLinkList.aspx?FS_PID={0}" >
    <ItemStyle HorizontalAlign="Center" CssClass="gvLeft" Width="25%" />
    <HeaderStyle CssClass="gvLeft" />
</asp:HyperLinkField>

  <asp:BoundField HeaderText="����˵��" DataField="FS_Alt" >
      <ItemStyle HorizontalAlign="Center" CssClass="gvLeft" Width="50%" />
      <HeaderStyle CssClass="gvLeft" />
  </asp:BoundField>
  <asp:HyperLinkField DataNavigateUrlFields="FS_ID" FooterStyle-HorizontalAlign="center" DataNavigateUrlFormatString="FriendLinkTypeAdd.aspx?FS_ID={0}&amp;Type=1" HeaderText="�༭" Text='&lt;img src=&quot;../images/edit.GIF&quot; alt=&quot;�༭&quot; /&gt;' >
      <ItemStyle HorizontalAlign="Center" Width="15%"  CssClass="gvLeft"/>
  </asp:HyperLinkField>
  </Columns>
  </asp:GridView>
  <p style="text-align:center;"><asp:Label ID="lblMessage" runat="server" ForeColor="red"></asp:Label></p>
  </td>
  </tr>
  <tr>
  <td class="content_action">
   <input id="chkAll" onclick="chkAll_true()" type="checkbox" name="chkAll" runat="server" />ȫѡ
   <asp:Button ID="lnkDel" runat="server" CssClass="button" Text="ɾ��" OnClick="lnkDel_Click" />&nbsp;
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
