<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForeclosedInfo.aspx.cs"
    Inherits="XYECOM.Web.xymanage.Foreclosed.ForeclosedInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>抵债详细信息</title>
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
        <a href="../index.aspx">后台管理首页</a> >> 抵债详细信息</h1>
    <table width="100%">
        <tr>
            <td class="right">
                <div class="main-setting">
                    <div class="itemtitle">
                        <h3>
                            抵债详细信息</h3>
                    </div>
                    <table width="100%" class="xy_tb xy_tb2 infotable" id="InfoShow">
                        <tr>
                            <th>
                                编号：
                            </th>
                            <td>
                                <asp:Label ID="labIdentityNumber" runat="server"></asp:Label>
                            </td>
                        </tr>
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
                                低价：
                            </th>
                            <td>
                                <asp:Label ID="labLinePrice" runat="server"></asp:Label>元
                            </td>
                        </tr>
                        <tr>
                            <th>
                                当前最高价：
                            </th>
                            <td>
                                <asp:Label ID="labHighPrice" runat="server"></asp:Label>元
                            </td>
                        </tr>
                        <tr>
                            <th>
                                地区：
                            </th>
                            <td>
                                <asp:Label ID="labAreaId" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                详细地址：
                            </th>
                            <td>
                                <asp:Label ID="labAddress" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                结束时间：
                            </th>
                            <td>
                                <asp:Label ID="labEndDate" runat="server"></asp:Label>
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
                                审核状态：
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
                                详细描述：
                            </th>
                            <td>
                                <span runat="server" id="spDescription"></span>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                物品类型：
                            </th>
                            <td>
                                <asp:Label ID="labTypeName" runat="server"></asp:Label>
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
