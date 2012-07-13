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
    }
}
