<%@ Page Title="" Language="C#" MasterPageFile="~/Server/Server.master" AutoEventWireup="true"
    CodeBehind="ReceiveMessageInfo.aspx.cs" Inherits="XYECOM.Web.Server.ReceiveMessageInfo" %>

<%@ Register Src="../Other/UserContorl/ReceiveMessageInfo.ascx" TagName="ReceiveMessageInfo"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <uc1:ReceiveMessageInfo ID="ReceiveMessageInfo111" runat="server" />
</asp:Content>
