<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowAdd.aspx.cs" Inherits="XYECOM.Web.xymanage.ShowInfoManage.ShowAdd" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc1" %>
<%@ Register Src="../UserControl/UploadImage.ascx" TagName="UploadImage" TagPrefix="uc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>���չ����Ϣ</title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script language="javascript" type ="text/javascript" src ="../javascript/CheckedAll.js"></script>
<script type="text/javascript" src="/common/js/date.js" ></script>
<script type="text/javascript" src="../javascript/TreeType.js" ></script>
<script language ="javascript" type="text/javascript"  src="/common/js/UploadControl.js"></script>
</head>
<body>
<form id="Form1" method="post" runat="server">
<h1><a href="../index.aspx">��̨������ҳ</a> >> <asp:Label ID="Label1" runat="server" Text="���չ����Ϣ"></asp:Label></h1>
<table  width="100%" >
<tr>
<!-- right -->
<td class="right">
<!--��̨���� -->



<div class="main-setting">
<div class="itemtitle"><h3>������ϸ��Ϣ</h3></div>


<table width="100%" class="xy_tb xy_tb2 infotable">
<tr>
<th>չ�����ƣ�</th>
<td>
    <asp:TextBox ID="txtname" runat="server" Columns="60"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvname" runat="server" ControlToValidate="txtname"
        ErrorMessage="����дչ�����ƣ�"></asp:RequiredFieldValidator></td>
</tr>
<tr>
<th>չ�����</th>
<td>
<div id="classType"></div>
<input id="hidptid" name="hidptid" runat="server" type="hidden" value="" />
<script type="text/javascript">
var cla = new ClassType("cla",'exhibition','classType','hidptid');
cla.Mode ="select";
cla.Init();
</script>

    </td>
</tr>
<tr>
<th>��ϸ˵����</th>
<td><label>
<FCKeditorV2:FCKeditor ID="lbcontent" runat="server" BasePath="/Common/fckeditor/" ToolbarSet="User" Height="300px">
</FCKeditorV2:FCKeditor>
</label></td>
</tr>

<tr>
<th>�ϴ�ͼƬ��</th>
<td>
 <uc1:UploadImage ID="UploadFile1" runat="server" Iswatermark="false" MaxAmount="20" TableName="i_ShowInfo" InfoID="0"  />
</td>
</tr>

<tr>
<th>��Ļʱ�䣺</th>
<td style="height: 21px"><label>
<input id="bgdate" type="text" runat="server" readonly="readonly" onclick="getDateString(this);" maxlength="10" style="width:80px;" />
    <asp:RequiredFieldValidator ID="rvfdate" runat="server" ControlToValidate="bgdate"
        ErrorMessage="��ѡ��Ļʱ�䣡"></asp:RequiredFieldValidator></label></td>
</tr>

<tr>
<th>��Ļʱ�䣺</th>
<td style="height: 21px"><label>
<input id="egdate" type="text" readonly="readonly" runat="server" onclick="getDateString(this);" maxlength="10" style="width: 80px;" />
    <asp:RequiredFieldValidator ID="rvfed" runat="server" ControlToValidate="egdate"
        ErrorMessage="��ѡ���Ļʱ�䣡"></asp:RequiredFieldValidator></label></td>
</tr>
<tr>
<th>չ�����ڣ�</th>
<td><label>
    <asp:DropDownList ID="showzhouqi" runat="server" Width="80">
        <asp:ListItem>��ѡ��</asp:ListItem>
        <asp:ListItem>һ������</asp:ListItem>
        <asp:ListItem Selected="True">һ��һ��</asp:ListItem>
        <asp:ListItem>����һ��</asp:ListItem>
        <asp:ListItem>����һ��</asp:ListItem>
        <asp:ListItem>����һ��</asp:ListItem>
        <asp:ListItem>����</asp:ListItem>
    </asp:DropDownList></label></td>
</tr>

<tr>
<th>չ�����ͣ�</th>
<td><label>
    <asp:DropDownList ID="showtype" runat="server" Width="80">
        <asp:ListItem>����չ</asp:ListItem>
        <asp:ListItem>����չ</asp:ListItem>
    </asp:DropDownList></label></td>
</tr>
<tr>
<th>չ��ص㣺</th>
<td><label>
    <asp:TextBox ID="txtshowaddress" runat="server" Columns="60" TextMode="MultiLine" Rows="2"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvdidian" runat="server" ControlToValidate="txtshowaddress"
        ErrorMessage="����дչ��ص㣡"></asp:RequiredFieldValidator></label></td>
</tr>

<tr>
<th>չ�᳡�ݣ�</th>
<td><label>
    <asp:TextBox ID="txtshowchang" runat="server" Columns="60" TextMode="MultiLine" Rows="2"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvchangguan" runat="server" ControlToValidate="txtshowchang"
        ErrorMessage="����дչ�᳡�ݣ�"></asp:RequiredFieldValidator></label></td>
</tr>

<tr>
<th>���쵥λ��</th>
<td><label>
    <asp:TextBox ID="txtdanwei" runat="server" Columns="60" TextMode="MultiLine" Rows="4"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
        ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtdanwei" ErrorMessage="����д���쵥λ��"></asp:RequiredFieldValidator></label></td>
</tr>

<tr>
<th>�а쵥λ��</th>
<td><label>
    <asp:TextBox ID="txtundertakepost" runat="server"  Columns="60" TextMode="MultiLine" Rows="4"></asp:TextBox>&nbsp;</label></td>
</tr>

<tr>
<th>Э�쵥λ��</th>
<td><label>
    <asp:TextBox ID="txtxieban" runat="server"  Columns="60" TextMode="MultiLine" Rows="4"></asp:TextBox>&nbsp;</label></td>
</tr>

<tr>
<th>֧�ֵ�λ��</th>
<td style="height: 21px"><label>
    <asp:TextBox ID="txtshowsuoppt" runat="server"  Columns="60" TextMode="MultiLine" Rows="4"></asp:TextBox>&nbsp;</label></td>
</tr>



<tr>
<th>չ����ַ��</th>
<td><label>
    <asp:TextBox ID="txtshowhomepage" runat="server"  Columns="60"></asp:TextBox>&nbsp;</label></td>
</tr>

<tr>
<th>���������λ��</th>
<td style="height: 21px"><label>
    <asp:TextBox ID="txtshowareaunit" runat="server"></asp:TextBox>&nbsp;</label></td>
</tr>

<tr>
<th>���ص��ۣ�</th>
<td><label>
    <asp:TextBox ID="txtshowprice" runat="server"></asp:TextBox>
    </label></td>
</tr>

<tr>
<th>����������</th>
<td><label>
    <asp:TextBox ID="txtshowunit" runat="server"></asp:TextBox>
    </label></td>
</tr>

<tr>
<th>չλ���������</th>
<td><label>
    <asp:TextBox ID="txtshowarea" runat="server"></asp:TextBox>
    </label></td>
</tr>
<tr>
<th>&nbsp;</th>
<td class="padleft"><label>
    &nbsp;<asp:Button ID="Button1" runat="server" CssClass="button" Text="����" OnClick="Button1_Click" />
    <input id="Button2" type="button" value="����" onclick ="window.location.href='ShowInfoList.aspx?<%= backURL %>';" class ="button" />
    <asp:Label ID="lblMessage" runat="server" ForeColor="#C00000"></asp:Label>
    &nbsp;
    </label></td>
</tr>
</table> 

</div>
</td> 
</tr> 
</table> 
</form>
</body>
</html>
