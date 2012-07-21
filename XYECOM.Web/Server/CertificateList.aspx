<%@ Page Title="" Language="C#" MasterPageFile="~/Server/Server.master" AutoEventWireup="true"
    CodeBehind="CertificateList.aspx.cs" Inherits="XYECOM.Web.Server.CertificateList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div id="right">
        <div class="ly_tit3">
            <ul>
                <li class="on"><a href="#">企业证书</a> </li>
            </ul>
        </div>
        <div class="ly_tit32">
            证书类别：<asp:DropDownList ID="txttype" runat="server">
                <asp:ListItem Value="">请选择证书类别</asp:ListItem>
                <asp:ListItem Value="1">营业执照</asp:ListItem>
                <asp:ListItem Value="2">税务登记类</asp:ListItem>
                <asp:ListItem Value="3">经营许可类</asp:ListItem>
                <asp:ListItem Value="4">其它分类</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />
        </div>
        <asp:Repeater ID="Repeater1" runat="server">
            <HeaderTemplate>
                <table class="content" width="100%">
                    <thead>
                        <tr>
                            <th style="height: 20px">
                                证书名称
                            </th>
                            <th style="height: 20px">
                                所属类别
                            </th>
                            <th style="height: 20px">
                                生效日期
                            </th>
                            <th style="height: 20px">
                                截至日期
                            </th>
                            <th style="height: 20px">
                                状态
                            </th>
                            <th style="height: 20px">
                                操作
                            </th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%# Eval("CE_Name")%>
                    </td>
                    <td>
                        <%# GetTypeName(Eval("CE_Type"))%>
                    </td>
                    <td>
                        <%# Eval("CE_Begin")%>
                    </td>
                    <td>
                        <%# Eval("CE_Upto")%>
                    </td>
                    <td class="orange">
                        <%# AuditingState(Eval("AuditingState"))%>
                    </td>
                    <td>
                        <a href="/Server/CertificateAdd.aspx?ce_id=<%# Eval("CE_ID") %>" title="请点击">修改</a>
                        <asp:LinkButton ID="lbtnDel" OnClick="lbtnDel_Click" OnClientClick="javascript:return confirm('确定删除该信息!');" runat="server" CommandArgument='<%# Eval("CE_ID") %>'>删除</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody> </table>
            </FooterTemplate>
        </asp:Repeater>
        <table class="content_action">
            <tr>
                <td>
                    <input name="barnd" class="button" type="button" value="新增" onclick="window.location.href='/Server/certificateadd.aspx'" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
