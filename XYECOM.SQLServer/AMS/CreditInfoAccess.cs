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
    /// 抵债信息数据访问类
    /// </summary>
    public class CreditInfoAccess
    {
        /// <summary>
        /// 增加债权信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int InsertCreditInfo(CreditInfo info)
        {
            string sql = @"Insert into CreditInfo (Title,DebtorName,DebtorTelpone,CollectionPeriod,DebtorReason,Arrears,Bounty,
                                    Remark,LicenseType,DebtorType,Introduction,Age,IsInLitigation,IsLitigationed,IsSelfCollection,IsConfirm,
                                    DebtObligation,DepartId,UserId,ApprovaStatus,CreateDate,AreaId)
                                    values (@Title,@DebtorName,@DebtorTelpone,@CollectionPeriod,@DebtorReason,@Arrears,@Bounty,@Remark,
                                    @LicenseType,@DebtorType,@Introduction,@Age,@IsInLitigation,@IsLitigationed,@IsSelfCollection,@IsConfirm,
                                    @DebtObligation,@DepartId,@UserId,@ApprovaStatus,@CreateDate,@AreaId)";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Title",info.Title),
                new SqlParameter("@DebtorName",info.DebtorName),
                new SqlParameter("@DebtorTelpone",info.DebtorTelpone),
                new SqlParameter("@CollectionPeriod",info.CollectionPeriod),
                new SqlParameter("@DebtorReason",info.DebtorReason),
                new SqlParameter("@Arrears",info.Arrears),
                new SqlParameter("@Bounty",info.Bounty),
                new SqlParameter("@Remark",info.Remark),
                new SqlParameter("@LicenseType",info.LicenseType),
                new SqlParameter("@DebtorType",info.DebtorType),
                new SqlParameter("@Introduction",info.Introduction),
                new SqlParameter("@Age",info.Age),
                new SqlParameter("@IsInLitigation",info.IsInLitigation),
                new SqlParameter("@IsLitigationed",info.IsLitigationed),
                new SqlParameter("@IsSelfCollection",info.IsSelfCollection),
                new SqlParameter("@IsConfirm",info.IsConfirm),
                new SqlParameter("@DebtObligation",info.DebtObligation),
                new SqlParameter("@DepartId",info.DepartId),
                new SqlParameter("@UserId",info.UserId),
                new SqlParameter("@ApprovaStatus",info.ApprovaStatus),
                new SqlParameter("@CreateDate",info.CreateDate),
                new SqlParameter("@AreaId",info.AreaId)
            };
            int rowAffected = SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
            return rowAffected;
        }

        /// <summary>
        /// 新增并获取自增长列的值
        /// </summary>
        /// <param name="info"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int InsertCreditInfo(CreditInfo info, out int Id)
        {
            string sql = @"Insert into CreditInfo (Title,DebtorName,DebtorTelpone,CollectionPeriod,DebtorReason,Arrears,Bounty,
                                    Remark,LicenseType,DebtorType,Introduction,Age,IsInLitigation,IsLitigationed,IsSelfCollection,IsConfirm,
                                    DebtObligation,DepartId,UserId,ApprovaStatus,CreateDate,AreaId)
                                    values (@Title,@DebtorName,@DebtorTelpone,@CollectionPeriod,@DebtorReason,@Arrears,@Bounty,@Remark,
                                    @LicenseType,@DebtorType,@Introduction,@Age,@IsInLitigation,@IsLitigationed,@IsSelfCollection,@IsConfirm,
                                    @DebtObligation,@DepartId,@UserId,@ApprovaStatus,@CreateDate,@AreaId);select @ID = @@identity";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ID",SqlDbType.Int),
                new SqlParameter("@Title",info.Title),
                new SqlParameter("@DebtorName",info.DebtorName),
                new SqlParameter("@DebtorTelpone",info.DebtorTelpone),
                new SqlParameter("@CollectionPeriod",info.CollectionPeriod),
                new SqlParameter("@DebtorReason",info.DebtorReason),
                new SqlParameter("@Arrears",info.Arrears),
                new SqlParameter("@Bounty",info.Bounty),
                new SqlParameter("@Remark",info.Remark),
                new SqlParameter("@LicenseType",info.LicenseType),
                new SqlParameter("@DebtorType",info.DebtorType),
                new SqlParameter("@Introduction",info.Introduction),
                new SqlParameter("@Age",info.Age),
                new SqlParameter("@IsInLitigation",info.IsInLitigation),
                new SqlParameter("@IsLitigationed",info.IsLitigationed),
                new SqlParameter("@IsSelfCollection",info.IsSelfCollection),
                new SqlParameter("@IsConfirm",info.IsConfirm),
                new SqlParameter("@DebtObligation",info.DebtObligation),
                new SqlParameter("@DepartId",info.DepartId),
                new SqlParameter("@UserId",info.UserId),
                new SqlParameter("@ApprovaStatus",info.ApprovaStatus),
                new SqlParameter("@CreateDate",info.CreateDate),
                new SqlParameter("@AreaId",info.AreaId)
            };
            param[0].Direction = ParameterDirection.Output;
            int rowAffected = SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
            if (rowAffected >= 0)
            {
                if (param[0].Value != null && param[0].Value.ToString() != "")
                    Id = (int)param[0].Value;
                else
                    Id = 0;
            }
            else
            {
                Id = -1;
            }
            return rowAffected;
        }
        /// <summary>
        /// 修改债权信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int UpdateCreditInfoByID(CreditInfo info)
        {
            string sql = @"UPDATE CreditInfo SET Title =                                                                                                              
                                    @Title,DebtorName=@DebtorName,DebtorTelpone=@DebtorTelpone,CollectionPeriod=@CollectionPeriod,DebtorReason=@DebtorReason,
                                    Arrears=@Arrears,Bounty=@Bounty,Remark=@Remark,LicenseType=@LicenseType,DebtorType=@DebtorType,Introduction=@Introduction,
                                    Age=@Age,IsInLitigation=@IsInLitigation,IsLitigationed=@IsLitigationed,IsSelfCollection=@IsSelfCollection,IsConfirm=@IsConfirm,DebtObligation=@DebtObligation,
                                   ApprovaStatus=@ApprovaStatus,AreaId=@AreaId WHERE CreditId=@CreditId";

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Title",info.Title),
                new SqlParameter("@DebtorName",info.DebtorName),
                new SqlParameter("@DebtorTelpone",info.DebtorTelpone),
                new SqlParameter("@CollectionPeriod",info.CollectionPeriod),
                new SqlParameter("@DebtorReason",info.DebtorReason),
                new SqlParameter("@Arrears",info.Arrears),
                new SqlParameter("@Bounty",info.Bounty),
                new SqlParameter("@Remark",info.Remark),
                new SqlParameter("@LicenseType",info.LicenseType),
                new SqlParameter("@DebtorType",info.DebtorType),
                new SqlParameter("@Introduction",info.Introduction),
                new SqlParameter("@Age",info.Age),
                new SqlParameter("@IsInLitigation",info.IsInLitigation),
                new SqlParameter("@IsLitigationed",info.IsLitigationed),
                new SqlParameter("@IsSelfCollection",info.IsSelfCollection),
                new SqlParameter("@IsConfirm",info.IsConfirm),
                new SqlParameter("@DebtObligation",info.DebtObligation),
                new SqlParameter("@ApprovaStatus",info.ApprovaStatus),
                new SqlParameter("@AreaId",info.AreaId),
                new SqlParameter("@CreditId",info.CreditId)
            };
            int rowAffected = SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
            return rowAffected;
        }

        /// <summary>
        /// 单条修改债权信息状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public int UpdateApprovaStatusByID(int id, XYECOM.Model.CreditState state)
        {
            string sql = "Update dbo.CreditInfo set ApprovaStatus= " + (int)state + ",PassDate=getDate() where CreditId = " + id;
            int rowAffected = SqlHelper.ExecuteNonQuery(CommandType.Text, sql, null);
            return rowAffected;
        }

        /// <summary>
        /// 多条修改债权信息状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public int UpdateApprovaStatusByID(string id, XYECOM.Model.CreditState state)
        {
            string sql = "Update CreditInfo set ApprovaStatus= " + (int)state + ",PassDate=getDate() where CreditId in ( " + id + " )";
            int rowAffected = SqlHelper.ExecuteNonQuery(CommandType.Text, sql, null);
            return rowAffected;
        }

        /// <summary>
        /// 根据编号获取抵债信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CreditInfo GetCreditInfoById(int id)
        {
            string sql = "SELECT * FROM CreditInfo WHERE CreditId = @Id";
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@Id",id),
            };
            CreditInfo info = null;

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                if (reader.Read())
                {
                    info = new CreditInfo();

                    info.CreditId = id;
                    info.Title = reader["Title"].ToString();
                    info.Age = reader["Age"].ToString();
                    info.ApprovaStatus = Core.MyConvert.GetInt32(reader["ApprovaStatus"].ToString());
                    info.AreaId = Core.MyConvert.GetInt32(reader["AreaId"].ToString());
                    info.Arrears = Core.MyConvert.GetDecimal(reader["Arrears"].ToString());
                    info.Bounty = Core.MyConvert.GetDecimal(reader["Bounty"].ToString());
                    info.CollectionPeriod = reader["CollectionPeriod"].ToString();
                    info.CreateDate = Core.MyConvert.GetDateTime(reader["CreateDate"].ToString());
                    info.DebtObligation = reader["DebtObligation"].ToString();
                    info.DebtorName = reader["DebtorName"].ToString();
                    info.DebtorReason = reader["DebtorReason"].ToString();
                    info.DebtorTelpone = reader["DebtorTelpone"].ToString();
                    info.DebtorType = reader["DebtorType"].ToString();
                    info.DepartId = Core.MyConvert.GetInt32(reader["DepartId"].ToString());
                    info.Introduction = reader["Introduction"].ToString();
                    info.IsConfirm = Core.MyConvert.GetBoolean(reader["IsConfirm"].ToString());
                    info.IsCreditEvaluation = Core.MyConvert.GetBoolean(reader["IsCreditEvaluation"].ToString());
                    info.IsInLitigation = Core.MyConvert.GetBoolean(reader["IsInLitigation"].ToString());
                    info.IsLitigationed = Core.MyConvert.GetBoolean(reader["IsLitigationed"].ToString());
                    info.IsSelfCollection = Core.MyConvert.GetBoolean(reader["IsSelfCollection"].ToString());
                    info.IsServerEvaluation = Core.MyConvert.GetBoolean(reader["IsServerEvaluation"].ToString());
                    info.IsCreditEvaluation = Core.MyConvert.GetBoolean(reader["IsCreditEvaluation"].ToString());
                    info.LicenseType = reader["LicenseType"].ToString();
                    info.PassDate = Core.MyConvert.GetDateTime(reader["PassDate"].ToString());
                    info.Remark = reader["Remark"].ToString();
                    info.UserId = Core.MyConvert.GetInt32(reader["UserId"].ToString());
                }
            }
            return info;
        }

        /// <summary>
        /// 根据债权信息编号以及是否服务商修改债权信息是否被评价
        /// </summary>
        /// <param name="credId"></param>
        /// <param name="isServer"></param>
        /// <returns></returns>
        public int UpdateEvaluationByCredId(int credId, bool isServer)
        {
            string sql = string.Empty;
            if (isServer)
            {
                sql = "update creditinfo set IsServerEvaluation = 'True' where CreditId = " + credId;
            }
            else
            {
                sql = "update creditinfo set IsCreditEvaluation = 'True' where CreditId = " + credId;
            }
            int rowAffected = SqlHelper.ExecuteNonQuery(CommandType.Text, sql, null);
            return rowAffected;
        }
    }
}
