<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_LabelManage_LabelTypeAdd" Codebehind="LabelTypeAdd.aspx.cs" %>

<%@ Register Src="../UserControl/top.ascx" TagName="top" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>��ǩ�༭</title>
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script type="text/javascript" src="../javascript/CheckedAll.js" ></script>
</head>
<body>
<form id="form1" runat="server">
<h1><a href="../index.aspx">��̨������ҳ</a> >> ��ǩ�������</h1>
<table width="100%" >
<tr>
<td class="right">    

<div class="main-setting">
<div class="itemtitle"><h3 id="title" runat="server">IM ��������</h3>
</div>
<table class="xy_tb xy_tb2 ">


<tr class="nobg">
  <td colspan="2" class="td27">��ǩ�������ƣ�</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="tbName" Width="250" runat="server" CssClass="input" MaxLength="50"></asp:TextBox>
   </td>
   <td class="vtop tips2"><span>�磺��վ����</span></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">˵����</td>
</tr>
<tr>
   <td class="vtop rowform">
    
        <asp:TextBox ID="tbRemark" runat="server" CssClass="input" Columns="116" Rows="6" TextMode="MultiLine"></asp:TextBox>
   </td>
   <td class="vtop tips2"></td>
</tr>
<tr>
<td style="height: 30px" colspan="2"><asp:button id="btnok" runat="server" CssClass="button" Text="�������" OnClick="btnok_Click"  ></asp:button>&nbsp;<input id="Button1" class="button" type="button" value="����" onclick="javascript:history.go(-1);" /></td>
</tr>
</table>
</div>
</td>
</tr>
</table>
</form>
</body>
</html>


