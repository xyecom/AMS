<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="XYECOM.Web.xymanage.Interface.Payment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>在线支付工具</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />

    <script language="javascript" type="text/javascript" src="/common/js/base.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <a href="../index.aspx">后台管理首页</a> >> 在线支付工具整合</h1>
    <table width="100%" class="contentl">
        <tr>
            <td width="15%" rowspan="2">
                &nbsp;<img src="../images/99bill.gif" />
            </td>
            <td width="85%">
                <asp:RadioButtonList ID="rdo99Bill" runat="server" RepeatColumns="2" OnSelectedIndexChanged="rdo_SelectedChanged"
                    AutoPostBack="true">
                    <asp:ListItem Text="启用" Value="Yes"></asp:ListItem>
                    <asp:ListItem Text="禁用" Value="No"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel runat="server" ID="pnl99Bill">
                    <table class="setPay">
                        <tr>
                            <td class="t">
                                商户编号：
                            </td>
                            <td>
                                <asp:TextBox ID="txtMerchant_Id" runat="server" Columns="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="t">
                                商户密钥：
                            </td>
                            <td>
                                <asp:TextBox ID="txtMerchant_Key" runat="server" Columns="50"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td width="15%">
                &nbsp;<img src="../images/chinabank.gif" />
            </td>
            <td width="85%">
                <asp:RadioButtonList ID="rdoChinaBank" runat="server" RepeatColumns="2" OnSelectedIndexChanged="rdo_SelectedChanged"
                    AutoPostBack="true">
                    <asp:ListItem Text="启用" Value="Yes"></asp:ListItem>
                    <asp:ListItem Text="禁用" Value="No"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Panel runat="server" ID="pnlChinaBank">
                    <table class="setPay">
                        <tr>
                            <td class="t">
                                商户号：
                            </td>
                            <td>
                                <asp:TextBox ID="txtV_MId" runat="server" Columns="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="t">
                                密钥：
                            </td>
                            <td>
                                <asp:TextBox ID="txtKey" runat="server" Columns="50"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td width="15%">
                &nbsp;<img src="../images/alipay.gif" />
            </td>
            <td width="85%">
                <asp:RadioButtonList ID="rdoAlipay" runat="server" RepeatColumns="2" OnSelectedIndexChanged="rdo_SelectedChanged"
                    AutoPostBack="true">
                    <asp:ListItem Text="启用" Value="Yes"></asp:ListItem>
                    <asp:ListItem Text="禁用" Value="No"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="2">
                <asp:Panel runat="server" ID="pnlAlipay">
                    <table class="setPay">
                        <tr>
                            <td class="t">
                                合作者Id：
                            </td>
                            <td class="b">
                                <asp:TextBox ID="txtPartnerId" runat="server" Columns="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="t">
                                帐户：
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmail" runat="server" Columns="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="t">
                                安全校验码：
                            </td>
                            <td>
                                <asp:TextBox ID="txtSecurityCode" runat="server" Columns="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="t">
                                接口类型：
                            </td>
                            <td>
                                <select id="service" name="service" runat="server">
                                    <option value="create_direct_pay_by_user">标准双接口</option>
                                    <option value="create_partner_trade_by_buyer">担保交易接口</option>
                                    <option value="trade_create_by_buyer">及时到帐交易接口</option>
                                </select>&nbsp;请选择最后一次和支付宝签订协议中说明的接口类型
                                <%--           
                                <input name="hidservice" runat="server" type="hidden" value="create_partner_trade_by_buyer" id="hidservice" />
                                <script type="text/javascript">document.getElementById("service").value=document.getElementById("hidservice").value;</script>
                                --%>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="btn99BillOk" runat="server" Text="保存设置" CssClass="button" OnClick="btnOK_Click" />
                &nbsp;&nbsp;<asp:Label ID="lblMsg" ForeColor="red" runat="server"></asp:Label>
                <br />
                <br />
            </td>
        </tr>
    </table>
    <table width="100%" class="contentl">
    </table>
    </form>
</body>
</html>
