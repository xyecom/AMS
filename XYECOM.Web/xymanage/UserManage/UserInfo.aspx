<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_UserManage_EditeUserInfo"
    CodeBehind="UserInfo.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 transitional//EN" "http://www.w3.org/tr/xhtml1/Dtd/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>�û���ϸ��Ϣ</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/XYLib.css" type="text/css" rel="Stylesheet" />
    <script language="javascript" type="text/javascript" src="/common/js/base.js"></script>
    <script language="javascript" type="text/javascript">
        function GetTable(num) {
            if (num == 2) {
                document.getElementById("userinfo").style.display = 'none';
                document.getElementById("auditing").style.display = 'block';
            } else {
                document.getElementById("userinfo").style.display = 'block';
                document.getElementById("auditing").style.display = 'none';
            }
        }
        //��Ա��Чʱ���л�
        function getgradetimeshow(num) {
            if (num == 1) {
                document.getElementById("ddmath").style.display = "block";
                document.getElementById("tbyear").style.display = "none";
            }
            else {
                document.getElementById("tbyear").style.display = "block";
                document.getElementById("ddmath").style.display = "none";
            }

        }
        function updategrade() {
            if (document.getElementById("rsgrade").checked == false) {
                return alertmsg('��Ա�ȼ�û��ѡ��', '', false);
            }
            if (document.getElementById("rbmath").checked == false && document.getElementById("rbyear").checked == false) {
                return alertmsg('��Ա��Чʱ��û��ѡ��', '', false);
            }
            if (document.getElementById("rbyear").checked == true) {
                if (document.getElementById("rsgrade").value == "") {
                    return alertmsg('������ʱ�䣡', '', false);
                }
                if (document.getElementById("rsgrade").value.search(/^[-\+]?\d+$/) == -1) {
                    return alertmsg('������ʱ����������', '', false);
                }
            }
        }
    </script>
</head>
<body>
    <!--��̨���� -->
    <form id="Form1" method="post" runat="server">
    <h1>
        <a href="../index.aspx">��̨������ҳ</a> >> �û���ϸ��Ϣ</h1>
    <table width="100%">
        <tr>
            <td class="right">
                <div class="main-setting">
                    <div id="userinfo">
                        <div class="itemtitle">
                            <h3>
                                �û�������Ϣ</h3>
                        </div>
                        <table width="100%" class="xy_tb xy_tb2 infotable border_buttom0" id="companyinfo">
                            <tr>
                                <th>
                                    ��˾���ƣ�
                                </th>
                                <td id="lbcompanyname" runat="server">
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    ��ϵ�ˣ�
                                </th>
                                <td id="linkman" runat="server">
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    ��ϵ�绰��
                                </th>
                                <td id="phone" runat="server">
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    E-mail��
                                </th>
                                <td id="mail" runat="server">
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    ���ڲ��ţ�
                                </th>
                                <td id="lbsection" runat="server">
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    ����ְλ��
                                </th>
                                <td id="lbpost" runat="server">
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    ��Ա�ȼ���
                                </th>
                                <td id="lblevel" runat="server">
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    ״̬��
                                </th>
                                <td id="Td1" runat="server">
                                    <asp:Label ID="lbmessage" runat="server" ForeColor="Red" Text="lbmessage"></asp:Label>
                                </td>
                            </tr>
                            <asp:Panel runat="server" ID="plreason" Visible="false">
                                <tr>
                                    <th>
                                        ԭ��
                                    </th>
                                    <td>
                                        <asp:Label ID="labreason" runat="server" ForeColor="Red" Text="lbmessage"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        �����
                                    </th>
                                    <td>
                                        <asp:Label ID="labadv" runat="server" ForeColor="Red" Text="lbmessage"></asp:Label>
                                    </td>
                                </tr>
                            </asp:Panel>
                            <tr>
                                <th style="height: 30px">
                                </th>
                                <td class="content_action" style="height: 30px">
                                    <asp:Button ID="Button5" runat="server" Text="ͨ�����" CssClass="button" OnClick="Button5_Click" />
                                    <input id="Button6" type="button" value="��ͨ����˲���֪�û��޸Ľ���" class="button" onclick="GetTable(2);" />&nbsp;
                                    <input id="btnBack" type="button" value="����" class="button" runat="server" />
                                    <input id="U_ID" runat="server" type="hidden" />
                                    <input id="Email" runat="server" type="hidden" />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <div class="itemtitle">
                            <h3>
                                �ʻ���Ϣ</h3>
                        </div>
                        <table width="100%" class="xy_tb xy_tb2 infotable border_buttom0" id="Table1">
                            <tr>
                                <td>
                                    <table width="100%" id="Table2">
                                        <tr>
                                            <th>
                                                ���������
                                            </th>
                                            <td id="lbfcleftmoney" runat="server">
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                �ֽ��ʻ���
                                            </th>
                                            <td id="lbualeftmoney" runat="server">
                                            </td>
                                        </tr>
                                        <!--
<tr>
<th>���֣�</th>
<td id="lbmark" runat="server"></td>
</tr>
-->
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <div class="itemtitle">
                            <h3>
                                ��¼��Ϣ</h3>
                        </div>
                        <table width="100%" class="xy_tb xy_tb2 infotable border_buttom0" id="Table3">
                            <tr>
                                <td>
                                    <table width="100%" id="Table5">
                                        <tr>
                                            <th>
                                                ע��IP��
                                            </th>
                                            <td id="regip" runat="server">
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                ����¼IP��
                                            </th>
                                            <td id="lastloginip" runat="server">
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                ����¼ʱ�䣺
                                            </th>
                                            <td id="lastlogintime" runat="server">
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                ��¼������
                                            </th>
                                            <td id="loginnum" runat="server">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <div class="itemtitle">
                            <h3>
                                ��������</h3>
                        </div>
                        <table width="100%" class="xy_tb xy_tb2 infotable border_buttom0" id="Table4">
                            <tr>
                                <th>
                                    �����룺
                                </th>
                                <td id="lbpwd" runat="server">
                                    <asp:TextBox ID="txtpwd" runat="server" Text="000000"></asp:TextBox>
                                    <asp:Button ID="Button2" runat="server" Text="��������" CssClass="button" OnClick="Button2_Click" />
                                    <asp:Label ID="libok" runat="server" Text="" Width="82px"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <br />
                    </div>
                    <table width="100%" class="xy_tb xy_tb2 infotable" id="auditing" style="display: none;">
                        <tr>
                            <td>
                                <table width="100%">
                                    <tr>
                                        <th>
                                            ���󴦷�
                                        </th>
                                        <td>
                                            <asp:RadioButton ID="rbnoerror" runat="server" Text="���۳�" GroupName="errorgroup"
                                                Checked="True" />&nbsp;<asp:RadioButton runat="server" ID="rbcommonerror" GroupName="errorgroup"
                                                    Text="��ͨ����" />&nbsp;<asp:RadioButton runat="server" Text="�������" ID="rbgravenesserror"
                                                        GroupName="errorgroup" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            δͨ��ԭ��
                                        </th>
                                        <td>
                                            <asp:TextBox ID="tbA_Reason" runat="server" TextMode="MultiLine" Rows="10" Columns="100"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            �Ƽ������
                                        </th>
                                        <td>
                                            <asp:TextBox ID="tbA_Advice" runat="server" TextMode="MultiLine" Rows="10" Columns="100"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            &nbsp;
                                        </th>
                                        <td class="content_action">
                                            <asp:Button ID="Button1" runat="server" Text="ȷ��" CssClass="button" OnClick="Button1_Click">
                                            </asp:Button>
                                            <input type="button" value="ȡ��" onclick="javascript:return GetTable(1);" class="button" />
                                        </td>
                                    </tr>
                                </table>
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
