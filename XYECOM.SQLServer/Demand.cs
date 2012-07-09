using System;
using System.Collections.Generic;
using System.Text;
using XYECOM.Core.Data;
using System.Data;
using System.Data.SqlClient;
using XYECOM.Core;


namespace XYECOM.SQLServer
{
    /// <summary>
    /// 投融资信息数据处理类
    /// </summary>
    public class Demand
    {
        /// <summary>
        /// 插入加工信息
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <param name="esid">返回的信息id</param>
        /// <returns>受影响的行数</returns>
        public int Insert(XYECOM.Model.DemandInfo info, out int esid)
        {
            SqlParameter[] parame = new SqlParameter[]
			{
                new SqlParameter("@SD_ID",SqlDbType.Int),
				new SqlParameter("@U_ID",info.UserID),
				new SqlParameter("@TypeName",info.TypeName),
				new SqlParameter("@SD_Title",info.Title),
				new SqlParameter("@SD_Description",info.InfoContent),
				new SqlParameter("@SD_PublishDate",info.PublishTime),
				new SqlParameter("@SD_IsSupply",info.IsPause),
				new SqlParameter("@SD_Date",info.UseFulDate),
				new SqlParameter("@SD_Flag",info.InfoType),
				new SqlParameter("@SD_EndDate",info.EndTime),
				new SqlParameter("@SD_HTMLPage",info.HtmlPage),
				new SqlParameter("@SD_Vouch",info.IsCommend),
				new SqlParameter("@SD_ClickNum",info.ClickNum),
				new SqlParameter("@SD_MessageNum",info.MessageNum),
				new SqlParameter("@SD_NoMessgeNum",info.NotReadingNum),
				new SqlParameter("@AuditingState",info.AuditingState),
				new SqlParameter("@SD_Price",info.Price),
				new SqlParameter("@Trade",info.Trade),
				new SqlParameter("@Area",info.Area),
				new SqlParameter("@WebSite",info.WebSite),
				new SqlParameter("@Summary",info.Summary),
				new SqlParameter("@TradeId",info.TradeId),
				new SqlParameter("@TypeId",info.TypeId),
				new SqlParameter("@AreaId",info.AreaId)	
			};

            string sql = "INSERT INTO i_Demand (";
            sql += "U_ID,";
            sql += "TypeName,";
            sql += "SD_Title,";
            sql += "SD_Description,";
            sql += "SD_PublishDate,";
            sql += "SD_IsSupply,";
            sql += "SD_Date,";
            sql += "SD_Flag,";
            sql += "SD_EndDate,";
            sql += "SD_HTMLPage,";
            sql += "SD_Vouch,";
            sql += "SD_ClickNum,";
            sql += "SD_MessageNum,";
            sql += "SD_NoMessgeNum,";
            sql += "AuditingState,";
            sql += "SD_Price,";
            sql += "Trade,";
            sql += "Area,";
            sql += "WebSite,";
            sql += "Summary,";
            sql += "TradeId,";
            sql += "TypeId,";
            sql += "AreaId) values (";
            sql += "@U_ID,";
            sql += "@TypeName,";
            sql += "@SD_Title,";
            sql += "@SD_Description,";
            sql += "@SD_PublishDate,";
            sql += "@SD_IsSupply,";
            sql += "@SD_Date,";
            sql += "@SD_Flag,";
            sql += "@SD_EndDate,";
            sql += "@SD_HTMLPage,";
            sql += "@SD_Vouch,";
            sql += "@SD_ClickNum,";
            sql += "@SD_MessageNum,";
            sql += "@SD_NoMessgeNum,";
            sql += "@AuditingState,";
            sql += "@SD_Price,";
            sql += "@Trade,";
            sql += "@Area,";
            sql += "@WebSite,";
            sql += "@Summary,";
            sql += "@TradeId,";
            sql += "@TypeId,";
            sql += "@AreaId);select @SD_ID = @@identity";
            parame[0].Direction = ParameterDirection.Output;

            int rowAffected = SqlHelper.ExecuteNonQuery(CommandType.Text, sql, parame);

            if (rowAffected >= 0)
            {
                if (parame[0].Value != null && parame[0].Value.ToString() != "")
                    esid = (int)parame[0].Value;
                else
                    esid = 0;
            }
            else
            {
                esid = -1;
            }

            return rowAffected;
        }

        /// <summary>
        /// 更新加工信息
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>受影响的行数</returns>
        public int Update(XYECOM.Model.DemandInfo info)
        {
            SqlParameter[] parame = new SqlParameter[]
			{
				new SqlParameter("@SD_ID",info.InfoID),
				new SqlParameter("@TypeName",info.TypeName),
				new SqlParameter("@SD_Title",info.Title),
				new SqlParameter("@SD_Description",info.InfoContent),
				new SqlParameter("@SD_PublishDate",info.PublishTime),
				new SqlParameter("@SD_IsSupply",info.IsPause),
				new SqlParameter("@SD_Date",info.UseFulDate),
				new SqlParameter("@SD_Flag",info.InfoType),
				new SqlParameter("@SD_EndDate",info.EndTime),
				new SqlParameter("@SD_HTMLPage",info.HtmlPage),
				new SqlParameter("@SD_Vouch",info.IsCommend),
				new SqlParameter("@SD_ClickNum",info.ClickNum),
				new SqlParameter("@SD_MessageNum",info.MessageNum),
				new SqlParameter("@SD_NoMessgeNum",info.NotReadingNum),
				new SqlParameter("@AuditingState",info.AuditingState),
				new SqlParameter("@SD_Price",info.Price),
				new SqlParameter("@Trade",info.Trade),
				new SqlParameter("@Area",info.Area),
				new SqlParameter("@WebSite",info.WebSite),
				new SqlParameter("@Summary",info.Summary),
				new SqlParameter("@TradeId",info.TradeId),
				new SqlParameter("@TypeId",info.TypeId),
				new SqlParameter("@AreaId",info.AreaId)	
			};

            string sql = "update i_Demand set ";
            sql += "TypeName=@TypeName,";
            sql += "SD_Title=@SD_Title,";
            sql += "SD_Description=@SD_Description,";
            sql += "SD_PublishDate=@SD_PublishDate,";
            sql += "SD_IsSupply=@SD_IsSupply,";
            sql += "SD_Date=@SD_Date,";
            sql += "SD_Flag=@SD_Flag,";
            sql += "SD_EndDate=@SD_EndDate,";
            sql += "SD_HTMLPage=@SD_HTMLPage,";
            sql += "SD_Vouch=@SD_Vouch,";
            sql += "SD_ClickNum=@SD_ClickNum,";
            sql += "SD_MessageNum=@SD_MessageNum,";
            sql += "SD_NoMessgeNum=@SD_NoMessgeNum,";
            sql += "AuditingState=@AuditingState,";
            sql += "SD_Price=@SD_Price,";
            sql += "Trade=@Trade,";
            sql += "Area=@Area,";
            sql += "WebSite=@WebSite,";
            sql += "Summary=@Summary,";
            sql += "TradeId=@TradeId,";
            sql += "TypeId=@TypeId,";
            sql += "AreaId=@AreaId";
            sql += " where SD_ID = @SD_ID";
            return SqlHelper.ExecuteNonQuery(CommandType.Text, sql, parame);
        }

        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="infoId">记录编号</param>
        /// <returns>数据对象</returns>
        public XYECOM.Model.DemandInfo GetItem(int infoId)
        {
            string sql = "select * from i_Demand where sd_id = " + infoId + "";

            XYECOM.Model.DemandInfo info = null;

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(sql))
            {
                if (reader.Read())
                {
                    info = new XYECOM.Model.DemandInfo();

                    if (reader["AuditingState"].ToString() != "")
                    {
                        if (reader["AuditingState"].ToString().Equals("1"))
                            info.AuditingState = XYECOM.Model.AuditingState.Passed;
                        else
                            info.AuditingState = XYECOM.Model.AuditingState.NoPass;
                    }
                    else
                    {
                        info.AuditingState = XYECOM.Model.AuditingState.Null;
                    }

                    info.InfoID = infoId;
                    info.Title = reader["SD_Title"].ToString();
                    info.Price = MyConvert.GetDecimal(reader["SD_Price"].ToString());
                    info.PublishTime = Core.MyConvert.GetDateTime(reader["SD_PublishDate"].ToString());
                    info.EndTime = Core.MyConvert.GetDateTime(reader["SD_EndDate"].ToString());
                    info.UseFulDate = Core.MyConvert.GetInt32(reader["SD_Date"].ToString());
                    info.InfoType = Core.MyConvert.GetInt32(reader["SD_flag"].ToString());
                    info.MessageNum = Core.MyConvert.GetInt32(reader["SD_MessageNum"].ToString());
                    info.NotReadingNum = Core.MyConvert.GetInt32(reader["SD_NoMessgeNum"].ToString());
                    info.InfoContent = reader["SD_Description"].ToString();
                    info.UserID = Core.MyConvert.GetInt64(reader["U_ID"].ToString());
                    info.TypeName = reader["TypeName"].ToString();
                    info.HtmlPage = reader["SD_HTMLPage"].ToString();
                    info.WebSite = reader["website"].ToString();
                    info.Summary = reader["summary"].ToString();
                    info.ClickNum = Core.MyConvert.GetInt64(reader["SD_ClickNum"].ToString());
                    info.IsCommend = reader["SD_Vouch"].ToString() == "1";
                    info.Area = reader["Area"].ToString();
                    info.Trade = reader["Trade"].ToString();
                    info.TypeId = Core.MyConvert.GetInt32(reader["TypeId"].ToString());
                    info.AreaId = Core.MyConvert.GetInt32(reader["AreaId"].ToString());
                    info.TradeId = Core.MyConvert.GetInt32(reader["TradeId"].ToString());
                    info.IsPause = Core.MyConvert.GetBoolean(reader["SD_IsSupply"].ToString());
                }
            }
            return info;
        }

        /// <summary>
        /// 删除操作(删除单条)
        /// </summary>
        /// <param name="infoId">信息主键Id</param>
        /// <returns>受影响的行数</returns>
        public int Delete(int infoId)
        {
            SqlParameter[] parame = new SqlParameter[]
			{
				new SqlParameter("@SD_ID",infoId)
			};
            string sql = "delete i_Demand where SD_ID = @SD_ID";
            return SqlHelper.ExecuteNonQuery(CommandType.Text, sql, parame);
        }


        /// <summary>
        /// 删除操作(删除多条)
        /// </summary>
        /// <param name="infoIds">以逗号隔开的主键Id集合</param>
        /// <returns>受影响的行数</returns>
        public int DeleteByIds(string infoIds)
        {
            string sql = "delete i_Demand where SD_ID in (" + infoIds + ")";
            return SqlHelper.ExecuteNonQuery(CommandType.Text, sql, null);
        }
        /// <summary>
        /// 修改推荐信息
        /// </summary>
        /// <param name="es">实体类</param>
        /// <returns>受影响的行数</returns>
        public int UpdateSD_Vouch(XYECOM.Model.DemandInfo info)
        {
            SqlParameter[] param = new SqlParameter[] 
            {
                new SqlParameter("@SD_Vouch",SqlDbType.Bit),
                new SqlParameter("@SD_ID",SqlDbType.Int)
            };

            param[0].Value = info.IsCommend;
            param[1].Value = info.InfoID;

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateDemandVouch", param);
        }
        /// <summary>
        /// 修改暂停信息
        /// </summary>
        /// <param name="SD_ID">编号</param>
        /// <returns></returns>
        public int UpdateSD_Pause(string SD_ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            {
                new SqlParameter("@strwhere","where SD_ID in ("+SD_ID+")") 
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateDemandPause", param);
        }

        /// <summary>
        /// 批量移动
        /// </summary>
        /// <param name="strwhere">条件</param>
        /// <param name="content">执行的主体</param>
        /// <returns>受影响行数</returns>
        public int MoveMachining(String strwhere, String content)
        {
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@strwhere",strwhere),
                new SqlParameter("@tablename","I_demand"),
                new SqlParameter("@content",content)
            };
            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "usp_PublicUpdate", param);
        }

        /// <summary>
        /// 修改投融资信息的审核状态
        /// </summary>
        /// <param name="id">投融资信息ID</param>
        /// <param name="state">要审核的状态</param>
        /// <returns>受影响的行数</returns>
        public int UpdateStateById(int id, int state)
        {
            string sql = "update i_demand set AuditingState = "+state+" where sd_id = "+id+"";
            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 修改投融资信息的推荐状态
        /// </summary>
        /// <param name="id">投融资信息</param>
        /// <param name="vouch">要推荐的状态</param>
        /// <returns>受影响的行数</returns>
        public int UpdateVouchById(int id)
        {
            string sql = "update i_demand set sd_vouch = case sd_vouch when 0 then 1 else 0 end where sd_id = " + id;
            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(sql);
        }

        public int UpdateVouchById(int id,int vouch)
        {
            string sql = "update i_demand set sd_vouch ="+vouch+" where sd_id = " + id;
            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(sql);
        }
    }
}
