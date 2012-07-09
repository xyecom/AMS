<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditPollLabel.aspx.cs" Inherits="XYECOM.Web.xymanage.LabelManage.EditPollLabel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>新增投票标签</title>
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script type="text/javascript" src="../javascript/CheckedAll.js" ></script>
</head>
<body>
<form id="form1" runat="server">
<h1><a href="../index.aspx">后台管理首页</a> >> 新增投票标签</h1>
<table width="100%" >
<tr>
<td class="right">    

<div class="main-setting">
<div class="itemtitle"><h3 id="title" runat="server">新增投票标签</h3>
</div>
<table class="xy_tb xy_tb2 ">


<tr class="nobg">
  <td colspan="2" class="td27">标签名称：</td>
</tr>
<tr>
   <td class="vtop rowform" style="font-weight:bold; width:500px; height: 48px;">
     {XY_POLL_<asp:TextBox ID="txtName" Columns="30" runat="server" CssClass="input" MaxLength="50"></asp:TextBox>}
     <br/>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
           ErrorMessage="标签名称不能为空"></asp:RequiredFieldValidator></td>
   <td class="vtop tips2" style="height: 48px"><span></span></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">投票标题：</td>
</tr>
<tr>
   <td class="vtop rowform" >
    
        <asp:TextBox ID="txtTitle" runat="server" CssClass="input"  Columns="80" TextMode="MultiLine" Rows="4" style=" width:482px;"></asp:TextBox>
       <br/>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTitle"
           ErrorMessage="投票标题不能为空"></asp:RequiredFieldValidator><br /><br />
   </td>
   <td class="vtop tips2">500字符以内</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">选择模式：</td>
</tr>
<tr>
   <td class="vtop rowform">
        <asp:RadioButton runat="server" ID="rdoSingle" GroupName="SlectMode" Checked="true" Text="单选"/>
        <asp:RadioButton runat="server" ID="rdoCheck" GroupName="SlectMode" Text="多选"/>

   </td>
   <td class="vtop tips2">投票选项的选择模式</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">投票选项：</td>
</tr>
<tr>
   <td class="vtop rowform">
        <asp:PlaceHolder ID="phMain" runat="server">
        </asp:PlaceHolder>
   </td>
   <td class="vtop tips2">
   <img src="../images/add.gif" alt="点此继续添加选项" onclick="AddPollOption()" />  点此继续添加选项
            <input type="hidden" id="OptionTotal" name="OptionTotal" runat="server" value="1" />
            <input type="hidden" id="DelOptionIds" name="DelOptionIds" runat="server" value="" />
   </td>
</tr>

<tr>
<td style="height: 30px" colspan="2">
    <asp:button id="btnOK" runat="server" CssClass="button" Text="保存" OnClick="btnOK_Click"></asp:button>&nbsp;
    <input id="Button1" class="button" type="button" value="返回" onclick="location.href='PollLabelList.aspx';" />
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

