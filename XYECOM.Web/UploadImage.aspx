<%@ Page Language="C#" AutoEventWireup="true" Inherits="UploadImage" Codebehind="UploadImage.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<link href="/common/css/XYLib.css" type="text/css" rel="Stylesheet" />
<script language ="javascript" type="text/javascript"  src="/common/js/base.js"></script>
<script language ="javascript" type="text/javascript"  src="/common/js/UploadControl.js"></script>
<style type="text/css">
body {
    background-color:#fff;
    padding:2px;
}
.upload_filefrm
{
	text-align:left; 
	height:140px;
	border:solid #cccccc 1px;
	padding:5px;
	background-color:#f8f8f8;
	overflow-x:hidden;
	overflow-y:auto;
}
.upload_filefrm input {
    width:330px; 
    border:solid #ccc 1px;
    font-size:12px;
    height:18px;
    background-color:#FDFFF4;
}
.upload_filefrm input[type='button'] {
    width:22px;
    margin-left:10px;
    border:none;
    cursor:pointer;
    background:url(/Common/Images/delete.gif) no-repeat left -1px;
}
.upload_btnfrm{
    text-align:center;
    width:100%;
    margin:4px 0;
}
.upload_button{ 
	background:url(/common/images/cue_button_bg.gif) no-repeat left top;
	border:0;
	width:66px;
	height:25px;
	line-height:16px;
	text-align:center;
	margin:5px 10px;
	cursor:pointer;
}
.upload_msg {
    font-size:12px; 
    padding:10px; 
    border:solid #cccccc 1px;
    background-color:#f8f8f8;
    text-align:left;
}
.upload_ing {position:absolute; display:none; z-index:5; background-color:#fff; text-align:center; padding-top:40px;font-size:12px; }
</style>
 <title>上传附件</title>
   <base target ="_self"/>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
        <div class="upload_filefrm" id="uploadfilefrm">
            
        </div>
        <script language="javascript" type="text/javascript">UploadFileInit();</script>
        <div class="upload_btnfrm">
            <asp:Button ID="btnOK" CssClass="upload_button" runat="server" OnClick="btnOK_Click" Text="确定" OnClientClick="uploading();" />
            <input type="button" class="upload_button" value="取消" onclick="UploadClose()" />
        </div>
        <div class="upload_msg">
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </div>
  </form>
</body>
</html>
