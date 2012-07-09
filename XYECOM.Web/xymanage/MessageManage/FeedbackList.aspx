<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FeedbackList.aspx.cs" Inherits="XYECOM.Web.xymanage.MessageManage.FeedbackList" %>
<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>意见反馈</title>
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
<script language="javascript" type="text/javascript" src="/common/js/date.js"></script>
</head>
<body>
<form id="Form1" method="post" runat="server">
<h1>意见反馈</h1>
<table width="100%" >
<tr>
<td class="right">

<div class="main-setting">
<div class="itemtitle"><h3>意见反馈</h3>
</div>
<table class="xy_tb xy_tb2">
<tr>
<td>

    <table width="100%" class="partition">
        <tr>
            <th>
                标题：</th>
            <td><asp:textbox id="txtTitle" runat="server" Width="150px" MaxLength="30" CssClass="input_s"></asp:textbox>
            </td>
            <th>
                &nbsp;类型：</th>
            <td id="classType">
                <asp:RadioButtonList ID="ddlType" runat="server" RepeatDirection="Horizontal"
                    RepeatLayout="Flow">
                    <asp:ListItem Value="0" Selected="True">所有</asp:ListItem>
                    <asp:ListItem Value="1" >求助</asp:ListItem>
                    <asp:ListItem Value="2">建议</asp:ListItem>
                    <asp:ListItem Value="3">投诉</asp:ListItem>
                    <asp:ListItem Value="4">表扬</asp:ListItem>
                    <asp:ListItem Value="5">业务联系</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <th>
                姓名：</th>
            <td>
                <asp:TextBox ID="Name" runat="server" CssClass="input_s" MaxLength="30" Width="150px"></asp:TextBox></td>
            <th>
                E-mail：</th>
            <td>
                <asp:TextBox ID="Email" runat="server" CssClass="input_s" MaxLength="30" Width="150px"></asp:TextBox></td>
        </tr>
        <tr>
            <th>
                开始日期：</th>
            <td>
                <asp:TextBox ID="txtBeginDate" runat="server" CssClass="input_s" onclick="getDateString(this);" MaxLength="30" Width="150px" ReadOnly="true"></asp:TextBox></td><th>
                    电话：</th>
            <td>
                <asp:TextBox ID="Telephone" runat="server" CssClass="input_s" MaxLength="30" Width="150px"></asp:TextBox></td>
        </tr>
        <tr>
            <th>
                结束日期：</th>
            <td>
                <asp:TextBox ID="txtEndDate" runat="server" CssClass="input_s" onclick="getDateString(this);" MaxLength="30" Width="150px" ReadOnly="true"></asp:TextBox></td>
                <th>
                投诉信息类型:
                </th>
            <td>
             <asp:DropDownList ID="DDLInfoFlag" runat="server">
            <asp:ListItem Value="-1">请选择</asp:ListItem>
            <asp:ListItem Value="0">订单</asp:ListItem>
            <asp:ListItem Value="1">合同</asp:ListItem>
            <asp:ListItem Value="2">团购</asp:ListItem>
            </asp:DropDownList>
            </td>
        </tr>
        <tr>
    <th>每页条数：</th>
    <td>
        <asp:TextBox ID="txtPageSize" runat="server" CssClass="" Columns="2" Text="20" MaxLength="3"></asp:TextBox> 条(1~100)
        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtPageSize"
            ErrorMessage="介于1～100之间" MaximumValue="100" MinimumValue="1" Type="Integer"></asp:RangeValidator>
        </td>
    <th></th>
    <td>
     <asp:CheckBox runat="server" ID="cbdays" Checked="true" /> 返回最近&nbsp;<asp:TextBox runat="server" CssClass="" ID="txtdays" Columns="2" Text="2" ></asp:TextBox>&nbsp;天的全部数据 
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtdays"
            ErrorMessage="必须为数字" ValidationExpression="^[1-9]\d*$"></asp:RegularExpressionValidator></td> 
</tr>
        <tr>
            <td></td>
            <td colspan="3">
            <asp:Button ID="btnFind" runat="server" CssClass="button" Text="查询" OnClick="btnFind_Click"  />
            <input type="reset" value="重置" class ="button" />
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
<asp:TemplateField HeaderText="选择" >
<ItemTemplate>
<asp:CheckBox ID="chkExport" runat="server" />
</ItemTemplate>
    <ItemStyle Width="4%" />
</asp:TemplateField>
<asp:BoundField DataField="Title" HeaderText="标题" >
    <HeaderStyle CssClass="gvLeft" />
    <ItemStyle CssClass="gvLeft" Width="32%" />
</asp:BoundField>
<asp:BoundField DataField="Name" HeaderText="姓名" >
    <HeaderStyle CssClass="gvLeft" />
    <ItemStyle CssClass="gvLeft" Width="15%" />
</asp:BoundField>
 <asp:TemplateField HeaderText="类型">
    <ItemStyle Width="10%" />
        <ItemTemplate>
            <asp:Literal runat="server" ID="ltInfoFlag" Text='<%# GetInfoFlag(Eval("FeedbackID").ToString())%>'></asp:Literal>
        </ItemTemplate>
 </asp:TemplateField>
<%--<asp:ButtonField CommandName="type" HeaderText="类型" DataTextField="Type" ><ItemStyle CssClass="action" Width="10%" /></asp:ButtonField>--%>
<asp:BoundField DataField="Email" HeaderText="E-mail" >
    <HeaderStyle CssClass="gvLeft" />
    <ItemStyle CssClass="gvLeft" Width="15%" />
</asp:BoundField>
    <asp:TemplateField HeaderText="发布日期">
        <ItemTemplate>
            <asp:Label ID="Label1" runat="server" Text='<%# Convert.ToDateTime(Eval("addtime")).ToString("yyyy-MM-dd") %>'></asp:Label>
        </ItemTemplate>
        <ItemStyle Width="12%" />
    </asp:TemplateField>

  <asp:TemplateField HeaderText="查看">
    <ItemStyle Width="5%" />
        <ItemTemplate>
            <a href='LookFeedback.aspx?FeedbackID=<%# Eval("FeedbackID") %>&backURL=<%# backURL %>'><img src="../images/look.GIF" alt="查看" /></a>
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
<input id="chkAll" onclick="chkAll_true()" type="checkbox" name="chkAll" runat="server" />全选
<asp:Button ID="lnkDel" runat="server" CssClass="button" Text="删除" OnClick="lnkDel_Click"  /></td>
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

