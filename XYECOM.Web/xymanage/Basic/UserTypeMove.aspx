<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserTypeMove.aspx.cs" Inherits="XYECOM.Web.xymanage.Basic.UserTypeMove" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
 <title>分类转移</title>
 <link href="../css/style.css" type="text/css" rel="stylesheet" />
 <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
 <script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
 <script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
<script language ="javascript" type ="text/javascript" src ="../javascript/labelClass.js"></script>

</head>
<body>
<form id="form1" runat="server">

<h1><a href="../index.aspx">后台管理首页</a> >> 分类转移</h1>

<table width="100%" >
<tr>
<td class="right">
<!--后台导航 -->



<div class="main-setting">
<div class="itemtitle"><h3>分类转移</h3></div>


<table width="100%" class="xy_tb xy_tb2" id="InfoShow">

<tr>
    <td valign="top" style="text-align:left; width:30%; line-height:200%;">
    <b>当前选择的分类是：</b>
    <br />
    <asp:Label ID="Label1" runat="server"></asp:Label>    
    <br/><br/>
    <b>转移选项：</b><br/>
    <asp:RadioButton ID="rbttype" runat="server" Checked="True" GroupName="rbt" Text="转 移 分 类" />
    <br />
    <asp:RadioButton ID="rbtdata" runat="server" GroupName="rbt" Text="转移分类下所有数据" />
    </td>
    <td align="left" id="tdSuperClass" style="width:70%;">
            <b>转移到：</b><br/>
        <div style="height:350px; OVERFLOW-Y: scroll; OVERFLOW-X:hidden; border:1px #cccccc solid; padding:5px;">
              <asp:Panel ID="pnlSuperClass" runat="server"  CssClass="classTreeList">
               </asp:Panel>
        </div>
    </td>
</tr>
<tr>
    <td></td>
    <td style="height: 23px" align="left" >
        <input type="submit" value="转移" onclick="return CheckSelectClassNumber();" class="button"/> 
        <input id="Button1" class="button" type="button" value="返回" onclick="javascript:history.go(-1);" />
        <asp:Button ID="btnok" runat="server" Text="设置为一级类别" CssClass="button" OnClick="btnok_Click"/>
        <asp:Label ID="lblMessage" runat="server"  ForeColor="Red"></asp:Label>
        <input type="hidden" id="hidptid" value="" runat="server" />
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
