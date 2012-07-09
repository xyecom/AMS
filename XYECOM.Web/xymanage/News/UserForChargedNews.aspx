<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_news_UserForChargedNews" Codebehind="UserForChargedNews.aspx.cs" %>

<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>�շ���Ѷ������Ϣ�б�</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/XYLib.css" type="text/css" rel="Stylesheet" />
    <script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
    <script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
</head>
<body>
  <form id="form1" runat="server">
    <h1><a href="../index.aspx">��̨������ҳ</a> >>�շ���Ѷ������Ϣ����</h1>
  <table width="100%">
  <tr>
  <td class="right">

  
<div class="main-setting">
<div class="itemtitle"><h3>�շ���Ѷ������Ϣ����</h3>
<ul id="mainMenus0" runat="server" class="tab1">
</ul>
</div>

<table class="xy_tb xy_tb2" style="margin-top:0px;">

  <tr>
     <td> 
     ��Ѷ����:&nbsp;<input runat="Server" id="tbnewstitle" type="text" class="input" />
     ��˾����:&nbsp;<input runat="Server" id="tbcompanyname" type="text" class="input" />
     <asp:Button runat="server" ID="find" CssClass="button" Text="�� ��" OnClick="find_Click" /></td>
  </tr>
  <tr>
  <td>
   <asp:GridView ID="gvlist" HeaderStyle-CssClass="gv_header_style" Width="100%" runat="server" AutoGenerateColumns="False" DataKeyNames="CI_ID" GridLines="None" OnRowDataBound="gvlist_RowDataBound">
   <Columns>
   <asp:BoundField Visible="False" DataField="CI_ID" />
   <asp:BoundField Visible="False" DataField="NS_ID" />
   <asp:BoundField DataField="NS_NewsName" HeaderText="��Ѷ����" >
       <ItemStyle Width="50%" CssClass="gvLeft" />
       <HeaderStyle CssClass="gvLeft" />
   </asp:BoundField>
   <asp:TemplateField HeaderText="��Ѷ����"><ItemTemplate><asp:Label runat="server" ID="labelnstype" Text='<%#GetNewsType(DataBinder.Eval(Container,"DataItem.NS_Type").ToString())%>'></asp:Label></ItemTemplate>
       <ItemStyle Width="10%" />
   </asp:TemplateField>
   <asp:BoundField Visible="False" DataField="U_ID" />
   <asp:BoundField DataField="UI_Name" HeaderText="�û�����" >
       <ItemStyle Width="20%" />
   </asp:BoundField>
   <asp:BoundField DataField="UG_Name" HeaderText="�û��ȼ�" >
       <ItemStyle Width="10%" />
   </asp:BoundField>
   <asp:TemplateField HeaderText="����ʱ��"><ItemTemplate><asp:Label ID="labeltime" runat="server" Text='<%#GetDateTime(DataBinder.Eval(Container,"DataItem.CI_AddTime").ToString())%>'></asp:Label></ItemTemplate>
       <ItemStyle Width="10%" />
   </asp:TemplateField>
   </Columns>
   </asp:GridView>
   <p style="text-align:center;"><asp:Label ID="lblMessage" runat="server" ForeColor="red"></asp:Label></p>
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
