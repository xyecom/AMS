<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_basic_ReceiveEmaiinfo" Codebehind="ReceiveEmaiinfo.aspx.cs" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>�յ�������ϸ��Ϣ</title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script language ="javascript" src ="../javascript/CheckedAll.js" type ="text/javascript" >function Button1_onclick() {

}

</script>
</head>
<body >
<form id="Form1" method="post" runat="server">
<h1><a href="../index.aspx">��̨������ҳ</a> >> �յ�������ϸ��Ϣ</h1>
<table  width="100%" >
<tr>
<!-- right -->
<td class="right">
<!--��̨���� -->
    



<div class="main-setting">

<div class="itemtitle"><h3>�յ�������ϸ��Ϣ</h3></div>

<table width="100%" class="xy_tb xy_tb2 infotable border_buttom0" id="companyinfo">
<tr>
<th>��ϵ�ˣ�</th>
<td id="username" runat="server"></td>
</tr>
<tr>
<th>��ϵ�绰��</th>
<td id="phone" runat="server"></td>
</tr>
<tr>
<th>�ֻ���</th>
<td id="moblie" runat="server"></td>
</tr>
<tr>
<th>���ݣ�</th>
<td id="info" runat="server"></td>
</tr>

<tr>
<th>
    ���� ��</th>
<td id="addtime" runat="server"></td>
</tr>

<tr>
<th>&nbsp;</th>
<td><label>
    <asp:Button ID="btn_back" runat="server" CssClass="button" 
        Text="����" OnClick="btn_back_Click" /></label>
        
        <input id="U_ID" runat="server" type="hidden" />
        </td>
</tr>
</table>

<br/>
<div class="itemtitle"><h3>�ظ�����</h3></div>
<table width="100%" class="xy_tb xy_tb2 infotable border_buttom0" id="Table1">

<tr>
<th>
    ���⣺</th>
<td  runat="server">
    <asp:TextBox ID="title" runat="server" Width="442px"  MaxLength ="900" ReadOnly="True"></asp:TextBox></td>
</tr>
<tr>
<th>
    ���ݣ�</th>
<td  runat="server">
    <asp:TextBox ID="content" runat="server" Height="160px" TextMode="MultiLine" Width="443px"  MaxLength ="1500"></asp:TextBox></td>
</tr>
<tr>
<th style="height: 40px">&nbsp;</th>
<td style="height: 40px">
    <asp:Button ID="Button3" runat="server" Text="ȷ��"  CssClass ="button" OnClick="Button3_Click"/><asp:Button ID="btn_back2" runat="server" CssClass="button" 
        Text="ȡ��" OnClick="btn_back2_Click" /></td>
</tr>
</table>

</div>

</td>
</tr>
</table>
</form>
</body>
</html>
