<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_basic_BussinessInfoSet" Codebehind="BussinessInfoSet.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
  <title>��ҵ��Ϣ��������</title>
  <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
  <link href="../css/style.css" type="text/css" rel="stylesheet" />
  <script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
  <script language="javascript" type="text/javascript" src="../javascript/WebSet.js"></script>
</head>
<body>
<form id="form1" runat="server">
<h1><a href="../index.aspx">��̨������ҳ</a> >> ��ҵ��Ϣ��������</h1>
<table width="100%">
<tr>
<td class="right">

<div class="main-setting">
<div class="itemtitle">
<h3>ϵͳ��������</h3>
<ul class="tab1">
    <li><a href="WebInfo.aspx"><span>��������</span></a></li>
    <li><a href="Function.aspx"><span>��������</span></a></li>
    <li class="current"><a href="BussinessInfoSet.aspx"><span>��ҵ��Ϣ���</span></a></li>
    <li><a href="UserInfoSet.aspx"><span>�û����</span></a></li>
    <li><a href="ShopSet.aspx"><span>�������</span></a></li>
    <li><a href="Server.aspx"><span>����������</span></a></li>
    <li><a href="EMailBoxInfoSet.aspx"><span>��վ����</span></a></li>
    <li><a href="SEO.aspx"><span>SEO����</span></a></li>
    <li><a href="SecuritySet.aspx"><span>��ȫ����</span></a></li>
</ul>
</div>


<table class="xy_tb xy_tb2 border_buttom0">

<tr class="nobg">
  <td colspan="2" class="td27">��˷�ʽ��</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:RadioButton ID="autoadtms" runat="server" CssClass="input" GroupName="msadttype" Text="�Զ����" Checked="True" />
		<asp:RadioButton ID="manadtms" runat="server" CssClass="input" GroupName="msadttype"  Text="�˹����" />
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">�޸ĺ���˷�ʽ��</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:RadioButton ID="autonewadt" runat="server" CssClass="input" GroupName="newmsadttype" Text="�Զ����" Checked="True" />
	<asp:RadioButton ID="mannewadt" runat="server" CssClass="input" GroupName="newmsadttype" Text="�˹����" />
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">����ʼ���ʾ��</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:RadioButton ID="AuditIsEmailYes" runat="server" CssClass="input" GroupName="audingbussiness" Text="����" Checked ="True"/>
		<asp:RadioButton ID="AuditIsEmailNo" runat="server" CssClass="input" GroupName="audingbussiness" Text="������" />
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">��˶�����ʾ��</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:RadioButton ID="AuditIsMessageYes" runat="server" CssClass="input" GroupName="webmessage" Text="����" Checked ="True"/>
		<asp:RadioButton ID="AuditIsMessageNo" runat="server" CssClass="input" GroupName="webmessage" Text="������"  />
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">��˶��ű��⣺</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="tbsentmessagetitle" Width="500px" MaxLength="40" runat="server" CssClass="input"></asp:TextBox>
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">��˶������ݣ�</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="tbsentmessagecontent" runat="server" MaxLength="4000" Columns="116" Rows="6" CssClass="input" TextMode="MultiLine" Width="500px"></asp:TextBox>
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">������Ϣ������</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="tbuseraddinfo" runat="server" MaxLength="4" CssClass="input" Width="40px">0</asp:TextBox>
		<asp:Label ID="Label4" runat="server"></asp:Label>
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">ˢ��һ����Ϣ������</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="tbrefurbishinfo" runat="server" MaxLength="4" CssClass="input" Width="40px"></asp:TextBox>
		 <asp:Label ID="Label5" runat="server"></asp:Label>
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">��Ч��ѡ��ʽ��</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:RadioButton runat="server" ID="enddate" CssClass="input" GroupName="timetype" Text="ѡ��ʱ���" Checked="True" />
       <asp:RadioButton runat="server" ID="endtime" CssClass="input" GroupName="timetype" Text="����ʱ���" />
   </td>
   <td class="vtop tips2">������ҵ��Ϣʱ��Ч�ڵ�ָ����ʽ</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">��ز�Ʒ(��Ϣ)�����������ã�</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="txtAboutInfoNum" runat="server" MaxLength="4"  Width="40px" CssClass="input" onblur="IsInt(this);"></asp:TextBox>
   </td>
   <td class="vtop tips2"></td>
</tr>
<tr class="nobg">
  <td colspan="2" class="td27">�������Ե����������ã�</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="txtSysMessageNum" runat="server" MaxLength="4"  Width="40px" CssClass="input" onblur="IsInt(this);"></asp:TextBox>
   </td>
   <td class="vtop tips2"></td>
</tr>
</table>


<div class="itemtitle" style="margin-top:10px;"><h3>�ʼ�����</h3></div>
<table class="xy_tb xy_tb2 ">

<tr class="nobg">
  <td colspan="2" class="td27">�����ʼ���ʾ��</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:RadioButton ID="BidIsEmailYes" runat="server" CssClass="input" GroupName="jinjiaemail" Text="����" Checked="True"/>
		<asp:RadioButton ID="BidIsEmailNo" runat="server" CssClass="input" GroupName="jinjiaemail" Text="������" />
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">���۶�����ʾ��</td>
</tr>
<tr>
   <td class="vtop rowform">
    
        <asp:RadioButton ID="BidIsMessageYes" runat="server" CssClass="input" GroupName="jinjiamessage" Text="����" Checked="True"/>
		<asp:RadioButton ID="BidIsMessageNo" runat="server" CssClass="input" GroupName="jinjiamessage" Text="������" />
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">���۶��ű��⣺</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="jinjiatitle" Width="500px" MaxLength="40" runat="server" CssClass="input"></asp:TextBox>
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">���۶������ݣ�</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="jinjiacontent" runat="server" MaxLength="4000" Columns="116" Rows="6" CssClass="input" TextMode="MultiLine" Width="500px"></asp:TextBox>
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">�Ƽ�ְλ�ʼ���ʾ��</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:RadioButton ID="JobIsEmailYes" runat="server" CssClass="input" GroupName="job" Text="����" Checked="True"/>
		<asp:RadioButton ID="JobIsEmailNo" runat="server" CssClass="input" GroupName="job" Text="������"   />
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">��Ƹְλ������ʾ��</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:RadioButton ID="JobIsMessageYes" runat="server" CssClass="input" GroupName="jobmessage" Text="����" Checked="True"/>
		<asp:RadioButton ID="JobIsMessageNo" runat="server" CssClass="input" GroupName="jobmessage" Text="������"   />
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">��Ƹ��ְ���ű��⣺</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="jobtitle" Width="500px" MaxLength="40" runat="server" CssClass="input"></asp:TextBox>
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">��Ƹ��ְ�������ݣ�</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="jobcontent" runat="server" MaxLength="4000" Columns="116" Rows="6" CssClass="input" TextMode="MultiLine" Width="500px"></asp:TextBox>
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">�����ʼ���ʾ��</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:RadioButton ID="OrderIsEmailYes" runat="server" CssClass="input" GroupName="order" Text="����" Checked="True"/>
		<asp:RadioButton ID="OrderIsEmailNo" runat="server" CssClass="input" GroupName="order" Text="������"   />
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">����������ʾ��</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:RadioButton ID="OrderIsMessageYes" runat="server" CssClass="input" GroupName="ordermessage" Text="����" Checked="True"/>
		<asp:RadioButton ID="OrderIsMessageNo" runat="server" CssClass="input" GroupName="ordermessage" Text="������"   />
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">�������ű��⣺</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="ordermessagetitle" Width="500px" MaxLength="40" runat="server" CssClass="input"></asp:TextBox>
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">�����������ݣ�</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="ordermessagecontent" runat="server" MaxLength="4000" Columns="116" Rows="6" CssClass="input" TextMode="MultiLine" Width="500px"></asp:TextBox></td>
</tr>
</table>

<div style="padding:5px 0px 15px 0px;">
<asp:Button ID="btok" runat="server" CssClass="button" Text="��������" OnClick="btok_Click" /></div>
</div>
   </td>
   <td class="vtop tips2"></td>
</tr>
</table>
</form>
</body>
</html>
