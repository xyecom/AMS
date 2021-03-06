﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="menu.ascx.cs" Inherits="XYECOM.Web.Creditor.UserContorl.menu" %>
<div id="nav-menu">
    <div class="container">
        <div class="outerbox">
            <div class="innerbox clearfixmenu">
                <ul class="menu">
                    <li class="stmenu">
                        <h3>
                            <a class="xialaguang" href="/"><span>网站首页</span></a></h3>
                    </li>
                    <!--企业简介-->
                    <%--<li class="stmenu">
                        <h3>
                            <a class="xialaguang" href="#"><span>企业简介</span></a></h3>
                    </li>--%>
                    <!--外包债权-->
                    <li class="stmenu">
                        <h3>
                            <a class="xialaguang" href="#"><span>债权业务</span></a></h3>
                        <ul style="display: none" class="children clearfixmenu">
                            <li>
                                <h3>
                                    <a class="stmenu" href="#"><span>了解债权</span></a></h3>
                            </li>
                            <li class="noborder">
                                <h3>
                                    <a class="stmenu" href="#"><span>发布债权</span></a></h3>
                            </li>
                            <li>
                                <h3>
                                    <a href="#"><span>取消发布业务</span></a></h3>
                            </li>
                            <li class="noborder">
                                <h3>
                                    <a class="stmenu" href="#"><span>选择服务商</span></a></h3>
                            </li>
                            <li>
                                <h3>
                                    <a class="stmenu" href="#"><span>债权草稿箱</span></a></h3>
                            </li>
                            <li class="noborder">
                                <h3>
                                    <a class="stmenu" href="#"><span>已完成业务</span></a></h3>
                            </li>
                            <li>
                                <h3>
                                    <a class="stmenu" href="#"><span>已关闭业务</span></a></h3>
                            </li>
                            <li class="noborder">
                                <h3>
                                    <a class="stmenu" href="#"><span>进行中的任务</span></a></h3>
                            </li>
                            <li class="noborder">
                                <h3>
                                    <a class="stmenu" href="#"><span>草稿转外包</span></a></h3>
                            </li>
                            <li class="count noborder">
                                <div>
                                    通过这些菜单可以完成债权发布！</div>
                            </li>
                        </ul>
                    </li>
                    <!--存储业务-->
                    <li class="stmenu">
                        <h3>
                            <a class="xialaguang" href="#"><span>存储业务</span></a></h3>
                        <ul style="display: none" class="children clearfixmenu">
                            <li>
                                <h3>
                                    <a class="stmenu" href="#"><span>了解存储系统</span></a></h3>
                            </li>
                            <li class="noborder">
                                <h3>
                                    <a class="stmenu" href="#"><span>开始存储</span></a></h3>
                            </li>
                            <li class="count noborder">
                                <div>
                                    提供各存储业务</div>
                            </li>
                        </ul>
                    </li>
                    <!--服务商介绍-->
                    <li class="stmenu">
                        <h3>
                            <a class="xialaguang" href="#"><span>服务商</span></a></h3>
                        <ul style="display: none" class="children clearfixmenu">
                            <li>
                                <h3>
                                    <a class="stmenu" href="#"><span>优质服务商</span></a></h3>
                            </li>
                            <li class="noborder">
                                <h3>
                                    <a class="stmenu" href="#"><span>投标服务商</span></a></h3>
                            </li>
                            <li>
                                <h3>
                                    <a class="stmenu" href="#"><span>同地区服务商</span></a></h3>
                            </li>
                            <li class="count noborder">
                                <div>
                                    服务商展示平台</div>
                            </li>
                        </ul>
                    </li>
                    <!--抵债物品-->
                    <li class="stmenu">
                        <h3>
                            <a class="xialaguang" href="#"><span>抵债信息</span></a></h3>
                        <ul style="display: none" class="children clearfixmenu">
                            <li>
                                <h3>
                                    <a href="#"><span>如何发布抵债物品</span></a></h3>
                            </li>
                            <li class="noborder">
                                <h3>
                                    <a class="stmenu" href="#"><span>开始发布</span></a></h3>
                            </li>
                            <li>
                                <h3>
                                    <a class="stmenu" href="#"><span>已完成成交</span></a></h3>
                            </li>
                            <li class="noborder">
                                <h3>
                                    <a class="stmenu" href="#"><span>正在成交中</span></a></h3>
                            </li>
                            <li>
                                <h3>
                                    <a class="stmenu" href="#"><span>已关闭交易</span></a></h3>
                            </li>
                            <li class="noborder">
                                <h3>
                                    <a class="stmenu" href="#"><span>其他</span></a></h3>
                            </li>
                            <li class="count noborder">
                                <div>
                                    抵债物品变现</div>
                            </li>
                        </ul>
                    </li>
                    <!--企业下属部门-->
                    <li class="stmenu" runat="server" id="liPart">
                        <h3>
                            <a class="xialaguang" href="#"><span>下属部门</span></a></h3>
                        <asp:Repeater ID="rptPart" runat="server">
                            <HeaderTemplate>
                                <ul style="display: none" class="children clearfixmenu sleft">
                            </HeaderTemplate>
                            <ItemTemplate>
                                <li class="noborder">
                                    <h3>
                                        <a class="stmenu" href='<%# string.Format("/Creditor/EditPartInfo.aspx?ac=u&partid={0}",Eval("U_ID")) %>'>
                                            <span>
                                                <%# Eval("LayerName") %></span> </a>
                                    </h3>
                                </li>
                            </ItemTemplate>
                            <FooterTemplate>
                                </ul>
                            </FooterTemplate>
                        </asp:Repeater>
                    </li>
                    <!--信用评价-->
                    <li class="stmenu">
                        <h3>
                            <a class="xialaguang" href="/Creditor/Index.aspx"><span>个人中心</span></a></h3>
                    </li>
                    <li class="overlay"></li>
                </ul>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
    $(document).ready(function () {
        $('#nav-menu .menu > li').hover(function () {
            $(this).find('.children').animate({ opacity: 'show', height: 'show' }, 300);
            $(this).find('.xialaguang').addClass('navhover');
        }, function () {
            $('.children').stop(true, true).hide();
            $('.xialaguang').removeClass('navhover');
        }
).slice(-3, -1).find('.children').addClass('sleft');
    }); 
</script>
