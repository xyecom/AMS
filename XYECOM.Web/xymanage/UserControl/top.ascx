<%@ Control Language="C#" AutoEventWireup="true" Inherits="xymanage_UserControl_top" Codebehind="top.ascx.cs" %>
<table width="100%" border="0" cellspacing="0" cellpadding="0"class="head_nav">
  <tr>
    <td class="head_wel">欢迎 <asp:Label id="lblAdminName" runat="server" ForeColor="Red"></asp:Label>!</td>
	<td  class="head_right"> <a href="../index.aspx" class="head_button">首页</a><a href="#"  class="head_button">基本信息管理</a><a href="#"  class="head_button">商业信息管理</a><a href="/xymanage/outlogin.aspx" target="_parent" class="head_button">退出系统</a></td>
  </tr>
</table>
