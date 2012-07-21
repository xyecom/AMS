<%@ Page Title="" Language="C#" MasterPageFile="~/Creditor/Creditor.master" AutoEventWireup="true"
    CodeBehind="Index.aspx.cs" Inherits="XYECOM.Web.Creditor.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <div id="right">
        <!--rightmsg start-->
        <div id="rightmsg">
            <div id="msgimg">
                <img src="/Other/images/man.GIF"><br>
                <br>
                <a href="UpLoadPicture.aspx">修改头像</a>
            </div>
            <div id="line">
            </div>
            <div id="msgmain">
                <p>
                    <font>尊敬的&nbsp; </font><strong>华众物流</strong><font>，欢迎您！</font> <span style="padding-bottom: 10px;
                        padding-right: 10px; float: right">最近一次登录时间：2012-3-14 12:45</span></p>
                <p>
                </p>
                <table id="msgtb">
                    <tbody>
                        <tr>
                            <td width="60">
                                账号状态
                            </td>
                            <td width="128">
                                <img src="/Other/images/zhzt.gif">
                            </td>
                            <td width="100">
                                <a href="/Creditor/ModifyPwd.aspx">修改账户密码</a>
                            </td>
                            <td width="21">
                                <img src="/Other/images/sjyes.gif">
                            </td>
                            <td width="83">
                                手机已绑定
                            </td>
                            <td width="21">
                                <img src="/Other/images/yxno.gif">
                            </td>
                            <td width="113">
                                邮箱未验证
                            </td>
                        </tr>
                    </tbody>
                </table>
                <p>
                </p>
                <table id="msgtb2">
                    <tbody>
                        <tr>
                            <td>
                                存储文件：23条
                            </td>
                            <td>
                                外包债权：23条
                            </td>
                        </tr>
                        <tr>
                            <td>
                                债权草稿箱：23条
                            </td>
                            <td>
                                部门数量：6个
                            </td>
                        </tr>
                        <tr>
                            <td>
                                已收邮件数：24条
                            </td>
                            <td>
                                站内消息：通知/提醒（<a href="#"><font style="color: #f00">38</font></a>条）
                            </td>
                        </tr>
                    </tbody>
                </table>
                <p>
                    账号余额：￥454.00 <a href="#">充值</a> <a href="#">提现</a> <a href="#">收支明细</a></p>
            </div>
        </div>
        <!--rightmsg end-->
        <!--rightzqlist start-->
        <div id="rightzqlist">
            <h2>
                正在进行中的案件</h2>
            <div class="rhr">
            </div>
            <!--列表 start-->
            <div id="list">
                <table>
                    <tbody>
                        <tr id="trtop">
                            <td width="40%" align="middle">
                                案件标题
                            </td>
                            <td width="20%" align="middle">
                                发布时间
                            </td>
                            <td width="15%" align="middle">
                                付款状态
                            </td>
                            <td width="25%" align="middle">
                                操作菜单
                            </td>
                        </tr>
                        <tr style="height: 28px; border-top: #ccc 1px solid" id="trmidd" onmousemove="this.style.backgroundColor='#F7F7F7'"
                            onmouseout="this.style.backgroundColor='#ffffff'">
                            <td id="tdtitle">
                                <a title="与xxx企业的业务往来" href="#">与xxx企业的业务往来</a>
                            </td>
                            <td>
                                2012-02-12
                            </td>
                            <td>
                                【已付款】
                            </td>
                            <td>
                                <a href="#">详情</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href="#">删除</a>
                            </td>
                        </tr>
                        <tr style="height: 28px; border-top: #ccc 1px solid" id="trmidd" onmousemove="this.style.backgroundColor='#F7F7F7'"
                            onmouseout="this.style.backgroundColor='#ffffff'">
                            <td id="tdtitle">
                                <a title="李长春视察珠海产业园：三一是具有国际影响力的品牌" href="#">李长春视察珠海产业园：三一是具有国际影响力的品牌</a>
                            </td>
                            <td>
                                2012-02-12
                            </td>
                            <td>
                                【已付款】
                            </td>
                            <td>
                                <a href="#">详情</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href="#">删除</a>
                            </td>
                        </tr>
                        <tr style="height: 28px; border-top: #ccc 1px solid" id="trmidd" onmousemove="this.style.backgroundColor='#F7F7F7'"
                            onmouseout="this.style.backgroundColor='#ffffff'">
                            <td id="tdtitle">
                                <a title="梁稳根成中国双料“首富”" href="#">梁稳根成中国双料“首富”</a>
                            </td>
                            <td>
                                2012-02-12
                            </td>
                            <td>
                                【已付款】
                            </td>
                            <td>
                                <a href="#">详情</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href="#">删除</a>
                            </td>
                        </tr>
                        <tr style="height: 28px; border-top: #ccc 1px solid" id="trmidd" onmousemove="this.style.backgroundColor='#F7F7F7'"
                            onmouseout="this.style.backgroundColor='#ffffff'">
                            <td id="tdtitle">
                                <a title="依托过渡基地 三一海洋重工加速跑 20余台大港机实现交付" href="#">依托过渡基地 三一海洋重工加速跑 20余台大港机··· </a>
                            </td>
                            <td>
                                2012-02-12
                            </td>
                            <td>
                                【已付款】
                            </td>
                            <td>
                                <a href="#">详情</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href="#">删除</a>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <!--列表 end-->
        </div>
        <!--rightzqlist end-->
        <!--rightdzwplist start-->
        <div id="rightdzwplist">
            <h2>
                发布中的抵债物品</h2>
            <div class="rhr">
            </div>
            <table id="dztb">
                <tbody>
                    <tr>
                        <td>
                            <img src="/Other/images/left1.gif">
                            <p>
                                <strong>新建复式楼</strong><br>
                            </p>
                            <p>
                                <font>物品底价：￥12,123.00</font></p>
                            <p>
                                <font>承接人数：6人</font></p>
                            <p>
                                <a href="#">查看详情&gt;&gt;</a></p>
                        </td>
                        <td>
                            <img src="/Other/images/left1.gif" />
                            <p>
                                <strong>新建复式楼</strong><br />
                            </p>
                            <p>
                                <font>物品底价：￥12,123.00</font></p>
                            <p>
                                <font>承接人数：6人</font></p>
                            <p>
                                <a href="#">查看详情&gt;&gt;</a></p>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <!--rightdzwplist end-->
    </div>
</asp:Content>
