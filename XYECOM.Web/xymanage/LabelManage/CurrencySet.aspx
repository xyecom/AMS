<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_LabelManage_currucyset"
    CodeBehind="currencyset.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ͨ�ñ�ǩ����</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />

    <script language="javascript" type="text/javascript" src="/common/js/base.js"></script>

    <script type="text/javascript" src="../javascript/CheckedAll.js"></script>

    <script type="text/javascript" src="../javascript/TreeType.js"></script>

    <script type="text/javascript" src="../javascript/usertype.js"></script>

    <link href="/Common/css/XYLib.css" media="screen" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript">
    function moduleChanged_hotkeyword(obj){
        var moduleName = obj.options[obj.selectedIndex].value;
        
        if(moduleName =="news" 
        || moduleName =="job" 
        || moduleName =="brand" 
        || moduleName == "exhibition"
        || moduleName == "company"
        ){
            $("rdoToSellPage").disabled = true;
            $("rdoToBuyPage").disabled = true;
        }else{
            $("rdoToSellPage").disabled = false;
            $("rdoToBuyPage").disabled = false;
        }
    }
    </script>

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
                                <span>���Źؼ���</span></a></li>
                            <li id="li_page" onclick="infoshow(2,this);parent.setChildNum(13);"><a href="javascript:;">
                                <span>��������</span></a></li>
                            <li id="li_key" onclick="infoshow(3,this);parent.setChildNum(14);"><a href="javascript:;">
                                <span>���</span></a></li>
                        </ul>
                    </div>
                    <!--��̨���� -->
                    <!--���Źؼ���-->
                    <table width="100%" class="xy_tb xy_tb2 setLabelData" id="base">
                        <tr>
                            <th style="height: 21px">
                                ����ģ�飺
                            </th>
                            <td style="height: 21px">
                                <asp:DropDownList ID="ddlModulesByHotKeywords" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                ����������
                            </th>
                            <td>
                                <asp:TextBox ID="txtNumberForKeyword" runat="server" MaxLength="4" Columns="5" onblur="isNumer(this);">10</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                �Ƿ��Ƽ���
                            </th>
                            <td>
                                <input type="radio" runat="server" id="rdoCommendAllForKeyword" checked="true" name="IsCommandForKeyword" />����
                                <input type="radio" runat="server" id="rdoCommendYesForKeyword" name="IsCommandForKeyword" />�Ƽ�
                                <input type="radio" runat="server" id="rdoCommendNoForKeyword" name="IsCommandForKeyword" />���Ƽ�
                            </td>
                        </tr>
                        <tr>
                            <th>
                                ���ӵ���
                            </th>
                            <td>
                                <input type="radio" id="rdoToSellPage" runat="server" name="ToPage" checked="true" />��Ӧ�б�
                                <input type="radio" id="rdoToBuyPage" runat="server" name="ToPage" />���б�
                            </td>
                        </tr>
                        <tr>
                            <th width="23%">
                                &nbsp;
                            </th>
                            <td class="content_action" style="height: 30px">
                                <label>
                                    <asp:Button ID="btnHotKeywordOK" runat="server" CssClass="button" Text="ȷ�������˱�ǩ"
                                        OnClick="btnHotKeywordOK_Click"></asp:Button>&nbsp;
                                    <input class="button" type="button" value="ȡ ��" onclick="closewindows();" /></label>
                            </td>
                        </tr>
                    </table>
                    <!--��������-->
                    <table width="100%" class="xy_tb xy_tb2 setLabelData" id="page" style="display: none;">
                        <tr>
                            <th>
                                ���ӷ��ࣺ
                            </th>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlLinkSort">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                �������ͣ�
                            </th>
                            <td>
                                <asp:DropDownList ID="ddlLinkType" runat="server" CssClass="input" Width="74px">
                                    <asp:ListItem Value="1">ͼƬ</asp:ListItem>
                                    <asp:ListItem Value="0">����</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                ����������
                            </th>
                            <td>
                                <asp:TextBox ID="tblinknum" runat="server" CssClass="input" MaxLength="10" onblur="isNumer(this);"
                                    Text="10"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                ������ʾ��
                            </th>
                            <td>
                                <asp:DropDownList ID="ddllinkalt" runat="server" CssClass="input">
                                    <asp:ListItem Value="1">��ʾ</asp:ListItem>
                                    <asp:ListItem Value="0">����ʾ</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                �Ƿ��Ƽ���
                            </th>
                            <td style="padding-top: 5px;">
                                <input type="radio" runat="server" id="rdoCommendAllForFriendLink" checked="true"
                                    name="IsCommandForFriendLink" />����
                                <input type="radio" runat="server" id="rdoCommendYesForFriendLink" name="IsCommandForFriendLink" />�Ƽ�
                                <input type="radio" runat="server" id="rdoCommendNoForFriendLink" name="IsCommandForFriendLink" />���Ƽ�
                            </td>
                        </tr>
                        <tr>
                            <th width="23%">
                                &nbsp;
                            </th>
                            <td class="content_action" style="height: 30px">
                                <label>
                                    <asp:Button ID="btnfriendlink" runat="server" CssClass="button" Text="ȷ�������˱�ǩ" OnClick="btnfriendlink_Click">
                                    </asp:Button>&nbsp;
                                    <input class="button" type="button" value="ȡ ��" onclick="closewindows();" /></label>
                            </td>
                        </tr>
                    </table>
                    <!--���-->
                    <table width="100%" class="xy_tb xy_tb2 setLabelData" id="key" style="display: none;">
                        <tr>
                            <th>
                                ���λ��
                            </th>
                            <td>
                                <asp:DropDownList ID="ddladvertising" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                ����������
                            </th>
                            <td>
                                <asp:TextBox ID="tbadnum" runat="server" MaxLength="10" onblur="isNumer(this);" Text="10"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th width="23%">
                                &nbsp;
                            </th>
                            <td class="content_action" style="height: 30px">
                                <label>
                                    <asp:Button ID="btnguanggao" runat="server" CssClass="button" Text="ȷ�������˱�ǩ" OnClick="btnguanggao_Click">
                                    </asp:Button>&nbsp;
                                    <input class="button" type="button" value="ȡ ��" onclick="closewindows();" /></label>
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
