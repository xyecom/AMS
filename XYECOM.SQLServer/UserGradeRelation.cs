using System;
using System.Collections.Generic;
using System.Text;
using XYECOM.SQLServer;
using System.Data.SqlClient;
using XYECOM.Core.Data;
using System.Data;
using XYECOM.Core;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// 用户等级属性数据处理类
    /// </summary>
    public class UserGradeRelation
    {
        /// <summary>
        /// 插入用户等级属性数据
        /// </summary>
        /// <param name="er">数据对象</param>
        /// <returns>影响行数</returns>
        public int Insert(XYECOM.Model.UserGradeRelationInfo er)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter ("@U_ID",er.U_ID ),
                new SqlParameter ("@UGR_ID",er.UGR_ID ),
                new SqlParameter ("@U_BeginTime",er.U_BeginTime ),
                new SqlParameter ("@U_EndTime",er.U_EndTime ),
                new SqlParameter ("@U_Money",er.U_Money )     
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertGraderelation", parm);
        }

        #region 获取一条记录
        /// <summary>
        /// 获取等级数据
        /// </summary>
        /// <param name="U_ID">用户Id</param>
        /// <returns>数据对象</returns>
        public XYECOM.Model.UserGradeRelationInfo GetItem(long U_ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," Where U_ID=" + U_ID.ToString()),
                new SqlParameter("@strTableName","u_graderelation"),
                new SqlParameter("@strOrder","")
            };

            XYECOM.Model.UserGradeRelationInfo egrf = null;

            using (SqlDataReader dr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (dr.Read())
                {
                    egrf = new XYECOM.Model.UserGradeRelationInfo();

                    if (dr["U_ID"].ToString() != "")
                    {
                        egrf.U_ID = MyConvert.GetInt64(dr["U_ID"].ToString());
                    }
                    if (dr["U_BeginTime"].ToString() != "")
                    {
                        egrf.U_BeginTime = MyConvert.GetDateTime(dr["U_BeginTime"].ToString());                            
                    }
                    if (dr["UGR_ID"].ToString() != "")
                    {
                        egrf.UGR_ID = MyConvert.GetInt16(dr["UGR_ID"].ToString());
                    }
                    if (dr["U_EndTime"].ToString() != "")
                    {
                        egrf.U_EndTime = dr["U_EndTime"].ToString();
                    }
                    else
                    {
                        egrf.U_EndTime = "";
                    }
                    if (dr["U_Money"].ToString() != "")
                    {
                        egrf.U_Money = MyConvert.GetDecimal(dr["U_Money"].ToString());
                    }
                    else
                    {
                        egrf.U_Money = 0;
                    }
                    if (dr["UR_Flag"].ToString() != "")
                    {
                        if (dr["UR_Flag"].ToString().ToLower() == "true")
                            egrf.UR_Flag = true;
                        else
                            egrf.UR_Flag = false;
                    }
                    else
                        egrf.UR_Flag = false;
                }
            }
            return egrf;
        }
        #endregion

        #region 修改用户等级关系
        /// <summary>
        /// 更新等级属性数据
        /// </summary>
        /// <param name="info">等级属性数据对象</param>
        /// <returns></returns>
        public int UpdateGradeRelation(Model.UserGradeRelationInfo info)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter ("@U_ID",info.U_ID),
                new SqlParameter ("@UGR_ID",info.UGR_ID),
                new SqlParameter ("@U_BeginTime",info.U_BeginTime),
                new SqlParameter ("@U_EndTime",info.U_EndTime),
                new SqlParameter ("@U_Money",info.U_Money),
                new SqlParameter ("@UR_Flag",info.UR_Flag)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateGradeRelation", parm);
        }
        #endregion
    }

}
