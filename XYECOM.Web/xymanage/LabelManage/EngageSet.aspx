<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_LabelManage_EngageSet"
    CodeBehind="EngageSet.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>招聘信息标签设置</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/Common/css/XYLib.css" media="screen" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="/Common/js/base.js" language="javascript"></script>

    <script type="text/javascript" src="../javascript/CheckedAll.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <table width="100%">
        <tr>
            <!-- right  DataBinder.Eval (Container.DataItem, "A_isAudited") -->
            <td class="right">
                <div class="main-setting">
                    <div class="labeldatatitle">
                        <ul id="labelTable">
                            <li id="li_base" class="current" onclick="infoshow(1,this);"><a href="javascript:;">
                                <span>基本列表</span></a></li>
                            <li id="li_page" onclick="infoshow(2,this);"><a href="javascript:;"><span>分页列表</span></a></li>
                        </ul>
                    </div>
                    <table width="100%" class="xy_tb xy_tb2 setLabelData" id="base">
                        <tr>
                            <th>
                                信息类别：
                            </th>
                            <td>
                                <div id="classType">
                                </div>
                                <input id="hidptid" runat="server" type="hidden" value="" />
                            </td>
                        </tr>
                        <tr>
                            <th width="23%">
                                调用数量：
                            </th>
                            <td>
                                <asp:TextBox ID="tbnum" runat="server" CssClass="input" MaxLength="10" onblur="isNumer(this);"
                                    Text="10"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                岗位显示字数：
                            </th>
                            <td>
                                <asp:TextBox ID="tbtitlenum" runat="server" CssClass="input" MaxLength="10" onblur="isNumer(this);"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                点击次数大于：
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
                                <asp:CheckBox runat="server" ID="chkUserGradeOrder" Checked="true" Text="优先以会员等级排序" />
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
                                具体要求显示字数：
                            </th>
                            <td>
                                <asp:TextBox ID="tbinfonum" runat="server" CssClass="input" MaxLength="10" onblur="isNumer(this);"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                公司名称显示字数：
                            </th>
                            <td>
                                <asp:TextBox ID="tbcorporationNum" runat="server" CssClass="input" MaxLength="10"
                                    onblur="isNumer(this);"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                是否推荐：
                            </th>
                            <td>
                                <asp:DropDownList ID="ddlCommend" runat="server">
                                    <asp:ListItem Value="">所有</asp:ListItem>
                                    <asp:ListItem Value="0">不推荐</asp:ListItem>
                                    <asp:ListItem Value="1">推荐</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th style="height: 30px">
                                &nbsp;
                            </th>
                            <td class="content_action" style="height: 30px">
                                <label>
                                    <asp:Button ID="Button1" runat="server" CssClass="button" Text="确定创建此标签" OnClick="Button1_Click">
                                    </asp:Button>&nbsp;
                                    <input id="Button2" class="button" type="button" value="取消" onclick="closewindows();" /></label>
                            </td>
                        </tr>
                    </table>
                    <!--分页列表设置 -->
                    <table width="100%" class="xy_tb xy_tb2 setLabelData" id="page" style="display: none;">
                        <tr>
                            <th width="23%">
                                每页调用数量：
                            </th>
                            <td>
                                <asp:TextBox ID="tbpagenum" runat="server" CssClass="input" MaxLength="10" onblur="isNumer(this);"
                                    Text="20"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                标题显示字数：
                            </th>
                            <td>
                                <asp:TextBox ID="tbpagetitlenum" runat="server" CssClass="input" MaxLength="10" onblur="isNumer(this);"></asp:TextBox>
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
                                具体要求显示字数：
                            </th>
                            <td>
                                <asp:TextBox ID="tbpageproductnum" runat="server" CssClass="input" MaxLength="10"
                                    onblur="isNumer(this);"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                公司名称显示字数：
                            </th>
                            <td>
                                <asp:TextBox ID="tbpagecorporationnum" runat="server" CssClass="input" MaxLength="10"
                                    onblur="isNumer(this);"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th style="height: 30px">
                                &nbsp;
                            </th>
                            <td class="content_action" style="height: 30px">
                                <label>
                                    <asp:Button ID="Button3" runat="server" CssClass="button" Text="确定创建此标签" OnClick="Button3_Click">
                                    </asp:Button>&nbsp;
                                    <input id="Button4" class="button" type="button" value="取消" onclick="closewindows();" /></label>
                            </td>
                        </tr>
                    </table>
                    <div id="key" style="display: none;">
                    </div>
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>

<script type="text/javascript">
var cla = new ClassType("cla",'job','classType','hidptid');
cla.Mode = "select";
cla.Init();
</script>

