<%@ Page Title="" Language="C#" MasterPageFile="~/Creditor/Creditor.master" AutoEventWireup="true"
    CodeBehind="UpdateCreditInfo.aspx.cs" Inherits="XYECOM.Web.Creditor.UpdateCreditInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript" src="/Other/js/ForeUploadControl.js"></script>
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
                添加债权资料</h2>
            <div class="rhr">
            </div>
            <!--基本信息 start-->
            <div class="divtext">
                <div style="text-align: center; margin-top: 5px">
                    <h4>
                        债务基本资料</h4>
                </div>
                <table style="margin-top: 2px;" class="tab">
                    <tr>
                        <td class="info_lei3">
                            <span class="red">*</span>案件标题
                        </td>
                        <td colspan="3">
                            <asp:TextBox runat="server" ID="txtTitle" Width="600px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="info_lei3">
                            欠款人姓名
                        </td>
                        <td class="info_lei2">
                            <asp:TextBox runat="server" ID="txtDebtorName"></asp:TextBox>
                        </td>
                        <td class="info_lei3">
                            欠款人联系电话
                        </td>
                        <td class="info_lei2">
                            <asp:TextBox runat="server" ID="txtDebtorTelpone"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="info_lei3">
                            欠款金额
                        </td>
                        <td class="info_lei2">
                            <asp:TextBox runat="server" ID="txtArrears"></asp:TextBox>元
                        </td>
                        <td class="info_lei3">
                            悬赏金额
                        </td>
                        <td class="info_lei2">
                            <asp:TextBox runat="server" ID="txtBounty"></asp:TextBox>元
                        </td>
                    </tr>
                    <tr>
                        <td class="info_lei3">
                            授权类型
                        </td>
                        <td class="info_lei2">
                            <asp:TextBox runat="server" ID="txtLicenseType"></asp:TextBox>
                        </td>
                        <td class="info_lei3">
                            欠款类型
                        </td>
                        <td class="info_lei2">
                            <asp:TextBox runat="server" ID="txtDebtorType"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="info_lei3">
                            欠款原因
                        </td>
                        <td colspan="3">
                            <asp:TextBox runat="server" ID="txtDebtorReason" Width="600px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="info_lei3">
                            催收期限
                        </td>
                        <td class="info_lei2">
                            <asp:TextBox runat="server" ID="txtCollectionPeriod"></asp:TextBox>天
                        </td>
                        <td class="info_lei3">
                            备注
                        </td>
                        <td class="info_lei2">
                            <asp:TextBox runat="server" ID="txtRemark"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="info_lei3">
                            案件所在地
                        </td>
                        <td class="info_lei2">
                            <div id="divArea">
                            </div>
                            <input type="hidden" id="areaid" name="areaid" runat="server" />
                            <script type="text/javascript">
                                var cla = new ClassType("cla", 'area', 'divArea', '<%=areaid.ClientID %>', 1);
                                cla.Mode = "select";
                                cla.Init();
                            </script>
                        </td>
                    </tr>
                    <tr>
                        <td class="info_lei3">
                            案情简介
                        </td>
                        <td colspan="3">
                            <asp:TextBox runat="server" ID="txtIntroduction" Width="100%" Rows="10"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <div style="text-align: center; margin-top: 5px;">
                    <h4>
                        债务催收情况</h4>
                </div>
                <table style="margin-top: 1px;" class="tab">
                    <tr>
                        <td class="info_lei3">
                            账龄
                        </td>
                        <td class="info_lei2">
                            <asp:TextBox runat="server" ID="txtAge"></asp:TextBox>天
                        </td>
                        <td class="info_lei3">
                            是否在诉讼期
                        </td>
                        <td class="info_lei2">
                            <asp:RadioButtonList runat="server" ID="radIsInLitigation" RepeatDirection="Horizontal">
                                <asp:ListItem Value="1">是</asp:ListItem>
                                <asp:ListItem Value="0">否</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="info_lei3">
                            是否经过诉讼
                        </td>
                        <td class="info_lei2">
                            <asp:RadioButtonList runat="server" ID="radIsLitigationed" RepeatDirection="Horizontal">
                                <asp:ListItem Value="1">是</asp:ListItem>
                                <asp:ListItem Value="0">否</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td class="info_lei3">
                            是否自行催收过
                        </td>
                        <td class="info_lei2">
                            <asp:RadioButtonList runat="server" ID="radIsSelfCollection" RepeatDirection="Horizontal">
                                <asp:ListItem Value="1">是</asp:ListItem>
                                <asp:ListItem Value="0">否</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="info_lei3">
                            债务人债务确认
                        </td>
                        <td class="info_lei2">
                            <asp:RadioButtonList runat="server" ID="radIsConfirm" RepeatDirection="Horizontal">
                                <asp:ListItem Value="1">是</asp:ListItem>
                                <asp:ListItem Value="0">否</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td class="info_lei3">
                            债权凭证
                        </td>
                        <td class="info_lei2" colspan="3">
                            <asp:CheckBoxList runat="server" ID="cheDebtObligation" RepeatDirection="Horizontal">
                                <asp:ListItem Value="合同">合同</asp:ListItem>
                                <asp:ListItem Value="发票">发票</asp:ListItem>
                                <asp:ListItem Value="欠条">欠条</asp:ListItem>
                                <asp:ListItem Value="发票其他凭证">发票其他凭证</asp:ListItem>
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                </table>
                <div style="width: 756px; height: 40px; line-height: 40px; text-align: center">
                    <table style="width: 600px; text-align: center">
                        <tr>
                            <td align="center" colspan="2">
                                <asp:RadioButtonList runat="server" ID="radSelect" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="发布" Selected="True">直接对外发布</asp:ListItem>
                                    <asp:ListItem Value="草稿">存为债权草稿</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>
                </div>
                <div>
                    <p>
                        上传图片</p>
                    <div id="baseinfo">
                        <p>
                            <XYECOM:UploadImage ID="udCreditInfo" runat="server" Iswatermark="false" MaxAmount="3"
                                TableName="CreditInfo" IsCreateThumbnailImg="false" />
                        </p>
                    </div>
                </div>
                <%--<div>
                    <p>
                        从本地上传资料</p>
                </div>
                <div>
                    <p>
                        从档案库选择资料</p>
                    <div id="divtitle">
                    </div>
                    <input id="hdgetid" type="text" />
                    <input id="ttt" type="hidden" />
                    <script type="text/javascript">
                        var cla = new ClassTypes("cla", 'ttt', 'divtitle', 'hdgetid', 5, '<%=this.userinfo.IsPrimary?"and CompanyId="+userinfo.CompanyId:"and userid="+userinfo.userid %>', "xy018");
                        cla.Init();
                    </script>
                </div>--%>
                <div style="width: 756px; height: 50px; line-height: 50px; text-align: center">
                    <%--                    <input type="button" value="确 定" style="background: url(../images/yes.gif); width: 80px;
                        height: 25px; border: none; cursor: pointer; color: #FFF" />--%>
                    <asp:Button runat="server" ID="btnOk" OnClick="btnOK_Click" Text="确定" />
                    <input type="button" value="返回" onclick="javascript:history.back();" />
                    <input type="hidden" id="hiddID" runat="server" />
                </div>
            </div>
        </div>
        <!--rightzqmain end-->
    </div>
    <!--right end-->
</asp:Content>
