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
     /// 友情链接数据处理类
     /// </summary>
    public class FriendLink
    {
        #region 添加友情链接
        /// <summary>
        /// 添加友情链接
        /// </summary>
        /// <param name="efl">友情链接属性类对象</param>
        /// <returns>数字。大于等于0表示添加成功</returns>
        public int Insert(XYECOM.Model.FriendLinkInfo efl, out short FL_ID)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
				    new SqlParameter("@FL_ID",SqlDbType.SmallInt),
                    new SqlParameter ("@FL_Type",efl.FL_Type),
                    new  SqlParameter ("@FL_Font",efl.FL_Font ),
                    new SqlParameter ("@FL_URL",efl.FL_URL ),
                    new SqlParameter("@FL_Alt",efl.FL_Alt),
                    new SqlParameter("@FL_Flag",efl.FL_Flag),
                    new SqlParameter("@FS_ID",efl.FS_ID)
                };


            parm[0].Direction = ParameterDirection.Output;
            int err = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertFriendLink", parm);

            if (parm[0].Value != null && parm[0].Value.ToString() != "")
            {
                FL_ID = Convert.ToInt16(parm[0].Value);
            }
            else
            {
                FL_ID = -1;
            }

            return err;
        }
        #endregion

        #region 修改友情链接
        /// <summary>
        /// 修改友情链接
        /// </summary>
        /// <param name="efl">友情链接属性类对象</param>
        /// <returns>数字。大于等于0表示修改成功</returns>
        public int Update(XYECOM.Model.FriendLinkInfo efl)
        {
            SqlParameter[] parm = new SqlParameter[]{
                new SqlParameter("@FL_ID",efl.FL_ID),
                new SqlParameter ("@FL_Type",efl.FL_Type),
                new  SqlParameter ("@FL_Font",efl.FL_Font ),
                new SqlParameter ("@FL_URL",efl.FL_URL ),
                new SqlParameter("@FL_Alt",efl.FL_Alt),
                new SqlParameter("@FL_Flag",efl.FL_Flag),
                new SqlParameter("@FS_ID",efl.FS_ID)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateFriendLink", parm);
        }
        /// <summary>
        /// 修改友情链接推荐状态
        /// </summary>
        /// <param name="FL_ID">友情链接编号</param>
        /// <param name="FL_Flag">推荐状态</param>
        /// <returns>数字。大于等于0表示修改成功</returns>
        public int UpdateForFlag(short FL_ID, bool FL_Flag)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@FL_ID",FL_ID),
                new SqlParameter ("@FL_Flag",FL_Flag),                   
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateFriendLinkForFlag", parm);
        }

        /// <summary>
        /// 更新推荐状态
        /// </summary>
        /// <param name="FL_ID">信息Id</param>
        /// <param name="isCommend">是否推荐</param>
        /// <returns>受影响行数</returns>
        public int UpdateIsCommend(short FL_ID, bool isCommend)
        {
            string strCmd = "0";

            if (isCommend) strCmd = "1";

            return XYECOM.Core.Function.UpdateColumuByWhere("FL_IsCommend", "" + strCmd, " where FL_ID=" + FL_ID, "b_friendLink");
        }
        #endregion

        #region 删除友情链接
        /// <summary>
        /// 删除多条友情链接
        /// </summary>
        /// <param name="FL_IDs">友情链接编号字符串</param>
        /// <returns>数字。大于等于0表示删除成功</returns>
        public int Delete(string FL_IDs)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where FL_ID in ("+FL_IDs+")"),
                new SqlParameter("@strTableName","b_FriendLink")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }
        #endregion

        #region 获取友情链接
        /// <summary>
        /// 获取制定友情链接
        /// </summary>
        /// <param name="FL_ID">友情链接编号</param>
        /// <returns>友情链接属性类对象</returns>
        public XYECOM.Model.FriendLinkInfo GetItem(short FL_ID)
        {

            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter ("@strWhere","where FL_ID="+FL_ID .ToString ()),
                new SqlParameter ("@strTableName","XYV_FriendLink"),
                new SqlParameter("@strOrder"," order by FL_ID DESC ")
            };
            
            XYECOM.Model.FriendLinkInfo efl = null;

            using (SqlDataReader dr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure,"XYP_SelectByWhere", parm))
            {
                if (dr.Read())
                {
                    efl = new XYECOM.Model.FriendLinkInfo();

                    efl.FL_ID = FL_ID;
                    if (dr["FL_Type"].ToString() != "")
                    {
                        efl.FL_Type = Convert.ToBoolean(dr["FL_Type"].ToString());
                    }
                    else
                        efl.FL_Type = false;
                    efl.FL_URL = dr["FL_URL"].ToString();
                    efl.FL_Alt = dr["FL_Alt"].ToString();
                    efl.FL_AddDate = dr["FL_AddDate"].ToString();
 
                    if (dr["FL_Flag"].ToString() != "")
                    {
                        efl.FL_Flag = Convert.ToBoolean(dr["FL_Flag"].ToString());
                    }
                    else
                        efl.FL_Flag = false;

                    efl.FL_Font = dr["FL_Font"].ToString();

                    if (dr["FS_ID"].ToString() != "")
                        efl.FS_ID = Convert.ToInt32(dr["FS_ID"].ToString());
                    else
                        efl.FS_ID = 0;
                }
            }

            return efl;
        }

        /// <summary>
        /// 获取指定条件和排序规则的数据
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <param name="strOrderBy">排序规则</param>
        /// <returns></returns>
        public DataTable GetDataTable(string strWhere,string strOrderBy)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere",strWhere),
                new SqlParameter("@strTableName","XYV_FriendLink"),
                new SqlParameter("@strOrder",strOrderBy)
            };
            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure,"XYP_SelectByWhere", param);
        }
        #endregion
    }
}
