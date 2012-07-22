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
    /// �û�ע��������ݴ�����
    /// </summary>
    public class UserReg
    {
        #region ����û�
        /// <summary>
        /// ����û�
        /// </summary>
        /// <param name="eu">ʵ����</param>
        /// <param name="U_ID">����ӵ��û����Զ����</param>
        /// <returns>��Ӱ�������</returns>
        public int Insert(XYECOM.Model.UserRegInfo eu, out long U_ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@U_ID",SqlDbType.BigInt),
                new SqlParameter("@U_Name",eu.LoginName),
                new SqlParameter("@U_Email",eu.Email),
                new SqlParameter("@U_PassWord",eu.Password),
                new SqlParameter("@U_Question",eu.Question),
                new SqlParameter("@U_Answer",eu.Answer),
                new SqlParameter("@UG_ID",eu .GradeId ),
                new SqlParameter("@U_Flag",true),
                new SqlParameter("@AccountId",eu.AccountId),
                new SqlParameter("@AreaId",eu.AreaId),
                new SqlParameter("@UserType",(int)eu.UserType),
                new SqlParameter("@CompanyId",eu.CompanyId),
                new SqlParameter("@IsPrimary",eu.IsPrimary)
            };

            param[0].Direction = ParameterDirection.Output;

            int rowAffected = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertUser", param);

            if (rowAffected >= 0)
                U_ID = (long)param[0].Value;
            else
                U_ID = -1;

            return rowAffected;
        }
        #endregion

        /// <summary>
        /// ��ȡ�û������״̬
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>true ���ͨ��</returns>
        public bool GetUserAuditingState(string userName)
        {
            SqlParameter[] Parame = new SqlParameter[]
            {
                new SqlParameter("@Top",""),
                new SqlParameter("@Columns","UserAuditingState"),
                new SqlParameter("@Table","u_User"),
                new SqlParameter("@Where","U_Name='" + userName + "'"),
                new SqlParameter("@Order","")
            };
            bool result = false;
            using (SqlDataReader dr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_CommonSelect", Parame))
            {
                if (dr.Read())
                {
                    if (dr[0].ToString() == "1")
                        result = true;
                }
            }
            return result;
        }

        #region ��ȡһ����¼
        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <param name="nameOrEmail">��¼�����ʼ���ַ</param>
        /// <returns></returns>
        public XYECOM.Model.UserRegInfo GetItem(string nameOrEmailOrAccountId)
        {
            int accountId = XYECOM.Core.MyConvert.GetInt32(nameOrEmailOrAccountId);

            string where = string.Empty;

            if (accountId > 0)
            {
                where = " where AccountId=" + nameOrEmailOrAccountId;
            }
            else
            {
                where = " where U_Name='" + nameOrEmailOrAccountId + "' Or U_Email='" + nameOrEmailOrAccountId + "'";
            }

            SqlParameter[] param = new SqlParameter[]
             {
                new SqlParameter ("@strWhere",where),
                new SqlParameter ("@strTableName","u_User"),
                new SqlParameter ("@strOrder","") 
             };

            XYECOM.Model.UserRegInfo info = null;

            using (SqlDataReader dr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                info = ReadData(dr);
            }

            return info;
        }

        /// <summary>
        /// ��ȡ�û���Ϣ
        /// </summary>
        /// <param name="nameOrEmail">�û���/Email</param>
        /// <param name="password">����(MD5���ܺ��ַ���)</param>
        /// <returns></returns>
        public XYECOM.Model.UserRegInfo GetItem(string nameOrEmail, string password)
        {
            SqlParameter[] param = new SqlParameter[]
             {
                new SqlParameter ("@strWhere"," where (U_Name='"+nameOrEmail+"' and U_Password='"+password+"') Or (U_Email='"+nameOrEmail+"' and U_Password='"+password+"')"),
                new SqlParameter ("@strTableName","u_User"),
                new SqlParameter ("@strOrder","") 
             };

            XYECOM.Model.UserRegInfo info = null;

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                info = ReadData(reader);
            }

            return info;
        }

        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <param name="userId">�û�id</param>
        /// <returns>�û����ݶ���</returns>
        public XYECOM.Model.UserRegInfo GetItem(long userId)
        {
            SqlParameter[] param = new SqlParameter[]
                 {
                    new SqlParameter ("@strWhere"," where U_ID="+userId),
                    new SqlParameter ("@strTableName","u_User"),
                    new SqlParameter ("@strOrder","") 
                 };

            XYECOM.Model.UserRegInfo info = null;

            using (SqlDataReader dr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                info = ReadData(dr);
            }
            return info;
        }

        /// <summary>
        /// ��SqlDataReader �ж�ȡ����
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private XYECOM.Model.UserRegInfo ReadData(SqlDataReader reader)
        {
            XYECOM.Model.UserRegInfo info = null;

            if (reader.Read())
            {
                info = new XYECOM.Model.UserRegInfo();

                info.Answer = reader["U_Answer"].ToString();
                info.LoginName = reader["U_Name"].ToString();
                info.ClickNum = Core.MyConvert.GetInt32(reader["U_ClickNum"].ToString());
                info.Email = reader["U_Email"].ToString();
                info.HTMLPage = reader["U_HtmlPage"].ToString();
                info.UserId = Core.MyConvert.GetInt32(reader["U_ID"].ToString());
                info.Mark = Core.MyConvert.GetInt32(reader["U_Mark"].ToString());
                info.LoginName = reader["U_Name"].ToString();
                info.Password = reader["U_PassWord"].ToString();
                info.Question = reader["U_Question"].ToString();
                info.RegDate = Core.MyConvert.GetDateTime(reader["U_RegDate"].ToString());

                info.GradeId = Core.MyConvert.GetInt32(reader["UG_ID"].ToString());


                info.Cred = Core.MyConvert.GetInt32(reader["U_Cred"].ToString());
                info.MessageNum = Core.MyConvert.GetInt32(reader["U_MessageNum"].ToString());
                info.NoMessgeNum = Core.MyConvert.GetInt32(reader["U_NoMessgeNum"].ToString());

                if (reader["U_TempName"].ToString() != "")
                    info.TemplateName = reader["U_TempName"].ToString();
                else
                    info.TemplateName = "default";

                info.CommonErr = Core.MyConvert.GetInt32(reader["U_CommonErr"].ToString());

                info.MaliceErr = Core.MyConvert.GetInt32(reader["U_MaliceErr"].ToString());

                info.InFormation = Core.MyConvert.GetInt32(reader["U_InFormation"].ToString());

                info.IsPuach = Core.MyConvert.GetBoolean(reader["U_Puach"].ToString());

                info.IsVouch = Core.MyConvert.GetBoolean(reader["U_Vouch"].ToString());

                info.IsActivation = Core.MyConvert.GetBoolean(reader["U_Activation"].ToString());


                if (reader["userAuditingState"].ToString().Equals(""))
                {
                    info.AuditingState = XYECOM.Model.AuditingState.Null;
                }
                else if (reader["userAuditingState"].ToString().Equals("1"))
                {
                    info.AuditingState = XYECOM.Model.AuditingState.Passed;
                }
                else
                {
                    info.AuditingState = XYECOM.Model.AuditingState.NoPass;
                }

                info.IsHasImage = false;
                if (reader["UserIsHasImage"].ToString().Equals("1"))
                {
                    info.IsHasImage = true;
                }

                info.AccountId = Core.MyConvert.GetInt32(reader["AccountId"].ToString());
                info.CreditIntegral = Core.MyConvert.GetDecimal(reader["CreditIntegral"].ToString());
                info.CreditLeavl = new CreditLeavlAccess().GetItemByPoint(info.CreditIntegral);

                info.IsPrimary = Core.MyConvert.GetBoolean(reader["IsPrimary"].ToString());
                info.LayerName = reader["LayerName"].ToString();
                info.LayerId = reader["LayerId"].ToString();

                info.Description = reader["Description"].ToString();
                info.DelState = Core.MyConvert.GetInt32(reader["DelState"].ToString());
                info.Telphone = reader["Telphone"].ToString();
                info.OtherContact = reader["OtherContact"].ToString();
                string strSex = reader["Sex"].ToString();
                if (!string.IsNullOrEmpty(strSex)) 
                {
                    info.Sex = bool.Parse(strSex);
                }
                
                info.IdNumber = reader["IdNumber"].ToString();

                info.AreaId = Core.MyConvert.GetInt32(reader["AreaId"].ToString());
                info.IsExport = Core.MyConvert.GetBoolean(reader["IsExport"].ToString()); ;
                info.UserType = Core.MyConvert.GetInt32(reader["UserType"].ToString());
                info.IdentityNumber = reader["IdentityNumber"].ToString();

                info.CompanyId = Core.MyConvert.GetInt32(reader["CompanyId"].ToString());

                info.PartManagerTel = reader["PartManagerTel"].ToString();
                info.PartManagerName = reader["PartManagerName"].ToString();
            }

            return info;
        }
        #endregion

        #region �޸��û�����
        /// <summary>
        /// �޸��û�����
        /// </summary>
        /// <param name="UserName">�û���</param>
        /// <param name="Password">����</param>
        /// <returns>��Ӱ�������</returns>
        public int UpdatePassWord(long U_ID, string Password)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@U_ID",U_ID ),
                new SqlParameter("@U_PassWord",Password)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateUserPassword", param);
        }
        #endregion

        #region �����û������Ƿ��Ѿ�����
        /// <summary>
        /// �����û������Ƿ��Ѿ�����
        /// </summary>
        /// <returns>�������ʾ���û������Ѿ�����</returns>
        public int IsExistTheUserName(string UserName)
        {
            SqlParameter[] Param = new SqlParameter[] 
            { 
                new SqlParameter("@UserName",UserName)
            };

            return (int)XYECOM.Core.Data.SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "XYP_IsExistUserName", Param);
        }


        public int IsExistThePartName(string partName, long companyId)
        {
            string sql = "select  count(u_name) from u_user where UserType in (" + (int)Model.UserType.CreditorEnterprise + "," + (int)Model.UserType.CreditorIndividual + ") and CompanyId=" + companyId + " and LayerName = '" + partName + "'";
            return (int)XYECOM.Core.Data.SqlHelper.ExecuteScalar(sql);
        }
        #endregion

        #region �����û������Ƿ��Ѿ�����
        /// <summary>
        /// �����û������Ƿ��Ѿ�����
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public int IsExistTheEmail(string email)
        {
            SqlParameter[] Param = new SqlParameter[] 
            { 
                new SqlParameter("@email",email)
            };

            object result = XYECOM.Core.Data.SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "XYP_IsExistEmail", Param);

            if (result == null) return 0;

            return (int)result;
        }
        #endregion

        #region ��Ӽ�����
        /// <summary>
        /// ��Ӽ�����
        /// </summary>
        /// <param name="activationcode">������</param>
        /// <returns></returns>
        public int UserActivation(string activationcode)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@U_ActivationCode",activationcode)
                
            };

            int rowAffected = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateActivation", param);

            return rowAffected;
        }
        #endregion

        #region �����û�
        /// <summary>
        /// �����û�
        /// </summary>
        /// <param name="activationcode">������</param>
        /// <param name="U_ID">�û�Id</param>
        /// <returns></returns>
        public int AddActivation(string activationcode, long U_ID)
        {
            SqlParameter[] param = new SqlParameter[]
            {                     
                new SqlParameter("@UserId",U_ID),
                new SqlParameter("@ActivationCode",activationcode)
            };

            int rowAffected = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertActivationCode", param);

            return rowAffected;
        }
        #endregion

        #region ���ݼ���������û���Ϣ
        /// <summary>
        /// ���ݼ���������û���Ϣ
        /// </summary>
        /// <param name="activationcode">������</param>
        /// <returns></returns>
        public XYECOM.Model.UserRegInfo GetUserCode(string activationcode)
        {
            SqlParameter[] param = new SqlParameter[]
                 {
                    new SqlParameter ("@strWhere"," where U_ActivationCode='"+activationcode.ToString ()+"'"),
                    new SqlParameter ("@strTableName","u_user"),
                    new SqlParameter ("@strOrder","") 
                 };

            XYECOM.Model.UserRegInfo eu = null;

            using (SqlDataReader dr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (dr.Read())
                {
                    eu = new XYECOM.Model.UserRegInfo();

                    eu.Answer = dr["U_Answer"].ToString();
                    eu.LoginName = dr["U_Name"].ToString();
                    eu.ClickNum = Core.MyConvert.GetInt32(dr["U_ClickNum"].ToString());

                    eu.Email = dr["U_Email"].ToString();
                    eu.HTMLPage = dr["U_HtmlPage"].ToString();
                    eu.UserId = Core.MyConvert.GetInt32(dr["U_ID"].ToString());
                    eu.Mark = Core.MyConvert.GetInt32(dr["U_Mark"].ToString());
                    eu.LoginName = dr["U_Name"].ToString();
                    eu.Password = dr["U_PassWord"].ToString();
                    eu.Question = dr["U_Question"].ToString();
                    eu.RegDate = Core.MyConvert.GetDateTime(dr["U_RegDate"].ToString());

                    eu.Cred = Core.MyConvert.GetInt32(dr["U_Cred"].ToString());
                    eu.MessageNum = Core.MyConvert.GetInt32(dr["U_MessageNum"].ToString());
                    eu.NoMessgeNum = Core.MyConvert.GetInt32(dr["U_NoMessgeNum"].ToString());

                    if (dr["U_Puach"].ToString().ToLower() == "true")
                        eu.IsPuach = true;
                    else
                        eu.IsPuach = false;

                    if (dr["U_Vouch"].ToString().ToLower() == "true")
                        eu.IsVouch = true;
                    else
                        eu.IsVouch = false;

                    if (dr["U_TempName"].ToString() != "")
                        eu.TemplateName = dr["U_TempName"].ToString();
                    else
                        eu.TemplateName = "default";

                    eu.CommonErr = Core.MyConvert.GetInt32(dr["U_CommonErr"].ToString());
                    eu.MaliceErr = Core.MyConvert.GetInt32(dr["U_MaliceErr"].ToString());
                    eu.InFormation = Core.MyConvert.GetInt32(dr["U_InFormation"].ToString());
                    if (dr["U_Activation"].ToString().ToLower() == "true")
                        eu.IsActivation = true;
                    else
                        eu.IsActivation = false;
                }
            }

            return eu;
        }
        #endregion

        #region �����û�����
        /// <summary>
        /// �����û�����
        /// </summary>
        /// <param name="U_ID">�û�Id</param>
        /// <param name="Mark">��������</param>
        /// <returns></returns>
        public int UpdateMark(long U_ID, long Mark)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@U_ID",U_ID),
                new SqlParameter("@Mark",Mark)
            };
            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateUserMark", param);
        }
        #endregion

        #region �޸��û�����ģ������
        /// <summary>
        /// �޸��û�����ģ������
        /// </summary>
        /// <param name="U_ID">�û����</param>
        /// <param name="tempname">ģ������</param>
        public int UpdateTmepName(long U_ID, string tempname)
        {
            string strSQL = " update u_user set U_TempName='" + tempname + "' where U_ID=" + U_ID;

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(strSQL);
        }
        #endregion

        #region �޸��Ƽ���Ϣ
        /// <summary>
        /// �����Ƽ�״̬
        /// </summary>
        /// <param name="eu">�û�����</param>
        /// <returns></returns>
        public int UpdateVouch(XYECOM.Model.UserRegInfo eu)
        {
            SqlParameter[] param = new SqlParameter[] 
            {
                new SqlParameter("@U_Vouch",SqlDbType.Bit),
                new SqlParameter("@U_ID",SqlDbType.BigInt )
            };

            param[0].Value = eu.IsVouch;
            param[1].Value = eu.UserId;

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateUserVouch", param);
        }
        #endregion

        #region ɾ���û�
        /// <summary>
        /// ɾ����¼
        /// </summary>
        /// <param name="U_ID">�û�Id</param>
        /// <returns></returns>
        public int Delete(string U_ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where U_ID in ("+U_ID+")"),
                new SqlParameter("@strTableName","u_User")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }
        #endregion

        #region �۳��û��ĳ���ָ��
        /// <summary>
        /// �۳��û��ĳ���ָ��
        /// </summary>
        /// <param name="U_ID">�û�Id</param>
        /// <param name="number">����</param>
        /// <returns></returns>
        public int DeductFaithMongy(long U_ID, int number)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@U_ID", U_ID),
                new SqlParameter("@Money",number)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateUserDeduct", param);
        }
        #endregion

        #region �����û��ĳ���ָ��
        /// <summary>
        /// �����û��ĳ���ָ��
        /// </summary>
        /// <param name="U_ID">�û�Id</param>
        /// <param name="number">����</param>
        /// <returns></returns>
        public int AddUserCred(long U_ID, int number)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@U_ID", U_ID),
                new SqlParameter("@Money",number)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateUsercCred", param);
        }
        #endregion

        #region ��ͨ���󱻴����Ĵ���
        public int AddUserCommonErr(long U_ID, int Money)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@U_ID", U_ID),
                new SqlParameter("@U_CommonErr",Money)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateUserCommonError", param);
        }
        #endregion

        #region ������󱻴����Ĵ���
        /// <summary>
        /// ������󱻴����Ĵ���
        /// </summary>
        /// <param name="U_ID">�û�Id</param>
        /// <param name="num"></param>
        /// <returns></returns>
        public int AddUserMaliceErr(long U_ID, int num)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@U_ID", U_ID),
                new SqlParameter("@MaliceErr",num)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateUserMaliceError", param);
        }
        #endregion

        #region �޸��û��������Ƴ̶�
        /// <summary>
        /// �����������ƶ�
        /// </summary>
        /// <param name="U_ID">�û�Id</param>
        /// <param name="Consummate">���ƶ�</param>
        /// <returns></returns>
        public int EditConsumate(long U_ID, int Consummate)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter ("@U_ID",U_ID),
                new SqlParameter ("@U_InFormation",Consummate)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateConsummate", parm);
        }
        #endregion

        #region �����û����жϸ��û��ȼ��Ƿ��ڣ������м��쵽��
        /// <summary>
        /// �����û����жϸ��û��ȼ��Ƿ��ڣ������м��쵽��
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        public string GetUserGradeState(long userId)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@UserId",userId),
                new SqlParameter("@Days",SqlDbType.VarChar,100)
            };

            param[1].Direction = ParameterDirection.Output;

            int row = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_GetUserGradeState", param);

            if (param[1].Value != null)
            {
                return param[1].Value.ToString();
            }
            return "";
        }
        #endregion

        #region �һ�����
        /// <summary>
        /// �һ�����
        /// </summary>
        /// <param name="username">�û���</param>
        /// <param name="question">����</param>
        /// <param name="answer">��</param>
        /// <param name="password">����</param>
        /// <param name="messinfo">���ؽ��</param>
        /// <returns>
        /// -2: ����ʧ��
        /// -1: �����ڴ��û�
        /// 1:  ����ɹ�
        /// </returns>
        public int RetakePassWord(string username, string password, string question, string answer)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                            new SqlParameter ("@Username",username ),
                            new SqlParameter ("@Question",question ),
                            new SqlParameter ("@Answer",answer),
                            new SqlParameter ("@Password",password),
                            new SqlParameter ("@ReturnValue",SqlDbType.Int ),

            };
            parm[4].Direction = ParameterDirection.Output;

            int rowAffected = 0;
            int result = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_RetakePassWord", parm);

            if (result >= 0)
            {
                if (parm[4].Value != null && parm[4].Value.ToString() != "")
                    rowAffected = (int)parm[4].Value;
                else
                    rowAffected = -2;
            }
            else
            {
                rowAffected = -1;
            }

            return rowAffected;
        }
        #endregion

        /// <summary>
        /// ���¼�¼
        /// </summary>
        /// <param name="info">ʵ�����</param>
        /// <returns></returns>
        public int Update(XYECOM.Model.UserRegInfo info)
        {
            string sql = "update u_User set U_Email='" + info.Email + "',U_Question='" + info.Question + "',U_Answer='" + info.Answer + "',U_RegDate='" + info.RegDate + "' where U_ID=" + info.UserId;

            return SqlHelper.ExecuteNonQuery(sql);
        }

        public int UpdatePartInfo(XYECOM.Model.UserRegInfo info)
        {
            string sqlFmt = @"update u_User set LayerName='{6}', Description='{0}', U_Email='{1}', OtherContact='{2}', PartManagerName='{3}', PartManagerTel='{4}',Telphone='{7}' where u_id={5}";
            string sql = string.Format(sqlFmt, info.Description, info.Email, info.OtherContact, info.PartManagerName, info.PartManagerTel, info.UserId, info.LayerName, info.Telphone);

            if (info.IsPrimary)
            {
                string.Format("update u_userinfo set Description='{0}',Email='{1}' where u_id={2}", info.Description, info.Email, info.CompanyId);
            }
            return SqlHelper.ExecuteNonQuery(sql);
        }


        public int AddPart(Model.UserRegInfo regInfo)
        {
            long uid = 0;

            regInfo.Answer = string.Empty;
            regInfo.Question = string.Empty;

            string sqlfmt = @"insert u_User(U_Name,U_PassWord,U_Email,U_Question,U_Answer,U_RegDate,U_TempName,UserAuditingState,IsPrimary,LayerName,
                              Description,Telphone,OtherContact,AreaId,UserType,
                                DelState,CompanyId,PartManagerName,PartManagerTel)
                              values('{0}','{1}','{2}','{3}','{4}',getdate(),'default',1,0,'{5}',
                              '{6}','{7}','{8}',{9},{10},
                               0,{11},'{12}','{13}')";

            string sql = string.Format(sqlfmt, regInfo.LoginName, regInfo.Password, regInfo.Email, regInfo.Question, regInfo.Answer, regInfo.LayerName,
                regInfo.Description, regInfo.Telphone, regInfo.OtherContact, regInfo.AreaId, regInfo.UserType, regInfo.CompanyId, regInfo.PartManagerName, regInfo.PartManagerTel);

            return SqlHelper.ExecuteNonQuery(sql);
        }

        public DataTable GetPartList(long companyId)
        {
            string sql = "select LayerName,PartManagerName,PartManagerTel,UserAuditingState,CompanyId,U_ID,Telphone,U_RegDate From u_user where CompanyId=" + companyId + " and IsPrimary=0";

            return SqlHelper.ExecuteTable(sql);
        }

        public int UpdatePartState(string userId, string stateId)
        {
            string sqlfmt = @"update u_user set UserAuditingState={0} where u_id={1}";
            string sql = string.Empty;
            if (stateId == "0")
            {
                sql = string.Format(sqlfmt, 1, userId);
            }
            else
            {
                sql = string.Format(sqlfmt, 0, userId);
            }
            return SqlHelper.ExecuteNonQuery(sql);
        }

        public int SetQuestAndAnswer(long userId, string question, string answer)
        {
            string sql = "update u_user set U_Question='" + question + "',U_Answer='" + answer + "' where u_id=" + userId;
            return SqlHelper.ExecuteNonQuery(sql);
        }
    }
}
