<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_UserManage_UserMoreInfo" Codebehind="UserMoreInfo.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>企业会员详细页面</title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<link href="/common/css/XYLib.css" type="text/css" rel="Stylesheet" />
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<script language ="javascript" type="text/javascript"  src="/common/js/base.js"></script>
<script language ="javascript" type="text/javascript"  src="/config/js/config.js"></script>
<script type="text/javascript" src="/common/js/date.js" ></script>
</head>
<body>
<form id="form1" runat="server">
<h1><a href="../index.aspx">后台管理首页</a> >> 企业会员详细信息</h1>
<table width="100%">
<tr>
<td class="right">


<div class="main-setting">

<div class="itemtitle"><h3>会员注册资料</h3></div>

<table width="100%" class="xy_tb xy_tb2 infotable border_buttom0">
<tr>
 <th>用户名:</th>
 <td>
     <asp:TextBox ID="tdusername" runat="server" Width="250px" ReadOnly="True"></asp:TextBox></td>
</tr>
    <tr>
        <th>
            提示问题:</th>
        <td>
            <asp:TextBox ID="txtQuestion" runat="server" Width="250px"></asp:TextBox></td>
    </tr>
    <tr>
            <th>
            提示答案:</th>
        <td>
            <asp:TextBox ID="txtAnswer" runat="server" Width="250px"></asp:TextBox></td>
    </tr>
<tr>
 <th>性   别:</th>
 <td>
     <asp:RadioButtonList ID="tdsex" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
         <asp:ListItem Value="1">男</asp:ListItem>
         <asp:ListItem Value="0">女</asp:ListItem>
     </asp:RadioButtonList></td>
 </td>
</tr>
<tr>
 <th>电子邮件:</th>
 <td><asp:TextBox ID="tdemail" runat="server" Width="250px"></asp:TextBox></td>

</tr>
<tr>
 <th>注册时间:</th>
 <td><input id="bgdate" type="text" runat="server" onclick="getDateString(this);" maxlength="10" style="width:80px;" readonly="readonly"/>
</tr>

</table>

<br/>
<div class="itemtitle"><h3>企业基本资料</h3></div>
<table width="100%" class="xy_tb xy_tb2 infotable border_buttom0">
<tr>
<th>企业名称:</th>
<td><asp:TextBox ID="companyname" runat="server" Width="250px"></asp:TextBox></td>
</tr>
<tr>
 <th>所在区域:</th>
 <td>
<div id="classType"></div>
<input type ="hidden" id="areatypeid" runat="server" />
<script type="text/javascript">
var cla = new ClassType("cla",'area','classType','areatypeid');
cla.Mode ="select";
cla.Init();
</script>
 </td>
</tr>
<tr>
 <th>联系人:</th>
 <td><asp:TextBox ID="tdrealname" runat="server" Width="250px"></asp:TextBox></td>
 </tr>
<tr>
  <th>固定电话:</th>
 <td><asp:TextBox ID="txtTelephone" runat="server" Width="300px"></asp:TextBox></td>
</tr>
<tr>
  <th>传真号码:</th>
 <td><asp:TextBox ID="txtFax" runat="server" MaxLength="20" Width="300px"></asp:TextBox></td>
</tr>
<tr>
 <th>手机号码:</th>
 <td><asp:TextBox ID="tdmobil" runat="server" Width="250px"></asp:TextBox></td>
</tr>
<tr>
<th>所在部门:</th>
<td><asp:TextBox ID="tdsection" runat="server" Width="250px"></asp:TextBox></td>
</tr>

<tr>
<th>所属职位:</th>
<td><asp:TextBox ID="tdpost" runat="server" Width="250px"></asp:TextBox></td>
</tr>

<tr>
  <th>邮政编码:</th>
 <td><asp:TextBox ID="tdpostcode" runat="server" Width="250px"></asp:TextBox></td>
</tr>
    <tr>
        <th id="tdIM" runat="server"></th>
            
        <td>
            <asp:TextBox ID="txtIM" runat="server" Width="250px"></asp:TextBox></td>
    </tr>
<tr>
 <th>企业网址:</th>
 <td><asp:TextBox ID="tdhomepage" runat="server" Width="250px"></asp:TextBox></td>
</tr>
<tr> 
 <th>联系地址:</th>
 <td><asp:TextBox ID="tdlinkadress" runat="server" Width="250px"></asp:TextBox></td>
</tr>
<tr>
<th>企业性质:</th>
<td>
    <asp:RadioButtonList ID="tdcharacter" runat="server" RepeatDirection="Horizontal"
        RepeatLayout="Flow">
        <asp:ListItem>企业单位</asp:ListItem>
        <asp:ListItem>个体经营</asp:ListItem>
        <asp:ListItem>事业单位或社会团体</asp:ListItem>
    </asp:RadioButtonList></td>
</tr>
<tr>
<th>企业类别:</th>
<td>
<div id="classTypecompany"></div>
<input type ="hidden" id="companyid" runat="server"/>
<script type="text/javascript">
var clacompany = new ClassType("clacompany",'company','classTypecompany','companyid');
clacompany.Mode ="select";
clacompany.Init();
</script>
</td>
</tr>
<tr>
<th>供应产品/服务:</th>
<td><asp:TextBox ID="tdsupply" runat="server" TextMode="MultiLine" Rows="3" Columns="80"></asp:TextBox></td>
</tr>
<tr>
<th>需求产品/服务:</th>
<td><asp:TextBox ID="tdbuy" runat="server" TextMode="MultiLine" Rows="3" Columns="80"></asp:TextBox></td>
</tr>
</table>

<br/>
<div class="itemtitle"><h3>企业高级资料</h3></div>
<table width="100%" class="xy_tb xy_tb2 infotable border_buttom0">
<tr>
<th>注册资金:</th>
<td><asp:TextBox ID="tdmoney" runat="server" Width="250px"></asp:TextBox></td>
</tr>
<tr>
<th>注册资金类别:</th>
<td><asp:TextBox ID="tdmoneytype" runat="server" Width="250px" ReadOnly="True"></asp:TextBox></td>
</tr>
<tr>
<th>企业经营模式:</th>
<td>
    <asp:CheckBoxList ID="tdumode" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
    </asp:CheckBoxList></td>
</tr>
<tr>
<th>企业成立年份：</th>
<td><asp:TextBox ID="lbyear" runat="server" Width="250px"></asp:TextBox></td>
</tr>
<tr>
<th>企业注册地：</th>
<td>
<div id="divaddress"></div>

<input type ="hidden" id="lbaddress" runat="server" />
<script type="text/javascript">
var cla3 = new ClassType("cla3",'area','divaddress','lbaddress');
cla3.Mode ="select";
cla3.Init();
</script>
</td>
</tr>
<tr>
<th>主要经营地点：</th>
<td><asp:TextBox ID="lbarea" runat="server" Width="250px"></asp:TextBox></td>
</tr>
<tr>
<th>企业人数：</th>
<td><asp:TextBox ID="lbnumber" runat="server" Width="250px"></asp:TextBox></td>
</tr>
<tr>
<th>企业简介：</th>
<td><asp:TextBox ID="tdsynopsis" runat="server" Width="500px" TextMode ="MultiLine" Rows="8"></asp:TextBox></td>
</tr>
<tr>
<th></th>
<td class="content_action" colspan="3"> &nbsp;<asp:Button ID="btnOk" runat="server" CssClass="button" OnClick="btnOk_Click"
        Text="确认修改" />
    <input id="btcancel" type="button" value="返回" class="button" runat="server" /></td>
</tr>
</table>

</div>

</td>
</tr>
</table>

</form>
</body>
</html>
