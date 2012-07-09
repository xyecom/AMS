<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditPartLabel.aspx.cs"
    Inherits="XYECOM.Web.xymanage.LabelManage.EditPartLabel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>编辑企业专栏标签</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />

    <script language="javascript" type="text/javascript" src="/common/js/base.js"></script>

    <script type="text/javascript" src="../javascript/CheckedAll.js"></script>

    <script language="javascript" type="text/javascript" src="/common/js/date.js"></script>

    <script type="text/javascript">
function SelectUser(obj,toObj)
{
    var value = obj.options[obj.selectedIndex].value;
                
    document.getElementById(toObj).value = value;
}
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <a href="../index.aspx">后台管理首页</a> >> 编辑企业专栏标签</h1>
    <table width="100%">
        <tr>
            <td class="right">
                <div class="main-setting">
                    <div class="itemtitle">
                        <h3 id="title" runat="server">
                            编辑企业专栏标签</h3>
                    </div>
                    <table class="xy_tb xy_tb2 ">
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                标签名称：
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform" style="font-weight: bold; width: 500px; height: 48px;">
                                <asp:Label ID="lblLabelName" runat="server"></asp:Label>
                                <br />
                            </td>
                            <td class="vtop tips2" style="height: 48px">
                            </td>
                        </tr>
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                专栏名称：
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform" style="font-weight: bold; width: 500px; height: 48px;">
                                <asp:Label ID="lblCName" runat="server"></asp:Label>
                                <br />
                            </td>
                            <td class="vtop tips2" style="height: 48px">
                                专栏所在位置等简单描述<br />
                            </td>
                        </tr>
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                专栏格式：
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop " style="font-weight: bold; width: 100px; height: 48px;">
                                <asp:Label ID="lblFormat" runat="server"></asp:Label>
                            </td>
                            <td class="vtop tips2" style="height: 48px">
                                <span></span>
                            </td>
                        </tr>
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                有效时间：
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <input id="txtBeginTime" runat="server" size="10" type="text" readonly="readonly"
                                    onclick="getDateString(this);" />
                                ～
                                <input id="txtEndTime" runat="server" size="10" type="text" readonly="readonly" onclick="getDateString(this);" />&nbsp;<br />
                                &nbsp;
                            </td>
                            <td>
                                结束时间必须大于开始时间<br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtBeginTime"
                                    ErrorMessage="开始时间不能为空"></asp:RequiredFieldValidator><br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEndTime"
                                    ErrorMessage="结束时间不能为空"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr class="nobg">
                            <td colspan="2" class="td27" style="height: 29px">
                                企业名称：
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform">
                                <asp:Label ID="lblCompanyName" runat="server"></asp:Label>
                            </td>
                            <td class="vtop tips2">
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 30px" colspan="2">
                                <asp:Button ID="btnOK" runat="server" CssClass="button" Text="保存" OnClick="btnOK_Click">
                                </asp:Button>&nbsp;
                                <input id="Button1" class="button" type="button" value="返回" onclick="location.href='PartLabelList.aspx';" />
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
