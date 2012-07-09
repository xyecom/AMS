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
    /// ������Ϣ���ݴ�����
    /// </summary>
    public class Supply
    {
        /// <summary>
        /// ��ӹ�����Ϣ
        /// </summary>
        /// <param name="info">ʵ����</param>
        /// /// <param name="infoid">�������</param>
        /// <returns>��Ӱ�������</returns>
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
        /// �޸Ĺ�Ӧ��Ϣ
        /// </summary>
        /// <param name="ea">ʵ����</param>
        /// <returns>��Ӱ�������</returns>
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
        /// ��ȡһ����¼
        /// </summary>
        /// <param name="SD_ID">��¼���</param>
        /// <returns>һ����¼</returns>
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


                    //�����ĸ������� ���� 2008-10-18
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
                    //����������ֵ
                    info.Unit = reader["SD_Unit"].ToString();
                    info.LeastNum = Core.MyConvert.GetInt32(reader["SD_SmallNum"].ToString());
                    info.CountNum = Core.MyConvert.GetInt32(reader["SD_CountNum"].ToString());
                    info.IsPayMent = Core.MyConvert.GetBoolean(reader["SD_IsPayMent"].ToString());
                    info.Isshop = Core.MyConvert.GetBoolean(reader["isshop"].ToString());
                    info.CompanyProductTypeId = Core.MyConvert.GetInt32(reader["companyproducttypeid"].ToString());
                    info.Tags = reader["Tags"].ToString();
                    info.AttachInfo = new Attachment().GetItems(info.InfoID, "i_supply");
                    //���ø�����Ϣ
                    //Attachment.SetAttachmentInfo(info, reader);
                }
            }

            return info;
        }

        /// <summary>
        /// ���ݲ�Ʒ��Ż�ȡ�ò�Ʒ������������������� 2011-04-13��
        /// </summary>
        /// <param name="supplyId">��ƷID</param>
        /// <returns>��������</returns>
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
        /// ���ݲ�Ʒ��Ż�ȡ�ò�Ʒ����ϸ��Ϣ��������� 2011-03-30��
        /// </summary>
        /// <param name="id">��ƷID</param>
        /// <returns>��Ʒ����ϸ��Ϣ</returns>
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

                    //����ɽ���ڼ��̳����������� ����
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
        /// ����һ����Ʒ��Ϣ (������� 2011-04-01)
        /// </summary>
        /// <param name="supply">��Ʒ��Ϣ</param>
        /// <param name="infoId">�����Ĳ�ƷID</param>
        /// <returns>���������Ĳ�ƷID</returns>
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
                //��ӷ�������ֵ��Ϣ
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
        /// ���ݲ�Ʒ����޸Ĳ�Ʒ��Ϣ (�������2011-04-01)
        /// </summary>
        /// <param name="supply">��Ʒ��Ϣ</param>
        /// <returns>��Ӱ�������</returns>
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

                //ɾ����Ʒԭ���ķ�������ֵ
                fieldDAL.DeleteFieldValueByProductId(supply.InfoID);

                //�����޸ĺ�ķ�������ֵ��Ϣ
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
        /// ��ȡ������¼
        /// </summary>
        /// <param name="��_ID">������ѯ</param>
        /// <returns>������¼</returns>
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
        /// ɾ��һ����¼
        /// </summary>
        /// <param name="SD_ID">��¼���</param>
        /// <returns>��Ӱ�������</returns>
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
        /// ɾ��������¼
        /// </summary>
        /// <param name="SD_ID">��¼���</param>
        /// <returns>��Ӱ�������</returns>
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
        /// �޸��Ƽ���Ϣ
        /// </summary>
        /// <param name="es">ʵ����</param>
        /// <returns>��Ӱ�������</returns>
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
        /// �޸���ͣ��Ϣ
        /// </summary>
        /// <param name="SD_ID">���</param>
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
        /// ���ָ���Ĳ�Ʒ�б�
        /// </summary>
        /// <param name="colums">����</param>
        /// <param name="where">����</param>
        /// <param name="order">����</param>
        /// <param name="topNumber">��¼����</param>
        /// <returns></returns>
        public DataTable ExecuteTable(string colums, string where, string order, int topNumber)
        {
            return Utils.ExecuteTable("XYV_Supply", colums, where, order, topNumber);
        }

        #region �����ƶ�
        /// <summary>
        /// �����ƶ�
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
        /// ���û�Ա�̻���Ϣ��ͣ (������� 2011-04-07)
        /// </summary>
        /// <param name="lstId">�̻���ż���</param>
        /// <param name="state">״̬ trueΪ���ã�falseͣ��</param>
        /// <returns>����Ӱ������</returns>
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
        /// �Ƽ���Ա�̻���Ϣ������,�������ȡ���Ƽ�  (������� 2011-04-07)
        /// </summary>
        /// <param name="lstId">�̻���ż���</param>
        /// <param name="state">״̬ trueΪ�Ƽ���falseȡ���Ƽ�</param>
        /// <returns>����Ӱ������</returns>
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
        /// ˢ�»�Ա���̻���Ϣ (������� 2011-04-07)
        /// </summary>        
        /// <param name="lstId">�̻���ż���</param>
        /// <returns>����Ӱ������</returns>
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
        /// ���ݲ�Ʒ����߼�ɾ����Ʒ��Ϣ  (������� 2011-04-07)
        /// </summary>
        /// <param name="lstId">��Ʒ���</param>
        /// <returns>��Ӱ�������</returns>
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
        /// ���ݹ��������͵�ǰ��Ʒ�ļ۸�����������ǰ��
        /// </summary>
        /// <param name="proCount">����Ĳ�Ʒ����</param>
        /// <param name="pid">��ƷID</param>
        /// <returns>��ǰ�ļ۸�</returns>
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
        /// ���ݹ��������͵�ǰ��Ʒ�ļ۸�����������ǰ�۸�����
        /// </summary>
        /// <param name="proCount">����Ĳ�Ʒ����</param>
        /// <param name="pid">��ƷID</param>
        /// <returns>��ǰ�ļ۸�����</returns>
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
        ///���ݲ�Ʒ��Ż�ȡ��Ʒ����
        /// </summary>
        /// <param name="suppid">��Ʒ���</param>
        /// <returns>��Ʒ����</returns>
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
        /// ��ȡһ���Ʒ�й��еĻ��˷�ʽ
        /// �����в�Ʒ�У���һ�ֲ�֧�����ᣬ�����в�Ʒ��֧������
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
                            select 0,0,'���ҳе��˷�','���ҳе��˷�' from
                            (select FreightType,count(1) as ct from i_supply where SD_ID in (" + productIds + @") 
                            and (FreightType=" + (int)Model.FreightType.SellerPayment + @") group by FreightType
                            ) as t1 where t1.ct=" + productCount + @"
                            union
                            select -1,0,'��������','��������' from
                            (select FreightType,count(1) as ct from i_supply where SD_ID in (" + productIds + @") 
                            and (FreightType=" + (int)Model.FreightType.SelfDelivery + @") group by FreightType
                            ) as t2 where t2.ct=" + productCount + @"
                            union
                            select -1,0,'��������','��������' from
                            (select FreightType,count(1) as ct from i_supply where SD_ID in (" + productIds + @") 
                            and (FreightType=" + (int)Model.FreightType.BuyerPayAndSelfDelivery + @") group by FreightType
                            ) as t3 where t3.ct=" + productCount + @"
                            union
                            select -1,0,'��������','��������' from
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
        /// ��Ʒ�Ĺ��Ʋ���
        /// </summary>
        /// <param name="supplyId">��ƷID</param>
        /// <param name="count">������</param>
        /// <param name="ispayBail">���Ƶ�״̬��0������ ��1���ƣ�</param>
        /// <returns>��Ӱ�������</returns>
        public int UpdateIsPayBailById(int supplyId, int count, bool ispayBail, decimal marginRefund)
        {
            string sql = "update i_supply set ispaybail = " + (ispayBail ? 1 : 0) + " ,stocks = " + count + ",MarginRefund=" + marginRefund + " where sd_id = " + supplyId + "";
            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// ����Ʒ��id ��ȡ��id�����õĲ�Ʒ��
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns></returns>
        public int GetBrandSupplyForBrandId(int brandId)
        {
            string sql = "select count(1) from i_supply where BrandId=" + brandId;
            return XYECOM.Core.MyConvert.GetInt32(XYECOM.Core.Data.SqlHelper.ExecuteScalar(sql).ToString());
        }
        /// <summary>
        /// ����Ʒ��id ��ȡ��id�����õĲ�Ʒ��
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns></returns>
        public int GetBrandSupplyForUnitId(int UnitId)
        {
            string sql = "select count(1) from i_supply where MeasuringUnitId=" + UnitId;
            return XYECOM.Core.MyConvert.GetInt32(XYECOM.Core.Data.SqlHelper.ExecuteScalar(sql).ToString());
        }

        /// <summary>
        /// ���ݲ�Ʒ��Ÿ��²�Ʒ�Ŀ��������������������
        /// </summary>
        /// <param name="supplyId">��Ʒ���</param>
        /// <param name="count">��Ʒ����</param>
        /// <returns>��Ӱ�������</returns>
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
        /// ���ݲ�Ʒ����޸�������,�ۼ�������
        /// </summary>
        /// <param name="supplyId">��Ʒ���</param>
        /// <param name="count">�޸ĵ�������</param>
        /// <returns>��Ӱ�������</returns>
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
