<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_basic_Server" Codebehind="Server.aspx.cs" %>

<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc2" %>

<%@ Register Src="../UserControl/top.ascx" TagName="top" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>����������</title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script language ="javascript" type ="text/javascript"  src ="../javascript/CheckedAll.js"></script>
</head>
<body onload ="load();">
<form id="Form1" method="post" runat="server">
<h1><a href="../index.aspx">��̨������ҳ</a> >> ����������</h1>
<table  width="100%" >
<tr>
<td class="right">

<div class="main-setting">
<div class="itemtitle">
<h3>ϵͳ��������</h3>
<ul class="tab1">
    <li><a href="WebInfo.aspx"><span>��������</span></a></li>
    <li><a href="Function.aspx"><span>��������</span></a></li>
    <li><a href="BussinessInfoSet.aspx"><span>��ҵ��Ϣ���</span></a></li>
    <li><a href="UserInfoSet.aspx"><span>�û����</span></a></li>
    <li><a href="ShopSet.aspx"><span>�������</span></a></li>
    <li class="current"><a href="Server.aspx"><span>����������</span></a></li>
    <li><a href="EMailBoxInfoSet.aspx"><span>��վ����</span></a></li>
    <li><a href="SEO.aspx"><span>SEO����</span></a></li>
    <li><a href="SecuritySet.aspx"><span>��ȫ����</span></a></li>
</ul>
</div>
<input class="addbtn" id="btnAdd" onclick="block();" type="button" value="����������" runat="server"/>
<br/><br/>

<!-- ��� -->

<table width="100%" class="xy_tb xy_tb2" style="DISPLAY: none;" id="add">


<tr class="nobg">
  <td colspan="2" class="td27">�������</td>
</tr>
<tr style="display:none">
   <td class="vtop rowform">
    <label>
    <asp:RadioButton ID="lbwenzi" runat="server" Text="�ļ�" GroupName="servertype" />
    <asp:RadioButton ID="lbimage" runat="server" Text="ͼƬ" GroupName="servertype" Checked="True" /></label>
   </td>
   <td class="vtop tips2"></td>
</tr>


<tr class="nobg">
  <td colspan="2" class="td27">�Ƿ���ΪĬ�Ϸ�������</td>
</tr>
<tr>
   <td class="vtop rowform">    
    <asp:RadioButton ID="rbyes" runat="server" Text="��" GroupName="isyesno" Checked="True" />
    <asp:RadioButton ID="rbno" runat="server" Text="��" GroupName="isyesno" />
   </td>
   <td class="vtop tips2">Ĭ�Ϸ���������ǰ�����������ϴ����ļ����Ե�ǰ������Ϊ׼</td>
</tr>


<tr class="nobg">
  <td colspan="2" class="td27">���������ƣ�</td>
</tr>
<tr>
   <td class="vtop rowform">
    <label><asp:textbox id="txtName" runat="server" CssClass="txt"  MaxLength="20"></asp:textbox></label>
   </td>
   <td class="vtop tips2">��������ʶ���������ظ�</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">����·�� ������·������</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:textbox id="serverpath" runat="server" CssClass="txt" MaxLength="70"></asp:textbox>
   </td>
   <td class="vtop tips2">�磺e:\website <br />
	   ��ǰվ�������·��Ϊ��<asp:Label ID="lbServerPath" runat="server"></asp:Label>
   </td>
</tr>


<tr class="nobg">
  <td colspan="2" class="td27">����·��������·������</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:textbox id="serversul" runat="server" CssClass="txt" MaxLength="70"></asp:textbox>
    
   </td>
   <td class="vtop tips2">�磺http://server.xyecom.com/<br />
   ��ǰվ�������·��Ϊ��
    <asp:Label ID="lbHttpPath" runat="server"></asp:Label>
   </td>
</tr>


<tr>
<td colspan="2"><label><input class="button" id="btnOk" title="��ʼ���" type="submit" value="ȷ��" name="Submit3" runat="server" onserverclick="btnOk_ServerClick" />
<input class="button" id="btnQuit" onclick="quit();" type="button" value="ȡ��"/>
</label></td>
</tr>
</table>


<table id="update" style="DISPLAY: none;"  class="xy_tb xy_tb2">


<tr class="nobg">
  <td colspan="2" class="td27">���������ƣ�</td>
</tr>
<tr>
   <td class="vtop rowform">
    <label>
<asp:textbox id="txtname1" runat="server" CssClass="txt" ToolTip="�����û��ȼ���" MaxLength="50"></asp:textbox>
</label>
   </td>
   <td class="vtop tips2"></td>
</tr>


<tr class="nobg">
  <td colspan="2" class="td27">����·����</td>
</tr>
<tr>
   <td class="vtop rowform">
<asp:textbox id="serverpath1" runat="server" CssClass="txt" ToolTip="���������" MaxLength="200"></asp:textbox>
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">����·����</td>
</tr>
<tr>
   <td class="vtop rowform">
<asp:textbox id="serversul1" runat="server" CssClass="txt" MaxLength="200"></asp:textbox>
   </td>
   <td class="vtop tips2"></td>
</tr>


<tr>
<th></th>
<td><label id="key1"><input class="button" id="btupdate" title="�޸�" type="submit" value="�޸�" name="Submit3" runat="server"  onclick ="return Edit();" onserverclick="Submit1_ServerClick"  />
    <asp:Button ID="btnCanel" runat="server" CssClass="button" Text="ȡ��" OnClick="btnCanel_Click" />
    <input id="S_ID" runat="server" type="hidden" />
    <input id="key" runat="server" type="hidden" /></label></td>
</tr>
</table>



<table class="xy_tb xy_tb2">
<tr>
<td>
    <asp:GridView ID="gvlist" HeaderStyle-CssClass="gv_header_style" runat="server" AutoGenerateColumns="False"  DataKeyNames="S_ID,S_Flag"  Width="100%"  OnRowCommand="gvlist_RowCommand" OnRowDataBound="gvlist_RowDataBound" GridLines="None">
<Columns>
    <asp:BoundField DataField="S_ID" HeaderText="S_ID" Visible="False" />
    <asp:BoundField DataField="S_Name" HeaderText="����������" >
        <ItemStyle CssClass="gvLeft" Width="15%" />
        <HeaderStyle CssClass="gvLeft" />
    </asp:BoundField>
     <asp:BoundField DataField="S_Path" HeaderText="����·��"  >
         <ItemStyle CssClass="gvLeft" Width="30%" />
         <HeaderStyle CssClass="gvLeft" />
     </asp:BoundField>
      <asp:BoundField DataField="S_URL" HeaderText="����·��" >
          <ItemStyle CssClass="gvLeft" Width="30%" />
          <HeaderStyle CssClass="gvLeft" />
      </asp:BoundField>
    <asp:TemplateField HeaderText="Ĭ��" ShowHeader="False">
        <ItemTemplate>
            <asp:LinkButton ID="lbtnChecked" CommandArgument='<%# Eval("S_ID") %>' runat="server" CausesValidation="False"
                OnClick="lbtnChecked_Click" Text='<%# Convert.ToBoolean(Eval("S_IsCurrent")) ? "<img src=\"../images/checked.gif\" />" : "<img src=\"../images/unchecked.gif\" />" %>'></asp:LinkButton>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:BoundField DataField="S_Flag" HeaderText="����" Visible="false"/>
     <asp:ButtonField CommandName="up" HeaderText="�޸�" Text="&lt;img src=&quot;../images/edit.gif&quot; /&gt;" />
      <asp:ButtonField CommandName="del" HeaderText="ɾ��" Text="&lt;img src=&quot;../images/delete.gif&quot; /&gt;"/>
     
</Columns>
</asp:GridView><input id="Hidden1" runat="server" type="hidden" />
</td>
</tr>

</table>
<p style="text-align:center;"><asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
    <uc2:page ID="Page1" runat="server" />
</p>
</div>
</td>
</tr>
</table>
</form>
</body>
</html>
