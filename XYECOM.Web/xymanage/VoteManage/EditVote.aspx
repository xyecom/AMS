<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditVote.aspx.cs" Inherits="XYECOM.Web.xymanage.VoteManage.EditVote" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>编辑调查</title>
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script type="text/javascript" src="../javascript/CheckedAll.js" ></script>
<script language="javascript" type="text/javascript" src="/common/js/date.js"></script>
</head>
<body>
<form id="form1" runat="server">
<h1><a href="../index.aspx">后台管理首页</a> >> 编辑调查</h1>
<table width="100%" >
<tr>
<td class="right">    

<div class="main-setting">
<div class="itemtitle"><h3 id="title" runat="server">编辑调查</h3>
</div>
<table class="xy_tb xy_tb2 ">


<tr class="nobg">
  <td colspan="2" class="td27">调查标题：</td>
</tr>
<tr>
   <td class="vtop rowform" style=" width:500px; height: 48px;">
     <asp:TextBox ID="txtTitle" Columns="30" runat="server" CssClass="input" MaxLength="50"></asp:TextBox>
     <br/>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
           ErrorMessage="调查标题不能为空"></asp:RequiredFieldValidator></td>
   <td class="vtop tips2"><span></span></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">调查描述：</td>
</tr>
<tr>
   <td class="vtop rowform" style="width:500px;">
     <asp:TextBox ID="txtDesc" Columns="100" Width="450" runat="server" TextMode="MultiLine" Rows="4" CssClass="input"></asp:TextBox>
     <br/>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDesc"
           ErrorMessage="调查描述不能为空"></asp:RequiredFieldValidator></td>
   <td class="vtop tips2"><span></span></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">参与用户：</td>
</tr>
<tr>
   <td class="vtop rowform" >
    
        <asp:RadioButtonList ID="rdolstUserType" runat="server" RepeatColumns="4">
            <asp:ListItem Text="不限制" Value="all" Selected="True"></asp:ListItem>
            <asp:ListItem Text="仅会员" Value="user"></asp:ListItem>
        </asp:RadioButtonList>
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">开始时间：</td>
</tr>
<tr>
   <td>
    <asp:TextBox ID="txtStartTime" Enabled="true" runat="server" CssClass="input_s" onclick="getDateString(this);" ReadOnly="true" MaxLength="30" Width="100px"></asp:TextBox>

    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtStartTime"
           ErrorMessage="开始时间不能为空"></asp:RequiredFieldValidator>
   </td>
   <td></td>
</tr>


<tr class="nobg">
  <td colspan="2" class="td27">结束时间：</td>
</tr>
<tr>
   <td>
     <asp:TextBox ID="txtEndTime" runat="server" Enabled="true" CssClass="input_s" onclick="getDateString(this);" ReadOnly="true" MaxLength="30" Width="100px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEndTime"
           ErrorMessage="结束时间不能为空"></asp:RequiredFieldValidator>
   </td>
   <td>小于当天时间则直接结束！</td>
</tr>

<tr>
<td style="height: 30px" colspan="2">
    <asp:button id="btnOK" runat="server" CssClass="button" Text="保存" OnClick="btnOK_Click"></asp:button>&nbsp;
    <input id="Button1" class="button" type="button" value="返回" onclick="location.href='List.aspx';" />
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
