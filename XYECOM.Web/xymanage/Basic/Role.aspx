<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_basic_Role" CodeBehind="Role.aspx.cs" %>

<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc2" %>
<%@ Register Src="../UserControl/top.ascx" TagName="top" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>��ɫ����</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <link rel="stylesheet" href="../css/style.css" type="text/css" />
    <script language="javascript" type="text/javascript" src="/common/js/base.js"></script>
    <script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
</head>
<body onload="load();">
    <form id="Form1" method="post" runat="server">
    <h1>
        <a href="../index.aspx">��̨������ҳ</a> >> ��ɫ����</h1>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td class="right" style="height: 581px">
                <div class="main-setting">
                    <div class="itemtitle">
                        <h3>
                            ����Ա����</h3>
                        <ul class="tab1">
                            <li><a href="Administrator.aspx"><span>����Ա</span></a></li>
                            <li class="current"><a href="Role.aspx"><span>��ɫ</span></a></li>
                        </ul>
                        <input id="btnAdd" type="button" class="addbtn" value="������ɫ" onclick="block();" />
                    </div>
                    <table class="xy_tb xy_tb2" style="display: none" id="update">
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                ��ɫ���ƣ�
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform">
                                <asp:TextBox ID="TextBox1" runat="server" Width="250" MaxLength="10"></asp:TextBox>
                                <input id="key" runat="server" type="hidden" />
                            </td>
                            <td class="vtop tips2">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="Button2" runat="server" Text="ȷ��" CssClass="button" CausesValidation="False"
                                    OnClick="Button2_Click" />
                                <input type="button" class="button" value="ȡ��" id="Button1" onclick="Exit();" />
                            </td>
                        </tr>
                    </table>
                    <table class="xy_tb xy_tb2" style="display: none" id="add">
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                ��ɫ���ƣ�
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform">
                                <asp:TextBox ID="txtName" runat="server" Width="250px" ToolTip="������Ҫ��ӵ�����" MaxLength="10"></asp:TextBox>
                                <input id="hidUR_ID" runat="server" type="hidden" />
                            </td>
                            <td class="vtop tips2">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <input name="Submit3" type="submit" class="button" value="ȷ��" id="btnOk" runat="server"
                                    title="��ʼ���" onserverclick="btnOk_ServerClick" />
                                <input type="button" class="button" value="ȡ��" id="btnQuit" onclick="quit();" />
                            </td>
                        </tr>
                    </table>
                    <table class="xy_tb xy_tb2">
                        <tr>
                            <td>
                                <asp:GridView ID="gvlist" HeaderStyle-CssClass="gv_header_style" runat="server" AutoGenerateColumns="False"
                                    Width="100%" AllowPaging="True" OnRowCommand="gvlist_RowCommand" DataKeyNames="UR_ID"
                                    OnPageIndexChanging="gvlist_PageIndexChanging" GridLines="None" OnRowDataBound="gvlist_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="UR_ID" HeaderText="UR_ID" Visible="False" />
                                        <asp:BoundField DataField="UR_Name" HeaderText="��ɫ����">
                                            <ItemStyle CssClass="gvLeft" Width="50%" />
                                            <HeaderStyle CssClass="gvLeft" />
                                        </asp:BoundField>
                                        <asp:HyperLinkField DataNavigateUrlFields="UR_ID" DataNavigateUrlFormatString="UserPopedom.aspx?UR_ID={0}"
                                            HeaderText="Ȩ������" NavigateUrl="UserPopedom.aspx?UR_ID={0}" Text="Ȩ������" />
                                        <asp:ButtonField HeaderText="�༭" Text="&lt;img src=&quot;../images/edit.gif&quot; /&gt;"
                                            CommandName="up" />
                                        <asp:ButtonField HeaderText="ɾ��" Text="&lt;img src=&quot;../images/delete.gif&quot; /&gt;"
                                            CommandName="del" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                    <p style="text-align: center;">
                        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                        <uc2:page ID="Page1" runat="server" />
                    </p>
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
