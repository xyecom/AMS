<%@ Page Title="" Language="C#" MasterPageFile="~/Creditor/Creditor.master" AutoEventWireup="true"
    CodeBehind="AddEvaluation.aspx.cs" Inherits="XYECOM.Web.Creditor.AddEvaluation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <title>对服务商进行评价</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <!--right start-->
    <div id="right">
        <!--rightdzmain start-->
        <div id="rightdzmain">
            <h2>
                对服务商进行评价</h2>
            <div class="rhr">
            </div>
            <!--基本信息 start-->
            <table class="pjtb">
                <tr>
                    <td>
                        请选择:
                    </td>
                    <td>
                        <asp:RadioButtonList runat="server" ID="radEvaluationType" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1" Text="好评"></asp:ListItem>
                            <asp:ListItem Value="0" Text="差评"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
            </table>
            <table class="pjtb">
                <tr>
                    <td>
                        请填写您的评价：
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtDescription" TextMode="MultiLine" Rows="15" Width="426px"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <div style="width: 756px; height: 50px; line-height: 50px; text-align: center">
                <input type="hidden" runat="server" id="hidCredId" />
                <asp:Button runat="server" ID="btnOk" Text="我要评价" OnClick="btnOk_Click" />
            </div>
            <!--基本信息 end-->
        </div>
        <!--rightdzmain end-->
    </div>
    <!--right end-->
</asp:Content>
