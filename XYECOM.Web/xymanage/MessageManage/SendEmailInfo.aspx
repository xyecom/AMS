<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_basic_SendEmailEdit" Codebehind="SendEmailInfo.aspx.cs" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>�����ʼ�����</title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script  language =javascript type ="text/javascript" src ="../javascript/CheckedAll.js"></script>
</head>
<body >
<form id="Form1" method="post" runat="server">
<h1><a href="../index.aspx">��̨������ҳ</a> >> �鿴�����ʼ���Ϣ</h1>
<table  width="100%" >
<tr>
<!-- right -->
<td class="right">
<!--��̨���� -->
    

<!-- ��� -->

<div class="main-setting">

<div class="itemtitle"><h3>�鿴�����ʼ���Ϣ</h3></div>

<table width="100%" class="xy_tb xy_tb2 infotable" id="companyinfo">
<tr >
<th>
    ���⣺</th>
<td><label>
    &nbsp;<asp:Label ID="lbtitle" runat="server"></asp:Label></label></td>
</tr>
<tr>
<th>
    ���ݣ�</th>
<td><label id="LABEL1" runat="server">
    &nbsp;<asp:Label ID="lbcontent" runat="server"></asp:Label></label></td>
</tr>
<tr>
<th>
    ���� ��</th>
<td ><label>
    &nbsp;<asp:Label ID="lbtime" runat="server"></asp:Label></label></td>
</tr>

<tr>
<th></th>
<td>
    <input id="Button1" type="button" value="����"  class ="button" onclick ="window.location.href='SendEmail.aspx';"/></td>
</tr>
</table>

</div>
</td>
</tr>
</table>

</form>
</body>
</html>
