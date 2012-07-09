using System;
using System.Collections.Generic;
using System.Text;


using System.Data;
using System.Data.SqlClient;

namespace XYECOM.Business
{
    /// <summary>
    /// 过滤字业务类
    /// </summary>
    public class FiltrateKeyWord
    {
        private static readonly XYECOM.SQLServer.FiltrateKeyWord DAL = new XYECOM.SQLServer.FiltrateKeyWord();
        /// <summary>
        /// 修改过滤字信息
        /// </summary>
        /// <param name="ef">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Insert(XYECOM.Model.FiltrateKeyWordInfo ef)
        {
            return DAL.Insert(ef);
        }

        /// <summary>
        /// 修改过滤字信息
        /// </summary>
        /// <param name="ef">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Update(XYECOM.Model.FiltrateKeyWordInfo ef)
        {
            return DAL.Update(ef);
        }

        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="FKW_ID">记录编号</param>
        /// <returns>一条记录</returns>
        public XYECOM.Model.FiltrateKeyWordInfo  GetItem(int FKW_ID)
        {
            if (FKW_ID <= 0) return null;

            return DAL.GetItem(FKW_ID);
        }

        /// <summary>
        /// 获取所有记录
        /// </summary>
        /// <returns>记录集</returns>
        public static DataTable GetDataTable()
        {
            return DAL.GetDataTable();
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="FKW_ID">记录编号</param>
        /// <returns>受影响的行数</returns>
        public int Delete(int FKW_ID)
        {
            if (FKW_ID <= 0) return 0;

            return DAL.Delete(FKW_ID);
        }


        /// <summary>
        /// 删除多条记录
        /// </summary>
        /// <param name="FKW_ID">记录编号</param>
        /// <returns>受影响的行数</returns>
        public int Deletes(string FKW_ID)
        {
            if (string.IsNullOrEmpty(FKW_ID) || FKW_ID.Trim().Equals("")) return 0;

            return DAL.Deletes(FKW_ID);
        }

        /// <summary>
        /// 替换过滤关键字
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <param name="source">需要替换的字符串</param>
        /// <returns>替换过后的字符串</returns>
        public static string LeachKeyWord(int userGradeId, string source)
        {
            return LeachKeyWord(source);
        }

        /// <summary>
        /// 过滤关键字
        /// </summary>
        /// <param name="source">需要替换的字符串</param>
        /// <returns>过滤后的关键字</returns>
        public static string LeachKeyWord(string source)
        {
            string newkeyword = source;

            DataTable dt = GetDataTable();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (newkeyword.IndexOf(dt.Rows[i]["FKW_Name"].ToString()) >= 0)
                    {
                        ASCIIEncoding ascii = new ASCIIEncoding();
                        int tempLen = 0;
                        byte[] s = ascii.GetBytes(dt.Rows[i]["FKW_Name"].ToString());
                        for (int j = 0; j < s.Length; j++)
                        {
                            if ((int)s[j] == 63)
                            {
                                tempLen += 2;
                            }
                            else
                            {
                                tempLen += 1;
                            }
                        }

                        if (dt.Rows[i]["FKW_Name"].ToString().Trim().Equals("")) continue;

                        newkeyword = newkeyword.Replace(dt.Rows[i]["FKW_Name"].ToString(), XYECOM.Core.Function.ReplaceString(tempLen));
                    }
                }
            }

            return newkeyword;
        }
    }
}
