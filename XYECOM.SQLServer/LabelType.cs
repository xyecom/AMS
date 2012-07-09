using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using XYECOM.Core.Data;
using XYECOM.Core;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// 标签分类数据处理类
    /// </summary>
    public class LabelType
    {
        #region 添加标签类别
        /// <summary>
        /// 添加标签类别
        /// </summary>
        /// <param name="elt">标签类别属性类对象</param>
        /// <returns>数字。大于0表示添加成功</returns>
        public int Insert(XYECOM.Model.LabelTypeInfo elt)
        {
            SqlParameter[] parm = new SqlParameter[]{
                new SqlParameter("@LT_Name",elt.LT_Name),
                new SqlParameter("@LT_ParentID",elt.LT_ParentID),
                new SqlParameter("@LT_Remark",elt.LT_Remark),

            };

            int err = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[XYP_InsertLabelType]", parm);

            return err;
        }
        #endregion

        #region 修改标签类别
        /// <summary>
        /// 修改标签类别
        /// </summary>
        /// <param name="elt">标签类别属性类对象</param>
        /// <returns>数字。大于0表示修改成功</returns>
        public int Update(XYECOM.Model.LabelTypeInfo elt)
        {
            SqlParameter[] parm = new SqlParameter[]{
                new SqlParameter("@LT_ID",elt.LT_ID),
                new SqlParameter("@LT_Name",elt.LT_Name),
                new SqlParameter("@LT_ParentID",elt.LT_ParentID),
                new SqlParameter("@LT_Remark",elt.LT_Remark),

            };

            int err = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[XYP_UpdateLabelType]", parm);

            return err;
        }
        #endregion

        #region 删除标签类别
        /// <summary>
        /// 删除标签类别
        /// </summary>
        /// <param name="LT_ID">标签类别编号</param>
        /// <returns></returns>
        public int Delete(int LT_ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where LT_ID="+LT_ID.ToString()),
                new SqlParameter("@strTableName","b_LabelType")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }
        #endregion

        #region 获取标签类别
        /// <summary>
        /// 获取指定类别名称
        /// </summary>
        /// <param name="LT_ID">类别编号</param>
        /// <returns>类别名称</returns>
        public string GetLTName(int LT_ID)
        {
            string  elt = "";

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," Where LT_ID=" + LT_ID.ToString()),
                new SqlParameter("@strTableName","b_LabelType"),
                new SqlParameter("@strOrder","")
            };

            using (SqlDataReader dr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure,"XYP_SelectByWhere", param))
            {
                if (dr.Read())
                {
                    elt = dr["LT_Name"].ToString();
                }
            }

            return elt;
        }

        /// <summary>
        /// 获取指定类别信息
        /// </summary>
        /// <param name="LT_ID">类别编号</param>
        /// <returns>类别信息</returns>
        public XYECOM.Model.LabelTypeInfo GetItem(int LT_ID)
        {
            XYECOM.Model.LabelTypeInfo elt = null;

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," Where LT_ID=" + LT_ID.ToString()),
                new SqlParameter("@strTableName","b_LabelType"),
                new SqlParameter("@strOrder","")
            };

            using (SqlDataReader dr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure,"XYP_SelectByWhere", param))
            {                   
                if (dr.Read())
                {
                    elt = new XYECOM.Model.LabelTypeInfo();

                    elt.LT_ID = LT_ID;
                    elt.LT_Name = dr["LT_Name"].ToString();
                    elt.LT_Remark = dr["LT_Remark"].ToString();
                }
            }
               
            return elt;
        }

        /// <summary>
        /// 获取指定条件的类别信息
        /// </summary>
        /// <param name="strWhere">筛选条件</param>
        /// <returns>类别信息集</returns>
        public DataTable GetDataTable(string strWhere)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere",strWhere),
                new SqlParameter("@strTableName","b_LabelType"),
                new SqlParameter("@strOrder","")
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure,"XYP_SelectByWhere", param);
        }
        #endregion
    }
}
