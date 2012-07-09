<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowAdd.aspx.cs" Inherits="XYECOM.Web.xymanage.ShowInfoManage.ShowAdd" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc1" %>
<%@ Register Src="../UserControl/UploadImage.ascx" TagName="UploadImage" TagPrefix="uc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>添加展会信息</title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script language="javascript" type ="text/javascript" src ="../javascript/CheckedAll.js"></script>
<script type="text/javascript" src="/common/js/date.js" ></script>
<script type="text/javascript" src="../javascript/TreeType.js" ></script>
<script language ="javascript" type="text/javascript"  src="/common/js/UploadControl.js"></script>
</head>
<body>
<form id="Form1" method="post" runat="server">
<h1><a href="../index.aspx">后台管理首页</a> >> <asp:Label ID="Label1" runat="server" Text="添加展会信息"></asp:Label></h1>
<table  width="100%" >
<tr>
<!-- right -->
<td class="right">
<!--后台导航 -->



<div class="main-setting">
<div class="itemtitle"><h3>供求详细信息</h3></div>


<table width="100%" class="xy_tb xy_tb2 infotable">
<tr>
<th>展会名称：</th>
<td>
    <asp:TextBox ID="txtname" runat="server" Columns="60"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvname" runat="server" ControlToValidate="txtname"
        ErrorMessage="请填写展会名称！"></asp:RequiredFieldValidator></td>
</tr>
<tr>
<th>展会类别：</th>
<td>
<div id="classType"></div>
<input id="hidptid" name="hidptid" runat="server" type="hidden" value="" />
<script type="text/javascript">
var cla = new ClassType("cla",'exhibition','classType','hidptid');
cla.Mode ="select";
cla.Init();
</script>

    </td>
</tr>
<tr>
<th>详细说明：</th>
<td><label>
<FCKeditorV2:FCKeditor ID="lbcontent" runat="server" BasePath="/Common/fckeditor/" ToolbarSet="User" Height="300px">
</FCKeditorV2:FCKeditor>
</label></td>
</tr>

<tr>
<th>上传图片：</th>
<td>
 <uc1:UploadImage ID="UploadFile1" runat="server" Iswatermark="false" MaxAmount="20" TableName="i_ShowInfo" InfoID="0"  />
</td>
</tr>

<tr>
<th>开幕时间：</th>
<td style="height: 21px"><label>
<input id="bgdate" type="text" runat="server" readonly="readonly" onclick="getDateString(this);" maxlength="10" style="width:80px;" />
    <asp:RequiredFieldValidator ID="rvfdate" runat="server" ControlToValidate="bgdate"
        ErrorMessage="请选择开幕时间！"></asp:RequiredFieldValidator></label></td>
</tr>

<tr>
<th>闭幕时间：</th>
<td style="height: 21px"><label>
<input id="egdate" type="text" readonly="readonly" runat="server" onclick="getDateString(this);" maxlength="10" style="width: 80px;" />
    <asp:RequiredFieldValidator ID="rvfed" runat="server" ControlToValidate="egdate"
        ErrorMessage="请选择闭幕时间！"></asp:RequiredFieldValidator></label></td>
</tr>
<tr>
<th>展会周期：</th>
<td><label>
    <asp:DropDownList ID="showzhouqi" runat="server" Width="80">
        <asp:ListItem>请选择</asp:ListItem>
        <asp:ListItem>一年两次</asp:ListItem>
        <asp:ListItem Selected="True">一年一次</asp:ListItem>
        <asp:ListItem>两年一次</asp:ListItem>
        <asp:ListItem>三年一次</asp:ListItem>
        <asp:ListItem>四年一次</asp:ListItem>
        <asp:ListItem>其他</asp:ListItem>
    </asp:DropDownList></label></td>
</tr>

<tr>
<th>展会类型：</th>
<td><label>
    <asp:DropDownList ID="showtype" runat="server" Width="80">
        <asp:ListItem>国内展</asp:ListItem>
        <asp:ListItem>国外展</asp:ListItem>
    </asp:DropDownList></label></td>
</tr>
<tr>
<th>展会地点：</th>
<td><label>
    <asp:TextBox ID="txtshowaddress" runat="server" Columns="60" TextMode="MultiLine" Rows="2"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvdidian" runat="server" ControlToValidate="txtshowaddress"
        ErrorMessage="请填写展会地点！"></asp:RequiredFieldValidator></label></td>
</tr>

<tr>
<th>展会场馆：</th>
<td><label>
    <asp:TextBox ID="txtshowchang" runat="server" Columns="60" TextMode="MultiLine" Rows="2"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvchangguan" runat="server" ControlToValidate="txtshowchang"
        ErrorMessage="请填写展会场馆！"></asp:RequiredFieldValidator></label></td>
</tr>

<tr>
<th>主办单位：</th>
<td><label>
    <asp:TextBox ID="txtdanwei" runat="server" Columns="60" TextMode="MultiLine" Rows="4"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
        ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtdanwei" ErrorMessage="请填写主办单位！"></asp:RequiredFieldValidator></label></td>
</tr>

<tr>
<th>承办单位：</th>
<td><label>
    <asp:TextBox ID="txtundertakepost" runat="server"  Columns="60" TextMode="MultiLine" Rows="4"></asp:TextBox>&nbsp;</label></td>
</tr>

<tr>
<th>协办单位：</th>
<td><label>
    <asp:TextBox ID="txtxieban" runat="server"  Columns="60" TextMode="MultiLine" Rows="4"></asp:TextBox>&nbsp;</label></td>
</tr>

<tr>
<th>支持单位：</th>
<td style="height: 21px"><label>
    <asp:TextBox ID="txtshowsuoppt" runat="server"  Columns="60" TextMode="MultiLine" Rows="4"></asp:TextBox>&nbsp;</label></td>
</tr>



<tr>
<th>展会网址：</th>
<td><label>
    <asp:TextBox ID="txtshowhomepage" runat="server"  Columns="60"></asp:TextBox>&nbsp;</label></td>
</tr>

<tr>
<th>净地面积单位：</th>
<td style="height: 21px"><label>
    <asp:TextBox ID="txtshowareaunit" runat="server"></asp:TextBox>&nbsp;</label></td>
</tr>

<tr>
<th>净地单价：</th>
<td><label>
    <asp:TextBox ID="txtshowprice" runat="server"></asp:TextBox>
    </label></td>
</tr>

<tr>
<th>净地起定量：</th>
<td><label>
    <asp:TextBox ID="txtshowunit" runat="server"></asp:TextBox>
    </label></td>
</tr>

<tr>
<th>展位面积总量：</th>
<td><label>
    <asp:TextBox ID="txtshowarea" runat="server"></asp:TextBox>
    </label></td>
</tr>
<tr>
<th>&nbsp;</th>
<td class="padleft"><label>
    &nbsp;<asp:Button ID="Button1" runat="server" CssClass="button" Text="保存" OnClick="Button1_Click" />
    <input id="Button2" type="button" value="返回" onclick ="window.location.href='ShowInfoList.aspx?<%= backURL %>';" class ="button" />
    <asp:Label ID="lblMessage" runat="server" ForeColor="#C00000"></asp:Label>
    &nbsp;
    </label></td>
</tr>
</table> 

</div>
</td> 
</tr> 
</table> 
</form>
</body>
</html>
