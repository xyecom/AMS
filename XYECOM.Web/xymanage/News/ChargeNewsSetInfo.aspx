<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_news_ChargeNewsSetInfo" Codebehind="ChargeNewsSetInfo.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
 <title>�����շ���Ѷ��Ϣ</title>
 <link type="text/css" href="../css/style.css" rel="stylesheet" />
 <link href="/common/css/XYLib.css" type="text/css" rel="Stylesheet" />
 <script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
</head>
<body>
<form id="form1" runat="server">
 <h1><a href="../index.aspx">��̨������ҳ</a> >> �����շ���Ѷ��Ϣ</h1>
<table width="100%">
<tr>
 <td class="right">
 
<div class="main-setting">
<div class="itemtitle"><h3>�����շ���Ѷ��Ϣ</h3></div>
  
  <table class="xy_tb xy_tb2">
<tr class="nobg">
  <td colspan="2" class="td27">���⣺</td>
</tr>
<tr>
   <td class="vtop rowform">
     <asp:Label ID="tbnewstitle" runat="server"></asp:Label><input type="hidden" runat="server" id="nsid" />
   </td>
   <td class="vtop tips2"></td>
</tr>

  <tr>
  <td colspan="2">
  <asp:PlaceHolder ID="phMain" runat="server"></asp:PlaceHolder>
     <asp:Button ID="btadd" runat="server" CssClass="button" Text="ȷ��" OnClick="btadd_Click"/>
     <input class="button" type="button" value="����" id="Button1" runat="server" />
  </td>
  </tr>
  </table>
  </div>
 </td>
</tr>
</table>
</form>
</body>
</html>
