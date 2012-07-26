<%@ Page Title="" Language="C#" MasterPageFile="~/Creditor/Creditor.master" AutoEventWireup="true"
    CodeBehind="EvaluationList.aspx.cs" Inherits="XYECOM.Web.Creditor.EvaluationList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <title>信用评价管理</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <!--right start-->
    <div id="right">
        <!--rightzqlist start-->
        <div id="rightzqlist">
            <h2>
                信用评价管理</h2>
            <div class="rhr">
            </div>
            <!--serch start-->
            <div class="serchl">
                <asp:RadioButtonList runat="server" ID="radEvaType" RepeatDirection="Horizontal">
                    <asp:ListItem Value="credit" Selected="True">我对服务商的评价</asp:ListItem>
                    <asp:ListItem Value="server">服务商对我的评价</asp:ListItem>
                </asp:RadioButtonList>
                <asp:Button runat="server" ID="btnSearch" Text="搜索" OnClick="btnSearch_Click" />
            </div>
            <!--serch end-->
            <!--列表 start-->
            <div id="list">
                <asp:Repeater ID="rptList" runat="server">
                    <HeaderTemplate>
                        <table>
                            <tr id="trtop">
                                <td align="center" width="20%">
                                    服务商姓名
                                </td>
                                <td align="center" width="20%">
                                    债权信息标题
                                </td>
                                <td align="center" width="20%">
                                    评价结果
                                </td>
                                <td align="center" width="40%">
                                    评价描述
                                </td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr id="trmidd" style="height: 28px; border-top: 1px solid #ccc" onmousemove="this.style.backgroundColor='#F7F7F7'"
                            onmouseout="this.style.backgroundColor='#ffffff'">
                            <td id="tdtitle">
                                <%# isServer == true ? Eval("UserName") : Eval("User2Name")%>
                            </td>
                            <td>
                                <%# GetCreditTitle(Eval("CreditInfoId"))%>
                            </td>
                            <td>
                                <%# Eval("Evaluation").ToString() == "1" ? "好评" : "差评"%>
                            </td>
                            <td>
                                <%# Eval("Description")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table></FooterTemplate>
                </asp:Repeater>
                <div style="width: 705px; height: 30px; line-height: 30px; text-align: center">
                    <XYECOM:Page ID="Page1" runat="server" PageSize="20" OnPageChanged="Page1_PageChanged" />
                </div>
                <div>
                    <p style="text-align: center;">
                        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label></p>
                </div>
            </div>
            <!--列表 end-->
        </div>
        <!--rightzqlist end-->
    </div>
    <!--right end-->
</asp:Content>
