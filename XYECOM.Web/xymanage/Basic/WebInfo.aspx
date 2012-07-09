<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_basic_WebInfo" CodeBehind="WebInfo.aspx.cs" %>

<%@ Register Src="../UserControl/UploadFile.ascx" TagName="UploadFile" TagPrefix="uc2" %>
<%@ Register Src="../UserControl/top.ascx" TagName="top" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>网站信息设置</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <script language="javascript" type="text/javascript" src="/common/js/base.js"></script>
    <script language="javascript" type="text/javascript" src="/common/js/UploadControl.js"></script>
    <script language="Javascript" type="text/javascript" src="../javascript/WebSet.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <a href="../index.aspx">后台管理首页</a> >> 系统基本配置</h1>
    <table width="100%">
        <tr>
            <td class="right">
                <div class="main-setting">
                    <div class="itemtitle">
                        <h3>
                            系统基本配置</h3>
                        <ul class="tab1">
                            <li class="current"><a href="WebInfo.aspx"><span>基本配置</span></a></li>
                            <li><a href="Function.aspx"><span>功能配置</span></a></li>
                            <li><a href="BussinessInfoSet.aspx"><span>商业信息相关</span></a></li>
                            <li><a href="UserInfoSet.aspx"><span>用户相关</span></a></li>
                            <li><a href="ShopSet.aspx"><span>网店相关</span></a></li>
                            <li><a href="Server.aspx"><span>附件服务器</span></a></li>
                            <li><a href="EMailBoxInfoSet.aspx"><span>网站邮箱</span></a></li>
                            <li><a href="SEO.aspx"><span>SEO设置</span></a></li>
                            <li><a href="SecuritySet.aspx"><span>安全设置</span></a></li>
                        </ul>
                    </div>
                    <table class="xy_tb xy_tb2">
                        <tr>
                            <th colspan="15" class="partition">
                                技巧提示
                            </th>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr class="nobg">
                            <td colspan="2" class="tipsblock">
                                <ul id="tipslis">
                                    <li>网站域名必须以/结尾</li>
                                    <li>伪后缀和静态页面后缀不能相同</li>
                                </ul>
                            </td>
                        </tr>
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                网站名称:
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform">
                                <asp:TextBox ID="tbwebname" runat="server" CssClass="txt" MaxLength="24"></asp:TextBox>
                            </td>
                            <td class="vtop tips2">
                                此处填写您的网站名称，如“纵横商务网”。
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="td27">
                                网站URL:
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform">
                                <asp:TextBox ID="tbweburl" runat="server" CssClass="txt" MaxLength="40"></asp:TextBox>
                            </td>
                            <td class="vtop tips2">
                                以/结束，请填写网站完整URL地址，如http://www.xyecom.com/。
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="td27">
                                网站Logo:
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform">
                                <asp:TextBox ID="txtWebLogo" runat="server" CssClass="txt" MaxLength="100"></asp:TextBox>
                            </td>
                            <td class="vtop tips2">
                                请填写网站完整Logo地址，如http://www.xyecom.com/logo.gif。
                            </td>
                        </tr>
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                伪后缀名:
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform">
                                <asp:TextBox ID="tbwebsuffix" runat="server" CssClass="txt" MaxLength="5"></asp:TextBox>
                            </td>
                            <td class="vtop tips2">
                                请填写伪后缀名，不要超过5个字符，关于伪后缀及其设置方法，请查询<a href="#" target="_blank">帮助文档</a>。
                            </td>
                        </tr>
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                静态页面后缀:
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform">
                                <asp:DropDownList runat="server" ID="ddlstaticpagesuffix" CssClass="input">
                                    <asp:ListItem Value="html">html</asp:ListItem>
                                    <asp:ListItem Value="htm">htm</asp:ListItem>
                                    <asp:ListItem Value="shtml">shtml</asp:ListItem>
                                    <asp:ListItem Value="shtm">shtm</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="vtop tips2">
                                选择生成静态页面的后缀名。注：不能与伪后缀相同。
                            </td>
                        </tr>
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                是否启用伪静态:
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform">
                                <asp:RadioButtonList ID="rbbogusstatic" runat="server" RepeatDirection="Horizontal"
                                    RepeatLayout="Flow">
                                    <asp:ListItem CssClass="radio" Value="true">启用</asp:ListItem>
                                    <asp:ListItem Value="false">不启用</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td class="vtop tips2">
                                选择启用伪静态，可以展示友好的URL地址，推荐选择启用。
                            </td>
                        </tr>
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                二级域名开启项：
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop" colspan="2">
                                <asp:CheckBox ID="rbdomain" runat="server" Text="网店" />
                                <asp:CheckBox ID="rbnewsdomain" runat="server" Text="资讯栏目" />
                                <asp:CheckBox ID="rdoTradeDomain" runat="server" Text="行业频道" />
                                <asp:CheckBox ID="rdoAreaDomain" runat="server" Text="地区频道" />&nbsp;
                                <asp:CheckBox ID="rdoTopicDomain" runat="server" Text="专题" />
                                <asp:CheckBox ID="rdoProtypeDomain" runat="server" Text="产品分类" />
                            </td>
                        </tr>
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                Cookie 域:
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform">
                                <asp:TextBox ID="CookieDomain" runat="server" MaxLength="50" CssClass="txt"></asp:TextBox>
                            </td>
                            <td class="vtop tips2">
                                Cookie 数据的有效范围。选择启用网店二级域名后，必须正确设置此项。
                            </td>
                        </tr>
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                虚拟货币名称：
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform">
                                <asp:TextBox ID="webmoney" runat="server" MaxLength="10" CssClass="txt"></asp:TextBox>
                            </td>
                            <td class="vtop tips2">
                                可以结合网站给虚拟货币取一个名字。如“QQ币”、“纵横通宝”
                            </td>
                        </tr>
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                网站状态:
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform">
                                <asp:RadioButton ID="rdoSiteStateOpen" runat="server" GroupName="SiteState" Text="打开"
                                    Checked="true" />
                                <asp:RadioButton ID="rdoSiteStateClose" runat="server" GroupName="SiteState" Text="关闭"
                                    CssClass="input" />
                            </td>
                            <td class="vtop tips2">
                                如果网站需要暂停，可以选择暂时关闭。
                            </td>
                        </tr>
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                网站关闭的原因:
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform">
                                <asp:TextBox runat="server" ID="txtSiteCloseTips" TextMode="MultiLine" Rows="4" Columns="100"></asp:TextBox>
                            </td>
                            <td class="vtop tips2">
                                这里填写网站关闭的原因，用户访问前台页面的时候会显示这里的内容。
                            </td>
                        </tr>
                    </table>
                    <div style="padding: 5px 0px 15px 0px;">
                        <asp:Button ID="btnok" runat="server" CssClass="button" Text="保存设置" OnClick="btnok_Click" /></div>
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
