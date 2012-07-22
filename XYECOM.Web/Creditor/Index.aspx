<%@ Page Title="" Language="C#" MasterPageFile="~/Creditor/Creditor.master" AutoEventWireup="true"
    CodeBehind="Index.aspx.cs" Inherits="XYECOM.Web.Creditor.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <div id="right">
        <!--rightmsg start-->
        <div id="rightmsg">
            <div id="msgimg">
                <asp:Image ID="imgPic" Width="100" runat="server" />
                <br />
                <br />
                <a href="UpLoadPicture.aspx">修改头像</a>
            </div>
            <div id="line">
            </div>
            <div id="msgmain">
                <p>
                    <font>尊敬的&nbsp; </font><strong>
                        <asp:Literal ID="ltlCompanyName" runat="server"></asp:Literal>
                    </strong><font>，欢迎您！</font> <span style="padding-bottom: 10px; padding-right: 10px;
                        float: right">最近一次登录时间：
                        <asp:Literal ID="ltlLastLoginTime" runat="server"></asp:Literal>
                    </span>
                </p>
                <p>
                </p>
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
                                <a href="ModifyPwd.aspx">修改账户密码</a>
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
                <p>
                </p>
                <table id="msgtb2">
                    <tbody>
                        <tr>
                            <td>
                                存储文件：<asp:Literal ID="ltlCaseCount" runat="server"></asp:Literal>条
                            </td>
                            <td>
                                外包债权：<asp:Literal ID="ltlCreditInfoCount" runat="server"></asp:Literal>条
                            </td>
                        </tr>
                        <tr>
                            <td>
                                债权草稿箱：<asp:Literal ID="ltlDraftCount" runat="server"></asp:Literal>条
                            </td>
                            <td>
                                部门数量：<asp:Literal ID="ltlPartCount" runat="server"></asp:Literal>个
                            </td>
                        </tr>
                        <tr>
                            <td>
                                站内消息：通知/提醒（<a href="ReceiveMessageList.aspx"><font style="color: #f00"><asp:Literal
                                    ID="ltlMessageCount" runat="server"></asp:Literal></font></a>条）
                            </td>
                            <td>
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
        </div>
        <!--rightzqlist end-->
        <!--rightdzwplist start-->
        <div id="rightdzwplist">
            <h2>
                发布中的抵债物品</h2>
            <div class="rhr">
            </div>
            <div id="dztb">
                <h2>
                    <asp:Label ID="lblDzMessage" runat="server" Text=""></asp:Label>
                </h2>
                <asp:DataList ID="dltDz" runat="server" RepeatColumns="2" Width="100%">
                    <HeaderTemplate>
                        <dl>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <dd>
                            <img src='<%# GetInfoImgHref(Eval("ForeclosedId")) %>' style="width: 100px" />
                            <p>
                                <strong>
                                    <%#Eval("Title") %></strong><br />
                            </p>
                            <p>
                                <font>物品底价：<%# Eval("LinePrice")%>元</font></p>
                            <p>
                                <font>竞价结束时间：<%# GetEndDate(Eval("EndDate"))%></font></p>
                            <p>
                                <a href='ForeclosedDetail.aspx?Id=<%# Eval("ForeclosedId") %>'>查看详情>></a></p>
                        </dd>
                    </ItemTemplate>
                    <FooterTemplate>
                        </dl></FooterTemplate>
                </asp:DataList>
            </div>
        </div>
        <!--rightdzwplist end-->
    </div>
</asp:Content>
