<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeamBuySet.aspx.cs" Inherits="XYECOM.Web.xymanage.LabelManage.TeamBuySet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>展会信息标签设置</title>
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
                                <span>基本列表</span></a></li>
                            <li id="li_page" onclick="infoshow(2,this);"><a href="javascript:;"><span>分页列表</span></a></li>
                        </ul>
                    </div>
                    <!--基本列表设置 -->
                    <table width="100%" class="xy_tb xy_tb2 setLabelData" id="base">
                        <tr>
                            <th width="23%">
                                调用数量：
                            </th>
                            <td>
                                <asp:TextBox ID="tbnum" runat="server" CssClass="input" MaxLength="10" onblur="isNumer(this);"
                                    Text="10"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                标题显示字数：
                            </th>
                            <td>
                                <asp:TextBox ID="tbtitlenum" runat="server" CssClass="input" MaxLength="10" onblur="isNumer(this);"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                信息描述显示字数：
                            </th>
                            <td>
                                <asp:TextBox ID="tbinfonum" runat="server" CssClass="input" MaxLength="10" onblur="isNumer(this);"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                排序字段：
                            </th>
                            <td>
                                <asp:DropDownList ID="ddlOrderColumuName" runat="server" CssClass="input1">
                                    <asp:ListItem Value="StartDate">团购开始时间</asp:ListItem>
                                    <asp:ListItem Value="EndDate">团购结束时间</asp:ListItem>
                                    <asp:ListItem Value="Id">信息发布时间</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlOrderType" runat="server" CssClass="input1">
                                    <asp:ListItem Value="DESC">降序</asp:ListItem>
                                    <asp:ListItem Value="ASC">升序</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                日期格式：
                            </th>
                            <td>
                                <asp:DropDownList ID="ddldatetype" runat="server">
                                    <asp:ListItem Value="">请选择</asp:ListItem>
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
                                是否是平台团购：
                            </th>
                            <td>
                                <asp:DropDownList ID="ddlIsPlat" runat="server">
                                    <asp:ListItem Value="">所有</asp:ListItem>
                                    <asp:ListItem Value="1">是</asp:ListItem>
                                    <asp:ListItem Value="0">否</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr id="platcommend">
                            <th>
                                是否推荐：
                            </th>
                            <td>
                                <asp:DropDownList ID="ddlCommend" runat="server">
                                    <asp:ListItem Value="">所有</asp:ListItem>
                                    <asp:ListItem Value="0">不推荐</asp:ListItem>
                                    <asp:ListItem Value="1">推荐</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr id="usercommend">
                            <th>
                                是否用户推荐：
                            </th>
                            <td>
                                <asp:DropDownList ID="ddlUserCommend" runat="server">
                                    <asp:ListItem Value="">所有</asp:ListItem>
                                    <asp:ListItem Value="0">不推荐</asp:ListItem>
                                    <asp:ListItem Value="1">推荐</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th style="height: 30px">
                                &nbsp;
                            </th>
                            <td class="content_action" style="height: 30px">
                                <label>
                                    <asp:Button ID="Button1" runat="server" CssClass="button" Text="确定创建此标签" OnClick="Button1_Click">
                                    </asp:Button>&nbsp;
                                    <input id="Button2" class="button" type="button" value="取 消" onclick="closewindows();" /></label>
                            </td>
                        </tr>
                    </table>
                    <!--分页列表设置 -->
                    <table width="100%" class="xy_tb xy_tb2 setLabelData" id="page" style="display: none">
                        <tr>
                            <th width="23%">
                                每页调用数量：
                            </th>
                            <td>
                                <asp:TextBox ID="tbpagenum" runat="server" CssClass="input" MaxLength="10" onblur="isNumer(this);"
                                    Text="20"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                标题显示字数：
                            </th>
                            <td>
                                <asp:TextBox ID="tbpagetitlenum" runat="server" CssClass="input" MaxLength="10" onblur="isNumer(this);"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                排序字段：
                            </th>
                            <td>
                                <asp:DropDownList ID="ddlPageOrderColumnName" runat="server" CssClass="input1">
                                    <asp:ListItem Value="StartDate">团购开始时间</asp:ListItem>
                                    <asp:ListItem Value="EndDate">团购结束时间</asp:ListItem>
                                    <asp:ListItem Value="Id">信息发布时间</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlPageOrderType" runat="server" CssClass="input1">
                                    <asp:ListItem Value="DESC">降序</asp:ListItem>
                                    <asp:ListItem Value="ASC">升序</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                是否是平台团购：
                            </th>
                            <td>
                                <asp:DropDownList ID="ddlIsPlat1" runat="server">
                                    <asp:ListItem Value="">所有</asp:ListItem>
                                    <asp:ListItem Value="1">是</asp:ListItem>
                                    <asp:ListItem Value="0">否</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                日期格式：
                            </th>
                            <td>
                                <asp:DropDownList ID="ddlpagedatetype" runat="server">
                                    <asp:ListItem Value="">请选择</asp:ListItem>
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
                                信息描述显示字数：
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
                                    <asp:Button ID="Button3" runat="server" CssClass="button" Text="确定创建此标签" OnClick="Button3_Click">
                                    </asp:Button>&nbsp;
                                    <input id="Button4" class="button" type="button" value="取 消" onclick="closewindows();" /></label>
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
