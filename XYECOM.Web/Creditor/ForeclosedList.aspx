<%@ Page Title="" Language="C#" MasterPageFile="~/Creditor/Creditor.master" AutoEventWireup="true"
    CodeBehind="ForeclosedList.aspx.cs" Inherits="XYECOM.Web.Creditor.ForeclosedList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <!--right start-->
    <div id="right">
        <!--rightpart start-->
        <div id="rightpart">
            <h2>
                抵债信息管理</h2>
            <div class="rhr">
            </div>
            <!--serch start-->
            <div class="serchl">
                &nbsp;&nbsp; 物品类型：
                <asp:DropDownList runat="server" ID="droTypeName" CssClass="select1" Width="150px">
                    <asp:ListItem Value="所有" Text="----所有----"></asp:ListItem>
                    <asp:ListItem Value="房屋" Text="房屋"></asp:ListItem>
                    <asp:ListItem Value="汽车" Text="汽车"></asp:ListItem>
                    <asp:ListItem Value="金条" Text="金条"></asp:ListItem>
                </asp:DropDownList>
                &nbsp;&nbsp; &nbsp;&nbsp; 标题：<asp:TextBox runat="server" ID="txtTitle"></asp:TextBox>
                <asp:Button runat="server" ID="btnSearch" Text="查询" OnClick="btnSearch_Click" />
            </div>
            <!--serch end-->
            <!--列表 start-->
            <div id="list">                
                <asp:Repeater ID="rptList" runat="server" >
                    <HeaderTemplate>
                        <table>
                            <tr id="trtop">
                                <td align="center" width="20%">
                                    档案标题
                                </td>
                                <td align="center" width="20%">
                                    结束时间
                                </td>
                                <td align="center" width="20%">
                                    物品类型
                                </td>
                                <td align="center" width="15%">
                                    审核状态
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
                                <span style="color: Red">
                                    <%# GetEndDate(Eval("EndDate"))%></span>
                            </td>
                            <td>
                                <%# Eval("ForeColseTypeName")%>
                            </td>
                            <td>
                                <%# GetAuditingState(XYECOM.Core.MyConvert.GetInt32(Eval("State").ToString()))%>
                            </td>
                            <td>
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "UpdateForeclosed.aspx?Id=" + Eval("ForeclosedId") %>'>修改</asp:HyperLink>
                                <asp:HyperLink ID="hlUpdate" runat="server" NavigateUrl='<%# "/ForeclosedDetail.aspx?Id=" + Eval("ForeclosedId") %>'>查看竞价</asp:HyperLink>
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
        <!--rightpart end-->
    </div>
    <!--right end-->
</asp:Content>
