<%@ Page Title="" Language="C#" MasterPageFile="~/Creditor/Creditor.master" AutoEventWireup="true"
    CodeBehind="EditPartInfo.aspx.cs" Inherits="XYECOM.Web.Creditor.EditPartInfo" %>

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
                添加部门</h2>
            <div class="rhr">
            </div>
            <div id="Div1">
                <div style="margin-top: 10px; width: 50%; float: left; height: 20px; font-size: 13px;
                    font-weight: bold">
                    【部门登陆账号设置】</div>
                <table class="basetb">
                    <tbody>
                        <tr>
                            <td class="info_lei3">
                                登陆名：
                            </td>
                            <td style="color: #999" class="info_lei2" colspan="3">
                                <asp:TextBox ID="txtLoginName" runat="server"></asp:TextBox>
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
                                <asp:TextBox ID="txtPartName" runat="server"></asp:TextBox>
                            </td>
                            <td class="info_lei3">
                                负责人E-Mail：
                            </td>
                            <td class="info_lei2">
                                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
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
                                <asp:TextBox ID="txtPartManagerName" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="info_lei3">
                                部门联系电话：
                            </td>
                            <td class="info_lei2">
                                <asp:TextBox ID="txtPartManagerTel" runat="server"></asp:TextBox>
                            </td>
                            <td class="info_lei3">
                                负责人联系电话：
                            </td>
                            <td class="info_lei2">
                                <asp:TextBox ID="txtLinkManTel" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="info_lei3">
                                其他联系方式：
                            </td>
                            <td class="info_lei2" colspan="3">
                                <asp:TextBox ID="txtOtherContact" runat="server"></asp:TextBox>
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
                            <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Columns="50"
                                Rows="5"></asp:TextBox>
                        </td>
                    </tr>
                </tbody>
            </table>
            <div style="text-align: center; width: 812px; margin-bottom: 20px; height: 47px;
                padding-top: 18px">
                <asp:HiddenField ID="hidPartId" runat="server" />
                <asp:Button ID="btnOK" runat="server" Text="确 定" CssClass="btnok" OnClick="btnOK_Click" />
            </div>
        </div>
        <!--rightpart end-->
    </div>
</asp:Content>
