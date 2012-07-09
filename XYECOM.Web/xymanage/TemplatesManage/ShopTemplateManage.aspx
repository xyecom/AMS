<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.IO" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShopTemplateManage.aspx.cs" Inherits="XYECOM.Web.xymanage.TemplatesManage.ShopTemplateManage" %>

<%@ Register Src="../UserControl/top.ascx" TagName="top" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>����ģ�����</title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
<link href="../css/style.css" type="text/css" rel="stylesheet" />

<script language ="javascript" type ="text/javascript" src ="/common/js/base.js"></script>
<script language ="javascript" type ="text/javascript" src ="../javascript/CheckedAll.js"></script>
<script type="text/javascript" src="../javascript/templates.js"></script>
</head>
<body>
<form method="post" runat="server">
<iframe id="window" style="position:absolute; z-index:4;display:none;" frameBorder="0" onload="iframeload(this)"></iframe>
<div id='Div_window' style="position:absolute;display:none; left:0; top:0; width:100%; z-index:3;" onkeydown ="if(event.keyCode == 13 || event.keyCode == 32){sClose();} "></div>
    
    <h1><a href="../index.aspx">��̨������ҳ</a> >> ����ģ�����</h1>
 
    <table  width="100%" >
        <tr>
            <td class="right">
                
                <div class="main-setting">
                    <div class="itemtitle">
                        <h3>����ģ�����</h3>
                    </div>
                    <div>
                        <div class="sel_nav">
                            <ul class="sel_s_tabs">
                                <li id="shop_tmp_tab1" class="current"><a href="#" onclick="xy_selectBox(2,1,'shop_tmp');document.getElementById('templateType').value='basic';">����ģ��</a></li>
                                <li id="shop_tmp_tab2"><a href="#" onclick="xy_selectBox(2,2,'shop_tmp');document.getElementById('templateType').value='other';">ϵ��ģ��</a></li>
                            </ul>
                            <div class="sel_s_ac">
                                <input type="checkbox" value="" onclick="xy_select_shop_template(this);"/>ȫѡ
                                <input type="button" class="button" value="����ѡ������ģ��" onclick="xy_create_shop_template();"/>
                                <input type="button" class="button" value="ȫ������" onclick='createAll("_shop");'/>
                            </div>
                        </div>
                        <input type="hidden" id="templateType" value="basic"/>
                        <div id="shop_tmp_box1" class="basic_shop_temp">
                            <ul>
                                <%  
                                    DataTable tableThemes = GetThemes("");

                                    foreach (DataRow row in tableThemes.Rows)
                                    {
                                        Response.Write("<li>");
                                        Response.Write("<a href='ShopTemplateTree.aspx?path=" + row["filename"].ToString() + "'>");
                                        Response.Write("<img src='"+row["img"].ToString()+"' border='0' alt='�������ģ�����'/><br/>");
                                        Response.Write("</a>");
                                        Response.Write("<input type='checkbox' name='basic_shop_temp' value='" + row["filename"].ToString() + "'/>");
                                        Response.Write(row["cname"]);
                                        Response.Write("[<a href=\"javascript:ShopTemplatesSetting('" + row["filename"].ToString() + "');\">Ȩ������</a>]");
                                        Response.Write("</li>");
                                    }
                                 %>
                                <li></li>
                            </ul>    
                        </div>
                        
                        <div id="shop_tmp_box2" style="display:none;" class="other_shop_temp">
                            <%
                                DataTable table = GetSkins();
                                string dirName = "";

                                DataTable tableThemes1 = null;
                                
                                foreach (DataRow row in table.Rows)
                                {
                                    dirName = row["dir"].ToString();

                                    if (dirName.Equals("")) continue;

                                    tableThemes1 = GetThemes(dirName);

                                    Response.Write("<div class='tit'>");
                                    Response.Write("<input type='checkbox' name='other_shop_temp' value='" + dirName + "'/>");
                                    Response.Write(row["name"].ToString());
                                    Response.Write(" [<a href='ShopTemplateTree.aspx?path=" + dirName + "'>�ļ�����</a>]");
                                    Response.Write(" [<a href=\"javascript:ShopStyleSetting('" + dirName + "');\">Ȩ������</a>]");
                                    Response.Write("</div>");
                                    
                                    Response.Write("<ul>");
                                    foreach (DataRow row1 in tableThemes1.Rows)
                                    {
                                        Response.Write("<li>");
                                        Response.Write("<a href=\"javascript:ShopTemplatesSetting('" + row1["filename"].ToString() + "');\">");
                                        Response.Write("<img src='" + row1["img"].ToString() + "' border='0' alt='�������ģ�����'/><br/>");
                                        Response.Write("</a>");
                                        Response.Write(row1["cname"]);
                                        Response.Write("[<a href=\"javascript:ShopTemplatesSetting('" + row1["filename"].ToString() + "');\">Ȩ������</a>]");
                                        Response.Write("</li>");
                                    }
                                    Response.Write("</ul>");
                                }
                            %>
                        </div>
                    </div>
                   

                </div>
            </td> 
        </tr> 
    </table> 
</form>
</body>
</html>


