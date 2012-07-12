<%@ Page Title="" Language="C#" MasterPageFile="~/Creditor/Creditor.master" AutoEventWireup="true"
    CodeBehind="UpdateForeclosed.aspx.cs" Inherits="XYECOM.Web.Creditor.UpdateForeclosed" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
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
                        <asp:TextBox runat="server" ID="txtLinePrice"></asp:TextBox><span>元</span>
                    </td>
                </tr>
                <tr>
                    <td class="info1">
                        地区：
                    </td>
                    <td>
                        <div id="divArea">
                        </div>
                        <input type="hidden" id="areaid" name="areaid" runat="server" />
                        <script type="text/javascript">
                            var cla = new ClassType("cla", 'area', 'divArea', '<%=areaid.ClientID %>');
                            cla.Mode = "select";
                            cla.Init();
                        </script>
                    </td>
                    <td class="info1">
                        物品类型：
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="droTypeName" Width="135px">
                            <asp:ListItem Value="房屋" Text="房屋"></asp:ListItem>
                            <asp:ListItem Value="汽车" Text="汽车"></asp:ListItem>
                            <asp:ListItem Value="金条" Text="金条"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="info1">
                        详细地址：
                    </td>
                    <td colspan="3">
                        <asp:TextBox runat="server" ID="txtAddress"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="info1">
                        结束竞拍时间：
                    </td>
                    <td colspan="3">
                        <input id="endDate" runat="server" size="10" type="text" readonly="readonly" onclick="getDateString(this);" />
                    </td>
                </tr>
                <tr>
                    <td class="info1">
                        物品详细描述：
                    </td>
                    <td colspan="3">
                        <FCKeditorV2:FCKeditor ID="fckDescription" runat="server" BasePath="/Common/fckeditor/"
                            ToolbarSet="News" Height="200px">
                        </FCKeditorV2:FCKeditor>
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
                    &nbsp;<XYECOM:UploadImage ID="supplyImages" runat="server" Iswatermark="false" MaxAmount="3"
                        TableName="i_supply" IsCreateThumbnailImg="true" />
            </div>
        </div>
        <!--rightzqmain end-->
        <div style="width: 812px; height: 40px; line-height: 40px; text-align: center">
            <%--  <input type="button" value="确 定" style="background: url(../images/yes.gif); width: 80px;
                height: 25px; border: none; cursor: pointer; color: #FFF" />--%>
            <asp:Button runat="server" ID="btnOK" Width="80px" Height="25px" Text="确定" OnClick="btnOK_Click" />
        </div>
        <input type="hidden" id="hiddID" runat="server" />
    </div>
    <!--right end-->
</asp:Content>
