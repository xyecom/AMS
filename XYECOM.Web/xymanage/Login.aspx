<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="XYECOM.Web.xymanage.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>纵横B2B电子商务系统-Management System Power by XYECS!B2B</title>
    <link rel="stylesheet" href="/common/css/xylib.css" type="text/css" />
    <script language="javascript" type="text/javascript" src="/common/js/base.js"></script>
    <script language="javascript" type="text/javascript" src="javascript/CheckedAll.js"></script>
    <script language="javascript" type="text/javascript">
        function getuserfocus() {
            document.getElementById("txtUserName").focus();
        }
        if (self != top) { top.location = self.location; } 
    </script>
    <link rel="stylesheet" href="css/style.css" type="text/css" />
    <link rel="stylesheet" href="css/login.css" type="text/css" />
    <style>
        body
        {
            background: url(images/body_bg.gif) repeat-x left top;
        }
    </style>
</head>
<body onload="getuserfocus();">
    <form action="" method="post" runat="server">
    <div id="login">
        <img src="/xymanage/Images/logo.jpg" alt="纵横电子商务" />
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <th>
                    帐 &nbsp;号：
                </th>
                <td>
                    <label>
                        <asp:TextBox ID="txtUserName" runat="server" CssClass="inputtext" MaxLength="25"
                            Width="150px" TabIndex="1"></asp:TextBox>&nbsp;
                    </label>
                </td>
                <td rowspan="3" class="button_login">
                    <asp:ImageButton ID="btnLogin" runat="server" alt="登录商务网站平台" ImageUrl="/xymanage/images/button_login.gif"
                        OnClientClick="return getlogin(this);" OnClick="btnLogin_Click" TabIndex="4" />
                </td>
            </tr>
            <tr>
                <th>
                    密 &nbsp;码：
                </th>
                <td>
                    <label>
                        <asp:TextBox ID="txtPassWord" runat="server" CssClass="inputtext" MaxLength="25"
                            TextMode="Password" Width="150px" TabIndex="2"></asp:TextBox>&nbsp;
                    </label>
                </td>
            </tr>
            <tr>
                <th>
                    验证码：
                </th>
                <td colspan="2">
                    <label>
                        <asp:TextBox ID="txtCode" runat="server" CssClass="inputtext" MaxLength="25" Width="50px"
                            TabIndex="3"></asp:TextBox>&nbsp;
                        <img src="/Common/ValidateCode.ashx" alt="看不清点我" id="imgCode" onclick="this.src='/Common/ValidateCode.ashx?='+Math.random();"
                            style="cursor: pointer; vertical-align: middle;" /></label>
                </td>
            </tr>
            <tr>
                <td colspan="3" id="copyright">
                    Powered by <a href="http://www.xyecs.com/" target="_blank"><strong>xyesc!b2b 3.2</strong></a>
                    &copy; 2006-2009 <a href="http://www.xyecom.com" target="_blank">xyecom Inc</a>.
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
