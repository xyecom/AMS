<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_UserManage_UserMoreInfo" Codebehind="UserMoreInfo.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>��ҵ��Ա��ϸҳ��</title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<link href="/common/css/XYLib.css" type="text/css" rel="Stylesheet" />
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<script language ="javascript" type="text/javascript"  src="/common/js/base.js"></script>
<script language ="javascript" type="text/javascript"  src="/config/js/config.js"></script>
<script type="text/javascript" src="/common/js/date.js" ></script>
</head>
<body>
<form id="form1" runat="server">
<h1><a href="../index.aspx">��̨������ҳ</a> >> ��ҵ��Ա��ϸ��Ϣ</h1>
<table width="100%">
<tr>
<td class="right">


<div class="main-setting">

<div class="itemtitle"><h3>��Աע������</h3></div>

<table width="100%" class="xy_tb xy_tb2 infotable border_buttom0">
<tr>
 <th>�û���:</th>
 <td>
     <asp:TextBox ID="tdusername" runat="server" Width="250px" ReadOnly="True"></asp:TextBox></td>
</tr>
    <tr>
        <th>
            ��ʾ����:</th>
        <td>
            <asp:TextBox ID="txtQuestion" runat="server" Width="250px"></asp:TextBox></td>
    </tr>
    <tr>
            <th>
            ��ʾ��:</th>
        <td>
            <asp:TextBox ID="txtAnswer" runat="server" Width="250px"></asp:TextBox></td>
    </tr>
<tr>
 <th>��   ��:</th>
 <td>
     <asp:RadioButtonList ID="tdsex" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
         <asp:ListItem Value="1">��</asp:ListItem>
         <asp:ListItem Value="0">Ů</asp:ListItem>
     </asp:RadioButtonList></td>
 </td>
</tr>
<tr>
 <th>�����ʼ�:</th>
 <td><asp:TextBox ID="tdemail" runat="server" Width="250px"></asp:TextBox></td>

</tr>
<tr>
 <th>ע��ʱ��:</th>
 <td><input id="bgdate" type="text" runat="server" onclick="getDateString(this);" maxlength="10" style="width:80px;" readonly="readonly"/>
</tr>

</table>

<br/>
<div class="itemtitle"><h3>��ҵ��������</h3></div>
<table width="100%" class="xy_tb xy_tb2 infotable border_buttom0">
<tr>
<th>��ҵ����:</th>
<td><asp:TextBox ID="companyname" runat="server" Width="250px"></asp:TextBox></td>
</tr>
<tr>
 <th>��������:</th>
 <td>
<div id="classType"></div>
<input type ="hidden" id="areatypeid" runat="server" />
<script type="text/javascript">
var cla = new ClassType("cla",'area','classType','areatypeid');
cla.Mode ="select";
cla.Init();
</script>
 </td>
</tr>
<tr>
 <th>��ϵ��:</th>
 <td><asp:TextBox ID="tdrealname" runat="server" Width="250px"></asp:TextBox></td>
 </tr>
<tr>
  <th>�̶��绰:</th>
 <td><asp:TextBox ID="txtTelephone" runat="server" Width="300px"></asp:TextBox></td>
</tr>
<tr>
  <th>�������:</th>
 <td><asp:TextBox ID="txtFax" runat="server" MaxLength="20" Width="300px"></asp:TextBox></td>
</tr>
<tr>
 <th>�ֻ�����:</th>
 <td><asp:TextBox ID="tdmobil" runat="server" Width="250px"></asp:TextBox></td>
</tr>
<tr>
<th>���ڲ���:</th>
<td><asp:TextBox ID="tdsection" runat="server" Width="250px"></asp:TextBox></td>
</tr>

<tr>
<th>����ְλ:</th>
<td><asp:TextBox ID="tdpost" runat="server" Width="250px"></asp:TextBox></td>
</tr>

<tr>
  <th>��������:</th>
 <td><asp:TextBox ID="tdpostcode" runat="server" Width="250px"></asp:TextBox></td>
</tr>
    <tr>
        <th id="tdIM" runat="server"></th>
            
        <td>
            <asp:TextBox ID="txtIM" runat="server" Width="250px"></asp:TextBox></td>
    </tr>
<tr>
 <th>��ҵ��ַ:</th>
 <td><asp:TextBox ID="tdhomepage" runat="server" Width="250px"></asp:TextBox></td>
</tr>
<tr> 
 <th>��ϵ��ַ:</th>
 <td><asp:TextBox ID="tdlinkadress" runat="server" Width="250px"></asp:TextBox></td>
</tr>
<tr>
<th>��ҵ����:</th>
<td>
    <asp:RadioButtonList ID="tdcharacter" runat="server" RepeatDirection="Horizontal"
        RepeatLayout="Flow">
        <asp:ListItem>��ҵ��λ</asp:ListItem>
        <asp:ListItem>���徭Ӫ</asp:ListItem>
        <asp:ListItem>��ҵ��λ���������</asp:ListItem>
    </asp:RadioButtonList></td>
</tr>
<tr>
<th>��ҵ���:</th>
<td>
<div id="classTypecompany"></div>
<input type ="hidden" id="companyid" runat="server"/>
<script type="text/javascript">
var clacompany = new ClassType("clacompany",'company','classTypecompany','companyid');
clacompany.Mode ="select";
clacompany.Init();
</script>
</td>
</tr>
<tr>
<th>��Ӧ��Ʒ/����:</th>
<td><asp:TextBox ID="tdsupply" runat="server" TextMode="MultiLine" Rows="3" Columns="80"></asp:TextBox></td>
</tr>
<tr>
<th>�����Ʒ/����:</th>
<td><asp:TextBox ID="tdbuy" runat="server" TextMode="MultiLine" Rows="3" Columns="80"></asp:TextBox></td>
</tr>
</table>

<br/>
<div class="itemtitle"><h3>��ҵ�߼�����</h3></div>
<table width="100%" class="xy_tb xy_tb2 infotable border_buttom0">
<tr>
<th>ע���ʽ�:</th>
<td><asp:TextBox ID="tdmoney" runat="server" Width="250px"></asp:TextBox></td>
</tr>
<tr>
<th>ע���ʽ����:</th>
<td><asp:TextBox ID="tdmoneytype" runat="server" Width="250px" ReadOnly="True"></asp:TextBox></td>
</tr>
<tr>
<th>��ҵ��Ӫģʽ:</th>
<td>
    <asp:CheckBoxList ID="tdumode" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
    </asp:CheckBoxList></td>
</tr>
<tr>
<th>��ҵ������ݣ�</th>
<td><asp:TextBox ID="lbyear" runat="server" Width="250px"></asp:TextBox></td>
</tr>
<tr>
<th>��ҵע��أ�</th>
<td>
<div id="divaddress"></div>

<input type ="hidden" id="lbaddress" runat="server" />
<script type="text/javascript">
var cla3 = new ClassType("cla3",'area','divaddress','lbaddress');
cla3.Mode ="select";
cla3.Init();
</script>
</td>
</tr>
<tr>
<th>��Ҫ��Ӫ�ص㣺</th>
<td><asp:TextBox ID="lbarea" runat="server" Width="250px"></asp:TextBox></td>
</tr>
<tr>
<th>��ҵ������</th>
<td><asp:TextBox ID="lbnumber" runat="server" Width="250px"></asp:TextBox></td>
</tr>
<tr>
<th>��ҵ��飺</th>
<td><asp:TextBox ID="tdsynopsis" runat="server" Width="500px" TextMode ="MultiLine" Rows="8"></asp:TextBox></td>
</tr>
<tr>
<th></th>
<td class="content_action" colspan="3"> &nbsp;<asp:Button ID="btnOk" runat="server" CssClass="button" OnClick="btnOk_Click"
        Text="ȷ���޸�" />
    <input id="btcancel" type="button" value="����" class="button" runat="server" /></td>
</tr>
</table>

</div>

</td>
</tr>
</table>

</form>
</body>
</html>
