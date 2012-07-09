using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace XYECOM.Business
{
   public class SupplyBuy
    {
       XYECOM.SQLServer.SupplyBuy buy = new SQLServer.SupplyBuy();
         /// <summary>
        /// 插入信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
       public int Insert(XYECOM.Model.SupplyBuyInfo info)
       {
           return buy.Insert(info);
       }
          /// <summary>
        /// 更新一条信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
       public int Update(XYECOM.Model.SupplyBuyInfo info)
       {
           return buy.Update(info);
       }

           /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       public int Delete(long id)
       {
           return buy.Delete(id);
       }

         /// <summary>
        /// 删除操作(批量删除)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       public int Delete(string ids)
       {
           return buy.Delete(ids);
       }
          /// <summary>
        /// 获取一个信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       public XYECOM.Model.SupplyBuyInfo GetItem(long id)
       {
           return buy.GetItem(id);
       }
           /// <summary>
        /// 获取所有信息
        /// </summary>
        /// <returns></returns>
       public DataTable Select()
       {
           return buy.Select();
       }
    }
}
