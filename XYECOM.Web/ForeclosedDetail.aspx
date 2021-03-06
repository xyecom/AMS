﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Fore.Master" AutoEventWireup="true"
    CodeBehind="ForeclosedDetail.aspx.cs" Inherits="XYECOM.Web.ForeclosedDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Other/js/FancyZoom.js" type="text/javascript"></script>
    <script src="Other/js/FancyZoomHTML.js" type="text/javascript"></script>

    <title>抵债<asp:Literal runat="server" ID="litTitle"></asp:Literal>信息</title>
    <script type="text/javascript" language="javascript">
        function ShowNo()                        //隐藏两个层 
        {
            document.getElementById("doing").style.display = "none";
            document.getElementById("divcj").style.display = "none";
        }
        function $(id) {
            return (document.getElementById) ? document.getElementById(id) : document.all[id];
        }
        function showFloat()                    //根据屏幕的大小显示两个层 
        {
            var range = getRange();
            $('doing').style.width = range.width + "px";
            $('doing').style.height = range.height + "px";
            $('doing').style.display = "block";
            document.getElementById("divcj").style.display = "";
        }
        function getRange()                      //得到屏幕的大小 
        {
            var top = document.body.scrollTop;
            var left = document.body.scrollLeft;
            var height = document.body.clientHeight;
            var width = document.body.clientWidth;

            if (top == 0 && left == 0 && height == 0 && width == 0) {
                top = document.documentElement.scrollTop;
                left = document.documentElement.scrollLeft;
                height = document.documentElement.clientHeight;
                width = document.documentElement.clientWidth;
            }
            return { top: top, left: left, height: height, width: width };
        } 
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <!--left开始-->
        <div id="left">
            <div style="height: auto; width: 721px;">
                <div id="rightdzmain">
                    <h2>
                        抵债物品详情</h2>
                    <div class="rhr">
                    </div>
                    <!--基本信息 start-->
                    <div id="dzbase">
                        【物品基本信息】
                        <hr />
                        <table class="dzbasetb">
                            <tr>
                                <td>
                                    发布者：
                                </td>
                                <td colspan="3">
                                    <a runat="server" id="aShow" target="_blank" alt="点击发布者可查看其信用度">
                                        <asp:Label runat="server" ID="labUserName"></asp:Label></a>
                                </td>
                            </tr>
                            <tr>
                                <td class="info1">
                                    物品名称：
                                </td>
                                <td>
                                    <asp:Label ID="labTitle" runat="server"></asp:Label>
                                </td>
                                <td class="info1">
                                    拍卖底价：
                                </td>
                                <td>
                                    <asp:Label ID="labLinePrice" runat="server"></asp:Label>元
                                </td>
                            </tr>
                            <tr>
                                <td class="info1">
                                    物品编号：
                                </td>
                                <td>
                                    <asp:Label ID="labIdentityNumber" runat="server"></asp:Label>
                                </td>
                                <td class="info1">
                                    目前最高出价：
                                </td>
                                <td>
                                    <asp:Label ID="labHighPrice" runat="server"></asp:Label>元
                                </td>
                            </tr>
                            <tr>
                                <td class="info1">
                                    物品所属地区：
                                </td>
                                <td colspan="3">
                                    <asp:Label ID="labAreid" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="info1">
                                    物品详细地址：
                                </td>
                                <td colspan="3">
                                    <asp:Label ID="labAddress" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="info1">
                                    物品详细描述：
                                </td>
                                <td colspan="3">
                                    <asp:Label runat="server" ID="labDescription"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="info1">
                                    结束竞拍时间：
                                </td>
                                <td colspan="3">
                                    <asp:Label ID="labEndDate" runat="server" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <input type="hidden" id="hidId" runat="server" />
                        【物品相关图片】
                        <hr />
                            <div id="dzbasepic">

                            <asp:Repeater runat="server" ID="rpPrice">
                                <ItemTemplate>
                                 <a href="/Upload/<%# Eval("At_Path") %>" target="_blank">  
                                   <img width="96px;" src='/Upload/<%# Eval("At_Path") %>' />
                                   </a>
                                </ItemTemplate>
                            </asp:Repeater>
                     </div>
                        【物品竞价信息】
                        <hr />
                        <div class="basetbjj">
                                   <table>  
                                     <tr id="trtop">
                                            <td align="center" width="10%">
                                                出价(元)
                                            </td>
                                            <td align="center" width="15%">
                                                出价时间
                                            </td>
                                            <td align="center" width="15%">
                                                来自地区
                                            </td>
                                            <td align="center" width="15%">
                                                买家联系方式
                                            </td>
                                            <td align="center" width="35%">
                                                留言
                                            </td>
                                            <td align="center" width="10%">
                                                目前状态
                                            </td>
                                        </tr>
                                        <asp:Repeater ID="rptList" runat="server">
                                <ItemTemplate>
                                    <tr style="height: 22px; text-align: center;" onmousemove="this.style.backgroundColor='#F7F7F7'"
                                        onmouseout="this.style.backgroundColor='#ffffff'">
                                        <td>
                                            <%# Eval("Price")%>
                                        </td>
                                        <td>
                                            <%# Eval("PriceDate", "{0:yyyy-MM-dd}")%>
                                        </td>
                                        <td>
                                            <%# Eval("FromAddress")%>
                                        </td>
                                        <td>
                                            <%# GetContact(Eval("Contact").ToString())%>
                                        </td>
                                        <td>
                                            <%# Eval("Remark")%>
                                        </td>
                                        <td>
                                            <img src="/Common/images/okhank.gif" />领先
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                         
                            <asp:Repeater ID="rpChuJu" runat="server">
                                <ItemTemplate>
                                    <tr style="height: 22px; text-align: center;" onmousemove="this.style.backgroundColor='#F7F7F7'"
                                        onmouseout="this.style.backgroundColor='#ffffff'">
                                        <td>
                                            <%# Eval("Price")%>
                                        </td>
                                        <td>
                                            <%# Eval("PriceDate", "{0:yyyy-MM-dd}")%>
                                        </td>
                                        <td>
                                            <%# Eval("FromAddress")%>
                                        </td>
                                        <td>
                                            <%# GetContact(Eval("Contact").ToString())%>
                                        </td>
                                        <td>
                                            <%# Eval("Remark")%>
                                        </td>
                                        <td>
                                            <img alt="" src="/Common/images/cj.gif" />出局
                                        </td>
                                    </tr>
                                </ItemTemplate>
                               </asp:Repeater>
                                    </table>
                           
                            <div style="height: 30px;">
                                <div align="center">
                                    <XYECOM:Page ID="Page1" runat="server" PageSize="20" OnPageChanged="Page1_PageChanged" />
                                </div>
                            </div>
                            <div>
                                <p style="text-align: center;">
                                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label></p>
                            </div>


        <div style="width: 656px; height: 25px; line-height: 25px; text-align:center; margin: 10px">
  
             <input type="button" value="我要报价" onclick="showFloat()" style="background: url(/Other/images/yes.gif);
                        color: Black;   width: 80px; height: 25px; border: none; cursor: pointer; color: #FFF" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <a href="Index.aspx"><strong style="color:Red">返回首页</strong></a>

            </div> 

     <div style="width:700px; padding-left:30px; height:60px">                      
<!-- Baidu Button BEGIN -->
    <div id="bdshare" class="bdshare_b" style="line-height: 12px;"><img src="http://bdimg.share.baidu.com/static/images/type-button-5.jpg" />
		<a class="shareCount"></a>
	</div>
<script type="text/javascript" id="bdshare_js" data="type=button&amp;uid=251453" ></script>
<script type="text/javascript" id="bdshell_js"></script>
<script type="text/javascript">
    document.getElementById("bdshell_js").src = "http://bdimg.share.baidu.com/static/js/shell_v2.js?cdnversion=" + new Date().getHours();
</script>
<!-- Baidu Button END -->
 </div>                    
                            <!--加一个半透明层-->
                            <div id="doing" style="filter: alpha(opacity=30); -moz-opacity: 0.3; opacity: 0.3;
                                background-color: #000; width: 100%; height: 100%; z-index: 800; position: absolute;
                                left: 0; top: 0; display: none; overflow: hidden;">
                            </div>
                            <!--加一个层-->
                            <div id="divcj" style="border: solid 10px #898989; background: #fff; padding: 10px;
                                width: 630px; z-index: 800; position: absolute; display: none; top: 50%; left: 50%;
                                margin: 100px 0 0 -300px;">
                                <div style="padding: 3px 15px 3px 15px; text-align: center; vertical-align: middle;">
                                    <div style="margin: 8px 10px; font-size: 13px; color: #f00">
                                        * 注意：请认真填写您的相关资料！
                                    </div>
<table style=" width:610px; text-align:left">
<tr>
<td style="width:80px">姓名：</td > <td style="width:540px"> <asp:TextBox runat="server" ID="txtName" Width="300px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="txtName" ErrorMessage="姓名不能为空" Font-Size="9pt" 
        ForeColor="Red"></asp:RequiredFieldValidator></td>
</tr>
<tr>
<td style="width:80px">手机号码：</td><td style="width:540px">  <asp:TextBox runat="server" ID="txtContact" Width="300px"></asp:TextBox> 
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtContact"
                                            ErrorMessage="手机号码格式不正确" 
        ValidationExpression="\s*((\d{2,3}-){0,1}\d{11})\s*"  Font-Size="9pt" 
        ForeColor="Red"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtContact"
                                            ErrorMessage="手机号码不能为空"  Font-Size="9pt" 
        ForeColor="Red"></asp:RequiredFieldValidator></td>
</tr>
<tr>
<td style="width:80px">地址：</td> <td style="width:540px">    <asp:TextBox runat="server" ID="txtAddress" Width="300px"></asp:TextBox></td>
</tr>

<tr>
<td style="width:80px">出价：</td> <td style="width:540px">           <asp:TextBox runat="server" ID="txtPrice" Width="300px"></asp:TextBox>元<asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPrice" ErrorMessage="报价不能为空"  Font-Size="9pt" 
        ForeColor="Red"></asp:RequiredFieldValidator></td>
</tr>

<tr>
<td style="width:80px">留言：</td> <td style="width:540px">  <asp:TextBox runat="server" ID="txtRemark" Width="300px" TextMode="MultiLine" Rows="10"></asp:TextBox></td>
</tr>
</table>

                                    <br />
                                   
                                    <div>
  <asp:Button ID="btnOK" runat="server" Text="确 定"  style=" background:url(/Other/images/ok.gif); width:95px; height:38px; border:none; cursor:pointer; font-size:13px;" 
                        onclick="btnOK_Click"/>&nbsp; &nbsp; 
                    <input id="BttCancel" type="button" value=" 取 消 " onclick="ShowNo()" style=" background:url(/Other/images/quit.gif); width:95px; height:41px; border:none; cursor:pointer; font-size:13px;"/> 

                                    
                                    </div>
                                </div>
                            </div>
                            <!--半透明层结束-->
                        </div>
                    </div>
                    <!--基本信息 end-->
                </div>
            </div>
        </div>
        <!--left结束-->
    </div>
</asp:Content>
