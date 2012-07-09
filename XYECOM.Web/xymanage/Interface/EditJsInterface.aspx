<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditJsInterface.aspx.cs"
    Inherits="XYECOM.Web.xymanage.Interface.EditJsInterface" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>IM</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />

    <script language="javascript" type="text/javascript" src="/common/js/base.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <a href="../index.aspx">后台管理首页</a> &gt;&gt; 编辑站外Js代码</h1>
    <table width="100%">
        <tr>
            <td>
                <div class="main-setting">
                    <div class="itemtitle">
                        <h3>
                            站外Js代码</h3>
                    </div>
                    <table class="xy_tb xy_tb2 ">
                    <tr class="nobg">
                            <td colspan="2" class="td27">
                                调用索引(Key)：
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform">
                                <asp:TextBox ID="txtKey" runat="server"></asp:TextBox>
                            </td>
                            <td class="vtop tips2">
                                模板中调用时用到，请认证填写，不能重复
                            </td>
                        </tr>
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                是否启用：
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform">
                                <asp:RadioButton ID="rdoEnabled" runat="server" Text="启用" GroupName="isEnabled" />
                                <asp:RadioButton ID="rdoDisabled" runat="server" Text="禁用" GroupName="isEnabled" />
                            </td>
                            <td class="vtop tips2">
                                启用整合服务请详细填写下列数据
                            </td>
                        </tr>
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                调用代码：
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform">
                                <asp:TextBox ID="txtValue" runat="server" MaxLength="2000" CssClass="labelBody" Columns="100"
                                    Rows="10" TextMode="MultiLine" Width="400px"></asp:TextBox><br />
                            </td>
                            <td class="vtop tips2">
                                被调用的JS代码.</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                            <input type="hidden" id="hidKeyName" runat="server" />
                                <asp:Button ID="btnOK" runat="server" CssClass="button" Text="保存设置" OnClick="btnOK_Click" />&nbsp;&nbsp;
                                <input type="button" value="返回" class="button" id="btnback" name="btnback" onclick="javascript:window.history.back();" />
                                &nbsp;&nbsp;<asp:Label
                                    runat="server" ID="lblMessage" CssClass="input" ForeColor="red"></asp:Label>
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
