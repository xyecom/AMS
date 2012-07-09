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
    /// 临时词条
    /// </summary>
    public class TmpLemma
    {
		private static readonly XYECOM.SQLServer.TmpLemma DAL = new XYECOM.SQLServer.TmpLemma();
		
        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="infoId">记录编号</param>
        /// <returns>一条记录</returns>
        public XYECOM.Model.TmpLemmaInfo  GetItem(long infoId)
        {
			if (infoId <= 0) return null;
            return DAL.GetItem(infoId);
        }
        /// <summary>
        /// 新增临时词条，输出主键
        /// </summary>
        /// <param name="info">临时词条</param>
        /// <param name="pk">主键输出参数</param>
        /// <returns>返回影响行数</returns>
        public int Insert(XYECOM.Model.TmpLemmaInfo info, out long pk)
        {
            return DAL.Insert(info, out pk);
        }
        /// <summary>
        /// 审核该临时词条
        /// </summary>
        /// <param name="tmpInfo">待审核的临时词条</param>
        /// <returns>返回影响行数</returns>
        public int CheckUpLemma(XYECOM.Model.TmpLemmaInfo tmpInfo)
        {
            return DAL.CheckUpLemma(tmpInfo);
        }

        /// <summary>
        /// 在临时词条表中查找词条名称为Name的词条，如果存在返回并且状态为待审核返回0，否则返回1，不存在返回1
        /// </summary>
        /// <param name="name">待创建的词条名称</param>
        /// <returns>如果存在返回并且状态为待审核返回0，否则返回1，不存在返回1</returns>
        public int CheckLemmaName(string name,out int res)
        {
            return DAL.CheckLemmaName(name, out res);
        }

        /// <summary>
        /// 判断该词条是否可编辑
        /// </summary>
        /// <param name="lemmaId">词条编号</param>
        /// <returns>true 可编辑,false不能编辑</returns>
        public bool EditAble(long lemmaId)
        {
            return DAL.EditAble(lemmaId);
        }

        public int Delete(string id)
        {
            return DAL.Delete(id);
        }
    }
}
