<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_MessageManage_SendMessageList" Codebehind="SendMessageList.aspx.cs" %>

<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc1" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>�������Ź���</title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script language ="javascript" type ="text/javascript" src ="../javascript/CheckedAll.js"></script>
</head>
<body>
<form id="Form1" method="post" runat="server">
<h1><a href="../index.aspx">��̨������ҳ</a> >> �������Ź���</h1>
<table  width="100%" >
<tr>
<td class="right">


<div class="main-setting">
<div class="itemtitle"><h3>վ�ڶ���</h3>
    <ul class="tab1" id="mainMenus0">
            <li><a href="ReceiveEmail.aspx"><span>�ռ���</span></a></li>
            <li class="current"><a href="#"><span>������</span></a></li>
            <li><a href="SendMessageAdd.aspx"><span>������Ϣ</span></a></li>
        </ul>
</div>

<table class="xy_tb xy_tb2">
<tr>
<td>
<asp:GridView ID="gvlist" HeaderStyle-CssClass="gv_header_style" runat="server" AutoGenerateColumns="False"  DataKeyNames="M_ID"  Width="100%"  PageSize="20" GridLines="None" OnRowDataBound="gvlist_RowDataBound"  >
<Columns>
<asp:BoundField DataField="M_ID" HeaderText="M_ID" Visible="False" />
<asp:TemplateField HeaderText="ѡ��">                
<ItemTemplate>
<asp:CheckBox ID="chkExport" runat="server" />
</ItemTemplate>
    <ItemStyle Width="5%" />
</asp:TemplateField>
<asp:BoundField DataField="M_Title" HeaderText="���Ա���"  >
    <HeaderStyle CssClass="gvLeft" />
    <ItemStyle CssClass="gvLeft" Width="65%" />
</asp:BoundField>
    <asp:BoundField DataField="M_AddTime" HeaderText="����ʱ��" DataFormatString="{0:yyyy-MM-dd}">
    <ItemStyle Width="15%" />
    </asp:BoundField>
    <asp:BoundField DataField="M_HasReply" HeaderText="״̬" >
        <ItemStyle Width="10%" />
    </asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="M_ID" DataNavigateUrlFormatString="SendMessageInfo.aspx?M_ID={0}" HeaderText="�鿴" Text="&lt;img src=&quot;../images/look.gif&quot; /&gt;" >
    <ItemStyle Width="5%" />
</asp:HyperLinkField>
</Columns>
</asp:GridView>
<p style="text-align:center;"><asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label></p>
</td>
</tr>
<tr>
<td class="content_action">
<input id="chkAll" onclick="chkAll_true()" type="checkbox" name="chkAll" runat="server" />ȫѡ&nbsp;<asp:Button
    ID="Button2" runat="server" Text="ɾ��"  CssClass ="button" OnClick="Button2_Click"/>
    </td>
</tr>
</table>
<uc1:page ID="Page1" runat="server"/>
</div>
</td>
</tr>
</table> 

</form>
</body>
</html>
