<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Field.aspx.cs" Inherits="XYECOM.Web.xymanage.Basic.Field" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>自定义字段</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/Common/css/xylib.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="/Common/js/base.js"></script>
    <script type="text/javascript" src="../javascript/TreeType.js"></script>
    <script language="javascript" type="text/javascript" src="../javascript/field.js"></script>
    <script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <a href="../index.aspx">后台管理首页</a> >> 新增自定义字段</h1>
    <table width="100%">
        <tr>
            <td class="right">
                <div class="main-setting">
                    <div class="itemtitle">
                        <h3>
                            自定义字段管理</h3>
                    </div>
                    <table class="xy_tb xy_tb2">
                        <tr>
                            <td>
                                <table width="100%">
                                    <tr>
                                        <th width="186">
                                            所属类别：
                                        </th>
                                        <td>
                                            <asp:Label ID="lbClassType" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="topInherit" class="content2">
                                </div>
                                <div id="divfield" class="content2">
                                </div>
                                <input type="hidden" id="deleteids" name="deleteids" />
                                <script type="text/javascript" language="javascript">
var fieldarr =[<asp:Literal runat="server" id="litfieldarr" />];
var topobj = <asp:Literal runat="server" id="littopclass" />;
var fieldobj = new field("fieldobj","topInherit","divfield","cbIsFull","deleteids");
fieldobj.Init(fieldarr,topobj);

function SelectTopAll() {
    fieldobj.SelectTopAll();
}

function ShowTopAll() {
    fieldobj.ShowTopAll();
}

function addline() {
    fieldobj.AddNewLine();
}

function checkfrm() {
    return fieldobj.Check();
}
                                </script>
                            </td>
                        </tr>
                        <tr>
                            <td class="content_action">
                                <input id="btnaddline" class="button" type="button" value="+ 新增一行" onclick="addline();" />
                                <asp:Button ID="btnok" runat="server" CssClass="button" Text="确 定" OnClick="btnok_Click"
                                    OnClientClick="return checkfrm();"></asp:Button>
                                <input type="button" id="btnback" onclick="javascript:window.location.href='Typelist.aspx';"
                                    value="返回" class="button" />
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
