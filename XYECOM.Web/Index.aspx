<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="XYECOM.Web.Index1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>抵债信息资讯</title>
    <script src="/Other/js/jquery.js" type="text/javascript"></script>
    <script src="/Common/Js/forebase.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <!--left开始-->
        <div id="left">
            <!--left4开始-->
            <div id="left4">
                <div style="background: url('../images/erji_titlebg.gif'); background-repeat: repeat-x;
                    height: auto; overflow: hidden;">
                    <div style="width: 100px; margin-left: 55px; float: left; font-size: 14px">
                        <strong>抵债物品资讯</strong></div>
                    <div style="width: 514px; float: right; text-align: center">
                        <table width="512" style="width: 480px; float: left">
                            <tr>
                                <td width="60">
                                    物品类型
                                </td>
                                <td width="92">
                                    <asp:DropDownList runat="server" ID="droTypeName" Width="135px">
                                        <asp:ListItem Value="所有" Text="----所有----"></asp:ListItem>
                                        <asp:ListItem Value="房屋" Text="房屋"></asp:ListItem>
                                        <asp:ListItem Value="汽车" Text="汽车"></asp:ListItem>
                                        <asp:ListItem Value="金条" Text="金条"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td width="39">
                                    地区
                                </td>
                                <td width="76">
                                    <div id="divarea">
                                        <input type="hidden" id="city" name="city" runat="server" />
                                    </div>
                                    <script type="text/javascript">
                                        var claarea = new ClassType("claarea", 'area', 'divarea', 'city', 1);
                                        claarea.Mode = "select";
                                        claarea.Init();
                                    </script>
                                </td>
                                <td width="92">
                                    <%--                                    <input name="搜索" type="button" value="搜索" style="background: url(../images/yes.gif);
                                        width: 80px; height: 25px; border: none; cursor: pointer; color: #FFF" />--%>
                                    <asp:Button runat="server" ID="btnSearch" OnClick="btnSearch_Click" Text="搜索" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div style="height: auto; width: 721px;">
                    <asp:DataList ID="dlForeclosed" runat="server" RepeatColumns="2" RepeatDirection="Horizontal"
                        Width="100%">
                        <HeaderTemplate>
                            <dl>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <dd>
                                <img width="96px;" src='<%# GetInfoImgHref(Eval("ForeclosedId")) %>' />
                                <p>
                                    <strong>
                                        <%#Eval("Title") %></strong><br />
                                </p>
                                <p>
                                    <font>物品底价：<%# Eval("LinePrice")%>元</font></p>
                                <p>
                                    <font>物品所在地：<%# GetAreaIdFull(Eval("AreaId"))%></font></p>
                                <p>
                                    <font>竞价结束时间：<%# GetEndDate(Eval("EndDate"))%></font></p>
                                <p>
                                    <a href='ForeclosedDetail.aspx?Id=<%# Eval("ForeclosedId") %>'>查看详情>></a></p>
                            </dd>
                        </ItemTemplate>
                        <FooterTemplate>
                            </dl></FooterTemplate>
                    </asp:DataList>
                    <div style="width: 705px; height: 30px; line-height: 30px; text-align: center">
                        <XYECOM:Page ID="Page1" runat="server" PageSize="20" OnPageChanged="Page1_PageChanged" />
                    </div>
                    <div>
                        <p style="text-align: center;">
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label></p>
                    </div>
                </div>
            </div>
            <!--left4结束-->
        </div>
        <!--left结束-->
    </div>
    </form>
</body>
</html>
