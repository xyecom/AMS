using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using XYECOM.Web.BasePage;

public partial class xymanage_LabelManage_Add : LabelBasePage
{
    XYECOM.Business.Label le = new XYECOM.Business.Label();

    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("label");
    }

    protected override void BindData()
    {
        lstDataBind();
        DataBindLableType();
        this.rbtnSystem.Checked = true;
        this.ImageButton1.Visible = false;

        int lid = XYECOM.Core.XYRequest.GetQueryInt("L_ID", 0);

        XYECOM.Model.LabelInfo el = null;

        if (lid > 0 && (el = le.GetItem(lid)) != null)
        {
            this.ImageButton1.Visible = true;

            lableid.Value = lid.ToString();
            this.tbContent.Text = el.LabelContent;
            this.txtHead.Text = el.LabelStyleHead;
            this.txtConent.Text = el.LabelStyleContent;
            this.txtfooter.Text = el.LabelStyleFooter;
            this.hidTableName.Value = el.LabelTableName;
            this.txtDescription.Text = el.LabelDescription;
            switch (el.LabelRange)
            {
                case XYECOM.Model.LabelRange.System:
                    this.hidUserIds.Value = "";
                    this.hidGroupIds.Value = "";
                    this.rbtnUser.Checked = false;
                    this.rbtnUserGroup.Checked = false;
                    this.rbtnSystem.Checked = true;
                    break;
                case XYECOM.Model.LabelRange.User:
                    this.hidUserIds.Value = el.GroupIdOrUserId;
                    this.hidGroupIds.Value = "";
                    this.divuser.Style["display"] = "bolck";
                    this.divgroup.Style["display"] = "none";

                    XYECOM.Business.UserInfo userBll = new XYECOM.Business.UserInfo();
                    DataTable table = userBll.GetUserNamesByIds(el.GroupIdOrUserId);
                    string names = string.Empty;
                    foreach (DataRow row in table.Rows)
                    {
                        names += string.Format("{0}/{1}/{2},", row["u_name"], row["u_email"], row["ui_name"]);
                    }
                    this.spanUserNames.InnerHtml = XYECOM.Core.Utils.RemoveEndComma(names);
                    this.spanGroupNames.InnerHtml = "";
                    this.rbtnUser.Checked = true;
                    this.rbtnUserGroup.Checked = false;
                    this.rbtnSystem.Checked = false;
                    break;
                case XYECOM.Model.LabelRange.UserGropu:
                    this.hidUserIds.Value = "";
                    this.hidGroupIds.Value = el.GroupIdOrUserId;
                    this.divgroup.Style["display"] = "bolck";
                    this.divuser.Style["display"] = "none";
                    this.spanUserNames.InnerHtml = "";                    
                    
                    this.rbtnUserGroup.Checked = true;
                    this.rbtnUser.Checked = true;
                    this.rbtnSystem.Checked = true;
                    break;
            }

            this.hidLT_ID.SelectedValue = el.LabelTypeId.ToString();

            int copy = XYECOM.Core.XYRequest.GetQueryInt("type", 0);

            if (copy == 0)
            {
                this.tbCName.Text = el.LabelCName;
                this.tbName.Text = el.LabelName;
                L_ID = el.Id;
            }
        }
    }

    private void DataBindLableType()
    {
        this.hidLT_ID.DataSource = new XYECOM.Business.LabelType().GetDataTable("where LT_ParentID=0");
        this.hidLT_ID.DataTextField = "LT_Name";
        this.hidLT_ID.DataValueField = "LT_ID";
        this.hidLT_ID.DataBind();
    }

    private void lstDataBind()
    {
        #region 供应
        lst_Offer.Items.Add(new ListItem("信息编号", "{SP:XY_ID}"));
        lst_Offer.Items.Add(new ListItem("信息完整标题", "{SP:XY_TitleAll}"));
        lst_Offer.Items.Add(new ListItem("信息截取标题", "{SP:XY_Title}"));
        lst_Offer.Items.Add(new ListItem("信息类别", "{SP:XY_PName}"));
        lst_Offer.Items.Add(new ListItem("信息类别链接地址", "{SP:XY_PURL}"));
        lst_Offer.Items.Add(new ListItem("信息类型", "{SP:XY_Flag}"));
        lst_Offer.Items.Add(new ListItem("市场价", "{SP:MarketPrice}"));
        lst_Offer.Items.Add(new ListItem("产品价格", "{SP:XY_Price}"));
        lst_Offer.Items.Add(new ListItem("计量单位", "{SP:XY_Unit}"));
        lst_Offer.Items.Add(new ListItem("最小起订量", "{SP:XY_SmallNum}"));
        lst_Offer.Items.Add(new ListItem("供货数量", "{SP:XY_Num}"));
        lst_Offer.Items.Add(new ListItem("产品描述", "{SP:XY_Description}"));
        lst_Offer.Items.Add(new ListItem("发布时间", "{SP:XY_Date}"));
        lst_Offer.Items.Add(new ListItem("信息有效期", "{SP:XY_EndDate}"));
        lst_Offer.Items.Add(new ListItem("链接地址", "{SP:XY_URL}"));
        lst_Offer.Items.Add(new ListItem("浏览次数", "{SP:XY_Click}"));
        lst_Offer.Items.Add(new ListItem("缩略图1", "{SP:XY_SmallImg1}"));
        lst_Offer.Items.Add(new ListItem("缩略图2", "{SP:XY_SmallImg2}"));
        lst_Offer.Items.Add(new ListItem("缩略图3", "{SP:XY_SmallImg3}"));
        lst_Offer.Items.Add(new ListItem("大图地址", "{SP:XY_IMG}"));
        lst_Offer.Items.Add(new ListItem("是否是合同保障", "{SP:IsContractVouch}"));
        lst_Offer.Items.Add(new ListItem("是否缴纳保证金", "{SP:IsPayBail}"));
        lst_Offer.Items.Add(new ListItem("发货库房", "{SP:DepotName}"));

        lst_Offer.Items.Add(new ListItem("库房地址", "{SP:DepotAddress}"));
        //lst_Offer.Items.Add(new ListItem("库管员", "{SP:DepotManager}"));
        //lst_Offer.Items.Add(new ListItem("库房传真", "{SP:DepotFax}"));

        //lst_Offer.Items.Add(new ListItem("库房电话", "{SP:DepotPhone}"));
        //lst_Offer.Items.Add(new ListItem("库房Email", "{SP:DepotEmail}"));


        #endregion

        #region 求购
        lst_SupplyBuy.Items.Add(new ListItem("信息编号", "{SB:SD_ID}"));
        //lst_SupplyBuy.Items.Add(new ListItem("用户编号", "{SB:UID}"));
        lst_SupplyBuy.Items.Add(new ListItem("信息标题", "{SB:Title}"));
        lst_SupplyBuy.Items.Add(new ListItem("产品关键字", "{SB:KeyWord}"));
        lst_SupplyBuy.Items.Add(new ListItem("产品要求", "{SB:Contetns}"));
        lst_SupplyBuy.Items.Add(new ListItem("联系人", "{SB:Name}"));
        lst_SupplyBuy.Items.Add(new ListItem("联系电话", "{SB:Tel}"));
        lst_SupplyBuy.Items.Add(new ListItem("发布时间", "{SB:PublishDate}"));
        lst_SupplyBuy.Items.Add(new ListItem("连接地址", "{SB:Url}"));
        lst_SupplyBuy.Items.Add(new ListItem("所属地区编号", "{SB:buyId}"));
        lst_SupplyBuy.Items.Add(new ListItem("求购所属地区", "{SB:buyareaname}"));
        #endregion

        #region 加工
        lst_Machining.Items.Add(new ListItem("信息编号", "{DM:XY_ID}"));
        lst_Machining.Items.Add(new ListItem("信息完整标题", "{DM:XY_TitleAll}"));
        lst_Machining.Items.Add(new ListItem("信息截取标题", "{DM:XY_Title}"));
        lst_Machining.Items.Add(new ListItem("投融资类型名称", "{DM:XY_TypeName}"));
        lst_Machining.Items.Add(new ListItem("投融资信息摘要", "{DM:XY_Summary}"));
        lst_Machining.Items.Add(new ListItem("投融资地区", "{DM:XY_Area}"));
        lst_Machining.Items.Add(new ListItem("融资项目网址", "{DM:XY_WebSite}"));
        //lst_Machining.Items.Add(new ListItem("信息类别链接地址", "{DM:XY_PURL}"));
        lst_Machining.Items.Add(new ListItem("是否是融资信息", "{DM:XY_Flag}"));
        lst_Machining.Items.Add(new ListItem("投融资金额", "{DM:XY_Price}"));
        lst_Machining.Items.Add(new ListItem("投融资所属区域", "{DM:XY_Trade}"));
        lst_Machining.Items.Add(new ListItem("投融资信息详细描述", "{DM:XY_Description}"));
        lst_Machining.Items.Add(new ListItem("发布日期", "{DM:XY_Date}"));
        lst_Machining.Items.Add(new ListItem("信息有效期", "{DM:XY_EndDate}"));
        lst_Machining.Items.Add(new ListItem("链接地址", "{DM:XY_URL}"));
        //lst_Machining.Items.Add(new ListItem("浏览次数", "{DM:XY_Click}"));
        //lst_Machining.Items.Add(new ListItem("缩略图1", "{DM:XY_SmallImg1}"));
        //lst_Machining.Items.Add(new ListItem("缩略图2", "{DM:XY_SmallImg2}"));
        //lst_Machining.Items.Add(new ListItem("缩略图3", "{DM:XY_SmallImg3}"));
        //lst_Machining.Items.Add(new ListItem("大图地址", "{DM:XY_IMG}"));
        #endregion

        #region 招商代理
        lst_Investment.Items.Add(new ListItem("信息编号", "{BS:XY_ID}"));
        lst_Investment.Items.Add(new ListItem("信息完整标题", "{BS:XY_TitleAll}"));
        lst_Investment.Items.Add(new ListItem("信息截取标题", "{BS:XY_Title}"));
        lst_Investment.Items.Add(new ListItem("信息类别", "{BS:XY_PName}"));
        lst_Investment.Items.Add(new ListItem("信息类别链接地址", "{BS:XY_PURL}"));
        lst_Investment.Items.Add(new ListItem("信息类型", "{BS:XY_Flag}"));
        lst_Investment.Items.Add(new ListItem("招商内容", "{BS:XY_Content}"));
        lst_Investment.Items.Add(new ListItem("招商区域", "{BS:XY_Area}"));
        lst_Investment.Items.Add(new ListItem("代理过的品牌", "{BS:XY_BName}"));
        lst_Investment.Items.Add(new ListItem("详细描述", "{BS:XY_Content}"));
        lst_Investment.Items.Add(new ListItem("可提供支持", "{BS:XY_Support}"));
        lst_Investment.Items.Add(new ListItem("对代理的要求", "{BS:XY_Demand}"));
        lst_Investment.Items.Add(new ListItem("发布时间", "{BS:XY_Date}"));
        lst_Investment.Items.Add(new ListItem("信息有效期", "{BS:XY_EndDate}"));
        lst_Investment.Items.Add(new ListItem("招商展示地址", "{BS:XY_ShowURL}"));
        lst_Investment.Items.Add(new ListItem("链接地址", "{BS:XY_URL}"));
        lst_Investment.Items.Add(new ListItem("浏览次数", "{BS:XY_Click}"));
        lst_Investment.Items.Add(new ListItem("缩略图1", "{BS:XY_SmallImg1}"));
        lst_Investment.Items.Add(new ListItem("缩略图2", "{BS:XY_SmallImg2}"));
        lst_Investment.Items.Add(new ListItem("缩略图3", "{BS:XY_SmallImg3}"));
        lst_Investment.Items.Add(new ListItem("大图地址", "{BS:XY_IMG}"));
        #endregion

        #region 服务
        lst_Service.Items.Add(new ListItem("信息编号", "{SG:XY_ID}"));
        lst_Service.Items.Add(new ListItem("信息完整标题", "{SG:XY_TitleAll}"));
        lst_Service.Items.Add(new ListItem("信息截取标题", "{SG:XY_Title}"));
        lst_Service.Items.Add(new ListItem("信息类别", "{SG:XY_PName}"));
        lst_Service.Items.Add(new ListItem("信息类别链接地址", "{SG:XY_PURL}"));
        lst_Service.Items.Add(new ListItem("信息类型", "{SG:XY_Flag}"));
        lst_Service.Items.Add(new ListItem("服务内容", "{SG:XY_Content}"));
        lst_Service.Items.Add(new ListItem("发布时间", "{SG:XY_Date}"));
        lst_Service.Items.Add(new ListItem("信息有效期", "{SG:XY_EndDate}"));
        lst_Service.Items.Add(new ListItem("浏览次数", "{SG:XY_Click}"));
        lst_Service.Items.Add(new ListItem("链接地址", "{SG:XY_URL}"));
        lst_Service.Items.Add(new ListItem("缩略图1", "{SG:XY_SmallImg1}"));
        lst_Service.Items.Add(new ListItem("缩略图2", "{SG:XY_SmallImg2}"));
        lst_Service.Items.Add(new ListItem("缩略图3", "{SG:XY_SmallImg3}"));
        lst_Service.Items.Add(new ListItem("大图地址", "{SG:XY_IMG}"));

        #endregion

        #region 展会
        lst_Exhibition.Items.Add(new ListItem("信息编号", "{SH:XY_ID}"));
        lst_Exhibition.Items.Add(new ListItem("信息完整标题", "{SH:XY_TitleAll}"));
        lst_Exhibition.Items.Add(new ListItem("信息截取标题", "{SH:XY_Title}"));
        lst_Exhibition.Items.Add(new ListItem("结束标识", "{SH:XY_EndFlag}"));
        lst_Exhibition.Items.Add(new ListItem("分类名称", "{SH:XY_PName}"));
        lst_Exhibition.Items.Add(new ListItem("分类链接", "{SH:XY_PURL}"));
        lst_Exhibition.Items.Add(new ListItem("详细说明", "{SH:XY_Content}"));
        lst_Exhibition.Items.Add(new ListItem("展会开始时间", "{SH:XY_BeginTime}"));
        lst_Exhibition.Items.Add(new ListItem("展会结束时间", "{SH:XY_EndTime}"));
        lst_Exhibition.Items.Add(new ListItem("展会地点", "{SH:XY_Place}"));
        lst_Exhibition.Items.Add(new ListItem("展会场馆", "{SH:XY_Stadiums}"));
        lst_Exhibition.Items.Add(new ListItem("主办单位", "{SH:XY_Sponsor}"));
        lst_Exhibition.Items.Add(new ListItem("承办单位", "{SH:XY_Undertake}"));
        lst_Exhibition.Items.Add(new ListItem("协办单位", "{SH:XY_Coorganizor}"));
        lst_Exhibition.Items.Add(new ListItem("支持单位", "{SH:XY_Sustain}"));
        lst_Exhibition.Items.Add(new ListItem("展会周期", "{SH:XY_ShowSycle}"));
        lst_Exhibition.Items.Add(new ListItem("展会性质", "{SH:XY_ShowCharacter}"));
        lst_Exhibition.Items.Add(new ListItem("展会网址", "{SH:XY_ShowURL}"));
        lst_Exhibition.Items.Add(new ListItem("展会面积单位", "{SH:XY_Landmeasure}"));
        lst_Exhibition.Items.Add(new ListItem("展会面积单位单价", "{SH:XY_UnitPrice}"));
        lst_Exhibition.Items.Add(new ListItem("展会面积起定量", "{SH:XY_MinRation}"));
        lst_Exhibition.Items.Add(new ListItem("展会面积总量", "{SH:XY_TotalArea}"));
        lst_Exhibition.Items.Add(new ListItem("发布时间", "{SH:XY_Date}"));
        lst_Exhibition.Items.Add(new ListItem("链接地址", "{SH:XY_URL}"));
        lst_Exhibition.Items.Add(new ListItem("缩略图1", "{SH:XY_SmallImg1}"));
        lst_Exhibition.Items.Add(new ListItem("缩略图2", "{SH:XY_SmallImg2}"));
        lst_Exhibition.Items.Add(new ListItem("缩略图3", "{SH:XY_SmallImg3}"));
        lst_Exhibition.Items.Add(new ListItem("大图地址", "{SH:XY_IMG}"));
        #endregion

        #region 品牌
        lst_Brand.Items.Add(new ListItem("品牌编号", "{BD:XY_ID}"));
        lst_Brand.Items.Add(new ListItem("品牌完整名称", "{BD:XY_NameAll}"));
        lst_Brand.Items.Add(new ListItem("品牌截取名称", "{BD:XY_Name}"));
        lst_Brand.Items.Add(new ListItem("品牌类别", "{BD:XY_PName}"));
        lst_Brand.Items.Add(new ListItem("品牌介绍", "{BD:XY_Remark}"));
        lst_Brand.Items.Add(new ListItem("发布时间", "{BD:XY_Date}"));
        lst_Brand.Items.Add(new ListItem("浏览次数", "{BD:XY_ClickNum}"));
        lst_Brand.Items.Add(new ListItem("链接地址", "{BD:XY_URL}"));
        lst_Brand.Items.Add(new ListItem("缩略图1", "{BD:XY_SmallImg1}"));
        lst_Brand.Items.Add(new ListItem("缩略图2", "{BD:XY_SmallImg2}"));
        lst_Brand.Items.Add(new ListItem("缩略图3", "{BD:XY_SmallImg3}"));
        lst_Brand.Items.Add(new ListItem("缩略图地址", "{BD:XY_IMG}"));
        #endregion

        #region 人才招聘
        lst_Job.Items.Add(new ListItem("信息编号", "{EG:XY_ID}"));
        lst_Job.Items.Add(new ListItem("招聘岗位", "{EG:XY_Post}"));
        lst_Job.Items.Add(new ListItem("招聘完整职位", "{EG:XY_TitleAll}"));
        lst_Job.Items.Add(new ListItem("招聘截取职位", "{EG:XY_Title}"));
        lst_Job.Items.Add(new ListItem("招聘部门", "{EG:XY_Branch}"));
        lst_Job.Items.Add(new ListItem("招聘类型", "{EG:XY_Type}"));
        lst_Job.Items.Add(new ListItem("工作地区", "{EG:XY_Area}"));
        lst_Job.Items.Add(new ListItem("具体要求", "{EG:XY_Request}"));
        lst_Job.Items.Add(new ListItem("福利薪水", "{EG:XY_Pay}"));
        lst_Job.Items.Add(new ListItem("学历", "{EG:XY_SA}"));
        lst_Job.Items.Add(new ListItem("年龄", "{EG:XY_Age}"));
        lst_Job.Items.Add(new ListItem("性别", "{EG:XY_Sex}"));
        lst_Job.Items.Add(new ListItem("工作经验", "{EG:XY_Experience}"));
        lst_Job.Items.Add(new ListItem("户籍要求", "{EG:XY_Nationality}"));
        lst_Job.Items.Add(new ListItem("招聘人数", "{EG:XY_Number}"));
        lst_Job.Items.Add(new ListItem("发布时间", "{EG:XY_Date}"));
        lst_Job.Items.Add(new ListItem("信息有效期", "{EG:XY_EndDate}"));
        lst_Job.Items.Add(new ListItem("浏览次数", "{EG:XY_Click}"));
        lst_Job.Items.Add(new ListItem("链接地址", "{EG:XY_URL}"));
        #endregion

        #region 企业
        lst_Company.Items.Add(new ListItem("公司编号", "{CP:XY_ID}"));
        lst_Company.Items.Add(new ListItem("公司完整名称", "{CP:XY_NameAll}"));
        lst_Company.Items.Add(new ListItem("公司截取名称", "{CP:XY_Name}"));
        lst_Company.Items.Add(new ListItem("公司地址", "{CP:XY_Area}"));
        lst_Company.Items.Add(new ListItem("公司详细地址", "{CP:XY_Address}"));
        lst_Company.Items.Add(new ListItem("营业执照号", "{CP:XY_License}"));
        lst_Company.Items.Add(new ListItem("公司性质", "{CP:XY_Character}"));
        lst_Company.Items.Add(new ListItem("联系人", "{CP:XY_LinkMan}"));
        lst_Company.Items.Add(new ListItem("联系电话", "{CP:XY_Telephone}"));
        lst_Company.Items.Add(new ListItem("联系手机", "{CP:XY_Mobil}"));
        lst_Company.Items.Add(new ListItem("联系人IM", "{CP:XY_IM}"));
        lst_Company.Items.Add(new ListItem("所在部门", "{CP:XY_Section}"));
        lst_Company.Items.Add(new ListItem("就任职位", "{CP:XY_Post}"));

        lst_Company.Items.Add(new ListItem("企业人数", "{CP:XY_Number}"));
        lst_Company.Items.Add(new ListItem("企业网址", "{CP:XY_HomePage}"));
        lst_Company.Items.Add(new ListItem("企业传真", "{CP:XY_Fax}"));
        lst_Company.Items.Add(new ListItem("企业简介", "{CP:XY_jianjie}"));
        lst_Company.Items.Add(new ListItem("邮政编号", "{CP:XY_Postcode}"));

        lst_Company.Items.Add(new ListItem("行业类型", "{CP:XY_Type}"));
        lst_Company.Items.Add(new ListItem("用户等级", "{CP:XY_Gread}"));
        lst_Company.Items.Add(new ListItem("用户等级图标", "{CP:XY_GIMG}"));

        lst_Company.Items.Add(new ListItem("主营方向", "{CP:XY_Way}"));
        //lst_Company.Items.Add(new ListItem("供应的产品和服务", "{CP:XY_SupplyProduct}"));
        lst_Company.Items.Add(new ListItem("主营产品和服务", "{CP:XY_PType}"));
        lst_Company.Items.Add(new ListItem("需求的产品和服务", "{CP:XY_BuyProduct}"));
        lst_Company.Items.Add(new ListItem("经营模式", "{CP:XY_Mode}"));
        lst_Company.Items.Add(new ListItem("注册资金", "{CP:XY_Money}"));
        lst_Company.Items.Add(new ListItem("公司成立年份", "{CP:XY_Year}"));
        lst_Company.Items.Add(new ListItem("主要营业地点", "{CP:XY_LAddress}"));

        lst_Company.Items.Add(new ListItem("注册时间", "{CP:XY_Date}"));
        lst_Company.Items.Add(new ListItem("链接地址", "{CP:XY_URL}"));
        lst_Company.Items.Add(new ListItem("浏览次数", "{CP:XY_Click}"));
        lst_Company.Items.Add(new ListItem("Logo缩略图1", "{CP:XY_SmallImg1}"));
        lst_Company.Items.Add(new ListItem("Logo缩略图2", "{CP:XY_SmallImg2}"));
        lst_Company.Items.Add(new ListItem("Logo缩略图3", "{CP:XY_SmallImg3}"));
        lst_Company.Items.Add(new ListItem("Logo大图地址", "{CP:XY_IMG}"));
        //lst_Company.Items.Add(new ListItem("诚信指数", "{CP:XY_Cred}"));
        lst_Company.Items.Add(new ListItem("企业用户信用值", "{CP:XY_CreditIntegral}"));
        lst_Company.Items.Add(new ListItem("企业用户信用等级图片", "{CP:XY_CreditIntegralImage}"));
        lst_Company.Items.Add(new ListItem("企业用户信用等级", "{CP:XY_CreditIntegralLeavl}"));
        
        #endregion

        #region 资讯

        #region 资讯基本/搜索列表
        lst_NewsList.Items.Add(new ListItem("资讯编号", "{NS:XY_ID}"));
        lst_NewsList.Items.Add(new ListItem("资讯完整标题", "{NS:XY_TitleAll}"));
        lst_NewsList.Items.Add(new ListItem("资讯截取标题", "{NS:XY_Title}"));
        lst_NewsList.Items.Add(new ListItem("资讯栏目", "{NS:XY_TName}"));
        lst_NewsList.Items.Add(new ListItem("资讯栏目简称", "{NS:XY_STName}"));
        lst_NewsList.Items.Add(new ListItem("资讯栏目链接地址", "{NS:XY_TURL}"));
        lst_NewsList.Items.Add(new ListItem("资讯副标题", "{NS:XY_CurtTitle}"));
        lst_NewsList.Items.Add(new ListItem("资讯完整导读", "{NS:XY_NaviContentAll}"));
        lst_NewsList.Items.Add(new ListItem("资讯截取导读", "{NS:XY_NaviContent}"));
        lst_NewsList.Items.Add(new ListItem("资讯内容", "{NS:XY_Content}"));
        lst_NewsList.Items.Add(new ListItem("资讯作者", "{NS:XY_Author}"));
        lst_NewsList.Items.Add(new ListItem("资讯来源", "{NS:XY_Source}"));
        lst_NewsList.Items.Add(new ListItem("关键字", "{NS:XY_KeyWord}"));
        lst_NewsList.Items.Add(new ListItem("资讯图片地址", "{NS:XY_PicPath}"));
        lst_NewsList.Items.Add(new ListItem("资讯发布时间", "{NS:XY_Date}"));
        lst_NewsList.Items.Add(new ListItem("标题资讯链接地址", "{NS:XY_Link}"));
        lst_NewsList.Items.Add(new ListItem("链接地址", "{NS:XY_URL}"));
        lst_NewsList.Items.Add(new ListItem("浏览次数", "{NS:XY_Click}"));
        lst_NewsList.Items.Add(new ListItem("行业标识", "{NS:XY_TradeFlag}"));
        lst_NewsList.Items.Add(new ListItem("地区标识", "{NS:XY_AreaFlag}"));
        lst_NewsList.Items.Add(new ListItem("新闻附件", "{NS:XY_Attachment}"));
        #endregion

        #region 不规则资讯
        lst_anomulyNewsList.Items.Add(new ListItem("不规则资讯内容", "{NS:XY_ATitle}"));
        #endregion

        #region 企业新闻
        lst_UserNews.Items.Add(new ListItem("新闻标题", "{un:xy_title}"));
        lst_UserNews.Items.Add(new ListItem("新闻内容", "{un:xy_content}"));
        lst_UserNews.Items.Add(new ListItem("新闻发布时间", "{un:xy_addtime}"));
        lst_UserNews.Items.Add(new ListItem("新闻链接地址", "{un:xy_url}"));
        #endregion

        #region 用户资讯基本/搜索列表
        lst_UserNewsList.Items.Add(new ListItem("资讯编号", "{UNS:XY_ID}"));
        lst_UserNewsList.Items.Add(new ListItem("资讯标题", "{UNS:XY_TitleAll}"));
        //lst_UserNewsList.Items.Add(new ListItem("资讯截取标题", "{UNS:XY_Title}"));
        lst_UserNewsList.Items.Add(new ListItem("资讯栏目", "{UNS:XY_TName}"));
        //lst_UserNewsList.Items.Add(new ListItem("资讯栏目简称", "{NS:XY_STName}"));
        //lst_UserNewsList.Items.Add(new ListItem("资讯栏目链接地址", "{UNS:XY_TURL}"));
        lst_UserNewsList.Items.Add(new ListItem("资讯副标题", "{UNS:XY_CurtTitle}"));
        lst_UserNewsList.Items.Add(new ListItem("资讯导读", "{UNS:XY_NaviContentAll}"));
        //lst_UserNewsList.Items.Add(new ListItem("资讯截取导读", "{NS:XY_NaviContent}"));
        lst_UserNewsList.Items.Add(new ListItem("资讯内容", "{UNS:XY_Content}"));
        lst_UserNewsList.Items.Add(new ListItem("资讯作者", "{UNS:XY_Author}"));
        lst_UserNewsList.Items.Add(new ListItem("资讯来源", "{UNS:XY_Source}"));
        lst_UserNewsList.Items.Add(new ListItem("关键字", "{UNS:XY_KeyWord}"));
        //lst_UserNewsList.Items.Add(new ListItem("资讯图片地址", "{NS:XY_PicPath}"));
        lst_UserNewsList.Items.Add(new ListItem("资讯发布时间", "{UNS:XY_Date}"));
        //lst_UserNewsList.Items.Add(new ListItem("标题资讯链接地址", "{UNS:XY_Link}"));
        lst_UserNewsList.Items.Add(new ListItem("链接地址", "{UNS:XY_URL}"));
        lst_UserNewsList.Items.Add(new ListItem("浏览次数", "{UNS:XY_Click}"));
        //lst_UserNewsList.Items.Add(new ListItem("行业标识", "{NS:XY_TradeFlag}"));
        //lst_UserNewsList.Items.Add(new ListItem("地区标识", "{NS:XY_AreaFlag}"));
        //lst_UserNewsList.Items.Add(new ListItem("新闻附件", "{NS:XY_Attachment}"));

        #endregion

        #endregion

        #region 个人
        lst_AssociatorList.Items.Add(new ListItem("个人编号", "{AC:XY_ID}"));
        lst_AssociatorList.Items.Add(new ListItem("真实姓名", "{AC:XY_Name}"));
        lst_AssociatorList.Items.Add(new ListItem("性别", "{AC:XY_Sex}"));
        lst_AssociatorList.Items.Add(new ListItem("身份证号码", "{AC:XY_Code}"));
        lst_AssociatorList.Items.Add(new ListItem("地区", "{AC:XY_Area}"));
        lst_AssociatorList.Items.Add(new ListItem("通讯地址", "{AC:XY_Address}"));
        lst_AssociatorList.Items.Add(new ListItem("联系电话", "{AC:XY_Telephone}"));
        lst_AssociatorList.Items.Add(new ListItem("邮政编号", "{AC:XY_Postcode}"));
        lst_AssociatorList.Items.Add(new ListItem("手机", "{AC:XY_Mobil}"));
        lst_AssociatorList.Items.Add(new ListItem("注册时间", "{AC:XY_Date}"));

        lst_AssociatorList.Items.Add(new ListItem("毕业学校", "{AC:XY_School}"));
        lst_AssociatorList.Items.Add(new ListItem("所学专业", "{AC:XY_Speciality}"));
        lst_AssociatorList.Items.Add(new ListItem("毕业时间", "{AC:XY_Graduate}"));
        lst_AssociatorList.Items.Add(new ListItem("教育程度", "{AC:XY_Level}"));
        lst_AssociatorList.Items.Add(new ListItem("职位", "{AC:XY_Job}"));
        lst_AssociatorList.Items.Add(new ListItem("薪水要求", "{AC:XY_Pay}"));
        lst_AssociatorList.Items.Add(new ListItem("期望所在城市", "{AC:XY_Hopecity}"));
        lst_AssociatorList.Items.Add(new ListItem("工作年限", "{AC:XY_Years}"));
        lst_AssociatorList.Items.Add(new ListItem("工作经验", "{AC:XY_Experience}"));
        lst_AssociatorList.Items.Add(new ListItem("自我评价", "{AC:XY_Appraise}"));
        lst_AssociatorList.Items.Add(new ListItem("链接地址", "{AC:XY_URL}"));
        #endregion

        #region 专题
        lst_TopicList.Items.Add(new ListItem("专题编号", "{TP:XY_ID}"));
        lst_TopicList.Items.Add(new ListItem("专题中文名", "{TP:XY_CName}"));
        lst_TopicList.Items.Add(new ListItem("专题英文名", "{TP:XY_EName}"));
        lst_TopicList.Items.Add(new ListItem("专题类别编号", "{TP:XY_TPCID}"));
        lst_TopicList.Items.Add(new ListItem("专题类别名称", "{TP:XY_TPCName}"));
        lst_TopicList.Items.Add(new ListItem("专题链接地址", "{TP:XY_URL}"));
        lst_TopicList.Items.Add(new ListItem("专题发布时间", "{TP:XY_AddTime}"));
        lst_TopicList.Items.Add(new ListItem("专题静态页面地址", "{TP:XY_HTMLPage}"));
        #endregion

        #region 通用标签

        #region 友情链接
        lst_FriendLink.Items.Add(new ListItem("友情链接地址", "{WI:XY_URL}"));
        lst_FriendLink.Items.Add(new ListItem("图片友情链接说明", "{WI:XY_ALT}"));
        lst_FriendLink.Items.Add(new ListItem("图片友情链接地址", "{WI:XY_SRC}"));
        lst_FriendLink.Items.Add(new ListItem("文字友情链接内容", "{WI:XY_Font}"));
        #endregion

        #region 广告
        lst_advertisingList.Items.Add(new ListItem("广告内容", "{AD:XY_AdInfo}"));
        lst_advertisingList.Items.Add(new ListItem("广告说明", "{AD:XY_Description}"));
        #endregion

        #region 热门关键字
        lst_HotKeyword.Items.Add(new ListItem("关键字", "{hk:xy_keyword}"));
        lst_HotKeyword.Items.Add(new ListItem("链接地址", "{hk:xy_url}"));
        lst_HotKeyword.Items.Add(new ListItem("点击次数", "{hk:xy_clicknum}"));
        #endregion

        #region 省市地
        #endregion

        #endregion

        #region 系统
        lst_System.Items.Add(new ListItem("网站域名", "{SY:XY_WebURL}"));
        lst_System.Items.Add(new ListItem("模板路径", "{SY:XY_TemplatePath}"));
        lst_System.Items.Add(new ListItem("版本号", "{SY:XY_Version}"));

        lst_System.Items.Add(new ListItem("企业类别名称", "{UT:XY_Title}"));
        lst_System.Items.Add(new ListItem("企业类别链接地址", "{UT:XY_URL}"));

        lst_System.Items.Add(new ListItem("资讯栏目", "{NT:XY_Title}"));
        lst_System.Items.Add(new ListItem("资讯栏目链接地址", "{NT:XY_URL}"));

        #endregion

        #region 百科

        lst_baike.Items.Add(new ListItem("词条名称", "{BK:XY_LemmaName}"));
        lst_baike.Items.Add(new ListItem("参考资料", "{BK:XY_Reference}"));
        lst_baike.Items.Add(new ListItem("所属分类", "{BK:XY_LemmaCategory}"));
        lst_baike.Items.Add(new ListItem("扩展阅读", "{BK:XY_ExtendRead}"));
        lst_baike.Items.Add(new ListItem("创建者", "{BK:XY_Creator}"));
        lst_baike.Items.Add(new ListItem("创建时间", "{BK:XY_CreateTime}"));
        lst_baike.Items.Add(new ListItem("浏览次数", "{BK:XY_BrowseTimes}"));
        lst_baike.Items.Add(new ListItem("编辑次数", "{BK:XY_EditTimes}"));
        lst_baike.Items.Add(new ListItem("同义词", "{BK:XY_Synonyms}"));
        lst_baike.Items.Add(new ListItem("英文翻译", "{BK:XY_EnName}"));
        lst_baike.Items.Add(new ListItem("内容", "{BK:XY_Content}"));
        lst_baike.Items.Add(new ListItem("最近更新时间", "{BK:XY_LastModiyTime}"));
        lst_baike.Items.Add(new ListItem("图片路径", "{BK:XY_Picture}"));
        lst_baike.Items.Add(new ListItem("链接地址", "{BK:XY_url}"));

        #endregion

        #region 网上调查
        lst_Vote.Items.Add(new ListItem("调查标题", "{vote:xy_title}"));
        lst_Vote.Items.Add(new ListItem("调查描述", "{vote:xy_desc}"));
        lst_Vote.Items.Add(new ListItem("链接地址", "{vote:xy_url}"));
        #endregion

        #region 团购
        lst_TeamBuy.Items.Add(new ListItem("团购编号", "{TB:Id}"));
        lst_TeamBuy.Items.Add(new ListItem("产品编号", "{TB:ProductId}"));
        lst_TeamBuy.Items.Add(new ListItem("完整标题", "{TB:AllTitle}"));
        lst_TeamBuy.Items.Add(new ListItem("标题", "{TB:Title}"));
        lst_TeamBuy.Items.Add(new ListItem("描述", "{TB:Description}"));
        lst_TeamBuy.Items.Add(new ListItem("图片", "{TB:Image}"));
        lst_TeamBuy.Items.Add(new ListItem("关键字", "{TB:KeyWord}"));
        lst_TeamBuy.Items.Add(new ListItem("市场价", "{TB:MarketPrice}"));
        lst_TeamBuy.Items.Add(new ListItem("当前价", "{TB:CurrentPrice}"));
        lst_TeamBuy.Items.Add(new ListItem("折扣", "{TB:Discount}"));
        lst_TeamBuy.Items.Add(new ListItem("节省", "{TB:Saved}"));
        lst_TeamBuy.Items.Add(new ListItem("成团人数", "{TB:SucPeopleNum}"));
        lst_TeamBuy.Items.Add(new ListItem("参与人数", "{TB:Joins}"));
        lst_TeamBuy.Items.Add(new ListItem("发布时间", "{TB:PubLishDate}"));
        lst_TeamBuy.Items.Add(new ListItem("开始时间", "{TB:StartDate}"));
        lst_TeamBuy.Items.Add(new ListItem("有效期至", "{TB:EndDate}"));
        lst_TeamBuy.Items.Add(new ListItem("用户编号", "{TB:UserId}"));
        lst_TeamBuy.Items.Add(new ListItem("企业地址", "{TB:Address}"));
        lst_TeamBuy.Items.Add(new ListItem("企业名称", "{TB:CompanyName}"));
        lst_TeamBuy.Items.Add(new ListItem("企业电话", "{TB:Telephone}"));
        lst_TeamBuy.Items.Add(new ListItem("登陆名", "{TB:LoginName}"));
        //lst_TeamBuy.Items.Add(new ListItem("平台推荐", "{TB:IsRecommend}"));
        //lst_TeamBuy.Items.Add(new ListItem("企业推荐", "{TB:IsUserRecommend}"));
        //lst_TeamBuy.Items.Add(new ListItem("是否是平台团购", "{TB:IsPlat}"));
        lst_TeamBuy.Items.Add(new ListItem("限购数量", "{TB:LimitCountOfBuy}"));
        lst_TeamBuy.Items.Add(new ListItem("团购连接", "{TB:Url}"));
        lst_TeamBuy.Items.Add(new ListItem("预付金", "{TB:SubScription}"));
        //lst_TeamBuy.Items.Add(new ListItem("倒计时脚本", "{TB:xy_title}"));

        #endregion
    }

    #region 确定
    protected void btnok_Click(object sender, EventArgs e)
    {
        XYECOM.Model.LabelInfo el = new XYECOM.Model.LabelInfo();

        el.LabelTableName = "";
        el.LabelTypeId = XYECOM.Core.MyConvert.GetInt32(this.hidLT_ID.SelectedValue);
        el.LabelCName = this.tbCName.Text.Trim();
        el.LabelName = this.tbName.Text.Trim();
        el.LabelContent = tbContent.Text;
        el.LabelStyleHead = txtHead.Text;
        el.LabelStyleContent = txtConent.Text;
        el.LabelStyleFooter = txtfooter.Text;
        el.LabelTableName = this.hidTableName.Value;
        el.LabelDescription = this.txtDescription.Text.Trim();

        if (rbtnSystem.Checked)
        {
            el.LabelRange = XYECOM.Model.LabelRange.System;
            el.GroupIdOrUserId = "0";
        }
        if (rbtnUser.Checked)
        {
            el.LabelRange = XYECOM.Model.LabelRange.User;
            el.GroupIdOrUserId = this.hidUserIds.Value;
        }
        if (rbtnUserGroup.Checked)
        {
            el.LabelRange = XYECOM.Model.LabelRange.UserGropu;
            el.GroupIdOrUserId = this.hidGroupIds.Value;
        }

        if (L_ID == 0)
        {
            int err = new XYECOM.Business.Label().Insert(el);
            if (err == -1)
            {
                Alert("该标签已存在", "add.aspx");
            }
            else if (err == -2)
            {
                Alert("数据库错误！请稍后再试！", "List.aspx");
            }
            else
            {
                Response.Redirect("list.aspx");
            }
        }
        else
        {
            el.Id = L_ID;
            int err = new XYECOM.Business.Label().Update(el);

            if (err == -2)
            {
                Alert("数据库错误！请稍后再试！", "List.aspx");
            }
            else
            {
                this.Response.Redirect("List.aspx?" + XYECOM.Core.XYRequest.GetQueryString("backURL"));
            }
        }
    }
    #endregion

    #region 属性
    protected long L_ID
    {
        set { ViewState["L_ID"] = value; }
        get { if (ViewState["L_ID"] != null && ViewState["L_ID"].ToString() != "") return Convert.ToInt64(ViewState["L_ID"].ToString()); else return 0; }
    }
    #endregion

    protected void DisplayLabelPage(string lid)
    {
        MyDictionary table = GetData(lid);
        string id = "";
        string label = table["XY"].ToLower();
        switch (label)
        {
            case "supplylist":
            case "supplypagelist":
            case "supplykeypagelist":
                id = "1";
                break;
            case "demandlist":
            case "demandpagelist":
            case "machiningkeypagelist":
                id = "2";
                break;
            case "businesslist":
            case "businesspagelist":
            case "investmentkeypagelist":
                id = "3";
                break;
            case "surrogatelist":
            case "surrogatepagelist":
            case "servicekeypagelist":
                id = "4";
                break;
            case "showlist":
            case "showpagelist":
                id = "5";
                break;
            case "brandlist":
            case "brandpagelist":
                id = "6";
                break;
            case "engagelist":
            case "engagepagelist":
                id = "7";
                break;
            case "corporationlist":
            case "corporationpagelist":
                id = "8";
                break;
            case "newslist":
            case "newspagelist":
            case "usernews":
                id = "9";
                break;
            case "associatorlist":
            case "associatorpagelist":
                id = "11";
                break;
            case "topiclist":
                id = "12";
                break;
            case "hotkeyword":
            case "friendlink":
            case "advertisinglist":
                id = "15";
                break;
            case "baikelist":
            case "baikepagelist":
                id = "17";
                break;
            case "votelist":
                id = "18";
                break;
            case "usernewslist":
            case "usernewspagelist":
                id = "19";
                break;
            case "supplybuylist":
            case "supplybuypagelist":
                id = "20";
                break;
            case "teambuylist":
            case "teambuypagelist":
                id = "21";
                break;
        }
        if (!string.IsNullOrEmpty(id))
        {
            ClientScript.RegisterStartupScript(GetType(), "page", "setshow(" + id + ")", true);
        }
    }

    protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        string lid = this.Request.QueryString["L_ID"];
        DisplayLabelPage(lid);
    }
}
