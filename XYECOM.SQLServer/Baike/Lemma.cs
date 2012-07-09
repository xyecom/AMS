//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：Lemma.cs
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
    /// <summary>
    /// 
    /// </summary>
    public class Lemma
    {
		/// <summary>
        /// 插入词条
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>受影响的行数</returns>
        public int Insert(XYECOM.Model.LemmaInfo info)
        {
            SqlParameter[] param = new SqlParameter[]
            { 
					new SqlParameter("@LemmaId",info.LemmaId),
					new SqlParameter("@LemmaName",info.LemmaName),
					new SqlParameter("@Reference",info.Reference),
					new SqlParameter("@LemmaCategory",info.LemmaCategory),
					new SqlParameter("@ExtendRead",info.ExtendRead),
					new SqlParameter("@Creator",info.Creator),
					new SqlParameter("@CreateTime",info.CreateTime),
					new SqlParameter("@BrowseTimes",info.BrowseTimes),
					new SqlParameter("@EditTimes",info.EditTimes),
					new SqlParameter("@IsBestLemma",info.IsBestLemma),
					new SqlParameter("@IsRecommend",info.IsRecommend),
					new SqlParameter("@Synonyms",info.Synonyms),
					new SqlParameter("@EnName",info.EnName),
					new SqlParameter("@CompleteStatus",info.CompleteStatus),
					new SqlParameter("@Content",info.Content),
					new SqlParameter("@Picture",info.Picture),
					new SqlParameter("@LastModiyTime",info.LastModiyTime),
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertLemma", param);
        }
		
		/// <summary>
        /// 修改词条
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>受影响的行数</returns>
        public int Update(XYECOM.Model.LemmaInfo info)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
					new SqlParameter("@LemmaId",info.LemmaId),
					new SqlParameter("@LemmaName",info.LemmaName),
					new SqlParameter("@Reference",info.Reference),
					new SqlParameter("@LemmaCategory",info.LemmaCategory),
					new SqlParameter("@ExtendRead",info.ExtendRead),
					new SqlParameter("@Creator",info.Creator),
					new SqlParameter("@CreateTime",info.CreateTime),
					new SqlParameter("@BrowseTimes",info.BrowseTimes),
					new SqlParameter("@EditTimes",info.EditTimes),
					new SqlParameter("@IsBestLemma",info.IsBestLemma),
					new SqlParameter("@IsRecommend",info.IsRecommend),
					new SqlParameter("@Synonyms",info.Synonyms),
					new SqlParameter("@EnName",info.EnName),
					new SqlParameter("@CompleteStatus",info.CompleteStatus),
					new SqlParameter("@Content",info.Content),
					new SqlParameter("@Picture",info.Picture),
					new SqlParameter("@LastModiyTime",info.LastModiyTime),
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateLemma", param);
        }


		 /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="infoId">记录编号</param>
        /// <returns>数据对象</returns>
        public XYECOM.Model.LemmaInfo  GetItem(long infoId)
        {
            XYECOM.Model.LemmaInfo model = null;
            SqlParameter[] Parame = new SqlParameter[] 
            {
				new SqlParameter("@Top","0"),
				new SqlParameter("@Columns",""),
				new SqlParameter("@Table","XY_Lemma"),
				new SqlParameter("@Where","LemmaId = " + infoId.ToString()),
				new SqlParameter("@Order","")
            };
            using (SqlDataReader rdr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_CommonSelect", Parame))
            {
                if (rdr.Read())
                {
                    model = new XYECOM.Model.LemmaInfo();

					model.LemmaId = XYECOM.Core.MyConvert.GetInt64(rdr["LemmaId"].ToString());
					model.LemmaName = rdr["LemmaName"].ToString();
					model.Reference = rdr["Reference"].ToString();
					model.LemmaCategory = rdr["LemmaCategory"].ToString();
					model.ExtendRead = rdr["ExtendRead"].ToString();
                    model.Creator = rdr["Creator"].ToString();
					model.CreateTime = Convert.ToDateTime(rdr["CreateTime"].ToString());
					model.BrowseTimes = Convert.ToInt32(rdr["BrowseTimes"].ToString());
					model.EditTimes = Convert.ToInt32(rdr["EditTimes"].ToString());
					model.IsBestLemma = Convert.ToBoolean(rdr["IsBestLemma"].ToString());
					model.IsRecommend = Convert.ToBoolean(rdr["IsRecommend"].ToString());
					model.Synonyms = rdr["Synonyms"].ToString();
					model.EnName = rdr["EnName"].ToString();
					model.CompleteStatus = Convert.ToInt32(rdr["CompleteStatus"].ToString());
					model.Content = rdr["Content"].ToString();					
					model.LastModiyTime = rdr["LastModiyTime"].ToString();
                    model.Picture = XYECOM.Core.MyConvert.GetInt64(rdr["Picture"].ToString());
                    model.AttachInfo = new Attachment().GetItems(model.Picture, "baike");
                }
            }
            return model;
        }
		
		/// <summary>
        /// 删除一条或多条记录
        /// </summary>
        /// <param name="infoIds">记录编号</param>
        /// <returns>受影响的行数</returns>
        public int Delete(string  infoIds)
        {
           return Utils.Delete("XY_Lemma","LemmaId in ("+ infoIds +")");		
        }
		
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
		public DataTable GetList()
        {
            return Utils.ExecuteTable("XY_Lemma", "", "");
        }

        /// <summary>
        /// 插入词条信息，返回影响行数，并输出主键
        /// </summary>
        /// <param name="info">要插入的词条信息</param>
        /// <param name="infoId">输出参数，主键</param>
        /// <returns>返回影响行数</returns>
        public int Insert(XYECOM.Model.LemmaInfo info, out long infoId)
        {
            SqlParameter[] param = new SqlParameter[]
            { 
					new SqlParameter("@LemmaId",SqlDbType.BigInt),
					new SqlParameter("@LemmaName",info.LemmaName),
					new SqlParameter("@Reference",info.Reference),
					new SqlParameter("@LemmaCategory",info.LemmaCategory),
					new SqlParameter("@ExtendRead",info.ExtendRead),
					new SqlParameter("@Creator",info.Creator),
					new SqlParameter("@CreateTime",info.CreateTime),
					new SqlParameter("@BrowseTimes",info.BrowseTimes),
					new SqlParameter("@EditTimes",info.EditTimes),
					new SqlParameter("@IsBestLemma",info.IsBestLemma),
					new SqlParameter("@IsRecommend",info.IsRecommend),
					new SqlParameter("@Synonyms",info.Synonyms),
					new SqlParameter("@EnName",info.EnName),
					new SqlParameter("@CompleteStatus",info.CompleteStatus),
					new SqlParameter("@Content",info.Content),
					new SqlParameter("@LastModiyTime",info.LastModiyTime),
                    new SqlParameter("@Picture",info.Picture)
                    
            };

            param[0].Direction = ParameterDirection.Output;


            int rowAffected = XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertLemma", param);

            if (rowAffected >= 0)
            {
                if (param[0].Value != null && param[0].Value.ToString() != "")
                    infoId = (long)param[0].Value;
                else
                    infoId = 0;
            }
            else
            {
                infoId = -1;
            }

            return rowAffected;

            
        }

        /// <summary>
        /// 根据百科分类编号获取词条信息
        /// </summary>
        /// <param name="categoryId">百科分类编号</param>
        /// <returns>返回符合条件的词条</returns>
        public DataTable GetList(string categoryId)
        {
            if (string.IsNullOrEmpty(categoryId)) categoryId = "-1";
            return Utils.ExecuteTable("XY_Lemma", "LemmaId,LemmaName", "charindex('," + categoryId + ",',LemmaCategory) > 0");
        }

        /// <summary>
        /// 设置该词条是否为优质
        /// </summary>
        /// <param name="id">词条编号</param>
        /// <returns>影响行数</returns>
        public int SetLemmaBestValue(string id)
        {
            if (string.IsNullOrEmpty(id)) return -1;
            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery("update XY_Lemma set IsBestLemma = case IsBestLemma when 1 then 0 else 1 end where LemmaId = " + id);
        }

        /// <summary>
        /// 设置改词条是否为推荐
        /// </summary>
        /// <param name="id">词条编号</param>
        /// <returns>影响行数</returns>
        public int SetLemmaRecommendValue(string id)
        {
            if (string.IsNullOrEmpty(id)) return -1;
            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery("update XY_Lemma set IsRecommend = case IsRecommend when 1 then 0 else 1 end where LemmaId = " + id);
        }

        /// <summary>
        /// 删除和这条词条的相关内容。
        /// </summary>
        /// <param name="id">词条编号</param>        
        public void DeleteLemma(int id)
        {
            DeleteLemmas(id.ToString());
        }

        /// <summary>
        /// 批量删除多条词条，以及这些词条的相关内容
        /// </summary>
        /// <param name="ids"></param>
        public void DeleteLemmas(string ids) 
        {
            Utils.Delete("XY_Lemma", "LemmaId in (" + ids + ")");
            Utils.Delete("XY_TmpLemma", "LemmaId in (" + ids + ")");
            Utils.Delete("XY_HistoryLemma", "LemmaId in (" + ids + ")");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int SetDisplay(string id)
        {
            if (string.IsNullOrEmpty(id)) return -1;
            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery("update XY_Lemma set Display = case Display when 1 then 0 else 1 end where LemmaId = " + id);
        }
    }
}
