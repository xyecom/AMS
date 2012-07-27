<%@ Page Title="" Language="C#" MasterPageFile="~/Creditor/Creditor.master" AutoEventWireup="true"
    CodeBehind="AddForeclosed.aspx.cs" Inherits="XYECOM.Web.Creditor.AddForeclosed" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <title>添加抵债物品</title>
    <script language="javascript" type="text/javascript" src="/Other/js/ForeUploadControl.js"></script>
    <script type="text/javascript" language="javascript">
        function checkAredId() {
            var areaId = $('#<%=areaid.ClientID %>').val();
            if (areaId == 0) {
                $("#spAreaMessage").html("请选择地区");
                return false;
            }
            else {
                $("#spAreaMessage").html("");
                return true;
            }
        }
    </script>
    <style type="text/css">
        .upload_bg
        {
            position: absolute;
            background-color: #000;
            margin: auto;
            left: 0;
            top: 0;
            display: none;
            z-index: 30;
            filter: Alpha(opacity=30); /* IE */
            -moz-opacity: 0.3; /* Moz + FF */
            opacity: 0.3; /* CSS3*/
        }
        
        .upload_frm
        {
            position: absolute;
            display: none;
            z-index: 40;
        }
        
        .upload_fileitem
        {
            padding: 5px;
            margin-left: 5px;
            float: left;
            text-align: center;
            border: solid 1px #eee;
        }
        .upload_fileitem ul
        {
        }
        .upload_fileitem li
        {
        }
        .Upload_img
        {
        }
        a.Upload_btn:link
        {
        }
        
        
        .upload_fileitem_byfile
        {
            width: 80%;
            float: left;
            text-align: center;
        }
        .Upload_File
        {
            width: 100%;
        }
        .Upload_File li
        {
            height: 22px;
            line-height: 22px;
            text-align: left;
            margin-top: 5px;
            border: solid 1px #eee;
            padding: 5px;
            background-color: #f8f8f8;
        }
        .Upload_File li em
        {
            float: left;
        }
        .Upload_File li span
        {
            float: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <!--right start-->
    <div id="right">
        <!--rightzqmain start-->
        <div id="rightzqmain">
            <h2>
                添加抵债信息</h2>
            <div class="rhr">
            </div>
            <!--基本信息 start-->
            【物品基本信息】
            <hr />
            <table class="dzbasetb">
                <tr>
                    <td class="info1">
                        <span style="color: Red">*</span> 名称：
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtTitle" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtTitle"
                            ErrorMessage="名称不能为空"></asp:RequiredFieldValidator>
                    </td>
                    <td class="info1">
                        <span style="color: Red">*</span>拍卖底价：
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtLinePrice"></asp:TextBox><span>元</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLinePrice"
                            ErrorMessage="拍卖底价不能为空"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="info1">
                        地区：
                    </td>
                    <td>
                        <div id="divArea">
                        </div>
                        <input type="hidden" id="areaid" name="areaid" runat="server" /><span id="spAreaMessage"
                            style="color: Red"></span>
                        <script type="text/javascript">
                            var cla = new ClassType("cla", 'area', 'divArea', '<%=areaid.ClientID %>', 1);
                            cla.Mode = "select";
                            cla.Init();
                        </script>
                    </td>
                    <td class="info1">
                        <span style="color: Red">*</span>物品类型：
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
                        <asp:TextBox runat="server" ID="txtAddress" Width="100%" MaxLength="25"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="info1">
                        <span style="color: Red">*</span>结束竞拍时间：
                    </td>
                    <td colspan="3">
                        <input id="endDate" style="width: 120px" runat="server" size="10" type="text" readonly="readonly"
                            onclick="getDateString(this);" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="endDate"
                            ErrorMessage="结束竞拍时间不能为空"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="info1">
                        物品详细描述：
                    </td>
                    <td colspan="3">
                        <asp:TextBox runat="server" ID="txtDescription" Width="100%" TextMode="MultiLine"
                            Rows="15"></asp:TextBox>
                    </td>
                </tr>
            </table>
            【物品相关图片】
            <hr />
            <div id="dzbasepic">
                <div id="picshow">
                </div>
                <p>
                    图片：
                </p>
                <div id="baseinfo">
                    <p>
                        <XYECOM:UploadImage ID="udForeclosedInfo" runat="server" Iswatermark="false" MaxAmount="3"
                            TableName="ForeclosedInfo" IsCreateThumbnailImg="false" />
                    </p>
                </div>
            </div>
        </div>
        <!--rightzqmain end-->
        <div style="width: 812px; height: 40px; line-height: 40px; text-align: center">
            <%--  <input type="button" value="确 定" style="background: url(../images/yes.gif); width: 80px;
                height: 25px; border: none; cursor: pointer; color: #FFF" />--%>
            <asp:Button runat="server" ID="btnOK" Width="80px" Height="25px" Text="确定" OnClick="btnOK_Click"
                OnClientClick="if(!checkAredId()) return true" />
            <input type="button" value="返回" onclick="javascript:history.back();" />
        </div>
    </div>
    <!--right end-->
</asp:Content>
