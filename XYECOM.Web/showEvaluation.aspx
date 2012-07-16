<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="showEvaluation.aspx.cs"
    Inherits="XYECOM.Web.showEvaluation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <asp:Label ID="labTitle" runat="server"></asp:Label></h1>
    <table width="100%">
        <tr>
            <td class="right">
                <div class="main-setting">
                    <table width="100%" class="xy_tb xy_tb2 infotable" id="InfoShow">
                        <tr>
                            <th>
                                公司名称：
                            </th>
                            <td>
                                <asp:Label ID="labCompName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                用户名：
                            </th>
                            <td>
                                <asp:Label ID="labUserName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                所在地：
                            </th>
                            <td>
                                <asp:Label ID="labAreaId" runat="server"></asp:Label>元
                            </td>
                        </tr>
                    </table>
                    <asp:Panel runat="server" ID="Panel1">
                        <table width="100%" class="xy_tb xy_tb2 infotable" id="Table1">
                            <tr>
                                <th>
                                    联系电话：
                                </th>
                                <td>
                                    <asp:Label ID="labPhone" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    邮箱：
                                </th>
                                <td>
                                    <asp:Label ID="labEmail" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </div>
            </td>
        </tr>
    </table>
    <asp:Panel runat="server" ID="panSecret">
    </asp:Panel>
    <label>
        信用信息</label>
    <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound">
        <HeaderTemplate>
            <table>
                <tr id="trtop">
                    <td align="center" width="20%">
                        评价人姓名
                    </td>
                    <td align="center" width="20%">
                        评价人公司名称
                    </td>
                    <td align="center" width="20%">
                        债权信息标题
                    </td>
                    <td align="center" width="20%">
                        评价结果
                    </td>
                    <td align="center" width="40%">
                        评价描述
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr id="trmidd" style="height: 28px; border-top: 1px solid #ccc" onmousemove="this.style.backgroundColor='#F7F7F7'"
                onmouseout="this.style.backgroundColor='#ffffff'">
                <td id="tdtitle">
                    <%# Eval("UserName")%>
                </td>
                <td>
                    <%# GetComName(Eval("UserId"))%>
                </td>
                <td>
                    <%# GetCreditTitle(Eval("CreditInfoId"))%>
                </td>
                <td>
                    <%# Eval("IsSuccess").ToString()=="1"?"好评":"差评"%>
                </td>
                <td>
                    <%# Eval("Description")%>
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
    </form>
</body>
</html>
