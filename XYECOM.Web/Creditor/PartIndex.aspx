<%@ Page Title="" Language="C#" MasterPageFile="~/Creditor/Creditor.master" AutoEventWireup="true"
    CodeBehind="PartIndex.aspx.cs" Inherits="XYECOM.Web.Creditor.PartIndex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <div id="right">
        <!--rightpart start-->
        <div id="rightpart">
            <h2>
                办公室详情</h2>
            <div class="rhr">
            </div>
            <div id="dzbase">
                <div style="width: 50%; float: left; height: 20px; font-size: 13px; font-weight: bold">
                    【部门基本情况】</div>
                <div style="width: 100px; float: right; height: 20px">
                    <a href="EditPartInfo.aspx?ac=u">修改</a></div>
                <table class="dzbasetb">
                    <tbody>
                        <tr>
                            <td class="info1">
                                部门名称：
                            </td>
                            <td>
                                <asp:Literal ID="ltlPaartName" runat="server"></asp:Literal>
                            </td>
                            <td class="info1">
                                负责人：
                            </td>
                            <td>
                                <asp:Literal ID="ltlFzr" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td class="info1">
                                负责人电话：
                            </td>
                            <td>
                                <asp:Literal ID="ltlFzeTel" runat="server"></asp:Literal>
                            </td>
                            <td class="info1">
                                负责人E-MAIL：
                            </td>
                            <td>
                                <asp:Literal ID="ltlFzeEmail" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <div style="width: 50%; float: left; height: 20px; font-size: 13px; font-weight: bold">
                    【部门债权】</div>
                <!--serch start-->
                <div class="serchl">
                    <asp:DropDownList ID="ddlState" runat="server" Width="150">
                        <asp:ListItem Text="所有" Value="">
                        </asp:ListItem>
                        <asp:ListItem Text="草稿" Value="0">
                        </asp:ListItem>
                        <asp:ListItem Text="投标中" Value="2">
                        </asp:ListItem>
                        <asp:ListItem Text="进行中" Value="3">
                        </asp:ListItem>
                        <asp:ListItem Text="已完成" Value="5">
                        </asp:ListItem>
                        <asp:ListItem Text="已取消" Value="6">
                        </asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;
                    <input onblur="if(!value){this.value=defaultValue;}" runat="server" id="txtKey" style="color: #a8a4a3"
                        onfocus="this.value=''" value="请输入关键字" type="text">
                    <asp:Button ID="btnSearch" runat="server" Text="查 询" OnClick="btnSearch_Click" />
                </div>
                <!--serch end-->
                <!--列表 start-->
                <div id="list">
                    <asp:Repeater ID="dlCreditList" runat="server">
                        <HeaderTemplate>
                            <table>
                                <tbody>
                                    <tr id="trtop">
                                        <td width="40%" align="middle">
                                            案件标题
                                        </td>
                                        <td width="20%" align="middle">
                                            发布时间
                                        </td>
                                        <td width="15%" align="middle">
                                            付款状态
                                        </td>
                                        <td width="25%" align="middle">
                                            操作菜单
                                        </td>
                                    </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr style="background-color: #ffffff; height: 28px; border-top: #ccc 1px solid" id="trmidd"
                                onmousemove="this.style.backgroundColor='#F7F7F7'" onmouseout="this.style.backgroundColor='#ffffff'">
                                <td id="tdtitle">
                                    <a title="与xxx企业的业务往来" href="#">与xxx企业的业务往来</a>
                                </td>
                                <td>
                                    2012-02-12
                                </td>
                                <td>
                                    【已付款】
                                </td>
                                <td>
                                    <a href="#">详情</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href="#">删除</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody> </table></FooterTemplate>
                    </asp:Repeater>
                    <table>
                        <tbody>
                            <tr style="height: 23px">
                                <td bgcolor="#f9f9f9" colspan="4" align="middle">
                                <h2>
                                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label></h2>
                                    <XYECOM:Page ID="page1" runat="server" PageSize="10" OnPageChanged="Page1_PageChanged" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <!--列表 end-->
            </div>
        </div>
        <!--rightpart end-->
    </div>
</asp:Content>
