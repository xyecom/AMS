<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_MessageManage_AddSendEmail" Codebehind="AddSendEmail.aspx.cs" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Src="../UserControl/page.ascx" TagName="page" TagPrefix="uc2" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>�����ʼ�</title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<link href="../css/style.css" type="text/css" rel="stylesheet" />
<link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script language ="javascript" src ="../javascript/CheckedAll.js" type ="text/javascript" ></script>
<script language ="javascript" src ="../javascript/labelClass.js" type ="text/javascript" ></script>
</head>
<body>
<form id="Form1" method="post" runat="server">
<h1><a href="../index.aspx">��̨������ҳ</a> >> �����ʼ�</h1>
<table  width="100%" >
<tr>
<td class="right" style="height: 504px">

<div class="main-setting">
<div class="itemtitle"><h3>�ʼ�����</h3>
    <ul class="tab1" id="mainMenus0">
        <li><a href="SendEmail.aspx"><span>������</span></a></li>
        <li class="current"><a href="#"><span>�����ʼ�</span></a></li>
    </ul>
</div>

<table width="100%" style="margin-top:0px;" cellpadding="0" cellspacing="0">
    <tr>      
    <td valign="top">
            <table width="100%" class="send_msg_body">
            <tr>
                <td valign="top">���⣺</td>
                <td><asp:TextBox ID="lbtitle" runat="server" Width="98%"  MaxLength ="200"></asp:TextBox></td>
            </tr>
            <tr>
                <td valign="top">���ݣ�</td>
                <td>
                <FCKeditorV2:FCKeditor ID="lbcontent" runat="server" BasePath="/Common/fckeditor/" ToolbarSet="Basic" Height="340px">
                </FCKeditorV2:FCKeditor>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <label>
                    ��¼����{loginname}  |  ��˾����/�������ƣ�{username}  |  �û�ID��{userid}<br/>
                    <asp:Button ID="Button2" runat="server" Text="����" CssClass ="button" OnClick="Button2_Click2"/>&nbsp;
                    <asp:Button ID="Button3" runat="server" Text="ȡ��" CssClass ="button" OnClick="Button3_Click1" />
                    
                    <input id="key" runat="server" type="hidden" />
                    <input id="value" runat="server" type="hidden" />
                    </label>
                 </td>
            </tr>
            </table>
        </td>
        <td style="width:10px;">
        </td>
        <td align="left" class="select_user">
         <div id="a2">
		    <ul>
		      <li id="lic" class="cur_usertype" onclick="company();">��ҵ��Ա</li>
		      <li id="lip" class="usertype" onclick="person();">���˻�Ա</li>
		    </ul>
	     </div>
	        <div id="b22">	            
                <input type="radio" name="rbt" id="rbtsearch" onclick="rbtchanage(1)" checked="checked"/>��������û����з���
                <hr/>                
                <div id="pansearch" >
                    ����˾����(��¼��)������<br/>
                    <asp:TextBox ID="txtcompany" runat="server" MaxLength="50" Columns="29"></asp:TextBox>
                    <asp:Button ID="btnsearch" runat="server" Text="����"  CssClass="button" OnClick="btnsearch_Click"/>
                    <hr />
                    ����б�
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  DataKeyNames="U_ID"  Width="100%"  PageSize="5" GridLines="None" >
                            <Columns>
                            <asp:BoundField DataField="U_ID" HeaderText="U_ID" Visible="False" />
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkExport1" runat="server" />
                                </ItemTemplate>
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="UI_Name" HeaderText="��˾����">
                                <HeaderStyle CssClass="gvLeft" />
                                <ItemStyle CssClass="gvLeft" Width="95%" />
                            </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                        <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                        <hr />
                        <uc2:page ID="Page2" runat="server" Mode="simple"/>
                </div>
	        </div>
	        <div id="b23" style="display:none;">
	            <input type="radio" name="rbtperson" id="Radio1"  onclick="rbtchanageperson(0)" />�����и����û�����
	            <br />
	            <input type="radio" name="rbtperson" id="Radio2" checked="checked" onclick="rbtchanageperson(1)"/>��������û����з���
                
                
                <input id="personall" runat="server" type="hidden" value="0"/>
                <hr />
                <div  id="personserach">
		        ������������<br />
                <asp:TextBox ID="txtperson" runat="server" MaxLength="10" Columns="29"></asp:TextBox>
                <asp:Button ID="btnperson" runat="server" Text="����" CssClass="button" OnClick="btnperson_Click" />
	            <hr />
	            ����б�
	            <asp:GridView ID="gvlist" runat="server" AutoGenerateColumns="False"  DataKeyNames="U_ID"  Width="100%"  PageSize="5" GridLines="None" >
                <Columns>
                <asp:BoundField DataField="U_ID" HeaderText="U_ID" Visible="False" />
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkExport" runat="server" />
                    </ItemTemplate>
                    <ItemStyle Width="5%" />
                </asp:TemplateField>
                <asp:BoundField DataField="UI_Name" HeaderText="����">
                    <HeaderStyle CssClass="gvLeft" />
                    <ItemStyle CssClass="gvLeft" Width="45%" />
                </asp:BoundField>
                <asp:BoundField DataField="U_Name" HeaderText="�û���">
                    <HeaderStyle CssClass="gvLeft" />
                    <ItemStyle CssClass="gvLeft" Width="50%" />
                </asp:BoundField>
                </Columns>
            </asp:GridView>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            <hr />
             <input id="chkAll" onclick="chkAll_true();" type="checkbox" name="chkAll" />ȫѡ
             <uc2:page ID="Page1" runat="server" Mode="simple"/> 
	        </div>
	        </div>
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
