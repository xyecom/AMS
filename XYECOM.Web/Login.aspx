<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="XYECOM.Web.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>登录</title>
    <link href="/Other/css/layout.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
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
            <div id="regleft">
                <img style="margin: 0px 20px" align="middle" src="/Other/images/723280_121819740000_2.gif"
                    alt="" /><br />
                <p style="line-height: 22px; margin: 5px auto; width: 300px; color: #8c8c8c">
                    <strong style="color: red">还不是包青天会员？</strong>
                    <br>
                    包青天债权管理网是您债权管理的好帮手，您可以免费注册并获得我们的资讯等，并可以随时随地管理您的应收账款等债权信息。让您资产无忧！<a href="Register.aspx"><strong
                        style="color: red">快来注册吧！</strong></a>
                </p>
            </div>
            <div id="regright">
                <div style="border-bottom: #d1d0d0 1px solid; border-left: #d1d0d0 1px solid; background-color: #edecec;
                    margin-top: 60px; width: 400px; float: right; height: 250px; border-top: #d1d0d0 1px solid;
                    border-right: #d1d0d0 1px solid">
                    <div style="padding-bottom: 20px; padding-left: 20px; padding-right: 20px; color: #000;
                        font-size: 15px; font-weight: bold; padding-top: 20px">
                        包青天会员登录</div>
                    <table style="text-align: center" width="399" height="123">
                        <tbody>
                            <tr>
                                <td class="style1" width="110">
                                    通行证
                                </td>
                                <td width="210" style="text-align: left">
                                    <input runat="server" style="width: 200px; height: 20px" id="txtUserName" onfocus="if(this.value=='邮箱/客户码/用户名')  this.value=''"
                                        title="如果您是部门登录，只能用部门客户ID或部门负责人邮箱" value="邮箱/客户码/用户名" name="txtname" 
                                        tabindex="1" />
                                </td>
                            </tr>
                            <tr>
                                <td width="110">
                                    密码
                                </td>
                                <td width="210" style="text-align: left">
                                    <input style="width: 200px; height: 20px" id="txtPassWord" value="" type="password"
                                        name="txtpass" runat="server" tabindex="2" />
                                </td>
                            </tr>
                            <tr>
                                <td width="110">
                                    验证码
                                </td>
                                <td width="210" style="text-align: left">
                                    <asp:TextBox ID="txtCode" runat="server" MaxLength="25" Width="50px" TabIndex="3"></asp:TextBox>
                                    <img src="/Common/ValidateCode.ashx" alt="看不清点我" id="imgCode" onclick="this.src='/Common/ValidateCode.ashx?='+Math.random();"
                                        style="cursor: pointer; vertical-align: middle;" />
                                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td height="57" colspan="2" style="text-align: center">
                                    <asp:Button runat="server" ID="btnLogin" Style="width: 89px; height: 30px" Text="登录"
                                        OnClick="btnLogin_Click" TabIndex="4" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <div style="margin: 10px 100px; color: red; font-size: 13px; font-weight: bold">
                        <a href="/getpassword.aspx">忘记密码 </a>&nbsp;&nbsp; |&nbsp;&nbsp;<a href="/register.aspx">
                            免费注册</a></div>
                </div>
            </div>
        </div>
        <!------------页脚--------------->
        <hr>
        <div style="text-align: center; line-height: 22px; color: #666; font-size: 13px"
            id="footer">
            版权所有：包青天管理网 ICP备050028356<br />
            全国服务热线：400-800-800&nbsp;&nbsp; 增值业务电信许可证&nbsp;&nbsp;&nbsp;Copyright@2011-2013
        </div>
    </div>
    </form>
</body>
</html>
