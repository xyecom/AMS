<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_MessageManage_SendMessageInfo" Codebehind="SendMessageInfo.aspx.cs" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>���Ͷ�����ϸ��Ϣ</title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
</head>
<body >
<form id="Form1" method="post" runat="server">
<h1><a href="../index.aspx">��̨������ҳ</a> >> ���Ͷ�����ϸ��Ϣ</h1>
<table  width="100%" >
<tr>
<!-- right -->
<td class="right" style="height: 462px">
<!--��̨���� -->
    


<div class="main-setting">

<div class="itemtitle"><h3>���Ͷ�����ϸ��Ϣ</h3></div>

<table width="100%" class="xy_tb xy_tb2 infotable">
<tr>
<th>
    ���⣺</th>
<td id="username" runat="server"></td>
</tr>
<tr>
<th>���ݣ�</th>
<td id="info" runat="server"></td>
</tr>

<tr>
<th>���� ��</th>
<td id="addtime" runat="server"></td>
</tr>
<tr>
<th>�鿴״̬��</th>
<td id="HasReply" runat="server"></td>
</tr>
<tr>
<th>&nbsp;</th>
<td><label>
    <input id="Button1" class="button" type="button" value="����" onclick="window.location.href='SendMessageList.aspx';" /></label></td>
</tr>
</table>

</div>
</td></tr>
</table>
</form>
</body>
</html>
