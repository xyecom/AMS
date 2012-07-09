<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_news_NewsList" CodeBehind="NewsList.aspx.cs" %>

<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>���Ź����б�</title>
    <link href="../css/style.css" type="text/css" rel="Stylesheet" />
    <link href="/common/css/XYLib.css" type="text/css" rel="Stylesheet" />

    <script language="javascript" type="text/javascript" src="/common/js/base.js"></script>

    <script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>

    <script language="javascript" type="text/javascript" src="../javascript/list.js"></script>

    <script language="javascript" type="text/javascript" src="../Javascript/AddNews.js"></script>

    <script type="text/javascript" src="/common/js/date.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <a href="../index.aspx">��̨������ҳ</a> >> ��Ѷ�б�</h1>
    <table width="100%">
        <tr>
            <td class="right">
                <div class="main-setting">
                    <div class="itemtitle">
                        <h3>
                            ��Ѷ����</h3>
                        <ul class="tab1">
                            <li class="current"><a href="#"><span>������Ѷ</span></a></li>
                            <li><a href="ContributorList.aspx"><span>Ͷ����Ѷ</span></a></li>
                            <li><a href="ChargeNewsSetList.aspx"><span>�շ���Ѷ</span></a></li>
                        </ul>
                        <input type="button" class="addbtn" onclick="window.location.href='AddNews.aspx';"
                            value="������Ѷ" />
                    </div>
                    <table class="xy_tb xy_tb2" style="margin-top: 0px;">
                        <tr>
                            <td>
                                <table class="partition">
                                    <tr>
                                        <th>
                                            ����ؼ��֣�
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtkeyword" runat="server" CssClass="txt"></asp:TextBox>
                                        </td>
                                        <th>
                                            ��Ѷ���ߣ�
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtauthor" runat="server" CssClass="txt"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            ��Ѷ���ͣ�
                                        </th>
                                        <td>
                                            <asp:RadioButtonList ID="ddlType" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="0" Selected="True">����</asp:ListItem>
                                                <asp:ListItem Value="1">��ͨ����</asp:ListItem>
                                                <asp:ListItem Value="2">ͼƬ����</asp:ListItem>
                                                <asp:ListItem Value="3">��������</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <th>
                                            ���״̬��
                                        </th>
                                        <td>
                                            <asp:RadioButtonList ID="ddlState" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="-1" Selected="True">����</asp:ListItem>
                                                <asp:ListItem Value="AuditingState = 1">ͨ�����</asp:ListItem>
                                                <asp:ListItem Value="AuditingState = 0">δͨ�����</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            ��Ѷ������Ŀ��
                                            <input type="hidden" id="hidTypeId" name="hidTypeId" runat="server" />
                                            <input type="hidden" id="hidMoueleName" name="hidMoueleName" runat="server" value="news" />
                                        </th>
                                        
                                        <td id="classType">
                                        </td>

                                        <script type="text/javascript">
                                            var cla = new ClassType("cla",'hidMoueleName','classType','hidTypeId');
                                            cla.Mode ="select";
                                            cla.Init();
                                        </script>
                                        
                                        <%--    <asp:DropDownList ID="ddcolumn" runat="server" CssClass="dropdownlist" Width="100px">
                                            </asp:DropDownList>
                                        --%>
                                        
                                        <th>
                                            ���ͣ�
                                        </th>
                                        <td>
                                            <asp:CheckBox ID="cbIsFlag" runat="server" Text=" �Ƽ�" />&nbsp;
                                            <asp:CheckBox ID="cbIsDiscuss" runat="server" Text=" ��������" />&nbsp;
                                            <asp:CheckBox ID="cbIsTop" runat="server" Text=" ͷ��" />&nbsp;
                                            <asp:CheckBox ID="cbIsHot" runat="server" Text=" �ȵ�" />&nbsp;
                                            <asp:CheckBox ID="cbIsSlide" runat="server" Text="�õ�" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            ��Ѷ�ؼ��֣�
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtnewskeywords" runat="server" CssClass="input_s"></asp:TextBox>
                                        </td>
                                        <th>
                                            ������ڣ�
                                        </th>
                                        <td>
                                            <input id="bgdate" type="text" runat="server" readonly="readonly" onclick="getDateString(this);" maxlength="10"
                                                style="width: 80px;" />
                                            ��
                                            <input id="egdate" type="text" runat="server" readonly="readonly" onclick="getDateString(this);" maxlength="10"
                                                style="width: 80px;" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            ÿҳ������
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtPageSize" runat="server" CssClass="" Columns="2" Text="20" MaxLength="3"></asp:TextBox>
                                            ��(1~100)
                                            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtPageSize"
                                                ErrorMessage="����1��100֮��" MaximumValue="100" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                                        </td>
                                        <th>
                                            <input type="hidden" id="ddlprotype" name="ddlprotype" runat="server" />
                                            <input type="hidden" id="offerName" name="offerName" runat="server" value="offer" />��Ʒ���
                                        </th>
                                        <%--<td>
                                            <asp:DropDownList ID="ddlprotype" runat="server" CssClass="dropdownlist">
                                            </asp:DropDownList>
                                        </td>--%>
                                        <td id="offerType">
                                        </td>

                                        <script type="text/javascript">
                                            var cla = new ClassType("cla",'offerName','offerType','ddlprotype');
                                            cla.Mode ="select";
                                            cla.Init();
                                        </script>
                                    </tr>
                                    <tr>
                                        <th>
                                            �����ˣ�
                                        </th>
                                        <td>
                                            <asp:DropDownList ID="ddlPromulgator" runat="server" CssClass="dropdownlist" Width="100px">
                                            </asp:DropDownList>
                                        </td>
                                        <th>
                                        </th>
                                        <td>
                                            <asp:CheckBox runat="server" ID="cbdays" Checked="true" />
                                            �������&nbsp;<asp:TextBox runat="server" CssClass="" ID="txtdays" Columns="2" Text="2"></asp:TextBox>&nbsp;���ȫ������
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtdays"
                                                ErrorMessage="����Ϊ����" ValidationExpression="^[1-9]\d*$"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                        </th>
                                        <td colspan="3">
                                            <asp:Button ID="btnFind" runat="server" CssClass="button" Text="����" OnClick="btnFind_Click" />
                                            <input type="reset" value="����" class="button" />
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gvlist" HeaderStyle-CssClass="gv_header_style" Width="100%" runat="server"
                                    AutoGenerateColumns="False" DataKeyNames="NS_ID" GridLines="None" OnRowCommand="gvlist_RowCommand"
                                    OnRowDataBound="gvlist_RowDataBound">
                                    <Columns>
                                        <asp:BoundField Visible="False" DataField="NS_ID">
                                            <ItemStyle Width="0%" />
                                        </asp:BoundField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <input type="checkbox" id="chkExport" runat="server" value='<%# Eval("NS_ID")%>'>
                                            </ItemTemplate>
                                            <ItemStyle Width="4%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="���ű���">
                                            <ItemStyle Width="35%" CssClass="gvLeft" HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%#IsType(DataBinder.Eval(Container,"DataItem.NS_Type").ToString()) %>'></asp:Label>
                                                <a href="<%#GetHref(DataBinder.Eval(Container,"DataItem.NS_ID").ToString(),DataBinder.Eval(Container,"DataItem.NT_TempletFolderAddress").ToString()) %>"
                                                    target="_blank"><span style="<%# Eval("NS_TitleStyle") %>">
                                                        <%# Eval("NS_NewsName") %></span></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="��Ŀ">
                                            <ItemTemplate>
                                                <%#GetTitlsName(DataBinder.Eval(Container,"DataItem.NT_ID")) %>
                                            </ItemTemplate>
                                            <ItemStyle Width="14%" CssClass="gvLeft" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="��������">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container,"DataItem.NS_AddTime")).ToString("yy-MM-dd") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="10%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="����">
                                            <ItemStyle Width="5%" />
                                            <ItemTemplate>
                                                <a href='NewsDiscussList.aspx?NS_ID=<%# Eval("NS_ID") %>&backURL=<%# backURL2 %>'>�鿴</a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:ButtonField HeaderText="�Ƽ�" DataTextField="NS_IsCommand" CommandName="ChangeCommand" />
                                        <asp:ButtonField HeaderText="���" DataTextField="AuditingState" CommandName="ChangeAuditing">
                                            <ItemStyle Width="8%" />
                                        </asp:ButtonField>
                                        <asp:TemplateField HeaderText="�շ�">
                                            <ItemStyle Width="6%" />
                                            <ItemTemplate>
                                                <a href='ChargeNewsSetInfo.aspx?NS_ID=<%# Eval("NS_ID") %>&backURL=<%# backURL2 %>'>
                                                    <img src="../images/manage_base.GIF" alt="�����Ϊ�շ�����" /></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="�༭">
                                            <ItemStyle Width="5%" />
                                            <ItemTemplate>
                                                <a href='AddNews.aspx?id=<%# Eval("NS_ID") %>&backURL=<%# backURL %>'>
                                                    <img src="../images/edit.GIF" alt="�༭" /></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="��̬ҳ��">
                                            <ItemStyle CssClass="gvLeft" Width="8%" />
                                            <ItemTemplate>
                                                <%# Eval("NS_HTMLPage").ToString().Trim() != "" ? "<a href=\"/" + Eval("NS_HTMLPage").ToString() + "\" target=\"_black\">�鿴</a>" : "-"%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <p style="text-align: center">
                                    <asp:Label ID="lblMessage" runat="server" ForeColor="red"></asp:Label></p>
                            </td>
                        </tr>
                        <tr>
                            <td class="content_action">
                                <input id="chkAll" onclick="chkAll_true()" type="checkbox" name="chkAll" runat="server" />ȫѡ
                                <asp:Button ID="lnkDel" runat="server" CssClass="button" Text="ɾ��" OnClick="lnkDel_Click" />
                                <asp:Button ID="btnCreateHtml" runat="server" CssClass="button" OnClick="btnCreateHtml_Click"
                                    Text="���ɾ�̬ҳ" />&nbsp;
                                <asp:Button ID="btnDelHtml" runat="server" CssClass="button" OnClick="btnDelHtml_Click"
                                    Text="ɾ����̬ҳ" />
                                <asp:Button ID="btnSetChargeNews" runat="server" CssClass="button" OnClick="btnSetChargeNews_Click"
                                    Text="��Ϊ�շ�" />
                                <asp:Button ID="btnSetTitleStyle" runat="server" CssClass="button" Text="������ʾ" OnClick="btnSetTitleStyle_Click" />
                                <input type="button" runat="server" class="button" value="ѡ��ר��" onclick="ShowTopicPageForToTopioc()"
                                    id="btnSpecial" />
                                    
                                     <span id="productType"></span>
                                <input type="hidden" id="typeId" name="typeId" runat="server" />                                
                                <asp:Button ID="btnMove" CssClass="button" runat="server" Text="����ת��" OnClick="btnMove_Click" />
                           
                                <input type="hidden" id="hidTopicID" runat="server" />
                                <div id="topicnames">
                                </div>
                            </td>
                        </tr>
                    </table>
                    <uc2:page ID="page1" runat="server" />
                </div>
            </td>
        </tr>
    </table>
    </form>
        <script type="text/javascript">
                var cla2 = new ClassType("cla2",'hidMoueleName','productType','typeId');
                cla2.Mode ="select";
                cla2.Init();
    </script>
    <iframe id="SelTopicType" runat="server" frameborder="0" src="TopicTypeList.aspx?mode=list">
    </iframe>
    <div id='SelTopicType_bg'>
    </div>
</body>
</html>
