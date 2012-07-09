<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsSource.aspx.cs" Inherits="XYECOM.Web.xymanage.Global.NewsSource" %>
<%@ Import Namespace="XYECOM.Configuration" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />

    <script language="javascript" type="text/javascript" src="/common/js/base.js"></script>

    <script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>

    <style type="text/css">
        .selChannel a
        {
            background-color: #f60;
        }
        .selChannel a
        {
            margin: 3px 0;
            margin-left: 4px;
            padding: 2px 5px; *padding:4px5px1px;border-right:#7b9ebd1pxsolid;border-top:#7b9ebd1pxsolid;font-size:12px;background:url(../css/bgimages/btn_bg.gif)repeat-xlefttop;border-left:#7b9ebd1pxsolid;cursor:hand;color:black;border-bottom:#7b9ebd1pxsolid;}
        .selChannel div
        {
            line-height: 200%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <a href="../index.aspx">后台首页</a> >> 生成新闻源Xml</h1>
    <table width="100%">
        <tr>
            <td class="right">
                <div class="main-setting">
                    <div class="itemtitle">
                        <h3>
                            生成新闻源</h3>
                    </div>
                    <table width="100%" class="xy_tb xy_tb2" id="InfoShow">
                        <tr>
                            <td>
                                <table class="partition">
                                    <tr>
                                        <th>
                                            选择栏目:
                                        </th>
                                        <td class="selChannel">
                                            <div id="divtitle">
                                            </div>
                                            <input id="hdgetid" runat="server" type="hidden" />

                                            <script type="text/javascript">
                                    var cla = new ClassType("cla",'news','divtitle','hdgetid');
                                    cla.Mode="select";
                                    cla.Init();
                                            </script>

                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            生成条数:
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtCount" runat="server" CssClass="input">100</asp:TextBox>
                                            <span>(1-100条)</span>
                                            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtCount"
                                                Display="Dynamic" ErrorMessage="最小1条,最大100条" MaximumValue="100" MinimumValue="1"
                                                SetFocusOnError="True" Type="Integer"></asp:RangeValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCount"
                                                Display="Dynamic" ErrorMessage="生成条数为必填项(1-100)" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            文件路径及文件名:
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtFullPath" runat="server">/news.xml</asp:TextBox>
                                            <span>默认存放路径为根目录,文件名为news.xml</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            网站域名:
                                        </th>
                                        <td>
                                        
                                            <asp:TextBox ID="txtDomainName" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="域名是必填项！"
                                                ControlToValidate="txtDomainName" Display="Dynamic"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtDomainName"
                                                Display="Dynamic" ErrorMessage="请填写格式正确的域名信息！" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            网站管理员Email:
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtWebMaster" runat="server" Text="a@a.a"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtWebMaster"
                                                Display="Dynamic" ErrorMessage="管理员Email为必填项!"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtWebMaster"
                                                Display="Dynamic" ErrorMessage="请填入格式合法的Email地址！" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            更新周期:
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtUpdatePeri" runat="server" Text="30"></asp:TextBox>
                                            <span>更新周期，单位分钟</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            仅读取当天:
                                        </th>
                                        <td>
                                            <asp:CheckBox ID="ckToday" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                        </th>
                                        <td>
                                            <asp:Button ID="btadGeneral" runat="server" CssClass="button" Text="生成Xml" OnClick="btadGeneral_Click" />
                                            <input id="btcancel" class="button" type="button" value="返回" onclick="javascript:history.back();" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gvlist" runat="server" GridLines="None" HeaderStyle-CssClass="gv_header_style"
                                    OnRowDataBound="gvlist_RowDataBound" Width="100%" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField DataField="Name" HeaderText="文件名">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <ItemStyle Width="10%" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="URL">
                                            <ItemStyle Width="25%" />
                                            <ItemTemplate>
                                                <a href='<%# XYECOM.Configuration.WebInfo.Instance.WebDomain + Eval("VirtualPath") %>'>
                                                    <%# XYECOM.Configuration.WebInfo.Instance.WebDomain + Eval("VirtualPath").ToString().Substring(1) %>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="虚拟路径">
                                            <ItemStyle Width="15%" />
                                            <ItemTemplate>
                                                <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("VirtualPath").ToString() %>'>
                                                </asp:Literal>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="LastWriteTime" HeaderText="最近更新时间">
                                            <ItemStyle Width="15%" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="文件属性相关">
                                            <ItemTemplate>
                                                <asp:Literal ID="Literal2" runat="server" Text='<%# GetProperties(Eval("PropertiesPath").ToString()) %>'>
                                                </asp:Literal>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="操作">
                                            <ItemStyle Width="8%" />
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnUpdate" runat="server" CommandArgument='<%# Eval("PhysicalPath") + "$" + Eval("PropertiesPath") %>'
                                                    OnClick="btnUpdate_Click" CausesValidation="false">更新</asp:LinkButton>
                                                <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%# Eval("PhysicalPath") %>'
                                                    OnClick="btnDelete_Click" CausesValidation="false" OnClientClick="javascript:return window.confirm('确定删除该文件？');">删除</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <p style="text-align: center;">
                                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label></p>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
