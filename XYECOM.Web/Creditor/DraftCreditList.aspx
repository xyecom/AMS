<%@ Page Title="" Language="C#" MasterPageFile="~/Creditor/Creditor.master" AutoEventWireup="true"
    CodeBehind="DraftCreditList.aspx.cs" Inherits="XYECOM.Web.Creditor.DraftCreditList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <title>债权草稿管理</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <!--right start-->
    <div id="right">
        <!--rightzqlist start-->
        <div id="rightzqlist">
            <h2>
                债权草稿管理</h2>
            <div class="rhr">
            </div>
            <!--serch start-->
            <div class="serchl">
                &nbsp;&nbsp;
                <table>
                    <tr>
                        <td>
                            添加日期：
                        </td>
                        <td>
                           <input id="bgdate" type="text" runat="server" readonly="readonly" onclick="getDateString(this);"
                        maxlength="10"   style="width: 150px;" />
                        </td>
                        <td>
                            &nbsp;到&nbsp;
                        </td>
                        <td>
                           <input id="egdate" type="text" runat="server" readonly="readonly" onclick="getDateString(this);"
                        maxlength="10"   style="width: 150px;"/>
                             <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="CompareValidator"
                        ControlToCompare="bgdate" ControlToValidate="egdate" Operator="GreaterThan" Type="Date" ForeColor="Red" Font-Size="9pt">截至日期必须大于生效日期
                    </asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                     
               
                            <td>
                                标题：
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtTitle"   style="width: 150px;"></asp:TextBox></td>
                                <td></td>
                                <td>
                                <asp:Button runat="server" ID="btnSearch" Text="搜 索" OnClick="btnSearch_Click" Style="background: url(../Other/images/yes.gif);
                                    width: 80px; height: 25px; border: none; cursor: pointer; font-size: 13px; color: White" />
                            </td>
                    </tr>
                </table>
            </div>
   <!--serch end-->
            <!--列表 start-->
            <div id="list">
                <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound">
                    <HeaderTemplate>
                        <table>
                            <tr id="trtop">
                                <td align="center" width="20%">
                                    案件标题
                                </td>
                                <td align="center" width="20%">
                                    添加时间
                                </td>
                                <td align="center" width="20%">
                                    投标个数
                                </td>
                                <td align="center" width="15%">
                                    账龄
                                </td>
                                <td align="center" width="25%">
                                    操作
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
                                <%# GetTenderCountByCreditID(Eval("CreditId"))%>
                            </td>
                            <td>
                                <%# Eval("Age")%>
                            </td>
                            <td>
                                <asp:HyperLink ID="hlUpdate" runat="server" NavigateUrl='<%# "UpdateCreditInfo.aspx?Id=" + Eval("CreditId") %>'>修改</asp:HyperLink>
                                <asp:LinkButton ID="lbtnRelease" runat="server" Text="发布" OnClick="lbtnRelease_Click"
                                    CommandArgument='<%# Eval("CreditId") %>'></asp:LinkButton>
                                <asp:HyperLink ID="hlShowTender" runat="server" NavigateUrl='<%# "CreditDetils.aspx?Id=" + Eval("CreditId") %>'>查看详细</asp:HyperLink>
                                <asp:LinkButton ID="lbtnDelete" runat="server" Text="删除" OnClientClick="javascript:return confirm('确定删除吗？');"
                                    OnClick="lbtnDelete_Click" CommandArgument='<%# Eval("CreditId") %>'></asp:LinkButton>
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
