<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SecuritySet.aspx.cs" Inherits="XYECOM.Web.xymanage.Basic.SecuritySet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>网站功能设置</title>
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <script language="javascript" type="text/javascript" src="/common/js/base.js"></script>
    <script language="javascript" type="text/javascript" src="/common/js/UploadControl.js"></script>
    <script language="Javascript" type="text/javascript" src="../javascript/WebSet.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <a href="../index.aspx">后台管理首页</a> >> 系统基本配置</h1>
    <table width="100%">
        <tr>
            <td class="right">
                <div class="main-setting">
                    <div class="itemtitle">
                        <h3>
                            系统基本配置</h3>
                        <ul class="tab1">
                            <li><a href="WebInfo.aspx"><span>基本配置</span></a></li>
                            <li><a href="Function.aspx"><span>功能配置</span></a></li>
                            <li style="display: none;"><a href="BussinessInfoSet.aspx"><span>商业信息相关</span></a></li>
                            <li><a href="UserInfoSet.aspx"><span>用户相关</span></a></li>
                            <li style="display: none;"><a href="ShopSet.aspx"><span>网店相关</span></a></li>
                            <li><a href="Server.aspx"><span>附件服务器</span></a></li>
                            <li><a href="EMailBoxInfoSet.aspx"><span>网站邮箱</span></a></li>
                            <li style="display: none;"><a href="SEO.aspx"><span>SEO设置</span></a></li>
                            <li class="current"><a href="SecuritySet.aspx"><span>安全设置</span></a></li>
                        </ul>
                    </div>
                    <!--水印相关-->
                    <div class="itemtitle">
                        <h3>
                            安全设置</h3>
                    </div>
                    <table class="xy_tb xy_tb2">
                        <tr class="nobg" style="display: none;">
                            <td colspan="2" class="td27">
                                验证码开启项：
                            </td>
                        </tr>
                        <tr style="display: none;">
                            <td class="vtop" colspan="2">
                                <asp:CheckBox ID="chkIsVCodeForRegister" runat="server" Text="用户注册" />&nbsp;
                                <asp:CheckBox ID="chkIsVCodeForUserLogin" runat="server" Text="会员登录" />&nbsp;
                                <asp:CheckBox ID="chkIsVCodeForNewsComment" runat="server" Text="资讯评论" />&nbsp;
                                <asp:CheckBox ID="chkIsVCodeForMessage" runat="server" Text="快速留言" />&nbsp;
                                <asp:CheckBox ID="chkIsVCodeForOrder" runat="server" Text="在线订购" />&nbsp;
                                <asp:CheckBox ID="chkIsVCodeForQuickPost" runat="server" Text="快速发布信息" />&nbsp;
                            </td>
                        </tr>
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                验证码长度：
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop" colspan="2">
                                <asp:TextBox runat="server" ID="txtVCodeLength" MaxLength="2" Width="20px"></asp:TextBox>
                                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtVCodeLength"
                                    ErrorMessage="长度2～15之间" MaximumValue="15" MinimumValue="2" Type="Integer"></asp:RangeValidator><br />
                                <span class="vtop tips2">2~15之间</span>
                            </td>
                        </tr>
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                验证码字符扭曲度：
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop" colspan="2">
                                <asp:DropDownList runat="server" ID="ddlVCodeTortuosity">
                                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                </asp:DropDownList>
                                <br />
                                <span class="vtop tips2">1为不扭曲</span>
                            </td>
                        </tr>
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                验证码字符池：
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop" colspan="2">
                                <asp:TextBox runat="server" ID="txtVCodeCharPool" TextMode="MultiLine" Rows="10"
                                    Columns="100"></asp:TextBox><br />
                                <span class="vtop tips2">多个之间用逗号(,)隔开,建议最少30字符个以上；如果要启用中文字符，尽量使用常用汉字</span>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtVCodeCharPool"
                                    ErrorMessage="字符池不能为空"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                禁止访问IP列表：
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop" colspan="2">
                                <asp:TextBox runat="server" ID="txtForbidIP" TextMode="MultiLine" Rows="6" Columns="100"></asp:TextBox><br />
                                <span class="vtop tips2">多个之间用 | 隔开</span>
                            </td>
                        </tr>
                    </table>
                    <div style="padding: 5px 0px 15px 0px;">
                        <asp:Button ID="btnok" runat="server" CssClass="button" Text="保存设置" OnClientClick="return chkfunctioninput();"
                            OnClick="btnok_Click" />
                    </div>
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
