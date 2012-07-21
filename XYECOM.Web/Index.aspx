<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="XYECOM.Web.Index1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>首页</title>    
    <script language="javascript" type="text/javascript" src="/Common/js/base.js"></script>
    <link href="/Other/css/vipnew_home_20110412.css" rel="stylesheet" type="text/css" />
    <link href="/Other/css/style.css" rel="stylesheet" type="text/css" />
    <script src="/Other/js/zu.js" type="text/javascript"></script>
    <script src="/Other/js/update8.js" type="text/javascript"></script>
    <style type="text/css">
        .btnok
        {
            background: url(/Other/images/yes.gif);
            width: 80px;
            height: 25px;
            border: none;
            cursor: pointer;
            color: #FFF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="all">
        <!--头部开始-->
        <div id="header">
            <div class="logo">
            </div>
            <div class="logoright" style="width: 250px">
                <a href="#">设为首页</a>&nbsp; |&nbsp; <a href="#">加入收藏</a>&nbsp;|&nbsp; <a href="/Login.aspx">
                    登陆</a>&nbsp;|&nbsp;<a href="/Register.aspx">注册</a>
            </div>
            <div id="menu" style="float: left;">
                <ul>
                    <li class='m_li_a' id="m_1"><a href="#">网站首页</a></li>
                    <li class="m_line">
                        <img src="/Other/images/line1.gif" /></li>
                    <li class='m_li' id="m_2" onmouseover='mover(2);' onmouseout='mout(2);'><a href="#">
                        债权资讯</a></li>
                    <li class="m_line">
                        <img src="/Other/images/line1.gif" /></li>
                    <li class='m_li' id="m_3" onmouseover='mover(3);' onmouseout='mout(3);'><a href="#">
                        优质服务商</a></li>
                    <li class="m_line">
                        <img src="/Other/images/line1.gif" /></li>
                    <li class='m_li' id="m_4" onmouseover='mover(4);' onmouseout='mout(4);'><a href="#">
                        抵债物品资讯</a></li>
                    <li class="m_line">
                        <img src="/Other/images/line1.gif" /></li>
                    <li class='m_li' id="m_5" onmouseover='mover(5);' onmouseout='mout(5);'><a href="#">
                        在线服务</a></li>
                </ul>
            </div>
        </div>
        <!--头部结束-->
        <!--中间开始-->
        <div id="middle">
            <!--left开始-->
            <div id="left">
                <!--left1开始-->
                <div id="left1">
                    <div id="fader">
                        <ul>
                            <li>
                                <img src="/Other/images/1.gif" alt="债权管理方案"></li>
                            <li>
                                <img src="/Other/images/2.gif" alt="抵债管理方案"></li>
                            <li>
                                <img src="/Other/images/3.gif" alt="优质服务"></li>
                        </ul>
                    </div>
                    <script type="text/javascript">
                        var fader = new Hongru.fader.init('fader', {
                            id: 'fader'
                        });
                    </script>
                </div>
                <!--left1结束-->
                <!--left2开始-->
                <div id="left2">
                    <ul>
                        <li><a href="javascript:void(0)">如何注册</a></li>
                        <li><a href="javascript:void(0)">如何存储</a></li>
                        <li><a href="javascript:void(0)">如何发布</a></li>
                        <li><a href="javascript:void(0)">如何投标</a></li>
                        <li><a href="javascript:void(0)">成交成功</a></li>
                        <li><a href="javascript:void(0)">快速注册</a></li>
                        <li><a href="javascript:void(0)">开始存储</a></li>
                        <li><a href="javascript:void(0)">开始发布</a></li>
                        <li><a href="javascript:void(0)">开始投标</a></li>
                        <li><a href="javascript:void(0)">获取佣金</a></li>
                    </ul>
                </div>
                <!--left2结束-->
                <!-- left3开始-->
                <div id="left3">
                    <div style="background: url('/Other/images/erji_titlebg.gif'); background-repeat: repeat-x;
                        height: auto; overflow: hidden;">
                        <div style="width: 100px; line-height: 38px; margin-left: 55px; float: left; font-size: 14px">
                            <strong>债权资讯</strong></div>
                        <div style="width: 514px; float: right; height: 40px; line-height: 35px; text-align: center">
                            <table width="512" style="height: 31px; width: 480px; float: left">
                                <tr>
                                    <td width="50">
                                        标的额
                                    </td>
                                    <td width="92">
                                        <select id="Select1">
                                            <option>1万以下</option>
                                            <option>10~50万</option>
                                        </select>
                                    </td>
                                    <td width="39">
                                        地区
                                    </td>
                                    <td width="76">
                                        <select id="Select2">
                                            <option>陕西</option>
                                            <option>湖南</option>
                                        </select>
                                    </td>
                                    <td width="92">
                                        <input name="搜索" type="button" value="搜索" style="background: url(/Other/images/yes.gif);
                                            width: 80px; height: 25px; border: none; cursor: pointer; color: #FFF" />
                                    </td>
                                    <td width="44">
                                        <a href="/IndexCreditList.aspx">更多>></a>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <table id="zqlist1">
                        <tr>
                            <td height="23" class="tdtitle">
                                债权标题
                            </td>
                            <td class="tdprice">
                                标的金额
                            </td>
                            <td class="tdarea">
                                所在地区
                            </td>
                            <td class="tdtime">
                                发布时间
                            </td>
                            <td class="tdnumber">
                                投标人数
                            </td>
                        </tr>
                    </table>
                    <table width="702" id="zqtj">
                        <tr>
                            <td class="tdtitle">
                                <img src="/Other/images/jian.gif" /><a href="#">与xxx企业的业务往来</a>
                            </td>
                            <td class="tdprice">
                                12，234.00
                            </td>
                            <td class="tdarea">
                                陕西·西安
                            </td>
                            <td class="tdtime">
                                2012-6-10
                            </td>
                            <td class="tdnumber">
                                4
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtitle">
                                <img src="/Other/images/jian.gif" /><a href="#">与xxx企业的业务往来</a>
                            </td>
                            <td class="tdprice">
                                12，234.00
                            </td>
                            <td class="tdarea">
                                陕西·西安
                            </td>
                            <td class="tdtime">
                                2012-6-10
                            </td>
                            <td class="tdnumber">
                                4
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtitle">
                                <img src="/Other/images/jian.gif" /><a href="#">与xxx企业的业务往来</a>
                            </td>
                            <td class="tdprice">
                                12，234.00
                            </td>
                            <td class="tdarea">
                                陕西·西安
                            </td>
                            <td class="tdtime">
                                2012-6-10
                            </td>
                            <td class="tdnumber">
                                4
                            </td>
                        </tr>
                    </table>
                    <div class="box" id="marqueebox1">
                        <table id="zqlist2">
                            <tr>
                                <td class="tdtitle">
                                    <a href="#">与xxx企业的业务往来</a>
                                </td>
                                <td class="tdprice">
                                    12，234.00
                                </td>
                                <td class="tdarea">
                                    陕西·西安
                                </td>
                                <td class="tdtime">
                                    2012-6-10
                                </td>
                                <td class="tdnumber">
                                    4
                                </td>
                            </tr>
                            <tr>
                                <td class="tdtitle">
                                    <a href="#">与xxx企业的业务往来</a>
                                </td>
                                <td class="tdprice">
                                    12，234.00
                                </td>
                                <td class="tdarea">
                                    陕西·西安
                                </td>
                                <td class="tdtime">
                                    2012-6-10
                                </td>
                                <td class="tdnumber">
                                    4
                                </td>
                            </tr>
                            <tr>
                                <td class="tdtitle">
                                    <a href="#">与xxx企业的业务往来</a>
                                </td>
                                <td class="tdprice">
                                    12，234.00
                                </td>
                                <td class="tdarea">
                                    陕西·西安
                                </td>
                                <td class="tdtime">
                                    2012-6-10
                                </td>
                                <td class="tdnumber">
                                    4
                                </td>
                            </tr>
                            <tr>
                                <td class="tdtitle">
                                    <a href="#">与xxx企业的业务往来</a>
                                </td>
                                <td class="tdprice">
                                    12，234.00
                                </td>
                                <td class="tdarea">
                                    陕西·西安
                                </td>
                                <td class="tdtime">
                                    2012-6-10
                                </td>
                                <td class="tdnumber">
                                    4
                                </td>
                            </tr>
                            <tr>
                                <td class="tdtitle">
                                    <a href="#">与xxx企业的业务往来</a>
                                </td>
                                <td class="tdprice">
                                    12，234.00
                                </td>
                                <td class="tdarea">
                                    陕西·西安
                                </td>
                                <td class="tdtime">
                                    2012-6-10
                                </td>
                                <td class="tdnumber">
                                    4
                                </td>
                            </tr>
                            <tr>
                                <td class="tdtitle">
                                    <a href="#">与xxx企业的业务往来</a>
                                </td>
                                <td class="tdprice">
                                    12，234.00
                                </td>
                                <td class="tdarea">
                                    陕西·西安
                                </td>
                                <td class="tdtime">
                                    2012-6-10
                                </td>
                                <td class="tdnumber">
                                    4
                                </td>
                            </tr>
                            <tr>
                                <td class="tdtitle">
                                    <a href="#">与xxx企业的业务往来</a>
                                </td>
                                <td class="tdprice">
                                    12，234.00
                                </td>
                                <td class="tdarea">
                                    陕西·西安
                                </td>
                                <td class="tdtime">
                                    2012-6-10
                                </td>
                                <td class="tdnumber">
                                    4
                                </td>
                            </tr>
                            <tr>
                                <td class="tdtitle">
                                    <a href="#">与xxx企业的业务往来</a>
                                </td>
                                <td class="tdprice">
                                    12，234.00
                                </td>
                                <td class="tdarea">
                                    陕西·西安
                                </td>
                                <td class="tdtime">
                                    2012-6-10
                                </td>
                                <td class="tdnumber">
                                    4
                                </td>
                            </tr>
                            <tr>
                                <td class="tdtitle">
                                    <a href="#">与xxx企业的业务往来</a>
                                </td>
                                <td class="tdprice">
                                    12，234.00
                                </td>
                                <td class="tdarea">
                                    陕西·西安
                                </td>
                                <td class="tdtime">
                                    2012-6-10
                                </td>
                                <td class="tdnumber">
                                    4
                                </td>
                            </tr>
                            <tr>
                                <td class="tdtitle">
                                    <a href="#">与xxx企业的业务往来</a>
                                </td>
                                <td class="tdprice">
                                    12，234.00
                                </td>
                                <td class="tdarea">
                                    陕西·西安
                                </td>
                                <td class="tdtime">
                                    2012-6-10
                                </td>
                                <td class="tdnumber">
                                    4
                                </td>
                            </tr>
                            <tr>
                                <td class="tdtitle">
                                    <a href="#">与xxx企业的业务往来</a>
                                </td>
                                <td class="tdprice">
                                    12，234.00
                                </td>
                                <td class="tdarea">
                                    陕西·西安
                                </td>
                                <td class="tdtime">
                                    2012-6-10
                                </td>
                                <td class="tdnumber">
                                    4
                                </td>
                            </tr>
                            <tr>
                                <td class="tdtitle">
                                    <a href="#">与xxx企业的业务往来</a>
                                </td>
                                <td class="tdprice">
                                    12，234.00
                                </td>
                                <td class="tdarea">
                                    陕西·西安
                                </td>
                                <td class="tdtime">
                                    2012-6-10
                                </td>
                                <td class="tdnumber">
                                    4
                                </td>
                            </tr>
                            <tr>
                                <td class="tdtitle">
                                    <a href="#">与xxx企业的业务往来</a>
                                </td>
                                <td class="tdprice">
                                    12，234.00
                                </td>
                                <td class="tdarea">
                                    陕西·西安
                                </td>
                                <td class="tdtime">
                                    2012-6-10
                                </td>
                                <td class="tdnumber">
                                    4
                                </td>
                            </tr>
                        </table>
                    </div>
                    <script type="text/javascript">
                        function startmarquee(lh, speed, delay, index) {
                            var t;
                            var p = false;
                            var o = document.getElementById("marqueebox" + index);
                            o.innerHTML += o.innerHTML;
                            o.onmouseover = function () { p = true }
                            o.onmouseout = function () { p = false }
                            o.scrollTop = 0;
                            function start() {
                                t = setInterval(scrolling, speed);
                                if (!p) { o.scrollTop += 1; }
                            }
                            function scrolling() {
                                if (o.scrollTop % lh != 0) {
                                    o.scrollTop += 1;
                                    if (o.scrollTop >= o.scrollHeight / 2) o.scrollTop = 0;
                                } else {
                                    clearInterval(t);
                                    setTimeout(start, delay);
                                }
                            }
                            setTimeout(start, delay);
                        }
                        startmarquee(25, 40, 0, 1);
                    </script>
                </div>
                <!--left3 结束-->
                <!--left4开始-->
                <div id="left4">
                    <div style="background: url('/Other/images/erji_titlebg.gif'); background-repeat: repeat-x;
                        height: auto; overflow: hidden;">
                        <div style="width: 100px; line-height: 38px; margin-left: 55px; float: left; font-size: 14px">
                            <strong>抵债物品资讯</strong></div>
                        <div style="width: 514px; float: right; height: 40px; text-align: center">
                            <table style="height: 31px; width: 514px;">
                                <tr>
                                    <td width="65">
                                        物品类型
                                    </td>
                                    <td width="113">
                                        <asp:DropDownList runat="server" ID="droTypeName">
                                            <asp:ListItem Value="所有" Text="--所有--"></asp:ListItem>
                                            <asp:ListItem Value="房屋" Text="房屋"></asp:ListItem>
                                            <asp:ListItem Value="汽车" Text="汽车"></asp:ListItem>
                                            <asp:ListItem Value="金条" Text="金条"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td width="29">
                                        地区
                                    </td>
                                    <td width="80">
                                        <div id="divarea">
                                        </div>
                                        <input type="hidden" id="city" name="city" runat="server" />
                                        <script type="text/javascript">

                                            var claarea = new ClassType("claarea", 'area', 'divarea', 'city', 1);
                                            claarea.Mode = "select";
                                            claarea.Init();
                                        </script>
                                    </td>
                                    <td width="123">
                                        <asp:Button runat="server" ID="btnSearch" OnClick="btnSearch_Click" CssClass="btnok"
                                            Text="搜索" />
                                    </td>
                                    <td width="42">
                                        <a href="#">更多>></a>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div style="height: auto; width: 721px;">
                        <asp:DataList ID="dlForeclosed" runat="server" RepeatColumns="2" RepeatDirection="Horizontal"
                            Width="100%">
                            <HeaderTemplate>
                                <dl>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <dd>
                                    <img src='<%# GetInfoImgHref(Eval("ForeclosedId")) %>' />
                                    <p>
                                        <strong>
                                            <%#Eval("Title") %></strong><br />
                                    </p>
                                    <p>
                                        <font>物品底价：<%# Eval("LinePrice")%>元</font></p>
                                    <p>
                                        <font>物品所在地：<%# GetAreaIdFull(Eval("AreaId"))%></font></p>
                                    <p>
                                        <font>竞价结束时间：<%# GetEndDate(Eval("EndDate"))%></font></p>
                                    <p>
                                        <a href='ForeclosedDetail.aspx?Id=<%# Eval("ForeclosedId") %>'>查看详情>></a></p>
                                </dd>
                            </ItemTemplate>
                            <FooterTemplate>
                                </dl></FooterTemplate>
                        </asp:DataList>
                        <div style="width: 705px; height: 30px; line-height: 30px; text-align: center">
                            <XYECOM:Page ID="Page1" runat="server" PageSize="20" OnPageChanged="Page1_PageChanged" />
                        </div>
                        <div>
                            <p style="text-align: center;">
                                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label></p>
                        </div>
                    </div>
                </div>
                <!--left4结束-->
            </div>
            <!--left结束-->
            <!--right开始-->
            <div id="right">
                <!--right1开始-->
                <div id="right1">
                    <strong style="margin-left: 20px;">快速了解包青天</strong>
                    <div class="qul">
                        <ul>
                            <li><font>【新手攻略】</font><a href="#"> 债权人如何对外发布债权信息</a></li>
                            <li><font>【新手攻略】</font><a href="#"> 债权人如何使用存储系统</a></li>
                            <li><font>【常见问题】</font><a href="#"> 企业总账号如何管理部门</a></li>
                            <li><font>【常见问题】</font><a href="#"> 如何承接抵债物品</a></li>
                            <li><font>【安全须知】</font><a href="#"> 发布债权信息须知</a></li>
                            <li><font>【常见问题】</font><a href="#"> 债权人如何对外发布债权信息</a></li>
                            <li><font>【常见问题】</font><a href="#"> 债权人如何对外发布债权信息</a></li>
                        </ul>
                    </div>
                </div>
                <!--right1结束-->
                <!--right2开始-->
                <div id="right2">
                    <strong style="margin-left: 20px;">企业纪事</strong>
                    <div class="qul">
                        <ul>
                            <li><font>【2011年3月】</font> 公司策划开始···</li>
                            <li><font>【2011年3月】</font> 公司策划开始···</li>
                            <li><font>【2011年3月】</font> 公司策划开始···</li>
                            <li><font>【2011年3月】</font> 公司策划开始···</li>
                            <li><font>【2011年3月】</font> 公司策划开始···</li>
                        </ul>
                    </div>
                </div>
                <!--right2结束-->
                <!--right3开始-->
                <div id="right3">
                    <img src="/Other/images/1212.gif" />
                </div>
                <!--right3结束-->
                <!--right4开始-->
                <div id="right4">
                    <strong style="margin-left: 20px; height: 35px; line-height: 35px;">媒体报道</strong>
                    <div style="margin: 2px 10px">
                        <img src="/Other/images/cctv.gif" style="float: l" /><img src="/Other/images/zk.jpg" /></div>
                    <div class="qul">
                        <ul>
                            <li><font>【陕西电视台】</font> "包青天"为数万债权人···</li>
                            <li><font>【山西日报】</font> 律师的集结地</li>
                            <li><font>【湖南卫视】</font> "包青天"为数万债权人···</li>
                            <li><font>【重庆时报】</font> 律师的集结地···</li>
                        </ul>
                    </div>
                </div>
                <!--right4结束-->
            </div>
            <!--right结束-->
        </div>
        <!--中间结束-->
        <!--bottom开始-->
        <div id="bottom">
            <div style="width: 1000px; height: 150px;">
                <ul>
                    <li><strong>新手上路</strong></li>
                    <li><a href="#">了解本网</a></li>
                    <li><a href="#">注册债权人</a></li>
                    <li><a href="#">注册服务商</a></li>
                    <li><a href="#">帮助中心</a></li>
                </ul>
                <ul>
                    <li><strong>交易指南</strong></li>
                    <li><a href="#">如何发布债权</a></li>
                    <li><a href="#">如何获取佣金</a></li>
                    <li><a href="#">交易安全</a></li>
                    <li><a href="#">服务中心</a></li>
                </ul>
                <ul>
                    <li><strong>交易保障</strong></li>
                    <li><a href="#">担保交易</a></li>
                    <li><a href="#">诚信保障服务</a></li>
                    <li><a href="#">提供发票</a></li>
                    <li><a href="#">全假信息识别</a></li>
                </ul>
                <ul>
                    <li><strong>支付方式</strong></li>
                    <li><a href="#">网银支付</a></li>
                    <li><a href="#">银行柜台支付</a></li>
                    <li><a href="#">支付宝担保交易</a></li>
                    <li><a href="#">账户余额支付</a></li>
                </ul>
                <div style="height: 90px; margin-left: 800px; margin: 20px 10px;">
                    <img src="/Other/images/tel.gif" /><strong style="font-size: 18px; color: #f00">400-100-1010</strong>
                </div>
            </div>
        </div>
        <!--bottom结束-->
        <!--footer开始-->
        <div id="footer">
            <div style="height: 50px; text-align: center">
                <table>
                    <tr>
                        <td>
                            <img src="/Other/images/11.gif" />
                        </td>
                        <td>
                            <font>不跨区·享案源</font>
                        </td>
                        <td>
                            <img src="/Other/images/22.gif" />
                        </td>
                        <td>
                            <font>大商品·低价卖</font>
                        </td>
                        <td>
                            <img src="/Other/images/33.gif" />
                        </td>
                        <td>
                            <font>多方案·优服务</font>
                        </td>
                    </tr>
                </table>
            </div>
            <p>
                <a href="">网站地图</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a href="">关于我们</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a
                    href="">合作洽谈</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a href="">客户手册</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a
                        href="">客服中心</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a href="">加入我们</a></p>
            <p>
                网站24小时服务热线：400-100-1010 传真：029-12345678 地址：陕西省西安市高新园区一号大厦3楼</p>
            <p>
                Copyright 2005-2011 baoqt.cn 版权所有 <a href="#" target="_blank">陕ICP备10202274号</a></p>
        </div>
        <!--footer结束-->
    </div>
    </form>
</body>
</html>
