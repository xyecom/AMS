<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LabelOut.aspx.cs" Inherits="XYECOM.Web.xymanage.LabelManage.LabelOutIn" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>��ǩ���뵼��</title>
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>


<style type="text/css">

.tdAlignCenter{
    text-align:center;
}
</style>

</head>
<body>
<form id="form1" runat="server">

<h1><a href="../index.aspx">��̨������ҳ</a> >> ��ǩ����</h1>

<table width="100%">
<tr>
<td class="right">

<div class="main-setting">
<div class="itemtitle"><h3>��ǩ���뵼��</h3>
    <ul class="tab1" id="Ul1">
        <li class="current"><a href="#"><span>��ǩ����</span></a></li>
        <li><a href="LabelIn.aspx"><span>��ǩ����</span></a></li>
    </ul>
</div>

<!-- content  -->
<table class="xy_tb xy_tb2">
<tr>
<td class="right">
<!--��̨���� -->

<!-- ��� -->
        <script language="javascript">
        function ExportNavLabel(){
            if(document.getElementById("rbttypelabel").checked)
                document.getElementById("ddlclassID").disabled= true;
            else
                document.getElementById("ddlclassID").disabled= false;
        }
        </script>
        <br/>
            <asp:RadioButton ID="rbtcontentlabel" Checked="true" runat="server" GroupName="rbt" Text="�����������ݱ�ǩ" />
             <asp:DropDownList ID="ddlclassID" runat="server">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RadioButton ID="rbttypelabel" runat="server" GroupName="rbt" Text="�������е�����ǩ"/>&nbsp;&nbsp;
        <asp:Button ID="Button1" CssClass="button"  runat="server" Text=" ���� " OnClick="Button1_Click"/>
        &nbsp;&nbsp;<asp:Label ID="Label1" runat="server" ForeColor="Red" ></asp:Label>

<br/><br/><br/>
</td>
</tr>

<tr>
<td>

<table width="100%" >
<tr>
<td width="20%">
    <asp:ListBox ID="ddlBakFileList" runat="server" Width="300px" Rows="4"></asp:ListBox>
</td>
<td width="80%" align="left" class="back">
      <asp:Button ID="btnDeleteBackFile" runat="server" CssClass="button"
        Text=" ɾ����ǩ�ļ� " OnClick="btnDeleteBackFile_Click" /><br />
      <asp:Button ID="btnDownloadBackFile" runat="server" CssClass="button"
        Text=" ���ر�ǩ�ļ� " OnClick="btnDownloadBackFile_Click" />
</td>
</tr>
</table>


</td>
</tr>
</table>
</form>
</body>
</html>