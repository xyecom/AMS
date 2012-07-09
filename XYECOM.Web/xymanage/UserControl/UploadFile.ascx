<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UploadFile.ascx.cs" Inherits="XYECOM.Web.xymanage.UserControl.UploadFile" %>
 <div id="_UploadFile">
    <input id="_Upload_TabName" name="_Upload_TabName" type="hidden" value="<%= TableName %>"/>
    <input id="_Upload_IDs" name="_Upload_IDs" type="hidden" value="<%= Ids %>" />
    <input id="_Upload_Files" name="_Upload_Files" type="hidden" value="<%= Files %>" />
    <input id="_Upload_DelIDs" name="_Upload_DelIDs" type="hidden" />
    <input id="_Upload_UpIDs" name="_Upload_UpIDs" type="hidden" />
    <input id="_Upload_MaxAmount" name="_Upload_MaxAmount" type="hidden" value="<%= MaxAmount %>" />    
    <script language="javascript" type="text/javascript">_UploadFileInit();</script>
</div>