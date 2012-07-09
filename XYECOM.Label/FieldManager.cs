using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace XYECOM.Label
{
    /* ***************************************************************
     * 
     *  XYECOM.Label.FieldManager.cs
     *  创建标识 TC 20080618
     *  
     * 功能：根据内容标签的字段内容生成需要从数据库中查询的字段列表
     *  
     * ***************************************************************/

    /// <summary> 
    /// 标签字段管理类
    /// </summary>
    internal class FieldManager
    {
        XYECOM.Configuration.WebInfo webInfo = XYECOM.Configuration.WebInfo.Instance;
        XYECOM.Configuration.Template templateInfo = XYECOM.Configuration.Template.Instance;
        XYECOM.Configuration.Module moduleInfo = XYECOM.Configuration.Module.Instance;

        static readonly string SYS_NOIMAGE_PATH = "/Common/Images/DefaultImg.gif";

        static string domainHost = "";

        static FieldManager()
        {
            if (System.Web.HttpContext.Current.Request.Params["HTTP_HOST"].ToString().Contains("localhost"))
                domainHost = "0.0.1";
            else
                domainHost = System.Web.HttpContext.Current.Request.Params["HTTP_HOST"].Substring(System.Web.HttpContext.Current.Request.Params["HTTP_HOST"].IndexOf('.'));
        }



        #region 生成需要查询的列名
        /// <summary>
        /// 生成需要查询的列名
        /// </summary>
        /// <param name="strLabelBody">样式循环体标记</param>
        /// <returns>列名列表</returns>
        public string GetColumnName(string strLabelBody)
        {
            StringBuilder columns = new StringBuilder("");

            #region 友情链接
            if (strLabelBody.Contains("{WI:XY_URL}"))
            {
                columns.Append(",FL_URL");
            }
            if (strLabelBody.Contains("{WI:XY_ALT}"))
            {
                columns.Append(",FL_Alt");
            }
            if (strLabelBody.Contains("{WI:XY_Font}"))
            {
                columns.Append(",FL_Font");
            }
            if (strLabelBody.Contains("{WI:XY_SRC}"))
            {
                columns.Append(",FL_Font,S_URL,At_Path");
            }
            #endregion

            #region 供应信息
            if (strLabelBody.Contains("{SP:XY_ID}"))
            {
                columns.Append(",SD_ID");
            }
            if (strLabelBody.Contains("{SP:MarketPrice}"))
            {
                columns.Append(",MarketPrice");
            }
            if (strLabelBody.Contains("{SP:IsContractVouch}"))
            {
                columns.Append(",IsContractVouch");
            }
            if (strLabelBody.Contains("{SP:IsPayBail}"))
            {
                columns.Append(",IsPayBail");
            }
            if (strLabelBody.Contains("{SP:DepotName}"))
            {
                columns.Append(",DepotName");
            }

            if (strLabelBody.Contains("{SP:DepotAddress}"))
            {
                columns.Append(",DepotAddress");
            }
            if (strLabelBody.Contains("{SP:DepotManager}"))
            {
                columns.Append(",DepotManager");
            }
            if (strLabelBody.Contains("{SP:DepotFax}"))
            {
                columns.Append(",DepotFax");
            }
            if (strLabelBody.Contains("{SP:DepotPhone}"))
            {
                columns.Append(",DepotPhone");
            }
            if (strLabelBody.Contains("{SP:DepotEmail}"))
            {
                columns.Append(",DepotEmail");
            }

            if (strLabelBody.Contains("{SP:XY_TitleAll}"))
            {
                columns.Append(",SD_Title,UG_ID");
            }
            if (strLabelBody.Contains("{SP:XY_Title}"))
            {
                columns.Append(",SD_Title,UG_ID");
            }
            if (strLabelBody.Contains("{SP:XY_PName}"))
            {
                columns.Append(",PT_Name");
            }
            if (strLabelBody.Contains("{SP:XY_PURL}"))
            {
                columns.Append(",PT_ID");
            }
            if (strLabelBody.Contains("{SP:XY_Price}"))
            {
                columns.Append(",SD_Price");
            }
            if (strLabelBody.Contains("{SP:XY_Unit}"))
            {
                columns.Append(",SD_Unit");
            }
            if (strLabelBody.Contains("{SP:XY_SmallNum}"))
            {
                columns.Append(",SD_SmallNum");
            }
            if (strLabelBody.Contains("{SP:XY_Num}"))
            {
                columns.Append(",SD_CountNum");
            }
            if (strLabelBody.Contains("{SP:XY_Description}"))
            {
                columns.Append(",SD_Description,UG_ID");
            }
            if (strLabelBody.Contains("{SP:XY_Date}"))
            {
                columns.Append(",SD_PublishDate");
            }
            if (strLabelBody.Contains("{SP:XY_EndDate}"))
            {
                columns.Append(",SD_EndDate");
            }
            if (strLabelBody.Contains("{SP:XY_URL}"))
            {
                columns.Append(",SD_HTMLPage,SD_ID,U_Name,U_id");
            }
            if (strLabelBody.Contains("{SP:XY_Click}"))
            {
                columns.Append(",SD_ClickNum");
            }
            if (strLabelBody.Contains("{SP:XY_IMG}"))
            {
                columns.Append(",IsHasImage,SD_ID");
            }

            if (strLabelBody.Contains("{SP:XY_SmallImg1}") || strLabelBody.Contains("{SP:XY_SmallImg2}") || strLabelBody.Contains("{SP:XY_SmallImg3}"))
            {
                columns.Append(",IsHasImage,SD_ID");
            }

            #endregion

            #region 求购信息
            if (strLabelBody.Contains("{SB:SD_ID}"))
                columns.Append(",SD_ID");
            if (strLabelBody.Contains("{SB:UID}"))
                columns.Append(",UID");
            if (strLabelBody.Contains("{SB:Title}"))
                columns.Append(",Title");
            if (strLabelBody.Contains("{SB:KeyWord}"))
                columns.Append(",KeyWord");
            if (strLabelBody.Contains("{SB:Contetns}"))
                columns.Append(",Contetns");
            if (strLabelBody.Contains("{SB:Name}"))
                columns.Append(",Name");
            if (strLabelBody.Contains("{SB:Tel}"))
                columns.Append(",Tel");
            if (strLabelBody.Contains("{SB:PublishDate}"))
                columns.Append(",PublishDate");

            if (strLabelBody.Contains("{SB:Emergency}"))
                columns.Append(",Emergency");
            if (strLabelBody.Contains("{SB:AuditingState}"))
                columns.Append(",AuditingState");
            if (strLabelBody.Contains("{SB:Url}"))
                columns.Append(",SD_ID");
            if (strLabelBody.Contains("{SB:buyId}"))
                columns.Append(",buyId");
            if (strLabelBody.Contains("{SB:buyareaname}"))
                columns.Append(",buyareaname");
            #endregion

            #region 加工信息
            if (strLabelBody.Contains("{DM:XY_ID}"))
            {
                columns.Append(",SD_ID");
            }
            if (strLabelBody.Contains("{DM:XY_TitleAll}"))
            {
                columns.Append(",SD_Title,UG_ID");
            }
            if (strLabelBody.Contains("{DM:XY_Title}"))
            {
                columns.Append(",SD_Title,UG_ID");
            }
            if (strLabelBody.Contains("{DM:XY_TypeName}"))
            {
                columns.Append(",TypeName");
            }
            if (strLabelBody.Contains("{DM:XY_Summary}"))
            {
                columns.Append(",Summary");
            }
            if (strLabelBody.Contains("{DM:XY_Area}"))
            {
                columns.Append(",Area");
            }
            if (strLabelBody.Contains("{DM:XY_WebSite}"))
            {
                columns.Append(",WebSite");
            }

            //if (strLabelBody.Contains("{DM:XY_PURL}"))
            //{
            //    columns.Append(",TypeId");
            //}
            if (strLabelBody.Contains("{DM:XY_Flag}"))
            {
                columns.Append(",SD_Flag");
            }
            if (strLabelBody.Contains("{DM:XY_Price}"))
            {
                columns.Append(",SD_Price");
            }
            if (strLabelBody.Contains("{DM:XY_Trade}"))
            {
                columns.Append(",Trade");
            }
            if (strLabelBody.Contains("{DM:XY_Description}"))
            {
                columns.Append(",SD_Description,UG_ID");
            }
            if (strLabelBody.Contains("{DM:XY_Date}"))
            {
                columns.Append(",SD_PublishDate");
            }

            if (strLabelBody.Contains("{DM:XY_EndDate}"))
            {
                columns.Append(",SD_EndDate");
            }
            if (strLabelBody.Contains("{DM:XY_URL}"))
            {
                columns.Append(",SD_HTMLPage,SD_ID,SD_Flag,U_Name,u_id");
            }
            #endregion

            #region 招商代理信息
            if (strLabelBody.Contains("{BS:XY_ID}"))
                columns.Append(",IBI_ID");

            if (strLabelBody.Contains("{BS:XY_TitleAll}"))
                columns.Append(",IBI_Title,IBI_Sign,ModuleName,UG_ID");

            if (strLabelBody.Contains("{BS:XY_Title}"))
                columns.Append(",IBI_Title,IBI_Sign,ModuleName,UG_ID");

            if (strLabelBody.Contains("{BS:XY_PName}"))
                columns.Append(",IT_Name");

            if (strLabelBody.Contains("{BS:XY_PURL}"))
                columns.Append(",IT_ID,ModuleName");

            if (strLabelBody.Contains("{BS:XY_Flag}"))
                columns.Append(",IBI_Sign,ModuleName");

            if (strLabelBody.Contains("{BS:XY_Content}"))
                columns.Append(",IBI_Content,UG_ID");

            //删除产品描述字段
            if (strLabelBody.Contains("{BS:XY_Description}"))
                columns.Append(",IBI_Content,UG_ID");

            if (strLabelBody.Contains("{BS:XY_Area}"))
                columns.Append(",A_Area");

            if (strLabelBody.Contains("{BS:XY_BName}"))
                columns.Append(",S_Name,UG_ID");

            if (strLabelBody.Contains("{BS:XY_Support}"))
                columns.Append(",IBI_Support,UG_ID");

            if (strLabelBody.Contains("{BS:XY_Demand}"))
                columns.Append(",IBI_Demand,UG_ID");

            if (strLabelBody.Contains("{BS:XY_Date}"))
                columns.Append(",IBI_PublishDate");

            if (strLabelBody.Contains("{BS:XY_EndDate}"))
                columns.Append(",IBI_EndTime");

            if (strLabelBody.Contains("{BS:XY_ShowURL}"))
                columns.Append(",IBI_URL,IBI_URL,IBI_HTMLPage,IBI_Sign,ModuleName");

            if (strLabelBody.Contains("{BS:XY_URL}"))
                columns.Append(",IBI_HTMLPage,IBI_ID,IBI_Sign");

            if (strLabelBody.Contains("{BS:XY_Click}"))
                columns.Append(",IBI_ClickNum");

            if (strLabelBody.Contains("{BS:XY_IMG}"))
                columns.Append(",IBI_ID,IsHasImage");


            if (strLabelBody.Contains("{BS:XY_SmallImg1}") || strLabelBody.Contains("{BS:XY_SmallImg2}") || strLabelBody.Contains("{BS:XY_SmallImg3}"))
            {
                columns.Append(",IsHasImage,IBI_ID");
            }

            #endregion

            #region 服务信息
            if (strLabelBody.Contains("{SG:XY_ID}"))
                columns.Append(",S_ID");

            if (strLabelBody.Contains("{SG:XY_TitleAll}"))
                columns.Append(",S_Title,S_Flag,ModuleName,UG_ID");

            if (strLabelBody.Contains("{SG:XY_Title}"))
                columns.Append(",S_Title,S_Flag,UG_ID,ModuleName");

            if (strLabelBody.Contains("{SG:XY_PName}"))
                columns.Append(",ST_Name");

            if (strLabelBody.Contains("{SG:XY_Flag}"))
                columns.Append(",S_Flag");

            if (strLabelBody.Contains("{SG:XY_PURL}"))
                columns.Append(",ST_ID,ModuleName");

            if (strLabelBody.Contains("{SG:XY_Date}"))
                columns.Append(",S_AddTime");

            if (strLabelBody.Contains("{SG:XY_EndDate}"))
                columns.Append(",S_EndTime");

            if (strLabelBody.Contains("{SG:XY_Click}"))
                columns.Append(",S_ClickNum");

            if (strLabelBody.Contains("{SG:XY_URL}"))
                columns.Append(",S_HTMLPage,S_ID,S_Flag,ModuleName");

            if (strLabelBody.Contains("{SG:XY_IMG}"))
                columns.Append(",S_ID,IsHasImage");

            if (strLabelBody.Contains("{SG:XY_Content}"))
                columns.Append(",S_Content,UG_ID");

            if (strLabelBody.Contains("{SG:XY_SmallImg1}") || strLabelBody.Contains("{SG:XY_SmallImg2}") || strLabelBody.Contains("{SG:XY_SmallImg3}"))
            {
                columns.Append(",IsHasImage,S_ID");
            }
            #endregion

            #region 展会信息
            if (strLabelBody.Contains("{SH:XY_ID}"))
                columns.Append(",id");

            if (strLabelBody.Contains("{SH:XY_TitleAll}"))
                columns.Append(",infotitle");

            if (strLabelBody.Contains("{SH:XY_Title}"))
                columns.Append(",infotitle");

            if (strLabelBody.Contains("{SH:XY_EndFlag}"))
                columns.Append(",endtime");

            if (strLabelBody.Contains("{SH:XY_PName}"))
                columns.Append(",SHT_Name");

            if (strLabelBody.Contains("{SH:XY_PURL}"))
                columns.Append(",typeid");

            if (strLabelBody.Contains("{SH:XY_Content}"))
                columns.Append(",contents");

            if (strLabelBody.Contains("{SH:XY_BeginTime}"))
                columns.Append(",BeginTime");

            if (strLabelBody.Contains("{SH:XY_EndTime}"))
                columns.Append(",EndTime");

            if (strLabelBody.Contains("{SH:XY_Place}"))
                columns.Append(",District");

            if (strLabelBody.Contains("{SH:XY_Stadiums}"))
                columns.Append(",Site");

            if (strLabelBody.Contains("{SH:XY_Sponsor}"))
                columns.Append(",sponsor");

            if (strLabelBody.Contains("{SH:XY_Undertake}"))
                columns.Append(",undertake");

            if (strLabelBody.Contains("{SH:XY_Coorganizor}"))
                columns.Append(",coorganizor");

            if (strLabelBody.Contains("{SH:XY_Sustain}"))
                columns.Append(",sustain");

            if (strLabelBody.Contains("{SH:XY_ShowSycle}"))
                columns.Append(",Sycle");

            if (strLabelBody.Contains("{SH:XY_ShowCharacter}"))
                columns.Append(",Type");

            if (strLabelBody.Contains("{SH:XY_ShowURL}"))
                columns.Append(",URL,htmlPage,id,ModuleName");

            if (strLabelBody.Contains("{SH:XY_Landmeasure}"))
                columns.Append(",Area");

            if (strLabelBody.Contains("{SH:XY_UnitPrice}"))
                columns.Append(",unitPrice");

            if (strLabelBody.Contains("{SH:XY_MinRation}"))
                columns.Append(",leastRation");

            if (strLabelBody.Contains("{SH:XY_TotalArea}"))
                columns.Append(",areaTotal");

            if (strLabelBody.Contains("{SH:XY_Date}"))
                columns.Append(",AddInfoTime");

            if (strLabelBody.Contains("{SH:XY_URL}"))
                columns.Append(",htmlPage,id");

            if (strLabelBody.Contains("{SH:XY_IMG}"))
                columns.Append(",id,IsHasImage");


            if (strLabelBody.Contains("{SH:XY_SmallImg1}") || strLabelBody.Contains("{SH:XY_SmallImg2}") || strLabelBody.Contains("{SH:XY_SmallImg3}"))
            {
                columns.Append(",IsHasImage,id");
            }

            #endregion

            #region 品牌信息
            if (strLabelBody.Contains("{BD:XY_ID}"))
                columns.Append(",B_ID");

            if (strLabelBody.Contains("{BD:XY_NameAll}"))
                columns.Append(",B_Type,UG_ID");

            if (strLabelBody.Contains("{BD:XY_Name}"))
                columns.Append(",B_Type,UG_ID");

            if (strLabelBody.Contains("{BD:XY_PName}"))
                columns.Append(",PT_Name");

            if (strLabelBody.Contains("{BD:XY_Remark}"))
                columns.Append(",B_Remark,UG_ID");

            if (strLabelBody.Contains("{BD:XY_Date}"))
                columns.Append(",addtime");

            if (strLabelBody.Contains("{BD:XY_ClickNum}"))
                columns.Append(",B_ClickNum");

            if (strLabelBody.Contains("{BD:XY_URL}"))
                columns.Append(",B_HtmlPage,B_ID");

            if (strLabelBody.Contains("{BD:XY_IMG}"))
                columns.Append(",B_ID,IsHasImage");

            if (strLabelBody.Contains("{BD:XY_SmallImg1}") || strLabelBody.Contains("{BD:XY_SmallImg2}") || strLabelBody.Contains("{BD:XY_SmallImg3}"))
            {
                columns.Append(",IsHasImage,B_ID");
            }

            #endregion

            #region 人才信息
            if (strLabelBody.Contains("{EG:XY_ID}"))
                columns.Append(",EI_ID");

            if (strLabelBody.Contains("{EG:XY_Post}"))
                columns.Append(",P_Name");

            if (strLabelBody.Contains("{EG:XY_TitleAll}"))
                columns.Append(",EI_Job,UG_ID");

            if (strLabelBody.Contains("{EG:XY_Title}"))
                columns.Append(",EI_Job,UG_ID");

            if (strLabelBody.Contains("{EG:XY_Branch}"))
                columns.Append(",EI_Branch");

            if (strLabelBody.Contains("{EG:XY_Type}"))
                columns.Append(",EI_Type");

            //if (strLabelBody.Contains("{EG:XY_Province}"))
            //    columns.Append(",Province_Name");

            //if (strLabelBody.Contains("{EG:XY_City}"))
            //    columns.Append(",C_Name");

            if (strLabelBody.Contains("{EG:XY_Area}"))
                columns.Append(",WorkAreaId");

            if (strLabelBody.Contains("{EG:XY_Request}"))
                columns.Append(",EI_Request,UG_ID");

            if (strLabelBody.Contains("{EG:XY_Pay}"))
                columns.Append(",EI_Pay");

            if (strLabelBody.Contains("{EG:XY_SA}"))
                columns.Append(",EI_Eb");

            if (strLabelBody.Contains("{EG:XY_Age}"))
                columns.Append(",EI_Age");

            if (strLabelBody.Contains("{EG:XY_Sex}"))
                columns.Append(",EI_Sex");

            if (strLabelBody.Contains("{EG:XY_Experience}"))
                columns.Append(",EI_Experience");

            if (strLabelBody.Contains("{EG:XY_Nationality}"))
                columns.Append(",EI_Nationality");

            if (strLabelBody.Contains("{EG:XY_Number}"))
                columns.Append(",EI_Number");

            if (strLabelBody.Contains("{EG:XY_Date}"))
                columns.Append(",EI_AddDate");

            if (strLabelBody.Contains("{EG:XY_EndDate}"))
                columns.Append(",EI_EndDate");

            if (strLabelBody.Contains("{EG:XY_URL}"))
                columns.Append(",EI_HTMLPage,U_Name,EI_ID,U_ID");

            if (strLabelBody.Contains("{EG:XY_Click}"))
                columns.Append(",EI_ClickNum");

            #endregion

            #region 企业信息
            if (strLabelBody.Contains("{CP:XY_ID}"))
                columns.Append(",U_ID");

            if (strLabelBody.Contains("{CP:XY_CreditIntegral}") || strLabelBody.Contains("{CP:XY_CreditIntegralImage}") || strLabelBody.Contains("{CP:XY_CreditIntegralLeavl}"))
            {
                columns.Append(",CreditIntegral,u_flag");
            }

            if (strLabelBody.Contains("{CP:XY_NameAll}"))
                columns.Append(",UI_Name");

            if (strLabelBody.Contains("{CP:XY_Name}"))
                columns.Append(",UI_Name");

            if (strLabelBody.Contains("{CP:XY_Area}"))
                columns.Append(",Area_ID");

            if (strLabelBody.Contains("{CP:XY_Address}"))
                columns.Append(",UI_Area");

            if (strLabelBody.Contains("{CP:XY_License}"))
                columns.Append(",UI_License");

            if (strLabelBody.Contains("{CP:XY_Character}"))
                columns.Append(",UI_Character");

            if (strLabelBody.Contains("{CP:XY_LinkMan}"))
                columns.Append(",UI_LinkMan");

            if (strLabelBody.Contains("{CP:XY_IM}"))
                columns.Append(",IM,UG_ID");

            if (strLabelBody.Contains("{CP:XY_Telephone}"))
                columns.Append(",Telephone");

            if (strLabelBody.Contains("{CP:XY_Number}"))
                columns.Append(",UI_Number");

            if (strLabelBody.Contains("{CP:XY_HomePage}"))
                columns.Append(",UI_HomePage");

            if (strLabelBody.Contains("{CP:XY_Fax}"))
                columns.Append(",Fax");

            if (strLabelBody.Contains("{CP:XY_jianjie}"))
                columns.Append(",UI_Synopsis");

            if (strLabelBody.Contains("{CP:XY_Postcode}"))
                columns.Append(",UI_Postcode");

            if (strLabelBody.Contains("{CP:XY_Mobil}"))
                columns.Append(",UI_Mobil");

            if (strLabelBody.Contains("{CP:XY_Type}"))
                columns.Append(",UT_ID");

            if (strLabelBody.Contains("{CP:XY_Gread}"))
                columns.Append(",UG_ID");

            if (strLabelBody.Contains("{CP:XY_GIMG}"))
                columns.Append(",UG_ID");

            if (strLabelBody.Contains("{CP:XY_Section}"))
                columns.Append(",U_Section");

            if (strLabelBody.Contains("{CP:XY_Post}"))
                columns.Append(",U_Post");

            if (strLabelBody.Contains("{CP:XY_Way}"))
                columns.Append(",U_Way");

            if (strLabelBody.Contains("{CP:XY_SupplyProduct}"))
                columns.Append(",U_SupplyProduct");

            if (strLabelBody.Contains("{CP:XY_BuyProduct}"))
                columns.Append(",U_BuyProduct");

            if (strLabelBody.Contains("{CP:XY_Mode}"))
                columns.Append(",U_Mode");

            if (strLabelBody.Contains("{CP:XY_Money}"))
                columns.Append(",U_Money,U_MoneyType");

            if (strLabelBody.Contains("{CP:XY_Year}"))
                columns.Append(",U_Year");

            if (strLabelBody.Contains("{CP:XY_RArea}"))
                columns.Append(",A_N");

            if (strLabelBody.Contains("{CP:XY_LAddress}"))
                columns.Append(",U_Address");

            if (strLabelBody.Contains("{CP:XY_PType}"))
                columns.Append(",U_PType");

            if (strLabelBody.Contains("{CP:XY_Date}"))
                columns.Append(",U_RegDate");

            if (strLabelBody.Contains("{CP:XY_URL}"))
                columns.Append(",U_Name,UG_ID,U_ID");

            if (strLabelBody.Contains("{CP:XY_Click}"))
                columns.Append(",U_ClickNum");

            if (strLabelBody.Contains("{CP:XY_IMG}"))
                columns.Append(",U_ID,UserIsHasImage");

            //if (strLabelBody.Contains("{CP:XY_Cred}"))
            //    columns.Append(",U_Cred");

            if (strLabelBody.Contains("{CP:XY_SmallImg1}") || strLabelBody.Contains("{CP:XY_SmallImg2}") || strLabelBody.Contains("{CP:XY_SmallImg3}"))
            {
                columns.Append(",U_ID,UserIsHasImage");
            }

            #endregion

            #region 个人信息
            if (strLabelBody.Contains("{AC:XY_ID}"))
                columns.Append(",U_ID");

            if (strLabelBody.Contains("{AC:XY_Name}"))
                columns.Append(",UI_Name");

            if (strLabelBody.Contains("{AC:XY_Sex}"))
                columns.Append(",UI_Sex");

            if (strLabelBody.Contains("{AC:XY_Code}"))
                columns.Append(",UI_Code");

            if (strLabelBody.Contains("{AC:XY_Area}"))
                columns.Append(",Area_ID");

            if (strLabelBody.Contains("{AC:XY_Address}"))
                columns.Append(",UI_Address");

            if (strLabelBody.Contains("{AC:XY_Telephone}"))
                columns.Append(",Telephone");

            if (strLabelBody.Contains("{AC:XY_Postcode}"))
                columns.Append(",UI_Postcode");

            if (strLabelBody.Contains("{AC:XY_Mobil}"))
                columns.Append(",UI_Mobil");

            if (strLabelBody.Contains("{AC:XY_Date}"))
                columns.Append(",U_RegDate");
            //
            if (strLabelBody.Contains("{AC:XY_School}"))
                columns.Append(",RE_School");

            if (strLabelBody.Contains("{AC:XY_Speciality}"))
                columns.Append(",RE_Speciality");

            if (strLabelBody.Contains("{AC:XY_Graduate}"))
                columns.Append(",RE_Gyear");

            if (strLabelBody.Contains("{AC:XY_Level}"))
                columns.Append(",RE_Schoolage");

            if (strLabelBody.Contains("{AC:XY_Job}"))
                columns.Append(",RE_Intentjob");

            if (strLabelBody.Contains("{AC:XY_Pay}"))
                columns.Append(",RE_Intentpay");

            if (strLabelBody.Contains("{AC:XY_Hopecity}"))
                columns.Append(",Area_ID");

            if (strLabelBody.Contains("{AC:XY_Years}"))
                columns.Append(",RE_JobYear");

            if (strLabelBody.Contains("{AC:XY_Experience}"))
                columns.Append(",RE_Experience");

            if (strLabelBody.Contains("{AC:XY_Appraise}"))
                columns.Append(",RE_Resume");

            if (strLabelBody.Contains("{AC:XY_URL}"))
                columns.Append(",U_ID");


            #endregion

            #region 企业类别
            if (strLabelBody.Contains("{UT:XY_Title}"))
                columns.Append(",UT_Type");

            if (strLabelBody.Contains("{UT:XY_URL}"))
                columns.Append(",UT_ID");
            #endregion

            #region 资讯栏目
            if (strLabelBody.Contains("{NT:XY_Title}"))
                columns.Append(",NT_Name");

            if (strLabelBody.Contains("{NT:XY_URL}"))
                columns.Append(",NT_EnName,NT_TempletAddress,NT_ID,DomainName");

            #endregion

            #region 资讯信息

            if (strLabelBody.Contains("{NS:XY_ID}"))
                columns.Append(",NS_ID");

            if (strLabelBody.Contains("{NS:XY_TitleAll}"))
                columns.Append(",NS_NewsName,NS_TitleStyle");

            if (strLabelBody.Contains("{NS:XY_Title}"))
                columns.Append(",NS_NewsName,NS_TitleStyle");

            if (strLabelBody.Contains("{NS:XY_TName}"))
                columns.Append(",NT_Name");

            if (strLabelBody.Contains("{NS:XY_STName}"))
                columns.Append(",NT_NessName");

            if (strLabelBody.Contains("{NS:XY_TURL}"))
                columns.Append(",NT_ID,NT_TempletFolderAddress,DomainName");

            if (strLabelBody.Contains("{NS:XY_CurtTitle}"))
                columns.Append(",NS_TwoName");

            if (strLabelBody.Contains("{NS:XY_NaviContentAll}"))
                columns.Append(",NS_NewsLess");

            if (strLabelBody.Contains("{NS:XY_NaviContent}"))
                columns.Append(",NS_NewsLess");

            if (strLabelBody.Contains("{NS:XY_Content}"))
                columns.Append(",NS_NewsNote");

            if (strLabelBody.Contains("{NS:XY_Author}"))
                columns.Append(",NS_NewsAuthor");

            if (strLabelBody.Contains("{NS:XY_Source}"))
                columns.Append(",NS_NewsOrigin");

            if (strLabelBody.Contains("{NS:XY_KeyWord}"))
                columns.Append(",NS_KeyWord");

            if (strLabelBody.Contains("{NS:XY_Date}"))
                columns.Append(",NS_AddTime");

            if (strLabelBody.Contains("{NS:XY_Link}"))
                columns.Append(",NS_LinkAddress,NS_ID,NT_TempletFolderAddress,DomainName");

            if (strLabelBody.Contains("{NS:XY_URL}"))
                columns.Append(",NS_HTMLPage,NS_LinkAddress,NS_ID,NS_Type,NT_TempletFolderAddress,DomainName");

            if (strLabelBody.Contains("{NS:XY_Click}"))
                columns.Append(",NS_Count");

            //资讯图片地址（为兼容之前字段保留）
            if (strLabelBody.Contains("{NS:XY_SmallPicPath}"))
                columns.Append(",IsHasImage,NS_ID");

            //资讯图片地址
            if (strLabelBody.Contains("{NS:XY_PicPath}"))
                columns.Append(",IsHasImage,NS_ID,NS_PicUrl");

            //行业标识
            if (strLabelBody.Contains("{NS:XY_TradeFlag}"))
                columns.Append(",TradeIds");

            //地区标识
            if (strLabelBody.Contains("{NS:XY_AreaFlag}"))
                columns.Append(",AreaIds");

            //新闻附件
            if (strLabelBody.Contains("{NS:XY_Attachment}"))
            {
                columns.Append(",NS_ID");
            }

            #endregion

            #region 用户资讯信息

            if (strLabelBody.Contains("{UNS:XY_ID}"))
                columns.Append(",N_ID");

            if (strLabelBody.Contains("{UNS:XY_TitleAll}"))
                columns.Append(",N_title,TitleStyle");

            //if (strLabelBody.Contains("{UNS:XY_Title}"))
            //    columns.Append(",NS_NewsName,NS_TitleStyle");

            if (strLabelBody.Contains("{UNS:XY_TName}"))
                columns.Append(",Name");

            //if (strLabelBody.Contains("{UNS:XY_STName}"))
            //    columns.Append(",NT_NessName");

            //if (strLabelBody.Contains("{UNS:XY_TURL}"))
            //    columns.Append(",N_ID,NS_TempletFolderAddress,DomainName");

            if (strLabelBody.Contains("{UNS:XY_CurtTitle}"))
                columns.Append(",TwoName");

            if (strLabelBody.Contains("{UNS:XY_NaviContentAll}"))
                columns.Append(",Less");

            //if (strLabelBody.Contains("{UNS:XY_NaviContent}"))
            //    columns.Append(",NS_NewsLess");

            if (strLabelBody.Contains("{UNS:XY_Content}"))
                columns.Append(",N_Content");

            if (strLabelBody.Contains("{UNS:XY_Author}"))
                columns.Append(",Author");

            if (strLabelBody.Contains("{UNS:XY_Source}"))
                columns.Append(",Origin");

            if (strLabelBody.Contains("{UNS:XY_KeyWord}"))
                columns.Append(",KeyWord");

            if (strLabelBody.Contains("{UNS:XY_Date}"))
                columns.Append(",N_addtime");

            //if (strLabelBody.Contains("{UNS:XY_Link}"))
            //    columns.Append(",NS_LinkAddress,NS_ID,NT_TempletFolderAddress,DomainName");

            if (strLabelBody.Contains("{UNS:XY_URL}"))
                columns.Append(",N_ID,U_Name");

            if (strLabelBody.Contains("{UNS:XY_Click}"))
                columns.Append(",Count");

            ////资讯图片地址（为兼容之前字段保留）
            //if (strLabelBody.Contains("{UNS:XY_SmallPicPath}"))
            //    columns.Append(",IsHasImage,NS_ID");

            ////资讯图片地址
            //if (strLabelBody.Contains("{UNS:XY_PicPath}"))
            //    columns.Append(",IsHasImage,NS_ID,NS_PicUrl");

            ////行业标识
            //if (strLabelBody.Contains("{UNS:XY_TradeFlag}"))
            //    columns.Append(",TradeIds");

            ////地区标识
            //if (strLabelBody.Contains("{UNS:XY_AreaFlag}"))
            //    columns.Append(",AreaIds");

            ////新闻附件
            //if (strLabelBody.Contains("{UNS:XY_Attachment}"))
            //{
            //    columns.Append(",NS_ID");
            //}


            #endregion

            #region 广告

            if (strLabelBody.Contains("{AD:XY_AdInfo}"))
                columns.Append(",AD_ID,AD_Size,AD_Color,AD_Font,AD_Type,AD_NoteText,AD_High,AD_Alt,AD_Width,AD_PicURL,AD_JSname,AD_CodeContent,S_URL,AT_Path,AD_Letter,AD_LinkURL,AD_OpenType");

            if (strLabelBody.Contains("{AD:XY_Description}"))
                columns.Append(",AD_Alt");

            #endregion

            #region 专题信息
            if (strLabelBody.Contains("{TP:XY_ID}"))
                columns.Append(",ID");

            if (strLabelBody.Contains("{TP:XY_CName}"))
                columns.Append(",CName");

            if (strLabelBody.Contains("{TP:XY_EName}"))
                columns.Append(",EName");

            if (strLabelBody.Contains("{TP:XY_TPCID}"))
                columns.Append(",TCID");

            if (strLabelBody.Contains("{TP:XY_TPCName}"))
                columns.Append(",TCName");

            if (strLabelBody.Contains("{TP:XY_URL}"))
                columns.Append(",URL,EName,IsDomain");

            if (strLabelBody.Contains("{TP:XY_AddTime}"))
                columns.Append(",AddTime");

            if (strLabelBody.Contains("{TP:XY_HTMLPage}"))
                columns.Append(",HTMLPage");

            #endregion

            #region 热门关键字相关
            if (strLabelBody.Contains("{hk:xy_url}"))
                columns.Append(",sk_sort,sk_name");

            if (strLabelBody.Contains("{hk:xy_keyword}"))
                columns.Append(",sk_name");

            if (strLabelBody.Contains("{hk:xy_clicknum}"))
                columns.Append(",sk_count");
            #endregion

            #region 企业新闻相关
            if (strLabelBody.Contains("{un:xy_title}"))
                columns.Append(",n_title,ug_id");

            if (strLabelBody.Contains("{un:xy_content}"))
                columns.Append(",n_content");

            if (strLabelBody.Contains("{un:xy_addtime}"))
                columns.Append(",n_addtime");

            if (strLabelBody.Contains("{un:xy_url}"))
                columns.Append(",n_id,u_name");
            #endregion

            #region 百科
            if (strLabelBody.Contains("{BK:XY_LemmaName}"))
                columns.Append(",LemmaName");

            if (strLabelBody.Contains("{BK:XY_Reference}"))
                columns.Append(",Reference");

            if (strLabelBody.Contains("{BK:XY_LemmaCategory}"))
                columns.Append(",LemmaCategory");

            if (strLabelBody.Contains("{BK:XY_ExtendRead}"))
                columns.Append(",ExtendRead");

            if (strLabelBody.Contains("{BK:XY_Creator}"))
                columns.Append(",Creator");

            if (strLabelBody.Contains("{BK:XY_CreateTime}"))
                columns.Append(",CreateTime");

            if (strLabelBody.Contains("{BK:XY_EditTimes}"))
                columns.Append(",EditTimes");

            if (strLabelBody.Contains("{BK:XY_BrowseTimes}"))
                columns.Append(",BrowseTimes");

            if (strLabelBody.Contains("{BK:XY_Synonyms}"))
                columns.Append(",Synonyms");

            if (strLabelBody.Contains("{BK:XY_EnName}"))
                columns.Append(",EnName");

            if (strLabelBody.Contains("{BK:XY_Content}"))
                columns.Append(",Content");

            if (strLabelBody.Contains("{BK:XY_LastModiyTime}"))
                columns.Append(",LastModiyTime");

            if (strLabelBody.Contains("{BK:XY_Picture}"))
                columns.Append(",Picture");

            if (strLabelBody.Contains("{BK:XY_url}"))
                columns.Append(",LemmaId");


            #endregion

            #region 网上调查
            if (strLabelBody.Contains("{vote:xy_title}"))
                columns.Append(",Title");

            if (strLabelBody.Contains("{vote:xy_desc}"))
                columns.Append(",[Desc]");

            if (strLabelBody.Contains("{vote:xy_url}"))
                columns.Append(",VoteId");

            #endregion


            #region 团购
            if (strLabelBody.Contains("{TB:Url}") || strLabelBody.Contains("{TB:Image}") || strLabelBody.Contains("{TB:Id}"))
                columns.Append(",Id,HtmlPage,UserId,IsPlatForm");
            if (strLabelBody.Contains("{TB:Address}"))
                columns.Append(",Address");
            if (strLabelBody.Contains("{TB:CompanyName}"))
                columns.Append(",CompanyName");
            if (strLabelBody.Contains("{TB:Telephone}"))
                columns.Append(",Telephone");
            if (strLabelBody.Contains("{TB:LoginName}"))
                columns.Append(",LoginName");
            if (strLabelBody.Contains("{TB:IsRecommend}"))
                columns.Append(",IsRecommend");
            if (strLabelBody.Contains("{TB:IsUserRecommend}"))
                columns.Append(",IsUserRecommend");
            if (strLabelBody.Contains("{TB:IsPlat}"))
                columns.Append(",IsPlatform");
            if (strLabelBody.Contains("{TB:UserId}"))
                columns.Append(",UserId");
            if (strLabelBody.Contains("{TB:EndDate}"))
                columns.Append(",EndDate");
            if (strLabelBody.Contains("{TB:StartDate}"))
                columns.Append(",StartDate");
            if (strLabelBody.Contains("{TB:PubLishDate}"))
                columns.Append(",PublishDate");
            if (strLabelBody.Contains("{TB:SucPeopleNum}"))
                columns.Append(",SucPeopleNum");
            if (strLabelBody.Contains("{TB:KeyWord}"))
                columns.Append(",KeyWord");
            if (strLabelBody.Contains("{TB:ProductId}"))
                columns.Append(",ProductId");
            if (strLabelBody.Contains("{TB:Title}") || strLabelBody.Contains("{TB:AllTitle}"))
                columns.Append(",Title");
            if (strLabelBody.Contains("{TB:Description}"))
                columns.Append(",Description");
            if (strLabelBody.Contains("{TB:LimitCountOfBuy}"))
                columns.Append(",LimitCountOfBuy");
            if (strLabelBody.Contains("{TB:SubScription}"))
                columns.Append(",SubScription");


            if (strLabelBody.Contains("{TB:MarketPrice}") || strLabelBody.Contains("{TB:Discount}")
                || strLabelBody.Contains("{TB:Saved}") || strLabelBody.Contains("{TB:CurrentPrice}")
                || strLabelBody.Contains("{TB:Joins}"))
                columns.Append(",Id,MarketPrice,CurrentJoin,CurrentPrice,SucPeopleNum");

            #endregion

            if (columns.Length > 0)
            {
                string str = columns.ToString().Substring(1);

                string[] cols = Core.Utils.RepaceSpilthItem(str.Split(','));

                return Core.Utils.ArrayToString(cols);
            }

            return columns.ToString();
        }
        #endregion

        #region 替换样式
        /// <summary>
        /// 替换标签字段为真实数据
        /// </summary>
        /// <param name="index">索引号</param>
        /// <param name="labelFlagName">标签标识名称</param>
        /// <param name="labelBody">标签主体</param>
        /// <param name="dataRow">数据行</param>
        /// <param name="queryParam">标签格式条件</param>
        /// <returns></returns>
        public string ReplaceField(int index, string labelFlagName, string labelBody, DataRow dataRow, LabelQueryParameterInfo queryParam)
        {

            List<XYECOM.Configuration.ModuleItemInfo> moduleItems = new List<XYECOM.Configuration.ModuleItemInfo>();

            labelFlagName = labelFlagName.ToLower().Trim();

            labelBody = labelBody.Replace("{i}", index.ToString());

            #region  系统字段
            if (labelBody.Contains("{SY:XY_WebURL}"))
            {
                labelBody = labelBody.Replace("{SY:XY_WebURL}", webInfo.WebDomain);
            }
            if (labelBody.Contains("{SY:XY_TemplatePath}"))
            {
                labelBody = labelBody.Replace("{SY:XY_TemplatePath}", templateInfo.Path);
            }
            //if (str.IndexOf("{SY:XY_Coptright}") > 0)
            //{
            //    str = str.Replace("{SY:XY_Coptright}", "XYECS!b2b");
            //}
            if (labelBody.Contains("{SY:XY_Version}"))
            {
                labelBody = labelBody.Replace("{SY:XY_Version}", System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Web.HttpContext.Current.Server.MapPath("/bin/XYECOM.Web.dll")).FileVersion);
            }
            #endregion

            #region 友情链接

            if (labelBody.Contains("{WI:XY_URL}"))
            {
                if (IsHaveColumn(dataRow, "FL_URL"))
                    labelBody = labelBody.Replace("{WI:XY_URL}", dataRow["FL_URL"].ToString());
            }

            if (labelBody.Contains("{WI:XY_ALT}"))
            {
                if (queryParam.IsFriendLinkAlt)
                {
                    if (IsHaveColumn(dataRow, "FL_Alt"))
                        labelBody = labelBody.Replace("{WI:XY_ALT}", dataRow["FL_Alt"].ToString());
                }
                else
                {
                    labelBody = labelBody.Replace("{WI:XY_ALT}", "");
                }
            }

            if (labelBody.Contains("{WI:XY_SRC}"))
            {
                if (dataRow["FL_Font"].ToString() == "Image")
                {
                    if (IsHaveColumn(dataRow, "At_Path"))
                        labelBody = labelBody.Replace("{WI:XY_SRC}", dataRow["S_URL"].ToString() + dataRow["At_Path"].ToString());
                }
                else
                {
                    if (IsHaveColumn(dataRow, "FL_Font"))
                        labelBody = labelBody.Replace("{WI:XY_SRC}", dataRow["FL_Font"].ToString());
                }
            }
            if (labelBody.Contains("{WI:XY_Font}"))
            {
                if (IsHaveColumn(dataRow, "FL_Font"))
                    labelBody = labelBody.Replace("{WI:XY_Font}", dataRow["FL_Font"].ToString());
            }

            #endregion            

            #region 资讯栏目

            string allDomainName = "";
            if (labelBody.Contains("{NT:XY_Title}"))
            {
                if (IsHaveColumn(dataRow, "NT_Name"))
                    labelBody = labelBody.Replace("{NT:XY_Title}", dataRow["NT_Name"].ToString());
            }
            if (labelBody.Contains("{NT:XY_URL}"))
            {
                if (dataRow["DomainName"].ToString() != "")
                {
                    allDomainName = webInfo.GetSubDomain(dataRow["DomainName"].ToString());
                }
                if (dataRow["NT_TempletAddress"].ToString() != "")
                    labelBody = labelBody.Replace("{NT:XY_URL}", webInfo.WebDomain + "news/" + dataRow["NT_EnName"].ToString() + "/" + dataRow["NT_TempletAddress"].ToString().Substring(0, dataRow["NT_TempletAddress"].ToString().IndexOf('.')) + "." + webInfo.WebSuffix);
                else
                {
                    if (webInfo.IsBogusStatic)
                    {
                        if (webInfo.IsNewsDomain && dataRow["DomainName"].ToString() != "")
                        {
                            labelBody = labelBody.Replace("{NT:XY_URL}", allDomainName + "channel-" + dataRow["NT_ID"].ToString() + "." + webInfo.WebSuffix);
                        }
                        else
                        {
                            labelBody = labelBody.Replace("{NT:XY_URL}", webInfo.WebDomain + "news/channel-" + dataRow["NT_ID"].ToString() + "." + webInfo.WebSuffix);
                        }
                    }
                    else
                    {
                        if (webInfo.IsNewsDomain && dataRow["DomainName"].ToString() != "")
                        {
                            labelBody = labelBody.Replace("{NT:XY_URL}", allDomainName + "channel." + webInfo.WebSuffix + "?nt_id=" + dataRow["NT_ID"].ToString());
                        }
                        else
                        {
                            labelBody = labelBody.Replace("{NT:XY_URL}", webInfo.WebDomain + "news/channel." + webInfo.WebSuffix + "?nt_id=" + dataRow["NT_ID"].ToString());
                        }
                    }
                }
            }
            #endregion

            #region 新闻信息
            if (labelFlagName.Equals("newslist") || labelFlagName.Equals("newspagelist"))
            {
                if (labelBody.Contains("{NS:XY_ID}"))
                    labelBody = labelBody.Replace("{NS:XY_ID}", dataRow["NS_ID"].ToString());

                if (labelBody.Contains("{NS:XY_TitleAll}"))
                {
                    string newsName = XYECOM.Business.FiltrateKeyWord.LeachKeyWord(dataRow["NS_NewsName"].ToString());

                    if (!dataRow["NS_TitleStyle"].ToString().Trim().Equals(""))
                    {
                        newsName = "<font style=" + dataRow["NS_TitleStyle"].ToString().Trim() + ">" + newsName + "</font>";
                    }

                    labelBody = labelBody.Replace("{NS:XY_TitleAll}", newsName);
                }

                if (labelBody.Contains("{NS:XY_Title}"))
                {
                    string newsName = XYECOM.Core.Utils.IsLength(queryParam.TitleFontNumbers, XYECOM.Business.FiltrateKeyWord.LeachKeyWord(dataRow["NS_NewsName"].ToString()));

                    if (!dataRow["NS_TitleStyle"].ToString().Trim().Equals(""))
                    {
                        newsName = "<font style=" + dataRow["NS_TitleStyle"].ToString().Trim() + ">" + newsName + "</font>";
                    }

                    labelBody = labelBody.Replace("{NS:XY_Title}", newsName);
                }

                if (labelBody.Contains("{NS:XY_TName}"))
                    labelBody = labelBody.Replace("{NS:XY_TName}", dataRow["NT_Name"].ToString());

                if (labelBody.Contains("{NS:XY_STName}"))
                    labelBody = labelBody.Replace("{NS:XY_STName}", dataRow["NT_NessName"].ToString());

                if (labelBody.Contains("{NS:XY_TURL}"))
                {
                    if (dataRow["DomainName"].ToString() != "")
                    {
                        allDomainName = webInfo.GetSubDomain(dataRow["DomainName"].ToString());
                    }
                    string channelId = dataRow["NT_ID"].ToString();
                    string subChannelFolder = dataRow["NT_TempletFolderAddress"].ToString().Trim();

                    if (!subChannelFolder.Equals("")) subChannelFolder = subChannelFolder + "/";

                    channelId = Core.Utils.RemoveStartComma(channelId);

                    channelId = channelId.Substring(0, channelId.IndexOf(','));

                    if (webInfo.IsBogusStatic)
                    {
                        if (webInfo.IsNewsDomain && dataRow["DomainName"].ToString() != "")
                        {
                            labelBody = labelBody.Replace("{NS:XY_TURL}", allDomainName + "channel-" + channelId + "." + webInfo.WebSuffix);
                        }
                        else
                        {
                            labelBody = labelBody.Replace("{NS:XY_TURL}", webInfo.WebDomain + "news/" + subChannelFolder + "channel-" + channelId + "." + webInfo.WebSuffix);
                        }
                    }
                    else
                    {
                        if (webInfo.IsNewsDomain && dataRow["DomainName"].ToString() != "")
                        {
                            labelBody = labelBody.Replace("{NS:XY_TURL}", allDomainName + "channel." + webInfo.WebSuffix + "?nt_id=" + channelId);
                        }
                        else
                        {
                            labelBody = labelBody.Replace("{NS:XY_TURL}", webInfo.WebDomain + "news/" + subChannelFolder + "channel." + webInfo.WebSuffix + "?nt_id=" + channelId);
                        }
                    }
                }
                if (labelBody.Contains("{NS:XY_CurtTitle}"))
                    labelBody = labelBody.Replace("{NS:XY_CurtTitle}", XYECOM.Business.FiltrateKeyWord.LeachKeyWord(dataRow["NS_TwoName"].ToString()));
                if (labelBody.Contains("{NS:XY_NaviContentAll}"))
                    labelBody = labelBody.Replace("{NS:XY_NaviContentAll}", XYECOM.Business.FiltrateKeyWord.LeachKeyWord(dataRow["NS_NewsLess"].ToString()));
                if (labelBody.Contains("{NS:XY_NaviContent}"))
                    labelBody = labelBody.Replace("{NS:XY_NaviContent}", XYECOM.Core.Utils.IsLength(queryParam.NewsLeadinFontNumber, XYECOM.Business.FiltrateKeyWord.LeachKeyWord(XYECOM.Core.Utils.RemoveHTML(dataRow["NS_NewsLess"].ToString()))));
                if (labelBody.Contains("{NS:XY_Content}"))
                    labelBody = labelBody.Replace("{NS:XY_Content}", XYECOM.Business.FiltrateKeyWord.LeachKeyWord(dataRow["NS_NewsNote"].ToString()));
                if (labelBody.Contains("{NS:XY_Author}"))
                    labelBody = labelBody.Replace("{NS:XY_Author}", dataRow["NS_NewsAuthor"].ToString());
                if (labelBody.Contains("{NS:XY_Source}"))
                    labelBody = labelBody.Replace("{NS:XY_Source}", dataRow["NS_NewsOrigin"].ToString());
                if (labelBody.Contains("{NS:XY_KeyWord}"))
                    labelBody = labelBody.Replace("{NS:XY_KeyWord}", XYECOM.Business.FiltrateKeyWord.LeachKeyWord(dataRow["NS_KeyWord"].ToString()));
                if (labelBody.Contains("{NS:XY_Date}"))
                {
                    if (queryParam.DateFormat != "")
                        labelBody = labelBody.Replace("{NS:XY_Date}", FormatDateTime(dataRow["NS_AddTime"].ToString(), queryParam.DateFormat));
                    else
                        labelBody = labelBody.Replace("{NS:XY_Date}", dataRow["NS_AddTime"].ToString());
                }
                if (labelBody.Contains("{NS:XY_Link}"))
                {
                    if (dataRow["DomainName"].ToString() != "")
                    {
                        allDomainName = webInfo.GetSubDomain(dataRow["DomainName"].ToString());
                    }
                    if (IsHaveColumn(dataRow, "NS_LinkAddress"))
                    {
                        if (dataRow["NS_LinkAddress"].ToString() != "")
                            labelBody = labelBody.Replace("{NS:XY_Link}", dataRow["NS_LinkAddress"].ToString());
                        else
                        {
                            string subChannelFolder = dataRow["NT_TempletFolderAddress"].ToString().Trim();
                            if (!subChannelFolder.Equals("")) subChannelFolder = subChannelFolder + "/";

                            if (webInfo.IsBogusStatic)
                                if (webInfo.IsNewsDomain && dataRow["DomainName"].ToString() != "")
                                {
                                    labelBody = labelBody.Replace("{NS:XY_Link}", allDomainName + "content-" + dataRow["NS_ID"].ToString() + "." + webInfo.WebSuffix);
                                }
                                else
                                {
                                    labelBody = labelBody.Replace("{NS:XY_Link}", webInfo.WebDomain + "news/" + subChannelFolder + "content-" + dataRow["NS_ID"].ToString() + "." + webInfo.WebSuffix);
                                }
                            else
                            {
                                if (webInfo.IsNewsDomain && dataRow["DomainName"].ToString() != "")
                                {
                                    labelBody = labelBody.Replace("{NS:XY_Link}", allDomainName + "content." + webInfo.WebSuffix + "?ns_id=" + dataRow["NS_ID"].ToString());
                                }
                                else
                                {
                                    labelBody = labelBody.Replace("{NS:XY_Link}", webInfo.WebDomain + "news/" + subChannelFolder + "content." + webInfo.WebSuffix + "?ns_id=" + dataRow["NS_ID"].ToString());
                                }
                            }
                        }
                    }
                }
                if (labelBody.Contains("{NS:XY_URL}"))
                {
                    string subChannelFolder = dataRow["NT_TempletFolderAddress"].ToString().Trim();
                    if (!subChannelFolder.Equals("")) subChannelFolder = subChannelFolder + "/";
                    if (dataRow["DomainName"].ToString() != "")
                    {
                        allDomainName = webInfo.GetSubDomain(dataRow["DomainName"].ToString());
                    }

                    if (dataRow["NS_Type"].ToString() == "3")
                    {
                        if (dataRow["NS_LinkAddress"].ToString() != "")
                            labelBody = labelBody.Replace("{NS:XY_URL}", dataRow["NS_LinkAddress"].ToString());
                        else
                        {
                            if (webInfo.IsBogusStatic)
                                if (webInfo.IsNewsDomain && dataRow["DomainName"].ToString() != "")
                                {
                                    labelBody = labelBody.Replace("{NS:XY_URL}", allDomainName + "content-" + dataRow["NS_ID"].ToString() + "." + webInfo.WebSuffix);
                                }
                                else
                                {
                                    labelBody = labelBody.Replace("{NS:XY_URL}", webInfo.WebDomain + "news/" + subChannelFolder + "content-" + dataRow["NS_ID"].ToString() + "." + webInfo.WebSuffix);
                                }
                            else
                            {
                                if (webInfo.IsNewsDomain && dataRow["DomainName"].ToString() != "")
                                {
                                    labelBody = labelBody.Replace("{NS:XY_URL}", allDomainName + "content." + webInfo.WebSuffix + "?ns_id=" + dataRow["NS_ID"].ToString());
                                }
                                else
                                {
                                    labelBody = labelBody.Replace("{NS:XY_URL}", webInfo.WebDomain + "news/" + subChannelFolder + "content." + webInfo.WebSuffix + "?ns_id=" + dataRow["NS_ID"].ToString());
                                }
                            }

                        }
                    }
                    else
                    {
                        if (dataRow["NS_HTMLPage"].ToString() != "")
                            labelBody = labelBody.Replace("{NS:XY_URL}", webInfo.WebDomain + dataRow["NS_HTMLPage"].ToString());
                        else
                        {
                            if (webInfo.IsBogusStatic)
                                if (webInfo.IsNewsDomain && dataRow["DomainName"].ToString() != "")
                                {
                                    labelBody = labelBody.Replace("{NS:XY_URL}", allDomainName + "content-" + dataRow["NS_ID"].ToString() + "." + webInfo.WebSuffix);
                                }
                                else
                                {
                                    labelBody = labelBody.Replace("{NS:XY_URL}", webInfo.WebDomain + "news/" + subChannelFolder + "content-" + dataRow["NS_ID"].ToString() + "." + webInfo.WebSuffix);
                                }
                            else
                            {
                                if (webInfo.IsNewsDomain && dataRow["DomainName"].ToString() != "")
                                {
                                    labelBody = labelBody.Replace("{NS:XY_URL}", allDomainName + "content." + webInfo.WebSuffix + "?ns_id=" + dataRow["NS_ID"].ToString());
                                }
                                else
                                {
                                    labelBody = labelBody.Replace("{NS:XY_URL}", webInfo.WebDomain + "news/" + subChannelFolder + "content." + webInfo.WebSuffix + "?ns_id=" + dataRow["NS_ID"].ToString());
                                }
                            }
                        }
                    }
                }

                if (labelBody.Contains("{NS:XY_Click}"))
                    labelBody = labelBody.Replace("{NS:XY_Click}", dataRow["NS_Count"].ToString());

                //资讯图片地址(为兼容之前字段保留)
                if (labelBody.Contains("{NS:XY_SmallPicPath}"))
                {
                    if (IsHaveColumn(dataRow, "IsHasImage"))
                    {
                        if (dataRow["IsHasImage"].ToString() != "0")
                        {
                            long infoId = Core.MyConvert.GetInt64(dataRow["NS_ID"].ToString());

                            string imgUrl = Business.Attachment.GetInfoDefaultImgHref(XYECOM.Model.AttachmentItem.News, infoId);

                            labelBody = labelBody.Replace("{NS:XY_SmallPicPath}", imgUrl);
                        }
                        else
                        {
                            if (!dataRow["NS_PicUrl"].ToString().Equals(""))
                            {
                                labelBody = labelBody.Replace("{NS:XY_PicPath}", dataRow["NS_PicUrl"].ToString());
                            }
                            else
                            {
                                labelBody = labelBody.Replace("{NS:XY_SmallPicPath}", SYS_NOIMAGE_PATH);
                            }
                        }
                    }
                }
                //资讯图片地址
                if (labelBody.Contains("{NS:XY_PicPath}"))
                {
                    if (IsHaveColumn(dataRow, "IsHasImage"))
                    {
                        if (dataRow["IsHasImage"].ToString() != "0")
                        {
                            long infoId = Core.MyConvert.GetInt64(dataRow["NS_ID"].ToString());

                            string imgUrl = Business.Attachment.GetInfoDefaultImgHref(XYECOM.Model.AttachmentItem.News, infoId);

                            labelBody = labelBody.Replace("{NS:XY_PicPath}", imgUrl);
                        }
                        else
                        {
                            if (!dataRow["NS_PicUrl"].ToString().Equals(""))
                            {
                                labelBody = labelBody.Replace("{NS:XY_PicPath}", dataRow["NS_PicUrl"].ToString());
                            }
                            else
                            {
                                labelBody = labelBody.Replace("{NS:XY_PicPath}", SYS_NOIMAGE_PATH);
                            }
                        }
                    }
                }

                if (labelBody.Contains("{NS:XY_Attachment}"))
                {
                    if (IsHaveColumn(dataRow, "NS_ID"))
                    {
                        string attachment = "";
                        long infoId = Core.MyConvert.GetInt64(dataRow["NS_ID"].ToString());

                        XYECOM.Business.Attachment attBll = new XYECOM.Business.Attachment();

                        DataTable dt = attBll.GetDataTable(infoId, XYECOM.Model.AttachmentItem.News, XYECOM.Model.UploadFileType.File);

                        string divfmt = "<div class=\"attachment\"><a href=\"{0}\">附件{1}</a></div>";

                        int aIndex = 1;
                        foreach (DataRow row in dt.Rows)
                        {
                            XYECOM.Model.ServerInfo info = new XYECOM.Business.Server().GetItem(Core.MyConvert.GetInt32(row["S_ID"].ToString()));
                            attachment += string.Format(divfmt, info.S_URL + row["At_Path"], aIndex++);
                        }
                        labelBody = labelBody.Replace("{NS:XY_Attachment}", attachment);
                    }
                }               

                //地区标识
                if (labelBody.Contains("{NS:XY_AreaFlag}"))
                {
                    string areaName = "";
                    if (IsHaveColumn(dataRow, "AreaIds"))
                    {
                        //=========================================================================/
                        int aId = XYECOM.Core.MyConvert.GetInt32(dataRow["AreaIds"].ToString().Split(',')[1]);

                        if (aId > 0)
                        {
                            XYECOM.Model.AreaInfo aInfo = new XYECOM.Business.Area().GetItem(aId);
                            if (null != aInfo) areaName = aInfo.Name;
                        }
                        //=========================================================================/
                    }
                    labelBody = labelBody.Replace("{NS:XY_AreaFlag}", areaName);
                }
            }
            #endregion

            return labelBody;
        }
        #endregion

        /// <summary>
        /// 获取热门关键词连接
        /// </summary>
        /// <param name="moduleName">模块名称</param>
        /// <param name="keyword">关键词</param>
        /// <param name="toPage">目的页面</param>
        /// <returns></returns>
        private static string GetHotKeywordUrl(string moduleName, string keyword, string toPage)
        {
            string url = "";

            XYECOM.Configuration.WebInfo webInfo = XYECOM.Configuration.WebInfo.Instance;

            string pageSuffix = webInfo.WebSuffix;

            string sellLinkUrl = "/search/seller_search." + pageSuffix + "?flag={0}&keyword={1}";
            string sellBogueStaticLinkUrl = "/search/seller_search-{0}--{1}-------." + pageSuffix + "";

            string buyLinkUrl = "/search/buyer_search." + pageSuffix + "?flag={0}&keyword={1}";
            string buyBogueStaticLinkUrl = "/search/buyer_search-{0}--{1}-------." + pageSuffix + "";

            string jobLinkUrl = "/job/list." + pageSuffix + "?keyword={0}'";
            string bogusStaticJobLinkUrl = "/job/list-----{0}---." + pageSuffix + "";

            string newsLinkUrl = "/search/news_search." + pageSuffix + "?keyword={0}";
            string bogusStaticNewsLinkUrl = "/search/news_search---{0}-----." + pageSuffix + "";

            string srcUrl = "";

            XYECOM.Configuration.InfoType infoType = XYECOM.Configuration.InfoType.Sell;

            if (!toPage.Equals("") && toPage.Equals("求购页"))
                infoType = XYECOM.Configuration.InfoType.Buy;

            if (moduleName.Equals("news") || moduleName.Equals("job"))
            {
                if (webInfo.IsBogusStatic)
                    srcUrl = moduleName.Equals("news") ? bogusStaticNewsLinkUrl : bogusStaticJobLinkUrl;
                else
                    srcUrl = moduleName.Equals("news") ? newsLinkUrl : jobLinkUrl;

                url = String.Format(srcUrl, keyword);
            }
            else if (moduleName.Equals("brand") || moduleName.Equals("company"))
            {
                if (webInfo.IsBogusStatic)
                    srcUrl = sellBogueStaticLinkUrl;
                else
                    srcUrl = sellLinkUrl;

                url = String.Format(srcUrl, moduleName, keyword);
            }
            else
            {
                if (webInfo.IsBogusStatic)
                    srcUrl = infoType == XYECOM.Configuration.InfoType.Sell ? sellBogueStaticLinkUrl : buyBogueStaticLinkUrl;
                else
                    srcUrl = infoType == XYECOM.Configuration.InfoType.Sell ? sellLinkUrl : buyLinkUrl;

                url = String.Format(srcUrl, moduleName, keyword);
            }

            return url;
        }

        /// <summary>
        /// 行中是否包含指定的列
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="strColumuName"></param>
        /// <returns></returns>
        private static bool IsHaveColumn(DataRow dr, string strColumuName)
        {
            for (int i = 0; i < dr.Table.Columns.Count; i++)
            {
                if (dr.Table.Columns[i].ColumnName.ToLower().Equals(strColumuName.ToLower()))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 根据指定的格式转化日期
        /// </summary>
        /// <param name="dateTime">日期</param>
        /// <param name="format">格式</param>
        /// <returns></returns>
        private static string FormatDateTime(string dateTime, string format)
        {
            string date = "";
            //自定
            try
            {
                date = XYECOM.Core.MyConvert.GetDateTime(dateTime).ToString(format);
            }
            catch
            {
                date = XYECOM.Core.MyConvert.GetDateTime(dateTime).ToString("yyyy-MM-dd");
            }

            return date;
        }

        /// <summary>
        /// 返回缩略图地址
        /// </summary>
        /// <param name="labelName">缩略图字段标签名称</param>
        /// <param name="dataRow">数据行</param>
        /// <param name="imageIndex">图片索引(1,2,3)</param>
        /// <returns></returns>
        private static string GetThumbnailiImagePath(string infoId, Model.AttachmentItem attItem, int imageIndex)
        {
            string path = SYS_NOIMAGE_PATH;

            long _InfoId = Core.MyConvert.GetInt64(infoId);

            Model.AttachmentInfo attInfo = Business.Attachment.GetTop1Info(attItem, _InfoId);

            if (attInfo == null) return path;

            if (attInfo.SmallImg != null)
            {
                return attInfo.SmallImg[imageIndex - 1];
            }

            if (attInfo.At_Path.Equals("")) return path;

            return attInfo.Server.S_URL + attInfo.At_Path;
        }

        /// <summary>
        /// 返回企业缩略图地址
        /// </summary>
        /// <param name="dataRow"></param>
        /// <param name="imageIndex"></param>
        /// <returns></returns>
        private static string GetUserThumbnailiImagePath(DataRow dataRow, int imageIndex)
        {
            string path = SYS_NOIMAGE_PATH;

            if (!IsHaveColumn(dataRow, "U_ID")) return path;

            long userId = Core.MyConvert.GetInt64(dataRow["U_ID"].ToString());

            Model.AttachmentInfo info = Business.Attachment.GetTop1Info(XYECOM.Model.AttachmentItem.Logo, userId);

            if (info == null) return path;

            if (info.SmallImg != null)
            {
                return info.SmallImg[imageIndex - 1];
            }

            if (info.At_Path.Equals("")) return path;

            return info.Server.S_URL + info.At_Path;
        }
    }
}
