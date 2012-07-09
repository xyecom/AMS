using System;
using System.Collections.Generic;
using System.Text;

using System.Data  ;
using System.Data.SqlClient;

namespace XYECOM.Business
{
    /// <summary>
    /// 财务类别业务类
    /// </summary>
    public  class FinanceType
    {
        private static readonly XYECOM.SQLServer.FinanceType DAL = new XYECOM.SQLServer.FinanceType();
        
        /// <summary>
        /// 添加财务类别
        /// </summary>
        /// <param name="et">财务类实体对象</param>
        /// <returns>影响行数</returns>
        public int Insert(XYECOM.Model.FinanceTypeInfo et)
        {
            return DAL.Insert(et);
        }
        /// <summary>
        /// 修改财务类别
        /// </summary>
        /// <param name="et">财务类实体对象</param>
        /// <returns>影响行数</returns>
        public int Update(XYECOM.Model.FinanceTypeInfo et)
        {
            return DAL.Update(et);        
        }

        /// <summary>
        /// 删除财务类别
        /// </summary>
        /// <param name="FT_ID">财务类别编号</param>
        /// <returns>影响行数</returns>
        public int Delete(int FT_ID)
        {
            return DAL.Delete(FT_ID);
        }

        /// <summary>
        /// 根据编号得到财务类别信息
        /// </summary>
        /// <param name="FT_ID">财务类别编号</param>
        /// <returns>财务类别实体对象</returns>
        public XYECOM .Model.FinanceTypeInfo  GetItem(int FT_ID)
        {
            return DAL.GetItem(FT_ID);
        }
        public DataTable GetDataTable()
        {
            return DAL.GetDataTable();
        }
    }
}
