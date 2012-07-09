<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogManage.aspx.cs" Inherits="XYECOM.Web.xymanage.Global.LogManage" %>

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
    <script type="text/javascript" src="/common/js/date.js">        function DIV1_onclick() {

        }

    </script>
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
                            ��־����</h3>
                        <ul class="tab1">
                            <li class="current"><a href="LogManage.aspx"><span>����Ա��־����</span></a></li>
                            <li><a href="LogUserLogin.aspx"><span>�û���¼/ע����־����</span></a></li>
                            <li><a href="LogUserbehavior.aspx"><span>�û�������Ϊ��־</span></a></li>
                        </ul>
                    </div>
                    <table class="xy_tb xy_tb2">
                        <tr>
                            <td class="content_action">
                                ���⣺<asp:TextBox ID="txtname" runat="server" CssClass="input"></asp:TextBox>&nbsp;
                                ����Ա���ƣ�<asp:TextBox ID="txtadmin" runat="server" CssClass="input"></asp:TextBox>
                                ģ������<asp:TextBox ID="txtmould" runat="server" CssClass="input"></asp:TextBox>
                                
                            </td>
                        </tr>
                        <tr>
                            <td>
                                ����ʱ�䣺<input id="begindate" runat="server" maxlength="10" onclick="getDateString(this);"
                                    readonly="readonly" style="width: 90px" type="text" />
                                ��
                                <input id="enddate" runat="server" maxlength="10" onclick="getDateString(this);"
                                    readonly="readonly" style="width: 90px" type="text" />&nbsp;
                                <asp:Button ID="Button4" runat="server" CssClass="button" Text="����" OnClick="Button4_Click"></asp:Button>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView HeaderStyle-CssClass="gv_header_style" ID="gvlist" runat="server" AutoGenerateColumns="False"
                                    DataKeyNames="L_ID" Width="100%" PageSize="20" GridLines="None" OnRowDataBound="gvlist_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="L_ID" HeaderText="L_ID" Visible="False" />
                                        <asp:TemplateField HeaderText="ѡ��">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkExport" runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle Width="5%" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="L_Title" HeaderText="����">
                                            <HeaderStyle CssClass="gvLeft" />
                                            <ItemStyle Width="45%" CssClass="gvLeft" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="UM_Name" HeaderText="����Ա����">
                                            <HeaderStyle CssClass="gvLeft" />
                                            <ItemStyle Width="10%" CssClass="gvLeft" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="L_MF" HeaderText="ģ����">
                                            <ItemStyle Width="15%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="L_addtime" HeaderText="����">
                                            <ItemStyle Width="20%" />
                                        </asp:BoundField>
                                        <%--<asp:HyperLinkField DataNavigateUrlFields="L_ID" DataNavigateUrlFormatString="loginfo.aspx?L_ID={0}"
                                            HeaderText="�鿴" NavigateUrl="loginfo.aspx?L_ID={0}" Text="&lt;img src=&quot;../images/look.gif&quot; /&gt;">
                                            <ItemStyle Width="5%" />
                                        </asp:HyperLinkField>--%>
                                        <asp:TemplateField HeaderText="�鿴">
                                            <ItemTemplate>
                                                <a href='LogInfo.aspx?L_ID=<%# Eval("L_ID").ToString()%>&backURL=<%# backURL %>'>
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
                                    runat="server" />ȫѡ
                                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="ɾ��" CssClass="button" />
                                <asp:Button ID="btnDelAll" runat="server" CssClass="button" OnClick="btnDelAll_Click"
                                    Text="ɾ��ȫ��" />
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
