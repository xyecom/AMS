<%@ Page Title="" Language="C#" MasterPageFile="~/Server/Server.master" AutoEventWireup="true"
    CodeBehind="InProgressCreditList.aspx.cs" Inherits="XYECOM.Web.Server.InProgressCreditList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <!--right start-->
    <div id="right">
        <!--rightzqlist start-->
        <div id="rightzqlist">
            <h2>
                进行中的案件</h2>
            <div class="rhr">
            </div>
            <!--serch start-->
            <div class="serchl">
                &nbsp;&nbsp; 投标日期：
                <input id="bgdate" type="text" runat="server" readonly="readonly" onclick="getDateString(this);"
                    maxlength="10" style="width: 80px;" />
                到
                <input id="egdate" type="text" runat="server" readonly="readonly" onclick="getDateString(this);"
                    maxlength="10" style="width: 80px;" />
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="CompareValidator"
                    ControlToCompare="bgdate" ControlToValidate="egdate" Operator="GreaterThan" Type="Date">截至日期必须大于生效日期
                </asp:CompareValidator>
                &nbsp;&nbsp; &nbsp;&nbsp;
                <%--<input type="text" value="请输入关键字" onfocus="this.value=''" onblur="if(!value){value=defaultValue;}"
                    style="color: #a8a4a3"><input name="" type="button" value="查 询" />--%>
                债权标题：<asp:TextBox runat="server" ID="txtTitle"></asp:TextBox>
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
                                    投标时间
                                </td>
                                <td align="center" width="15%">
                                    催收期限
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
                                <%# GetCreditInfoByCredID(Eval("CreditInfoId")).Title%>
                            </td>
                            <td>
                                <%# Eval("TenderDate")%>
                            </td>
                            <td>
                                <%# GetCreditInfoByCredID(Eval("CreditInfoId")).CollectionPeriod%>
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
