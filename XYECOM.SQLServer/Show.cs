using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using XYECOM.Model;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// 展会信息数据处理类
    /// </summary>
    public class Show
    {
        /// <summary>
        /// 添加一条新的展会信息对象
        /// </summary>
        /// <param name="info">要添加的新的展会信息对象</param>
        /// <param name="infoId"></param>
        /// <returns>数字,大于或等于0表成功,否表失败</returns>
        public int Insert(ShowInfo info,out long infoId)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@id",SqlDbType.BigInt),
                new SqlParameter("@infotitle",info.Infotitle),
                new SqlParameter("@typeid",info.Typeid),
                new SqlParameter("@contents",info.Contents),
                new SqlParameter("@BeginTime",info.BeginTime),
                new SqlParameter("@EndTime",info.EndTime),
                new SqlParameter("@District",info.District),
                new SqlParameter("@Site",info.Site),
                new SqlParameter("@sponsor",info.Sponsor),
                new SqlParameter("@undertake",info.Undertake),
                new SqlParameter("@coorganizor",info.Coorganizor),
                new SqlParameter("@sustain",info.Sustain),
                new SqlParameter("@Sycle",info.Sycle),
                new SqlParameter("@Type",info.Type),
                new SqlParameter("@URL",info.URL),
                new SqlParameter("@Area",info.Area),
                new SqlParameter("@unitPrice",info.UnitPrice),
                new SqlParameter("@leastRation",info.LeastRation),
                new SqlParameter("@areaTotal",info.AreaTotal)
            };

            param[0].Direction = ParameterDirection.Output;

            int rowAffected = XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"XYP_InsertShowInfo", param);

            if (rowAffected >= 0)
            {
                if (param[0].Value != null && param[0].Value.ToString() != "")
                    infoId = (long)param[0].Value;
                else
                    infoId = 0;
            }
            else
            {
                infoId = -1;
            }

            return rowAffected;
        }

        /// <summary>
        /// 更改一条指定的展会信息对象
        /// </summary>
        /// <param name="shi">要修改的展会信息对象</param>
        /// <returns>数字,大于或等于0表成功,否则表失败</returns>
        public int Update(ShowInfo shi)
        {
            SqlParameter[] param = new SqlParameter[]
            {
               new SqlParameter ("@id",shi.Id),
                new SqlParameter("@infotitle",shi.Infotitle),
                new SqlParameter("@typeid",shi.Typeid),
                new SqlParameter("@contents",shi.Contents),
                new SqlParameter("@BeginTime",shi.BeginTime),
                new SqlParameter("@EndTime",shi.EndTime),
                new SqlParameter("@District",shi.District),
                new SqlParameter("@Site",shi.Site),
                new SqlParameter("@sponsor",shi.Sponsor),
                new SqlParameter("@undertake",shi.Undertake),
                new SqlParameter("@coorganizor",shi.Coorganizor),
                new SqlParameter("@sustain",shi.Sustain),
                new SqlParameter("@Sycle",shi.Sycle),
                new SqlParameter("@Type",shi.Type),
                new SqlParameter("@URL",shi.URL),
                new SqlParameter("@Area",shi.Area),
                new SqlParameter("@unitPrice",shi.UnitPrice),
                new SqlParameter("@leastRation",shi.LeastRation),
                new SqlParameter("@areaTotal",shi.AreaTotal),
                new SqlParameter("@IsCommend",shi.IsCommend),
                new SqlParameter("@htmlPage",shi.HtmlPage)
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"XYP_UpdateShowInfo", param);
        }

        /// <summary>
        /// 删除指定编号的展会信息对象集
        /// </summary>
        /// <param name="shiid">要删除的展会对象编号集</param>
        /// <returns>数字,大于或等于0表删除成功,否则表失败</returns>
        public int Delete(string shiid)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere"," where id in ("+shiid+")"),
                new SqlParameter("@strTableName","XY_ShowInfo")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }

        /// <summary>
        /// 获取满足指定条件的展会信息对象集
        /// </summary>
        /// <param name="strWhere">指定的where条件</param>
        /// <param name="Order">指定的order条件</param>
        /// <returns>满足指定条件的DataTable对象集</returns>
        public DataTable GetDataTable(string strWhere, string Order)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere",strWhere),
                new SqlParameter("@strTableName","XYV_ShowInfo"),
                new SqlParameter("@strOrder",Order)
            };

            return XYECOM.Core.Data.SqlHelper.GetDataTable("XYP_SelectByWhere", param);
        }

        /// <summary>
        /// 获取指定编号的展会信息对象
        /// </summary>
        /// <param name="infoId">指定编号的展会信息对象</param>
        /// <returns>该编号对应的展会信息对象</returns>
        public ShowInfo GetItem(Int64 infoId)
        {
            ShowInfo info = null;

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere"," where id ="+infoId.ToString()),
                new SqlParameter("@strTableName","XYV_ShowInfo"),
                new SqlParameter("@strOrder","")
            };

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader( CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (reader.Read())
                {
                    info = new ShowInfo();

                    info.Id = Core.MyConvert.GetInt32(reader["id"].ToString());
                    info.Infotitle = reader["infotitle"].ToString();
                    info.AddInfoTime = reader["addInfoTime"].ToString();
                    info.Contents = reader["contents"].ToString();
                    info.Typeid = Core.MyConvert.GetInt32(reader["typeid"].ToString());
                    info.HtmlPage = reader["htmlPage"].ToString();
                    info.IsCommend = reader["IsCommend"].ToString() == "1";

                    info.BeginTime = reader["BeginTime"].ToString();
                    info.EndTime = reader["EndTime"].ToString();
                    info.District = reader["District"].ToString();
                    info.Site = reader["Site"].ToString();
                    info.Sponsor = reader["Sponsor"].ToString();
                    info.Undertake = reader["undertake"].ToString();
                    info.Coorganizor = reader["coorganizor"].ToString();
                    info.Sustain = reader["sustain"].ToString();
                    info.Sycle = reader["Sycle"].ToString();
                    info.Type = reader["Type"].ToString();
                    info.URL = reader["URL"].ToString();
                    info.Area = reader["Area"].ToString();
                    info.UnitPrice = Core.MyConvert.GetInt32(reader["unitPrice"].ToString());
                    info.LeastRation = Core.MyConvert.GetInt32(reader["leastRation"].ToString());
                    info.AreaTotal = Core.MyConvert.GetInt32(reader["areaTotal"].ToString());

                    info.AttachInfo = new Attachment().GetItems(info.Id, "i_showinfo");
                    //设置附件信息
                    //this.SetAttachmentInfo(info, reader);
                }
            }

            return info;
        }

        /// <summary>
        /// 更改指定编号的展会信息的推荐状态
        /// </summary>
        /// <param name="shiid">指定的展会信息的编号</param>
        /// <param name="IsCommend">更改的推荐状态</param>
        /// <returns>数字,大于或等于0表成功,否则表失败</returns>
        public int SetIsCommend(Int64 shiid, bool IsCommend)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@id",shiid),
                new SqlParameter("@IsCommend",IsCommend)
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"XYP_UpdateShowInfoCommend", param);
        }

    }
}
