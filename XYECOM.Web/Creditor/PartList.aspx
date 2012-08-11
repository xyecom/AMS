<%@ Page Title="" Language="C#" MasterPageFile="~/Creditor/Creditor.master" AutoEventWireup="true"
    CodeBehind="PartList.aspx.cs" Inherits="XYECOM.Web.Creditor.PartList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .tr
        {
            background-color: #ffffff;
            height: 28px;
            border-top: #ccc 1px solid;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <div id="right">
        <!--rightpart start-->
        <div id="rightpart">
            <h2>
                部门列表</h2>
            <h3>
                <a href="EditPartInfo.aspx">添加</a>
            </h3>
            <div class="rhr">
            </div>
            <!--列表 start-->
            <asp:Repeater ID="rptPartList" runat="server">
                <HeaderTemplate>
                    <table>
                        <tbody>
                            <tr id="trtop">
                                <td width="30%" align="middle">
                                    部门名称
                                </td>
                                <td width="20%" align="middle">
                                    部门负责人
                                </td>
                                <td width="10%" align="middle">
                                    负责人电话
                                </td>
                                <td width="10%" align="middle">
                                    启用状态
                                </td>
                                <td width="30%" align="middle">
                                    操作菜单
                                </td>
                            </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tr" onmousemove="this.style.backgroundColor='#F7F7F7'" onmouseout="this.style.backgroundColor='#ffffff'">
                        <td>
                            <%# Eval("LayerName") %>
                        </td>
                        <td>
                            <%# Eval("PartManagerName")%>
                        </td>
                        <td>
                            <%# Eval("PartManagerTel")%>
                        </td>
                        <td>
                            <%# ToStateName(Eval("UserAuditingState").ToString(),true)%>
                        </td>
                        <td>
                            <asp:LinkButton ID="lbtnDel" OnClick="lbtnDel_Click" OnClientClick="return confirm('确认删除！')"
                                CommandArgument='<%# Eval("U_ID") %>' runat="server">删除</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;<a
                                    href="/Creditor/EditPartInfo.aspx?ac=u&partid=<%# Eval("U_ID") %>">修改</a>&nbsp;&nbsp;&nbsp;&nbsp;
                            <a href='/Creditor/ParDetail.aspx?ac=u&partid=<%# Eval("U_ID") %>'>查看详情</a>&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:LinkButton OnClick="lbtnStatus_Click" CommandArgument='<%# string.Format("{0}|{1}",Eval("U_ID"),Eval("UserAuditingState")) %>'
                                ID="lbtnStatus" runat="server"><%# ToStateName(Eval("UserAuditingState").ToString(),false)%></asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody> </table>
                </FooterTemplate>
            </asp:Repeater>
            <!--列表 end-->
        </div>
        <!--rightpart end-->
    </div>
</asp:Content>
