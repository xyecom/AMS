<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Function.aspx.cs" Inherits="XYECOM.Web.xymanage.Basic.Function" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>网站功能设置</title>
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <script language="javascript" type="text/javascript" src="/common/js/base.js"></script>
    <script language="javascript" type="text/javascript" src="/common/js/UploadControl.js"></script>
    <script language="Javascript" type="text/javascript" src="../javascript/WebSet.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <a href="../index.aspx">后台管理首页</a> >> 系统基本配置</h1>
    <table width="100%">
        <tr>
            <td class="right">
                <div class="main-setting">
                    <div class="itemtitle">
                        <h3>
                            系统基本配置</h3>
                        <ul class="tab1">
                            <li><a href="WebInfo.aspx"><span>基本配置</span></a></li>
                            <li class="current"><a href="Function.aspx"><span>功能配置</span></a></li>
                            <li style="display: none;"><a href="BussinessInfoSet.aspx"><span>商业信息相关</span></a></li>
                            <li><a href="UserInfoSet.aspx"><span>用户相关</span></a></li>
                            <li style="display: none;"><a href="ShopSet.aspx"><span>网店相关</span></a></li>
                            <li><a href="Server.aspx"><span>附件服务器</span></a></li>
                            <li><a href="EMailBoxInfoSet.aspx"><span>网站邮箱</span></a></li>
                            <li style="display: none;"><a href="SEO.aspx"><span>SEO设置</span></a></li>
                            <li><a href="SecuritySet.aspx"><span>安全设置</span></a></li>
                        </ul>
                    </div>
                    <!--图片上传相关-->
                    <div class="itemtitle">
                        <h3>
                            上传相关设置</h3>
                    </div>
                    <table class="xy_tb xy_tb2 border_buttom0">
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                上传图片最大尺寸：
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform">
                                <asp:TextBox ID="tbUploadImg" runat="server" CssClass="txt" MaxLength="24"></asp:TextBox>
                            </td>
                            <td class="vtop tips2">
                                格式为：宽度 * 高度 例如：1024*768。
                            </td>
                        </tr>
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                缩略图文件夹：
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform">
                                <asp:TextBox ID="tbUploadThumbnailImgFolder" runat="server" CssClass="txt" MaxLength="24"></asp:TextBox>
                            </td>
                            <td class="vtop tips2">
                                格式为：宽度 * 高度 例如：1024*768。
                            </td>
                        </tr>
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                缩略图1尺寸：
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform">
                                <asp:TextBox ID="tbUploadThumbnailImg1" runat="server" CssClass="txt" MaxLength="24"></asp:TextBox>
                            </td>
                            <td class="vtop tips2">
                                格式为：宽度 * 高度
                            </td>
                        </tr>
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                缩略图2尺寸：
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform">
                                <asp:TextBox ID="tbUploadThumbnailImg2" runat="server" CssClass="txt" MaxLength="24"></asp:TextBox>
                            </td>
                            <td class="vtop tips2">
                                格式为：宽度 * 高度
                            </td>
                        </tr>
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                缩略图3尺寸：
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform">
                                <asp:TextBox ID="tbUploadThumbnailImg3" runat="server" CssClass="txt" MaxLength="24"></asp:TextBox>
                            </td>
                            <td class="vtop tips2">
                                格式为：宽度 * 高度
                            </td>
                        </tr>
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                上传图片类型：
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform">
                                <asp:TextBox ID="tbUploadFileType" runat="server" CssClass="txt" MaxLength="50"></asp:TextBox>
                            </td>
                            <td class="vtop tips2">
                                文件类型后缀名,以";"隔开。
                            </td>
                        </tr>
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                图片大小：
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform">
                                <asp:TextBox ID="tbUploadFileSize" runat="server" CssClass="txt" MaxLength="4" onblur="IsInt(this);"
                                    Width="40px">0</asp:TextBox>KB
                            </td>
                            <td class="vtop tips2">
                                KB 为单位，1M = 1024KB
                            </td>
                        </tr>
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                上传附件类型：
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform">
                                <asp:TextBox ID="tbUploadAdjunctType" runat="server" CssClass="txt" MaxLength="50"></asp:TextBox>
                            </td>
                            <td class="vtop tips2">
                                文件类型后缀名,以";"隔开。
                            </td>
                        </tr>
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                附件大小：
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform">
                                <asp:TextBox ID="tbUploadAdjunctSize" runat="server" CssClass="input" MaxLength="4"
                                    onblur="IsInt(this);" Width="40px">0</asp:TextBox>
                                KB
                            </td>
                            <td class="vtop tips2">
                                KB 为单位，1M = 1024KB
                            </td>
                        </tr>
                    </table>
                    <br />
                    <!--水印相关-->
                    <div class="itemtitle">
                        <h3>
                            水印相关设置</h3>
                    </div>
                    <table class="xy_tb xy_tb2 border_buttom0">
                        <tr>
                            <td>
                                <table width="100%">
                                    <tr>
                                        <th>
                                            是否启用水印：
                                        </th>
                                        <td>
                                            <asp:RadioButtonList ID="rblIsWaterMark" runat="server" RepeatDirection="Horizontal"
                                                RepeatLayout="Flow">
                                                <asp:ListItem Value="1">启用</asp:ListItem>
                                                <asp:ListItem Value="0">不启用</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            水印类型：
                                        </th>
                                        <td>
                                            <asp:RadioButtonList ID="rblWaterMarkType" runat="server" RepeatDirection="Horizontal"
                                                RepeatLayout="Flow">
                                                <asp:ListItem Value="0">文字</asp:ListItem>
                                                <asp:ListItem Value="1">图片</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            文字水印：
                                        </th>
                                        <td style="line-height: 150%">
                                            <asp:Label ID="lbwatermarkchar" runat="server" CssClass="input" Text="内容："></asp:Label>
                                            <asp:TextBox ID="tbWaterMarkContent" runat="server" CssClass="input" MaxLength="20"
                                                Width="250px"></asp:TextBox><br />
                                            <br />
                                            <asp:Label ID="lbcharfont" runat="server" Text="字体："></asp:Label>
                                            <asp:DropDownList ID="ddlWaterMarkFont" runat="server" CssClass="input">
                                                <asp:ListItem Value="SimSun">宋体</asp:ListItem>
                                                <asp:ListItem Value="SimHei">黑体</asp:ListItem>
                                                <asp:ListItem Value="FangSong_GB2312">仿宋体</asp:ListItem>
                                                <asp:ListItem Value="NSimSun">新宋体</asp:ListItem>
                                                <asp:ListItem Value="Arial">Arial</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Label ID="lbcharsize" runat="server" Text="文字大小："></asp:Label>
                                            <asp:DropDownList ID="ddlWaterMarkFontSize" runat="server" CssClass="input">
                                                <asp:ListItem Value="8">8pt</asp:ListItem>
                                                <asp:ListItem Value="10">10pt</asp:ListItem>
                                                <asp:ListItem Value="12">12pt</asp:ListItem>
                                                <asp:ListItem Value="14">14pt</asp:ListItem>
                                                <asp:ListItem Value="18">18pt</asp:ListItem>
                                                <asp:ListItem Value="24">24pt</asp:ListItem>
                                                <asp:ListItem Value="36">36pt</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Label ID="lbplacechar" runat="server" Text="放置位置："></asp:Label>
                                            <asp:DropDownList ID="ddlWaterMarkPlace" runat="server" CssClass="input">
                                                <asp:ListItem Value="左上">左上</asp:ListItem>
                                                <asp:ListItem Value="右上">右上</asp:ListItem>
                                                <asp:ListItem Value="居中">居中</asp:ListItem>
                                                <asp:ListItem Value="左下">左下</asp:ListItem>
                                                <asp:ListItem Value="右下">右下</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Label ID="lbcolorchar" runat="server" Text="文字颜色："></asp:Label>
                                            <asp:DropDownList ID="ddlWaterMarkColor" runat="server" CssClass="input">
                                                <asp:ListItem Value="Red" style="color: #FF0000; background-color: #FF0000"></asp:ListItem>
                                                <asp:ListItem Value="yellow" style="color: #FFFFF0; background-color: #FFFFF0"></asp:ListItem>
                                                <asp:ListItem Value="blue" style="color: #0000FF; background-color: #0000FF"></asp:ListItem>
                                                <asp:ListItem Value="cyan" style="color: #00FFFF; background-color: #00FFFF"></asp:ListItem>
                                                <asp:ListItem Value="green" style="color: #008000; background-color: #008000"></asp:ListItem>
                                                <asp:ListItem Value="orange" style="color: #FFA500; background-color: #FFA500"></asp:ListItem>
                                                <asp:ListItem Value="pink" style="color: #FFC0CB; background-color: #FFC0CB"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            图片水印：
                                        </th>
                                        <td>
                                            <br />
                                            <asp:Image ID="imgWaterMarkPicURL" runat="server" />
                                            <br />
                                            <p>
                                                <asp:Label ID="lbWaterMarkPicURL" runat="server"></asp:Label></p>
                                            <br />
                                            <asp:Label ID="lbplacepic" runat="server" Text="放置位置："></asp:Label>
                                            <asp:DropDownList ID="ddlWaterMarkPicPlace" runat="server" CssClass="input">
                                                <asp:ListItem Value="左上">左上</asp:ListItem>
                                                <asp:ListItem Value="右上">右上</asp:ListItem>
                                                <asp:ListItem Value="居中">居中</asp:ListItem>
                                                <asp:ListItem Value="左下">左下</asp:ListItem>
                                                <asp:ListItem Value="右下">右下</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Label ID="lbdiaphaneity" runat="server" Text="图片透明度："></asp:Label>
                                            <asp:DropDownList ID="ddlWaterMarkPicDiaphaneity" runat="server" CssClass="input">
                                                <asp:ListItem Value="0.1">10%</asp:ListItem>
                                                <asp:ListItem Value="0.2">20%</asp:ListItem>
                                                <asp:ListItem Value="0.3">30%</asp:ListItem>
                                                <asp:ListItem Value="0.4">40%</asp:ListItem>
                                                <asp:ListItem Value="0.5">50%</asp:ListItem>
                                                <asp:ListItem Value="0.6">60%</asp:ListItem>
                                                <asp:ListItem Value="0.7">70%</asp:ListItem>
                                                <asp:ListItem Value="0.8">80%</asp:ListItem>
                                                <asp:ListItem Value="0.9">90%</asp:ListItem>
                                                <asp:ListItem Value="1">100%</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Label ID="lbcolorpic" runat="server" Text="图片底色："></asp:Label>
                                            <asp:DropDownList ID="ddlWaterMarkPicBgColor" runat="server" CssClass="input">
                                                <asp:ListItem Value="Red" style="color: #FF0000; background-color: #FF0000"></asp:ListItem>
                                                <asp:ListItem Value="yellow" style="color: #FFFFF0; background-color: #FFFFF0"></asp:ListItem>
                                                <asp:ListItem Value="blue" style="color: #0000FF; background-color: #0000FF"></asp:ListItem>
                                                <asp:ListItem Value="cyan" style="color: #00FFFF; background-color: #00FFFF"></asp:ListItem>
                                                <asp:ListItem Value="green" style="color: #008000; background-color: #008000"></asp:ListItem>
                                                <asp:ListItem Value="orange" style="color: #FFA500; background-color: #FFA500"></asp:ListItem>
                                                <asp:ListItem Value="pink" style="color: #FFC0CB; background-color: #FFC0CB"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <!--水印相关-->
                    <div class="itemtitle" style="display: none;">
                        <h3>
                            其他设置</h3>
                    </div>
                    <table class="xy_tb xy_tb2" style="display: none;">
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                相关新闻调用数量：
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform">
                                <asp:TextBox ID="txtAboutNewsNum" runat="server" MaxLength="4" Width="40px" CssClass="input"
                                    onblur="IsInt(this);"></asp:TextBox>
                            </td>
                            <td class="vtop tips2">
                            </td>
                        </tr>
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                自动收集站内搜索关键词：
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform">
                                <asp:RadioButtonList ID="rdoIsAutoGatherSearchKey" runat="server" RepeatDirection="Horizontal"
                                    RepeatLayout="Flow">
                                    <asp:ListItem Value="true">启用</asp:ListItem>
                                    <asp:ListItem Value="false">不启用</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td class="vtop tips2">
                            </td>
                        </tr>
                    </table>
                    <div style="padding: 5px 0px 15px 0px;">
                        <asp:Button ID="btnok" runat="server" CssClass="button" Text="保存设置" OnClientClick="return chkfunctioninput();"
                            OnClick="btnok_Click" />
                    </div>
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
