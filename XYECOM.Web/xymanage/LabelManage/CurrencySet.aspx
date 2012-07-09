<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_LabelManage_currucyset"
    CodeBehind="currencyset.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>通用标签设置</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />

    <script language="javascript" type="text/javascript" src="/common/js/base.js"></script>

    <script type="text/javascript" src="../javascript/CheckedAll.js"></script>

    <script type="text/javascript" src="../javascript/TreeType.js"></script>

    <script type="text/javascript" src="../javascript/usertype.js"></script>

    <link href="/Common/css/XYLib.css" media="screen" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript">
    function moduleChanged_hotkeyword(obj){
        var moduleName = obj.options[obj.selectedIndex].value;
        
        if(moduleName =="news" 
        || moduleName =="job" 
        || moduleName =="brand" 
        || moduleName == "exhibition"
        || moduleName == "company"
        ){
            $("rdoToSellPage").disabled = true;
            $("rdoToBuyPage").disabled = true;
        }else{
            $("rdoToSellPage").disabled = false;
            $("rdoToBuyPage").disabled = false;
        }
    }
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
                            <li id="li_base" class="current" onclick="infoshow(1,this);"><a href="javascript:;">
                                <span>热门关键字</span></a></li>
                            <li id="li_page" onclick="infoshow(2,this);parent.setChildNum(13);"><a href="javascript:;">
                                <span>友情连接</span></a></li>
                            <li id="li_key" onclick="infoshow(3,this);parent.setChildNum(14);"><a href="javascript:;">
                                <span>广告</span></a></li>
                        </ul>
                    </div>
                    <!--后台导航 -->
                    <!--热门关键字-->
                    <table width="100%" class="xy_tb xy_tb2 setLabelData" id="base">
                        <tr>
                            <th style="height: 21px">
                                所属模块：
                            </th>
                            <td style="height: 21px">
                                <asp:DropDownList ID="ddlModulesByHotKeywords" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                调用数量：
                            </th>
                            <td>
                                <asp:TextBox ID="txtNumberForKeyword" runat="server" MaxLength="4" Columns="5" onblur="isNumer(this);">10</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                是否推荐：
                            </th>
                            <td>
                                <input type="radio" runat="server" id="rdoCommendAllForKeyword" checked="true" name="IsCommandForKeyword" />所有
                                <input type="radio" runat="server" id="rdoCommendYesForKeyword" name="IsCommandForKeyword" />推荐
                                <input type="radio" runat="server" id="rdoCommendNoForKeyword" name="IsCommandForKeyword" />不推荐
                            </td>
                        </tr>
                        <tr>
                            <th>
                                链接到：
                            </th>
                            <td>
                                <input type="radio" id="rdoToSellPage" runat="server" name="ToPage" checked="true" />供应列表
                                <input type="radio" id="rdoToBuyPage" runat="server" name="ToPage" />求购列表
                            </td>
                        </tr>
                        <tr>
                            <th width="23%">
                                &nbsp;
                            </th>
                            <td class="content_action" style="height: 30px">
                                <label>
                                    <asp:Button ID="btnHotKeywordOK" runat="server" CssClass="button" Text="确定创建此标签"
                                        OnClick="btnHotKeywordOK_Click"></asp:Button>&nbsp;
                                    <input class="button" type="button" value="取 消" onclick="closewindows();" /></label>
                            </td>
                        </tr>
                    </table>
                    <!--友情连接-->
                    <table width="100%" class="xy_tb xy_tb2 setLabelData" id="page" style="display: none;">
                        <tr>
                            <th>
                                链接分类：
                            </th>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlLinkSort">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                链接类型：
                            </th>
                            <td>
                                <asp:DropDownList ID="ddlLinkType" runat="server" CssClass="input" Width="74px">
                                    <asp:ListItem Value="1">图片</asp:ListItem>
                                    <asp:ListItem Value="0">文字</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                调用数量：
                            </th>
                            <td>
                                <asp:TextBox ID="tblinknum" runat="server" CssClass="input" MaxLength="10" onblur="isNumer(this);"
                                    Text="10"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                连接提示：
                            </th>
                            <td>
                                <asp:DropDownList ID="ddllinkalt" runat="server" CssClass="input">
                                    <asp:ListItem Value="1">显示</asp:ListItem>
                                    <asp:ListItem Value="0">不显示</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                是否推荐：
                            </th>
                            <td style="padding-top: 5px;">
                                <input type="radio" runat="server" id="rdoCommendAllForFriendLink" checked="true"
                                    name="IsCommandForFriendLink" />所有
                                <input type="radio" runat="server" id="rdoCommendYesForFriendLink" name="IsCommandForFriendLink" />推荐
                                <input type="radio" runat="server" id="rdoCommendNoForFriendLink" name="IsCommandForFriendLink" />不推荐
                            </td>
                        </tr>
                        <tr>
                            <th width="23%">
                                &nbsp;
                            </th>
                            <td class="content_action" style="height: 30px">
                                <label>
                                    <asp:Button ID="btnfriendlink" runat="server" CssClass="button" Text="确定创建此标签" OnClick="btnfriendlink_Click">
                                    </asp:Button>&nbsp;
                                    <input class="button" type="button" value="取 消" onclick="closewindows();" /></label>
                            </td>
                        </tr>
                    </table>
                    <!--广告-->
                    <table width="100%" class="xy_tb xy_tb2 setLabelData" id="key" style="display: none;">
                        <tr>
                            <th>
                                广告位：
                            </th>
                            <td>
                                <asp:DropDownList ID="ddladvertising" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                调用数量：
                            </th>
                            <td>
                                <asp:TextBox ID="tbadnum" runat="server" MaxLength="10" onblur="isNumer(this);" Text="10"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th width="23%">
                                &nbsp;
                            </th>
                            <td class="content_action" style="height: 30px">
                                <label>
                                    <asp:Button ID="btnguanggao" runat="server" CssClass="button" Text="确定创建此标签" OnClick="btnguanggao_Click">
                                    </asp:Button>&nbsp;
                                    <input class="button" type="button" value="取 消" onclick="closewindows();" /></label>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
