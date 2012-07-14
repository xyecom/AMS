<%@ Page Title="" Language="C#" MasterPageFile="~/Server/Server.master" AutoEventWireup="true"
    CodeBehind="BaseEdit.aspx.cs" Inherits="XYECOM.Web.Server.BaseEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .btnok
        {
            border-bottom: medium none;
            border-left: medium none;
            width: 80px;
            background: url(/Other/images/yes.gif);
            height: 25px;
            color: #fff;
            border-top: medium none;
            cursor: pointer;
            border-right: medium none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div id="right">
        <!--rightzqlist start-->
        <div id="rightzqlist">
            <h2>
                基本资料修改</h2>
            <div class="rhr">
            </div>
            <!--列表 start-->
            <div id="baseinfo">
                <table class="basetb">
                    <tbody>
                        <tr>
                            <td class="info_lei3">
                                用户名：
                            </td>
                            <td style="color: #999" class="info_lei2">
                                <asp:TextBox ID="txtUserName" Enabled="false" runat="server"></asp:TextBox>
                            </td>
                            <td class="info_lei3">
                                E-Mail：
                            </td>
                            <td class="info_lei2">
                                <asp:TextBox ID="txtEmail" Enabled="false" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="info_lei3">
                                所在地区：
                            </td>
                            <td style="color: #999" class="info_lei2">
                                <asp:TextBox ID="txtArea" Enabled="false" runat="server"></asp:TextBox>
                            </td>
                            <td class="info_lei3">
                                律师姓名：
                            </td>
                            <td style="color: #999" class="info_lei2">
                                <asp:TextBox ID="txtLayerName" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="info_lei3">
                                联系电话：
                            </td>
                            <td class="info_lei2">
                                <asp:TextBox ID="txtTelphone" runat="server"></asp:TextBox>
                            </td>
                            <td class="info_lei3">
                                所在事务所：
                            </td>
                            <td class="info_lei2">
                                <asp:TextBox ID="txtCompanyName" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="info_lei3">
                                性别：
                            </td>
                            <td class="info_lei2">
                                <asp:DropDownList ID="ddlSex" runat="server">
                                    <asp:ListItem Text="男" Value="0" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="女" Value="1"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="info_lei3">
                                身份证：
                            </td>
                            <td class="info_lei2">
                                <asp:TextBox ID="txtIdNumber" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="info_lei3">
                                律师证：
                            </td>
                            <td class="info_lei2">
                                <asp:TextBox ID="txtLayerId" runat="server"></asp:TextBox>
                            </td>
                            <td class="info_lei3">
                                &nbsp;
                            </td>
                            <td class="info_lei2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="info_lei3">
                                其他联系方式：
                            </td>
                            <td class="info_lei2" colspan="3">
                                <asp:TextBox ID="txtOtherContact" runat="server" Width="532"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="info_lei3">
                                事务所地址：
                            </td>
                            <td class="info_lei2" colspan="3">
                                <asp:TextBox ID="txtAddress" runat="server" Width="532"></asp:TextBox>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <!--列表 end-->
            <h2>
                服务商基本描述</h2>
            <div class="rhr">
            </div>
            <table class="basetb">
                <tbody>
                    <tr>
                        <td class="info_lei3">
                            律师简介：
                        </td>
                        <td class="info_lei2">
                            <asp:TextBox ID="txtIntroduction" TextMode="MultiLine" Rows="5" Columns="50" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </tbody>
            </table>
            <div style="text-align: center; width: 812px; margin-bottom: 20px; height: 47px;
                padding-top: 18px">
                <asp:Button ID="btnOk" CssClass="btnok" runat="server" Text="确定" OnClick="btnOk_Click" />
            </div>
        </div>
        <!--rightzqlist end-->
    </div>
</asp:Content>
