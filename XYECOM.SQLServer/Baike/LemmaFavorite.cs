using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using XYECOM.Core.Data;

namespace XYECOM.SQLServer
{
    public class LemmaFavorite
    {
        public int Insert(XYECOM.Model.LemmaFavoriteInfo info)
        {
            SqlParameter[] param = new SqlParameter[]
            { 
                new SqlParameter("@LemmaId",info.LemmaId),
                new SqlParameter("@UserId",info.UserId),
                new SqlParameter("@Tags",info.Tags)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertLemmaFavorite", param);
        }

        public DataTable GetListByUserId(long userId) 
        {
            return Utils.ExecuteTable("XY_LemmaFavorite", "", "userid=" + userId);
        }

        public int Deletes(string infoids)
        {
            return Utils.Delete("XY_LemmaFavorite", "FavId in (" + infoids + ")");
        }
    }
}
