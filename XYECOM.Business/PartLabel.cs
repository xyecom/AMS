using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Business
{
    /// <summary>
    /// 企业专题标签业务类
    /// </summary>
    public class PartLabel
    {
        private static readonly XYECOM.SQLServer.PartLabel DAL = new XYECOM.SQLServer.PartLabel();

        /// <summary>
        /// 插入专题标签
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int Insert(Model.PartLabelInfo info)
        {
            if (info == null) return 0;

            return DAL.Update(info);
        }

        /// <summary>
        /// 编辑专题标签
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int Update(Model.PartLabelInfo info)
        {
            if (info == null) return 0;

            return DAL.Update(info);
        }

        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="partId"></param>
        /// <returns></returns>
        public int Delete(int partId)
        {
            if (partId <= 0) return 0;

            return DAL.Delete(partId);
        }

        /// <summary>
        /// 根据标签名称获取对象
        /// </summary>
        /// <param name="labelName"></param>
        /// <returns></returns>
        public Model.PartLabelInfo GetItem(string labelName)
        {
            if (string.IsNullOrEmpty(labelName) || labelName.Trim().Equals("")) return null;

            return DAL.GetItem(labelName);
        }

        /// <summary>
        /// 根据标签Id获取对象
        /// </summary>
        /// <param name="partId">标签Id</param>
        /// <returns></returns>
        public Model.PartLabelInfo GetItem(int partId)
        {
            if (partId <= 0) return null;

            return DAL.GetItem(partId);
        }
    }
}
