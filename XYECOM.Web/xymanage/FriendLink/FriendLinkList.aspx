<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_FriendLink_FriendLinkList" Codebehind="FriendLinkList.aspx.cs" %>

<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc2" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>友情链接类别列表</title>
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
</head>
<body>
<form id="form1" runat="server">
<h1><a href="../index.aspx">后台设置首页</a> >> 友情链接管理</h1>
 <table width="100%">
 <tr>
 <td class="right">

<div class="main-setting">
<div class="itemtitle"><h3>友情链接管理 </h3>
<ul class="tab1">
<li><a href="List.aspx"><span>友情链接管理 </span></a></li>
<li class="current"><a href="FriendLinkList.aspx"><span>友情链接分类管理</span></a></li>
</ul>
<asp:Button ID="lnkAdd" runat="server" CssClass="addbtn" Text="新增分类" OnClick="lnkAdd_Click" /> 
</div>



<table class="xy_tb xy_tb2">
  <tr>
  <td>
  <asp:GridView ID="gvlist" HeaderStyle-CssClass="gv_header_style" Width="100%" runat="server" AutoGenerateColumns="False" DataKeyNames="FS_ID" GridLines="None" OnRowDataBound="gvList_RowDataBound">
  <Columns>
  <asp:BoundField Visible="False" DataField="FS_ID" />
  <asp:TemplateField HeaderText="选择">
  <ItemTemplate><asp:CheckBox ID="chkExport" runat="server" /></ItemTemplate>
      <ItemStyle HorizontalAlign="Center" Width="5%" />
  </asp:TemplateField>
<asp:HyperLinkField  DataTextField="FS_Name" HeaderText="分类名称" DataNavigateUrlFields="FS_ID" DataNavigateUrlFormatString="FriendLinkList.aspx?FS_PID={0}" >
    <ItemStyle HorizontalAlign="Center" CssClass="gvLeft" Width="25%" />
    <HeaderStyle CssClass="gvLeft" />
</asp:HyperLinkField>

  <asp:BoundField HeaderText="分类说明" DataField="FS_Alt" >
      <ItemStyle HorizontalAlign="Center" CssClass="gvLeft" Width="50%" />
      <HeaderStyle CssClass="gvLeft" />
  </asp:BoundField>
  <asp:HyperLinkField DataNavigateUrlFields="FS_ID" FooterStyle-HorizontalAlign="center" DataNavigateUrlFormatString="FriendLinkTypeAdd.aspx?FS_ID={0}&amp;Type=1" HeaderText="编辑" Text='&lt;img src=&quot;../images/edit.GIF&quot; alt=&quot;编辑&quot; /&gt;' >
      <ItemStyle HorizontalAlign="Center" Width="15%"  CssClass="gvLeft"/>
  </asp:HyperLinkField>
  </Columns>
  </asp:GridView>
  <p style="text-align:center;"><asp:Label ID="lblMessage" runat="server" ForeColor="red"></asp:Label></p>
  </td>
  </tr>
  <tr>
  <td class="content_action">
   <input id="chkAll" onclick="chkAll_true()" type="checkbox" name="chkAll" runat="server" />全选
   <asp:Button ID="lnkDel" runat="server" CssClass="button" Text="删除" OnClick="lnkDel_Click" />&nbsp;
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
