<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SetQuestion.ascx.cs" Inherits="XYECOM.Web.Other.UserContorl.SetQuestion" %>
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
            设置密码提示问题及答案</h2>
        <div class="rhr">
        </div>
        <!--列表 start-->
        <div id="baseinfo">
            <table class="basetb">
                <tbody>
                    <tr>
                        <td class="info_lei3" style="width: 40%; text-align: right;">
                            提示问题：
                        </td>
                        <td style="color: #999" class="info_lei2">
                            <asp:TextBox ID="txtQuestion" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtQuestion" Display="Dynamic" ErrorMessage="提示问题必填！"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="info_lei3" style="width: 40%; text-align: right;">
                            答案：
                        </td>
                        <td style="color: #999" class="info_lei2">
                            <asp:TextBox ID="txtAnswer" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtAnswer" Display="Dynamic" ErrorMessage="提示答案必填！"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div style="text-align: center; width: 812px; margin-bottom: 20px; height: 47px;
            padding-top: 18px">
            <asp:HiddenField ID="hidUserId" runat="server" />
            <asp:Button ID="btnOk" CssClass="btnok" runat="server" Text="确定" OnClick="btnOk_Click" />
            <input type="button" id="btnBack" class="btnok" value="返回" onclick="javascript:history.back();" />
        </div>
    </div>
    <!--rightzqlist end-->
</div>