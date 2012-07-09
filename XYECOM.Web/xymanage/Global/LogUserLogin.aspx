<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogUserLogin.aspx.cs" Inherits="XYECOM.Web.xymanage.Global.LogUserLogin" %>

<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>日志管理</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <script language="javascript" type="text/javascript" src="/common/js/base.js"></script>
    <script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
    <script type="text/javascript" src="/common/js/date.js"></script>
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <h1>
        <a href="../index.aspx">后台管理首页</a> >> 日志管理</h1>
    <table width="100%">
        <tr>
            <td class="right">
                <div class="main-setting">
                    <div class="itemtitle">
                        <h3>
                            用户日志管理</h3>
                        <ul class="tab1">
                            <li><a href="LogManage.aspx"><span>管理员日志管理</span></a></li>
                            <li class="current"><a href="LogUserLogin.aspx"><span>用户登录/注册日志管理</span></a></li>
                            <li><a href="LogUserbehavior.aspx"><span>用户操作行为日志</span></a></li>
                        </ul>
                    </div>
                    <table class="xy_tb xy_tb2">
                        <tr>
                            <th>
                                用户名称或E-Mail：
                            </th>
                            <td>
                                <asp:TextBox ID="txtname" runat="server" CssClass="input"></asp:TextBox>&nbsp;
                            </td>
                            <th align="right">
                                日期范围：
                            </th>
                            <td>
                                <input id="bgdate" type="text" runat="server" onclick="getDateString(this);" maxlength="10"
                                    style="width: 80px;" readonly="readonly" />
                                到
                                <input id="egdate" type="text" runat="server" onclick="getDateString(this);" maxlength="10"
                                    style="width: 80px;" readonly="readonly" />
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <asp:Button ID="BtnSearch" runat="server" CssClass="button" Text="搜索" OnClick="BtnSearch_Click">
                                </asp:Button>
                                <input type="reset" value="重置" class="button" />
                            </th>
                            <td>
                                &nbsp;
                            </td>
                            <th>
                            </th>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <table class="xy_tb xy_tb2">
                        <tr>
                            <td>
                                <asp:GridView HeaderStyle-CssClass="gv_header_style" ID="gvlist" runat="server" AutoGenerateColumns="False"
                                    DataKeyNames="UL_ID" Width="100%" PageSize="20" GridLines="None">
                                    <Columns>
                                        <asp:BoundField DataField="UL_ID" HeaderText="UL_ID" Visible="False" />
                                        <asp:TemplateField HeaderText="选择" Visible="false">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkExport" runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle Width="5%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="用户名/E-Mail">
                                            <ItemTemplate>
                                                <%# GetUserName(XYECOM.Core.MyConvert.GetInt32(Eval("U_ID").ToString())) %>
                                            </ItemTemplate>
                                            <ItemStyle Width="15%" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="LastLoginDate" HeaderText="登录时间">
                                            <HeaderStyle CssClass="gvLeft" />
                                            <ItemStyle Width="20%" CssClass="gvLeft" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="LastLoginIP" HeaderText="登录IP">
                                            <ItemStyle Width="15%" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                    <p style="text-align: center;">
                        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label></p>
                    <uc2:page ID="Page1" runat="server" />
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
