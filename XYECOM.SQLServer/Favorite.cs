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
    /// �ղ���Ϣ���ݴ�����
    /// </summary>
    public class Favorite
    {
        /// <summary>
        /// �����ղ���Ϣ
        /// </summary>
        /// <param name="info">ʵ�����</param>
        /// <returns>��Ӱ�������</returns>
        public int Insert(XYECOM.Model.FavoriteInfo info)
        {
            SqlParameter[] param = new SqlParameter[]
            { 
                new SqlParameter("@U_ID",info.U_ID),
                new SqlParameter("@DescTabName",info.DescTabName),
                new SqlParameter("@DescTabID",info.DescTabID)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertFavorites", param);
        }

        /// <summary>
        /// �޸��ղ���Ϣ
        /// </summary>
        /// <param name="info">ʵ�����</param>
        /// <returns>��Ӱ�������</returns>
        public int Update(XYECOM.Model.FavoriteInfo info)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@Fa_ID",info.Fa_ID),
                new SqlParameter("@U_ID",info.U_ID),
                new SqlParameter("@DescTabName",info.DescTabName),
                new SqlParameter("@DescTabID",info.DescTabID)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertFavorites", param);
        }

        /// <summary>
        /// ��ȡһ����¼
        /// </summary>
        /// <param name="Fa_ID">��¼���</param>
        /// <returns>���ݶ���</returns>
        public XYECOM.Model .FavoriteInfo  GetItem(int Fa_ID)
        {
            XYECOM.Model.FavoriteInfo ft = null;
            SqlParameter[] Parame = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," Where Fa_ID=" + Fa_ID.ToString()),
                new SqlParameter("@strTableName","pl_Favorite"),
                new SqlParameter("@strOrder","")
            };
            using (SqlDataReader rdr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", Parame))
            {
                if (rdr.Read())
                {
                    ft = new XYECOM.Model.FavoriteInfo();

                    ft.At_PulishDate = Convert.ToDateTime(rdr[""].ToString());
                    ft.DescTabID = Int64.Parse(rdr["DescTabID"].ToString());
                    ft.DescTabName = rdr["DescTabName"].ToString();
                    ft.Fa_ID = Int64.Parse(rdr["Fa_ID"].ToString());
                    ft.U_ID = Int64.Parse(rdr["U_ID"].ToString());
                }
            }
            return ft;
        }

        /// <summary>
        /// ɾ��һ����¼
        /// </summary>
        /// <param name="Fa_ID">��¼���</param>
        /// <returns>��Ӱ�������</returns>
        public int Delete(string  Fa_IDs)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where Fa_ID in ("+Fa_IDs .ToString ()+")"),
                new SqlParameter("@strTableName","pl_Favorite")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }
    }
}
