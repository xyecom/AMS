<%@ Page Title="" Language="C#" MasterPageFile="~/Server/Server.master" AutoEventWireup="true"
    CodeBehind="ParticipateCreditList.aspx.cs" Inherits="XYECOM.Web.Server.ParticipateCreditList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <!--right start-->
    <div id="right">
        <!--rightzqlist start-->
        <div id="rightzqlist">
            <h2>
                我参与的案件</h2>
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
                案件状态：<asp:DropDownList Width="150px" ID="drpState" runat="server">
                    <asp:ListItem Value="-2" Text="所有"></asp:ListItem>
                    <asp:ListItem Value="2" Text="投标中"></asp:ListItem>
                    <asp:ListItem Value="3" Text="案件进行中"></asp:ListItem>
                    <asp:ListItem Value="4" Text="服务商案件完成等待债权人确认"></asp:ListItem>
                    <asp:ListItem Value="5" Text="案件结束"></asp:ListItem>
                    <asp:ListItem Value="6" Text="债权人取消案件"></asp:ListItem>
                </asp:DropDownList>
                <asp:Button runat="server" ID="btnSearch" Text="搜索" OnClick="btnSearch_Click" />
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
                                    投标时间
                                </td>
                                <td align="center" width="10%">
                                    投标状态
                                </td>
                                <td align="center" width="10%">
                                    案件状态
                                </td>
                                <td align="center" width="15%">
                                    催收期限(天)
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
                                <%# Eval("TenderDate", "{0:yyyy-MM-dd}")%>
                            </td>
                            <td>
                                <%# GetTenderState(Eval("IsSuccess"))%>
                            </td>
                            <td>
                                <%# GetApprovaStatus(Eval("CreditInfoId"))%>
                            </td>
                            <td>
                                <%# GetCreditInfoByCredID(Eval("CreditInfoId")).CollectionPeriod%>
                            </td>
                            <td>
                                <asp:HiddenField ID="hidCreditInfoId" runat="server" Value='<%# Eval("CreditInfoId")%>' />
                                <asp:HiddenField ID="hidTenderId" runat="server" Value='<%# Eval("TenderId")%>' />
                                <asp:HyperLink ID="hlShowTender" runat="server" NavigateUrl='<%# "/CreditInfoDetail.aspx?Id=" + Eval("CreditInfoId") %>'>查看详细</asp:HyperLink>
                                <asp:HyperLink Visible="false" ID="hlEvaluate" runat="server" NavigateUrl='<%# "AddEvaluation.aspx?Id=" + Eval("CreditInfoId") %>'>评价</asp:HyperLink>
                                <asp:LinkButton Visible="false" ID="lbtnCreditConfirm" runat="server" Text="确认案件完成"
                                    OnClientClick="javascript:return confirm('确定该案件执行完毕吗？');" OnClick="lbtnCreditConfirm_Click"
                                    CommandArgument='<%# Eval("CreditInfoId") %>'></asp:LinkButton>
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
