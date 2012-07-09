//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：LemmaCategory.cs
// author: peidun
// create date：2009-12-10 20:32:46
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using XYECOM.Core.Data;
using XYECOM.Core;

namespace XYECOM.SQLServer
{
    public class LemmaCategory
    {
		/// <summary>
        /// 插入百科分类
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>受影响的行数</returns>
        public int Insert(XYECOM.Model.LemmaCategoryInfo info)
        {
            string fullId = Core.Utils.AppendComma(GetFullID(info.ParentId));
            SqlParameter[] param = new SqlParameter[]
            { 
					new SqlParameter("@CategoryId",info.CategoryId),
					new SqlParameter("@CategoryName",info.CategoryName),
					new SqlParameter("@ParentId",info.ParentId),
					new SqlParameter("@Description",info.Description),
					new SqlParameter("@FullId",fullId),
					new SqlParameter("@OrderId",info.OrderId),
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertLemmaCategory", param);
        }

        /// <summary>
        /// 获取包括上级id的完整id
        /// </summary>
        /// <param name="parentID">百科分类编号id</param>
        /// <returns>id集合字符串</returns>
        private string GetFullID(int parentID)
        {
            string strFullIDs = "";

            XYECOM.Model.LemmaCategoryInfo info = GetItem(parentID);

            if (info == null) return "0";

            if (info.ParentId != 0)
            {
                strFullIDs = GetFullID(info.ParentId) + "," + info.CategoryId.ToString() + strFullIDs;
            }
            else
            {
                strFullIDs = info.CategoryId.ToString();
            }
            return strFullIDs;
        }

		/// <summary>
        /// 修改百科分类
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>受影响的行数</returns>
        public int Update(XYECOM.Model.LemmaCategoryInfo info)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
					new SqlParameter("@CategoryId",info.CategoryId),
					new SqlParameter("@CategoryName",info.CategoryName),
					new SqlParameter("@ParentId",info.ParentId),
					new SqlParameter("@Description",info.Description),
					new SqlParameter("@FullId",info.FullId),
					new SqlParameter("@OrderId",info.OrderId),
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateLemmaCategory", param);
        }


		 /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="infoId">记录编号</param>
        /// <returns>数据对象</returns>
        public XYECOM.Model.LemmaCategoryInfo  GetItem(int infoId)
        {
            XYECOM.Model.LemmaCategoryInfo model = null;
            SqlParameter[] Parame = new SqlParameter[] 
            {
				new SqlParameter("@Top","0"),
				new SqlParameter("@Columns",""),
				new SqlParameter("@Table","XY_LemmaCategory"),
				new SqlParameter("@Where","CategoryId = " + infoId.ToString()),
				new SqlParameter("@Order","")
            };
            using (SqlDataReader rdr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_CommonSelect", Parame))
            {
                if (rdr.Read())
                {
                    model = new XYECOM.Model.LemmaCategoryInfo();

					model.CategoryId = Convert.ToInt32(rdr["CategoryId"].ToString());
					model.CategoryName = rdr["CategoryName"].ToString();
					model.ParentId = Convert.ToInt32(rdr["ParentId"].ToString());
					model.Description = rdr["Description"].ToString();
					model.FullId = rdr["FullId"].ToString();
					model.OrderId = Convert.ToInt32(rdr["OrderId"].ToString());
                }
            }
            return model;
        }
		
		/// <summary>
        /// 删除一条或多条记录
        /// </summary>
        /// <param name="Fa_ID">记录编号</param>
        /// <returns>受影响的行数</returns>
        public int Delete(string  infoIds)
        {
           return Utils.Delete("XY_LemmaCategory","CategoryId in ("+ infoIds +")");		
        }
		
		public DataTable GetList()
        {
            return Utils.ExecuteTable("XY_LemmaCategory", "", "");
        }
    }
}
