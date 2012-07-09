<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetTitleStyle.aspx.cs" Inherits="XYECOM.Web.xymanage.News.SetTitleStyle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
 <title>设置标题样式</title>
 <link type="text/css" href="../css/style.css" rel="stylesheet" />
 <link href="/common/css/XYLib.css" type="text/css" rel="Stylesheet" />
 <script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
</head>
<body>
<form id="form1" runat="server">
  <h1><a href="../index.aspx">后台管理首页</a> >> 设置标题样式</h1>
<table width="100%">
<tr>
 <td class="right">

<div class="main-setting">
<div class="itemtitle"><h3>设置标题样式</h3></div>
  
  <table class="xy_tb xy_tb2">
<tr class="nobg">
  <td colspan="2" class="td27">资讯标题：</td>
</tr>
<tr>
   <td class="vtop rowform">
     <asp:Label ID="lbNewsTitles" runat="server"></asp:Label>
     <input type="hidden" runat="server" id="hidNewsIds" />
   </td>
   <td class="vtop tips2"></td>
</tr>
<tr class="nobg">
  <td colspan="2" class="td27">标题样式：</td>
</tr>
<tr>
   <td class="vtop">
    <input type="text" id="txtTitleColor" value="" size="7" maxlength="7" runat="server"/>
    <select onchange="document.getElementById('txtTitleColor').value=this.options[this.selectedIndex].value;">
        <option value="">默认色</option>
        <option value="#FF0000" style="color:#FF0000;BACKGROUND-COLOR:#FF0000"></option>
        <option value="#0000FF" style="color:#0000FF;BACKGROUND-COLOR:#0000FF" ></option>
        <option value="#008000" style="color:#008000;BACKGROUND-COLOR:#008000"></option>
        <option value="#FFA500" style="color:#FFA500;BACKGROUND-COLOR:#FFA500"></option>
        <option value="#800080" style="color:#800080;BACKGROUND-COLOR:#800080"></option>
        <option value="#000000" style="color:#000000;BACKGROUND-COLOR:#000000"></option>
    </select>
    <input type="checkbox" id="chkFontBold" value="bold" runat="server"/>粗体
    <input type="checkbox" id="chkFontItalic" value="italic" runat="server"/>斜体
    <input type="checkbox" id="chkFontUnderline" value="underline" runat="server"/>下划线
    
   </td>
   <td class="vtop tips2"></td>
</tr>
  <tr>
  <td colspan="2">
     <asp:Button ID="btnOK" runat="server" CssClass="button" Text="确定" OnClick="btnOK_Click"/>
     <input class="button" type="button" value="返回" id="btnBack" runat="server" />
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
