using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using XYECOM.Core.Data;
using XYECOM.Core;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// ϵͳģ�����ݴ�����
    /// </summary>
    public class Template
    {
        #region �����ļ�����TemplateAboutInfo����
        /// <summary>
        /// ��ȡģ����������
        /// </summary>
        /// <param name="strxmlpath">�ļ���ַ</param>
        /// <returns>TemplateAboutInfo����</returns>
        private TemplateAboutInfo GetTemplateAboutInfo(string strxmlpath)
        {
            TemplateAboutInfo info = new TemplateAboutInfo();
            info.name = "";
            info.author = "";
            info.createdate = "";
            info.ver = "";
            info.copyright = "";
            if (File.Exists(strxmlpath + @"\about.xml"))
            {
                XmlDocument document = new XmlDocument();
                document.Load(strxmlpath + @"\about.xml");
                foreach (XmlNode node2 in document.SelectSingleNode("about").ChildNodes)
                {
                    if ((node2.NodeType == XmlNodeType.Comment) || (node2.Name.ToLower() != "template"))
                    {
                        continue;
                    }
                    XmlAttribute attribute = node2.Attributes["name"];
                    XmlAttribute attribute2 = node2.Attributes["author"];
                    XmlAttribute attribute3 = node2.Attributes["createdate"];
                    XmlAttribute attribute4 = node2.Attributes["ver"];
                    XmlAttribute attribute5 = node2.Attributes["copyright"];
                    if (attribute != null)
                    {
                        info.name = attribute.Value.ToString();
                    }
                    if (attribute2 != null)
                    {
                        info.author = attribute2.Value.ToString();
                    }
                    if (attribute3 != null)
                    {
                        info.createdate = attribute3.Value.ToString();
                    }
                    if (attribute4 != null)
                    {
                        info.ver = attribute4.Value.ToString();
                    }
                    if (attribute5 != null)
                    {
                        info.copyright = attribute5.Value.ToString();
                    }
                }
            }
            return info;
        }
        #endregion

        /// <summary>
        /// �ṹ��
        /// </summary>
        public struct TemplateAboutInfo
        {
            public string name;
            public string author;
            public string createdate;
            public string ver;
            public string copyright;
        }

        #region ��ȡģ����
        /// <summary>
        /// ��ȡģ����
        /// </summary>
        /// <param name="templateid">ģ����</param>
        /// <returns></returns>
        public XYECOM.Model.TemplateInfo GetTemplateItem(int templateid)
        {
            if (templateid > 0)
            {
                XYECOM.Model.TemplateInfo info = new XYECOM.Model.TemplateInfo();
                DataRow[] rowArray = GetValidTemplateList().Select("t_id = " + templateid.ToString());
                if (rowArray.Length > 0)
                {
                    info.Templateid = short.Parse(rowArray[0]["t_id"].ToString());
                    info.Name = rowArray[0]["t_name"].ToString();
                    info.Directory = rowArray[0]["t_path"].ToString();
                    info.Copyright = rowArray[0]["t_copyright"].ToString();
                    return info;
                }
            }
            return null;
        }
        #endregion

        #region ��ȡģ����Ϣ
       /// <summary>
       /// ��ȡģ���ļ��б�
       /// </summary>
       /// <param name="templatePath">ģ��·��</param>
       /// <returns></returns>
        public DataTable GetAllTemplateList(string templatePath)
        {
            DataTable table = XYECOM.Core.Data.SqlHelper.SelectByWhere("b_Template", "", "");
            table.Columns.Add("valid", Type.GetType("System.Int16"));

            foreach (DataRow row in table.Rows)
            {
                row["valid"] = 1;
            }

            DirectoryInfo info = new DirectoryInfo(templatePath);

            int num;
            if (XYECOM.Core.Data.SqlHelper.ExecuteTable("Select Top 1 T_ID From b_Template").Rows.Count == 0)
                num = 0;
            else
                num = Convert.ToInt32(XYECOM.Core.Data.SqlHelper.ExecuteTable("Select Max(T_ID) From b_Template").Rows[0][0].ToString());

            num = num + 1;
            foreach (DirectoryInfo info2 in info.GetDirectories())
            {
                if (info2 != null)
                {
                    bool flag = false;
                    foreach (DataRow row2 in table.Rows)
                    {
                        if (row2["T_Path"].ToString() == info2.Name)
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        if (info2.Name.StartsWith("_")) continue;
                        DataRow row3 = table.NewRow();
                        row3["T_ID"] = num.ToString();
                        row3["T_Path"] = info2.Name;

                        TemplateAboutInfo templateAboutInfo = GetTemplateAboutInfo(info2.FullName);
                        row3["T_Name"] = templateAboutInfo.name;
                        row3["T_Author"] = templateAboutInfo.author;
                        row3["T_AddDate"] = templateAboutInfo.createdate;
                        row3["T_Ver"] = templateAboutInfo.ver;
                        row3["T_Copyright"] = templateAboutInfo.copyright;
                        table.Rows.Add(row3);
                        num++;
                    }
                }
            }

            table.AcceptChanges();

            return table;
        }

        /// <summary>
        /// ��ȡ����ģ������
        /// </summary>
        /// <returns></returns>
        private DataTable GetValidTemplateList()
        {
            return XYECOM.Core.Data.SqlHelper.SelectByWhere("b_Template", "", "");
        }

        public int SelectMaxID(string tablename, string maxid)
        {
            if (XYECOM.Core.Data.SqlHelper.ExecuteTable("Select Top 1 " + maxid + " From " + tablename).Rows.Count == 0)
            {
                return 0;
            }
            return Convert.ToInt32(XYECOM.Core.Data.SqlHelper.ExecuteTable("Select Max(" + maxid + ") From " + tablename).Rows[0][0].ToString());
        }

        #endregion

        #region ɾ��ģ����Ϣ
        /// <summary>
        /// ɾ�����ģ��
        /// </summary>
        /// <param name="templateidlist">ģ���¼Id��</param>
        /// <returns>Ӱ������</returns>
        public int DeleteTemplateItem(string templateidlist)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where T_ID in ("+templateidlist+")"),
                new SqlParameter("@strTableName","b_Template")
            };
            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }

        /// <summary>
        /// ɾ��ģ��
        /// </summary>
        /// <param name="T_ID">��¼Id</param>
        /// <returns>Ӱ������</returns>
        public int DeleteTemplateItem(int T_ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where T_ID="+T_ID.ToString()),
                new SqlParameter("@strTableName","b_Template")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }
        #endregion

        #region �޸�����״̬
        /// <summary>
        /// �޸�����״̬
        /// </summary>
        /// <param name="T_ID">ģ����</param>
        /// <returns>Ӱ������</returns>
        public int UpdateFlag(int T_ID)
        {
            Function.UpdateColumuByWhere("T_ID", T_ID.ToString (), "", "b_WebInfo");
            Function.UpdateColumuByWhere("T_Flag", "0", " where 1=1 ", "b_Template");
            return Function.UpdateColumuByWhere("T_Flag", "1", " where T_ID=" + T_ID, "b_Template");
        }
        #endregion

    }
}
