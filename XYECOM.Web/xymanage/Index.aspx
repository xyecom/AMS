<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_index" CodeBehind="index.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/style.css" type="text/css" rel="stylesheet" />
    <script language="javascript" type="text/javascript" src="/common/js/base.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <h1 runat="server" id="headTip" class="headTip">
    </h1>
    <table width="100%">
        <tr>
            <td class="right">
                <div class="main-setting">
                    <div class="itemtitle">
                        <h3>
                            ��ݲ���</h3>
                    </div>
                    <table width="99%" class="xy_tb xy_tb2 infotable border_buttom0">
                        <tr>
                            <th>
                                �༭�û���
                            </th>
                            <td>
                                <asp:TextBox ID="lbusrname" runat="server" Width="220px" MaxLength="15"></asp:TextBox>
                            </td>
                            <td width="15%">
                                <asp:Button ID="Button1" runat="server" Text="�ύ" CssClass="button" OnClick="Button1_Click" />
                            </td>
                        </tr>                        
                        <tr>
                            <th>
                                ����ģ�壺
                            </th>
                            <td>
                                <asp:DropDownList ID="ddmodulelist" runat="server" Width="149px">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="Button3" runat="server" Text="�ύ" CssClass="button" OnClick="Button3_Click" />
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Ȩ�����ã�
                            </th>
                            <td>
                                <asp:DropDownList ID="ddlpogroem" runat="server" Width="149px">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="Button4" runat="server" Text="�ύ" CssClass="button" OnClick="Button4_Click" />
                            </td>
                        </tr>
                        <tr>
                            <th>
                                ��ҵ��Ϣ��
                            </th>
                            <td>
                                <asp:DropDownList ID="ddlbusiness" runat="server" Width="149px">
                                    <asp:ListItem Value="1">������Ϣ </asp:ListItem>
                                    <asp:ListItem Value="2">�ӹ���Ϣ </asp:ListItem>
                                    <asp:ListItem Value="3">���̴�����Ϣ </asp:ListItem>
                                    <asp:ListItem Value="4">������Ϣ </asp:ListItem>
                                    <asp:ListItem Value="5">չ����Ϣ </asp:ListItem>
                                    <asp:ListItem Value="6">Ʒ�ƹ��� </asp:ListItem>
                                    <asp:ListItem Value="7">��Ƹ���� </asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="�ύ" CssClass="button" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <div class="itemtitle">
                        <h3>
                            �ٷ���Ϣ</h3>
                    </div>
                    <table width="99%" class="xy_tb xy_tb2 infotable border_buttom0">
                        <tr>
                            <td runat="server" id="tdIframe">
                            </td>
                        </tr>
                    </table>
                    <br />
                    <div class="itemtitle">
                        <h3>
                            ��ϵ����</h3>
                    </div>
                    <table width="99%" class="xy_tb xy_tb2 infotable border_buttom0">
                        <tr>
                            <td width="15%">
                                ��˾���ƣ�
                            </td>
                            <td width="35%">
                                �ݺ����̣�������������޹�˾
                            </td>
                            <td width="15%">
                                ��Ŀ���ƿ�����
                            </td>
                            <td width="35%">
                                QQ:9393581 �绰:010-62669815
                            </td>
                        </tr>
                        <tr>
                            <td>
                                ��Ʒ��ѯ��
                            </td>
                            <td>
                                QQ:843990692 QQ:327126406
                            </td>
                            <td>
                                ģ��������ѯ��
                            </td>
                            <td>
                                QQ:810194562
                            </td>
                        </tr>
                        <tr>
                            <td>
                                �����ͬ��
                            </td>
                            <td>
                                010-86818791
                            </td>
                            <td>
                                �ͷ��绰��
                            </td>
                            <td>
                                010-62669815 010-86818791
                            </td>
                        </tr>
                        <tr>
                            <td>
                                �ٷ���վ��
                            </td>
                            <td>
                                <a href="http://www.xyecom.com/" target="_blank">www.xyecom.com</a>
                            </td>
                            <td>
                                �������ģ�
                            </td>
                            <td>
                                <a href="http://help.xyecom.com/" target="_blank">help.xyecom.com</a>&nbsp;&nbsp;��̳��<a
                                    href="http://bbs.xyecom.com/" target="_blank">bbs.xyecom.com</a>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <br />
    <br />
    </form>
</body>
</html>
