<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserNewsList.aspx.cs" Inherits="XYECOM.Web.xymanage.News.UserNewsList" %>

<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>企业资讯管理</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <script language="javascript" type="text/javascript" src="/common/js/base.js"></script>
    <script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
    <script language="javascript" type="text/javascript" src="/common/js/date.js"></script>
    <script language="javascript" type="text/javascript" src="../javascript/list.js"></script>
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <h1>
        企业资讯</h1>
    <table width="100%">
        <tr>
            <td class="right">
                <div class="main-setting">
                    <div class="itemtitle">
                        <h3>
                            企业资讯</h3>
                    </div>
                    <table class="xy_tb xy_tb2">
                        <tr>
                            <td>
                                <table width="100%" class="partition">
                                    <tr>
                                        <th>
                                            标题：
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtTitle" runat="server" Width="150px" MaxLength="30" CssClass="input_s"></asp:TextBox>
                                        </td>
                                        <th style="width: 93px">
                                            审核状态：
                                        </th>
                                        <td id="classType">
                                            <asp:RadioButtonList ID="ddlState" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Selected="True" Value="-1">所有</asp:ListItem>
                                                <asp:ListItem Value="AuditingState = 1">通过审核</asp:ListItem>
                                                <asp:ListItem Value="AuditingState = 0">未通过审核</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            帐户或企业名称：
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtUserName" runat="server" CssClass="input_s" MaxLength="30" Width="150px"></asp:TextBox>
                                        </td>
                                        <th>
                                            添加日期：
                                        </th>
                                        <td>
                                            <input id="bgdate" runat="server" maxlength="10" onclick="getDateString(this);" readonly="readonly"
                                                style="width: 80px" type="text" />
                                            到
                                            <input id="egdate" runat="server" maxlength="10" onclick="getDateString(this);" readonly="readonly"
                                                style="width: 80px" type="text" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            每页条数：
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtPageSize" runat="server" CssClass="" Columns="2" Text="20" MaxLength="3"></asp:TextBox>
                                            条(1~100)
                                            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtPageSize"
                                                ErrorMessage="介于1～100之间" MaximumValue="100" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                                        </td>
                                        <th style="width: 93px">
                                        </th>
                                        <td>
                                            <asp:CheckBox runat="server" ID="cbdays" Checked="true" />
                                            返回最近&nbsp;<asp:TextBox runat="server" CssClass="" ID="txtdays" Columns="2" Text="2"></asp:TextBox>&nbsp;天的全部数据
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtdays"
                                                ErrorMessage="必须为数字" ValidationExpression="^[1-9]\d*$"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td colspan="3">
                                            <asp:Button ID="btnFind" runat="server" CssClass="button" Text="查询" OnClick="btnFind_Click" />
                                            <input type="reset" value="重置" class="button" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="GV1" runat="server" HeaderStyle-CssClass="gv_header_style" AutoGenerateColumns="False"
                                    DataKeyNames="N_ID" OnRowDataBound="GV1_RowDataBound" Width="100%" GridLines="None"
                                    OnRowCommand="GV1_RowCommand">
                                    <Columns>
                                        <asp:BoundField DataField="N_ID" HeaderText="N_ID" Visible="False" />
                                        <asp:TemplateField HeaderText="选择">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkExport" runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle Width="4%" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="N_Title" HeaderText="标题">
                                            <HeaderStyle CssClass="gvLeft" />
                                            <ItemStyle CssClass="gvLeft" Width="27%" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="帐户或企业名称">
                                            <ItemStyle CssClass="gvLeft" Width="15%" />
                                            <HeaderStyle CssClass="gvLeft" />
                                            <ItemTemplate>
                                                <a href='../UserManage/UserInfo.aspx?U_ID=<%# Eval("U_ID")%>&backURL=../News/<%#backURL %>'>
                                                    <%# Eval("Ui_Name")%></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="发布日期">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Convert.ToDateTime(Eval("N_addtime")).ToString("yyyy-MM-dd") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="12%" />
                                        </asp:TemplateField>
                                        <asp:ButtonField CommandName="shenhe" HeaderText="审核" DataTextField="AuditingState">
                                            <ItemStyle CssClass="action" Width="10%" />
                                        </asp:ButtonField>
                                         <asp:TemplateField HeaderText="状态">
                                            <ItemStyle Width="15%" />
                                            <ItemTemplate>
                                                <%# GetStateName(Eval("State").ToString()) %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="编辑">
                                            <ItemStyle Width="5%" />
                                            <ItemTemplate>
                                                <a href='UserNewsInfo.aspx?id=<%# Eval("N_ID") %>&backURL=<%# backURL %>'>
                                                    <img src="../images/edit.GIF" alt="编辑" /></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="gv_header_style" />
                                </asp:GridView>
                                <p style="text-align: center;">
                                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label></p>
                            </td>
                        </tr>
                        <tr>
                            <td class="content_action">
                                <input id="chkAll" onclick="chkAll_true()" type="checkbox" name="chkAll" runat="server" />全选
                                <asp:Button ID="lnkDel" runat="server" CssClass="button" Text="删除" OnClick="lnkDel_Click" />
                            </td>
                        </tr>
                    </table>
                    <uc2:page ID="page1" runat="server" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
