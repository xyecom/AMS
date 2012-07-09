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
    /// 附件数据处理类
    /// </summary>
    public class Attachment
    {
        private const string SQL_GET_ITEM = "select * from pl_Attachment where At_ID={0}";

        private const string SQL_GET_ITEMS = "select * from pl_Attachment where DescTabID ={0} and DescTabName='{1}'";

        /// <summary>
        /// 添加附件信息
        /// </summary>
        /// <param name="ea">实体类</param>
        /// <returns>受影响的行数</returns>
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
        /// 修改附件信息
        /// </summary>
        /// <param name="ea">实体类</param>
        /// <returns>受影响的行数</returns>
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
        /// 修改其他表中的附加信息在附件表中映射的纪录编号
        /// </summary>
        /// <param name="At_ID">附件信息的编号</param>
        /// <param name="DescTabID">原表中的编号（用于做映射）</param>
        /// <returns>受影响的行数</returns>
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
        /// 删除一条记录
        /// </summary>
        /// <param name="attId">记录编号</param>
        /// <returns>受影响的行数</returns>
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
        /// 删除多条附件信息
        /// </summary>
        /// <param name="attIds">以逗号可开的附件Id</param>
        /// <returns>受影响的行数</returns>
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
        /// 删除所有垃圾附件
        /// </summary>
        /// <returns>受影响的行数</returns>
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
        /// 更新相应的表中是否包含图片的字段
        /// 主要在删除附件时调用
        /// </summary>
        /// <param name="descTabName">信息表标识名称</param>
        /// <param name="descTabId">信息Id</param>
        /// <returns>受影响的行数</returns>
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
        /// 获取一条记录
        /// </summary>
        /// <param name="At_ID">记录编号</param>
        /// <returns>一条记录</returns>
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
        /// 获取指定信息的所有附件
        /// </summary>
        /// <param name="DescTabId">信息id</param>
        /// <param name="descTabName">信息标识名称</param>
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
        /// 获取多条记录
        /// </summary>
        /// <param name="DescTabID">信息Id</param>
        /// <param name="DescTabName">信息标识名称</param>
        /// <returns>多条记录</returns>
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
        /// 返回所有无效数据
        /// </summary>
        /// <returns>数据表对象</returns>
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
        /// 获取指定Id的多个附件信息
        /// </summary>
        /// <param name="attIds">以逗号隔开的附件信息id</param>
        /// <returns>数据表对象</returns>
        public DataTable GetDataTable(string attIds)
        {
            string cmdText = "select * from XYV_Attachment where at_id in(" + attIds + ")";

            return XYECOM.Core.Data.SqlHelper.ExecuteTable(cmdText);
        }


        /// <summary>
        /// 获取默认附件信息（如默认图片等）
        /// </summary>
        /// <param name="DescTabName">信息标识名称</param>
        /// <param name="DescTabID">信息Id</param>
        /// <returns>附件对象</returns>
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
        /// 从SqlDataReader中读取数据到Model实体类中
        /// </summary>
        /// <param name="rdr">SqlDataReader对象</param>
        /// <returns>附件实体对象</returns>
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

            //读取服务器信息
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

                    //读取服务器信息
                    info.Server = new Server().GetItem(info.S_ID);
                }
            }
            return info;
        }
    }
}
