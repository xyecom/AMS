using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using XYECOM.Core.Data;
using XYECOM.Core;

namespace XYECOM.SQLServer
{
    #region 静态页面设置信息数据库访问类
    /// <summary>
    /// 静态页面设置信息数据库处理类
    /// </summary>
    public class HTMLPageSet
    {
        #region 添加静态页面设置信息
        /// <summary>
        /// 添加静态页面设置信息
        /// </summary>
        /// <param name="ehps">静态页面设置信息属性类对象</param>
        /// <returns>数字。大于0表示设置成功</returns>
        public int Insert(XYECOM.Model.HtmlPageSetInfo ehps)
        {
            SqlParameter[] parm = new SqlParameter[]{
                new SqlParameter("@HPS_Index",ehps.HPS_Index),
                new SqlParameter("@HPS_Indextime",ehps.HPS_Indextime),
                new SqlParameter("@HPS_Supply",ehps.HPS_Supply ),
                new SqlParameter("@HPS_Supplytime",ehps.HPS_Supplytime),
                new SqlParameter("@HPS_Demand",ehps.HPS_Demand),
                new SqlParameter("@HPS_Demandtime",ehps.HPS_Demandtime),
                new SqlParameter("@HPS_Business",ehps.HPS_Bussiness),
                new SqlParameter("@HPS_Businesstime",ehps.HPS_Bussinesstime),
                new SqlParameter("@HPS_Engage",ehps.HPS_Engage),
                new SqlParameter("@HPS_Engagetime",ehps.HPS_Engagetime),
                new SqlParameter("@HPS_Corporation",ehps.HPS_Corporation),
                new SqlParameter("@HPS_Corporationtime",ehps.HPS_Corporationtime),
                new SqlParameter("@HPS_Address",ehps.HPS_Address),
                new SqlParameter("@HPS_Addresstime",ehps.HPS_Addresstime)                 
            };
            int err = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[XYP_InsertHTMLPageSet]", parm);

            return err;
        }
        #endregion

        #region 修改静态页面设置信息
        /// <summary>
        /// 修改静态页面设置信息
        /// </summary>
        /// <param name="ehps">静态页面设置信息属性类对象</param>
        /// <returns>数字。大于0表示修改成功</returns>
        public int Update(XYECOM.Model.HtmlPageSetInfo ehps)
        {
            SqlParameter[] parm = new SqlParameter[]{
                new SqlParameter("@HPS_ID",ehps.HPS_ID),
                new SqlParameter("@HPS_Index",ehps.HPS_Index),
                new SqlParameter("@HPS_Indextime",ehps.HPS_Indextime),
                new SqlParameter("@HPS_Supply",ehps.HPS_Supply ),
                new SqlParameter("@HPS_Supplytime",ehps.HPS_Supplytime),
                new SqlParameter("@HPS_Demand",ehps.HPS_Demand),
                new SqlParameter("@HPS_Demandtime",ehps.HPS_Demandtime),
                new SqlParameter("@HPS_Business",ehps.HPS_Bussiness),
                new SqlParameter("@HPS_Businesstime",ehps.HPS_Bussinesstime),
                new SqlParameter("@HPS_Engage",ehps.HPS_Engage),
                new SqlParameter("@HPS_Engagetime",ehps.HPS_Engagetime),
                new SqlParameter("@HPS_Corporation",ehps.HPS_Corporation),
                new SqlParameter("@HPS_Corporationtime",ehps.HPS_Corporationtime),
                new SqlParameter("@HPS_Address",ehps.HPS_Address),
                new SqlParameter("@HPS_Addresstime",ehps.HPS_Addresstime)                 
            };
            int err = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateHTMLPageSet", parm);

            return err;
        }
        #endregion

        #region 获取静态页面设置信息
        /// <summary>
        /// 获取静态页面设置信息
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="strOrderBy">排序条件</param>
        /// <returns>DataTable数据集</returns>
        public DataTable GetDataTable(string strWhere, string strOrderBy)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere",strWhere),
                new SqlParameter("@strTableName","b_HTMLPageSet"),
                new SqlParameter("@strOrder",strOrderBy)
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure,"XYP_SelectByWhere", param);
        }
        #endregion
    }
    #endregion
}
