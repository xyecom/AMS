<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogUserbehavior.aspx.cs"
    Inherits="XYECOM.Web.xymanage.Global.LogUserbehavior" %>

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
                            <li><a href="LogUserLogin.aspx"><span>�û���¼/ע����־����</span></a></li>
                            <li class="current"><a href="LogUserbehavior.aspx"><span>�û�������Ϊ��־</span></a></li>
                        </ul>
                    </div>
                    <table class="xy_tb xy_tb2">
                        <tr>
                            <td class="content_action">
                                �û����ƻ�E-Mail��<asp:TextBox ID="txtname" runat="server" CssClass="input"></asp:TextBox>&nbsp;
                                �����<asp:DropDownList runat="server" ID="DDLoperate">
                                    <asp:ListItem Value="-1">��ѡ��</asp:ListItem>
                                    <asp:ListItem Value="0">���߳�ֵ</asp:ListItem>
                                    <asp:ListItem Value="1">֧������</asp:ListItem>
                                    <asp:ListItem Value="2">֧����Ʒ��֤��</asp:ListItem>
                                    <asp:ListItem Value="3">֧����ͬ��֤��</asp:ListItem>
                                    <asp:ListItem Value="8">��ֵ��ͬ��֤��</asp:ListItem>
                                </asp:DropDownList>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                ����ʱ�䣺<input id="bgdate" type="text" runat="server" readonly="readonly" onclick="getDateString(this);"
                                    maxlength="10" style="width: 80px;" />
                                ��
                                <input id="egdate" type="text" runat="server" readonly="readonly" onclick="getDateString(this);"
                                    maxlength="10" style="width: 80px;" />&nbsp;
                                <asp:Button ID="BtnSearch" runat="server" CssClass="button" Text="����" OnClick="BtnSearch_Click">
                                </asp:Button>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView HeaderStyle-CssClass="gv_header_style" ID="gvlist" runat="server" AutoGenerateColumns="False"
                                    DataKeyNames="ID" Width="100%" PageSize="20" GridLines="None">
                                    <Columns>
                                        <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                                        <asp:TemplateField HeaderText="ѡ��">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkExport" runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle Width="5%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="�û���/E-Mail">
                                            <ItemTemplate>
                                                <%# GetUserName(Eval("AccountId").ToString())%>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="gvLeft" />
                                            <ItemStyle Width="15%" CssClass="gvLeft" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="������">
                                            <ItemTemplate>
                                                <%# new XYECOM.Business.Log().GetOperInfo(Eval("Operate").ToString())%>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="gvLeft" />
                                            <ItemStyle Width="10%" CssClass="gvLeft" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="OperateDescription" HeaderText="����˵��">
                                            <HeaderStyle CssClass="gvLeft" />
                                            <ItemStyle Width="45%" CssClass="gvLeft" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="OperateDate" HeaderText="����ʱ��">
                                            <HeaderStyle CssClass="gvLeft" />
                                            <ItemStyle Width="20%" CssClass="gvLeft" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="����">
                                            <ItemTemplate>
                                                <a href="LogUserbehaviorInfo.aspx?ID=<%# Eval("Id").ToString()%>&backURL=<%# backURL %>">
                                                <img src="../images/look.gif" alt="�鿴" /></a>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="gvLeft" />
                                            <ItemStyle Width="10%" CssClass="gvLeft" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td class="content_action">
                                <input class="list_td04" id="chkAll" onclick="chkAll_true()" type="checkbox" name="chkAll"
                                    runat="server" />
                            ȫѡ
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
