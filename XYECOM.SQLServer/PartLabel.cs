using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using XYECOM.Core.Data;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// 专栏标签DAL
    /// </summary>
    public class PartLabel:DataCache
    {
        /// <summary>
        /// 插入或新增专题标签
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int Update(Model.PartLabelInfo info)
        {
            SqlParameter[] param = new SqlParameter[] 
            {                                  
                new SqlParameter("@PartName",info.PartName),
                new SqlParameter("@LabelName",info.LabelName),
                new SqlParameter("@Format",info.Format),
                new SqlParameter("@Body",info.Body),
                new SqlParameter("@InfoIds",info.InfoIds),
                new SqlParameter("@BeginTime",info.BeginTime),
                new SqlParameter("@EndTime",info.EndTime),
                new SqlParameter("@UserId",info.UserId)
            };

            int i= SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdatePartLabel", param);

            if (i > 0) UpdateCache();

            return i;
        }

        /// <summary>
        /// 删除专题标签
        /// </summary>
        /// <param name="partId"></param>
        /// <returns></returns>
        public int Delete(int partId)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where PartId="+partId),
                new SqlParameter("@strTableName","XY_PartLabel")
            };

            int i= XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);

            if (i > 0) UpdateCache();

            return i;
        }

        /// <summary>
        /// 获取专题标签
        /// </summary>
        /// <param name="labelName">标签名称</param>
        /// <returns></returns>
        public Model.PartLabelInfo GetItem(string labelName)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," Where LabelName='" + labelName+ "'"),
                new SqlParameter("@strTableName","XY_PartLabel"),
                new SqlParameter("@strOrder","")
            };

            XYECOM.Model.PartLabelInfo info = null;

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (reader.Read())
                {
                    info = new XYECOM.Model.PartLabelInfo();

                    info.PartId = XYECOM.Core.MyConvert.GetInt32(reader["PartId"].ToString());
                    info.PartName = reader["PartName"].ToString();
                    info.LabelName = reader["LabelName"].ToString();
                    info.Format = reader["format"].ToString();
                    info.Body = reader["Body"].ToString();
                    info.InfoIds = reader["InfoIds"].ToString();
                    info.BeginTime = Core.MyConvert.GetDateTime(reader["BeginTime"].ToString());
                    info.EndTime = Core.MyConvert.GetDateTime(reader["EndTime"].ToString());
                    info.UserId = XYECOM.Core.MyConvert.GetInt64(reader["UserId"].ToString());
                    info.IntState = XYECOM.Core.MyConvert.GetInt16(reader["AuditingState"].ToString());
                }
            }
            return info;
        }


        /// <summary>
        /// 获取专题标签
        /// </summary>
        /// <param name="partId">标签Id</param>
        /// <returns></returns>
        public Model.PartLabelInfo GetItem(int partId)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," Where partId=" + partId),
                new SqlParameter("@strTableName","XY_PartLabel"),
                new SqlParameter("@strOrder","")
            };
            XYECOM.Model.PartLabelInfo info = null;
            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (reader.Read())
                {
                    info = new XYECOM.Model.PartLabelInfo();

                    info.PartId = XYECOM.Core.MyConvert.GetInt32(reader["PartId"].ToString());
                    info.PartName = reader["PartName"].ToString();
                    info.LabelName = reader["LabelName"].ToString();
                    info.Format = reader["format"].ToString();
                    info.Body = reader["Body"].ToString();
                    info.InfoIds = reader["InfoIds"].ToString();
                    info.BeginTime = Core.MyConvert.GetDateTime(reader["BeginTime"].ToString());
                    info.EndTime = Core.MyConvert.GetDateTime(reader["EndTime"].ToString());
                    info.UserId = XYECOM.Core.MyConvert.GetInt64(reader["UserId"].ToString());
                    info.IntState = XYECOM.Core.MyConvert.GetInt16(reader["AuditingState"].ToString());
                }
            }
            return info;
        }

        /// <summary>
        /// 
        /// </summary>
        public override string SQL_Get_All
        {
            get { return "select * from xy_partLabel"; }
        }
    }
}
