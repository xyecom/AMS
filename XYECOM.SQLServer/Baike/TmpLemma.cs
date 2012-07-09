//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：TmpLemma.cs
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
    public class TmpLemma
    {
		/// <summary>
        /// 插入临时词条
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>受影响的行数</returns>
        public int Insert(XYECOM.Model.TmpLemmaInfo info)
        {
            SqlParameter[] param = new SqlParameter[]
            { 
					new SqlParameter("@LemmaTmpId",info.LemmaTmpId),
					new SqlParameter("@LemmaId",info.LemmaId),
					new SqlParameter("@LemmaName",info.LemmaName),
					new SqlParameter("@Reference",info.Reference),
					new SqlParameter("@LemmaCategory",info.LemmaCategory),
					new SqlParameter("@ExtendRead",info.ExtendRead),
					new SqlParameter("@LemmaStatus",info.LemmaStatus),
					new SqlParameter("@Creator",info.Creator),
					new SqlParameter("@CreateTime",info.CreateTime),
					new SqlParameter("@Synonyms",info.Synonyms),
					new SqlParameter("@EnName",info.EnName),
					new SqlParameter("@FailReason",info.FailReason),
					new SqlParameter("@FailTime",info.FailTime),
					new SqlParameter("@PassTime",info.PassTime),
					new SqlParameter("@ModiyDate",info.ModiyDate),
					new SqlParameter("@Content",info.Content),
                    new SqlParameter("@Modifier",info.Modifier),
					new SqlParameter("@ModifyReason",info.ModifyReason),
                    new SqlParameter("@BrowseTimes",info.BrowseTimes),
					new SqlParameter("@EditTimes",info.EditTimes)
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertTmpLemma", param);
        }
		
		/// <summary>
        /// 修改临时词条
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>受影响的行数</returns>
        public int Update(XYECOM.Model.TmpLemmaInfo info)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
					new SqlParameter("@LemmaTmpId",info.LemmaTmpId),
					new SqlParameter("@LemmaId",info.LemmaId),
					new SqlParameter("@LemmaName",info.LemmaName),
					new SqlParameter("@Reference",info.Reference),
					new SqlParameter("@LemmaCategory",info.LemmaCategory),
					new SqlParameter("@ExtendRead",info.ExtendRead),
					new SqlParameter("@LemmaStatus",info.LemmaStatus),
					new SqlParameter("@Creator",info.Creator),
					new SqlParameter("@CreateTime",info.CreateTime),
					new SqlParameter("@Synonyms",info.Synonyms),
					new SqlParameter("@EnName",info.EnName),
					new SqlParameter("@FailReason",info.FailReason),
					new SqlParameter("@FailTime",info.FailTime),
					new SqlParameter("@PassTime",info.PassTime),
					new SqlParameter("@ModiyDate",info.ModiyDate),
					new SqlParameter("@Content",info.Content),
                    new SqlParameter("@Modifier",info.Modifier),
					new SqlParameter("@ModifyReason",info.ModifyReason),
                    new SqlParameter("@BrowseTimes",info.BrowseTimes),
					new SqlParameter("@EditTimes",info.EditTimes)
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateTmpLemma", param);
        }


		 /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="infoId">记录编号</param>
        /// <returns>数据对象</returns>
        public XYECOM.Model.TmpLemmaInfo  GetItem(long infoId)
        {
            XYECOM.Model.TmpLemmaInfo model = null;
            SqlParameter[] Parame = new SqlParameter[] 
            {
				new SqlParameter("@Top","0"),
				new SqlParameter("@Columns",""),
				new SqlParameter("@Table","XY_TmpLemma"),
				new SqlParameter("@Where","LemmaTmpId = " + infoId.ToString()),
				new SqlParameter("@Order","")
            };
            using (SqlDataReader rdr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_CommonSelect", Parame))
            {
                if (rdr.Read())
                {
                    model = new XYECOM.Model.TmpLemmaInfo();

					model.LemmaTmpId = XYECOM.Core.MyConvert.GetInt64(rdr["LemmaTmpId"].ToString());
					model.LemmaId = XYECOM.Core.MyConvert.GetInt64(rdr["LemmaId"].ToString());
					model.LemmaName = rdr["LemmaName"].ToString();
					model.Reference = rdr["Reference"].ToString();
					model.LemmaCategory = rdr["LemmaCategory"].ToString();
					model.ExtendRead = rdr["ExtendRead"].ToString();
					model.LemmaStatus = Convert.ToInt32(rdr["LemmaStatus"].ToString());
                    model.Creator = rdr["Creator"].ToString();
					model.CreateTime = Convert.ToDateTime(rdr["CreateTime"].ToString());
					model.Synonyms = rdr["Synonyms"].ToString();
					model.EnName = rdr["EnName"].ToString();
					model.FailReason = rdr["FailReason"].ToString();
					model.FailTime = rdr["FailTime"].ToString();
					model.PassTime = rdr["PassTime"].ToString();
					model.ModiyDate = rdr["ModiyDate"].ToString();
					model.Content = rdr["Content"].ToString();
                    model.Modifier = rdr["Modifier"].ToString();
                    model.ModifyReason = rdr["ModifyReason"].ToString();
                    model.EditTimes = XYECOM.Core.MyConvert.GetInt32(rdr["EditTimes"].ToString());
                    model.BrowseTimes = XYECOM.Core.MyConvert.GetInt32(rdr["BrowseTimes"].ToString());
                    model.Picture = XYECOM.Core.MyConvert.GetInt64(rdr["Picture"].ToString());
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
           return Utils.Delete("XY_TmpLemma","LemmaTmpId in ("+ infoIds +")");
        }
		
		public DataTable GetList()
        {
            return Utils.ExecuteTable("XY_TmpLemma", "", "");
        }

        public int Insert(XYECOM.Model.TmpLemmaInfo info, out long pk)
        {
            SqlParameter[] param = new SqlParameter[]
            { 
					new SqlParameter("@LemmaTmpId",SqlDbType.BigInt),
					new SqlParameter("@LemmaId",info.LemmaId),
					new SqlParameter("@LemmaName",info.LemmaName),
					new SqlParameter("@Reference",info.Reference),
					new SqlParameter("@LemmaCategory",info.LemmaCategory),
					new SqlParameter("@ExtendRead",info.ExtendRead),
					new SqlParameter("@LemmaStatus",info.LemmaStatus),
					new SqlParameter("@Creator",info.Creator),
					new SqlParameter("@CreateTime",info.CreateTime),
					new SqlParameter("@Synonyms",info.Synonyms),
					new SqlParameter("@EnName",info.EnName),
					new SqlParameter("@FailReason",info.FailReason),
					new SqlParameter("@FailTime",info.FailTime),
					new SqlParameter("@PassTime",info.PassTime),
					new SqlParameter("@ModiyDate",info.ModiyDate),
					new SqlParameter("@Content",info.Content),
                    new SqlParameter("@Modifier",info.Modifier),
					new SqlParameter("@ModifyReason",info.ModifyReason),
                    new SqlParameter("@BrowseTimes",info.BrowseTimes),
					new SqlParameter("@EditTimes",info.EditTimes),
					new SqlParameter("@Picture",info.Picture)
            };

            param[0].Direction = ParameterDirection.Output;

            int rowAffected = XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertTmpLemma", param);

            if (rowAffected >= 0)
            {
                if (param[0].Value != null && param[0].Value.ToString() != "")
                    pk = (long)param[0].Value;
                else
                    pk = 0;
            }
            else
            {
                pk = -1;
            }

            return rowAffected;
        }

        /// <summary>
        /// 审核临时词条
        /// </summary>
        /// <param name="tmpInfo">待审核的临时词条</param>
        /// <returns>返回影响行数</returns>
        public int CheckUpLemma(XYECOM.Model.TmpLemmaInfo tmpInfo)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
					new SqlParameter("@LemmaTmpId",tmpInfo.LemmaTmpId),
					new SqlParameter("@LemmaId",tmpInfo.LemmaId),
					new SqlParameter("@LemmaName",tmpInfo.LemmaName),
					new SqlParameter("@Reference",tmpInfo.Reference),
					new SqlParameter("@LemmaCategory",tmpInfo.LemmaCategory),
					new SqlParameter("@ExtendRead",tmpInfo.ExtendRead),
					new SqlParameter("@LemmaStatus",tmpInfo.LemmaStatus),
					new SqlParameter("@Creator",tmpInfo.Creator),
					new SqlParameter("@CreateTime",tmpInfo.CreateTime),
					new SqlParameter("@Synonyms",tmpInfo.Synonyms),
					new SqlParameter("@EnName",tmpInfo.EnName),
					new SqlParameter("@FailReason",tmpInfo.FailReason),
					new SqlParameter("@FailTime",tmpInfo.FailTime),
					new SqlParameter("@PassTime",tmpInfo.PassTime),
					new SqlParameter("@ModiyDate",tmpInfo.ModiyDate),
					new SqlParameter("@Content",tmpInfo.Content),
                    new SqlParameter("@Modifier",tmpInfo.Modifier),
					new SqlParameter("@ModifyReason",tmpInfo.ModifyReason),
                    new SqlParameter("@BrowseTimes",tmpInfo.BrowseTimes),
					new SqlParameter("@EditTimes",tmpInfo.EditTimes)
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_CheckUpLemma", param);
        }

        /// <summary>
        /// 在临时词条表中查找词条名称为Name的词条，如果存在返回并且状态为待审核返回0，否则返回1，不存在返回1
        /// </summary>
        /// <param name="name">待创建的词条名称</param>
        /// <returns>如果存在返回并且状态为待审核返回0，否则返回1，不存在返回1</returns>
        public int CheckLemmaName(string name,out int res)
        {
            SqlParameter[] param = new SqlParameter[] 
            {
                new SqlParameter("@LemmaName", name),
                new SqlParameter("@res",SqlDbType.Int)
            };
            param[1].Direction = ParameterDirection.Output;

            int rowAffected = XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_CheckLemmaName", param);
            
            res = (int)param[1].Value;

            return rowAffected;
        }

        /// <summary>
        /// 判断该词条是否可编辑
        /// </summary>
        /// <param name="lemmaId">词条编号</param>
        /// <returns>true 可编辑,false不能编辑</returns>
        public bool EditAble(long lemmaId)
        {
            SqlParameter[] param = new SqlParameter[] 
            {
                new SqlParameter("@LemmaId", lemmaId)
            };

            object obj = XYECOM.Core.Data.SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "XYP_EditAble", param);
            if (obj != null) 
            {
                long k = long.Parse(obj.ToString());
                if (k > 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
