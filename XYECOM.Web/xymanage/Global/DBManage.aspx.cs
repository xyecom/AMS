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
using System.Data.SqlClient;
using XYECOM.Business;
using System.IO;
using System.Net;
using XYECOM.Core;

namespace XYECOM.Web.xymanage.Global
{
    public partial class DBManage : XYECOM.Web.BasePage.ManagePage
    {
        public string databasename = XYECOM.Core.Data.SqlHelper.ConnectionString;
        public string database = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("database");

            if (!Page.IsPostBack)
            {
                database = GetSystemDatabaseName();

                string dirPath = Server.MapPath("/_BackUp");

                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }

                ReadBackFile();
            }
        }
        private string GetSystemDatabaseName()
        {
            if (databasename.IndexOf("_BackUp", StringComparison.OrdinalIgnoreCase) > 0)
            {
                databasename = databasename.Substring(databasename.IndexOf("database", StringComparison.OrdinalIgnoreCase)).Split(';')[0];
                database = databasename.Substring(databasename.IndexOf("=")).Substring(1);

                return database;
            }

            if (databasename.IndexOf("Initial Catalog", StringComparison.OrdinalIgnoreCase) > 0)
            {
                databasename = databasename.Substring(databasename.IndexOf("Initial Catalog", StringComparison.OrdinalIgnoreCase)).Split(';')[0];
                database = databasename.Substring(databasename.IndexOf("=")).Substring(1);

                return database;
            }

            return "";
        }

        #region �����
        private string GenerateCheckCode()
        {
            int number;
            char code;
            string checkCode = String.Empty;
            System.Random random = new Random();
            for (int i = 0; i < 6; i++)
            {
                number = random.Next();
                code = (char)('0' + (char)(number % 10));
                checkCode += code.ToString();
            }

            return checkCode;
        }
        #endregion

        protected void btnDeleteBackFile_Click(object sender, EventArgs e)
        {
            string fileName = this.ddlBakFileList.SelectedValue;

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            ReadBackFile();
        }

        private void ReadBackFile()
        {
            string dirPath = Server.MapPath("/_BackUp");

            DirectoryInfo info = new DirectoryInfo(dirPath);

            this.ddlBakFileList.Items.Clear();
            foreach (FileInfo file in info.GetFiles())
            {
                if (file != null)
                {
                    ListItem item = new ListItem();
                    item.Text = file.Name + "[" + file.CreationTime.ToString("yyyy-MM-dd") + "]";
                    item.Value = file.FullName;
                    this.ddlBakFileList.Items.Add(item);
                }
            }
        }

        protected void btnDownloadBackFile_Click(object sender, EventArgs e)
        {
            string fileName = this.ddlBakFileList.SelectedValue;

            if (fileName == "") return;

            FileInfo file = new FileInfo(fileName);

            XYECOM.Core.Utils.ResponseFile(fileName, file.Name, "application/msword");
        }

        protected void btnExexSql_Click(object sender, EventArgs e)
        {
            string sql = this.txtSQL.Text.Trim();

            if (sql.Equals(""))
            {
                this.lblExecSqlResult.InnerHtml = "������SQL���!";
                return;
            }

            this.lblExecSqlResult.InnerHtml = "";

            string result = "ִ�гɹ���";

            try
            {
                int rows = XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(sql);

                if (rows>=0)result += "��Ӱ�������Ϊ��" + rows +" �С�";
            }
            catch (SqlException ex)
            {
                result = ex.Message + "<br/><br/>" + ex.StackTrace;
            }
            finally
            {
                XYECOM.Model.LogInfo el = new XYECOM.Model.LogInfo();

                el.L_Title = "���ݿ�ά��";
                el.L_Content = this.txtSQL.Text;
                el.L_MF = "ϵͳ����";

                
                {
                    el.UM_ID = AdminId;
                }
                new XYECOM.Business.Log().Insert(el);
            }

            this.lblExecSqlResult.InnerHtml = result;
        }

        protected void btnBackUpDatabase_Click(object sender, EventArgs e)
        {
            string prefix = DateTime.Now.ToString("yyyyMMddhhssmm");

            string UserFileName = prefix + GenerateCheckCode();

            database = GetSystemDatabaseName();

            string path = Server.MapPath("/_BackUp/");

            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            path += UserFileName + ".bak";

            if (!File.Exists(path))
            {
                try
                {
                    StreamWriter stream = new StreamWriter(path);
                    stream.Flush();
                    stream.Close();
                }
                catch (Exception ex)
                {
                    WriteLog("�������ݿ�ʧ��", ex);
                }
            }

            try
            {
                string backupSql = "use master;";
                backupSql += "backup database @databse  to disk =@path";

                SqlParameter[] param = new SqlParameter[]
                    {
                        new SqlParameter("@databse",database),
                        new SqlParameter("@path",path),
                    };

                XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.Text, backupSql, param);

                XYECOM.Business.Log l = new XYECOM.Business.Log();
                XYECOM.Model.LogInfo el = new XYECOM.Model.LogInfo();

                el.L_Title = "���ݿ�ά��";
                el.L_Content = "�������ݿ�";
                el.L_MF = "ϵͳ����";
                
                {
                    el.UM_ID = AdminId;
                }

                l.Insert(el);
                Alert("���ݳɹ���");
                ReadBackFile();
            }
            catch (Exception ex)
            {
                string url = "DataList.aspx";
                Alert("����ʧ�ܣ�<br/>(Ŀǰ��֧�ֳ�������������ݷ�����Ϊͬһ�������ı��ݲ�����", url);
                WriteLog("�������ݿ�ʧ�ܣ�", ex);
            }
        }
    }
}
