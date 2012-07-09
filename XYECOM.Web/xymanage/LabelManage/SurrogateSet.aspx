<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_LabelManage_SurrogateSet"
    CodeBehind="SurrogateSet.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>�����ǩ����</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/Common/css/XYLib.css" media="screen" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="/Common/js/base.js" language="javascript"></script>

    <script type="text/javascript" src="../javascript/TreeType.js"></script>

    <script type="text/javascript" src="../javascript/CheckedAll.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <table width="100%">
        <tr>
            <!-- right  DataBinder.Eval (Container.DataItem, "A_isAudited") -->
            <td class="right">
                <!--��̨���� -->
                <div class="main-setting">
                    <div class="labeldatatitle">
                        <ul id="labelTable">
                            <li id="li_base" class="current" onclick="infoshow(1,this);"><a href="javascript:;"><span>�����б�</span></a></li>
                            <li id="li_page" onclick="infoshow(2,this);"><a href="javascript:;"><span>��ҳ�б�</span></a></li>
                            <li id="li_key" onclick="infoshow(3,this);"><a href="javascript:;"><span>�ؼ��������б�</span></a></li>
                        </ul>
                    </div>
                    <!--�����б����� -->
                    <table width="100%" class="xy_tb xy_tb2 setLabelData" id="base">
                        <tr>
                            <th>
                                ����ģ�飺
                            </th>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlmodul" CssClass="input" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlmodul_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                ��Ϣ���
                            </th>
                            <td>
                                <div id="classType">
                                </div>
                                <input id="hidTypeID" runat="server" type="hidden" value="" />
                                <input id="moduleflag" runat="server" type="hidden" value="" />

                                <script type="text/javascript">
var cla = new ClassType("cla",'moduleflag','classType','hidTypeID');
cla.Mode = "select";
cla.Init();
                                </script>

                            </td>
                        </tr>
                        <tr>
                            <th>
                                ����������
                            </th>
                            <td>
                                <asp:TextBox ID="tbnum" runat="server" CssClass="input" MaxLength="10" onblur="isNumer(this);"
                                    Text="10"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                ������ʾ������
                            </th>
                            <td>
                                <asp:TextBox ID="tbtitlenum" runat="server" CssClass="input" MaxLength="10" onblur="isNumer(this);"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                ����������ڣ�
                            </th>
                            <td>
                                <asp:TextBox ID="tbclicknum" runat="server" CssClass="input" MaxLength="10" onblur="isNumer(this);"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                �����ֶΣ�
                            </th>
                            <td>
                                <asp:DropDownList ID="ddlorderColumuName" runat="server" CssClass="input">
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlorder" runat="server" CssClass="input">
                                    <asp:ListItem Value="DESC">����</asp:ListItem>
                                    <asp:ListItem Value="ASC">����</asp:ListItem>
                                </asp:DropDownList>
                                <asp:CheckBox runat="server" ID="chkUserGradeOrder" Checked="true" Text="�����Ի�Ա�ȼ�����" />
                            </td>
                        </tr>
                        <tr>
                            <th>
                                ���ڸ�ʽ��
                            </th>
                            <td>
                                <asp:DropDownList ID="ddldatetype" runat="server">
                                    <asp:ListItem Value="">��ѡ��</asp:ListItem>
                                    <asp:ListItem Value="yyyy-MM-dd">yyyy-MM-dd</asp:ListItem>
                                    <asp:ListItem Value="yy-MM-dd">yy-MM-dd</asp:ListItem>
                                    <asp:ListItem Value="MM.dd">MM.dd</asp:ListItem>
                                    <asp:ListItem Value="MM-dd">MM-dd</asp:ListItem>
                                    <asp:ListItem Value="MM\\dd">MM\dd</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                ��Ϣ������ʾ������
                            </th>
                            <td>
                                <asp:TextBox ID="tbinfonum" runat="server" CssClass="input" MaxLength="10" onblur="isNumer(this);"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                ��˾������ʾ������
                            </th>
                            <td>
                                <asp:TextBox ID="tbcorporationNum" runat="server" CssClass="input" MaxLength="10"
                                    onblur="isNumer(this);"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                �Ƿ��Ƽ���
                            </th>
                            <td>
                                <asp:DropDownList ID="ddlCommend" runat="server">
                                    <asp:ListItem Value="">����</asp:ListItem>
                                    <asp:ListItem Value="0">���Ƽ�</asp:ListItem>
                                    <asp:ListItem Value="1">�Ƽ�</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                �Ƿ����ͼƬ��
                            </th>
                            <td>
                                <asp:DropDownList ID="ddlimg" runat="server">
                                    <asp:ListItem Value="">����</asp:ListItem>
                                    <asp:ListItem Value="0">������</asp:ListItem>
                                    <asp:ListItem Value="1">����</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                ��Ϣ���ͣ�
                            </th>
                            <td>
                                <asp:DropDownList ID="ddltype" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                &nbsp;
                            </th>
                            <td>
                                <label>
                                    <asp:Button ID="Button1" runat="server" CssClass="button" Text="ȷ�������˱�ǩ" OnClick="Button1_Click">
                                    </asp:Button>&nbsp;
                                    <input id="Button2" class="button" type="button" value="ȡ ��" onclick="closewindows();" /></label>
                            </td>
                        </tr>
                    </table>
                    <!--��ҳ�б����� -->
                    <table width="100%" class="xy_tb xy_tb2 setLabelData" id="page" style="display: none;">
                        <tr>
                            <th>
                                ÿҳ����������
                            </th>
                            <td>
                                <asp:TextBox ID="tbpagenum" runat="server" CssClass="input" MaxLength="10" onblur="isNumer(this);"
                                    Text="20"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                ������ʾ������
                            </th>
                            <td>
                                <asp:TextBox ID="tbpagetitlenum" runat="server" CssClass="input" MaxLength="10" onblur="isNumer(this);"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                �����ֶΣ�
                            </th>
                            <td>
                                <asp:DropDownList ID="ddlpageorder" runat="server" CssClass="input">
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlpagedesc" runat="server" CssClass="input">
                                    <asp:ListItem Value="DESC">����</asp:ListItem>
                                    <asp:ListItem Value="ASC">����</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                ���ڸ�ʽ��
                            </th>
                            <td>
                                <asp:DropDownList ID="ddlpagedatetype" runat="server">
                                    <asp:ListItem Value="">��ѡ��</asp:ListItem>
                                    <asp:ListItem Value="yyyy-MM-dd">yyyy-MM-dd</asp:ListItem>
                                    <asp:ListItem Value="yy-MM-dd">yy-MM-dd</asp:ListItem>
                                    <asp:ListItem Value="MM.dd">MM.dd</asp:ListItem>
                                    <asp:ListItem Value="MM-dd">MM-dd</asp:ListItem>
                                    <asp:ListItem Value="MM\\dd">MM\dd</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                ��Ϣ������ʾ������
                            </th>
                            <td>
                                <asp:TextBox ID="tbpageproductnum" runat="server" CssClass="input" MaxLength="10"
                                    onblur="isNumer(this);"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                ��˾������ʾ������
                            </th>
                            <td>
                                <asp:TextBox ID="tbpagecorporationnum" runat="server" CssClass="input" MaxLength="10"
                                    onblur="isNumer(this);"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                &nbsp;
                            </th>
                            <td>
                                <label>
                                    <asp:Button ID="Button3" runat="server" CssClass="button" Text="ȷ�������˱�ǩ" OnClick="Button3_Click">
                                    </asp:Button>&nbsp;
                                    <input id="Button4" class="button" type="button" value="ȡ ��" onclick="closewindows();" /></label>
                            </td>
                        </tr>
                    </table>
                    <!--�ؼ��ʾ����б����� -->
                    <table width="100%" class="xy_tb xy_tb2 setLabelData" id="key" style="display: none;">
                        <tr>
                            <th>
                                ��ʾ���Σ�
                            </th>
                            <td>
                                <asp:DropDownList ID="ddlRankList" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                ������ʾ������
                            </th>
                            <td>
                                <asp:TextBox ID="tbkeytitlenum" runat="server" CssClass="input" MaxLength="10" onblur="isNumer(this);"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                ���ڸ�ʽ��
                            </th>
                            <td>
                                <asp:DropDownList ID="ddlkeydatetype" runat="server">
                                    <asp:ListItem Value="">��ѡ��</asp:ListItem>
                                    <asp:ListItem Value="yyyy-MM-dd">yyyy-MM-dd</asp:ListItem>
                                    <asp:ListItem Value="yy-MM-dd">yy-MM-dd</asp:ListItem>
                                    <asp:ListItem Value="MM.dd">MM.dd</asp:ListItem>
                                    <asp:ListItem Value="MM-dd">MM-dd</asp:ListItem>
                                    <asp:ListItem Value="MM\\dd">MM\dd</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                ��Ϣ������ʾ������
                            </th>
                            <td>
                                <asp:TextBox ID="tbkeycontentnum" runat="server" MaxLength="10" CssClass="input"
                                    onblur="isNumer(this);"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                ��˾������ʾ������
                            </th>
                            <td>
                                <asp:TextBox ID="tbkeycompanynum" runat="server" MaxLength="10" CssClass="input"
                                    onblur="isNumer(this);"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                &nbsp;
                            </th>
                            <td>
                                <label>
                                    <asp:Button ID="Button5" runat="server" CssClass="button" Text="ȷ�������˱�ǩ" OnClick="Button5_Click">
                                    </asp:Button>&nbsp;
                                    <input id="Button6" class="button" type="button" value="ȡ ��" onclick="closewindows();" /></label>
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
