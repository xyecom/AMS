<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_TemplatesManage_TemplatesEdit" Codebehind="TemplatesEdit.aspx.cs" %>

<%@ Register Src="../UserControl/top.ascx" TagName="top" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>修改模板代码</title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312"/>
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<link href="/Common/css/XYLib.css" media="screen" rel="stylesheet" type="text/css" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script type="text/javascript" src="../javascript/CheckedAll.js" ></script>
</head>
<body>
    <form id="form1" runat="server"> 
<table  width="100%"  class="content">
<tr>
<td >
<asp:TextBox ID="txtContent" CssClass="borderN" runat="server" Width="97%" Rows="23"  TextMode="MultiLine"></asp:TextBox>
</td>
</tr>
<tr>
<td class="content_action" ><asp:Button ID="btnOK" runat="server" Text="保存修改" CssClass="button" OnClick="btnOK_Click" />&nbsp;
<input id="Button4" class="button" type="button" value="取 消" onclick="closewindows();" />
</td>
</tr>
</table>

    </form>
  
	
</body>
</html>
