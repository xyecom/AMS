<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_LabelManage_List"
    CodeBehind="List.aspx.cs" %>

<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>��ǩ��Ϣ����</title>
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
                    alert("��ʹ�õ�FF�����,���ƹ��ܱ�������ܾ���\n�����������ַ������'about:config'���س�\nȻ��'signed.applets.codebase_principal_support'����Ϊ'true'");
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
            //             lblmsg.AlertMsg("�������Ϣ���Ƶ������� :<br />" + "<textarea rows='4' cols='60'>" + txt + "</textarea>");
            //             lblmsg.Stop();
            sAlert("�������Ϣ�Ѹ��Ƶ������� :<br />" + "<textarea rows='4' cols='60'>" + txt + "</textarea>");
            sStop();
            return false;
        }
    </script>
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <h1>
        <a href="../index.aspx">��̨������ҳ</a> >> ��ǩ��Ϣ����</h1>
    <table width="100%">
        <tr>
            <td class="right">
                <div class="main-setting" style="border: none;">
                    <div class="itemtitle">
                        <h3>
                            ��ǩ��Ϣ����</h3>
                        <input id="butadd" class="addbtn" type="button" value="������ǩ" onclick="window.location.href='Add.aspx?showcopy=0';" />
                    </div>
                    <table class="xy_tb xy_tb2">
                        <tr>
                            <tr>
                                <td style="text-align: left; padding: 3px;">
                                    <asp:DropDownList ID="ddlclassID" runat="server">
                                    </asp:DropDownList>
                                    &nbsp;&nbsp; ��ǩ����:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>&nbsp;
                                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="����" CssClass="button" />&nbsp;&nbsp;ע������ʱ�뽫��ǩ�����е�{}�Լ�XY_ǰ׺ȥ����������
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
                                        <asp:TemplateField HeaderText="ѡ��">
                                            <ItemStyle Width="5%" />
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkExport" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="��ǩ����" DataField="L_Name">
                                            <ItemStyle Width="25%" HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="��ǩ������" DataField="L_CName">
                                            <ItemStyle Width="20%" HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="��������" DataField="LT_Name">
                                            <ItemStyle Width="10%" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="��ǩ����">
                                            <ItemTemplate>
                                                <%# GetLabelOfMemberInfo(Eval("L_ID"))%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="�༭">
                                            <ItemStyle Width="5%" />
                                            <ItemTemplate>
                                                <a href='Add.aspx?L_ID=<%# Eval("L_ID") %>&backURL=<%# backURL %>'>
                                                    <img src="../images/edit.GIF" alt="�༭" /></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="����">
                                            <ItemStyle Width="5%" />
                                            <ItemTemplate>
                                                <a href='Add.aspx?type=1&L_ID=<%# Eval("L_ID") %>&backURL=<%# backURL %>'>
                                                    <img src="../images/look.GIF" alt="���ƴ˱�ǩ" /></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="���">
                                            <ItemStyle Width="5%" />
                                            <ItemTemplate>
                                                <a onclick="javascript:copyToClipboard('<%# Eval("L_Name") %>')" style="cursor: hand">
                                                    <img src="../images/copy.gif" alt="js���" /></a>
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
                                <input id="chkAll" onclick="chkAll_true()" type="checkbox" name="chkAll" runat="server" />ȫѡ
                                <asp:Button ID="btndelete" runat="server" CssClass="button" OnClick="btndelete_Click"
                                    Text="ɾ��" />
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
