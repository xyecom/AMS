<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_LabelManage_NewsSet" Codebehind="NewsSet.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>���ű�ǩ����</title>
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
<script type="text/javascript" src="/Common/js/base.js" language="javascript"></script>
<script type="text/javascript" src="../javascript/CheckedAll.js" ></script>
<script type="text/javascript" src="../javascript/TreeNewsType.js" >
</script>

</head>
<body>
<form id="form1" runat="server">
<table width="100%" >
<tr>

<td class="right">


<div class="main-setting">

<div class="labeldatatitle">
<ul id="labelTable">
    <li id="li_base" class="current" onclick="infoshow(1,this);"><a href="javascript:;"><span>�����б�</span></a></li>
    <li id="li_page" onclick="infoshow(2,this);"><a href="javascript:;"><span>������ҳ�б�</span></a></li>
    <%--<li id="li_key" onclick="infoshow(3,this);parent.setChildNum(16);"><a href="javascript:;"><span>��ҵ�����б�</span></a></li>--%>
</ul>
</div>



<!--������Ϣ-->
<table width="100%" class="xy_tb xy_tb2 setLabelData" id="base" >
<tr>
<th>��Ѷ���ͣ�</th>
<td>
    <asp:RadioButton ID="Rbt_base" runat="server" Checked="True" Text="����" GroupName="Rbt_news" OnCheckedChanged="Rbt_filmstrip_CheckedChanged" AutoPostBack="True"/>
    <asp:RadioButton ID="Rbt_index" runat="server" Text="ͷ��" GroupName="Rbt_news" OnCheckedChanged="Rbt_filmstrip_CheckedChanged"  AutoPostBack="True"/>
    <asp:RadioButton ID="Rbt_hot" runat="server" Text="�ȵ�" GroupName="Rbt_news" OnCheckedChanged="Rbt_filmstrip_CheckedChanged" AutoPostBack="True"/>
    <asp:RadioButton ID="Rbt_filmstrip" runat="server" Text="�õ�" GroupName="Rbt_news" OnCheckedChanged="Rbt_filmstrip_CheckedChanged" AutoPostBack="True" />
    <asp:RadioButton ID="Rbt_Scheme" runat="server" Text="����ʽ�ɹ�" GroupName="Rbt_news" OnCheckedChanged="Rbt_filmstrip_CheckedChanged" AutoPostBack="True" /></td>
</tr>
<tr>
<th>��Ѷ��Ŀ��</th>
<td>
<div id="classType1"></div>
<input id="hdgetid" type="hidden" runat="server" /></td>
</tr>
<tr>
<th width="23%">
    ����ר�⣺</th>
<td>
    <asp:DropDownList ID="ddlTopicid" runat="server">
     
    </asp:DropDownList>
</td>
</tr>
<tr>
<th>
    ����������</th>
<td>
        <asp:TextBox ID="tbnum" runat="server" CssClass="input" MaxLength="10" onblur="isNumer(this);" Text="10"></asp:TextBox></td>
</tr>
<tr><th>
    ������ʾ������</th>
    <td>
    <asp:TextBox ID="tbtitlenum" runat="server" CssClass="input" MaxLength="10" onblur="isNumer(this);"></asp:TextBox></td>
</tr>
<tr>
<th>
    ����������ڣ�</th>
<td>
    <asp:TextBox ID="tbclicknum" runat="server" CssClass="input" MaxLength="10" onblur="isNumer(this);"></asp:TextBox></td>
</tr>
<tr>
<th>
    �����ֶΣ�</th>
<td>
        <asp:DropDownList ID="ddlorderColumuName" runat="server" CssClass="input">
        </asp:DropDownList><asp:DropDownList ID="ddlorder" runat="server" CssClass="input">
            <asp:ListItem Value="DESC">����</asp:ListItem>
            <asp:ListItem Value="ASC">����</asp:ListItem>
        </asp:DropDownList></td>
</tr>
<tr>
<th>���ڸ�ʽ��</th>
<td>
    <asp:DropDownList ID="ddldatetype" runat="server"><asp:ListItem Value="">��ѡ��</asp:ListItem>
        <asp:ListItem Value="yyyy-MM-dd">yyyy-MM-dd</asp:ListItem>
        <asp:ListItem Value="yy-MM-dd">yy-MM-dd</asp:ListItem>
        <asp:ListItem Value="MM.dd">MM.dd</asp:ListItem>
        <asp:ListItem Value="MM-dd">MM-dd</asp:ListItem>
        <asp:ListItem Value="MM\\dd">MM\dd</asp:ListItem>
    </asp:DropDownList></td>
</tr>
<tr>
<th>
    ��Ѷ������ʾ������</th>
<td>
    <asp:TextBox ID="tbcontentnum" runat="server" CssClass="input" MaxLength="10" onblur="isNumer(this);"></asp:TextBox></td>
</tr>
<tr>
<th>
    �Ƿ��Ƽ���</th>
<td>
    <asp:DropDownList ID="ddlCommend" runat="server">
        <asp:ListItem Value="">����</asp:ListItem>
        <asp:ListItem Value="0">���Ƽ�</asp:ListItem>
        <asp:ListItem Value="1">�Ƽ�</asp:ListItem>
    </asp:DropDownList></td>
</tr>
<tr>
<th>�Ƿ�ΪͼƬ��Ѷ��</th>
<td>
    <asp:DropDownList ID="ddlimg" runat="server">
        <asp:ListItem Value="">����</asp:ListItem>
        <asp:ListItem Value="0">����</asp:ListItem>
        <asp:ListItem Value="1">ͼƬ</asp:ListItem>
    </asp:DropDownList></td>
</tr>
<tr>
    <th>�Ƿ�ΪͶ����Ѷ��</th>
   <td>
        <asp:RadioButton runat="server" ID="rbtcobyes" GroupName="contributor" Text="��" />
        <asp:RadioButton runat="server" ID="rbtcobno" GroupName="contributor" Text="��" />
        <asp:RadioButton runat="server" ID="rbtcobmay" GroupName="contributor" Text="����" Checked="true" />
   </td> 
</tr>
<tr>
<th>&nbsp;</th>
<td><label> <asp:button id="btnOK" runat="server" CssClass="button" Text="ȷ�������˱�ǩ" OnClick="BtnNewsList"   ></asp:button>&nbsp;
    <input id="Button2" class="button" type="button" value="ȡ��" onclick="closewindows();" /></label></td>
</tr>
</table>


<!--������ҳ�б����� -->

<table width="100%" class="xy_tb xy_tb2 setLabelData" id="page" style="display:none;">
<tr>
<th>
    ÿҳ����������</th>
<td>
        <asp:TextBox ID="tbpagenum" runat="server" CssClass="input" MaxLength="10" onblur="isNumer(this);" Text="20"></asp:TextBox></td>
</tr>
<tr><th>
    ������ʾ������</th>
    <td>
    <asp:TextBox ID="tbpagetitlenum" runat="server" CssClass="input" MaxLength="10" onblur="isNumer(this);"></asp:TextBox></td>
</tr>
<tr>
<th>���ڸ�ʽ��</th>
<td>
    <asp:DropDownList ID="ddlpagedatetype" runat="server"><asp:ListItem Value="">��ѡ��</asp:ListItem>
        <asp:ListItem Value="yyyy-MM-dd">yyyy-MM-dd</asp:ListItem>
        <asp:ListItem Value="yy-MM-dd">yy-MM-dd</asp:ListItem>
        <asp:ListItem Value="MM.dd">MM.dd</asp:ListItem>
        <asp:ListItem Value="MM-dd">MM-dd</asp:ListItem>
        <asp:ListItem Value="MM\\dd">MM\dd</asp:ListItem>
    </asp:DropDownList></td>
</tr>
<tr>
<th>
    �����ֶΣ�</th>
<td >
        <asp:DropDownList ID="ddlpageorder" runat="server" CssClass="input">
        </asp:DropDownList><asp:DropDownList ID="ddlpagedesc" runat="server" CssClass="input">
            <asp:ListItem Value="DESC">����</asp:ListItem>
            <asp:ListItem Value="ASC">����</asp:ListItem>
        </asp:DropDownList></td>
</tr>
<tr>
<th>��Ѷ������ʾ������</th>
<td>
    <asp:TextBox ID="tbpageproductnum" runat="server" CssClass="input" MaxLength="10" onblur="isNumer(this);"></asp:TextBox></td>
</tr>
<tr>
<th>&nbsp;</th>
<td><label> &nbsp;<asp:button id="btnPageOK" runat="server" CssClass="button" Text="ȷ�������˱�ǩ" OnClick="BtnNewsPageList"></asp:button>&nbsp;
    <input id="Button4" class="button" type="button" value="ȡ��" onclick="closewindows();" /></label></td>
</tr>
</table>




<!--��ҵ�����б����� -->
<%--<table width="100%" class="xy_tb xy_tb2 setLabelData" id="key" style="display:none;" >
<tr>
<th>
    ����������</th>
<td>
        <asp:TextBox ID="txtTopNumberForUserNews" runat="server" CssClass="input" MaxLength="10" onblur="isNumer(this);" Text="10"></asp:TextBox>
        </td>
</tr>
<tr><th>
    ������ʾ������</th>
    <td>
    <asp:TextBox ID="txtTitleNumberForUserNews" runat="server" CssClass="input" MaxLength="10" onblur="isNumer(this);"></asp:TextBox></td>
</tr>
<tr>
<th>���ڸ�ʽ��</th>
<td>
    <asp:DropDownList ID="ddlDateFormatForUserNews" runat="server">
        <asp:ListItem Value="">��ѡ��</asp:ListItem>
        <asp:ListItem Value="yyyy-MM-dd">yyyy-MM-dd</asp:ListItem>
        <asp:ListItem Value="yy-MM-dd">yy-MM-dd</asp:ListItem>
        <asp:ListItem Value="MM.dd">MM.dd</asp:ListItem>
        <asp:ListItem Value="MM-dd">MM-dd</asp:ListItem>
        <asp:ListItem Value="MM\\dd">MM\dd</asp:ListItem>
    </asp:DropDownList></td>
</tr>

<tr>
<th>ָ����ҵ��</th>
<td>
    <asp:TextBox ID="txtLoginNameForUserNews" runat="server" CssClass="input" MaxLength="15"></asp:TextBox><br/>
    ��ָ����ҵ�û���¼��;���Բ�ָ��,��Ĭ�ϵ���������ҵ����</td>
</tr>
<tr>
<th>&nbsp;</th>
<td><label> <asp:button id="btnCreateEnterpriseNews" runat="server" CssClass="button" Text="ȷ�������˱�ǩ" OnClick="btnCreateEnterpriseNews_Click" ></asp:button>&nbsp;
    <input id="btnEnterpriseCancel" class="button" type="button" value="ȡ��" onclick="closewindows();" /></label></td>
</tr>
</table>--%>

</div>

</td>
</tr>
</table>
</form>
</body>
</html>
<script type="text/javascript">
var cla = new ClassType("cla",'news','classType1','hdgetid');
cla.Mode = "select";
cla.Init();
</script>
