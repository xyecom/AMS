<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SEO.aspx.cs" Inherits="XYECOM.Web.xymanage.Basic.SEO" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>SEO设置</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
    <style type="text/css">
    .seotable th{width:120px;text-align:right;}
    .seotable .caption{background-color:#f1f5f8;font-weight:bold;}
    </style>
</head>
<body>
<form id="form1" runat="server">
<h1><a href="../index.aspx">后台管理首页</a>  &gt;&gt; SEO信息设置</h1>
<table width="100%">
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
    <li><a href="ShopSet.aspx"><span>网店相关</span></a></li>
    <li><a href="Server.aspx"><span>附件服务器</span></a></li>
    <li><a href="EMailBoxInfoSet.aspx"><span>网站邮箱</span></a></li>
    <li class="current"><a href="SEO.aspx"><span>SEO设置</span></a></li>
    <li><a href="SecuritySet.aspx"><span>安全设置</span></a></li>
</ul>
</div>
    <table width="100%" class="xy_tb xy_tb2">
       
        <tr class="nobg">
          <td class="td27">通用设置：</td>
        </tr>
        <tr>
            <td class="tipsblock">
            <ul>
                <li>选中此项，所有 title 项之后将自动追加 “_网站名称”</li>
                <li>选中此项，所有 description,keyworks 项之后将自动追加 “,网站名称”</li>
                <li>网站首页除外</li>
            </ul>
            </td>
        </tr>
        <tr>
           <td >
                <asp:CheckBox ID="chkAutoAppendWebName" runat="server" Text="自动追加网站名称到各项之后"/>
           </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnSaveCommon" runat="server" Text="保存设置" CssClass="button" OnClick="btnSaveCommon_Click"/>
            </td>
        </tr>
        <tr class="nobg">
          <td class="td27">详细设置：</td>
        </tr>
        <tr class="nobg">
            <td  class="tipsblock">
                <ul id="Ul2">
                    <li>在设置内容中可以插入标签<span style="color:#f60">{keyword}</span>，在列表页将被替换为当前搜索的关键字；在信息详细页面将被替换为当前信息的名称<br/><span style="color:#f60">注意：此标签对各模块首页无效.</span></li>
                    <li>列表页启用关键字匹配后，当前搜索的关键字将自动追加到各项内容之后</li>
                    <li>详细内容页启用分类匹配后，当前信息的分类将自动追加到各项内容之后</li>
                </ul>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%">           
                    <tr>
                        <td  width="155px;" valign="top">
                            <div class="m_title">选择模块</div>
                            <asp:ListBox runat="server" ID="lstModules" Rows="14" Width="150px" CssClass="modules" OnSelectedIndexChanged="lstModuls_SelectedChanged" AutoPostBack="true">                    
                            </asp:ListBox>
                        </td>
                        <td>
                        
                            <table width="100%" class="seotable">
                                <tr>
                                    <td colspan="2" class="caption">首页相关设置</td>
                                </tr>
                                <tr>
                                    <th>标题(title)：</th>
                                    <td><asp:TextBox ID="txtIndexTitle" runat="server" MaxLength="400" Columns="45" Rows="3" TextMode="MultiLine" CssClass="input" Width="96%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                   <th>描述：<span>(description)</span></th>
                                   <td><asp:TextBox ID="txtIndexDesc" runat="server" Columns="116" CssClass="input" Rows="3" TextMode="MultiLine" MaxLength="500" Width="96%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <th>关键词：<span>(keywords)</span></th>
                                    <td><asp:TextBox ID="txtIndexKeywords" runat="server" Columns="116" MaxLength="500" CssClass="input" Rows="3" TextMode="MultiLine" Width="96%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <th>蜘蛛程序(robots)：</th>
                                    <td><asp:RadioButton ID="rdoIsRobotsYes" runat="server" CssClass="input" Text="允许" GroupName="index" Checked="True" />
                                        <asp:RadioButton ID="rdoIsRobotsNo" runat="server" CssClass="input" Text="不允许" GroupName="index" />
                                        </td>
                                </tr>
                            </table>
                            
                            <asp:Panel runat="server" ID="pnlListPage">
                           <table width="100%" class="seotable">
                                <tr>
                                    <td colspan="2" class="caption">列表页相关设置</td>
                                </tr>
                                <tr>
                                    <th>标题(title)：</th>
                                    <td><asp:TextBox ID="txtListTitle" runat="server" MaxLength="400" Rows="3" TextMode="MultiLine" Columns="45" CssClass="input" Width="96%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                   <th>描述：<span>(description)</span></th>
                                   <td><asp:TextBox ID="txtListDesc" runat="server" Columns="116" CssClass="input" Rows="3" TextMode="MultiLine" MaxLength="500" Width="96%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <th>关键词：<span>(keywords)</span></th>
                                    <td><asp:TextBox ID="txtListKeywords" runat="server" Columns="116" MaxLength="500" CssClass="input" Rows="3" TextMode="MultiLine" Width="96%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <th>匹配关键字：</th>
                                    <td><asp:CheckBox runat="server" ID="chkListIsMatch" Text="启用匹配"/></td>
                                </tr>
                           </table>
                           </asp:Panel>
                           
                           <asp:Panel runat="server" ID="pnlInfoPage">
                            <table width="100%"  class="seotable">
                                <tr>
                                    <td colspan="2" class="caption">信息页相关设置</td>
                                </tr>
                                <tr>
                                    <th>标题(title)：</th>
                                    <td><asp:TextBox ID="txtInfoTitle" runat="server" MaxLength="400" Rows="3" TextMode="MultiLine" Columns="45" CssClass="input" Width="96%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                   <th>描述：<span>(description)</span></th>
                                   <td><asp:TextBox ID="txtInfoDesc" runat="server" Columns="116" CssClass="input" Rows="3" TextMode="MultiLine" MaxLength="500" Width="96%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <th>关键词：<span>(keywords)</span></th>
                                    <td><asp:TextBox ID="txtInfoKeywords" runat="server" Columns="116" MaxLength="500" CssClass="input" Rows="3" TextMode="MultiLine" Width="96%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <th>匹配分类名称：</th>
                                    <td><asp:CheckBox runat="server" ID="chkInfoIsMatch" Text="启用匹配"/></td>
                                </tr>
                           </table>        
                           </asp:Panel> 
                           <table>
                            <tr>
                                <td>
                                    <asp:Button  ID="btnOK" runat="server" Text="保存设置" CssClass="button" OnClick="btnOK_Click"/>
                                </td>
                            </tr>
                           </table>     
                        </td>
                    </tr>
                </table>
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

