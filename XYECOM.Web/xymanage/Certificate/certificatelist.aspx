<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_Certificate_certificatelist"
    CodeBehind="certificatelist.aspx.cs" %>

<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>企业证书信息列表</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
    <meta content="C#" name="CODE_LANGUAGE" />
    <meta content="JavaScript" name="vs_defaultClientScript" />
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <script language="javascript" type="text/javascript" src="/common/js/base.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/CheckedAll.js"></script>
    <script type="text/javascript" src="/common/js/date.js"></script>
</head>
<body>
    <form id="Form2" method="post" runat="server">
    <h1>
        <a href="../index.aspx">后台设置首页</a> >> 企业证书信息列表</h1>
    <table width="100%">
        <tr>
            <td class="right">
                <div class="main-setting">
                    <div class="itemtitle">
                        <h3>
                            企业证书信息列表</h3>
                    </div>
                    <table class="xy_tb xy_tb2" style="margin-top: 0px;">
                        <tr>
                            <td>
                                <table class="partition">
                                    <tr>
                                        <th>
                                            用户名：
                                        </th>
                                        <td>
                                            <asp:TextBox ID="TextBox1" runat="server" CssClass="input_s" Width="250px"></asp:TextBox>
                                        </td>
                                        <th>
                                            审核状态：
                                        </th>
                                        <td>
                                            <asp:RadioButtonList ID="ddlState" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="" Selected="True">所有</asp:ListItem>
                                                <asp:ListItem Value="null">未审核</asp:ListItem>
                                                <asp:ListItem Value="1">通过审核</asp:ListItem>
                                                <asp:ListItem Value="0">未通过审核</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            注册日期：
                                        </th>
                                        <td>
                                            <input id="bgdate" type="text" runat="server" onclick="getDateString(this);" readonly="readonly"
                                                maxlength="10" style="width: 80px;" />
                                            到
                                            <input id="egdate" type="text" runat="server" onclick="getDateString(this);" readonly="readonly"
                                                maxlength="10" style="width: 80px;" />
                                        </td>
                                        <th>
                                            证书类型：
                                        </th>
                                        <td>
                                            <asp:RadioButtonList ID="ddlType" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="0" Selected="True">所有</asp:ListItem>
                                                <asp:ListItem Value="1">营业执照</asp:ListItem>
                                                <asp:ListItem Value="2">税务登记类</asp:ListItem>
                                                <asp:ListItem Value="3">经营许可类</asp:ListItem>
                                                <asp:ListItem Value="4">其它类</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr class="content_action">
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Button ID="Button1" runat="server" Text="搜索" CssClass="button" OnClick="Button1_Click" />
                                            <input type="reset" value="重置" class="button" />
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="GV1" HeaderStyle-CssClass="gv_header_style" runat="server" AutoGenerateColumns="False"
                                    DataKeyNames="CE_ID,U_ID,CE_Type" Width="100%" GridLines="None" OnRowCommand="GV1_RowCommand"
                                    OnRowDataBound="GV1_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="CE_ID" HeaderText="CE_ID" Visible="False" />
                                        <asp:TemplateField HeaderText="选择">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkExport" runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle Width="5%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="用户名">
                                            <ItemStyle Width="20%" />
                                            <ItemTemplate>
                                                <a href='../UserManage/UserInfo.aspx?&U_ID=<%# Eval("U_ID") %>&backURL=<%# backURL %>'>
                                                    <%# Eval("U_Name") %></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="CE_Name" HeaderText="证书名称">
                                            <HeaderStyle CssClass="gvLeft" />
                                            <ItemStyle CssClass="gvLeft" Width="30%" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="证书类别" DataField="CE_Type">
                                            <HeaderStyle CssClass="gvLeft" />
                                            <ItemStyle CssClass="gvLeft" Width="15%" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="上传日期">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Convert.ToDateTime(Eval("CE_Addtime")).ToString("yyyy-MM-dd")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="15%" />
                                        </asp:TemplateField>
                                        <asp:ButtonField CommandName="shenhe" HeaderText="审　核" DataTextField="AuditingState">
                                            <ItemStyle CssClass="action" Width="10%" />
                                        </asp:ButtonField>
                                        <asp:TemplateField HeaderText="查看">
                                            <ItemStyle Width="10%" />
                                            <ItemTemplate>
                                                <a href='certificateinfo.aspx?CE_ID=<%# Eval("CE_ID") %>&CE_Type=<%# Eval("CE_Type") %>&U_ID=<%# Eval("U_ID") %>&backURL=<%# backURL %>'>
                                                    <img src="../images/look.GIF" alt="查看" /></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="U_ID" HeaderText="U_ID" Visible="False" />
                                    </Columns>
                                </asp:GridView>
                                <p style="text-align: center;">
                                    <asp:Label ID="lbmanage" runat="server" ForeColor="Red"></asp:Label></p>
                            </td>
                        </tr>
                        <tr>
                            <td class="content_action">
                                <input id="chkAll" onclick="chkAll_true()" type="checkbox" name="chkAll" />全选
                                <asp:Button ID="Btndel" runat="server" CssClass="button" Text="删除" OnClick="Btndel_Click">
                                </asp:Button>
                            </td>
                        </tr>
                    </table>
                    <uc1:page ID="Page1" runat="server" />
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
