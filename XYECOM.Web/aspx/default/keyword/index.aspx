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
	XYBody.Append("	<title> 固定排名-");	XYBody.Append(config.webname);	XYBody.Append("</title>\r\n");
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
	XYBody.Append("		<div id=\"quick_link\"><a href=\"\">会员登录</a> <a href=\"\">使用帮助</a></div>\r\n");
	XYBody.Append("	</div>\r\n");
	XYBody.Append("	<div id=\"rank_nav\">\r\n");
	XYBody.Append("		<ul>\r\n");
	XYBody.Append("			<li><a href=\"\"><span>首 页</span></a></li>\r\n");
	XYBody.Append("			<li><a href=\"\" class=\"current\"><span>查询排名情况</span></a></li>\r\n");
	XYBody.Append("			<li><a href=\"\"><span>购买排名</span></a></li>\r\n");
	XYBody.Append("			<li><a href=\"\"><span>帮助中心</span></a></li>\r\n");
	XYBody.Append("			<li><a href=\"\"><span>联系我们</span></a></li>\r\n");
	XYBody.Append("			<li><a href=\"\" class=\"current\"><span>多长的字都可以哦</span></a></li>\r\n");
	XYBody.Append("		</ul>\r\n");
	XYBody.Append("	</div>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<div id=\"layoutBnner\">\r\n");
	XYBody.Append("<div id=\"layoutBnnerT\"><strong class=\"font14 whitefont\">什么是固定排名？</strong><br /><br />\r\n");
	XYBody.Append("固定排名是");	XYBody.Append(config.webname);	XYBody.Append("推出的的信息排名服务，买家在");	XYBody.Append(config.webname);	XYBody.Append("查看或者搜索相关产品、企业信息时，固定排名企业的信息将排在搜索结果的前三位，能够被买家第一时间就找到。</div>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<!--主体部分-->\r\n");
	XYBody.Append("<div id=\"layoutMain\">\r\n");
	XYBody.Append("  <div id=\"layoutMainL\">\r\n");
	XYBody.Append("  <div id=\"Lsearch\">\r\n");
	XYBody.Append("    <form id=\"form1\" name=\"form1\" method=\"post\" action=\"\" onsubmit=\"\">\r\n");
	XYBody.Append("      <input type=\"text\" id=\"keyword\" name=\"keyword\" class=\"keyclass\" onload=\"if(this.value=='')this.value='请输入您所要查询的关键词';\" onfocus=\"if(this.value=='请输入您所要查询的关键词') this.value = '';\" value=\"");	XYBody.Append(keyword.ToString());	XYBody.Append("\"/> \r\n");
	XYBody.Append("      <input type=\"submit\" name=\"Submit\" value=\"  \" class=\"keybut\" />\r\n");
	XYBody.Append("    </form>\r\n");
	XYBody.Append("    </div>\r\n");

	if (keyData.Rows.Count>0)
	{

	XYBody.Append("     <table class=\"rankTable\" style=\"width:100%; float:left;\">\r\n");
	XYBody.Append("            <thead>\r\n");
	XYBody.Append("                <tr class=\"title\">\r\n");
	XYBody.Append("                    <td>关键词</td>\r\n");
	XYBody.Append("                    <td>相关信息</td>\r\n");
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
	XYBody.Append("                                <th align=\"center\">名次</th>\r\n");
	XYBody.Append("                                <th align=\"left\">状态信息</th>\r\n");
	XYBody.Append("                                <th align=\"center\">购买</th>\r\n");
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
	XYBody.Append("	      <p><strong class=\"redfont\" style=\"font-size:14px;\">固定排名的费用：</strong><br />\r\n");
	XYBody.Append("	        排名第一位：300元/月<br />\r\n");
	XYBody.Append("	        排名第二位：200元/月<br />\r\n");
	XYBody.Append("	        排名第三位：100元/月<br />\r\n");
	XYBody.Append("	        如有疑问，请与<a href=\"Contact.htm\" target=\"_blank\"><strong>联系我们</strong></a></p>\r\n");
	XYBody.Append("	    </div>\r\n");
	XYBody.Append("	    <div class=\"clr\"></div>\r\n");
	XYBody.Append("	</div>\r\n");

	}	//end if

	XYBody.Append("	<div id=\"Lfix_xg2\"></div>\r\n");
	XYBody.Append("	<div id=\"Lfix_show\">\r\n");
	XYBody.Append("	<table class=\"tabHotKey\">\r\n");
	XYBody.Append("	    <tr>\r\n");
	XYBody.Append("	        <th>热门关键词</th>\r\n");
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
	XYBody.Append("	        <th>最新关键词</th>\r\n");
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
	XYBody.Append("		<div class=\"rk_cate\"><h2>为什么要购买固定排名？</h2></div>\r\n");
	XYBody.Append("		<div class=\"rk_item\">\r\n");
	XYBody.Append("			<strong>1、提升品牌形象,迅速扩大客户群</strong><br />\r\n");
	XYBody.Append("			在这里，98％的买家通过搜索关键词去寻找合适的卖家，排名三甲在此醒目位置出现，其展现率及客户访问量可想而知！\r\n");
	XYBody.Append("		</div>\r\n");
	XYBody.Append("		<div class=\"rk_item\">\r\n");
	XYBody.Append("			<strong>2、信息排前三，获得更多买家关注</strong><br />\r\n");
	XYBody.Append("			排名前列一直是商家必争之地！根据统计，90%的买家会优先查看排名前三的信息，因此在搜索结果中获得排名，优先于竞争对手出现，将领先于您的竞争对手！\r\n");
	XYBody.Append("		</div>\r\n");
	XYBody.Append("		<div class=\"rk_item\">\r\n");
	XYBody.Append("			<strong>3、性价比高，物超所值</strong><br />\r\n");
	XYBody.Append("			价格极低，一次付费全年推广，并且还有超值的一年玻璃通服务赠送！\r\n");
	XYBody.Append("		</div>\r\n");
	XYBody.Append("		<br />\r\n");
	XYBody.Append("		<div class=\"rk_cate\"><h2>如何购买排名三甲？</h2></div>\r\n");
	XYBody.Append("		<div class=\"rk_item\">\r\n");
	XYBody.Append("			<strong>方法一：</strong><br />\r\n");
	XYBody.Append("			直接致电客户专员。<br />服务电话：010-6266 9815\r\n");
	XYBody.Append("		</div>\r\n");
	XYBody.Append("		<div class=\"rk_item\">\r\n");
	XYBody.Append("			<strong>方法二：</strong><br />\r\n");
	XYBody.Append("			在线提交购买意向，客户专员将尽快联系您。\r\n");
	XYBody.Append("		</div>\r\n");
	XYBody.Append("	</div>\r\n");
	XYBody.Append("	<div class=\"RightEndBg\"></div>\r\n");
	XYBody.Append("	  	<div class=\"RightTopBg\" style=\"margin-top:10px;\"></div>\r\n");
	XYBody.Append("		<div class=\"RightMidBg\"><table width=\"96%\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\">\r\n");
	XYBody.Append("      <tr>\r\n");
	XYBody.Append("        <td width=\"200\" height=\"21\"><strong class=\"font14\">有疑问请与我们联系</strong></td>\r\n");
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
	XYBody.Append("<div id=\"Binfo\"><a href=\"#\">关于我们</a> │ <a href=\"#\">联系我们</a> │ <a href=\"#\" target=\"_blank\">固定排名</a> │ <a href=\"#\">法律声明</a> │ <a href=\"#\">网站地图</a> │<a href=\"#\">工作机会</a> │ <a href=\"#\">帮助中心</a><br />\r\n");
	XYBody.Append("	  客服热线:010-6266 9815,400 6686 816 <br />\r\n");
	XYBody.Append("  <a href=\"http://www.miibeian.gov.cn/\" target=\"_blank\">增值电信业务经营许可证:京00-0000000</a> 版权所有 &copy; 2005-2009  <a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("\">");	XYBody.Append(config.webname);	XYBody.Append("</a></div>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("</body>\r\n");
	XYBody.Append("</html>\r\n");

	XYBody.Append(IsCopyright());
	Response.Write(XYBody.ToString());
}
</script>
