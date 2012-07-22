<%@ Page Title="" Language="C#" MasterPageFile="~/Server/Server.master" AutoEventWireup="true"
    CodeBehind="Index.aspx.cs" Inherits="XYECOM.Web.Server.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div id="right">
        <!--rightmsg start-->
        <div id="rightmsg">
            <div id="msgimg">
                <asp:Image ID="imgPicture" runat="server" Width="120" />
                <br />
                <br>
                <a href="/Server/UpLoadPicture.aspx">修改头像</a>
            </div>
            <div id="line">
            </div>
            <div id="msgmain">
                <p>
                    <font>尊敬的&nbsp; </font><strong>
                        <asp:Literal ID="ltlCompanyName" runat="server"></asp:Literal></strong><font>，欢迎您！</font>
                    <span style="padding-bottom: 10px; padding-right: 10px; float: right">最近一次登录时间：<asp:Literal
                        ID="ltlLastLoginTime" runat="server"></asp:Literal></span></p>
                <table id="msgtb">
                    <tbody>
                        <tr>
                            <td width="60">
                                账号状态
                            </td>
                            <td width="128">
                                <img src="/Other/images/zhzt.gif">
                            </td>
                            <td width="100">
                                <a href="#">修改账户密码</a>
                            </td>
                            <td width="21">
                                <asp:Image ID="imgSj" runat="server" Width="19" />
                            </td>
                            <td width="83">
                                <asp:Literal ID="ltlSjMessage" runat="server"></asp:Literal>
                            </td>
                            <td width="21">
                                <asp:Image ID="imgYx" runat="server" Width="19" />
                            </td>
                            <td width="113">
                                <asp:Literal ID="ltlYxMessage" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <table id="msgtb2">
                    <tbody>
                        <tr>
                            <td>
                                已参与案件数：<asp:Label runat="server" ID="labCanCount"></asp:Label>
                                条
                            </td>
                            <td>
                                已中标数量：<asp:Label runat="server" ID="labZhongCount"></asp:Label>条
                            </td>
                        </tr>
                        <tr>
                            <td>
                                站内消息：通知/提醒（<a href="ReceiveMessageList.aspx"><font style="color: #f00"><asp:Literal
                                    ID="ltlMessageCount" runat="server"></asp:Literal></font></a>条）
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
        <!--rightmsg end-->
        <!--rightzqlist start-->
        <div id="rightzqlist">
            <h2>
                正在进行中的案件</h2>
            <div class="rhr">
            </div>
            <!--列表 start-->
            <!--列表 start-->
            <div id="list">
                <h2>
                    <asp:Label ID="lblZqMessage" runat="server" Text=""></asp:Label>
                </h2>
                <asp:Repeater ID="rptCreadit" runat="server">
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
                                    <td width="25%" align="middle">
                                        操作菜单
                                    </td>
                                </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr style="background-color: #ffffff; height: 28px; border-top: #ccc 1px solid" onmousemove="this.style.backgroundColor='#F7F7F7'"
                            onmouseout="this.style.backgroundColor='#ffffff'">
                            <td id="tdtitle">
                                <%# Eval("Title") %>
                            </td>
                            <td>
                                <%# Eval("CreateDate") %>
                            </td>
                            <td>
                                <a href='<%#  string.Format("/CreditInfoDetail.aspx?Id={0}",Eval("CreditId")) %>'>详情</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody> </table></FooterTemplate>
                </asp:Repeater>
            </div>
            <!--列表 end-->
            <!--列表 end-->
        </div>
        <!--rightzqlist end-->
    </div>
</asp:Content>
