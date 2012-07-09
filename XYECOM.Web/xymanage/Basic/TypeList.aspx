<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_basic_Typelist" Codebehind="Typelist.aspx.cs" %>
<%@ Register Src="../UserControl/top.ascx" TagName="top" TagPrefix="uc1" %>
<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>产品类别管理</title>
<link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
<script language ="javascript" type ="text/javascript" src ="../javascript/list.js"></script>
<script language ="javascript" type ="text/javascript" src ="../javascript/labelClass.js"></script>
<script language ="javascript" type ="text/javascript" src ="../../config/js/config.js"></script>

<style type="text/css">
.hide {border-top:3px solid #AAC7E9;border-right:1px solid #AAC7E9;border-bottom:1px solid #AAC7E9; background:#E8F5FE;border-left:1px solid #AAC7E9;cursor:hand;}
.show {border-top:3px solid #ff9900;border-right:1px solid #AAC7E9;border-bottom:1px solid #AAC7E9; border-left:1px solid #AAC7E9;background:#FFFFDD;cursor:hand;}
.lfloat {float:left;}


.tabs1{margin-top:10px; margin-left:10px;}
.tabs{width:97%; margin:10px auto 0 auto; background:#fff;border:0px solid #ccc; text-align:center;}
</style>
    <style type="text/css">
    .YMenuList li{margin:0px;padding:2px; padding-left:5px;}
    .Yhover{background-color:#f1f5f8; font-weight:bold;}

    .YMenuBody{z-index:1;padding-left:5px;}
    </style>

</head>
<body>
<form id="Form1" method="post" runat="server">
<h1><a href="../index.aspx">后台管理首页</a> &gt;&gt; 供求产品类别管理</h1>
<table width="100%" >
<tr>
<td class="right">

<div class="main-setting">
<div class="itemtitle"><h3>
    类别管理</h3>
<asp:DropDownList ID="ddlTypeAdd" CssClass="ddltype" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTypeAdd_SelectedIndexChanged">
        <asp:ListItem>新增分类</asp:ListItem>
    </asp:DropDownList>
</div>
    


<table class="xy_tb" cellpadding="0" cellspacing="0">   
    <tr>
        <td colspan="2" style="height:6px;border-bottom:0px;"></td>
    </tr>
    <tr>
        <td class="YMenuList" style="width:15%; margin:0px; padding:0px; border-bottom:0px;" valign="top">
            <ul id="leftYMenu" runat="server" style="width:100%;margin:0px;">

            </ul>
        </td>
        <td style="background-color:#f1f5f8; width:85%; padding-left:10px;" valign="top">          
            <asp:Panel ID="pnlSuperClass" runat="server" CssClass="classTreeList">
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
        <input type="hidden" id="strdel" value="" runat="server"/>
        </td>
        <td>
        <input type="submit" value="批量删除" onclick="return delall();" class="button" id="Submit1"/> 
        </td>
    </tr>
        <tr>
        <td colspan="2" style="height:6px;border-bottom:0px;"></td>
    </tr>
</table>
</div>
</td>
</tr>
</table>
</form>
</body>
</html>
