<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RankingUserDetailed.aspx.cs"
    Inherits="XYECOM.Web.xymanage.Ranking.RankingUserDetailed" %>

<%@ Register Src="../UserControl/UploadImage.ascx" TagName="UploadImage" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>专题信息</title>
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <link href="../css/style.css" type="text/css" rel="stylesheet" />

    <script language="javascript" type="text/javascript" src="/common/js/base.js"></script>

    <script language="javascript" type="text/javascript" src="/common/js/UploadControl.js"></script>

    <script type="text/javascript" src="../javascript/Topic.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <a href="../index.aspx">后台管理首页</a> >>用户自定义详细信息</h1>
    <table width="100%">
        <tr>
            <td class="right">
                <div class="main-setting">
                    <table class="xy_tb xy_tb2">
                        <tr class="nobg">
                            <td class="td27">
                                信息标题：
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform">
                                <asp:TextBox ID="txtTitle" runat="server" CssClass="input" MaxLength="30" Columns="32"
                                    Width="300px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
                                    ErrorMessage="信息标题不能为空"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr class="nobg">
                            <td class="td27" style="height: 27px">
                                链接地址：
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform">
                                <asp:TextBox ID="txtUrl" runat="server" CssClass="input" MaxLength="30" Columns="32"
                                    Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr class="nobg">
                            <td class="td27">
                                详细内容：
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform">
                                <asp:TextBox ID="txtDesc" Height="60" runat="server" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr class="nobg">
                            <td class="td27">
                                图片链接地址：
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform" style="width: 306px">
                                <asp:TextBox ID="txtImageUrl" runat="server" CssClass="input" MaxLength="30" Columns="32"
                                    Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr class="nobg">
                            <td class="td27">
                                图片预览：
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform" style="width: 306px; height: 24px;">
                                <uc1:UploadImage ID="UploadFile1" runat="server" InfoID="0" Iswatermark="false" MaxAmount="1"
                                    TableName="xy_rankingUserInfo" />
                            </td>
                        </tr>
                        <tr>
                            <td class="content_action" style="height: 30px">
                                <asp:Button ID="btnok" runat="server" CssClass="button" Text="确定" OnClick="btnok_Click">
                                </asp:Button>&nbsp;<asp:Button ID="btnCancel" CssClass="button" runat="server" OnClick="btnCancel_Click"
                                    Text="返回" CausesValidation="false" />&nbsp;
                                <asp:Label ID="lblMessge" runat="server" ForeColor="Red"></asp:Label>
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
