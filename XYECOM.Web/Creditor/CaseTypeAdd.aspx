<%@ Page Title="" Language="C#" MasterPageFile="~/Creditor/Creditor.master" AutoEventWireup="true"
    CodeBehind="CaseTypeAdd.aspx.cs" Inherits="XYECOM.Web.Creditor.CaseTypeAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <div id="right">
    <div id="rightzqlist">
            <h2>
                档案分类添加</h2>
            <div class="rhr"></div>
       <table style="margin: 8px auto" class="tab">
                    <tr>
                        <td class="info_lei3">
                            分类名称
                        </td>
                        <td colspan="3">
                            <asp:TextBox runat="server" ID="txtName" Width="430px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtName"
                                ErrorMessage="*" ForeColor="Red" Font-Size="9pt"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="info_lei3">
                            分类说明
                        </td>
                        <td colspan="3">
                            <asp:TextBox runat="server" ID="txtRemark"  TextMode="MultiLine" 
                                Width="430px" Height="75px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRemark"
                                ErrorMessage="*" ForeColor="Red" Font-Size="9pt"></asp:RequiredFieldValidator>
                        </td>
                        </tr>
                        </table>
            <div style="text-align: center; line-height:40px">
             <asp:Button ID="btnok" runat="server" CssClass="button" Text="保存" OnClick="btnok_Click" Style="background: url(../Other/images/yes.gif);
                                    width: 80px; height: 25px; border: none; cursor: pointer; font-size: 13px; color: White">
                </asp:Button>
                &nbsp;
                <input type="button" id="btnBack" onclick="javascript:history.back();" value="返回" Style="background: url(../Other/images/no.gif);
                                    width: 80px; height: 25px; border: none; cursor: pointer; font-size: 13px; color: White"/>
                <asp:HiddenField ID="hidInfoId" runat="server" />
  </div>
  </div>
    </div> 
</asp:Content>
