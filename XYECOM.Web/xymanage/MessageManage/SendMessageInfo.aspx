<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_MessageManage_SendMessageInfo" Codebehind="SendMessageInfo.aspx.cs" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>发送短信详细信息</title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
</head>
<body >
<form id="Form1" method="post" runat="server">
<h1><a href="../index.aspx">后台管理首页</a> >> 发送短信详细信息</h1>
<table  width="100%" >
<tr>
<!-- right -->
<td class="right" style="height: 462px">
<!--后台导航 -->
    


<div class="main-setting">

<div class="itemtitle"><h3>发送短信详细信息</h3></div>

<table width="100%" class="xy_tb xy_tb2 infotable">
<tr>
<th>
    标题：</th>
<td id="username" runat="server"></td>
</tr>
<tr>
<th>内容：</th>
<td id="info" runat="server"></td>
</tr>

<tr>
<th>日期 ：</th>
<td id="addtime" runat="server"></td>
</tr>
<tr>
<th>查看状态：</th>
<td id="HasReply" runat="server"></td>
</tr>
<tr>
<th>&nbsp;</th>
<td><label>
    <input id="Button1" class="button" type="button" value="返回" onclick="window.location.href='SendMessageList.aspx';" /></label></td>
</tr>
</table>

</div>
</td></tr>
</table>
</form>
</body>
</html>
