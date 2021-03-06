﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreditorInfo.aspx.cs" Inherits="XYECOM.Web.xymanage.CreditorInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>债权详细信息</title>
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <script language="javascript" type="text/javascript" src="/common/js/base.js"></script>
    <script language="javascript" type="text/javascript" src="/config/js/config.js"></script>
    <script language="javascript" type="text/javascript" src="/common/js/date.js"></script>
    <script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
    <script language="javascript" type="text/javascript" src="/common/js/UploadControl.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <a href="../index.aspx">后台管理首页</a> >> 债权详细信息</h1>
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
                        <tr>
                            <th>
                                &nbsp;
                            </th>
                            <td class="content_action">
                                <label>
                                    <asp:Button ID="btnPass" runat="server" CssClass="button" Text="通过审核" OnClick="btnPass_Click" />
                                    <asp:Button ID="btnNoPass" runat="server" CssClass="button" Text="通过不审核" OnClick="btnNoPass_Click" />
                                    <asp:Button ID="Button3" runat="server" Text="返回" CssClass="button" OnClick="Button3_Click" />
                                    <input type="hidden" runat="server" id="hidID" />
                                    <input type="hidden" runat="server" id="hidUserId" />
                                </label>
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
