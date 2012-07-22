<%@ Page Title="" Language="C#" MasterPageFile="~/Fore.Master" AutoEventWireup="true"
    CodeBehind="showEvaluation.aspx.cs" Inherits="XYECOM.Web.showEvaluation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main">
        <table border="0" cellspacing="0" cellpadding="0" style="width: 99%">
            <tr>
                <td>
                    <div class="title">
                        <strong>
                            <asp:Label ID="labTitle" runat="server"></asp:Label></strong></div>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    <b style="font-size: 14px; text-align: center; color: #ff0000">
                        <asp:Label ID="labTitle1" runat="server"></asp:Label></b><br />
                    <br />
                    <p>
                        <b>一、基本情况：</b><br />
                        <table class="dzbasetb">
                            <tr>
                                <td class="info1">
                                    公司名称：
                                </td>
                                <td>
                                    <asp:Label ID="labCompName" runat="server"></asp:Label>
                                </td>
                                <td class="info1">
                                    用户名：
                                </td>
                                <td>
                                    <asp:Label ID="labUserName" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="info1">
                                    所在地：
                                </td>
                                <td>
                                    <asp:Label ID="labAreaId" runat="server"></asp:Label>
                                </td>
                                <td class="info1">
                                    联系电话：
                                </td>
                                <td>
                                    <asp:Label ID="labPhone" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="info1">
                                    邮箱：
                                </td>
                                <td>
                                    <asp:Label ID="labEmail" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <b>二、信用列表：</b><br />
                        <!--列表 start-->
                        <div id="list">
                            <asp:Repeater ID="rptList" runat="server">
                                <HeaderTemplate>
                                    <table>
                                        <table>
                                            <tr id="trtop">
                                                <td align="center" width="35%">
                                                    评价人姓名
                                                </td>
                                                <td align="center" width="20%">
                                                    债权信息标题
                                                </td>
                                                <td align="center" width="10%">
                                                    评价结果
                                                </td>
                                                <td align="center" width="35%">
                                                    评价描述
                                                </td>
                                            </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr id="trmidd" style="height: 28px; border-top: 1px solid #ccc" onmousemove="this.style.backgroundColor='#F7F7F7'"
                                        onmouseout="this.style.backgroundColor='#ffffff'">
                                        <td id="tdtitle">
                                            <%# Eval("UserName")%>
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
                            <input runat="server" id="hidId" type="hidden" />
                            <div style="width: 705px; height: 30px; line-height: 30px; text-align: center">
                                <XYECOM:Page ID="Page1" runat="server" PageSize="20" OnPageChanged="Page1_PageChanged" />
                            </div>
                            <div>
                                <p style="text-align: center;">
                                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label></p>
                            </div>
                        </div>
                        <!--列表 end-->
                        <br />
                    </p>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
