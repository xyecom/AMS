using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Business
{
    /// <summary>
    /// 分类标签业务类
    /// </summary>
    public class ClassLabel
    {
        private static readonly XYECOM.SQLServer.ClassLabel DAL = new XYECOM.SQLServer.ClassLabel();
        /// <summary>
        /// 根据分类标签名称获取分类标签实体对象
        /// </summary>
        /// <param name="labelName">分类标签名称</param>
        /// <returns>分类标签实体对象</returns>
        public Model.ClassLabelInfo GetItem(string labelName)
        {
            if (String.IsNullOrEmpty(labelName) || labelName == "") return null;

            return DAL.GetItem(labelName);
        }

        public XYECOM.Model.ClassLabelInfo GetItem(int labelId)
        {
            return DAL.GetItem(labelId);
        }

        public int Update(XYECOM.Model.ClassLabelInfo info)
        {
            return DAL.Update(info);
        }

        public int Insert(XYECOM.Model.ClassLabelInfo info)
        {
            return DAL.Insert(info);
        }

        public int Delete(int p)
        {
            return DAL.Delete(p);
        }

        public bool IsExists(string p)
        {
            return DAL.IsExists(p);
        }
    }
}
