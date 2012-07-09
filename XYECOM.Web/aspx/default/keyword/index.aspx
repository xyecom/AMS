<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.keyword.index,XYECOM.Page" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="XYECOM.Core" %>
<%@ Import namespace="XYECOM.Model" %>
<%@ Import namespace="XYECOM.Business" %>
<%@ Import namespace="XYECOM.Template" %>
<%@ Import namespace="XYECOM.Configuration" %>
<script runat="server">
protected override void OnLoad(EventArgs e)
{
	base.OnLoad(e);
	XYBody.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n");
	XYBody.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n");
	XYBody.Append("<head>\r\n");
	XYBody.Append("	<title> �̶�����-");	XYBody.Append(config.webname);	XYBody.Append("</title>\r\n");
	XYBody.Append("	<meta name=\"description\" content=\"xyecom\" />\r\n");
	XYBody.Append("	<meta name=\"keywords\" content=\"xyecom\" />\r\n");
	XYBody.Append("	<meta name=\"robots\" content=\"all\"  />\r\n");
	XYBody.Append("	<meta http-equiv=\"Content-Type\" content=\"text/html; charset=gb2312\" />\r\n");
	XYBody.Append("	<link href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/css/global.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n");
	XYBody.Append("	<link href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/css/rank.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n");
	XYBody.Append("</head>\r\n");
	XYBody.Append("<body>\r\n");
	XYBody.Append("<div id=\"layoutHead\">\r\n");
	XYBody.Append("	<div id=\"rank_header\">\r\n");
	XYBody.Append("		<div id=\"logo\"><a href=\"\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/logo_rank.gif\" width=\"351\" height=\"50\" alt=\"\" /></a></div>\r\n");
	XYBody.Append("		<div id=\"quick_link\"><a href=\"\">��Ա��¼</a> <a href=\"\">ʹ�ð���</a></div>\r\n");
	XYBody.Append("	</div>\r\n");
	XYBody.Append("	<div id=\"rank_nav\">\r\n");
	XYBody.Append("		<ul>\r\n");
	XYBody.Append("			<li><a href=\"\"><span>�� ҳ</span></a></li>\r\n");
	XYBody.Append("			<li><a href=\"\" class=\"current\"><span>��ѯ�������</span></a></li>\r\n");
	XYBody.Append("			<li><a href=\"\"><span>��������</span></a></li>\r\n");
	XYBody.Append("			<li><a href=\"\"><span>��������</span></a></li>\r\n");
	XYBody.Append("			<li><a href=\"\"><span>��ϵ����</span></a></li>\r\n");
	XYBody.Append("			<li><a href=\"\" class=\"current\"><span>�೤���ֶ�����Ŷ</span></a></li>\r\n");
	XYBody.Append("		</ul>\r\n");
	XYBody.Append("	</div>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<div id=\"layoutBnner\">\r\n");
	XYBody.Append("<div id=\"layoutBnnerT\"><strong class=\"font14 whitefont\">ʲô�ǹ̶�������</strong><br /><br />\r\n");
	XYBody.Append("�̶�������");	XYBody.Append(config.webname);	XYBody.Append("�Ƴ��ĵ���Ϣ�������������");	XYBody.Append(config.webname);	XYBody.Append("�鿴����������ز�Ʒ����ҵ��Ϣʱ���̶�������ҵ����Ϣ���������������ǰ��λ���ܹ�����ҵ�һʱ����ҵ���</div>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<!--���岿��-->\r\n");
	XYBody.Append("<div id=\"layoutMain\">\r\n");
	XYBody.Append("  <div id=\"layoutMainL\">\r\n");
	XYBody.Append("  <div id=\"Lsearch\">\r\n");
	XYBody.Append("    <form id=\"form1\" name=\"form1\" method=\"post\" action=\"\" onsubmit=\"\">\r\n");
	XYBody.Append("      <input type=\"text\" id=\"keyword\" name=\"keyword\" class=\"keyclass\" onload=\"if(this.value=='')this.value='����������Ҫ��ѯ�Ĺؼ���';\" onfocus=\"if(this.value=='����������Ҫ��ѯ�Ĺؼ���') this.value = '';\" value=\"");	XYBody.Append(keyword.ToString());	XYBody.Append("\"/> \r\n");
	XYBody.Append("      <input type=\"submit\" name=\"Submit\" value=\"  \" class=\"keybut\" />\r\n");
	XYBody.Append("    </form>\r\n");
	XYBody.Append("    </div>\r\n");

	if (keyData.Rows.Count>0)
	{

	XYBody.Append("     <table class=\"rankTable\" style=\"width:100%; float:left;\">\r\n");
	XYBody.Append("            <thead>\r\n");
	XYBody.Append("                <tr class=\"title\">\r\n");
	XYBody.Append("                    <td>�ؼ���</td>\r\n");
	XYBody.Append("                    <td>�����Ϣ</td>\r\n");
	XYBody.Append("                </tr>\r\n");
	XYBody.Append("            </thead>\r\n");

	int key__loop__id=0;
	foreach(DataRow key in keyData.Rows)
	{
		key__loop__id++;

	XYBody.Append("            <tr>\r\n");
	XYBody.Append("                <td valign=\"top\" class=\"k line\" >" + key["SK_Name"].ToString().Trim() + "</td>\r\n");
	XYBody.Append("                <td class=\"line\">\r\n");
	 data = GetRankingData(key["SK_ID"].ToString());
	

	if (data.Rows.Count>0)
	{

	XYBody.Append("                        <table width=\"100%\" class=\"cTable\">\r\n");
	XYBody.Append("                            <tr>\r\n");
	XYBody.Append("                                <th align=\"center\">����</th>\r\n");
	XYBody.Append("                                <th align=\"left\">״̬��Ϣ</th>\r\n");
	XYBody.Append("                                <th align=\"center\">����</th>\r\n");
	XYBody.Append("                            </tr>\r\n");

	int rdata__loop__id=0;
	foreach(DataRow rdata in data.Rows)
	{
		rdata__loop__id++;

	XYBody.Append("                            <tr>\r\n");
	XYBody.Append("                                <td align=\"center\">" + rdata["rank"].ToString().Trim() + "</td>\r\n");
	XYBody.Append("                                <td align=\"left\">" + rdata["state"].ToString().Trim() + "</td>\r\n");
	XYBody.Append("                                <td align=\"center\">" + rdata["link"].ToString().Trim() + "</td>\r\n");
	XYBody.Append("                            </tr>\r\n");

	}	//end loop

	XYBody.Append("                        </table>\r\n");

	}	//end if

	XYBody.Append("                </td>\r\n");
	XYBody.Append("            </tr>\r\n");

	}	//end loop

	XYBody.Append("         </table>\r\n");

	}
	else
	{

	XYBody.Append("    <div id=\"Lfix_xg\"></div>\r\n");
	XYBody.Append("    <div id=\"Lfix_xg1\">\r\n");
	XYBody.Append("	    <div id=\"Lfix_xg1L\"><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/fix_show.gif\" /></div>\r\n");
	XYBody.Append("	    <div id=\"Lfix_xg1R\">\r\n");
	XYBody.Append("	      <p><strong class=\"redfont\" style=\"font-size:14px;\">�̶������ķ��ã�</strong><br />\r\n");
	XYBody.Append("	        ������һλ��300Ԫ/��<br />\r\n");
	XYBody.Append("	        �����ڶ�λ��200Ԫ/��<br />\r\n");
	XYBody.Append("	        ��������λ��100Ԫ/��<br />\r\n");
	XYBody.Append("	        �������ʣ�����<a href=\"Contact.htm\" target=\"_blank\"><strong>��ϵ����</strong></a></p>\r\n");
	XYBody.Append("	    </div>\r\n");
	XYBody.Append("	    <div class=\"clr\"></div>\r\n");
	XYBody.Append("	</div>\r\n");

	}	//end if

	XYBody.Append("	<div id=\"Lfix_xg2\"></div>\r\n");
	XYBody.Append("	<div id=\"Lfix_show\">\r\n");
	XYBody.Append("	<table class=\"tabHotKey\">\r\n");
	XYBody.Append("	    <tr>\r\n");
	XYBody.Append("	        <th>���Źؼ���</th>\r\n");
	XYBody.Append("	    </tr>\r\n");
	XYBody.Append("	    <tr>\r\n");
	XYBody.Append("	        <td>\r\n");
	 data = GetHotKeyword(20);
	
	XYBody.Append("	        <ul>\r\n");

	int hotkey__loop__id=0;
	foreach(DataRow hotkey in data.Rows)
	{
		hotkey__loop__id++;

	XYBody.Append("			<li><a href=\"?keyword=" + hotkey["SK_Name"].ToString().Trim() + "\" target=\"_self\">" + hotkey["SK_Name"].ToString().Trim() + "</a><span>(" + hotkey["SK_Count"].ToString().Trim() + ")</span></li>\r\n");

	}	//end loop

	XYBody.Append("            </ul>\r\n");
	XYBody.Append("	        </td>\r\n");
	XYBody.Append("	    </tr>\r\n");
	XYBody.Append("	</table>\r\n");
	XYBody.Append("    <div class=\"clr\"></div>\r\n");
	XYBody.Append(" 	<table class=\"tabHotKey\">\r\n");
	XYBody.Append("	    <tr>\r\n");
	XYBody.Append("	        <th>���¹ؼ���</th>\r\n");
	XYBody.Append("	    </tr>\r\n");
	XYBody.Append("	    <tr>\r\n");
	XYBody.Append("	        <td>\r\n");
	 data = GetNewKeyword(20);
	
	XYBody.Append("	        <ul>\r\n");

	int newkey__loop__id=0;
	foreach(DataRow newkey in data.Rows)
	{
		newkey__loop__id++;

	XYBody.Append("			<li><a href=\"?keyword=" + newkey["SK_Name"].ToString().Trim() + "\" target=\"_self\">" + newkey["SK_Name"].ToString().Trim() + "</a><span>(" + newkey["SK_Count"].ToString().Trim() + ")</span></li>\r\n");

	}	//end loop

	XYBody.Append("            </ul>\r\n");
	XYBody.Append("	        </td>\r\n");
	XYBody.Append("	    </tr>\r\n");
	XYBody.Append("	</table>   \r\n");
	XYBody.Append("	</div>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("  <div id=\"layoutMainR\">\r\n");
	XYBody.Append("  	<div class=\"RightTopBg\"></div>\r\n");
	XYBody.Append("	<div class=\"RightMidBg\">\r\n");
	XYBody.Append("		<div class=\"rk_cate\"><h2>ΪʲôҪ����̶�������</h2></div>\r\n");
	XYBody.Append("		<div class=\"rk_item\">\r\n");
	XYBody.Append("			<strong>1������Ʒ������,Ѹ������ͻ�Ⱥ</strong><br />\r\n");
	XYBody.Append("			�����98�������ͨ�������ؼ���ȥѰ�Һ��ʵ����ң����������ڴ���Ŀλ�ó��֣���չ���ʼ��ͻ������������֪��\r\n");
	XYBody.Append("		</div>\r\n");
	XYBody.Append("		<div class=\"rk_item\">\r\n");
	XYBody.Append("			<strong>2����Ϣ��ǰ������ø�����ҹ�ע</strong><br />\r\n");
	XYBody.Append("			����ǰ��һֱ���̼ұ���֮�أ�����ͳ�ƣ�90%����һ����Ȳ鿴����ǰ������Ϣ���������������л�������������ھ������ֳ��֣������������ľ������֣�\r\n");
	XYBody.Append("		</div>\r\n");
	XYBody.Append("		<div class=\"rk_item\">\r\n");
	XYBody.Append("			<strong>3���Լ۱ȸߣ��ﳬ��ֵ</strong><br />\r\n");
	XYBody.Append("			�۸񼫵ͣ�һ�θ���ȫ���ƹ㣬���һ��г�ֵ��һ�겣��ͨ�������ͣ�\r\n");
	XYBody.Append("		</div>\r\n");
	XYBody.Append("		<br />\r\n");
	XYBody.Append("		<div class=\"rk_cate\"><h2>��ι����������ף�</h2></div>\r\n");
	XYBody.Append("		<div class=\"rk_item\">\r\n");
	XYBody.Append("			<strong>����һ��</strong><br />\r\n");
	XYBody.Append("			ֱ���µ�ͻ�רԱ��<br />����绰��010-6266 9815\r\n");
	XYBody.Append("		</div>\r\n");
	XYBody.Append("		<div class=\"rk_item\">\r\n");
	XYBody.Append("			<strong>��������</strong><br />\r\n");
	XYBody.Append("			�����ύ�������򣬿ͻ�רԱ��������ϵ����\r\n");
	XYBody.Append("		</div>\r\n");
	XYBody.Append("	</div>\r\n");
	XYBody.Append("	<div class=\"RightEndBg\"></div>\r\n");
	XYBody.Append("	  	<div class=\"RightTopBg\" style=\"margin-top:10px;\"></div>\r\n");
	XYBody.Append("		<div class=\"RightMidBg\"><table width=\"96%\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\">\r\n");
	XYBody.Append("      <tr>\r\n");
	XYBody.Append("        <td width=\"200\" height=\"21\"><strong class=\"font14\">����������������ϵ</strong></td>\r\n");
	XYBody.Append("        </tr>\r\n");
	XYBody.Append("      <tr>\r\n");
	XYBody.Append("        <td height=\"55\">010-6266 9815</td>\r\n");
	XYBody.Append("      </tr>\r\n");
	XYBody.Append("    </table>\r\n");
	XYBody.Append("		</div>\r\n");
	XYBody.Append("		<div class=\"RightEndBg\"></div>\r\n");
	XYBody.Append("  </div>\r\n");
	XYBody.Append("  <div class=\"clr\"></div>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<div id=\"layoutBottom\">\r\n");
	XYBody.Append("<div id=\"Binfo\"><a href=\"#\">��������</a> �� <a href=\"#\">��ϵ����</a> �� <a href=\"#\" target=\"_blank\">�̶�����</a> �� <a href=\"#\">��������</a> �� <a href=\"#\">��վ��ͼ</a> ��<a href=\"#\">��������</a> �� <a href=\"#\">��������</a><br />\r\n");
	XYBody.Append("	  �ͷ�����:010-6266 9815,400 6686 816 <br />\r\n");
	XYBody.Append("  <a href=\"http://www.miibeian.gov.cn/\" target=\"_blank\">��ֵ����ҵ��Ӫ���֤:��00-0000000</a> ��Ȩ���� &copy; 2005-2009  <a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("\">");	XYBody.Append(config.webname);	XYBody.Append("</a></div>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("</body>\r\n");
	XYBody.Append("</html>\r\n");

	XYBody.Append(IsCopyright());
	Response.Write(XYBody.ToString());
}
</script>
