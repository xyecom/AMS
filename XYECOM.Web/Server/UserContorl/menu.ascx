<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="menu.ascx.cs" Inherits="XYECOM.Web.Server.UserContorl.menu" %>
<div id="nav-menu">
    <div class="container">
        <div class="outerbox">
            <div class="innerbox clearfixmenu">
                <ul class="menu">
                    <li class="stmenu">
                        <h3>
                            <a class="xialaguang" href="#"><span>网站首页</span></a></h3>
                    </li>
                    <li class="stmenu">
                        <h3>
                            <a href="#" class="xialaguang"><span>债权资讯</span></a>
                        </h3>
                    </li>
                    <li class="stmenu">
                        <h3>
                            <a href="#" class="xialaguang"><span>优质服务商</span></a></h3>
                    </li>
                    <li class="stmenu">
                        <h3>
                            <a href="#" class="xialaguang"><span>抵债物品资讯</span></a></h3>
                    </li>
                    <li class="stmenu">
                        <h3>
                            <a href="#" class="xialaguang"><span>在线服务</span></a></h3>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
    $(document).ready(function () {
        $('#nav-menu .menu > li').hover(function () {            
            $(this).find('.xialaguang').addClass('navhover');
        }, function () {            
            $('.xialaguang').removeClass('navhover');
        }
).slice(-3, -1).find('.children').addClass('sleft');
    });    
</script>