<%@ Page Title="" Language="C#" MasterPageFile="~/Creditor/Creditor.master" AutoEventWireup="true"
    CodeBehind="CaseTypeAdd.aspx.cs" Inherits="XYECOM.Web.Creditor.CaseTypeAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <table class="xy_tb xy_tb2">
        <tr class="nobg">
            <td colspan="2" class="td27" style="height: 27px">
                分类名称：
            </td>
        </tr>
        <tr>
            <td class="vtop rowform">
                <asp:TextBox ID="txtName" runat="server" CssClass="input" MaxLength="20"></asp:TextBox>
            </td>
            <td class="vtop tips2">
            </td>
        </tr>
        <tr class="nobg">
            <td colspan="2" class="td27" style="height: 27px">
                分类说明:
            </td>
        </tr>
        <tr>
            <td class="vtop rowform">
                <asp:TextBox ID="txtRemark" Rows="5" Columns="30" TextMode="MultiLine" runat="server"></asp:TextBox>
            </td>
            <td class="vtop tips2">
            </td>
        </tr>
        <tr>
            <td colspan="2" class="content_action">
                <asp:Button ID="btnok" runat="server" CssClass="button" Text="保存" OnClick="btnok_Click">
                </asp:Button>
                <input type="button" id="btnBack" onclick="javascript:history.back();" value="返回" />
                <asp:HiddenField ID="hidInfoId" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
