<%@ Page Title="" Language="C#" MasterPageFile="~/Server/Server.master" AutoEventWireup="true" CodeBehind="SetQuestion.aspx.cs" Inherits="XYECOM.Web.Server.SetQuestion" %>
<%@ Register src="../Other/UserContorl/SetQuestion.ascx" tagname="SetQuestion" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <uc1:SetQuestion ID="SetQuestion1" runat="server" />
</asp:Content>
