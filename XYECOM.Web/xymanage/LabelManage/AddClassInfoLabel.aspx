<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddClassInfoLabel.aspx.cs" Inherits="XYECOM.Web.xymanage.LabelManage.AddClassInfoLabel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>无标题页</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
    <script language ="javascript" type ="text/javascript" src ="../javascript/labelClass.js"></script>
    <style>
		#pnlSuperClass {
		    width:100%;
		    height:300px;
		    overflow-x: hidden;
	        overflow-y: auto;
		}	
		#tdSuperClass ul li{ 
		display:list-item; 
		float:left; 
	    width:100%;
	    clear:left;
		}
		#class2 {
		    width:100%;
		    height:300px;
		    overflow-x: hidden;
	        overflow-y: auto;
		}
		.class2item {
		    border:solid #eee 1px;
		    margin:10px 5px;
		    width:98%;
		    clear:left;
		    overflow: hidden;
		}
		#class2 li{
            width:110px;
            float:left;
        }
		
		#tdComClass{ padding:10px;}
		#tdComClass div{ border-bottom:dotted 1px #cccccc; margin-bottom:15px;}
    </style>
</head>
<body>


<form id="form1" runat="server">
<h1><a href="../index.aspx">后台管理首页</a> >> 新增分类导航标签</h1>
<table width="100%" >
<tr>
<td class="right" >

<div class="main-setting">
<div class="itemtitle"><h3>新增分类导航标签</h3></div>
                
<table class="xy_tb xy_tb2 infotable border_buttom0">
    <tr>
        <th>标签名称：</th>
        <td style="font-weight:bold">
            {XY_CLS_<asp:TextBox ID="txtLabelName" runat="server" CssClass="input_s"></asp:TextBox>}
            <br/>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLabelName" ErrorMessage="标签名称不能为空！" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
        </td>
        <th>请选择分类：</th>
        <td>
            <asp:DropDownList Width="150" ID="ddlClass" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged"></asp:DropDownList>
            <br/>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlClass" Display="Dynamic" ErrorMessage="请选择分类" SetFocusOnError="True"></asp:RequiredFieldValidator></td>  
            </tr>
        <tr>
           <th>中文名称：</th>
           <td>
                <asp:TextBox ID="txtCNName" runat="server" Columns="31" CssClass="input_s"></asp:TextBox>
                <br/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCNName"
                    ErrorMessage="中文名称不能为空！" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
            <th>选择目标页面：</th>
            <td>
            <asp:RadioButtonList ID="rblProduct" runat="server" RepeatDirection="Horizontal"
                RepeatLayout="Flow" Visible="False">
                <asp:ListItem Selected="True" Value="sell">到供应页</asp:ListItem>
                <asp:ListItem Value="buy">到求购页</asp:ListItem>
                <asp:ListItem Value="cate">到产品主页</asp:ListItem>
            </asp:RadioButtonList>
            <asp:RadioButtonList ID="rblInvestment" runat="server" RepeatDirection="Horizontal"
                RepeatLayout="Flow" Visible="False">
                <asp:ListItem Selected="True" Value="sell">到诚招代理页</asp:ListItem>
                <asp:ListItem Value="buy">到代理企业</asp:ListItem>
            </asp:RadioButtonList>
            <asp:RadioButtonList ID="rblService" runat="server" RepeatDirection="Horizontal"
                RepeatLayout="Flow" Visible="False">
                <asp:ListItem Selected="True" Value="sell">到提供服务页</asp:ListItem>
                <asp:ListItem Value="buy">到寻求服务页</asp:ListItem>
            </asp:RadioButtonList>
            <asp:RadioButtonList ID="rblMachining" runat="server" RepeatDirection="Horizontal"
                RepeatLayout="Flow" Visible="False">
                <asp:ListItem Selected="True" Value="sell">到寻求加工页</asp:ListItem>
                <asp:ListItem Value="buy">到提供加工页</asp:ListItem>
            </asp:RadioButtonList>
            <asp:RadioButtonList ID="rblNewsType" runat="server" RepeatDirection="Horizontal"
                RepeatLayout="Flow" Visible="False">
                <asp:ListItem Selected="True" Value="sell">到搜索页</asp:ListItem>
                <asp:ListItem Value="buy">到频道页</asp:ListItem>
            </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <th>选择组合方式：</th>
            <td>
<input id="Radio1" name="z" type="radio" onclick="$('tb1').style.display='none';$('tb2').style.display='block';" checked="checked" />自由组合
<input id="Radio2" name="z" type="radio" onclick="$('tb2').style.display='none';$('tb1').style.display='block';" />自动组合
            </td>
            <th>
            </th>
            <td>
            </td>
        </tr>
    </table>


            <table  style="width:97%;display:none;margin-top:5px;"  class="xy_tb xy_tb2 border_buttom0" cellpadding="4" id="tb1">
            <tr>
                <td colspan="2">
                    <table style="width:100%">
                        <tr>
                            <th style="width:15%">
                                自动组合</th>                          
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtLevel" runat="server" Width="28px">1</asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtLevel"
                                    Display="Dynamic" ErrorMessage="要组合的等级数必须为数字" SetFocusOnError="True" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>请输入组合至多少级</td>
                            
                        <td style="text-align: left">
                            <asp:Button ID="btnCall" runat="server" CssClass="button" Text="组合全部分类" OnClick="btnCall_Click" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
           </table>
           
  <table width="97%" border="0" cellpadding="5" cellspacing="1" class="xy_tb xy_tb2 border_buttom0" id="tb2" style="margin-top:5px;"> 
      <tr>
          <th align="left" bgcolor="#ffffff" colspan="2" style="height: 20px">
              自由组合</th>
      </tr>
<tr>
              <th align="left" bgcolor="#FFFFFF" style="width:40%; height: 42px;">
              一级分类:<br/>
              <span>选择单个或多个分类进行组合</span>
              </th>
              <th  align="left" bgcolor="#FFFFFF"  style="width:60%; height: 42px;">
                  下级分类:
              <br/>
              <span>选择要显示的子类进行组合</span>
              </th>
            </tr>
            <tr>
              <td align="left" bgcolor="#FFFFFF" id="tdSuperClass">
          <asp:Panel ID="pnlSuperClass" runat="server">
                    </asp:Panel></td>
              <td align="left" bgcolor="#FFFFFF">
              
              <div id="class2"></div>
              </td>
            </tr>
            <tr>
              <td align="left" bgcolor="#FFFFFF">&nbsp;</td>
<td align="left" bgcolor="#FFFFFF" >                                </td>          
            </tr>
            <tr>
              <td align="left" bgcolor="#FFFFFF" style="padding:8px;" >
                  &nbsp;<input id="btnZ" type="button" value="组合" class="button" onclick="LabelClassAssembled()" /></td>
                
              <td align="left" bgcolor="#FFFFFF" >&nbsp;</td>
            </tr>
        </table>
        
		<table class="xy_tb xy_tb2 border_buttom0" style="margin-top:5px;">
            <tr>
                <td align="left" id="tdComClass">
                    
              </td>
            </tr>
            <tr>
                <td align="left" style="padding:8px;">
                <asp:Button ID="btnFinish" runat="server" Text=" 完成 " OnClick="btnFinish_Click" CssClass="button"/>
                &nbsp;&nbsp;<input id="hddValue" runat="server" type="hidden" />
                    &nbsp;&nbsp;
                    <input id="Button1" type="button" value="放弃" class="button" onclick="LabelClassClear()" />
                    &nbsp;
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                    </td>
            </tr>
	</table>
	
                </td>
            </tr>
           </table>
    </form>
                    
</body>
</html>
