<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetPassWord.aspx.cs" Inherits="XYECOM.Web.GetPassWord" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/Other/css/layout.css" rel="stylesheet" type="text/css" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <script language="javascript" type="text/javascript" src="/Common/js/base.js"></script>
    <script language="javascript" type="text/javascript" src="/config/js/config.js"></script>
    <script language="javascript" type="text/javascript" src="/Other/js/login.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="all">
        <!----------头部开始----------------->
        <div id="top">
            <div class="logo">
                <img src="/Other/images/logo.png" /></div>
            <p class="p1">
                <a href="#">关于我们</a> | <a href="#">安全承诺</a> | <a href="#">加入收藏</a> | <a href="#">设为首页</a></p>
        </div>
        <!----------内容开始-------------->
        <div id="middle">
            <h2>
                找回密码</h2>
            <table width="880" border="0" align="center" cellpadding="6" cellspacing="0">
                <tr>
                    <td align="right" valign="top" width="130" style="padding-top: 12px;" align="left">
                        <strong class="Font14_1">通过邮箱找回密码</strong> <span class="red">*</span>
                    </td>
                    <td width="293" valign="top">
                        <input type="text" name="email" id="email" size="28" maxlength="30" class="regOutInput" />
                        <br />
                        <input type="button" id="btnFindPwd" value="找回密码" onclick="RetakePasswordByEmail();" />
                    </td>
                    <td width="432" valign="top">
                        <div id="Div1" class="regOutTip">
                        请输入您在本站的注册邮箱。
                    </td>
                </tr>
            </table>
            <h2>
                重设密码
            </h2>
            <table width="880" border="0" align="center" cellpadding="6" cellspacing="0">
                <tr>
                    <td align="right" valign="top" width="130" style="padding-top: 12px;" align="left">
                        <strong class="Font14_1">请输入您用户名</strong> <span class="red">*</span>
                    </td>
                    <td width="293" valign="top">
                        <input name="" type="text" size="28" id="username" class="regOutInput" maxlength="100"
                            onblur="chktxtPassword('0');" onfocus="fsm('0');" />
                    </td>
                    <td width="432" valign="top" id="txt0" class="regOutTip">
                        请输入您注册的用户名。
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top" width="130" style="padding-top: 12px;" align="left">
                        <strong class="Font14_1">密码提示问题</strong> <span class="red">*</span>
                    </td>
                    <td width="293" valign="top">
                        <input name="" type="text" size="28" id="question" onblur="chktxtPassword('1');"
                            onfocus="fsm('1');" class="regOutInput" readonly="readonly" disabled />
                    </td>
                    <td width="432" valign="top" class="regOutTip" id="txt1">
                        您注册时填写的密码提示问题。
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top" width="130" style="padding-top: 12px;" align="left">
                        <strong class="Font14_1">密码提示答案</strong> <span class="red">*</span>
                    </td>
                    <td width="293" valign="top">
                        <input name="" type="text" size="28" id="answer" onblur="chktxtPassword('2');" onfocus="fsm('2');"
                            class="regOutInput" />
                    </td>
                    <td width="432" valign="top" id="txt2" class="regOutTip">
                        请输入您注册时填写的密码提示问题答案。
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top" width="130" style="padding-top: 12px;" align="left">
                        <strong class="Font14_1">输入新密码</strong> <span class="red">*</span>
                    </td>
                    <td width="293" valign="top">
                        <input name="" type="password" size="28" id="newpwd" onblur="chktxtPassword('3');"
                            onfocus="fsm('3');" class="regOutInput" />
                    </td>
                    <td width="432" valign="top" id="txt3" class="regOutTip">
                        6-20位(不能包含汉字), 不能与用户名相同。
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top" width="130" style="padding-top: 12px;" align="left">
                        <strong class="Font14_1">确认密码</strong> <span class="red">*</span>
                    </td>
                    <td width="293" valign="top">
                        <input name="" type="password" size="28" id="npassword" onblur="chktxtPassword('4');"
                            class="regOutInput" onfocus="fsm('4');" />
                    </td>
                    <td width="432" valign="top" id="txt4" class="regOutTip">
                        请再输入一遍上面填写的密码
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <input type="button" id="btnResetPwd" value="重设密码" onclick="return checkpassword();"
                            disabled="disabled" />
                        <input type="reset" value=" 取消 " onclick="window.location.href='{config.WebURL}/index.{config.Suffix}'" />
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
        </div>
        <!------------页脚--------------->
        <hr />
        <div id="footer" style="text-align: center; line-height: 22px; font-size: 13px; color: #666">
            版权所有：包青天管理网 ICP备050028356<br />
            全国服务热线：400-800-800&nbsp;&nbsp; 增值业务电信许可证&nbsp;&nbsp;&nbsp;Copyright@2011-2013
        </div>
    </div>
    <div>
    </div>
    </form>
</body>
</html>
