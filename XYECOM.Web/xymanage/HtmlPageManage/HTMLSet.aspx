<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_HtmlPageManage_HTMLSet" Codebehind="HTMLSet.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>静态页面相关</title>
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <link type="text/css" rel="Stylesheet" href="../css/style.css" />
    <script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
    <script type="text/javascript" language="javascript" src="../javascript/WebSet.js"></script>
            <script type="text/javascript">
            function __q_setValue(txtid,value)
            {
                var  myField = document.getElementById(txtid);
                                               
                if(myField.value.indexOf(value) !=-1)
                {
                    alert("各参数只能使用一次");
                    return;
                }
                __xy_set_value(myField,value);
            }
            
            function __q_setRandValue(valueField,txtField)
            {
                var myField = document.getElementById(valueField);
                
                if(myField.value.indexOf('@Rand') !=-1)
                {
                    alert("随机数只能插入一次");
                    return;
                }
                
                var randSize = document.getElementById(txtField).value;
                
                if(randSize=="" || isNaN(randSize))randSize =3;
                
                var myValue ="@Rand("+randSize+")";
                
                __xy_set_value(myField,myValue);
            }
            
            function __xy_set_value(ele,value)
            {
                if (document.selection) { 
                    ele.focus(); 
                    sel = document.selection.createRange(); 
                    sel.text = value; 
                    ele.focus(); 
                } else if (ele.selectionStart || ele.selectionStart == '0') { 
                    var startPos = ele.selectionStart; 
                    var endPos = ele.selectionEnd; 
                    var cursorPos = endPos; 
                    ele.value = ele.value.substring(0, startPos) 
                                      + value 
                                      + ele.value.substring(endPos, ele.value.length); 
                    cursorPos += value.length; 
                    ele.focus(); 
                    ele.selectionStart = cursorPos; 
                    ele.selectionEnd = cursorPos; 
                } else { 
                    ele.value += value; 
                    ele.focus(); 
                }   
            }
            
            function __xy_sel_mode(mode)
            {
                var ele = document.getElementById("txtBaseDirName");
                
                if(mode =='default')
                    ele.disabled = true;
                else
                    ele.disabled = false;
            }
        </script>
        
    <style type="text/css">
    .fSet{border:1px solid #ccc; background-color:#ffffe1;padding:5px;}
    .quick_btn{
    border-top:1px #ddd solid;
    border-left:1px #ddd solid;
    border-right:1px #999 solid;
    border-bottom:1px #999 solid;
    height:20px;
    }
    .quick_txt{
    margin-top:0px;
    background-color:#fff;
    vertical-align:top;
    }
    </style>
</head>
<body>
 <form id="form1" runat="server"> 
 <h1><a href="../index.aspx">后台管理首页</a> >>静态页面相关设置</h1>
 <table width="100%">
 <tr>
 <td class="right">

<div class="main-setting">
<div class="itemtitle">
<h3>静态页面相关设置</h3>
<ul id="mainMenus0" runat="server" class="tab1">
<li class="current"><a href='HTMLSet.aspx'><span>相关设置</span></a></li>
<li><a href='HtmlManage.aspx'><span>添加任务</span></a></li>
<li><a href='HtmlState.aspx'><span>任务状态查看</span></a></li>
</ul>
</div>

 <table width="100%" class="xy_tb xy_tb2">
 
 <tr class="nobg">
  <td colspan="2" class="td27">操作提示：</td>
</tr>

 <tr>
 <td class="vtop rowform"  style="width: 600px; line-height:250%;">
  1：以下设置仅对各模块信息内容页有效，各模块首页及资讯栏目页不遵循以下规则<br/>
  2：设置路径及文件名时请确保同一文件夹下文件的唯一性
  </td>
</tr>

 <tr class="nobg">
  <td colspan="2" class="td27">页面存放模式：</td>
</tr>
<tr>
   <td class="vtop rowform" style="width: 400px; line-height:250%;">
        <input type="radio" name="SaveMode" id="rdoDefaultMode" value="default" runat="server" checked="true" onclick="__xy_sel_mode('default');"/>默认模式 (按模块在不同的目录下存放静态页面)<br/>
        <input type="radio" name="SaveMode" id="rdoUnifyMode" value="unify" runat="server"  onclick="__xy_sel_mode('unify');"/>统一存放模式 (将文件存放于同一目录，按模块名称分文件夹存放)<br/>
        <div id="divHTMLFolder" class="fSet">
        目录名称：
        <input type="text" id="txtBaseDirName" value="html" size="10" maxlength="10" runat="server" onblur="if(this.value=='')this.value='html';"/>&nbsp;
        <script type="text/javascript">
            if(document.getElementById("rdoDefaultMode").checked == true)
                document.getElementById("txtBaseDirName").disabled = true;
        </script>

            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtBaseDirName"
                ErrorMessage="只能使用a~z之间的字母" ValidationExpression="^[A-Za-z]+$"></asp:RegularExpressionValidator></div>
    
   </td>
</tr>

 <tr class="nobg">
  <td colspan="2" class="td27">文件夹路径设置：</td>
</tr>
<tr>
   <td class="vtop rowform" style="width: 600px; line-height:250%;">
        
        注：以信息发布时间为基准<br/>
        
        <input id="txtDirPath" type="text" name="txtDirPath" size="60" maxlength="50" runat="server"/>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDirPath"
           ErrorMessage="路径设置不能为空"></asp:RequiredFieldValidator>
           <div>

            <input type="button" value="年" onclick="__q_setValue('txtDirPath','@yyyy')" class="quick_btn"/>
            <input type="button" value="月" onclick="__q_setValue('txtDirPath','@MM')" class="quick_btn"/>
            <input type="button" value="日" onclick="__q_setValue('txtDirPath','@dd')" class="quick_btn"/>
            <input type="button" value="时" onclick="__q_setValue('txtDirPath','@HH')" class="quick_btn"/>
        </div>
   </td>
</tr>

 <tr class="nobg">
  <td colspan="2" class="td27">文件名称设置：</td>
</tr>
<tr>
   <td class="vtop rowform" style="width: 100%; line-height:250%; height: 83px;">
        注：以信息发布时间为基准<br/>
        <input id="txtFileName" type="text" name="txtFileName" size="60" maxlength="50" runat="server"/>  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFileName"
           ErrorMessage="文件名称设置不能为空"></asp:RequiredFieldValidator>
           <div>

            <input type="button" value="年" onclick="__q_setValue('txtFileName','@yyyy')" class="quick_btn"/>
            <input type="button" value="月" onclick="__q_setValue('txtFileName','@MM')" class="quick_btn"/>
            <input type="button" value="日" onclick="__q_setValue('txtFileName','@dd')" class="quick_btn"/>
            <input type="button" value="时" onclick="__q_setValue('txtFileName','@HH')" class="quick_btn"/>
            <input type="button" value="分" onclick="__q_setValue('txtFileName','@mm')" class="quick_btn"/>
            <input type="button" value="秒" onclick="__q_setValue('txtFileName','@ss')" class="quick_btn"/>
            <input type="button" value="毫秒" onclick="__q_setValue('txtFileName','@fff')" class="quick_btn"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <input type="button" value="Id" onclick="__q_setValue('txtFileName','@Id')" class="quick_btn"/>
            <input type="button" value="随机数" onclick="__q_setRandValue('txtFileName','randNumberSizeForFileName')" class="quick_btn"/>
            <input type="text" size="1" maxlength="1" id="randNumberSizeForFileName"  class="quick_txt" value="3"/>位
        </div>
   </td>
</tr>

<tr>
    <td colspan="2"><asp:Button ID="btnOK" runat="server" CssClass="button" Text="保存设置" OnClick="btnOK_Click" />&nbsp;&nbsp;<asp:Label runat="server" ID="lblSetMsg"  ForeColor="red"/></td>
</tr>
<tr class="nobg">
  <td colspan="2" class="td27" style="height: 27px"></td>
</tr>
<tr>
   <td class="vtop rowform" style="width: 306px">
    </td>
   <td class="vtop tips2"></td>
</tr>
</table>

</div>
   </td>
</tr>
 </table>  
 </form>
</body>
</html>
