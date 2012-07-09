<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupplyBuySet.aspx.cs" Inherits="XYECOM.Web.xymanage.LabelManage.SupplyBuy" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>供求标签设置</title>
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<link href="/Common/css/XYLib.css" media="screen" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="/Common/js/base.js" language="javascript"></script>
<script type="text/javascript" src="../javascript/TreeType.js" ></script>
<script type="text/javascript" src="../javascript/CheckedAll.js" ></script>

</head>
<body>
<form id="form1" runat="server" method="post">
<table width="100%">
<tr>
<td class="right">
<div class="main-setting">

<div class="labeldatatitle">
<ul id="labelTable">
    <li id="li_base" class="current" onclick="infoshow(1,this);"><a href="javascript:;"><span>基本列表</span></a></li>
    <li id="li_page" onclick="infoshow(2,this);"><a href="javascript:;"><span>分页列表</span></a></li>
    <%--<li id="li_key"  onclick="infoshow(3,this);"><a href="javascript:;"><span>关键词排名列表</span></a></li>--%>
</ul>
</div>


<!--基本列表设置 -->

<table width="100%" class="xy_tb xy_tb2 setLabelData" id="base" >
<tr>
    <th>所属模块：</th>
    <td>
    <asp:DropDownList runat="server" ID="ddlmodul" CssClass="input" AutoPostBack="True" >
    <asp:ListItem Value="1">
    产品求购
    </asp:ListItem>
    </asp:DropDownList>
    </td>
</tr>
<tr>
<th width="23%">
    调用数量：</th>
<td><asp:TextBox ID="tbnum" runat="server" CssClass="input1" MaxLength="10" onblur="isNumer(this);" Text="10"></asp:TextBox></td>
</tr>
<tr><th>标题显示字数：</th>
<td><asp:TextBox ID="tbtitlenum" runat="server" CssClass="input1" MaxLength="10" onblur="isNumer(this);"></asp:TextBox></td>
</tr>

<tr>
<th>排序字段：</th>
<td><asp:DropDownList ID="ddlorderColumuName" runat="server" CssClass="input1">
<asp:ListItem Value="PublishDate">发布时间</asp:ListItem>
<asp:ListItem Value="Emergency">紧急求购</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="ddlorder" runat="server" CssClass="input1">
            <asp:ListItem Value="DESC">降序</asp:ListItem>
            <asp:ListItem Value="ASC">升序</asp:ListItem>
        </asp:DropDownList>
</td>
</tr>
<tr>
<th>日期格式：</th>
<td>
    <asp:DropDownList ID="ddldatetype" runat="server">
        <asp:ListItem Value="">请选择</asp:ListItem>
        <asp:ListItem Value="yyyy-MM-dd">yyyy-MM-dd</asp:ListItem>
        <asp:ListItem Value="yy-MM-dd">yy-MM-dd</asp:ListItem>
        <asp:ListItem Value="MM.dd">MM.dd</asp:ListItem>
        <asp:ListItem Value="MM-dd">MM-dd</asp:ListItem>
        <asp:ListItem Value="MM\\dd">MM\dd</asp:ListItem>
    </asp:DropDownList></td>
</tr>
<tr>
<th>所在地区：</th>
<td>
     <div id="classType" style="line-height: 20px; padding: 0;">
                                            </div>
                                            <input type="hidden" id="areatypeid" runat="server" />
                                            <script type="text/javascript">
                                                var cla = new ClassType("cla", 'area', 'classType', 'areatypeid');
                                                cla.Mode = "select";
                                                cla.Init();
                                            </script></td>
</tr>
<tr>
<th>信息描述显示字数：</th>
<td>
    <asp:TextBox ID="tbinfonum" runat="server" CssClass="input1" MaxLength="10" onblur="isNumer(this);"></asp:TextBox></td>
</tr>
<tr>
<th>
    公司名称显示字数：</th>
<td>
    <asp:TextBox ID="tbcorporationNum" runat="server" CssClass="input1" MaxLength="10" onblur="isNumer(this);"></asp:TextBox></td>
</tr>

<tr>
<th>&nbsp;</th>
<td><label> <asp:button id="Button1" runat="server" CssClass="button" Text="确定创建此标签" OnClick="Button1_Click"   ></asp:button>&nbsp;
    <input id="Button2" class="button" type="button" value="取 消" onclick="closewindows();" /></label></td>
</tr>
</table>


<!--分页列表设置 -->

<table width="100%" class="xy_tb xy_tb2 setLabelData" id="page" style="display:none;">
<tr>
<th>
    每页调用数量：</th>
<td>
        <asp:TextBox ID="tbpagenum" runat="server" CssClass="input1" MaxLength="10"  onblur="isNumer(this);" Text="20"></asp:TextBox></td>
</tr>
<tr><th>
    标题显示字数：</th>
    <td>
    <asp:TextBox ID="tbpagetitlenum" runat="server" CssClass="input1"  MaxLength="10" onblur="isNumer(this);"></asp:TextBox></td>
</tr>
<tr>
<th>
    排序字段：</th>
<td>
        <asp:DropDownList ID="ddlpageorder" runat="server" CssClass="input1">
        <asp:ListItem Value="PublishDate">发布时间</asp:ListItem>
<asp:ListItem Value="Emergency">紧急求购</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="ddlpagedesc" runat="server" CssClass="input1">
            <asp:ListItem Value="DESC">降序</asp:ListItem>
            <asp:ListItem Value="ASC">升序</asp:ListItem>
        </asp:DropDownList></td>
</tr>
<tr>
<th>日期格式：</th>
<td>
    <asp:DropDownList ID="ddlpagedatetype" runat="server">
        <asp:ListItem Value="">请选择</asp:ListItem>
        <asp:ListItem Value="yyyy-MM-dd">yyyy-MM-dd</asp:ListItem>
        <asp:ListItem Value="yy-MM-dd">yy-MM-dd</asp:ListItem>
        <asp:ListItem Value="MM.dd">MM.dd</asp:ListItem>
        <asp:ListItem Value="MM-dd">MM-dd</asp:ListItem>
        <asp:ListItem Value="MM\\dd">MM\dd</asp:ListItem>
    </asp:DropDownList></td>
</tr>
<tr>
<th>所在地区：</th>
<td>
     <div id="classType1" style="line-height: 20px; padding: 0;">
                                            </div>
                                            <input type="hidden" id="areatypeid2" runat="server" />
                                            <script type="text/javascript">
                                                var cla1 = new ClassType("cla1", 'area', 'classType1', 'areatypeid2');
                                                cla1.Mode = "select";
                                                cla1.Init();
                                            </script></td>
</tr>
<tr>
<th>信息描述显示字数：</th>
<td>
    <asp:TextBox ID="tbpageproductnum" runat="server"  MaxLength="10" CssClass="input1"  onblur="isNumer(this);"></asp:TextBox></td>
</tr>
<tr>
<th>
    公司名称显示字数：</th>
<td>
    <asp:TextBox ID="tbpagecorporationnum" runat="server" MaxLength="10" CssClass="input1"  onblur="isNumer(this);"></asp:TextBox></td>
</tr>
<tr>
<th>&nbsp;</th>
<td><label> <asp:button id="Button3" runat="server" CssClass="button" Text="确定创建此标签" OnClick="Button3_Click"    ></asp:button>&nbsp;
    <input id="Button4" class="button" type="button" value="取 消" onclick="closewindows();" /></label></td>
</tr>
</table>


<!--关键词竞价列表设置 -->
<table width="100%" class="xy_tb xy_tb2 setLabelData" id="key" style="display:none;" >
</table>
<%--<table width="100%" class="xy_tb xy_tb2 setLabelData" id="key" style="display:none;" >
<tr><th>显示名次：</th><td>
    <asp:DropDownList ID="ddlRankList" runat="server">
    </asp:DropDownList></td></tr>
<tr><th>标题显示字数：</th>
<td><asp:TextBox ID="tbkeytitlenum" runat="server" CssClass="input1"  MaxLength="10" onblur="isNumer(this);"></asp:TextBox></td>
</tr>
<tr>
<th>日期格式：</th>
<td>
    <asp:DropDownList ID="ddlkeydatetype" runat="server">
        <asp:ListItem Value="">请选择</asp:ListItem>
        <asp:ListItem Value="yyyy-MM-dd">yyyy-MM-dd</asp:ListItem>
        <asp:ListItem Value="yy-MM-dd">yy-MM-dd</asp:ListItem>
        <asp:ListItem Value="MM.dd">MM.dd</asp:ListItem>
        <asp:ListItem Value="MM-dd">MM-dd</asp:ListItem>
        <asp:ListItem Value="MM\\dd">MM\dd</asp:ListItem>
    </asp:DropDownList></td>
</tr>
<tr>
<th>信息描述显示字数：</th>
<td><asp:TextBox ID="tbkeycontentnum" runat="server"  MaxLength="10" CssClass="input1"  onblur="isNumer(this);"></asp:TextBox></td>
</tr>
<tr>
<th>公司名称显示字数：</th>
<td><asp:TextBox ID="tbkeycompanynum" runat="server" MaxLength="10" CssClass="input1"  onblur="isNumer(this);"></asp:TextBox></td>
</tr>
<tr>
<th>&nbsp;</th>
<td> <asp:button id="Button5" runat="server" CssClass="button" Text="确定创建此标签" OnClick="Button5_Click"  ></asp:button>&nbsp;
    <input id="Button6" class="button" type="button" value="取 消" onclick="closewindows();" /></td>
</tr>
</table>

</div>
</td>
</tr>
</table>--%>
</form>
</body>
</html>


