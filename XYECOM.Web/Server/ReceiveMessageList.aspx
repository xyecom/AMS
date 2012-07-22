<%@ Page Title="" Language="C#" MasterPageFile="~/Server/Server.master" AutoEventWireup="true"
    CodeBehind="ReceiveMessageList.aspx.cs" Inherits="XYECOM.Web.Server.ReceiveMessageList" %>

<%@ Register Src="../Other/UserContorl/ReceiveMessage.ascx" TagName="ReceiveMessage"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <uc1:ReceiveMessage ID="ReceiveMessage1" runat="server" />
</asp:Content>
