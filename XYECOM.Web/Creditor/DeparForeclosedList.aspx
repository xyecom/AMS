﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Creditor/Creditor.master" AutoEventWireup="true"
    CodeBehind="DeparForeclosedList.aspx.cs" Inherits="XYECOM.Web.Creditor.DeparForeclosedList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <title>部门抵债管理</title>
    <script type="text/javascript">
        var ConfirmForeclosed = function () {
            if (window.confirm("确认关闭信息吗？")) {
                return window.confirm("信息一旦关闭不能继续竞价，请确认？");
            }
            return false;
        }
        var DeleteForeclosed = function () {
            if (window.confirm("确认删除案件吗？")) {
                return window.confirm("只能删除未竞价的抵债信息？");
            }
            return false;
        }    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <!--right start-->
    <div id="right">
        <!--rightpart start-->
        <div id="rightpart">
            <h2>
                部门债权管理</h2>
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
                <asp:Button runat="server" ID="btnSearch" Text="查 询" OnClick="btnSearch_Click"  Style="background: url(../Other/images/yes.gif);
                                width: 80px; height: 25px; border: none; cursor: pointer; font-size: 13px; color: White"  />
            </div>
            <!--serch end-->
            <!--列表 start-->
            <div id="list">
                <asp:Repeater ID="rptList" runat="server">
                    <HeaderTemplate>
                        <table>
                            <tr id="trtop">
                                <td align="center" width="20%">
                                    档案标题
                                </td>
                                <td align="center" width="10%">
                                    部门名称
                                </td>
                                <td align="center" width="10%">
                                    结束时间
                                </td>
                                <td align="center" width="15%">
                                    物品类型
                                </td>
                                <td align="center" width="15%">
                                    审核状态
                                </td>
                                <td align="center" width="10%">
                                    竞价个数
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
                                <%# GetDeparName(Eval("DepartmentId"))%>
                            </td>
                            <td>
                                <%# Eval("ForeColseTypeName")%>
                            </td>
                            <td>
                                <span style="color: Red">
                                    <%# GetEndDate(Eval("EndDate"))%></span>
                            </td>
                            <td>
                                <%# GetAuditingState(XYECOM.Core.MyConvert.GetInt32(Eval("State").ToString()))%>
                            </td>
                            <td>
                                <%# GetBidInfoCountByForeID(Eval("ForeclosedId"))%>
                            </td>
                            <td>
                                <asp:HyperLink ID="hlUpdate" runat="server" NavigateUrl='<%# "/ForeclosedDetail.aspx?Id=" + Eval("ForeclosedId") %>'>查看竞价</asp:HyperLink>
                                <asp:LinkButton ID="lbtnRelease" runat="server" Text="删除" OnClick="lbtnDelete_Click"
                                    CommandArgument='<%# Eval("ForeclosedId") %>' OnClientClick="javascript:return DeleteForeclosed();"></asp:LinkButton>
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
