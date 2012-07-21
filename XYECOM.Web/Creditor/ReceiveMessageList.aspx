<%@ Page Title="" Language="C#" MasterPageFile="~/Creditor/Creditor.master" AutoEventWireup="true" CodeBehind="ReceiveMessageList.aspx.cs" Inherits="XYECOM.Web.Creditor.ReceiveMessageList" %>

<%@ Register src="../Other/UserContorl/ReceiveMessage.ascx" tagname="ReceiveMessage" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    
    <uc1:ReceiveMessage ID="ReceiveMessage1" runat="server" />
    
</asp:Content>
