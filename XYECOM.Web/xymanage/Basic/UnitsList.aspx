<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnitsList.aspx.cs" Inherits="XYECOM.Web.xymanage.Basic.UnitsList" %>

<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>单位管理</title>
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script type="text/javascript" src="../javascript/CheckedAll.js" ></script>

    <style type="text/css">
        .style1
        {
            width: 111px;
        }
    </style>

</head>
<body onload="">
<form id="form1" runat="server" >
<h1><a href="../index.aspx">后台管理首页</a> &gt;&gt; 单位管理</h1>

    
<table width="100%">
        <tr>
            <td class="right">
                <div class="main-setting">
                    <div class="itemtitle">
                        <h3>
                            单位管理</h3>
                     
                        <input type="button" class="addbtn" onclick="javascript:window.location.href='Unitsadd.aspx';"
                            value="添加单位信息" />
                    </div>
                    <table class="xy_tb xy_tb2">
                        <tr>
                            <td>
                                <table width="100%" class="partition">
                                    <tr>
                                        <th class="style1">
                                            单位名称：
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtKeyword" runat="server" Width="150px" MaxLength="30" CssClass="input_s"></asp:TextBox>
                                        </td>
                                        <th>
                                            &nbsp;</th>
                                        <td id="classType">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                        </td>
                                        <td colspan="3">
                                            <asp:Button ID="btFind" runat="server" CssClass="button" Text="搜索" OnClick="btFind_Click" />
                                            <input type="reset" value="重置" class="button" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="middle">
                                <asp:GridView ID="gvlist" HeaderStyle-CssClass="gv_header_style" Width="100%" runat="server"
                                    AutoGenerateColumns="False" DataKeyNames="id,MeasuringUnitName" GridLines="None" RowStyle-HorizontalAlign="Left"
                                    OnRowDataBound="gvlist_RowDataBound">
                                    <Columns>
                                        <asp:BoundField Visible="False" DataField="id" />
                                        <asp:TemplateField HeaderText="选择">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkExport" runat="server" /></ItemTemplate>
                                            <ItemStyle Width="5%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="单位名称">
                                            <ItemStyle CssClass="gvLeft" Width="35%" />
                                            <HeaderStyle CssClass="gvLeft" />
                                            <ItemTemplate>
                                                <%# XYECOM.Core.Utils.IsLength(50, Eval("MeasuringUnitName").ToString())%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                 
                                        <asp:TemplateField HeaderText="查看/编辑">
                                            <ItemStyle Width="20%" />
                                            <ItemTemplate>
                                                <a href='unitsAdd.aspx?infoid=<%# Eval("id") %>&backURL=<%# backURL %>'>
                                                    <img src="../images/look.GIF" alt="查看" /></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <a style="text-align: center">
                                    <asp:Label ID="lblMessage" runat="server" ForeColor="red"></asp:Label></a>
                            </td>
                        </tr>
                        <tr>
                            <td class="content_action">
                                <input id="chkAll" onclick="chkAll_true();" type="checkbox" name="chkAll" runat="Server" />全选
                                <asp:Button ID="lnkDel" runat="server" CssClass="button" Text="删除" OnClick="lnkDel_Click" />&nbsp;
                            </td>
                        </tr>
                    </table>
                    <uc2:page ID="page1" runat="server" />
                </div>
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


