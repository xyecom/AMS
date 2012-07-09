using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

namespace XYECOM.Web.xymanage.LabelManage
{
    public partial class LabelOutIn : XYECOM.Web.BasePage.ManagePage
    {
        public string LT_ParentID = "0";
        int isok = 0;
        string strsql = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("label");

            this.rbttypelabel.Attributes.Add("onclick", "ExportNavLabel();");
            this.rbtcontentlabel.Attributes.Add("onclick", "ExportNavLabel();");

            if (!IsPostBack)
            {
                ListBox_DataBound();
                ReadFile();
            }
            this.Label1.Text = "";
        }

        #region ���б��

        protected void ListBox_DataBound()
        {
            this.ddlclassID.Items.Clear();
            this.ddlclassID.Items.Add(new ListItem("��ѡ��Ҫ�����ı�ǩ����", "-1"));
            XYECOM.Business.LabelType lt = new XYECOM.Business.LabelType();
            String strwhere = " where LT_ParentID=0 ";
            DataTable dt = lt.GetDataTable(strwhere);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    this.ddlclassID.Items.Add(new ListItem(dt.Rows[i]["LT_Name"].ToString(), dt.Rows[i]["LT_ID"].ToString()));
                }
            }

        }


        #endregion

        #region һ������
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.rbtcontentlabel.Checked == true && this.ddlclassID.SelectedValue.Equals("-1"))
            {
                tablename = "b_label";
                strsql = CreatInserSql(tablename, "", "contentLabel");
                isok = CreateFiled(strsql, "�������ݱ�ǩ");
            }
            if (this.rbttypelabel.Checked == true)
            {
                tablename = "xy_classLabel";
                strsql = CreatInserSql(tablename, "", "typeLabel");
                isok = CreateFiled(strsql, "���з����ǩ");

            }
            if (!this.ddlclassID.SelectedValue.Equals("-1"))
            {
                LabelOutByType();
            }

            if (isok <= 0)
            {
                this.Label1.Text = "�����ɹ�";
                ReadFile();
            }
            else
            {
                this.Label1.Text = "����ʧ��";
            }
        }
        #endregion


        #region ����ǩ���ർ��
        protected void LabelOutByType()
        {
            String typeid = this.ddlclassID.SelectedValue;
            if (!typeid.Equals("-1"))
            {
                String strWhere = " where LT_ID = " + typeid;
                tablename = "b_label";
                strsql = CreatInserSql(tablename, strWhere, "classLabel");
                isok = CreateFiled(strsql, this.ddlclassID.SelectedItem.Text);
                if (isok <= 0)
                {
                    this.Label1.Text = "�����ɹ�";
                    ReadFile();
                }
                else
                {
                    this.Label1.Text = "����ʧ��";
                }
            }
        }
        #endregion


        #region ���ɵ�����XML�ĵ�
        /// <summary>
        /// ���ɵ�����XML�ĵ�
        /// </summary>
        /// <param name="tablename">Ҫ�����ı���</param>
        /// <param name="strwhere">����</param>
        private String CreatInserSql(String tablename, String strwhere, String namefalg)
        {

            DataTable dt = new DataTable();
            if (strwhere.Equals(""))
            {
                dt = XYECOM.Core.Data.SqlHelper.ExecuteTable("select * from " + tablename + "");
            }
            else
            {
                dt = XYECOM.Core.Data.SqlHelper.ExecuteTable("select * from " + tablename + " " + strwhere + "");
            }
            String strxml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
            strxml += "<xml>\r\n";
            strxml += "<name>" + namefalg + "</name>\r\n";
            if (dt.Rows.Count > 0)
            {

                if (tablename.Equals("b_label"))
                {
                    strxml += "<data>\r\n";

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        strxml += "<item>\r\n";
                        strxml += "<tablename>" + tablename + "</tablename>\r\n";
                        for (int j = 1; j < dt.Columns.Count; j++)
                        {
                            strxml += "<" + dt.Columns[j].ColumnName + ">" + System.Text.RegularExpressions.Regex.Replace(dt.Rows[i][j].ToString(), ((char)10).ToString(), "").Replace("&", "&amp;").Replace("\"", "&quot;").Replace("'", "&apos;").Replace("<", "&lt;").Replace(">", "&gt;") + "</" + dt.Columns[j].ColumnName + ">\r\n";
                        }
                        strxml += "</item>\r\n";
                    }
                    strxml += "</data>\r\n";
                    strxml += "<type>\r\n";

                    if (!strwhere.Equals(""))
                    {
                        dt = XYECOM.Core.Data.SqlHelper.ExecuteTable("select * from b_labeltype " + strwhere + "");
                    }
                    else
                    {
                        dt = XYECOM.Core.Data.SqlHelper.ExecuteTable("select * from b_labeltype");
                    }

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        strxml += "<typeitem>\r\n";
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            strxml += "<" + dt.Columns[j].ColumnName + ">" + System.Text.RegularExpressions.Regex.Replace(dt.Rows[i][j].ToString(), ((char)10).ToString(), "").Replace("&", "&amp;").Replace("\"", "&quot;").Replace("'", "&apos;").Replace("<", "&lt;").Replace(">", "&gt;") + "</" + dt.Columns[j].ColumnName + ">\r\n";
                        }
                        strxml += "</typeitem>\r\n";
                    }

                    strxml += "</type>\r\n";
                }
            }
            else
            {
                return "";
            }


            if (tablename.Equals("xy_classLabel"))
            {
                strxml += "<data>\r\n";

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strxml += "<item>\r\n";
                    strxml += "<tablename>" + tablename + "</tablename>\r\n";
                    for (int j = 1; j < dt.Columns.Count; j++)
                    {
                        strxml += "<" + dt.Columns[j].ColumnName + ">" + System.Text.RegularExpressions.Regex.Replace(dt.Rows[i][j].ToString(), ((char)10).ToString(), "").Replace("&", "&amp;").Replace("\"", "&quot;").Replace("'", "&apos;").Replace("<", "&lt;").Replace(">", "&gt;") + "</" + dt.Columns[j].ColumnName + ">\r\n";
                    }
                    strxml += "</item>\r\n";
                }
                strxml += "</data>\r\n";

            }
            strxml += "</xml>\r\n";
            return strxml;

        }
        #endregion

        #region �ڷ������������ļ�
        /// <summary>
        /// �ڷ������������ļ�
        /// </summary>
        /// <param name="str">Ҫ���ļ���д�������</param>
        /// <param name="name">�ļ���</param>
        private int CreateFiled(String str, String name)
        {
            String path = Server.MapPath("/_BackUp/BackUpLabel/");
            int i = 0;
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            if (str.Equals(""))
            {
                return 1;
            }
            path += name + ".xml";

            try
            {
                StreamWriter stream = new StreamWriter(path);
                stream.Write(str);
                stream.Flush();
                stream.Close();
            }
            catch (Exception ex)
            {
                i = 1;
                this.Label1.Text = ex.Message;
            }
            return i;
        }
        #endregion

        #region ��ȡ�������˵��ļ�
        private void ReadFile()
        {
            string dirPath = Server.MapPath("/_BackUp/BackUpLabel");
            if (!Directory.Exists(dirPath)) Directory.CreateDirectory(dirPath);
            DirectoryInfo info = new DirectoryInfo(dirPath);

            this.ddlBakFileList.Items.Clear();
            foreach (FileInfo file in info.GetFiles())
            {
                if (file != null)
                {
                    ListItem item = new ListItem();

                    item.Text = file.Name + "  ����ʱ��  [" + file.CreationTime.ToString() + "]";
                    item.Value = file.FullName;
                    this.ddlBakFileList.Items.Add(item);
                }
            }
        }
        #endregion

        #region ɾ���ļ�

        protected void btnDeleteBackFile_Click(object sender, EventArgs e)
        {
            string fileName = this.ddlBakFileList.SelectedValue;

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            ReadFile();
        }
        #endregion

        #region �����ļ�

        protected void btnDownloadBackFile_Click(object sender, EventArgs e)
        {
            string fileName = this.ddlBakFileList.SelectedValue;

            if (fileName == "") return;

            FileInfo file = new FileInfo(fileName);

            XYECOM.Core.Utils.ResponseFile(fileName, file.Name, "application/msword");
        }
        #endregion

    }
}
