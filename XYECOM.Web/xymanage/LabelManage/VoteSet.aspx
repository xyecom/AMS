<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VoteSet.aspx.cs" Inherits="XYECOM.Web.xymanage.LabelManage.VoteSet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>通用标签设置</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />

    <script language="javascript" type="text/javascript" src="/common/js/base.js"></script>

    <script type="text/javascript" src="../javascript/CheckedAll.js"></script>

    <script type="text/javascript" src="../javascript/TreeType.js"></script>

    <script type="text/javascript" src="../javascript/usertype.js"></script>

    <link href="/Common/css/XYLib.css" media="screen" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
    <table width="100%">
        <tr>
            <td class="right">
                <div class="main-setting">
                    <div class="labeldatatitle">
                        <ul id="labelTable">
                            <li id="li_base" class="current" onclick="infoshow(1,this);"><a href="javascript:;"><span>网上调查</span></a></li>                            
                        </ul>
                    </div>
                    <!--网上调查-->
                    <table width="100%" class="xy_tb xy_tb2 setLabelData" id="base">
                        <tr>
                            <th>
                                调用数量：
                            </th>
                            <td>
                                <asp:TextBox ID="txtVoteNumber" runat="server" MaxLength="10" onblur="isNumer(this);"
                                    Text="10"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                排序字段：
                            </th>
                            <td>
                                <asp:DropDownList ID="ddlVoteOrderFieldName" runat="server" CssClass="input">
                                    <asp:ListItem Text="发布时间" Value="VoteId"></asp:ListItem>
                                    <asp:ListItem Text="开始时间" Value="StartTime"></asp:ListItem>
                                    <asp:ListItem Text="结束时间" Value="EndTime"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlVoteOrderType" runat="server" CssClass="input">
                                    <asp:ListItem Value="DESC">降序</asp:ListItem>
                                    <asp:ListItem Value="ASC">升序</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th>
                            </th>
                            <td>
                                <asp:CheckBox runat="server" ID="chkOnlyNoEnd" Text="仅调用已开始未结束信息" Checked="true" />
                            </td>
                        </tr>
                        <tr>
                            <th width="23%">
                                &nbsp;
                            </th>
                            <td class="content_action" style="height: 30px">
                                <label>
                                    <asp:Button ID="btnVoteOK" runat="server" CssClass="button" Text="确定创建此标签" OnClick="btnVoteOK_Click">
                                    </asp:Button>&nbsp;
                                    <input class="button" type="button" value="取 消" onclick="closewindows();" /></label>
                            </td>
                        </tr>
                    </table>
                    <div id="page" style="display:none;"></div>
                    <div id="key" style="display:none;"></div>
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
