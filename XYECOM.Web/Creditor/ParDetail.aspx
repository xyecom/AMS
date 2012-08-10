<%@ Page Title="" Language="C#" MasterPageFile="~/Creditor/Creditor.master" AutoEventWireup="true"
    CodeBehind="ParDetail.aspx.cs" Inherits="XYECOM.Web.Creditor.ParDetail" %>

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
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <div id="right">
        <!--rightpart start-->
        <div id="rightpart">
            <h2>
                查看部门详情</h2>
            <div class="rhr">
            </div>
            <div id="Div1">
                <div style="margin-top: 10px; width: 50%; float: left; height: 20px; font-size: 13px;
                    font-weight: bold">
                    【部门登录账号设置】</div>
                <table class="basetb">
                    <tbody>
                        <tr>
                            <td class="info_lei3">
                                登录名：
                            </td>
                            <td style="color: #999" class="info_lei2" colspan="3">
                                <asp:Label runat="server" ID="labLoginName"></asp:Label>
                            </td>
                            <td class="info_lei3">
                                初始密码为：000000,添加成功后，请通知相关人员修改密码。
                            </td>
                            <td class="info_lei2">
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <!--列表 start-->
            <div id="baseinfo">
                <div style="margin-top: 10px; width: 50%; float: left; height: 20px; font-size: 13px;
                    font-weight: bold">
                    【部门基本情况】</div>
                <table class="basetb">
                    <tbody>
                        <tr>
                            <td class="info_lei3">
                                部门名称：
                            </td>
                            <td style="color: #999" class="info_lei2">
                                <asp:Label runat="server" ID="labPartName"></asp:Label>
                            </td>
                            <td class="info_lei3">
                                负责人E-Mail：
                            </td>
                            <td class="info_lei2">
                                <asp:Label runat="server" ID="labEmail"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="info_lei3">
                                所在地区：
                            </td>
                            <td style="color: #999" class="info_lei2">
                                <asp:Label ID="lblArea" runat="server" Text=""></asp:Label>
                            </td>
                            <td class="info_lei3">
                                部门负责人：
                            </td>
                            <td style="color: #999" class="info_lei2">
                                <asp:Label runat="server" ID="labPartManagerName"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="info_lei3">
                                部门联系电话：
                            </td>
                            <td class="info_lei2">
                                <asp:Label runat="server" ID="labPartManagerTel"></asp:Label>
                            </td>
                            <td class="info_lei3">
                                负责人联系电话：
                            </td>
                            <td class="info_lei2">
                                <asp:Label runat="server" ID="labLinkManTel"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="info_lei3">
                                其他联系方式：
                            </td>
                            <td class="info_lei2" colspan="3">
                                <asp:Label runat="server" ID="labOtherContact"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="info_lei3">
                                公司具体地址：
                            </td>
                            <td class="info_lei2" colspan="3">
                                <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <!--列表 end-->
            <div style="margin-top: 10px; width: 50%; float: left; height: 20px; font-size: 13px;
                font-weight: bold">
                【部门描述】</div>
            <table class="basetb">
                <tbody>
                    <tr>
                        <td class="info_lei3">
                            &nbsp;&nbsp;&nbsp; 部门介绍：
                        </td>
                        <td class="info_lei2">
                            <asp:Label ID="labDescription" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
            <div style="text-align: center; width: 812px; margin-bottom: 20px; height: 47px;
                padding-top: 18px">
                <asp:HiddenField ID="hidPartId" runat="server" />
                <input type="button" value="返 回" onclick="javascript:history.back();" style="background: url(../Other/images/no.gif);
                    color: Black; width: 80px; height: 25px; border: none; cursor: pointer; color: #FFF" />
            </div>
        </div>
        <!--rightpart end-->
    </div>
</asp:Content>
