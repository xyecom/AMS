<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AttachmentManage.aspx.cs"
    Inherits="XYECOM.Web.xymanage.Global.AttachmentManage" %>

<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>附件管理</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <script language="javascript" type="text/javascript" src="/common/js/base.js"></script>
    <script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
    <script type="text/javascript" src="/common/js/date.js"></script>
    <script type="text/javascript">
        function selectAttDescTab(obj) {
            var value = obj.options[obj.selectedIndex].value.toLowerCase();

            document.getElementById("rdoBodyImage").checked = true;

            if (value == "all" || value == "n_news") {
                document.getElementById("rdoBodyFile").disabled = false;
            } else {
                document.getElementById("rdoBodyFile").disabled = true;
            }

            selectAttBody();
        }

        function selectAttBody() {
            var bodyImage = document.getElementById("rdoBodyImage").checked;
            var bodyFile = document.getElementById("rdoBodyFile").checked;

            if (bodyImage == true) {
                setIsIncluseSmallImg(false);

                document.getElementById("divImgFormatList").style.display = "";
                document.getElementById("divFileFormatList").style.display = "none";
            } else {
                setIsIncluseSmallImg(true);

                document.getElementById("divImgFormatList").style.display = "none";
                document.getElementById("divFileFormatList").style.display = "";
            }
        }

        function setIsIncluseSmallImg(isDisabled) {
            var eles = document.getElementsByName("IsIncludeSmallImg");

            for (var i = 0; i < eles.length; i++) {
                eles[i].disabled = isDisabled;
            }

            if (isDisabled) {
                eles[0].checked = true;
            }
        }

        function initPage() {
            selectAttBody();
        }
    </script>
</head>
<body onload="initPage();">
    <form id="form1" runat="server">
    <h1>
        <a href="../index.aspx">后台管理首页</a> >> 附件管理</h1>
    <table width="100%">
        <tr>
            <td class="right">
                <div class="main-setting">
                    <div class="itemtitle">
                        <h3>
                            附件管理</h3>
                    </div>
                    <table class="xy_tb xy_tb2">
                        <tr>
                            <td>
                                <!--搜索条件-->
                                <table class="partition">
                                    <tr>
                                        <th>
                                            所属信息：
                                        </th>
                                        <td>
                                            <select runat="server" id="selInfoType" onchange="selectAttDescTab(this);">
                                                <option value="all">全部信息</option>
                                                <option value="i_supply">供求信息</option>
                                                <option value="i_demand">加工信息</option>
                                                <option value="i_InviteBusinessmaninfo">招商代理信息</option>
                                                <option value="i_ServiceInfo">服务信息</option>
                                                <option value="i_ShowInfo">展会信息</option>
                                                <option value="n_News">新闻</option>
                                                <option value="XY_Topic">专题</option>
                                                <option value="u_User">企业Logo</option>
                                                <option value="u_Individual">个人头像</option>
                                                <option value="u_Certificate">企业证书</option>
                                                <option value="b_FriendLink">友情链接</option>
                                            </select>
                                        </td>
                                        <th>
                                            附件内容：
                                        </th>
                                        <td>
                                            <input type="radio" runat="server" id="rdoBodyImage" checked value="image" name="attBody"
                                                onclick="selectAttBody();" />图片
                                            <input type="radio" runat="server" id="rdoBodyFile" value="file" name="attBody" onclick="selectAttBody();" />其他文件
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            是否包含缩略图：
                                        </th>
                                        <td>
                                            <input type="radio" runat="server" id="rdoIsIncludeSmallImgAll" name="IsIncludeSmallImg"
                                                checked />不限
                                            <input type="radio" runat="server" id="rdoIsIncludeSmallImgYes" name="IsIncludeSmallImg" />包含
                                            <input type="radio" runat="server" id="rdoIsIncludeSmallImgNo" name="IsIncludeSmallImg" />不包含
                                        </td>
                                        <th>
                                            上传时间：
                                        </th>
                                        <td>
                                            <input id="txtStartTime" type="text" runat="server" onclick="getDateString(this);"
                                                readonly="readonly" maxlength="10" style="width: 80px;" />
                                            到
                                            <input id="txtEndTime" type="text" runat="server" onclick="getDateString(this);"
                                                readonly="readonly" maxlength="10" style="width: 80px;" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            格式：
                                        </th>
                                        <td colspan="3">
                                            <div id="divImgFormatList">
                                                <asp:RadioButtonList runat="server" ID="rdolstImgFormat" RepeatColumns="12">
                                                </asp:RadioButtonList>
                                            </div>
                                            <div id="divFileFormatList" style="display: none">
                                                <asp:RadioButtonList runat="server" ID="rdolstFileFormat" RepeatColumns="12">
                                                </asp:RadioButtonList>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            是否有效：
                                        </th>
                                        <td colspan="3">
                                            <asp:RadioButton runat="server" ID="rdoIsValidAll" Text="不限" GroupName="IsValid"
                                                Checked="true" />
                                            <asp:RadioButton runat="server" ID="rdoIsValidYes" Text="有效" GroupName="IsValid" />
                                            <asp:RadioButton runat="server" ID="rdoIsValidNo" Text="无效" GroupName="IsValid" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                        </th>
                                        <td colspan="3">
                                            <asp:Button CssClass="button" runat="server" ID="btnSearch" Text="搜索" OnClick="btnSearch_Click" />
                                            <asp:Button CssClass="button" runat="server" ID="btnDeleteAllTemp" Text="删除所有垃圾附件"
                                                OnClick="btnDeleteAllTemp_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gvList" HeaderStyle-CssClass="gv_header_style" runat="server" AutoGenerateColumns="False"
                                    DataKeyNames="at_id" GridLines="None" OnRowDataBound="gvlist_RowDataBound" Width="100%">
                                    <Columns>
                                        <asp:BoundField DataField="at_id" HeaderText="at_id" Visible="False" />
                                        <asp:TemplateField HeaderText="选择">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkExport" runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle Width="5%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="路径">
                                            <ItemStyle Width="45%" />
                                            <ItemTemplate>
                                                <a href='<%# Eval("S_URL") %><%# Eval("At_Path") %>' target="_blank">
                                                    <%# Eval("At_Path") %></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="是否有效">
                                            <ItemStyle Width="10%" />
                                            <ItemTemplate>
                                                <%#IsValidate(DataBinder.Eval(Container, "DataItem.DescTabId").ToString(), DataBinder.Eval(Container, "DataItem.S_URL").ToString(), DataBinder.Eval(Container, "DataItem.At_Path").ToString())%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="所在服务器">
                                            <ItemTemplate>
                                                <%# Eval("s_Name") %>
                                            </ItemTemplate>
                                            <ItemStyle Width="15%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="对应信息">
                                            <ItemStyle Width="25%" />
                                            <ItemTemplate>
                                                <%#GetInfoUrl(DataBinder.Eval(Container, "DataItem.DescTabName").ToString(),DataBinder.Eval(Container, "DataItem.DescTabId").ToString())%>
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
                                <input class="list_td04" id="chkAll" onclick="chkAll_true()" type="checkbox" name="chkAll"
                                    runat="server" />全选
                                <asp:Button ID="btnDelete" runat="server" Text="删除" CssClass="button" OnClick="btnDelete_Click" />&nbsp;
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
