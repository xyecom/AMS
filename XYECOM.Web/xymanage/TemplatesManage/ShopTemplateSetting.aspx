<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShopTemplateSetting.aspx.cs"
    Inherits="XYECOM.Web.xymanage.TemplatesManage.ShopTemplateSetting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>新闻标签设置</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="../css/cue.css" type="text/css" rel="stylesheet" />
    <link href="/Common/css/XYLib.css" media="screen" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/Common/js/base.js" language="javascript"></script>
    <script type="text/javascript" src="../javascript/CheckedAll.js"></script>
    <script type="text/javascript" src="../javascript/TreeNewsType.js">
    </script>
    <script type="text/javascript" src="../javascript/templates.js"></script>
</head>
<body id="btnSearchUser">
    <form id="form1" runat="server">
    <table width="100%">
        <tr>
            <td class="right">
                <div class="main-setting">
                    <div class="labeldatatitle">
                        <ul id="Ul1">
                            <li class="current"><a href="javascript:;"><span>网店模板设置</span></a></li>
                        </ul>
                    </div>
                    <table width="100%" class="xy_tb xy_tb2 setLabelData" id="base">
                        <tr>
                            <td>
                                <table width="100%">
                                    <tr style="height: 25px; line-height: 25px;">
                                        <th>
                                            模板名称：
                                        </th>
                                        <td style="padding-top: 5px;">
                                            <asp:Label ID="lblTemplateName" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            模板性质：
                                        </th>
                                        <td>
                                            <asp:RadioButton ID="rdoAccessPublic" runat="server" GroupName="Access" Text="公共"
                                                OnCheckedChanged="rdoAccessPublic_CheckedChanged" AutoPostBack="True" />
                                            <asp:RadioButton ID="rdoAccessPrivate" runat="server" GroupName="Access" Text="独享"
                                                OnCheckedChanged="rdoAccessPrivate_CheckedChanged" AutoPostBack="True" />
                                        </td>
                                    </tr>
                                    <tr id="trPublic" runat="server">
                                        <th>
                                            用户级别：
                                        </th>
                                        <td>
                                            <asp:RadioButton ID="rdoAllUser" runat="server" GroupName="user" Text="所有用户"  />
                                        </td>
                                    </tr>
                                    <tr id="trPrivate" runat="server">
                                        <th>
                                            用户ID：<br />
                                            <span>多个之间用,号隔开&nbsp;&nbsp;</span>
                                        </th>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtUserIdList" MaxLength="50" Columns="43"></asp:TextBox><br />
                                            <br />
                                            <asp:Panel runat="server" ID="pnlSearchUser">
                                                <asp:TextBox runat="server" ID="txtUserName" MaxLength="40" Columns="34" onclick="if(this.value=='请输入用户名或公司名称')this.value='';">请输入用户名或公司名称</asp:TextBox>&nbsp;&nbsp;<asp:Button
                                                    runat="server" ID="btnSearch1" OnClick="btnSearch_Click" CssClass="button" Text="搜索">
                                                </asp:Button><br />
                                                <asp:ListBox ID="lstUsers" runat="server" Rows="6" Width="280px" ToolTip="双击选中用户">
                                                </asp:ListBox>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th style="height: 30px">
                                            &nbsp;
                                        </th>
                                        <td class="content_action" style="height: 30px">
                                            <asp:Button ID="btnOK" runat="server" CssClass="button" Text="确 定" OnClick="btnOK_Click">
                                            </asp:Button>&nbsp;
                                            <input id="btnClose" class="button" type="button" value="取 消" onclick="ShopAboutSettingCancel();" /><asp:Label
                                                runat="server" ID="lblMessage" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
    </form>
</body>
</html>
