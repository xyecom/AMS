<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IM.aspx.cs" Inherits="XYECOM.Web.xymanage.Interface.IM" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>IM</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
</head>
<body>

    <form id="form1" runat="server">
    <h1><a href="../index.aspx">后台管理首页</a> >> IM设置</h1>
<table width="100%">
 <tr>
 <td>
<div class="main-setting">
<div class="itemtitle"><h3>IM 工具设置</h3>
</div>
<table class="xy_tb xy_tb2 ">
<tr class="nobg">
  <td colspan="2" class="td27">是否启用：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:RadioButton ID="rdoEnabled" runat="server" Text="启用" GroupName="isEnabled"/>
       <asp:RadioButton ID="rdoDisabled" runat="server" Text="禁用" GroupName="isEnabled"/>   </td>
   <td class="vtop tips2">启用整合服务请详细填写下列数据</td>
</tr> 
<tr class="nobg">
  <td colspan="2" class="td27">IM工具名称：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="txtName" runat="server" MaxLength="20" CssClass="input"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
           ErrorMessage="IM 名称不能为空"></asp:RequiredFieldValidator>   </td>
   <td class="vtop tips2">IM工具名称即即时通讯工具名称，如QQ，MSN等</td>
</tr>

     

<tr class="nobg">
  <td colspan="2" class="td27">调用代码：</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="txtCode" runat="server"  MaxLength="2000" CssClass="labelBody" Columns="100" Rows="10" TextMode="MultiLine" Width="400px"></asp:TextBox><br />   </td>
   <td class="vtop tips2">
   调用代码即通过官方工具或其它工具生成的在线状态调用代码<br/>
   要替换的IM号码位置请用{XY_IM}代替<br/>
   <span class="r">{XY_IM}为必须字段</span>，网页中将被替换成会员的 IM 号码，如QQ号码
   </td>
</tr> 


 <tr>
   <td colspan="2"><asp:Button ID="btnOK" runat="server" CssClass="button" Text="保存设置" OnClick="btnOK_Click"/></td>
   </tr>
 </table>
 <asp:Label runat="server" ID="lbmessage" CssClass="input" ForeColor="red"></asp:Label>

 </div>
 

 </td>
 </tr>
 </table>

   


    </form>
</body>
</html>