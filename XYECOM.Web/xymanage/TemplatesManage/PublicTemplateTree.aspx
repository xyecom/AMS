<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_TemplatesManage_PublicTemplateTree" Codebehind="PublicTemplateTree.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title><%=TName%>ģ�����</title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />

<link href="../css/eflange.css" type="text/css" rel="stylesheet" />
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<link href="/common/css/XYLib.css" type="text/css" rel="Stylesheet" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script type="text/javascript" src="../javascript/CheckedAll.js"></script>
<script type="text/javascript" src="../javascript/templates.js"></script>

</head>
<body>
<iframe id="window" style="position:absolute; z-index:4;display:none;" frameBorder="0" onload="iframeload(this)"></iframe>
<div id='Div_window' style="position:absolute;display:none; left:0; top:0; width:100%; z-index:3;" onkeydown ="if(event.keyCode == 13 || event.keyCode == 32){sClose();} "></div>

<form id="Form1" method="post" runat="server">
<h1><a href="../index.aspx">��̨������ҳ</a> >> <%=TName%>ģ���ļ��б�</h1> 
<table cellspacing="0" cellpadding="0" width="100%" border="0">
<tr>
<!-- right -->
<td class="right">
<!--��̨���� -->
<!-- ��� -->
 
   
    <div id="temp">
	
	 <div id="temp_title" class="sel_s_tabs2">
	 <ul>
	  <li id="default" class="current" ><%=TName%>ģ���ļ�</li>	  
	 </ul>	 
	 </div>
	 
	 <div class="temp_con" id="defaultlist" runat="server"></div>
	 
	 <div class="temp_but">
	  <input name="" type="checkbox" value="" id="chkallaspx" onclick="templatescheckall();" />ȫѡ&nbsp;<input
              id="Button2" class="button" type="button" value="��ѡ�е�ģ���ļ�����ҳ��" onclick="javascript:return createmobulehtml();" />&nbsp;<input type="button" value="�� ��" class="button" onclick="window.location.href=document.getElementById('hidurl').value;" />
	  </div>
	 
	</div>
</td>
</tr>
</table>
<input id="hidT_ID" type="hidden" name="Hidden1" runat="server" />
    <input id="hidpath" runat="server" type="hidden" />
    <input id="hidpathname" runat="server" type="hidden" /><input id="hidppathname" runat="server" type="hidden" /><input id="hidurl" runat="server" type="hidden" />
</form>
</body>
</html>

