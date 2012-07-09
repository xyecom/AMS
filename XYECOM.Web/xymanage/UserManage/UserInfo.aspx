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
    <script language="javascript" type="text/javascript">
        function GetTable(num) {
            if (num == 2) {
                document.getElementById("userinfo").style.display = 'none';
                document.getElementById("auditing").style.display = 'block';
            } else {
                document.getElementById("userinfo").style.display = 'block';
                document.getElementById("auditing").style.display = 'none';
            }
        }
        //会员有效时间切换
        function getgradetimeshow(num) {
            if (num == 1) {
                document.getElementById("ddmath").style.display = "block";
                document.getElementById("tbyear").style.display = "none";
            }
            else {
                document.getElementById("tbyear").style.display = "block";
                document.getElementById("ddmath").style.display = "none";
            }

        }
        function updategrade() {
            if (document.getElementById("rsgrade").checked == false) {
                return alertmsg('会员等级没有选择！', '', false);
            }
            if (document.getElementById("rbmath").checked == false && document.getElementById("rbyear").checked == false) {
                return alertmsg('会员有效时间没有选择！', '', false);
            }
            if (document.getElementById("rbyear").checked == true) {
                if (document.getElementById("rsgrade").value == "") {
                    return alertmsg('请输入时间！', '', false);
                }
                if (document.getElementById("rsgrade").value.search(/^[-\+]?\d+$/) == -1) {
                    return alertmsg('请输入时间问整数！', '', false);
                }
            }
        }
    </script>
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
                                    联系人：
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
                                    所在部门：
                                </th>
                                <td id="lbsection" runat="server">
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    担任职位：
                                </th>
                                <td id="lbpost" runat="server">
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    会员等级：
                                </th>
                                <td id="lblevel" runat="server">
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    状态：
                                </th>
                                <td id="Td1" runat="server">
                                    <asp:Label ID="lbmessage" runat="server" ForeColor="Red" Text="lbmessage"></asp:Label>
                                </td>
                            </tr>
                            <asp:Panel runat="server" ID="plreason" Visible="false">
                                <tr>
                                    <th>
                                        原因：
                                    </th>
                                    <td>
                                        <asp:Label ID="labreason" runat="server" ForeColor="Red" Text="lbmessage"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        意见：
                                    </th>
                                    <td>
                                        <asp:Label ID="labadv" runat="server" ForeColor="Red" Text="lbmessage"></asp:Label>
                                    </td>
                                </tr>
                            </asp:Panel>
                            <tr>
                                <th style="height: 30px">
                                </th>
                                <td class="content_action" style="height: 30px">
                                    <asp:Button ID="Button5" runat="server" Text="通过审核" CssClass="button" OnClick="Button5_Click" />
                                    <input id="Button6" type="button" value="不通过审核并告知用户修改建议" class="button" onclick="GetTable(2);" />&nbsp;
                                    <input id="btnBack" type="button" value="返回" class="button" runat="server" />
                                    <input id="U_ID" runat="server" type="hidden" />
                                    <input id="Email" runat="server" type="hidden" />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <div class="itemtitle">
                            <h3>
                                帐户信息</h3>
                        </div>
                        <table width="100%" class="xy_tb xy_tb2 infotable border_buttom0" id="Table1">
                            <tr>
                                <td>
                                    <table width="100%" id="Table2">
                                        <tr>
                                            <th>
                                                虚拟货币余额：
                                            </th>
                                            <td id="lbfcleftmoney" runat="server">
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                现金帐户余额：
                                            </th>
                                            <td id="lbualeftmoney" runat="server">
                                            </td>
                                        </tr>
                                        <!--
<tr>
<th>积分：</th>
<td id="lbmark" runat="server"></td>
</tr>
-->
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <div class="itemtitle">
                            <h3>
                                登录信息</h3>
                        </div>
                        <table width="100%" class="xy_tb xy_tb2 infotable border_buttom0" id="Table3">
                            <tr>
                                <td>
                                    <table width="100%" id="Table5">
                                        <tr>
                                            <th>
                                                注册IP：
                                            </th>
                                            <td id="regip" runat="server">
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                最后登录IP：
                                            </th>
                                            <td id="lastloginip" runat="server">
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                最后登录时间：
                                            </th>
                                            <td id="lastlogintime" runat="server">
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                登录次数：
                                            </th>
                                            <td id="loginnum" runat="server">
                                            </td>
                                        </tr>
                                    </table>
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
                        <br />
                        <br />
                        <br />
                    </div>
                    <table width="100%" class="xy_tb xy_tb2 infotable" id="auditing" style="display: none;">
                        <tr>
                            <td>
                                <table width="100%">
                                    <tr>
                                        <th>
                                            错误处罚
                                        </th>
                                        <td>
                                            <asp:RadioButton ID="rbnoerror" runat="server" Text="不扣除" GroupName="errorgroup"
                                                Checked="True" />&nbsp;<asp:RadioButton runat="server" ID="rbcommonerror" GroupName="errorgroup"
                                                    Text="普通错误" />&nbsp;<asp:RadioButton runat="server" Text="恶意错误" ID="rbgravenesserror"
                                                        GroupName="errorgroup" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            未通过原因：
                                        </th>
                                        <td>
                                            <asp:TextBox ID="tbA_Reason" runat="server" TextMode="MultiLine" Rows="10" Columns="100"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            推荐意见：
                                        </th>
                                        <td>
                                            <asp:TextBox ID="tbA_Advice" runat="server" TextMode="MultiLine" Rows="10" Columns="100"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            &nbsp;
                                        </th>
                                        <td class="content_action">
                                            <asp:Button ID="Button1" runat="server" Text="确定" CssClass="button" OnClick="Button1_Click">
                                            </asp:Button>
                                            <input type="button" value="取消" onclick="javascript:return GetTable(1);" class="button" />
                                        </td>
                                    </tr>
                                </table>
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
