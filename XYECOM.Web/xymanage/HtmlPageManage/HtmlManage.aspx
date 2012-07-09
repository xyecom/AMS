<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HtmlManage.aspx.cs" Inherits="XYECOM.Web.xymanage.HtmlPageManage.HtmlManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>静态页面管理</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="../css/cue.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" src="/Common/js/base.js" language="javascript"></script>
    <script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
    <script type="text/javascript" src="/common/js/date.js" ></script>
    <script type="text/javascript" src="../javascript/templates.js" ></script>
</head>
<body>
    <form id="form1" runat="server">
    
    <h1><a href="../index.aspx">后台管理首页</a> >> 静态页面管理</h1>
<table width="100%" >
<tr>
<td class="right">
    


<div class="main-setting">
<div class="itemtitle"><h3>静态页面管理</h3>
<ul id="mainMenus0" runat="server" class="tab1">
<li><a href='HTMLSet.aspx'><span>相关设置</span></a></li>
<li class="current"><a href='#'><span>添加任务</span></a></li>
<li><a href='HtmlState.aspx'><span>任务状态查看</span></a></li>
</ul>
</div>
<div class="itemtitle"><h3>栏目首页</h3></div>
<table class="xy_tb  border_buttom0">
<tr>
<td>
    <asp:DataList ID="DefaultPage" runat="server" RepeatColumns="3" RepeatDirection="Horizontal" Width="100%">
        <ItemTemplate>
        <table width="100%" >
            <tr height="30px">
                <td width="20px" style="text-align:center;">
                    <input id="cbSel" type="checkbox" runat="server" value='<%# Eval("PageHttpURL") %>' /></td>
                <td style="width:130px; text-align:left;">
                    <asp:Label ID="lbPageName" runat="server" Text='<%# Eval("PageName") %>'></asp:Label>
                    <asp:Label ID="lbPageModule" runat="server" Visible="false" Text='<%# Eval("PageModuleName") %>'></asp:Label>
                </td>
                <td width="110px"><%# Eval("CreateTime") %></td>
            </tr>
        </table>
        </ItemTemplate>
    </asp:DataList>

</td></tr></table>

<div class="itemtitle" style="margin-top:10px;"><h3>栏目详细信息页面管理</h3></div>
<table class="xy_tb xy_tb2">
<tr>
<td>
<table width="100%" >
    <tr>
        <th style="width:5%; text-align:center;">
            选择</th>
        <th style="width:15%; text-align:left;">
            栏目</th>
        <th style="width:25%;text-align:left;">
            起始时间</th>
        <th style="width:10%;text-align:left;">
            仅生成新增的</th>
        <th style="width:45%;text-align:left;">
            类别</th>
    </tr>
    <asp:Repeater ID="InfoPage" runat="server" OnItemDataBound="InfoPage_ItemDataBound">
        <ItemTemplate>
    <tr>
        <td style="text-align:center;">
            <input id="cbSel" runat="server" type="checkbox" value='<%# Eval("PageType") %>' /></td>
        <td>            
            <asp:Label ID="lbPageName" runat="server" Text='<%# Eval("PageName") %>'></asp:Label>
        </td>
        <td>
        <input id="tbBeginTime" type="text" runat="server" onclick="getDateString(this);" maxlength="10" style="width:80px;" />
        <asp:Literal ID="litspac" runat="server" Text="-"></asp:Literal>
        <input id="tbEndTime" type="text" runat="server" onclick="getDateString(this);" maxlength="10" style="width: 80px;" /></td>
        <td style="text-align:center;"><input id="newOnly" runat="server" type="checkbox" /></td>
        <td>
            <input name="hidClassID" type="hidden" id="hidClassID" runat="server" />
            <input name="moduleflag" type="hidden" id="moduleflag" runat="server" value='<%# Eval("PageModuleName") %>' />
            <asp:Literal ID="ClassShow" runat="server"></asp:Literal>
        </td>
    </tr>
    </ItemTemplate>
    </asp:Repeater>
</table>
<table width="100%">
    <tr>
        <th style="text-align:left; width:100%;">
            <input id="btnSelAll" type="button" class="button" value="反选" onclick="SelectAll();" />
            <asp:Button ID="btnCreate" runat="server" CssClass="button" Text="生成静态页" OnClick="btnCreate_Click" />
            <asp:Button ID="btnDelete" runat="server" CssClass="button" Text="删除静态页" OnClick="btnDelete_Click" />
        </th>
    </tr>
</table>
</td></tr></table>
</div>
</td>
</tr></table>
    </form>
</body>
</html>
