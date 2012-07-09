<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_news_AddTitle" Codebehind="AddTitle.aspx.cs" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="head1" runat="server">
<link href="../css/style.css" type="text/css" rel="Stylesheet" />
<link href="/common/css/XYLib.css" type="text/css" rel="Stylesheet" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script language="javascript" type="text/javascript" src="../javascript/AddNews.js"></script>
<title>添加资讯栏目</title>
</head>
<body>
<form id="form1" runat="server">
<h1><a href="../index.aspx">后台管理首页</a> >> 添加资讯栏目</h1>
<table width="100%">
<tr>
<td class="right">

<div class="main-setting">
<div class="itemtitle"><h3>添加资讯栏目</h3></div>


<table class="xy_tb xy_tb2">
<tr class="nobg">
  <td colspan="2" class="td27">栏目中文名称：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="txtChannelCNName" MaxLength="150" runat="server" CssClass="input"  Columns="40"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
        ID="RequiredFieldValidator1" runat="server" ErrorMessage="栏目中文名称不能为空" ControlToValidate="txtChannelCNName"></asp:RequiredFieldValidator><br />
   </td>
   <td class="vtop tips2">例如:行业资讯</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">栏目简称：</td>
</tr>
<tr>
   <td class="vtop rowform">
		<asp:TextBox ID="txtChannelShortTitle" runat="server" MaxLength="40" CssClass="input" Columns="40"></asp:TextBox><span>&nbsp;<asp:RequiredFieldValidator
        ID="RequiredFieldValidator2" runat="server" ErrorMessage="栏目简称不能为空" ControlToValidate="txtChannelShortTitle"></asp:RequiredFieldValidator><br />
   </td>
   <td class="vtop tips2">例如:行业</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">父级栏目：</td>
</tr>
<tr>
   <td class="vtop rowform">
	<asp:TextBox ID="txtParentChannel" runat="server" CssClass="input" Columns="40"></asp:TextBox>
    <input id="ptitleid" runat="server" type="hidden" />
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">栏目英文名称：</td>
</tr>
<tr>
   <td class="vtop rowform">
<asp:TextBox ID="txtChannelENName" runat="server" Columns="40" MaxLength="150" CssClass="input" onkeyup="value=value.replace(/[\W]/g,'') " onbeforepaste="clipboardData
.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="栏目英文名称不能为空" ControlToValidate="txtChannelENName"></asp:RequiredFieldValidator>
   </td>
   <td class="vtop tips2">3-50个字母</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">自定义栏目文件夹地址：</td>
</tr>
<tr>
   <td class="vtop rowform">
	<asp:TextBox ID="txtTemplate" runat="server" Columns="40" MaxLength="200" CssClass="input"></asp:TextBox>
	<br/><br/>
	<asp:CheckBox ID="chkSubChannelAutoInherit" runat="server" text="子栏目自动继承" Checked Visible="false"/>
   </td>
   <td class="vtop tips2" style="color:#f60;">
   此项非常重要，默认保持为空即可，栏目将使用资讯通用模板<br/>
   如果要为当前栏目制作特定的模板，则在模板目录 news 文件夹下新建文件夹，并拷贝默认模板(index.htm , channel.htm , content.htm)到新建目录下进行修改<br/>
   栏目访问地址为：http://www.site.com/news/自定义文件夹/<br/>
   此属性将默认自动继承给子栏目(子栏目仍可自定义)
   </td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">是否允许在该栏目下投稿：</td>
</tr>
<tr>
   <td class="vtop rowform">
	<asp:RadioButton runat="server" ID="rdoIsAllowContributYes" Text="允许" GroupName="IsAllowContribut" Checked/>
	<asp:RadioButton runat="server" ID="rdoIsAllowContributNo" Text="不允许" GroupName="IsAllowContribut" />
   </td>
   <td class="vtop tips2" style="color:#f60;">
   设置网站用户是否可以给该栏目投稿<br/>
   子栏目将自动继承父栏目的不允许投稿属性
   </td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">隐藏该栏目：</td>
</tr>
<tr>
   <td class="vtop rowform">
	<asp:CheckBox runat="server" ID="chkIsHide" Checked="false"/>
   </td>
   <td class="vtop tips2" style="color:#f60;">
   隐藏栏目所属的资讯不会被搜索到，只有通过标签才可以调用,适合特殊资讯<br/>
   通过标签调用时必须将栏目指定为隐藏栏目方可调用栏目所属的资讯<br/>
   子栏目将自动继承父栏目的隐藏属性
   </td>
</tr>


<tr class="nobg">
  <td colspan="2" class="td27">二级域名名称：</td>
</tr>
<tr>
      <td class="vtop rowform">
		<asp:Label runat="server" ID="Label1" Text="Http://"></asp:Label>
		<input id="txtDomain" runat="server" maxlength="20" class="input"  type="text" onblur="ChangeTxt();"/>
		<asp:Label runat="server" ID="webname"></asp:Label><br /><br />
		<input type="checkbox" id="cbdomain" runat="server"  checked="checked" visible="false" onclick="ChangeCheckBox();"  />子栏目自动继承
   </td>
   <td class="vtop tips2" style="color:#f60;">
   如果无法填写，请查看系统基本配置里是否开启资讯栏目二级域名选项<br/>
   栏目启用二级域名，则建议自定义模板，否则二级域名首页和主域名资讯栏目首页为同一页面
   </td>
</tr>

<tr>
<td colspan="2" class="content_action">
    <asp:Button ID="btnOK" runat="server" CssClass="button" Text="提交" OnClick="btadd_Click" />
    <input id="btcancel" class="button" type="button" value="返回" runat="server" onserverclick="btcancel_ServerClick" causesvalidation="false"/>
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
