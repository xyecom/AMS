<%@ Page Title="" Language="C#" MasterPageFile="~/Creditor/Creditor.master" AutoEventWireup="true"
    CodeBehind="ForeclosedDetail.aspx.cs" Inherits="XYECOM.Web.Creditor.ForeclosedDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <!--right start-->
    <div id="right">
        <!--rightdzmain start-->
        <div id="rightdzmain">
            <h2>
                抵债物品详情</h2>
            <div class="rhr">
            </div>
            <!--基本信息 start-->
            <div id="dzbase">
                【物品基本信息】
                <hr />
                <table class="dzbasetb">
                    <tr>
                        <td class="info1">
                            名称：
                        </td>
                        <td>
                            <asp:Label ID="labTitle" runat="server"></asp:Label>
                        </td>
                        <td class="info1">
                            拍卖底价：
                        </td>
                        <td>
                            <asp:Label ID="labLinePrice" runat="server"></asp:Label>元
                        </td>
                    </tr>
                    <tr>
                        <td class="info1">
                            承接人数：
                        </td>
                        <td>
                            <asp:Label runat="server" ID="labCount"></asp:Label>
                            个
                        </td>
                        <td class="info1">
                            目前最高出价：
                        </td>
                        <td>
                            <asp:Label ID="labHighPrice" runat="server"></asp:Label>元
                        </td>
                    </tr>
                    <tr>
                        <td class="info1">
                            物品所在地：
                        </td>
                        <td colspan="3">
                            <asp:Label ID="labAddress" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="info1">
                            结束竞拍时间：
                        </td>
                        <td colspan="3">
                            <asp:Label ID="labEndDate" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </table>
                【物品相关图片】
                <hr />
                <div id="dzbasepic">
                    <asp:Repeater runat="server" ID="rpPrice">
                        <ItemTemplate>
                            <img width="96px;" src='/Upload/<%# Eval("At_Path") %>' />
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <input type="hidden" id="hidId" runat="server" />
                【物品竞价信息】
                <hr />
                <div id="basetbjj">
                    <asp:Repeater ID="rptList" runat="server">
                        <HeaderTemplate>
                            <table>
                                <tr id="trtop">
                                    <td align="center" width="20%">
                                        出价
                                    </td>
                                    <td align="center" width="15%">
                                        出价时间
                                    </td>
                                    <td align="center" width="15%">
                                        来自地区
                                    </td>
                                    <td align="center" width="20%">
                                        买家联系方式
                                    </td>
                                    <td align="center" width="20%">
                                        留言
                                    </td>
                                    <td align="center" width="10%">
                                        目前状态
                                    </td>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr style="height: 22px; text-align: center; : 1px solid #ccc" onmousemove="this.style.backgroundColor='#F7F7F7'"
                                onmouseout="this.style.backgroundColor='#ffffff'">
                                <td>
                                    <%# Eval("Price")%>元
                                </td>
                                <td>
                                    <%# Eval("PriceDate", "{0:yyyy-MM-dd}")%>
                                </td>
                                <td>
                                    <%# Eval("FromAddress")%>
                                </td>
                                <td>
                                    <%# GetContact(Eval("Contact").ToString())%>
                                </td>
                                <td>
                                    <%# Eval("Remark")%>
                                </td>
                                <td>
                                    <img alt="'" src="/Common/images/okhank.gif" />领先
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                        </FooterTemplate>
                    </asp:Repeater>
                    <asp:Repeater ID="rpChuJu" runat="server">
                        <ItemTemplate>
                            <tr style="height: 22px; text-align: center; border: 1px solid #ccc" onmousemove="this.style.backgroundColor='#F7F7F7'"
                                onmouseout="this.style.backgroundColor='#ffffff'">
                                <td>
                                    <%# Eval("Price")%>元
                                </td>
                                <td>
                                    <%# Eval("PriceDate")%>
                                </td>
                                <td>
                                    <%# Eval("FromAddress")%>
                                </td>
                                <td>
                                    <%# GetContact(Eval("Contact").ToString())%>
                                </td>
                                <td>
                                    <%# Eval("Remark")%>
                                </td>
                                <td>
                                    <img alt="" src="/Common/images/cj.gif" />出局
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
            </div>
            <!--基本信息 end-->
        </div>
        <!--rightdzmain end-->
    </div>
    <!--right end-->
</asp:Content>
