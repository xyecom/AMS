using System;
using System.Collections.Generic;
using System.Text;
using XYECOM.Core.Data;
using System.Data .SqlClient ;
using System.Data;
using XYECOM.SQLServer;
using XYECOM.Core;

namespace XYECOM.SQLServer
{
   /// <summary>
   /// 企业经营模式数据处理类
   /// </summary>
    public class Mode:DataCache
    {
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <param name="info">数据对象</param>
        /// <returns>受影响行数</returns>
        public int Insert(XYECOM.Model.ModeInfo info)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter ("@M_Type",info.M_Type )
            };

            int result =  SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertMode", parm);

            UpdateCache();

            return result;
        }

        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="info">数据对象</param>
        /// <returns>受影响行数</returns>
        public int Update(XYECOM.Model.ModeInfo info)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter ("@M_Type",info .M_Type),
                new SqlParameter ("@M_ID",info .M_ID)
            };

            int result =  SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateMode", parm);

            UpdateCache();

            return result;
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="modeId">记录编号</param>
        /// <returns>受影响的行数</returns>
        public int Delete(int modeId)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where M_ID="+modeId.ToString()),
                new SqlParameter("@strTableName","b_Mode")
            };

            int result = XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);

            UpdateCache();

            return result;
        }

        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="modeId">记录编号</param>
        /// <returns>一条记录</returns>
        public XYECOM.Model.ModeInfo GetItem(int modeId)
        {
            XYECOM.Model.ModeInfo info = null;

            Object obj= GetCache();

            if (obj != null)
            {
                DataTable table = (DataTable)obj;

                DataRow[] rows = table.Select("M_ID =" + modeId.ToString());

                if (rows != null && rows.Length > 0)
                {
                    info = new XYECOM.Model.ModeInfo();
                    info.M_ID = Convert.ToInt32(rows[0]["M_ID"].ToString());
                    info.M_Type = rows[0]["M_Type"].ToString();
                }
            }

            return info;
        }
        /// <summary>
        /// 获取所有记录
        /// </summary>
        /// <returns>记录集</returns>
        public DataTable GetDataTable()
        {
            Object obj= GetCache();

            if (obj != null)
            {
                return (DataTable)obj;
            }

            return new DataTable();
        }

        /// <summary>
        /// 
        /// </summary>
        public override string SQL_Get_All
        {
            get { return "select * from b_Mode"; }
        }
    }
}
    
    
   

    
   

