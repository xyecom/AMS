<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_basic_UserTypeAdd" Codebehind="UserTypeAdd.aspx.cs" %>

<%@ Register Src="../UserControl/top.ascx" TagName="top" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>��ҵ������</title>
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script type="text/javascript" src="../javascript/CheckedAll.js" ></script>
</head>
<body>

<form id="form1" runat="server">
<h1><a href="../index.aspx">��̨������ҳ</a> >> ��ҵ������</h1>
<!-- content  -->
<table  width="100%" >
<tr>
<!-- right -->
<td class="right">

<!--��̨���� -->


<div class="main-setting">
<table width="100%" class="xy_tb xy_tb2 infotable">
<tr>
<th>��ҵ������ƣ�</th>
<td><asp:TextBox ID="tbName" Width="400px" runat="server" CssClass="input" MaxLength="20" Rows="5" TextMode="MultiLine"></asp:TextBox></td>
<td class="vtop tips2"><asp:Label ID="lbremark" runat="server" Text="��Ӷ���ԡ�,���Ÿ�����"></asp:Label></td>
</tr>
<tr>
<th>������ҵ���</th>
<td>
<asp:Label ID="lblName" runat="server"></asp:Label></td>
</tr>
<tr>
<th>&nbsp;</th>
<td class="content_action" style="height: 30px"><label> <asp:button id="btnok" runat="server" CssClass="button" Text="����" OnClick="btnok_Click"  ></asp:button>&nbsp;<input id="Button1" class="button" type="button" value="����" onClick="javascript:history.go(-1);" /></label></td>
</tr>
</table>
</div>

</td>
</tr>
</table>
</form>


</body>
</html>


