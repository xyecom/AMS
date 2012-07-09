<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassLabelPreview.aspx.cs" Inherits="XYECOM.Web.xymanage.LabelManage.ClassLabelPreview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>分类信息标签预览</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
</head>
<body>
     <form id="form1" runat="server">
    <div class="Top_nav">
        <div class="Top_nav_left">
        <a href="../index.aspx">后台管理首页</a> &gt;&gt; 分类信息标签预览</div>
        <div class="Top_nav_right">
            <asp:Button ID="btnBack" runat="server" Text=" 返回 "  CssClass="button" OnClick="btnBack_Click"/>
        </div>
    </div>

    <table width="100%"  class="content">
        <tr>
            <td style="width:50%;vertical-align:top; padding:15px; border-right:dotted 1px #dddddd;" align=left>
                <label id="lblBody" runat="server"></label>
            </td>
            <td  style="width:50%; vertical-align:top;padding:15px" align=left>
         
                分类列表格式为(一块为单位)：<br/>
<pre>
&lt;dl&gt;
    &lt;dt&gt;&lt;h4&gt;大类名称&lt;/h4&gt;&lt;/dt&gt;
    &lt;dd&gt;
        &lt;ul&gt;
            &lt;a href="#"&gt;二级类名称&lt;/a&gt;
            &lt;span&gt;
                &lt;a href="#"&gt;三级类名称&lt;/a&gt;
                .....
            &lt;/span&gt;
            .....
        &lt;/ul&gt;
    &lt;/dd&gt;
&lt;/dl&gt;
</pre><br/>
     可根据需要调整CSS来控制其显示效果及样式。
            </td>
        </tr>
        <tr>
            <td align="left" style="border-right: #dddddd 1px dotted; padding-right: 15px; padding-left: 15px;
                padding-bottom: 15px; vertical-align: top; width: 50%; padding-top: 15px">
            </td>
            <td align="left" style="padding-right: 15px; padding-left: 15px; padding-bottom: 15px;
                vertical-align: top; width: 50%; padding-top: 15px">
            </td>
        </tr>
    </table>
<p style="text-align:center;"><asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></p>
    </form>
</body>
</html>
