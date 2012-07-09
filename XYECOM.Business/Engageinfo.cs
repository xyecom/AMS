using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace XYECOM.Business
{
    /// <summary>
    /// 招聘信息业务类
    /// </summary>
    public class Engageinfo
    {

        private static readonly XYECOM.SQLServer.Engageinfo DAL = new XYECOM.SQLServer.Engageinfo();
        /// <summary>
        /// 添加招聘信息
        /// </summary>
        /// <param name="E">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Insert(XYECOM.Model.Engageinfo E, out long esid)
        {
            return DAL.Insert(E, out esid);
        }
        /// <summary>
        /// 修改招聘信息
        /// </summary>
        /// <param name="E">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Update(XYECOM.Model.Engageinfo E)
        {
            return DAL.Update(E);
        }
        /// <summary>
        /// 删除多条记录
        /// </summary>
        /// <param name="EI_ID">记录编号</param>
        /// <returns>受影响的行数</returns>
        public int Delete(string ID)
        {
            return DAL.Delete(ID);
        }
        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="SD_ID">记录编号</param>
        /// <returns>一条记录</returns>
        public XYECOM.Model.Engageinfo GetItem(long JobId)
        {
            if (JobId <= 0) return null;

            return DAL.GetItem(JobId);
        }

        #region   显示一条招聘信息
        /// <summary>
        /// 显示一条招聘信息
        /// </summary>
        /// <param name="EI_ID">招聘信息编号</param>
        /// <returns>一条招聘信息</returns>
        public DataTable GetDataTable(long EI_ID)
        {
            return DAL.GetDataTable(EI_ID);
        }
        #endregion

        #region 修改推荐
        /// <summary>
        /// 修改推荐
        /// </summary>
        /// <param name="EI_ID">信息编号</param>
        /// <param name="Vouch">是否推荐</param>
        /// <returns>影响行数</returns>
        public int UpdateVouch(long EI_ID, bool Vouch)
        {
            return DAL.UpdateVouch(EI_ID, Vouch);
        }
        #endregion
    }
}
