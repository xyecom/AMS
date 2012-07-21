<%@ Page Title="" Language="C#" MasterPageFile="~/Creditor/Creditor.master" AutoEventWireup="true" CodeBehind="SendMessageList.aspx.cs" Inherits="XYECOM.Web.Creditor.SendMessageList" %>
<%@ Register src="../Other/UserContorl/SendMessageList.ascx" tagname="SendMessageList" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <uc1:SendMessageList ID="SendMessageList1" runat="server" />
</asp:Content>
