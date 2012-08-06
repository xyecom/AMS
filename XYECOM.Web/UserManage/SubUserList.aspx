<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubUserList.aspx.cs" Inherits="XYECOM.Web.xymanage.UserManage.SubUserList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>�û���Ϣ����</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/XYLib.css" type="text/css" rel="Stylesheet" />
    <script language="javascript" type="text/javascript" src="/common/js/base.js"></script>
    <script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
    <script type="text/javascript" src="/common/js/date.js"></script>
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <h1>
        <a href="../index.aspx">��̨������ҳ</a> >> �û��б�</h1>
    <table width="100%">
        <tr>
            <!-- right -->
            <td class="right">
                <div class="main-setting">
                    <div class="itemtitle">
                        <h3>
                            ��<asp:Label ID="lblCompanyName" runat="server" Text=""></asp:Label>�������б�</h3>
                    </div>
                    <table class="xy_tb xy_tb2">
                        <tr>
                            <td>
                                <asp:GridView ID="gvlist" HeaderStyle-CssClass="gv_header_style" runat="server" AutoGenerateColumns="False"
                                    Width="100%" OnRowDataBound="gvlist_RowDataBound" GridLines="None">
                                    <Columns>
                                        <asp:BoundField DataField="U_ID" HeaderText="U_ID" Visible="False" />
                                        <asp:TemplateField HeaderText="��������">
                                            <ItemTemplate>
                                                <a href='PartInfo.aspx?partid=<%# Eval("u_id") %>'>
                                                    <%# Eval("LayerName") %>
                                                </a>
                                            </ItemTemplate>
                                            <ItemStyle Width="10%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="���Ÿ�����">
                                            <ItemStyle CssClass="gvLeft" Width="18%" />
                                            <HeaderStyle CssClass="gvLeft" />
                                            <ItemTemplate>
                                                <%# Eval("PartManagerName") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="�����˵绰">
                                            <ItemStyle CssClass="gvLeft" Width="18%" />
                                            <HeaderStyle CssClass="gvLeft" />
                                            <ItemTemplate>
                                                <%# Eval("PartManagerTel")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="���ŵ绰">
                                            <HeaderStyle CssClass="gvLeft" />
                                            <ItemStyle CssClass="gvLeft" Width="15%" />
                                            <ItemTemplate>
                                                <%# Eval("Telphone")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="U_RegDate" HeaderText="ע��ʱ��">
                                            <HeaderStyle Width="12%" />
                                            <ItemStyle Width="12%" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                                <p style="text-align: center;">
                                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label></p>
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
