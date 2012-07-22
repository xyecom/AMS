<%@ Page Title="" Language="C#" MasterPageFile="~/Fore.Master" AutoEventWireup="true"
    CodeBehind="Activation .aspx.cs" Inherits="XYECOM.Web.Activation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        会员激活</h2>
    <asp:Label ID="lblUserName" runat="server" Text=""></asp:Label>
    <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
    <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
</asp:Content>
