<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_basic_SearchKeyList"
    CodeBehind="SearchKeyList.aspx.cs" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>热门关键词管理</title>
    <link type="text/css" href="../css/style.css" rel="stylesheet" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <script language="javascript" type="text/javascript" src="/common/js/base.js"></script>
    <script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <a href="../index.aspx">后台设置首页</a> >> 热门关键词管理</h1>
    <table width="100%">
        <tr>
            <td class="right">
                <div class="main-setting">
                    <div class="itemtitle">
                        <h3>
                            热门关键词管理</h3>
                        <input id="btadd" class="addbtn" type="button" value="新增关键词" runat="Server" onserverclick="btadd_ServerClick" />
                    </div>
                    <table class="xy_tb xy_tb2">
                        <tr>
                            <td class="content_action">
                                <span style="float: left">
                                    <asp:DropDownList ID="ddlModules" runat="server" CssClass="dropdownlist">
                                        <asp:ListItem Value="-1"></asp:ListItem>
                                    </asp:DropDownList>
                                    &nbsp;
                                    <asp:DropDownList ID="ddlIsCommend" runat="server" CssClass="dropdownlist">
                                        <asp:ListItem Value="">是否推荐</asp:ListItem>
                                        <asp:ListItem Value="true">推荐</asp:ListItem>
                                        <asp:ListItem Value="false">不推荐</asp:ListItem>
                                    </asp:DropDownList>
                                    &nbsp;
                                    <asp:DropDownList ID="ddlIsRanking" runat="server" CssClass="dropdownlist">
                                        <asp:ListItem Value="">是否参与排名</asp:ListItem>
                                        <asp:ListItem Value="true">参与</asp:ListItem>
                                        <asp:ListItem Value="false">不参与</asp:ListItem>
                                    </asp:DropDownList>
                                    &nbsp;
                                    <asp:DropDownList ID="ddlOrderType" runat="server">
                                        <asp:ListItem Text="按录入时间排序" Value="InputData" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="按搜索次数排序" Value="NumberOfSearchs"></asp:ListItem>
                                    </asp:DropDownList>
                                    &nbsp;
                                    <asp:DropDownList ID="ddlSearCount" runat="server">
                                        <asp:ListItem Text="选择搜索次数" Value="-1" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="1-20次" Value="20"></asp:ListItem>
                                        <asp:ListItem Text="21-40次" Value="40"></asp:ListItem>
                                        <asp:ListItem Text="41-60次" Value="60"></asp:ListItem>
                                        <asp:ListItem Text="60次以上" Value="61"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtKey" runat="server"></asp:TextBox>
                                    <asp:Button ID="btnSearch" runat="server" Text="查询" CssClass="button" OnClick="btnSearch_Click" />&nbsp;
                                </span><span style="float: right">
                                    <asp:Button ID="btnDownload" runat="server" CssClass="button" OnClick="btnDownload_Click"
                                        Text="导入Excel表" />
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gvlist" HeaderStyle-CssClass="gv_header_style" Width="100%" runat="server"
                                    AutoGenerateColumns="False" DataKeyNames="SK_ID" GridLines="None" OnRowCommand="gvlist_RowCommand"
                                    OnRowDataBound="gvlist_RowDataBound">
                                    <Columns>
                                        <asp:BoundField Visible="False" DataField="SK_ID" />
                                        <asp:TemplateField HeaderText="选择">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkExport" runat="Server" /></ItemTemplate>
                                            <ItemStyle Width="5%" />
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="热词名称" DataField="SK_Name">
                                            <ItemStyle Width="21%" CssClass="gvLeft" />
                                            <HeaderStyle CssClass="gvLeft" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="所属模块">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="Server" Text='<%#GetType(DataBinder.Eval(Container,"DataItem.SK_Sort").ToString())%>'></asp:Label></ItemTemplate>
                                            <ItemStyle Width="10%" />
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="搜索次数" DataField="SK_Count">
                                            <ItemStyle Width="10%" CssClass="gvRight" />
                                            <HeaderStyle CssClass="gvRight" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="录入时间" DataField="SK_AddTime" DataFormatString="{0:yyyy-MM-dd}">
                                            <ItemStyle Width="15%" CssClass="gvRight" />
                                            <HeaderStyle CssClass="gvRight" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="最后搜索时间" DataField="SK_LastSearchTime" DataFormatString="{0:yyyy-MM-dd}">
                                            <ItemStyle Width="15%" CssClass="gvRight" />
                                            <HeaderStyle CssClass="gvRight" />
                                        </asp:BoundField>
                                        <asp:ButtonField HeaderText="推荐" DataTextField="SK_IsCommend" CommandName="SetIsCommend"
                                            HeaderStyle-CssClass="gvCenter">
                                            <ItemStyle Width="8%" CssClass="gvCenter" />
                                        </asp:ButtonField>
                                        <asp:ButtonField HeaderText="排名" DataTextField="SK_IsRanking" CommandName="SetIsRanking"
                                            HeaderStyle-CssClass="gvCenter">
                                            <ItemStyle Width="8%" CssClass="gvCenter" />
                                        </asp:ButtonField>
                                        <asp:TemplateField HeaderText="编辑">
                                            <ItemStyle Width="8%" />
                                            <ItemTemplate>
                                                <a href='<%# string.Format("SearchKeyInfo.aspx?sk_id={0}&backURL={1}",Eval("SK_ID"),backURL) %>'>
                                                    <img src="../images/edit.GIF" alt="点此编辑" />
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <p style="text-align: center;">
                                    <asp:Label ID="lblMessage" runat="Server" ForeColor="red"></asp:Label></p>
                            </td>
                        </tr>
                        <tr>
                            <td class="content_action" style="width: 547px">
                                <input id="chkAll" onclick="chkAll_true();" type="checkbox" name="chkAll" runat="server" />全选
                                <asp:Button ID="lnkDel" runat="server" CssClass="button" Text="删除" OnClick="lnkDel_Click" />&nbsp;
                                <asp:Button ID="btnClear" CssClass="button" runat="server" Text="搜索次数归零" OnClick="btnClear_Click" />
                            </td>
                        </tr>
                    </table>
                    <XYECOM:Page ID="page1" runat="server" OnPageChanged="Page1_PageChanged" />
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
