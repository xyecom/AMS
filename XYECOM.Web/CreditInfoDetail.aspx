<%@ Page Title="" Language="C#" MasterPageFile="~/Fore.Master" AutoEventWireup="true"
    CodeBehind="CreditInfoDetail.aspx.cs" Inherits="XYECOM.Web.CreditInfoDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #zqmain
        {
            height: auto;
            overflow: hidden;
            border: 1px solid #ddd;
            margin: 5px auto;
        }
        #zqmain h2
        {
            font-size: 17px;
            color: #C00;
            margin: 10px 10px;
            width: 700px;
        }
        table
        {
            border-collapse: collapse; /*细线表格*/
        }
        .rhrd
        {
            background: #C00;
            height: 2px;
        }
        
        .divtextd
        {
            height: auto;
            float: left;
            display: inline;
            margin: 10px 30px;
        }
        .divtextd p
        {
            padding: 10px 20px;
        }
        
        .tabd
        {
            border: 1px solid #ddd;
            color: #555;
            width: 690px;
        }
        .info_lei3
        {
            width: 200px;
            line-height: 22px;
            padding: 2px 5px;
            background-color: #f3f3f3;
            border: 1px solid #ddd;
        }
        .info_lei2
        {
            width: 450px;
            line-height: 22px;
            border: 1px solid #ddd;
            padding: 2px 5px;
        }
        h4
        {
            font-size: 14px;
        }
    </style>
    <title>案件<asp:Literal runat="server" ID="litTitle"></asp:Literal>详情</title>
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

            if (top == 0 && left == 0 && height == 0 && widtd == 0) {
                top = document.documentElement.scrollTop;
                left = document.documentElement.scrollLeft;
                height = document.documentElement.clientHeight;
                width = document.documentElement.clientWidth;
            }
            return { "top": top, "height": left, "height": height, "width": width };
        } 
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="zqmain">
        <h2>
            债权详细信息</h2>
        <div class="rhrd">
        </div>
        <div class="divtextd">
            <div style="text-align: center; margin-top: 5px">
                <h4>
                    债务基本资料</h4>
                <div class="rhrd">
                </div>
            </div>
            <table style="margin-top: 2px;" class="tabd">
                <tr>
                    <td class="info_lei3">
                        发布者：
                    </td>
                    <td class="info_lei2">
                        <a runat="server" id="aShow" target="_blank" alt="点击发布者可查看其信用度">
                            <asp:Label ID="labUserName" runat="server"></asp:Label></a>
                    </td>
                </tr>
                <tr>
                    <td class="info_lei3">
                        标题：
                    </td>
                    <td class="info_lei2">
                        <asp:Label ID="labTitle" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="info_lei3">
                        欠款人姓名(中标后可查看)：
                    </td>
                    <td class="info_lei2">
                        <asp:Label ID="labDebtorName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="info_lei3">
                        欠款人联系电话(中标后可查看)：
                    </td>
                    <td class="info_lei2">
                        <asp:Label ID="labDebtorTelpone" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="info_lei3">
                        催收期限：
                    </td>
                    <td class="info_lei2">
                        <asp:Label ID="labCollectionPeriod" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="info_lei3">
                        欠款原因：
                    </td>
                    <td class="info_lei2">
                        <asp:Label ID="labDebtorReason" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="info_lei3">
                        欠款金额：
                    </td>
                    <td class="info_lei2">
                        <asp:Label ID="labArrears" runat="server"></asp:Label>元
                    </td>
                </tr>
                <tr>
                    <td class="info_lei3">
                        悬赏金额：
                    </td>
                    <td class="info_lei2">
                        <asp:Label ID="labBounty" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="info_lei3">
                        创建时间：
                    </td>
                    <td class="info_lei2">
                        <asp:Label ID="labCreateDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="info_lei3">
                        案件状态：
                    </td>
                    <td class="info_lei2">
                        <asp:Label ID="labState" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="info_lei3">
                        所属公司：
                    </td>
                    <td class="info_lei2">
                        <asp:Label ID="labCompanyName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="info_lei3">
                        案情简介：
                    </td>
                    <td class="info_lei2">
                        <asp:Label runat="server" ID="labIntroduction"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="info_lei3">
                        账龄：
                    </td>
                    <td class="info_lei2">
                        <asp:Label ID="labAge" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="info_lei3">
                        是否在诉讼期：
                    </td>
                    <td class="info_lei2">
                        <asp:Label ID="labIsInLitigation" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="info_lei3">
                        是否经过诉讼：
                    </td>
                    <td class="info_lei2">
                        <asp:Label ID="labIsLitigationed" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="info_lei3">
                        是否自行催收过：
                    </td>
                    <td class="info_lei2">
                        <asp:Label ID="labIsSelfCollection" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="info_lei3">
                        债务人是否确认：
                    </td>
                    <td class="info_lei2">
                        <asp:Label ID="labIsConfirm" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="info_lei3">
                        债权凭证：
                    </td>
                    <td class="info_lei2">
                        <asp:Label runat="server" ID="labDebtObligation"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="info_lei3">
                        所属地区：
                    </td>
                    <td class="info_lei2">
                        <asp:Label ID="labAreaId" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <div style="text-align: center; margin-top: 5px;">
                <h4>
                    【图片信息】(中标后可查看)
                </h4>
                <hr />
                <p>
                    <asp:Repeater runat="server" ID="rpPrice">
                        <ItemTemplate>
                            <img width="96px;" src='/Upload/<%# Eval("At_Path") %>' />
                        </ItemTemplate>
                    </asp:Repeater>
                </p>
                <h4>
                    【文件信息】(中标后可查看)</h4>
                <hr />
                <p>
                    <asp:Repeater runat="server" ID="rpfile">
                        <ItemTemplate>
                            <a href='<%# Eval("FilePath") %>'>
                                <%# GetFileName(Eval("FilePath")) %><br />
                            </a>
                        </ItemTemplate>
                    </asp:Repeater>
                </p>
            </div>
        </div>
    </div>
    <table>
        <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound">
            <HeaderTemplate>
                <tr id="trtop">
                    <td align="center" widtd="10%">
                        服务商名称
                    </td>
                    <td align="center" widtd="10%">
                        投标日期
                    </td>
                    <td align="center" widtd="10%">
                        是否中标
                    </td>
                    <td align="center" widtd="35%">
                        投标留言
                    </td>
                    <td align="center" widtd="25%">
                        操作
                    </td>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr id="trmidd" style="height: 28px; border-top: 1px solid #ccc" onmousemove="tdis.style.backgroundColor='#F7F7F7'"
                    onmouseout="tdis.style.backgroundColor='#ffffff'">
                    <td id="tdtitle">
                        <a href='showEvaluation.aspx?isServer=1&UserId=<%# Eval("LayerId") %>' title="点击发布者可查看其信用度"
                            target="_blank">
                            <%# GetUserName(Eval("LayerId"))%></a>
                    </td>
                    <td>
                        <%# Eval("TenderDate", "{0:yyyy-MM-dd}")%>
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
        </asp:Repeater>
    </table>
    <div style="widtd: 705px; height: 30px; line-height: 30px; text-align: center">
        <XYECOM:Page ID="Page1" runat="server" PageSize="20" OnPageChanged="Page1_PageChanged" />
    </div>
    <div>
        <p style="text-align: center;">
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label></p>
    </div>
    <input type="hidden" id="hidID" runat="server" />
    <input type="hidden" id="hidStae" runat="server" />
    <div style="widtd: 710px; height: 40px; line-height: 40px; text-align: center">
        <div style="background: url(/Other/images/yes.gif) no-repeat; width: 396px; height: 25px;
            float: right; line-height: 25px; text-align: left; padding-left: 10px; margin: 10px">
            <a href="javascript:void(0)" onclick="showFloat()"><strong style="color: White">我要投标</strong></a></div>
    </div>
    <!--加一个半透明层-->
    <div id="doing" style="filter: alpha(opacity=30); -moz-opacity: 0.3; opacity: 0.3;
        background-color: #000; widtd: 100%; height: 100%; z-index: 800; position: absolute;
        left: 0; top: 0; display: none; overflow: hidden;">
    </div>
    <!--加一个层-->
    <div id="divcj" style="border: solid 10px #898989; background: #fff; padding: 10px;
        widtd: 600px; z-index: 800; position: absolute; display: none; top: 50%; left: 50%;
        margin: 100px 0 0 -200px;">
        <div style="padding: 3px 15px 3px 15px; text-align: center; vertical-align: middle;">
            <div style="margin: 8px 10px; font-size: 13px; color: #f00">
            </div>
            <div style="margin: 8px 10px;">
                留言：
                <asp:TextBox runat="server" ID="txtRemark" Widtd="254px" TextMode="MultiLine" Rows="10"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Button runat="server" ID="btnOK" Text="确定投标" OnClick="btnTender_Click" />
                &nbsp; &nbsp;
                <input id="BttCancel" type="button" value=" 取 消 " onclick="ShowNo()" style="background: url(../images/quit.gif);
                    widtd: 95px; height: 41px; border: none; cursor: pointer; font-size: 13px;" />
            </div>
        </div>
    </div>
    <!--半透明层结束-->
</asp:Content>
