<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_basic_Administrator"
    CodeBehind="Administrator.aspx.cs" %>

<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc2" %>
<%@ Register Src="../UserControl/top.ascx" TagName="top" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理员管理</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <link href="../css/style.css" type="text/css" rel="stylesheet" />

    <script language="javascript" type="text/javascript" src="/common/js/base.js"></script>

    <script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>

</head>
<body onload="load();">
    <form id="Form1" method="post" runat="server">
    <h1>
        <a href="../index.aspx">后台设置首页</a> >> 管理员管理</h1>
    <table width="100%">
        <tr>
            <td class="right">
                <div class="main-setting">
                    <div class="itemtitle">
                        <h3>
                            管理员管理</h3>
                        <ul class="tab1">
                            <li class="current"><a href="Administrator.aspx"><span>管理员</span></a></li>
                            <li><a href="Role.aspx"><span>角色</span></a></li>
                        </ul>
                        <input class="addbtn" id="btnAdd" onclick="block();" type="button" value="新增管理员" />
                    </div>
                    <!-- 表格 -->
                    <table width="100%" class="xy_tb xy_tb2" style="display: none" id="add">
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                选择角色：
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform">
                                <asp:DropDownList ID="ddlRose" runat="server">
                                    <asp:ListItem Selected="True" Value="-1">请选择角色</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="vtop tips2">
                            </td>
                        </tr>
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                用户名：
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform">
                                <asp:TextBox ID="txtName" runat="server" Width="200px" CssClass="input" ToolTip="输入您要添加的用户名称"
                                    MaxLength="10"></asp:TextBox>
                            </td>
                            <td class="vtop tips2">
                            </td>
                        </tr>
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                登陆密码：
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform">
                                <asp:TextBox ID="txtPwd" runat="server" Width="200px" CssClass="input" ToolTip="输入您要添加的用户密码"
                                    MaxLength="16" TextMode="Password"></asp:TextBox>
                            </td>
                            <td class="vtop tips2">
                            </td>
                        </tr>
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                确认密码：
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform">
                                <asp:TextBox ID="txtPwd2" runat="server" Width="200px" CssClass="input" ToolTip="再次输入您要添加的密码"
                                    MaxLength="16" TextMode="Password"></asp:TextBox>
                            </td>
                            <td class="vtop tips2">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <input class="button" id="btnOk" title="开始添加" type="submit" value="确定" name="Submit3"
                                    runat="server" onserverclick="btnOk_ServerClick1" />
                                <input class="button" id="btnQuit" onclick="quit();" type="button" value="取消" />
                            </td>
                        </tr>
                    </table>
                    <table id="update" style="display: none" class="xy_tb xy_tb2">
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                请选择角色：
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform">
                                <asp:DropDownList ID="ddlUpdate" runat="server">
                                    <asp:ListItem Value="-1">请选择角色</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="vtop tips2">
                            </td>
                        </tr>
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                用户名：
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform">
                                <asp:Label ID="txtName1" runat="server" ForeColor="Red"></asp:Label>
                                <input id="key" runat="server" type="hidden" />
                                <input id="value" runat="server" type="hidden" />
                            </td>
                            <td class="vtop tips2">
                            </td>
                        </tr>
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                原密码：
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform">
                                <asp:TextBox ID="txtYuanPwd" runat="server" Width="200px" CssClass="input" ToolTip="输入您的原密码"
                                    MaxLength="16" TextMode="Password"></asp:TextBox>
                            </td>
                            <td class="vtop tips2">
                            </td>
                        </tr>
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                新密码：
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform">
                                <asp:TextBox ID="txtNewPwd" runat="server" Width="200px" CssClass="input" ToolTip="输入您的新密码"
                                    MaxLength="16" TextMode="Password"></asp:TextBox>
                            </td>
                            <td class="vtop tips2">
                            </td>
                        </tr>
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                确认密码：
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform">
                                <asp:TextBox ID="txtOKpwd" runat="server" Width="200px" CssClass="input" ToolTip="再次输入您要修改的密码"
                                    MaxLength="16" TextMode="Password"></asp:TextBox>
                            </td>
                            <td class="vtop tips2">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <input class="button" id="Submit1" title="修改" type="submit" value="修改" name="Submit3"
                                    runat="server" onserverclick="Submit1_ServerClick" />
                                <input class="button" id="btnQuit1" onclick="Exit();" type="button" value="取消" />
                            </td>
                        </tr>
                    </table>
                    <table class="xy_tb xy_tb2">
                        <tr>
                            <td>
                                <asp:GridView ID="gvlist" HeaderStyle-CssClass="gv_header_style" runat="server" AutoGenerateColumns="False"
                                    DataKeyNames="UM_ID" OnRowCommand="gvlist_RowCommand" Width="100%" GridLines="None"
                                    OnRowDataBound="gvlist_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="UM_ID" HeaderText="UM_ID" Visible="False" />
                                        <asp:BoundField DataField="UM_Pwd" HeaderText="UM_Pwd" Visible="False" />
                                        <asp:BoundField DataField="UR_ID" HeaderText="UR_ID" Visible="False" />
                                        <asp:BoundField DataField="UM_Name" HeaderText="管理员名称">
                                            <ItemStyle Width="60%" CssClass="gvLeft" />
                                            <HeaderStyle CssClass="gvLeft" />
                                        </asp:BoundField>
                                        <asp:ButtonField CommandName="up" HeaderText="修改" Text="&lt;img src=&quot;../images/edit.GIF&quot; /&gt;" />
                                        <asp:ButtonField CommandName="del" HeaderText="删除" Text="&lt;img src=&quot;../images/delete.GIF&quot; /&gt;" />
                                    </Columns>
                                    <PagerSettings FirstPageText="首页" LastPageText="尾页" Mode="NextPreviousFirstLast"
                                        NextPageText="下一页" PreviousPageText="上一页" />
                                </asp:GridView>
                                <p style="text-align: center;">
                                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label></p>
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
