using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using XYECOM.Core.Data;
using XYECOM.Core;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// ��Ƹ��Ϣ���ݴ�����
    /// </summary>
    public class Engageinfo
    {
        /// <summary>
        /// ������Ƹ��Ϣ
        /// </summary>
        /// <param name="info">ʵ�����</param>
        /// <param name="esid">���ص���Ϣid</param>
        /// <returns>��Ӱ�������</returns>
        public int Insert(XYECOM.Model.Engageinfo info, out long esid)
        {
            SqlParameter[] param = new SqlParameter[]
            { 
                new SqlParameter("@EI_ID",SqlDbType.BigInt),
                new SqlParameter("@P_ID",info.PostId),
                new SqlParameter("@EI_Job",info.JobTitle),
                new SqlParameter("@EI_Branch",info.JobBranch),
                new SqlParameter("@EI_EndDate",info.EndDate),
                new SqlParameter("@EI_Type",info.JobType),
                new SqlParameter("@EI_Request",info.Request),
                new SqlParameter("@EI_Pay",info.Pay),
                new SqlParameter("@EI_Eb",info.Education),
                new SqlParameter("@EI_Age",info.Age),
                new SqlParameter("@EI_Sex",info.Sex),
                new SqlParameter("@EI_Experience",info.Experience),
                new SqlParameter("@EI_Nationality",info.Nationality),
                new SqlParameter("@U_ID",info.UserId),
                new SqlParameter("@EI_ClickNum",info.ClickNum),
                new SqlParameter("@EI_Number",info.Number),
                new SqlParameter ("@Area_ID",info.WorkAreaID )               
            };

            param[0].Direction = ParameterDirection.Output;

            int rowAffected = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertEngage", param);

            if (rowAffected >= 0)
            {
                if (param[0].Value != null && param[0].Value.ToString() != "")
                    esid = (long)param[0].Value;
                else
                    esid = 0;
            }
            else
            {
                esid = -1;
            }

            return rowAffected;
        }
        /// <summary>
        /// �޸���Ƹ��Ϣ
        /// </summary>
        /// <param name="E">ʵ�����</param>
        /// <returns>��Ӱ�������</returns>
        public int Update(XYECOM.Model.Engageinfo E)
        {
            SqlParameter[] param = new SqlParameter[]
            { 
                new SqlParameter("@P_ID",E.PostId),
                new SqlParameter("@EI_Job",E.JobTitle),
                new SqlParameter("@EI_Branch",E.JobBranch),
                new SqlParameter("@EI_EndDate",E.EndDate),
                new SqlParameter("@EI_Type",E.JobType),
                new SqlParameter("@EI_Request",E.Request),
                new SqlParameter("@EI_Pay",E.Pay),
                new SqlParameter("@EI_Eb",E.Education),
                new SqlParameter("@EI_Age",E.Age),
                new SqlParameter("@EI_Sex",E.Sex),
                new SqlParameter("@EI_Experience",E.Experience),
                new SqlParameter("@EI_Nationality",E.Nationality),
                new SqlParameter("@U_ID",E.UserId),
                new SqlParameter("@EI_ID",E.JobId),
                new SqlParameter("@EI_Number",E.Number),
                new SqlParameter ("@Area_ID",E .WorkAreaID )
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateEngage", param);
        }
        /// <summary>
        /// ɾ��������¼
        /// </summary>
        /// <param name="ID">��¼���</param>
        /// <returns>��Ӱ�������</returns>
        public int Delete(string ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where EI_ID in ("+ID+")"),
                new SqlParameter("@strTableName","i_engageinfo")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }
        /// <summary>
        /// ��ȡһ����¼
        /// </summary>
        /// <param name="JobId">��¼���</param>
        /// <returns>���ݶ���</returns>
        public XYECOM.Model.Engageinfo GetItem(long JobId)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," Where EI_ID=" + JobId.ToString()),
                new SqlParameter("@strTableName","XYV_Engageinfo"),
                new SqlParameter("@strOrder","")
            };

            XYECOM.Model.Engageinfo info = null;

            using (SqlDataReader sdr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure,"XYP_SelectByWhere", param))
            {
                if (sdr.Read())
                {
                    info = new XYECOM.Model.Engageinfo();

                    info.JobId = Core.MyConvert.GetInt32(sdr["EI_ID"].ToString());
                    info.PostId = Core.MyConvert.GetInt32(sdr["P_ID"].ToString());
                    info.JobTitle = sdr["EI_Job"].ToString();
                    info.JobBranch = sdr["EI_Branch"].ToString();
                    if (sdr["EI_EndDate"].ToString() != "")
                    {
                        info.EndDate = Convert.ToDateTime(sdr["EI_EndDate"].ToString());
                    }
                    info.JobType = sdr["EI_Type"].ToString();
                    info.Request = sdr["EI_Request"].ToString();
                    info.Pay = sdr["EI_Pay"].ToString();
                    info.Education = sdr["EI_Eb"].ToString();
                    info.Age = sdr["EI_Age"].ToString();
                    info.Sex = sdr["EI_Sex"].ToString();
                    info.Experience = sdr["EI_Experience"].ToString();
                    info.Nationality = sdr["EI_Nationality"].ToString();
                    info.UserId = Core.MyConvert.GetInt64(sdr["U_ID"].ToString());

                    if (sdr["EI_AddDate"].ToString() != "")
                    {
                        info.AddDate = Convert.ToDateTime(sdr["EI_AddDate"].ToString());
                    }

                    info.ClickNum = Core.MyConvert.GetInt32(sdr["EI_ClickNum"].ToString());

                    info.PostName = sdr["P_Name"].ToString();

                    info.WorkAreaID = Core.MyConvert.GetInt32(sdr["WorkAreaID"].ToString());

                    info.WorkAreaInfo = new Area().GetItem(info.WorkAreaID);

                    info.Number = Core.MyConvert.GetInt32(sdr["EI_Number"].ToString());

                    if (Convert.ToBoolean(sdr["EI_Puach"].ToString()) == true)
                    {
                        info.IsPause = true;
                    }
                    else
                    {
                        info.IsPause = false;
                    }
                }
            }
            return info;
        }


        /// <summary>
        /// ��ȡһ����Ƹ��Ϣ
        /// </summary>
        /// <param name="EI_ID">��ϢId</param>
        /// <returns>DataTable����</returns>
        public DataTable GetDataTable(long EI_ID)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strwhere","where EI_ID="+EI_ID),
                new SqlParameter("@strtableName","XYV_Engageinfo"),
                new SqlParameter("@strOrder","")
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure,"XYP_SelectByWhere", param);
        }

        /// <summary>
        /// �Ƽ���ȡ���Ƽ���Ƹ��Ϣ
        /// </summary>
        /// <param name="jobId">��Ƹ��¼Id</param>
        /// <param name="isVouch">�Ƿ��Ƽ�</param>
        /// <returns></returns>
        public int UpdateVouch(long jobId, bool isVouch)
        {
            if (isVouch)
                return Function.UpdateSD_Pause("i_engageinfo", " where EI_ID =" + jobId.ToString(), " EI_Vouch=1 ");
            else
                return Function.UpdateSD_Pause("i_engageinfo", " where EI_ID =" + jobId.ToString(), " EI_Vouch=0 ");
        }
    }
}
