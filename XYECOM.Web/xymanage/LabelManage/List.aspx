<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_LabelManage_List"
    CodeBehind="List.aspx.cs" %>

<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>标签信息管理</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <script language="javascript" type="text/javascript" src="/common/js/base.js"></script>
    <script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
    <script language="javascript" type="text/javascript">

        function copyToClipboard(lblName) {
            var txt = "&lt;script language='javascript' type='text/javascript' src='" + config.WebURL + "Common/XYOutInvoke.aspx?lblName=" + escape(lblName) + "'&gt;&lt\/script&gt;";
            var txt1 = "<script language='javascript' type='text/javascript' src='" + config.WebURL + "Common/XYOutInvoke.aspx?lblName=" + escape(lblName) + "'><\/script>";
            if (window.clipboardData) {
                window.clipboardData.clearData();
                window.clipboardData.setData("Text", txt1);
            }
            else if (navigator.userAgent.indexOf("Opera") != -1) {
                window.location = txt1;
            }
            else if (window.netscape) {
                try {
                    netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect");
                }
                catch (e) {
                    alert("你使用的FF浏览器,复制功能被浏览器拒绝！\n请在浏览器地址栏输入'about:config'并回车\n然后将'signed.applets.codebase_principal_support'设置为'true'");
                }
                var clip = Components.classes['@mozilla.org/widget/clipboard;1'].createInstance(Components.interfaces.nsIClipboard);
                if (!clip) return;
                var trans = Components.classes['@mozilla.org/widget/transferable;1'].createInstance(Components.interfaces.nsITransferable);
                if (!trans) return;
                trans.addDataFlavor('text/unicode');
                var str = new Object();
                var len = new Object();
                var str = Components.classes["@mozilla.org/supports-string;1"].createInstance(Components.interfaces.nsISupportsString);
                var copytext = txt1;
                str.data = copytext;
                trans.setTransferData("text/unicode", str, copytext.length * 2);
                var clipid = Components.interfaces.nsIClipboard;
                if (!clip) return false;
                clip.setData(trans, null, clipid.kGlobalClipboard);
            }

            //             var lblmsg = new MsgClass("lblmsg");
            //             lblmsg.AlertMsg("下面的信息复制到剪贴板 :<br />" + "<textarea rows='4' cols='60'>" + txt + "</textarea>");
            //             lblmsg.Stop();
            sAlert("下面的信息已复制到剪贴板 :<br />" + "<textarea rows='4' cols='60'>" + txt + "</textarea>");
            sStop();
            return false;
        }
    </script>
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <h1>
        <a href="../index.aspx">后台管理首页</a> >> 标签信息管理</h1>
    <table width="100%">
        <tr>
            <td class="right">
                <div class="main-setting" style="border: none;">
                    <div class="itemtitle">
                        <h3>
                            标签信息管理</h3>
                        <input id="butadd" class="addbtn" type="button" value="新增标签" onclick="window.location.href='Add.aspx?showcopy=0';" />
                    </div>
                    <table class="xy_tb xy_tb2">
                        <tr>
                            <tr>
                                <td style="text-align: left; padding: 3px;">
                                    <asp:DropDownList ID="ddlclassID" runat="server">
                                    </asp:DropDownList>
                                    &nbsp;&nbsp; 标签名称:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>&nbsp;
                                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="搜索" CssClass="button" />&nbsp;&nbsp;注：搜索时请将标签名称中的{}以及XY_前缀去掉进行搜索
                                </td>
                            </tr>
                            <td>
                                <asp:GridView ID="gvList" HeaderStyle-CssClass="gv_header_style" Width="100%" runat="server"
                                    AutoGenerateColumns="False" OnRowDataBound="gvList_RowDataBound" DataKeyNames="L_ID"
                                    GridLines="None">
                                    <Columns>
                                        <asp:BoundField Visible="False" DataField="L_ID">
                                            <ItemStyle Width="10%" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="选择">
                                            <ItemStyle Width="5%" />
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkExport" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="标签名称" DataField="L_Name">
                                            <ItemStyle Width="25%" HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="标签中文名" DataField="L_CName">
                                            <ItemStyle Width="20%" HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="所属分类" DataField="LT_Name">
                                            <ItemStyle Width="10%" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="标签类型">
                                            <ItemTemplate>
                                                <%# GetLabelOfMemberInfo(Eval("L_ID"))%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="编辑">
                                            <ItemStyle Width="5%" />
                                            <ItemTemplate>
                                                <a href='Add.aspx?L_ID=<%# Eval("L_ID") %>&backURL=<%# backURL %>'>
                                                    <img src="../images/edit.GIF" alt="编辑" /></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="复制">
                                            <ItemStyle Width="5%" />
                                            <ItemTemplate>
                                                <a href='Add.aspx?type=1&L_ID=<%# Eval("L_ID") %>&backURL=<%# backURL %>'>
                                                    <img src="../images/look.GIF" alt="复制此标签" /></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="外调">
                                            <ItemStyle Width="5%" />
                                            <ItemTemplate>
                                                <a onclick="javascript:copyToClipboard('<%# Eval("L_Name") %>')" style="cursor: hand">
                                                    <img src="../images/copy.gif" alt="js外调" /></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <p style="text-align: center;">
                                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label></p>
                            </td>
                        </tr>
                        <tr>
                            <td class="content_action">
                                <input id="chkAll" onclick="chkAll_true()" type="checkbox" name="chkAll" runat="server" />全选
                                <asp:Button ID="btndelete" runat="server" CssClass="button" OnClick="btndelete_Click"
                                    Text="删除" />
                            </td>
                        </tr>
                    </table>
                    <uc1:page ID="Page1" runat="server" PageSize="20" OnPageChanged="Page1_PageChanged" />
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
