<%@ Page Title="" Language="C#" MasterPageFile="~/Creditor/Creditor.master" AutoEventWireup="true"
    CodeBehind="UploadCase.aspx.cs" Inherits="XYECOM.Web.Creditor.UploadCase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <div id="right">
        <h2>
            上传档案</h2>
        <hr />
        <div runat="server" id="divType">
            分类选择：<asp:DropDownList ID="ddlType" runat="server">
            </asp:DropDownList>
        </div>
        <div>
            名称:<asp:TextBox ID="txtCaseName" runat="server"></asp:TextBox>
        </div>
        <div>
            说明:<asp:TextBox ID="txtDescription" TextMode="MultiLine" Columns="50" Rows="5" runat="server"></asp:TextBox>
        </div>
        <div runat="server" id="divfile">
            选择文件:
            <asp:FileUpload ID="flCase" runat="server" />
        </div>
        <div>
            <asp:HiddenField ID="hidInfoId" runat="server" />
            <asp:Button ID="btnUpload" runat="server" Text="上传" OnClick="btnUpload_Click" />
        </div>
    </div>
</asp:Content>
