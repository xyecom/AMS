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
    /// 标签信息数据库处理类
    /// </summary>
    public class Label : DataCache
    {
        #region 添加标签信息
        /// <summary>
        /// 添加标签信息
        /// </summary>
        /// <param name="info">标签信息属性类对象</param>
        /// <returns>数字。大于0表示添加成功</returns>
        public int Insert(XYECOM.Model.LabelInfo info)
        {
            SqlParameter[] parm = new SqlParameter[]{
                new SqlParameter("@L_Name",info.LabelName),
                new SqlParameter("@L_CName",info.LabelCName),
                new SqlParameter("@LT_ID",info.LabelTypeId),
                new SqlParameter("@L_TableName",info.LabelTableName),
                new SqlParameter("@L_Content",info.LabelContent),
                new SqlParameter("@L_StyleHead",info.LabelStyleHead),
                new SqlParameter("@L_StyleContent",info.LabelStyleContent),
                new SqlParameter("@L_StyleFooter",info.LabelStyleFooter),
                new SqlParameter("@membership",info.LabelRangeData),
                new SqlParameter("@labelDescription",info.LabelDescription)
            };

            int err = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[XYP_InsertLabel]", parm);

            UpdateCache();

            return err;
        }
        #endregion

        #region 修改标签信息
        /// <summary>
        /// 修改标签信息
        /// </summary>
        /// <param name="el">标签信息属性类对象</param>
        /// <returns>数字。大于0表示添加成功</returns>
        public int Update(XYECOM.Model.LabelInfo info)
        {
            SqlParameter[] parm = new SqlParameter[]{
                new SqlParameter("@L_ID",info.Id),
                new SqlParameter("@L_Name",info.LabelName),
                new SqlParameter("@L_CName",info.LabelCName),
                new SqlParameter("@LT_ID",info.LabelTypeId),
                new SqlParameter("@L_TableName",info.LabelTableName),
                new SqlParameter("@L_Content",info.LabelContent),
                new SqlParameter("@L_StyleHead",info.LabelStyleHead),
                new SqlParameter("@L_StyleContent",info.LabelStyleContent),
                new SqlParameter("@L_StyleFooter",info.LabelStyleFooter),
                new SqlParameter("@membership",info.LabelRangeData),
                new SqlParameter("@labelDescription",info.LabelDescription)
            };

            int err = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[XYP_UpdateLabel]", parm);

            UpdateCache();

            return err;
        }
        #endregion

        #region 删除标签信息
        /// <summary>
        /// 删除标签信息
        /// </summary>
        /// <param name="L_ID">标签编号</param>
        /// <returns>数字。大于0表示删除成功</returns>
        public int Delete(long labelId)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where L_ID="+labelId.ToString()),
                new SqlParameter("@strTableName","b_Label")
            };

            int result = XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);

            UpdateCache();

            return result;
        }

        /// <summary>
        /// 删除多个标签信息
        /// </summary>
        /// <param name="labelIds">标签Id集，逗号隔开</param>
        /// <returns>受影响行数</returns>
        public int Delete(string labelIds)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where L_ID in ( "+labelIds + " )"),
                new SqlParameter("@strTableName","b_Label")
            };

            int result = XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);

            UpdateCache();

            return result;
        }
        #endregion

        #region 获取标签信息

        /// <summary>
        /// 获取指定标签名称的标签对象
        /// </summary>
        /// <param name="labelName">标签名称</param>
        /// <returns>标签对象</returns>
        public XYECOM.Model.LabelInfo GetItem(string labelName)
        {
            XYECOM.Model.LabelInfo info = null;

            Object obj = GetCache();

            if (obj != null)
            {
                DataTable table = (DataTable)obj;

                DataRow[] rows = table.Select("l_Name ='" + labelName + "'");

                if (rows != null && rows.Length > 0)
                {
                    info = new XYECOM.Model.LabelInfo();

                    info.LabelName = rows[0]["L_Name"].ToString();
                    info.LabelCName = rows[0]["L_CName"].ToString();
                    info.Id = Convert.ToInt64(rows[0]["L_ID"].ToString());
                    info.LabelTableName = rows[0]["L_TableName"].ToString();
                    info.LabelTypeId = Convert.ToInt32(rows[0]["LT_ID"].ToString());
                    info.LabelContent = rows[0]["L_Content"].ToString();
                    info.LabelStyleHead = rows[0]["L_StyleHead"].ToString();
                    info.LabelStyleContent = rows[0]["L_StyleContent"].ToString();
                    info.LabelStyleFooter = rows[0]["L_StyleFooter"].ToString();

                    info.LabelDescription = rows[0]["LabelDescription"].ToString();
                    string labelData = rows[0]["Membership"].ToString().Trim(); ;
                    if (!string.IsNullOrEmpty(labelData))
                    {
                        string[] ar = labelData.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                        if (ar.Length == 2)
                        {
                            info.LabelRange = (Model.LabelRange)Enum.Parse(typeof(Model.LabelRange), ar[0]);
                            info.GroupIdOrUserId = ar[1];
                        }
                    }
                }
            }

            return info;
        }

        /// <summary>
        /// 获取指定标签Id的标签对象
        /// </summary>
        /// <param name="labelId">标签Id</param>
        /// <returns>标签对象</returns>
        public XYECOM.Model.LabelInfo GetItem(long labelId)
        {
            XYECOM.Model.LabelInfo info = null;

            Object obj = GetCache();

            if (obj != null)
            {
                DataTable table = (DataTable)obj;

                DataRow[] rows = table.Select("l_ID =" + labelId + "");

                if (rows != null && rows.Length > 0)
                {
                    info = new XYECOM.Model.LabelInfo();

                    info.LabelName = rows[0]["L_Name"].ToString();
                    info.LabelCName = rows[0]["L_CName"].ToString();
                    info.Id = Convert.ToInt64(rows[0]["L_ID"].ToString());
                    info.LabelTableName = rows[0]["L_TableName"].ToString();
                    info.LabelTypeId = Convert.ToInt32(rows[0]["LT_ID"].ToString());
                    info.LabelContent = rows[0]["L_Content"].ToString();
                    info.LabelStyleHead = rows[0]["L_StyleHead"].ToString();
                    info.LabelStyleContent = rows[0]["L_StyleContent"].ToString();
                    info.LabelStyleFooter = rows[0]["L_StyleFooter"].ToString();
                    info.LabelDescription = rows[0]["LabelDescription"].ToString();
                    string labelData = rows[0]["Membership"].ToString().Trim(); ;
                    if (!string.IsNullOrEmpty(labelData))
                    {
                        string[] ar = labelData.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                        if (ar.Length == 2)
                        {
                            info.LabelRange = (Model.LabelRange)Enum.Parse(typeof(Model.LabelRange), ar[0]);
                            info.GroupIdOrUserId = ar[1];
                        }
                    }
                }
            }

            return info;
        }
        #endregion

        public override string SQL_Get_All
        {
            get { return "select * from b_label"; }
        }
    }
}
