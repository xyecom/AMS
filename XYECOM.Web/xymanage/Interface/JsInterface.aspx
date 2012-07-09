<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JsInterface.aspx.cs" Inherits="XYECOM.Web.xymanage.Interface.JsInterface" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>自定义配置字段</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />

    <script language="javascript" type="text/javascript" src="/common/js/base.js"></script>

    <script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <a href="../index.aspx">后台管理首页</a> >> 外部功能整合</h1>
    <table width="100%">
        <tr>
            <td class="right">
                <div class="main-setting">
                    <div class="itemtitle">
                        <h3>
                            外部功能整合</h3>
                        <input id="btadd" class="addbtn" type="button" value="新增调用关键字" onclick="window.location.href='EditJsInterface.aspx';" />
                    </div>
                    <table class="xy_tb xy_tb2">
                        <tr>
                            <th colspan="15" class="partition">
                                说明
                            </th>
                        </tr>
                        <tr class="nobg">
                            <td colspan="2" class="tipsblock">
                                <ul id="tipslis">
                                    <li>通过外部功能整合可以简单的增加本站功能，如在线客服，流量统计等</li>
                                    <li>可以通过 <font color="red">{config.GetJs("自定义字段名称")}</font> 的方式在模板中调用</li>
                                </ul>
                            </td>
                        </tr>
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                <asp:GridView ID="gvlist" HeaderStyle-CssClass="gv_header_style" Width="100%" runat="server"
                                    AutoGenerateColumns="False" DataKeyNames="key" GridLines="None" OnRowDataBound="gvlist_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField HeaderText="选择">
                                            <ItemTemplate>
                                                <input type="checkbox" runat="server" id="chkExport" value='<%# Eval("Key")%>' />
                                            </ItemTemplate>
                                            <ItemStyle Width="5%" />
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="名称(Key)" DataField="Key">
                                            <ItemStyle Width="10%" CssClass="gvLeft" />
                                            <HeaderStyle CssClass="gvLeft" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="状态">
                                            <ItemTemplate>
                                                <asp:Literal ID="Literal1" runat="server" Text='<%# (bool.Parse(Eval("Enable").ToString())) ? "启用" : "禁用"%>'></asp:Literal>
                                            </ItemTemplate>
                                            <ItemStyle Width="10%" />
                                            <HeaderStyle CssClass="gvLeft" />
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="值(Value)" DataField="Value">
                                            <ItemStyle CssClass="gvLeft" />
                                            <HeaderStyle CssClass="gvLeft" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="编辑">
                                            <ItemStyle Width="10%" />
                                            <ItemTemplate>
                                                <a href="EditJsInterface.aspx?key=<%# Eval("key") %>">
                                                    <img src="../Images/edit.GIF"; alt="点此编辑" />
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <p style="text-align: center;">
                                    <asp:Label ID="lblMessage" runat="Server" ForeColor="red"></asp:Label></p>
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform">
                                <input id="chkAll" onclick="chkAll_true();" type="checkbox" name="chkAll" runat="server" />全选
                                <asp:Button ID="lnkDel" runat="server" CssClass="button" Text="删除" OnClick="lnkDel_Click" />&nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
