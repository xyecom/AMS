<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AreaSiteManage.aspx.cs" Inherits="XYECOM.Web.xymanage.Global.AreaSiteManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>地方站管理</title>
      <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
    <script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <h1><a href="../index.aspx">后台管理首页</a> >> 地方站管理</h1>
    <table width="100%" >
<tr>
<td class="right">    

<div class="main-setting">
<div class="itemtitle"><h3>地方站管理</h3>
<input id="btadd" class="addbtn" type="button" value="新增地方站" onclick="location.href='EditAreaSite.aspx';"/>
</div>

<table class="xy_tb xy_tb2">
<tr class="nobg">
  <td class="td27">
<asp:GridView ID="gvlist" HeaderStyle-CssClass="gv_header_style" Width="100%" runat="server" AutoGenerateColumns="False" DataKeyNames="id" GridLines="None" OnRowDataBound="gvlist_RowDataBound">
    <Columns>
        <asp:BoundField Visible="False" DataField="key" />
        
        <asp:TemplateField HeaderText="选择">
            <ItemTemplate><asp:CheckBox ID="chkExport" runat="Server" /></ItemTemplate>
            <ItemStyle Width="5%" />
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="地区">
            <HeaderStyle CssClass="gvLeft" />
            <ItemStyle CssClass="gvLeft" Width="20%" />
            <ItemTemplate>
                <%#GetAraName(DataBinder.Eval(Container, "DataItem.AreaId"))%>
            </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="访问地址">
            <HeaderStyle CssClass="gvLeft" />
            <ItemStyle CssClass="gvLeft" Width="60%" />
            <ItemTemplate>
                <a href="<%#GetHref(DataBinder.Eval(Container, "DataItem.FlagName"))%>" target="_blank"><%#GetHref(DataBinder.Eval(Container, "DataItem.FlagName"))%></a>
            </ItemTemplate>
        </asp:TemplateField>
               
        
        <asp:TemplateField HeaderText="编辑">
            <ItemStyle Width="5%" />
            <ItemTemplate>
                <a href="EditAreaSite.aspx?siteid=<%# Eval("id") %>"><img src="../images/edit.GIF"; alt="点此编辑" /></a>
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
