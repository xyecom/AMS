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
                   <div style="margin:5px auto; text-align:center; font-weight:bold; font-size:14px">
                    <asp:Label ID="lblZqMessage" runat="server" Text=""></asp:Label>
              </div>
               
                        <table>
                        
                                <tr id="trtop">
                                    <td width="44%" align="center">
                                        案件标题
                                    </td>
                                    <td width="18%" align="center">
                                        案件状态
                                    </td>
                                    <td width="20%" align="center">
                                        发布时间
                                    </td>
                                    <td width="18%" align="center">
                                        操作菜单
                                    </td> 
                                     </tr>
                <asp:Repeater ID="rptCreadit" runat="server">
                    <ItemTemplate>
                        <tr  id="trmidd"  style="background-color: #ffffff; height: 28px; border-top: #ccc 1px solid" onmousemove="this.style.backgroundColor='#F7F7F7'"
                            onmouseout="this.style.backgroundColor='#ffffff'">
                            <td id="tdtitle">
                                <%# Eval("Title") %>
                            </td>
                            <td>
                                <%# GetApprovaStatus(Eval("ApprovaStatus"))%>
                            </td>
                            <td>
                                <%# Eval("CreateDate") %>
                            </td>
                            <td>
                                <asp:HyperLink ID="hlShowTender" runat="server" NavigateUrl='<%# "CreditDetils.aspx?Id=" + Eval("CreditId") %>'>查看详情</asp:HyperLink>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                </table>
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
            <div style="height: auto; width: 800px;">
                <div style="margin:5px auto; text-align:center; font-weight:bold; font-size:14px">
                    <asp:Label ID="lblDzMessage" runat="server" Text=""></asp:Label>
              </div>

              
                <asp:DataList ID="dltDz" runat="server" RepeatColumns="2" Width="100%">
                    <ItemTemplate>
    <div style=" float:left;width:373px; height:105px; border:1px solid #ddd; margin:5px 8px; padding:5px 5px">
<table id="dztb">
<tr>
<td>
<img width="96px;" src='<%# GetInfoImgHref(Eval("ForeclosedId")) %>'/>
<p><strong><%#Eval("Title") %></strong></p>
<p><font>物品底价：￥<%# Eval("LinePrice")%></font></p>
 <p><font>竞价结束时间：<%# GetEndDate(Eval("EndDate"))%></font></p>
 <p> <a href='ForeclosedDetail.aspx?Id=<%#Eval("ForeclosedId") %>'>查看详情>></a></p>
</td>
</tr>
                        </table>
                       </div>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
        <!--rightdzwplist end-->
    </div>
</asp:Content>
