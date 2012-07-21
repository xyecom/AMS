<%@ Page Title="" Language="C#" MasterPageFile="~/Server/Server.master" AutoEventWireup="true"
    CodeBehind="SendMessageList.aspx.cs" Inherits="XYECOM.Web.Server.SendMessageList" %>

<%@ Register Src="../Other/UserContorl/SendMessageList.ascx" TagName="SendMessageList"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <uc1:SendMessageList ID="SendMessageList1" runat="server" />
</asp:Content>
