<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_news_AddTitle" Codebehind="AddTitle.aspx.cs" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="head1" runat="server">
<link href="../css/style.css" type="text/css" rel="Stylesheet" />
<link href="/common/css/XYLib.css" type="text/css" rel="Stylesheet" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script language="javascript" type="text/javascript" src="../javascript/AddNews.js"></script>
<title>�����Ѷ��Ŀ</title>
</head>
<body>
<form id="form1" runat="server">
<h1><a href="../index.aspx">��̨������ҳ</a> >> �����Ѷ��Ŀ</h1>
<table width="100%">
<tr>
<td class="right">

<div class="main-setting">
<div class="itemtitle"><h3>�����Ѷ��Ŀ</h3></div>


<table class="xy_tb xy_tb2">
<tr class="nobg">
  <td colspan="2" class="td27">��Ŀ�������ƣ�</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="txtChannelCNName" MaxLength="150" runat="server" CssClass="input"  Columns="40"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
        ID="RequiredFieldValidator1" runat="server" ErrorMessage="��Ŀ�������Ʋ���Ϊ��" ControlToValidate="txtChannelCNName"></asp:RequiredFieldValidator><br />
   </td>
   <td class="vtop tips2">����:��ҵ��Ѷ</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">��Ŀ��ƣ�</td>
</tr>
<tr>
   <td class="vtop rowform">
		<asp:TextBox ID="txtChannelShortTitle" runat="server" MaxLength="40" CssClass="input" Columns="40"></asp:TextBox><span>&nbsp;<asp:RequiredFieldValidator
        ID="RequiredFieldValidator2" runat="server" ErrorMessage="��Ŀ��Ʋ���Ϊ��" ControlToValidate="txtChannelShortTitle"></asp:RequiredFieldValidator><br />
   </td>
   <td class="vtop tips2">����:��ҵ</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">������Ŀ��</td>
</tr>
<tr>
   <td class="vtop rowform">
	<asp:TextBox ID="txtParentChannel" runat="server" CssClass="input" Columns="40"></asp:TextBox>
    <input id="ptitleid" runat="server" type="hidden" />
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">��ĿӢ�����ƣ�</td>
</tr>
<tr>
   <td class="vtop rowform">
<asp:TextBox ID="txtChannelENName" runat="server" Columns="40" MaxLength="150" CssClass="input" onkeyup="value=value.replace(/[\W]/g,'') " onbeforepaste="clipboardData
.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="��ĿӢ�����Ʋ���Ϊ��" ControlToValidate="txtChannelENName"></asp:RequiredFieldValidator>
   </td>
   <td class="vtop tips2">3-50����ĸ</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">�Զ�����Ŀ�ļ��е�ַ��</td>
</tr>
<tr>
   <td class="vtop rowform">
	<asp:TextBox ID="txtTemplate" runat="server" Columns="40" MaxLength="200" CssClass="input"></asp:TextBox>
	<br/><br/>
	<asp:CheckBox ID="chkSubChannelAutoInherit" runat="server" text="����Ŀ�Զ��̳�" Checked Visible="false"/>
   </td>
   <td class="vtop tips2" style="color:#f60;">
   ����ǳ���Ҫ��Ĭ�ϱ���Ϊ�ռ��ɣ���Ŀ��ʹ����Ѷͨ��ģ��<br/>
   ���ҪΪ��ǰ��Ŀ�����ض���ģ�壬����ģ��Ŀ¼ news �ļ������½��ļ��У�������Ĭ��ģ��(index.htm , channel.htm , content.htm)���½�Ŀ¼�½����޸�<br/>
   ��Ŀ���ʵ�ַΪ��http://www.site.com/news/�Զ����ļ���/<br/>
   �����Խ�Ĭ���Զ��̳и�����Ŀ(����Ŀ�Կ��Զ���)
   </td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">�Ƿ������ڸ���Ŀ��Ͷ�壺</td>
</tr>
<tr>
   <td class="vtop rowform">
	<asp:RadioButton runat="server" ID="rdoIsAllowContributYes" Text="����" GroupName="IsAllowContribut" Checked/>
	<asp:RadioButton runat="server" ID="rdoIsAllowContributNo" Text="������" GroupName="IsAllowContribut" />
   </td>
   <td class="vtop tips2" style="color:#f60;">
   ������վ�û��Ƿ���Ը�����ĿͶ��<br/>
   ����Ŀ���Զ��̳и���Ŀ�Ĳ�����Ͷ������
   </td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">���ظ���Ŀ��</td>
</tr>
<tr>
   <td class="vtop rowform">
	<asp:CheckBox runat="server" ID="chkIsHide" Checked="false"/>
   </td>
   <td class="vtop tips2" style="color:#f60;">
   ������Ŀ��������Ѷ���ᱻ��������ֻ��ͨ����ǩ�ſ��Ե���,�ʺ�������Ѷ<br/>
   ͨ����ǩ����ʱ���뽫��Ŀָ��Ϊ������Ŀ���ɵ�����Ŀ��������Ѷ<br/>
   ����Ŀ���Զ��̳и���Ŀ����������
   </td>
</tr>


<tr class="nobg">
  <td colspan="2" class="td27">�����������ƣ�</td>
</tr>
<tr>
      <td class="vtop rowform">
		<asp:Label runat="server" ID="Label1" Text="Http://"></asp:Label>
		<input id="txtDomain" runat="server" maxlength="20" class="input"  type="text" onblur="ChangeTxt();"/>
		<asp:Label runat="server" ID="webname"></asp:Label><br /><br />
		<input type="checkbox" id="cbdomain" runat="server"  checked="checked" visible="false" onclick="ChangeCheckBox();"  />����Ŀ�Զ��̳�
   </td>
   <td class="vtop tips2" style="color:#f60;">
   ����޷���д����鿴ϵͳ�����������Ƿ�����Ѷ��Ŀ��������ѡ��<br/>
   ��Ŀ���ö��������������Զ���ģ�壬�������������ҳ����������Ѷ��Ŀ��ҳΪͬһҳ��
   </td>
</tr>

<tr>
<td colspan="2" class="content_action">
    <asp:Button ID="btnOK" runat="server" CssClass="button" Text="�ύ" OnClick="btadd_Click" />
    <input id="btcancel" class="button" type="button" value="����" runat="server" onserverclick="btcancel_ServerClick" causesvalidation="false"/>
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
