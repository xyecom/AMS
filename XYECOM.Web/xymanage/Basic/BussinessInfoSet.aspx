<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_basic_BussinessInfoSet" Codebehind="BussinessInfoSet.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
  <title>商业信息基本设置</title>
  <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
  <link href="../css/style.css" type="text/css" rel="stylesheet" />
  <script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
  <script language="javascript" type="text/javascript" src="../javascript/WebSet.js"></script>
</head>
<body>
<form id="form1" runat="server">
<h1><a href="../index.aspx">后台管理首页</a> >> 商业信息基本设置</h1>
<table width="100%">
<tr>
<td class="right">

<div class="main-setting">
<div class="itemtitle">
<h3>系统基本配置</h3>
<ul class="tab1">
    <li><a href="WebInfo.aspx"><span>基本配置</span></a></li>
    <li><a href="Function.aspx"><span>功能配置</span></a></li>
    <li class="current" style="display: none;"><a href="BussinessInfoSet.aspx"><span>商业信息相关</span></a></li>
    <li><a href="UserInfoSet.aspx"><span>用户相关</span></a></li>
    <li style="display: none;"><a href="ShopSet.aspx"><span>网店相关</span></a></li>
    <li><a href="Server.aspx"><span>附件服务器</span></a></li>
    <li><a href="EMailBoxInfoSet.aspx"><span>网站邮箱</span></a></li>
    <li style="display: none;"><a href="SEO.aspx"><span>SEO设置</span></a></li>
    <li><a href="SecuritySet.aspx"><span>安全设置</span></a></li>
</ul>
</div>


<table class="xy_tb xy_tb2 border_buttom0">

<tr class="nobg">
  <td colspan="2" class="td27">审核方式：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:RadioButton ID="autoadtms" runat="server" CssClass="input" GroupName="msadttype" Text="自动审核" Checked="True" />
		<asp:RadioButton ID="manadtms" runat="server" CssClass="input" GroupName="msadttype"  Text="人工审核" />
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">修改后审核方式：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:RadioButton ID="autonewadt" runat="server" CssClass="input" GroupName="newmsadttype" Text="自动审核" Checked="True" />
	<asp:RadioButton ID="mannewadt" runat="server" CssClass="input" GroupName="newmsadttype" Text="人工审核" />
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">审核邮件提示：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:RadioButton ID="AuditIsEmailYes" runat="server" CssClass="input" GroupName="audingbussiness" Text="启用" Checked ="True"/>
		<asp:RadioButton ID="AuditIsEmailNo" runat="server" CssClass="input" GroupName="audingbussiness" Text="不启用" />
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">审核短信提示：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:RadioButton ID="AuditIsMessageYes" runat="server" CssClass="input" GroupName="webmessage" Text="启用" Checked ="True"/>
		<asp:RadioButton ID="AuditIsMessageNo" runat="server" CssClass="input" GroupName="webmessage" Text="不启用"  />
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">审核短信标题：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="tbsentmessagetitle" Width="500px" MaxLength="40" runat="server" CssClass="input"></asp:TextBox>
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">审核短信内容：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="tbsentmessagecontent" runat="server" MaxLength="4000" Columns="116" Rows="6" CssClass="input" TextMode="MultiLine" Width="500px"></asp:TextBox>
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">发布信息奖励：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="tbuseraddinfo" runat="server" MaxLength="4" CssClass="input" Width="40px">0</asp:TextBox>
		<asp:Label ID="Label4" runat="server"></asp:Label>
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">刷新一次信息奖励：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="tbrefurbishinfo" runat="server" MaxLength="4" CssClass="input" Width="40px"></asp:TextBox>
		 <asp:Label ID="Label5" runat="server"></asp:Label>
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">有效期选择方式：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:RadioButton runat="server" ID="enddate" CssClass="input" GroupName="timetype" Text="选择时间段" Checked="True" />
       <asp:RadioButton runat="server" ID="endtime" CssClass="input" GroupName="timetype" Text="输入时间点" />
   </td>
   <td class="vtop tips2">发布商业信息时有效期的指定方式</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">相关产品(信息)调用条数设置：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="txtAboutInfoNum" runat="server" MaxLength="4"  Width="40px" CssClass="input" onblur="IsInt(this);"></asp:TextBox>
   </td>
   <td class="vtop tips2"></td>
</tr>
<tr class="nobg">
  <td colspan="2" class="td27">快速留言调用条数设置：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="txtSysMessageNum" runat="server" MaxLength="4"  Width="40px" CssClass="input" onblur="IsInt(this);"></asp:TextBox>
   </td>
   <td class="vtop tips2"></td>
</tr>
</table>


<div class="itemtitle" style="margin-top:10px;"><h3>邮件设置</h3></div>
<table class="xy_tb xy_tb2 ">

<tr class="nobg">
  <td colspan="2" class="td27">竞价邮件提示：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:RadioButton ID="BidIsEmailYes" runat="server" CssClass="input" GroupName="jinjiaemail" Text="启用" Checked="True"/>
		<asp:RadioButton ID="BidIsEmailNo" runat="server" CssClass="input" GroupName="jinjiaemail" Text="不启用" />
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">竞价短信提示：</td>
</tr>
<tr>
   <td class="vtop rowform">
    
        <asp:RadioButton ID="BidIsMessageYes" runat="server" CssClass="input" GroupName="jinjiamessage" Text="启用" Checked="True"/>
		<asp:RadioButton ID="BidIsMessageNo" runat="server" CssClass="input" GroupName="jinjiamessage" Text="不启用" />
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">竞价短信标题：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="jinjiatitle" Width="500px" MaxLength="40" runat="server" CssClass="input"></asp:TextBox>
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">竞价短信内容：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="jinjiacontent" runat="server" MaxLength="4000" Columns="116" Rows="6" CssClass="input" TextMode="MultiLine" Width="500px"></asp:TextBox>
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">推荐职位邮件提示：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:RadioButton ID="JobIsEmailYes" runat="server" CssClass="input" GroupName="job" Text="启用" Checked="True"/>
		<asp:RadioButton ID="JobIsEmailNo" runat="server" CssClass="input" GroupName="job" Text="不启用"   />
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">招聘职位短信提示：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:RadioButton ID="JobIsMessageYes" runat="server" CssClass="input" GroupName="jobmessage" Text="启用" Checked="True"/>
		<asp:RadioButton ID="JobIsMessageNo" runat="server" CssClass="input" GroupName="jobmessage" Text="不启用"   />
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">招聘求职短信标题：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="jobtitle" Width="500px" MaxLength="40" runat="server" CssClass="input"></asp:TextBox>
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">招聘求职短信内容：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="jobcontent" runat="server" MaxLength="4000" Columns="116" Rows="6" CssClass="input" TextMode="MultiLine" Width="500px"></asp:TextBox>
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">订单邮件提示：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:RadioButton ID="OrderIsEmailYes" runat="server" CssClass="input" GroupName="order" Text="启用" Checked="True"/>
		<asp:RadioButton ID="OrderIsEmailNo" runat="server" CssClass="input" GroupName="order" Text="不启用"   />
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">订单短信提示：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:RadioButton ID="OrderIsMessageYes" runat="server" CssClass="input" GroupName="ordermessage" Text="启用" Checked="True"/>
		<asp:RadioButton ID="OrderIsMessageNo" runat="server" CssClass="input" GroupName="ordermessage" Text="不启用"   />
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">订单短信标题：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="ordermessagetitle" Width="500px" MaxLength="40" runat="server" CssClass="input"></asp:TextBox>
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">订单短信内容：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="ordermessagecontent" runat="server" MaxLength="4000" Columns="116" Rows="6" CssClass="input" TextMode="MultiLine" Width="500px"></asp:TextBox></td>
</tr>
</table>

<div style="padding:5px 0px 15px 0px;">
<asp:Button ID="btok" runat="server" CssClass="button" Text="保存设置" OnClick="btok_Click" /></div>
</div>
   </td>
   <td class="vtop tips2"></td>
</tr>
</table>
</form>
</body>
</html>
