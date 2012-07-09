<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShopSet.aspx.cs" Inherits="XYECOM.Web.xymanage.Basic.ShopSet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>网店相关配置</title>
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <h1><a href="../index.aspx">后台管理首页</a> >> 系统基本配置</h1>
    <table width="100%" >
        <tr>
        <td class="right">    
        
        <div class="main-setting">
            <div class="itemtitle">
                <h3>系统基本配置</h3>
                <ul class="tab1">
                    <li><a href="WebInfo.aspx"><span>基本配置</span></a></li>
                    <li><a href="Function.aspx"><span>功能配置</span></a></li>
                    <li><a href="BussinessInfoSet.aspx"><span>商业信息相关</span></a></li>
                    <li><a href="UserInfoSet.aspx"><span>用户相关</span></a></li>
                    <li class="current"><a href="ShopSet.aspx"><span>网店相关</span></a></li>
                    <li><a href="Server.aspx"><span>附件服务器</span></a></li>
                    <li><a href="EMailBoxInfoSet.aspx"><span>网站邮箱</span></a></li>
                    <li><a href="SEO.aspx"><span>SEO设置</span></a></li>
                    <li><a href="SecuritySet.aspx"><span>安全设置</span></a></li>
                </ul>
              </div>
              
              <table class="xy_tb xy_tb2">
               
                
                <tr class="nobg">
                    <td colspan="2" class="td27">产品展示每页条数：</td>
                </tr>
                <tr>
                    <td class="vtop rowform">
                    <asp:TextBox ID="txtProductPageSize" runat="server" CssClass="txt" MaxLength="3" Columns="3" Width="50"></asp:TextBox>
                        <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txtProductPageSize"
                            ErrorMessage="必须在1～100之间" MaximumValue="100" MinimumValue="1" Type="Integer"></asp:RangeValidator></td><td class="vtop tips2">
    1~100
                    </td>
                </tr>
                
                <tr class="nobg">
                    <td colspan="2" class="td27">商机信息展示每页条数：</td>
                </tr>
                <tr>
                    <td class="vtop rowform">
                    <asp:TextBox ID="txtInfoPageSize" runat="server" CssClass="txt" MaxLength="3" Columns="3" Width="50"></asp:TextBox>
                        <asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="txtInfoPageSize"
                            ErrorMessage="必须在1～100之间" MaximumValue="100" MinimumValue="1" Type="Integer"></asp:RangeValidator></td><td class="vtop tips2">
    1~100
                    </td>
                </tr>
                
                <tr class="nobg">
                    <td colspan="2" class="td27">企业资讯展示每页条数：</td>
                </tr>
                <tr>
                    <td class="vtop rowform">
                    <asp:TextBox ID="txtNewsPageSize" runat="server" CssClass="txt" MaxLength="3" Columns="3" Width="50"></asp:TextBox>
                        <asp:RangeValidator ID="RangeValidator5" runat="server" ControlToValidate="txtNewsPageSize"
                            ErrorMessage="必须在1～100之间" MaximumValue="100" MinimumValue="1" Type="Integer"></asp:RangeValidator></td><td class="vtop tips2">
    1~100
                    </td>
                </tr>
                
                <tr class="nobg">
                    <td colspan="2" class="td27">品牌展示每页条数：</td>
                </tr>
                <tr>
                    <td class="vtop rowform">
                    <asp:TextBox ID="txtBrandPageSize" runat="server" CssClass="txt" MaxLength="3" Columns="3" Width="50"></asp:TextBox>
                        <asp:RangeValidator ID="RangeValidator6" runat="server" ControlToValidate="txtBrandPageSize"
                            ErrorMessage="必须在1～100之间" MaximumValue="100" MinimumValue="1" Type="Integer"></asp:RangeValidator></td><td class="vtop tips2">
    1~100
                    </td>
                </tr>
                
                <tr class="nobg">
                    <td colspan="2" class="td27">招聘信息每页条数：</td>
                </tr>
                <tr>
                    <td class="vtop rowform">
                    <asp:TextBox ID="txtJobPageSize" runat="server" CssClass="txt" MaxLength="3" Columns="3" Width="50"></asp:TextBox>
                        <asp:RangeValidator ID="RangeValidator7" runat="server" ControlToValidate="txtJobPageSize"
                            ErrorMessage="必须在1～100之间" MaximumValue="100" MinimumValue="1" Type="Integer"></asp:RangeValidator></td><td class="vtop tips2">
    1~100
                    </td>
                </tr>
              </table>
              
              <div style="padding:5px 0px 15px 0px;">
                <asp:Button ID="btnok" runat="server" CssClass="button" Text="保存设置" OnClick="btnok_Click" />
                </div>

        </div>
        </td>
        </tr>
    </table>

    </form>
</body>
</html>
