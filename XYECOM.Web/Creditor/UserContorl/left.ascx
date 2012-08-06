<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="left.ascx.cs" Inherits="XYECOM.Web.Creditor.UserContorl.left" %>
<!--left1 start-->
<div id="left1">
    <div id="vertmenu">
        <h1>
            存储业务</h1>
        <ul>

            <li><a tabindex="1" href="/Creditor/CaseTypeList.aspx">档案分类管理</a></li>
            <li><a tabindex="2" href="/Creditor/CaseList.aspx">档案管理</a></li>
           <li><a tabindex="2" href="/Creditor/UploadCase.aspx">添加档案</a></li>

        </ul>
        <h1>
            债权业务</h1>
        <ul>
            <li><a tabindex="3" href="/Creditor/AddCreditInfo.aspx">发布债权信息</a></li>
            <li><a tabindex="4" href="/Creditor/DraftCreditList.aspx">债权草稿管理</a></li>
            <li><a tabindex="5" href="/Creditor/CreditInfoList.aspx">外包债权管理</a></li>
            <li id="liCredManage" runat="server"><a tabindex="6" href="/Creditor/DeparCreditList.aspx">
                部门债权管理</a> </li>
        </ul>
        <h1>
            抵债业务</h1>
        <ul>
            <li><a tabindex="7" href="/Creditor/AddForeclosed.aspx">发布抵债信息</a></li>
            <li><a tabindex="8" href="/Creditor/ForeclosedList.aspx">抵债信息管理</a></li>
            <li runat="server" id="liForeManage"><a tabindex="7" href="/Creditor/DeparForeclosedList.aspx">
                部门抵债管理</a></li>
        </ul>
        <h1>
            其他设置</h1>
        <ul>
            <li>
                <asp:HyperLink ID="hlInfo" runat="server" TabIndex="9">资料修改</asp:HyperLink>
            </li>
            <li runat="server" id="liPart"><a tabindex="10" href="/Creditor/PartList.aspx">部门管理</a></li>
            <li><a tabindex="11" href="/Creditor/ReceiveMessageList.aspx">站内信</a></li>
           <li><a tabindex="4" href="/Creditor/ModifyPwd.aspx">密码修改</a></li>
            <li><a tabindex="12" href="#" title="暂未开放">认证管理</a></li>
            <li><a tabindex="13" href="/Creditor/UpLoadPicture.aspx">头像修改</a></li></ul>
    </div>
</div>
<!--left2 start-->
<a href="#">
    <img src="/Other/images/ads1.jpg" width="158" style="border: 1px solid #ddd" /></a>
<!--left2 end-->
