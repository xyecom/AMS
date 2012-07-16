<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexCreditList.aspx.cs"
    Inherits="XYECOM.Web.IndexCreditList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>债权信息资讯</title>
    <script src="/Other/js/jquery.js" type="text/javascript"></script>
    <script src="/Common/Js/forebase.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <!--left开始-->
        <div id="left">
            <!--left4开始-->
            <div id="left4">
                <div style="background: url('../images/erji_titlebg.gif'); background-repeat: repeat-x;
                    height: auto; overflow: hidden;">
                    <div style="width: 100px; margin-left: 55px; float: left; font-size: 14px">
                        <strong>债权信息资讯</strong></div>
                    <div style="width: 514px; float: right; text-align: center">
                        <table width="512" style="width: 480px; float: left">
                            <tr>
                                <td width="60">
                                    欠款金额：
                                </td>
                                <td width="92">
                                    <asp:DropDownList runat="server" ID="drpArrears">
                                        <asp:ListItem Value="所有" Text="--所有--"></asp:ListItem>
                                        <asp:ListItem Value="小于1万" Text="0-1万"></asp:ListItem>
                                        <asp:ListItem Value="大于1万小于5万" Text="1万-5万"></asp:ListItem>
                                        <asp:ListItem Value="大于5万小于10万" Text="5万-10万"></asp:ListItem>
                                        <asp:ListItem Value="大于10万" Text=">=10万"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td width="60">
                                    标题：
                                </td>
                                <td width="92">
                                    <asp:TextBox runat="server" ID="txtTitle"></asp:TextBox>
                                </td>
                                <td width="39">
                                    地区
                                </td>
                                <td width="76">
                                    <div id="divarea">
                                        <input type="hidden" id="city" name="city" runat="server" />
                                    </div>
                                    <script type="text/javascript">
                                        var claarea = new ClassType("claarea", 'area', 'divarea', 'city', 1);
                                        claarea.Mode = "select";
                                        claarea.Init();
                                    </script>
                                </td>
                                <td width="92">
                                    <%--                                    <input name="搜索" type="button" value="搜索" style="background: url(../images/yes.gif);
                                        width: 80px; height: 25px; border: none; cursor: pointer; color: #FFF" />--%>
                                    <asp:Button runat="server" ID="btnSearch" OnClick="btnSearch_Click" Text="搜索" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div style="height: auto; width: 721px;">
                    <asp:Repeater ID="dlCreditList" runat="server">
                        <HeaderTemplate>
                            <table>
                                <tr id="trtop">
                                    <td align="center" width="20%">
                                        案件标题
                                    </td>
                                    <td align="center" width="10%">
                                        发布时间
                                    </td>
                                    <td align="center" width="10%">
                                        发布者
                                    </td>
                                    <td align="center" width="10%">
                                        欠款金额
                                    </td>
                                    <td align="center" width="10%">
                                        悬赏金额
                                    </td>
                                    <td align="center" width="15%">
                                        投标人数
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
                                    <%# Eval("CreateDate")%>
                                </td>
                                <td>
                                    <a href=""><%# GetUserName(Eval("DepartId"))%></a><span style="color:Red">点击发布者可查看其信用度</span>
                                </td>
                                <td>
                                    <%# Eval("Arrears")%>
                                </td>
                                <td>
                                    <%# Eval("Bounty")%>
                                </td>
                                <td>
                                    <%# GetTenderCountByCreditID(Eval("CreditId"))%>
                                </td>
                                <td>
                                    <asp:HyperLink ID="hlShowTender" runat="server" NavigateUrl='<%# "/CreditInfoDetail.aspx?Id=" + Eval("CreditId") %>'>查看详细</asp:HyperLink>
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
                </div>
            </div>
            <!--left4结束-->
        </div>
        <!--left结束-->
    </div>
    </form>
</body>
</html>
