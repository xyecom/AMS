<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreaditLeavlList.aspx.cs"
    Inherits="XYECOM.Web.xymanage.Basic.CreaditLeavlList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>���õȼ��趨</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <link rel="stylesheet" href="../css/style.css" type="text/css" />
    <script language="javascript" type="text/javascript" src="/common/js/base.js"></script>
    <script language="javascript" type="text/javascript" src="../javascript/CheckedAll.js"></script>
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <h1>
        <a href="../index.aspx">��̨������ҳ</a> >> ���õȼ��趨</h1>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td class="right" style="height: 581px">
                <div class="main-setting">
                    <h3>
                        ���õȼ��趨</h3>
                    <input id="btadd" class="addbtn" type="button" value="�������õȼ�" onclick="javascript:window.location.href='EditCredLeavl.aspx'" />
                </div>
                <table class="xy_tb xy_tb2">
                    <tr>
                        <td>
                            <asp:GridView ID="gvlist" HeaderStyle-CssClass="gv_header_style" runat="server" AutoGenerateColumns="False"
                                Width="100%" GridLines="None" OnRowDataBound="gvlist_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="ͼƬ">
                                        <ItemTemplate>
                                            <img style="width: 72px" src='<%# Eval("ImagePath") %>' alt='<%# Eval("LeavlName") %>' />
                                        </ItemTemplate>
                                        <ItemStyle CssClass="gvCenter" Width="10%" />
                                        <HeaderStyle CssClass="gvCenter" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="LeavlName" HeaderText="�ȼ�����">
                                        <ItemStyle CssClass="gvLeft" Width="15%" />
                                        <HeaderStyle CssClass="gvLeft" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="������Χ">
                                        <ItemTemplate>
                                            <%# GetPoint(Eval("DownPoint"), Eval("UpPoint"))%>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="gvLeft" Width="15%" />
                                        <HeaderStyle CssClass="gvLeft" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="�༭">
                                        <ItemTemplate>
                                            <asp:HyperLink runat="server" ID="hykEdit" ImageUrl="../images/edit.gif" Visible='<%# Eval("UpPoint").ToString()=="-1" %>'
                                                NavigateUrl="EditCredLeavl.aspx?type=modify">
                                            <%--<img alt="�༭" src='../images/edit.gif' />--%>
                                            </asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="gvLeft" Width="10%" />
                                        <HeaderStyle CssClass="gvLeft" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ɾ��">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ibtnDel" ImageUrl="../images/delete.gif" runat="server" OnClick="ibtnDel_Click"
                                                CommandArgument='<%# Eval("Id") %>' Visible='<%# Eval("UpPoint").ToString()=="-1" %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass="gv_header_style"></HeaderStyle>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                <p style="text-align: center;">
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                </p>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
