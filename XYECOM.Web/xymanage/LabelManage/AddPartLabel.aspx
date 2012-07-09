<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddPartLabel.aspx.cs" Inherits="XYECOM.Web.xymanage.LabelManage.AddPartLabel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>新增企业专栏标签</title>
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script type="text/javascript" src="../javascript/CheckedAll.js" ></script>
<script language="javascript" type="text/javascript" src="../../Common/Js/date.js"></script>
<script type="text/javascript">
function SelectUser(obj,toObj)
{
    var value = obj.options[obj.selectedIndex].value;
                
    document.getElementById(toObj).value = value;
}
</script>
</head>
<body>
<form id="form1" runat="server">
<h1><a href="../index.aspx">后台管理首页</a> >> 新增企业专栏标签</h1>
<table width="100%" >
<tr>
<td class="right">    

<div class="main-setting">
<div class="itemtitle"><h3 id="title" runat="server">新增企业专栏标签</h3>
</div>
<table class="xy_tb xy_tb2 ">


<tr class="nobg">
  <td colspan="2" class="td27">标签名称：</td>
</tr>
<tr>
   <td class="vtop rowform" style="font-weight:bold; width:500px; height: 48px;">
     {XY_PART_<asp:TextBox ID="txtName" Columns="30" runat="server" CssClass="input" MaxLength="50"></asp:TextBox>}
     <br/>
       </td>
   <td class="vtop tips2" style="height: 48px"><span>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
           ErrorMessage="标签名称不能为空"></asp:RequiredFieldValidator></span></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">专栏名称：</td>
</tr>
<tr>
   <td class="vtop rowform" style="font-weight:bold; width:500px; height: 48px;">
     <asp:TextBox ID="txtCName" Columns="43" runat="server" CssClass="input" MaxLength="50"></asp:TextBox>
     <br/>
       </td>
   <td class="vtop tips2" style="height: 48px">
    可以对所在位置等进行简单描述<br />
       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCName"
           ErrorMessage="专栏名称不能为空"></asp:RequiredFieldValidator></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">专栏格式：</td>
</tr>
<tr>
   <td class="vtop " style="font-weight:bold; width:100px; height: 48px;">
    <asp:DropDownList runat="server" ID="ddlFormat">
        <asp:ListItem Value="1" Text="  格式1  "></asp:ListItem>
        <asp:ListItem Value="2" Text="  格式2  "></asp:ListItem>
    </asp:DropDownList>
    </td>
   <td class="vtop tips2" style="height: 48px"><span></span></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">有效时间：</td>
</tr>
<tr>
   <td class="vtop rowform" >
    <input id="txtBeginTime" runat="server" size="10"   type="text" readonly="readonly" onclick="getDateString(this);" />
    ～
    <input id="txtEndTime" runat="server" size="10"   type="text" readonly="readonly" onclick="getDateString(this);" />&nbsp;<br />
       &nbsp;
   </td>
   <td class="vtop tips2">结束时间必须大于开始时间<br />
       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtBeginTime"
           ErrorMessage="开始时间不能为空"></asp:RequiredFieldValidator><br />
       <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEndTime"
           ErrorMessage="结束时间不能为空"></asp:RequiredFieldValidator></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27" style="height: 29px">企业Id：</td>
</tr>
<tr>
   <td class="vtop rowform">
         <asp:TextBox ID="txtUserId" Columns="8" runat="server" CssClass="input" MaxLength="8"></asp:TextBox> 指定Id或从下面搜索<br/>
         
        <div style="background-color:#f2f2f2; padding:2px;">
        <asp:textbox runat="server" ID="txtUserName" MaxLength="40" Columns="34" onclick="if(this.value=='请输入用户名或公司名称')this.value='';">请输入用户名或公司名称</asp:textbox>&nbsp;&nbsp;<asp:Button runat="server" ID="btnSearch1" OnClick="btnSearch_Click" CssClass="button" Text="搜索" CausesValidation="False"> </asp:Button><br/>
        <asp:ListBox ID="lstUsers" runat="server" Rows="6" Width="280px" ToolTip="双击选中用户"></asp:ListBox>
        </div>
       <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>

   </td>
   <td class="vtop tips2">
       指定企业Id<br />
       <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="企业Id不能为空" ControlToValidate="txtUserId"></asp:RequiredFieldValidator><br />
       <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtUserId"
           ErrorMessage="企业Id必须为数字" ValidationExpression="\d{1,8}"></asp:RegularExpressionValidator></td>
</tr>




<tr>
<td style="height: 30px" colspan="2">
    <asp:button id="btnOK" runat="server" CssClass="button" Text="保存" OnClick="btnOK_Click"></asp:button>&nbsp;
    <input id="Button1" class="button" type="button" value="返回" onclick="location.href='PartLabelList.aspx';" />
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