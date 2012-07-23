<%@ Page Title="" Language="C#" MasterPageFile="~/Fore.Master" AutoEventWireup="true"
    CodeBehind="IndexForeclosed.aspx.cs" Inherits="XYECOM.Web.IndexForeclosed" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="left4">
        <div style="background: url('/Other/images/erji_titlebg.gif'); background-repeat: repeat-x;
            height: auto; overflow: hidden;">
            <div style="width: 100px; line-height: 38px; margin-left: 55px; float: left; font-size: 14px">
                <strong>抵债物品资讯</strong></div>
            <div style="width: 514px; float: right; height: 40px; text-align: center">
                <table style="height: 31px; width: 514px;">
                    <tr>
                        <td width="65">
                            物品类型
                        </td>
                        <td width="113">
                            <asp:DropDownList runat="server" ID="droTypeName">
                                <asp:ListItem Value="所有" Text="--所有--"></asp:ListItem>
                                <asp:ListItem Value="房屋" Text="房屋"></asp:ListItem>
                                <asp:ListItem Value="汽车" Text="汽车"></asp:ListItem>
                                <asp:ListItem Value="金条" Text="金条"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td width="29">
                            地区
                        </td>
                        <td width="80">
                            <div id="divarea">
                            </div>
                            <input type="hidden" id="city" name="city" runat="server" />
                            <script type="text/javascript">                                var claarea
            = new ClassType("claarea", 'area', 'divarea', 'city', 1); claarea.Mode = "select";
                                claarea.Init(); </script>
                        </td>
                        <td width="123">
                            <asp:Button runat="server" ID="btnSearch" OnClick="btnSearch_Click" CssClass="btnok"
                                Text="搜索" />
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
                    <dd style="float: left; width: 25%">
                        <img width="96px;" src='<%# GetInfoImgHref(Eval("ForeclosedId")) %>' style="width: 100px" />
                        <p>
                            <strong>
                                <%#Eval("Title") %></strong><br />
                        </p>
                        <p>
                            <font>物品底价：<%# Eval("LinePrice")%>元</font></p>
                        <p>
                            <font>物品所在地：<%# GetAreaIdFull(Eval("AreaId"))%></font></p>
                        <p>
                            <a href='ForeclosedDetail.aspx?Id=<%#
            Eval("ForeclosedId") %>'>查看详情>></a></p>
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
</asp:Content>
