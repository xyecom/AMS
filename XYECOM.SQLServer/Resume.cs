using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// �������ݴ�����
    /// </summary>
    public class Resume
    {
        /// <summary>
        /// ��Ӽ���
        /// </summary>
        /// <param name="Re">ʵ�����</param>
        /// <returns>��Ӱ������</returns>
        public int Insert(XYECOM.Model.ResumeInfo Re)
        {
            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter ("@U_ID",Re.U_ID),                   
                new SqlParameter("@RE_JobYear",Re.RE_JobYear),                   
                new SqlParameter ("@RE_Resume",Re.RE_Resume),
                new SqlParameter ("@RE_School",Re.RE_School),
                new SqlParameter ("@RE_Schoolage",Re.RE_Schoolage),
                new SqlParameter ("@RE_Speciality",Re.RE_Speciality),
                new SqlParameter ("@RE_Experience",Re.RE_Experience),
                new SqlParameter ("@RE_Intentpay",Re.RE_Intentpay),
                new SqlParameter ("@RE_Intentadd",Re.RE_Intentadd),
                new SqlParameter ("@RE_Intentjob",Re.RE_Intentjob),                  
                new SqlParameter ("@RE_Gyear",Re.RE_Gyear)
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertResume", Param);
        }
        /// <summary>
        /// �޸ļ���
        /// </summary>
        /// <param name="Re">ʵ�����</param>
        /// <returns>��Ӱ������</returns>
        public int Update(XYECOM.Model.ResumeInfo Re)
        {
            return Insert(Re);
        }
        /// <summary>
        /// ����XYECOM.Model
        /// </summary>
        /// <param name="U_ID">�û�ID</param>
        /// <returns>���ݶ���</returns>
        public XYECOM.Model.ResumeInfo GetItem(long U_ID)
        {
            XYECOM.Model.ResumeInfo resume = null;

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," Where U_ID=" + U_ID.ToString()),
                new SqlParameter("@strTableName","U_Resume"),
                new SqlParameter("@strOrder","")
            };

            using (SqlDataReader dr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (dr.Read())
                {
                    resume = new XYECOM.Model.ResumeInfo();
                    resume.U_ID = Convert.ToInt32(dr["U_ID"].ToString());
                    resume.RE_Adddate = Convert.ToDateTime(dr["RE_Adddate"].ToString());
                    resume.RE_Experience = dr["RE_Experience"].ToString();
                    resume.RE_Intentadd = dr["RE_Intentadd"].ToString();
                    resume.RE_Intentjob = dr["RE_Intentjob"].ToString();
                    resume.RE_Intentpay = dr["RE_Intentpay"].ToString();
                    resume.RE_JobYear = dr["RE_JobYear"].ToString();
                    resume.RE_Resume = dr["RE_Resume"].ToString();
                    resume.RE_School = dr["RE_School"].ToString();
                    resume.RE_Schoolage = dr["RE_Schoolage"].ToString();
                    resume.RE_Speciality = dr["RE_Speciality"].ToString();
                    resume.RE_Gyear = Convert.ToDateTime(dr["RE_Gyear"].ToString());
                    resume.Re_htmlpage = dr["RE_HtmlPage"].ToString();
                }
            }

            return resume;
        }
        /// <summary>
        /// Ͷ����
        /// </summary>
        /// <param name="U_ID"> �û�ID</param>
        /// <param name="EI_ID">ְλID</param>
        /// <returns>�Ƿ�ɹ�>0�ɹ�</returns>
        public int AddResume(long U_ID, long EI_ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@U_ID",U_ID),
                new SqlParameter("@EI_ID",EI_ID)
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertJobResume", param);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="ER_ID"></param>
        /// <returns></returns>
        public DataTable GetDataTable(long ER_ID)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strwhere","where ER_ID="+ER_ID),
                new SqlParameter("@strtableName","XYV_JobResume"),
                new SqlParameter("@strOrder","")
            };

            return XYECOM.Core.Data.SqlHelper.GetDataTable("XYP_SelectByWhere", param);
        }

        //public DataTable GetDataTables(long id,String tablename) {
        //    SqlParameter[] param = new SqlParameter[]
        //    {
        //        new SqlParameter("@strwhere","where U_ID="+id),
        //        new SqlParameter("@strtableName",tablename),
        //        new SqlParameter("@strOrder","")
        //    };

        //    return XYECOM.Core.Data.SqlHelper.GetDataTable("XYP_SelectByWhere", param);
        //}


        /// <summary>
        /// ���¼���״̬
        /// </summary>
        /// <param name="RE_ID">������¼Id</param>
        /// <param name="type">״̬</param>
        /// <returns></returns>
        public int UpdateType(long RE_ID, int type)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                 new SqlParameter("@RE_ID",RE_ID),
                new SqlParameter("@RE_Estate",type)             
                
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateJobResume", param);
        }

        /// <summary>
        /// �鿴��Ƹ��Ϣ�����ı���״̬
        /// </summary>
        /// <param name="EF_ID">�������α��</param>
        /// <param name="type">Ҫ���ĵ�״̬</param>
        /// <returns>����,���ڻ����0��ɹ�,�����ʧ��</returns>
        public int UpdateLookTyep(long RE_ID, int type)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@RE_ID",RE_ID),
                new SqlParameter("@RE_Estate",type)                      
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateLookJobResume", param);
        }

        /// <summary>
        /// ɾ��������¼
        /// </summary>
        /// <param name="Ids">id�ַ���,����ö��Ÿ���</param>
        /// <returns>��Ӱ�������</returns>
        public int Deletes(string Ids)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where ER_ID in ("+Ids+")"),
                new SqlParameter("@strTableName","u_JobResume")
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "usp_DeleteByWhere", param);
        }

        /// <summary>
        /// �������������ļ���
        /// </summary>
        /// <param name="strWhere">����</param>
        /// <param name="Order">����</param>
        /// <returns>���������ļ�¼</returns>
        public DataTable GetDataTable(int PageSize, int PageIndex, string strWhere, string strOrder, string strTableName, string strColumuName, string strPrimaryKey)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {                 
                
                new SqlParameter("@PageSize",SqlDbType.Int),
				new SqlParameter("@PageIndex",SqlDbType.Int),
				new SqlParameter("@strWhere",SqlDbType.VarChar,200),
				new SqlParameter("@strOrder",SqlDbType.VarChar,50),
				new SqlParameter("@strTableName",SqlDbType.VarChar,50),
				new SqlParameter("@strPrimaryKey",SqlDbType.VarChar,50),
				new SqlParameter("@strColumuName",SqlDbType.VarChar,500),
            };

            parameters[0].Value = PageSize;
            parameters[1].Value = PageIndex;
            parameters[2].Value = strWhere;
            parameters[3].Value = strOrder;
            parameters[4].Value = strTableName;
            parameters[5].Value = strPrimaryKey;
            parameters[6].Value = strColumuName;

            return XYECOM.Core.Data.SqlHelper.GetDataTable("XYP_SelectByPage", parameters);
        }
    }
}
