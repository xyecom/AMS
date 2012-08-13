<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="XYECOM.Web.Register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>注册</title>
    <link href="/Other/css/layout.css" rel="stylesheet" type="text/css" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <script language="javascript" type="text/javascript" src="/Common/js/base.js"></script>
    <script language="javascript" type="text/javascript" src="/config/js/config.js"></script>
    <style type="text/css">
        #divtitle h2
        {
            width: 100px;
        }
    </style>
</head>
<body>
    <form id="from1" runat="server">
    <div id="all">
        <!----------头部开始----------------->
        <div id="top">
            <div class="logo">
                <a href="Index.aspx" title="返回首页"><img src="/Other/images/logo.png" style=" border:none" /></a></div>
            <p class="p1">
              <a href="aboutus.htm">关于我们</a> | <a href="aqcn.htm">安全承诺</a> |  <a href="#" onclick="this.style.behavior='url(#default#homepage)';this.setHomePage('http://www.baoqt.cn/')">
                    设为首页</a> | <a href='#' onclick='window.external.AddFavorite("http://www.baoqt.cn/","【包青天债权管理网】")'>
                        添加到收藏夹</a></p>
        </div>
        <!----------内容开始-------------->
        <div id="middle">
            <div style="width: 800px; height: auto; overflow: hidden; background-color: #F7F7F6;
                margin: 20px auto; border: 2px solid #ddd;">
                <div style="width: 200px; height: 80px; float: left; margin: 19px 19px;">
                    <strong style="font-size: 28px">快速注册</strong><br />
                    <p style="margin-top: 10px; font-size: 13px; color: #666">
                        30秒快速注册，包青天欢迎您！</p>
                </div>
                <div style="float: right; padding-top: 50px; padding-right: 20px;">
                    已有包青天账号？<a href="Login.aspx"><strong style="color: red">登录</strong></a>
                </div>
                <div class="fuwu" style="width: 800px; margin: 10px auto">
                    <div class="sle">
                        <h3>
                            &nbsp;&nbsp;&nbsp;请选择注册身份</h3>
                        <asp:RadioButton ID="RadioButton1" runat="server" GroupName="C" Text="债权人 企业" AutoPostBack="true"
                            OnCheckedChanged="RadioButton1_CheckedChanged" ToolTip="0" Checked="true" />
                        <asp:RadioButton ID="RadioButton2" runat="server" GroupName="C" Text="债权人 个人" AutoPostBack="true"
                            OnCheckedChanged="RadioButton1_CheckedChanged" ToolTip="1" />
                        <asp:RadioButton ID="RadioButton3" runat="server" GroupName="C" Text="律师" AutoPostBack="true"
                            OnCheckedChanged="RadioButton1_CheckedChanged" ToolTip="2" />
                        <asp:RadioButton ID="RadioButton4" runat="server" GroupName="C" Text="非律师" AutoPostBack="true"
                            OnCheckedChanged="RadioButton1_CheckedChanged" ToolTip="3" />
                    </div>
                    <table width="800" style="margin-left: 60px; font-size: 14px">
                        <tr>
                            <td width="175" height="40" class="ming">
                                用户名：
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtUserName"></asp:TextBox><span class="span1">*长度为3-20个字符，可由字母数字、“-”、“@”组成</span>
                            </td>
                        </tr>
                        <tr>
                            <td height="40" class="ming">
                                密码：
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtPwd1" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPwd1"
                                    Display="Dynamic" ErrorMessage="*密码必须填写"></asp:RequiredFieldValidator>
                                <span class="span1">*长度为6-20个字符，区分大小写</span>
                            </td>
                        </tr>
                        <tr>
                            <td height="40" class="ming">
                                确认密码：
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtPwd2" TextMode="Password"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPwd1"
                                    ControlToValidate="txtPwd2" Display="Dynamic" ErrorMessage="两次密码输入不一致!"></asp:CompareValidator>
                                <span class="span1">*请注意与上面密码输入一致</span>
                            </td>
                        </tr>
                        <tr>
                            <td width="175" height="40" class="ming">
                                所在地区：
                            </td>
                            <td>
                                <div id="divarea">
                                    <input type="hidden" id="city" name="city" runat="server" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td height="40" class="ming">
                                E-mail：
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox><span class="span1">*公司常用邮箱，我们将发邮件确认</span>
                            </td>
                        </tr>
                    </table>
                    <asp:MultiView ID="MultiView1" runat="server">
                        <asp:View ID="View2" runat="server">
                            <table width="800" style="margin-left: 60px; font-size: 14px">
                                <tr>
                                    <td width="175" height="40" class="ming">
                                        公司名称：
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtCompanyName"></asp:TextBox><span class="span1">*例如：陕西省旗舰福运科技有限公司</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="40" class="ming">
                                        公司法人或负责人：
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtCompanyChief"></asp:TextBox><span class="span1">*请填写公司法人代表真实姓名</span>
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="View3" runat="server">
                        </asp:View>
                        <asp:View ID="View4" runat="server">
                            <table width="800" style="margin-left: 60px; font-size: 14px">
                                <tr>
                                    <td width="175" height="40" class="ming">
                                        所在事务所名称：
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtLawyerCompanyName"></asp:TextBox><span class="span1">*例如：陕西省福运律师事务所</span>
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="View5" runat="server">
                        </asp:View>
                    </asp:MultiView>
                    <div style="text-align: center">
                        <asp:Button runat="server" CssClass="btn_agree2" ID="btnReg" Text="注册"  OnClick="btnReg_Click"  Style="background: url(Other/images/yes.gif);
                                    width: 80px; height: 25px; border: none; cursor: pointer; font-size: 13px; color: White" />
                    </div>
                </div>
            </div>
        </div>
        <!------------页脚--------------->
        <hr />
        <div id="footer" style="text-align: center; line-height: 22px; font-size: 13px; color: #666">
            版权所有：包青天管理网 ICP备050028356<br />
            全国服务热线：400-800-800&nbsp;&nbsp; 增值业务电信许可证&nbsp;&nbsp;&nbsp;Copyright@2011-2013
        </div>
    </div>
    </form>
    <script type="text/javascript">
        var claarea = new ClassType("claarea", 'area', 'divarea', 'city');
        claarea.Mode = "select";
        claarea.Init();
    </script>
</body>
</html>
