<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditAreaSite.aspx.cs" Inherits="XYECOM.Web.xymanage.Global.EditAreaSite" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>地方站信息编辑</title>
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="../css/cue.css" type="text/css" rel="stylesheet" />
    <script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
    <script language ="javascript" type="text/javascript"  src="/config/js/config.js"></script>
    <script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js" ></script>
    <style type="text/css">
    .hide{ display:none}
    </style>
    <script language="javascript" type="text/javascript">
        function Initaa()
        {
            if(document.getElementById("txtAraeID").value!="")
            {
                document.getElementById("tdArea").disabled = true;
            }
        }
    </script>
</head>
<body onload="Initaa();">
    <form id="form1" runat="server">
    <h1><a href="../index.aspx">后台管理首页</a> &gt;&gt; 地方站信息</h1>
    <table width="100%">
<tr>
<td class="right">

<div class="main-setting">
<div class="itemtitle"><h3>地方站信息</h3>
</div>

<table class="xy_tb xy_tb2">

<tr class="nobg">
  <td colspan="2" class="td27">选择地区：<asp:TextBox runat="server" ID="txtAraeID" CssClass="hide"></asp:TextBox></td>
</tr>
<tr>
   <td class="vtop" id="tdArea">

<div id="classType"></div>

<script type="text/javascript">
var cla = new ClassType("cla",'area','classType','txtAraeID');
cla.Mode ="select";
cla.Init();
</script>
<br/>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAraeID"
           ErrorMessage="请选择地区"></asp:RequiredFieldValidator></td>
   <td class="vtop tips2">地方站对应的地区，添加成功后不能修改</td>
</tr>
<tr class="nobg">
  <td colspan="2" class="td27">标识名称：</td>
</tr>
<tr>
   <td class="vtop rowform" style="width:200px;">
   <asp:TextBox ID="txtFlagName" runat="server"></asp:TextBox><br />
       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFlagName"
           ErrorMessage="标识名称不能为空"></asp:RequiredFieldValidator><br />
       <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtFlagName"
           ErrorMessage="标识名称必须为字母，且长度必须在 2 ～ 20 之间" ValidationExpression="[a-zA-Z]{2,20}"></asp:RegularExpressionValidator></td>
   <td class="vtop tips2">
    由a~z组成,长度在2 ～ 20 之间的名称，不能重复
   </td>
</tr>

<tr>
    <td class="vtop rowform" style="width:200px;">
        <asp:CheckBox ID="chkIsCustomTemplate" runat="server" Text="是否自定义模板"/>
    </td>
    <td  class="vtop tips2">
    默认为不启用<br/>
    如果要自定义模板，请在当前模板 area 目录下以标识名称为名字新建文件夹，并把模板放置到新文件下，模板名称为 index.htm
    </td>
</tr>

  <tr>
   <td colspan="2" class="content_action">
   <asp:Button ID="btnOK" runat="server" CssClass="button" Text="确定" OnClick="btnOK_Click"/>
	  <input class="button" type="button" value="取消" runat="server" id="btcancle" onclick="location.href='AreaSiteManage.aspx';"/></td>
 </tr>
 </table>
 </div>
 </td>
 </tr>
 </table>

    </form>
</body>
</html>