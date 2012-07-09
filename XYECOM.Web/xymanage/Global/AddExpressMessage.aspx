<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddExpressMessage.aspx.cs" Inherits="XYECOM.Web.xymanage.Global.AddExpressMessage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
 <title>后台添加系统快速留言</title>
 <link href="../css/style.css" type="text/css" rel="stylesheet" />
 <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
 <script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
 <script language="javascript" type="text/javascript">
 function input()
 {
   if(document.getElementById("hidsmid").value == "-1")
   {
       var type = false;
       var chklist = document.all.tags("input");
       for (i=0; i < chklist.length;i++)
       {
           if(chklist[i].type == "checkbox")
            {
               if(chklist[i].checked == true)
               {
                  type = true;
                  break;
               }
            }
       } 
       if(type == false)
       {
          return alertmsg("请选择留言类别.","",false);
       }
   }
   if(document.getElementById("txtBody").value == "")
   {
      return alertmsg("留言标题不能为空.","",false);
   }
 }
 
 
 </script>  
</head>
<body>
<form id="form1" runat="server"> 
<h1><a href="../index.aspx">后台首页</a> >> 编辑系统快速留言</h1>
 <table width="100%">
 <tr>
 <td class="right">

<div class="main-setting">
<div class="itemtitle"><h3 id="caption" runat="server">编辑系统快速留言</h3></div>
 
<table class="xy_tb xy_tb2">
<tr class="nobg">
  <td class="td27">所属模块：</td>
</tr>
<tr>
   <td class="vtop">
    <asp:CheckBoxList runat="server" ID="chklstModules"  RepeatDirection="Horizontal" RepeatColumns="5" CssClass="input">

  </asp:CheckBoxList>
  <asp:Label ID="lbtype" runat="server"></asp:Label>
      <input id="hidModuleName" type="hidden" runat="server" />
   </td>
</tr>
<tr class="nobg">
  <td class="td27">留言内容：</td>
</tr>
<tr>
   <td class="vtop">
    <asp:TextBox ID="txtBody" runat="server" Columns="100" TextMode="MultiLine" CssClass="input" MaxLength="200" Rows="4"></asp:TextBox>
     <input id="hidMsgId" runat="server" type="hidden" />
   </td>
</tr>

 <tr>
    <td><asp:Button ID="btnAdd" runat="server" CssClass="button" Text="提交留言" OnClick="btnAdd_Click"/>&nbsp;
                           <input id="btnCancel" runat="server" class="button" type="button" value="返回" onserverclick="btnCancel_ServerClick" /></td>
 </tr>
 </table>
</div>
 </td>
 </tr>
 </table>
</form>
</body>
</html>
