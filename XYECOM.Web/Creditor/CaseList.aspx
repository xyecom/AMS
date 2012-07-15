<%@ Page Title="" Language="C#" MasterPageFile="~/Creditor/Creditor.master" AutoEventWireup="true"
    CodeBehind="CaseList.aspx.cs" Inherits="XYECOM.Web.Creditor.CaseList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <div id="right">
        <h2>
            档案管理
        </h2>
        <div>
            <a href="/Creditor/UploadCase.aspx">添加档案</a>
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EnableModelValidation="True"
            Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField HeaderText="选择" Visible="false">
                    <ItemTemplate>
                        <input type="checkbox" value='<%# Eval("Id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="档案名称">
                    <ItemTemplate>
                        <%# Eval("CaseName") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="所属分类">
                    <ItemTemplate>
                        <%# Eval("CaseTypeName")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="所属部门">
                    <ItemTemplate>
                        <%# Eval("PartName")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="上传时间">
                    <ItemTemplate>
                        <%# Eval("CreateDate")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="说明">
                    <ItemTemplate>
                        <%# Eval("Description") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnDel" runat="server" OnClientClick="javascript:confirm('确定删除？')!"
                            CommandArgument='<%# string.Format("{0}|{1}",Eval("Id"),Eval("FilePath")) %>'
                            OnClick="btnDel_Click">删除</asp:LinkButton>
                        <a href='/Creditor/UploadCase.aspx?id=<%# Eval("Id") %>'>修改</a> <a href='<%# Eval("FilePath") %>'>
                            下载</a>
                        <asp:LinkButton ID="btnDownLoad" runat="server" CommandArgument='<%# Eval("FilePath") %>'
                            OnClick="btnDownLoad_Click" Visible="false">下载</asp:LinkButton>
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
