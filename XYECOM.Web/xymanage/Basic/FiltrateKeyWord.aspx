<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_basic_FiltrateKeyWord" Codebehind="FiltrateKeyWord.aspx.cs" %>

<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc2" %>

<%@ Register Src="../UserControl/top.ascx" TagName="top" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>过滤字管理</title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
<link rel="stylesheet" href="../css/style.css" type="text/css" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script language ="javascript" type ="text/javascript" src ="../javascript/CheckedAll.js"></script>
</head>
<body onload="load();">
<form id="Form1" method="post" runat="server">

<h1><a href="../index.aspx">后台设置首页</a> >> 过滤字管理</h1>

<table width="100%" >
<tr>
<td class="right">


<div class="main-setting">
<div class="itemtitle"><h3>过滤字管理</h3>
<input id="btnAdd" type="button" class="addbtn" value="新增过滤字" onclick="block();" />
</div>



<table class="xy_tb xy_tb2" style="DISPLAY: none" id="add">
<tr class="nobg">
  <td colspan="2" class="td27">过滤字名称：</td>
</tr>
<tr>
   <td class="vtop rowform">    
	<asp:TextBox id="txtName" runat="server" ToolTip="" MaxLength="500" TextMode="MultiLine" Columns="116" Rows="6"></asp:TextBox>
   </td>
   <td class="vtop tips2">以","隔开</td>
</tr>
<tr>
<td colspan="2">
<input name="Submit3" type="submit" class="button" value="确定" id="btnOk" runat="server" title="开始添加" onserverclick="btnOk_ServerClick" /> <input type="button" class="button" value="取消" id="btnQuit" onclick="quit();" />
    <input id="key" runat="server" type="hidden" />
    <input id="va" runat="server" type="hidden" /></td>
</tr>
</table>

<table class="xy_tb xy_tb2" style="DISPLAY: none" id="update">
<tr class="nobg">
  <td colspan="2" class="td27">过滤字名称：</td>
</tr>
<tr>
   <td class="vtop rowform">    
	<asp:TextBox id="TextBox1" runat="server" ToolTip="输入您要添加的剂型名称" MaxLength="20" Width="261px"></asp:TextBox>
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr>
<td colspan="2">
    <asp:Button ID="Button2" runat="server" Text="确定"  CssClass ="button" OnClick="Button2_Click"/>
    <input type="button" class="button" value="取消" id="Button1" onclick="Exit();" />
    </td>
</tr>
</table>


<table class="xy_tb xy_tb2" style="margin-top:10px;">
<tr>
<td>
<asp:GridView ID="gvlist" HeaderStyle-CssClass="gv_header_style"  runat="server" AutoGenerateColumns="False" Width="100%" OnRowCommand="gvlist_RowCommand" DataKeyNames="FKW_ID" GridLines="None" OnRowDataBound="gvlist_RowDataBound">
<Columns>
<asp:BoundField DataField="FKW_ID" HeaderText="FKW_ID" Visible="False" />
<asp:TemplateField HeaderText="选择">                
<ItemTemplate>
<asp:CheckBox ID="chkExport" runat="server" />
</ItemTemplate>
    <ItemStyle Width="5%" />
</asp:TemplateField>
<asp:BoundField DataField="FKW_Name" HeaderText="过滤字名称" ><ItemStyle  Width="90%" CssClass="gvLeft" />
    <HeaderStyle CssClass="gvLeft" />
</asp:BoundField>
<asp:ButtonField HeaderText="编辑" Text="&lt;img src=&quot;../images/edit.GIF&quot; /&gt;" CommandName="up" >
    <ItemStyle Width="5%" />
</asp:ButtonField>
</Columns>
</asp:GridView>
</td>
</tr>
<tr>
<td  class="content_action" ><label><input id="chkAll" onclick="chkAll_true()" type="checkbox" name="chkAll" runat="server" />全选
    <asp:Button ID="btndelete" runat="server" CssClass="button" OnClick="btndelete_Click"
        Text="删除" />
    </label></td>
</tr>
</table>
<p style="text-align:center;"><asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
    <uc2:page ID="Page1" runat="server" />
</p>
</div>

</td></tr></table>

</form>
</body>
</html>
