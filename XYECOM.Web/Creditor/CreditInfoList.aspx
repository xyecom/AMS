<%@ Page Title="" Language="C#" MasterPageFile="~/Creditor/Creditor.master" AutoEventWireup="true"
    CodeBehind="CreditInfoList.aspx.cs" Inherits="XYECOM.Web.Creditor.CreditInfoList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <title>外包债权中心</title>
    <script type="text/javascript">
        var ConfirmCredit = function () {
            if (window.confirm("确认取消案件吗？")) {
                return window.confirm("案件一旦取消标识着案件中止建议请联系并和案件服务商协商，否则出现纠纷无本网站无关？");
            }
            return false;
        }
        var ClosedCredit = function () {
            if (window.confirm("确认关闭案件吗？")) {
                return window.confirm("请认真核实案件是否完全结束，关闭后案件中止？");
            }
            return false;
        }    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <!--right start-->
    <div id="right">
        <!--rightzqlist start-->
        <div id="rightzqlist">
            <h2>
                外包债权中心</h2>
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
                                style="width: 150px;" />
                        </td>
                        <td>
                            到
                        </td>
                        <td>
                            <input id="egdate" type="text" runat="server" readonly="readonly" onclick="getDateString(this);"
                                style="width: 150px;" />
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="CompareValidator"
                                ControlToCompare="bgdate" ControlToValidate="egdate" Operator="GreaterThan" Type="Date"
                                ForeColor="Red" Font-Size="9pt">截至日期必须大于生效日期
                            </asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            案件状态：
                        </td>
                        <td>
                            <asp:DropDownList Width="150px" ID="drpState" runat="server">
                                <asp:ListItem Value="-2" Text="所有"></asp:ListItem>
                                <asp:ListItem Value="-1" Text="未审核"></asp:ListItem>
                                <asp:ListItem Value="0" Text="草稿"></asp:ListItem>
                                <asp:ListItem Value="1" Text="审核未通过"></asp:ListItem>
                                <asp:ListItem Value="2" Text="投标中"></asp:ListItem>
                                <asp:ListItem Value="3" Text="案件进行中"></asp:ListItem>
                                <asp:ListItem Value="4" Text="服务商案件完成等待债权人确认"></asp:ListItem>
                                <asp:ListItem Value="5" Text="案件结束"></asp:ListItem>
                                <asp:ListItem Value="6" Text="债权人取消案件"></asp:ListItem>
                            </asp:DropDownList>
                            </td>
                            <td>
                                标题：
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtTitle"></asp:TextBox>&nbsp;&nbsp; &nbsp;&nbsp;
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
                                <td align="center" width="40%">
                                    案件标题
                                </td>
                                <td align="center" width="15%">
                                    添加时间
                                </td>
                                <td align="center" width="10%">
                                    投标个数
                                </td>
                                <td align="center" width="10%">
                                    案件状态
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
                                <%# GetApprovaStatus(Eval("ApprovaStatus"))%>
                            </td>
                            <td>
                                <asp:HiddenField ID="hidState" runat="server" Value='<%# Eval("ApprovaStatus")%>' />
                                <asp:HiddenField ID="hidInfoId" runat="server" Value='<%# Eval("CreditId")%>' />
                                <asp:HiddenField ID="hidIsCreditEvaluation" runat="server" Value='<%# Eval("IsCreditEvaluation")%>' />
                                <asp:HyperLink ID="hlUpdate" runat="server" NavigateUrl='<%# "UpdateCreditInfo.aspx?Id=" + Eval("CreditId") %>'>修改</asp:HyperLink>
                                <asp:HyperLink ID="hlShowTender" runat="server" NavigateUrl='<%# "CreditDetils.aspx?Id=" + Eval("CreditId") %>'>查看详情</asp:HyperLink>
                                <asp:HyperLink ID="hlEvaluate" runat="server" NavigateUrl='<%# "AddEvaluation.aspx?Id=" + Eval("CreditId") %>'>评价</asp:HyperLink>
                                <asp:LinkButton ID="lbtnCancel" runat="server" Text="取消案件" OnClick="lbtnCancel_Click"
                                    OnClientClick="javascript:return ConfirmCredit();" CommandArgument='<%# Eval("CreditId") %>'></asp:LinkButton>
                                <asp:LinkButton ID="lbtnClosed" runat="server" Text="关闭案件" OnClick="lbtnClose_Click"
                                    OnClientClick="javascript:return ClosedCredit();" CommandArgument='<%# Eval("CreditId") %>'></asp:LinkButton>
                                <asp:LinkButton ID="lbtnRelease" runat="server" Text="发布" OnClick="lbtnRelease_Click"
                                    CommandArgument='<%# Eval("CreditId") %>'></asp:LinkButton>
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
