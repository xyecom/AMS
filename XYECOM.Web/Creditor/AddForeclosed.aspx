<%@ Page Title="" Language="C#" MasterPageFile="~/Creditor/Site1.Master" AutoEventWireup="true"
    CodeBehind="AddForeclosed.aspx.cs" Inherits="XYECOM.Web.Creditor.AddForeclosed" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--right start-->
    <div id="right">
        <!--rightzqmain start-->
        <div id="rightzqmain">
            <h2>
                添加抵债物品</h2>
            <div class="rhr">
            </div>
            <!--基本信息 start-->
            【物品基本信息】
            <hr />
            <table class="dzbasetb">
                <tr>
                    <td class="info1">
                        名称：
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtTitle"></asp:TextBox>
                    </td>
                    <td class="info1">
                        拍卖底价：
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtLinePrice"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="info1">
                        物品所在地：
                    </td>
                    <td colspan="3">
                        <input id="Text3" type="text" style="width: 550px" />
                    </td>
                </tr>
                <tr>
                    <td class="info1">
                        结束竞拍时间：
                    </td>
                    <td colspan="3">
                        <input id="Text4" type="text" />
                    </td>
                </tr>
            </table>
            【物品相关图片】
            <hr />
            <div id="dzbasepic">
                <div id="picshow">
                </div>
                <p>
                    选择图片：
                </p>
                <p>
                    <input type="file" size="20" onchange="upimg(this);" />
                </p>
                <p>
                    <input type="file" size="20" onchange="upimg(this);" />
                </p>
                <p>
                    <input type="file" size="20" onchange="upimg(this);" />
                </p>
            </div>
        </div>
        <!--rightzqmain end-->
        <div style="width: 812px; height: 40px; line-height: 40px; text-align: center">
            <input type="button" value="确 定" style="background: url(../images/yes.gif); width: 80px;
                height: 25px; border: none; cursor: pointer; color: #FFF" />
        </div>
    </div>
    <!--right end-->
</asp:Content>
