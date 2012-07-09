<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_LabelManage_ShowSet"
    CodeBehind="ShowSet.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>չ����Ϣ��ǩ����</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="../css/cue.css" type="text/css" rel="stylesheet" />
    <link href="/Common/css/XYLib.css" media="screen" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="/Common/js/base.js" language="javascript"></script>

    <script type="text/javascript" src="../javascript/TreeType.js"></script>

    <script type="text/javascript" src="../javascript/CheckedAll.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <table width="100%">
        <tr>
            <td class="right">
                <div class="main-setting">
                    <div class="labeldatatitle">
                        <ul id="labelTable">
                            <li id="li_base" class="current" onclick="infoshow(1,this);"><a href="javascript:;">
                                <span>�����б�</span></a></li>
                            <li id="li_page" onclick="infoshow(2,this);"><a href="javascript:;"><span>��ҳ�б�</span></a></li>
                        </ul>
                    </div>
                    <!--�����б����� -->
                    <table width="100%" class="xy_tb xy_tb2 setLabelData" id="base">
                        <tr>
                            <th>
                                չ����ࣺ
                            </th>
                            <td>
                                <div id="classType">
                                </div>
                                <input id="hidptid" runat="server" type="hidden" value="" />
                                <input id="hidweburl" runat="server" type="hidden" />
                                <input id="selectflag" type="hidden" value="5" />
                                <input id="hidsuffix" runat="server" type="hidden" />
                                <input id="hidPT_ID" type="hidden" />
                            </td>
                        </tr>

                        <script type="text/javascript">
var cla = new ClassType("cla",'exhibition','classType','hidptid');
cla.Mode = "select";
cla.Init();
                        </script>

                        <tr>
                            <th width="23%">
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
                                ��Ϣ������ʾ������
                            </th>
                            <td>
                                <asp:TextBox ID="tbinfonum" runat="server" CssClass="input" MaxLength="10" onblur="isNumer(this);"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                �����ֶΣ�
                            </th>
                            <td>
                                <asp:DropDownList ID="ddlOrderColumuName" runat="server" CssClass="input1">
                                    <asp:ListItem Value="BeginTime">չ�Ὺʼʱ��</asp:ListItem>
                                    <asp:ListItem Value="Id">��Ϣ����ʱ��</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlOrderType" runat="server" CssClass="input1">
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
                                չ�����ͣ�
                            </th>
                            <td>
                                <asp:DropDownList ID="ddlShowType" runat="server">
                                    <asp:ListItem Value="����">����</asp:ListItem>
                                    <asp:ListItem Value="����չ">����չ</asp:ListItem>
                                    <asp:ListItem Value="����չ">����չ</asp:ListItem>
                                </asp:DropDownList>
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
                            <th style="height: 30px">
                                &nbsp;
                            </th>
                            <td class="content_action" style="height: 30px">
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
                            <th width="23%">
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
                                <asp:DropDownList ID="ddlPageOrderColumnName" runat="server" CssClass="input1">
                                    <asp:ListItem Value="BeginTime">չ�Ὺʼʱ��</asp:ListItem>
                                    <asp:ListItem Value="Id">��Ϣ����ʱ��</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlPageOrderType" runat="server" CssClass="input1">
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
                            <th style="height: 30px">
                                &nbsp;
                            </th>
                            <td class="content_action" style="height: 30px">
                                <label>
                                    <asp:Button ID="Button3" runat="server" CssClass="button" Text="ȷ�������˱�ǩ" OnClick="Button3_Click">
                                    </asp:Button>&nbsp;
                                    <input id="Button4" class="button" type="button" value="ȡ ��" onclick="closewindows();" /></label>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <div id="key" style="display: none">
    </div>
    </form>
</body>
</html>
