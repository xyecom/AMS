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
    /// ͨ�ú���
    /// </summary>
    public class Function
    {
        #region ���ɾ�̬ҳ��
        /// <summary>
        /// ������ҳ
        /// </summary>
        /// <param name="TableName">��Ŀ����</param>
        /// <param name="strsavepath">�洢·��</param>
        /// <param name="strhttpurl">����ҳ���ַ</param>
        /// <param name="strfilename">�����ļ���</param>
        /// <returns>�Ƿ�ɹ�</returns>
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
                s.WriteLine(cFetchStr); // �����ļ�
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

        #region ��ȡ��¼����
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

        #region ��ҳ
        /// <summary>
        /// ��ҳ������ָ����С��ҳ��ķ��������ļ�¼
        /// (�ѹ�ʱ���Ƽ�ʹ��XYECOM.SQLServer.Utils.GetPaginationData����)
        /// </summary>
        /// <param name="PageSize">ÿҳ��¼��</param>
        /// <param name="PageIndex">ҳ��</param>
        /// <param name="strWhere">����</param>
        /// <param name="strOrder">����</param>
        /// <param name="strTableName">����</param>
        /// <param name="strPrimaryKey">����</param>
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

        #region ����ָ�����ָ��������DataTable
        ///<summary>
        /// ����ָ�����ָ��������DataTable
        /// </summary>
        /// <param name="strWhere">����</param>
        /// <param name="strTableName">����</param>
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

        #region �޸�ָ���ֶε�ֵ
        /// <summary>
        /// ����ָ���ֶε�ֵ
        /// </summary>
        /// <param name="strColumuName">�б���</param>
        /// <param name="strColumuValue">ֵ</param>
        /// <param name="strWhere">����</param>
        /// <param name="strTableName">����</param>
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


        #region �����޸���ͣ��Ϣ
        /// <summary>
        /// �����޸���ͣ��Ϣ
        /// </summary>
        /// <param name="tablename">����</param>
        ///  <param name="strwhere">����</param>
        ///  <param name="content">�޸�����</param>
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


        #region ȡǰ����������
        /// <summary>
        /// ��ȡ����������ǰN����¼
        /// </summary>
        /// <param name="TopNum">��¼��</param>
        /// <param name="strColumuName">�ֶ���</param>
        /// <param name="strTableName">����</param>
        /// <param name="strWhere">����</param>
        /// <param name="strOrder">����</param>
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

        #region �����޸�ˢ����Ϣ
        /// <summary>
        /// �����޸�ˢ����Ϣ
        /// </summary>
        /// <param name="tablename">����</param>
        ///  <param name="strwhere">����</param>
        ///  <param name="content">�޸�����</param>
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


        #region ��ǩǰ׺
        public static string LabelPrefix
        {
            get { return "XY_"; }
        }
        #endregion

        #region ������Ϣ�ĵ����
        /// <summary>
        /// ���µ����
        /// </summary>
        /// <param name="strwhere">����</param>
        /// <param name="tablename">����</param>
        /// <param name="columname">����</param>
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

        #region  �����滻*
        /// <summary>
        /// �����滻*
        /// </summary>
        /// <param name="length">����</param>
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
