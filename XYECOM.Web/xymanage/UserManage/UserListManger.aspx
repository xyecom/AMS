<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_UserManage_UserListManger"
    CodeBehind="UserListManger.aspx.cs" %>

<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc2" %>
<%@ Register Src="../UserControl/top.ascx" TagName="top" TagPrefix="uc1" %>
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
                            �û��б�</h3>
                    </div>
                    <table class="xy_tb xy_tb2">
                        <tr>
                            <td>
                                <table class="partition">
                                    <tr>
                                        <th>
                                            �û����ƣ�
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtKeyWord" runat="server" Width="100px"></asp:TextBox>
                                        </td>
                                        <th>
                                            ��˾���ƣ�
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtcompany" runat="server" Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            ��ҵ����
                                        </th>
                                        <td>
                                            <div id="classType" style="line-height: 20px; padding: 0;">
                                            </div>
                                            <input type="hidden" id="areatypeid" runat="server" />
                                            <script type="text/javascript">
                                                var cla = new ClassType("cla", 'area', 'classType', 'areatypeid');
                                                cla.Mode = "select";
                                                cla.Init();
                                            </script>
                                        </td>
                                        <th>
                                        </th>
                                        <td>
                                            <asp:CheckBox runat="server" ID="cbdays" Checked="true" />
                                            �������&nbsp;<asp:TextBox runat="server" CssClass="" ID="txtdays" Columns="2" Text="2"></asp:TextBox>&nbsp;���ȫ������
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtdays"
                                                ErrorMessage="����Ϊ����" ValidationExpression="^[1-9]\d*$"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            ÿҳ������
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtPageSize" runat="server" CssClass="" Columns="2" Text="20" MaxLength="3"></asp:TextBox>
                                            ��(1~100)
                                            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtPageSize"
                                                ErrorMessage="����1��100֮��" MaximumValue="100" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Button ID="Button2" runat="server" Text="����" CssClass="button" OnClick="Button2_Click" />
                                            <input type="reset" value="����" class="button" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gvlist" HeaderStyle-CssClass="gv_header_style" runat="server" AutoGenerateColumns="False"
                                    DataKeyNames="U_ID,U_Name,U_Email,UI_Name" Width="100%" OnRowDataBound="gvlist_RowDataBound"
                                    GridLines="None">
                                    <Columns>
                                        <asp:BoundField DataField="U_ID" HeaderText="U_ID" Visible="False" />
                                        <asp:TemplateField HeaderText="ѡ��">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkExport" runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle Width="5%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="�û���">
                                            <ItemStyle CssClass="gvLeft" Width="18%" />
                                            <HeaderStyle CssClass="gvLeft" />
                                            <ItemTemplate>
                                                <a href='UserMoreInfo.aspx?U_ID=<%# Eval("U_ID") %>&backURL=<%# backURL %>'>
                                                    <%# Eval("U_Name") %></a><br />
                                                <div style="margin-top: 2px; color: #666;">
                                                    ��¼<%# login.GetUserLoginNumByDate("","",Eval("u_id").ToString()) %>��</div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="��˾����">
                                            <HeaderStyle CssClass="gvLeft" />
                                            <ItemStyle CssClass="gvLeft" Width="22%" />
                                            <ItemTemplate>
                                                <div style="margin-top: 2px; color: #f60;">
                                                    <a href='<%# GetSubUserUrl(Eval("U_ID"),Eval("UserType")) %>'>
                                                        <%# Eval("UI_Name") %>
                                                        (<%# Eval("IsReal").ToString() == "True" ? "��ʵ����֤" : "δʵ����֤"%>) </a>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="�Ƿ���ʵ����Ա">
                                            <HeaderStyle CssClass="gvLeft" />
                                            <ItemStyle CssClass="gvLeft" Width="22%" />
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnSetIsReal" runat="server" CommandArgument='<%# string.Format("{0}|{1}",Eval("IsReal"),Eval("U_Id")) %>'
                                                    OnClick="btnSetIsReal_Click"><%# Eval("IsReal").ToString() == "True" ? "ȡ��ʵ��" : "ʵ����֤"%></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="�û�����">
                                            <HeaderStyle CssClass="gvLeft" />
                                            <ItemStyle CssClass="gvLeft" Width="10%" />
                                            <ItemTemplate>
                                                <%# GetUserTypeName(Eval("UserType"))%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="U_RegDate" HeaderText="ע��ʱ��">
                                            <HeaderStyle Width="12%" />
                                            <ItemStyle Width="12%" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="��ϸ">
                                            <ItemStyle CssClass="gvLeft" Width="10%" />
                                            <HeaderStyle CssClass="gvLeft" />
                                            <ItemTemplate>
                                                <a href='UserInfo.aspx?U_ID=<%# Eval("U_ID") %>&backURL=<%# backURL %>'>
                                                    <img src="../images/look.gif" alt="�༭" /></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="gv_header_style"></HeaderStyle>
                                </asp:GridView>
                                <p style="text-align: center;">
                                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label></p>
                            </td>
                        </tr>
                        <tr>
                            <td class="content_action">
                                <input class="list_td04" id="chkAll" onclick="chkAll_true()" type="checkbox" name="chkAll"
                                    runat="server" />ȫѡ
                                <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="ɾ��" CssClass="button" />&nbsp;
                            </td>
                        </tr>
                    </table>
                    <uc2:page ID="Page1" runat="server" />
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
