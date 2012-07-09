<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="XYECOM.Web.xymanage.Ranking.List" %>

<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc2" %>

<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>排名管理</title>
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
<script type="text/javascript" src="/common/js/date.js" ></script>
</head>
<body>
<form id="Form1" method="post" runat="server">
<h1><a href="../index.aspx">后台设置首页</a> >> 当前排名管理</h1>
<table width="100%" >
<tr>
<td class="right">

<div class="main-setting">
<div class="itemtitle"><h3>排名管理 </h3>
<ul class="tab1">
<li class="current"><a href="List.aspx"><span>排名管理 </span></a></li>
<li><a href="LogList.aspx"><span>日志管理 </span></a></li>
<li><a href="Setting.aspx"><span>相关设置</span></a></li>
</ul>
</div>

<table class="xy_tb xy_tb2">
<tr>
<td class="">

<table class="partition ">
        <tr>
            <th>关键词：</th>
            <td>
                <asp:TextBox ID="txtkey" runat="server" Columns="28" MaxLength="30"></asp:TextBox>
            </td>
            <th>企业帐号或名称：</th>
            <td>
                <asp:TextBox ID="txtUserIdOrName" runat="server" MaxLength="30" Columns="28"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>开始时间：</th>
            <td>
             <input id="txtBeginTimeStart" type="text" runat="server" onclick="getDateString(this);" maxlength="10" style="width:75px;" readonly="readonly" />
             到
            <input id="txtBeginTimeEnd" type="text" runat="server" onclick="getDateString(this);" maxlength="10" style="width: 75px;" readonly="readonly" />                
            </td>
            <th>结束时间：</th>
            <td>
             <input id="txtEndTimeStart" type="text" runat="server" onclick="getDateString(this);" maxlength="10" style="width:75px;" readonly="readonly"/>
             到
            <input id="txtEndTimeEnd" type="text" runat="server" onclick="getDateString(this);" maxlength="10" style="width: 75px;" readonly="readonly"/>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="3">
                <asp:Button ID="btnSearch" runat="server" CssClass="button" Text="搜索" OnClick="btnSearch_Click" />
                <asp:Button ID="btnReset" runat="server" CssClass="button" Text="重置" OnClick="btnReset_Click"/>
            </td>
        </tr>
    </table>

</td>
</tr>
<tr>
<td>
<asp:GridView ID="gvList" HeaderStyle-CssClass="gv_header_style" Width="100%" runat="server" AutoGenerateColumns="False" DataKeyNames="RID" GridLines="None">
<Columns>

    <asp:BoundField DataField="Rid" HeaderText="Rid" Visible="False" />

    <asp:TemplateField HeaderText="选择">
        <ItemTemplate>
            <asp:CheckBox ID="chkExport" runat="server" />
        </ItemTemplate>
        <ItemStyle Width="5%" />
    </asp:TemplateField>



    <asp:TemplateField HeaderText="关键词">
    <ItemStyle Width="15%"  CssClass="gvLeft"/>
        <ItemTemplate>
            <a href='../basic/SearchKeyInfo.aspx?sk_id=<%# Eval("KeyId") %>&backURL=<%# backURL %>'><%# Eval("keyword")%></a>
        </ItemTemplate>
    </asp:TemplateField>


    <asp:BoundField HeaderText="名次" DataField="rank" >
        <ItemStyle Width="5%" CssClass="gvCenter" />
        <HeaderStyle CssClass="gvCenter" />
    </asp:BoundField>


    <asp:TemplateField HeaderText="企业名称">
    <ItemStyle Width="25%" />
        <ItemTemplate>
            <a href='../UserManage/UserInfo.aspx?U_ID=<%# Eval("UserID") %>&backURL=<%# backURL %>'><%# Eval("UI_name") %></a>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:BoundField HeaderText="开始时间" DataField="BeginTime" DataFormatString="{0:yyyy-MM-dd}">
        <ItemStyle Width="15%" CssClass="gvLeft" />
        <HeaderStyle CssClass="gvLeft" />
    </asp:BoundField>
    <asp:BoundField HeaderText="结束时间" DataField="EndTime"  DataFormatString="{0:yyyy-MM-dd}">
        <ItemStyle Width="15%" CssClass="gvLeft" />
        <HeaderStyle CssClass="gvLeft" />
    </asp:BoundField>

    <asp:TemplateField HeaderText="查看/编辑">
        <ItemStyle Width="10%" />
        <ItemTemplate>
            <a href='Info.aspx?rid=<%# Eval("rid") %>&backURL=<%# backURL %>'><img src="../images/look.GIF" alt="查看详细/编辑结束时间" /></a>
        </ItemTemplate>
    </asp:TemplateField>
      
</Columns>
    <HeaderStyle CssClass="gv_header_style" />
</asp:GridView>
<p style="text-align:center;"><asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></p>
</td>
</tr>
<tr>
    <td class="content_action">
    <input id="chkAll" onClick="chkAll_true()" type="checkbox" name="chkAll"/>全选&nbsp;
    <asp:Button ID="btnDelete" runat="server" CssClass="button" Text="立刻结束" OnClick="btnDelete_Click" />
  </td>
</tr>

</table>
    <uc2:page ID="Page1" runat="server" />
</div>
</td>
</tr>
</table>
</form>
</body>
</html>

