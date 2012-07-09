using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// 简历数据处理类
    /// </summary>
    public class Resume
    {
        /// <summary>
        /// 添加简历
        /// </summary>
        /// <param name="Re">实体对象</param>
        /// <returns>受影响行数</returns>
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
        /// 修改简历
        /// </summary>
        /// <param name="Re">实体对象</param>
        /// <returns>受影响行数</returns>
        public int Update(XYECOM.Model.ResumeInfo Re)
        {
            return Insert(Re);
        }
        /// <summary>
        /// 返回XYECOM.Model
        /// </summary>
        /// <param name="U_ID">用户ID</param>
        /// <returns>数据对象</returns>
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
        /// 投简历
        /// </summary>
        /// <param name="U_ID"> 用户ID</param>
        /// <param name="EI_ID">职位ID</param>
        /// <returns>是否成功>0成功</returns>
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
        /// 获取列表
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
        /// 更新简历状态
        /// </summary>
        /// <param name="RE_ID">简历记录Id</param>
        /// <param name="type">状态</param>
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
        /// 查看招聘信息并更改报名状态
        /// </summary>
        /// <param name="EF_ID">报名批次编号</param>
        /// <param name="type">要更改的状态</param>
        /// <returns>数字,大于或等于0表成功,否则表失败</returns>
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
        /// 删除多条记录
        /// </summary>
        /// <param name="Ids">id字符串,多个用逗号隔开</param>
        /// <returns>受影响的行数</returns>
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
        /// 返回满足条件的简历
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <param name="Order">表名</param>
        /// <returns>满足条件的记录</returns>
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
