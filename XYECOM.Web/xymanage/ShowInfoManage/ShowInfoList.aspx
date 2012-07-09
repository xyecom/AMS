<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_ShowInfoManage_ShowInfoList" Codebehind="ShowInfoList.aspx.cs" %>

<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
 <title>展会信息列表</title>
 <link type="text/css" rel="stylesheet" href="../css/style.css" />
 <link href="/common/css/XYLib.css" type="text/css" rel="Stylesheet" />
 <script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script language="javascript" type="text/javascript" src="/common/js/date.js"></script>
 <script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
<script language ="javascript" type ="text/javascript" src ="../javascript/list.js"></script>
</head>
<body>
<form id="form1" method="post" runat="server">
<h1><a href="../index.aspx">后台管理首页</a> >> 展会信息管理</h1>
 <table width="100%">
  <tr>
  <td class="right">

<div class="main-setting">
<div class="itemtitle"><h3>展会信息管理</h3>
<asp:Button ID="btnadd" runat="server" Text="添加展会" CssClass="addbtn" OnClick="btnadd_Click"/>
</div>

<table class="xy_tb xy_tb2">
   <tr>
   <td>
    <table width="100%" class="partition">
        <tr>
            <th>标题：</th>
            <td><asp:textbox id="txtKeyword" runat="server" Width="150px" MaxLength="30" CssClass="input_s"></asp:textbox>
            </td>
            <th>
                <input type="hidden" id="hidTypeId"  name="hidTypeId" runat="server" />                
                展会类别：</th>
            <td id="classType">
                </td>
    <script type="text/javascript">
    var cla = new ClassType("cla",'exhibition','classType','hidTypeId');
    cla.Mode ="select";
    cla.Init();
    </script>
        </tr>
        <tr>
            <th>
                开始日期：</th>
            <td>
                <asp:TextBox ID="txtBeginDate" runat="server" CssClass="input_s" onclick="getDateString(this);" MaxLength="20" Width="100px" readonly="true"></asp:TextBox></td>
            <th>结束日期：
                </th>
            <td><asp:TextBox ID="txtEndDate" runat="server" CssClass="input_s" onclick="getDateString(this);" MaxLength="20" Width="100px" readonly="true"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <th>展会类型
                </th>
            <td>
                <asp:RadioButtonList  ID="rdolistShowType" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
                    RepeatLayout="Flow">
                    <asp:ListItem Value="所有"  Selected="True">所有</asp:ListItem>
                    <asp:ListItem Value="国内展">国内展</asp:ListItem>
                    <asp:ListItem Value="国外展">国外展</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <th>是否推荐：
            </th>
            <td>
            <asp:RadioButtonList ID="rblIsCommend" runat="server" RepeatDirection="Horizontal"
                    RepeatLayout="Flow">
                    <asp:ListItem Value="-1" Selected="True">所有</asp:ListItem>
                    <asp:ListItem Value="1">推荐</asp:ListItem>
                    <asp:ListItem Value="0">不推荐</asp:ListItem>
                </asp:RadioButtonList>
                </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="3">
            <asp:Button ID="btFind" runat="server" CssClass="button" Text="搜索" OnClick="btFind_Click" />
            <input type="reset" value="重置" class ="button" />
            </td>
        </tr>
    </table>

</td></tr>
   <tr>
    <td align="center" valign="middle">
     <asp:GridView ID="gvlist" HeaderStyle-CssClass="gv_header_style"  Width="100%"  runat="server" AutoGenerateColumns="False" DataKeyNames="id,Infotitle" GridLines="None" OnRowCommand="gvlist_RowCommand" OnRowDataBound="gvlist_RowDataBound">
     <Columns>
     <asp:BoundField Visible="False" DataField="id" />
     <asp:TemplateField HeaderText="选择"><ItemTemplate><asp:CheckBox ID="chkExport" runat="server" /></ItemTemplate>
         <ItemStyle Width="5%" />
     </asp:TemplateField>
<%--     <asp:BoundField HeaderText="标题" DataField="Infotitle" >
         <ItemStyle Width="35%" CssClass="gvLeft" />
         <HeaderStyle CssClass="gvLeft" />
     </asp:BoundField>--%>
     <asp:TemplateField HeaderText="标题">
                                            <ItemStyle CssClass="gvLeft" Width="25%" />
                                            <HeaderStyle CssClass="gvLeft" />
                                            <ItemTemplate>                                            
                                                <a href='<%# GetInfoUrl(Eval("HtmlPage").ToString(),Eval("id").ToString())%>' target="_blank">
                                                    <%# XYECOM.Core.Utils.IsLength(50, Eval("Infotitle").ToString())%>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField> 
     <asp:BoundField HeaderText="发布时间" DataField="addInfoTime" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="False" >
         <ItemStyle Width="10%" />
     </asp:BoundField>
     <asp:ButtonField DataTextField="IsCommend" HeaderText="推荐" CommandName="SetCommend" >
         <ItemStyle CssClass="action" Width="7%" />
     </asp:ButtonField>
     
    <asp:TemplateField HeaderText="查看/编辑">
    <ItemStyle Width="8%" />
        <ItemTemplate>
            <a href='ShowAdd.aspx?iswhich=1&infoid=<%# Eval("id") %>&backURL=<%# backURL %>'><img src="../images/look.GIF" alt="查看" /></a>
        </ItemTemplate>
    </asp:TemplateField>
             <asp:TemplateField HeaderText="静态页面">
    <ItemStyle CssClass="gvLeft" Width="10%" />
        <ItemTemplate>
            <%# Eval("HtmlPage").ToString() != "" ? "<a href=\"/" + Eval("HtmlPage").ToString() + "\" target=\"_black\">查看</a>" : "-"%>
        </ItemTemplate>
    </asp:TemplateField>
     </Columns>
     </asp:GridView>
     <a style="text-align:center"><asp:Label ID="lblMessage" runat="server" ForeColor="red"></asp:Label></a>
    </td>
   </tr>
   <tr>
   <td class="content_action">
    <input id="chkAll" onclick="chkAll_true();" type="checkbox" name="chkAll" runat="Server" />全选
    <asp:Button ID="lnkDel" runat="server" CssClass="button" Text="删除" OnClick="lnkDel_Click" />&nbsp;
       <asp:Button ID="btnCreateHtml" runat="server" CssClass="button" OnClick="btnCreateHtml_Click"
           Text="生成静态页面" />&nbsp;
       <asp:Button ID="btnDelHtml" runat="server" CssClass="button" OnClick="btnDelHtml_Click"
           Text="删除静态页面" /></td>
   </tr>          
 </table>
 <uc2:page ID="page1" runat="server" />
 </div>
 </td>
 </tr>
</table>  
</form>
</body>
</html>
