<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UploadImage.ascx.cs" Inherits="XYECOM.Web.xymanage.UserControl.UploadImage" %>
 <div id="UploadFile">
    <input id="Upload_TabName" name="Upload_TabName" type="hidden" value="<%= TableName %>"/>
    <input id="Upload_IDs" name="Upload_IDs" type="hidden" value="<%= Ids %>" />
    <input id="Upload_Files" name="Upload_Files" type="hidden" value="<%= Files %>" />
    <input id="Upload_DelIDs" name="Upload_DelIDs" type="hidden" />
    <input id="Upload_UpIDs" name="Upload_UpIDs" type="hidden" />
    <input id="Upload_MaxAmount" name="Upload_MaxAmount" type="hidden" value="<%= MaxAmount %>" />
    <input id="Upload_IsWaterMark" name="Upload_IsWaterMark" type="hidden" value="<%= Iswatermark %>" />
    
    <script language="javascript" type="text/javascript">UploadInit();</script>
</div>