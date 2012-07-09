<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResumeList.aspx.cs" Inherits="XYECOM.Web.xymanage.UserManage.ResumeList" %>
<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc2" %>

<%@ Register Src="../UserControl/top.ascx" TagName="top" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>个人后台管理</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/XYLib.css" type="text/css" rel="Stylesheet" />
    <script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
    <script language ="javascript" type ="text/javascript" src ="../javascript/CheckedAll.js"></script>
    <script type="text/javascript" src="/common/js/date.js" ></script>
</head>
<body> 
    <form id="form1" runat="server">
    <h1><a href="../index.aspx">后台管理首页</a> >> 个人用户管理</h1>
<table  width="100%" >
<tr>
<!-- right -->
<td class="right">
<!--后台导航 -->
<div class="main-setting">
<div class="itemtitle"><h3>个人用户管理</h3>
<ul class="tab1">
<li><a href="IndividualList.aspx"><span>基本信息</span></a></li><li class="current"><a href="ResumeList.aspx"><span>简历信息</span></a></li></ul></div>

<table class="xy_tb xy_tb2">
<tr>
<td>

<table class="partition">
<tr>
    <th>教育程度：</th>
    <td>
        <asp:DropDownList ID="edulevel" runat="server">
            <asp:ListItem Value="-1" Selected="True">所有</asp:ListItem>
            <asp:ListItem Value="初中">初中</asp:ListItem>
            <asp:ListItem Value="中专">中专</asp:ListItem>
            <asp:ListItem Value="高中">高中</asp:ListItem>
            <asp:ListItem Value="大专">大专</asp:ListItem>
            <asp:ListItem Value="本科">本科</asp:ListItem>
            <asp:ListItem Value="硕士">硕士</asp:ListItem>
            <asp:ListItem Value="博士">博士</asp:ListItem>
            <asp:ListItem Value="更高">更高</asp:ListItem>          
        </asp:DropDownList>
    </td>
    <th>工作年限：</th>
    <td>
        <asp:DropDownList ID="workyears" runat="server">
            <asp:ListItem Value="-1" Selected="True">所有</asp:ListItem>
            <asp:ListItem Value="在读学生">在读学生</asp:ListItem>
            <asp:ListItem Value="应届毕业生">应届毕业生</asp:ListItem>
            <asp:ListItem Value="一年以上">一年以上</asp:ListItem>
            <asp:ListItem Value="两年以上">两年以上</asp:ListItem>
            <asp:ListItem Value="三年以上">三年以上</asp:ListItem>
            <asp:ListItem Value="五年以上">五年以上</asp:ListItem>
            <asp:ListItem Value="八年以上">八年以上</asp:ListItem>
            <asp:ListItem Value="十年以上">十年以上</asp:ListItem>
        </asp:DropDownList>
    </td>
</tr>
<tr>
    <th>所在城市：</th>
    <td>
     <div id="classType"></div>
        <input type ="hidden" id="areatypeid" runat="server" />
        <script type="text/javascript">
        var cla = new ClassType("cla",'area','classType','areatypeid');
        cla.Mode ="select";
        cla.Init();
        </script>
    </td>
    <th>毕业时间：</th>
    <td>
    <input id="bgdate" type="text" runat="server" onclick="getDateString(this);" readonly="readonly" maxlength="10" style="width:80px;" />
     到
    <input id="egdate" type="text" runat="server" onclick="getDateString(this);" readonly="readonly" maxlength="10" style="width: 80px;" />
    </td>
</tr>
<tr class="content_action">
<td></td>
    <td colspan="3">
    <asp:Button ID="Button2" runat="server" Text="搜索" CssClass ="button" OnClick="Button2_Click" />
    <input type="reset" value="重置" class ="button" />
    </td>
</tr>
</table>
</td>
</tr>
<tr>
<td>

<asp:GridView ID="gvlist"  HeaderStyle-CssClass="gv_header_style" runat="server" AutoGenerateColumns="False"  DataKeyNames="U_ID,U_Name"  Width="100%" GridLines="None" OnRowDataBound="gvlist_RowDataBound">
<Columns>
<asp:BoundField DataField="U_ID" HeaderText="U_ID" Visible="False" />
<asp:TemplateField HeaderText="选择">
 <ItemTemplate>
<asp:CheckBox ID="chkExport" runat="server" />
</ItemTemplate> 
    <ItemStyle Width="5%" />
</asp:TemplateField>
    <asp:TemplateField HeaderText="发布者">
    <ItemStyle Width="15%" />
        <ItemTemplate>
            <a href='IndividualInfo.aspx?U_ID=<%# Eval("U_ID") %>&backURL=<%# backURL %>'><%# Eval("U_Name")%></a>
        </ItemTemplate>
    </asp:TemplateField>
<asp:BoundField DataField="RE_School" HeaderText="毕业学校">
    <HeaderStyle CssClass="gvLeft" />
    <ItemStyle CssClass="gvLeft" Width="15%" />
</asp:BoundField>
<asp:BoundField DataField="RE_Speciality" HeaderText="所学专业">
    <HeaderStyle CssClass="gvLeft" />
    <ItemStyle CssClass="gvLeft" Width="15%" />
</asp:BoundField>
<asp:BoundField DataField="RE_Schoolage" HeaderText="教育程度">
    <HeaderStyle CssClass="gvLeft" />
    <ItemStyle CssClass="gvLeft" Width="10%" />
</asp:BoundField>

<asp:TemplateField HeaderText="期望城市">
    <ItemStyle Width="10%" CssClass="gvLeft" HorizontalAlign="Left"/>
    <ItemTemplate>
        <%#GetAreaName(DataBinder.Eval(Container,"DataItem.Area_Id").ToString())%>
    </ItemTemplate>
</asp:TemplateField>

<asp:BoundField DataField="RE_JobYear" HeaderText="工作年限">
    <HeaderStyle CssClass="gvLeft" />
    <ItemStyle CssClass="gvLeft" Width="10%" />
</asp:BoundField>
<asp:BoundField DataField="RE_Gyear" HeaderText="毕业时间" DataFormatString="{0:d}" HtmlEncode="False">
    <ItemStyle Width="10%" />
</asp:BoundField>

<asp:TemplateField HeaderText="静态页面">
<ItemStyle CssClass="gvLeft" Width="10%" />
    <ItemTemplate>
        <%# Eval("RE_HtmlPage").ToString() != "" ? "<a href=\"/" + Eval("RE_HtmlPage").ToString() + "\" target=\"_black\">查看</a>" : "-"%>
    </ItemTemplate>
</asp:TemplateField>
 
</Columns>
</asp:GridView>
<p style="text-align:center;"><asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label></p> 
</td>
</tr>
<tr>
    <td class="content_action">
    <input id="chkAll" onclick="chkAll_true()" type="checkbox" name="chkAll" runat="server" />全选
    <asp:Button ID="btnCreateHtml" runat="server" CssClass="button" OnClick="btnCreateHtml_Click"
        Text="生成静态页面" />&nbsp;
    <asp:Button ID="btnDelHtml" runat="server" CssClass="button" OnClick="btnDelHtml_Click"
        Text="删除静态页面" />
    </td>
</tr>
</table>

<uc2:page ID="Page1" runat="server"/>
</div>
</td>
</tr>
</table>
    </form>
</body>
</html>
