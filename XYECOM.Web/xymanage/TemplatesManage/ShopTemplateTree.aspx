<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShopTemplateTree.aspx.cs" Inherits="XYECOM.Web.xymanage.TemplatesManage.ShopTemplateTree" %>

<%@ Register Src="../UserControl/top.ascx" TagName="top" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>网店模板管理</title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script language ="javascript" type ="text/javascript" src ="../javascript/CheckedAll.js"></script>
<script type="text/javascript" src="../javascript/templates.js"></script>
</head>
<body>
<form id="Form1" method="post" runat="server">
<iframe id="window" style="position:absolute; z-index:4;display:none;" frameBorder="0" onload="iframeload(this)"></iframe>
<div id='Div_window' style="position:absolute;display:none; left:0; top:0; width:100%; z-index:3;" onkeydown ="if(event.keyCode == 13 || event.keyCode == 32){sClose();} "></div>
    <h1><a href="../index.aspx">后台管理首页</a> >> 网店模板管理</h1>
    <table  width="100%" >
        <tr>
            <td class="right">
                
                

                <div class="main-setting">
                <br/>
                <div>
                    <ul class="sel_s_tabs1">
                        <li id="fileList_tab1" class="current"><a href="#" onclick="xy_selectBox(2,1,'fileList');">基本文件</a></li>
                        <li id="fileList_tab2"><a href="#" onclick="xy_selectBox(2,2,'fileList');">样式文件</a></li>
                    </ul>
                    
                    <div class="temp_con3" id="fileList_box1" runat="server">
                        
                    </div> 
                    
                    <div class="temp_con3" id="fileList_box2" runat="server" style="display:none;">
                        
                    </div>   
                </div>
                <div class="temp_but">
	                <input name="" type="checkbox" value="" id="chkallaspx" onclick="templatescheckall();" />全选&nbsp;<input id="Button2" class="button" type="button" value="生成选中的模板文件" onclick="javascript:return createhtml();" />&nbsp;<input type="button" class="button" onclick="javascript:return deletehtml();"  value="删除指定的模版文件"/>
	            </div>
	          </div>
            </td> 
        </tr> 
    </table> 
    <input id="hidpathname" type="hidden" value="" runat="server"/>
    <input id="hidT_ID" type="hidden" name="hidT_ID" runat="server" value="_shop"/>
    <input name="hidpath" type="hidden" id="hidpath" value="_shop" />
</form>
</body>
</html>


