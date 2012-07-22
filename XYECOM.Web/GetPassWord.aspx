<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetPassWord.aspx.cs" Inherits="XYECOM.Web.GetPassWord"
    MasterPageFile="~/Fore.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="head">
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <script language="javascript" type="text/javascript" src="/Other/js/login.js"></script>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <h2>
        找回密码</h2>
    <table width="880" border="0" align="center" cellpadding="6" cellspacing="0">
        <tr>
            <td align="right" valign="top" width="130" style="padding-top: 12px;" align="left">
                <strong class="Font14_1">通过邮箱找回密码</strong> <span class="red">*</span>
            </td>
            <td width="200" valign="top">
                <input type="text" name="email" id="email" size="28" maxlength="30" class="regOutInput" />
                <br />
                <input type="button" id="btnFindPwd" value="找回密码" onclick="RetakePasswordByEmail();" />
            </td>
            <td width="350" valign="top" align="left">
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
            <td width="200" valign="top">
                <input name="" type="text" size="28" id="username" class="regOutInput" maxlength="100"
                    onblur="chktxtPassword('0');" onfocus="fsm('0');" />
            </td>
            <td width="350" valign="top" align="left" id="txt0" class="regOutTip">
                请输入您注册的用户名。
            </td>
        </tr>
        <tr>
            <td align="right" valign="top" width="130" style="padding-top: 12px;" align="left">
                <strong class="Font14_1">密码提示问题</strong> <span class="red">*</span>
            </td>
            <td width="200" valign="top">
                <input name="" type="text" size="28" id="question" onblur="chktxtPassword('1');"
                    onfocus="fsm('1');" class="regOutInput" readonly="readonly" disabled />
            </td>
            <td width="350" valign="top" align="left" class="regOutTip" id="txt1">
                您注册时填写的密码提示问题。
            </td>
        </tr>
        <tr>
            <td align="right" valign="top" width="130" style="padding-top: 12px;" align="left">
                <strong class="Font14_1">密码提示答案</strong> <span class="red">*</span>
            </td>
            <td width="200" valign="top">
                <input name="" type="text" size="28" id="answer" onblur="chktxtPassword('2');" onfocus="fsm('2');"
                    class="regOutInput" />
            </td>
            <td width="350" valign="top" align="left" id="txt2" class="regOutTip">
                请输入您注册时填写的密码提示问题答案。
            </td>
        </tr>
        <tr>
            <td align="right" valign="top" width="130" style="padding-top: 12px;" align="left">
                <strong class="Font14_1">输入新密码</strong> <span class="red">*</span>
            </td>
            <td width="200" valign="top">
                <input name="" type="password" size="28" id="newpwd" onblur="chktxtPassword('3');"
                    onfocus="fsm('3');" class="regOutInput" />
            </td>
            <td width="350" valign="top" align="left" id="txt3" class="regOutTip">
                6-20位(不能包含汉字), 不能与用户名相同。
            </td>
        </tr>
        <tr>
            <td align="right" valign="top" width="130" style="padding-top: 12px;" align="left">
                <strong class="Font14_1">确认密码</strong> <span class="red">*</span>
            </td>
            <td width="200" valign="top">
                <input name="" type="password" size="28" id="npassword" onblur="chktxtPassword('4');"
                    class="regOutInput" onfocus="fsm('4');" />
            </td>
            <td width="350" valign="top" align="left" id="txt4" class="regOutTip">
                请再输入一遍上面填写的密码
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <input type="button" id="btnResetPwd" value="重设密码" onclick="return checkpassword();"
                    disabled="disabled" />
                <input type="reset" value=" 取消 " onclick="window.location.href='/index.aspx'" />
            </td>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
