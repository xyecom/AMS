using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace XYECOM.Business
{
    /// <summary>
    /// 地区数据操作业务类
    /// </summary>
    public class Area
    {
        private XYECOM.SQLServer.Area DAL = new XYECOM.SQLServer.Area();

        /// <summary>
        /// 返回地区数据
        /// </summary>
        /// <param name="areaID">地区Id</param>
        /// <returns>无数据返回null</returns>
        public XYECOM.Model.AreaInfo GetItem(int areaID)
        {
            if (areaID <= 0) return null;

            return DAL.GetItem(areaID);
        }

        /// <summary>
        /// 获取指定Id集合的多个地区信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public List<Model.AreaInfo> GetItemsByIDs(string ids)
        {
            return DAL.GetItemsByIDs(ids);
        }

        /// <summary>
        /// 把指定Id集合的多个地区信息拼写成字符串
        /// </summary>
        /// <param name="ids">地区信息Id</param>
        /// <returns>指定Id集合的多个地区拼写成的字符串</returns>
        public string GetNamesByIDs(string ids)
        {
            if (string.IsNullOrEmpty(ids)) return "";

            List<Model.AreaInfo> list = GetItemsByIDs(ids);

            string names = "";

            foreach (Model.AreaInfo info in list)
            {
                if (names.Equals(""))
                    names = info.Name;
                else
                    names += "," + info.Name;
            }

            return names;
        }

        /// <summary>
        /// 返回子级地区集合
        /// </summary>
        /// <param name="parentID">父级Id</param>
        /// <returns>无数据返回空集合</returns>
        public List<Model.AreaInfo> GetItems(int parentID)
        {
            //如果parentId小于0则返回空集合
            if (parentID < 0)
                return new List<XYECOM.Model.AreaInfo>();

            return DAL.GetItems(parentID);
        }

        /// <summary>
        /// 插入地区信息
        /// </summary>
        /// <param name="info">信息数据实体</param>
        /// <returns>大于 0插入成功，小于等于0插入失败</returns>
        public int Insert(XYECOM.Model.AreaInfo info)
        {
            if (info == null) return 0;

            return DAL.Insert(info);
        }

        /// <summary>
        /// 更新地区信息
        /// </summary>
        /// <param name="info">信息数据实体</param>
        /// <returns>大于 0 更新成功，小于等于0更新失败</returns>
        public int Update(XYECOM.Model.AreaInfo info)
        {
            if (info == null) return 0;

            return DAL.Update(info);
        }

        /// <summary>
        /// 删除地区信息
        /// </summary>
        /// <param name="areaID">地区Id</param>
        /// <returns>大于 0 删除成功，小于等于0删除失败</returns>
        public int Delete(string areaID)
        {
            if (string.IsNullOrEmpty(areaID)
                || areaID.Equals(""))
                return 0;

            return DAL.Delete(areaID);
        }

        /// <summary>
        /// 判断是否有下级地区
        /// </summary>
        /// <param name="parentID">父级Id</param>
        /// <returns>true:有子级 false:无子级</returns>
        public bool HasSubArea(int parentID)
        {
            if (parentID < 0) return false;

            return DAL.HasSubArea(parentID);
        }

        /// <summary>
        /// 获取子地区ID
        /// </summary>
        /// <param name="areaId">父级Id</param>
        /// <returns></returns>
        public string GetSubIds(int areaId)
        {
            if (areaId <= 0) return "";

            Model.AreaInfo info = GetItem(areaId);

            if (info == null) return "";

            return DAL.GetSubIds(areaId);
        }
    }
}
