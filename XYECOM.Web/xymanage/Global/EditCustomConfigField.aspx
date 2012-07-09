<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditCustomConfigField.aspx.cs" Inherits="XYECOM.Web.xymanage.Global.EditCustomConfigField" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>自定义配置字段编辑</title>
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="../css/cue.css" type="text/css" rel="stylesheet" />
    <script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
    <script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js" ></script>
</head>
<body>
    <form id="form1" runat="server">
    <h1><a href="../index.aspx">后台管理首页</a> &gt;&gt; 自定义配置字段</h1>
    <table width="100%">
<tr>
<td class="right">

<div class="main-setting">
<div class="itemtitle"><h3>自定义配置字段</h3>
</div>

<table class="xy_tb xy_tb2">

<tr class="nobg">
  <td colspan="2" class="td27">名称(Key)：</td>
</tr>
<tr>
   <td class="vtop rowform" style="height: 52px">
    
 <asp:TextBox ID="txtKey" runat="server" MaxLength="20" Columns="20" CssClass="input"></asp:TextBox>
      <br/> <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtKey"
           ErrorMessage="key 不能为空"></asp:RequiredFieldValidator><br />
       <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtKey"
           ErrorMessage="key 必须为字母，且长度必须在 2 ～ 20 之间" ValidationExpression="[a-zA-Z]{2,20}"></asp:RegularExpressionValidator></td>
   <td class="vtop tips2" style="height: 52px">由a~z组成,长度在2 ～ 20 之间的名称，不能重复</td>
</tr>
<tr class="nobg">
  <td colspan="2" class="td27">值(Value)：</td>
</tr>
<tr>
   <td class="vtop rowform" style="width:480px;">
   <asp:TextBox ID="txtValue" runat="server" Rows="6" TextMode="MultiLine" MaxLength="1000" Width="400px"></asp:TextBox>

   <a href="javascript:ChangeTextRow('txtValue','add',30,6,2);"><img src="../images/add.gif" alt="新增一行" /></a> &nbsp; <a href="javascript:ChangeTextRow('txtValue','sub',30,6,2);"><img src="../images/subtraction.gif" alt="删除一行" /></a> <br />
       </td>
   <td class="vtop tips2">长度小于等于 1000 的值</td>
</tr>

  <tr>
   <td colspan="2" class="content_action">
   <asp:Button ID="btnOK" runat="server" CssClass="button" Text="确定" OnClick="btnOK_Click"/>
	  <input class="button" type="button" value="取消" runat="server" id="btcancle"/></td>
 </tr>
 </table>
 </div>
 </td>
 </tr>
 </table>

    </form>
</body>
</html>
