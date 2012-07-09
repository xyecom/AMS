<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNewsInfoList.aspx.cs"
    Inherits="XYECOM.Web.xymanage.News.AddNewsInfoList" %>

<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <script language="javascript" type="text/javascript" src="/common/js/base.js"></script>
    <script language="javascript" type="text/javascript" src="../javascript/AddNews.js"></script>
    <script type="text/javascript">
        function SelectedAndClose() {
            var objid = $("selinfolist").getElementsByTagName("input");
            var objparentid = parent.$("SelectinfoIds");
            var objparentinfo = parent.$("infos");
            var ids = "";
            var namesId = "";
            var inputs = "";
            var ItemStr = "";
            var objSelectedItemStr = parent.$("HidItemStr");

            for (var i = 0; i < objid.length; i++) {
                if (objid[i].checked) {
                    ids += "" == ids ? "" : ",";
                    ids += objid[i].value;
                    namesId = "Name_" + objid[i].value;
                    var objparentname = $("Name_" + objid[i].value);
                    ItemStr += objid[i].value + ":" + objparentname.outerText + ",";
                }
            }
            //新选择的信息
            var CSelectedItemStr = objSelectedItemStr.value;
            var SelectedItemStrarry = CSelectedItemStr.split(',');
            //已经选择的信息
            var CItemStr = ItemStr.substring(0, ItemStr.length - 1);
            var ItemStrarry = CItemStr.split(',');

            for (var i = 0; i < ItemStrarry.length; i++) {
                var Flag = 0;
                
                for (var j = 0; j < SelectedItemStrarry.length; j++) {
                    var SIarry = SelectedItemStrarry[j].split(':');
                    var Iarry = ItemStrarry[i].split(':');

                    if (SIarry[0] == Iarry[0])
                        Flag = 1;
                }
                if (Flag == 0)
                    objSelectedItemStr.value += ","+ ItemStrarry[i];
            }

            var NewSelectedItemStr = objSelectedItemStr.value;
            //去除字符串首“，”字符
            if (NewSelectedItemStr.substring(0, 1) == ",") {
                NewSelectedItemStr = NewSelectedItemStr.substring(1, objSelectedItemStr.value.length);
            }
            var NewSelectedItemStrarry = NewSelectedItemStr.split(',');
            
            for (var i = 0; i < NewSelectedItemStrarry.length; i++) {
                var SIA = NewSelectedItemStrarry[i].split(':');
                inputs += "<input checked='checked' onclick=\"Selectchange('" + SIA[0] + "')\" type='checkbox' id='cbsel_" + SIA[0] + "' value='" + SIA[0] + "'/><label>" + SIA[1] + "</label>";
            }

            objSelectedItemStr.value = NewSelectedItemStr;
            objparentinfo.innerHTML = inputs;
            parent.CloseInfo();
        }

        window.onload = function () {
            var objparentid = parent.$F("HidItemStr");
            var ItemStr = objparentid.split(",");
            if (ItemStr != null && ItemStr.length > 0) {
                for (var i = 0; i < ItemStr.length; i++) {
                    var CItemStr = ItemStr[i].split(':');
                    var ck = $("cbsel_" + CItemStr[0]);
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
    <div class="infolist">
        <div style="float: left;">
            <span>企业名称,用户登录名,产品标题:</span>
            <asp:TextBox ID="txtName" ToolTip="企业名称,用户登录名,产品标题" runat="server"></asp:TextBox>
        </div>
        <div id="classType">
            <input type="hidden" id="hidTypeId" name="hidTypeId" runat="server" />
            <script type="text/javascript">
                var cla = new ClassType("cla", 'offer', 'classType', 'hidTypeId');
                cla.Mode = "select";
                cla.Init();
            </script>
        </div>
        <div style="float: left">
            <asp:Button ID="btnSearch" runat="server" Text="搜索" OnClick="btnSearch_Click" /></div>
        <p style="clear: both; height: 10px">
        </p>
    </div>
    &nbsp;<div class="selinfo_list" id="selinfolist">
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <li><span><b>编号</b></span> <span><b>产品分类</b></span> <span><b>产品名称</b></span> <span><b>
                    公司名称</b></span> <span><b>登录名</b></span> </li>
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <input type="checkbox" id='cbsel_<%# Eval("SD_ID")%>' value='<%# Eval("SD_ID")%>' />
                    <span>[<%# Eval("PT_Name")%>]</span> <span id='Name_<%# Eval("SD_ID")%>'>
                        <%# Eval("SD_Title")%></span> <span>
                            <%# Eval("UI_Name")%></span> <span>
                                <%# Eval("U_Name")%></span> </li>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <uc1:page ID="Page1" runat="server" PageSize="10" OnPageChanged="Page1_PageChanged" />
    <div>
        <input id="btnOk" type="button" class="button" runat="server" value="确定" onclick="SelectedAndClose()" />
        <input id="BtnEsc" type="button" class="button" value="取消" onclick="parent.CloseInfo()" /></div>
    </form>
</body>
</html>
