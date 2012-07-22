<%@ Page Title="" Language="C#" MasterPageFile="~/Creditor/Creditor.master" AutoEventWireup="true"
    CodeBehind="CreditDetils.aspx.cs" Inherits="XYECOM.Web.Creditor.CreditDetils" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <!--right start-->
    <div id="right">
        <!--rightzqmain start-->
        <div id="rightzqmain">
            <h2>
                债权资料详情</h2>
            <div class="rhr">
            </div>
            <!--基本信息 start-->
            <div class="divtext">
                <div style="text-align: center; margin-top: 5px">
                    <div style="float: right; width: 131px;">
                        关注度：<a href="#"><strong style="color: Red"><asp:Label runat="server" ID="labCount"></asp:Label></strong></a></div>
                    <h4>
                        债务基本资料</h4>
                </div>
                <table style="margin-top: 2px;" class="tab">
                    <tr>
                        <td class="info_lei3">
                            案件标题
                        </td>
                        <td colspan="3" id="heng">
                            <asp:Label ID="labTitle" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="info_lei3">
                            欠款人姓名
                        </td>
                        <td class="info_lei2">
                            <asp:Label ID="labDebtorName" runat="server"></asp:Label>
                        </td>
                        <td class="info_lei3">
                            欠款人联系电话
                        </td>
                        <td class="info_lei2">
                            <asp:Label ID="labDebtorTelpone" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="info_lei3">
                            欠款金额
                        </td>
                        <td class="info_lei2">
                            <asp:Label ID="labArrears" runat="server"></asp:Label>元
                        </td>
                        <td class="info_lei3">
                            欠款原因
                        </td>
                        <td class="info_lei2">
                            <asp:Label ID="labDebtorReason" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="info_lei3">
                            催收期限
                        </td>
                        <td class="info_lei2">
                            <asp:Label ID="labCollectionPeriod" runat="server"></asp:Label>
                        </td>
                        <td class="info_lei3">
                            创建时间
                        </td>
                        <td class="info_lei2">
                            <asp:Label ID="labCreateDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="info_lei3">
                            案件状态
                        </td>
                        <td class="info_lei2">
                            <asp:Label ID="labState" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                        </td>
                        <td class="info_lei3">
                            欠款类型
                        </td>
                        <td class="info_lei2">
                            <asp:Label runat="server" ID="labDebtorType"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="info_lei3">
                            悬赏金额
                        </td>
                        <td class="info_lei2">
                            <asp:Label ID="labBounty" runat="server"></asp:Label>元
                        </td>
                        <td class="info_lei3">
                            其他信息
                        </td>
                        <td class="info_lei2">
                            暂无
                        </td>
                    </tr>
                    <tr>
                        <td class="info_lei3">
                            案情简介
                        </td>
                        <td colspan="3" id="heng">
                            <asp:Label runat="server" ID="labIntroduction"></asp:Label>
                        </td>
                    </tr>
                </table>
                <div style="text-align: center; margin-top: 5px;">
                    <h4>
                        债务催收情况</h4>
                </div>
                <table style="margin-top: 1px;" class="tab">
                    <tr>
                        <td class="info_lei3">
                            账龄
                        </td>
                        <td class="info_lei2">
                            <asp:Label ID="labAge" runat="server"></asp:Label>
                        </td>
                        <td class="info_lei3">
                            是否在诉讼期
                        </td>
                        <td class="info_lei2">
                            <asp:Label ID="labIsInLitigation" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="info_lei3">
                            是否经过诉讼
                        </td>
                        <td class="info_lei2">
                            <asp:Label ID="labIsLitigationed" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                        </td>
                        <td class="info_lei3">
                            是否自行催收过
                        </td>
                        <td class="info_lei2">
                            <asp:Label ID="labIsSelfCollection" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="info_lei3">
                            债务人债务确认
                        </td>
                        <td class="info_lei2">
                            <asp:Label ID="labIsConfirm" runat="server"></asp:Label>
                        </td>
                        <td class="info_lei3">
                            债权凭证
                        </td>
                        <td class="info_lei2" colspan="3">
                            <asp:Label runat="server" ID="labDebtObligation"></asp:Label>
                        </td>
                    </tr>
                </table>
                <input type="hidden" id="hidID" runat="server" />
                <div style="text-align: center; margin-top: 5px;">
                    <h4>
                        案件相关资料</h4>
                </div>
                <div style="width: 763px; height: auto; overflow: hidden">
                    <asp:Repeater runat="server" ID="rpPrice">
                        <ItemTemplate>
                            <img width="96px;" src='/Upload/<%# Eval("At_Path") %>' />
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Repeater runat="server" ID="rpfile">
                        <ItemTemplate>
                            <a href='<%# Eval("FilePath") %>'>
                                <%# Eval("CaseName") %>
                            </a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div style="width: 758px; text-align: center; margin-top: 5px">
                    <h4>
                        投标情况</h4>
                    <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound">
                        <ItemTemplate>
                            <div class="serverlist" style="width: 733px; height: 135px; overflow: hidden; padding: 10px 10px;
                                border: 1px solid #ccc; margin: 10px 0">
                                <div style="text-align: left; margin: 0 10px; width: 711px">
                                    <img src='<%# GetInfoImgHref(Eval("LayerId")) %>' width="50" height="50" />
                                    <a href='/showEvaluation.aspx?isServer=1&UserId=<%# Eval("LayerId") %>' alt="点击发布者可查看其信用度"
                                        target="_blank">
                                        <%# GetUserName(Eval("LayerId"))%></a> &nbsp; &nbsp; &nbsp; 是否中标：<strong style="color: Red;
                                            font-weight: bold; font-size: 14px"><%# GetTenderState(Eval("IsSuccess"))%></strong>&nbsp;
                                    <div style="width: 126px; text-align: right; float: right">
                                        <asp:HiddenField ID="hidCreditInfoId" runat="server" Value='<%# Eval("CreditInfoId")%>' />
                                        <asp:LinkButton ID="lbtnConfirm" runat="server" Text="选为此案件服务商" OnClick="lbtnOK_Click"
                                            OnClientClick="javascript:return confirm('确定选为此案件服务商吗？');" CommandArgument='<%# Eval("TenderId") %>'></asp:LinkButton>
                                        <asp:Label runat="server" Visible="false" ID="labTenderMessage">竞标已结束</asp:Label>
                                        <asp:Label runat="server" Visible="false" ID="labToTender">投标中</asp:Label>
                                    </div>
                                </div>
                                <hr style="width: 710px; text-align: center; height: 1px; color: Red" />
                                <div style="width: 714px; padding-left: 10px; text-align: left;">
                                    服务商留言：<%# Eval("Message")%></div>
                                <div style="text-align: right; width: 727px; height: 18px">
                                    服务商所在地：<strong style="color: Red; font-weight: bold; font-size: 14px"><%# GetAreaName(Eval("LayerId"))%></strong>
                                    &nbsp; &nbsp;</div>
                                <div style="text-align: right; color: #666; width: 727px; height: 19px;">
                                    投标时间：<%# Eval("TenderDate", "{0:yyyy-MM-dd}")%>&nbsp; &nbsp;</div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <div style="width: 705px; height: 30px; line-height: 30px; text-align: center">
                        <XYECOM:Page ID="Page1" runat="server" PageSize="20" OnPageChanged="Page1_PageChanged" />
                    </div>
                    <div>
                        <p style="text-align: center;">
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label></p>
                    </div>
                </div>
            </div>
        </div>
        <!--rightzqmain end-->
    </div>
    <!--right end-->
</asp:Content>
