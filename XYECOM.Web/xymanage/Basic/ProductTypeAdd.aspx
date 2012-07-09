<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_basic_ProductTypeAdd" Codebehind="ProductTypeAdd.aspx.cs" %>

<%@ Register Src="../UserControl/top.ascx" TagName="top" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>��Ʒ�������</title>
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
<h1><a href="../index.aspx">��̨������ҳ</a> &gt;&gt; ��Ʒ�������</h1>
<table width="100%" >
<tr>
<td class="right">

<div class="main-setting">
<div class="itemtitle"><h3>��Ʒ�������</h3></div>
    
<table class="xy_tb xy_tb2">

<tr class="nobg">
  <td colspan="2" class="td27" style="height: 27px">�������ƣ�</td>
</tr>
<tr>
   <td class="vtop rowform">    
    <asp:TextBox onBlur="PinYinZhuanHuan();" ID="tbName" Width="350px"   runat="server" CssClass="input" MaxLength="20" Rows="5" TextMode="MultiLine"></asp:TextBox>
        
   </td>
   <td class="vtop tips2"><asp:Label ID="lbremark" runat="server" Text="��Ӷ���ԡ�,���Ÿ�����"></asp:Label></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">�ϼ����ࣺ</td>
</tr>
<tr>
   <td class="vtop rowform">    
    <asp:Label ID="lblName" runat="server"></asp:Label>
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr id="module2" runat="server" class="nobg">
  <td colspan="2" class="td27">����ģ�飺</td>
</tr>
<tr runat="server" id="module">
   <td class="vtop rowform" style="height: 30px">    
       <asp:Label ID="lblType" runat="server"></asp:Label></td>
   <td class="vtop tips2" style="height: 30px">    
   </td>
</tr>
<tr class="nobg" id="FlagName1">
  <td colspan="2" class="td27" >��ʶ���ƣ�</td>
</tr>
<tr id="FlagName2" >
   <td class="vtop rowform" style="width:300px;">
   <asp:TextBox ID="txtFlagName" Width="350px" MaxLength="20" Rows="5" TextMode="MultiLine" runat="server"></asp:TextBox>
       <br />
       <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtFlagName"
           ErrorMessage="��ʶ���Ʊ���Ϊ��ĸ���ҳ��ȱ����� 2 �� 50 ֮��" ValidationExpression="([a-zA-Z_1-9,��]){2,500}"></asp:RegularExpressionValidator>--%></td>
   <td class="vtop tips2" style="border-left-width">
   ��a~z���,������2 �� 50 ֮������ƣ������ظ�<br/>
   ������ö�������������Ϊ������
   </td>
</tr>

<tr id="isCustom">
    <td class="vtop rowform" style="width:200px;">
        <asp:CheckBox ID="chkIsCustomTemplate" runat="server" Text="�Ƿ��Զ���ģ��"/>
    </td>
    <td  class="vtop tips2">
    Ĭ��Ϊ������<br/>
    ���Ҫ�Զ���ģ�壬���ڵ�ǰģ�� cate Ŀ¼���Ա�ʶ����Ϊ�����½��ļ��У�����ģ����õ����ļ��£�ģ������Ϊ index.htm
    </td>
</tr>

<tr id="trTrade1" runat="server" class="nobg">
  <td colspan="2" class="td27" style="height: 35px">�����ҵ��
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
   ��Ʒ������������ҵ��
   </td>
</tr>
<tr>
<td colspan="2" class="content_action"><asp:button id="btnok" runat="server" CssClass="button" Text="����" OnClick="btnok_Click"  ></asp:button>
    <asp:Button ID="Button2" runat="server" CssClass="button" OnClick="Button1_Click"
        Text="����" />
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


