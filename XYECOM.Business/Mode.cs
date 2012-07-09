using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace XYECOM.Business
{
    /// <summary>
    /// 经营模式业务类
    /// </summary>
    public class Mode
    {
        private static readonly XYECOM.SQLServer.Mode DAL = new XYECOM.SQLServer.Mode();

        /// <summary>
        /// 添加一条信息
        /// </summary>
        /// <param name="em">经营模式实体对象</param>
        /// <returns>影响行数</returns>
        public int Insert(XYECOM.Model.ModeInfo em)
        {
            return DAL.Insert(em);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="em">经营模式实体对象</param>
        /// <returns>影响行数</returns>
        public int Update(XYECOM.Model.ModeInfo em)
        {
            return DAL.Update(em);
        }
        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="UM_ID">记录编号</param>
        /// <returns>一条记录</returns>
        public XYECOM.Model.ModeInfo GetItem(int M_ID)
        {
            return DAL.GetItem(M_ID);
        }
        /// <summary>
        /// 获取所有记录
        /// </summary>
        /// <returns>记录集</returns>
        public  DataTable GetDataTable()
        {
            return DAL.GetDataTable();
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="UM_ID">记录编号</param>
        /// <returns>受影响的行数</returns>
        public int Delete(int M_ID)
        {
            return DAL.Delete(M_ID);
        }
    }
}
    
    
   

    
   

