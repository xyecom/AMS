<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_basic_ReceiveEmail" Codebehind="ReceiveEmail.aspx.cs" %>

<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>收到邮件管理</title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script language ="javascript" type ="text/javascript"  src ="../javascript/CheckedAll.js"></script>
<script language="javascript" type="text/javascript" src="/common/js/date.js"></script>
</head>
<body>
<form id="Form1" method="post" runat="server">
<h1><a href="../index.aspx">后台管理首页</a> >> 收到留言管理</h1>
<table  width="100%" >
<tr>
<td class="right">

<div class="main-setting">
<div class="itemtitle"><h3>站内短信</h3>
    <ul class="tab1" id="mainMenus0">
            <li class="current"><a href="#"><span>收件箱</span></a></li>
            <li><a href="SendMessageList.aspx"><span>发件箱</span></a></li>
            <li><a href="SendMessageAdd.aspx"><span>发送信息</span></a></li>
        </ul>
</div>

<table class="xy_tb xy_tb2">
    <tr>
        <td>
            <table class="partition" width="100%">
                <tr>
                    <th>
                        &nbsp;类型：</th>
                    <td id="Td1">
                        <asp:RadioButtonList ID="ddlType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Selected="True" Value="0">所有</asp:ListItem>
                            <asp:ListItem Value="1">求助</asp:ListItem>
                            <asp:ListItem Value="2">建议</asp:ListItem>
                            <asp:ListItem Value="3">投诉</asp:ListItem>
                            <asp:ListItem Value="4">表扬</asp:ListItem>
                            <asp:ListItem Value="5">业务联系</asp:ListItem>
                            <asp:ListItem Value="6">升级会员</asp:ListItem>
                        </asp:RadioButtonList></td>
                    <th>
                    </th>
                    <td>
                    </td>
                </tr>
                <tr>
                    <th> 标题：</th>
                    <td>
                        <asp:TextBox ID="txtTitle" runat="server" CssClass="input_s" MaxLength="30" Width="150px"></asp:TextBox>
                    </td>
                    <th>状态：</th>
                    <td>
                        <asp:RadioButtonList ID="ddlshifouchakan" runat="server" RepeatDirection="Horizontal"
                            RepeatLayout="Flow">
                            <asp:ListItem Selected="True" Value="">所有</asp:ListItem>
                            <asp:ListItem Value="1">已查看</asp:ListItem>
                            <asp:ListItem Value="0">未查看</asp:ListItem>
                        </asp:RadioButtonList>
                     </td>
                       
                </tr>
                <tr>
                    <th>
                        开始日期：</th>
                    <td>
                        <asp:TextBox ID="txtBeginDate" runat="server" CssClass="input_s" MaxLength="30" onclick="getDateString(this);"
                            Width="150px" ReadOnly="true"></asp:TextBox></td>
                    <th>用户名：</th>
                    <td><asp:TextBox id="U_Name" runat="server" Width="150px" CssClass="input_s" MaxLength="30"></asp:TextBox></td>
                </tr>
                <tr>
                    <th>
                        结束日期：</th>
                    <td>
                        <asp:TextBox ID="txtEndDate" runat="server" CssClass="input_s" MaxLength="30" onclick="getDateString(this);"
                            Width="150px" ReadOnly="true"></asp:TextBox></td>
                    <th>
                        每页条数：</th>
                    <td>
                        <asp:TextBox ID="txtPageSize" runat="server" Columns="2" CssClass="" MaxLength="3"
                            Text="20"></asp:TextBox>
                        条(1~100)
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtPageSize"
                            ErrorMessage="介于1～100之间" MaximumValue="100" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <th>
                    </th>
                    <td>
                        <asp:CheckBox ID="cbdays" runat="server" Checked="true" />
                        返回最近
                        <asp:TextBox ID="txtdays" runat="server" Columns="2" CssClass="" Text="2"></asp:TextBox>
                        天的全部数据
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtdays"
                            ErrorMessage="必须为数字" ValidationExpression="^[1-9]\d*$"></asp:RegularExpressionValidator></td><th>
                            </th>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td colspan="3">
                        <asp:Button ID="btn_select" runat="server" CssClass="button" OnClick="btn_select_Click"
                            Text="查询" />
                        <input class="button" type="reset" value="重置" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>

<tr>
<td>
<asp:GridView HeaderStyle-CssClass="gv_header_style" ID="gvlist" runat="server" AutoGenerateColumns="False"  DataKeyNames="M_ID"  Width="100%"  PageSize="20" GridLines="None"  OnRowDataBound="gvlist_RowDataBound"   >
<Columns>
    <asp:BoundField DataField="M_ID" HeaderText="M_ID" Visible="False" />

<asp:TemplateField HeaderText="选择">                
<ItemTemplate>
<asp:CheckBox ID="chkExport" runat="server" />
</ItemTemplate>
    <ItemStyle Width="5%" />
</asp:TemplateField>
    <asp:BoundField DataField="M_Title" HeaderText="标题" >
        <HeaderStyle CssClass="gvLeft" />
        <ItemStyle Width="25%" CssClass="gvLeft" />
    </asp:BoundField>
    <asp:TemplateField HeaderText="用户名">
        <ItemStyle CssClass="gvLeft" Width="12%" />
        <HeaderStyle CssClass="gvLeft" />
        <ItemTemplate>
            <a href='../UserManage/<%# Eval("M_UserType").ToString().ToLower() == "true" ? "UserInfo.aspx?U_ID=" + Eval("U_ID") : "IndividualInfo.aspx?U_ID=" + Eval("U_ID") %>&backURL=../MessageManage/<%#backURL %>'><%# Eval("U_Name")%></a>
             
        </ItemTemplate>
    </asp:TemplateField>
      <asp:BoundField DataField="M_PHMa" HeaderText="联系电话" Visible="False"   >
          <HeaderStyle CssClass="gvLeft" />
          <ItemStyle  CssClass="gvLeft" />
      </asp:BoundField>
       <asp:BoundField DataField="UI_Mobil" HeaderText="手机"  Visible="False">
       </asp:BoundField>
     <asp:BoundField DataField="U_Email" HeaderText="Email" >
          <HeaderStyle CssClass="gvLeft" />
         <ItemStyle Width="20%"  CssClass="gvLeft" />
     </asp:BoundField>
    <asp:TemplateField HeaderText="留言日期">
        <ItemTemplate>
            <asp:Label ID="Label1" runat="server" Text='<%# Convert.ToDateTime(Eval("M_addtime")).ToString("yyyy-MM-dd") %>'></asp:Label>
        </ItemTemplate>
        <ItemStyle Width="12%" />
    </asp:TemplateField>
    <asp:BoundField DataField="M_HasReply" HeaderText="状态" >
        <ItemStyle Width="10%" />
    </asp:BoundField>
    <asp:TemplateField HeaderText="查看">
    <ItemStyle Width="5%" />
    <ItemTemplate>
        <a href='ReceiveEmaiinfo.aspx?M_ID=<%# Eval("M_ID") %>&backURL=<%# backURL %>'><img src="../images/look.GIF" alt="查看具体内容" /></a>
    </ItemTemplate>
</asp:TemplateField>
</Columns>
</asp:GridView>
<p style="text-align:center;"><asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label></p> 
</td>
</tr>
<tr>
<td class="content_action">
<input id="chkAll" onclick="chkAll_true()" type="checkbox" name="chkAll" runat="server" />全选
<asp:Button ID="lnkDel" runat="server" CssClass="button" Text="删除" OnClick="lnkDel_Click1" /></td>
</tr>
</table>
    <uc1:page ID="Page1" runat="server" />
</div>

 </tr>
</table>
</form>
</body>
</html>
