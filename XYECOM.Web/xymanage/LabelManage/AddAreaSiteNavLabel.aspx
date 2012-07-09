<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddAreaSiteNavLabel.aspx.cs" Inherits="XYECOM.Web.xymanage.LabelManage.AddAreaSiteNavLabelaspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>新增地方站导航标签</title>
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script type="text/javascript" src="../javascript/CheckedAll.js" ></script>
</head>
<body>
<form id="form1" runat="server">
<h1><a href="../index.aspx">后台管理首页</a> >> 新增地方站导航标签</h1>
<table width="100%" >
<tr>
<td class="right">    

<div class="main-setting">
<div class="itemtitle"><h3 id="title" runat="server">新增地方站导航标签</h3>
</div>
<table class="xy_tb xy_tb2 ">


<tr class="nobg">
  <td colspan="2" class="td27">标签名称：</td>
</tr>
<tr>
   <td class="vtop rowform" style="font-weight:bold; width:500px; height: 48px;">
     {XY_ASN_<asp:TextBox ID="txtName" Columns="30" runat="server" CssClass="input" MaxLength="50"></asp:TextBox>}
       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
           ErrorMessage="标签名称不能为空"></asp:RequiredFieldValidator></td>
   <td class="vtop tips2" style="height: 48px"><span></span></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">中文名称：</td>
</tr>
<tr>
   <td class="vtop rowform" style=" width:500px;">
    
        <asp:TextBox ID="txtCNName" runat="server" CssClass="input"  Columns="44" MaxLength="50"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCNName"
           ErrorMessage="中文名称不能为空"></asp:RequiredFieldValidator><br /><br />
   </td>
   <td class="vtop tips2">对标签的简单描述</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">地方站列表：</td>
</tr>
<tr>
   <td class="vtop rowform">
    
       <asp:CheckBoxList ID="chklstAreaSite" runat="server" RepeatColumns="4" RepeatLayout="Table">
       </asp:CheckBoxList><br/>
       <asp:CustomValidator   ID="CustomValidator1"   runat="server"   ErrorMessage="请至少选择一项" ClientValidationFunction="ClientValidate" Width="300"> </asp:CustomValidator > 

   </td>
   <td class="vtop tips2">至少选择一个站点</td>
</tr>


<tr>
<td style="height: 30px" colspan="2">
    <asp:button id="btnOK" runat="server" CssClass="button" Text="保存" OnClick="btnOK_Click"></asp:button>&nbsp;
    <input id="Button1" class="button" type="button" value="返回" onclick="location.href='ClassLabelList.aspx';" />
</td>
</tr>
</table>
</div>
</td>
</tr>
</table>
</form>

<script  language="javascript" type="text/javascript">   
function     ClientValidate(sender,   args) 
{ 
        var   flag   =   false; 
        var   inarr=form1.all.tags("input"); 
              
        for(var i=0; i < inarr.length;i++) 
        { 
                if(inarr[i].type=="checkbox") 
                  { 
                        if(inarr[i].checked==true)         
                          { 
                                  flag   =   true; 
                          } 
                    } 
          } 
          if   (flag) 
          { 
                args.IsValid   =   true; 
          } 
          else 
          { 
                args.IsValid   =   false; 
          } 
} 
</script >
</body>
</html>

