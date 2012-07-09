<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserNewsInfo.aspx.cs" Inherits="XYECOM.Web.xymanage.News.UserNewsInfo" %>

<%@ Register Src="../UserControl/UploadFile.ascx" TagName="UploadFile" TagPrefix="uc2" %>
<%@ Register Src="../UserControl/UploadImage.ascx" TagName="UploadImage" TagPrefix="uc1" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
 
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>后台添加新闻</title>

<link href="../css/cue.css" type="text/css" rel="stylesheet" />
<link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
<link href="../css/style.css" type="text/css" rel="stylesheet" /> 
<style>
    .selChannel a{ background-color:#f60;}
    .selChannel a {
		 margin:3px 0; margin-left:4px;padding:2px 5px; *padding:4px 5px 1px; BORDER-RIGHT: #7b9ebd 1px solid; BORDER-TOP: #7b9ebd 1px solid; FONT-SIZE: 12px; background:url(../css/bgimages/btn_bg.gif)  repeat-x left top;  BORDER-LEFT: #7b9ebd 1px solid; CURSOR: hand; COLOR: black; BORDER-BOTTOM: #7b9ebd 1px solid;
	}
    .selChannel div{ line-height:200%;}
</style>
<script language="javascript" type="text/javascript" src="/common/js/base.js"></script>
<script language ="javascript" type="text/javascript"  src="/common/js/UploadControl.js"></script>
<script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
<script language="javascript" type="text/javascript" src="../javascript/GetKeyWord.js"></script>
<script language="javascript" type="text/javascript" src="/common/js/date.js"></script>
<script language="javascript" type="text/javascript" src="../javascript/AddNews.js"></script>
</head>
<body>
<form id="form1" runat="server">
<h1><a href="../index.aspx">后台首页</a> >> 添加资讯</h1>
<table width="100%">
<tr>
<td class="right" style="height:auto">
  


<div class="main-setting">
<div class="itemtitle"><h3>
    修改资讯</h3></div>

<table width="100%" class="xy_tb xy_tb2 infotable" id="InfoShow">
<tr>
 <th>资讯标题：</th>
 <td > 
     <asp:TextBox ID="txtTitle" runat="server" Columns="80" CssClass="input"></asp:TextBox></td>    
</tr>
<tr>
 <th>副标题：</th>
 <td > 
     <asp:TextBox ID="txtTowTitle" runat="server" Columns="80" CssClass="input"></asp:TextBox></td>    
</tr>
<tr>
 <th>资讯栏目：</th>
 <td > 
 <asp:Literal runat="server" ID="txtTitleInfo"></asp:Literal></td>    
</tr>
<tr>
 <th>关键字：</th>
 <td > 
     <asp:TextBox ID="txtKeyWord" runat="server" Columns="80" CssClass="input"></asp:TextBox></td>    
</tr>
<tr>
 <th>资讯作者：</th>
 <td > 
     <asp:TextBox ID="txtAuthor" runat="server" Columns="80" CssClass="input"></asp:TextBox></td>    
</tr>
<tr>
 <th>资讯来源：</th>
 <td > 
     <asp:TextBox ID="txtOrigin" runat="server" Columns="80" CssClass="input"></asp:TextBox></td>    
</tr>
<tr>
 <th>资讯导读：</th>
 <td > 
     <asp:TextBox ID="txtLess" runat="server" Columns="80" CssClass="input"></asp:TextBox></td>    
</tr>
<tr id="TR5" style="display:block">
<th>资讯正文：</th>
<td class="floatAlertTable">
<!--Editer Start-->
<FCKeditorV2:FCKeditor ID="newsBody" runat="server" BasePath="/Common/fckeditor/" ToolbarSet="Basic" Height="300px">

</FCKeditorV2:FCKeditor>
</td>    
</tr>
<tr>
    <th></th>
    <td>	 <asp:Button ID="btadadd" runat="server" CssClass="button" Text="保存资讯" OnClick="btadadd_Click"  />&nbsp;
     <input id="btcancel" runat="server" class="button" type="button" value="返回" onserverclick="btcancel_ServerClick" /></td>
</tr>
</table>
</div>
</td>
</tr>
</table>
</form>
</body>
</html>

