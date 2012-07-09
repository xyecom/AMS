using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using XYECOM.Model;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// 诚信指数数据处理类
    /// </summary>
    public class FaithSet
    {
        /// <summary>
        /// 添加诚信指数对象
        /// </summary>
        /// <param name="cn">添加诚信指数对象</param>
        /// <returns>数字,大于或等于0表成功,否则表失败</returns>
        public int Insert(FaithSetInfo fs)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@GF_Fath",fs.GF_Fath  ),
                new SqlParameter("@GF_Money",fs.GF_Money  ),
                new SqlParameter("@GF_ErrFath",fs.GF_FrrFath ),
                new SqlParameter("@GF_ErrMoney",fs.GF_ErrMoney ),
                new SqlParameter("@GF_Remark",fs.GF_Remark ),
                new SqlParameter("@HF_Fath",fs.HF_Fath ),
                new SqlParameter("@HF_Money",fs.HF_Money ),
                new SqlParameter("@HF_ErrFath",fs.HF_FrrFath ),
                new SqlParameter("@HF_ErrMoney",fs.UF_ErrMoney),
                new SqlParameter("@HF_Remark",fs.HF_Remark ),
                new SqlParameter("@UF_Fath",fs.UF_Fath ),
                new SqlParameter("@UF_Money",fs.UF_Money ),
                new SqlParameter("@UF_ErrFath",fs.UF_FrrFath ),
                new SqlParameter("@UF_ErrMoney",fs.UF_ErrMoney ),
                new SqlParameter("@UF_Remark",fs.UF_Remark ),
                new SqlParameter("@BF_Fath",fs.BF_Fath ),
                new SqlParameter("@BF_Money",fs.BF_Money  ),
                new SqlParameter("@BF_ErrFath",fs.BF_FrrFath ),
                new SqlParameter("@BF_ErrMoney",fs.BF_ErrMoney ),
                new SqlParameter("@BF_Remark",fs.BF_Remark ),
                new SqlParameter("@FS_Base",fs.FS_Base),              //增加基本项增加指数
                new SqlParameter("@FS_Hot",fs.FS_Hot),                //增加高级项增加指数
                new SqlParameter("@FS_Licence",fs.FS_Licence),        //上传营业执照增加指数
                new SqlParameter("@FS_Certificate",fs.FS_Certificate) //上传其他资质增加指数
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"XYP_InsertFaithset", param);
        }
        /// <summary>
        /// 修改诚信指数对象
        /// </summary>
        /// <param name="cn">修改诚信指数对象</param>
        /// <returns>数字,大于或等于0表成功,否则表失败</returns>
        public int Update(FaithSetInfo fs)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@F_ID",fs.F_ID),
                new SqlParameter("@GF_Fath",fs.GF_Fath  ),
                new SqlParameter("@GF_Money",fs.GF_Money  ),
                new SqlParameter("@GF_ErrFath",fs.GF_FrrFath ),
                new SqlParameter("@GF_ErrMoney",fs.GF_ErrMoney ),
                new SqlParameter("@GF_Remark",fs.GF_Remark ),
                new SqlParameter("@HF_Fath",fs.HF_Fath ),
                new SqlParameter("@HF_Money",fs.HF_Money ),
                new SqlParameter("@HF_ErrFath",fs.HF_FrrFath ),
                new SqlParameter("@HF_ErrMoney",fs.HF_ErrMoney ),
                new SqlParameter("@HF_Remark",fs.HF_Remark ),
                new SqlParameter("@UF_Fath",fs.UF_Fath ),
                new SqlParameter("@UF_Money",fs.UF_Money ),
                new SqlParameter("@UF_ErrFath",fs.UF_FrrFath ),
                new SqlParameter("@UF_ErrMoney",fs.UF_ErrMoney ),
                new SqlParameter("@UF_Remark",fs.UF_Remark ),
                new SqlParameter("@BF_Fath",fs.BF_Fath ),
                new SqlParameter("@BF_Money",fs.BF_Money  ),
                new SqlParameter("@BF_ErrFath",fs.BF_FrrFath ),
                new SqlParameter("@BF_ErrMoney",fs.BF_ErrMoney ),
                new SqlParameter("@BF_Remark",fs.BF_Remark ),
                new SqlParameter("@FS_Base",fs.FS_Base),              //增加基本项增加指数
                new SqlParameter("@FS_Hot",fs.FS_Hot),                //增加高级项增加指数
                new SqlParameter("@FS_Licence",fs.FS_Licence),        //上传营业执照增加指数
                new SqlParameter("@FS_Certificate",fs.FS_Certificate) //上传其他资质增加指数
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateFaithSet", param);
        }

        /// <summary>
        /// 删除指定诚信指数编号集的抽象方法
        /// </summary>
        /// <param name="kiids">要删除的诚信指数编号集</param>
        /// <returns>数字,大于或等于0表删除成功</returns>
        public int Delete(string kiids)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere","where F_ID in ("+kiids+")"),
                new SqlParameter("@strTableName","b_FaithSet")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }
        /// <summary>
        /// 获取满足指定条件的诚信指数对象的抽象方法
        /// </summary>
        /// <param name="strWhere">指定的strWhere条件</param>
        /// <param name="strOrderBy">指定的OrderBy条件</param>
        /// <returns>满足给定条件的诚信指数对象的数据集</returns>
        public  DataTable GetDataTable()
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere",""),
                new SqlParameter("@strTableName","b_FaithSet"),
                new SqlParameter("@strOrder","")
            };

            return XYECOM.Core.Data.SqlHelper.GetDataTable("XYP_SelectByWhere", param);
        }
    }
}
