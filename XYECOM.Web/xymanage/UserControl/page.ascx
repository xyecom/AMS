<%@ Control Language="C#" AutoEventWireup="true" Inherits="xymanage_UserControl_page" Codebehind="page.ascx.cs" %>	
<table border="0" cellspacing="0" cellpadding="0" id="page">
 <tr>
 <td>
    <asp:label id="lbl_PageInfo" runat="server"></asp:label>&nbsp;
    
	<asp:linkbutton id="btn_pagefirst" style="CURSOR: hand" tabIndex="1" runat="server" BorderStyle="None"
		Text="�� ҳ" ToolTip="��������ҳ" CommandName="first"  CssClass="button_link">��һҳ</asp:linkbutton>
	<asp:linkbutton id="btn_pageprev" style="CURSOR: hand" tabIndex="2" runat="server" BorderStyle="None"
		Text="��һҳ" ToolTip="��������һҳ" CommandName="previous"  CssClass="button_link">��һҳ</asp:linkbutton>
	<asp:linkbutton id="btn_pagenext" style="CURSOR: hand" tabIndex="3" runat="server" BorderStyle="None"
		Text="��һҳ" ToolTip="��������һҳ" CommandName="next"  CssClass="button_link">��һҳ</asp:linkbutton>
	<asp:linkbutton id="btn_pagelast" style="CURSOR: hand" tabIndex="4" runat="server" BorderStyle="None"
		Text="β ҳ" ToolTip="������βҳ" CommandName="last"  CssClass="button_link">���һҳ</asp:linkbutton> 
	<asp:TextBox id="txtToPage" runat="server" CssClass="toPage"></asp:TextBox><asp:Button Text=">>" ID="btnToPage" runat="server" CssClass="btnToPage" OnClick="btnToPage_Click" />
</td>
</tr>
</table>
