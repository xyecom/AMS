using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// 地区信息数据处理类
    /// </summary>
    public class Area:DataCache
    {
       /// <summary>
       /// 获取地区对象
       /// </summary>
       /// <param name="areaID">地区id</param>
       /// <returns>地区对象</returns>
        public XYECOM.Model.AreaInfo GetItem(int areaID)
        {
            XYECOM.Model.AreaInfo info = null;

            Object obj = GetCache();

            if (obj == null) return info;

            DataTable table = (DataTable)obj;

            DataRow[] rows = table.Select("id  = " + areaID);

            if (rows != null && rows.Length > 0)
            {
                info = new XYECOM.Model.AreaInfo();
                info.ID =Core.MyConvert.GetInt32(rows[0]["id"].ToString());
                info.ParentID = Core.MyConvert.GetInt32(rows[0]["ParentId"].ToString());
                info.Name = rows[0]["Name"].ToString();
                info.FullID = rows[0]["FullId"].ToString();
                if (info.FullID.Length > 0)
                {
                    info.FullName = GetFullName(info.FullID);
                }
                info.FullNameAll = "" == info.FullName ? info.Name : info.FullName + "," + info.Name;
            }
            return info;
        }
        /// <summary>
        /// 通过多个id获取对象集合
        /// </summary>
        /// <param name="ids">id集合，多个之间用逗号隔开</param>
        /// <returns>对象集合</returns>
        public List<Model.AreaInfo> GetItemsByIDs(string ids)
        {
            List<Model.AreaInfo> list = new List<XYECOM.Model.AreaInfo>();

            if ("" == ids) return list;

            Object obj = GetCache();

            if (obj == null) return list;

            DataTable table = (DataTable)obj;

            DataRow[] rows = table.Select("id in(" + ids + ")");

            if (rows != null && rows.Length > 0)
            {
                list = SetInfos(rows);
            }

            return list;
        }

        /// <summary>
        /// 获取该Id下的所有地区信息
        /// </summary>
        /// <param name="parentID">上级地区id</param>
        /// <returns>子地区集合</returns>
        public List<Model.AreaInfo> GetItems(int parentID)
        {
            List<Model.AreaInfo> list = new List<XYECOM.Model.AreaInfo>();

            Object obj = GetCache();

            if (obj == null) return list;

            DataTable table = (DataTable)obj;

            DataRow[] rows = table.Select("ParentID =" + parentID);

            if (rows != null && rows.Length > 0)
            {
                list = SetInfos(rows);
            }

            return list;
        }
        /// <summary>
        /// 将DataTable行对象集合转换为对象集合
        /// </summary>
        /// <param name="rows">DateTable行对象集合</param>
        /// <returns>对象集合</returns>
        private List<Model.AreaInfo> SetInfos(DataRow[] rows)
        {
            List<Model.AreaInfo> list = new List<XYECOM.Model.AreaInfo>();

            foreach (DataRow row in rows)
            {
                XYECOM.Model.AreaInfo Info = new XYECOM.Model.AreaInfo();

                Info.ID = Convert.ToInt32(row["ID"].ToString());
                Info.ParentID = Convert.ToInt32(row["ParentID"].ToString());
                Info.Name = Convert.ToString(row["Name"].ToString());
                Info.FullID = Convert.ToString(row["FullId"].ToString());

                if (Info.FullID.Length > 0)
                {
                    Info.FullName = GetFullName(Info.FullID);
                }
                
                Info.FullNameAll = "" == Info.FullName ? Info.Name : Info.FullName + "," + Info.Name;
                
                Info.HasSubArea = HasSubArea(Info.ID);

                list.Add(Info);
            }
            return list;
        }
        /// <summary>
        /// 获取完整地区名称
        /// </summary>
        /// <param name="fullId">完整地区id</param>
        /// <returns>地区名称</returns>
        private string GetFullName(string fullId)
        {
            Object obj = GetCache();

            if (obj == null) return "";

            DataTable table = (DataTable)obj;

            DataRow []rows = table.Select("id in (" + Core.Utils.RemoveComma(fullId) + ")","id asc");

            string name = "";

            if (rows != null)
            {
                foreach (DataRow row in rows)
                {
                    name += row["name"].ToString() + ",";
                }
            }

            return name;
        }

        /// <summary>
        /// 是否有子地区
        /// </summary>
        /// <param name="parentID">地区id</param>
        /// <returns>true:有，false:无</returns>
        public bool HasSubArea(int parentID)
        {
            Object obj = GetCache();

            if (obj == null) return false;

            DataTable table = (DataTable)obj;

            DataRow[] rows = table.Select("ParentID =" + parentID);

            if (rows != null && rows.Length > 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 获取所有子级地区Id（包括自己）
        /// </summary>
        /// <param name="areaId">地区Id</param>
        /// <returns>属于Id的信息不存在则返回空字符串</returns>
        public string GetSubIds(int areaId)
        {
            Object obj = GetCache();

            if (obj == null) return "";

            DataTable table = (DataTable)obj;

            DataRowCollection rows = FilterDataRows(table, areaId);

            string ids = "";

            if(rows != null && rows.Count >0)
            {
                foreach (DataRow row in rows)
                {
                    if (ids == "")
                        ids = row["ID"].ToString();
                    else
                        ids += "," + row["ID"].ToString();
                }
            }

            return ids;
        }

        /// <summary>
        /// 根据指定的地区Id总表中筛选出满足条件的行
        /// </summary>
        /// <param name="table">地区信息表</param>
        /// <param name="areaId">地区Id</param>
        /// <returns>满足条件数据集合</returns>
        private DataRowCollection FilterDataRows(DataTable table, int areaId)
        {
            DataTable _table = table.Clone();

            foreach (DataRow row in table.Rows)
            {
                if (row["Id"].ToString().Equals(areaId.ToString())
                    || row["ParentId"].ToString().Equals(areaId.ToString())
                    || row["FullId"].ToString().IndexOf("," + areaId + ",") != -1)
                {
                    _table.ImportRow(row);
                }
            }
            return _table.Rows;
        }
        /// <summary>
        /// 获取包括上级id的完整id
        /// </summary>
        /// <param name="parentID">地区id</param>
        /// <returns>id集合字符串</returns>
        private string GetFullID(int parentID)
        {
            string strFullIDs = "";

            XYECOM.Model.AreaInfo info = GetItem(parentID);

            if (info == null) return "0";

            if (info.ParentID != 0)
            {
                strFullIDs = GetFullID(info.ParentID) + "," + info.ID.ToString() + strFullIDs;
            }
            else
            {
                strFullIDs = info.ID.ToString();
            }
            return strFullIDs;
        }

        
        /// <summary>
        /// 插入地区信息
        /// </summary>
        /// <param name="info">地区数据对象</param>
        /// <returns>受影响的行数</returns>
        public int Insert(XYECOM.Model.AreaInfo info)
        {
            string fullId = Core.Utils.AppendComma(GetFullID(info.ParentID));

            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@ParentID",info.ParentID),
                new SqlParameter("@Name",info.Name ),
                new SqlParameter("@FullID", fullId)
            } ;

            int result =  XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertArea", parm);

            UpdateCache();

            return result;
        }
        

       /// <summary>
       /// 更新地区数据
       /// </summary>
       /// <param name="info">数据对象</param>
        /// <returns>受影响的行数</returns>
        public int Update(XYECOM.Model.AreaInfo info)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter ("@ID",info.ID ),
                new SqlParameter("@Name",info.Name)
            };

            int result = XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateArea", param);

            UpdateCache();

            return result;
        }
        

        #region 删除
        /// <summary>
        /// 删除指定编号的
        /// </summary>
        /// <param name="ctids">要删除的加工类别编号集</param>
        /// <returns>数字,大于或等于0表成功</returns>
        public int Delete(string mtids)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere"," where ID in ("+mtids+")"),
                new SqlParameter("@strTableName","XY_Area")
            };

            int result =  XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);

            UpdateCache();

            return result;
        }

        #endregion

        public override string SQL_Get_All
        {
            get { return "select * from xy_area"; }
        }
    }
}
