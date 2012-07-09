using System;
using System.Collections.Generic;
using System.Text;
using XYECOM.Core.Data;
using System.Data.SqlClient;
using System.Data;
using XYECOM.SQLServer;
using XYECOM.Core;

namespace XYECOM.SQLServer
{
    public class PaymentPassWordMistake
    {
        #region 添加用户输入错误支付密码
        /// <summary>
        ///  添加用户输入错误支付密码
        /// </summary>
        /// <param name="PInfo">支付密码错误信息对象</param>
        /// <returns>数字，大于或等于0表示添加成功</returns>
        public int Insert(XYECOM.Model.PaymentPassWordMistake PInfo)
        {
            string sql = "";

            SqlParameter[] prarm = new SqlParameter[]
            {
                new SqlParameter("@UserId",PInfo.UserId),
                new SqlParameter("@LockTime",PInfo.LockTime),
                new SqlParameter("@MistakeNum",PInfo.MistakeNum)
            
            };

            sql += "INSERT INTO XY_PaymentPassWordMistake (UserId,LockTime,MistakeNum) ";
            sql += "VALUES (@UserId,@LockTime,@MistakeNum)";

            int rowAffected = Core.Data.SqlHelper.ExecuteNonQuery(CommandType.Text, sql, prarm);

            return rowAffected;
        }
        #endregion

        /// <summary>
        /// 根据用户Id删除数据
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public int Delete(int UserId)
        {
            string sql = "DELETE XY_PaymentPassWordMistake WHERE UserId=" + UserId;

            int i = XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(sql);

            return i;
        }

        /// <summary>
        /// 获取对象
        /// </summary>
        /// <param name="UserId">用户Id</param>
        /// <returns></returns>
        public Model.PaymentPassWordMistake GetItem(int UserId)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," Where UserId=" + UserId),
                new SqlParameter("@strTableName","XY_PaymentPassWordMistake"),
                new SqlParameter("@strOrder","")
            };

            XYECOM.Model.PaymentPassWordMistake PInfo = null;

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (reader.Read())
                {
                    PInfo = new XYECOM.Model.PaymentPassWordMistake();

                    PInfo.UserId = XYECOM.Core.MyConvert.GetInt32(reader["UserId"].ToString());
                    PInfo.LockTime = XYECOM.Core.MyConvert.GetDateTime(reader["LockTime"].ToString());
                    PInfo.MistakeNum = XYECOM.Core.MyConvert.GetInt32(reader["MistakeNum"].ToString());
                }
            }
            return PInfo;
        }

        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="PInfo">数据对象</param>
        /// <returns>受影响行数</returns>
        public int Update(XYECOM.Model.PaymentPassWordMistake PInfo)
        {
            string cmdText = "Update XY_PaymentPassWordMistake set LockTime = @LockTime,MistakeNum = @MistakeNum where UserId = @UserId";

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@UserId",PInfo.UserId),
                new SqlParameter("@LockTime",PInfo.LockTime),
                new SqlParameter("@MistakeNum",PInfo.MistakeNum),
            };

            int i = XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.Text, cmdText, param);
            return i;
        }
    }
}
