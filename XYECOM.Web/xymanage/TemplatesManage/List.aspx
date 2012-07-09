<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_TemplatesManage_List" Codebehind="List.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html  xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>模板列表</title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312"/>
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<link href="/common/css/XYLib.css" type="text/css" rel="Stylesheet" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script type="text/javascript" language="javascript" src="../JavaScript/CheckedAll.js"></script>
<script type="text/javascript" language="javascript" src="../javascript/templates.js"></script>
</head>
<body>
<form id="Form1" method="post" runat="server">
<!-- content  -->
<h1><a href="../index.aspx">后台设置首页</a> >> 模板列表</h1>
<table width="100%" >
<tr>
<td class="right">


<div class="main-setting">
<div class="itemtitle"><h3>模板列表</h3>

</div>

<table class="xy_tb xy_tb2">
<tr>
<td class="partition2">
<asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" Width="100%" GridLines="None" DataKeyNames="T_ID">
<Columns>
<asp:TemplateField HeaderText="选择">
<ItemTemplate><input type="checkbox" id="T_ID" value='<%# DataBinder.Eval(Container, "DataItem.T_ID").ToString() %>' name="T_ID" />
</ItemTemplate>
</asp:TemplateField>
    <asp:BoundField DataField="T_ID" Visible="False" />
<asp:BoundField HeaderText="名称" DataField="T_Name" >
    <HeaderStyle CssClass="gvLeft" />
    <ItemStyle CssClass="gvLeft" />
</asp:BoundField>
<asp:BoundField DataField="T_Path" HeaderText="路径" >
    <HeaderStyle CssClass="gvLeft" />
    <ItemStyle CssClass="gvLeft"  />
</asp:BoundField>
<asp:BoundField HeaderText="作者" DataField="T_Author" >
    <HeaderStyle CssClass="gvLeft" />
    <ItemStyle CssClass="gvLeft" />
</asp:BoundField>
<asp:BoundField HeaderText="创建时间" DataField="T_AddDate" DataFormatString="{0:d}" >
</asp:BoundField>
<asp:BoundField HeaderText="版权" DataField="T_Copyright" >
    <HeaderStyle CssClass="gvLeft" />
    <ItemStyle CssClass="gvLeft" />
</asp:BoundField>
<asp:BoundField HeaderText="版本" DataField="T_Ver" >
</asp:BoundField>
    <asp:TemplateField HeaderText="入库">
        <ItemTemplate>
            <asp:Label ID="Label1" runat="server" Text='<%# Valid(DataBinder.Eval(Container, "DataItem.valid").ToString())%>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="启用" ShowHeader="False">
        <ItemTemplate>
        <asp:Label ID="Label2" runat="server" Text='<%# IsFlag(DataBinder.Eval(Container, "DataItem.T_Flag").ToString())%>'></asp:Label>
            <asp:LinkButton ID="btnUse" runat="server" CommandArgument='<%# Eval("T_ID") %>' Text="启用" OnClick="btnUse_Click"></asp:LinkButton>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="生成全部" ShowHeader="False">
        <ItemTemplate>
            <img src="../images/manage_base.GIF"; alt="生成全部" onclick='createAll("<%# Eval("T_Name") %>");' style="cursor:pointer"/>
        </ItemTemplate>
    </asp:TemplateField>
<asp:HyperLinkField HeaderText="进入" DataNavigateUrlFields="T_Name,T_ID" DataNavigateUrlFormatString="TemplatesTree.aspx?path={0}&amp;T_ID={1}" Text="&lt;img src=&quot;../images/look.gif&quot; /&gt;" ><ItemStyle CssClass="action" Width="5%" /></asp:HyperLinkField>
</Columns>
</asp:GridView>
</td>
</tr>
<tr>
<td class="content_action">
<asp:Button ID="lnkDel" runat="server" CssClass="button" Text="删除" OnClick="lnkDel_Click" />
<input class="button" value="入库" onclick="javascript:return addtemp();" type="button" />
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
