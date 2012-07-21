<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReceiveMessageInfo.ascx.cs"
    Inherits="XYECOM.Web.Other.UserContorl.ReceiveMessageInfo" %>
<div id="right">
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <table>
                <tr>
                    <td>
                        发信人
                    </td>
                    <td runat="server" id="sender">
                    </td>
                </tr>
                <tr>
                    <td>
                        发布时间
                    </td>
                    <td runat="server" id="addtime">
                    </td>
                </tr>
                <tr>
                    <td>
                        主题
                    </td>
                    <td runat="server" id="subject">
                    </td>
                </tr>
                <tr>
                    <td>
                        内容
                    </td>
                    <td runat="server" id="content">
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        </asp:View>
    </asp:MultiView>
    <br />
    <input type="button" id="btnback" onclick="javascript:history.back()" value="返回" />
</div>
