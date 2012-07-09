using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using XYECOM.Core.Data;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// �����ǩ���ݴ�����
    /// </summary>
    public class ClassLabel:DataCache
    {
        /// <summary>
        /// ����һ�������ǩ��Ϣ
        /// </summary>
        /// <param name="info">�����ǩʵ�����</param>
        /// <returns>��Ӱ������</returns>
        public int Insert(Model.ClassLabelInfo info)
        {
            string cmdText = "Insert Into XY_ClassLabel(name,CNName,body,tableName)"
                            +"values (@Name,@CNName,@Body,@TableName)";

            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@Name",info.Name),
                new SqlParameter("@CNName",info.CNName),
                new SqlParameter("@Body",info.Body),
                new SqlParameter("@TableName",info.TableName)
            };

            int result =  XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.Text,cmdText,param);

            UpdateCache();

            return result;
        }

        /// <summary>
        /// ���·����ǩ����
        /// </summary>
        /// <param name="info">ʵ�����</param>
        /// <returns>��Ӱ������</returns>
        public int Update(Model.ClassLabelInfo info)
        {
            string cmdText = "update XY_ClassLabel set name=@Name,CNName=@CNName,body=@Body,tableName=@TableName where Id = " + info.ID;

            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@Name",info.Name),
                new SqlParameter("@CNName",info.CNName),
                new SqlParameter("@Body",info.Body),
                new SqlParameter("@TableName",info.TableName)
            };

            int result = XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.Text, cmdText, param);

            UpdateCache();

            return result;
        }

        /// <summary>
        /// ɾ�������ǩ
        /// </summary>
        /// <param name="Id">��ǩId</param>
        /// <returns></returns>
        public int Delete(int Id)
        {
            string cmdText = "Delete From XY_ClassLabel where Id = " + Id;

            int result =  SqlHelper.ExecuteNonQuery(cmdText);

            UpdateCache();

            return result;
        }

        /// <summary>
        /// ��ȡ�����ǩ����
        /// </summary>
        /// <param name="Id">�����ǩId</param>
        /// <returns>���ݶ���</returns>
        public Model.ClassLabelInfo GetItem(int Id)
        {
            XYECOM.Model.ClassLabelInfo info = null;

            Object obj= GetCache();

            if (obj != null)
            {
                DataTable table = (DataTable)obj;

                DataRow[] rows = table.Select("Id =" + Id);

                if (rows.Length >0)
                {
                    info = new XYECOM.Model.ClassLabelInfo();
                    info.ID = Id;
                    info.Name = rows[0]["name"].ToString();
                    info.Body = rows[0]["body"].ToString();
                    info.TableName = rows[0]["tableName"].ToString();
                    info.CNName = rows[0]["CNName"].ToString();
                }
            }

            return info;
        }

       /// <summary>
       /// ��ȡ�����ǩ����
       /// </summary>
       /// <param name="name">��ǩ����</param>
        /// <returns>���ݶ���</returns>
        public Model.ClassLabelInfo GetItem(string name)
        {
            XYECOM.Model.ClassLabelInfo info = null;

            Object obj = GetCache();

            if (obj != null)
            {
                DataTable table = (DataTable)obj;

                DataRow[] rows = table.Select("Name ='" + name + "'");

                if (rows.Length > 0)
                {
                    info = new XYECOM.Model.ClassLabelInfo();
                    info.ID = Core.MyConvert.GetInt32(rows[0]["Id"].ToString());
                    info.Name = name;
                    info.Body = rows[0]["body"].ToString();
                    info.TableName = rows[0]["tableName"].ToString();
                    info.CNName = rows[0]["CNName"].ToString();
                }
            }

            return info;
        }

        /// <summary>
        /// �Ƿ����ͬ����ǩ
        /// </summary>
        /// <param name="name">��ǩ����</param>
        /// <returns>true:����,false:������</returns>
        public bool IsExists(string name)
        {
            Object obj = GetCache();

            if (obj == null) return false;

            DataTable table = (DataTable)obj;

            DataRow[] rows = table.Select("name ='" + name + "'");

            if (rows.Length > 0) return true;

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        public override string SQL_Get_All
        {
            get { return "Select * From XY_ClassLabel"; }
        }
    }
}
