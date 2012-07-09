<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StatSendInfo.aspx.cs" Inherits="XYECOM.Web.xymanage.Global.StatSendInfo" %>

<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head2" runat="server">
    <title>统计资讯</title>
    <link href="../css/style.css" type="text/css" rel="Stylesheet" />
    <link href="/common/css/XYLib.css" type="text/css" rel="Stylesheet" />
    <link href="../css/cue.css" type="text/css" rel="stylesheet" />
    <script language="javascript" type="text/javascript" src="/common/js/base.js"></script>
    <script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
    <script language="javascript" type="text/javascript" src="../javascript/list.js"></script>
    <script language="javascript" type="text/javascript" src="/common/js/UploadControl.js"></script>
    <script language="javascript" type="text/javascript" src="../javascript/GetKeyWord.js"></script>
    <script language="javascript" type="text/javascript" src="/common/js/date.js"></script>
    <script language="javascript" type="text/javascript" src="../javascript/AddNews.js"></script>
    <script type="text/javascript" src="/common/js/date.js">        function DIV1_onclick() {

        }

    </script>
</head>
<body>
    <form id="form2" runat="server" action="{config.WebURL}StatSendInfo.{config.Suffix}">
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
                            <li class="current"><a href="StatSendInfo.aspx"><span>投稿资讯</span></a></li>
                            <li><a href="PageRecord.aspx"><span>页面访问</span></a></li>
                        </ul>
                    </div>
                    <table class="xy_tb xy_tb2" style="margin-top: 0px;">
                        <tr>
                            <td align="center">
                                <table class="partition">
                                    <tr>
                                        <th align="right">
                                            信息所属栏目：
                                        </th>
                                        <td align="left">
                                            <input id="hidTypeId" name="hidTypeId" runat="server" type="hidden" />
                                            <input type="hidden" id="hidMoueleName" runat="server" />
                                            <div id="classType">
                                            </div>
                                            <script type="text/javascript">
                                                var cla = new ClassType("cla", 'news', 'classType', 'hidTypeId', null, null, "contribut:0|hidden:0");
                                                cla.Mode = "select";
                                                cla.Init();
                                            </script>
                                        </td>
                                        <%--            <th align="right">
                </th>
            <td align="left">
                <asp:DropDownList ID="ddcolumn" runat="server" CssClass="dropdownlist" Width="100px">
                </asp:DropDownList></td>--%>
                                        <td align="right">
                                            地区信息：
                                        </td>
                                        <td align="left">
                                            <div id="divPArea">
                                            </div>
                                            <input type="hidden" id="areaId" runat="server" name="areaId" />
                                            <script type="text/javascript">
                                                var cla2 = new ClassType("cla2", 'area', 'divPArea', 'areaId');
                                                cla2.Mode = "select";
                                                cla2.Init();
                                            </script>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th align="right">
                                            行业：
                                        </th>
                                        <td align="left">
                                            <div id="classTypecompany">
                                            </div>
                                            <input type="hidden" id="typeid" runat="server" name="typeid" />
                                            <script type="text/javascript">
                                                var clacompany = new ClassType("clacompany", 'company', 'classTypecompany', 'typeid');
                                                clacompany.Mode = "select";
                                                clacompany.Init();
                                            </script>
                                        </td>
                                        <td align="right">
                                            审核状态：
                                        </td>
                                        <td align="left">
                                            <asp:RadioButtonList ID="ddlState" runat="server" Height="9px" RepeatDirection="Horizontal"
                                                Width="240px">
                                                <asp:ListItem Selected="True" Value="-1">所有</asp:ListItem>
                                                <asp:ListItem Value="1">通过审核</asp:ListItem>
                                                <asp:ListItem Value="0">未通过审核</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th align="right">
                                            日期：
                                        </th>
                                        <td align="left">
                                            <input id="bgdate" runat="server" maxlength="10" onclick="getDateString(this);" readonly="readonly"
                                                style="width: 90px" type="text" />
                                            到
                                            <input id="egdate" runat="server" maxlength="10" onclick="getDateString(this);" readonly="readonly"
                                                style="width: 90px" type="text" />
                                        </td>
                                        <td align="right">
                                        </td>
                                        <td align="left">
                                        </td>
                                    </tr>
                                    <tr>
                                        <th align="right">
                                        </th>
                                        <td align="left">
                                            <asp:Button ID="btnSearch" runat="server" CssClass="button" Text="查询" OnClick="btnSearch_Click" />
                                        </td>
                                        <td align="right">
                                        </td>
                                        <td align="left">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <table class="xy_tb xy_tb2 infotable border_buttom0" width="100%">
                                                <tr>
                                                    <td style="height: 20px">
                                                        <br />
                                                        <h1>
                                                            <label id="lblExecSqlResult" runat="server">
                                                            </label>
                                                        </h1>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
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
