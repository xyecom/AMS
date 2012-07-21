<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReceiveMessage.ascx.cs"
    Inherits="XYECOM.Web.Other.UserContorl.ReceiveMessage" %>
<div id="right">
    <h2>
        收到的站内信
    </h2>
    <asp:DataList ID="DataList1" runat="server" Width="100%">
        <HeaderTemplate>
            <table class="ly_tab2 ly_w1">
                <thead>
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                            标题
                        </td>
                        <td>
                            时间
                        </td>
                        <td>
                            发自
                        </td>
                        <td>
                            操作
                        </td>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <input name="sd_id" id="sd_id" type="checkbox" value='<%# Eval("M_ID") %>' name="sd_id" />
                </td>
                <td valign="top">
                    <img src="/templates/default/images/ly_img<%# Eval("M_HasReply").ToString()=="False"?"3":"2" %>.gif" />
                </td>
                <td>
                    <a href="receivemessageinfo.aspx?m_id=<%# Eval("M_ID") %>">
                        <%# Eval("M_Title")%></a><br />
                </td>
                <td>
                    <%# Eval("M_AddTime")%>
                </td>
                <td>
                    <%# GetUserName(Eval("U_ID").ToString(), Eval("M_UserName").ToString(), Eval("M_CompanyName").ToString(), Eval("M_ID").ToString())%>
                </td>
                <td>
                    <asp:LinkButton ID="btndel" runat="server" CommandArgument='<%# Eval("M_ID") %>'
                        OnClick="btndel_Click">删除</asp:LinkButton>
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
