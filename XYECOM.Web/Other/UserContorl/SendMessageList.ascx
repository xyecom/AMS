<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SendMessageList.ascx.cs" Inherits="XYECOM.Web.Other.UserContorl.SendMessageList" %>
<div id="right">
    <h2>
        发出的站内信
    </h2>
    <asp:DataList ID="DataList1" runat="server" Width="100%">
        <HeaderTemplate>
            <table class="ly_tab2 ly_w1">
                <thead>
                    <tr>
                        <td>
                            标题
                        </td>
                        <td>
                            时间
                        </td>
                        <td>内容</td>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <a href="receivemessageinfo.aspx?m_id=<%# Eval("M_ID") %>">
                        <%# Eval("M_Title")%></a><br />
                </td>
                <td>
                    <%# Eval("M_AddTime")%>
                </td>
                <td>
                <%# Eval("content")%>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </tbody> </table></FooterTemplate>
    </asp:DataList>
    <div style="height: 30px;">
        <XYECOM:Page ID="pageinfo" runat="server" OnPageChanged="Page1_PageChanged" />
    </div>
    <div>
        <p style="text-align: center;">
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label></p>
    </div>
</div>