<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_UserManage_IndividualList"
    CodeBehind="IndividualList.aspx.cs" %>

<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc2" %>
<%@ Register Src="../UserControl/top.ascx" TagName="top" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>个人后台管理</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/XYLib.css" type="text/css" rel="Stylesheet" />

    <script language="javascript" type="text/javascript" src="/common/js/base.js"></script>

    <script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>

    <script type="text/javascript" src="/common/js/date.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <a href="../index.aspx">后台管理首页</a> >> 个人用户管理</h1>
    <table width="100%">
        <tr>
            <!-- right -->
            <td class="right">
                <div class="main-setting">
                    <div class="itemtitle">
                        <h3>
                            个人用户管理</h3>
                        <ul class="tab1">
                            <li class="current"><a href="IndividualList.aspx"><span>基本信息</span></a></li><li><a
                                href="ResumeList.aspx"><span>简历信息</span></a></li></ul>
                    </div>
                    <table class="xy_tb xy_tb2">
                        <tr>
                            <td>
                                <table class="partition">
                                    <tr>
                                        <th>
                                            用户名：
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtName" runat="server" CssClass="input_s" Width="100px"></asp:TextBox>
                                        </td>
                                        <th>
                                            性别：
                                        </th>
                                        <td>
                                            <asp:RadioButtonList ID="tdcharacter" runat="server" RepeatDirection="Horizontal"
                                                RepeatLayout="Flow">
                                                <asp:ListItem Value="-1" Selected="True">所有</asp:ListItem>
                                                <asp:ListItem Value="1">男</asp:ListItem>
                                                <asp:ListItem Value="0">女</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            所在城市：
                                        </th>
                                        <td>
                                            <div id="classType">
                                            </div>
                                            <input type="hidden" id="areatypeid" runat="server" />

                                            <script type="text/javascript">
        var cla = new ClassType("cla",'area','classType','areatypeid');
        cla.Mode ="select";
        cla.Init();
                                            </script>

                                        </td>
                                        <th>
                                            注册时间：
                                        </th>
                                        <td>
                                            <input id="bgdate" type="text" runat="server" onclick="getDateString(this);" readonly="readonly" maxlength="10"
                                                style="width: 80px;" />
                                            到
                                            <input id="egdate" type="text" runat="server" onclick="getDateString(this);" readonly="readonly" maxlength="10"
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
                                                ErrorMessage="必须为数字" ValidationExpression="^[1-9]\d*$"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr class="content_action">
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Button ID="Button2" runat="server" Text="搜索" CssClass="button" OnClick="Button2_Click" />
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
                                <asp:GridView ID="gvlist" HeaderStyle-CssClass="gv_header_style" runat="server" AutoGenerateColumns="False"
                                    DataKeyNames="U_ID,U_Name,U_Email,UI_Name" Width="100%" GridLines="None" OnRowDataBound="gvlist_RowDataBound"
                                    OnRowCommand="gvlist_RowCommand">
                                    <Columns>
                                        <asp:BoundField DataField="U_ID" HeaderText="U_ID" Visible="False" />
                                        <asp:TemplateField HeaderText="选择">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkExport" runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle Width="5%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="用户名">
                                            <ItemStyle Width="40%" />
                                            <ItemTemplate>
                                                <a href='IndividualInfo.aspx?U_ID=<%# Eval("U_ID") %>&backURL=<%# backURL %>'>
                                                    <%# Eval("U_Name") %></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="UI_Name" HeaderText="姓名">
                                            <HeaderStyle CssClass="gvLeft" />
                                            <ItemStyle CssClass="gvLeft" Width="10%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="UI_Sex" HeaderText="性别">
                                            <ItemStyle Width="5%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Telephone" HeaderText="联系电话">
                                            <ItemStyle Width="15%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="U_RegDate" HeaderText="注册日期" DataFormatString="{0:d}"
                                            HtmlEncode="False">
                                            <ItemStyle Width="10%" />
                                        </asp:BoundField>
                                        <asp:ButtonField CommandName="shenhe" HeaderText="审核" DataTextField="UserAuditingState">
                                            <ItemStyle CssClass="action" Width="10%" />
                                        </asp:ButtonField>
                                        <asp:TemplateField HeaderText="查看">
                                            <ItemStyle Width="5%" />
                                            <ItemTemplate>
                                                <a href='IndividualInfo.aspx?U_ID=<%# Eval("U_ID") %>&backURL=<%# backURL %>'>
                                                    <img src="../images/look.GIF" alt="查看" /></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="U_Name" HeaderText="U_Name" Visible="False" />
                                        <asp:BoundField DataField="U_Email" HeaderText="email" Visible="False" />
                                    </Columns>
                                </asp:GridView>
                                <p style="text-align: center;">
                                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label></p>
                            </td>
                        </tr>
                        <tr>
                            <td class="content_action">
                                <input class="list_td04" id="chkAll" onclick="chkAll_true()" type="checkbox" name="chkAll"
                                    runat="server" />全选
                                <asp:Button ID="Button1" runat="server" Text="删除" CssClass="button" OnClick="Button1_Click" />
                            </td>
                        </tr>
                    </table>
                    <uc2:page ID="Page1" runat="server" />
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
