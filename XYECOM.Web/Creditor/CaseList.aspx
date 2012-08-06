<%@ Page Title="" Language="C#" MasterPageFile="~/Creditor/Creditor.master" AutoEventWireup="true"
    CodeBehind="CaseList.aspx.cs" Inherits="XYECOM.Web.Creditor.CaseList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <div id="right">
        <!--rightpart start-->
        <div id="rightpart">
            <h2>
                档案管理</h2>
            <div class="rhr">
            </div>
            <!--serch start-->
            <div class="serchl">
                所属部门:<asp:DropDownList ID="ddlPart" runat="server" Width="150">
                </asp:DropDownList>
                &nbsp;&nbsp; &nbsp;&nbsp; 关键字:
                <input onblur="if(!value){value=defaultValue;}" style="color: #a8a4a3" onfocus="this.value=''"
                    value="请输入关键字" type="text" runat="server" id="txtKey" />
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click"  Style="background: url(../Other/images/yes.gif);
                                width: 80px; height: 25px; border: none; cursor: pointer; font-size: 13px; color: White" />
            </div>
            <!--serch end-->
            <!--列表 start-->
            <div id="list">
                <asp:Repeater ID="rptList" runat="server">
                    <HeaderTemplate>
                        <table>
                            <tbody>
                                <tr id="trtop">
                                    <td width="30%" align="middle">
                                        档案标题
                                    </td>
                                    <td width="15%" align="middle">
                                        分类
                                    </td>
                                    <td width="15%" align="middle">
                                        创建时间
                                    </td>
                                    <td width="15%" align="middle">
                                        创建者
                                    </td>
                                    <td width="25%" align="middle">
                                        操作菜单
                                    </td>
                                </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr id="trmidd"  style="background-color: #ffffff; height: 28px; border-top: #ccc 1px solid" onmousemove="this.style.backgroundColor='#F7F7F7'"
                            onmouseout="this.style.backgroundColor='#ffffff'">
                            <td id="tdtitle">
                                <%# Eval("CaseName") %>
                            </td>
                            <td>
                                <%# Eval("CaseTypeName")%>
                            </td>
                            <td>
                                <%# Eval("CreateDate", "{0:yyyy-MM-dd}")%>
                            </td>
                            <td>
                                <%# Eval("PartName")%>
                            </td>
                            <td>
                                <a href='/Creditor/UploadCase.aspx?id=<%# Eval("Id") %>'>修改</a> <a href='<%# Eval("FilePath") %>'>
                                    下载</a> <a href="#">详情</a>&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="btnDel" runat="server"
                                        OnClientClick="javascript:return confirm('确定删除？');" CommandArgument='<%# string.Format("{0}|{1}",Eval("Id"),Eval("FilePath")) %>'
                                        OnClick="btnDel_Click">删除</asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody> </table>
                    </FooterTemplate>
                </asp:Repeater>
                <table>
                    <tbody>
                        <tr style="height: 23px">
                            <h2>
                                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label></p></h2>
                            <XYECOM:Page ID="Page1" runat="server" PageSize="20" OnPageChanged="Page1_PageChanged" />
                        </tr>
                    </tbody>
                </table>
            </div>
            <!--列表 end-->
        </div>
        <!--rightpart end-->
    </div>
    <div style="text-align:right; padding-right:10px; font-size:14px; font-weight:bold; height:50px; line-height:50px">
        <a href="/Creditor/UploadCase.aspx">添加档案</a>
    </div>
</asp:Content>
