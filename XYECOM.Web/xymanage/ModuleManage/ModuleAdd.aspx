<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_ModuleManage_ModuleAdd" Codebehind="ModuleAdd.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>�Զ���ģ������</title>
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<link href="../css/cue.css" type="text/css" rel="stylesheet" />
<link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script type="text/javascript" src="../javascript/CheckedAll.js" ></script>
</head>
<body>
<form id="form1" runat="server" method="post">
<h1><a href="../index.aspx">��̨������ҳ</a> >> �Զ���ģ������</h1>
<table width="100%" >
<tr>
<td class="right">    

<div class="main-setting">
<div class="itemtitle"><h3>�Զ���ģ������</h3>
</div>

<table class="xy_tb xy_tb2 ">
<tr>
   <td class="vtop">    
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
    <asp:TextBox ID="tbename" runat="server" CssClass="input" MaxLength="15" ToolTip="Z-a"></asp:TextBox>
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
<asp:Panel ID="pnlSEOSetting" runat="server">
<tr class="nobg">
  <td colspan="2" class="td27">��Ϣ�������ã�</td>
</tr>
<tr>
   <td class="vtop rowform">
        <table border="0" cellpadding="0" cellspacing="0" class="s_f_p" id="tableInfoType">
                <tr class="t">
                <td></td>
                <td>ǰ׺</td>
                <td>��׺</td>
                <td>��Ϣ����</td>
                <td>&nbsp;</td>
                </tr>
                <tr>
                <td><input type="text" id="tbid1" readonly="readonly" class="m_i" value="1"/></td>
                <td><input type="text" id="tbprefix1" name="tbprefix1" /></td>
                <td><input type="text" id="tbpostfix1" name="tbpostfix1"/></td>
                <td>
                    <input type="radio" name="rb1" value="sell" checked="checked"   onclick="SetInfoTypeValue(1);"/><label>��</label>
                    <input type="radio" name="rb1" value="buy"  onclick="SetInfoTypeValue(1);"/><label>��</label>
                    <input type="hidden" id="hidInfoType_1" name="hidInfoType_1" value="sell"/>
                </td>
                <td></td>
                </tr>
                <tr id="tr2">
                <td><input type="text" id="tbid2" readonly="readonly" class="m_i" value="2"/></td>
                <td><input type="text" id="tbprefix2" name="tbprefix2" /></td>
                <td><input type="text" id="tbpostfix2" name="tbpostfix2"/></td>
                <td>
                    <input type="radio" name="rb2" value="sell" checked="checked" onclick="SetInfoTypeValue(2);"/><label>��</label>
                    <input type="radio" name="rb2" value="buy" onclick="SetInfoTypeValue(2);"/><label>��</label>
                    <input type="hidden" id="hidInfoType_2" name="hidInfoType_2" value="sell" />
                </td>
                <td id="tdDel_2" style="display:none;"><a href="#" onclick="DeleteInfoType(2);"><img src="../images/delete1.gif" alt="ɾ��" border="0"/></a></td>
                </tr>
                <tr id="tr3">
                <td><input type="text" id="tbid3" readonly="readonly" class="m_i" value="3"/></td>
                <td><input type="text" id="tbprefix3" name="tbprefix3"/></td>
                <td><input type="text" id="tbpostfix3" name="tbpostfix3"/></td>
                <td> 
                    <input type="radio" name="rb3" value="sell" checked="checked" onclick="SetInfoTypeValue(3);"/><label>��</label>
                    <input type="radio" name="rb3" value="buy" onclick="SetInfoTypeValue(3);"/><label>��</label>
                    <input type="hidden" id="hidInfoType_3" name="hidInfoType_3" value="sell"/>
                </td>
                <td id="tdDel_3"  style="display:;"><a href="#" onclick="DeleteInfoType(3);"><img src="../images/delete1.gif" alt="ɾ��"/></a></td>
                </tr>
                </table>
   </td>
   <td class="vtop tips2">
   <img src="../images/add.gif" alt="��˼�������Ϣ����" onclick="AddInfoType()" />  ��˼�������Ϣ����
            <input type="hidden" id="infoTypeTotal" name="infoTypeTotal" runat="server" value="3" />
   </td>
</tr>
</asp:Panel>
<tr>
<td colspan="2">&nbsp;<label><input type="submit" value="����" class="button" runat="server"/>
&nbsp;<input id="Button1" class="button" type="button" value="����" onclick="javascript:history.go(-1);" /></label></td>
</tr>
</table>
</div>
</td>
</tr>
</table>
</form>
</body>
</html>


