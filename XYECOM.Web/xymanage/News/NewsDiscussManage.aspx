<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsDiscussManage.aspx.cs" Inherits="XYECOM.Web.xymanage.News.NewsDiscussManage" %>

<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc2" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>资讯评论列表</title>
    <link href="../css/style.css" type="text/css" rel="Stylesheet" />
    <link href="/common/css/XYLib.css" type="text/css" rel="Stylesheet" />
    <script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
    <script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
    <script type="text/javascript" src="/common/js/date.js" ></script>
</head>
<body>
<form id="NewsDiscussList" runat="server">
<h1><a href="../index.aspx">后台首页</a> >> 资讯评论列表</h1>
<table width="100%">
<tr>
<td class="right">

<div class="main-setting">
<div class="itemtitle"><h3 id="caption" runat="server">资讯评论列表</h3></div>

<table class="xy_tb xy_tb2">

<tr>
<td>
<table class="partition">
<tr>
    <th>内容关键字：</th>
    <td><asp:TextBox ID="txtkeyword" runat="server" CssClass="txt"></asp:TextBox></td>
    <th>用户昵称：</th>
    <td><asp:TextBox ID="txtauthor" runat="server" CssClass="txt"></asp:TextBox></td>
</tr>
<tr>
    <th>是否显示：</th>
    <td>
    
       <asp:RadioButton ID="cbIsFlag" runat="server" Text=" 显示"  GroupName="rbt" />&nbsp;
       <asp:RadioButton  ID="cbIsDiscuss" runat="server" Text=" 不显示" GroupName="rbt" />&nbsp;
    </td>
    <th>评论日期：</th>
    <td>
    <input id="bgdate" type="text" runat="server" onclick="getDateString(this);" readonly="readonly" maxlength="10" style="width:80px;" />
     到
    <input id="egdate" type="text" runat="server" onclick="getDateString(this);" readonly="readonly" maxlength="10" style="width: 80px;" />
    </td> 
</tr>


<tr>
<td></td>
<td>
<asp:Button ID="btnFind" runat="server" CssClass="button" Text="搜索" OnClick="btnFind_Click" />
<input type="reset" value="重置" class ="button" />
</td>
<td></td>
<td></td>
</tr>
</table>
</td>
</tr>


  <tr>
   <td>
   <asp:GridView ID="gvlist" HeaderStyle-CssClass="gv_header_style" Width="100%" runat="server" AutoGenerateColumns="False" DataKeyNames="ND_ID,NS_ID" GridLines="None" OnRowDataBound="gvlist_RowDataBound" OnRowCommand="gvlist_RowCommand">
   <Columns>
   <asp:BoundField Visible="False" DataField="ND_ID" />
   <asp:TemplateField HeaderText="选择">
   <ItemTemplate>
   <asp:CheckBox ID="chkExport" runat="server" />
   </ItemTemplate>
       <ItemStyle Width="5%" />
   </asp:TemplateField>
   <asp:BoundField HeaderText="用户编号" DataField="U_ID" Visible="False" />
   <asp:BoundField HeaderText="用户昵称" DataField="U_Name" >
       <ItemStyle Width="10%" CssClass="gvLeft" />
       <HeaderStyle CssClass="gvLeft" />
   </asp:BoundField>
   <asp:BoundField HeaderText="评论内容" DataField="ND_Content" >
       <ItemStyle Width="45%" CssClass="gvLeft" />
       <HeaderStyle CssClass="gvLeft" />
   </asp:BoundField>
   <asp:BoundField HeaderText="评论时间" DataField="ND_AddTime" DataFormatString="{0:yyyy-MM-dd}">
       <ItemStyle Width="15%" />
   </asp:BoundField>
   <asp:ButtonField HeaderText="是否显示" DataTextField="ND_IsShow" CommandName="SetIsShow">
       <ItemStyle Width="10%" />
   </asp:ButtonField>
   <asp:BoundField DataField="NS_ID" Visible="False" HeaderText="资讯编号" />
      <asp:TemplateField HeaderText="查看">
    <ItemStyle Width="5%" />
        <ItemTemplate>
            <a href='NewsDiscussInfo.aspx?ND_ID=<%# Eval("ND_ID") %>&NS_ID=<%# Eval("NS_ID") %>&backURL=<%# backURL %>'><img src="../images/look.GIF" alt="编辑" /></a>
        </ItemTemplate>
    </asp:TemplateField>
   
   
       <asp:TemplateField HeaderText="所属资讯">
        <ItemStyle Width="10%" />
            <ItemTemplate>
                <a href="<%#GetHref(DataBinder.Eval(Container,"DataItem.NS_ID").ToString()) %>" target="_blank">查看</a>
            </ItemTemplate>
        </asp:TemplateField>

   </Columns>
   </asp:GridView>
   <p style="text-align:center;"><asp:Label ID="lblMessage" runat="server" ForeColor="red"></asp:Label></p>
   </td>
  </tr>
  <tr>
  <td class="content_action">
  <input id="chkAll" onclick="chkAll_true()" type="checkbox" name="chkAll" runat="server" />全选
  <asp:Button ID="lnkDel" runat="server" CssClass="button" Text="删除" OnClick="lnkDel_Click" />
  </td>
  </tr>
  </table>
  <uc2:page ID="Page1" runat="server" />
</div>
</td>
 </tr>
</table>
</form>
</body>
</html>
