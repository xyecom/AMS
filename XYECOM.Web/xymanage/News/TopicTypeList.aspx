<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TopicTypeList.aspx.cs" Inherits="XYECOM.Web.xymanage.News.TopicTypeList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>专题类别管理</title>
<link href="../css/style.css" type="text/css" rel="stylesheet" /> 
<link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
<script language="javascript" type="text/javascript" src="/common/js/base.js"></script>
<script language="javascript" type="text/javascript" src="../javascript/AddNews.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="seltopictype_list" id="seltopictypelist">
        <asp:Repeater ID="rptList" runat="server">
            <ItemTemplate>
                <li>
                    <input type="checkbox" id="cbsel" value='<%# Eval("ID") %>' runat="server" /><span><%# Eval("CName") %></span>
                </li>
            </ItemTemplate>
        </asp:Repeater>
        <script language="javascript" type="text/javascript">TopicTypeInit();</script>
    </div>
    <div>
       
        <input id="btnOKToTopic" type="submit" class="button" runat="server"   value="确定" onserverclick="btnOKToTopic_ServerClick" />
        <input id="btnOk" type="button" class="button" runat="server" value="确定" onclick="TopicTypeInsert()" />
        <input id="BtnEsc" type="button" class="button" value="取消" onclick="parent.CloseTopicType()" /></div>
    </form>
</body>
</html>
