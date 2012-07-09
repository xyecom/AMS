<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_err" CodeBehind="err.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>信息提示</title>
    <link rel="stylesheet" href="css/style.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <a href="index.aspx">后台设置首页</a> >> 信息提示</h1>
    <div>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <!-- left -->
                <!-- right -->
                <td class="right">
                    <form name="form1" method="post" action="">
                    <div class="main-setting">
                        <div class="itemtitle">
                            <h3>
                                错误信息提示</h3>
                        </div>
                        <!-- 表格 -->
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="xy_tb xy_tb2">
                            <tr>
                                <td valign="top" style="padding-top: 15px; width: 10%;">
                                    &nbsp; &nbsp; &nbsp;
                                    <img alt="" src="/xymanage/images/sysError.gif" />
                                </td>
                                <td class="errorcue" style="width: 80%; line-height: 200%; font-size: 14px;" id="errinfo"
                                    runat="server" align="left">
                                </td>
                            </tr>
                        </table>
                    </div>
                    </form>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
