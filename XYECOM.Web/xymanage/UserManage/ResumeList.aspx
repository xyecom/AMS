<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResumeList.aspx.cs" Inherits="XYECOM.Web.xymanage.UserManage.ResumeList" %>
<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc2" %>

<%@ Register Src="../UserControl/top.ascx" TagName="top" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>���˺�̨����</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/XYLib.css" type="text/css" rel="Stylesheet" />
    <script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
    <script language ="javascript" type ="text/javascript" src ="../javascript/CheckedAll.js"></script>
    <script type="text/javascript" src="/common/js/date.js" ></script>
</head>
<body> 
    <form id="form1" runat="server">
    <h1><a href="../index.aspx">��̨������ҳ</a> >> �����û�����</h1>
<table  width="100%" >
<tr>
<!-- right -->
<td class="right">
<!--��̨���� -->
<div class="main-setting">
<div class="itemtitle"><h3>�����û�����</h3>
<ul class="tab1">
<li><a href="IndividualList.aspx"><span>������Ϣ</span></a></li><li class="current"><a href="ResumeList.aspx"><span>������Ϣ</span></a></li></ul></div>

<table class="xy_tb xy_tb2">
<tr>
<td>

<table class="partition">
<tr>
    <th>�����̶ȣ�</th>
    <td>
        <asp:DropDownList ID="edulevel" runat="server">
            <asp:ListItem Value="-1" Selected="True">����</asp:ListItem>
            <asp:ListItem Value="����">����</asp:ListItem>
            <asp:ListItem Value="��ר">��ר</asp:ListItem>
            <asp:ListItem Value="����">����</asp:ListItem>
            <asp:ListItem Value="��ר">��ר</asp:ListItem>
            <asp:ListItem Value="����">����</asp:ListItem>
            <asp:ListItem Value="˶ʿ">˶ʿ</asp:ListItem>
            <asp:ListItem Value="��ʿ">��ʿ</asp:ListItem>
            <asp:ListItem Value="����">����</asp:ListItem>          
        </asp:DropDownList>
    </td>
    <th>�������ޣ�</th>
    <td>
        <asp:DropDownList ID="workyears" runat="server">
            <asp:ListItem Value="-1" Selected="True">����</asp:ListItem>
            <asp:ListItem Value="�ڶ�ѧ��">�ڶ�ѧ��</asp:ListItem>
            <asp:ListItem Value="Ӧ���ҵ��">Ӧ���ҵ��</asp:ListItem>
            <asp:ListItem Value="һ������">һ������</asp:ListItem>
            <asp:ListItem Value="��������">��������</asp:ListItem>
            <asp:ListItem Value="��������">��������</asp:ListItem>
            <asp:ListItem Value="��������">��������</asp:ListItem>
            <asp:ListItem Value="��������">��������</asp:ListItem>
            <asp:ListItem Value="ʮ������">ʮ������</asp:ListItem>
        </asp:DropDownList>
    </td>
</tr>
<tr>
    <th>���ڳ��У�</th>
    <td>
     <div id="classType"></div>
        <input type ="hidden" id="areatypeid" runat="server" />
        <script type="text/javascript">
        var cla = new ClassType("cla",'area','classType','areatypeid');
        cla.Mode ="select";
        cla.Init();
        </script>
    </td>
    <th>��ҵʱ�䣺</th>
    <td>
    <input id="bgdate" type="text" runat="server" onclick="getDateString(this);" readonly="readonly" maxlength="10" style="width:80px;" />
     ��
    <input id="egdate" type="text" runat="server" onclick="getDateString(this);" readonly="readonly" maxlength="10" style="width: 80px;" />
    </td>
</tr>
<tr class="content_action">
<td></td>
    <td colspan="3">
    <asp:Button ID="Button2" runat="server" Text="����" CssClass ="button" OnClick="Button2_Click" />
    <input type="reset" value="����" class ="button" />
    </td>
</tr>
</table>
</td>
</tr>
<tr>
<td>

<asp:GridView ID="gvlist"  HeaderStyle-CssClass="gv_header_style" runat="server" AutoGenerateColumns="False"  DataKeyNames="U_ID,U_Name"  Width="100%" GridLines="None" OnRowDataBound="gvlist_RowDataBound">
<Columns>
<asp:BoundField DataField="U_ID" HeaderText="U_ID" Visible="False" />
<asp:TemplateField HeaderText="ѡ��">
 <ItemTemplate>
<asp:CheckBox ID="chkExport" runat="server" />
</ItemTemplate> 
    <ItemStyle Width="5%" />
</asp:TemplateField>
    <asp:TemplateField HeaderText="������">
    <ItemStyle Width="15%" />
        <ItemTemplate>
            <a href='IndividualInfo.aspx?U_ID=<%# Eval("U_ID") %>&backURL=<%# backURL %>'><%# Eval("U_Name")%></a>
        </ItemTemplate>
    </asp:TemplateField>
<asp:BoundField DataField="RE_School" HeaderText="��ҵѧУ">
    <HeaderStyle CssClass="gvLeft" />
    <ItemStyle CssClass="gvLeft" Width="15%" />
</asp:BoundField>
<asp:BoundField DataField="RE_Speciality" HeaderText="��ѧרҵ">
    <HeaderStyle CssClass="gvLeft" />
    <ItemStyle CssClass="gvLeft" Width="15%" />
</asp:BoundField>
<asp:BoundField DataField="RE_Schoolage" HeaderText="�����̶�">
    <HeaderStyle CssClass="gvLeft" />
    <ItemStyle CssClass="gvLeft" Width="10%" />
</asp:BoundField>

<asp:TemplateField HeaderText="��������">
    <ItemStyle Width="10%" CssClass="gvLeft" HorizontalAlign="Left"/>
    <ItemTemplate>
        <%#GetAreaName(DataBinder.Eval(Container,"DataItem.Area_Id").ToString())%>
    </ItemTemplate>
</asp:TemplateField>

<asp:BoundField DataField="RE_JobYear" HeaderText="��������">
    <HeaderStyle CssClass="gvLeft" />
    <ItemStyle CssClass="gvLeft" Width="10%" />
</asp:BoundField>
<asp:BoundField DataField="RE_Gyear" HeaderText="��ҵʱ��" DataFormatString="{0:d}" HtmlEncode="False">
    <ItemStyle Width="10%" />
</asp:BoundField>

<asp:TemplateField HeaderText="��̬ҳ��">
<ItemStyle CssClass="gvLeft" Width="10%" />
    <ItemTemplate>
        <%# Eval("RE_HtmlPage").ToString() != "" ? "<a href=\"/" + Eval("RE_HtmlPage").ToString() + "\" target=\"_black\">�鿴</a>" : "-"%>
    </ItemTemplate>
</asp:TemplateField>
 
</Columns>
</asp:GridView>
<p style="text-align:center;"><asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label></p> 
</td>
</tr>
<tr>
    <td class="content_action">
    <input id="chkAll" onclick="chkAll_true()" type="checkbox" name="chkAll" runat="server" />ȫѡ
    <asp:Button ID="btnCreateHtml" runat="server" CssClass="button" OnClick="btnCreateHtml_Click"
        Text="���ɾ�̬ҳ��" />&nbsp;
    <asp:Button ID="btnDelHtml" runat="server" CssClass="button" OnClick="btnDelHtml_Click"
        Text="ɾ����̬ҳ��" />
    </td>
</tr>
</table>

<uc2:page ID="Page1" runat="server"/>
</div>
</td>
</tr>
</table>
    </form>
</body>
</html>
