<%@ Page Title="" Language="C#" MasterPageFile="~/Creditor/Creditor.master" AutoEventWireup="true"
    CodeBehind="AddCreditInfo.aspx.cs" Inherits="XYECOM.Web.Creditor.AddCreditInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
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
                            <span style="color: Red">*</span>案件标题
                        </td>
                        <td colspan="3">
                            <asp:TextBox runat="server" ID="txtTitle" Width="600px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtTitle"
                                ErrorMessage="案件标题不能为空"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="info_lei3">
                            <span style="color: Red">*</span>欠款人姓名
                        </td>
                        <td class="info_lei2">
                            <asp:TextBox runat="server" ID="txtDebtorName"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDebtorName"
                                ErrorMessage="欠款人姓名不能为空"></asp:RequiredFieldValidator>
                        </td>
                        <td class="info_lei3">
                            <span style="color: Red">*</span>欠款人手机
                        </td>
                        <td class="info_lei2">
                            <asp:TextBox runat="server" ID="txtDebtorTelpone"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDebtorTelpone"
                                ErrorMessage="欠款人联系电话不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtDebtorTelpone"
                                ErrorMessage="手机号码格式不正确" ValidationExpression="\s*((\d{2,3}-){0,1}\d{11})\s*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="info_lei3">
                            <span style="color: Red">*</span>欠款金额
                        </td>
                        <td class="info_lei2">
                            <asp:TextBox runat="server" ID="txtArrears"></asp:TextBox>元
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtArrears"
                                ErrorMessage="欠款金额不能为空"></asp:RequiredFieldValidator>
                        </td>
                        <td class="info_lei3">
                            <span style="color: Red">*</span>悬赏金额
                        </td>
                        <td class="info_lei2">
                            <asp:TextBox runat="server" ID="txtBounty"></asp:TextBox>元
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtBounty"
                                ErrorMessage="悬赏金额不能为空"></asp:RequiredFieldValidator>
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
                            <span style="color: Red">*</span>欠款原因
                        </td>
                        <td colspan="3">
                            <asp:TextBox runat="server" ID="txtDebtorReason" Width="600px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDebtorReason"
                                ErrorMessage="欠款原因不能为空"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="info_lei3">
                            <span style="color: Red">*</span>催收期限
                        </td>
                        <td class="info_lei2">
                            <asp:TextBox runat="server" ID="txtCollectionPeriod"></asp:TextBox>天
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCollectionPeriod"
                                ErrorMessage="催收期限不能为空"></asp:RequiredFieldValidator>
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
                            <span style="color: Red">*</span>案情简介
                        </td>
                        <td colspan="3">
                            <asp:TextBox runat="server" ID="txtIntroduction" TextMode="MultiLine" Width="100%"
                                Rows="10"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtIntroduction"
                                ErrorMessage="案情简介不能为空"></asp:RequiredFieldValidator>
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
                            <span style="color: Red">*</span>债龄
                        </td>
                        <td class="info_lei2">
                            <asp:TextBox runat="server" ID="txtAge"></asp:TextBox>天
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtAge"
                                ErrorMessage="债龄不能为空"></asp:RequiredFieldValidator>
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
                <div style="width: 756px; height: 50px; line-height: 50px; text-align: center">
                    <%--                    <input type="button" value="确 定" style="background: url(../images/yes.gif); width: 80px;
                        height: 25px; border: none; cursor: pointer; color: #FFF" />--%>
                    <asp:Button runat="server" ID="btnOk" OnClick="btnOk_Click" Text="确定" />
                    <input type="button" value="返回" onclick="javascript:history.back();" />
                </div>
            </div>
        </div>
        <div>
            <p></p>
        </div>
        <div>
            <div id="divtitle">
            </div>
            <input id="hdgetid" type="text" />
            <input id="ttt" type="hidden" />
            <script type="text/javascript">
                var cla = new ClassTypes("cla", 'ttt', 'divtitle', 'hdgetid', 5, '<%=this.userinfo.IsPrimary?"and CompanyId="+userinfo.CompanyId:"and userid="+userinfo.userid %>', "xy018");
                cla.Init();
            </script>
        </div>
        <!--rightzqmain end-->
    </div>
    <!--right end-->
</asp:Content>
