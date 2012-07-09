using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
namespace XYECOM.Business
{
    /// <summary>
    /// 供求信息业务类
    /// </summary>
    public class Supply
    {
        private static readonly XYECOM.SQLServer.Supply DAL = new XYECOM.SQLServer.Supply();
        /// <summary>
        /// 添加管理员信息
        /// </summary>
        /// <param name="ea">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Insert(XYECOM.Model.SupplyInfo info, out int infoId)
        {
            infoId = 0;

            if (info == null) return 0;

            return DAL.Insert(info, out infoId);
        }

        /// <summary>
        /// 修改供应信息
        /// </summary>
        /// <param name="ea">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Update(XYECOM.Model.SupplyInfo es)
        {
            return DAL.Update(es);
        }

        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="SD_ID">记录编号</param>
        /// <returns>一条记录</returns>
        public XYECOM.Model.SupplyInfo GetItem(int SD_ID)
        {
            return DAL.GetItem(SD_ID);
        }


       
        /// <summary>
        /// 获取多条记录
        /// </summary>
        /// <param name="Ｕ_ID">条件查询</param>
        /// <returns>多条记录</returns>
        public DataTable GetDataTable(long U_ID)
        {
            return DAL.GetDataTable(U_ID);
        }
        /// <summary>
        /// 删除一条供求信息
        /// </summary>
        /// <param name="SD_ID">记录编号</param>
        /// <returns>受影响的行数</returns>
        public int Delete(long supplyId)
        {
            new XYECOM.Business.Attachment().Delete(supplyId, XYECOM.Model.AttachmentItem.Supply, XYECOM.Model.UploadFileType.All);

            return DAL.Delete(supplyId);
        }

        /// <summary>
        /// 删除多条记录
        /// </summary>
        /// <param name="SD_ID">记录编号</param>
        /// <returns>受影响的行数</returns>
        public int Deletes(string ids)
        {
            Business.Attachment attBLL = new Attachment();

            attBLL.Delete(ids, XYECOM.Model.AttachmentItem.Supply, XYECOM.Model.UploadFileType.All);

            return DAL.Deletes(ids);

        }
        /// <summary>
        /// 修改推荐信息
        /// </summary>
        /// <param name="es">实体类</param>
        /// <returns>受影响的行数</returns>
        public int UpdateVouch(XYECOM.Model.SupplyInfo es)
        {
            return DAL.UpdateVouch(es);
        }
        /// <summary>
        /// 修改暂停信息
        /// </summary>
        /// <param name="SD_ID">编号</param>
        /// <returns></returns>
        public int UpdatePause(string SD_ID)
        {
            return DAL.UpdatePause(SD_ID);
        }

        #region 批量移动
        /// <summary>
        /// 批量移动
        /// </summary>
        /// <returns>影响行数</returns>
        public int MoveSupply(String strwhere, String content)
        {
            return DAL.MoveSupply(strwhere, content);
        }
        #endregion

        /// <summary>
        /// 根据产品编号获取该产品的详细信息（王振添加 2011-03-30）
        /// </summary>
        /// <param name="id">产品ID</param>
        /// <returns>产品的详细信息</returns>
        public XYECOM.Model.SupplyInfo GetSupplyById(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            return DAL.GetSupplyById(id);
        }
        /// <summary>
        /// 根据品牌id 获取该id被引用的产品数
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns></returns>
        public int GetBrandSupplyForBrandId(int brandId)
        {
            return DAL.GetBrandSupplyForBrandId(brandId);
        }
           /// <summary>
        /// 根据计量id 获取该id被引用的产品数
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns></returns>
        public int GetBrandSupplyForUnitId(int UnitId)
        {
            return DAL.GetBrandSupplyForUnitId(UnitId);
        }
        /// <summary>
        /// 新增一条产品信息 (王振添加 2011-04-01)
        /// </summary>
        /// <param name="supply">产品信息</param>
        /// <param name="id">新增的产品ID</param>
        /// <returns>返回新增的产品ID</returns>
        public int InsertSupply(Model.SupplyInfo supply, out int infoId)
        {
            infoId = 0;
            if (supply != null)
            {
                return DAL.InsertSupply(supply, out infoId);
            }
            return 0;
        }

        /// <summary>
        /// 根据产品编号修改产品信息 (王振添加2011-04-01)
        /// </summary>
        /// <param name="supply">产品信息</param>
        /// <returns>受影响的行数</returns>
        public int UpdateSupply(Model.SupplyInfo supply)
        {
            if (supply == null || supply.InfoID < 1)
            {
                return 0;
            }
            return DAL.UpdateSupply(supply);
        }


        /// <summary>
        /// 设置会员商机信息暂停 (王振添加 2011-04-07)
        /// </summary>
        /// <param name="lstId">商机编号集合</param>
        /// <param name="state">状态 true为启用，false停用</param>
        /// <returns>返回影响行数</returns>
        public int UpdateSupplyState(string lstId, bool state)
        {
            if (string.IsNullOrEmpty(lstId))
            {
                return 0;
            }
            return DAL.UpdateSupplyState(lstId, state);
        }

        /// <summary>
        /// 推荐会员商机信息至网店,或从网店取消推荐  (王振添加 2011-04-07)
        /// </summary>
        /// <param name="lstId">商机编号集合</param>
        /// <param name="state">状态 true为推荐，false取消推荐</param>
        /// <returns>返回影响行数</returns>
        public int RecommendToShop(string lstId, bool state)
        {
            if (string.IsNullOrEmpty(lstId))
            {
                return 0;
            }
            return DAL.RecommendToShop(lstId, state);
        }

        /// <summary>
        /// 刷新会员的商机信息 (王振添加 2011-04-07)
        /// </summary>        
        /// <param name="lstId">商机编号集合</param>
        /// <returns>返回影响行数</returns>
        public int ReSendInfo(string lstId)
        {
            if (string.IsNullOrEmpty(lstId))
            {
                return 0;
            }
            return DAL.ReSendInfo(lstId);
        }

        /// <summary>
        /// 根据产品编号逻辑删除产品信息 (王振添加 2011-04-07)
        /// </summary>
        /// <param name="lstId">产品编号</param>
        /// <returns>受影响的行数</returns>
        public int UpdateDeleteById(string lstId)
        {
            if (string.IsNullOrEmpty(lstId))
            {
                return 0;
            }
            return DAL.UpdateDeleteById(lstId);
        }

        /// <summary>
        /// 根据购买数量和当前产品的价格区间计算出当前价 (王振添加 2011-04-07)
        /// </summary>
        /// <param name="proCount">购买的产品个数</param>
        /// <param name="pid">产品ID</param>
        /// <returns>当前的价格</returns>
        public decimal GetProductPrice(int pid, int proCount)
        {
            if (pid <= 0 || proCount <= 0)
            {
                return 0;
            }
            return DAL.GetProductPrice(pid, proCount);
        }

        /// <summary>
        /// 根据购买数量和当前产品的价格区间计算出当前价格区间 (王振添加 2011-04-11)
        /// </summary>
        /// <param name="proCount">购买的产品个数</param>
        /// <param name="pid">产品ID</param>
        /// <returns>当前的价格区间</returns>
        public int GetProductOrderNum(int pid, int proCount)
        {
            if (pid <= 0 || proCount <= 0)
            {
                return 0;
            }
            return DAL.GetProductOrderNum(pid, proCount);
        }

        /// <summary>
        /// 根据产品编号获取该产品的最少起订量（王振添加 2011-04-13）
        /// </summary>
        /// <param name="supplyId">产品ID</param>
        /// <returns>最少起订量</returns>
        public int GetSmallNum(int supplyId)
        {
            if (supplyId <= 0)
            {
                return 0;
            }
            return DAL.GetSmallNum(supplyId);
        }

        /// <summary>
        ///根据产品编号获取产品名称
        /// </summary>
        /// <param name="suppid">产品编号</param>
        /// <returns>产品名称</returns>
        public string GetSupplyNameById(int suppid)
        {
            if (suppid <= 0)
            {
                return string.Empty;
            }
            return DAL.GetSupplyNameById(suppid);
        }

        /// <summary>
        /// 根据一组产品编号，获取这些产品所支持的货运方式
        /// </summary>
        /// <param name="productIds">产品编号集合</param>        
        /// <returns></returns>
        public DataTable GetProductsSupportLogisticsTypesByProductIds(string productIds)
        {
            return DAL.GetProductsSupportLogisticsTypesByProductIds(productIds);
        }

        /// <summary>
        /// 产品的挂牌操作
        /// </summary>
        /// <param name="supplyId">产品ID</param>
        /// <param name="count">挂牌量</param>
        /// <param name="ispayBail">挂牌的状态（0不挂牌 ，1挂牌）</param>
        /// <returns>受影响的行数</returns>
        public int UpdateIsPayBailById(int supplyId, int count, bool ispayBail, decimal MarginRefund)
        {
            if (supplyId <= 0||count<=0)
            {
                return 0;
            }
            return DAL.UpdateIsPayBailById(supplyId,count,ispayBail,MarginRefund);
        }

        /// <summary>
        /// 根据产品编号跟新产品的库存量，挂牌量，锁定量
        /// </summary>
        /// <param name="supplyId">产品编号</param>
        /// <param name="count">产品数量</param>
        /// <returns>受影响的行数</returns>
        public int UpdateStocksAndLockById(int supplyId, int count)
        {
            if (supplyId <= 0 || count <= 0)
            {
                return 0;
            }
            return DAL.UpdateStocksAndLockById(supplyId, count);
        }

        /// <summary>
        /// 根据产品编号修改锁定量，累计销售量
        /// </summary>
        /// <param name="supplyId">产品编号</param>
        /// <param name="count">修改的锁定量</param>
        /// <returns>受影响的行数</returns>
        public int UpdateLockCountById(int supplyId, int count)
        {
            if (supplyId <= 0 || count <= 0)
            {
                return 0;
            }
            return DAL.UpdateLockCountById(supplyId, count);
        }
    }
}
