<%@ Import Namespace="System.Data" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VoteResult.aspx.cs" Inherits="XYECOM.Web.xymanage.VoteManage.VoteResult" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>调查结果分析</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
</head>
<body>

    <form id="form1" runat="server">
    <h1><a href="../index.aspx">后台管理首页</a> >> 调查结果分析</h1>
<table width="100%">
 <tr>
 <td>
<div class="main-setting">
<div class="itemtitle"><h3>调查结果分析</h3>
<ul id="mainMenus0" runat="server" class="tab1">
<li>【 主题：<asp:Label ID="lblVoteTitle" runat="server"></asp:Label>】</li>
</ul>
</div>
<table class="xy_tb xy_tb2 ">

<%  
    foreach (DataRow row in subject.Rows)
    {
        %>
        <tr class="nobg">
            <td width="6%">
            [<font color="#ff6600">
            <%
            if (row["type"].ToString().Equals("text") || row["type"].ToString().Equals("mtext"))
                 Response.Write("文本");
             else
                 Response.Write("选项");
            %>
            </font>]
            </td>
            <td><b style="color:#436b87"><%=row["Subject"].ToString()%></b></td>
        </tr>
        <tr>
            <td></td>
         <td >
         <%
             if (row["type"].ToString().Equals("text") || row["type"].ToString().Equals("mtext"))
             {
                 System.Data.DataTable texts = GetTexts(row["subjectId"].ToString());
                 
                 Response.Write("<table width='100%' border='0' style='background-color:#f8f8f8'>");

                 foreach (DataRow text in texts.Rows)
                 {
                 %>
                 <tr>
                    <td>&nbsp;<%=text["body"].ToString()%></td>
                 </tr>
                 <%
                 }
                 Response.Write("<tr><td align='right'><a href='MoreText.aspx?subjectId=" + row["subjectId"].ToString() + "' target='_blank'>更多>></a>&nbsp;</td></tr>");
                 Response.Write("</table>");
             }
             else
             {
                 int vaoteTotalNumber = 0;

                 System.Data.DataTable options = GetOptions(row["subjectId"].ToString(), out vaoteTotalNumber);

                 Response.Write("<table width='100%' border='0' style='background-color:#f8f8f8'>");
                 foreach (DataRow option in options.Rows)
                 {
                     float divWidth = XYECOM.Core.MyConvert.GetInt32(option["voteTotal"].ToString());

                     if (divWidth == 0)
                         divWidth = 1;
                     else
                         divWidth = XYECOM.Core.MyConvert.GetFloat(option["percent"].ToString());
                 %>
                    <tr>
                        <td width="40%">
                        &nbsp;<%=option["text"].ToString()%>(<%=option["voteTotal"].ToString()%>/<%=vaoteTotalNumber%>)
                        </td>
                        <td width="60%">
                        <div style="background-color:#009f00; float:left; height:13px; width:<%=divWidth%>%">&nbsp;</div>&nbsp;<%=option["percent"].ToString()%>%
                        </td>
                    </tr>
                 <%
             }
                 Response.Write("</table>");
             }      
         %>
            </td>
        </tr> 
        <%
    }
 %>



     

 <tr>
   <td colspan="2">
   <input type="button" value="返回" onclick="location.href='<%=backURL%>';" class="button"/>
   </td>
   </tr>
 </table>
 <asp:Label runat="server" ID="lbmessage" CssClass="input" ForeColor="red"></asp:Label>

 </div>
 

 </td>
 </tr>
 </table>

   


    </form>
</body>
</html>
