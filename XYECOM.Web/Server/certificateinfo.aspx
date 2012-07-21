<%@ Page Title="" Language="C#" MasterPageFile="~/Server/Server.master" AutoEventWireup="true"
    CodeBehind="certificateinfo.aspx.cs" Inherits="XYECOM.Web.Server.certificateinfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div id="right">
        <form method="post">
        <table class="contentl">
            <caption>
                修改企业证书<span>（*为必填项）</span></caption>
            <tr>
                <th>
                    证书名称：<em class="red">*</em><span></span>
                </th>
                <td>
                    <input name="txtname" id="txtname" type="text" maxlength="30" size="30" value="{name}" />
                </td>
            </tr>
            <tr>
                <th>
                    证书类别：<em class="red">*</em>
                </th>
                <td>
                    <select id="txttype" name="txttype">
                        <option value="">请选择证书类别</option>
                        <option value="1">营业执照</option>
                        <option value="2">税务登记类</option>
                        <option value="3">经营许可类</option>
                        <option value="4">其它类</option>
                    </select>
                </td>
            </tr>
            <tr>
                <th>
                    发证机构：<em class="red">*</em>
                </th>
                <td>
                    <input name="txtorgan" id="txtorgan" type="text" maxlength="30" size="30" value="{organ}" />
                </td>
            </tr>
            <tr>
                <th>
                    生效日期：<em class="red">*</em>
                </th>
                <td>
                    <input onclick="getDateString(this);" id="txtbegin" maxlength="15" readonly="readonly"
                        name="txtbegin" value="{begin}" />
                </td>
            </tr>
            <tr>
                <th>
                    截至日期：<em class="red">*</em>
                </th>
                <td>
                    <input onclick="getDateString(this);" id="txtupto" maxlength="15" readonly="readonly"
                        name="txtupto" value="{upto}" />
                </td>
            </tr>
            <tr>
                <th>
                    上传证书：<em class="red">*</em>
                </th>
                <td>
                    <input type="hidden" id="aurl" name="aurl" value="" />
                </td>
            </tr>
            <tr>
                <th>
                    您上传的时间：<em class="red">*</em>
                </th>
                <td>
                    <input id="txtaddtime" maxlength="15" readonly="readonly" name="txtaddtime" value="{addtime}" />
                </td>
            </tr>
        </table>
        <div class="content_action">
            <input name="but01" type="submit" value="确定" onclick="return certificate();" class="button" />
            <input name="but02" type="button" value="取消" onclick="window.location.href='{config.WebURL}user/certificatelist.{config.Suffix}'"
                class="button" />
        </div>
        </form>
    </div>
</asp:Content>
