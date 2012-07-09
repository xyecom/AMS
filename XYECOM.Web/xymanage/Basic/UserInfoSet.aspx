 <%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_basic_UserInfoSet" Codebehind="UserInfoSet.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>�û���Ϣ���� </title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
    <script language="javascript" type="text/javascript" src="../javascript/WebSet.js"></script>
</head>
<body>
 <form id="form1" runat="server">
 <h1><a href="../index.aspx">��̨������ҳ</a> >> �û���Ϣ����</h1>
 <table width="100%">
 <tr>
 <td class="right">

<div class="main-setting">
<div class="itemtitle">
<h3>ϵͳ��������</h3>
<ul class="tab1">
    <li><a href="WebInfo.aspx"><span>��������</span></a></li>
    <li><a href="Function.aspx"><span>��������</span></a></li>
    <li><a href="BussinessInfoSet.aspx"><span>��ҵ��Ϣ���</span></a></li>
    <li class="current"><a href="UserInfoSet.aspx"><span>�û����</span></a></li>
    <li><a href="ShopSet.aspx"><span>�������</span></a></li>
    <li><a href="Server.aspx"><span>����������</span></a></li>
    <li><a href="EMailBoxInfoSet.aspx"><span>��վ����</span></a></li>
    <li><a href="SEO.aspx"><span>SEO����</span></a></li>
    <li><a href="SecuritySet.aspx"><span>��ȫ����</span></a></li>
</ul>
</div>


<table class="xy_tb xy_tb2 border_buttom0">

<tr class="nobg">
  <td colspan="2" class="td27">���û�ע�᣺</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:RadioButton ID="isusert" runat="server" CssClass="input" GroupName="IsUser" Text="����" Checked="True" />
		<asp:RadioButton ID="isuserf" runat="server" CssClass="input" GroupName="IsUser"	Text="������" />
   </td>
   <td class="vtop tips2">ѡ�в�����ע��ҳ�潫��ʾ��ֹע����ʾ</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">���û�ע��ģʽ��</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:RadioButtonList ID="RegisterModeList" runat="server" RepeatDirection="Horizontal"
        RepeatLayout="Flow">
        <asp:ListItem Value="simple">���ģʽ</asp:ListItem>
        <asp:ListItem Value="full">����ģʽ</asp:ListItem>
    </asp:RadioButtonList>
   </td>
   <td class="vtop tips2">���ģʽ��ע��ֻ����д������Ϣ������ģʽ����Ҫ��д������Ϣ��(��ҵ/����)��ϸ��Ϣ</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">��˷�ʽ��</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:RadioButton ID="atuoadtuser" runat="server" CssClass="input" GroupName="useradttype" Text="�Զ����" Checked="True" />
		<asp:RadioButton ID="manadtuser" runat="server" CssClass="input" GroupName="useradttype" Text="�˹����" />
   </td>
   <td class="vtop tips2">���û�ע����ɻ����û��༭���Ϻ����˷�ʽ</td>
</tr>
<tr class="nobg">
  <td colspan="2" class="td27">�����û�ѡ�����ҵ������</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="txtCanChooseTradeNumber" runat="server" MaxLength="4" CssClass="txt" Width="100px">0</asp:TextBox>&nbsp;
   </td>
   <td class="vtop tips2">�û�����ѡ�����ҵ����</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">��ֹע����û�����</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="tbforbidname" runat="server" MaxLength="4000" CssClass="txt" TextMode="MultiLine" Columns="116" Rows="6" ></asp:TextBox>
   </td>
   <td class="vtop tips2"><span>�����","����</span></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">ע��ɹ�Ĭ��(�����)��</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="tbuserhortation" runat="server" MaxLength="4" CssClass="txt" Width="100px">0</asp:TextBox>
		<asp:Label ID="Label2" runat="server"></asp:Label>
   </td>
   <td class="vtop tips2">�»�Աע��ɹ��Ժ�Ĭ�Ͻ��������������</td>
</tr>
<tr class="nobg">
  <td colspan="2" class="td27">�ο��Ƿ���Բ鿴��ҵ��Ϣ��ϵ��ʽ��</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:RadioButton ID="yke" runat="server" CssClass="input" GroupName="youke"	Text="����" Checked="True" />
	 <asp:RadioButton ID="yk" runat="server" CssClass="input" GroupName="youke" Text="������" />
   </td>
   <td class="vtop tips2">������ҵ��Ϣ����ҵ��Ա��ϵ��ʽ�Ƿ������οͲ鿴</td>
</tr>
<tr class="nobg">
  <td colspan="2" class="td27">��¼����(�����)��</td>
</tr>
<tr>
   <td class="vtop rowform">
    
        <asp:TextBox ID="tbloginhortation" runat="server" MaxLength="4" CssClass="txt" Width="100px"></asp:TextBox>
        <asp:Label ID="Label3" runat="server"></asp:Label>
   </td>
   <td class="vtop tips2">��Աÿ�ε�½���������������������Ϊ��λ��һ������һ��</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">��¼����(����)��</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="txtScores" runat="server"  MaxLength="4" CssClass="txt"  Width="100px" onblur="IsInt(this);">0</asp:TextBox>
   </td>
   <td class="vtop tips2">��Աÿ�ε�½�����Ļ�������������Ϊ��λ��һ������һ��</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">ע��ɹ��ʼ���ʾ(�������伤����)��</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:RadioButton ID="rbresteisemailyes" runat="server" CssClass="input" GroupName="msresster" Text="����"  />
		<asp:RadioButton ID="rbresteisemailno" runat="server" CssClass="input" GroupName="msresster"  Text="������"/>
   </td>
   <td class="vtop tips2">�»�Աע��ɹ��Ժ��Ƿ�ͨ���ʼ��ķ�ʽ֪ͨ���������伤���뼤��ע������(ȷ����վ�ʼ�������������ȷ)</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">ע��ɹ�������ʾ��</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:RadioButton ID="webnotet" runat="server" CssClass="input" GroupName="webmessage" Text="����" />
		<asp:RadioButton ID="webnotef" runat="server" CssClass="input" GroupName="webmessage" Text="������" />
   </td>
   <td class="vtop tips2">�»�Աע��ɹ��Ժ��Ƿ�ͨ��վ�ڶ��ŵķ�ʽ֪ͨ</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">ע��ɹ���ӭ���ű��⣺</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="tbnotetitle" MaxLength="40" runat="server" CssClass="txt"></asp:TextBox>
   </td>
   <td class="vtop tips2">�»�Աע��ɹ��Ժ�վ�ڶ�����ʾ����</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">ע��ɹ���ӭ�������ݣ�</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="tbnotetext" runat="server" MaxLength="4000" Columns="116" Rows="6" CssClass="txt" TextMode="MultiLine"></asp:TextBox>
   </td>
   <td class="vtop tips2">�»�Աע��ɹ��Ժ�վ�ڶ�����ʾ����</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">����û��ʼ���ʾ��</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:RadioButton ID="auditinguseryes" runat="server" CssClass="input" GroupName="newmsadttype" Text="����"  />
		<asp:RadioButton ID="auditinguserno" runat="server" CssClass="input" GroupName="newmsadttype" Text="������"/>
   </td>
   <td class="vtop tips2">��ע���Ա��˲������Ƿ�ͨ���ʼ��ķ�ʽ֪ͨ</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">����û�������ʾ��</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:RadioButton ID="rbauditmessageyes" runat="server" CssClass="input" GroupName="auditsentmessagesy" Text="����" />
		<asp:RadioButton ID="rbauditmessageno" runat="server" CssClass="input" GroupName="auditsentmessagesy" Text="������"/>
   </td>
   <td class="vtop tips2">��ע���Ա��˲������Ƿ�ͨ��վ�ڶ��ŵķ�ʽ֪ͨ</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">����û����ű��⣺</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="lbsentmessasgetitle" MaxLength="40" runat="server" CssClass="txt"></asp:TextBox>
   </td>
   <td class="vtop tips2">��ע���Ա��˲�����վ�ڶ�����ʾ����</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">����û��������ݣ�</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="lbusersentmessagecontent" runat="server" MaxLength="4000" Columns="116" Rows="6" CssClass="txt" TextMode="MultiLine"></asp:TextBox>
   </td>
   <td class="vtop tips2">��ע���Ա��˲�����վ�ڶ�����ʾ����</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">�û���ֵ�ʼ���ʾ��</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:RadioButton ID="addmoneyyes" runat="server" CssClass="input" GroupName="addmoneyemail" Text="����"  />
		<asp:RadioButton ID="addmoneyno" runat="server" CssClass="input" GroupName="addmoneyemail" Text="������"/>
   </td>
   <td class="vtop tips2">��Ա��ֵ�������Ƿ����ʼ��ķ�ʽ֪ͨ</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">�û���ֵ������ʾ��</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:RadioButton ID="useraddmoneymessageyes" runat="server" CssClass="input" GroupName="usermessage" Text="����"  />
		<asp:RadioButton ID="useraddmoneymessageno" runat="server" CssClass="input" GroupName="usermessage" Text="������"/>
   </td>
   <td class="vtop tips2">��Ա��ֵ�������Ƿ���վ�ڶ��ŵķ�ʽ֪ͨ</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">�û���ֵ��Ϣ���ű��⣺</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="addmoneytitle" MaxLength="180" runat="server" CssClass="txt"></asp:TextBox>
   </td>
   <td class="vtop tips2">��Ա��ֵ������վ�ڶ���֪ͨ����</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">�û���ֵ��Ϣ�������ݣ�</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="addmoneycontent" runat="server" MaxLength="4000" Columns="116" Rows="6" CssClass="txt" TextMode="MultiLine"></asp:TextBox>
   </td>
   <td class="vtop tips2">��Ա��ֵ������վ�ڶ���֪ͨ����</td>
</tr>
</table>

<div class="itemtitle" style="margin-top:10px;"><h3>�û��������ƶ����</h3>
</div>
<table class="xy_tb xy_tb2 ">

<tr class="nobg">
  <td colspan="2" class="td27">(������)ע��ɹ���</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox runat="server" ID="tbregist" CssClass="txt" MaxLength="3"></asp:TextBox>%
   </td>
   <td class="vtop tips2">����������,���ƶ��������ܳ���100</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">(������)��д���������</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox runat="server" ID="tbbase" CssClass="txt" MaxLength="3"></asp:TextBox>%
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">(������)����ֻ����룺</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox runat="server" ID="tbmobile" CssClass="txt" MaxLength="3"></asp:TextBox>%
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">(������)������ڲ��ţ�</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox runat="server" ID="tbbranch" CssClass="txt" MaxLength="3"></asp:TextBox>%
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">(�߼���)��Ӳ������ϱ����</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox runat="server" ID="tbcomple" CssClass="txt" MaxLength="3"></asp:TextBox>%
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">(�߼���)���ע���ʱ���</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox runat="server" ID="tbcapital" CssClass="txt" MaxLength="3"></asp:TextBox>%</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">(֤����)�ϴ�Ӫҵִ��:</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox runat="server" ID="tblicence" CssClass="txt" MaxLength="3"></asp:TextBox>%
   </td>
   <td class="vtop tips2">
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">(֤����)�����ϴ�����֤������</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox runat="server" ID="tbcertificate" CssClass="txt" MaxLength="3"></asp:TextBox>&nbsp;*5%
     
   </td>
   <td class="vtop tips2"> �����������ϴ�����֤����Ŀ,ϵͳ����֤����*5����������ֵ,����ֵ���ᳬ��100</td>
</tr>
</table>
<div style="padding:5px 0px 15px 0px;"><asp:Button ID="btok" runat="server" CssClass="button" Text="��������" OnClick="btok_Click" /></div>
 </div>
 </td>
 </tr>
 </table>
 </form>
</body>
</html>
