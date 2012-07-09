using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace XYECOM.Business
{
    /// <summary>
    /// 留言业务类
    /// </summary>
    public class Message
    {
        private static readonly XYECOM.SQLServer.Message DAL = new XYECOM.SQLServer.Message();

        /// <summary>
        /// 添加留言信息
        /// </summary>
        /// <param name="ea">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Insert(XYECOM.Model.MessageInfo em)
        {
            return DAL.Insert(em);
        }


        /// <summary>
        /// 修改留言信息
        /// </summary>
        /// <param name="ea">实体类</param>
        /// <returns>受影响的行数</returns>
        public int UpdateMess(long M_ID)
        {
            return DAL.UpdateMess(M_ID);
        }

        /// <summary>
        /// 修改留言信息查看状态
        /// </summary>
        /// <param name="ea">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Update(long M_ID)
        {
            return DAL.Update(M_ID);
        }

        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="M_ID">记录编号</param>
        /// <returns>一条记录</returns>
        public XYECOM.Model.MessageInfo GetItem(long M_ID)
        {
            return DAL.GetItem(M_ID);                
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="M_ID">记录编号</param>
        /// <returns>受影响的行数</returns>
        public int Delete(long M_ID)
        {
            return DAL.Delete(M_ID);
        }

        /// <summary>
        /// 删除多条记录
        /// </summary>
        /// <param name="M_ID">记录编号集合</param>
        /// <returns>影响行数</returns>
        public int Deletes(string M_ID)
        {
            return DAL.Deletes(M_ID);
        }
      
    }
}
