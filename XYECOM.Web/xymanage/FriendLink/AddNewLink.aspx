<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_FriendLink_AddNewLink" Codebehind="AddNewLink.aspx.cs" %>

<%@ Register Src="../UserControl/UploadImage.ascx" TagName="UploadImage" TagPrefix="uc2" %>

<%@ Register Src="../UserControl/top.ascx" TagName="top" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title >��������</title>
<link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script language ="javascript" type="text/javascript"  src="/common/js/UploadControl.js"></script>
<script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
<script language="javascript" type="text/javascript" src="../javascript/FriendLinkType.js"></script>
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<link href="../css/cue.css" type="text/css" rel="Stylesheet" />
<script language="javascript1.2" type="text/javascript">
   function TypeChange( num )
   {
      if(num == 1)
       {
           document.getElementById("TR41").style.display = "none";
           document.getElementById("TR51").style.display = "none";
           document.getElementById("TR61").style.display = "none";
           document.getElementById("TR31").style.display = "block"; 
           document.getElementById("TR21").style.display = "block";
           
           document.getElementById("TR42").style.display = "none";
           document.getElementById("TR52").style.display = "none";
           document.getElementById("TR62").style.display = "none";
           document.getElementById("TR32").style.display = "block"; 
           document.getElementById("TR22").style.display = "block";
       }
       else if(num == 2)
       {
           document.getElementById("TR31").style.display = "none";
           document.getElementById("TR21").style.display = "block";
           document.getElementById("TR41").style.display = "block";
           
           document.getElementById("TR32").style.display = "none";
           document.getElementById("TR22").style.display = "block";
           document.getElementById("TR42").style.display = "block";
           TypeChange(3);
       }
       else if(num == 3)
       {
           document.getElementById("TR51").style.display = "block";
           document.getElementById("TR61").style.display = "none";
           
           document.getElementById("TR52").style.display = "block";
           document.getElementById("TR62").style.display = "none";
       }
       else if(num == 4)
       {
           document.getElementById("TR51").style.display = "none";
           document.getElementById("TR61").style.display = "block";
           
           document.getElementById("TR52").style.display = "none";
           document.getElementById("TR62").style.display = "block";
       }
   }
   
   function Input()
   {
      if(document.getElementById("rbtext").checked == false && document.getElementById("rbpic").checked == false)
      {
           return alertmsg("���ֻ�ͼƬ���ͱ���ѡһ",'',false);
      }
      
      if(document.getElementById("tblinkrul").value == "")
      {
           return alertmsg("����URL����Ϊ�գ�",'',false);
      }
      	  
      if(document.getElementById("flsortid").value == "")
      {
           return alertmsg('��ѡ���������','',false);
      }
      if(document.getElementById("tblinkalt").value == "")
      {
           return alertmsg("������ʾ����Ϊ�գ�",'',false) ;
      } 
    
      if(document.getElementById("rbpic").checked == true)
      {
            if(document.getElementById("rbpicurl").checked == false && document.getElementById("rbpicupload").checked == false)
            {
                 return alertmsg("��ѡ��ͼƬ���ͣ�",'',false);
            }
              if(document.getElementById("rbpicurl").checked == true)
              {
		         if(document.getElementById("tbpicaddress").value == "")
                 {
                     return  alertmsg("ͼƬURL��ַ����Ϊ�գ�",'',false);
                 }
                 if(document.getElementById("tbpicaddress").value.search(/^http:\/\//) == -1)
                 {
                     return  alertmsg('ͼƬ����URL����!','',false);
                 } 
              }
              else if(document.getElementById("rbpicupload").checked == true)
              {
                  if(!IsUploadFile())
                  {
                      return alertmsg("�����ϴ�ͼƬ��",'',false);
                   }
              }
      }
       
     
     if(document.getElementById("rbtext").checked == true && document.getElementById("tblinkfont").value == "")
     {
		   return alertmsg("����˵������Ϊ�գ�",'',false);
     }
  } 
    
    function GetPicType(picurl)
    {
       if(picurl != null && picurl != "")
       {
            var temp1 = picurl.split('.');
            var len1 = temp1.length;
            var fileExt = temp1[len1-1].toLowerCase();
            var type = new Array();
            if(document.getElementById("imagetype").value != null && document.getElementById("imagetype").value != "")
            {
                type = document.getElementById("imagetype").value.split(';');
                for (var i = 0; i < type.length; i++)
                {
                    var j = 0;
                    j = fileExt.indexOf(type[i]);
                    if( j >= 0)
                    {
                       return true;
                       continue;
                    }
                }
                return false;
            }
            return true;
        }else
          return false;
    }
    
    function GetFL()
    {
        if(document.getElementById("rbtext").checked == true)
        {
            TypeChange(1);
        }
        else if(document.getElementById("rbpic").checked == true)
        {
            TypeChange(2);
                    
            if(document.getElementById("rbpicurl").checked == true)
            {
                 TypeChange(3);  
            }
            else if(document.getElementById("rbpicupload").checked == true)
            {
                 TypeChange(4);
            }
        }

    }       
</script>

</head>
<body onload = "GetFL();" >
<form id="form1" runat="server">
<h1><a href="../index.aspx">��̨������ҳ</a> &gt;&gt; ��������</h1>
<table width="100%" >
<tr>
<td class="right">

<div class="main-setting">
<div class="itemtitle"><h3>��������</h3></div>

<table class="xy_tb xy_tb2">
<tr class="nobg">
  <td colspan="2" class="td27">�������ͣ�</td>
</tr>
<tr>
   <td class="vtop rowform">
    
	<asp:RadioButton ID="rbtext" runat="server" Text="��������" GroupName="LinkType" CssClass="input" Checked="True" />
	<asp:RadioButton ID="rbpic" runat="server" Text="ͼƬ����" GroupName="LinkType" CssClass="input"  />

   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">����URL��</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:TextBox ID="tblinkrul" MaxLength="80" Columns="40" runat="server" CssClass="input" Text="http://"></asp:TextBox>
   </td>
   <td class="vtop tips2">�磺http://www.xyecom.com</td>
</tr>

<tr class="nobg">
  <td colspan="2" class="td27">���ӷ��ࣺ</td>
</tr>
<tr>
   <td class="vtop rowform">
    <asp:ListBox ID="flsortid" runat="server" Rows="1"></asp:ListBox>
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg" id="TR21">
  <td colspan="2" class="td27">������ʾ��</td>
</tr>
<tr id="TR22">
   <td class="vtop rowform">
    <asp:TextBox ID="tblinkalt" MaxLength="20" Columns="40" runat="server" CssClass="input"></asp:TextBox>
   </td>
   <td class="vtop tips2">��������Alt��ʾ����</td>
</tr>

<tr class="nobg" id="TR31">
  <td colspan="2" class="td27">����˵����</td>
</tr>
<tr id="TR32">
   <td class="vtop rowform">
    <asp:TextBox ID="tblinkfont" MaxLength="20"  Columns="40"  runat="server" CssClass="input" ></asp:TextBox>
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg" id="TR41">
  <td colspan="2" class="td27">ͼƬ���ͣ�</td>
</tr>
<tr id="TR42">
   <td class="vtop rowform">
   <asp:RadioButton ID="rbpicurl" runat="server" Text="ͼƬURL" GroupName="IsFlag" CssClass="input" Checked="True" />
    <asp:RadioButton ID="rbpicupload" runat="server" Text="�ϴ�ͼƬ" GroupName="IsFlag" CssClass="input" />
    <input id="imagetype" runat="server" type="hidden" />
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr class="nobg" id="TR51">
  <td colspan="2" class="td27">ͼƬURL��ַ��</td>
</tr>
<tr id="TR52">
   <td class="vtop rowform">
   <asp:TextBox ID="tbpicaddress" MaxLength="80" runat="server" CssClass="input" Columns="40"></asp:TextBox>
   </td>
   <td class="vtop tips2">ͼƬ������URL��ַ</td>
</tr>

<tr class="nobg" id="TR61" style="display:none">
  <td colspan="2" class="td27">�ϴ�ͼƬ��ַ��</td>
</tr>
<tr id="TR62" style="display: none">
   <td class="vtop rowform">
   <uc2:UploadImage ID="UploadFile1" runat="server" Iswatermark="false" MaxAmount="1" TableName="b_FriendLink" />
   </td>
   <td class="vtop tips2"></td>
</tr>

<tr>
<td class="content_action" colspan="2">
 <asp:button id="btnAdd" runat="server" CssClass="button" Text="ȷ��" OnClick="btnAdd_Click" EnableViewState="False" ></asp:button>&nbsp; &nbsp;
 <input class="button" runat="Server" id="btcancel" type="button" value="ȡ��" onserverclick="btcancel_ServerClick" />
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
