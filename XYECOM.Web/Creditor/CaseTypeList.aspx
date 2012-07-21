<%@ Page Title="" Language="C#" MasterPageFile="~/Creditor/Creditor.master" AutoEventWireup="true"
    CodeBehind="CaseTypeList.aspx.cs" Inherits="XYECOM.Web.Creditor.CaseTypeList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <div id="right">
        <h2>
            分类管理
        </h2>
        <div>
            <a href="/Creditor/CaseTypeAdd.aspx">添加分类</a>
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EnableModelValidation="True"
            Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField HeaderText="类别名称">
                    <ItemTemplate>
                        <%# Eval("PtName") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="所属部门">
                    <ItemTemplate>
                        <%# Eval("LayerName")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="说明">
                    <ItemTemplate>
                        <%# Eval("Remark") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnDel" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="btnDel_Click">删除</asp:LinkButton>
                        <a href='/Creditor/CaseTypeAdd.aspx?id=<%# Eval("Id") %>'>修改</a> <a href='/Creditor/CaseList.aspx?id=<%# Eval("Id") %>'>
                            档案管理 </a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView>
    </div>
</asp:Content>
