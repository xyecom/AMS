﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Server/Server.master" AutoEventWireup="true"
    CodeBehind="RecommendCredList.aspx.cs" Inherits="XYECOM.Web.Server.RecommendCredList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <title>系统推荐案件</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <!--right start-->
    <div id="right">
        <!--rightzqlist start-->
        <div id="rightzqlist">
            <h2>
                系统推荐案件</h2>
            <div class="rhr">
            </div>
            <!--serch start-->
            <div class="serchl">
                &nbsp;&nbsp; 款金额：<asp:DropDownList runat="server" ID="drpArrears">
                    <asp:ListItem Value="所有" Text="--所有--"></asp:ListItem>
                    <asp:ListItem Value="小于1万" Text="0-1万"></asp:ListItem>
                    <asp:ListItem Value="大于1万小于5万" Text="1万-5万"></asp:ListItem>
                    <asp:ListItem Value="大于5万小于10万" Text="5万-10万"></asp:ListItem>
                    <asp:ListItem Value="大于10万" Text=">=10万"></asp:ListItem>
                </asp:DropDownList>
                &nbsp;&nbsp; &nbsp;&nbsp; 标题：<asp:TextBox runat="server" ID="txtKey"></asp:TextBox>
                <asp:Button runat="server" ID="btnSearch" Text="搜索" OnClick="btnSearch_Click" />
            </div>
            <!--serch end-->
            <!--列表 start-->
            <div id="list">
                <asp:Repeater ID="rptList" runat="server">
                    <HeaderTemplate>
                        <table>
                            <tr id="trtop">
                                <td align="center" width="40%">
                                    案件标题
                                </td>
                                <td align="center" width="20%">
                                    发布时间
                                </td>
                                <td align="center" width="15%">
                                    付款状态
                                </td>
                                <td align="center" width="25%">
                                    操作菜单
                                </td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr id="trmidd" style="height: 28px; border-top: 1px solid #ccc" onmousemove="this.style.backgroundColor='#F7F7F7'"
                            onmouseout="this.style.backgroundColor='#ffffff'">
                            <td id="tdtitle">
                                <%# Eval("Title") %>
                            </td>
                            <td>
                                <%# Eval("CreateDate", "{0:yyyy-MM-dd}")%>
                            </td>
                            <td>
                                <%# GetApprovaStatus(Eval("ApprovaStatus"))%>
                            </td>
                            <td>
                                <asp:HyperLink ID="hlShowTender" runat="server" NavigateUrl='<%# "/CreditInfoDetail.aspx?Id=" + Eval("CreditId") %>'>查看详细</asp:HyperLink>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table></FooterTemplate>
                </asp:Repeater>
                <div style="height: 30px;">
                    <div align="center">
                        <XYECOM:Page ID="Page1" runat="server" PageSize="20" OnPageChanged="Page1_PageChanged" />
                    </div>
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
