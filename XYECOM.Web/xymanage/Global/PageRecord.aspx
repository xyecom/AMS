<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageRecord.aspx.cs" Inherits="XYECOM.Web.xymanage.Global.PageRecord" %>

<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head2" runat="server">
    <title>统计资讯</title>
    <link href="../css/style.css" type="text/css" rel="Stylesheet" />
    <link href="/common/css/XYLib.css" type="text/css" rel="Stylesheet" />
    <script language="javascript" type="text/javascript" src="/common/js/base.js"></script>
    <script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
    <script language="javascript" type="text/javascript" src="../javascript/list.js"></script>
    <script type="text/javascript" src="/common/js/date.js">        function DIV1_onclick() {

        }

    </script>
</head>
<body>
    <form id="form2" runat="server">
    <h1>
        <a href="../index.aspx">后台管理首页</a> >> 数据统计</h1>
    <table width="100%">
        <tr>
            <td class="right">
                <div class="main-setting">
                    <div class="itemtitle">
                        <h3>
                            数据统计</h3>
                        <ul class="tab1">
                            <li><a href="StatisticsNew.aspx"><span>常规资讯</span></a></li>
                            <li><a href="StatSendInfo.aspx"><span>投稿资讯</span></a></li>
                            <li class="current"><a href="PageRecord.aspx"><span>页面访问</span></a></li>
                        </ul>
                    </div>
                    <table class="xy_tb xy_tb2" style="margin-top: 0px;">
                        <tr>
                            <td align="center">
                                <table class="partition">
                                    <tr>
                                        <th style="width: 129px;" align="right">
                                            访问页面所属类型：
                                        </th>
                                        <td style="width: 244px" align="left">
                                            <asp:DropDownList ID="DllFlag" runat="server" CssClass="dropdownlist" Width="100px">
                                                <asp:ListItem Value="-1">请选择</asp:ListItem>
                                                <asp:ListItem Value="0">网站页</asp:ListItem>
                                                <asp:ListItem Value="1">产品信息页</asp:ListItem>
                                                <asp:ListItem Value="2">融资信息页</asp:ListItem>
                                                <asp:ListItem Value="3">资讯信息页</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right" style="width: 99px; height: 24px">
                                            访问日期：
                                        </td>
                                        <td style="width: 452px; height: 24px" align="left">
                                            <input id="begindate" runat="server" maxlength="10" onclick="getDateString(this);"
                                                readonly="readonly" style="width: 90px" type="text" />
                                            到
                                            <input id="enddate" runat="server" maxlength="10" onclick="getDateString(this);"
                                                readonly="readonly" style="width: 90px" type="text" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th align="right" style="width: 129px; height: 24px">
                                            被访问用户(输入用户名或E-Mail)：
                                        </th>
                                        <td align="left" style="width: 244px">
                                           <asp:TextBox runat="server" ID="txtuserName"></asp:TextBox>
                                        </td>
                                        <td align="right" style="width: 99px; height: 24px">
                                        
                                        </td>
                                        <td align="left" style="width: 452px; height: 24px">
                                            <asp:Button ID="Button1" runat="server" CssClass="button" Text="查询" OnClick="btnSearch_Click" />
                                        <asp:Button ID="Blank" runat="server" CssClass="button" Text="重置" OnClick="btnBlank_Click" />
                                        </td>
                                    </tr>
                                   
                                    <tr>
                                        <td colspan="4">
                                            <asp:GridView ID="gvlist" HeaderStyle-CssClass="gv_header_style" runat="server" Width="100%"
                                                AutoGenerateColumns="False" PageSize="20" GridLines="None" ShowFooter="True">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="用户名">
                                                        <ItemTemplate>
                                                            <%#GetUserName(Eval("UserId").ToString()) %>
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="gvLeft" />
                                                        <ItemStyle Width="20%" CssClass="gvLeft" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="公司名称">
                                                        <ItemTemplate>
                                                            <%#GetCorpName(Eval("UserId").ToString()) %>
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="gvLeft" />
                                                        <ItemStyle Width="30%" CssClass="gvLeft" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="访问次数">
                                                        <ItemTemplate>
                                                           共被访问<b style="color:Red"><%# Eval("Num").ToString()%></b>次
                                                           <br/>
                                                           网店共被访问<b style="color:Red"><b><%# GetShopFlagNum(Eval("UserId").ToString())%></b>次
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="gvLeft" />
                                                        <ItemStyle Width="20%" CssClass="gvLeft" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="最后访问时间">
                                                        <ItemTemplate>
                                                             <%#GetLastDate(Eval("UserId").ToString()) %>
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="gvLeft" />
                                                        <ItemStyle Width="20%" CssClass="gvLeft" />
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="操作">
                                                        <ItemTemplate>
                                                     <a href='/xymanage/Global/PageRecordInfo.aspx?UserId=<%# Eval("UserId") %>&bgdate=<%# BegDate %>&egdate=<%# EndDate %>&username=<%# UserName %>&page=<%# PagePram %>&pageflag=<%# PageFlag %>'>
                                                    <img src="../images/look.gif" alt="查看" /></a>
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="gvLeft" />
                                                        <ItemStyle Width="20%" CssClass="gvLeft" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <HeaderStyle CssClass="gv_header_style" />
                                            </asp:GridView>
                                            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                                        </td>
                                        <uc2:page ID="Page1" runat="server" />
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <p style="text-align: center;">
                    </p>
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
