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
     /// �����������ݴ�����
     /// </summary>
    public class FriendLink
    {
        #region �����������
        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="efl">�����������������</param>
        /// <returns>���֡����ڵ���0��ʾ��ӳɹ�</returns>
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

        #region �޸���������
        /// <summary>
        /// �޸���������
        /// </summary>
        /// <param name="efl">�����������������</param>
        /// <returns>���֡����ڵ���0��ʾ�޸ĳɹ�</returns>
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
        /// �޸����������Ƽ�״̬
        /// </summary>
        /// <param name="FL_ID">�������ӱ��</param>
        /// <param name="FL_Flag">�Ƽ�״̬</param>
        /// <returns>���֡����ڵ���0��ʾ�޸ĳɹ�</returns>
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
        /// �����Ƽ�״̬
        /// </summary>
        /// <param name="FL_ID">��ϢId</param>
        /// <param name="isCommend">�Ƿ��Ƽ�</param>
        /// <returns>��Ӱ������</returns>
        public int UpdateIsCommend(short FL_ID, bool isCommend)
        {
            string strCmd = "0";

            if (isCommend) strCmd = "1";

            return XYECOM.Core.Function.UpdateColumuByWhere("FL_IsCommend", "" + strCmd, " where FL_ID=" + FL_ID, "b_friendLink");
        }
        #endregion

        #region ɾ����������
        /// <summary>
        /// ɾ��������������
        /// </summary>
        /// <param name="FL_IDs">�������ӱ���ַ���</param>
        /// <returns>���֡����ڵ���0��ʾɾ���ɹ�</returns>
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

        #region ��ȡ��������
        /// <summary>
        /// ��ȡ�ƶ���������
        /// </summary>
        /// <param name="FL_ID">�������ӱ��</param>
        /// <returns>�����������������</returns>
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
        /// ��ȡָ��������������������
        /// </summary>
        /// <param name="strWhere">����</param>
        /// <param name="strOrderBy">�������</param>
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
