<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LivenessInfo.aspx.cs" Inherits="XYECOM.Web.xymanage.UserManage.LivenessInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>用户信息管理</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/XYLib.css" type="text/css" rel="Stylesheet" />
    <script language="javascript" type="text/javascript" src="/common/js/base.js"></script>
    <script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
    <script type="text/javascript" src="/common/js/date.js"></script>
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <h1>
        <a href="../index.aspx">后台设置首页</a> >> 用户列表</h1>
    <table width="100%">
        <tr>
            <!-- right -->
            <td class="right">
                <div class="main-setting">
                    <div class="itemtitle">
                        <h3>
                            用户列表</h3>
                    </div>
                    <table class="xy_tb xy_tb2">
                        <tr>
                            <td>
                                <table class="partition">
                                    <tr>
                                        <th>
                                            用户名称：
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtKeyWord" runat="server" Width="100px"></asp:TextBox>
                                        </td>
                                        <th>
                                            审核状态：
                                        </th>
                                        <td>
                                            <asp:RadioButtonList ID="ddlState" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="" Selected="True">所有</asp:ListItem>
                                                <asp:ListItem Value="-1">未审核</asp:ListItem>
                                                <asp:ListItem Value="1">通过审核</asp:ListItem>
                                                <asp:ListItem Value="0">未通过审核</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            日期范围：
                                        </th>
                                        <td>
                                            <input id="bgdate" type="text" runat="server" onclick="getDateString(this);" maxlength="10"
                                                style="width: 80px;" readonly="readonly" />
                                            到
                                            <input id="egdate" type="text" runat="server" onclick="getDateString(this);" maxlength="10"
                                                style="width: 80px;" readonly="readonly" />
                                        </td>
                                        <th>
                                        </th>
                                        <td>
                                            <asp:Button ID="Button2" runat="server" Text="搜索" CssClass="button" OnClick="Button2_Click" />
                                            <input type="reset" value="重置" class="button" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gvlist" HeaderStyle-CssClass="gv_header_style" runat="server" AutoGenerateColumns="False"
                                    Width="100%" OnRowDataBound="gvlist_RowDataBound" GridLines="None" AllowPaging="True">
                                    <Columns>
                                        <asp:TemplateField HeaderText="用户名">
                                            <ItemStyle CssClass="gvLeft" Width="18%" />
                                            <HeaderStyle CssClass="gvLeft" />
                                            <ItemTemplate>
                                                <a href='UserMoreInfo.aspx?U_ID=<%# Eval("U_ID") %>&backURL=<%# backURL %>'>
                                                    <%# Eval("U_Name") %></a><br />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="公司名称">
                                            <HeaderStyle CssClass="gvLeft" />
                                            <ItemStyle CssClass="gvLeft" Width="20%" />
                                            <ItemTemplate>
                                                <div style="margin-top: 2px; color: #f60;">
                                                    <%# Eval("UI_Name") %><br />
                                                </div>
                                                <a href="<%# Eval("UI_Homepage") %>" target="_blank">
                                                    <%# Eval("UI_Homepage") %></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="登陆次数">
                                            <ItemStyle CssClass="gvLeft" Width="8%" />
                                            <HeaderStyle CssClass="gvLeft" />
                                            <ItemTemplate>
                                                共登录<span style="color: Red; font-weight: bolder;"><%# Eval("LoginNum") %></span>
                                                次
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="LastLoginDate" HeaderText="最后登陆时间">
                                            <HeaderStyle Width="12%" />
                                            <ItemStyle Width="12%" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="详细">
                                            <ItemStyle CssClass="gvLeft" Width="10%" />
                                            <HeaderStyle CssClass="gvLeft" />
                                            <ItemTemplate>
                                                <a href='/xymanage/Global/LogUserLogin.aspx?KeyWord=<%# Eval("U_name") %>&bgdate=<%# begindate %>&egdate=<%# enddate %>&backURL=<%# backURL %>'>
                                                    <img src="../images/look.gif" alt="查看" /></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="gv_header_style"></HeaderStyle>
                                    <PagerSettings Visible="False" />
                                </asp:GridView>
                                <p style="text-align: center;">
                                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label></p>
                            </td>
                        </tr>
                    </table>
                    <XYECOM:Page ID="Page1" runat="server" OnPageChanged="Page1_PageChanged" PageSize="10" />
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
