<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_basic_UserType" Codebehind="UserTypelist.aspx.cs" %>

<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc2" %>

<%@ Register Src="../UserControl/top.ascx" TagName="top" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>��ҵ������</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
    <script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
    <script language ="javascript" type ="text/javascript" src ="../javascript/labelClass.js"></script>
</head>
<body>
<form id="Form1" method="post" runat="server">

<h1><a href="../index.aspx">��̨������ҳ</a> &gt;&gt; ��ҵ�������</h1>
<table  width="100%" >
<tr>
<td class="right">    

<div class="main-setting">
<div class="itemtitle"><h3>��ҵ�����б�</h3>
<input id="btnadd" class="addbtn" type="button" value="������ҵ����" onclick="window.location.href='UserTypeAdd.aspx?UT_PID=<%=UT_PID%>';" />
</div>

<table class="xy_tb xy_tb2">
    <tr><td>
        <asp:Panel ID="pnlSuperClass" runat="server" CssClass="classTreeList">
        </asp:Panel>
   </td>
</tr>
<tr>
<td class="content_action">
    <input type="hidden" id="strdel" value="" runat="server"/>
    <input type="submit" value="����ɾ��" onclick="return delall();" class="button"/> 
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
