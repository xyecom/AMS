<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogUserbehavior.aspx.cs"
    Inherits="XYECOM.Web.xymanage.Global.LogUserbehavior" %>

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
                            <li><a href="LogUserLogin.aspx"><span>用户登录/注册日志管理</span></a></li>
                            <li class="current"><a href="LogUserbehavior.aspx"><span>用户操作行为日志</span></a></li>
                        </ul>
                    </div>
                    <table class="xy_tb xy_tb2">
                        <tr>
                            <td class="content_action">
                                用户名称或E-Mail：<asp:TextBox ID="txtname" runat="server" CssClass="input"></asp:TextBox>&nbsp;
                                操作项：<asp:DropDownList runat="server" ID="DDLoperate">
                                    <asp:ListItem Value="-1">请选择</asp:ListItem>
                                    <asp:ListItem Value="0">在线充值</asp:ListItem>
                                    <asp:ListItem Value="1">支付订单</asp:ListItem>
                                    <asp:ListItem Value="2">支付产品保证金</asp:ListItem>
                                    <asp:ListItem Value="3">支付合同保证金</asp:ListItem>
                                    <asp:ListItem Value="8">充值合同保证金</asp:ListItem>
                                </asp:DropDownList>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                操作时间：<input id="bgdate" type="text" runat="server" readonly="readonly" onclick="getDateString(this);"
                                    maxlength="10" style="width: 80px;" />
                                到
                                <input id="egdate" type="text" runat="server" readonly="readonly" onclick="getDateString(this);"
                                    maxlength="10" style="width: 80px;" />&nbsp;
                                <asp:Button ID="BtnSearch" runat="server" CssClass="button" Text="搜索" OnClick="BtnSearch_Click">
                                </asp:Button>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView HeaderStyle-CssClass="gv_header_style" ID="gvlist" runat="server" AutoGenerateColumns="False"
                                    DataKeyNames="ID" Width="100%" PageSize="20" GridLines="None">
                                    <Columns>
                                        <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                                        <asp:TemplateField HeaderText="选择">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkExport" runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle Width="5%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="用户名/E-Mail">
                                            <ItemTemplate>
                                                <%# GetUserName(Eval("AccountId").ToString())%>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="gvLeft" />
                                            <ItemStyle Width="15%" CssClass="gvLeft" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="操作项">
                                            <ItemTemplate>
                                                <%# new XYECOM.Business.Log().GetOperInfo(Eval("Operate").ToString())%>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="gvLeft" />
                                            <ItemStyle Width="10%" CssClass="gvLeft" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="OperateDescription" HeaderText="操作说明">
                                            <HeaderStyle CssClass="gvLeft" />
                                            <ItemStyle Width="45%" CssClass="gvLeft" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="OperateDate" HeaderText="操作时间">
                                            <HeaderStyle CssClass="gvLeft" />
                                            <ItemStyle Width="20%" CssClass="gvLeft" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="操作">
                                            <ItemTemplate>
                                                <a href="LogUserbehaviorInfo.aspx?ID=<%# Eval("Id").ToString()%>&backURL=<%# backURL %>">
                                                <img src="../images/look.gif" alt="查看" /></a>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="gvLeft" />
                                            <ItemStyle Width="10%" CssClass="gvLeft" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td class="content_action">
                                <input class="list_td04" id="chkAll" onclick="chkAll_true()" type="checkbox" name="chkAll"
                                    runat="server" />
                            全选
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
