<%@ Page Title="" Language="C#" MasterPageFile="~/Creditor/Creditor.master" AutoEventWireup="true"
    CodeBehind="UploadCase.aspx.cs" Inherits="XYECOM.Web.Creditor.UploadCase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <div id="right">
 <div id="rightzqlist">
            <h2>
                上传档案</h2>
            <div class="rhr"></div>
        
       <table style="margin: 8px auto" class="tab">
                     <tr>
                        <td class="info_lei3">
                             选择分类
                        </td>
                        <td colspan="3">
   <asp:DropDownList ID="ddlType" runat="server" Height="23px" Width="149px">
            </asp:DropDownList>
                        </td>
                    </tr>
                   
                    <tr>
                        <td class="info_lei3">
                             名称
                        </td>
                        <td colspan="3"><asp:TextBox ID="txtCaseName" runat="server" Width="430px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtCaseName"
                                ErrorMessage="*" ForeColor="Red" Font-Size="9pt"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="info_lei3">
                           说明
                        </td>
                        <td colspan="3">
                        <asp:TextBox ID="txtDescription" TextMode="MultiLine" Width="430px" Rows="5" runat="server"></asp:TextBox>
                        </td>
                        </tr>
                        <tr>
                        <td class="info_lei3">
                        选择文件
                         </td>
                        <td>
                         <asp:FileUpload ID="flCase" runat="server" Width="403px" />
                        </td>
                        
                        </tr>
                        </table>      

   <div style="text-align: center; line-height:40px">
  <asp:HiddenField ID="hidInfoId" runat="server" />
            <asp:Button ID="btnUpload" runat="server" Text="上传" OnClick="btnUpload_Click"  Style="background: url(../Other/images/yes.gif);
                                    width: 80px; height: 25px; border: none; cursor: pointer; font-size: 13px; color: White"/>
                                        &nbsp;
                <input type="button" id="btnBack" onclick="javascript:history.back();" value="返回" Style="background: url(../Other/images/no.gif);
                                    width: 80px; height: 25px; border: none; cursor: pointer; font-size: 13px; color: White"/>
   </div>
   </div>
   </div>
 </asp:Content>
