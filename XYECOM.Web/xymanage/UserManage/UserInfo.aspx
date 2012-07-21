<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_UserManage_EditeUserInfo"
    CodeBehind="UserInfo.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 transitional//EN" "http://www.w3.org/tr/xhtml1/Dtd/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>用户详细信息</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/XYLib.css" type="text/css" rel="Stylesheet" />
    <script language="javascript" type="text/javascript" src="/common/js/base.js"></script>    
</head>
<body>
    <!--后台导航 -->
    <form id="Form1" method="post" runat="server">
    <h1>
        <a href="../index.aspx">后台管理首页</a> >> 用户详细信息</h1>
    <table width="100%">
        <tr>
            <td class="right">
                <div class="main-setting">
                    <div id="userinfo">
                        <div class="itemtitle">
                            <h3>
                                用户基本信息</h3>
                        </div>
                        <table width="100%" class="xy_tb xy_tb2 infotable border_buttom0" id="companyinfo">
                            <tr>
                                <th>
                                    公司名称：
                                </th>
                                <td id="lbcompanyname" runat="server">
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    法人代表：
                                </th>
                                <td id="linkman" runat="server">
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    联系电话：
                                </th>
                                <td id="phone" runat="server">
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    E-mail：
                                </th>
                                <td id="mail" runat="server">
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    其他联系方式：
                                </th>
                                <td id="othercontract" runat="server">
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    公司具体地址：
                                </th>
                                <td id="address" runat="server">
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    所在地区：
                                </th>
                                <td id="area" runat="server">
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    详细信息：
                                </th>
                                <td id="tdDescription" runat="server">
                                </td>
                            </tr>
                            <tr>
                                <th style="height: 30px">
                                </th>
                                <td class="content_action" style="height: 30px">
                                    &nbsp;
                                    <input id="btnBack" type="button" value="返回" class="button" runat="server" />
                                    <input id="U_ID" runat="server" type="hidden" />
                                    <input id="Email" runat="server" type="hidden" />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <div class="itemtitle">
                            <h3>
                                重设密码</h3>
                        </div>
                        <table width="100%" class="xy_tb xy_tb2 infotable border_buttom0" id="Table4">
                            <tr>
                                <th>
                                    新密码：
                                </th>
                                <td id="lbpwd" runat="server">
                                    <asp:TextBox ID="txtpwd" runat="server" Text="000000"></asp:TextBox>
                                    <asp:Button ID="Button2" runat="server" Text="重设密码" CssClass="button" OnClick="Button2_Click" />
                                    <asp:Label ID="libok" runat="server" Text="" Width="82px"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
