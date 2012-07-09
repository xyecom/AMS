<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateCache.aspx.cs" Inherits="XYECOM.Web.xymanage.Global.UpdateCache" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>缓存更新</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
</head>
<body>


    <form id="form1" runat="server">
<h1><a href="../index.aspx">后台管理首页</a> >> 缓存管理</h1>
<table width="100%">
<tr>
<td class="right">

<div class="main-setting">
  <table class="xy_tb xy_tb2">
<tr>
<td class="right ">
        <table style="width:100%" >
        <caption style="text-align:left;">缓存配置：</caption>
            <tr>
                <td width="85%">
                缓存时间:<asp:TextBox ID="txtCacehTimeSpan" runat="server" MaxLength="4" Columns="5"></asp:TextBox>(单位：分钟,0为不缓存)
                
                </td>
                <td width="15%">
                <asp:Button runat="server" Text="保存设置" ID="btnOK" CssClass="button" OnClick="btnOK_Click"/>
                </td>
            </tr>
        </table>
   <br/>
        <table  style="width:100%">
        <caption style="text-align:left;">更新系统配置：</caption>
            <tr>
                <td><asp:Button id="btnUpdateWebConfig" runat="server" Text="更新系统配置信息" CssClass="button" OnClick="btnUpdateWebConfig_Click"/></td>
            </tr>
        </table>
   <br/><br/>
        <table style="width:100%">
        <caption style="text-align:left;">更新缓存：</caption>
            <tr>
                <td colspan="2"><asp:Button id="btnUpdateAllCache" runat="server" Text="更新全部缓存" CssClass="button" OnClick="btnUpdateAllCache_Click"/></td>
            </tr>
            <tr>
                <td><asp:Button id="btnUpdateContentLabelCache" runat="server" Text="更新内容标签缓存" CssClass="button" OnClick="btnUpdateContentLabelCache_Click"/></td>
                <td><asp:Button id="btnUpdateClassLabelCache" runat="server" Text="更新导航标签缓存" CssClass="button" OnClick="btnUpdateClassLabelCache_Click"/></td>
            </tr>
            <tr>
                <td style="height: 40px"><asp:Button id="btnUpdateSystemLabelCache" runat="server" Text="更新系统标签缓存" CssClass="button" OnClick="btnUpdateSystemLabelCache_Click"/></td>
                <td style="height: 40px"><asp:Button id="btnUpdateClassInfoStatCache" runat="server" Text="更新分类信息统计缓存" CssClass="button" OnClick="btnUpdateClassInfoStatCache_Click"/></td>
            </tr>
            <tr>
                <td style="height: 40px"><asp:Button id="btnUpdatePollLabelCache" runat="server" Text="更新投票标签缓存" CssClass="button" OnClick="btnUpdatePollLabelCache_Click"/></td>
                <td style="height: 40px"></td>
            </tr>
        </table>
        <!--
     <br/><br/>  
        <table  style="width:100%">
        <caption style="text-align:left;">更新分类信息总数统计：</caption>
            <tr>
                <td>
                <div style="background-color:#ffffe1; line-height:150%; padding:5px; border:1px dashed #e4d74a;">
                系统会根据数据变动自行维护统计数据，能保证统计数据的基本正确，所以不建议频繁操作。<br/>
                在进行大批量的数据操作或间隔较长时间后建议重新统计。<br/>
                子模块数据会在统计父模块时一并统计。
                </div>
                </td>
            </tr>
            <tr>
                <td>
                <asp:DropDownList ID="ddlSortType" runat="server">
                    <asp:ListItem Text="请选择分类" Value="all"></asp:ListItem>
                    <asp:ListItem Text="产品分类" Value="offer"></asp:ListItem>
                    <asp:ListItem Text="加工分类" Value="venture"></asp:ListItem>
                    <asp:ListItem Text="招商加盟分类" Value="investment"></asp:ListItem>
                    <asp:ListItem Text="服务分类" Value="service"></asp:ListItem>
                    <asp:ListItem Text="品牌分类" Value="brand"></asp:ListItem>
                    <asp:ListItem Text="展会分类" Value="exhibition"></asp:ListItem>
                    <asp:ListItem Text="企业分类" Value="company"></asp:ListItem>
                    <asp:ListItem Text="岗位分类" Value="job"></asp:ListItem>
                </asp:DropDownList>
                <asp:Button id="btnUpdateClassTotalStat" runat="server" Text="更新分类信息总数统计" CssClass="button" OnClick="btnUpdateClassTotalStat_Click"/>
                </td>
            </tr>
        </table>
        -->
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
