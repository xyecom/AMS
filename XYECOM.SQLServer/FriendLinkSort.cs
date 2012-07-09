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
    /// �������ӷ������ݴ�����
    /// </summary>
    public class FriendLinkSort
    {
         /// <summary>
         /// �����������������
         /// </summary>
         /// <param name="fs">��������������</param>
         /// <param name="fs_id">�����������������IDֵ</param>
         /// <returns>����,����0��ʾ��ӳɹ�</returns>
        public int Insert(XYECOM.Model.FriendLinkSortInfo fs, out int fs_id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("FS_ID",SqlDbType.Int),
                new SqlParameter("FS_Name",fs.FS_Name),
                new SqlParameter("FS_PID",fs.FS_PID),
                new SqlParameter("FS_Alt",fs.FS_Alt)
            };

            param[0].Direction = ParameterDirection.Output;

            int rowAffected = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertFriendLinkSort", param);
            if (param[0].Value.ToString() != null && param[0].Value.ToString() != "")
            {
                fs_id = Convert.ToInt32(param[0].Value);
            }
            else
            {
                fs_id = -1;
            }
            return rowAffected;
        }

         /// <summary>
         /// �޸�һ���������������Ϣ
         /// </summary>
         /// <param name="fs">Ҫ�޸ĵ���������������</param>
         /// <returns>����,����0��ʾ�޸ĳɹ�</returns>
        public int Update(XYECOM.Model.FriendLinkSortInfo fs)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@FS_ID",fs.FS_ID),
                new SqlParameter("@FS_Name",fs.FS_Name),
                new SqlParameter("@FS_PID",fs.FS_PID),
                new SqlParameter("@FS_Alt",fs.FS_Alt)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateFriendLinkSort", param);
        }

         /// <summary>
         /// ɾ��ָ�����������������Ϣ
         /// </summary>
         /// <param name="fs_ids">Ҫɾ���������������ID��</param>
         /// <returns>���֣�����0��ɾ���ɹ�</returns>
        public int Delete(string fs_ids)
        {
            SqlParameter [] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere","where FS_ID in ("+fs_ids+")"),
                new SqlParameter("@strTableName","b_FriendLinkSort")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }

        /// <summary>
        /// ��ȡ�����������ӷ���
        /// </summary>
        /// <returns></returns>
        public List<Model.FriendLinkSortInfo> GetItems()
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere",""),
                new SqlParameter("@strTableName","b_FriendLinkSort"),
                new SqlParameter("@strOrder","")
            };

            List<Model.FriendLinkSortInfo> infos = new List<XYECOM.Model.FriendLinkSortInfo>();

            using (SqlDataReader dr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                while (dr.Read())
                {
                    Model.FriendLinkSortInfo info = new XYECOM.Model.FriendLinkSortInfo();
                    info.FS_ID = Core.MyConvert.GetInt32(dr["FS_ID"].ToString());
                    info.FS_Name = dr["FS_Name"].ToString();
                    info.FS_Alt = dr["FS_Alt"].ToString();

                    infos.Add(info);
                }
            }

            return infos;
        }
         
        /// <summary>
        /// �õ�����������DataTable���͵��������������Ϣ
        /// </summary>
        /// <param name="strWhere">�����������������Ϣ��Where����</param>
        /// <param name="strOrderBy">�����������������Ϣ��OrderBy����</param>
        /// <returns>DataTable���͵������ѯ�������������������Ϣ</returns>
        public DataTable GetDataTable(string strWhere, string strOrderBy)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere",strWhere),
                new SqlParameter("@strTableName","b_FriendLinkSort"),
                new SqlParameter("@strOrder",strOrderBy)
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure,"XYP_SelectByWhere", param);
        }

        /// <summary>
        /// ����ָ��IDֵ�жϸ���������Ǹ����������
        /// </summary>
        /// <param name="fs_ids">ָ�������IDֵ</param>
        /// <returns>����,����0���������,������������</returns>
        public int GetSonType(string fs_ids)
        {
            string strWhere = " FS_PID in("+fs_ids+")";
            string strTableName = " b_FriendLinkSort";

            return Utils.GetTotalRecotd(strTableName,"FS_ID",strWhere);
        }

        /// <summary>
        /// ���������������ID��ȡ����������������
         /// </summary>
         /// <param name="fsid">Ҫ��ȡ��������������ID</param>
         /// <returns>������������������</returns>
        public string GetFriendLinkName(int fsid)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere","where FS_ID="+fsid.ToString()),
                new SqlParameter("@strTableName","b_FriendLinkSort"),
                new SqlParameter("@strOrder","")
            };

            string FriendLinkName = "";
            
            using (SqlDataReader dr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure,"XYP_SelectByWhere", param))
            {
                if (dr.Read())
                {
                    FriendLinkName = dr["FS_Name"].ToString();
                }
            }

            return FriendLinkName;
        }
    }
}
