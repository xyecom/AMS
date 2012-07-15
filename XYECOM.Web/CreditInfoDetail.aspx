<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreditInfoDetail.aspx.cs"
    Inherits="XYECOM.Web.CreditInfoDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
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
                                <asp:Label ID="labDebtorTelpone" runat="server"></asp:Label>元
                            </td>
                        </tr>
                        <tr>
                            <th>
                                催收期限：
                            </th>
                            <td>
                                <asp:Label ID="labCollectionPeriod" runat="server"></asp:Label>元
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
                                <asp:Label ID="labArrears" runat="server"></asp:Label>
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
    </form>
</body>
</html>
