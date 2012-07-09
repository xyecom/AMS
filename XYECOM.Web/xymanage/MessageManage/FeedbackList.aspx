<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FeedbackList.aspx.cs" Inherits="XYECOM.Web.xymanage.MessageManage.FeedbackList" %>
<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>�������</title>
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
<script language="javascript" type="text/javascript" src="/common/js/date.js"></script>
</head>
<body>
<form id="Form1" method="post" runat="server">
<h1>�������</h1>
<table width="100%" >
<tr>
<td class="right">

<div class="main-setting">
<div class="itemtitle"><h3>�������</h3>
</div>
<table class="xy_tb xy_tb2">
<tr>
<td>

    <table width="100%" class="partition">
        <tr>
            <th>
                ���⣺</th>
            <td><asp:textbox id="txtTitle" runat="server" Width="150px" MaxLength="30" CssClass="input_s"></asp:textbox>
            </td>
            <th>
                &nbsp;���ͣ�</th>
            <td id="classType">
                <asp:RadioButtonList ID="ddlType" runat="server" RepeatDirection="Horizontal"
                    RepeatLayout="Flow">
                    <asp:ListItem Value="0" Selected="True">����</asp:ListItem>
                    <asp:ListItem Value="1" >����</asp:ListItem>
                    <asp:ListItem Value="2">����</asp:ListItem>
                    <asp:ListItem Value="3">Ͷ��</asp:ListItem>
                    <asp:ListItem Value="4">����</asp:ListItem>
                    <asp:ListItem Value="5">ҵ����ϵ</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <th>
                ������</th>
            <td>
                <asp:TextBox ID="Name" runat="server" CssClass="input_s" MaxLength="30" Width="150px"></asp:TextBox></td>
            <th>
                E-mail��</th>
            <td>
                <asp:TextBox ID="Email" runat="server" CssClass="input_s" MaxLength="30" Width="150px"></asp:TextBox></td>
        </tr>
        <tr>
            <th>
                ��ʼ���ڣ�</th>
            <td>
                <asp:TextBox ID="txtBeginDate" runat="server" CssClass="input_s" onclick="getDateString(this);" MaxLength="30" Width="150px" ReadOnly="true"></asp:TextBox></td><th>
                    �绰��</th>
            <td>
                <asp:TextBox ID="Telephone" runat="server" CssClass="input_s" MaxLength="30" Width="150px"></asp:TextBox></td>
        </tr>
        <tr>
            <th>
                �������ڣ�</th>
            <td>
                <asp:TextBox ID="txtEndDate" runat="server" CssClass="input_s" onclick="getDateString(this);" MaxLength="30" Width="150px" ReadOnly="true"></asp:TextBox></td>
                <th>
                Ͷ����Ϣ����:
                </th>
            <td>
             <asp:DropDownList ID="DDLInfoFlag" runat="server">
            <asp:ListItem Value="-1">��ѡ��</asp:ListItem>
            <asp:ListItem Value="0">����</asp:ListItem>
            <asp:ListItem Value="1">��ͬ</asp:ListItem>
            <asp:ListItem Value="2">�Ź�</asp:ListItem>
            </asp:DropDownList>
            </td>
        </tr>
        <tr>
    <th>ÿҳ������</th>
    <td>
        <asp:TextBox ID="txtPageSize" runat="server" CssClass="" Columns="2" Text="20" MaxLength="3"></asp:TextBox> ��(1~100)
        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtPageSize"
            ErrorMessage="����1��100֮��" MaximumValue="100" MinimumValue="1" Type="Integer"></asp:RangeValidator>
        </td>
    <th></th>
    <td>
     <asp:CheckBox runat="server" ID="cbdays" Checked="true" /> �������&nbsp;<asp:TextBox runat="server" CssClass="" ID="txtdays" Columns="2" Text="2" ></asp:TextBox>&nbsp;���ȫ������ 
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtdays"
            ErrorMessage="����Ϊ����" ValidationExpression="^[1-9]\d*$"></asp:RegularExpressionValidator></td> 
</tr>
        <tr>
            <td></td>
            <td colspan="3">
            <asp:Button ID="btnFind" runat="server" CssClass="button" Text="��ѯ" OnClick="btnFind_Click"  />
            <input type="reset" value="����" class ="button" />
            </td>
        </tr>
    </table>



</td>
</tr>
<tr>
<td>
<asp:GridView ID="GV1" runat="server" HeaderStyle-CssClass="gv_header_style" AutoGenerateColumns="False" DataKeyNames="FeedbackID" Width ="100%" GridLines="None">
<Columns>
<asp:BoundField DataField="FeedbackID" HeaderText="FeedbackID" Visible="False" />
<asp:TemplateField HeaderText="ѡ��" >
<ItemTemplate>
<asp:CheckBox ID="chkExport" runat="server" />
</ItemTemplate>
    <ItemStyle Width="4%" />
</asp:TemplateField>
<asp:BoundField DataField="Title" HeaderText="����" >
    <HeaderStyle CssClass="gvLeft" />
    <ItemStyle CssClass="gvLeft" Width="32%" />
</asp:BoundField>
<asp:BoundField DataField="Name" HeaderText="����" >
    <HeaderStyle CssClass="gvLeft" />
    <ItemStyle CssClass="gvLeft" Width="15%" />
</asp:BoundField>
 <asp:TemplateField HeaderText="����">
    <ItemStyle Width="10%" />
        <ItemTemplate>
            <asp:Literal runat="server" ID="ltInfoFlag" Text='<%# GetInfoFlag(Eval("FeedbackID").ToString())%>'></asp:Literal>
        </ItemTemplate>
 </asp:TemplateField>
<%--<asp:ButtonField CommandName="type" HeaderText="����" DataTextField="Type" ><ItemStyle CssClass="action" Width="10%" /></asp:ButtonField>--%>
<asp:BoundField DataField="Email" HeaderText="E-mail" >
    <HeaderStyle CssClass="gvLeft" />
    <ItemStyle CssClass="gvLeft" Width="15%" />
</asp:BoundField>
    <asp:TemplateField HeaderText="��������">
        <ItemTemplate>
            <asp:Label ID="Label1" runat="server" Text='<%# Convert.ToDateTime(Eval("addtime")).ToString("yyyy-MM-dd") %>'></asp:Label>
        </ItemTemplate>
        <ItemStyle Width="12%" />
    </asp:TemplateField>

  <asp:TemplateField HeaderText="�鿴">
    <ItemStyle Width="5%" />
        <ItemTemplate>
            <a href='LookFeedback.aspx?FeedbackID=<%# Eval("FeedbackID") %>&backURL=<%# backURL %>'><img src="../images/look.GIF" alt="�鿴" /></a>
        </ItemTemplate>
 </asp:TemplateField>
</Columns>
    <HeaderStyle CssClass="gv_header_style" />
</asp:GridView>
<p style="text-align:center;"><asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label></p>
</td>
</tr>
<tr>
<td class="content_action">
<input id="chkAll" onclick="chkAll_true()" type="checkbox" name="chkAll" runat="server" />ȫѡ
<asp:Button ID="lnkDel" runat="server" CssClass="button" Text="ɾ��" OnClick="lnkDel_Click"  /></td>
</tr>
</table>
    <uc1:page ID="Page1" runat="server" />
</div>
</td>
</tr>
</table>
</form>
</body>
</html>

