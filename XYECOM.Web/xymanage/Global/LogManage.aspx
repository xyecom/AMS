<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogManage.aspx.cs" Inherits="XYECOM.Web.xymanage.Global.LogManage" %>

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
    <script type="text/javascript" src="/common/js/date.js">        function DIV1_onclick() {

        }

    </script>
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
                            日志管理</h3>
                        <ul class="tab1">
                            <li class="current"><a href="LogManage.aspx"><span>管理员日志管理</span></a></li>
                            <li><a href="LogUserLogin.aspx"><span>用户登录/注册日志管理</span></a></li>
                            <li><a href="LogUserbehavior.aspx"><span>用户操作行为日志</span></a></li>
                        </ul>
                    </div>
                    <table class="xy_tb xy_tb2">
                        <tr>
                            <td class="content_action">
                                标题：<asp:TextBox ID="txtname" runat="server" CssClass="input"></asp:TextBox>&nbsp;
                                管理员名称：<asp:TextBox ID="txtadmin" runat="server" CssClass="input"></asp:TextBox>
                                模块名：<asp:TextBox ID="txtmould" runat="server" CssClass="input"></asp:TextBox>
                                
                            </td>
                        </tr>
                        <tr>
                            <td>
                                操作时间：<input id="begindate" runat="server" maxlength="10" onclick="getDateString(this);"
                                    readonly="readonly" style="width: 90px" type="text" />
                                到
                                <input id="enddate" runat="server" maxlength="10" onclick="getDateString(this);"
                                    readonly="readonly" style="width: 90px" type="text" />&nbsp;
                                <asp:Button ID="Button4" runat="server" CssClass="button" Text="搜索" OnClick="Button4_Click"></asp:Button>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView HeaderStyle-CssClass="gv_header_style" ID="gvlist" runat="server" AutoGenerateColumns="False"
                                    DataKeyNames="L_ID" Width="100%" PageSize="20" GridLines="None" OnRowDataBound="gvlist_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="L_ID" HeaderText="L_ID" Visible="False" />
                                        <asp:TemplateField HeaderText="选择">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkExport" runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle Width="5%" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="L_Title" HeaderText="标题">
                                            <HeaderStyle CssClass="gvLeft" />
                                            <ItemStyle Width="45%" CssClass="gvLeft" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="UM_Name" HeaderText="管理员名称">
                                            <HeaderStyle CssClass="gvLeft" />
                                            <ItemStyle Width="10%" CssClass="gvLeft" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="L_MF" HeaderText="模块名">
                                            <ItemStyle Width="15%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="L_addtime" HeaderText="日期">
                                            <ItemStyle Width="20%" />
                                        </asp:BoundField>
                                        <%--<asp:HyperLinkField DataNavigateUrlFields="L_ID" DataNavigateUrlFormatString="loginfo.aspx?L_ID={0}"
                                            HeaderText="查看" NavigateUrl="loginfo.aspx?L_ID={0}" Text="&lt;img src=&quot;../images/look.gif&quot; /&gt;">
                                            <ItemStyle Width="5%" />
                                        </asp:HyperLinkField>--%>
                                        <asp:TemplateField HeaderText="查看">
                                            <ItemTemplate>
                                                <a href='LogInfo.aspx?L_ID=<%# Eval("L_ID").ToString()%>&backURL=<%# backURL %>'>
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
                                    runat="server" />全选
                                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="删除" CssClass="button" />
                                <asp:Button ID="btnDelAll" runat="server" CssClass="button" OnClick="btnDelAll_Click"
                                    Text="删除全部" />
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
