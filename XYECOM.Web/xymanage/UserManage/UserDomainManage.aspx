<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserDomainManage.aspx.cs"
    Inherits="XYECOM.Web.xymanage.UserManage.UserDomainManage" %>

<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>顶级域名绑定申请</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/XYLib.css" type="text/css" rel="Stylesheet" />

    <script language="javascript" type="text/javascript" src="/common/js/base.js"></script>

    <script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <a href="../index.aspx">后台管理首页</a> >> 顶级域名绑定申请</h1>
    <table width="100%">
        <tr>
            <!-- right -->
            <td class="right">
                <div class="main-setting">
                    <div class="itemtitle">
                        <h3>
                            顶级域名绑定申请</h3>
                    </div>
                    <table class="xy_tb xy_tb2" style="margin-top: 0px;">
                        <tr>
                            <td>
                                域名:<asp:TextBox ID="txtDomain" runat="server"></asp:TextBox>
                                ICP号:<asp:TextBox ID="txtICP" runat="server"></asp:TextBox>
                                <asp:Button runat="server" ID="btnFind" CssClass="button" Text="查询" OnClick="btnFind_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gvlist" HeaderStyle-CssClass="gv_header_style" runat="server" AutoGenerateColumns="False"
                                    DataKeyNames="InfoId" Width="100%" OnRowCommand="gvlist_RowCommand" OnRowDataBound="gvlist_RowDataBound"
                                    GridLines="None">
                                    <Columns>
                                        <asp:BoundField DataField="InfoId" HeaderText="InfoId" Visible="False" />
                                        <asp:TemplateField HeaderText="选择">
                                            <ItemTemplate>
                                            <input id="chkExport" type="checkbox" runat="server" value='<%# Eval("InfoId") %>' />                                              
                                            </ItemTemplate>
                                            <ItemStyle Width="5%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="企业名称">
                                            <ItemStyle CssClass="gvLeft" Width="40%" />
                                            <HeaderStyle CssClass="gvLeft" />
                                            <ItemTemplate>
                                                <a href='UserInfo.aspx?U_ID=<%# Eval("UserId") %>&backURL=<%# backURL %>'>
                                                    <%#GetCompanyName(DataBinder.Eval(Container, "DataItem.UserId"))%></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Domain" HeaderText="绑定域名">
                                            <HeaderStyle CssClass="gvLeft" />
                                            <ItemStyle CssClass="gvLeft" Width="15%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IcpInfo" HeaderText="ICP备案号" HtmlEncode="False">
                                            <HeaderStyle CssClass="gvLeft" />
                                            <ItemStyle HorizontalAlign="left" Width="15%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="AddDate" HeaderText="申请日期" HtmlEncode="False" DataFormatString="{0:yyyy/MM/dd}">
                                            <HeaderStyle CssClass="gvLeft" />
                                            <ItemStyle HorizontalAlign="left" Width="10%" />
                                        </asp:BoundField>
                                        <asp:ButtonField CommandName="shenhe" HeaderText="审核" DataTextField="AuditingState">
                                            <ItemStyle CssClass="action" Width="10%" />
                                        </asp:ButtonField>
                                    </Columns>
                                    <HeaderStyle CssClass="gv_header_style" />
                                </asp:GridView>
                                <p style="text-align: center;">
                                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label></p>
                            </td>
                        </tr>
                        <tr>
                            <td class="content_action">
                                <input class="list_td04" id="chkAll" onclick="chkAll_true()" type="checkbox" name="chkAll"
                                    runat="server" />全选
                                <asp:Button ID="btnDelete" runat="server" Text="删除" CssClass="button" 
                                    onclick="btnDelete_Click"/>
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
