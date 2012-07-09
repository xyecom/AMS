<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StatisticsNew.aspx.cs" Inherits="XYECOM.Web.xymanage.Global.StatisticsNew" %>

<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head2" runat="server">
<title>ͳ����Ѷ</title>
<link href="../css/style.css" type="text/css" rel="Stylesheet" />
<link href="/common/css/XYLib.css" type="text/css" rel="Stylesheet" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
<script language ="javascript" type ="text/javascript" src ="../javascript/list.js"></script>
<script type="text/javascript" src="/common/js/date.js" >function DIV1_onclick() {

}

</script>
</head>
<body>
<form id="form2" runat="server">



<h1><a href="../index.aspx">��̨������ҳ</a> >> ����ͳ��</h1>


<table  width="100%" >
<tr>
<td class="right">    

<div class="main-setting">
<div class="itemtitle"><h3>����ͳ��</h3>
<ul class="tab1">
    <li class="current"><a href="StatisticsNew.aspx"><span>������Ѷ</span></a></li>
   <li><a href="StatSendInfo.aspx"><span>Ͷ����Ѷ</span></a></li>
   <li><a href="PageRecord.aspx"><span>ҳ�����</span></a></li>   
</ul>
</div>
<table class="xy_tb xy_tb2" style="margin-top:0px;">
<tr>
<td align="center">
<table class="partition">
        <tr>
            <th style="width: 129px;" align="right">
                ��Ѷ������Ŀ��</th>
            <td style="width: 244px" align="left">
                <asp:DropDownList ID="ddcolumn" runat="server" CssClass="dropdownlist" Width="100px">
                </asp:DropDownList></td>
            <td align="right" style="width: 99px; height: 38px">
                �����ˣ�</td>
            <td style="width: 452px; height: 38px" align="left">
                <asp:DropDownList ID="ddlPromulgator" runat="server" CssClass="dropdownlist" Width="65px">
                    <asp:ListItem Value="-1"></asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <th style="width: 129px; height: 24px" align="right">
                ���״̬��</th>
            <td style="width: 244px" align="left">
                <asp:RadioButtonList ID="ddlState" runat="server" Height="9px" RepeatDirection="Horizontal"
                    Width="240px">
                    <asp:ListItem Selected="True" Value="-1">����</asp:ListItem>
                    <asp:ListItem Value="1">ͨ�����</asp:ListItem>
                    <asp:ListItem Value="0">δͨ�����</asp:ListItem>
                </asp:RadioButtonList></td>
            <td align="right" style="width: 99px; height: 24px">
                ���ڣ�</td>
            <td style="width: 452px; height: 24px" align="left">
                <input id="bgdate" runat="server" maxlength="10" onclick="getDateString(this);" readonly="readonly" style="width: 90px" type="text" />
                ��
                <input id="egdate" runat="server" maxlength="10" onclick="getDateString(this);" readonly="readonly" style="width: 90px" type="text" />
                </td>
        </tr>
    <tr>
        <th align="right" style="width: 129px; height: 24px">
        </th>
        <td align="left" style="width: 244px">
                <asp:Button ID="btnSearch" runat="server" CssClass="button" Text="��ѯ" OnClick="btnSearch_Click" /></td>
        <td align="right" style="width: 99px; height: 24px">
        </td>
        <td align="left" style="width: 452px; height: 24px">
        </td>
    </tr>
        <tr>
        
            <td  colspan="4">
    <asp:GridView  ID="gvlist" HeaderStyle-CssClass="gv_header_style"  runat="server" Width="100%" AutoGenerateColumns="False" PageSize="20" GridLines="None" OnRowDataBound="gvlist_RowDataBound" ShowFooter="True">
    
        <Columns>
 
            <asp:BoundField HeaderText="������" DataField="um_name">
            <HeaderStyle CssClass="gvCenter" />
            </asp:BoundField >
            
            <asp:BoundField HeaderText="��������" DataField="total">
           <HeaderStyle CssClass="gvCenter" /> 
       </asp:BoundField >
        </Columns>
        <HeaderStyle CssClass="gv_header_style" />
    </asp:GridView>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label></td>
        </tr>
    </table>
</td>
</tr>
</table>


<p style="text-align:center;"></p>
</div>
</td></tr>
</table>  

</form>
</body>
</html>
