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
    /// 供求信息数据处理类
    /// </summary>
    public class Supply
    {
        /// <summary>
        /// 添加供求信息
        /// </summary>
        /// <param name="info">实体类</param>
        /// /// <param name="infoid">输出参数</param>
        /// <returns>受影响的行数</returns>
        [Obsolete]
        public int Insert(XYECOM.Model.SupplyInfo info, out int infoid)
        {
            SqlParameter[] param = new SqlParameter[] 
            {                                                      
                new SqlParameter("@SD_ID",SqlDbType.Int),
                new SqlParameter("@U_ID",info.UserID),
                new SqlParameter("@PT_ID",info.SortID ),
                new SqlParameter("@SD_Title",info.Title),
                new SqlParameter("@SD_Description",info.InfoContent),
                new SqlParameter("@SD_Flag",info.InfoType ),
                new SqlParameter("@SD_Date",info.UseFulDate ),
                new SqlParameter("@P_ID",info.FieldID ),
                new SqlParameter("@SD_EndDate",info.EndTime ),
                new SqlParameter("@SD_Unit",info.Unit ),
                new SqlParameter("@SD_Price",info.Price ),
                new SqlParameter("@SD_SmallNum",info.LeastNum ),
                new SqlParameter("@SD_CountNum",info.CountNum ),
                new SqlParameter("@SD_IsPayMent",info.IsPayMent ),
                new SqlParameter("@companyproducttypeid",info.CompanyProductTypeId)
            };

            param[0].Direction = ParameterDirection.Output;

            int rowAffected = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertSupply", param);

            if (rowAffected >= 0)
            {
                if (param[0].Value != null && param[0].Value.ToString() != "")
                    infoid = (int)param[0].Value;
                else
                    infoid = 0;
            }
            else
            {
                infoid = -1;
            }

            return rowAffected;
        }

        /// <summary>
        /// 修改供应信息
        /// </summary>
        /// <param name="ea">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Update(XYECOM.Model.SupplyInfo es)
        {
            SqlParameter[] param = new SqlParameter[] 
            {                                                      
                new SqlParameter("@SD_ID",es.InfoID),
                new SqlParameter("@U_ID",es.UserID),
                new SqlParameter("@PT_ID",es.SortID ),
                new SqlParameter("@SD_Title",es.Title),
                new SqlParameter("@SD_Description",es.InfoContent),
                new SqlParameter("@SD_Flag",es.InfoType ),
                new SqlParameter("@SD_Date",es.UseFulDate ),
                new SqlParameter("@P_ID",es.FieldID ),
                new SqlParameter("@SD_EndDate",es.EndTime ),
                new SqlParameter("@SD_Unit",es.Unit ),
                new SqlParameter("@SD_Price",es.Price ),
                new SqlParameter("@SD_SmallNum",es.LeastNum ),
                new SqlParameter("@SD_CountNum",es.CountNum ),
                new SqlParameter("@SD_IsPayMent",es.IsPayMent),
                new SqlParameter("@companyproducttypeid",es.CompanyProductTypeId)
           };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateSupply", param);
        }

        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="SD_ID">记录编号</param>
        /// <returns>一条记录</returns>
        [Obsolete]
        public XYECOM.Model.SupplyInfo GetItem(int infoId)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," Where SD_ID=" + infoId.ToString()),
                new SqlParameter("@strTableName","XYV_Supply"),
                new SqlParameter("@strOrder","")
            };

            XYECOM.Model.SupplyInfo info = null;

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (reader.Read())
                {
                    info = new XYECOM.Model.SupplyInfo();

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


                    //新增的父类属性 刘甲 2008-10-18
                    info.InfoID = infoId;
                    info.ModuleFlag = reader["ModuleName"].ToString();
                    info.Title = reader["SD_Title"].ToString();
                    info.Price = Core.MyConvert.GetDecimal(reader["SD_Price"].ToString());
                    info.PublishTime = Core.MyConvert.GetDateTime(reader["SD_PublishDate"].ToString());
                    info.EndTime = Core.MyConvert.GetDateTime(reader["SD_EndDate"].ToString());
                    info.InfoContent = reader["SD_Description"].ToString();
                    info.UserID = Core.MyConvert.GetInt64(reader["U_ID"].ToString());
                    info.SortID = Core.MyConvert.GetInt64(reader["PT_ID"].ToString());
                    info.SortName = reader["PT_Name"].ToString();
                    info.HtmlPage = reader["SD_HTMLPage"].ToString();
                    info.ClickNum = Core.MyConvert.GetInt64(reader["SD_ClickNum"].ToString());
                    info.IsCommend = reader["SD_Vouch"].ToString() == "1";
                    info.MessageNum = Core.MyConvert.GetInt32(reader["SD_MessageNum"].ToString());
                    info.NotReadingNum = Core.MyConvert.GetInt32(reader["SD_NoMessgeNum"].ToString());
                    info.UseFulDate = Core.MyConvert.GetInt32(reader["SD_Date"].ToString());
                    info.InfoType = Core.MyConvert.GetInt32(reader["SD_Flag"].ToString());
                    info.FieldID = 0;
                    info.IsPause = Core.MyConvert.GetBoolean(reader["SD_IsSupply"].ToString());
                    //新增的属性值
                    info.Unit = reader["SD_Unit"].ToString();
                    info.LeastNum = Core.MyConvert.GetInt32(reader["SD_SmallNum"].ToString());
                    info.CountNum = Core.MyConvert.GetInt32(reader["SD_CountNum"].ToString());
                    info.IsPayMent = Core.MyConvert.GetBoolean(reader["SD_IsPayMent"].ToString());
                    info.Isshop = Core.MyConvert.GetBoolean(reader["isshop"].ToString());
                    info.CompanyProductTypeId = Core.MyConvert.GetInt32(reader["companyproducttypeid"].ToString());
                    info.Tags = reader["Tags"].ToString();
                    info.AttachInfo = new Attachment().GetItems(info.InfoID, "i_supply");
                    //设置附件信息
                    //Attachment.SetAttachmentInfo(info, reader);
                }
            }

            return info;
        }

        /// <summary>
        /// 根据产品编号获取该产品的最少起订量（王振添加 2011-04-13）
        /// </summary>
        /// <param name="supplyId">产品ID</param>
        /// <returns>最少起订量</returns>
        public int GetSmallNum(int supplyId)
        {
            string sql = "select sd_smallnum from i_supply where sd_id = " + supplyId + "";
            object obj = SqlHelper.ExecuteScalar(sql);
            if (obj == null)
            {
                return 0;
            }
            return (int)obj;
        }

        /// <summary>
        /// 根据产品编号获取该产品的详细信息（王振添加 2011-03-30）
        /// </summary>
        /// <param name="id">产品ID</param>
        /// <returns>产品的详细信息</returns>
        public XYECOM.Model.SupplyInfo GetSupplyById(int id)
        {
            string sql = "select * from i_supply where sd_id = " + id + "";
            XYECOM.Model.SupplyInfo info = null;

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.Text, sql, null))
            {
                if (reader.Read())
                {
                    info = new Model.SupplyInfo();
                    if (reader["AuditingState"].ToString() != "")
                    {
                        if (reader["AuditingState"].ToString().Equals("1"))
                        {
                            info.AuditingState = XYECOM.Model.AuditingState.Passed;
                        }
                        else
                        {
                            info.AuditingState = XYECOM.Model.AuditingState.NoPass;
                        }
                    }
                    else
                    {
                        info.AuditingState = XYECOM.Model.AuditingState.Null;
                    }
                    info.InfoID = id;
                    info.Title = reader["SD_Title"].ToString();
                    info.Price = Core.MyConvert.GetDecimal(reader["SD_Price"].ToString());
                    info.PublishTime = Core.MyConvert.GetDateTime(reader["SD_PublishDate"].ToString());
                    info.EndTime = Core.MyConvert.GetDateTime(reader["SD_EndDate"].ToString());
                    info.InfoContent = reader["SD_Description"].ToString();
                    info.UserID = Core.MyConvert.GetInt64(reader["U_ID"].ToString());
                    info.SortID = Core.MyConvert.GetInt64(reader["PT_ID"].ToString());
                    info.HtmlPage = reader["SD_HTMLPage"].ToString();
                    info.ClickNum = Core.MyConvert.GetInt64(reader["SD_ClickNum"].ToString());
                    info.IsCommend = reader["SD_Vouch"].ToString() == "1";
                    info.MessageNum = Core.MyConvert.GetInt32(reader["SD_MessageNum"].ToString());
                    info.NotReadingNum = Core.MyConvert.GetInt32(reader["SD_NoMessgeNum"].ToString());
                    info.UseFulDate = Core.MyConvert.GetInt32(reader["SD_Date"].ToString());
                    info.InfoType = Core.MyConvert.GetInt32(reader["SD_Flag"].ToString());
                    info.IsPause = Core.MyConvert.GetBoolean(reader["SD_IsSupply"].ToString());
                    info.Unit = reader["SD_Unit"].ToString();
                    info.LeastNum = Core.MyConvert.GetInt32(reader["SD_SmallNum"].ToString());
                    info.CountNum = Core.MyConvert.GetInt32(reader["SD_CountNum"].ToString());
                    info.IsPayMent = Core.MyConvert.GetBoolean(reader["SD_IsPayMent"].ToString());
                    info.Isshop = Core.MyConvert.GetBoolean(reader["isshop"].ToString());
                    info.CompanyProductTypeId = Core.MyConvert.GetInt32(reader["companyproducttypeid"].ToString());

                    //基于山东亿家商城新增的属性 王振
                    info.BrandId = Core.MyConvert.GetInt32(reader["BrandId"].ToString());
                    info.MeasuringUnitId = Core.MyConvert.GetInt32(reader["MeasuringUnitId"].ToString());
                    info.DepotId = Core.MyConvert.GetInt32(reader["DepotId"].ToString());
                    info.Stocks = Core.MyConvert.GetInt32(reader["Stocks"].ToString());
                    info.SalesVolume = Core.MyConvert.GetInt32(reader["SalesVolume"].ToString());
                    info.IsDeleted = Core.MyConvert.GetBoolean(reader["IsDeleted"].ToString());
                    info.Tags = reader["Tags"].ToString();
                    info.Summary = reader["Summary"].ToString();
                    info.IsContractVouch = Core.MyConvert.GetBoolean(reader["IsContractVouch"].ToString());
                    info.IsPayBail = Core.MyConvert.GetBoolean(reader["IsPayBail"].ToString());
                    info.FreightType = Core.MyConvert.GetInt32(reader["FreightType"].ToString());
                    info.MarketPrice = Core.MyConvert.GetDecimal(reader["MarketPrice"].ToString());
                    info.ProductType = new ProductType().GetProTypeById(XYECOM.Core.MyConvert.GetInt32(info.SortID.ToString()));
                    info.LockCount = Core.MyConvert.GetInt32(reader["LockCount"].ToString());
                    info.IsContractVouch = Core.MyConvert.GetBoolean(reader["IsContractVouch"].ToString());
                    info.MarginRefund = Core.MyConvert.GetDecimal(reader["MarginRefund"].ToString());

                    info.AttachInfo = new Attachment().GetItems(info.InfoID, "i_supply");
                    

                    if (info.ProductType != null)
                    {
                        info.FieldValues = new FieldValueAccess().GetItems(info);
                    }
                }
            }
            return info;
        }

        /// <summary>
        /// 新增一条产品信息 (王振添加 2011-04-01)
        /// </summary>
        /// <param name="supply">产品信息</param>
        /// <param name="infoId">新增的产品ID</param>
        /// <returns>返回新增的产品ID</returns>
        public int InsertSupply(Model.SupplyInfo supply, out int infoId)
        {
            SqlParameter[] param = new SqlParameter[] 
            {                                                      
                new SqlParameter("@SD_ID",SqlDbType.BigInt),
                new SqlParameter("@Brand_Id",supply.BrandId==0?(object)DBNull.Value:supply.BrandId),
                new SqlParameter("@U_ID",supply.UserID),
                new SqlParameter("@PT_ID",supply.SortID),
                new SqlParameter("@companyproducttypeid",supply.CompanyProductTypeId==0?(object)DBNull.Value:supply.CompanyProductTypeId),
                new SqlParameter("@measuringunitid",supply.MeasuringUnitId==0?(object)DBNull.Value:supply.MeasuringUnitId),
                new SqlParameter("@depotid",supply.DepotId==0?(object)DBNull.Value:supply.DepotId),
                new SqlParameter("@SD_Title",supply.Title),
                new SqlParameter("@SD_Description",supply.InfoContent),
                new SqlParameter("@publishdate",supply.PublishTime),
                new SqlParameter("@issupply",supply.IsPause),
                new SqlParameter("@sd_htmlpage",supply.HtmlPage),
                new SqlParameter("@sd_clicknum",supply.ClickNum),
                new SqlParameter("@sd_vouch",supply.IsCommend),
                new SqlParameter("@sd_messagenum",supply.MessageNum),
                new SqlParameter("@sd_nomessgenum",supply.NotReadingNum),
                new SqlParameter("@SD_Flag",supply.InfoType ),
                new SqlParameter("@SD_Date",supply.UseFulDate ),
                new SqlParameter("@SD_EndDate",supply.EndTime ),
                new SqlParameter("@SD_Unit",supply.Unit ),
                new SqlParameter("@SD_Price",supply.Price ),
                new SqlParameter("@SD_SmallNum",supply.LeastNum ),
                new SqlParameter("@SD_CountNum",supply.CountNum ),
                new SqlParameter("@stocks",supply.Stocks),
                new SqlParameter("@salesvolume",supply.SalesVolume),
                new SqlParameter("@sd_ispayment",supply.IsPayMent),
                new SqlParameter("@isshop",supply.Isshop ),
                new SqlParameter("@auditingstate",supply.AuditingState ),
                new SqlParameter("@ishasimage",supply.Ishasimage),
                new SqlParameter("@isdeleted",supply.IsDeleted),
                new SqlParameter("@tags",supply.Tags),
                new SqlParameter("@summary",supply.Summary ),
                new SqlParameter("@iscontractvouch",supply.IsContractVouch),
                new SqlParameter("@ispaybail",supply.IsPayBail),
                new SqlParameter("@freighttype",supply.FreightType),
                new SqlParameter("@marketprice",supply.MarketPrice),
                new SqlParameter("@LockCount",supply.LockCount)
            };
            string sql = @"insert into i_supply (
                                                brandid
                                                ,u_id
                                                ,pt_id
                                                ,companyproducttypeid
                                                ,measuringunitid
                                                ,depotid
                                                ,sd_title
                                                ,sd_description
                                                ,sd_publishdate
                                                ,sd_issupply
                                                ,sd_htmlpage
                                                ,sd_clicknum
                                                ,sd_vouch
                                                ,sd_messagenum
                                                ,sd_nomessgenum
                                                ,sd_flag
                                                ,sd_date
                                                ,sd_enddate
                                                ,sd_unit
                                                ,sd_price
                                                ,sd_smallnum
                                                ,sd_countnum
                                                ,stocks
                                                ,salesvolume
                                                ,sd_ispayment
                                                ,isshop
                                                ,auditingstate
                                                ,ishasimage
                                                ,isdeleted
                                                ,tags
                                                ,summary
                                                ,iscontractvouch 
                                                ,ispaybail
                                                ,freighttype
                                                ,marketprice,LockCount)
                                                values                 
                                                (
                                                @Brand_Id,
                                                @U_ID,
                                                @PT_ID,
                                                @companyproducttypeid,
                                                @measuringunitid,
                                                @depotid,
                                                @SD_Title,
                                                @SD_Description,
                                                @publishdate,
                                                @issupply,
                                                @sd_htmlpage,
                                                @sd_clicknum,
                                                @sd_vouch,
                                                @sd_messagenum,
                                                @sd_nomessgenum,
                                                @SD_Flag,
                                                @SD_Date,
                                                @SD_EndDate,
                                                @SD_Unit,
                                                @SD_Price,
                                                @SD_SmallNum,
                                                @SD_CountNum,
                                                @stocks,
                                                @salesvolume,
                                                @sd_ispayment,
                                                @isshop,
                                                @auditingstate,
                                                @ishasimage,
                                                @isdeleted,
                                                @tags,
                                                @summary,
                                                @iscontractvouch,
                                                @ispaybail,
                                                @freighttype,
                                                @marketprice,
                                                @LockCount
                                                );select @SD_ID=@@identity";
            param[0].Direction = ParameterDirection.Output;

            int rowAffected = SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);

            if (rowAffected >= 0)
            {
                if (param[0].Value != null && param[0].Value.ToString() != "")
                    infoId = XYECOM.Core.MyConvert.GetInt32(param[0].Value.ToString());
                else
                    infoId = 0;
            }
            else
            {
                infoId = -1;
            }
            if (infoId > 0)
            {
                //添加分类属性值信息
                FieldValueAccess fieldValueDal = new FieldValueAccess();

                foreach (Model.FieldValueInfo valueInfo in supply.FieldValues)
                {
                    if (valueInfo == null) continue;
                    valueInfo.ProductId = infoId;
                    fieldValueDal.Insert(valueInfo);
                }
            }
            return rowAffected;
        }

        /// <summary>
        /// 根据产品编号修改产品信息 (王振添加2011-04-01)
        /// </summary>
        /// <param name="supply">产品信息</param>
        /// <returns>受影响的行数</returns>
        public int UpdateSupply(Model.SupplyInfo supply)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@sid",supply.InfoID),
                new SqlParameter("@brandid",supply.BrandId==0?(object)DBNull.Value:supply.BrandId),
                new SqlParameter("@pt_id",supply.SortID),
                new SqlParameter("@companyProducttypeid",supply.CompanyProductTypeId==0?(object)DBNull.Value:supply.CompanyProductTypeId),
                new SqlParameter("@measuringunitid",supply.MeasuringUnitId==0?(object)DBNull.Value:supply.MeasuringUnitId),
                new SqlParameter("@depotid",supply.DepotId==0?(object)DBNull.Value:supply.DepotId),
                new SqlParameter("@sd_title",supply.Title),
                new SqlParameter("@sd_description",supply.InfoContent),
                new SqlParameter("@sd_date",supply.UseFulDate),
                new SqlParameter("@sd_enddate",supply.EndTime),
                new SqlParameter("@sd_unit",supply.Unit),
                new SqlParameter("@sd_price",supply.Price),
                new SqlParameter("@SD_SmallNum",supply.LeastNum),
                new SqlParameter("@tags",supply.Tags),
                new SqlParameter("@CountNum",supply.CountNum),
                new SqlParameter("@summary",supply.Summary),
                new SqlParameter("@freighttype",supply.FreightType),
                new SqlParameter("@marketprice",supply.MarketPrice),
                new SqlParameter("@LockCount",supply.LockCount)
            };
            string sql = @"update i_supply set  brandid = @brandid,
                                                pt_id = @pt_id,
                                                companyProducttypeid = @companyProducttypeid,
                                                measuringunitid = @measuringunitid,
                                                depotid = @depotid,
                                                sd_title= @sd_title,
                                                sd_description=@sd_description,
                                                sd_date=@sd_date,
                                                sd_enddate=@sd_enddate,
                                                sd_unit=@sd_unit,
                                                sd_price=@sd_price,
                                                SD_SmallNum=@SD_SmallNum,
                                                tags=@tags,
                                                summary=@summary,
                                                freighttype=@freighttype,
                                                marketprice = @marketprice,
                                                sd_countnum = @CountNum,
                                                LockCount = @LockCount
                                                where sd_id =@sid";
            int rowAffected = XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
            if (rowAffected > 0)
            {
                FieldValueAccess fieldDAL = new FieldValueAccess();

                //删除产品原来的分类属性值
                fieldDAL.DeleteFieldValueByProductId(supply.InfoID);

                //新增修改后的分类属性值信息
                foreach (Model.FieldValueInfo valueInfo in supply.FieldValues)
                {
                    if (valueInfo == null) continue;
                    valueInfo.ProductId = XYECOM.Core.MyConvert.GetInt32(supply.InfoID.ToString());
                    fieldDAL.Insert(valueInfo);
                }
            }
            return rowAffected;
        }



        /// <summary>
        /// 获取多条记录
        /// </summary>
        /// <param name="Ｕ_ID">条件查询</param>
        /// <returns>多条记录</returns>
        public DataTable GetDataTable(long U_ID)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strwhere","where U_ID="+U_ID),
                new SqlParameter("@strtableName","i_Supply"),
                new SqlParameter("@strOrder"," order by SD_ID desc ")
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "XYP_SelectByWhere", param);
        }
        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="SD_ID">记录编号</param>
        /// <returns>受影响的行数</returns>
        public int Delete(long SD_ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where SD_ID="+SD_ID.ToString()),
                new SqlParameter("@strTableName","i_Supply")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }

        /// <summary>
        /// 删除多条记录
        /// </summary>
        /// <param name="SD_ID">记录编号</param>
        /// <returns>受影响的行数</returns>
        public int Deletes(string ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where SD_ID in ("+ID+")"),
                new SqlParameter("@strTableName","i_Supply")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }
        /// <summary>
        /// 修改推荐信息
        /// </summary>
        /// <param name="es">实体类</param>
        /// <returns>受影响的行数</returns>
        public int UpdateVouch(XYECOM.Model.SupplyInfo es)
        {
            SqlParameter[] param = new SqlParameter[] 
            {
                new SqlParameter("@SD_Vouch",SqlDbType.Bit),
                new SqlParameter("@SD_ID",SqlDbType.BigInt )
            };

            param[0].Value = es.IsCommend;
            param[1].Value = es.InfoID;

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateSupplyVouch", param);
        }

        /// <summary>
        /// 修改暂停信息
        /// </summary>
        /// <param name="SD_ID">编号</param>
        /// <returns></returns>
        public int UpdatePause(string SD_ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            {
                new SqlParameter("@strwhere","where SD_ID in ("+SD_ID+")") 
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateSupplyPause", param);
        }
        /// <summary>
        /// 获得指定的产品列表
        /// </summary>
        /// <param name="colums">列名</param>
        /// <param name="where">条件</param>
        /// <param name="order">排序</param>
        /// <param name="topNumber">记录条数</param>
        /// <returns></returns>
        public DataTable ExecuteTable(string colums, string where, string order, int topNumber)
        {
            return Utils.ExecuteTable("XYV_Supply", colums, where, order, topNumber);
        }

        #region 批量移动
        /// <summary>
        /// 批量移动
        /// </summary>
        /// <returns></returns>
        public int MoveSupply(String strwhere, String content)
        {
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@strwhere",strwhere),
                new SqlParameter("@tablename","i_supply"),
                new SqlParameter("@content",content)
            };
            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "usp_PublicUpdate", param);
        }

        #endregion

        /// <summary>
        /// 设置会员商机信息暂停 (王振添加 2011-04-07)
        /// </summary>
        /// <param name="lstId">商机编号集合</param>
        /// <param name="state">状态 true为启用，false停用</param>
        /// <returns>返回影响行数</returns>
        public int UpdateSupplyState(string lstId, bool state)
        {
            if (string.IsNullOrEmpty(lstId)) return -1;

            string sqlfmt = string.Empty;

            string sql = string.Empty;

            sqlfmt = "update i_supply set SD_IsSupply={0} where SD_ID in ({1})";

            sql = string.Format(sqlfmt, (state ? 1 : 0), lstId);

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 推荐会员商机信息至网店,或从网店取消推荐  (王振添加 2011-04-07)
        /// </summary>
        /// <param name="lstId">商机编号集合</param>
        /// <param name="state">状态 true为推荐，false取消推荐</param>
        /// <returns>返回影响行数</returns>
        public int RecommendToShop(string lstId, bool state)
        {

            if (string.IsNullOrEmpty(lstId)) return -1;

            string sqlfmt = string.Empty;

            string sql = string.Empty;

            sqlfmt = "update i_supply set IsShop={0} where SD_ID in ({1})";

            sql = string.Format(sqlfmt, (state ? 1 : 0), lstId);

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 刷新会员的商机信息 (王振添加 2011-04-07)
        /// </summary>        
        /// <param name="lstId">商机编号集合</param>
        /// <returns>返回影响行数</returns>
        public int ReSendInfo(string lstId)
        {
            if (string.IsNullOrEmpty(lstId)) return -1;

            string sqlfmt = string.Empty;
            string sql = string.Empty;

            sqlfmt = "update i_supply set SD_PublishDate=getdate(),SD_EndDate=dateadd(day,SD_Date,getdate()) where SD_ID in ({0})";

            sql = string.Format(sqlfmt, lstId);

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 根据产品编号逻辑删除产品信息  (王振添加 2011-04-07)
        /// </summary>
        /// <param name="lstId">产品编号</param>
        /// <returns>受影响的行数</returns>
        public int UpdateDeleteById(string lstId)
        {
            if (string.IsNullOrEmpty(lstId)) return -1;

            string sqlfmt = string.Empty;
            string sql = string.Empty;

            sqlfmt = "update i_supply set IsDeleted = 1 where SD_ID in ({0})";

            sql = string.Format(sqlfmt, lstId);

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 根据购买数量和当前产品的价格区间计算出当前价
        /// </summary>
        /// <param name="proCount">购买的产品个数</param>
        /// <param name="pid">产品ID</param>
        /// <returns>当前的价格</returns>
        public decimal GetProductPrice(int pid, int proCount)
        {
            if (pid <= 0 || proCount <= 0)
            {
                return 0;
            }
            string sql = "select price from xy_pricerange where productid = " + pid + " and (ordernum<= " + proCount + " and (rangenum>=" + proCount + " or rangenum=-1))";
            object obj = XYECOM.Core.Data.SqlHelper.ExecuteScalar(sql);
            decimal price = 0;
            if (obj != null)
            {
                price = (decimal)obj;
            }
            return price;
        }

        /// <summary>
        /// 根据购买数量和当前产品的价格区间计算出当前价格区间
        /// </summary>
        /// <param name="proCount">购买的产品个数</param>
        /// <param name="pid">产品ID</param>
        /// <returns>当前的价格区间</returns>
        public int GetProductOrderNum(int pid, int proCount)
        {
            if (pid <= 0 || proCount <= 0)
            {
                return 0;
            }
            string sql = "select ordernum from xy_pricerange where productid = " + pid + " and (ordernum<= " + proCount + " and (rangenum>=" + proCount + " or rangenum=-1))";
            object obj = XYECOM.Core.Data.SqlHelper.ExecuteScalar(sql);
            int orderNum = 0;
            if (obj != null)
            {
                orderNum = (int)obj;
            }
            return orderNum;
        }

        /// <summary>
        ///根据产品编号获取产品名称
        /// </summary>
        /// <param name="suppid">产品编号</param>
        /// <returns>产品名称</returns>
        public string GetSupplyNameById(int suppid)
        {
            string sql = "select sd_title from i_supply where sd_id = " + suppid + "";
            object obj = XYECOM.Core.Data.SqlHelper.ExecuteScalar(sql);
            if (obj != null)
            {
                return obj.ToString();
            }
            return string.Empty;
        }

        /// <summary>
        /// 获取一组产品中共有的货运方式
        /// 当所有产品中，有一种不支持自提，则所有产品不支持字体
        /// </summary>
        /// <param name="productIds"></param>
        /// <returns></returns>
        public DataTable GetProductsSupportLogisticsTypesByProductIds(string productIds)
        {
            if (string.IsNullOrEmpty(productIds)) return new DataTable();

            int productCount = productIds.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Length;

            if (productCount < 1) return new DataTable();

            //
            string sql = @"select LogisticsTypeId,LogisticsPrice,TypeName,TypeName + ' ' + cast(LogisticsPrice as varchar(50)) as 
                            TypeAndPrice from (select LogisticsTypeId,max(LogisticsPrice) as LogisticsPrice ,count(1) as ct 
                            from XY_ProductLogisticsEnterprise where productId in (" + productIds + @") group by LogisticsTypeId
                            ) as t inner join XY_LogisticsType on t.LogisticsTypeId=XY_LogisticsType.Id where t.ct=" + productCount + @"
                            union
                            select 0,0,'卖家承担运费','卖家承担运费' from
                            (select FreightType,count(1) as ct from i_supply where SD_ID in (" + productIds + @") 
                            and (FreightType=" + (int)Model.FreightType.SellerPayment + @") group by FreightType
                            ) as t1 where t1.ct=" + productCount + @"
                            union
                            select -1,0,'买家自提货','买家自提货' from
                            (select FreightType,count(1) as ct from i_supply where SD_ID in (" + productIds + @") 
                            and (FreightType=" + (int)Model.FreightType.SelfDelivery + @") group by FreightType
                            ) as t2 where t2.ct=" + productCount + @"
                            union
                            select -1,0,'买家自提货','买家自提货' from
                            (select FreightType,count(1) as ct from i_supply where SD_ID in (" + productIds + @") 
                            and (FreightType=" + (int)Model.FreightType.BuyerPayAndSelfDelivery + @") group by FreightType
                            ) as t3 where t3.ct=" + productCount + @"
                            union
                            select -1,0,'买家自提货','买家自提货' from
                            (select sum(ct) as ct from (
                            select FreightType,count(1) as ct from i_supply where SD_ID in (" + productIds + @") 
                            and (FreightType=" + (int)Model.FreightType.SelfDelivery + @" or FreightType=" + (int)Model.FreightType.BuyerPayAndSelfDelivery + @") group by FreightType
                            ) as tt group by ct
                            ) as t4 where t4.ct=" + productCount + @"
                            union
                            select LogisticsTypeId,LogisticsPrice,TypeName,TypeName + ' ' + cast(LogisticsPrice as varchar(50)) as 
                            TypeAndPrice from(select * from XY_ProductLogisticsEnterprise where productId in (" + productIds + @") and 
                            LogisticsPrice=(select max(LogisticsPrice) from XY_ProductLogisticsEnterprise where productId in 
                            (" + productIds + @"))) as t inner join XY_LogisticsType on t.LogisticsTypeId=XY_LogisticsType.Id";

            DataTable table = XYECOM.Core.Data.SqlHelper.ExecuteTable(sql);

            return table;
        }

        /// <summary>
        /// 产品的挂牌操作
        /// </summary>
        /// <param name="supplyId">产品ID</param>
        /// <param name="count">挂牌量</param>
        /// <param name="ispayBail">挂牌的状态（0不挂牌 ，1挂牌）</param>
        /// <returns>受影响的行数</returns>
        public int UpdateIsPayBailById(int supplyId, int count, bool ispayBail, decimal marginRefund)
        {
            string sql = "update i_supply set ispaybail = " + (ispayBail ? 1 : 0) + " ,stocks = " + count + ",MarginRefund=" + marginRefund + " where sd_id = " + supplyId + "";
            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 根据品牌id 获取该id被引用的产品数
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns></returns>
        public int GetBrandSupplyForBrandId(int brandId)
        {
            string sql = "select count(1) from i_supply where BrandId=" + brandId;
            return XYECOM.Core.MyConvert.GetInt32(XYECOM.Core.Data.SqlHelper.ExecuteScalar(sql).ToString());
        }
        /// <summary>
        /// 根据品牌id 获取该id被引用的产品数
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns></returns>
        public int GetBrandSupplyForUnitId(int UnitId)
        {
            string sql = "select count(1) from i_supply where MeasuringUnitId=" + UnitId;
            return XYECOM.Core.MyConvert.GetInt32(XYECOM.Core.Data.SqlHelper.ExecuteScalar(sql).ToString());
        }

        /// <summary>
        /// 根据产品编号跟新产品的库存量，挂牌量，锁定量
        /// </summary>
        /// <param name="supplyId">产品编号</param>
        /// <param name="count">产品数量</param>
        /// <returns>受影响的行数</returns>
        public int UpdateStocksAndLockById(int supplyId, int count)
        {
            if (supplyId <= 0 || count <= 0)
            {
                return 0;
            }
            string sql = "update i_supply set SD_CountNum = SD_CountNum-" + count + ",Stocks=Stocks-" + count + ",lockcount =lockcount+" + count + " where sd_id =" + supplyId + "";
            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 根据产品编号修改锁定量,累计销售量
        /// </summary>
        /// <param name="supplyId">产品编号</param>
        /// <param name="count">修改的锁定量</param>
        /// <returns>受影响的行数</returns>
        public int UpdateLockCountById(int supplyId, int count)
        {
            if (supplyId <= 0 || count <= 0)
            {
                return 0;
            }
            string sql = "update i_supply set SalesVolume=SalesVolume+" + count + ",lockcount =lockcount-" + count + " where sd_id =" + supplyId + "";
            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(sql);
        }


    }
}
