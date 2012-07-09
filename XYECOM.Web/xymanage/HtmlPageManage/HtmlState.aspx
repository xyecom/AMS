<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HtmlState.aspx.cs" Inherits="XYECOM.Web.xymanage.HtmlPageManage.HtmlState" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>静态页面管理状态查看</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="../css/cue.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="/Common/js/base.js" language="javascript"></script>
    <script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
    <script type="text/javascript" src="/common/js/date.js" ></script>
    <script type="text/javascript" src="../javascript/templates.js" ></script>
</head>
<body>
    <form id="form1" runat="server">
    <h1><a href="../index.aspx">后台管理首页</a> >> 静态页面管理状态查看</h1>
<table width="100%" >
<tr>
<td class="right">

<div class="main-setting">
<div class="itemtitle">
<h3>静态页面管理</h3>
<ul id="mainMenus0" runat="server" class="tab1">
<li><a href='HTMLSet.aspx'><span>相关设置</span></a></li>
<li><a href='HtmlManage.aspx'><span>添加任务</span></a></li>
<li class="current"><a href='HtmlState.aspx'><span>任务状态查看</span></a></li>
</ul>


</div>
<div style="float:right;">
<input id="btnRefurbish" class="button" type="button" value="刷新" onclick="location.reload();" />
</div>
<table class="xy_tb xy_tb2">
    <tr>
        <td id="htmlstate">
            
        </td>
    </tr>
</table>
    <asp:Literal ID="litscript" runat="server"></asp:Literal>
</div>
</td>
</tr></table>
    </form>
</body>
</html>
