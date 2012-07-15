<%@ Page Title="" Language="C#" MasterPageFile="~/Server/Server.master" AutoEventWireup="true"
    CodeBehind="CertificateAdd.aspx.cs" Inherits="XYECOM.Web.Server.CertificateAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript" src="/Other/js/ForeUploadControl.js"></script>
    <script language="javascript" type="text/javascript" src="/Other/js/validate.js"></script>
    <style type="text/css">
        .upload_bg
        {
            position: absolute;
            background-color: #000;
            margin: auto;
            left: 0;
            top: 0;
            display: none;
            z-index: 30;
            filter: Alpha(opacity=30); /* IE */
            -moz-opacity: 0.3; /* Moz + FF */
            opacity: 0.3; /* CSS3*/
        }
        
        .upload_frm
        {
            position: absolute;
            display: none;
            z-index: 40;
        }
        
        .upload_fileitem
        {
            padding: 5px;
            margin-left: 5px;
            float: left;
            text-align: center;
            border: solid 1px #eee;
        }
        .upload_fileitem ul
        {
        }
        .upload_fileitem li
        {
        }
        .Upload_img
        {
        }
        a.Upload_btn:link
        {
        }
        
        
        .upload_fileitem_byfile
        {
            width: 80%;
            float: left;
            text-align: center;
        }
        .Upload_File
        {
            width: 100%;
        }
        .Upload_File li
        {
            height: 22px;
            line-height: 22px;
            text-align: left;
            margin-top: 5px;
            border: solid 1px #eee;
            padding: 5px;
            background-color: #f8f8f8;
        }
        .Upload_File li em
        {
            float: left;
        }
        .Upload_File li span
        {
            float: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div id="right">
        <h2>
            发布企业证书</h2>
        <table class="contentl">
            <tr>
                <th>
                    证书名称：<span></span>
                </th>
                <td>
                    <asp:TextBox ID="txtname" MaxLength="30" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    证书类别：
                </th>
                <td>
                    <asp:DropDownList ID="txttype" runat="server">
                        <asp:ListItem Value="">请选择证书类别</asp:ListItem>
                        <asp:ListItem Value="1">营业执照</asp:ListItem>
                        <asp:ListItem Value="2">税务登记类</asp:ListItem>
                        <asp:ListItem Value="3">经营许可类</asp:ListItem>
                        <asp:ListItem Value="4">其它分类</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th>
                    发证机构：
                </th>
                <td>
                    <asp:TextBox ID="txtorgan" runat="server" MaxLength="30"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    生效日期：
                </th>
                <td>
                    <asp:TextBox ID="txtbegin" runat="server" MaxLength="15" ReadOnly="true" onclick="getDateString(this);"></asp:TextBox>
                    <%--                    <input onclick="getDateString(this);" id="txtbegin" maxlength="15" readonly="readonly"
                        name="txtbegin" />--%>
                </td>
            </tr>
            <tr>
                <th>
                    截至日期：
                </th>
                <td>
                    <asp:TextBox ID="txtupto" runat="server" MaxLength="15" ReadOnly="true" onclick="getDateString(this);"></asp:TextBox>
                    <%--<input onclick="getDateString(this);" id="txtupto" maxlength="15" readonly="readonly"
                        name="txtupto" />--%>
                </td>
            </tr>
            <tr>
                <th>
                    上传证书：
                </th>
                <td>
                    <input type="hidden" id="aurl" name="aurl" value="" />
                    <XYECOM:UploadImage ID="UploadImage1" runat="server" TableName="u_certificate" MaxAmount="1"
                        Iswatermark="false" IsCreateThumbnailImg="true" />
                </td>
            </tr>
            <tr id="reason" runat="server">
                <th>
                    未通过原因：
                </th>
                <td id="txtCausation" runat="server">
                </td>
            </tr>
            <tr id="advice" runat="server">
                <th>
                    建议：
                </th>
                <td id="txtAdvice" runat="server">
                </td>
            </tr>
        </table>
        <div class="content_action">
            <asp:HiddenField ID="hidInfoId" runat="server" />
            <asp:Button ID="btnOK" runat="server" Text="确定" OnClick="btnOK_Click" />
            <input name="but02" type="button" value="取消" onclick="history.back();" class="button" />
        </div>
    </div>
</asp:Content>
