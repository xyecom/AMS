using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using XYECOM.Core.Data;
using XYECOM.Core;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// Gift的数据访问类
    /// </summary>
    public class Gift
    {
        #region 增加礼品
        /// <summary>
        /// 添加礼品
        /// </summary>
        /// <param name="giftInfo">礼品属性类对象</param>
        /// <returns>数字。大于等于0表示添加成功</returns>
        public int Insert(XYECOM.Model.GiftInfo giftInfo, out short gId)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
				    new SqlParameter("@GId",SqlDbType.Int),
                    new SqlParameter ("@Name",giftInfo.Name),
                    new  SqlParameter ("@Amount",giftInfo.Amount ),
                    new SqlParameter ("@GradeIds",giftInfo.GradeIds),

                    new SqlParameter("@Number",giftInfo.Number)                    
                };

            parm[0].Direction = ParameterDirection.Output;
            int err = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertGift", parm);
            
            gId = XYECOM.Core.MyConvert.GetInt16(parm[0].Value.ToString());
            return err;
        }
        #endregion

        #region 修改礼物
        /// <summary>
        /// 修改礼物
        /// </summary>
        /// <param name="gi">礼物属性类对象</param>
        /// <returns>数字。大于等于0表示修改成功</returns>
        public int Update(XYECOM.Model.GiftInfo gi)
        {
            SqlParameter[] parm = new SqlParameter[]{
                new SqlParameter("@GId",gi.GId),
                new SqlParameter ("@Name",gi.Name),
                new  SqlParameter ("@Amount",gi.Amount),
                new SqlParameter ("@GradeIds",gi.GradeIds),
                new SqlParameter("@Number",gi.Number)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateGift", parm);
        }

        #endregion

        #region 删除礼品
        /// <summary>
        /// 删除多条礼品记录
        /// </summary>
        /// <param name="FL_IDs">礼品编号字符串</param>
        /// <returns>数字。大于等于0表示删除成功</returns>
        public int Delete(string GIds)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@GIds",GIds)                
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("XYP_DeleteGift", param);
        }
        #endregion

        #region 获取礼品
        /// <summary>
        /// 获取礼品
        /// </summary>
        /// <param name="FL_ID">礼品编号</param>
        /// <returns>礼品属性类对象</returns>
        public XYECOM.Model.GiftInfo GetItem(short GId)
        {

            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter ("@strWhere","where GId=" + GId.ToString()),
                new SqlParameter ("@strTableName","XY_Gift"),
                new SqlParameter("@strOrder"," order by GId DESC ")
            };

            XYECOM.Model.GiftInfo giftInfo = null;

            using (SqlDataReader dr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", parm))
            {
                if (dr.Read())
                {
                    giftInfo = new XYECOM.Model.GiftInfo();

                    giftInfo.GId = GId;
                    giftInfo.Name = dr["Name"].ToString();                    
                    giftInfo.Amount = MyConvert.GetInt32(dr["Amount"].ToString());
                    giftInfo.GradeIds = dr["GradeIds"].ToString();
                    giftInfo.Number = MyConvert.GetInt32(dr["Number"].ToString());
                }
            }
            return giftInfo;
        }
        #endregion

        #region 获取指定条件和排序规则的数据

        /// <summary>
        /// 获取指定条件和排序规则的数据
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <param name="strOrderBy">排序规则</param>
        /// <returns></returns>
        public DataTable GetDataTable(string strWhere, string strOrderBy)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere",strWhere),
                new SqlParameter("@strTableName","XY_Gift"),
                new SqlParameter("@strOrder",strOrderBy)
            };
            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "XYP_SelectByWhere", param);
        }
        #endregion
    }
}
