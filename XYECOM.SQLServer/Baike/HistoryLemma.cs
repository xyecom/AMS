//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：HistoryLemma.cs
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
    public class HistoryLemma
    {
		/// <summary>
        /// 插入历史版本
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>受影响的行数</returns>
        public int Insert(XYECOM.Model.HistoryLemmaInfo info)
        {
            SqlParameter[] param = new SqlParameter[]
            { 
					new SqlParameter("@LemmaHistoryId",info.LemmaHistoryId),
					new SqlParameter("@LemmaName",info.LemmaName),
					new SqlParameter("@Reference",info.Reference),
					new SqlParameter("@LemmaCategory",info.LemmaCategory),
					new SqlParameter("@ExtendRead",info.ExtendRead),
					new SqlParameter("@Share",info.Share),
					new SqlParameter("@ShareTime",info.ShareTime),
					new SqlParameter("@Synonyms",info.Synonyms),
					new SqlParameter("@EnName",info.EnName),
					new SqlParameter("@CompleteStatus",info.CompleteStatus),
					new SqlParameter("@Content",info.Content),
					new SqlParameter("@Picture",info.Picture),
					new SqlParameter("@LemmaId",info.LemmaId),
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertHistoryLemma", param);
        }
		
		/// <summary>
        /// 修改历史版本
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>受影响的行数</returns>
        public int Update(XYECOM.Model.HistoryLemmaInfo info)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
					new SqlParameter("@LemmaHistoryId",info.LemmaHistoryId),
					new SqlParameter("@LemmaName",info.LemmaName),
					new SqlParameter("@Reference",info.Reference),
					new SqlParameter("@LemmaCategory",info.LemmaCategory),
					new SqlParameter("@ExtendRead",info.ExtendRead),
					new SqlParameter("@Share",info.Share),
					new SqlParameter("@ShareTime",info.ShareTime),
					new SqlParameter("@Synonyms",info.Synonyms),
					new SqlParameter("@EnName",info.EnName),
					new SqlParameter("@CompleteStatus",info.CompleteStatus),
					new SqlParameter("@Content",info.Content),
					new SqlParameter("@Picture",info.Picture),
					new SqlParameter("@LemmaId",info.LemmaId),
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateHistoryLemma", param);
        }


		 /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="infoId">记录编号</param>
        /// <returns>数据对象</returns>
        public XYECOM.Model.HistoryLemmaInfo  GetItem(int infoId)
        {
            XYECOM.Model.HistoryLemmaInfo model = null;
            SqlParameter[] Parame = new SqlParameter[] 
            {
				new SqlParameter("@Top","0"),
				new SqlParameter("@Columns",""),
				new SqlParameter("@Table","XY_HistoryLemma"),
				new SqlParameter("@Where","LemmaHistoryId = " + infoId.ToString()),
				new SqlParameter("@Order","")
            };
            using (SqlDataReader rdr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_CommonSelect", Parame))
            {
                if (rdr.Read())
                {
                    model = new XYECOM.Model.HistoryLemmaInfo();

					model.LemmaHistoryId = XYECOM.Core.MyConvert.GetInt64(rdr["LemmaHistoryId"].ToString());
					model.LemmaName = rdr["LemmaName"].ToString();
					model.Reference = rdr["Reference"].ToString();
					model.LemmaCategory = rdr["LemmaCategory"].ToString();
					model.ExtendRead = rdr["ExtendRead"].ToString();
                    model.Share = rdr["Share"].ToString();
					model.ShareTime = Convert.ToDateTime(rdr["ShareTime"].ToString());
					model.Synonyms = rdr["Synonyms"].ToString();
					model.EnName = rdr["EnName"].ToString();
					model.CompleteStatus = Convert.ToInt32(rdr["CompleteStatus"].ToString());
					model.Content = rdr["Content"].ToString();
					model.Picture = rdr["Picture"].ToString();
					model.LemmaId = XYECOM.Core.MyConvert.GetInt64(rdr["LemmaId"].ToString());
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
           return Utils.Delete("XY_HistoryLemma","LemmaHistoryId in ("+ infoIds +")");		
        }
		
		public DataTable GetList()
        {
            return Utils.ExecuteTable("XY_HistoryLemma", "", "");
        }
    }
}
