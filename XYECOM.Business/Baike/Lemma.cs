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
    public class Lemma
    {
		private static readonly XYECOM.SQLServer.Lemma DAL = new XYECOM.SQLServer.Lemma();
		
        /// <summary>
        /// 修改词条
        /// </summary>
        /// <param name="info">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Update(XYECOM.Model.LemmaInfo info)
        {
			if (info == null) return 0;
            return DAL.Update(info);
        }

        /// <summary>
        /// 新增临时词条，输出主键
        /// </summary>
        /// <param name="info">临时词条</param>
        /// <param name="pk">主键输出参数</param>
        /// <returns>返回影响行数</returns>
        public int Insert(XYECOM.Model.LemmaInfo info, out long pk)
        {
            return DAL.Insert(info, out pk);
        }

        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="infoId">记录编号</param>
        /// <returns>一条记录</returns>
        public XYECOM.Model.LemmaInfo  GetItem(long infoId)
        {
			if (infoId <= 0) return null;
            return DAL.GetItem(infoId);
        }

        /// <summary>
        /// 根据百科分类编号获取词条信息
        /// </summary>
        /// <param name="categoryId">百科分类编号</param>
        /// <returns>返回符合条件的词条</returns>
        public DataTable GetList(string categoryId)
        {
            return DAL.GetList(categoryId);
        }

        public int SetLemmaRecommendValue(string id)
        {
            return DAL.SetLemmaRecommendValue(id);
        }

        public int SetLemmaBestValue(string id)
        {
            return DAL.SetLemmaBestValue(id);
        }

        /// <summary>
        /// 批量删除多条词条，以及这些词条的相关内容
        /// </summary>
        /// <param name="ids">词条编号</param>
        public void DeleteLemmas(string ids)
        {
            DAL.DeleteLemmas(ids);
        }

        /// <summary>
        /// 删除该词条以及该词条的相关内容
        /// </summary>
        /// <param name="id">词条编号</param>
        public void DeleteLemma(int id)
        {
            DAL.DeleteLemma(id);
        }

        public int SetDisplay(string id)
        {
            return DAL.SetDisplay(id);
        }
    }
}
