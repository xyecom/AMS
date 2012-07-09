<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LookFeedback.aspx.cs" Inherits="XYECOM.Web.xymanage.MessageManage.LookFeedback" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>意见反馈信息</title>
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script language="javascript" type="text/javascript" src="/common/js/date.js"></script>
<script language ="javascript" type ="text/javascript" src ="../javascript/CheckedAll.js"></script>
<script language="javascript" type="text/javascript">
function GetTable(num)
{
   if(num == "1")
   {
      document.getElementById("InfoShow").style.display = 'block';
      document.getElementById("auditing").style.display = 'none';
   }
   if(num == "2")
   {
      document.getElementById("InfoShow").style.display = 'none';
      document.getElementById("auditing").style.display = 'block';         
   }
}
</script>
</head>
<body onload="GetTable(1);">

<form id="form1" runat="server">
<h1><a href="../index.aspx">后台管理首页</a> >> 意见反馈信息</h1>
<table width="100%" >

<td class="right">
<!--后台导航 -->



<div class="main-setting">
<div class="itemtitle"><h3>意见反馈信息</h3></div>
<table width="100%" class="xy_tb xy_tb2 infotable" id="InfoShow">
<tr>
<th>
    主题：</th>
<td>
    <asp:Label ID="lb_Title" runat="server" Width="200px"></asp:Label></td>
    <th>
        类型：</th>
    <td>
        <asp:Label ID="lb_Type" runat="server" Width="200px"></asp:Label></td>
</tr>
<tr>
<th>
    姓名：</th>
    <td id="classType">
        <asp:Label ID="lb_Name" runat="server" Width="200px"></asp:Label></td>
    <th>
        电话：</th>
    <td style="height: 17px">
        <asp:Label ID="lb_Telephone" runat="server" Width="200px"></asp:Label></td>
</tr>
<tr>
    <th>
     E-Mail：</th>
    <td>
    <asp:Label ID="lb_Email" runat="server" Width="200px"></asp:Label></td>
    <th>
     发送方式：</th>
    <td>
        <asp:CheckBoxList ID="cbMessage" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Selected="True">站内信</asp:ListItem>
        <asp:ListItem >站外邮件</asp:ListItem>
        </asp:CheckBoxList>
        
    </td>
</tr>
    <tr>
        <th>
        内容：</th>
        <td>
            <asp:Label ID="lb_content" runat="server"></asp:Label></td>
          <th>
        是否认同此投诉：</th>
        <td>
            <asp:RadioButton ID="rbIsAgreeYes" runat="server" GroupName="IsAgree" Checked="true" Text="是" />
            <asp:RadioButton ID="rbIsAgreeNo" runat="server" GroupName="IsAgree" Text="否" />
            </td>
    </tr>
    <tr style="display:block">
        <th>
            <asp:Label ID="lb_huifuEmail" runat="server">回复邮件：</asp:Label></th>
        <td colspan="3">
            
            <asp:Panel ID="Panelhuifu" runat="server" Visible="false">
            <table class="send_msg_body" width="100%">
                <tr>
                    <td style="width: 53px" valign="top">
                        标题：</td>
                    <td>
                        <asp:TextBox ID="txt_Title" runat="server" Width="190px"></asp:TextBox></td>
                </tr>
                <tr> 
                    <td style="width: 53px" valign="top">
                        内容：</td>
                    <td>
                        <asp:TextBox ID="txt_content" rows="8" cols="60" runat="server" Height="150px" TextMode="MultiLine" Width="342px"></asp:TextBox></td>
                </tr>
            </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <th>
        </th>
        <td colspan="3">
            <asp:Button ID="btnSendMail" runat="server" CssClass="button" OnClick="btnSendMail_Click"
                Text="发送邮件" />
            <asp:Button ID="brnBack" runat="server" CssClass="button" OnClick="brnBack_Click"
                Text="返回" /></td>
                <asp:HiddenField runat="server" ID="hiUserId" />
                <asp:HiddenField runat="server" ID="hiDefendantId" />
                <asp:HiddenField runat="server" ID="hiFeedBackId" />
    </tr>
    </table>
    
    </div>

    </form>
</body>
</html>
