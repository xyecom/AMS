using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using XYECOM.Model;

namespace XYECOM.Business
{
    /// <summary>
    /// 业务逻辑类Dissent的摘要说明。
    /// </summary>
    public class Dissent
    {
        private static readonly XYECOM.SQLServer.Dissent DAL = new XYECOM.SQLServer.Dissent();

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="info">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Insert(XYECOM.Model.DissentInfo info)
        {
            if (info == null) return 0;
            return DAL.Insert(info);
        }

        /// <summary>
        /// 插入实体并以输出参数的形式返回主键
        /// </summary>
        /// <param name="info">待插入的实体对象</param>
        /// <param name="infoId">以输出形式返回的主键</param>
        /// <returns>受影响的行数</returns>
        public int Insert(XYECOM.Model.DissentInfo info, out int infoId)
        {
            return DAL.Insert(info, out infoId);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="info">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Update(XYECOM.Model.DissentInfo info)
        {
            if (info == null) return 0;
            return DAL.Update(info);
        }

        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="infoId">记录编号</param>
        /// <returns>一条记录</returns>
        public XYECOM.Model.DissentInfo GetItem(int infoId)
        {
            if (infoId <= 0) return null;
            return DAL.GetItem(infoId);
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="infoId">记录编号</param>
        /// <returns>受影响的行数</returns>
        public int Delete(string infoId)
        {
            if (String.IsNullOrEmpty(infoId)) return 0;
            return DAL.Delete(infoId);
        }

        /// <summary>
        /// 获取所有列表
        /// </summary>        
        /// <returns>获取所有列表</returns>
        public DataTable GetList()
        {
            return DAL.GetList();
        }

        public DissentInfo GetItem(string orderid, string goodsorinvoice)
        {
            return DAL.GetItem(orderid, goodsorinvoice);
        }

        /// <summary>
        /// 根据订单编号，订单类型，异议类型获取异议信息
        /// </summary>
        /// <param name="orderid">订单编号</param>
        /// <param name="goodsorinvoice">异议类型</param>
        /// <param name="orderType">订单类型</param>
        /// <returns>异议信息</returns>
        public DissentInfo GetItem(string orderid, string goodsorinvoice,int orderType)
        {
            return DAL.GetItem(orderid, goodsorinvoice,orderType);
        }
    }
}
