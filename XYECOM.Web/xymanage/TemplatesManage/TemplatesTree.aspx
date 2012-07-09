<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_TemplatesManage_TemplatesTree"
    CodeBehind="TemplatesTree.aspx.cs" EnableViewState="false" %>

<%@ Register Src="../UserControl/top.ascx" TagName="top" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ģ�����</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />

    <script language="javascript" type="text/javascript" src="/common/js/base.js"></script>

    <script type="text/javascript" src="../javascript/CheckedAll.js"></script>

    <script type="text/javascript" src="../javascript/templates.js"></script>

</head>
<body>
    <form id="Form1" method="post" runat="server">
    <iframe id="window" style="position: absolute; z-index: 4; display: none;" frameborder="0"
        onload="iframeload(this)"></iframe>
    <div id='Div_window' style="position: absolute; display: none; left: 0; top: 0; width: 100%;
        z-index: 3;" onkeydown="if(event.keyCode == 13 || event.keyCode == 32){sClose();} ">
    </div>
    <h1>
        <a href="../index.aspx">��̨������ҳ</a> >> ģ���ļ��б�</h1>
    <!-- content  -->
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <!-- right -->
            <td class="right">
                <!--��̨���� -->
                <!-- ��� -->
                <div id="temp">
                    <div class="sel_s_tabs2">
                        <ul>
                            <li id="default" class="current" onclick="isaspx(1);">��Ŀ¼</li>                            
                            <li id="news" onclick="isaspx(2);">��Ѷ</li>
                            <li id="areasite" onclick="isaspx(3);">�ط�վ</li>                            
                            <li id="css" onclick="isaspx(4);">css</li>
                        </ul>
                    </div>
                    <div class="temp_con" id="defaultlist" runat="server">
                    </div>
                    <div class="temp_con" id="newslist" style="display: none;">
                        <div class="temp_height" id="newsinfolist" runat="server">
                        </div>
                        <div id="newsdefaultlist" runat="server">
                        </div>
                    </div>
                    <div class="temp_con" id="areasitelist" style="display: none;">
                        <div class="temp_height" id="areasiteinfolist" runat="server">
                        </div>
                        <div id="areasitedefaultlist" runat="server">
                        </div>
                    </div>                    
                    <div class="temp_con" id="csslist" runat="server" style="display: none;">
                    </div>
                    <div class="temp_but">
                        <input name="" type="checkbox" value="" id="chkallaspx" onclick="templatescheckall();" />ȫѡ&nbsp;
                        <input id="Button2" class="button" type="button" value="����ѡ�е�ģ���ļ�" onclick="javascript:return createhtml();" />&nbsp;
                        <input type="button" class="button" onclick="javascript:return deletehtml();" value="ɾ��ָ����ģ���ļ�" />
                    </div>
                </div>
            </td>
        </tr>
    </table>
    <input id="hidpath" runat="server" type="hidden" />
    <input id="hidpathname" type="hidden" />
    </form>
</body>
</html>
