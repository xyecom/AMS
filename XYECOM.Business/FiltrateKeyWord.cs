using System;
using System.Collections.Generic;
using System.Text;


using System.Data;
using System.Data.SqlClient;

namespace XYECOM.Business
{
    /// <summary>
    /// ������ҵ����
    /// </summary>
    public class FiltrateKeyWord
    {
        private static readonly XYECOM.SQLServer.FiltrateKeyWord DAL = new XYECOM.SQLServer.FiltrateKeyWord();
        /// <summary>
        /// �޸Ĺ�������Ϣ
        /// </summary>
        /// <param name="ef">ʵ����</param>
        /// <returns>��Ӱ�������</returns>
        public int Insert(XYECOM.Model.FiltrateKeyWordInfo ef)
        {
            return DAL.Insert(ef);
        }

        /// <summary>
        /// �޸Ĺ�������Ϣ
        /// </summary>
        /// <param name="ef">ʵ����</param>
        /// <returns>��Ӱ�������</returns>
        public int Update(XYECOM.Model.FiltrateKeyWordInfo ef)
        {
            return DAL.Update(ef);
        }

        /// <summary>
        /// ��ȡһ����¼
        /// </summary>
        /// <param name="FKW_ID">��¼���</param>
        /// <returns>һ����¼</returns>
        public XYECOM.Model.FiltrateKeyWordInfo  GetItem(int FKW_ID)
        {
            if (FKW_ID <= 0) return null;

            return DAL.GetItem(FKW_ID);
        }

        /// <summary>
        /// ��ȡ���м�¼
        /// </summary>
        /// <returns>��¼��</returns>
        public static DataTable GetDataTable()
        {
            return DAL.GetDataTable();
        }

        /// <summary>
        /// ɾ��һ����¼
        /// </summary>
        /// <param name="FKW_ID">��¼���</param>
        /// <returns>��Ӱ�������</returns>
        public int Delete(int FKW_ID)
        {
            if (FKW_ID <= 0) return 0;

            return DAL.Delete(FKW_ID);
        }


        /// <summary>
        /// ɾ��������¼
        /// </summary>
        /// <param name="FKW_ID">��¼���</param>
        /// <returns>��Ӱ�������</returns>
        public int Deletes(string FKW_ID)
        {
            if (string.IsNullOrEmpty(FKW_ID) || FKW_ID.Trim().Equals("")) return 0;

            return DAL.Deletes(FKW_ID);
        }

        /// <summary>
        /// �滻���˹ؼ���
        /// </summary>
        /// <param name="userId">�û����</param>
        /// <param name="source">��Ҫ�滻���ַ���</param>
        /// <returns>�滻������ַ���</returns>
        public static string LeachKeyWord(int userGradeId, string source)
        {
            return LeachKeyWord(source);
        }

        /// <summary>
        /// ���˹ؼ���
        /// </summary>
        /// <param name="source">��Ҫ�滻���ַ���</param>
        /// <returns>���˺�Ĺؼ���</returns>
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
