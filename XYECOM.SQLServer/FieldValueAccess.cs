//------------------------------------------------------------------------------
//
// file name：XY_FieldValueAccessor.cs
// author: wangzhen
// create date：2011-3-29 16:07:06
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using XYECOM.Core.Data;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// Data accessor of FieldValueAccess
    /// </summary>
    public partial class FieldValueAccess
    {
        /// <summary>
        /// 根据分类属性ID获取分类属性值信息 （王振添加 2011-03-30）
        /// </summary>
        /// <param name="sinfo"></param>
        /// <returns>分类属性值信息</returns>
        public IList<Model.FieldValueInfo> GetItems(Model.SupplyInfo sinfo)
        {
            IList<Model.FieldValueInfo> infos = new List<Model.FieldValueInfo>();

            if (sinfo == null || sinfo.SortID < 1 || sinfo.InfoID < 1)
            {
                return infos;
            }

            string sql = @"select val.Id,val.ProductId,val.FieldId,val.FieldValue,fld.Id as fldId,ProductTypeId,EName,CName
                         ,Type,Description,DefaultValue,InitValue,IsRequire,InputModel from (select * from XY_FieldValue 
                         where productId=" + sinfo.InfoID + ") as val inner join (select * from xy_field where producttypeId=" + sinfo.SortID + " or charindex(','+cast(producttypeid as varchar(10))+',',(select fullid from b_producttype where pt_id=" + sinfo.SortID + "))>0) as fld on fld.Id=val.fieldId";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(CommandType.Text, sql, null))
            {
                while (reader.Read())
                {
                    Model.FieldValueInfo info = new Model.FieldValueInfo();
                    info.FieldId = XYECOM.Core.MyConvert.GetInt32(reader["fldId"].ToString());
                    info.Field = new Model.FieldInfo();
                    info.Field.CName = reader["CName"].ToString();
                    info.Field.DefaultValue = reader["DefaultValue"].ToString();
                    info.Field.Description = reader["Description"].ToString();
                    info.Field.EName = reader["EName"].ToString();
                    info.Field.Id = info.FieldId;
                    info.Field.InitValue = reader["InitValue"].ToString();
                    info.Field.IsRequire = XYECOM.Core.MyConvert.GetBoolean(reader["IsRequire"].ToString());
                    info.Field.Type = reader["Type"].ToString();
                    info.Field.InputModel = reader["InputModel"].ToString();
                    info.Field.ProductTypeId = XYECOM.Core.MyConvert.GetInt32(reader["ProductTypeId"].ToString());
                    info.FieldValue = reader["FieldValue"].ToString();

                    info.ProductId = sinfo.InfoID;
                    info.Product = sinfo;
                    info.Id = XYECOM.Core.MyConvert.GetInt32(reader["Id"].ToString()); ;

                    infos.Add(info);
                }
            }

            return infos;
        }

        /// <summary>
        /// 根据产品编号删除分类属性值 (王振添加 2011-04-01)
        /// </summary>
        /// <param name="proId">产品编号</param>
        /// <returns>受影响的行数</returns>
        public int DeleteFieldValueByProductId(int proId)
        {
            if (proId < 0)
            {
                return 0;
            }
            string sql = "delete XY_FieldValue where productid = " + proId + "";
            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.Text, sql, null);
        }
    }
}
