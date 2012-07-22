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
    /// 企业会员详细资料数据处理类
    /// </summary>
    public class UserInfo
    {
        #region 添加用户
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <param name="info">数据对象</param>
        /// <returns>影响行数</returns>
        public int Insert(XYECOM.Model.UserInfo info)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter ("@U_ID",info .UserId ),
                new SqlParameter("@UI_Name",info.Name),                
                new SqlParameter("@UI_Area",info.Address),
                new SqlParameter("@UI_License",info.License),
                new SqlParameter("@UI_Character",info.Character),
                new SqlParameter("@UI_LinkMan",info.LinkMan),
                new SqlParameter("@UI_Number",info.EmployeeTotal),
                new SqlParameter("@UI_HomePage",info.HomePage),
                new SqlParameter("@UI_Synopsis",info.Synopsis),
                new SqlParameter("@UI_Postcode",info.Postcode),
                new SqlParameter("@UI_Mobil",info.Mobile),
                new SqlParameter("@UT_ID",info.UserTypeId ),
                new SqlParameter("@UI_Sex",info .Sex ),
                new SqlParameter("@U_Section",info .Section ),
                new SqlParameter("@U_Post",info .Post),
                new SqlParameter("@U_Way",info .SupplyOrBuy ),
                new SqlParameter("@U_SupplyProduct",info .SupplyPro ),
                new SqlParameter("@U_BuyProduct",info .BuyPro ),
                new SqlParameter("@U_Mode",info .Mode ),
                new SqlParameter("@U_Money",info .RegisteredCapital ),
                new SqlParameter("@U_Year",info.RegYear ),
                new SqlParameter("@U_Address",info .Address ),
                new SqlParameter("@U_PType",info .MainProduct ),
                new SqlParameter("@U_MoneyType",info .MoneyType ),
                new SqlParameter("@Area_ID",info.AreaId ),
                new SqlParameter("@AC_ID",info.RegAreaId ),
                new SqlParameter("@IM",info.IM),
                new SqlParameter("@Telephone",info.Telephone),
                new SqlParameter("@Fax",info.Fax),
                new SqlParameter("@TradeIds",info.TradeIds),
                new SqlParameter("@Email",info.Email)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertUserInfo", param);
        }
        #endregion

        #region 修改用户信息
        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="info">数据对象</param>
        /// <returns>影响行数</returns>
        public int Update(XYECOM.Model.UserInfo info)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter ("@U_ID",info.UserId ),
                new SqlParameter("@UI_Name",info.Name),
                new SqlParameter("@UI_Area",info.Address),
                new SqlParameter("@UI_License",info.License),
                new SqlParameter("@UI_Character",info.Character),
                new SqlParameter("@UI_LinkMan",info.LinkMan),
                new SqlParameter("@UI_Number",info.EmployeeTotal),
                new SqlParameter("@UI_HomePage",info.HomePage),
                new SqlParameter("@UI_Synopsis",info.Synopsis),
                new SqlParameter("@UI_Postcode",info.Postcode),
                new SqlParameter("@UI_Mobil",info.Mobile),
                new SqlParameter("@UT_ID",info.UserTypeId ),
                new SqlParameter ("@UI_Sex",info .Sex ),
                new SqlParameter ("@U_Section",info .Section ),
                new SqlParameter ("@U_Post",info.Post ),
                new SqlParameter ("@U_Way",info .SupplyOrBuy ),
                new SqlParameter ("@U_SupplyProduct",info.SupplyPro ),
                new SqlParameter ("@U_BuyProduct",info.BuyPro ),
                new SqlParameter ("@U_Mode",info .Mode ),
                new SqlParameter ("@U_Money",info .RegisteredCapital ),
                new SqlParameter ("@U_Year",info .RegYear ),
                new SqlParameter ("@U_Address",info .Address ),
                new SqlParameter ("@U_PType",info .MainProduct ),
                new SqlParameter ("@U_MoneyType",info .MoneyType ),
                new SqlParameter ("@Area_ID",info .AreaId ),
                new SqlParameter ("@AC_ID",info .RegAreaId ),
                new SqlParameter ("@U_Email",info.RegInfo.Email),
                new SqlParameter ("@IM",info.IM),
                new SqlParameter ("@Telephone",info.Telephone),
                new SqlParameter ("@Fax",info.Fax),
                new SqlParameter ("@TradeIds",info.TradeIds),
            };
            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateUserInfo", param);
        }
        #endregion

        #region 删除用户
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="U_ID">用户Id</param>
        /// <returns>影响行数</returns>
        public int Delete(string U_ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where U_ID in ("+U_ID+")"),
                new SqlParameter("@strTableName","u_UserInfo")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }
        #endregion

        #region 获取一条记录
        /// <summary>
        /// 获取用户数据
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns>数据对象</returns>
        public XYECOM.Model.UserInfo GetItem(long userId)
        {
            SqlParameter[] param = new SqlParameter[] 
                { 
                    new SqlParameter("@strWhere"," Where U_ID=" + userId.ToString()),
                    new SqlParameter("@strTableName","u_UserInfo"),
                    new SqlParameter("@strOrder","")
                };

            XYECOM.Model.UserInfo info = null;

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (reader.Read())
                {
                    info = new XYECOM.Model.UserInfo();

                    info.RegInfo = new UserReg().GetItem(userId);

                    info.UserId = userId;

                    info.Name = reader["UI_Name"].ToString();

                    info.Address = reader["UI_Area"].ToString();

                    info.Character = reader["UI_Character"].ToString();
                    info.License = reader["UI_License"].ToString();
                    info.HomePage = reader["UI_HomePage"].ToString();
                    info.LinkMan = reader["UI_LinkMan"].ToString();
                    info.Mobile = reader["UI_Mobil"].ToString();
                    info.EmployeeTotal = reader["UI_Number"].ToString();
                    info.Postcode = reader["UI_Postcode"].ToString();
                    info.Synopsis = reader["UI_Synopsis"].ToString();
                    info.Sex = Core.MyConvert.GetBoolean(reader["UI_Sex"].ToString());

                    info.UserTypeId = Core.MyConvert.GetInt64(reader["UT_ID"].ToString());
                    info._UserTypeInfo = new UserType().GetItem(info.UserTypeId);

                    info.Telephone = reader["telephone"].ToString();
                    info.Fax = reader["fax"].ToString();
                    info.Section = reader["U_Section"].ToString();
                    info.Post = reader["U_Post"].ToString();
                    info.SupplyOrBuy = Core.MyConvert.GetInt16(reader["U_Way"].ToString());
                    info.SupplyPro = reader["U_SupplyProduct"].ToString();
                    info.BuyPro = reader["U_BuyProduct"].ToString();
                    info.Mode = reader["U_Mode"].ToString();
                    info.RegisteredCapital = Core.MyConvert.GetDecimal(reader["U_Money"].ToString());
                    info.RegYear = Core.MyConvert.GetInt32(reader["U_Year"].ToString());
                    info.Address = reader["U_Address"].ToString();
                    info.MainProduct = reader["U_PType"].ToString();
                    info.MoneyType = reader["U_MoneyType"].ToString();

                    info.AreaId = Core.MyConvert.GetInt32(reader["Area_ID"].ToString());
                    info.RegAreaId = Core.MyConvert.GetInt32(reader["AC_ID"].ToString());

                    info.AreaInfo = new Area().GetItem(info.AreaId);
                    info.RegAreaInfo = new Area().GetItem(info.RegAreaId);

                    info.IM = reader["IM"].ToString();
                    info.TradeIds = Core.Utils.RemoveComma(reader["tradeIds"].ToString());

                    info.Email = reader["Email"].ToString();
                    info.Description = reader["Description"].ToString();
                    info.CreateDate = Core.MyConvert.GetDateTime(reader["CreateDate"].ToString());
                    info.State = Core.MyConvert.GetInt32(reader["State"].ToString());
                    info.PassTime = Core.MyConvert.GetDateTime(reader["PassTime"].ToString());
                    info.ManagerId = Core.MyConvert.GetInt32(reader["ManagerId"].ToString());
                    info.IsBoundEmail = Core.MyConvert.GetBoolean(reader["IsBoundEmail"].ToString());
                    info.IsBoundMobile = Core.MyConvert.GetBoolean(reader["IsBoundMobile"].ToString());

                    info.IsReal = Core.MyConvert.GetBoolean(reader["IsReal"].ToString()); ;
                    info.Point = Core.MyConvert.GetInt32(reader["Point"].ToString());
                    info.GoodTimes = Core.MyConvert.GetInt32(reader["GoodTimes"].ToString());
                    info.MidTimes = Core.MyConvert.GetInt32(reader["MidTimes"].ToString());
                    info.BadTimes = Core.MyConvert.GetInt32(reader["BadTimes"].ToString());
                }
            }
            return info;
        }
        #endregion

        #region   根据U_ID显示信息
        //public DataTable GetDataTable(long U_ID)
        //{
        //    SqlParameter[] param = new SqlParameter[]
        //    {
        //        new SqlParameter("@strwhere","where U_ID="+U_ID),
        //        new SqlParameter("@strtableName","XYV_UserInfo"),
        //        new SqlParameter("@strOrder","")
        //    };

        //    return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "XYP_SelectByWhere", param);
        //}
        #endregion

        #region  找回密码
        //public int RetakePassWord(string U_Name, string U_PassWord, string U_Question, string U_Answer)
        //{
        //    int num = 0;

        //    SqlParameter[] parameters = new SqlParameter[] 
        //            { 
        //                new SqlParameter("@U_Name", SqlDbType.VarChar), 
        //                new SqlParameter("@U_PassWord", SqlDbType.VarChar), 
        //                new SqlParameter("@U_Question", SqlDbType.VarChar), 
        //                new SqlParameter("@U_Answer", SqlDbType.VarChar) 
        //            };

        //    if ((U_Name != null) && (U_Name != ""))
        //    {
        //        parameters[0].Value = U_Name;
        //    }
        //    else
        //    {
        //        parameters[0].Value = DBNull.Value;
        //    }
        //    if ((U_PassWord != null) && (U_PassWord != ""))
        //    {
        //        parameters[1].Value = U_PassWord;
        //    }
        //    else
        //    {
        //        parameters[1].Value = DBNull.Value;
        //    }
        //    if ((U_Question != null) && (U_Question != ""))
        //    {
        //        parameters[2].Value = U_Question;
        //    }
        //    else
        //    {
        //        parameters[2].Value = DBNull.Value;
        //    }
        //    if ((U_Answer != null) && (U_Answer != ""))
        //    {
        //        parameters[3].Value = U_Answer;
        //    }
        //    else
        //    {
        //        parameters[3].Value = DBNull.Value;
        //    }
        //    num = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_RetakePassWord", parameters);
        //    return num;
        //}
        #endregion

        #region  企业列表
        //public DataTable GetDataTable()
        //{
        //    SqlParameter[] param = new SqlParameter[]
        //    {
        //        new SqlParameter("@strwhere",""),
        //        new SqlParameter("@strtableName","XYV_UserInfo"),
        //        new SqlParameter("@strOrder","")
        //    };

        //    return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "XYP_SelectByWhere", param);
        //}
        #endregion

        #region 根据公司名称搜索
        //public DataTable GetCompanyName(string Name)
        //{
        //    SqlParameter[] param = new SqlParameter[]
        //    {
        //        new SqlParameter("@strwhere"," where UI_Name like '%"+Name+"%'"),
        //        new SqlParameter("@strtableName","XYV_UserInfo"),
        //        new SqlParameter("@strOrder"," order by U_ID desc ")
        //    };

        //    return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "XYP_SelectByWhere", param);
        //}
        #endregion

        #region 修改用户等级ID
        /// <summary>
        /// 更新用户等级id
        /// </summary>
        /// <param name="U_ID">用户Id</param>
        /// <param name="UG_ID">等级Id</param>
        /// <returns>影响行数</returns>
        public int UpdateUGID(long U_ID, int UG_ID)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter ("@U_ID",U_ID .ToString ()),
                new SqlParameter ("@UG_ID",UG_ID .ToString ())                    
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateUGID", parm);
        }
        #endregion

        /// <summary>
        /// 获取用户在指定的条件下发布的信息数量
        /// </summary>
        /// <param name="viewname">表或视图名称</param>
        /// <param name="useridfieldname">用户Id字段名称</param>
        /// <param name="userid">用户id</param>
        /// <param name="datefieldname">日期字段名称</param>
        /// <param name="startime">开始时间</param>
        /// <param name="endtime">结束时间</param>
        /// <param name="infoidfieldname">信息Id字段名称</param>
        /// <param name="modulename">模块名称</param>
        /// <returns>信息条数</returns>
        public int InfoAddNum(String viewname, String useridfieldname, long userid, String datefieldname, String startime, String endtime, String infoidfieldname, String modulename)
        {
            String strsql = "";
            if (modulename.Equals("brand"))
            {
                strsql = "select count(" + infoidfieldname + ") from " + viewname + " where " + useridfieldname + "=" + userid + " and (" + datefieldname + " between '" + startime + "' and '" + endtime + "')";
            }
            else
            {
                strsql = "select count(" + infoidfieldname + ") from " + viewname + " where " + useridfieldname + "=" + userid + " and modulename='" + modulename + "'  and (" + datefieldname + " between '" + startime + "' and '" + endtime + "')";
            }
            return (int)XYECOM.Core.Data.SqlHelper.ExecuteScalar(strsql);
        }

        /// <summary>
        /// 专用方法，用于设置标签范围
        /// </summary>
        /// <param name="userIds"></param>
        /// <returns></returns>
        public DataTable GetUserNamesByIds(string userIds)
        {
            string sql = "select u_user.u_id,u_name,u_email,ui_name from u_user inner join u_userinfo on u_user.u_id=u_userinfo.u_id";
            if (!string.IsNullOrEmpty(userIds))
            {
                string tmp = XYECOM.Core.Utils.RemoveComma(userIds);
                if (!string.IsNullOrEmpty(tmp))
                {
                    sql += " where u_user.u_id in (" + tmp + ")";
                    return XYECOM.Core.Data.SqlHelper.ExecuteTable(sql);
                }
            }

            return new DataTable();
        }

        /// <summary>
        /// 根据公司编号获取公司名称 王振添加（2011-04-15）
        /// </summary>
        /// <param name="uid">用户编号</param>
        /// <returns>公司名称</returns>
        public string GetCompNameByUId(int uid)
        {
            string sql = "select ui_name from dbo.u_UserInfo where U_id = " + uid;
            object obj = XYECOM.Core.Data.SqlHelper.ExecuteScalar(sql);
            if (obj != null)
            {
                return obj.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 根据用户编号获取用户名称
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GetUserNameByID(int userId)
        {
            string sql = "SELECT U_Name FROM dbo.u_User WHERE U_Id = " + userId;
            object obj = XYECOM.Core.Data.SqlHelper.ExecuteScalar(sql);
            if (obj != null)
            {
                return obj.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 根据用户编号获取用户所在的部门名称
        /// </summary>
        /// <param name="PartId"></param>
        /// <returns></returns>
        public string GetPartNameById(int PartId)
        {
            string sql = "select LayerName from u_user  where u_id = " + PartId;
            object obj = XYECOM.Core.Data.SqlHelper.ExecuteScalar(sql);
            if (obj != null)
            {
                return obj.ToString();
            }
            else
            {
                return string.Empty;
            }
        }


        /// <summary>
        /// 根据用户编号获取用户邮箱
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GetEmailByID(int userId)
        {
            string sql = "SELECT U_Email FROM dbo.u_User WHERE U_Id = " + userId;
            object obj = XYECOM.Core.Data.SqlHelper.ExecuteScalar(sql);
            if (obj != null)
            {
                return obj.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        public int UpdateBaseInfo(Model.GeneralUserInfo userinfo)
        {
            string sqlfmt = @"update u_userinfo set UI_Name='{0}',U_Address='{1}',Email='{2}',Description='{3}',FAX='{4}',Telephone='{5}',UI_LinkMan='{6}' where U_ID={7}";
            string sql = string.Format(sqlfmt, userinfo.CompanyName, userinfo.Address, userinfo.Email, userinfo.Description, userinfo.OtherContact, userinfo.Telphone, userinfo.LinkMan, userinfo.CompanyId);


            string sqlfmt2 = @"{5};Update u_user set LayerName='{0}', Description='{1}', Telphone='{2}', OtherContact='{3}',PartManagerName='{6}',Sex={7},LayerId='{8}',IdNumber='{9}' where CompanyId ={4}";

            string sql2 = string.Format(sqlfmt2, userinfo.LayerName, userinfo.Description, userinfo.Telphone, userinfo.OtherContact, userinfo.CompanyId, sql, userinfo.LinkMan, userinfo.Sex ? 1 : 0, userinfo.LayerId, userinfo.IdNumber);


            return SqlHelper.ExecuteNonQuery(sql2);

        }
    }
}

