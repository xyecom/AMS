<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomConfigField.aspx.cs" Inherits="XYECOM.Web.xymanage.Global.CustomConfigField" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>自定义配置字段</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
    <script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <h1><a href="../index.aspx">后台管理首页</a> >> 自定义配置字段</h1>
    <table width="100%" >
<tr>
<td class="right">    

<div class="main-setting">
<div class="itemtitle"><h3>自定义配置字段</h3>
<input id="btadd" class="addbtn" type="button" value="新增字段" onclick="location.href='EditCustomConfigField.aspx';"/>
</div>

<table class="xy_tb xy_tb2">
<tr>
    <th colspan="15" class="partition">使用说明</th>
</tr>
<tr>
    <td ></td>
</tr>
<tr class="nobg">
    <td colspan="2" class="tipsblock">
        <ul id="tipslis">
            <li>通过自定义配置字段可以提高模板调用配置数据的灵活性</li>
            <li>自定义配置字段可以通过 <font color="red">{config.Get("自定义字段名称")}</font> 的方式在模板中调用</li>
        </ul>
    </td>
</tr>
<tr class="nobg">
  <td colspan="2" class="td27">
<asp:GridView ID="gvlist" HeaderStyle-CssClass="gv_header_style" Width="100%" runat="server" AutoGenerateColumns="False" DataKeyNames="key" GridLines="None" OnRowDataBound="gvlist_RowDataBound">
    <Columns>
        <asp:BoundField Visible="False" DataField="key" />
        
        <asp:TemplateField HeaderText="选择">
            <ItemTemplate><asp:CheckBox ID="chkExport" runat="Server" /></ItemTemplate>
            <ItemStyle Width="5%" />
        </asp:TemplateField>
        
        <asp:BoundField HeaderText="名称(key)" DataField="Key" >
            <ItemStyle Width="20%" CssClass="gvLeft" />
            <HeaderStyle CssClass="gvLeft" />
        </asp:BoundField>
        
        <asp:BoundField HeaderText="值(value)" DataField="Value">
            <ItemStyle Width="60%" CssClass="gvLeft" />
            <HeaderStyle CssClass="gvLeft" />
        </asp:BoundField>
        
        <asp:TemplateField HeaderText="编辑">
            <ItemStyle Width="5%" />
            <ItemTemplate>
                <a href="EditCustomConfigField.aspx?key=<%# Eval("key") %>"><img src="../images/edit.GIF"; alt="点此编辑" /></a>
            </ItemTemplate>
        </asp:TemplateField>
    
    </Columns>
</asp:GridView>
<p style="text-align:center;"><asp:Label ID="lblMessage" runat="Server" ForeColor="red"></asp:Label></p>
  
  </td>
</tr>
<tr>
    <td class="vtop rowform">
    <input id="chkAll" onclick="chkAll_true();" type="checkbox" name="chkAll" runat="server" />全选
<asp:Button ID="lnkDel" runat="server" CssClass="button" Text="删除" OnClick="lnkDel_Click" />&nbsp;
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
