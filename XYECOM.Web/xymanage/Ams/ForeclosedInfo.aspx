<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForeclosedInfo.aspx.cs"
    Inherits="XYECOM.Web.xymanage.Foreclosed.ForeclosedInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>【供应】<%=title%>——详细信息</title>
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <script language="javascript" type="text/javascript" src="/common/js/base.js"></script>
    <script language="javascript" type="text/javascript" src="/config/js/config.js"></script>
    <script language="javascript" type="text/javascript" src="/common/js/date.js"></script>
    <script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
    <script language="javascript" type="text/javascript" src="/common/js/UploadControl.js"></script>
    <script language="javascript" type="text/javascript">
        function GetTable(num) {
            if (num == "1") {
                document.getElementById("InfoShow").style.display = 'block';
                document.getElementById("auditing").style.display = 'none';
            }
            if (num == "2") {
                document.getElementById("InfoShow").style.display = 'none';
                document.getElementById("auditing").style.display = 'block';
            }
        }
    </script>
</head>
<body onload="GetTable(1);">
    <form id="form1" runat="server">
    <h1>
        <a href="../index.aspx">后台管理首页</a> >> 供应详细信息</h1>
    <table width="100%">
        <tr>
            <td class="right">
                <div class="main-setting">
                    <div class="itemtitle">
                        <h3>
                            供应详细信息</h3>
                    </div>
                    <table width="100%" class="xy_tb xy_tb2 infotable" id="InfoShow">
                        <tr>
                            <th>
                                信息名称：
                            </th>
                            <td>
                                <asp:TextBox ID="txtTitle" runat="server" Width="349px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                信息摘要：
                            </th>
                            <td>
                                <asp:TextBox ID="txtSummary" TextMode="MultiLine" runat="server" Width="349px" Height="68px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                详细说明：
                            </th>
                            <td>
                                <FCKeditorV2:FCKeditor ID="txtContent" runat="server" BasePath="/Common/fckeditor/"
                                    ToolbarSet="News" Height="300px">
                                </FCKeditorV2:FCKeditor>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                上传图片：
                            </th>
                            <td>
                                <XYECOM:UploadImage ID="supplyImages" runat="server" Iswatermark="false" MaxAmount="3"
                                    TableName="i_supply" IsCreateThumbnailImg="true" />
                            </td>
                        </tr>
                        <tr>
                            <th>
                                信息有效期：
                            </th>
                            <td>
                                <asp:TextBox ID="txtEndTime" runat="server"></asp:TextBox>
                                <asp:RadioButtonList ID="rblUseFulDate" runat="server" RepeatDirection="Horizontal"
                                    RepeatLayout="Flow">
                                    <asp:ListItem Value="10">10天</asp:ListItem>
                                    <asp:ListItem Value="20">20天</asp:ListItem>
                                    <asp:ListItem Value="30">1个月</asp:ListItem>
                                    <asp:ListItem Value="90">3个月</asp:ListItem>
                                    <asp:ListItem Value="180">6个月</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:CheckBox ID="cbIsUpdateEndTime" runat="server" Text="延长有效期" />
                            </td>
                        </tr>
                        <tr>
                            <th>
                                市场价：
                            </th>
                            <td>
                                <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                库存量：
                            </th>
                            <td>
                                <asp:TextBox ID="txtCountNum" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                公司名称：
                            </th>
                            <td>
                                <asp:HyperLink ID="linkCompany" runat="server"></asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                联系电话：
                            </th>
                            <td>
                                <asp:Label ID="lbUI_Telephone" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                企业传真：
                            </th>
                            <td>
                                <asp:Label ID="lbUI_Fax" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                手机：
                            </th>
                            <td>
                                <asp:Label ID="lbUI_Mobil" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                状态：
                            </th>
                            <td style="vertical-align: middle;">
                                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                &nbsp;
                            </th>
                            <td class="content_action">
                                <label>
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="button" OnClick="btnUpdate_Click"
                                        Text="保存修改" />
                                    <asp:Button ID="btnPass" runat="server" CssClass="button" Text="通过审核" OnClick="btnPass_Click" />
                                    <asp:Button ID="btnNoPass" runat="server" CssClass="button" Text="不通过审核" OnClick="btnNoPass_Click" />
                                    <input class="button" onclick="javascript:return GetTable(2);" type="button" value="不通过审核并告知用户修改建议"
                                        name="Submit2" id="Button2" />
                                    <asp:Button ID="Button3" runat="server" Text="返回" CssClass="button" OnClick="Button3_Click" />&nbsp;&nbsp;
                                    <input id="Email" runat="server" type="hidden" />
                                    <input id="A_ID" runat="server" type="hidden" />
                                    <input id="U_ID" runat="server" type="hidden" /></label>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" class="xy_tb xy_tb2 infotable" id="auditing" style="display: none;">
                        <tr>
                            <td>
                                <table width="100%">
                                    <tr>
                                        <th>
                                            错误类型：
                                        </th>
                                        <td>
                                            <asp:RadioButton ID="rbnoerror" runat="server" Text="无" GroupName="errorgroup" Checked="True" />&nbsp;<asp:RadioButton
                                                runat="server" ID="rbcommonerror" GroupName="errorgroup" Text="普通错误" />&nbsp;<asp:RadioButton
                                                    runat="server" Text="恶意错误" ID="rbgravenesserror" GroupName="errorgroup" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            未通过原因：
                                        </th>
                                        <td>
                                            <asp:TextBox ID="tbA_Reason" runat="server" TextMode="MultiLine" Rows="6" Width="515px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            推荐意见：
                                        </th>
                                        <td>
                                            <asp:TextBox ID="tbA_Advice" runat="server" TextMode="MultiLine" Rows="6" Width="515px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            &nbsp;
                                        </th>
                                        <td class="content_action">
                                            <asp:Button ID="Button1" runat="server" Text="确定" CausesValidation="False" CssClass="button"
                                                OnClick="Button1_Click"></asp:Button>
                                            <input type="button" value="取消" onclick="javascript:return GetTable(1);" class="button"
                                                id="Button4" />
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
