<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Info.aspx.cs" Inherits="XYECOM.Web.xymanage.Ranking.Info" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="../css/cue.css" type="text/css" rel="stylesheet" />
    <script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
    <script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js" ></script>
    <script type="text/javascript" src="/common/js/date.js" ></script>
</head>
<body>
    <form id="form1" runat="server">
<h1><a href="../index.aspx">后台管理首页</a> &gt;&gt; 排名详细信息</h1>
    <table width="100%">
<tr>
<td class="right">

<div class="main-setting">
<div class="itemtitle"><h3>排名详细信息</h3>
</div>

<table width="100%" class="xy_tb xy_tb2 infotable border_buttom0" id="companyinfo">
<tr>
<th>关键词：</th>
<td><asp:Label runat="server" ID="lblKeyword"></asp:Label>      </td>
</tr>
<tr>
<th>名次：</th>
<td><asp:Label runat="server" ID="lblRank"></asp:Label></td>
</tr>
<tr>
<th>企业名称：</th>
<td><asp:Label runat="server" ID="lblUserName"></asp:Label></td>
</tr>
<tr>
<th>开始时间：</th>
<td><asp:Label runat="server" ID="lblBeginTime"></asp:Label></td>
</tr>

<tr>
<th> 结束时间 ：</th>
<td> 
<input id="txtEndTime" type="text" runat="server" onclick="getDateString(this);" maxlength="10" style="width: 75px;" readonly="readonly"/> <br/>
结束时间 <= 操作时间,则当前排名立即结束，结束时间 > 操作时间，则当前排名将延长有效期
</td>
</tr>

<tr>
<th>&nbsp;</th>
<td><asp:Button ID="btnOK" runat="server" CssClass="button" Text="确定" OnClick="btnOK_Click"/>
       <asp:Button ID="btnBack" runat="server" CssClass="button" OnClick="btnBack_Click"
           Text="返回" /></td>
</tr>
</table>
 </div>
 </td>
 </tr>
 </table>

    </form>
</body>
</html>
