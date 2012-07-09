<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddSubject.aspx.cs" Inherits="XYECOM.Web.xymanage.VoteManage.AddSubject" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>新增调查问题</title>
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script type="text/javascript" src="../javascript/CheckedAll.js" ></script>
</head>
<body>
<form id="form1" runat="server">
<h1><a href="../index.aspx">后台管理首页</a> >> 新增调查问题</h1>
<table width="100%" >
<tr>
<td class="right">    

<div class="main-setting">
<div class="itemtitle"><h3 id="title" runat="server">新增调查问题</h3>
</div>
<table class="xy_tb xy_tb2 ">

<tr class="nobg">
  <td colspan="2" class="td27">所属调查：</td>
</tr>
<tr>
   <td class="vtop rowform" style="width:500px;">
    <asp:Label ID="lblVoteTitle" runat="server"></asp:Label>
    </td>
   <td class="vtop tips2"><span></span></td>
</tr>


<tr class="nobg">
  <td colspan="2" class="td27">问题：</td>
</tr>
<tr>
   <td class="vtop rowform" style="font-weight:bold; width:500px; height: 48px;">
     <asp:TextBox ID="txtSubject" Columns="30" runat="server" CssClass="input" 
           MaxLength="50" Width="450px"></asp:TextBox>
     <br/>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSubject"
           ErrorMessage="调查问题不能为空"></asp:RequiredFieldValidator></td>
   <td class="vtop tips2" style="height: 48px"><span></span></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">选项类型：</td>
</tr>
<tr>
   <td class="vtop rowform" >
    
        <asp:RadioButtonList ID="rdolstType" runat="server" RepeatColumns="4" 
            AutoPostBack="True" onselectedindexchanged="rdolstType_SelectedIndexChanged">
            <asp:ListItem Text="单行文本框" Value="text" Selected="True"></asp:ListItem>
            <asp:ListItem Text="多行文本框" Value="mtext"></asp:ListItem>
            <asp:ListItem Text="单选列表" Value="select"></asp:ListItem>
            <asp:ListItem Text="多选列表" Value="mselect"></asp:ListItem>
        </asp:RadioButtonList>
   </td>
   <td class="vtop tips2"></td>
</tr>


<asp:Panel runat="server" ID="pnlOptions" Visible="false">
<tr class="nobg">
  <td colspan="2" class="td27">子项：</td>
</tr>
<tr>
   <td class="vtop rowform" style="font-weight:bold; width:500px;">
        <table border="0" cellpadding="0" cellspacing="0" class="PollTable" id="tablePollOption">
               <tr>
                <td>1.</td>
                <td>
                    <textarea name="option1" rows="2" cols="60"></textarea>
                </td>
                <td></td>
               </tr>
        </table>
     </td>
   <td class="vtop tips2">
   
            <img src="../images/add.gif" alt="点此继续添加选项" onclick="AddPollOption()" />  点此继续添加选项
            <input type="hidden" id="OptionTotal" name="OptionTotal" runat="server" value="1" />
   </td>
</tr>

</asp:Panel>



<tr>
<td style="height: 30px" colspan="2">
    <asp:button id="btnOK" runat="server" CssClass="button" Text="保存" OnClick="btnOK_Click"></asp:button>&nbsp;
    <input id="Button1" class="button" type="button" value="返回" onclick="location.href='<%=backURL%>';" />
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

