<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_news_ChargeNewsSetList"
    CodeBehind="ChargeNewsSetList.aspx.cs" %>

<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>收费资讯设置信息管理</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/XYLib.css" type="text/css" rel="Stylesheet" />

    <script language="javascript" type="text/javascript" src="/common/js/base.js"></script>

    <script language="javascript" type="text/javascript" src="/common/js/date.js"></script>

    <script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>

    <script language="javascript" type="text/javascript" src="../javascript/list.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <a href="../index.aspx">后台管理首页</a> >>收费资讯管理</h1>
    <table width="100%">
        <tr>
            <td class="right">
                <div class="main-setting">
                    <div class="itemtitle">
                        <h3>
                            资讯管理</h3>
                        <ul class="tab1">
                            <li><a href="NewsList.aspx"><span>常规资讯</span></a></li>
                            <li><a href="ContributorList.aspx"><span>投稿资讯</span></a></li>
                            <li class="current"><a href="#"><span>收费资讯</span></a></li>
                        </ul>
                        <button id="lnkAdd" class="addbtn" onclick="location.href='AddNews.aspx';">
                            新增资讯</button>
                    </div>
                    <table class="xy_tb xy_tb2" style="margin-top: 0px;">
                        <tr>
                            <td>
                                <table class="partition">
                                    <tr>
                                        <th>
                                            标题关键字：
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtkeyword" runat="server" CssClass="input_s"></asp:TextBox>
                                        </td>
                                        <th>
                                            资讯作者：
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtauthor" runat="server" CssClass="input_s"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            资讯类型：
                                        </th>
                                        <td>
                                            <asp:RadioButtonList ID="ddlType" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="0" Selected="True">所有</asp:ListItem>
                                                <asp:ListItem Value="1">普通新闻</asp:ListItem>
                                                <asp:ListItem Value="2">图片新闻</asp:ListItem>
                                                <asp:ListItem Value="3">标题新闻</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <th>
                                            审核状态：
                                        </th>
                                        <td>
                                            <asp:RadioButtonList ID="ddlState" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="-1" Selected="True">所有</asp:ListItem>
                                                <asp:ListItem Value="AuditingState = 1">通过审核</asp:ListItem>
                                                <asp:ListItem Value="AuditingState = 0">未通过审核</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                         <th>
                                            资讯所属栏目：
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
                                        <th>
                                            类型：
                                        </th>
                                        <td>
                                            <asp:CheckBox ID="cbIsFlag" runat="server" Text=" 推荐" />&nbsp;
                                            <asp:CheckBox ID="cbIsDiscuss" runat="server" Text=" 允许评论" />&nbsp;
                                            <asp:CheckBox ID="cbIsTop" runat="server" Text=" 头条" />&nbsp;
                                            <asp:CheckBox ID="cbIsHot" runat="server" Text=" 热点" />&nbsp;
                                            <asp:CheckBox ID="cbIsSlide" runat="server" Text="幻灯" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            资讯关键字：
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtnewskeywords" runat="server" CssClass="input_s"></asp:TextBox>
                                        </td>
                                        <th>
                                            添加日期：
                                        </th>
                                        <td>
                                            <input id="bgdate" type="text" runat="server" readonly="readonly" onclick="getDateString(this);" maxlength="10"
                                                style="width: 80px;" />
                                            到
                                            <input id="egdate" type="text" runat="server" readonly="readonly" onclick="getDateString(this);" maxlength="10"
                                                style="width: 80px;" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            每页条数：
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtPageSize" runat="server" CssClass="" Columns="2" Text="20" MaxLength="3"></asp:TextBox>
                                            条(1~100)
                                            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtPageSize"
                                                ErrorMessage="介于1～100之间" MaximumValue="100" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                                        </td>
                                        <th>
                                        </th>
                                        <td>
                                            <asp:CheckBox runat="server" ID="cbdays" Checked="true" />
                                            返回最近&nbsp;<asp:TextBox runat="server" CssClass="" ID="txtdays" Columns="2" Text="2"></asp:TextBox>&nbsp;天的全部数据
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtdays"
                                                ErrorMessage="必须为数字" ValidationExpression="\d"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr class="content_action">
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnFind" runat="server" CssClass="button" Text="搜索" OnClick="btnFind_Click" />
                                            <input type="reset" value="重置" class="button" />
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
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
                                            <ItemStyle Width="5%" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="选择">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkExport" runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle Width="5%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="新闻标题">
                                            <ItemStyle Width="40%" CssClass="gvLeft" HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%#IsType(DataBinder.Eval(Container,"DataItem.NS_Type").ToString()) %>'></asp:Label>&nbsp;<a
                                                    href="<%#GetHref(DataBinder.Eval(Container,"DataItem.NS_ID").ToString(),DataBinder.Eval(Container,"DataItem.NT_TempletFolderAddress").ToString()) %>"
                                                    target="_blank"><%# Eval("NS_NewsName") %></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="栏目">
                                            <ItemTemplate>
                                                <%#GetTitlsName(DataBinder.Eval(Container,"DataItem.NT_ID")) %>
                                            </ItemTemplate>
                                            <ItemStyle Width="15%" CssClass="gvLeft" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="评论">
                                            <ItemStyle Width="5%" />
                                            <ItemTemplate>
                                                <a href='NewsDiscussList.aspx?NS_ID=<%# Eval("NS_ID") %>&backURL=<%# backURL2 %>'>查看</a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:ButtonField HeaderText="推荐" DataTextField="NS_IsCommand" CommandName="ChangeCommand" />
                                        <asp:ButtonField HeaderText="审核" DataTextField="AuditingState" CommandName="ChangeAuditing">
                                            <ItemStyle Width="10%" />
                                        </asp:ButtonField>
                                        <asp:TemplateField HeaderText="编辑">
                                            <ItemStyle Width="5%" />
                                            <ItemTemplate>
                                                <a href='AddNews.aspx?id=<%# Eval("NS_ID") %>&backURL=<%# backURL %>'>
                                                    <img src="../images/edit.GIF" alt="编辑" /></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="资费编辑">
                                            <ItemStyle Width="8%" />
                                            <ItemTemplate>
                                                <a href='ChargeNewsSetInfo.aspx?NS_ID=<%# Eval("NS_ID") %>&action=edit&backURL=<%# backURL2 %>'>
                                                    <img src="../images/manage_base.GIF" alt="点此设为收费新闻" /></a>
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
                                <input id="chkAll" onclick="chkAll_true()" type="checkbox" name="chkAll" runat="server" />全选
                                <asp:Button ID="lnkDel" runat="server" CssClass="button" Text="设为常规资讯" OnClick="lnkDel_Click" />
                            </td>
                        </tr>
                    </table>
                    <uc2:page ID="page1" runat="server" />
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
