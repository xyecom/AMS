//------------------------------------------------------------------------------
//
// file name：XY_FieldAccessor.cs
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

namespace XYECOM.SQLServer
{
    /// <summary>
    /// Data accessor of FieldAccess
    /// </summary>
    public partial class FieldAccess
    {
        private string TableName = "XY_Field";
        private string ProductTypeTableName = "b_ProductType";

        public IList<Model.FieldValueInfo> GetItems(int typeId)
        {
            IList<Model.FieldValueInfo> infos = new List<Model.FieldValueInfo>();

            if (typeId < 1)
            {
                return infos;
            }

            string sql = @"SELECT Id,ProductTypeId,CName,EName,Type,Description,DefaultValue                            ,InitValue,InputModel from " + TableName + @"                            where ProductTypeId =@TypeId or charindex(','+cast(ProductTypeId as varchar(50))+',',(select FullId from " + ProductTypeTableName
                            + @" where PT_Id=@TypeId))>0";

            SqlParameter[] parms = new SqlParameter[] { new SqlParameter("@TypeId", typeId) };

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.Text, sql, parms))
            {
                while (reader.Read())
                {
                    Model.FieldValueInfo info = new Model.FieldValueInfo();
                    info.FieldId = XYECOM.Core.MyConvert.GetInt32(reader["Id"].ToString());
                    info.Field = new Model.FieldInfo();

                    info.Field.CName = reader["CName"].ToString();
                    info.Field.DefaultValue = reader["DefaultValue"].ToString();
                    info.Field.Description = reader["Description"].ToString();
                    info.Field.EName = reader["EName"].ToString();
                    info.Field.Id = info.FieldId;
                    info.Field.InitValue = reader["InitValue"].ToString();
                    info.Field.InputModel = reader["InputModel"].ToString();

                    info.Field.Type = reader["Type"].ToString();
                    info.Field.ProductTypeId = XYECOM.Core.MyConvert.GetInt32(reader["ProductTypeId"].ToString());

                    info.FieldValue = "";

                    info.ProductId = 0;
                    info.Id = 0;

                    infos.Add(info);
                }
            }
            return infos;
        }
        /// <summary>
        /// 根据产品分类id获取相关的自定义属性
        /// </summary>
        /// <param name="typeId">产品分类id</param>
        /// <returns></returns>
        public IList<Model.FieldValueInfo> GetFieldValueForPtid(int typeId)
        {
            IList<Model.FieldValueInfo> infos = new List<Model.FieldValueInfo>();

            if (typeId < 1)
            {
                return infos;
            }

            string sql = @"SELECT Id,ProductTypeId,CName,EName,Type,Description,DefaultValue                            ,InitValue,InputModel from " + TableName + @"                            where [type]='radio' and ProductTypeId =@TypeId or charindex(','+cast(ProductTypeId as varchar(50))+',',(select FullId from " + ProductTypeTableName
                            + @" where PT_Id=@TypeId))>0";

            SqlParameter[] parms = new SqlParameter[] { new SqlParameter("@TypeId", typeId) };

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.Text, sql, parms))
            {
                while (reader.Read())
                {
                    Model.FieldValueInfo info = new Model.FieldValueInfo();
                    info.FieldId = XYECOM.Core.MyConvert.GetInt32(reader["Id"].ToString());
                    info.Field = new Model.FieldInfo();

                    info.Field.CName = reader["CName"].ToString();
                    info.Field.DefaultValue = reader["DefaultValue"].ToString();
                    info.Field.Description = reader["Description"].ToString();
                    info.Field.EName = reader["EName"].ToString();
                    info.Field.Id = info.FieldId;
                    info.Field.InitValue = reader["InitValue"].ToString();
                    info.Field.InputModel = reader["InputModel"].ToString();

                    info.Field.Type = reader["Type"].ToString();
                    info.Field.ProductTypeId = XYECOM.Core.MyConvert.GetInt32(reader["ProductTypeId"].ToString());

                    info.FieldValue = "";

                    info.ProductId = 0;
                    info.Id = 0;

                    infos.Add(info);
                }
            }
            return infos;
        }

    }
}
