<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PartInfo.aspx.cs" Inherits="XYECOM.Web.xymanage.UserManage.PartInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 transitional//EN" "http://www.w3.org/tr/xhtml1/Dtd/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>�û���ϸ��Ϣ</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/XYLib.css" type="text/css" rel="Stylesheet" />
    <script language="javascript" type="text/javascript" src="/common/js/base.js"></script>
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
                                ���Ż�����Ϣ</h3>
                        </div>
                        <table width="100%" class="xy_tb xy_tb2 infotable border_buttom0" id="companyinfo">
                            <tr>
                                <th>
                                    �������ƣ�
                                </th>
                                <td id="lbcompanyname" runat="server">
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    ���Ÿ����ˣ�
                                </th>
                                <td id="linkman" runat="server">
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    ���ŵ绰��
                                </th>
                                <td id="phone" runat="server">
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    ���Ÿ����˵绰��
                                </th>
                                <td id="managerTel" runat="server">
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
                                    ������ϵ��ʽ��
                                </th>
                                <td id="othercontract" runat="server">
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    ���ڵ�����
                                </th>
                                <td id="area" runat="server">
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    ������ϸ��Ϣ��
                                </th>
                                <td id="tdDescription" runat="server">
                                </td>
                            </tr>
                            <tr>
                                <th style="height: 30px">
                                </th>
                                <td class="content_action" style="height: 30px">
                                    <input id="btnBack" type="button" value="����" class="button" onclick="javascript:history.back();" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
