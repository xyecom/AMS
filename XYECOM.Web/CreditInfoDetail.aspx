<%@ Page Title="" Language="C#" MasterPageFile="~/Fore.Master" AutoEventWireup="true"
    CodeBehind="CreditInfoDetail.aspx.cs" Inherits="XYECOM.Web.CreditInfoDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>债权详细信息</title>
    <script type="text/javascript" language="javascript">
        function ShowNo()                        //隐藏两个层 
        {
            document.getElementById("doing").style.display = "none";
            document.getElementById("divcj").style.display = "none";
        }
        function $(id) {
            return (document.getElementById) ? document.getElementById(id) : document.all[id];
        }
        function showFloat()                    //根据屏幕的大小显示两个层 
        {
            var range = getRange();
            $('doing').style.width = range.width + "px";
            $('doing').style.height = range.height + "px";
            $('doing').style.display = "block";
            document.getElementById("divcj").style.display = "";
        }
        function getRange()                      //得到屏幕的大小 
        {
            var top = document.body.scrollTop;
            var left = document.body.scrollLeft;
            var height = document.body.clientHeight;
            var width = document.body.clientWidth;

            if (top == 0 && left == 0 && height == 0 && width == 0) {
                top = document.documentElement.scrollTop;
                left = document.documentElement.scrollLeft;
                height = document.documentElement.clientHeight;
                width = document.documentElement.clientWidth;
            }
            return { top: top, left: left, height: height, width: width };
        } 
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        债权详细信息</h1>
    <table width="100%">
        <tr>
            <td class="right">
                <div class="main-setting">
                    <div class="itemtitle">
                        <h3>
                            债权详细信息</h3>
                    </div>
                    <table width="100%" class="xy_tb xy_tb2 infotable" id="InfoShow">
                        <tr>
                            <th>
                                标题：
                            </th>
                            <td>
                                <asp:Label ID="labTitle" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                欠款人姓名：
                            </th>
                            <td>
                                <asp:Label ID="labDebtorName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                欠款人联系电话：
                            </th>
                            <td>
                                <asp:Label ID="labDebtorTelpone" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                催收期限：
                            </th>
                            <td>
                                <asp:Label ID="labCollectionPeriod" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                欠款原因：
                            </th>
                            <td>
                                <asp:Label ID="labDebtorReason" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                欠款金额：
                            </th>
                            <td>
                                <asp:Label ID="labArrears" runat="server"></asp:Label>元
                            </td>
                        </tr>
                        <tr>
                            <th>
                                悬赏金额：
                            </th>
                            <td>
                                <asp:Label ID="labBounty" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                创建时间：
                            </th>
                            <td>
                                <asp:Label ID="labCreateDate" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                案件状态：
                            </th>
                            <td style="vertical-align: middle;">
                                <asp:Label ID="labState" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                所属公司：
                            </th>
                            <td>
                                <asp:Label ID="labCompanyName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                发布者：
                            </th>
                            <td>
                                <asp:Label ID="labUserName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                案情简介：
                            </th>
                            <td>
                                <asp:Label runat="server" ID="labIntroduction"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                账龄：
                            </th>
                            <td>
                                <asp:Label ID="labAge" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                是否在诉讼期：
                            </th>
                            <td>
                                <asp:Label ID="labIsInLitigation" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                是否经过诉讼：
                            </th>
                            <td style="vertical-align: middle;">
                                <asp:Label ID="labIsLitigationed" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                是否自行催收过：
                            </th>
                            <td>
                                <asp:Label ID="labIsSelfCollection" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                债务人是否确认：
                            </th>
                            <td>
                                <asp:Label ID="labIsConfirm" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                债权凭证：
                            </th>
                            <td>
                                <asp:Label runat="server" ID="labDebtObligation"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                所属地区：
                            </th>
                            <td>
                                <asp:Label ID="labAreaId" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound">
        <HeaderTemplate>
            <table>
                <tr id="trtop">
                    <td align="center" width="10%">
                        服务商名称
                    </td>
                    <td align="center" width="10%">
                        投标日期
                    </td>
                    <td align="center" width="10%">
                        是否中标
                    </td>
                    <td align="center" width="35%">
                        投标留言
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
                    <a href='showEvaluation.aspx?isServer=1&UserId=<%# Eval("LayerId") %>' alt="点击发布者可查看其信用度"
                        target="_blank">
                        <%# GetUserName(Eval("LayerId"))%></a>
                </td>
                <td>
                    <%# Eval("TenderDate")%>
                </td>
                <td>
                    <%# GetTenderState(Eval("IsSuccess"))%>
                </td>
                <td>
                    <%# Eval("Message")%>
                </td>
                <td>
                    <asp:HiddenField ID="hidCreditInfoId" runat="server" Value='<%# Eval("CreditInfoId")%>' />
                    <asp:LinkButton ID="lbtnConfirm" runat="server" Text="选为此案件服务商" OnClick="lbtnOK_Click"
                        OnClientClick="javascript:return confirm('确定选为此案件服务商吗？');" CommandArgument='<%# Eval("TenderId") %>'></asp:LinkButton>
                    <asp:Label runat="server" Visible="false" ID="labTenderMessage">竞标已结束</asp:Label>
                    <asp:Label runat="server" Visible="false" ID="labToTender">投标中</asp:Label>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table></FooterTemplate>
    </asp:Repeater>
    <div style="width: 705px; height: 30px; line-height: 30px; text-align: center">
        <XYECOM:Page ID="Page1" runat="server" PageSize="20" OnPageChanged="Page1_PageChanged" />
    </div>
    <div>
        <p style="text-align: center;">
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label></p>
    </div>
    <input type="hidden" id="hidID" runat="server" />
    <input type="hidden" id="hidStae" runat="server" />
    <div style="width: 710px; height: 40px; line-height: 40px; text-align: center">
        <div style="background: url(../images/yes.gif) no-repeat; width: 396px; height: 25px;
            float: right; line-height: 25px; text-align: left; padding-left: 10px; margin: 10px">
            <a href="javascript:void(0)" onclick="showFloat()"><strong style="color: Red">我要投标</strong></a>
        </div>
    </div>
    <!--加一个半透明层-->
    <div id="doing" style="filter: alpha(opacity=30); -moz-opacity: 0.3; opacity: 0.3;
        background-color: #000; width: 100%; height: 100%; z-index: 800; position: absolute;
        left: 0; top: 0; display: none; overflow: hidden;">
    </div>
    <!--加一个层-->
    <div id="divcj" style="border: solid 10px #898989; background: #fff; padding: 10px;
        width: 600px; z-index: 800; position: absolute; display: none; top: 50%; left: 50%;
        margin: 100px 0 0 -200px;">
        <div style="padding: 3px 15px 3px 15px; text-align: center; vertical-align: middle;">
            <div style="margin: 8px 10px; font-size: 13px; color: #f00">
            </div>
            <div style="margin: 8px 10px;">
                留言：
                <asp:TextBox runat="server" ID="txtRemark" Width="254px" TextMode="MultiLine" Rows="10"></asp:TextBox>
            </div>
            <br />
            <div>
                &nbsp; &nbsp;
                <%--<input id="bntok" type="button" value=" 确 定" style="background: url(../images/ok.gif);
                                            width: 95px; height: 38px; border: none; cursor: pointer; font-size: 13px;" />--%>
                <asp:Button runat="server" ID="btnOK" Text="确定投标" OnClick="btnTender_Click" />
                &nbsp; &nbsp;
                <input id="BttCancel" type="button" value=" 取 消 " onclick="ShowNo()" style="background: url(../images/quit.gif);
                    width: 95px; height: 41px; border: none; cursor: pointer; font-size: 13px;" />
            </div>
        </div>
    </div>
    <!--半透明层结束-->
</asp:Content>
