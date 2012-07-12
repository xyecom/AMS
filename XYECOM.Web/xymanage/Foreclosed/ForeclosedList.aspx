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
                                            用户编号：
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
                                    DataKeyNames="SD_ID,SD_Flag,U_ID,U_Email,SD_Title" GridLines="None" OnRowCommand="GV1_RowCommand1"
                                    OnRowDataBound="GV1_RowDataBound1" Width="100%">
                                    <Columns>
                                        <asp:BoundField DataField="SD_ID" HeaderText="SD_ID" Visible="False" />
                                        <asp:TemplateField HeaderText="选择">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkExport" runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle Width="4%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="标题">
                                            <ItemStyle CssClass="gvLeft" Width="25%" />
                                            <HeaderStyle CssClass="gvLeft" />
                                            <ItemTemplate>
                                                <a href='<%# GetInfoUrl("offer",Eval("SD_Flag").ToString(),Eval("SD_ID").ToString())%>'
                                                    target="_blank">
                                                    <%# XYECOM.Core.Utils.IsLength(50,Eval("SD_Title").ToString())%>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="发布者">
                                            <ItemStyle CssClass="gvLeft" Width="12%" />
                                            <HeaderStyle CssClass="gvLeft" />
                                            <ItemTemplate>
                                                <a href='../UserManage/UserInfo.aspx?U_ID=<%# Eval("U_ID")%>&backURL=../Supply/<%#backURL %>'>
                                                    <%# Eval("U_Name")%></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="发布日期">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Convert.ToDateTime(Eval("SD_PublishDate")).ToString("yyyy-MM-dd") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="12%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="信息类型">
                                            <ItemTemplate>
                                                <%# Eval("IsContractVouch").ToString() == "True" ? "大宗" : "小额"%>
                                            </ItemTemplate>
                                            <ItemStyle Width="12%" CssClass="action" />
                                        </asp:TemplateField>
                                        <asp:ButtonField CommandName="shenhe" HeaderText="审核" DataTextField="AuditingState">
                                            <ItemStyle CssClass="action" Width="10%" />
                                        </asp:ButtonField>
                                        <asp:ButtonField CommandName="tj" HeaderText="推荐" DataTextField="SD_Vouch">
                                            <ItemStyle CssClass="action" Width="10%" />
                                        </asp:ButtonField>
                                        <asp:TemplateField HeaderText="参与团购">
                                            <ItemStyle CssClass="gvLeft" Width="8%" />
                                            <ItemTemplate>
                                                <%# Eval("AuditingState").ToString() == "1" ? string.Format("<a href='/xymanage/TeamBuy/PostPlatTeamInfo.aspx?infoid={0}'>{1}</a>", Eval("SD_ID"),"参与团购") : ""%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="查看">
                                            <ItemStyle Width="5%" />
                                            <ItemTemplate>
                                                <a href='LookSupply.aspx?SD_ID=<%# Eval("SD_ID") %>&backURL=<%# backURL %>'>
                                                    <img src="../images/look.GIF" alt="查看" /></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="UI_Name" HeaderText="公司名称" Visible="False">
                                            <HeaderStyle CssClass="gvLeft" />
                                            <ItemStyle CssClass="gvLeft" Width="18%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="SD_Flag" HeaderText="供求类别" Visible="False">
                                            <HeaderStyle Width="0%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="AuditingState" HeaderText="AuditingState" Visible="False" />
                                        <asp:BoundField DataField="U_ID" Visible="False" />
                                        <asp:BoundField DataField="U_Email" Visible="False" />
                                        <asp:TemplateField HeaderText="静态页面" Visible="false">
                                            <ItemStyle CssClass="gvLeft" Width="8%" />
                                            <ItemTemplate>
                                                <%# Eval("SD_HTMLPage").ToString() != "" ? "<a href=\"/" + Eval("SD_HTMLPage").ToString() + "\" target=\"_black\">查看</a>" : "-"%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <p style="text-align: center;">
                                    <asp:Label ID="lbmanage" runat="server" ForeColor="Red"></asp:Label></p>
                            </td>
                        </tr>
                        <tr>
                            <td class="content_action">
                                <input id="chkAll" onclick="chkAll_true()" type="checkbox" name="chkAll" />全选&nbsp;<asp:Button
                                    ID="Button2" runat="server" CssClass="button" OnClick="Button2_Click" Text="删除" />
                                <asp:Button ID="btnIsPass" runat="server" CssClass="button" Text="通过审核" OnClick="btnIsPass_Click" />
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
