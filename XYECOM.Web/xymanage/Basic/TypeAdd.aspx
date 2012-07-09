<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_basic_TypeAdd" Codebehind="TypeAdd.aspx.cs" %>

<%@ Register Src="../UserControl/top.ascx" TagName="top" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>产品分类管理</title>
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script type="text/javascript" src="../javascript/CheckedAll.js" ></script>

</head>
<body onload="">
<form id="form1" runat="server" >
<h1><a href="../index.aspx">后台管理首页</a> &gt;&gt; 产品分类管理</h1>
<table width="100%" >
<tr>
<td class="right">

<div class="main-setting">
<div class="itemtitle"><h3>
    分类管理</h3></div>
    
<table class="xy_tb xy_tb2">

<tr class="nobg">
  <td colspan="2" class="td27">分类名称：</td>
</tr>
<tr>
   <td class="vtop rowform">    
    <asp:TextBox ID="tbName" Width="400px" runat="server" CssClass="input" MaxLength="20" Rows="5" TextMode="MultiLine"></asp:TextBox>
        
   </td>
   <td class="vtop tips2"><asp:Label ID="lbremark" runat="server" Text="添加多个以“,”号隔开；"></asp:Label></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">上级分类：</td>
</tr>
<tr>
   <td class="vtop rowform">    
    <asp:Label ID="lblName" runat="server"></asp:Label>
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr id="module2" runat="server" class="nobg">
  <td colspan="2" class="td27">所属模块：</td>
</tr>
<tr runat="server" id="module">
   <td class="vtop rowform" style="height: 30px">    
   <asp:Label id="lblType" runat="server"></asp:Label></td>
   <td class="vtop tips2"  style="height: 30px">    
   </td>
</tr>

<tr>
<td colspan="2" class="content_action"><asp:button id="btnok" runat="server" CssClass="button" Text="保存" OnClick="btnok_Click"  ></asp:button>
    <asp:Button ID="Button2" runat="server" CssClass="button" OnClick="Button1_Click"
        Text="返回" />
<input type="hidden" id="hidLT_ID" value="" runat="server" /></td>
</tr>
</table>

</div>
</td>
</tr>
</table>
</form>
</body>
</html>


