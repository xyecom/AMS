<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditCredLeavl.aspx.cs"
    Inherits="XYECOM.Web.xymanage.Basic.EditCredLeavl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>后台添加信用等级</title>
    <link href="../css/cue.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <script language="javascript" type="text/javascript" src="/common/js/base.js"></script>
    <script type="text/javascript">
        window.onload = function () {
            document.getElementById("<%= this.btnOk.ClientID %>").onclick = function () {
                var operat = document.getElementById("<%= this.hidType.ClientID %>").value;
                if (operat == "add") {
                    var downPoint = document.getElementById("<%= this.hidDownPoint.ClientID %>").value;
                    var dp = parseInt(downPoint);
                    var txtDp = document.getElementById("<%= this.txtDownPoint.ClientID %>").value;
                    var inDp = parseInt(txtDp);
                    if (inDp <= dp) {
                        sAlert("分数下线应该大于：" + dp);
                        return false;
                    }
                }
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <a href="../index.aspx">后台首页</a> >> 添加信用等级</h1>
    <table width="100%">
        <tr>
            <td class="right" style="height: auto">
                <div class="main-setting">
                    <div class="itemtitle">
                        <h3>
                            信用等级维护</h3>
                    </div>
                    <table width="100%" class="xy_tb xy_tb2 infotable">
                        <tr>
                            <th>
                                等级名称：
                            </th>
                            <td style="padding-top: 8px;">
                                <asp:TextBox ID="txtLeavlName" runat="server"></asp:TextBox>
                                <!--hidPrevId当前级别的上一级-->
                                <asp:HiddenField runat="server" ID="hidDownPoint" />
                                <asp:HiddenField runat="server" ID="hidType" />
                            </td>
                        </tr>
                        <tr>
                            <th>
                                对应图标：
                            </th>
                            <td>
                                <asp:TextBox ID="txtImagePath" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                分数底线：
                            </th>
                            <td>
                                <asp:TextBox ID="txtDownPoint" runat="server"></asp:TextBox>
                                最小为：<asp:Label ID="lblMinValue" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                            </th>
                            <td>
                                <asp:Button ID="btnOk" runat="server" Text="保存" CssClass="button" OnClick="btnOk_Click" />
                                <input type="reset" class="button" value="取消" id="btnCancel" onclick="javascript:history.back()" />
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
