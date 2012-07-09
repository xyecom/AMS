 <%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_basic_UserInfoSet" Codebehind="UserInfoSet.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>用户信息设置 </title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
    <script language="javascript" type="text/javascript" src="../javascript/WebSet.js"></script>
</head>
<body>
 <form id="form1" runat="server">
 <h1><a href="../index.aspx">后台管理首页</a> >> 用户信息设置</h1>
 <table width="100%">
 <tr>
 <td class="right">

<div class="main-setting">
<div class="itemtitle">
<h3>系统基本配置</h3>
<ul class="tab1">
    <li><a href="WebInfo.aspx"><span>基本配置</span></a></li>
    <li><a href="Function.aspx"><span>功能配置</span></a></li>
    <li><a href="BussinessInfoSet.aspx"><span>商业信息相关</span></a></li>
    <li class="current"><a href="UserInfoSet.aspx"><span>用户相关</span></a></li>
    <li><a href="ShopSet.aspx"><span>网店相关</span></a></li>
    <li><a href="Server.aspx"><span>附件服务器</span></a></li>
    <li><a href="EMailBoxInfoSet.aspx"><span>网站邮箱</span></a></li>
    <li><a href="SEO.aspx"><span>SEO设置</span></a></li>
    <li><a href="SecuritySet.aspx"><span>安全设置</span></a></li>
</ul>
</div>


<table class="xy_tb xy_tb2 border_buttom0">

<tr class="nobg">
  <td colspan="2" class="td27">新用户注册：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:RadioButton ID="isusert" runat="server" CssClass="input" GroupName="IsUser" Text="允许" Checked="True" />
		<asp:RadioButton ID="isuserf" runat="server" CssClass="input" GroupName="IsUser"	Text="不允许" />
   </td>
   <td class="vtop tips2">选中不允许，注册页面将显示禁止注册提示</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">新用户注册模式：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:RadioButtonList ID="RegisterModeList" runat="server" RepeatDirection="Horizontal"
        RepeatLayout="Flow">
        <asp:ListItem Value="simple">简洁模式</asp:ListItem>
        <asp:ListItem Value="full">完整模式</asp:ListItem>
    </asp:RadioButtonList>
   </td>
   <td class="vtop tips2">简洁模式下注册只需填写基本信息，完整模式下需要填写基本信息及(企业/个人)详细信息</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">审核方式：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:RadioButton ID="atuoadtuser" runat="server" CssClass="input" GroupName="useradttype" Text="自动审核" Checked="True" />
		<asp:RadioButton ID="manadtuser" runat="server" CssClass="input" GroupName="useradttype" Text="人工审核" />
   </td>
   <td class="vtop tips2">新用户注册完成或老用户编辑资料后的审核方式</td>
</tr>
<tr class="nobg">
  <td colspan="2" class="td27">允许用户选择的行业个数：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="txtCanChooseTradeNumber" runat="server" MaxLength="4" CssClass="txt" Width="100px">0</asp:TextBox>&nbsp;
   </td>
   <td class="vtop tips2">用户可以选择的行业个数</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">禁止注册的用户名：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="tbforbidname" runat="server" MaxLength="4000" CssClass="txt" TextMode="MultiLine" Columns="116" Rows="6" ></asp:TextBox>
   </td>
   <td class="vtop tips2"><span>多个以","隔开</span></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">注册成功默认(虚拟币)：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="tbuserhortation" runat="server" MaxLength="4" CssClass="txt" Width="100px">0</asp:TextBox>
		<asp:Label ID="Label2" runat="server"></asp:Label>
   </td>
   <td class="vtop tips2">新会员注册成功以后默认奖励的虚拟币数量</td>
</tr>
<tr class="nobg">
  <td colspan="2" class="td27">游客是否可以查看商业信息联系方式：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:RadioButton ID="yke" runat="server" CssClass="input" GroupName="youke"	Text="可以" Checked="True" />
	 <asp:RadioButton ID="yk" runat="server" CssClass="input" GroupName="youke" Text="不可以" />
   </td>
   <td class="vtop tips2">发布商业信息的企业会员联系方式是否允许被游客查看</td>
</tr>
<tr class="nobg">
  <td colspan="2" class="td27">登录奖励(虚拟币)：</td>
</tr>
<tr>
   <td class="vtop rowform">
    
        <asp:TextBox ID="tbloginhortation" runat="server" MaxLength="4" CssClass="txt" Width="100px"></asp:TextBox>
        <asp:Label ID="Label3" runat="server"></asp:Label>
   </td>
   <td class="vtop tips2">会员每次登陆奖励的虚拟币数量，以天为单位，一天内算一次</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">登录奖励(积分)：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="txtScores" runat="server"  MaxLength="4" CssClass="txt"  Width="100px" onblur="IsInt(this);">0</asp:TextBox>
   </td>
   <td class="vtop tips2">会员每次登陆奖励的积分数量，以天为单位，一天内算一次</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">注册成功邮件提示(发送邮箱激活码)：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:RadioButton ID="rbresteisemailyes" runat="server" CssClass="input" GroupName="msresster" Text="启用"  />
		<asp:RadioButton ID="rbresteisemailno" runat="server" CssClass="input" GroupName="msresster"  Text="不启用"/>
   </td>
   <td class="vtop tips2">新会员注册成功以后是否通过邮件的方式通知并发送邮箱激活码激活注册邮箱(确保网站邮件服务器配置正确)</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">注册成功短信提示：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:RadioButton ID="webnotet" runat="server" CssClass="input" GroupName="webmessage" Text="启用" />
		<asp:RadioButton ID="webnotef" runat="server" CssClass="input" GroupName="webmessage" Text="不启用" />
   </td>
   <td class="vtop tips2">新会员注册成功以后是否通过站内短信的方式通知</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">注册成功欢迎短信标题：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="tbnotetitle" MaxLength="40" runat="server" CssClass="txt"></asp:TextBox>
   </td>
   <td class="vtop tips2">新会员注册成功以后站内短信提示标题</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">注册成功欢迎短信内容：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="tbnotetext" runat="server" MaxLength="4000" Columns="116" Rows="6" CssClass="txt" TextMode="MultiLine"></asp:TextBox>
   </td>
   <td class="vtop tips2">新会员注册成功以后站内短信提示内容</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">审核用户邮件提示：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:RadioButton ID="auditinguseryes" runat="server" CssClass="input" GroupName="newmsadttype" Text="启用"  />
		<asp:RadioButton ID="auditinguserno" runat="server" CssClass="input" GroupName="newmsadttype" Text="不启用"/>
   </td>
   <td class="vtop tips2">新注册会员审核操作后是否通过邮件的方式通知</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">审核用户短信提示：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:RadioButton ID="rbauditmessageyes" runat="server" CssClass="input" GroupName="auditsentmessagesy" Text="启用" />
		<asp:RadioButton ID="rbauditmessageno" runat="server" CssClass="input" GroupName="auditsentmessagesy" Text="不启用"/>
   </td>
   <td class="vtop tips2">新注册会员审核操作后是否通过站内短信的方式通知</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">审核用户短信标题：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="lbsentmessasgetitle" MaxLength="40" runat="server" CssClass="txt"></asp:TextBox>
   </td>
   <td class="vtop tips2">新注册会员审核操作后站内短信提示标题</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">审核用户短信内容：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="lbusersentmessagecontent" runat="server" MaxLength="4000" Columns="116" Rows="6" CssClass="txt" TextMode="MultiLine"></asp:TextBox>
   </td>
   <td class="vtop tips2">新注册会员审核操作后站内短信提示内容</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">用户充值邮件提示：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:RadioButton ID="addmoneyyes" runat="server" CssClass="input" GroupName="addmoneyemail" Text="启用"  />
		<asp:RadioButton ID="addmoneyno" runat="server" CssClass="input" GroupName="addmoneyemail" Text="不启用"/>
   </td>
   <td class="vtop tips2">会员充值操作后是否以邮件的方式通知</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">用户充值短信提示：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:RadioButton ID="useraddmoneymessageyes" runat="server" CssClass="input" GroupName="usermessage" Text="启用"  />
		<asp:RadioButton ID="useraddmoneymessageno" runat="server" CssClass="input" GroupName="usermessage" Text="不启用"/>
   </td>
   <td class="vtop tips2">会员充值操作后是否以站内短信的方式通知</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">用户充值信息短信标题：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="addmoneytitle" MaxLength="180" runat="server" CssClass="txt"></asp:TextBox>
   </td>
   <td class="vtop tips2">会员充值操作后站内短信通知标题</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">用户充值信息短信内容：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="addmoneycontent" runat="server" MaxLength="4000" Columns="116" Rows="6" CssClass="txt" TextMode="MultiLine"></asp:TextBox>
   </td>
   <td class="vtop tips2">会员充值操作后站内短信通知内容</td>
</tr>
</table>

<div class="itemtitle" style="margin-top:10px;"><h3>用户资料完善度相关</h3>
</div>
<table class="xy_tb xy_tb2 ">

<tr class="nobg">
  <td colspan="2" class="td27">(基本项)注册成功：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox runat="server" ID="tbregist" CssClass="txt" MaxLength="3"></asp:TextBox>%
   </td>
   <td class="vtop tips2">请输入整数,完善度总数不能超过100</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">(基本项)填写基本必填项：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox runat="server" ID="tbbase" CssClass="txt" MaxLength="3"></asp:TextBox>%
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">(基本项)添加手机号码：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox runat="server" ID="tbmobile" CssClass="txt" MaxLength="3"></asp:TextBox>%
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">(基本项)添加所在部门：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox runat="server" ID="tbbranch" CssClass="txt" MaxLength="3"></asp:TextBox>%
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">(高级项)添加补充资料必填项：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox runat="server" ID="tbcomple" CssClass="txt" MaxLength="3"></asp:TextBox>%
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">(高级项)添加注册资本：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox runat="server" ID="tbcapital" CssClass="txt" MaxLength="3"></asp:TextBox>%</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">(证书项)上传营业执照:</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox runat="server" ID="tblicence" CssClass="txt" MaxLength="3"></asp:TextBox>%
   </td>
   <td class="vtop tips2">
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">(证书项)增加上传其他证书数：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox runat="server" ID="tbcertificate" CssClass="txt" MaxLength="3"></asp:TextBox>&nbsp;*5%
     
   </td>
   <td class="vtop tips2"> 请输入允许上传其他证书数目,系统将以证书数*5来增加完善值,但总值不会超过100</td>
</tr>
</table>
<div style="padding:5px 0px 15px 0px;"><asp:Button ID="btok" runat="server" CssClass="button" Text="保存设置" OnClick="btok_Click" /></div>
 </div>
 </td>
 </tr>
 </table>
 </form>
</body>
</html>
