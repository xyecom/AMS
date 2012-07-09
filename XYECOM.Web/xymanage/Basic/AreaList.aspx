<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AreaList.aspx.cs" Inherits="XYECOM.Web.xymanage.basic.AreaList" %>
<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>地区管理</title>
<link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<script language="javascript" type="text/javascript" src="/common/js/base.js"></script>
<script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
<script language ="javascript" type ="text/javascript" src ="../javascript/labelClass.js"></script>
</head>
<body>
<form id="form1" runat="server">

    <h1><a href="../index.aspx">后台管理首页</a> >> 地区管理</h1>
    <table  width="100%" >
    <tr>
    <td class="right">    
        <div class="main-setting">
            <div class="itemtitle"><h3>地区管理</h3>
            <input id="btnadd" class="addbtn" type="button" value="新增地区信息" onclick="window.location.href='AreaAdd.aspx?ParentID=<%=strParentID%>';" />
            </div>

            <table class="xy_tb xy_tb2">
                <tr><td>
                <asp:Panel ID="pnlSuperClass" runat="server" CssClass="classTreeList">
                </asp:Panel>
                </td>
                </tr>
            </table>
        </div>
    </td>
    </tr>
    </table>
        <br/><br/>
</form>
</body>
</html>
