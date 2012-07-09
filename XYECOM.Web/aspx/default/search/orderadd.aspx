<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="XYECOM.Page.search.orderadd,XYECOM.Page" %>
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
	XYBody.Append("    <title>");	XYBody.Append(seo.Title);	XYBody.Append("</title>\r\n");
	XYBody.Append("	<meta name=\"description\" content=\"");	XYBody.Append(seo.Description);	XYBody.Append("\" />\r\n");
	XYBody.Append("	<meta name=\"keywords\" content=\"");	XYBody.Append(seo.Keywords);	XYBody.Append("\" />\r\n");
	XYBody.Append("	<meta name=\"robots\" content=\"all\"  />\r\n");
	XYBody.Append("	<meta http-equiv=\"Content-Type\" content=\"text/html;\" charset=\"gb2312\" />\r\n");
	XYBody.Append("	<link rel=\"stylesheet\" href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("common/css/XYLib.css\" type=\"text/css\" media=\"screen\" />\r\n");
	XYBody.Append("	<link href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/css/global.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n");
	XYBody.Append("    <link href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/css/gongqiu.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n");
	XYBody.Append("    <script type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("common/js/base.js\" language=\"javascript\"></" + "script>	\r\n");
	XYBody.Append("	<script type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/js/login.js\" language=\"javascript\"></" + "script>\r\n");
	XYBody.Append("    <script type=\"text/javascript\" src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/js/validate.js\" language=\"javascript\"></" + "script>\r\n");
	XYBody.Append("</head>\r\n");
	XYBody.Append("<body onload=\"");	XYBody.Append(pageinfo.OnLoadEvents);	XYBody.Append("\">\r\n");
	XYBody.Append("<div id=\"wrapper\">\r\n");

	XYBody.Append("<div id=\"hd_info\">\r\n");
	XYBody.Append("    <div id=\"cnts\">\r\n");
	XYBody.Append("        <div id=\"site_cang\">\r\n");
	XYBody.Append("            <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/ico_idx.gif\" width=\"16\"\r\n");
	XYBody.Append("                height=\"16\" alt=\"\" align=\"absmiddle\" />\r\n");
	XYBody.Append("            <a href=\"#\" onclick=\"this.style.behavior='url(#default#homepage)';this.setHomePage('");	XYBody.Append(config.WebURL);	XYBody.Append("');\">\r\n");
	XYBody.Append("                ��Ϊ��ҳ</a>&nbsp;&nbsp;\r\n");
	XYBody.Append("            <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/ico_cang.gif\" width=\"16\"\r\n");
	XYBody.Append("                height=\"16\" alt=\"\" align=\"absmiddle\" />\r\n");
	XYBody.Append("            <a style=\"cursor: hand\" onclick=\"window.external.addFavorite('");	XYBody.Append(config.WebURL);	XYBody.Append("','�ݺ��������')\">\r\n");
	XYBody.Append("                ��Ϊ�ղ�</a>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <div id=\"log_info\">\r\n");
	XYBody.Append("            <div id=\"login\">\r\n");
	XYBody.Append("                �û�����<input type=\"text\" class=\"com\" name=\"top_username\" id=\"top_username\" onkeydown=\"_xy_KeyNext('top_password');\" />\r\n");
	XYBody.Append("                ���룺<input type=\"password\" name=\"top_password\" class=\"com\" id=\"top_password\" onkeydown=\"_xy_KeyPress('_btnTopLogin');\" />\r\n");

	if (config.IsEnabledVCode("login"))
	{

	XYBody.Append("                ��֤�룺 ");	XYBody.Append(pageinfo.GetValidateCodeHTML("top_vcode","top_vimg"));	XYBody.Append("\r\n");

	}	//end if

	XYBody.Append("                <input id=\"_btnTopLogin\" type=\"button\" class=\"top_login\" onclick=\"return xy_TopLogin();\" />\r\n");
	XYBody.Append("                &nbsp;&nbsp;<a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("register.");	XYBody.Append(config.Suffix);	XYBody.Append("\">ע��</a> | <a href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("getPassword.");	XYBody.Append(config.Suffix);	XYBody.Append("\">\r\n");
	XYBody.Append("                    ��������</a> | <a href=\"##\">[VIP��Ա]</a> | <a href=\"##\">��������</a>| <a style=\"color:Red\" href=\"");	XYBody.Append(config.WebURL);	XYBody.Append("quickbuy.");	XYBody.Append(config.Suffix);	XYBody.Append("\">���ٷ�����</a>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <span id=\"logined\" style=\"display: none;\">��ӭ����<font id=\"uname\"></font> | <a id=\"ucenter\">\r\n");
	XYBody.Append("            �ҵ��û�����</a>| <a href=\"");	XYBody.Append(config.weburl);	XYBody.Append("logout.");	XYBody.Append(config.suffix);	XYBody.Append("\">[�˳�]</a> <font id=\"logined_user\"\r\n");
	XYBody.Append("                style=\"display: none;\">��ҵ�û��������</font> <font id=\"logined_person\" style=\"display: none;\">\r\n");
	XYBody.Append("                    �����û��������</font> </span>\r\n");
	XYBody.Append("        <div class=\"clr\">\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<div class=\"clr\">\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<script>    Login2();</" + "script>\r\n");



	XYBody.Append("<div id=\"header\">\r\n");
	XYBody.Append("    <div id=\"local_channel\">\r\n");
	XYBody.Append("        <span class=\"fright\"><a href=\"#\" onclick=\"div_opennew('_xy_div_allarea',200,100);return false;\">\r\n");
	XYBody.Append("            ���е���</a>\r\n");
	XYBody.Append("            <div id=\"_xy_div_allarea\" style=\"display: none\" onmouseover=\"div_mouseover('_xy_div_allarea')\"\r\n");
	XYBody.Append("                onmouseout=\"div_mouseout('_xy_div_allarea');\">\r\n");
	XYBody.Append("                <a href=\"\">ɽ��</a> <a href=\"\">�Ĵ�</a> <a href=\"\">����</a> <a href=\"\">�㶫</a>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </span><strong>����Ƶ����</strong>" +  XYECOMCreateHTML("XY_ASN_shandong").ToString() + " | <a href=\"#\" class=\"waiting\" title=\"��δ��ͨ\">\r\n");
	XYBody.Append("            ����ũҵ��</a> | <a href=\"#\" class=\"waiting\" title=\"��δ��ͨ\">����ũҵ��</a> | <a href=\"#\" class=\"waiting\"\r\n");
	XYBody.Append("                title=\"��δ��ͨ\">����ũҵ��</a> | <a href=\"#\" class=\"waiting\" title=\"��δ��ͨ\">�㶫ũҵ��</a>\r\n");
	XYBody.Append("        | <a href=\"#\" class=\"waiting\" title=\"��δ��ͨ\">�Ĵ�ũҵ��</a>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <div class=\"clr\">\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <div id=\"mains\">\r\n");
	XYBody.Append("        <div id=\"left\">\r\n");
	XYBody.Append("            <div id=\"logo\">\r\n");
	XYBody.Append("                <a href=\"/\">\r\n");
	XYBody.Append("                    <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/logo.gif\" width=\"219\"\r\n");
	XYBody.Append("                        height=\"50\" alt=\"\" border=\"0\" /></a></div>\r\n");
	XYBody.Append("            <div id=\"site_tube\">\r\n");
	XYBody.Append("                [ &nbsp;&nbsp;<a href=\"\" class=\"orange\">�й�ũҵ����վ</a> &nbsp; <a href=\"#\" onclick=\"div_opennew('_xy_div_alltrade',200,100);return false;\"\r\n");
	XYBody.Append("                    class=\"gray\">�л�����վ��</a> <a href=\"#\" onclick=\"div_opennew('_xy_div_alltrade',200,100);return false;\">\r\n");
	XYBody.Append("                        <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/ico_site_chg.gif\"\r\n");
	XYBody.Append("                            width=\"11\" height=\"11\" alt=\"\" align=\"absmiddle\" /></a>&nbsp;&nbsp; ]\r\n");
	XYBody.Append("                <div id=\"_xy_div_alltrade\" style=\"display: none\" onmouseover=\"div_mouseover('_xy_div_alltrade')\"\r\n");
	XYBody.Append("                    onmouseout=\"div_mouseout('_xy_div_alltrade');\">\r\n");
	XYBody.Append("                    <a href=\"\">��վ1</a> <a href=\"\">��վ2</a> <a href=\"\">��վ3</a> <a href=\"\">��վ4</a>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <div id=\"right\">\r\n");
	XYBody.Append("            <div id=\"site_nav\">\r\n");
	XYBody.Append("                <div class=\"c_name\">\r\n");
	XYBody.Append("                    ��ҵƵ��</div>\r\n");
	XYBody.Append("                <div class=\"text\">\r\n");
	XYBody.Append("                    <ul>\r\n");
	XYBody.Append("                        <li><a href=\"\">����</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">����</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">Ů��</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">����</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">ĸӤ</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">����</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">�Ժ�</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">����</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">����</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">����</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">��ѧ</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">����</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">����</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">ԭ��</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">�ƾ�</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">��ѧ</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">�ƾ�</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">��ѧ</a></li>\r\n");
	XYBody.Append("                    </ul>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("                <div class=\"c_name\">\r\n");
	XYBody.Append("                    ������Ѷ</div>\r\n");
	XYBody.Append("                <div class=\"text\">\r\n");
	XYBody.Append("                    <ul>\r\n");
	XYBody.Append("                        <li><a href=\"\">����</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">����</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">Ů��</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">����</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">ĸӤ</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">����</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">�Ժ�</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">����</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">����</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">����</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">��ѧ</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">����</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">����</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">ԭ��</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">�ƾ�</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">��ѧ</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">�ƾ�</a></li>\r\n");
	XYBody.Append("                        <li><a href=\"\">��ѧ</a></li>\r\n");
	XYBody.Append("                    </ul>\r\n");
	XYBody.Append("                </div>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("            <div id=\"hd_bnr\">\r\n");
	XYBody.Append("                <a href=\"\">\r\n");
	XYBody.Append("                    <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/temp_bnr_1.gif\" width=\"163\"\r\n");
	XYBody.Append("                        height=\"76\" alt=\"\" /></a>\r\n");
	XYBody.Append("            </div>\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("        <div class=\"clr\">\r\n");
	XYBody.Append("        </div>\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("    <div class=\"clr\">\r\n");
	XYBody.Append("    </div>\r\n");
	XYBody.Append("</div>\r\n");
	XYBody.Append("<div class=\"clr\">\r\n");
	XYBody.Append("</div>\r\n");


	XYBody.Append("	<div id=\"gq_guide\">\r\n");
	XYBody.Append("		<a href=\"\">����ǰ����λ�ã�<a href=\"/\">��ҳ</a> > ���߶��� </em>\r\n");
	XYBody.Append("	</div>\r\n");
	XYBody.Append("	<div id=\"layout\">\r\n");
	XYBody.Append("		<div id=\"orderLeft\">\r\n");
	XYBody.Append("			<div id=\"LeftProBorder\">\r\n");
	XYBody.Append("				<div id=\"ProTitle\"><span><a href=\"/buyer/list/14.html\">����һ���Ա��Ӳ�Ʒ����</a></span>����");	XYBody.Append(offerinfo.Title.ToString());	XYBody.Append("</div>\r\n");
	XYBody.Append("				<div id=\"ProText\">\r\n");
	XYBody.Append("					<div id=\"ProPic\">\r\n");
	XYBody.Append("						<div id=\"ProPicBorder\">\r\n");
	XYBody.Append("							<a href=\"");	XYBody.Append(offerinfo.MorePicUrl.ToString());	XYBody.Append("\" id=\"viewbigURL\" target=\"_blank\">\r\n");
	XYBody.Append("							<img src=\"" + offerinfo.SmallImg[2].ToString().Trim() + "\" alt=\"");	XYBody.Append(offerinfo.Title.ToString());	XYBody.Append("\" border=\"0\" id=\"viewbigpic\" onload=\"LoadImg(180,180,this)\" /></a>\r\n");
	XYBody.Append("						</div>\r\n");
	XYBody.Append("						<div id=\"ProPicName\">\r\n");
	XYBody.Append("						    <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/big.gif\" style=\"vertical-align:middle\" /> \r\n");
	XYBody.Append("						    <a href=\"");	XYBody.Append(offerinfo.MorePicUrl.ToString());	XYBody.Append("\" target=\"_blank\">");	XYBody.Append(offerinfo.Title.ToString());	XYBody.Append("</a>\r\n");
	XYBody.Append("						</div>\r\n");
	XYBody.Append("					</div>\r\n");
	XYBody.Append("					<div id=\"ProInfo\">\r\n");
	XYBody.Append("						<div id=\"ProInfoB\">\r\n");
	XYBody.Append("							<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	XYBody.Append("									<tr>\r\n");
	XYBody.Append("										<td  height=\"24\" colspan=\"2\">\r\n");

	if (offerinfo.Price==0)
	{

	XYBody.Append("                                            ��ǰ�۸�<span>����</span>");	XYBody.Append(offerinfo.Unit.ToString());	XYBody.Append("\r\n");

	}
	else
	{

	XYBody.Append("                                            ��ǰ�۸�<span>");	XYBody.Append(offerinfo.Price.ToString());	XYBody.Append("</span> Ԫ/");	XYBody.Append(offerinfo.Unit.ToString());	XYBody.Append(" \r\n");

	}	//end if

	XYBody.Append("                                        &nbsp;&nbsp;&nbsp;&nbsp;\r\n");
	XYBody.Append("										</td>\r\n");
	XYBody.Append("									</tr>\r\n");
	XYBody.Append("									<tr>\r\n");
	XYBody.Append("									    <td width=\"50%\">��С�𶩣�");	XYBody.Append(offerinfo.LeastNum.ToString());	XYBody.Append(" ");	XYBody.Append(offerinfo.Unit.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("									</tr>\r\n");
	XYBody.Append("									<tr>\r\n");
	XYBody.Append("										<td width=\"50%\">����������");	XYBody.Append(offerinfo.CountNum.ToString());	XYBody.Append(" ");	XYBody.Append(offerinfo.Unit.ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("									</tr>\r\n");
	XYBody.Append("									<tr>\r\n");
	XYBody.Append("										<td height=\"24\">��Ч������");	XYBody.Append(offerinfo.EndTime.ToShortDateString().ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("									</tr>\r\n");
	XYBody.Append("									<tr>\r\n");
	XYBody.Append("										<td>����ʱ�䣺");	XYBody.Append(offerinfo.PublishTime.ToShortDateString().ToString());	XYBody.Append("</td>\r\n");
	XYBody.Append("									</tr>\r\n");
	XYBody.Append("							</table>\r\n");
	XYBody.Append("						</div>\r\n");
	XYBody.Append("						<div class=\"blank5\"></div>\r\n");
	XYBody.Append("						<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	XYBody.Append("							<tr>\r\n");
	XYBody.Append("								<td width=\"47%\"><span class=\"Font14\">����������ϵ</span>��<strong class=\"orange\" style=\"font-family:Tahoma,'����';\">86-0599-6329616</strong></td>\r\n");
	XYBody.Append("								<td width=\"23%\"></td>\r\n");
	XYBody.Append("							</tr>\r\n");
	XYBody.Append("						</table>\r\n");
	XYBody.Append("					</div>\r\n");
	XYBody.Append("					<div class=\"clr\"></div>\r\n");
	XYBody.Append("					<div id=\"ProDesTitle\"><strong>��ϸ��Ϣ:</strong></div>\r\n");
	XYBody.Append("					<div class=\"ProDesText\">\r\n");
	XYBody.Append("					     <table width=\"95%\" border=\"0\" align=\"center\" cellpadding=\"1\" cellspacing=\"1\" class=\"typelist\"></table>\r\n");
	XYBody.Append("					     ");	XYBody.Append(offerinfo.InfoContent.ToString());	XYBody.Append("\r\n");
	XYBody.Append("					</div>\r\n");
	XYBody.Append("				</div>\r\n");
	XYBody.Append("			</div>\r\n");
	XYBody.Append("		 </form>\r\n");
	XYBody.Append("			<div id=\"SayInfo\">\r\n");
	XYBody.Append("				<strong>��������</strong>��������Ϣ�������ҵ�����ṩ������ҵ������Ϣ���ݵ���ʵ�ԡ�׼ȷ�ԺͺϷ��ԡ�\r\n");
	XYBody.Append("				<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");	XYBody.Append(config.webname);	XYBody.Append("�Դ˲��е��κα�֤���Ρ�\r\n");
	XYBody.Append("			</div>\r\n");
	XYBody.Append("		</div>\r\n");
	XYBody.Append("	    <div id=\"orderRight\">\r\n");
	XYBody.Append("	        <table>\r\n");
	XYBody.Append("	            <caption>ȷ���ջ���Ϣ:</caption>\r\n");
	XYBody.Append("	            <tr>\r\n");
	XYBody.Append("	                <th>��ϵ�ˣ�</th>\r\n");
	XYBody.Append("	            </tr>\r\n");
	XYBody.Append("	            <tr>\r\n");
	XYBody.Append("	                <td><input type=\"text\" id=\"txtLinkMan\" value=\"");	XYBody.Append(userinfo.linkman.ToString());	XYBody.Append("\"/></td>\r\n");
	XYBody.Append("	            </tr>\r\n");
	XYBody.Append("	            <tr>\r\n");
	XYBody.Append("	                <th>��ϵ�绰��</th>\r\n");
	XYBody.Append("	            </tr>\r\n");
	XYBody.Append("	            <tr>\r\n");
	XYBody.Append("	                <td><textarea id=\"txtLinkTelphone\" rows=\"3\" cols=\"40\">");	XYBody.Append(userinfo.telephone.ToString());	XYBody.Append("</textarea></td>\r\n");
	XYBody.Append("	            </tr>\r\n");
	XYBody.Append("	            <tr>\r\n");
	XYBody.Append("	                <th>�ͻ���ַ��</th>\r\n");
	XYBody.Append("	            </tr>\r\n");
	XYBody.Append("	            <tr>\r\n");
	XYBody.Append("	                <td><textarea id=\"txtLinkAddress\" rows=\"4\" cols=\"40\">");	XYBody.Append(userinfo.address.ToString());	XYBody.Append("</textarea></td>\r\n");
	XYBody.Append("	            </tr>\r\n");
	XYBody.Append("	        </table>\r\n");
	XYBody.Append("	        <table>\r\n");
	XYBody.Append("	            <caption>ȷ�Ϲ�������:</caption>\r\n");
	XYBody.Append("	            <tr>\r\n");
	XYBody.Append("	                 <th width=\"30%\">��ǰ�ۣ�</th>\r\n");
	XYBody.Append("	                 <td width=\"70%\"><span>");	XYBody.Append(offerinfo.Price.ToString());	XYBody.Append("</span>Ԫ/");	XYBody.Append(offerinfo.Unit.ToString());	XYBody.Append("<input  name=\"ProductPrice\" id=\"ProductPrice\" type=\"hidden\" value=\"");	XYBody.Append(offerinfo.Price.ToString());	XYBody.Append("\" /></td>\r\n");
	XYBody.Append("	            </tr>\r\n");
	XYBody.Append("	            <tr>\r\n");
	XYBody.Append("	                <th>����������</th>\r\n");
	XYBody.Append("	                <td>\r\n");
	XYBody.Append("	                    <input type=\"text\" name=\"txtNumber\" id=\"txtNumber\"  onchange=\"getMoney(this)\" class=\"inputtext\"  maxlength=\"5\" size=\"5\"/> ");	XYBody.Append(offerinfo.Unit.ToString());	XYBody.Append("\r\n");
	XYBody.Append("                        <input  name=\"ProductSmallNum\" id=\"ProductSmallNum\" type=\"hidden\" value=\"");	XYBody.Append(offerinfo.LeastNum.ToString());	XYBody.Append("\" />	\r\n");
	XYBody.Append("	               </td>\r\n");
	XYBody.Append("	            </tr>\r\n");
	XYBody.Append("	            <tr>\r\n");
	XYBody.Append("	                <th>�ܼۣ�</th>\r\n");
	XYBody.Append("	                <td>\r\n");
	XYBody.Append("	                    <span id=\"OrderMoney\" >0 </span>Ԫ<input  name=\"cp_id\" id=\"cp_id\" type=\"hidden\" value=\"");	XYBody.Append(offerinfo.InfoID.ToString());	XYBody.Append("\" />\r\n");
	XYBody.Append("	               </td>\r\n");
	XYBody.Append("	            </tr>\r\n");

	if (config.IsEnabledVCode("order"))
	{

	XYBody.Append("	            <tr>\r\n");
	XYBody.Append("	                <th>��֤�룺</th>\r\n");
	XYBody.Append("	                <td>");	XYBody.Append(pageinfo.GetValidateCodeHTML());	XYBody.Append("</td>\r\n");
	XYBody.Append("	            </tr>\r\n");

	}	//end if

	XYBody.Append("                <tr>\r\n");
	XYBody.Append("                    <td colspan=\"2\"><input name=\"\" type=\"submit\" onclick =\"return InsertOrder();\" value=\"ȷ�����󣬹���\" /></td>\r\n");
	XYBody.Append("                </tr>\r\n");
	XYBody.Append("	        </table>\r\n");
	XYBody.Append("	    </div>\r\n");
	XYBody.Append("	</div>\r\n");

	XYBody.Append("	<div id=\"footer\">\r\n");
	XYBody.Append("		<a href=\"\">������ҳ</a> | <a href=\"/about/index.htm\" target=\"_blank\">��������</a> | <a href=\"\">��������</a> | <a href=\"\">ý�屨��</a> | <a href=\"\">��ƸӢ��</a> | <a href=\"\">����ר��</a> | <a href=\"\">���ר��</a> | <a href=\"\">��������</a> | <a href=\"\">��ϵ����</a> | <a href=\"\">��վ��ͼ</a>\r\n");
	XYBody.Append("	</div>\r\n");
	XYBody.Append("	<div id=\"copyright\">\r\n");
	XYBody.Append("		<div id=\"copy_info\">\r\n");
	XYBody.Append("			<ul>\r\n");
	XYBody.Append("				<li>Copyright &copy; 2005-2009  &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<a href=\"#\" target=\"_blank\">��ICP��05003331��</a></li>\r\n");
	XYBody.Append("				<li><img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/ico_phone.gif\" align=\"absmiddle\">�绰��86-010-62669815 ���棺86-010-86818791  <img src=\"");	XYBody.Append(config.WebURL);	XYBody.Append("templates/");	XYBody.Append(config.TemplatePath);	XYBody.Append("/images/ico_email.gif\" />E-Mail��<a href=\"#\">info@xyecom.com </a></li>\r\n");
	XYBody.Append("				<li>��Ȩ���С��ݺ�������� - ��������С��ҵ��������Ӧ�ü�������δ����Ȩ����ת��</li>\r\n");
	XYBody.Append("			</ul>			\r\n");
	XYBody.Append("		</div>\r\n");
	XYBody.Append("		<div class=\"copyright_i\">\r\n");
	XYBody.Append("		 <div class=\"com copyright_i1\"><p class=\"p\"><a href=\"#\" target=\"_blank\">�������羯�챨��ƽ̨</a></p></div>\r\n");
	XYBody.Append("		 <div class=\"com copyright_i2\"><p class=\"p\">������Ϣ��ȫ������</p></div>\r\n");
	XYBody.Append("		 <div class=\"com copyright_i3\"><p class=\"p\"><a href=\"#\" target=\"_blank\">��Ӫ����վ������Ϣ</a></p></div>\r\n");
	XYBody.Append("		 <div class=\"com copyright_i4\"><p class=\"p\"><a href=\"#\" target=\"_blank\">������Ϣ�ٱ�����</a></p></div>\r\n");
	XYBody.Append("		</div>\r\n");
	XYBody.Append("	 </div>\r\n");


	XYBody.Append("</div>\r\n");
	XYBody.Append("</body>\r\n");
	XYBody.Append("</html>\r\n");

	XYBody.Append(IsCopyright());
	Response.Write(XYBody.ToString());
}
</script>
