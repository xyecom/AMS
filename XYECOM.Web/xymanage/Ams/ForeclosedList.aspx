<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForeclosedList.aspx.cs"
    Inherits="XYECOM.Web.xymanage.Creditor.Foreclosed.ForeclosedList" %>

<%@ Register Src="~/xymanage/UserControl/page.ascx" TagName="page" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>抵债信息</title>
    <link href="../CSS/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/XYLib.css" type="text/css" rel="Stylesheet" />
    <script language="javascript" type="text/javascript" src="/common/js/base.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/CheckedAll.js"></script>
    <script language="javascript" type="text/javascript" src="../javascript/list.js"></script>
    <script language="javascript" type="text/javascript" src="/common/js/date.js"></script>
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <h1>
        <a href="../index.aspx">后台管理首页</a> >> 抵债信息管理</h1>
    <table width="100%">
        <tr>
            <td class="right">
                <div class="main-setting">
                    <table class="xy_tb xy_tb2">
                        <tr>
                            <td>
                                <table width="100%" class="partition">
                                    <tr>
                                        <th>
                                            标题：
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtKeyword" runat="server" Width="150px" MaxLength="30" CssClass="input_s"></asp:TextBox>
                                        </td>
                                        <th>
                                            用户姓名：
                                        </th>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtId"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            请选择审核状态：
                                        </th>
                                        <td>
                                            <asp:RadioButtonList ID="rblState" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                <asp:ListItem Value="-1" Selected="True">所有</asp:ListItem>
                                                <asp:ListItem Value="1">未审核</asp:ListItem>
                                                <asp:ListItem Value="2">审核通过</asp:ListItem>
                                                <asp:ListItem Value="3">审核未通过</asp:ListItem>
                                            </asp:RadioButtonList>
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
                                        <th>
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
                                            <asp:Button ID="Button3" runat="server" CssClass="button" OnClick="Button1_Click"
                                                Text="搜索" />
                                            <input type="reset" value="重置" class="button" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="GV1" HeaderStyle-CssClass="gv_header_style" runat="server" AutoGenerateColumns="False"
                                    DataKeyNames="ForeclosedId" GridLines="None" OnRowCommand="GV1_RowCommand1" OnRowDataBound="GV1_RowDataBound1"
                                    Width="100%">
                                    <Columns>
                                        <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                                        <asp:TemplateField HeaderText="选择">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkExport" runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle Width="5%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="标题">
                                            <ItemStyle CssClass="gvLeft" Width="20%" />
                                            <HeaderStyle CssClass="gvLeft" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="labTitle" Text='<%# Eval("Title") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="公司名称">
                                            <ItemStyle CssClass="gvLeft" Width="10%" />
                                            <HeaderStyle CssClass="gvLeft" />
                                            <ItemTemplate>
                                                <%# GetComName(Eval("DepartmentId"))%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="发布者">
                                            <ItemStyle CssClass="gvLeft" Width="10%" />
                                            <HeaderStyle CssClass="gvLeft" />
                                            <ItemTemplate>
                                                <%# GetUserName(Eval("DepartmentId"))%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="发布日期">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Convert.ToDateTime(Eval("CreateDate")).ToString("yyyy-MM-dd") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="10%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="物品类型">
                                            <ItemTemplate>
                                                <%# Eval("ForeColseTypeName")%>
                                            </ItemTemplate>
                                            <ItemStyle Width="10%" CssClass="action" />
                                        </asp:TemplateField>
                                        <asp:ButtonField CommandName="shenhe" HeaderText="审核" DataTextField="State">
                                            <ItemStyle CssClass="action" Width="10%" />
                                        </asp:ButtonField>
                                        <asp:TemplateField HeaderText="竞价个数">
                                            <ItemTemplate>
                                                <%# GetBidInfoCountByForeID(Eval("ForeclosedId"))%>
                                            </ItemTemplate>
                                            <ItemStyle Width="10%" CssClass="action" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="查看">
                                            <ItemStyle Width="15%" />
                                            <ItemTemplate>
                                                <a href='ForeclosedInfo.aspx?ID=<%# Eval("ForeclosedId") %>&backURL=<%# backURL %>'>
                                                    查看详细</a> &nbsp; <a href='/ForeclosedDetail.aspx?Id=<%# Eval("ForeclosedId") %>'>查看竞价</a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="AuditingState" HeaderText="AuditingState" Visible="False" />
                                        <asp:BoundField DataField="DepartmentId" Visible="False" />
                                    </Columns>
                                </asp:GridView>
                                <p style="text-align: center;">
                                    <asp:Label ID="lbmanage" runat="server" ForeColor="Red"></asp:Label></p>
                            </td>
                        </tr>
                        <tr>
                            <td class="content_action">
                                <input id="chkAll" onclick="chkAll_true()" type="checkbox" name="chkAll" />全选&nbsp;<asp:Button
                                    ID="Button2" runat="server" CssClass="button" OnClick="btnDelete_Click" Text="删除" />
                                <asp:Button ID="btnIsPass" runat="server" CssClass="button" Text="审核通过" OnClick="btnIsPass_Click" />
                                <asp:Button ID="btnNotIsPass" runat="server" CssClass="button" Text="审核不通过" OnClick="btnNotIsPass_Click" />
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
