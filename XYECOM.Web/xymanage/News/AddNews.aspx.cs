using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Data.SqlClient;
using XYECOM.Core;
using XYECOM.Business;
using System.Net;
using System.IO;
using System.Text;

public partial class xymanage_news_AddNews : XYECOM.Web.BasePage.ManagePage
{
    protected Int64 newsId = 0;

    private static XYECOM.Model.NewsInfo newsInfo = new XYECOM.Model.NewsInfo();
    private static XYECOM.Business.Supply SupplyBLL = new Supply();

    #region 定义页面加载事件
    /// <summary>
    /// 定义页面加载事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpContext.Current.Response.Buffer = true;
        HttpContext.Current.Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
        HttpContext.Current.Response.Expires = 0;

        CheckRole("news");
        if (!IsPostBack)
        {
            addlistBind();

            this.imagetype.Value = webInfo.UploadFileType;

            newsId = XYECOM.Core.XYRequest.GetQueryInt64("id");

            if (newsId > 0)
            {

                UploadFile1.InfoID = newsId;
                UploadFile2.InfoID = newsId;

                NewsDataBind(newsId);
                //this.AddOrUpdate的值为0，则表示修改新闻
                this.AddOrUpdate.Value = "0";
            }
            else
            {
                newsInfo = new XYECOM.Model.NewsInfo();
                InitOption("");
                //this.AddOrUpdate的值为1,则表示添加新闻               
                this.AddOrUpdate.Value = "1";
                this.rbcommonnews.Checked = true;
                this.hipictype.Value = "0";
                this.reswords.Text = "";
                this.IsContributor.Visible = false;
                this.tbnewsauthor.Text = webInfo.WebName;
                this.tbnewsorigin.Text = webInfo.WebName;
                this.infoIds.Value = "";
                //ClientScript.RegisterStartupScript(GetType(), Guid.NewGuid().ToString(), "myclick('" + this.rbpicupload.ClientID + "','click');", true);
                //ClientScript.RegisterStartupScript(GetType(), Guid.NewGuid().ToString(), "myclick('" + this.rbcommonnews.ClientID + "','click');", true);                
            }

            #region 加载JS事件
            this.rbcommonnews.Attributes.Add("onclick", "javascript:return TypeChange();");
            this.rbpicnews.Attributes.Add("onclick", "javascript:return TypeChange();");
            this.rbcaptionnews.Attributes.Add("onclick", "javascript:return TypeChange();");

            this.btadadd.Attributes.Add("onclick", "javascript:return Input();");
            this.ddlnewsauthor.Attributes.Add("onchange", "javascript:return getauthor();");
            this.ddlnewsorigin.Attributes.Add("onchange", "javascript:return getorigin();");
            this.rbpicurl.Attributes.Add("onclick", "javascript:return ChangePicType();");
            this.rbpicupload.Attributes.Add("onclick", "javascript:return ChangePicType();");
            #endregion
        }
    }
    #endregion

    #region 绑定新闻作者数据记录
    private void addlistBind()
    {
        XYECOM.Business.NewsAuthor na = new XYECOM.Business.NewsAuthor();
        XYECOM.Business.NewsOrigin no = new XYECOM.Business.NewsOrigin();
        this.ddlnewsauthor.DataSource = na.GetDataTable("", "");
        this.ddlnewsauthor.DataTextField = "NA_Name";
        this.ddlnewsauthor.DataValueField = "NA_Name";
        this.ddlnewsauthor.DataBind();
        this.ddlnewsauthor.Items.Insert(0, new ListItem("--请选择--", ""));


        this.ddlnewsorigin.DataSource = no.GetDataTable("", "");
        this.ddlnewsorigin.DataTextField = "NO_Name";
        this.ddlnewsorigin.DataValueField = "NO_Name";
        this.ddlnewsorigin.DataBind();
        this.ddlnewsorigin.Items.Insert(0, new ListItem("--请选择--", ""));
    }
    #endregion

    #region 绑定要修改的新闻信息
    /// <summary>
    /// 绑定要修改的新闻信息
    /// </summary>
    /// <param name="id">要修改的新闻ID</param>
    private void NewsDataBind(Int64 id)
    {
        newsInfo = new XYECOM.Business.News().GetItem(newsId);

        if (newsInfo != null)
        {
            string newstypeckId = "";
            //新闻类型
            if (newsInfo.Type == XYECOM.Model.NewsType.TextNews)
            {
                this.rbcommonnews.Checked = true;
                this.rbpicnews.Checked = false;
                this.rbcaptionnews.Checked = false;
                newstypeckId = this.rbcommonnews.ClientID;
            }
            else if (newsInfo.Type == XYECOM.Model.NewsType.ImageNews)
            {
                this.rbpicnews.Checked = true;
                this.rbcommonnews.Checked = false;
                this.rbcaptionnews.Checked = false;
                newstypeckId = this.rbpicnews.ClientID;
            }
            else if (newsInfo.Type == XYECOM.Model.NewsType.HeadlineNews)
            {
                this.rbcaptionnews.Checked = true;
                this.rbcommonnews.Checked = false;
                this.rbpicnews.Checked = false;
                newstypeckId = this.rbcaptionnews.ClientID;
            }

            this.tbnewsname.Text = newsInfo.Title;

            //if (newsInfo.FileUrl != "")
            //{
            //    rbfileUrl.Checked = true;
            //    txtfileUrl.Text = newsInfo.FileUrl;
            //}

            if (!newsInfo.TitleStyle.Equals(""))
            {
                string[] strs = newsInfo.TitleStyle.Split(';');

                foreach (string s in strs)
                {
                    if (s.Equals("")) continue;

                    string[] ss = s.Split(':');

                    if (ss.Length != 2) continue;

                    if (ss[0].Equals("color"))
                    {
                        this.txtTitleColor.Value = ss[1];
                        this.selTitleColor.Value = ss[1];
                    }

                    if (ss[0].Equals("font-weight")) this.chkFontBold.Checked = true;

                    if (ss[0].Equals("font-style")) this.chkFontItalic.Checked = true;

                    if (ss[0].Equals("text-decoration")) this.chkFontUnderline.Checked = true;
                }
            }

            if (newsInfo.TypeIds != "")
            {
                this.hdgetid.Value = XYECOM.Core.Utils.RemoveComma(newsInfo.TypeIds.ToString());
            }

            hidTopicID.Value = newsInfo.TopicType;

            this.tbtwoname.Text = newsInfo.SubTitle;
            this.reswords.Text = newsInfo.Keyword;
            this.tbnewsness.Text = newsInfo.Leadin;
            this.tblinkaddress.Text = newsInfo.HeadlineNewsUrl;

            //附件信息
            DataTable tableAttInfo = new XYECOM.Business.Attachment().GetDataTable(newsInfo.NewsId, XYECOM.Model.AttachmentItem.News, XYECOM.Model.UploadFileType.Image);
            string uploadTypeckId = "";
            if (tableAttInfo.Rows.Count > 0 && newsInfo.PicUrl.Equals("Image"))
            {
                this.rbpicupload.Checked = true;
                this.rbpicurl.Checked = false;

                uploadTypeckId = this.rbpicupload.ClientID;
            }
            else
            {
                this.hipictype.Value = "-1";
                this.hdpicurl.Value = newsInfo.PicUrl;
                this.rbpicurl.Checked = true;
                this.rbpicupload.Checked = false;
                this.tbpinurl.Value = newsInfo.PicUrl;
                uploadTypeckId = this.rbpicurl.ClientID;
            }


            this.tbnewsauthor.Text = newsInfo.Author;
            this.ddlnewsauthor.SelectedValue = this.tbnewsauthor.Text.Trim();
            this.tbnewsorigin.Text = newsInfo.Origin;
            this.ddlnewsorigin.SelectedValue = this.tbnewsorigin.Text.Trim();
            this.newsBody.Value = newsInfo.Content;

            if (newsInfo.AddTime != "")
            {
                try
                {
                    this.tbaddtime.Value = Convert.ToDateTime(newsInfo.AddTime).ToShortDateString();
                }
                catch
                {
                    this.tbaddtime.Value = DateTime.Now.ToShortDateString();
                }
            }


            this.tbcount.Text = newsInfo.ClickNumber.ToString();

            this.cbIsFlag.Checked = newsInfo.IsCommend;

            this.cbIsDiscuss.Checked = newsInfo.IsAllowComment;

            this.cbIsTop.Checked = newsInfo.IsTop;

            this.cbIsHot.Checked = newsInfo.IsHot;

            this.cbIsSlide.Checked = newsInfo.IsSlide;

            if (newsInfo.State == XYECOM.Model.AuditingState.NoPass)
            {
                this.cbAuditing.Checked = false;
            }
            if (newsInfo.State == XYECOM.Model.AuditingState.Passed)
            {
                this.cbAuditing.Checked = true;
            }

            if (newsInfo.ChargeState != "1")
            {
                if (newsInfo.HTMLPage != "")
                {
                    this.cbcreate.Checked = true;
                }
            }
            else
            {
                this.cbcreate.Enabled = false;
            }

            if (newsInfo.Contributor.Equals(0))
            {
                this.IsContributor.Visible = false;
            }
            else
            {
                if (newsInfo.Contributor.ToString() == "-1")
                {
                    this.Contributor.InnerHtml = "<a href=\"#\">游客</a>";
                }
                else
                {
                    XYECOM.Business.UserReg urBLL = new UserReg();
                    XYECOM.Model.UserRegInfo urinfo = new XYECOM.Model.UserRegInfo();
                    urinfo = urBLL.GetItem(newsInfo.Contributor);
                    this.Contributor.InnerHtml = "<a href=\"../UserManage/UserInfo.aspx?U_ID=" + newsInfo.Contributor + "&backURL=../news/AddNews.aspx?id=" + newsId + "&" + XYECOM.Core.XYRequest.GetQueryString("backURL") + "\">" + newsInfo.Author + "(企业会员)</a>";
                }

            }

            this.city.Value = XYECOM.Core.Utils.RemoveComma(newsInfo.AreaIds);

            this.tradeid.Value = XYECOM.Core.Utils.RemoveComma(newsInfo.TradeIds);

            this.offerid.Value = XYECOM.Core.Utils.RemoveComma(newsInfo.ProtypeIds);

            InitOption(newsInfo.FileUrl);

            ClientScript.RegisterStartupScript(GetType(), Guid.NewGuid().ToString(), "myclick('" + newstypeckId + "','click');", true);
            ClientScript.RegisterStartupScript(GetType(), Guid.NewGuid().ToString(), "myclick('" + uploadTypeckId + "','click');", true);

            if (newsInfo.IsScheme == 1)
                this.cbIsScheme.Checked = true;

            if (newsInfo.IsScheme != 0 && newsInfo.ProIds != null)
            {
                string StrHtml = "";
                string[] IdsArry = newsInfo.ProIds.Split(',');
                string ItemStr = "";

                for (int i = 0; i < IdsArry.Length; i++)
                {
                    if (IdsArry[i] != null)
                    {
                        XYECOM.Model.SupplyInfo SupplyInfo = SupplyBLL.GetSupplyById(XYECOM.Core.MyConvert.GetInt32(IdsArry[i]));

                        StrHtml += "<input checked='checked' onclick=\"Selectchange('" + IdsArry[i] + "')\" type='checkbox' id='cbsel_" + IdsArry[i] + "' value='" + IdsArry[i] + "'/><label>" + SupplyInfo.Title + "</label>";
                        ItemStr += IdsArry[i] + ":" + SupplyInfo.Title + ",";
                    }
                }
                this.Infostxt.Text = StrHtml;
                this.HidItemStr.Value = ItemStr.Substring(0, ItemStr.Length - 1);
            }
        }
    }
    #endregion

    #region 定义确定添加事件
    /// <summary>
    /// 定义确定添加事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btadadd_Click(object sender, EventArgs e)
    {

        XYECOM.Business.NewsAuthor newsAuthorBLL = new XYECOM.Business.NewsAuthor();
        XYECOM.Business.News newsBLL = new XYECOM.Business.News();
        XYECOM.Business.NewsTitles newsTitlesBLL = new XYECOM.Business.NewsTitles();

        XYECOM.Model.NewsAuthorInfo newsAuthorInfo = new XYECOM.Model.NewsAuthorInfo();

        if (this.cbnewsauthor.Checked == true && this.tbnewsauthor.Text.ToString() != "")
        {
            int authorId = 0;
            newsAuthorInfo.NA_Name = this.tbnewsauthor.Text.ToString().Trim();
            int rowauthor = newsAuthorBLL.Insert(newsAuthorInfo, out authorId);
        }

        XYECOM.Business.NewsOrigin newsOriginBLL = new XYECOM.Business.NewsOrigin();
        XYECOM.Model.NewsOriginInfo newsOriginInfo = new XYECOM.Model.NewsOriginInfo();

        if (this.cbnewsorigin.Checked == true && this.tbnewsorigin.Text.ToString() != "")
        {
            int originId = 0;
            newsOriginInfo.NO_Name = this.tbnewsorigin.Text.ToString().Trim();
            int rowOrigin = newsOriginBLL.Insert(newsOriginInfo, out originId);
        }

        newsInfo.Title = this.tbnewsname.Text.Trim();

        newsInfo.SubTitle = this.tbtwoname.Text.Trim();

        string titleStyle = "";

        if (!this.txtTitleColor.Value.Trim().Equals("")) titleStyle += "color:" + this.txtTitleColor.Value.Trim() + ";";

        if (this.chkFontBold.Checked) titleStyle += "font-weight:bold;";

        if (this.chkFontItalic.Checked) titleStyle += "font-style:italic;";

        if (this.chkFontUnderline.Checked) titleStyle += "text-decoration:underline";

        newsInfo.TitleStyle = titleStyle;

        newsInfo.TopicType = hidTopicID.Value.Trim();

        newsInfo.Keyword = this.reswords.Text.ToString().Replace("，", ",").Replace(" ", "");
        newsInfo.Leadin = this.tbnewsness.Text.Trim();

        if (this.tbaddtime.Value.ToString() != "" && this.tbaddtime.Value.StartsWith("NaN") != true)
            newsInfo.AddTime = this.tbaddtime.Value;
        else
            newsInfo.AddTime = DateTime.Now.ToString();

        newsInfo.ClickNumber = XYECOM.Core.MyConvert.GetInt32(this.tbcount.Text.Trim());

        if (this.cbIsFlag.Checked)
            newsInfo.IsCommend = true;
        else
            newsInfo.IsCommend = false;

        if (this.cbIsDiscuss.Checked)
            newsInfo.IsAllowComment = true;
        else
            newsInfo.IsAllowComment = false;

        if (this.cbIsTop.Checked)
            newsInfo.IsTop = true;
        else
            newsInfo.IsTop = false;

        if (this.cbIsHot.Checked)
            newsInfo.IsHot = true;
        else
            newsInfo.IsHot = false;

        if (this.cbIsSlide.Checked)
            newsInfo.IsSlide = true;
        else
            newsInfo.IsSlide = false;


        if (this.cbAuditing.Checked)
        {
            newsInfo.State = XYECOM.Model.AuditingState.Passed;
        }
        else
        {
            newsInfo.State = XYECOM.Model.AuditingState.NoPass;
        }

        newsInfo.AreaIds = XYECOM.Core.Utils.AppendComma(city.Value);

        newsInfo.TradeIds = XYECOM.Core.Utils.AppendComma(tradeid.Value);

        newsInfo.ProtypeIds = XYECOM.Core.Utils.AppendComma(offerid.Value);

        if (this.cbIsScheme.Checked)
        {
            newsInfo.IsScheme = 1;
        }
        else
        {
            newsInfo.IsScheme = 0;
        }

        if (this.HidItemStr.Value != "")
        {
            string[] HSA = this.HidItemStr.Value.Split(',');
            string StrIds = "";

            for (int i = 0; i < HSA.Length; i++)
            {
                StrIds += HSA[i].Split(':')[0] + ",";
            }

            newsInfo.ProIds = StrIds.Substring(0, StrIds.Length - 1);
        }
        else
        {
            newsInfo.ProIds = "";
        }

        //如果是普通新闻，获取各参数
        if (rbcommonnews.Checked == true)
        {
            newsInfo.Type = XYECOM.Model.NewsType.TextNews;
            newsInfo.HeadlineNewsUrl = "";
            newsInfo.PicUrl = "";
            newsInfo.Author = "";

            if (!this.tbnewsauthor.Text.Trim().Equals(""))
                newsInfo.Author = this.tbnewsauthor.Text.Trim();
            else if (this.ddlnewsauthor.SelectedValue != "")
                newsInfo.Author = this.ddlnewsauthor.SelectedValue;

            newsInfo.Origin = "";

            if (!this.tbnewsorigin.Text.Trim().Equals(""))
                newsInfo.Origin = this.tbnewsorigin.Text.Trim();
            else if (this.ddlnewsorigin.SelectedValue != "")
                newsInfo.Origin = this.tbnewsorigin.Text.Trim();

            newsInfo.Content = this.newsBody.Value;
        }
        //如果是图片新闻，获取各参数
        else if (rbpicnews.Checked == true)
        {
            this.cbIsSlide.Visible = true;
            newsInfo.Type = XYECOM.Model.NewsType.ImageNews;
            newsInfo.HeadlineNewsUrl = "";

            if (this.rbpicurl.Checked == true && this.tbpinurl.Value != "")
                newsInfo.PicUrl = this.tbpinurl.Value.Trim();
            else if (this.rbpicupload.Checked == true)
                newsInfo.PicUrl = "Image";


            if (this.tbnewsauthor.Text == "")
            {
                this.hipictype.Value = "-1";
                newsInfo.Author = this.ddlnewsauthor.SelectedValue;
            }
            else
                newsInfo.Author = this.tbnewsauthor.Text;

            if (this.tbnewsorigin.Text == "")
                this.tbnewsorigin.Text = this.ddlnewsorigin.SelectedValue;
            else
                newsInfo.Origin = this.tbnewsorigin.Text;

            newsInfo.Content = this.newsBody.Value;
        }
        //如果是标题新闻，获取各参数
        else if (rbcaptionnews.Checked == true)
        {
            this.cbIsSlide.Visible = true;
            newsInfo.Type = XYECOM.Model.NewsType.HeadlineNews;
            newsInfo.HeadlineNewsUrl = this.tblinkaddress.Text;
            newsInfo.Author = "";
            newsInfo.Origin = "";
            newsInfo.PicUrl = "";

            if (this.rbpicurl.Checked == true && this.tbpinurl.Value != "")
            {
                this.hipictype.Value = "-1";
                newsInfo.PicUrl = this.tbpinurl.Value.Trim();
            }
            else if (this.rbpicupload.Checked == true)
            {
                newsInfo.PicUrl = "Image";
            }

            newsInfo.Content = "";


        }
        //记录发布人ID
        newsInfo.UM_ID = AdminId;

        Int64 ID = 0;
        int rowAff = 0;
        if (this.AddOrUpdate.Value.ToString() == "1")
        {
            newsInfo.HTMLPage = "";
            if (this.hdgetid.Value != null)   //新闻栏目编号集
            {
                newsInfo.TypeIds = XYECOM.Core.Utils.AppendComma(this.hdgetid.Value.ToString().Trim());

                int total = XYECOM.Core.MyConvert.GetInt32(this.OptionTotal.Value.ToString());

                string option = "";
                string filename = "";

                newsInfo.FileUrl = "";

                for (int i = 1; i <= total; i++)
                {
                    option = XYECOM.Core.XYRequest.GetFormString("option" + i).Trim();
                    filename = XYECOM.Core.XYRequest.GetFormString("filename" + i).Trim();

                    if (string.IsNullOrEmpty(option)) continue;

                    if (filename == "") filename = "附件" + i;

                    if (newsInfo.FileUrl.Equals(""))
                        newsInfo.FileUrl = filename + "$" + option.ToString();
                    else
                        newsInfo.FileUrl = newsInfo.FileUrl + "|" + filename + "$" + option.ToString();
                }

                rowAff = newsBLL.Insert(newsInfo, out ID);

                if (this.cbcreate.Checked)
                {
                    CreateHTML(ID.ToString(), "news", "news");
                }

                if (rowAff == -2)
                {
                    Alert("添加失败,可重新操作.", "NewsList.aspx");
                }
                else if (rowAff == -1)
                {
                    Alert("添加失败,所选栏目下已有雷同新闻.", "NewsList.aspx");
                }
                else
                {
                    UploadFile2.InfoID = ID;
                    UploadFile2.Update();

                    if (rbcommonnews.Checked == false)
                    {
                        if (this.rbpicurl.Checked == true)
                        {
                            AllowPicType();
                        }
                        else if (this.rbpicupload.Checked == true)
                        {
                            AllowPicType();
                            UploadFile1.InfoID = ID;
                            UploadFile1.Update();
                        }
                    }

                    Response.Redirect("NewsList.aspx");
                }
            }
        }
        else //修改新闻(此时,栏目是单选,即上传图片也为一张)
        {
            newsInfo.TypeIds = XYECOM.Core.Utils.AppendComma(this.hdgetid.Value.Trim());
            //newsInfo.NewsId = Convert.ToInt64(Request.QueryString["id"].ToString());

            if (rbcaptionnews.Checked == true || rbpicnews.Checked == true)
            {
                if (this.rbpicurl.Checked == true)
                {
                    AllowPicType();
                }
                else if (this.rbpicupload.Checked == true)
                {
                    AllowPicType();
                    UploadFile1.InfoID = newsInfo.NewsId;
                    UploadFile1.Update();
                }
            }

            UploadFile2.InfoID = newsInfo.NewsId;
            UploadFile2.Update();


            int total = XYECOM.Core.MyConvert.GetInt32(this.OptionTotal.Value.ToString());

            string option = "";
            string filename = "";

            newsInfo.FileUrl = "";

            for (int i = 1; i <= total; i++)
            {
                option = XYECOM.Core.XYRequest.GetFormString("option" + i).Trim();
                filename = XYECOM.Core.XYRequest.GetFormString("filename" + i).Trim();

                if (string.IsNullOrEmpty(option)) continue;

                if (filename == "") filename = "附件" + i;

                if (newsInfo.FileUrl.Equals(""))
                    newsInfo.FileUrl = filename + "$" + option.ToString();
                else
                    newsInfo.FileUrl = newsInfo.FileUrl + "|" + filename + "$" + option.ToString();
            }


            rowAff = newsBLL.Update(newsInfo);

            if (this.cbcreate.Checked)
            {
                CreateHTML(newsInfo.NewsId.ToString(), "news", "news");
            }

            if (rowAff >= 0)
            {
                Response.Redirect(XYECOM.Core.XYRequest.GetQueryString("backURL"));
            }
            else
            {
                Alert("修改新闻失败,可重新操作.", XYECOM.Core.XYRequest.GetQueryString("backURL"));
            }
        }

        newsInfo = null;
    }
    #endregion

    #region 取消按钮
    protected void btcancel_ServerClick(object sender, EventArgs e)
    {
        if (XYECOM.Core.XYRequest.GetQueryString("backURL").Equals(""))
            Response.Redirect("NewsList.aspx");
        else
            Response.Redirect(XYECOM.Core.XYRequest.GetQueryString("backURL"));
    }
    #endregion

    #region 后台检测上传图片类型
    private void AllowPicType()
    {
        // 得到图片的原始地址
        string picaddress = "";
        if (this.rbpicurl.Checked == true)
        {
            if (this.tbpinurl.Value.ToString() != "")
                picaddress = this.tbpinurl.Value.ToString().Trim();
            //进行图片类型的后台检验
            if (picaddress != "")
            {
                string[] AllowType = this.imagetype.Value.ToString().Trim().Split(';');
                for (int i = 0; i < AllowType.Length; i++)
                {
                    int j = 0;
                    j = picaddress.Substring(picaddress.LastIndexOf('.') + 1).IndexOf(AllowType[i].ToString());
                    if (j >= 0)
                    {
                        continue;
                    }
                }
            }
            else
                Alert("上传或链接图片地址出错,请重新操作.");
        }
    }
    #endregion



    /// <summary>
    /// 附件URL相关
    /// </summary>
    /// <param name="infos"></param>
    private void InitOption(string fileUrls)
    {
        Table t = new Table();

        t.ID = "tableFileOption";
        t.Attributes.Add("class", "FileTable");

        TableRow row = new TableRow();
        TableCell cell = new TableCell();

        //row.Attributes.Add("class", "t");

        string[] files = fileUrls.Split('|');

        if (fileUrls == "" || fileUrls.Equals(""))
        {
            row = new TableRow();
            cell = new TableCell();
            //Option Body

            HtmlInputText txt1 = new HtmlInputText();
            txt1.Size = 20;
            txt1.ID = "filename" + 1;
            txt1.Value = "附件1";
            cell.Controls.Add(txt1);

            HtmlInputText txt2 = new HtmlInputText();
            txt2.Size = 45;
            txt2.ID = "option" + 1;
            txt2.Value = "";
            cell.Controls.Add(txt2);


            //Option Id

            HtmlInputHidden hidden1 = new HtmlInputHidden();
            hidden1.ID = "filename_id_" + 1;
            hidden1.Value = "附件1";
            cell.Controls.Add(hidden1);

            HtmlInputHidden hidden2 = new HtmlInputHidden();
            hidden2.ID = "option_id_" + 1;
            hidden2.Value = "";
            cell.Controls.Add(hidden2);

            row.Cells.Add(cell);

            cell = new TableCell();
            cell.ID = "tdDel_" + 1;

            //if (i == files.Length && i != 1)
            //cell.Attributes.Add("style", "display:;");
            //else
            cell.Attributes.Add("style", "display:none;");

            cell.Text = "<a href=\"#\" onclick=\"DeletePollOption(" + 1 + ");DeleteServerOption();\"><img src=\"../images/delete1.gif\" alt=\"删除\" border=\"0\"/></a>";

            row.Cells.Add(cell);

            t.Rows.Add(row);
        }
        else
        {
            string fileName = "";
            string filePath = "";

            int index = 0;

            for (int i = 0; i < files.Length; i++)
            {
                index = i + 1;

                row = new TableRow();
                cell = new TableCell();
                //Option Body

                if (files[i] != "")
                {
                    string[] strs2 = files[i].Split('$');

                    if (strs2.Length == 1)
                    {
                        fileName = "附件" + index;
                        filePath = strs2[0];
                    }
                    else
                    {
                        fileName = strs2[0];
                        filePath = strs2[1];
                    }

                    HtmlInputText txt1 = new HtmlInputText();
                    txt1.Size = 20;
                    txt1.ID = "filename" + index;
                    txt1.Value = fileName;
                    cell.Controls.Add(txt1);

                    HtmlInputText txt2 = new HtmlInputText();
                    txt2.Size = 45;
                    txt2.ID = "option" + index;
                    txt2.Value = filePath;
                    cell.Controls.Add(txt2);


                    //Option Id

                    HtmlInputHidden hidden1 = new HtmlInputHidden();
                    hidden1.ID = "filename_id_" + index;
                    hidden1.Value = fileName;
                    cell.Controls.Add(hidden1);

                    HtmlInputHidden hidden2 = new HtmlInputHidden();
                    hidden2.ID = "option_id_" + index;
                    hidden2.Value = filePath;
                    cell.Controls.Add(hidden2);

                    row.Cells.Add(cell);

                }
                else
                {
                    HtmlInputText txt1 = new HtmlInputText();
                    txt1.Size = 20;
                    txt1.ID = "filename" + index;
                    txt1.Value = "附件" + index.ToString();
                    cell.Controls.Add(txt1);

                    HtmlInputText txt2 = new HtmlInputText();
                    txt2.Size = 45;
                    txt2.ID = "option" + index;
                    txt2.Value = "";
                    cell.Controls.Add(txt2);


                    //Option Id

                    HtmlInputHidden hidden1 = new HtmlInputHidden();
                    hidden1.ID = "filename_id_" + index;
                    hidden1.Value = "附件" + index.ToString();
                    cell.Controls.Add(hidden1);

                    HtmlInputHidden hidden2 = new HtmlInputHidden();
                    hidden2.ID = "option_id_" + index;
                    hidden2.Value = "";
                    cell.Controls.Add(hidden2);

                    row.Cells.Add(cell);
                }


                cell = new TableCell();
                cell.ID = "tdDel_" + index;

                if (index == files.Length && index != 1)
                    cell.Attributes.Add("style", "display:;");
                else
                    cell.Attributes.Add("style", "display:none;");

                cell.Text = "<a href=\"#\" onclick=\"DeletePollOption(" + index + ");DeleteServerOption('" + files[i].ToString() + "');\"><img src=\"../images/delete1.gif\" alt=\"删除\" border=\"0\"/></a>";

                row.Cells.Add(cell);

                t.Rows.Add(row);
            }
        }

        this.OptionTotal.Value = files.Length.ToString();
        phMain.Controls.Add(t);
    }


}

