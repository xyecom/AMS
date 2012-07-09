using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace XYECOM.Business
{

    /// <summary>
    /// 产品类型业务类
    /// </summary>
    public class ProductType
    {
        private static readonly XYECOM.SQLServer.ProductType DAL = new XYECOM.SQLServer.ProductType();

        /// <summary>
        /// 添加产品类型
        /// </summary>
        /// <param name="ea">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Insert(XYECOM.Model.ProductTypeInfo info)
        {
            if (info == null) return 0;

            return DAL.Insert(info);
        }

        /// <summary>
        /// 修改产品类型信息
        /// </summary>
        /// <param name="info">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Update(XYECOM.Model.ProductTypeInfo info)
        {
            if (info == null) return 0;

            int result = DAL.Update(info);

            if (result > 0)
            {
                string subIds = XYECOM.Business.XYClass.GetSubIds(info.ModuleName, info.PT_ID);

                subIds = Core.Utils.AppendComma(subIds);

                subIds = subIds.Replace("," + info.PT_ID + ",", ",").Replace(",,", ",");

                subIds = Core.Utils.RemoveComma(subIds);

                XYECOM.SQLServer.Utils.UpdateColumuByWhere("TradeId", info.TradeId.ToString(), " where PT_ID in(" + subIds + ")", "b_ProductType");
            }

            return result;
        }

        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="PT_ID">记录编号</param>
        /// <returns>一条记录</returns>
        public XYECOM.Model.ProductTypeInfo GetItem(long PT_ID)
        {
            if (PT_ID <= 0) return null;

            return DAL.GetItem(PT_ID);
        }

        /// <summary>
        /// 根据分类编号获取该编号的分类及该编号分类下的有所分类
        /// </summary>
        /// <param name="parentId">分类编号</param>
        /// <returns>分类集合</returns>
        public List<Model.ProductTypeInfo> GetItems(int parentId)
        {
            if (parentId < 0)
            {
                return null;
            }
            return DAL.GetItems(parentId);
        }


        /// <summary>
        /// 通过唯一标识名获取分类信息
        /// </summary>
        /// <param name="flagName">唯一标示名</param>
        /// <returns>实体对象</returns>
        public XYECOM.Model.ProductTypeInfo GetItemByFlagName(string flagName)
        {
            if (string.IsNullOrEmpty(flagName) || flagName.Trim().Equals("")) return null;

            return DAL.GetItemByFlagName(flagName);
        }

        /// <summary>
        /// 返回所有分类对象集合
        /// </summary>
        /// <returns>所有分类对象集合</returns>
        public List<Model.ProductTypeInfo> GetItems()
        {
            return DAL.GetItems();
        }

        /// <summary>
        /// 获取产品类型信息
        /// </summary>
        /// <param name="PT_ParentID">
        /// 如果 PT_ParentID 大于等于 0 返回部分产品类型信息
        /// 否则 返回所有的产品类型信息
        /// </param>
        /// <returns>多条产品类型信息</returns>
        public DataTable GetDataTable(long PT_ParentID)
        {
            return DAL.GetDataTable(PT_ParentID);
        }

        /// <summary>
        /// 获取指定产品类型信息
        /// </summary>
        /// <param name="PT_IDs">产品编号</param>
        /// <returns>DataTable</returns>
        public DataTable GetDataTable(string PT_IDs)
        {
            return DAL.GetDataTable(PT_IDs);
        }

        /// <summary>
        /// 获取指定产品类型信息
        /// </summary>
        /// <param name="PT_IDs">产品编号</param>
        /// <param name="M_ID">模块编号</param>
        /// <returns>DataTable</returns>
        public DataTable GetDataTable(long PT_ParentID, string moduleName)
        {
            return DAL.GetDataTable(PT_ParentID, moduleName);
        }


        /// <summary>
        /// 删除一条产品类型信息
        /// </summary>
        /// <param name="PT_ID">类型编号</param>
        /// <returns>受影响的行数</returns>
        public int Delete(string PT_ID)
        {
            return DAL.Delete(PT_ID);
        }

        /// <summary>
        /// 获取当前分类是第几级
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public int GetStep(long typeId)
        {
            Model.ProductTypeInfo info = GetItem(typeId);

            if (info == null) return 0;

            if (info.PT_ParentID == 0) return 1;

            string fullId = Core.Utils.RemoveComma(info.FullId);

            string[] ids = fullId.Split(',');

            return ids.Length + 1;
        }


        public XYECOM.Model.ProductTypeInfo GetItemByTypeName(string keyword)
        {
            Model.ProductTypeInfo info = null;
            if (!string.IsNullOrEmpty(keyword))
            {
                info = DAL.GetItemByTypeName(keyword);
            }
            return info;
        }

        /// <summary>
        /// 通过分类ID获取该分类信息 （王振添加 2011-03-30）
        /// </summary>
        /// <param name="id">分类Id</param>
        /// <returns>分类信息</returns>
        public Model.ProductTypeInfo GetProTypeById(int id)
        {
            if (id < 0)
            {
                return null;
            }
            return DAL.GetProTypeById(id);
        }

        /// <summary>
        /// 通过分类编号获取选择的分类以及所以父级的分类名称 （王振添加 2011-03-30）
        /// </summary>
        /// <param name="typeId">分类编号</param>
        /// <returns>先关分类名称</returns>
        public string GetProductTypeNameByTypeId(int typeId)
        {
            if (typeId < 0)
            {
                return string.Empty;
            }
            return DAL.GetProductTypeNameByTypeId(typeId);
        }
    }
}
