<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_FriendLink_FriendLinkTypeAdd"
    CodeBehind="FriendLinkTypeAdd.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <link href="../css/style.css" type="text/css" rel="stylesheet" />

    <script language="javascript" type="text/javascript" src="/common/js/base.js"></script>

    <script language="javascript" type="text/javascript">
  function Input()
  {
     if(document.getElementById("tbfltypename").value == "")
     {
        return alertmsg('�������������','',false);
     } 
     if(document.getElementById("tbfltypealt").value == "")
     {
        return alertmsg('���������˵��','',false);
     }
  }
    </script>

    <title>�����������</title>
</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <a href="../index.aspx">��̨������ҳ</a> &gt;&gt; �����������</h1>
    <table width="100%">
        <tr>
            <td class="right">
                <div class="main-setting">
                    <div class="itemtitle">
                        <h3>
                            �������ӷ���</h3>
                    </div>
                    <table class="xy_tb xy_tb2">
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                �������ƣ�
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform">
                                <asp:TextBox ID="tbfltypename" runat="server" MaxLength="20" CssClass="txt"></asp:TextBox>
                            </td>
                            <td class="vtop tips2">
                            </td>
                        </tr>
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                ����˵����
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform">
                                <asp:TextBox ID="tbfltypealt" runat="server" TextMode="MultiLine" Rows="3" Columns="40"
                                    MaxLength="30" CssClass="txt"></asp:TextBox>
                            </td>
                            <td class="vtop tips2">
                            </td>
                        </tr>
                        <tr>
                            <td class="content_action" colspan="2">
                                <label>
                                    <asp:Button ID="btadd" runat="server" CssClass="button" Text="�ύ" OnClick="btadd_Click" />
                                    <input id="btnback" runat="server" class="button" type="button" value="����" /></label>
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
