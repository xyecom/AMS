<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_Certificate_certificateinfo" Codebehind="certificateinfo.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>��ҵ֤����Ϣ�鿴</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
</head>
<body>


    <form id="form1" runat="server">
    <h1><a href="../index.aspx">��̨������ҳ</a> >> ��ҵ֤����Ϣ</h1>
    <table width="100%" >
<tr>
<td class="right" >

<div class="main-setting">
<div class="itemtitle"><h3>��ҵ֤����ϸ</h3></div>

<table width="100%" class="xy_tb xy_tb2 infotable border_buttom0">
    <tr>
    <th>
        ֤�����ƣ�</th>
    <td><asp:Label ID="LbCE_Name" runat="server"></asp:Label></td>
    </tr>
    <tr>
    <th>�����ߣ�</th>
    <td id="lbU_Name" runat ="server"></td>
    </tr>
    <tr>
    <th>
        ֤�����</th>
    <td><asp:Label ID="lbCE_Type" runat="server"></asp:Label></td>
    </tr>
    <tr>
    <th>
        ��֤���أ�</th>
    <td><asp:Label ID="lbCE_Organ" runat="server"></asp:Label></td>
    </tr>
    <tr>
    <th>���ʱ�䣺</th>
    <td><asp:Label ID="lbCE_Addtime" runat="server"></asp:Label></td>
    </tr>
<tr>
<th>
    ֤����Ч���ڣ�</th>
<td><asp:Label ID="lbCE_Begin" runat="server"></asp:Label></td>
</tr>
<tr>
<th>
    ֤��������ڣ�</th>
<td><asp:Label ID="lbCE_Upto" runat="server"></asp:Label></td>
</tr>
<tr>
<th>
    ֤��ͼƬ��</th>
<td>
    <asp:Image ID="Image1"  runat="server" Width="150" Height="100" />&nbsp;&nbsp;
    <a id="aZoom" target="_blank" runat="server" href="">�Ŵ�+</a>
    </td>
</tr>
<tr>
<th>
    ״̬��</th>
<td>
     <asp:label id="lblMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:label></td>
</tr>
<tr>
<th>&nbsp;</th>
<td class="content_action"><label>  
    <asp:Button ID="Button2" runat="server" Text="ͨ�����" CssClass ="button" OnClick="Button2_Click" />&nbsp;
    <asp:Button ID="Button3" runat="server" Text="����" CssClass ="button" OnClick="Button3_Click"  />
    <input id="CE_Type" runat="server" type="hidden" />
    <input id="U_ID" runat="server" type="hidden" /></label></td>
</tr>
</table>
</div>

</td></tr>
</table>
</form>
</body>
</html>
