<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ModifyPwd.ascx.cs" Inherits="XYECOM.Web.Other.UserContorl.ModifyPwd" %>
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
<div id="right">
    <!--rightzqlist start-->
    <div id="rightzqlist">
        <h2>
            重设密码</h2>
        <div class="rhr">
        </div>
        <!--列表 start-->
        <div id="baseinfo">
            <table class="basetb">
                <tbody>
                    <tr>
                        <td class="info_lei3" style="width: 40%; text-align: right;">
                            旧密码：
                        </td>
                        <td style="color: #999" class="info_lei2">
                            <asp:TextBox ID="txtOldPwd" TextMode="Password" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtOldPwd" Display="Dynamic" ErrorMessage="旧密码必填！"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="info_lei3" style="width: 40%; text-align: right;">
                            新密码：
                        </td>
                        <td style="color: #999" class="info_lei2">
                            <asp:TextBox ID="txtNewPwd" TextMode="Password" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtNewPwd" Display="Dynamic" ErrorMessage="新密码为必填！"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="info_lei3" style="width: 40%; text-align: right;">
                            确认密码：
                        </td>
                        <td class="info_lei2">
                            <asp:TextBox ID="txtNewPwd1" TextMode="Password" runat="server"></asp:TextBox>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                ControlToCompare="txtNewPwd" ControlToValidate="txtNewPwd1" Display="Dynamic" 
                                ErrorMessage="密码不一致！"></asp:CompareValidator>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div style="text-align: center; width: 812px; margin-bottom: 20px; height: 47px;
            padding-top: 18px">
            <asp:Button ID="btnOk" CssClass="btnok" runat="server" Text="确定" OnClick="btnOk_Click" />
            <input type="button" id="btnBack" class="btnok" value="返回" onclick="javascript:history.back();" />
        </div>
    </div>
    <!--rightzqlist end-->
</div>
