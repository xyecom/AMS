<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReceiveMessageInfo.ascx.cs"
    Inherits="XYECOM.Web.Other.UserContorl.ReceiveMessageInfo" %>
<link href="../css/main.css" rel="stylesheet" type="text/css" />
<div id="right">
<div id="rightzqlist">
<h2>消息详情</h2>
<div class="rhr"></div>
<div class="divmsg">
<asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
<table>
<tr><td> <p><strong>消息来源</strong></p></td></tr>
<tr>
<td  runat="server" id="sender"></td>
</tr>
<tr>
<td><p><strong>消息标题</strong></p> </td>
</tr>
<tr>
 <td runat="server" id="subject"></td>
</tr>
<tr><td> <p><strong>消息内容</strong></p></td></tr>
<tr>     <td runat="server" id="content"></td></tr>
<tr><td> <p><strong>消息发送时间</strong></p></td></tr>
<tr><td  runat="server" id="addtime"> </td></tr>
</table>
  </asp:View>
        <asp:View ID="View2" runat="server">
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        </asp:View>
 </asp:MultiView>
<div style="width:766px; height:30px; text-align:center">
   <input  type="button" value="删 除"  style="background:url(../Other/images/yes.gif); width:80px; height:25px;border:none; cursor:pointer;color:#FFF"/>&nbsp;&nbsp;
      <input type="button" id="Button1" onclick="javascript:history.back()" value="返 回" style="background:url(../Other/images/yes.gif); width:80px; height:25px;border:none; cursor:pointer;color:#FFF"/>
</div>
</div>
</div>
</div>