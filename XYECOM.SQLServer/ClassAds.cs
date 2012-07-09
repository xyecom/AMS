using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace XYECOM.SQLServer
{
    public   class ClassAds
    {
       /// <summary>
       /// 添加（购买）分类黄金广告位
       /// </summary>
       /// <param name="info"></param>
       /// <returns></returns>
       public int Insert(XYECOM.Model.ClassAdsInfo info,out int adsId)
       {
           SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@AdsId",SqlDbType.Int),
                new SqlParameter("@ClassId",info.ClassId),
                new SqlParameter("@UserId",info.UserId),
                new SqlParameter("@ImageUrl",info.ImageUrl),
                new SqlParameter("@Link",info.Link),
                new SqlParameter("@Desc",info.Desc),
                new SqlParameter("@Rank",info.Rank),
                new SqlParameter("@InputTime",info.InputTime),
                new SqlParameter("@TimeLength",info.TimeLength),
                new SqlParameter("@Property",info.Property),
                new SqlParameter("@IsPay",info.IsPay),
                new SqlParameter("@AuditingState",info.IntState)
            };

           param[0].Direction = ParameterDirection.Output;

           int rowAffected = XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertClassAds", param);

           if (rowAffected >= 0)
           {
               if (param[0].Value != null && param[0].Value.ToString() != "")
                   adsId = (int)param[0].Value;
               else
                   adsId = 0;
           }
           else
           {
               adsId = -1;
           }

           return rowAffected;
       }
       /// <summary>
       ///修改分类黄金广告位
       /// </summary>
       /// <param name="info"></param>
       /// <returns></returns>
       public int Update(XYECOM.Model.ClassAdsInfo info)
       {
           SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@AdsId",info.AdsId),
                new SqlParameter("@ClassId",info.ClassId),
                new SqlParameter("@UserId",info.UserId),
                new SqlParameter("@ImageUrl",info.ImageUrl),
                new SqlParameter("@Link",info.Link),
                new SqlParameter("@Desc",info.Desc),
                new SqlParameter("@Rank",info.Rank),
                new SqlParameter("@InputTime",info.InputTime),
                new SqlParameter("@BeginTime",info.BeginTime),
                new SqlParameter("@EndTime",info.EndTime),
                new SqlParameter("@TimeLength",info.TimeLength),
                new SqlParameter("@Property",info.Property),
                new SqlParameter("@IsPay",info.IsPay),
                new SqlParameter("@AuditingState",info.IntState)
            };

           return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateClassAds", param);
       }   
                             
       public XYECOM.Model.ClassAdsInfo GetItem(int adsid)
       {
           SqlParameter[] parm = new SqlParameter[] 
            {
                new SqlParameter("@strWhere"," Where AdsId="+adsid.ToString()),
                new SqlParameter("@strTableName","XY_ClassAds"),
                new SqlParameter("@strOrder","")
            };

            DataTable dt= XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "XYP_SelectByWhere", parm);
            XYECOM.Model.ClassAdsInfo info =new XYECOM.Model.ClassAdsInfo();
             
            info = new XYECOM.Model.ClassAdsInfo();
            info.AdsId =Core.MyConvert.GetInt32(dt.Rows[0]["AdsId"].ToString());
            info.ClassId = Core.MyConvert.GetInt32(dt.Rows[0]["ClassId"].ToString());
            info.UserId = Core.MyConvert.GetInt64(dt.Rows[0]["UserId"].ToString());
            info.ImageUrl = dt.Rows[0]["ImageUrl"].ToString();
            info.Link = dt.Rows[0]["Link"].ToString();
            info.Desc = dt.Rows[0]["Desc"].ToString();
            info.Rank = Core.MyConvert.GetInt16(dt.Rows[0]["Rank"].ToString());
            info.InputTime = Core.MyConvert.GetDateTime(dt.Rows[0]["InputTime"].ToString());
            info.BeginTime = null;

            if (!dt.Rows[0]["beginTime"].ToString().Equals(""))
            {
                info.BeginTime = Core.MyConvert.GetDateTime(dt.Rows[0]["BeginTime"].ToString());
            }

            info.EndTime = null;

            if (!dt.Rows[0]["EndTime"].ToString().Equals(""))
            {
                info.EndTime = Core.MyConvert.GetDateTime(dt.Rows[0]["EndTime"].ToString());
            }
            
            info.TimeLength =Core.MyConvert.GetInt16(dt.Rows[0]["TimeLength"].ToString());
            info.Property = dt.Rows[0]["Property"].ToString();
            info.IsPay = Core.MyConvert.GetBoolean(dt.Rows[0]["IsPay"].ToString());
            info.IntState = Core.MyConvert.GetInt16(dt.Rows[0]["AuditingState"].ToString());
        
            return info;          
       }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="infoid"></param>
       /// <returns></returns>
       public int Delete(string infoid)
       {
           SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strwhere","where AdsId in ("+infoid+")"),
                new SqlParameter("@strTableName","XY_ClassAds")
            };

           return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
       }

       #region 读取分类广告
       /// <summary>
       /// 读取分类广告
       /// </summary>
       /// <param name="classid">分类id</param>
       /// <param name="clsAdsType">分类id</param>
       /// <param name="state">分类id</param>
       /// <returns></returns>
       public DataTable GetItems(int classid,Model.ClassAdsState clsAdsState,Model.AuditingState state)
       {
           string where = "where ClassId=" + classid + " and IsPay='1'";

           if (clsAdsState == XYECOM.Model.ClassAdsState.HasExpired)
               where += " and EndTime<=getdate()";

           if (clsAdsState == XYECOM.Model.ClassAdsState.OnView)
               where += " and BeginTime <=getdate() and EndTime>getdate()";

           if (clsAdsState == XYECOM.Model.ClassAdsState.NotStarted)
               where += " and BeginTime>getdate()";

           if (clsAdsState == XYECOM.Model.ClassAdsState.Valid)
               where += " and ((BeginTime <=getdate() and EndTime>getdate()) Or (BeginTime>getdate()))";

           if (state == XYECOM.Model.AuditingState.Null) where += " and AuditingState=-1";

           if (state == XYECOM.Model.AuditingState.NoPass) where += " and AuditingState=0";

           if (state == XYECOM.Model.AuditingState.Passed) where += " and AuditingState=1";

           SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter ("@strWhere",where),
                new SqlParameter ("@strTableName","XY_ClassAds"),
                new SqlParameter ("@strOrder","")
            };

           return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "XYP_SelectByWhere", parm);
       }
        /// <summary>
        /// 根据类别id得到相应的类别广告信息
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        public DataTable GetItems(int classid)
        {
            string where = "  where ClassId=" + classid + " ";
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@strWhere",where),
                new SqlParameter("@strTableName","XY_ClassAds"),
                new SqlParameter("@strOrder","")
            };
            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "XYP_SelectByWhere", parm);
        }

        /// <summary>
        /// 获取所有设置为在所有页面显示的广告
        /// </summary>
        /// <returns></returns>
        public DataTable GetTopItems(long classId)
        {
            string where = "where ClassId<>" + classId + " and IsPay='1' and property='top'";

            where += " and BeginTime <=getdate() and EndTime>getdate()";

            where += " and AuditingState=1";

            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter ("@strWhere",where),
                new SqlParameter ("@strTableName","XY_ClassAds"),
                new SqlParameter ("@strOrder","order by newid()")
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "XYP_SelectByWhere", parm);   
        }


        /// <summary>
        /// 获取广告，前台页面专用（随机排序,通过审核，展示中）
        /// </summary>
        /// <param name="classid"></param>
        /// <param name="clsAdsState"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public DataTable GetItemsForFrontPage(long classid)
        {
            string where = "where ClassId=" + classid + " and IsPay='1'";

            where += " and BeginTime <=getdate() and EndTime>getdate()";

            where += " and AuditingState=1";

            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter ("@strWhere",where),
                new SqlParameter ("@strTableName","XY_ClassAds"),
                new SqlParameter ("@strOrder","order by newid()")
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "XYP_SelectByWhere", parm);
        }
       #endregion
    }
}
