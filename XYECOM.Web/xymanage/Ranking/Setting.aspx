<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Setting.aspx.cs" Inherits="XYECOM.Web.xymanage.Ranking.Setting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>排名相关设置</title>
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <link type="text/css" rel="Stylesheet" href="../css/style.css" />
    <script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
    <script type="text/javascript" language="javascript" src="../javascript/WebSet.js"></script>
      
</head>
<body>

 <form id="form1" runat="server">
 <h1><a href="../index.aspx">后台管理首页</a> >>排名相关设置</h1>
 <table width="100%">
 <tr>
 <td class="right">

<div class="main-setting">
<div class="itemtitle">
<h3>排名管理</h3>
<ul id="mainMenus0" runat="server" class="tab1">
<li><a href="List.aspx"><span>排名管理 </span></a></li>
<li><a href="LogList.aspx"><span>日志管理 </span></a></li>
<li class="current"><a href="Setting.aspx"><span>相关设置</span></a></li>
</ul>
</div>

  <script type="text/javascript">
  function __xy_SetPriceText()
  {
    var total = document.getElementById("txtRankNumber").value;
    var txtTotal = parseInt(document.getElementById("Total").value);
    
    if(total =="" || isNaN(total))total = 3;
    
    if(total == txtTotal)return;
    
    var table = document.getElementById("tablePrice");

    var textHTML ="";
    
    if(total > txtTotal)
    {
        for(var i=1;i<=total;i++)
        {
            if(i<=txtTotal) continue;
                
            var newRow = table.insertRow();
            
            newRow.id = "rand_row_" + i;
            newRow.insertCell();
            newRow.insertCell();
            
            textHTML = "<input name='rank_"+i+"' type='text id='rank_"+i+"' size='5' maxlength='5' value='100' />";
                    
            newRow.cells[0].innerHTML = i+".";
            newRow.cells[1].innerHTML = textHTML;
        }
    }
    
    if(total < txtTotal)
    {
        for(var j=txtTotal;j>total;j--)
        {           
            table.deleteRow(j-1);
        }
    }
    
    document.getElementById("Total").value = total;
  }
  </script>
  
 <table width="100%" class="xy_tb xy_tb2">
<tr class="nobg">
  <td colspan="2" class="td27">排名服务交易货币：</td>
</tr>
<tr>
  <td class="vtop rowform">
    <asp:RadioButton ID="rdoVirtualMoney"  runat="server" CssClass="radio" GroupName="MoneyType" Text="虚拟货币"/>
    <asp:RadioButton ID="rdoCach" runat="server" CssClass="radio" GroupName="MoneyType" Text="现金货币" /></td>
  <td class="vtop tips2">关键词排名服务可以选择用虚拟货币或者现金货币作为最终支付货币</td>
</tr>

 <tr class="nobg">
  <td colspan="2" class="td27">排名个数：</td>
</tr>
<tr>
   <td class="vtop rowform" style="width: 300px; line-height:250%;">
                
        <input id="txtRankNumber" type="text" name="txtRankNumber" onblur="__xy_SetPriceText();" size="2" value="3" maxlength="2" runat="server"/>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRankNumber"
           ErrorMessage="排名个数不能为空！"></asp:RequiredFieldValidator>
   </td>
   <td class="vtop tips2">设置排名信息条数，默认为三条</td>
</tr>

 <tr class="nobg">
  <td colspan="2" class="td27">单次排名时间周期单位：</td>
</tr>
<tr>
   <td class="vtop rowform" style="width: 300px; line-height:250%;">
          <asp:DropDownList runat="server" ID="ddlTimeUnits" Width="40px">
            <asp:ListItem Text="天" Value="天"></asp:ListItem>
            <asp:ListItem Text="周" Value="周"></asp:ListItem>
            <asp:ListItem Text="月" Value="月" Selected="True"></asp:ListItem>
            <asp:ListItem Text="年" Value="年"></asp:ListItem>
          </asp:DropDownList>
   </td>
   <td class="vtop tips2">一次排名服务的时间周期单位</td>
</tr>

 <tr class="nobg">
  <td colspan="2" class="td27">
      默认排名价格：
  </td>
</tr>
<tr>
   <td class="vtop rowform" style="width: 300px; line-height:250%;">
   <asp:PlaceHolder ID="phMain" runat="server"></asp:PlaceHolder>
   
        <input type="hidden" id="Total" name="Total" runat="server" value="" />
   </td>
   <td class="vtop tips2">
       关键词默认的排名价格标准</td>
</tr>

<tr>
<td style="height: 30px" colspan="2">
    <asp:button id="btnOK" runat="server" CssClass="button" Text="保存设置" OnClick="btnOK_Click"></asp:button>&nbsp;
</td>
</tr>

</table>

</div>
   </td>
</tr>
 </table>  
 </form>
</body>
</html>
