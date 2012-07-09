using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Net;
using XYECOM.Core.Data;

namespace XYECOM.Core
{
    /// <summary>
    /// 通用函数
    /// </summary>
    public class Function
    {
        #region 生成静态页面
        /// <summary>
        /// 生成首页
        /// </summary>
        /// <param name="TableName">栏目名称</param>
        /// <param name="strsavepath">存储路径</param>
        /// <param name="strhttpurl">访问页面地址</param>
        /// <param name="strfilename">生成文件名</param>
        /// <returns>是否成功</returns>
        public static bool CreateHTMLPage(string moduleName, string strsavepath, string strhttpurl, string strfilename)
        {
            try
            {
                if (moduleName != "")
                {
                    if (!Directory.Exists(strsavepath + "\\" + moduleName + "\\"))
                    {
                        Directory.CreateDirectory(strsavepath + "\\" + moduleName + "\\");
                    }

                    if (File.Exists(strsavepath + "\\" + moduleName + "\\" + strfilename))
                    {
                        File.Delete(strsavepath + "\\" + moduleName + "\\" + strfilename);
                    }

                }
                else
                {
                    if (File.Exists(strsavepath + "\\" + strfilename))
                    {
                        File.Delete(strsavepath + "\\" + strfilename);
                    }

                }
                string cFetchStr = "";
                HttpWebRequest httpRequest;

                httpRequest = (HttpWebRequest)WebRequest.Create(strhttpurl);
                httpRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 2.0.50727; .NET CLR 2.0.50727)";
                httpRequest.Accept = "*/*";
                HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                System.Text.Encoding strCoding = System.Text.Encoding.Default;
                StreamReader sResponseStream = new StreamReader(httpResponse.GetResponseStream(), strCoding);
                cFetchStr = sResponseStream.ReadToEnd();
                httpResponse.Close();
                sResponseStream.Close();
                System.IO.StreamWriter s;
                if (moduleName != "")
                    s = new StreamWriter((System.IO.Stream)File.OpenWrite(strsavepath + "\\" + moduleName + "\\" + strfilename), System.Text.Encoding.GetEncoding("gb2312"));
                else
                    s = new StreamWriter((System.IO.Stream)File.OpenWrite(strsavepath + "\\" + strfilename), System.Text.Encoding.GetEncoding("gb2312"));
                s.WriteLine(cFetchStr); // 生成文件
                s.Flush();
                s.Close();


                return true;
            }
            catch (Exception ex)
            {
                if (File.Exists(strsavepath + "\\" + strfilename))
                {
                    File.Delete(strsavepath + "\\" + strfilename);
                }

                throw ex;
            }
        }
        #endregion

        #region 获取记录行数
        [Obsolete]
        public static int GetRows(string strTable, string strField, string strWhere)
        {
            int result = 0;

            SqlParameter[] parameters =	
				{
					new SqlParameter("@strTable",SqlDbType.VarChar),
					new SqlParameter("@strField",SqlDbType.VarChar),
					new SqlParameter("@strWhere",SqlDbType.VarChar),
                    new SqlParameter("@strCount",SqlDbType.BigInt),
				};
            parameters[0].Value = strTable;
            parameters[1].Value = strField;
            parameters[2].Value = strWhere;
            parameters[3].Direction = ParameterDirection.Output;

            result = Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_GetRecordCount", parameters);
            if (parameters[3] != null)
                result = Convert.ToInt32(parameters[3].Value.ToString());
            return result;
        }

        #endregion

        #region 分页
        /// <summary>
        /// 分页，返回指定大小和页码的符合条件的记录
        /// (已过时，推荐使用XYECOM.SQLServer.Utils.GetPaginationData方法)
        /// </summary>
        /// <param name="PageSize">每页记录数</param>
        /// <param name="PageIndex">页码</param>
        /// <param name="strWhere">条件</param>
        /// <param name="strOrder">排序</param>
        /// <param name="strTableName">表名</param>
        /// <param name="strPrimaryKey">主键</param>
        /// <returns></returns>
        [Obsolete]
        public static DataTable GetPages(int PageSize, int PageIndex, string strWhere, string strOrder, string strTableName, string strColumuName, string strPrimaryKey)
        {
            SqlParameter[] parameters =	
				{
					new SqlParameter("@PageSize",SqlDbType.Int),
					new SqlParameter("@PageIndex",SqlDbType.Int),
					new SqlParameter("@strWhere",SqlDbType.VarChar),
					new SqlParameter("@strOrder",SqlDbType.VarChar),
					new SqlParameter("@strTableName",SqlDbType.VarChar),
					new SqlParameter("@strPrimaryKey",SqlDbType.VarChar),
					new SqlParameter("@strColumuName",SqlDbType.VarChar),
			};
            parameters[0].Value = PageSize;
            parameters[1].Value = PageIndex;
            parameters[2].Value = strWhere;
            parameters[3].Value = strOrder;
            parameters[4].Value = strTableName;
            parameters[5].Value = strPrimaryKey;
            parameters[6].Value = strColumuName;


            return Data.SqlHelper.GetDataTable("XYP_SelectByPage", parameters);
        }
        #endregion

        #region 返回指定表的指定条件的DataTable
        ///<summary>
        /// 返回指定表的指定条件的DataTable
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <param name="strTableName">表名</param>
        /// <returns></returns>
        public static DataTable GetDataTable(string strWhere, string strOrder, string strTableName)
        {
            SqlParameter[] parameters =	
				{
					new SqlParameter("@strWhere",SqlDbType.VarChar,200),
					new SqlParameter("@strOrder",SqlDbType.VarChar,50),
					new SqlParameter("@strTableName",SqlDbType.VarChar,50),
			};
            parameters[0].Value = strWhere;
            parameters[1].Value = strOrder;
            parameters[2].Value = strTableName;

            return Data.SqlHelper.GetDataTable("XYP_SelectByWhere", parameters);
        }

        #endregion

        #region 修改指定字段的值
        /// <summary>
        /// 更新指定字段的值
        /// </summary>
        /// <param name="strColumuName">列表明</param>
        /// <param name="strColumuValue">值</param>
        /// <param name="strWhere">条件</param>
        /// <param name="strTableName">表名</param>
        /// <returns></returns>
        public static int UpdateColumuByWhere(string strColumuName, string strColumuValue, string strWhere, string strTableName)
        {
            int rows;
            try
            {
                SqlParameter[] parameters =	
                {
                    new SqlParameter("@TableName",SqlDbType.VarChar,100),
                    new SqlParameter("@ColumuName",SqlDbType.VarChar,100),
                    new SqlParameter("@ColumuValue",SqlDbType.VarChar,500),
                    new SqlParameter("@StrWhere",SqlDbType.VarChar,500)
                };
                parameters[0].Value = strTableName;
                parameters[1].Value = strColumuName;
                parameters[2].Value = "'" + strColumuValue + "'";
                parameters[3].Value = strWhere;

                rows = Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "usp_updatecolumubywhere", parameters);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                rows = 0;
            }
            return rows;
        }
        #endregion


        #region 公用修改暂停信息
        /// <summary>
        /// 公用修改暂停信息
        /// </summary>
        /// <param name="tablename">表名</param>
        ///  <param name="strwhere">条件</param>
        ///  <param name="content">修改内容</param>
        /// <returns></returns>
        public static int UpdateSD_Pause(string tablename, string strwhere, string content)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[] 
                {
                 
                    new SqlParameter("@strwhere",strwhere),
                    new SqlParameter("@tablename",tablename),
                    new SqlParameter("@content",content)             
                };
                return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"usp_PublicUpdate", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region 取前多少条数据
        /// <summary>
        /// 获取满足条件的前N条记录
        /// </summary>
        /// <param name="TopNum">记录数</param>
        /// <param name="strColumuName">字段名</param>
        /// <param name="strTableName">表名</param>
        /// <param name="strWhere">条件</param>
        /// <param name="strOrder">排序</param>
        /// <returns></returns>
        public static DataTable GetDataTableForTop(int TopNum, string strColumuName, string strTableName, string strWhere, string strOrder)
        {
            SqlParameter[] parameterArray = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere", SqlDbType.VarChar, 8000), 
                new SqlParameter("@strOrder", SqlDbType.VarChar, 500), 
                new SqlParameter("@strTableName", SqlDbType.VarChar, 100), 
                new SqlParameter("@strColumuName", SqlDbType.VarChar, 8000), 
                new SqlParameter("@strTopNum", SqlDbType.Int, 4) 
            };
            parameterArray[0].Value = strWhere;
            parameterArray[1].Value = strOrder;
            parameterArray[2].Value = strTableName;
            parameterArray[3].Value = strColumuName;
            parameterArray[4].Value = TopNum;

            return Data.SqlHelper.GetDataTable("XYP_GetTopByWhere", parameterArray);
        }
        #endregion

        #region 公用修改刷新信息
        /// <summary>
        /// 公用修改刷新信息
        /// </summary>
        /// <param name="tablename">表名</param>
        ///  <param name="strwhere">条件</param>
        ///  <param name="content">修改内容</param>
        /// <returns></returns>
        public static int UpdateSD_refurbish(string tablename, string strwhere, string content)
        {
            SqlParameter[] param = new SqlParameter[] 
            {
                new SqlParameter("@strwhere",strwhere),
                new SqlParameter("@tablename",tablename),
                new SqlParameter("@content",content)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"usp_PublicUpdate", param);
        }
        #endregion


        #region 标签前缀
        public static string LabelPrefix
        {
            get { return "XY_"; }
        }
        #endregion

        #region 更改信息的点击量
        /// <summary>
        /// 更新点击数
        /// </summary>
        /// <param name="strwhere">条件</param>
        /// <param name="tablename">表明</param>
        /// <param name="columname">列名</param>
        /// <returns></returns>
        public static int Updateinfo(string strwhere, string tablename, string columname)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter ("@StrWhere",strwhere),
                new SqlParameter ("@TableName",tablename ),
                new SqlParameter ("@ColumuName",columname)
            };
            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"XYP_UpdateClickNum", parm);
        }
        #endregion

        #region  返回替换*
        /// <summary>
        /// 返回替换*
        /// </summary>
        /// <param name="length">长度</param>
        /// <returns></returns>
        public static string ReplaceString(int length)
        {
            string strreturn = "";

            for (int i = 0; i < length; i++)
            {
                strreturn += "*";
            }
            return strreturn;
        }
        #endregion    
    }
}
