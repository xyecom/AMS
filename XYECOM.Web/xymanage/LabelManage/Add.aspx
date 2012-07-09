<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_LabelManage_Add"
    CodeBehind="Add.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加标签</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="../css/cue.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="/Common/js/base.js" language="javascript"></script>
    <script type="text/javascript" src="../javascript/CheckedAll.js"></script>
    <script type="text/javascript">
        function CloseSelect() {
            $("SelTopicType_bg").style.display = "none";
            $("SelTopicType").style.display = "none";
            clearInterval(interval);
        }

        var interval = null;

        function ShowTopicType() {
            var dWidth = 450;
            var dHeight = 350;
            var scrollPos = new getScrollPos();
            var pageSize = new getPageSize();

            $("SelTopicType_bg").style.display = "block";
            $("SelTopicType_bg").style.height = (pageSize.height + scrollPos.scrollY) + "px";
            $("SelTopicType").style.display = "block";

            var x = Math.round(pageSize.width / 2) - (dWidth / 2) + scrollPos.scrollX;
            var y = Math.round(pageSize.height / 2) - (dHeight / 2) + scrollPos.scrollY;
            $("SelTopicType").style.width = dWidth + "px";
            $("SelTopicType").style.height = dHeight + "px";
            $("SelTopicType").style.left = x + 'px';
            $("SelTopicType").style.top = y + 'px';
        }
        window.onload = function () {
            $("<%= this.rbtnUser.ClientID %>").onclick = function () {
                $("divuser").style.display = "block";
                $("divgroup").style.display = "none";
                $("SelTopicType").src = "SelectUser.aspx";

                $("hidGroupIds").value = "";
                $("spanGroupNames").innerHTML = "";

                interval = setInterval("ShowTopicType()", 500);
            }
            $("<%= this.rbtnUserGroup.ClientID %>").onclick = function () {
                $("divuser").style.display = "none";

                $("hidUserIds").value = "";
                $("spanUserNames").innerHTML = "";

                $("divgroup").style.display = "block";
                $("SelTopicType").src = "SelectUserGroup.aspx";
                interval = setInterval("ShowTopicType()", 500);
            }
            $("<%= this.rbtnSystem.ClientID %>").onclick = function () {
                $("SelTopicType").src = "";
                $("divuser").style.display = "none";

                $("hidUserIds").value = "";
                $("spanUserNames").innerHTML = "";

                $("hidGroupIds").value = "";
                $("spanGroupNames").innerHTML = "";

                $("divgroup").style.display = "none";
                clearInterval(interval);
            }
        }
    </script>
    <style type="text/css">
        .labelBodyList li
        {
            width: 100px;
            float: left;
            padding: 2px;
            padding-left: 15px;
            background: url(../images/up-10x10.gif) transparent no-repeat left center;
            font-size: 12px;
        }
    </style>
</head>
<body onload="InitListBox();">
    <form id="form1" runat="server">
    <iframe id="window" style="position: absolute; z-index: 4; display: none;" frameborder="0"
        onload="iframeload(this)"></iframe>
    <input type="hidden" runat="server" id="lableid" />
    <div id='Div_window' style="position: absolute; display: none; left: 0; top: 0; width: 100%;
        z-index: 3;" onkeydown="if(event.keyCode == 13 || event.keyCode == 32){sClose();} ">
    </div>
    <h1>
        <a href="../index.aspx">后台管理首页</a> >> 标签设置</h1>
    <table width="100%">
        <tr>
            <td class="right">
                <div class="main-setting">
                    <div class="itemtitle">
                        <h3>
                            标签设置</h3>
                    </div>
                    <table class="xy_tb xy_tb2 infotable1">
                        <tr>
                            <th>
                                标签名称：
                            </th>
                            <td class="labelName">
                                {XY_<asp:TextBox ID="tbName" runat="server" CssClass="input" MaxLength="60" Columns="50"></asp:TextBox>}
                            </td>
                        </tr>
                        <tr>
                            <th>
                                标签中文名称：
                            </th>
                            <td>
                                <asp:TextBox ID="tbCName" runat="server" CssClass="input" Columns="57"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                标签分类：
                                <br />
                            </th>
                            <td>
                                <asp:ListBox ID="hidLT_ID" runat="server" Rows="1"></asp:ListBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                标签应用范围：
                                <br />
                            </th>
                            <td>
                                <asp:RadioButton ID="rbtnUser" runat="server" Text="单用户" GroupName="range" />
                                <asp:RadioButton ID="rbtnSystem" runat="server" Text="整个平台" GroupName="range" />
                                <asp:RadioButton ID="rbtnUserGroup" runat="server" Text="用户组专用" GroupName="range" />
                                <div id="divuser" style="display: none;" runat="server">
                                    <input id="hidUserIds" type="hidden" runat="server" />
                                    <span id="spanUserNames" runat="server"></span>
                                </div>
                                <div id="divgroup" style="display: none;" runat="server">
                                    <input id="hidGroupIds" type="hidden" runat="server" />
                                    <span id="spanGroupNames" runat="server"></span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <th rowspan="2">
                                标签数据结构：
                                <br />
                            </th>
                            <td>
                                <ul class="labelBodyList">
                                    <li>
                                        <asp:HyperLink ID="hlsupply" runat="server" NavigateUrl="javascript:setshow(1);">供求信息</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="javascript:setshow(20);">求购信息</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="hldemand" runat="server" NavigateUrl="javascript:setshow(2);">投融资信息</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="hlbusiness" runat="server" NavigateUrl="javascript:setshow(3);">代理招商信息</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="hlsurrogate" runat="server" NavigateUrl="javascript:setshow(4);">服务信息</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="hlshow" NavigateUrl="javascript:setshow(5);" runat="server">展会信息</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="hlbrand" NavigateUrl="javascript:setshow(6);" runat="server">品牌信息</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="hlengage" runat="server" NavigateUrl="javascript:setshow(7);">招聘信息</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="hlcorporation" runat="server" NavigateUrl="javascript:setshow(8);">企业信息</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="hlNews" runat="server" NavigateUrl="javascript:setshow(9);">资讯信息</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="hlassociator" NavigateUrl="javascript:setshow(11);" runat="server">个人信息</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="hlTopic" runat="server" NavigateUrl="javascript:setshow(12);">专题信息</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="hlcurrency" runat="server" NavigateUrl="javascript:setshow(15);">通用信息</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="hlbaike" runat="server" NavigateUrl="javascript:setshow(17);">百科信息</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="javascript:setshow(18);">网上调查</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="hlUserNews" runat="server" NavigateUrl="javascript:setshow(19);">企业资讯</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="hlTeamBuy" runat="server" NavigateUrl="javascript:setshow(21);">团购信息</asp:HyperLink></li>
                                </ul>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="tbContent" runat="server" Width="90%" CssClass="input" Rows="3"
                                    TextMode="MultiLine" BorderStyle="Groove"></asp:TextBox>
                                <asp:ImageButton ID="ImageButton1" ImageUrl="../images/edit.gif" runat="server" ToolTip="编辑"
                                    OnClick="ImageButton1_Click" />
                            </td>
                        </tr>
                        <tr>
                            <th>
                                开始标记：
                            </th>
                            <td>
                                <asp:TextBox ID="txtHead" runat="server" Rows="4" TextMode="MultiLine" CssClass="labelBody"></asp:TextBox>
                                <a href="javascript:ChangeTextRow('txtHead','add',10,4,2);">
                                    <img src="../images/add.gif" alt="新增一行" /></a> &nbsp; <a href="javascript:ChangeTextRow('txtHead','sub',10,4,2);">
                                        <img src="../images/subtraction.gif" alt="删除一行" /></a>
                                <br />
                                <br />
                                <span>标签体的开始部分 如 &lt;table&gt;、&lt;ul&gt; 等</span>
                            </td>
                        </tr>
                        <tr>
                            <th id="scontent">
                                主体循环标记：<br />
                                <div id="sel1" style="display: none;">
                                    <input type="radio" name="rdoffer" onclick="selecttablename(1);" checked="checked" />供求信息字段<input
                                        type="radio" name="rdoffer" onclick="selecttablename(8);" />企业字段</div>
                                <div id="sel2" style="display: none;">
                                    <input type="radio" name="rdmachining" onclick="selecttablename(2);" checked="checked" />加工信息字段<input
                                        type="radio" name="rdmachining" onclick="selecttablename(8);" />企业字段</div>
                                <div id="sel3" style="display: none;">
                                    <input type="radio" name="rdinvestment" onclick="selecttablename(3);" checked="checked" />招商代理字段<input
                                        type="radio" name="rdinvestment" onclick="selecttablename(8);" />企业字段</div>
                                <div id="sel4" style="display: none;">
                                    <input type="radio" name="rdservice" onclick="selecttablename(4);" checked="checked" />服务信息字段<input
                                        type="radio" name="rdservice" onclick="selecttablename(8);" />企业字段</div>
                                <div id="sel5" style="display: none;">
                                    <input type="radio" name="rdexhibition" onclick="selecttablename(5);" checked="checked" />展会信息字段<!-- <input type="radio" name="rdexhibition"  onclick="selecttablename(8);" />企业字段 --></div>
                                <div id="sel6" style="display: none;">
                                    <input type="radio" name="rdbrand" onclick="selecttablename(6);" checked="checked" />品牌信息字段<input
                                        type="radio" name="rdbrand" onclick="selecttablename(8);" />企业字段</div>
                                <div id="sel7" style="display: none;">
                                    <input type="radio" name="rdjob" onclick="selecttablename(7);" checked="checked" />人才信息字段<input
                                        type="radio" name="rdjob" onclick="selecttablename(8);" />企业字段</div>
                                <div id="sel16" style="display: none;">
                                    <input type="radio" name="rdUserNews" onclick="selecttablename(16);" checked="checked" />企业新闻字段<input
                                        type="radio" name="rdjob" onclick="selecttablename(8);" />企业字段</div>
                                <div id="sel20" style="display: none;">
                                    <input type="radio" name="rdSupplyBuy" onclick="selecttablename(20);" checked="checked" />求购信息字段
                                    <input type="radio" name="rdSupplyBuy" onclick="selecttablename(8);" />企业字段
                                </div>
                                <asp:ListBox ID="lst_Offer" runat="server" Style="display: none;" ondblclick="selectcolumuname(this);"
                                    Rows="12" Width="160px" ToolTip="双击选中"></asp:ListBox>
                                <asp:ListBox ID="lst_Machining" runat="server" Style="display: none;" ondblclick="selectcolumuname(this);"
                                    Rows="12" Width="160px" ToolTip="双击选中"></asp:ListBox>
                                <asp:ListBox ID="lst_Investment" runat="server" Style="display: none;" ondblclick="selectcolumuname(this);"
                                    Rows="12" Width="160px" ToolTip="双击选中"></asp:ListBox>
                                <asp:ListBox ID="lst_Service" runat="server" Style="display: none;" ondblclick="selectcolumuname(this);"
                                    Rows="12" Width="160px" ToolTip="双击选中"></asp:ListBox>
                                <asp:ListBox ID="lst_Exhibition" runat="server" Style="display: none;" ondblclick="selectcolumuname(this);"
                                    Rows="12" Width="160px" ToolTip="双击选中"></asp:ListBox>
                                <asp:ListBox ID="lst_Brand" runat="server" Style="display: none;" ondblclick="selectcolumuname(this);"
                                    Rows="12" Width="160px" ToolTip="双击选中"></asp:ListBox>
                                <asp:ListBox ID="lst_Job" runat="server" Style="display: none;" ondblclick="selectcolumuname(this);"
                                    Rows="12" Width="160px" ToolTip="双击选中"></asp:ListBox>
                                <asp:ListBox ID="lst_Company" runat="server" Style="display: none;" ondblclick="selectcolumuname(this);"
                                    Rows="12" Width="160px" ToolTip="双击选中"></asp:ListBox>
                                <asp:ListBox ID="lst_NewsList" runat="server" Style="display: none;" ondblclick="selectcolumuname(this);"
                                    Rows="12" Width="160px" ToolTip="双击选中"></asp:ListBox>
                                <asp:ListBox ID="lst_anomulyNewsList" runat="server" Style="display: none;" ondblclick="selectcolumuname(this);"
                                    Rows="12" Width="160px" ToolTip="双击选中"></asp:ListBox>
                                <asp:ListBox ID="lst_AssociatorList" runat="server" Style="display: none;" ondblclick="selectcolumuname(this);"
                                    Rows="12" Width="160px" ToolTip="双击选中"></asp:ListBox>
                                <asp:ListBox ID="lst_TopicList" runat="server" Style="display: none;" ondblclick="selectcolumuname(this);"
                                    Rows="12" Width="160px" ToolTip="双击选中"></asp:ListBox>
                                <asp:ListBox ID="lst_FriendLink" runat="server" Style="display: none;" ondblclick="selectcolumuname(this);"
                                    Rows="12" Width="160px" ToolTip="双击选中"></asp:ListBox>
                                <asp:ListBox ID="lst_advertisingList" runat="server" Style="display: none;" ondblclick="selectcolumuname(this);"
                                    Rows="12" Width="160px" ToolTip="双击选中"></asp:ListBox>
                                <asp:ListBox ID="lst_HotKeyword" runat="server" Style="display: none;" ondblclick="selectcolumuname(this);"
                                    Rows="12" Width="160px" ToolTip="双击选中"></asp:ListBox>
                                <asp:ListBox ID="lst_UserNews" runat="server" Style="display: none;" ondblclick="selectcolumuname(this);"
                                    Rows="12" Width="160px" ToolTip="双击选中"></asp:ListBox>
                                <asp:ListBox ID="lst_baike" runat="server" Style="display: none;" ondblclick="selectcolumuname(this);"
                                    Rows="12" Width="160px" ToolTip="双击选中"></asp:ListBox>
                                <asp:ListBox ID="lst_Vote" runat="server" Style="display: none;" ondblclick="selectcolumuname(this);"
                                    Rows="12" Width="160px" ToolTip="双击选中"></asp:ListBox>
                                <asp:ListBox ID="lst_UserNewsList" runat="server" Style="display: none;" ondblclick="selectcolumuname(this);"
                                    Rows="12" Width="160px" ToolTip="双击选中"></asp:ListBox>
                                <asp:ListBox ID="lst_SupplyBuy" runat="server" Style="display: none;" ondblclick="selectcolumuname(this);"
                                    Rows="12" Width="160px" ToolTip="双击选中"></asp:ListBox>
                                <asp:ListBox ID="lst_TeamBuy" runat="server" Style="display: none;" ondblclick="selectcolumuname(this);"
                                    Rows="12" Width="160px" ToolTip="双击选中"></asp:ListBox>
                                <!---Temp-->
                                <asp:ListBox ID="lst_System" runat="server" Style="display: none;" ondblclick="selectcolumuname(this);"
                                    Rows="12" Width="160px" ToolTip="双击选中"></asp:ListBox>
                                <asp:ListBox ID="lst_Province" runat="server" Style="display: none;" ondblclick="selectcolumuname(this);"
                                    Rows="12" Width="160px" ToolTip="双击选中"></asp:ListBox>
                                &nbsp;
                            </th>
                            <td>
                                <asp:TextBox ID="txtConent" runat="server" CssClass="labelBody" Rows="10" TextMode="MultiLine"></asp:TextBox><input
                                    type="hidden" id="hidend" />
                                <a href="javascript:ChangeTextRow('txtConent','add',30,10,2);">
                                    <img src="../images/add.gif" alt="新增一行" /></a> &nbsp; <a href="javascript:ChangeTextRow('txtConent','sub',30,10,2);">
                                        <img src="../images/subtraction.gif" alt="删除一行" /></a>
                                <br />
                                <div class="syslabel">
                                    系统标签：<br />
                                    {SY:XY_WebURL}：网站域名，{SY:XY_TemplatePath}：当前模板名称，{i}：循环索引，从1开始
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                结束标记：
                            </th>
                            <td>
                                <asp:TextBox ID="txtfooter" runat="server" CssClass="labelBody" Rows="4" TextMode="MultiLine"></asp:TextBox>
                                <a href="javascript:ChangeTextRow('txtfooter','add',10,4,2);">
                                    <img src="../images/add.gif" alt="新增一行" /></a> &nbsp; <a href="javascript:ChangeTextRow('txtfooter','sub',10,4,2);">
                                        <img src="../images/subtraction.gif" alt="删除一行" /></a>
                                <br />
                                <br />
                                <span>标签体的结束部分 如 &lt;/table&gt;、&lt;/ul&gt; 等</span>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                标签说明：
                            </th>
                            <td>
                                <asp:TextBox ID="txtDescription" runat="server" CssClass="labelBody" Rows="4" TextMode="MultiLine"></asp:TextBox>
                                <br />
                                <br />
                                <span>标签的说明部分</span>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                &nbsp;
                            </th>
                            <td class="content_action" style="height: 30px">
                                <label>
                                    <asp:Button ID="btnok" OnClientClick="return AddLabel();" runat="server" CssClass="button"
                                        Text="保存设置" OnClick="btnok_Click"></asp:Button>&nbsp;
                                    <input type="hidden" id="hidTableName" runat="server" /></label>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <iframe id="SelTopicType" frameborder="0" style="display: none;"></iframe>
    <div id='SelTopicType_bg'>
    </div>
    </form>
</body>
</html>
