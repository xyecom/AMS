<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReceiveMessage.ascx.cs"
    Inherits="XYECOM.Web.Other.UserContorl.ReceiveMessage" %>
<link href="../css/main.css" rel="stylesheet" type="text/css" />
<div id="right">
    <div id="rightzqlist">
        <h2>
            收到的站内信
        </h2>
        <span style="float: right; padding-right: 30px; height: 25px; line-height: 25px"><a
            href="#">删除</a>&nbsp;&nbsp;&nbsp; <a href="#">标记为已读</a></span>
        <div id="list">
            <asp:Repeater ID="rptList" runat="server">
                <HeaderTemplate>
                    <table>
                        <tr id="trtop">
                            <td align="center" width="3%">
                                <input id="Checkbox4" type="checkbox" />
                            </td>
                            <td align="center" width="47%">
                                消息标题
                            </td>
                            <td align="center" width="15%">
                                发信时间
                            </td>
                            <td align="center" width="15%">
                                信息来源
                            </td>
                            <td align="center" width="25%">
                                操作菜单
                            </td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr id="trmidd" style="height: 28px; border-top: 1px solid #ccc" onmousemove="this.style.backgroundColor='#F7F7F7'"
                        onmouseout="this.style.backgroundColor='#ffffff'">
                        <td>
                            <input id="Checkbox1" type="checkbox" />
                        </td>
                        <td id="tdtitle">
                            <img src="/templates/default/images/ly_img<%# Eval("M_HasReply").ToString()=="False"?"3":"2" %>.gif" />
                            <a href="receivemessageinfo.aspx?m_id=<%# Eval("M_ID") %>">
                                <%# Eval("M_Title")%></a>
                        </td>
                        <td>
                            <%# Eval("M_AddTime")%>
                        </td>
                        <td>
                            <%# GetUserName(Eval("U_ID").ToString(), Eval("M_UserName").ToString(), Eval("M_CompanyName").ToString(), Eval("M_ID").ToString())%>
                        </td>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:LinkButton ID="btndel" runat="server" CommandArgument='<%# Eval("M_ID") %>'
                                OnClick="btndel_Click">删除</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div style="height: 30px; text-align: center">
            <XYECOM:Page ID="pageinfo" runat="server" OnPageChanged="Page1_PageChanged" />
        </div>
        <div>
            <p style="text-align: center;">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label></p>
        </div>
    </div>
</div>
