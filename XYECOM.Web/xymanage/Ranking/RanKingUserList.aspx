<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RanKingUserList.aspx.cs"
    Inherits="XYECOM.Web.xymanage.Ranking.RanKingUserList" %>

<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc2" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>用户自定义信息管理</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />

    <script language="javascript" type="text/javascript" src="/common/js/base.js"></script>

    <script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>

    <script type="text/javascript" src="/common/js/date.js"></script>

</head>
<body>
    <form id="Form1" method="post" runat="server">
    <h1>
        <a href="../index.aspx">后台设置首页</a> >> 用户自定义信息管理</h1>
    <table width="100%">
        <tr>
            <td class="right">
                <div class="main-setting">
                    <div class="itemtitle">
                        <h3>
                            用户自定义信息管理
                        </h3>
                    </div>
                    <table class="xy_tb xy_tb2">
                        <tr>
                            <td class="content_action">
                                关键词：<asp:TextBox ID="txtkey" runat="server" Columns="28" MaxLength="30"></asp:TextBox>
                                <asp:Button ID="btnSearch" runat="server" CssClass="button" Text="搜索" OnClick="btnSearch_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p style="text-align: center;">
                                    <asp:GridView ID="gvList" HeaderStyle-CssClass="gv_header_style" Width="100%" runat="server"
                                        AutoGenerateColumns="False" DataKeyNames="InfoId" GridLines="None" OnRowCommand="gvlist_RowCommand"
                                        OnRowDataBound="gvlist_RowDataBound">
                                        <Columns>
                                            <asp:BoundField DataField="infoId" HeaderText="infoId" Visible="False" />
                                            <asp:TemplateField HeaderText="选择">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkExport" runat="server" />
                                                </ItemTemplate>
                                                <ItemStyle Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="自定义标题" SortExpression="Title">
                                                <ItemStyle Width="20%" />
                                                <ItemTemplate>
                                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("Title") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="企业名称">
                                                <ItemStyle CssClass="gvLeft" Width="40%" />
                                                <HeaderStyle CssClass="gvLeft" />
                                                <ItemTemplate>
                                                    <a href='../UserManage/UserInfo.aspx?U_ID=<%# Eval("UserId") %>&backURL=<%# backURL1 %>'>
                                                        <%#GetCompanyName(DataBinder.Eval(Container, "DataItem.UserId"))%></a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="名次" DataField="rank">
                                                <ItemStyle Width="5%" CssClass="gvCenter" />
                                                <HeaderStyle CssClass="gvCenter" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="排名信息">
                                                <ItemStyle Width="10%" />
                                                <ItemTemplate>
                                                    <a href='Info.aspx?rid=<%# Eval("RankingId") %>&backURL=<%# backURL %>'>查看</a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="详细内容">
                                                <ItemStyle Width="10%" />
                                                <ItemTemplate>
                                                    <a href='RankingUserDetailed.aspx?InfoId=<%# Eval("InfoId") %>&backURL=<%# backURL %>'>
                                                        查看</a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:ButtonField CommandName="shenhe" HeaderText="审核" DataTextField="AuditingState">
                                                <ItemStyle CssClass="action" Width="10%" />
                                            </asp:ButtonField>
                                        </Columns>
                                        <HeaderStyle CssClass="gv_header_style" />
                                    </asp:GridView>
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
                    <uc2:page ID="Page1" runat="server" />
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
