<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForeclosedDetail.aspx.cs"
    Inherits="XYECOM.Web.ForeclosedDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <!--left开始-->
        <div id="left">
            <div style="height: auto; width: 721px;">
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
                                <td>
                                    发布者：
                                </td>
                                <td colspan="3">
                                    <a href='showEvaluation.aspx?UserId=<%# Eval("DepartmentId") %>' target="_blank">
                                        <asp:Label runat="server" ID="labUserName"></asp:Label></a><span style="color: Red">点击发布者可查看其信用度</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="info1">
                                    物品名称：
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
                                    物品编号：
                                </td>
                                <td>
                                    <asp:Label ID="labIdentityNumber" runat="server"></asp:Label>
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
                                    物品所属地区：
                                </td>
                                <td colspan="3">
                                    <asp:Label ID="labAreid" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="info1">
                                    物品详细地址：
                                </td>
                                <td colspan="3">
                                    <asp:Label ID="labAddress" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="info1">
                                    物品详细描述：
                                </td>
                                <td colspan="3">
                                    <asp:Label runat="server" ID="labDescription"></asp:Label>
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
                        <input type="hidden" id="hidId" runat="server" />
                        【物品相关图片】
                        <hr />
                        <div id="dzbasepic">
                            <a href="../images/left1.gif">
                                <img src="/Common/images/logo.jpg" />
                            </a>
                        </div>
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
                                            <td align="center" width="25%">
                                                出价时间
                                            </td>
                                            <td align="center" width="25%">
                                                来自地区
                                            </td>
                                            <td align="center" width="20%">
                                                买家联系方式
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
                                            <%# Eval("Price")%>
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
                                            <img src="/Common/images/okhank.gif" />领先
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                </FooterTemplate>
                            </asp:Repeater>
                            <asp:Repeater ID="rpChuJu" runat="server">
                                <ItemTemplate>
                                    <tr style="height: 22px; text-align: center; : 1px solid #ccc" onmousemove="this.style.backgroundColor='#F7F7F7'"
                                        onmouseout="this.style.backgroundColor='#ffffff'">
                                        <td>
                                            <%# Eval("Price")%>
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
                                            出局
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
                            <div style="width: 710px; height: 40px; line-height: 40px; text-align: center">
                                <div style="background: url(../images/yes.gif) no-repeat; width: 396px; height: 25px;
                                    float: right; line-height: 25px; text-align: left; padding-left: 10px; margin: 10px">
                                    <a href="javascript:void(0)" onclick="showFloat()"><strong style="color: White">我要报价</strong></a>
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
                                        * 注意：请认真填写您的相关资料！
                                    </div>
                                    <div style="margin: 8px 10px;">
                                        <span style="color: Red">*</span>姓名：
                                        <asp:TextBox runat="server" ID="txtName" Width="254px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                                            ErrorMessage="姓名不能为空"></asp:RequiredFieldValidator>
                                    </div>
                                    <div style="margin: 8px 10px;">
                                        <span style="color: Red">*</span>手机号码：
                                        <asp:TextBox runat="server" ID="txtContact" Width="254px"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtContact"
                                            ErrorMessage="手机号码格式不正确" ValidationExpression="\s*((\d{2,3}-){0,1}\d{11})\s*"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtContact"
                                            ErrorMessage="手机号码不能为空"></asp:RequiredFieldValidator>
                                    </div>
                                    <div style="margin: 8px 10px;">
                                        地址：
                                        <asp:TextBox runat="server" ID="txtAddress" Width="254px"></asp:TextBox>
                                    </div>
                                    <div style="margin: 8px 10px;">
                                        <span style="color: Red">*</span>出价：
                                        <asp:TextBox runat="server" ID="txtPrice" Width="254px"></asp:TextBox>元<asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPrice" ErrorMessage="报价不能为空"></asp:RequiredFieldValidator>
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
                                        <asp:Button runat="server" ID="btnOK" Text="确定" OnClick="btnOK_Click" />
                                        &nbsp; &nbsp;
                                        <input id="BttCancel" type="button" value=" 取 消 " onclick="ShowNo()" style="background: url(../images/quit.gif);
                                            width: 95px; height: 41px; border: none; cursor: pointer; font-size: 13px;" />
                                    </div>
                                </div>
                            </div>
                            <!--半透明层结束-->
                        </div>
                    </div>
                    <!--基本信息 end-->
                </div>
            </div>
        </div>
        <!--left结束-->
    </div>
    </form>
</body>
</html>
