<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_index" CodeBehind="index.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/style.css" type="text/css" rel="stylesheet" />
    <script language="javascript" type="text/javascript" src="/common/js/base.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <h1 runat="server" id="headTip" class="headTip">
    </h1>
    <table width="100%">
        <tr>
            <td class="right">
                <div class="main-setting">
                    <div class="itemtitle">
                        <h3>
                            快捷操作</h3>
                    </div>
                    <table width="99%" class="xy_tb xy_tb2 infotable border_buttom0">
                        <tr>
                            <th>
                                编辑用户：
                            </th>
                            <td>
                                <asp:TextBox ID="lbusrname" runat="server" Width="220px" MaxLength="15"></asp:TextBox>
                            </td>
                            <td width="15%">
                                <asp:Button ID="Button1" runat="server" Text="提交" CssClass="button" OnClick="Button1_Click" />
                            </td>
                        </tr>                        
                        <tr>
                            <th>
                                生成模板：
                            </th>
                            <td>
                                <asp:DropDownList ID="ddmodulelist" runat="server" Width="149px">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="Button3" runat="server" Text="提交" CssClass="button" OnClick="Button3_Click" />
                            </td>
                        </tr>
                        <tr>
                            <th>
                                权限设置：
                            </th>
                            <td>
                                <asp:DropDownList ID="ddlpogroem" runat="server" Width="149px">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="Button4" runat="server" Text="提交" CssClass="button" OnClick="Button4_Click" />
                            </td>
                        </tr>
                        <tr>
                            <th>
                                商业信息：
                            </th>
                            <td>
                                <asp:DropDownList ID="ddlbusiness" runat="server" Width="149px">
                                    <asp:ListItem Value="1">供求信息 </asp:ListItem>
                                    <asp:ListItem Value="2">加工信息 </asp:ListItem>
                                    <asp:ListItem Value="3">招商代理信息 </asp:ListItem>
                                    <asp:ListItem Value="4">服务信息 </asp:ListItem>
                                    <asp:ListItem Value="5">展会信息 </asp:ListItem>
                                    <asp:ListItem Value="6">品牌管理 </asp:ListItem>
                                    <asp:ListItem Value="7">招聘管理 </asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="提交" CssClass="button" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <div class="itemtitle">
                        <h3>
                            官方消息</h3>
                    </div>
                    <table width="99%" class="xy_tb xy_tb2 infotable border_buttom0">
                        <tr>
                            <td runat="server" id="tdIframe">
                            </td>
                        </tr>
                    </table>
                    <br />
                    <div class="itemtitle">
                        <h3>
                            联系我们</h3>
                    </div>
                    <table width="99%" class="xy_tb xy_tb2 infotable border_buttom0">
                        <tr>
                            <td width="15%">
                                公司名称：
                            </td>
                            <td width="35%">
                                纵横易商（北京）软件有限公司
                            </td>
                            <td width="15%">
                                项目订制开发：
                            </td>
                            <td width="35%">
                                QQ:9393581 电话:010-62669815
                            </td>
                        </tr>
                        <tr>
                            <td>
                                产品咨询：
                            </td>
                            <td>
                                QQ:843990692 QQ:327126406
                            </td>
                            <td>
                                模板制作咨询：
                            </td>
                            <td>
                                QQ:810194562
                            </td>
                        </tr>
                        <tr>
                            <td>
                                财务合同：
                            </td>
                            <td>
                                010-86818791
                            </td>
                            <td>
                                客服电话：
                            </td>
                            <td>
                                010-62669815 010-86818791
                            </td>
                        </tr>
                        <tr>
                            <td>
                                官方网站：
                            </td>
                            <td>
                                <a href="http://www.xyecom.com/" target="_blank">www.xyecom.com</a>
                            </td>
                            <td>
                                帮助中心：
                            </td>
                            <td>
                                <a href="http://help.xyecom.com/" target="_blank">help.xyecom.com</a>&nbsp;&nbsp;论坛：<a
                                    href="http://bbs.xyecom.com/" target="_blank">bbs.xyecom.com</a>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <br />
    <br />
    </form>
</body>
</html>
