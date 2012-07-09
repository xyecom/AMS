<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_LabelManage_NewsSet" Codebehind="NewsSet.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>新闻标签设置</title>
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
<script type="text/javascript" src="/Common/js/base.js" language="javascript"></script>
<script type="text/javascript" src="../javascript/CheckedAll.js" ></script>
<script type="text/javascript" src="../javascript/TreeNewsType.js" >
</script>

</head>
<body>
<form id="form1" runat="server">
<table width="100%" >
<tr>

<td class="right">


<div class="main-setting">

<div class="labeldatatitle">
<ul id="labelTable">
    <li id="li_base" class="current" onclick="infoshow(1,this);"><a href="javascript:;"><span>基本列表</span></a></li>
    <li id="li_page" onclick="infoshow(2,this);"><a href="javascript:;"><span>搜索分页列表</span></a></li>
    <%--<li id="li_key" onclick="infoshow(3,this);parent.setChildNum(16);"><a href="javascript:;"><span>企业新闻列表</span></a></li>--%>
</ul>
</div>



<!--基本信息-->
<table width="100%" class="xy_tb xy_tb2 setLabelData" id="base" >
<tr>
<th>资讯类型：</th>
<td>
    <asp:RadioButton ID="Rbt_base" runat="server" Checked="True" Text="基本" GroupName="Rbt_news" OnCheckedChanged="Rbt_filmstrip_CheckedChanged" AutoPostBack="True"/>
    <asp:RadioButton ID="Rbt_index" runat="server" Text="头条" GroupName="Rbt_news" OnCheckedChanged="Rbt_filmstrip_CheckedChanged"  AutoPostBack="True"/>
    <asp:RadioButton ID="Rbt_hot" runat="server" Text="热点" GroupName="Rbt_news" OnCheckedChanged="Rbt_filmstrip_CheckedChanged" AutoPostBack="True"/>
    <asp:RadioButton ID="Rbt_filmstrip" runat="server" Text="幻灯" GroupName="Rbt_news" OnCheckedChanged="Rbt_filmstrip_CheckedChanged" AutoPostBack="True" />
    <asp:RadioButton ID="Rbt_Scheme" runat="server" Text="方案式采购" GroupName="Rbt_news" OnCheckedChanged="Rbt_filmstrip_CheckedChanged" AutoPostBack="True" /></td>
</tr>
<tr>
<th>资讯栏目：</th>
<td>
<div id="classType1"></div>
<input id="hdgetid" type="hidden" runat="server" /></td>
</tr>
<tr>
<th width="23%">
    新闻专题：</th>
<td>
    <asp:DropDownList ID="ddlTopicid" runat="server">
     
    </asp:DropDownList>
</td>
</tr>
<tr>
<th>
    调用数量：</th>
<td>
        <asp:TextBox ID="tbnum" runat="server" CssClass="input" MaxLength="10" onblur="isNumer(this);" Text="10"></asp:TextBox></td>
</tr>
<tr><th>
    标题显示字数：</th>
    <td>
    <asp:TextBox ID="tbtitlenum" runat="server" CssClass="input" MaxLength="10" onblur="isNumer(this);"></asp:TextBox></td>
</tr>
<tr>
<th>
    点击次数大于：</th>
<td>
    <asp:TextBox ID="tbclicknum" runat="server" CssClass="input" MaxLength="10" onblur="isNumer(this);"></asp:TextBox></td>
</tr>
<tr>
<th>
    排序字段：</th>
<td>
        <asp:DropDownList ID="ddlorderColumuName" runat="server" CssClass="input">
        </asp:DropDownList><asp:DropDownList ID="ddlorder" runat="server" CssClass="input">
            <asp:ListItem Value="DESC">降序</asp:ListItem>
            <asp:ListItem Value="ASC">升序</asp:ListItem>
        </asp:DropDownList></td>
</tr>
<tr>
<th>日期格式：</th>
<td>
    <asp:DropDownList ID="ddldatetype" runat="server"><asp:ListItem Value="">请选择</asp:ListItem>
        <asp:ListItem Value="yyyy-MM-dd">yyyy-MM-dd</asp:ListItem>
        <asp:ListItem Value="yy-MM-dd">yy-MM-dd</asp:ListItem>
        <asp:ListItem Value="MM.dd">MM.dd</asp:ListItem>
        <asp:ListItem Value="MM-dd">MM-dd</asp:ListItem>
        <asp:ListItem Value="MM\\dd">MM\dd</asp:ListItem>
    </asp:DropDownList></td>
</tr>
<tr>
<th>
    资讯导读显示字数：</th>
<td>
    <asp:TextBox ID="tbcontentnum" runat="server" CssClass="input" MaxLength="10" onblur="isNumer(this);"></asp:TextBox></td>
</tr>
<tr>
<th>
    是否推荐：</th>
<td>
    <asp:DropDownList ID="ddlCommend" runat="server">
        <asp:ListItem Value="">所有</asp:ListItem>
        <asp:ListItem Value="0">不推荐</asp:ListItem>
        <asp:ListItem Value="1">推荐</asp:ListItem>
    </asp:DropDownList></td>
</tr>
<tr>
<th>是否为图片资讯：</th>
<td>
    <asp:DropDownList ID="ddlimg" runat="server">
        <asp:ListItem Value="">所有</asp:ListItem>
        <asp:ListItem Value="0">文字</asp:ListItem>
        <asp:ListItem Value="1">图片</asp:ListItem>
    </asp:DropDownList></td>
</tr>
<tr>
    <th>是否为投稿资讯：</th>
   <td>
        <asp:RadioButton runat="server" ID="rbtcobyes" GroupName="contributor" Text="是" />
        <asp:RadioButton runat="server" ID="rbtcobno" GroupName="contributor" Text="否" />
        <asp:RadioButton runat="server" ID="rbtcobmay" GroupName="contributor" Text="不限" Checked="true" />
   </td> 
</tr>
<tr>
<th>&nbsp;</th>
<td><label> <asp:button id="btnOK" runat="server" CssClass="button" Text="确定创建此标签" OnClick="BtnNewsList"   ></asp:button>&nbsp;
    <input id="Button2" class="button" type="button" value="取消" onclick="closewindows();" /></label></td>
</tr>
</table>


<!--搜索分页列表设置 -->

<table width="100%" class="xy_tb xy_tb2 setLabelData" id="page" style="display:none;">
<tr>
<th>
    每页调用数量：</th>
<td>
        <asp:TextBox ID="tbpagenum" runat="server" CssClass="input" MaxLength="10" onblur="isNumer(this);" Text="20"></asp:TextBox></td>
</tr>
<tr><th>
    标题显示字数：</th>
    <td>
    <asp:TextBox ID="tbpagetitlenum" runat="server" CssClass="input" MaxLength="10" onblur="isNumer(this);"></asp:TextBox></td>
</tr>
<tr>
<th>日期格式：</th>
<td>
    <asp:DropDownList ID="ddlpagedatetype" runat="server"><asp:ListItem Value="">请选择</asp:ListItem>
        <asp:ListItem Value="yyyy-MM-dd">yyyy-MM-dd</asp:ListItem>
        <asp:ListItem Value="yy-MM-dd">yy-MM-dd</asp:ListItem>
        <asp:ListItem Value="MM.dd">MM.dd</asp:ListItem>
        <asp:ListItem Value="MM-dd">MM-dd</asp:ListItem>
        <asp:ListItem Value="MM\\dd">MM\dd</asp:ListItem>
    </asp:DropDownList></td>
</tr>
<tr>
<th>
    排序字段：</th>
<td >
        <asp:DropDownList ID="ddlpageorder" runat="server" CssClass="input">
        </asp:DropDownList><asp:DropDownList ID="ddlpagedesc" runat="server" CssClass="input">
            <asp:ListItem Value="DESC">降序</asp:ListItem>
            <asp:ListItem Value="ASC">升序</asp:ListItem>
        </asp:DropDownList></td>
</tr>
<tr>
<th>资讯导读显示字数：</th>
<td>
    <asp:TextBox ID="tbpageproductnum" runat="server" CssClass="input" MaxLength="10" onblur="isNumer(this);"></asp:TextBox></td>
</tr>
<tr>
<th>&nbsp;</th>
<td><label> &nbsp;<asp:button id="btnPageOK" runat="server" CssClass="button" Text="确定创建此标签" OnClick="BtnNewsPageList"></asp:button>&nbsp;
    <input id="Button4" class="button" type="button" value="取消" onclick="closewindows();" /></label></td>
</tr>
</table>




<!--企业新闻列表设置 -->
<%--<table width="100%" class="xy_tb xy_tb2 setLabelData" id="key" style="display:none;" >
<tr>
<th>
    调用数量：</th>
<td>
        <asp:TextBox ID="txtTopNumberForUserNews" runat="server" CssClass="input" MaxLength="10" onblur="isNumer(this);" Text="10"></asp:TextBox>
        </td>
</tr>
<tr><th>
    标题显示字数：</th>
    <td>
    <asp:TextBox ID="txtTitleNumberForUserNews" runat="server" CssClass="input" MaxLength="10" onblur="isNumer(this);"></asp:TextBox></td>
</tr>
<tr>
<th>日期格式：</th>
<td>
    <asp:DropDownList ID="ddlDateFormatForUserNews" runat="server">
        <asp:ListItem Value="">请选择</asp:ListItem>
        <asp:ListItem Value="yyyy-MM-dd">yyyy-MM-dd</asp:ListItem>
        <asp:ListItem Value="yy-MM-dd">yy-MM-dd</asp:ListItem>
        <asp:ListItem Value="MM.dd">MM.dd</asp:ListItem>
        <asp:ListItem Value="MM-dd">MM-dd</asp:ListItem>
        <asp:ListItem Value="MM\\dd">MM\dd</asp:ListItem>
    </asp:DropDownList></td>
</tr>

<tr>
<th>指定企业：</th>
<td>
    <asp:TextBox ID="txtLoginNameForUserNews" runat="server" CssClass="input" MaxLength="15"></asp:TextBox><br/>
    请指定企业用户登录名;可以不指定,则默认调用所有企业新闻</td>
</tr>
<tr>
<th>&nbsp;</th>
<td><label> <asp:button id="btnCreateEnterpriseNews" runat="server" CssClass="button" Text="确定创建此标签" OnClick="btnCreateEnterpriseNews_Click" ></asp:button>&nbsp;
    <input id="btnEnterpriseCancel" class="button" type="button" value="取消" onclick="closewindows();" /></label></td>
</tr>
</table>--%>

</div>

</td>
</tr>
</table>
</form>
</body>
</html>
<script type="text/javascript">
var cla = new ClassType("cla",'news','classType1','hdgetid');
cla.Mode = "select";
cla.Init();
</script>
