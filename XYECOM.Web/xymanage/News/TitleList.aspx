<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_news_TitleList" Codebehind="TitleList.aspx.cs" %>

<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc2" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>������Ŀ�б�</title>
<link href="../css/style.css" type="text/css" rel="Stylesheet" />
<link href="/common/css/XYLib.css" type="text/css" rel="Stylesheet" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
<script language ="javascript" type ="text/javascript" src ="../javascript/labelClass.js"></script>
</head>
<body>
<form id="form1" runat="server">

<h1><a href="../index.aspx">��̨������ҳ</a> >> ��Ѷ��Ŀ�б�</h1>

<table  width="100%" >
<tr>
<td class="right">    

<div class="main-setting">
<div class="itemtitle"><h3>��Ѷ��Ŀ�б�</h3>
<input type="button" class="addbtn" value="������Ŀ" onclick="location.href='AddTitle.aspx';"/>
</div>

<table class="xy_tb xy_tb2">
    <tr><td>

            <asp:Panel ID="pnlSuperClass" runat="server" CssClass="classTreeList">
            </asp:Panel>
    </td>
</tr>
<tr>
<td class="content_action">
    <input type="hidden" id="strids" value="" runat="server"/>
    <input type="hidden" id="cod" value="" runat="server"/>
    <input id="chkAll" onClick="chkchoose_true()" type="checkbox" name="chkAll"/>ȫѡ&nbsp;
    <input type="submit" value="���ɾ�̬ҳ��" onclick="return createordelete('��ѡ��Ҫ���ɵľ�̬ҳ��',0);" class="button"/> 
    &nbsp;
    <input type="submit" value="ɾ����̬ҳ��" onclick="return createordelete('��ѡ��Ҫɾ���ľ�̬ҳ��',1);" class="button"/> 
    &nbsp; &nbsp; ��Ŀ��û����Ѷ���ݵĽ��������ɾ�̬ҳ��</td>
</tr>
</table>
</td>
</tr>
</table>  
</td>
</tr>
</table>
</form>
</body>
</html>
