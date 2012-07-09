<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectUser.aspx.cs" Inherits="XYECOM.Web.xymanage.LabelManage.SelectUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>专题类别管理</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <script language="javascript" type="text/javascript" src="/common/js/base.js"></script>
    <script type="text/javascript">

        function SelectedAndClose() {
            var objid = $("seltopictypelist").getElementsByTagName("input");
            var objname = $("seltopictypelist").getElementsByTagName("label");
            var objparentid = parent.$("hidUserIds");
            var objparentname = parent.$("spanUserNames");

            var ids = "";
            var names = "";
            for (var i = 0; i < objid.length; i++) {
                if (objid[i].checked) {
                    ids += "" == ids ? "" : ",";
                    ids += objid[i].value;
                    names += " &nbsp; " + objname[i].innerHTML;
                }
            }
            objparentid.value = ids;
            objparentname.innerHTML = names;
            parent.CloseSelect();
        }

        window.onload = function () {
            var objparentid = parent.$F("hidUserIds");
            var ids = objparentid.split(",");
            if (ids != null && ids.length > 0) {
                for (var i = 0; i < ids.length; i++) {
                    var ck = $("cbsel_" + ids[i]);
                    if (ck != null) {
                        ck.checked = "checked";
                    }
                }
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin: 10px 10px 0px 10px;">
        <div style="float: left;">
            <span>企业名称,登录名或者Email:</span>
            <asp:TextBox ID="txtName" ToolTip="请输入企业名称,登录名或者Email" runat="server"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="搜索" OnClick="btnSearch_Click" />
        </div>
    </div>
    <div class="seltopictype_list" style="clear: both;" id="seltopictypelist">
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li style="line-height: 25px;">
                    <input type="radio" name="radio" id="<%# string.Format("cbsel_{0}",Eval("U_Id")) %>"
                        value='<%# Eval("U_Id") %>' />
                    <label for="<%# string.Format("cbsel_{0}",Eval("U_Id")) %>">
                        <%# string.Format("{0}/{1}/{2}", Eval("u_name"),Eval("u_email"), Eval("ui_name"))%></label>
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <XYECOM:Page ID="Page1" runat="server" PageSize="10" OnPageChanged="Page1_PageChanged" />
    <div>
        <input id="btnOk" type="button" class="button" runat="server" value="确定" onclick="SelectedAndClose()" />
        <input id="BtnEsc" type="button" class="button" value="取消" onclick="parent.CloseSelect()" /></div>
    </form>
</body>
</html>
