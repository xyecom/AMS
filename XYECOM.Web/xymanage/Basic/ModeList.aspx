<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_basic_ModeList" Codebehind="Modelist.aspx.cs" %>
<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc2" %>
<%@ Register Src="../UserControl/top.ascx" TagName="top" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>管理员管理</title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script language ="javascript" type ="text/javascript" src ="../javascript/CheckedAll.js"></script>
</head>
<body onload ="load();">
<form id="Form1" method="post" runat="server">
<h1><a href="../index.aspx">后台管理首页</a> >> 经营模式管理</h1>
<!-- content  -->
<table  width="100%" >
<tr>
<!-- right -->
<td class="right">

<div class="main-setting">
<div class="itemtitle"><h3>经营模式管理</h3>
<input class="addbtn" id="btnAdd" onclick="block();" type="button" value="新增经营模式"/>
</div>

<table class="xy_tb xy_tb2" style="DISPLAY: none" id="add">
<tr>
<td style="height: 75px">
<table width="100%" >
<tr>
<th >
    经营模式类别：</th>
<td ><label><asp:textbox id="txtName" runat="server" Width="250px" CssClass="input" ToolTip="输入您要添加的用户名称" MaxLength="10"></asp:textbox></label></td>
</tr>
<tr>
<th>&nbsp;</th>
<td><label><input class="button" id="btnOk" title="开始添加" type="submit" value="确定" name="Submit3" runat="server" onserverclick="btnOk_ServerClick1"/>
<input class="button" id="btnQuit" onclick="quit();" type="button" value="取消"/>
</label></td>
</tr>
</table>
</td></tr>
</table>

<table class="xy_tb xy_tb2" id="update" style="DISPLAY: none"  border="0">
<tr>
<td>
<table width="100%" >
<tr>
<th style="width: 180px; height: 10px;">
    经营模式类别：</th>
<td style="height: 10px">
    <asp:TextBox ID="uname" runat="server" MaxLength="30" Width="250px"></asp:TextBox>
    <input id="value" runat="server" type="hidden" />
    <input id="key" runat="server" type="hidden" /></td>
</tr>
<tr>
<th style="width: 180px; height: 36px;"></th>
<td style="height: 36px"><label id="key1"><input class="button" id="Submit1" title="修改" type="submit" value="修改" name="Submit3" runat="server" onserverclick="Submit1_ServerClick" />
<input class="button" id="btnQuit1" onclick="Exit();" type="button" value="取消"/>
    </label></td>
</tr>
</table>
</td></tr></table>

<!-- 表格 -->

<table class="xy_tb xy_tb2" style="margin-top:0px;">
<tr>
<td>
    <asp:GridView ID="gvlist" HeaderStyle-CssClass="gv_header_style" runat="server" AutoGenerateColumns="False"  DataKeyNames="M_ID" OnRowCommand="gvlist_RowCommand" Width="100%"  GridLines="None" OnRowDataBound="gvlist_RowDataBound"  >
<Columns>
    <asp:BoundField DataField="M_ID" HeaderText="M_ID" Visible="False" />
    <asp:BoundField DataField="M_Type" HeaderText="经营模式类别" ><ItemStyle  Width="80%" CssClass="gvLeft" />
        <HeaderStyle CssClass="gvLeft" />
    </asp:BoundField>
      <asp:ButtonField CommandName="up" HeaderText="修改" Text="&lt;img src=&quot;../images/edit.GIF&quot; /&gt;" >
          <ItemStyle Width="5%" />
      </asp:ButtonField>
      <asp:ButtonField CommandName="del" HeaderText="删除" Text="&lt;img src=&quot;../images/delete.GIF&quot; /&gt;">
          <ItemStyle Width="5%" />
      </asp:ButtonField>
</Columns>
        <PagerSettings FirstPageText="首页" LastPageText="尾页" Mode="NextPreviousFirstLast"
            NextPageText="下一页" PreviousPageText="上一页" />
</asp:GridView>
<p style="text-align:center;"><asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label></p>
    </td>
</tr>
</table><uc2:page id="Page1" runat="server">
    </uc2:page>
</div>

</td>
</tr>
</table>
</form>
</body>
</html>
