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
    /// �������ݴ�����
    /// </summary>
    public class Attachment
    {
        private const string SQL_GET_ITEM = "select * from pl_Attachment where At_ID={0}";

        private const string SQL_GET_ITEMS = "select * from pl_Attachment where DescTabID ={0} and DescTabName='{1}'";

        /// <summary>
        /// ��Ӹ�����Ϣ
        /// </summary>
        /// <param name="ea">ʵ����</param>
        /// <returns>��Ӱ�������</returns>
        public int Insert(XYECOM.Model.AttachmentInfo ea, out long At_ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            {                
                new SqlParameter("@AT_ID",SqlDbType.BigInt),
                new SqlParameter("@DescTabID",ea.DescTabID),
                new SqlParameter("@DescTabName",ea.DescTabName),
                new SqlParameter("@At_FileFormat",ea.At_FileFormat),
                new SqlParameter("@At_Index",ea.At_Index),
                new SqlParameter("@At_FileType",ea.At_FileType),
                new SqlParameter("@At_Remark",ea.At_Remark),
                new SqlParameter("@At_Path",ea.At_Path),
                new SqlParameter("@S_ID",ea.S_ID)
            };

            param[0].Direction = ParameterDirection.Output;
            int rowAffected = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertAttachment", param);

            if (rowAffected >= 0)
                At_ID = (long)param[0].Value;
            else
                At_ID = -1;

            return rowAffected;
        }


        /// <summary>
        /// �޸ĸ�����Ϣ
        /// </summary>
        /// <param name="ea">ʵ����</param>
        /// <returns>��Ӱ�������</returns>
        public int Update(XYECOM.Model.AttachmentInfo info)
        {
            SqlParameter[] param = new SqlParameter[] 
            {   
                new SqlParameter("@At_ID",info.At_ID), 
                new SqlParameter("@DescTabID",info.DescTabID),
                new SqlParameter("@DescTabName",info.DescTabName),
                new SqlParameter("@At_FileFormat",info.At_FileFormat),
                new SqlParameter("@At_Index",info.At_Index),
                new SqlParameter("@At_FileType",info.At_FileType),
                new SqlParameter("@At_Remark",info.At_Remark),
                new SqlParameter("@At_Path",info.At_Path),
                new SqlParameter("@S_ID",info.S_ID),
                new SqlParameter("@ThumbnailImg",info.ThumbnailImg),
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateAttachment", param);
        }

        /// <summary>
        /// �޸��������еĸ�����Ϣ�ڸ�������ӳ��ļ�¼���
        /// </summary>
        /// <param name="At_ID">������Ϣ�ı��</param>
        /// <param name="DescTabID">ԭ���еı�ţ�������ӳ�䣩</param>
        /// <returns>��Ӱ�������</returns>
        public int Update(string At_ID, long DescTabID)
        {
            SqlParameter[] param = new SqlParameter[] 
            {   
                new SqlParameter("@At_ID",At_ID), 
                new SqlParameter("@DescTabID",DescTabID)                  
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateInAttachmentByDescTabID", param);
        }


        /// <summary>
        /// ɾ��һ����¼
        /// </summary>
        /// <param name="attId">��¼���</param>
        /// <returns>��Ӱ�������</returns>
        public int Delete(long attId)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where At_ID="+attId.ToString()),
                new SqlParameter("@strTableName","pl_Attachment")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }

        /// <summary>
        /// ɾ������������Ϣ
        /// </summary>
        /// <param name="attIds">�Զ��ſɿ��ĸ���Id</param>
        /// <returns>��Ӱ�������</returns>
        public int Delete(string attIds)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere"," where At_ID in  ("+attIds.ToString () +")" ),
                new SqlParameter("@strTableName","pl_Attachment")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }

        /// <summary>
        /// ɾ��������������
        /// </summary>
        /// <returns>��Ӱ�������</returns>
        public int DeleteAllTemp()
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere"," where descTabId <=0" ),
                new SqlParameter("@strTableName","pl_Attachment")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }

        /// <summary>
        /// ������Ӧ�ı����Ƿ����ͼƬ���ֶ�
        /// ��Ҫ��ɾ������ʱ����
        /// </summary>
        /// <param name="descTabName">��Ϣ���ʶ����</param>
        /// <param name="descTabId">��ϢId</param>
        /// <returns>��Ӱ�������</returns>
        public int UpdateInfoIsHasImage(string descTabName, long descTabId)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@DescTabID",descTabId.ToString()),
                new SqlParameter("@DescTabName",descTabName)
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("XYP_UpdateInfoIsHasImage", param);
        }

        #region Read Data
        /// <summary>
        /// ��ȡһ����¼
        /// </summary>
        /// <param name="At_ID">��¼���</param>
        /// <returns>һ����¼</returns>
        public XYECOM.Model.AttachmentInfo GetItem(long attId)
        {
            XYECOM.Model.AttachmentInfo info = null;

            string cmdText = string.Format(SQL_GET_ITEM, attId);

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(cmdText))
            {
                if (reader.Read())
                {
                    info = SetInfo(reader);
                }
            }

            return info;
        }

        /// <summary>
        /// ��ȡָ����Ϣ�����и���
        /// </summary>
        /// <param name="DescTabId">��Ϣid</param>
        /// <param name="descTabName">��Ϣ��ʶ����</param>
        /// <returns></returns>
        public List<Model.AttachmentInfo> GetItems(long DescTabId, string descTabName)
        {
            string cmdText = string.Format(SQL_GET_ITEMS, DescTabId, descTabName);

            List<Model.AttachmentInfo> list = new List<XYECOM.Model.AttachmentInfo>();

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(cmdText))
            {
                while (reader.Read())
                {
                    list.Add(SetInfo(reader));
                }
            }

            return list;
        }

        /// <summary>
        /// ��ȡ������¼
        /// </summary>
        /// <param name="DescTabID">��ϢId</param>
        /// <param name="DescTabName">��Ϣ��ʶ����</param>
        /// <returns>������¼</returns>
        public DataTable GetDataTable(long descTabID, string descTabName, string fileType)
        {
            string cmdText = "Select * from XYV_Attachment ";

            if (fileType == "image" || fileType == "file")
                cmdText += "where DescTabID=" + descTabID.ToString() + " and DescTabName='" + descTabName.ToString() + "' and AT_FileType='" + fileType + "'";
            else
                cmdText += "where DescTabID=" + descTabID.ToString() + " and DescTabName='" + descTabName.ToString() + "'";


            DataTable table = XYECOM.Core.Data.SqlHelper.ExecuteTable(cmdText);

            return table;
        }

        /// <summary>
        /// ����������Ч����
        /// </summary>
        /// <returns>���ݱ����</returns>
        public DataTable GetAllTemp()
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strwhere","where DescTabID <=0 "),
                new SqlParameter("@strtableName","XYV_Attachment"),
                new SqlParameter("@strOrder"," ")
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "XYP_SelectByWhere", param);
        }


        /// <summary>
        /// ��ȡָ��Id�Ķ��������Ϣ
        /// </summary>
        /// <param name="attIds">�Զ��Ÿ����ĸ�����Ϣid</param>
        /// <returns>���ݱ����</returns>
        public DataTable GetDataTable(string attIds)
        {
            string cmdText = "select * from XYV_Attachment where at_id in(" + attIds + ")";

            return XYECOM.Core.Data.SqlHelper.ExecuteTable(cmdText);
        }


        /// <summary>
        /// ��ȡĬ�ϸ�����Ϣ����Ĭ��ͼƬ�ȣ�
        /// </summary>
        /// <param name="DescTabName">��Ϣ��ʶ����</param>
        /// <param name="DescTabID">��ϢId</param>
        /// <returns>��������</returns>
        public XYECOM.Model.AttachmentInfo GetTop1Info(string DescTabName, string DescTabID)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strTop","1"),
                new SqlParameter("@strwhere"," where DescTabID="+DescTabID+" and DescTabName='"+DescTabName+"' and AT_FileType='image'"),
                new SqlParameter("@strtableName","XYV_Attachment"),
                new SqlParameter("@strOrder"," order by at_id asc")
            };

            using (SqlDataReader rdr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (rdr.Read())
                {
                    return SetInfo(rdr);
                }
            }
            return null;
        }

        #endregion

        /// <summary>
        /// ��SqlDataReader�ж�ȡ���ݵ�Modelʵ������
        /// </summary>
        /// <param name="rdr">SqlDataReader����</param>
        /// <returns>����ʵ�����</returns>
        private XYECOM.Model.AttachmentInfo SetInfo(SqlDataReader rdr)
        {
            XYECOM.Model.AttachmentInfo info = new XYECOM.Model.AttachmentInfo();

            info.At_FileFormat = rdr["At_FileFormat"].ToString();
            info.At_FileType = rdr["At_FileType"].ToString();
            info.At_ID = Core.MyConvert.GetInt64(rdr["At_ID"].ToString());
            info.At_Index = Core.MyConvert.GetInt32(rdr["At_Index"].ToString());
            info.At_Path = rdr["At_Path"].ToString();
            info.At_PulishDate = Core.MyConvert.GetDateTime(rdr["At_PulishDate"].ToString());
            info.At_Remark = rdr["At_Remark"].ToString();
            info.DescTabID = Core.MyConvert.GetInt64(rdr["DescTabID"].ToString());
            info.DescTabName = rdr["DescTabName"].ToString();
            info.S_ID = Core.MyConvert.GetInt32(rdr["S_ID"].ToString());
            info.ThumbnailImg = rdr["ThumbnailImg"].ToString();

            //��ȡ��������Ϣ
            info.Server = new Server().GetItem(info.S_ID);
            return info;
        }

        public Model.AttachmentInfo GetItemInfoOfVideo(int userid)
        {
            string sql = "select * from pl_attachment where DescTabName='Video' and DescTabId=" + userid;

            XYECOM.Model.AttachmentInfo info = null;

            using (SqlDataReader rdr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.Text, sql))
            {
                if (rdr.Read())
                {
                    info = new XYECOM.Model.AttachmentInfo();
                    info.At_FileFormat = rdr["At_FileFormat"].ToString();
                    info.At_FileType = rdr["At_FileType"].ToString();
                    info.At_ID = Core.MyConvert.GetInt64(rdr["At_ID"].ToString());
                    info.At_Index = Core.MyConvert.GetInt32(rdr["At_Index"].ToString());
                    info.At_Path = rdr["At_Path"].ToString();
                    info.At_PulishDate = Core.MyConvert.GetDateTime(rdr["At_PulishDate"].ToString());
                    info.At_Remark = rdr["At_Remark"].ToString();
                    info.DescTabID = Core.MyConvert.GetInt64(rdr["DescTabID"].ToString());
                    info.DescTabName = rdr["DescTabName"].ToString();
                    info.S_ID = Core.MyConvert.GetInt32(rdr["S_ID"].ToString());
                    info.ThumbnailImg = rdr["ThumbnailImg"].ToString();

                    //��ȡ��������Ϣ
                    info.Server = new Server().GetItem(info.S_ID);
                }
            }
            return info;
        }
    }
}
