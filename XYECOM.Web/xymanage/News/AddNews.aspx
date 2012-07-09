<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" Inherits="xymanage_news_AddNews"
    CodeBehind="AddNews.aspx.cs" %>

<%@ Register Src="../UserControl/UploadFile.ascx" TagName="UploadFile" TagPrefix="uc2" %>
<%@ Register Src="../UserControl/UploadImage.ascx" TagName="UploadImage" TagPrefix="uc1" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>后台添加新闻</title>
    <link href="../css/cue.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        
        .selChannel a
        {
            margin: 3px 0;
            margin-left: 4px;
            padding: 2px 5px; *padding:4px 5px 1px;BORDER-RIGHT:#7b9ebd 1px solid;BORDER-TOP:#7b9ebd 1px solid;FONT-SIZE:12px;background:url(../css/bgimages/btn_bg.gif)repeat-x lefttop;BORDER-LEFT:#7b9ebd 1px solid;CURSOR:hand;COLOR:black;BORDER-BOTTOM:#7b9ebd 1px solid;}
        .selChannel div
        {
            line-height: 200%;
        }
        .search_txt
        {float:left;
         width:380px;
        	}
        .search_select
        {float:left;
         width:200px;
        	}
    </style>

    <script language="javascript" type="text/javascript" src="/Common/js/base.js"></script>

    <script language="javascript" type="text/javascript" src="/config/js/config.js"></script>

    <script language="javascript" type="text/javascript" src="/common/js/UploadControl.js"></script>

    <script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>

    <script language="javascript" type="text/javascript" src="../javascript/GetKeyWord.js"></script>

    <script language="javascript" type="text/javascript" src="/common/js/date.js"></script>

    <script language="javascript" type="text/javascript" src="../javascript/AddNews.js"></script>

</head>
<body onload='AddNewsPageInit()'>
    <form id="form1" runat="server">
    <h1>
        <a href="../index.aspx">后台首页</a> >> 添加资讯</h1>
    <table width="100%">
        <tr>
            <td class="right" style="height: auto">
                <div class="main-setting">
                    <div class="itemtitle">
                        <h3>
                            添加资讯</h3>
                    </div>
                    <table width="100%" class="xy_tb xy_tb2 infotable" id="InfoShow">
                        <tr>
                            <th>
                                资讯类型：
                            </th>
                            <td style="padding-top: 8px;">
                                <asp:RadioButton ID="rbcommonnews" runat="server" CssClass="input" GroupName="newtype"
                                    Text="普通资讯" />
                                <asp:RadioButton ID="rbpicnews" runat="server" CssClass="input" GroupName="newtype"
                                    Text="图片资讯" />
                                <asp:RadioButton ID="rbcaptionnews" runat="server" CssClass="input" GroupName="newtype"
                                    Text="标题资讯" />
                                <input id="AddOrUpdate" type="hidden" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <th>
                                资讯标题：
                            </th>
                            <td>
                                <asp:TextBox ID="tbnewsname" runat="server" Columns="80" CssClass="input"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                副标题：
                            </th>
                            <td>
                                <asp:TextBox ID="tbtwoname" runat="server" Columns="80" CssClass="input"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                标题样式：
                            </th>
                            <td>
                                <input type="text" id="txtTitleColor" value="" size="7" maxlength="7" runat="server" />
                                <select onchange="document.getElementById('txtTitleColor').value=this.options[this.selectedIndex].value;"
                                    id="selTitleColor" runat="server">
                                    <option value="">默认色</option>
                                    <option value="#FF0000" style="color: #FF0000; background-color: #FF0000"></option>
                                    <option value="#0000FF" style="color: #0000FF; background-color: #0000FF"></option>
                                    <option value="#008000" style="color: #008000; background-color: #008000"></option>
                                    <option value="#FFA500" style="color: #FFA500; background-color: #FFA500"></option>
                                    <option value="#800080" style="color: #800080; background-color: #800080"></option>
                                    <option value="#000000" style="color: #000000; background-color: #000000"></option>
                                </select>
                                <input type="checkbox" id="chkFontBold" value="bold" runat="server" />粗体
                                <input type="checkbox" id="chkFontItalic" value="italic" runat="server" />斜体
                                <input type="checkbox" id="chkFontUnderline" value="underline" runat="server" />下划线
                            </td>
                        </tr>
                        <tr>
                            <th>
                                选择栏目：
                            </th>
                            <td class="selChannel">
                                <div id="divtitle">
                                </div>
                                <input id="hdgetid" runat="server" type="text" style="display: none" />

                                <script type="text/javascript">
                                    var cla = new ClassTypes("cla",'news','divtitle','hdgetid');
                                    cla.Init();
                                </script>

                            </td>
                        </tr>
                        <tr>
                            <th>
                                关键字：
                            </th>
                            <td>
                                <asp:TextBox ID="reswords" runat="server" Columns="80" CssClass="input"></asp:TextBox><br />
                                <span>多个请以“,”隔开</span>
                            </td>
                        </tr>
                        <tr id="TR1" style="display: none">
                            <th>
                                链接地址：
                            </th>
                            <td>
                                <asp:TextBox ID="tblinkaddress" runat="server" Columns="80" CssClass="input"></asp:TextBox>
                            </td>
                        </tr>
                        <tr id="TR7" style="display: none">
                            <th style="height: 32px">
                                图片输入方式：
                            </th>
                            <td style="height: 32px">
                                <asp:RadioButton ID="rbpicurl" runat="server" GroupName="pictype" Text="图片URL" AutoPostBack="True" />
                                <asp:RadioButton ID="rbpicupload" runat="server" GroupName="pictype" Text="上传图片"
                                    Checked="true" />
                                <input id="imagetype" runat="server" type="hidden" />
                            </td>
                        </tr>
                        <tr id="TR8" style="display: none;">
                            <th>
                                图片URL：
                            </th>
                            <td>
                                <input id="hdpicurl" runat="server" type="hidden" />
                                <input id="hipictype" runat="server" type="hidden" />
                                <input runat="server" id="tbpinurl" type="text" onchange="PreviewImage(1);" />
                            </td>
                        </tr>
                        <tr id="tr11" style="display: none;">
                            <th style="width: 15%; line-height: 21px;">
                            </th>
                            <td style="width: 85%; line-height: 21px;">
                                <a id="picurl" href="" target="_blank">
                                    <img id="imgsrc" alt="" width="100px" src="" />
                                </a>
                            </td>
                        </tr>
                        <tr id="TR9" style="display: none">
                            <th>
                                上传图片：
                            </th>
                            <td>
                                <uc1:UploadImage ID="UploadFile1" runat="server" Iswatermark="false" MaxAmount="1"
                                    TableName="n_News" InfoID="0" IsCreateThumbnailImg="false" />
                            </td>
                        </tr>
                        <tr id="TR3" style="display: none">
                            <th>
                                资讯作者：
                            </th>
                            <td>
                                <asp:TextBox ID="tbnewsauthor" runat="server" CssClass="input" Columns="30"></asp:TextBox>&nbsp;
                                <asp:DropDownList ID="ddlnewsauthor" runat="server" Width="100px">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>佚名</asp:ListItem>
                                    <asp:ListItem>本站</asp:ListItem>
                                    <asp:ListItem>未知</asp:ListItem>
                                </asp:DropDownList>
                                <asp:CheckBox ID="cbnewsauthor" runat="server" Text="记忆该作者" />
                            </td>
                        </tr>
                        <tr id="TR4" style="display: none">
                            <th>
                                资讯来源：
                            </th>
                            <td>
                                <asp:TextBox ID="tbnewsorigin" runat="server" Columns="30" CssClass="input"></asp:TextBox>&nbsp;
                                <asp:DropDownList ID="ddlnewsorigin" runat="server" CssClass="input" Width="100px">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>佚名</asp:ListItem>
                                    <asp:ListItem>本站</asp:ListItem>
                                    <asp:ListItem>未知</asp:ListItem>
                                </asp:DropDownList>
                                &nbsp;<asp:CheckBox ID="cbnewsorigin" runat="server" Text="记忆该来源" />
                            </td>
                        </tr>
                        <tr>
                            <th>
                                资讯导读：
                            </th>
                            <td>
                                <asp:TextBox ID="tbnewsness" runat="server" Columns="80" CssClass="input" TextMode="MultiLine"
                                    Rows="5"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                类型：
                            </th>
                            <td>
                                <table class="toolbar">
                                    <tr>
                                        <td style="height: 23px">
                                            <asp:CheckBox ID="cbIsFlag" runat="server" Text=" 推荐" />&nbsp;
                                        </td>
                                        <td style="height: 23px">
                                            <asp:CheckBox ID="cbIsDiscuss" runat="server" Text=" 允许评论" Checked="true" />&nbsp;
                                        </td>
                                        <td style="height: 23px">
                                            <asp:CheckBox ID="cbIsTop" runat="server" Text=" 头条" />&nbsp;
                                        </td>
                                        <td style="height: 23px">
                                            <asp:CheckBox ID="cbIsHot" runat="server" Text=" 热点" />&nbsp;
                                        </td>
                                        <td style="height: 23px">
                                            <asp:CheckBox ID="cbIsScheme" runat="server" Text=" 方案式采购" />&nbsp;
                                        </td>
                                        <td id="TD1" style="height: 23px">
                                            <asp:CheckBox ID="cbIsSlide" runat="server" Text="幻灯" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr id="TR5">
                            <th>
                                资讯正文：
                            </th>
                            <td class="floatAlertTable">
                                <FCKeditorV2:FCKeditor ID="newsBody" runat="server" BasePath="/Common/fckeditor/"
                                    ToolbarSet="News" Height="500px">
                                </FCKeditorV2:FCKeditor>
                            </td>
                        </tr>
                        <tr>
                            <th>
                            </th>
                            <td>
                                <asp:Button ID="btadadd" runat="server" CssClass="button" Text="保存资讯" OnClick="btadadd_Click" OnClientClick="return Input()" />&nbsp;
                                <input id="btcancel" runat="server" class="button" type="button" value="返回" onserverclick="btcancel_ServerClick" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <table width="100%" style="background-color: #f2f2f2;">
                                    <tr>
                                        <th style="height: 54px">
                                            所属专题：
                                        </th>
                                        <td style="height: 54px">
                                            <input type="hidden" id="hidTopicID" runat="server" />
                                            <input type="button" class="button" value="选择专题" onclick="ShowTopicType()" />
                                            <div id="topicnames">
                                            </div>
                                        </td>
                                    </tr>
                                    <asp:Panel runat="server" ID="IsContributor">
                                        <tr>
                                            <th>
                                                投稿人：
                                            </th>
                                            <td id="Contributor" runat="server">
                                            </td>
                                        </tr>
                                    </asp:Panel>
                                    <tr>
                                        <th>
                                            附件格式：
                                        </th>
                                        <td>
                                            <div id="file2">
                                                <ul>
                                                    <li id="rbfileUpload" class="usertype" onclick="checkload(1);">附件上传</li>
                                                    <li id="rbfileUrl" class="cur_usertype" onclick="checkload(2);">附件URL</li>
                                                </ul>
                                            </div>
                                            <div id="file22">
                                                <uc2:UploadFile ID="UploadFile2" runat="server" MaxAmount="999" TableName="n_News"
                                                    InfoID="0" />
                                            </div>
                                            <div id="file23" style="display: none">
                                                <table class="filebgcolor">
                                                    <tr>
                                                        <td class="vtop rowform">
                                                            <asp:PlaceHolder ID="phMain" runat="server"></asp:PlaceHolder>
                                                        </td>
                                                        <td class="vtop tips2">
                                                            <img src="../images/add.gif" alt="点此继续添加选项" onclick="AddFileOption()" />
                                                            新增
                                                            <input type="hidden" id="OptionTotal" name="OptionTotal" runat="server" value="1" />
                                                            <input type="hidden" id="DelOptionIds" name="DelOptionIds" runat="server" value="" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            添加时间：<br />
                                        </th>
                                        <td>
                                            <input id="tbaddtime" runat="server" size="10" type="text" readonly="readonly" onclick="getDateString(this);" /><span>默认为当前时间</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            点击次数：<br />
                                        </th>
                                        <td>
                                            <asp:TextBox ID="tbcount" runat="server" Columns="10" CssClass="input" onblur="IsNum();">0</asp:TextBox><br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            相关地区：<br />
                                        </th>
                                        <td id="divarea">
                                            <input type="hidden" id="city" name="city" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            相关行业：<br />
                                        </th>
                                        <td id="divtrade">
                                            <input type="hidden" id="tradeid" name="tradeid" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            相关产品分类：
                                        </th>
                                        <td id="divoffer">
                                            <input type="hidden" id="offerid" name="offerid" runat="server" />
                                            <input type="hidden" id="infoIds" name="infoIds" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            相关产品：
                                        </th>
                                        <td >
                                            <input type="hidden" id="SelectinfoIds" runat="server" />
                                            <input type="hidden" id="SelectedIds" runat="server" />
                                            <input type="hidden" id="HidItemStr" runat="server" />
                                            <input type="button" class="button" value="请选择" onclick="ShowInfo()" />
                                            <div id="infos">
                                            <asp:Literal runat="server" ID="Infostxt"></asp:Literal>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            高级选项：
                                        </th>
                                        <td>
                                            <asp:CheckBox ID="cbAuditing" runat="server" Checked="true" Text="自动审核" />&nbsp;&nbsp;
                                            <asp:CheckBox ID="cbcreate" runat="server" Text="自动生成静态页面" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <iframe id="SelTopicType" frameborder="0" src="TopicTypeList.aspx?infoid=<%= newsId %>">
    </iframe>
    <div id='SelTopicType_bg'>
    </div>
     <iframe name="SelInfo" id="SelInfo" frameborder="0" src=""></iframe>
    <div id='SelInfo_bg'>
    </div>
    <script type="text/javascript">
var claarea = new ClassTypes("claarea",'area','divarea','city');
claarea.Init();

var clstrade = new ClassTypes("clstrade",'trade','divtrade','tradeid');
clstrade.Init();

var clsoffer = new ClassTypes("clsoffer", 'offer', 'divoffer', 'offerid');
clsoffer.Init();
    </script>

    </form>
</body>
</html>
