<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_basic_UserPopedom" Codebehind="UserPopedom.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>Ȩ������</title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<style>
    .ddd table td{ width:20%;}
</style>
</head>
<body>
<form id="Form1" method="post" runat="server">
<h1><a href="../index.aspx">��̨������ҳ</a> >> Ȩ������</h1>
<table  width="100%" >
<tr>
<td class="right">

<div class="main-setting">
<div class="itemtitle"><h3>Ȩ������</h3>
</div>

<table class="xy_tb xy_tb2">
<tr class="nobg">
  <td class="td27">����Ȩ�ޣ�</td>
</tr>
<tr>
   <td class="vtop">    
    <asp:CheckBoxList ID="cblbasic" runat="server" RepeatColumns="5" Width="100%">
        <asp:ListItem Value="basic">ϵͳ��������</asp:ListItem>
        <asp:ListItem Value="sysadmin">����Ա����</asp:ListItem>
        <asp:ListItem Value="filterkeyword">�����ֹ���</asp:ListItem>
        <asp:ListItem Value="hotkeyword">���Źؼ��ֹ���</asp:ListItem>
        <asp:ListItem Value="area">������Ϣ����</asp:ListItem>
        <asp:ListItem Value="customconfigfield">�Զ��������ֶ�</asp:ListItem>
        <asp:ListItem Value="areasite">�ط�վ����</asp:ListItem>
        <asp:ListItem Value="trade">��ҵ����</asp:ListItem>
        <asp:ListItem Value="ads">������</asp:ListItem>
        <asp:ListItem Value="rank">��������</asp:ListItem>
        <asp:ListItem Value="custom">�û��Զ������ݹ���</asp:ListItem>
        <asp:ListItem Value="friendlink">�������ӹ���</asp:ListItem>
    </asp:CheckBoxList>
   </td><!--<asp:ListItem Value="b_SearchKey">�����ؼ��ֹ���</asp:ListItem>--><!---->     
</tr>

<tr class="nobg">
  <td class="td27">��ҵ��ϢȨ�����ã�</td>
</tr>
<tr>
   <td class="vtop">    
    <asp:CheckBoxList ID="cblbusiness" runat="server" RepeatColumns="5" Width="100%">
        <asp:ListItem Value="typemanage">��Ϣ�������</asp:ListItem>
        <asp:ListItem Value="ExpressMessage">������������</asp:ListItem>
        <asp:ListItem Value="offer">������Ϣ����</asp:ListItem>
        <asp:ListItem Value="venture">�ӹ���Ϣ����</asp:ListItem>
        <asp:ListItem Value="investment">���̴�����Ϣ����</asp:ListItem>
        <asp:ListItem Value="service">������Ϣ����</asp:ListItem>
        <asp:ListItem Value="exhibition">չ����Ϣ����</asp:ListItem>
        <asp:ListItem Value="brand">Ʒ�ƹ���</asp:ListItem>
        <asp:ListItem Value="engageinfo">��Ƹ����</asp:ListItem>
        <asp:ListItem Value="order">���׹���</asp:ListItem>
        <asp:ListItem Value="Wikipedia">�ٿƷ������</asp:ListItem>
        <asp:ListItem Value="lemma">��������</asp:ListItem>
    </asp:CheckBoxList>
   </td>
</tr>

<tr class="nobg">
  <td class="td27">��Ѷ����Ȩ�����ã�</td>
</tr>
<tr>
   <td class="vtop">    
    <asp:CheckBoxList ID="cblnews" runat="server" RepeatColumns="5" Width="100%">
        <asp:ListItem Value="news">��ͨ��Ѷ����</asp:ListItem>
        <asp:ListItem Value="chargenews">�շ���Ѷ����</asp:ListItem>
        <asp:ListItem Value="newscomment">���۹���</asp:ListItem>
        <asp:ListItem Value="usernews">��ҵ��Ѷ����</asp:ListItem>
        <asp:ListItem Value="topic">ר�����</asp:ListItem>
    </asp:CheckBoxList>
   </td>
</tr>

<tr class="nobg">
  <td class="td27">�û�Ȩ�����ã�</td>
</tr>
<tr>
   <td class="vtop">    
    <asp:CheckBoxList ID="cbluser" runat="server" RepeatColumns="5" Width="100%">
        <asp:ListItem Value="user">��ҵ�û�����</asp:ListItem>
        <asp:ListItem Value="individual">�����û�����</asp:ListItem>
        <asp:ListItem Value="userGrade">�û��ȼ�����</asp:ListItem>
        <asp:ListItem Value="userType">��ҵ�������</asp:ListItem>
        <asp:ListItem Value="businessmode">��Ӫģʽ����</asp:ListItem>
        <asp:ListItem Value="certificate">֤����Ϣ����</asp:ListItem>
        
        <asp:ListItem Value="payMethod">֧����ʽ����</asp:ListItem>
        <asp:ListItem Value="finance">�������</asp:ListItem>
        <asp:ListItem Value="invoice">��Ʊ��Ϣ����</asp:ListItem>
        <asp:ListItem Value="remit">���ȷ����Ϣ����</asp:ListItem>        
    </asp:CheckBoxList>
   </td>
</tr>

<tr class="nobg">
  <td class="td27">ģ���ǩȨ�����ã�</td>
</tr>
<tr>
   <td class="vtop">    
    <asp:CheckBoxList ID="cbllable" runat="server" RepeatColumns="5" Width="100%">
        <asp:ListItem Value="template">ģ�����</asp:ListItem>
        <asp:ListItem Value="module">�Զ���ģ�����</asp:ListItem>
        <asp:ListItem Value="htmlpage">��̬ҳ�����ɹ���</asp:ListItem>
        <asp:ListItem Value="label">��ǩ����</asp:ListItem>
        <asp:ListItem Value="partlabel">ר����ǩ����</asp:ListItem>
    </asp:CheckBoxList>
   </td>
</tr>

<tr class="nobg">
  <td class="td27">�����ʼ���ϵͳ����Ȩ�����ã�</td>
</tr>
<tr>
   <td class="vtop">    
    <asp:CheckBoxList ID="cblsystem" runat="server" RepeatColumns="5" Width="100%">
        <asp:ListItem Value="sysmessage">վ�ڶ��Ź���</asp:ListItem>
        <asp:ListItem Value="email">�ʼ�����</asp:ListItem>
        <asp:ListItem Value="feedback">�����������</asp:ListItem>
        <asp:ListItem Value="database">���ݿ����</asp:ListItem>
        <asp:ListItem Value="log">��־����</asp:ListItem>
        <asp:ListItem Value="attachment">��������</asp:ListItem>
        <asp:ListItem Value="interface">�ӿڹ���</asp:ListItem>
        <asp:ListItem Value="Statistics">����ͳ��</asp:ListItem>
        <asp:ListItem Value="NewsSource">�ٶ�����Դ</asp:ListItem>
        <asp:ListItem Value="gift">��Ʒ����</asp:ListItem>
    </asp:CheckBoxList>
   </td>
</tr>


<tr>
<td  class="content_action" align="center">
    &nbsp;<asp:Button ID="btok" runat="server" CssClass="button" OnClick="Button1_Click1"
        Text="��������" />
    &nbsp;<asp:Button ID="bton" runat="server" CssClass="button" OnClick="Button2_Click1"
        Text="����" />
    <asp:Label ID="lbmanage" runat="server" ForeColor="Red"></asp:Label>
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
