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
    /// 评价数据访问类
    /// </summary>
    public class EvaluationAccess
    {
        /// <summary>
        /// 新增评价信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int InsertEvaluation(Evaluation info)
        {
            string sql = @"Insert Into Evaluation (userid,UserName,User2Id,User2Name,Evaluation,Description,CreditInfoID)
                         values (@UserId,@UserName,@User2Id,@User2Name,@EvaluationResult,@Description,@CreditInfoID)";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@UserId",info.UserId),
                new SqlParameter("@UserName",info.UserName),
                new SqlParameter("@User2Id",info.User2Id),
                new SqlParameter("@User2Name",info.User2Name),
                new SqlParameter("@EvaluationResult",info.EvaluationResult),
                new SqlParameter("@Description",info.Description),
                new SqlParameter("@CreditInfoID",info.CreditInfoId)
            };
            int rowAffected = SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
            return rowAffected;
        }
    }
}
