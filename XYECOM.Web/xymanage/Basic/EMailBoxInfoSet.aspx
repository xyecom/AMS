<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_basic_EMailBoxInfoSet" Codebehind="EMailBoxInfoSet.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>网站邮件服务器设置</title>
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <link type="text/css" rel="Stylesheet" href="../css/style.css" />
    <script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
    <script type="text/javascript" language="javascript" src="../javascript/WebSet.js"></script>
</head>
<body>
 <form id="form1" runat="server"> 
 <h1><a href="../index.aspx">后台管理首页</a> >>网站邮件服务器设置</h1>
 <table width="100%">
 <tr>
 <td class="right">

<div class="main-setting">
<div class="itemtitle">
<h3>系统基本配置</h3>
<ul class="tab1">
    <li><a href="WebInfo.aspx"><span>基本配置</span></a></li>
    <li><a href="Function.aspx"><span>功能配置</span></a></li>
    <li style="display: none;"><a href="BussinessInfoSet.aspx"><span>商业信息相关</span></a></li>
    <li><a href="UserInfoSet.aspx"><span>用户相关</span></a></li>
    <li style="display: none;"><a href="ShopSet.aspx"><span>网店相关</span></a></li>
    <li><a href="Server.aspx"><span>附件服务器</span></a></li>
    <li class="current"><a href="EMailBoxInfoSet.aspx"><span>网站邮箱</span></a></li>
    <li style="display: none;"><a href="SEO.aspx"><span>SEO设置</span></a></li>
    <li><a href="SecuritySet.aspx"><span>安全设置</span></a></li>
</ul>

</div>


 <table width="100%" class="xy_tb xy_tb2"><tr class="nobg">
  <td colspan="2" class="td27">站长信箱：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="txtEmail" runat="server" Width="250" MaxLength="100" CssClass="input"></asp:TextBox><br/>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEmail"
           ErrorMessage="站长信箱不能为空" ValidationGroup="v1"></asp:RequiredFieldValidator>
   </td>
   <td class="vtop tips2">站点服务邮箱，将作为对外发送邮件的邮箱</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">(SMTP)邮件服务器：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="txtEmailServer" runat="server" Width="250" MaxLength="100" CssClass="input"></asp:TextBox><br/>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmailServer"
           ErrorMessage="邮件服务器不能为空" ValidationGroup="v1"></asp:RequiredFieldValidator>
   </td>
   <td class="vtop tips2">邮件发送服务器，即SMTP服务器，如163邮箱的邮件服务器为smtp.163.com</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">(SMTP)邮件服务器端口：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="txtEmailServerPort" runat="server" Width="50" MaxLength="5" CssClass="input"></asp:TextBox><br/>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtEmailServerPort"
           ErrorMessage="邮件服务器端口不能为空" ValidationGroup="v1"></asp:RequiredFieldValidator><br/>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmailServerPort"
           ErrorMessage="端口必须为数字" ValidationExpression="\d{1,5}"></asp:RegularExpressionValidator></td>
   <td class="vtop tips2">默认为25</td>
</tr>


<tr class="nobg">
  <td colspan="2" class="td27">邮箱登录帐号：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="txtLoginName" runat="server" Width="250" MaxLength="100" CssClass="input"></asp:TextBox><br/>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtLoginName"
            ErrorMessage="登录名称不能为空" ValidationGroup="v1"></asp:RequiredFieldValidator>
   </td>
   <td class="vtop tips2">登录邮箱帐号</td>
</tr><tr class="nobg">
  <td colspan="2" class="td27">邮箱登录密码：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="txtPassword" runat="server" Width="250" MaxLength="30" TextMode="Password" CssClass="input"></asp:TextBox><br/>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPassword"
            ErrorMessage="登录密码不能为空" ValidationGroup="v1"></asp:RequiredFieldValidator></td>
   <td class="vtop tips2">登录邮箱密码</td>     
</tr>
<tr>
    <td colspan="2"><asp:Button ID="btnOK" runat="server" CssClass="button" Text="保存设置" OnClick="btnOK_Click" ValidationGroup="v1" />&nbsp;&nbsp;<asp:Label runat="server" ID="lblSetMsg"  ForeColor="red"/></td>
</tr>
<tr class="nobg">
  <td colspan="2" class="td27">测试邮件地址：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="txtTestEmail" runat="server" Width="250" CssClass="input"></asp:TextBox>&nbsp; <asp:Button CssClass="button" runat="Server" ID="btnTest" Text="测试" OnClick="btnTest_Click" ValidationGroup="v2" /><asp:Label runat="server" ID="lbmessage" CssClass="input" ForeColor="red"></asp:Label><br />
       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTestEmail"
           ErrorMessage="测试邮箱地址不能为空" ValidationGroup="v2"></asp:RequiredFieldValidator></td>
   <td class="vtop tips2">通过输入有效邮箱测试上述配置是否正确</td>
</tr>
</table>

</div>
   </td>
</tr>
 </table>  
 </form>
</body>
</html>
