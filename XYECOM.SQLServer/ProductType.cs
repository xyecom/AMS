using System;
using System.Collections.Generic;
using System.Text;
using XYECOM.Core.Data;
using System.Data;
using System.Data.SqlClient;
using XYECOM.Core;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// ��Ʒ�������ݴ�����
    /// </summary>
    public class ProductType
    {
        /// <summary>
        /// ��ȡ����Id
        /// </summary>
        /// <param name="parentID">�ϼ�Id</param>
        /// <returns></returns>
        public string GetFullID(long parentID)
        {
            string strFullIDs = "";

            XYECOM.Model.ProductTypeInfo info = GetItem(parentID);

            if (info == null) return "0";

            if (info.PT_ParentID != 0)
            {
                strFullIDs = GetFullID(info.PT_ParentID) + "," + info.PT_ID.ToString() + strFullIDs;
            }
            else
            {
                strFullIDs = info.PT_ID.ToString();
            }

            return strFullIDs;
        }
        /// <summary>
        /// ��Ӳ�Ʒ����
        /// </summary>
        /// <param name="info">ʵ�����</param>
        /// <returns>��Ӱ�������</returns>
        public int Insert(XYECOM.Model.ProductTypeInfo info)
        {
            string fullId = Core.Utils.AppendComma(GetFullID(info.PT_ParentID));

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@PT_Name",info.PT_Name),
                new SqlParameter("@PT_ParentID",info.PT_ParentID),
                new SqlParameter("@ModuleName",info.ModuleName),
                new SqlParameter("@FullId",fullId),
                new SqlParameter("@TradeId",info.TradeId),
                new SqlParameter("@FlagName",info.FlagName),
                new SqlParameter("@IsCustomTemplate",info.IsCustomTemplate)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertProductType", param);
        }

        /// <summary>
        /// �޸Ĳ�Ʒ������Ϣ
        /// </summary>
        /// <param name="info">ʵ�����</param>
        /// <returns>��Ӱ�������</returns>
        public int Update(XYECOM.Model.ProductTypeInfo info)
        {
            string fullId = Core.Utils.AppendComma(GetFullID(info.PT_ParentID));

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@PT_ID",info.PT_ID),
                new SqlParameter("@PT_Name",info.PT_Name),
                new SqlParameter("@PT_ParentID",info.PT_ParentID),
                new SqlParameter("@ModuleName",info.ModuleName),
                new SqlParameter("@FullId",fullId),
                new SqlParameter("@TradeId",info.TradeId),
                new SqlParameter("@FlagName",info.FlagName),
                new SqlParameter("@IsCustomTemplate",info.IsCustomTemplate)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateProductType", param);
        }

        /// <summary>
        /// ��ȡһ����¼
        /// </summary>
        /// <param name="PT_ID">��¼���</param>
        /// <returns>��¼����</returns>
        public XYECOM.Model.ProductTypeInfo GetItem(long PT_ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere","Where PT_ID=" + PT_ID.ToString()),
                new SqlParameter("@strTableName","b_ProductType"),
                new SqlParameter("@strOrder","")
            };

            XYECOM.Model.ProductTypeInfo info = null;

            using (SqlDataReader dr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (dr.Read())
                {
                    info = new XYECOM.Model.ProductTypeInfo();

                    info.PT_ID = Convert.ToInt64(dr["PT_ID"].ToString());
                    info.PT_Name = dr["PT_Name"].ToString();
                    info.PT_ParentID = Convert.ToInt64(dr["PT_ParentID"].ToString());
                    info.ModuleName = dr["ModuleName"].ToString();
                    info.FullId = dr["FullId"].ToString();
                    info.InfoCount = Core.MyConvert.GetInt32(dr["InfoCount"].ToString());
                    info.TradeId = Core.MyConvert.GetInt32(dr["TradeId"].ToString());
                    info.FlagName = dr["FlagName"].ToString();
                    info.IsCustomTemplate = dr["IsCustomTemplate"].ToString().Equals("True") ? true : false;
                }
            }
            return info;
        }

        /// <summary>
        /// ͨ������ID��ȡ�÷�����Ϣ ��������� 2011-03-30��
        /// </summary>
        /// <param name="id">����Id</param>
        /// <returns>������Ϣ</returns>
        public Model.ProductTypeInfo GetProTypeById(int id)
        {
            string sql = "select * from b_producttype where pt_id = " + id + "";
            XYECOM.Model.ProductTypeInfo info = null;

            using (SqlDataReader dr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.Text, sql, null))
            {
                if (dr.Read())
                {
                    info = new XYECOM.Model.ProductTypeInfo();

                    info.PT_ID = Convert.ToInt64(dr["PT_ID"].ToString());
                    info.PT_Name = dr["PT_Name"].ToString();
                    info.PT_ParentID = Convert.ToInt64(dr["PT_ParentID"].ToString());
                    info.ModuleName = dr["ModuleName"].ToString();
                    info.FullId = dr["FullId"].ToString();
                    info.InfoCount = Core.MyConvert.GetInt32(dr["InfoCount"].ToString());
                    info.TradeId = Core.MyConvert.GetInt32(dr["TradeId"].ToString());
                    info.FlagName = dr["FlagName"].ToString();
                    info.IsCustomTemplate = dr["IsCustomTemplate"].ToString().Equals("True") ? true : false;
                }
            }
            return info;
        }


        /// <summary>
        /// ͨ��Ψһ��ʶ����ȡ������Ϣ
        /// </summary>
        /// <param name="flagName">��ʶ����</param>
        /// <returns>���ݶ���</returns>
        public XYECOM.Model.ProductTypeInfo GetItemByFlagName(string flagName)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere","Where FlagName='" + flagName + "'"),
                new SqlParameter("@strTableName","b_ProductType"),
                new SqlParameter("@strOrder","")
            };

            XYECOM.Model.ProductTypeInfo info = null; ;

            using (SqlDataReader dr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (dr.Read())
                {
                    info = new XYECOM.Model.ProductTypeInfo();

                    info.PT_ID = Convert.ToInt64(dr["PT_ID"].ToString());
                    info.PT_Name = dr["PT_Name"].ToString();
                    info.PT_ParentID = Convert.ToInt64(dr["PT_ParentID"].ToString());
                    info.ModuleName = dr["ModuleName"].ToString();
                    info.FullId = dr["FullId"].ToString();
                    info.InfoCount = Core.MyConvert.GetInt32(dr["InfoCount"].ToString());
                    info.TradeId = Core.MyConvert.GetInt32(dr["TradeId"].ToString());
                    info.FlagName = dr["FlagName"].ToString();
                    info.IsCustomTemplate = dr["IsCustomTemplate"].ToString().Equals("True") ? true : false;
                }
            }
            return info;
        }

        /// <summary>
        /// ���ط��༯��
        /// </summary>
        /// <returns></returns>
        public List<Model.ProductTypeInfo> GetItems()
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere",""),
                new SqlParameter("@strTableName","b_ProductType"),
                new SqlParameter("@strOrder","")
            };

            List<Model.ProductTypeInfo> infos = new List<XYECOM.Model.ProductTypeInfo>();

            using (SqlDataReader dr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                while (dr.Read())
                {
                    XYECOM.Model.ProductTypeInfo info = new XYECOM.Model.ProductTypeInfo();

                    info.PT_ID = Convert.ToInt64(dr["PT_ID"].ToString());
                    info.PT_Name = dr["PT_Name"].ToString();
                    info.PT_ParentID = Convert.ToInt64(dr["PT_ParentID"].ToString());
                    info.ModuleName = dr["ModuleName"].ToString();
                    info.FullId = dr["FullId"].ToString();
                    info.InfoCount = Core.MyConvert.GetInt32(dr["InfoCount"].ToString());
                    info.TradeId = Core.MyConvert.GetInt32(dr["TradeId"].ToString());
                    info.FlagName = dr["FlagName"].ToString();
                    info.IsCustomTemplate = dr["IsCustomTemplate"].ToString().Equals("True") ? true : false;

                    infos.Add(info);
                }
            }
            return infos;
        }




        /// <summary>
        /// ��ȡ��Ʒ������Ϣ
        /// </summary>
        /// <param name="PT_ParentID">
        /// ��� PT_ParentID ���ڵ��� 0 ���ز��ֲ�Ʒ������Ϣ
        /// ���� �������еĲ�Ʒ������Ϣ
        /// </param>
        /// <returns>������Ʒ������Ϣ</returns>
        public DataTable GetDataTable(long PT_ParentID)
        {
            string WhereClause = "";

            if (PT_ParentID >= 0)
            {
                WhereClause = "Where PT_ParentID=" + PT_ParentID.ToString();
            }

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere",WhereClause),
                new SqlParameter("@strTableName","b_ProductType"),
                new SqlParameter("@strOrder","")
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "XYP_SelectByWhere", param);
        }

        /// <summary>
        /// ��ȡָ����Ʒ������Ϣ
        /// </summary>
        /// <param name="PT_IDs">��Ʒ���</param>
        /// <returns>DataTable</returns>
        public DataTable GetDataTable(string PT_IDs)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," where PT_ID in ("+PT_IDs+") "),
                new SqlParameter("@strTableName","b_ProductType"),
                new SqlParameter("@strOrder","")
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "XYP_SelectByWhere", param);
        }

        /// <summary>
        /// ��ȡָ����Ʒ������Ϣ
        /// </summary>
        /// <param name="parentID">��Ʒ���</param>
        /// <param name="moduleName">ģ����</param>
        /// <returns>DataTable</returns>
        public DataTable GetDataTable(long parentID, string moduleName)
        {
            string where = " where 1=1 ";

            if (parentID >= 0)
            {
                where += " and PT_ParentID=" + parentID.ToString();
            }

            if (!moduleName.Equals(""))
            {
                where += " and moduleName='" + moduleName + "'";
            }

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere",where),
                new SqlParameter("@strTableName","b_ProductType"),
                new SqlParameter("@strOrder","")
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "XYP_SelectByWhere", param);
        }


        /// <summary>
        /// ɾ��һ����Ʒ������Ϣ
        /// </summary>
        /// <param name="PT_ID">���ͱ��</param>
        /// <returns>��Ӱ�������</returns>
        public int Delete(string PT_ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where PT_ID in("+PT_ID+")"),
                new SqlParameter("@strTableName","b_ProductType")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public XYECOM.Model.ProductTypeInfo GetItemByTypeName(string keyword)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere","Where pt_name='" + keyword + "'"),
                new SqlParameter("@strTableName","b_ProductType"),
                new SqlParameter("@strOrder","")
            };

            XYECOM.Model.ProductTypeInfo info = null; ;

            using (SqlDataReader dr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (dr.Read())
                {
                    info = new XYECOM.Model.ProductTypeInfo();

                    info.PT_ID = Convert.ToInt64(dr["PT_ID"].ToString());
                    info.PT_Name = dr["PT_Name"].ToString();
                    info.PT_ParentID = Convert.ToInt64(dr["PT_ParentID"].ToString());
                    info.ModuleName = dr["ModuleName"].ToString();
                    info.FullId = dr["FullId"].ToString();
                    info.InfoCount = Core.MyConvert.GetInt32(dr["InfoCount"].ToString());
                    info.TradeId = Core.MyConvert.GetInt32(dr["TradeId"].ToString());
                    info.FlagName = dr["FlagName"].ToString();
                    info.IsCustomTemplate = dr["IsCustomTemplate"].ToString().Equals("True") ? true : false;
                }
            }
            return info;
        }

        /// <summary>
        /// ���ݷ����Ż�ȡ�ñ�ŵķ��༰�ñ�ŷ����µ��������� (������� 2011-03-30)
        /// </summary>
        /// <param name="parentId">������</param>
        /// <returns>���༯��</returns>
        public List<Model.ProductTypeInfo> GetItems(int parentId)
        {
            if (parentId < 0) parentId = 0;

            List<Model.ProductTypeInfo> infos = new List<Model.ProductTypeInfo>();

            string sql = "select b.*,(select count(1) from b_ProductType a where a.Pt_ParentId=b.pt_id) as ChildCount from b_ProductType  b where b.PT_ParentID=" + parentId + "";


            using (SqlDataReader dr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.Text, sql, null))
            {
                while (dr.Read())
                {
                    Model.ProductTypeInfo info = new Model.ProductTypeInfo();

                    info.PT_ID = Convert.ToInt64(dr["PT_ID"].ToString());
                    info.PT_Name = dr["PT_Name"].ToString();
                    info.PT_ParentID = Convert.ToInt64(dr["PT_ParentID"].ToString());
                    info.ModuleName = dr["ModuleName"].ToString();
                    info.FullId = dr["FullId"].ToString();
                    info.InfoCount = Core.MyConvert.GetInt32(dr["InfoCount"].ToString());
                    info.TradeId = Core.MyConvert.GetInt32(dr["TradeId"].ToString());
                    info.FlagName = dr["FlagName"].ToString();
                    info.IsCustomTemplate = dr["IsCustomTemplate"].ToString().Equals("True") ? true : false;
                    int childcount = XYECOM.Core.MyConvert.GetInt32(dr["ChildCount"].ToString());
                    info.ChildCount = childcount;
                    info.IsLeaf = (childcount == 0);
                    infos.Add(info);
                }
            }
            return infos;
        }

        /// <summary>
        /// ͨ�������Ż�ȡѡ��ķ����Լ����Ը����ķ������� ��������� 2011-03-30��
        /// </summary>
        /// <param name="typeId">������</param>
        /// <returns>�ȹط�������</returns>
        public string GetProductTypeNameByTypeId(int typeId)
        {
            StringBuilder res = new StringBuilder();
            if (typeId < 1)
            {
                return string.Empty;
            }

            string sql = "select PT_Name from b_producttype where charindex(','+cast(Pt_id as varchar(50))+',',(select FullID from  b_producttype  where Pt_id =" + typeId + "))>0 or pt_id=" + typeId + "";


            DataTable table = XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.Text, sql, null);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (i < 3)
                {
                    DataRow row = table.Rows[i];
                    res.Append(row["PT_Name"].ToString().Trim());
                    res.Append(">>");
                }
            }
            if (res.Length > 2)
            {
                res.Remove(res.Length - 2, 2);
            }
            return res.ToString();
        }
    }
}
