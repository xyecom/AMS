<%@ Page Title="" Language="C#" MasterPageFile="~/Creditor/Creditor.master" AutoEventWireup="true"
    CodeBehind="CaseTypeList.aspx.cs" Inherits="XYECOM.Web.Creditor.CaseTypeList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <div id="right">
            <!--rightzqlist start-->
        <div id="rightzqlist">
            <h2>
                档案分类管理</h2>
            <div class="rhr"></div>
        <div style=" width:800px ; height:40px; line-height:40px; text-align:right">
            <a href="/Creditor/CaseTypeAdd.aspx">添加分类</a>
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
            Width="100%" BackColor="White" BorderColor="#CC9966" BorderStyle="None" 
                BorderWidth="1px" CellPadding="4" >
            <Columns>
                <asp:TemplateField HeaderText="类别名称" ItemStyle-Width="250px">
                    <ItemTemplate>
                        <%# Eval("PtName") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="所属部门"  ItemStyle-Width="100px">
                    <ItemTemplate>
                        <%# Eval("LayerName")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="说明" ItemStyle-Width="250px">
                    <ItemTemplate>
                        <%# Eval("Remark") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作" ItemStyle-Width="200px">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnDel" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="btnDel_Click">删除</asp:LinkButton>
                        <a href='/Creditor/CaseTypeAdd.aspx?id=<%# Eval("Id") %>'>修改</a> <a href='/Creditor/CaseList.aspx?id=<%# Eval("Id") %>'>
                            档案管理 </a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#cc0000" Font-Bold="True" ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#ddd" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#ddd" />
            <SelectedRowStyle BackColor="#ddd" Font-Bold="True" ForeColor="#ddd" />
            <SortedAscendingCellStyle BackColor="#ddd" />
            <SortedAscendingHeaderStyle BackColor="#ddd" />
            <SortedDescendingCellStyle BackColor="#ddd" />
            <SortedDescendingHeaderStyle BackColor="#ddd" />
        </asp:GridView>
    </div>
    </div>
</asp:Content>
