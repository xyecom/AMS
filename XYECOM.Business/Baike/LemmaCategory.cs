//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// author: 苟波涛
// create date：2009-12-10 20:32:46
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data;

namespace XYECOM.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class LemmaCategory
    {
		private static readonly XYECOM.SQLServer.LemmaCategory DAL = new XYECOM.SQLServer.LemmaCategory();
		
        /// <summary>
        /// 添加百科分类
        /// </summary>
        /// <param name="info">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Insert(XYECOM.Model.LemmaCategoryInfo info)
        {
			if (info == null) return 0;
            return DAL.Insert(info);
        }

        /// <summary>
        /// 修改百科分类
        /// </summary>
        /// <param name="info">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Update(XYECOM.Model.LemmaCategoryInfo info)
        {
			if (info == null) return 0;
            return DAL.Update(info);
        }

        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="infoId">记录编号</param>
        /// <returns>一条记录</returns>
        public XYECOM.Model.LemmaCategoryInfo  GetItem(int infoId)
        {
			if (infoId <= 0) return null;
            return DAL.GetItem(infoId);
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="infoId">记录编号</param>
        /// <returns>受影响的行数</returns>
        public int Delete(string  infoId)
        {
			if (String.IsNullOrEmpty(infoId)) return 0;
            return DAL.Delete(infoId);
        }
		
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
		public DataTable GetList()
		{
			 return DAL.GetList();
		}
    }
}
