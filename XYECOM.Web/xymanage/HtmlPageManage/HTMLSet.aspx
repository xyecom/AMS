<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_HtmlPageManage_HTMLSet" Codebehind="HTMLSet.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>��̬ҳ�����</title>
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
                    alert("������ֻ��ʹ��һ��");
                    return;
                }
                __xy_set_value(myField,value);
            }
            
            function __q_setRandValue(valueField,txtField)
            {
                var myField = document.getElementById(valueField);
                
                if(myField.value.indexOf('@Rand') !=-1)
                {
                    alert("�����ֻ�ܲ���һ��");
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
 <h1><a href="../index.aspx">��̨������ҳ</a> >>��̬ҳ���������</h1>
 <table width="100%">
 <tr>
 <td class="right">

<div class="main-setting">
<div class="itemtitle">
<h3>��̬ҳ���������</h3>
<ul id="mainMenus0" runat="server" class="tab1">
<li class="current"><a href='HTMLSet.aspx'><span>�������</span></a></li>
<li><a href='HtmlManage.aspx'><span>�������</span></a></li>
<li><a href='HtmlState.aspx'><span>����״̬�鿴</span></a></li>
</ul>
</div>

 <table width="100%" class="xy_tb xy_tb2">
 
 <tr class="nobg">
  <td colspan="2" class="td27">������ʾ��</td>
</tr>

 <tr>
 <td class="vtop rowform"  style="width: 600px; line-height:250%;">
  1���������ý��Ը�ģ����Ϣ����ҳ��Ч����ģ����ҳ����Ѷ��Ŀҳ����ѭ���¹���<br/>
  2������·�����ļ���ʱ��ȷ��ͬһ�ļ������ļ���Ψһ��
  </td>
</tr>

 <tr class="nobg">
  <td colspan="2" class="td27">ҳ����ģʽ��</td>
</tr>
<tr>
   <td class="vtop rowform" style="width: 400px; line-height:250%;">
        <input type="radio" name="SaveMode" id="rdoDefaultMode" value="default" runat="server" checked="true" onclick="__xy_sel_mode('default');"/>Ĭ��ģʽ (��ģ���ڲ�ͬ��Ŀ¼�´�ž�̬ҳ��)<br/>
        <input type="radio" name="SaveMode" id="rdoUnifyMode" value="unify" runat="server"  onclick="__xy_sel_mode('unify');"/>ͳһ���ģʽ (���ļ������ͬһĿ¼����ģ�����Ʒ��ļ��д��)<br/>
        <div id="divHTMLFolder" class="fSet">
        Ŀ¼���ƣ�
        <input type="text" id="txtBaseDirName" value="html" size="10" maxlength="10" runat="server" onblur="if(this.value=='')this.value='html';"/>&nbsp;
        <script type="text/javascript">
            if(document.getElementById("rdoDefaultMode").checked == true)
                document.getElementById("txtBaseDirName").disabled = true;
        </script>

            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtBaseDirName"
                ErrorMessage="ֻ��ʹ��a~z֮�����ĸ" ValidationExpression="^[A-Za-z]+$"></asp:RegularExpressionValidator></div>
    
   </td>
</tr>

 <tr class="nobg">
  <td colspan="2" class="td27">�ļ���·�����ã�</td>
</tr>
<tr>
   <td class="vtop rowform" style="width: 600px; line-height:250%;">
        
        ע������Ϣ����ʱ��Ϊ��׼<br/>
        
        <input id="txtDirPath" type="text" name="txtDirPath" size="60" maxlength="50" runat="server"/>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDirPath"
           ErrorMessage="·�����ò���Ϊ��"></asp:RequiredFieldValidator>
           <div>

            <input type="button" value="��" onclick="__q_setValue('txtDirPath','@yyyy')" class="quick_btn"/>
            <input type="button" value="��" onclick="__q_setValue('txtDirPath','@MM')" class="quick_btn"/>
            <input type="button" value="��" onclick="__q_setValue('txtDirPath','@dd')" class="quick_btn"/>
            <input type="button" value="ʱ" onclick="__q_setValue('txtDirPath','@HH')" class="quick_btn"/>
        </div>
   </td>
</tr>

 <tr class="nobg">
  <td colspan="2" class="td27">�ļ��������ã�</td>
</tr>
<tr>
   <td class="vtop rowform" style="width: 100%; line-height:250%; height: 83px;">
        ע������Ϣ����ʱ��Ϊ��׼<br/>
        <input id="txtFileName" type="text" name="txtFileName" size="60" maxlength="50" runat="server"/>  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFileName"
           ErrorMessage="�ļ��������ò���Ϊ��"></asp:RequiredFieldValidator>
           <div>

            <input type="button" value="��" onclick="__q_setValue('txtFileName','@yyyy')" class="quick_btn"/>
            <input type="button" value="��" onclick="__q_setValue('txtFileName','@MM')" class="quick_btn"/>
            <input type="button" value="��" onclick="__q_setValue('txtFileName','@dd')" class="quick_btn"/>
            <input type="button" value="ʱ" onclick="__q_setValue('txtFileName','@HH')" class="quick_btn"/>
            <input type="button" value="��" onclick="__q_setValue('txtFileName','@mm')" class="quick_btn"/>
            <input type="button" value="��" onclick="__q_setValue('txtFileName','@ss')" class="quick_btn"/>
            <input type="button" value="����" onclick="__q_setValue('txtFileName','@fff')" class="quick_btn"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <input type="button" value="Id" onclick="__q_setValue('txtFileName','@Id')" class="quick_btn"/>
            <input type="button" value="�����" onclick="__q_setRandValue('txtFileName','randNumberSizeForFileName')" class="quick_btn"/>
            <input type="text" size="1" maxlength="1" id="randNumberSizeForFileName"  class="quick_txt" value="3"/>λ
        </div>
   </td>
</tr>

<tr>
    <td colspan="2"><asp:Button ID="btnOK" runat="server" CssClass="button" Text="��������" OnClick="btnOK_Click" />&nbsp;&nbsp;<asp:Label runat="server" ID="lblSetMsg"  ForeColor="red"/></td>
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
