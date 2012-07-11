using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using XYECOM.Core.Data;
using XYECOM.Core;
using XYECOM.Model.AMS;

namespace XYECOM.SQLServer.AMS
{
    /// <summary>
    /// 抵债数据访问层
    /// </summary>
    public class ForeclosedAccess
    {
        /// <summary>
        /// 新增抵债信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int InsertForeclosed(ForeclosedInfo info)
        {
            string sql = @"insert into ForeclosedInfo (Title,IdentityNumber,Address,AreaId,EndDate,CreateDate,State,
                                    UserId,DepartmentId,LinePrice,description,ForeColseTypeName,HighPrice)
                                    values (@Title,@Identitynumber,@Address,@AreaId,@EndDate,@CreateDate,@State,@UserId,
                                    @DepartmentId,@LinePrice,@Description,@ForeColseTypeName,0)";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Title",info.Title),
                new SqlParameter("@Identitynumber",info.IdentityNumber),
                new SqlParameter("@Address",info.Address),
                new SqlParameter("@AreaId",info.AreaId),
                new SqlParameter("@EndDate",info.EndDate),
                new SqlParameter("@CreateDate",info.CreateDate),
                new SqlParameter("@State",info.State),
                new SqlParameter("@UserId",info.UserId),
                new SqlParameter("@DepartmentId",info.DepartmentId),
                new SqlParameter("@LinePrice",info.LinePrice),
                new SqlParameter("@Description",info.Description),
                new SqlParameter("@ForeColseTypeName",info.ForeColseTypeName)
            };
            int rowAffected = SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
            return rowAffected;
        }

        /// <summary>
        /// 修改抵债信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int UpdateForeclosedByID(ForeclosedInfo info)
        {
            string sql = @"UPDATE ForeclosedInfo SET Title =                                                                                                              @Title,Address=@Address,AreaId=@AreaId,EndDate=@EndDate,LinePrice=@LinePrice,Description=@Description,
                            ForeColseTypeName=@ForeColseTypeName WHERE ForeclosedId=@Id";

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Title",info.Title),
                new SqlParameter("@Address",info.Address),
                new SqlParameter("@AreaId",info.AreaId),
                new SqlParameter("@EndDate",info.EndDate),
                new SqlParameter("@LinePrice",info.LinePrice),
                new SqlParameter("@Description",info.Description),
                new SqlParameter("@ForeColseTypeName",info.ForeColseTypeName),
                new SqlParameter("@Id",info.ForeclosedId)
            };
            int rowAffected = SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
            return rowAffected;
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int Delete(int ID)
        {
            string sql = "DELETE ForeclosedInfo WHERE ForeclosedId=@Id";
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@Id",ID),
            };
            int rowAffected = SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
            return rowAffected;
        }

        public ForeclosedInfo GetForeclosedInfoById(int id)
        {
            string sql = "SELECT * FROM dbo.ForeclosedInfo WHERE ForeclosedId = @Id";
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@Id",id),
            };
            ForeclosedInfo info = null;

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                if (reader.Read())
                {
                    info = new ForeclosedInfo();
                    
                    info.ForeclosedId = id;
                    info.Title = reader["Title"].ToString();
                    info.IdentityNumber = reader["IdentityNumber"].ToString();
                    info.HighPrice = Core.MyConvert.GetDecimal(reader["HighPrice"].ToString());
                    info.Address = reader["Address"].ToString();
                    info.EndDate = Core.MyConvert.GetDateTime(reader["EndDate"].ToString());
                    info.CreateDate = Core.MyConvert.GetDateTime(reader["CreateDate"].ToString());
                    info.State = Core.MyConvert.GetInt32(reader["State"].ToString());
                    info.PassDate = Core.MyConvert.GetDateTime(reader["PassDate"].ToString());
                    info.UserId = Core.MyConvert.GetInt32(reader["UserId"].ToString());
                    //info.DepartmentId = reader["SD_HTMLPage"].ToString();
                    //info.ClickNum = Core.MyConvert.GetInt64(reader["SD_ClickNum"].ToString());
                    //info.IsCommend = reader["SD_Vouch"].ToString() == "1";
                    //info.MessageNum = Core.MyConvert.GetInt32(reader["SD_MessageNum"].ToString());
                    //info.NotReadingNum = Core.MyConvert.GetInt32(reader["SD_NoMessgeNum"].ToString());
                    //info.UseFulDate = Core.MyConvert.GetInt32(reader["SD_Date"].ToString());
                    //info.InfoType = Core.MyConvert.GetInt32(reader["SD_Flag"].ToString());
                    //info.IsPause = Core.MyConvert.GetBoolean(reader["SD_IsSupply"].ToString());
                    //info.Unit = reader["SD_Unit"].ToString();
                    //info.LeastNum = Core.MyConvert.GetInt32(reader["SD_SmallNum"].ToString());
                    //info.CountNum = Core.MyConvert.GetInt32(reader["SD_CountNum"].ToString());
                    //info.IsPayMent = Core.MyConvert.GetBoolean(reader["SD_IsPayMent"].ToString());
                    //info.Isshop = Core.MyConvert.GetBoolean(reader["isshop"].ToString());
                    //info.CompanyProductTypeId = Core.MyConvert.GetInt32(reader["companyproducttypeid"].ToString());

                    ////基于山东亿家商城新增的属性 王振
                    //info.BrandId = Core.MyConvert.GetInt32(reader["BrandId"].ToString());
                    //info.MeasuringUnitId = Core.MyConvert.GetInt32(reader["MeasuringUnitId"].ToString());
                    //info.DepotId = Core.MyConvert.GetInt32(reader["DepotId"].ToString());
                    //info.Stocks = Core.MyConvert.GetInt32(reader["Stocks"].ToString());
                    //info.SalesVolume = Core.MyConvert.GetInt32(reader["SalesVolume"].ToString());
                    //info.IsDeleted = Core.MyConvert.GetBoolean(reader["IsDeleted"].ToString());
                    //info.Tags = reader["Tags"].ToString();
                    //info.Summary = reader["Summary"].ToString();
                    //info.IsPayBail = Core.MyConvert.GetBoolean(reader["IsPayBail"].ToString());
                    //info.FreightType = Core.MyConvert.GetInt32(reader["FreightType"].ToString());
                    //info.MarketPrice = Core.MyConvert.GetDecimal(reader["MarketPrice"].ToString());
                    //info.ProductType = new ProductType().GetProTypeById(XYECOM.Core.MyConvert.GetInt32(info.SortID.ToString()));
                    //info.LockCount = Core.MyConvert.GetInt32(reader["LockCount"].ToString());
                    //info.IsContractVouch = Core.MyConvert.GetBoolean(reader["IsContractVouch"].ToString());
                    //info.MarginRefund = Core.MyConvert.GetDecimal(reader["MarginRefund"].ToString());

                    //info.AttachInfo = new Attachment().GetItems(info.InfoID, "i_supply");
                    //info.PriceRange = new XYECOM.SQLServer.PriceRangeAccess().GetPriceRangeByProductId(id);
                    //if (info.BrandId > 0)
                    //{
                    //    info.BrandInfo = new XYECOM.SQLServer.BrandAccess().GetItem(info.BrandId);
                    //}
                    //if (info.DepotId > 0)
                    //{
                    //    info.DepotInfo = new XYECOM.SQLServer.DepotAccess().GetItem(info.DepotId);
                    //}

                    //if (info.FreightType == (int)Model.FreightType.SelfDelivery || info.FreightType == (int)Model.FreightType.BuyerPayAndSelfDelivery)
                    //{
                    //    info.SupportLogitsticsTypes = new XYECOM.SQLServer.ProductLogisticsEnterpriseAccess().GetItemsByProductId(info.InfoID);
                    //}

                    //if (info.ProductType != null)
                    //{
                    //    info.FieldValues = new FieldValueAccess().GetItems(info);
                    //}
                }
            }
            return info;
        }
    }
}
