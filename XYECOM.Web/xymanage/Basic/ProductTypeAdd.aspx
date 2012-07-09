<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_basic_ProductTypeAdd" Codebehind="ProductTypeAdd.aspx.cs" %>

<%@ Register Src="../UserControl/top.ascx" TagName="top" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>产品分类管理</title>
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script type="text/javascript" src="../javascript/CheckedAll.js" ></script>
<script language="vbscript">
function toAsc(str)
toAsc = hex(asc(str))
end function
</script>


<script language="javascript" type="text/javascript">

function InitEidt()
{
    var parentModuleName = document.getElementById("ParentModuleName").value;
    
    if(parentModuleName =="offer")
    {
        document.getElementById("trTrade1").style.display ="";
        document.getElementById("trTrade2").style.display ="";
        document.getElementById("FlagName1").style.display ="block";
        document.getElementById("FlagName2").style.display ="block";
        document.getElementById("isCustom").style.display ="block";
    }
    else
    {
        document.getElementById("trTrade1").style.display ="none";
        document.getElementById("trTrade2").style.display ="none";
    }   
}

function PinYinZhuanHuan()
{
   
    var s = document.getElementById("tbName").value; 
    
    if(s !="")
    {
        s = CheckIfEnglish(toPinyin(s));
        document.getElementById("txtFlagName").value=s;
    }
    
    
}



function GetUrl()
{
    var str=window.location.href;
    var es=/add=/;
    es.exec(str);
    var add=RegExp.rightContext;
    if(add ==1)
    {
        document.getElementById("trTrade1").style.display ="block";
        document.getElementById("trTrade2").style.display ="block";
    }
}

</script>
</head>
<body onload="InitEidt();GetUrl()">
<form id="form1" runat="server" >
<h1><a href="../index.aspx">后台管理首页</a> &gt;&gt; 产品分类管理</h1>
<table width="100%" >
<tr>
<td class="right">

<div class="main-setting">
<div class="itemtitle"><h3>产品分类管理</h3></div>
    
<table class="xy_tb xy_tb2">

<tr class="nobg">
  <td colspan="2" class="td27" style="height: 27px">分类名称：</td>
</tr>
<tr>
   <td class="vtop rowform">    
    <asp:TextBox onBlur="PinYinZhuanHuan();" ID="tbName" Width="350px"   runat="server" CssClass="input" MaxLength="20" Rows="5" TextMode="MultiLine"></asp:TextBox>
        
   </td>
   <td class="vtop tips2"><asp:Label ID="lbremark" runat="server" Text="添加多个以“,”号隔开；"></asp:Label></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">上级分类：</td>
</tr>
<tr>
   <td class="vtop rowform">    
    <asp:Label ID="lblName" runat="server"></asp:Label>
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr id="module2" runat="server" class="nobg">
  <td colspan="2" class="td27">所属模块：</td>
</tr>
<tr runat="server" id="module">
   <td class="vtop rowform" style="height: 30px">    
       <asp:Label ID="lblType" runat="server"></asp:Label></td>
   <td class="vtop tips2" style="height: 30px">    
   </td>
</tr>
<tr class="nobg" id="FlagName1">
  <td colspan="2" class="td27" >标识名称：</td>
</tr>
<tr id="FlagName2" >
   <td class="vtop rowform" style="width:300px;">
   <asp:TextBox ID="txtFlagName" Width="350px" MaxLength="20" Rows="5" TextMode="MultiLine" runat="server"></asp:TextBox>
       <br />
       <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtFlagName"
           ErrorMessage="标识名称必须为字母，且长度必须在 2 ～ 50 之间" ValidationExpression="([a-zA-Z_1-9,，]){2,500}"></asp:RegularExpressionValidator>--%></td>
   <td class="vtop tips2" style="border-left-width">
   由a~z组成,长度在2 ～ 50 之间的名称，不能重复<br/>
   如果启用二级域名，将作为主机名
   </td>
</tr>

<tr id="isCustom">
    <td class="vtop rowform" style="width:200px;">
        <asp:CheckBox ID="chkIsCustomTemplate" runat="server" Text="是否自定义模板"/>
    </td>
    <td  class="vtop tips2">
    默认为不启用<br/>
    如果要自定义模板，请在当前模板 cate 目录下以标识名称为名字新建文件夹，并把模板放置到新文件下，模板名称为 index.htm
    </td>
</tr>

<tr id="trTrade1" runat="server" class="nobg">
  <td colspan="2" class="td27" style="height: 35px">相关行业：
  <input type="hidden" name="IsRoot" id="IsRoot" value="0" runat="server" />
  <input type="hidden" name="IsEdit" id="IsEdit" value="" runat="server" />
  <input type="hidden" name="ParentModuleName" id="ParentModuleName" value="" runat="server" />
  </td>
</tr>
<tr runat="server" id="trTrade2">
   <td class="vtop" style="height: 32px">    

        <div id="divTrade" style="line-height:20px; padding:0;"></div>
        <input type ="hidden" id="tradeid" runat="server"/>
        <script type="text/javascript">
        var clsTrade = new ClassType("clsTrade",'trade','divTrade','tradeid');
        clsTrade.Mode ="select";
        clsTrade.Init();
        </script>

   </td>
   <td class="vtop tips2" style="height: 32px">
   产品顶级分类与行业绑定
   </td>
</tr>
<tr>
<td colspan="2" class="content_action"><asp:button id="btnok" runat="server" CssClass="button" Text="保存" OnClick="btnok_Click"  ></asp:button>
    <asp:Button ID="Button2" runat="server" CssClass="button" OnClick="Button1_Click"
        Text="返回" />
<input type="hidden" id="hidLT_ID" value="" runat="server" /></td>
</tr>
</table>

</div>
</td>
</tr>
</table>
</form>
</body>
</html>


