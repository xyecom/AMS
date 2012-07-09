using System;
using System.IO;
using XYECOM.Business;

public partial class xymanage_news_AddTitle : XYECOM.Web.BasePage.ManagePage
{
    public string domainname = "";

    #region 定义页面加载事件
     /// <summary>
    /// 定义页面加载事件
     /// </summary>
     /// <param name="sender"></param>
     /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("news");
        BindDomain();
        if (!IsPostBack)
        {
            PostType();
            //this.btnOK.Attributes.Add("onclick", "javascript:return Input();");
        }
    }
    #endregion

    #region 对添加或者修改做出判断并绑定不同
    /// <summary>
     /// 对添加或者修改做出判断并绑定不同
     /// </summary>
    private void PostType()
    {
        this.webname.Text = webInfo.WebDomain.Substring(webInfo.WebDomain.IndexOf('.'), webInfo.WebDomain.Length - webInfo.WebDomain.IndexOf('.'));
        XYECOM.Business.NewsTitles nt = new XYECOM.Business.NewsTitles();
        XYECOM.Model.NewsTitlesInfo parentChannelInfo = null;

        if (Request.QueryString["Type"] != null && Request.QueryString["ntid"] != null)
        {
            if (int.Parse(Request.QueryString["Type"]) == 0)
            {
                if (Request.QueryString["ntid"].ToString() != "")
                {
                    this.ptitleid.Value = Request.QueryString["ntid"].ToString();
                    parentChannelInfo = nt.GetItem(int.Parse(Request.QueryString["ntid"]));

                    if (parentChannelInfo != null)
                    {
                        this.txtParentChannel.Text = parentChannelInfo.Name;
                        this.txtParentChannel.ReadOnly = true;

                        if (!parentChannelInfo.IsAllowContribut)
                        {
                            this.rdoIsAllowContributNo.Checked = true;
                            this.rdoIsAllowContributYes.Enabled = false;
                        }

                        if (!parentChannelInfo.IsShow)
                        {
                            this.chkIsHide.Checked = true;
                            this.chkIsHide.Enabled = false;
                        }
                    }
                }
            }
            else if (int.Parse(Request.QueryString["Type"]) == 1)
            {
                if (Request.QueryString["ntid"].ToString() != "")
                {
                    this.chkSubChannelAutoInherit.Visible = true;
                    this.cbdomain.Visible = true;
                    BindData(int.Parse(Request.QueryString["ntid"]));
                }
            }
            else
            {
                this.txtParentChannel.Text = "根目录";
                this.txtParentChannel.ReadOnly = true;
            }
        }
        else
        {
            this.txtParentChannel.Text = "根目录";
            this.txtParentChannel.ReadOnly = true;
        }
    }
    #endregion

    #region 开启二级域名
    /// <summary>
    /// 是否开启二级域名
    /// </summary>
    private void BindDomain() { 
        if(!webInfo.IsNewsDomain){
            this.txtDomain.Disabled = false;
        }
    }
    #endregion

    #region 修改信息栏目数据绑定
    /// <summary>
    /// 修改信息栏目数据绑定
    /// </summary>
    /// <param name="id">要修改栏目的ID</param>
    protected void BindData(int id)
    {
        XYECOM.Business.NewsTitles BLL = new NewsTitles();
        XYECOM.Model.NewsTitlesInfo info = BLL.GetItem(id);
        XYECOM.Model.NewsTitlesInfo parentChannelInfo = null;

        if (info != null)
        {
            this.txtChannelCNName.Text = info.Name;
            this.txtChannelShortTitle.Text = info.ShortName;
            this.ptitleid.Value = info.ParentId.ToString();
            if (info.ParentId == 0)
            {
                this.txtParentChannel.Text = "根目录";
            }
            else
            {
                parentChannelInfo = BLL.GetItem(info.ParentId);

                this.txtParentChannel.Text = parentChannelInfo.Name;
            }
            this.txtParentChannel.ReadOnly = true;
            this.txtChannelENName.Text =info.EnName;
            this.txtTemplate.Text = info.TempletFolderAddress;
            this.txtDomain.Value = info.DomainName;
            domainname = info.DomainName;
            if (!info.IsShow)
                this.chkIsHide.Checked = true;

            if (info.IsAllowContribut)
                this.rdoIsAllowContributYes.Checked = true;
            else
                this.rdoIsAllowContributNo.Checked = true;

            if (parentChannelInfo != null)
            {
                if (!parentChannelInfo.IsAllowContribut)
                {
                    this.rdoIsAllowContributNo.Checked = true;
                    this.rdoIsAllowContributYes.Enabled = false;
                }

                if (!parentChannelInfo.IsShow)
                {
                    this.chkIsHide.Checked = true;
                    this.chkIsHide.Enabled = false;
                }
            }
        }

    }
    #endregion

    #region 添加栏目信息
    /// <summary>
    /// 添加栏目信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btadd_Click(object sender, EventArgs e)
    {
        string message = "";

        int ntid = 0;
        int rowAff = 0;
        
        XYECOM.Business.NewsTitles ne = new XYECOM.Business.NewsTitles();
        XYECOM.Model.NewsTitlesInfo info=new XYECOM.Model.NewsTitlesInfo();
        
        info.Name = this.txtChannelCNName.Text.Trim();
        info.ShortName = this.txtChannelShortTitle.Text.Trim();
        info.EnName = this.txtChannelENName.Text.Trim();
        info.TempletFolderAddress = this.txtTemplate.Text.Trim();
        info.TempletViewAddress = "";
        info.IsShow = true;
        info.IsAllowContribut = true;

        info.DomainName = this.txtDomain.Value.Trim().ToLower();

        if (chkIsHide.Checked) info.IsShow = false;
        if (rdoIsAllowContributNo.Checked) info.IsAllowContribut = false;

        if (this.txtTemplate.Text.Trim() == "")
        {
            info.TempletFolderAddress = "";
        }
        else 
        {
            String strAddress = Server.MapPath("/templates/" + XYECOM.Configuration.Template.Instance.Path + "/news/" + this.txtTemplate.Text);
            DirectoryInfo df = new DirectoryInfo(strAddress);
            if (!df.Exists)
            {
                Alert("该文件夹不存在,请检查!正确路径为/templates/" + XYECOM.Configuration.Template.Instance.Path + "/news/" + this.txtTemplate.Text + "/");
                return;
            }
            else 
            {
                String index = "";
                String content = "";
                String channel = "";
                FileInfo[] file = df.GetFiles();
                String[] needfile = { "index.htm", "content.htm", "channel.htm" };

                for (int i = 0; i < file.Length;i++ )
                {
                    if (file.Length < needfile.Length)
                    {
                        Alert("该文件夹下缺少必须的index.htm,channel.htm,content.htm,请检查!");
                        return;
                    }
                    else 
                    {
                        if(file[i].Name == needfile[0].ToString())
                        {
                            index = "index.htm";
                        }
                        else if(file[i].Name == needfile[1].ToString())
                        {
                            content = "content.htm";
                        }
                        else if(file[i].Name == needfile[2].ToString())
                        {
                            channel = "channel.htm";
                        }
                    }
                }
                if (index == "" || content == "" || channel == "")
                {
                    Alert("缺少必须的index.htm,channel.htm,content.htm,请检查!");
                    return;
                }
            }
        }


        if (Request.QueryString["Type"] != null && Request.QueryString["ntid"] != null)
        {
            if (int.Parse(Request.QueryString["Type"]) == 0)
            {
                info.ParentId = Convert.ToInt32(Request.QueryString["ntid"].ToString());
                rowAff = ne.Insert(info, out ntid);
                        
                if (rowAff >= 0)
                {
                    if(info.DomainName !="")
                    {
                        webInfo.AddForbidName(info.DomainName);
                        webInfo.Update();
                    }
                    message = "添加新闻子栏目成功!";

                    string cMsg = CreateChannelIndexPage(info.TempletFolderAddress);

                    if (!cMsg.Equals("")) message += "<br/>" + cMsg;

                    Alert(message, "TitleList.aspx?NT_PID=" + int.Parse(Request.QueryString["ntid"].ToString()));
                }
                else if (rowAff == -2)
                {
                    Alert("添加新闻子栏目出错,可以选择重新添加!", "TitleList.aspx?NT_PID=" + int.Parse(Request.QueryString["ntid"].ToString()));
                }
                else if (rowAff == -1)
                {
                    Alert("该新闻栏目名称已经存在,请重新输入!");
                }
            }
            else if (int.Parse(Request.QueryString["Type"]) == 1)
            {
                info.Id = int.Parse(Request.QueryString["ntid"]);
                info.ParentId = int.Parse(this.ptitleid.Value);

                if (this.cbdomain.Checked)
                {
                    if (info.TempletFolderAddress.Equals("") && !info.DomainName.Equals(""))
                    {
                        Alert("启用二级域名则必须自定义栏目模板（填写自定义栏目文件夹地址）!");
                        return;
                    }
                }

                rowAff = ne.Update(info,this.chkSubChannelAutoInherit.Checked,this.cbdomain.Checked);

                //if (rowAff.Equals(2))
                //{
                //    Alert("请填写自定义栏目文件夹地址和选择自定义文件夹子栏目继承选项!");
                //}

                if (rowAff >= 0)
                {
                    if (info.DomainName != "")
                    {
                        webInfo.AddForbidName(info.DomainName);
                        webInfo.Update();
                    }

                    message = "修改新闻栏目成功!";
                    string cMsg = CreateChannelIndexPage(info.TempletFolderAddress);

                    if (!cMsg.Equals("")) message += "<br/>" + cMsg;

                    Alert(message, "TitleList.aspx");
                }
                else
                {
                    Alert("修改新闻栏目失败!", "TitleList.aspx?NT_PID="+int.Parse(this.ptitleid.Value.Trim()));
                }
            }
        }
        else
        {
            info.ParentId = 0;
            rowAff = ne.Insert(info, out ntid);
            if (rowAff >= 0)
            {
                if (info.DomainName != "")
                {
                    webInfo.AddForbidName(info.DomainName);
                    webInfo.Update();
                }

                message = "添加新闻根栏目成功!";

                string cMsg = CreateChannelIndexPage(info.TempletFolderAddress);

                if (!cMsg.Equals("")) message += "<br/>" + cMsg;

                Alert(message, "TitleList.aspx");
            }
            else if (rowAff == -2)
            {
                Alert("添加新闻根栏目出错,可以选择重新添加!", "TitleList.aspx");
            }
            else if (rowAff == -1)
            {
                Alert("该新闻根栏目名称已经存在,请重新输入!", "TitleList.aspx");
            }
        }
    }
    #endregion

    /// <summary>
    /// 创建自定义文件夹栏目默认首页
    /// </summary>
    /// <param name="folder">自定义文件夹名称</param>
    /// <returns></returns>
    private string CreateChannelIndexPage(string folder)
    {
        if (!folder.Trim().Equals(""))
        {
            bool createIndexPage = CreateIndexPage("/news/" + folder + "/");

            if (!createIndexPage)
            {
                return "创建栏目默认首页失败,请手动创建!<br/>地址：news/" + folder + "/<br/>方法：拷贝/news/index." + webInfo.WebSuffix + "文件到上述地址";
            }
        }
        return "";
    }

    #region 单击返回
    protected void btcancel_ServerClick(object sender, EventArgs e)
    {
        if (Request.QueryString["Type"] != null && Request.QueryString["ntid"] != null)
        {
            if (int.Parse(Request.QueryString["Type"]) == 0)
                this.ClientScript.RegisterClientScriptBlock(GetType(), "", "<script>window.location.href(\"TitleList.aspx\")</script>");
            else
                this.ClientScript.RegisterClientScriptBlock(GetType(), "", "<script>window.location.href(\"TitleList.aspx?NT_PID=" + int.Parse(this.ptitleid.Value.Trim())+"\")</script>");
        }
        else
        {
            this.ClientScript.RegisterClientScriptBlock(GetType(), "", "<script>window.location.href(\"TitleList.aspx\")</script>");
        }
    }
    #endregion
}
