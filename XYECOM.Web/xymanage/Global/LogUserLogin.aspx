<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogUserLogin.aspx.cs" Inherits="XYECOM.Web.xymanage.Global.LogUserLogin" %>

<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>��־����</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <script language="javascript" type="text/javascript" src="/common/js/base.js"></script>
    <script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
    <script type="text/javascript" src="/common/js/date.js"></script>
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <h1>
        <a href="../index.aspx">��̨������ҳ</a> >> ��־����</h1>
    <table width="100%">
        <tr>
            <td class="right">
                <div class="main-setting">
                    <div class="itemtitle">
                        <h3>
                            �û���־����</h3>
                        <ul class="tab1">
                            <li><a href="LogManage.aspx"><span>����Ա��־����</span></a></li>
                            <li class="current"><a href="LogUserLogin.aspx"><span>�û���¼/ע����־����</span></a></li>
                            <li><a href="LogUserbehavior.aspx"><span>�û�������Ϊ��־</span></a></li>
                        </ul>
                    </div>
                    <table class="xy_tb xy_tb2">
                        <tr>
                            <th>
                                �û����ƻ�E-Mail��
                            </th>
                            <td>
                                <asp:TextBox ID="txtname" runat="server" CssClass="input"></asp:TextBox>&nbsp;
                            </td>
                            <th align="right">
                                ���ڷ�Χ��
                            </th>
                            <td>
                                <input id="bgdate" type="text" runat="server" onclick="getDateString(this);" maxlength="10"
                                    style="width: 80px;" readonly="readonly" />
                                ��
                                <input id="egdate" type="text" runat="server" onclick="getDateString(this);" maxlength="10"
                                    style="width: 80px;" readonly="readonly" />
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <asp:Button ID="BtnSearch" runat="server" CssClass="button" Text="����" OnClick="BtnSearch_Click">
                                </asp:Button>
                                <input type="reset" value="����" class="button" />
                            </th>
                            <td>
                                &nbsp;
                            </td>
                            <th>
                            </th>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <table class="xy_tb xy_tb2">
                        <tr>
                            <td>
                                <asp:GridView HeaderStyle-CssClass="gv_header_style" ID="gvlist" runat="server" AutoGenerateColumns="False"
                                    DataKeyNames="UL_ID" Width="100%" PageSize="20" GridLines="None">
                                    <Columns>
                                        <asp:BoundField DataField="UL_ID" HeaderText="UL_ID" Visible="False" />
                                        <asp:TemplateField HeaderText="ѡ��" Visible="false">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkExport" runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle Width="5%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="�û���/E-Mail">
                                            <ItemTemplate>
                                                <%# GetUserName(XYECOM.Core.MyConvert.GetInt32(Eval("U_ID").ToString())) %>
                                            </ItemTemplate>
                                            <ItemStyle Width="15%" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="LastLoginDate" HeaderText="��¼ʱ��">
                                            <HeaderStyle CssClass="gvLeft" />
                                            <ItemStyle Width="20%" CssClass="gvLeft" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="LastLoginIP" HeaderText="��¼IP">
                                            <ItemStyle Width="15%" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                    <p style="text-align: center;">
                        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label></p>
                    <uc2:page ID="Page1" runat="server" />
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
