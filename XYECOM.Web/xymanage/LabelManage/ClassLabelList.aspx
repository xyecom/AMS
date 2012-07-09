<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassLabelList.aspx.cs"
    Inherits="XYECOM.Web.xymanage.LabelManage.ClassLabelList" %>

<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>分类信息标签管理</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <script language="javascript" type="text/javascript" src="/common/js/base.js"></script>
    <script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <a href="../index.aspx">后台管理首页</a> >> 导航标签列表</h1>
    <div class="main-setting">
        <div class="itemtitle">
            <h3>
                导航标签列表</h3>
            <ul id="mainMenus0" runat="server" class="tab1">
            </ul>
            <input type="button" class="addbtn" value="新增行业站导航" onclick="location='AddTradeSiteNavLabel.aspx';" />
            <input type="button" class="addbtn" value="新增地方站导航" onclick="location='AddAreaSiteNavLabel.aspx';" />
            <input type="button" class="addbtn" value="新增分类导航" onclick="location='AddClassInfoLabel.aspx';" />
            <input type="button" class="addbtn" value="新增地区导航" onclick="location='AddAreaLabel.aspx';" />
        </div>
        <table class="xy_tb xy_tb2">
            <tr>
                <td>
                    <asp:GridView ID="gvClassLabel" HeaderStyle-CssClass="gv_header_style" Width="100%"
                        runat="server" AutoGenerateColumns="False" OnRowDataBound="gvList_RowDataBound"
                        DataKeyNames="ID" GridLines="None">
                        <Columns>
                            <asp:BoundField Visible="False" DataField="ID">
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="选择">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkExport" runat="server" />
                                </ItemTemplate>
                                <ItemStyle Width="5%" />
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="标签名称" DataField="Name">
                                <ItemStyle Width="25%" CssClass="gvLeft" />
                                <HeaderStyle CssClass="gvLeft" Width="25%" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="标签中文名" DataField="CNName">
                                <ItemStyle Width="15%" CssClass="gvLeft" />
                                <HeaderStyle CssClass="gvLeft" Width="40%" />
                            </asp:BoundField>
                            <asp:HyperLinkField DataNavigateUrlFields="L_ID" DataNavigateUrlFormatString="Add.aspx?L_ID={0}"
                                HeaderText="编辑" Text="&lt;img src=&quot;../images/edit.gif&quot; /&gt;" Visible="False">
                                <ItemStyle Width="5%" CssClass="action" />
                            </asp:HyperLinkField>
                            <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="ClassLabelPreview.aspx?id={0}"
                                HeaderText="预览" Text="预览" />
                            <asp:TemplateField HeaderText="修改">
                                <ItemStyle Width="5%" />
                                <ItemTemplate>
                                    <a href='EditClassInfolabel.aspx?id=<%# Eval("id") %>&backURL=<%# backURL %>'>
                                        <img src="../images/look.GIF" alt="修改" /></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <p style="text-align: center;">
                        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label></p>
                </td>
            </tr>
            <tr>
                <td class="content_action">
                    <input id="chkAll" onclick="chkAll_true()" type="checkbox" name="chkAll" runat="server" />全选
                    <asp:Button ID="btndelete" runat="server" CssClass="button" OnClick="btnDelete_Click"
                        Text="删 除" />
                </td>
            </tr>
        </table>
        <uc1:page ID="page1" runat="server" OnPageChanged="Page1_PageChanged" />
    </div>
    </form>
</body>
</html>
