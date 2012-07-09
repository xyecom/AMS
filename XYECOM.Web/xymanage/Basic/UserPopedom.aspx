<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_basic_UserPopedom" Codebehind="UserPopedom.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>权限设置</title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<style>
    .ddd table td{ width:20%;}
</style>
</head>
<body>
<form id="Form1" method="post" runat="server">
<h1><a href="../index.aspx">后台管理首页</a> >> 权限设置</h1>
<table  width="100%" >
<tr>
<td class="right">

<div class="main-setting">
<div class="itemtitle"><h3>权限设置</h3>
</div>

<table class="xy_tb xy_tb2">
<tr class="nobg">
  <td class="td27">基本权限：</td>
</tr>
<tr>
   <td class="vtop">    
    <asp:CheckBoxList ID="cblbasic" runat="server" RepeatColumns="5" Width="100%">
        <asp:ListItem Value="basic">系统基本配置</asp:ListItem>
        <asp:ListItem Value="sysadmin">管理员管理</asp:ListItem>
        <asp:ListItem Value="filterkeyword">过滤字管理</asp:ListItem>
        <asp:ListItem Value="hotkeyword">热门关键字管理</asp:ListItem>
        <asp:ListItem Value="area">地区信息设置</asp:ListItem>
        <asp:ListItem Value="customconfigfield">自定义配置字段</asp:ListItem>
        <asp:ListItem Value="areasite">地方站管理</asp:ListItem>
        <asp:ListItem Value="trade">行业管理</asp:ListItem>
        <asp:ListItem Value="ads">广告管理</asp:ListItem>
        <asp:ListItem Value="rank">排名管理</asp:ListItem>
        <asp:ListItem Value="custom">用户自定义内容管理</asp:ListItem>
        <asp:ListItem Value="friendlink">友情链接管理</asp:ListItem>
    </asp:CheckBoxList>
   </td><!--<asp:ListItem Value="b_SearchKey">搜索关键字管理</asp:ListItem>--><!---->     
</tr>

<tr class="nobg">
  <td class="td27">商业信息权限设置：</td>
</tr>
<tr>
   <td class="vtop">    
    <asp:CheckBoxList ID="cblbusiness" runat="server" RepeatColumns="5" Width="100%">
        <asp:ListItem Value="typemanage">信息分类管理</asp:ListItem>
        <asp:ListItem Value="ExpressMessage">快速留言设置</asp:ListItem>
        <asp:ListItem Value="offer">供求信息管理</asp:ListItem>
        <asp:ListItem Value="venture">加工信息管理</asp:ListItem>
        <asp:ListItem Value="investment">招商代理信息管理</asp:ListItem>
        <asp:ListItem Value="service">服务信息管理</asp:ListItem>
        <asp:ListItem Value="exhibition">展会信息管理</asp:ListItem>
        <asp:ListItem Value="brand">品牌管理</asp:ListItem>
        <asp:ListItem Value="engageinfo">招聘管理</asp:ListItem>
        <asp:ListItem Value="order">交易管理</asp:ListItem>
        <asp:ListItem Value="Wikipedia">百科分类管理</asp:ListItem>
        <asp:ListItem Value="lemma">词条管理</asp:ListItem>
    </asp:CheckBoxList>
   </td>
</tr>

<tr class="nobg">
  <td class="td27">资讯管理权限设置：</td>
</tr>
<tr>
   <td class="vtop">    
    <asp:CheckBoxList ID="cblnews" runat="server" RepeatColumns="5" Width="100%">
        <asp:ListItem Value="news">普通资讯管理</asp:ListItem>
        <asp:ListItem Value="chargenews">收费资讯管理</asp:ListItem>
        <asp:ListItem Value="newscomment">评论管理</asp:ListItem>
        <asp:ListItem Value="usernews">企业资讯管理</asp:ListItem>
        <asp:ListItem Value="topic">专题管理</asp:ListItem>
    </asp:CheckBoxList>
   </td>
</tr>

<tr class="nobg">
  <td class="td27">用户权限设置：</td>
</tr>
<tr>
   <td class="vtop">    
    <asp:CheckBoxList ID="cbluser" runat="server" RepeatColumns="5" Width="100%">
        <asp:ListItem Value="user">企业用户管理</asp:ListItem>
        <asp:ListItem Value="individual">个人用户管理</asp:ListItem>
        <asp:ListItem Value="userGrade">用户等级管理</asp:ListItem>
        <asp:ListItem Value="userType">企业分类管理</asp:ListItem>
        <asp:ListItem Value="businessmode">经营模式管理</asp:ListItem>
        <asp:ListItem Value="certificate">证书信息设置</asp:ListItem>
        
        <asp:ListItem Value="payMethod">支付方式管理</asp:ListItem>
        <asp:ListItem Value="finance">财务管理</asp:ListItem>
        <asp:ListItem Value="invoice">发票信息管理</asp:ListItem>
        <asp:ListItem Value="remit">汇款确认信息管理</asp:ListItem>        
    </asp:CheckBoxList>
   </td>
</tr>

<tr class="nobg">
  <td class="td27">模板标签权限设置：</td>
</tr>
<tr>
   <td class="vtop">    
    <asp:CheckBoxList ID="cbllable" runat="server" RepeatColumns="5" Width="100%">
        <asp:ListItem Value="template">模板管理</asp:ListItem>
        <asp:ListItem Value="module">自定义模块管理</asp:ListItem>
        <asp:ListItem Value="htmlpage">静态页面生成管理</asp:ListItem>
        <asp:ListItem Value="label">标签管理</asp:ListItem>
        <asp:ListItem Value="partlabel">专栏标签管理</asp:ListItem>
    </asp:CheckBoxList>
   </td>
</tr>

<tr class="nobg">
  <td class="td27">短信邮件及系统工具权限设置：</td>
</tr>
<tr>
   <td class="vtop">    
    <asp:CheckBoxList ID="cblsystem" runat="server" RepeatColumns="5" Width="100%">
        <asp:ListItem Value="sysmessage">站内短信管理</asp:ListItem>
        <asp:ListItem Value="email">邮件管理</asp:ListItem>
        <asp:ListItem Value="feedback">意见反馈管理</asp:ListItem>
        <asp:ListItem Value="database">数据库管理</asp:ListItem>
        <asp:ListItem Value="log">日志管理</asp:ListItem>
        <asp:ListItem Value="attachment">附件管理</asp:ListItem>
        <asp:ListItem Value="interface">接口管理</asp:ListItem>
        <asp:ListItem Value="Statistics">数据统计</asp:ListItem>
        <asp:ListItem Value="NewsSource">百度新闻源</asp:ListItem>
        <asp:ListItem Value="gift">礼品管理</asp:ListItem>
    </asp:CheckBoxList>
   </td>
</tr>


<tr>
<td  class="content_action" align="center">
    &nbsp;<asp:Button ID="btok" runat="server" CssClass="button" OnClick="Button1_Click1"
        Text="保存设置" />
    &nbsp;<asp:Button ID="bton" runat="server" CssClass="button" OnClick="Button2_Click1"
        Text="返回" />
    <asp:Label ID="lbmanage" runat="server" ForeColor="Red"></asp:Label>
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
