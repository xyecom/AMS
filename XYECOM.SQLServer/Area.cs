using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// ������Ϣ���ݴ�����
    /// </summary>
    public class Area:DataCache
    {
       /// <summary>
       /// ��ȡ��������
       /// </summary>
       /// <param name="areaID">����id</param>
       /// <returns>��������</returns>
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
        /// ͨ�����id��ȡ���󼯺�
        /// </summary>
        /// <param name="ids">id���ϣ����֮���ö��Ÿ���</param>
        /// <returns>���󼯺�</returns>
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
        /// ��ȡ��Id�µ����е�����Ϣ
        /// </summary>
        /// <param name="parentID">�ϼ�����id</param>
        /// <returns>�ӵ�������</returns>
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
        /// ��DataTable�ж��󼯺�ת��Ϊ���󼯺�
        /// </summary>
        /// <param name="rows">DateTable�ж��󼯺�</param>
        /// <returns>���󼯺�</returns>
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
        /// ��ȡ������������
        /// </summary>
        /// <param name="fullId">��������id</param>
        /// <returns>��������</returns>
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
        /// �Ƿ����ӵ���
        /// </summary>
        /// <param name="parentID">����id</param>
        /// <returns>true:�У�false:��</returns>
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
        /// ��ȡ�����Ӽ�����Id�������Լ���
        /// </summary>
        /// <param name="areaId">����Id</param>
        /// <returns>����Id����Ϣ�������򷵻ؿ��ַ���</returns>
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
        /// ����ָ���ĵ���Id�ܱ���ɸѡ��������������
        /// </summary>
        /// <param name="table">������Ϣ��</param>
        /// <param name="areaId">����Id</param>
        /// <returns>�����������ݼ���</returns>
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
        /// ��ȡ�����ϼ�id������id
        /// </summary>
        /// <param name="parentID">����id</param>
        /// <returns>id�����ַ���</returns>
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
        /// ���������Ϣ
        /// </summary>
        /// <param name="info">�������ݶ���</param>
        /// <returns>��Ӱ�������</returns>
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
       /// ���µ�������
       /// </summary>
       /// <param name="info">���ݶ���</param>
        /// <returns>��Ӱ�������</returns>
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
        

        #region ɾ��
        /// <summary>
        /// ɾ��ָ����ŵ�
        /// </summary>
        /// <param name="ctids">Ҫɾ���ļӹ�����ż�</param>
        /// <returns>����,���ڻ����0��ɹ�</returns>
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
