<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_ModuleManage_ModuleEdit" Codebehind="ModuleEdit.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
     <title>�Զ���ģ��༭</title>
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<link href="../css/cue.css" type="text/css" rel="stylesheet" />
<link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script type="text/javascript" src="../javascript/CheckedAll.js" ></script>
</head>
<body>
<form id="form1" runat="server">
<h1><a href="../index.aspx">��̨������ҳ</a> >> ģ��༭</h1>
<table width="100%" >
<tr>
<td class="right">

<div class="main-setting">
<div class="itemtitle"><h3>ģ��༭</h3>
</div>


<table class="xy_tb xy_tb2 ">

<tr>
   <td class="vtop rowform">
    <span class="td27">����ģ�飺</span><asp:Label ID="lblName" runat="server"></asp:Label>
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">ģ����������</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="tbcname" runat="server" CssClass="input" MaxLength="50"></asp:TextBox>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbcname"
            ErrorMessage="�������Ʋ���Ϊ��"></asp:RequiredFieldValidator>    
   </td>
   <td class="vtop tips2">ģ����ҳ��չʾ�����ƣ�������2��6������֮��</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">ģ��Ӣ������</td>
</tr>
<tr>
   <td class="vtop rowform">
    	<asp:TextBox ID="tbename" runat="server" CssClass="input" MaxLength="50"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbename"
            ErrorMessage="Ӣ�����Ʋ���Ϊ��"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbename"
            ErrorMessage="��������[a-z,A-Z]��ɳ�����3��15���ַ�֮�������" ValidationExpression="([a-zA-Z]{3,15})"></asp:RegularExpressionValidator>
   </td>
   <td class="vtop tips2">[A_Z,a-z]��ɵĳ�����3��15���ַ�֮���Ӣ������</td>
</tr>



<tr class="nobg">
  <td colspan="2" class="td27">ģ��˵����</td>
</tr>
<tr>
   <td class="vtop rowform">
    
        <asp:TextBox ID="tbDescription" runat="server" Columns="60" Rows="5" TextMode="MultiLine"></asp:TextBox>
   </td>
   <td class="vtop tips2">ģ�����;�ȼ򵥽���</td>
</tr>
<asp:panel ID="pnlSEOSetting" runat="server">
<tr class="nobg">
  <td colspan="2" class="td27">��Ϣ�������ã�</td>
</tr>
<tr>
   <td class="vtop rowform">
    
            <asp:PlaceHolder ID="phMain" runat="server">
            </asp:PlaceHolder>
     
   </td>
   <td class="vtop tips2"><img src="../images/add.gif" alt="��˼�������Ϣ����" onclick="AddInfoType()" />  ��˼�������Ϣ����
            <input type="hidden" id="infoTypeTotal" name="infoTypeTotal" runat="server" value="3" /></td>
</tr>

</asp:panel>
<tr>
    <td colspan="2">
        &nbsp;<input id="Submit1" type="submit" value="����" class="button" runat="server"/>&nbsp;<input id="Button1" class="button" type="button" value="����" onclick="javascript:history.go(-1);" />
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


