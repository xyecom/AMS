<%@ Page Title="" Language="C#" MasterPageFile="~/Creditor/Creditor.master" AutoEventWireup="true"
    CodeBehind="UpdateCreditInfo.aspx.cs" Inherits="XYECOM.Web.Creditor.UpdateCreditInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <title>修改债权资料</title>
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
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
             width:100px; height:95px;
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
        #divtitle h2
        {
            width: 100px;
            margin: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <!--right start-->
    <div id="right">
        <!--rightzqmain start-->
        <div id="rightzqmain">
            <h2>
                修改债权资料</h2>
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
                            <asp:TextBox runat="server" ID="txtTitle" Width="538px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtTitle"
                                ErrorMessage="*" ForeColor="Red" Font-Size="12pt"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="info_lei3">
                            欠款人姓名
                        </td>
                        <td class="info_lei2">
                            <asp:TextBox runat="server" ID="txtDebtorName"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDebtorName"
                                ErrorMessage="*" ForeColor="Red" Font-Size="12pt"></asp:RequiredFieldValidator>
                        </td>
                        <td class="info_lei3">
                            欠款人电话
                        </td>
                        <td class="info_lei2">
                            <asp:TextBox runat="server" ID="txtDebtorTelpone"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDebtorTelpone"
                                ErrorMessage="*" ForeColor="Red" Font-Size="12pt"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtDebtorTelpone"
                                ErrorMessage="*" ValidationExpression="\s*((\d{2,3}-){0,1}\d{11})\s*"
                                ForeColor="Red" Font-Size="12pt"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="info_lei3">
                            欠款金额
                        </td>
                        <td class="info_lei2">
                            <asp:TextBox runat="server" ID="txtArrears"></asp:TextBox>元<asp:RequiredFieldValidator
                                ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtArrears" ErrorMessage="*"
                                ForeColor="Red" Font-Size="12pt"></asp:RequiredFieldValidator>
                        </td>
                        <td class="info_lei3">
                            悬赏金额
                        </td>
                        <td class="info_lei2">
                            <asp:TextBox runat="server" ID="txtBounty"></asp:TextBox>元<asp:RequiredFieldValidator
                                ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtBounty" ErrorMessage="*"
                                ForeColor="Red" Font-Size="12pt"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="info_lei3">
                            授权类型
                        </td>
                        <td class="info_lei2">
                            <asp:RadioButtonList runat="server" ID="rdLicenseType" RepeatDirection="Horizontal">
                                <asp:ListItem Value="全部授权">全部授权</asp:ListItem>
                                <asp:ListItem Value="部分授权">部分授权</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td class="info_lei3">
                            欠款类型
                        </td>
                        <td class="info_lei2">
                            <asp:RadioButtonList runat="server" ID="rdDebtorType" RepeatDirection="Horizontal">
                                <asp:ListItem Value="货款逾期">货款逾期</asp:ListItem>
                                <asp:ListItem Value="商业纠纷">商业纠纷</asp:ListItem>
                                <asp:ListItem Value="其他类型">其他类型</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="info_lei3">
                            欠款原因
                        </td>
                        <td colspan="3">
                            <asp:TextBox runat="server" ID="txtDebtorReason" Width="538px"></asp:TextBox><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDebtorReason"
                                ErrorMessage="*" ForeColor="Red" Font-Size="12pt"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="info_lei3">
                            催收期限
                        </td>
                        <td class="info_lei2">
                            <asp:TextBox runat="server" ID="txtCollectionPeriod"></asp:TextBox>天<asp:RequiredFieldValidator
                                ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCollectionPeriod"
                                ErrorMessage="*" ForeColor="Red" Font-Size="12pt"></asp:RequiredFieldValidator>
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
                            <input type="hidden" id="areaid" name="areaid" runat="server" /><span id="spAreaMessage"
                                style="color: Red"></span>
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
                            <asp:TextBox runat="server" ID="txtIntroduction" Width="90%" Rows="5" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtIntroduction"
                                ErrorMessage="*" ForeColor="Red" Font-Size="12pt"></asp:RequiredFieldValidator>
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
                                <asp:ListItem Value="其他凭证">其他凭证</asp:ListItem>
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                    <tr>
                        <td class="info_lei3">
                            图片上传
                        </td>
                        <td colspan="3"  style="width:615px; height:auto">
                            <XYECOM:UploadImage ID="udCreditInfo" runat="server" Iswatermark="false" MaxAmount="20"
                                TableName="CreditInfo" IsCreateThumbnailImg="false" />
                        </td>
                    </tr>
                    <tr>
                        <td class="info_lei3">
                            档案选择：
                        </td>
                        <td class="info_lei2">
                           <input type="radio" name="case" value="1" id="remo" onclick="document.getElementById('loc').style.display='none';document.getElementById('remote').style.display='';" 
                                checked="checked" />档案库选择
                            <input type="radio" name="case" value="0" id="locat" onclick="document.getElementById('loc').style.display='';document.getElementById('remote').style.display='none';" />从本地上传
                        </td>
                        <td class="info_lei2" colspan="2">
                            <div id="loc" style="display: none;">
                                <p>
                                    从本地上传资料</p>
                                选择文件:
                                <asp:FileUpload ID="flCase" runat="server" />
                            </div>
                            <div id="remote">
                                <p>
                                    从档案库选择资料</p>
                                <div id="divtitle">
                                </div>
                                <input id="hdgetid" type="hidden" runat="server" />
                                <input id="ttt" type="hidden" />
                                <script type="text/javascript">
                                    var cla = new ClassTypes("cla", 'ttt', 'divtitle', '<%=hdgetid.ClientID %>', 5, '<%=this.userinfo.IsPrimary?"and CompanyId="+userinfo.CompanyId:"and userid="+userinfo.userid %>', "xy018");
                                    cla.Init();
                                </script>
                            </div>
                        </td>
                    </tr>
                </table>
                <div style="width: 756px; height: 40px; line-height: 40px; text-align: center">
                    <table style="width: 600px; text-align: center">
                        <tr>
                            <td align="center" colspan="2">
                                <asp:RadioButtonList runat="server" ID="radSelect" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="发布">直接对外发布</asp:ListItem>
                                    <asp:ListItem Value="草稿" Selected="True">存为债权草稿</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="width: 756px; height: 50px; line-height: 50px; text-align: center">
                    <asp:Button runat="server" ID="btnOk" OnClick="btnOK_Click" Text="确 定" OnClientClick="if(!checkAredId()) return true"   Style="background: url(../Other/images/yes.gif);    width: 80px; height: 25px;  border: none;
                        cursor: pointer; color: #FFF"/>
                    <input type="button" value="返 回" onclick="javascript:history.back();"style="background: url(../Other/images/no.gif);
                        color: Black;   width: 80px; height: 25px; border: none; cursor: pointer; color: #FFF" />
                    <input type="hidden" id="hiddID" runat="server" />
                </div>
            </div>
        </div>
        <!--rightzqmain end-->
    </div>
    <!--right end-->
</asp:Content>
