﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogList.aspx.cs" Inherits="XYECOM.Web.xymanage.Ranking.LogList" %>

<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc2" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>排名管理</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <script language="javascript" type="text/javascript" src="/common/js/base.js"></script>
    <script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
    <script type="text/javascript" src="/common/js/date.js"></script>
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <h1>
        <a href="../index.aspx">后台设置首页</a> >> 排名日志管理</h1>
    <table width="100%">
        <tr>
            <td class="right">
                <div class="main-setting">
                    <div class="itemtitle">
                        <h3>
                            排名管理
                        </h3>
                        <ul class="tab1">
                            <li><a href="List.aspx"><span>排名管理 </span></a></li>
                            <li class="current"><a href="LogList.aspx"><span>日志管理 </span></a></li>
                            <li><a href="Setting.aspx"><span>相关设置</span></a></li>
                        </ul>
                    </div>
                    <table class="xy_tb xy_tb2">
                        <tr>
                            <td class="">
                                <table class="partition ">
                                    <tr>
                                        <th>
                                            关键词：
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtkey" runat="server" Columns="28" MaxLength="30"></asp:TextBox>
                                        </td>
                                        <th>
                                            企业帐号或名称：
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtUserIdOrName" runat="server" MaxLength="30" Columns="28"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            开始时间：
                                        </th>
                                        <td>
                                            <input id="txtBeginTimeStart" type="text" runat="server" onclick="getDateString(this);"
                                                maxlength="10" readonly="readonly" style="width: 75px;" />
                                            到
                                            <input id="txtBeginTimeEnd" type="text" runat="server" onclick="getDateString(this);"
                                                maxlength="10" readonly="readonly" style="width: 75px;" />
                                        </td>
                                        <th>
                                            结束时间：
                                        </th>
                                        <td>
                                            <input id="txtEndTimeStart" type="text" runat="server" onclick="getDateString(this);"
                                                maxlength="10" readonly="readonly" style="width: 75px;" />
                                            到
                                            <input id="txtEndTimeEnd" type="text" runat="server" onclick="getDateString(this);"
                                                maxlength="10" readonly="readonly" style="width: 75px;" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td colspan="3">
                                            <asp:Button ID="btnSearch" runat="server" CssClass="button" Text="搜索" OnClick="btnSearch_Click" />
                                            <asp:Button ID="btnReset" runat="server" CssClass="button" Text="重置" OnClick="btnReset_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gvList" HeaderStyle-CssClass="gv_header_style" Width="100%" runat="server"
                                    AutoGenerateColumns="False" DataKeyNames="LogId" GridLines="None">
                                    <Columns>
                                        <asp:BoundField DataField="LogId" HeaderText="LogId" Visible="False" />
                                        <asp:TemplateField HeaderText="选择">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkExport" runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle Width="5%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="关键词">
                                            <ItemStyle Width="15%" CssClass="gvLeft" />
                                            <ItemTemplate>
                                                <a href='../basic/SearchKeyInfo.aspx?sk_id=<%# Eval("KeyId") %>&backURL=<%# backURL %>'>
                                                    <%# Eval("keyword")%></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="名次" DataField="rank">
                                            <ItemStyle Width="8%" CssClass="gvCenter" />
                                            <HeaderStyle CssClass="gvCenter" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="支付金额" DataField="amount">
                                            <ItemStyle Width="10%" CssClass="gvRight" />
                                            <HeaderStyle CssClass="gvRight" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="企业名称">
                                            <ItemStyle Width="29%" />
                                            <ItemTemplate>
                                                <a href='../UserManage/UserInfo.aspx?U_ID=<%# Eval("UserID") %>&backURL=<%# backURL %>'>
                                                    <%# Eval("UI_name") %></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="开始时间" DataField="BeginTime" DataFormatString="{0:yyyy-MM-dd}">
                                            <ItemStyle Width="10%" CssClass="gvLeft" />
                                            <HeaderStyle CssClass="gvLeft" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="结束时间" DataField="EndTime" DataFormatString="{0:yyyy-MM-dd}">
                                            <ItemStyle Width="10%" CssClass="gvLeft" />
                                            <HeaderStyle CssClass="gvLeft" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="实际结束时间" DataField="RealEndTime" DataFormatString="{0:yyyy-MM-dd}">
                                            <ItemStyle Width="12%" CssClass="gvLeft" />
                                            <HeaderStyle CssClass="gvLeft" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                                <p style="text-align: center;">
                                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label></p>
                            </td>
                        </tr>
                        <tr>
                            <td class="content_action">
                                <input id="chkAll" onclick="chkAll_true()" type="checkbox" name="chkAll" />全选&nbsp;
                                <asp:Button ID="btnDelete" runat="server" CssClass="button" Text="删除" OnClick="btnDelete_Click" />
                            </td>
                        </tr>
                    </table>
                    <uc2:page ID="Page1" runat="server" PageSize="20" />
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
