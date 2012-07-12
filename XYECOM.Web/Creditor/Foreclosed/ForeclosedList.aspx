<%@ Page Title="" Language="C#" MasterPageFile="~/Creditor/Creditor.master" AutoEventWireup="true"
    CodeBehind="ForeclosedList.aspx.cs" Inherits="XYECOM.Web.Creditor.Foreclosed.ForeclosedList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="/user/css/post.css" />
    <script src="/Common/Js/Newvalidate.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../xymanage/Javascript/CheckedAll.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <div id="right_guanli">
        <div class="guanli_box">
            <div class="glb_ss">
                标题：<asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                &nbsp;物品类型<asp:DropDownList ID="ddlVenType" runat="server">
                </asp:DropDownList><asp:Button runat="server" ID="btnSearch" />
            </div>
            <div class="glb_top">
                <div class="glb_tp">
                    标题</div>
                <div class="glb_bt">
                    低价</div>
                <div class="glb_jg">
                    物品类型</div>
                <div class="glb_lx">
                    结束时间</div>
                <div class="glb_sj">
                    审核状态</div>
                <div class="glb_cz">
                    操作</div>
            </div>
            <asp:Repeater ID="gdlist" runat="server">
                <ItemTemplate>
                    <div class="glb_li" style="background-color: #fff;" onmouseout="this.style.background='#fff'"
                        onmouseover="this.style.background='#deeffa'">
                        <div class="glb_tp">
                            <input id="chkExport" type="checkbox" runat="server" value='<%# Eval("ForeclosedId") %>' />
                            <%# Eval("Title") %>
                        </div>
                        <div class="glb_bt">
                            <%# Eval("LinePrice")%>
                        </div>
                        <div class="glb_jg">
                            <span>
                                <%# Eval("ForeColseTypeName")%></span></div>
                        <div class="glb_lx">
                            <%# Eval("Trade")%>
                        </div>
                        <div class="glb_sj">
                            <%# Eval("EndDate")%>
                        </div>
                        <div class="glb_cz">
                            <a href='<%# string.Format("AddFinancingInfo.{0}?operator=1&Id={1}",webInfo.WebSuffix,Eval("SD_ID")) %>'>
                                <img alt="" src="/user/image/guanli_07.jpg" /></a>&nbsp;&nbsp;
                            <asp:Button ID="btnDel" CssClass="buttonSkinB" runat="server" Text="删除" CommandArgument='<%# Eval("SD_ID") %>'
                                OnClientClick="return window.confirm('确认要删除！')" OnClick="btnDel_Click" />
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <p style="text-align: center;">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            </p>
        </div>
        <div class="guanli_bott">
            <input id="chkAll" name="chkAll" onclick="chkAll_true()" type="checkbox" />全选
            <asp:ImageButton ImageUrl="/user/image/guanli_09.jpg" ID="btnDelete" OnClientClick="return del();"
                runat="server" OnClick="btnDelete_Click" CssClass="buttonSkinB" />
            <XYECOM:Page ID="mypage" runat="server" PageSize="10" OnPageChanged="mypage_PageChanaged" />
        </div>
    </div>
</asp:Content>
