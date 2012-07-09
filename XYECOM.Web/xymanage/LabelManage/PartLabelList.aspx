<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PartLabelList.aspx.cs" Inherits="XYECOM.Web.xymanage.LabelManage.PartLabelList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>企业专栏标签管理</title>
        <link href="../css/style.css" type="text/css" rel="stylesheet" />
        <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
        <script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
        <script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
</head>
<body>
    <form id="form1" runat="server">
<h1><a href="../index.aspx">后台管理首页</a> >> 企业专栏标签列表</h1>
<div class="main-setting">
<div class="itemtitle"><h3>企业专栏标签列表</h3>
<ul id="mainMenus0" runat="server" class="tab1">
</ul>
<input type="button" class="addbtn" value="新增专栏" onclick="location='AddPartLabel.aspx';" />

</div>


<table class="xy_tb xy_tb2">
<tr>
<td>
<asp:GridView ID="gvlist" HeaderStyle-CssClass="gv_header_style" Width="100%" runat="server" AutoGenerateColumns="False" DataKeyNames="PartId" GridLines="None" OnRowCommand="gvlist_RowCommand" OnRowDataBound="gvlist_RowDataBound">
<Columns>
<asp:BoundField Visible="False" DataField="PartId" >
    <ItemStyle Width="1%" />
</asp:BoundField>
<asp:TemplateField HeaderText="选择"> 
    <ItemTemplate>
    <asp:CheckBox ID="chkExport" runat="server" />    
    </ItemTemplate>
    <ItemStyle Width="5%" />
</asp:TemplateField>

<asp:BoundField HeaderText="标签名称" DataField="LabelName" >
    <ItemStyle Width="13%" CssClass="gvLeft"/>
    <HeaderStyle  CssClass="gvLeft" Width="10%" />
</asp:BoundField>

<asp:BoundField HeaderText="专栏名称" DataField="PartName" >
    <ItemStyle Width="13%" CssClass="gvLeft" />
    <HeaderStyle CssClass="gvLeft" Width="15%" />
</asp:BoundField>

<asp:TemplateField HeaderText="开始时间">
    <ItemStyle CssClass="gvLeft" Width="9%" />
    <HeaderStyle CssClass="gvLeft" />
    <ItemTemplate>
       <%# XYECOM.Core.MyConvert.GetDateTime(DataBinder.Eval(Container, "DataItem.BeginTime").ToString()).ToString("yyyy-MM-dd")%>
    </ItemTemplate>
</asp:TemplateField>



<asp:TemplateField HeaderText="结束时间">
    <ItemStyle CssClass="gvLeft" Width="9%" />
    <HeaderStyle CssClass="gvLeft" />
    <ItemTemplate>
       <%# XYECOM.Core.MyConvert.GetDateTime(DataBinder.Eval(Container, "DataItem.EndTime").ToString()).ToString("yyyy-MM-dd")%>
    </ItemTemplate>
</asp:TemplateField>


<asp:TemplateField HeaderText="企业名称">
    <ItemStyle CssClass="gvLeft" Width="25%" />
    <HeaderStyle CssClass="gvLeft" />
    <ItemTemplate>
        <a href='../UserManage/UserInfo.aspx?U_ID=<%# Eval("UserId") %>&backURL=<%# backURL %>'><%#GetCompanyName(DataBinder.Eval(Container, "DataItem.UserId"))%></a>
    </ItemTemplate>
</asp:TemplateField>

        
   <asp:TemplateField HeaderText="预览">
    <ItemStyle Width="5%" />
        <ItemTemplate>
            <a href='PartLabelView.aspx?partId=<%# Eval("PartId") %>'>预览</a>
        </ItemTemplate>
    </asp:TemplateField> 
    
    <asp:ButtonField HeaderText="审核" DataTextField="AuditingState" CommandName="ChangeAuditing" >
    <ItemStyle Width="10%" />
</asp:ButtonField>

 <asp:TemplateField HeaderText="编辑">
    <ItemStyle Width="6%" />
        <ItemTemplate>
            <a href='EditPartLabel.aspx?partId=<%# Eval("PartId") %>'>编辑</a>
        </ItemTemplate>
    </asp:TemplateField> 
    
        
</Columns>
</asp:GridView>
<p style="text-align:center;"><asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></p>
</td>
</tr>
<tr>
<td class="content_action"><input id="chkAll" onclick="chkAll_true()" type="checkbox" name="chkAll" runat="server" />全选
    <asp:Button ID="btndelete" runat="server" CssClass="button" OnClick="btnDelete_Click"
        Text="删除" />
    </td>
</tr>
</table>

</div>

    </form>
</body>
</html>
