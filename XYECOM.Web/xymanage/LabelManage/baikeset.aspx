<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="baikeset.aspx.cs" Inherits="XYECOM.Web.xymanage.LabelManage.baikeset" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>新闻标签设置</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" src="/Common/js/base.js" language="javascript"></script>

    <script type="text/javascript" src="../javascript/CheckedAll.js"></script>

    <script type="text/javascript" src="../javascript/TreeNewsType.js">
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <table width="100%">
        <tr>
            <td class="right">
                <div class="main-setting">
                    <div class="labeldatatitle">
                        <ul id="labelTable">
                            <li id="li_base" class="current" onclick="infoshow(1,this);"><a href="javascript:;"><span>基本列表</span></a></li>
                            <li id="li_page" onclick="infoshow(2,this);"><a href="javascript:;"><span>搜索分页列表</span></a></li>
                        </ul>
                    </div>
                    <!--基本信息-->
                    <table width="100%" class="xy_tb xy_tb2 setLabelData" id="base">
                        <tr>
                            <th>
                                百科分类：
                            </th>
                            <td>
                                <div id="divtitle">
                                </div>
                                <input id="typeId" name="typeIds" runat="server" type="text" style="display: none" />

                                <script type="text/javascript">
                                var cla = new ClassType("cla",'baike','divtitle','typeId');
                                cla.Mode="select";
                                cla.Init();
                                </script>

                            </td>
                        </tr>
                        <tr>
                            <th>
                                调用数量：
                            </th>
                            <td>
                                <asp:TextBox ID="tbnum" runat="server" CssClass="input" MaxLength="10" onblur="isNumer(this);"
                                    Text="10"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                浏览次数大于：
                            </th>
                            <td>
                                <asp:TextBox ID="tbclicknum" runat="server" CssClass="input" MaxLength="10" onblur="isNumer(this);"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                排序字段：
                            </th>
                            <td>
                                <asp:DropDownList ID="ddlorderColumuName" runat="server" CssClass="input">
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlorder" runat="server" CssClass="input">
                                    <asp:ListItem Value="DESC">降序</asp:ListItem>
                                    <asp:ListItem Value="ASC">升序</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                日期格式：
                            </th>
                            <td>
                                <asp:DropDownList ID="ddldatetype" runat="server">
                                    <asp:ListItem Value="">请选择</asp:ListItem>
                                    <asp:ListItem Value="yyyy-MM-dd">yyyy-MM-dd</asp:ListItem>
                                    <asp:ListItem Value="yy-MM-dd">yy-MM-dd</asp:ListItem>
                                    <asp:ListItem Value="MM.dd">MM.dd</asp:ListItem>
                                    <asp:ListItem Value="MM-dd">MM-dd</asp:ListItem>
                                    <asp:ListItem Value="MM\\dd">MM\dd</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                内容显示字数：
                            </th>
                            <td>
                                <asp:TextBox ID="txtContentLength" runat="server" CssClass="input" MaxLength="10"
                                    onblur="isNumer(this);"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                是否推荐：
                            </th>
                            <td>
                                <asp:DropDownList ID="ddlrecommend" runat="server">
                                    <asp:ListItem Value="">所有</asp:ListItem>
                                    <asp:ListItem Value="0">不推荐</asp:ListItem>
                                    <asp:ListItem Value="1">推荐</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                是否优秀：
                            </th>
                            <td>
                                <asp:DropDownList ID="ddlbest" runat="server">
                                    <asp:ListItem Value="">所有</asp:ListItem>
                                    <asp:ListItem Value="1">优秀</asp:ListItem>
                                    <asp:ListItem Value="0">一般</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                &nbsp;
                            </th>
                            <td>
                                <label>
                                    <asp:Button ID="Button1" runat="server" CssClass="button" Text="确定创建此标签" OnClick="BtnBaikeList">
                                    </asp:Button>&nbsp;
                                    <input id="Button2" class="button" type="button" value="取消" onclick="closewindows();" /></label>
                            </td>
                        </tr>
                    </table>
                    <!--搜索分页列表设置 -->
                    <%--      <table width="100%" class="xy_tb xy_tb2 setLabelData" id="page" style="display: none;">--%>
                    <table width="100%" class="xy_tb xy_tb2 setLabelData" id="page" style="display: none;">
                        <tr>
                            <th>
                                每页调用数量：
                            </th>
                            <td>
                                <asp:TextBox ID="tbpagenum" runat="server" CssClass="input" MaxLength="10" onblur="isNumer(this);"
                                    Text="20"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                内容显示字数：
                            </th>
                            <td>
                                <asp:TextBox ID="txtpageContentLength" runat="server" CssClass="input" MaxLength="10"
                                    onblur="isNumer(this);"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                日期格式：
                            </th>
                            <td>
                                <asp:DropDownList ID="ddlpagedatetype" runat="server">
                                    <asp:ListItem Value="">请选择</asp:ListItem>
                                    <asp:ListItem Value="yyyy-MM-dd">yyyy-MM-dd</asp:ListItem>
                                    <asp:ListItem Value="yy-MM-dd">yy-MM-dd</asp:ListItem>
                                    <asp:ListItem Value="MM.dd">MM.dd</asp:ListItem>
                                    <asp:ListItem Value="MM-dd">MM-dd</asp:ListItem>
                                    <asp:ListItem Value="MM\\dd">MM\dd</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                排序字段：
                            </th>
                            <td>
                                <asp:DropDownList ID="ddlpageorder" runat="server" CssClass="input">
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlpagedesc" runat="server" CssClass="input">
                                    <asp:ListItem Value="DESC">降序</asp:ListItem>
                                    <asp:ListItem Value="ASC">升序</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                &nbsp;
                            </th>
                            <td>
                                <label>
                                    &nbsp;<asp:Button ID="Button3" runat="server" CssClass="button" Text="确定创建此标签" OnClick="BtnBaikePageList">
                                    </asp:Button>&nbsp;
                                    <input id="Button4" class="button" type="button" value="取消" onclick="closewindows();" /></label>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <div id="key" style="display:none;"></div>
    </form>
</body>
</html>
