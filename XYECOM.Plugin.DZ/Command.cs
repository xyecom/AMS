namespace XYECOM.Plugin.DZ
{
    using System;
    using System.Data;
    using System.Web;

    /// <summary>
    /// 库操作方法类
    /// </summary>
    public class Command
    {
        private static IDbProvider _DB;

        static Command()
        {
            if (Config.Instance.DBType == DNTDBType.SQLServer)
            {
                _DB = new SQLServer();
            }
            else
            {
                _DB = new Access();
            }
            _DB.vDataBaseConnectionString = Config.Instance.ConnString;
        }


        public static bool Login(string username, string password)
        {
            return Login(username, password, 0, false, "index.aspx");
        }

        public static bool Login(string username, string password, int expDays)
        {
            return Login(username, password, expDays, false, "index.aspx");
        }

        internal static UserInfo GetUserInfo(int userID)
        {
            string cmdText = string.Format("select  username,password from [{1}users] where uid='{0}'", userID, Config.Instance.DNTTablePrefix);

            UserInfo info = null;
            using (DataTable table = _DB.vDataTable(cmdText))
            {
                if (table != null && table.Rows.Count > 0)
                {
                    DataRow row = table.Rows[0];
                    info = new UserInfo();
                    info.Password = row["password"].ToString();
                }
            }
            return info;
        }

        internal static UserInfo GetUserInfo(string userName,string password)
        {
            string cmdText = string.Format("select top 1 username,password,tpp,ppp,pmsound,invisible,templateid,sigstatus,uid from [{2}users] where username='{0}' and password='{1}'", Utils.HtmlEncode(userName),Utils.MD5(password), Config.Instance.DNTTablePrefix);

            UserInfo info = null;
            using(DataTable table = _DB.vDataTable(cmdText))
            {
                if (table != null && table.Rows.Count > 0)
                {
                    DataRow row  = table.Rows[0];
                    info = new UserInfo();

                    info.Tpp = row["tpp"].ToString();
                    info.Ppp = row["ppp"].ToString();
                    info.Pmsound = row["pmsound"].ToString();
                    info.Invisible = row["invisible"].ToString();
                    info.Sigstatus = row["sigstatus"].ToString();
                    info.Uid = row["uid"].ToString();
                    info.TemplateId = Convert.ToInt32(row["templateid"].ToString());
                    info.Password = row["password"].ToString();
                }
            }
            return info;
        }

        public static bool Login(string username, string password, int expDays, bool inVisisble, string reFerer)
        {
            try
            {
                HttpCookie cookie = new HttpCookie("dnt");

                UserInfo userInfo = GetUserInfo(username,password);

                if (userInfo == null)
                {
                    Register(username, 0, string.Empty, password, 11, string.Empty);
                    userInfo = GetUserInfo(username, password);
                }

                if (userInfo == null)
                {
                    return false;
                }

                Utils.WriteUserCookie(userInfo);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string LoginOut()
        {
            string userKey = "";
            try
            {
                HttpCookie objA = HttpContext.Current.Request.Cookies["dnt"];
                if (object.Equals(objA, null))
                {
                    objA = new HttpCookie("dnt");
                }
                else if (!object.Equals(objA.Values["userid"], null))
                {
                    string str = objA.Values["userid"].ToString();
                    if (!string.IsNullOrEmpty(str))
                    {
                        int num;
                        int.TryParse(str, out num);

                        if (num != 0)
                        {
                            UserInfo userInfo = GetUserInfo(num);
                            if (userInfo != null)
                            {
                                userKey = userInfo.Password.Substring(4, 8).Trim();
                            }
                            _DB.vExecuteNonQuery(string.Format("UPDATE [{0}users] SET [oltime] = [oltime] + DATEDIFF(n,[lastvisit],{2}) WHERE [uid]={1};delete from [{0}online] where userid={1};", Config.Instance.DNTTablePrefix, num, Config.Instance.DBDefaultDateTime));    
                        }
                    }
                }
                Utils.ClearUserCookie("dnt");

                Utils.WriteCookie(Utils.GetTemplateCookieName(), "", -999999);
            }
            catch
            {
            }
            return userKey;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="username"></param>
        /// <param name="oldPwd"></param>
        /// <param name="newPwd"></param>
        /// <returns></returns>
        public static bool ModifyPwd(string username, string oldPwd,string newPwd)
        {
            UserInfo info = GetUserInfo(username, oldPwd);

            if (info != null)
            {
                return (_DB.vExecuteNonQuery(string.Format("update [{0}users] set password='{2}' where username='{1}' and password<>'{2}'", Config.Instance.DNTTablePrefix, Utils.HtmlEncode(username), Utils.MD5(newPwd))) == 1);
            }
            return false;
        }

        /// <summary>
        /// 注册新用户
        /// </summary>
        /// <param name="username"></param>
        /// <param name="gender"></param>
        /// <param name="nickname"></param>
        /// <param name="password"></param>
        /// <param name="groupid"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool Register(string username, int gender, string nickname, string password, int groupid, string email)
        {
            return Register(username, gender, nickname, password, groupid, email, Utils.GetUserIP(), string.Empty, string.Empty);
        }

        /// <summary>
        /// 注册新用户
        /// </summary>
        /// <param name="username"></param>
        /// <param name="gender"></param>
        /// <param name="nickname"></param>
        /// <param name="password"></param>
        /// <param name="groupid"></param>
        /// <param name="email"></param>
        /// <param name="regip"></param>
        /// <param name="qq"></param>
        /// <param name="msn"></param>
        /// <returns></returns>
        public static bool Register(string username, int gender, string nickname, string password, int groupid, string email, string regip, string qq, string msn)
        {
            int num;
            object obj2;
            object[,] objArray = new object[,] { { "@username", "@gender", "@nickname", "@password", "@groupid", "@email", "@lastip" }, {Utils.HtmlEncode(username), gender, Utils.HtmlEncode(nickname), Utils.MD5(password), groupid, email, regip } };
            if (_DB.vExecuteNonQuery(objArray, string.Format("insert into [{0}users] (username,gender,nickname,password,groupid,email,regip) values (@username,@gender,@nickname,@password,@groupid,@email,@lastip)", Config.Instance.DNTTablePrefix), false, out num) <= 0)
            {
                return false;
            }
            if (num <= 0)
            {
                obj2 = _DB.vExecuteScalar(string.Format("select top 1 uid from [{0}users] order by uid desc", Config.Instance.DNTTablePrefix));
            }
            else
            {
                obj2 = num;
            }
            objArray = new object[,] { { "@uid", "@qq", "@msn" }, { obj2, qq, msn } };
            if (_DB.vExecuteNonQuery(objArray, string.Format("insert into [{0}userfields] (uid, qq, msn) values (@uid, @qq, @msn)", Config.Instance.DNTTablePrefix), false) <= 0)
            {
                _DB.vExecuteNonQuery(string.Format("delete from [{0}users] where uid={1}", Config.Instance.DNTTablePrefix, num));
                return false;
            }
            objArray = new object[,] { { "@username", "@userid" }, { username, obj2 } };
            _DB.vExecuteNonQuery(objArray, string.Format("update [{0}statistics] set totalusers=totalusers+1, lastusername=@username, lastuserid=@userid", Config.Instance.DNTTablePrefix), false);
            return true;
        }

        public static string DbLastError
        {
            get
            {
                return _DB.vErrorResultString;
            }
        }
    }
}

