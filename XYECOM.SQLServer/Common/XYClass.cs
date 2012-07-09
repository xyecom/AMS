using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace XYECOM.SQLServer
{

    /*----------------------------------------------------------------
    * Copyright (C) 2008 �ݺ�����������޹�˾
    * ��Ȩ���С� 
    *
    * �ļ�����XYECOM.SQLServer.XYClass.cs
    * �ļ���������������ͨ�÷������ݷ�����
    *
    * ������ʶ��tc  20080429
    *
    ----------------------------------------------------------------*/

    /// <summary>
    /// �������ݴ���ͨ����
    /// </summary>
    public class XYClass
    {
        /// <summary>
        /// ��ȡ������Ϣ
        /// </summary>
        /// <param name="tableInfo">�������Ϣ</param>
        /// <param name="Id">����Id</param>
        /// <returns></returns>
        public Model.XYClassInfo GetItem(Model.XYClassTableInfo tableInfo, long Id)
        {
            string cmdText = "Select " + tableInfo.IdFieldName + "," + tableInfo.NameFieldName + "," + tableInfo.ParentIdFieldName + ","
                    + "(select count(" + tableInfo.IdFieldName + ") from " + tableInfo.TableName + " t2 where t2." + tableInfo.ParentIdFieldName + " = t1." + tableInfo.IdFieldName + ") as subids"
                    + " From " + tableInfo.TableName + " t1 "
                    + " Where " + tableInfo.IdFieldName + " = " + Id + " order by orderid";

            Model.XYClassInfo info = null;

            using (SqlDataReader reader = Core.Data.SqlHelper.ExecuteReader(cmdText))
            {
                if (reader.Read())
                {
                    info = new XYECOM.Model.XYClassInfo();

                    info.ClassId = Id;
                    info.ClassName = reader.GetString(1);
                    info.ParentId = XYECOM.Core.MyConvert.GetInt64(reader[2].ToString());
                    info.HasSub = XYECOM.Core.MyConvert.GetInt32(reader[3].ToString()) > 0;
                }
            }

            return info;
        }

        /// <summary>
        /// ��ȡ������Ϣ
        /// </summary>
        /// <param name="tableInfo">�������Ϣ</param>
        /// <param name="Id">����Id</param>
        /// <param name="moduleName">ģ������</param>
        /// <returns></returns>
        public Model.XYClassInfo GetItem(Model.XYClassTableInfo tableInfo, long Id, string moduleName)
        {
            string cmdText = "Select " + tableInfo.IdFieldName + "," + tableInfo.NameFieldName + "," + tableInfo.ParentIdFieldName + ", "
                    + "(select count(" + tableInfo.IdFieldName + ") from " + tableInfo.TableName + " t2 where t2." + tableInfo.ParentIdFieldName + " = t1." + tableInfo.IdFieldName + ") as subids"
                    + " From " + tableInfo.TableName + " t1 "
                    + " Where " + tableInfo.IdFieldName + " = " + Id
                    + " and " + tableInfo.ModuleFieldName + "='" + moduleName + "'" + " order by orderid";

            Model.XYClassInfo info = null;

            using (SqlDataReader reader = Core.Data.SqlHelper.ExecuteReader(cmdText))
            {
                if (reader.Read())
                {
                    info = new XYECOM.Model.XYClassInfo();

                    info.ClassId = Id;
                    info.ClassName = reader.GetString(1);
                    info.ParentId = XYECOM.Core.MyConvert.GetInt64(reader[2].ToString());
                    info.HasSub = XYECOM.Core.MyConvert.GetInt32(reader[3].ToString()) > 0;
                }
            }

            return info;
        }

        /// <summary>
        /// ��ȡ������Ϣ
        /// </summary>
        /// <param name="tableInfo">�������Ϣ</param>
        /// <param name="className">��������</param>
        /// <returns></returns>
        public Model.XYClassInfo GetItem(Model.XYClassTableInfo tableInfo, string className)
        {
            string cmdText = "Select " + tableInfo.IdFieldName + "," + tableInfo.NameFieldName + "," + tableInfo.ParentIdFieldName + " "
                    + " From " + tableInfo.TableName
                    + " Where " + tableInfo.NameFieldName + " = '" + className + "'" + " order by orderid";

            Model.XYClassInfo info = null;

            using (SqlDataReader reader = Core.Data.SqlHelper.ExecuteReader(cmdText))
            {
                if (reader.Read())
                {
                    info = new XYECOM.Model.XYClassInfo();

                    info.ClassId = XYECOM.Core.MyConvert.GetInt64(reader[0].ToString());
                    info.ClassName = reader.GetString(1);
                    info.ParentId = XYECOM.Core.MyConvert.GetInt64(reader[2].ToString());
                }
            }

            return info;
        }

        /// <summary>
        /// ��ȡ���з�����Ϣ
        /// </summary>
        /// <param name="tableInfo">�������Ϣ</param>
        /// <returns></returns>
        public DataTable GetItemsAll(Model.XYClassTableInfo tableInfo)
        {
            string cmdText = "Select " + tableInfo.IdFieldName + "," + tableInfo.NameFieldName + "," + tableInfo.ParentIdFieldName
                                       + " From " + tableInfo.TableName + " order by orderid";
            return Core.Data.SqlHelper.ExecuteTable(cmdText);
        }

        /// <summary>
        /// ��ȡ���з�����Ϣ
        /// </summary>
        /// <param name="tableInfo">�������Ϣ</param>
        /// <param name="moduleName">ģ������</param>
        /// <returns></returns>
        public DataTable GetItemsAll(Model.XYClassTableInfo tableInfo, string moduleName)
        {
            string cmdText = "Select " + tableInfo.IdFieldName + "," + tableInfo.NameFieldName + "," + tableInfo.ParentIdFieldName
                                       + " From " + tableInfo.TableName
                                       + " where " + tableInfo.ModuleFieldName + "='" + moduleName + "' order by orderid";

            return Core.Data.SqlHelper.ExecuteTable(cmdText);
        }

        /// <summary>
        /// ��ȡ�����ӷ�����Ϣ
        /// </summary>
        /// <param name="tableInfo">�������Ϣ</param>
        /// <param name="parentID">��������Id</param>
        /// <returns></returns>
        public List<Model.XYClassInfo> GetItems(Model.XYClassTableInfo tableInfo, long parentID)
        {
            string cmdText = "Select " + tableInfo.IdFieldName + "," + tableInfo.NameFieldName + ","
                            + "(select count(" + tableInfo.IdFieldName + ") from " + tableInfo.TableName + " t2 where t2." + tableInfo.ParentIdFieldName + " = t1." + tableInfo.IdFieldName + ") as subids"
                            + " From " + tableInfo.TableName + " t1 "
                            + " Where " + tableInfo.ParentIdFieldName + " = " + parentID + " order by orderid";
            string tmpWhere = string.Empty;


            List<Model.XYClassInfo> infos = new List<XYECOM.Model.XYClassInfo>();

            using (SqlDataReader reader = Core.Data.SqlHelper.ExecuteReader(cmdText))
            {
                while (reader.Read())
                {
                    Model.XYClassInfo info = new XYECOM.Model.XYClassInfo();

                    info.ClassId = Convert.ToInt64(reader[0]);
                    info.ClassName = reader.GetString(1);
                    info.HasSub = Core.MyConvert.GetInt32(reader[2].ToString()) > 0;

                    infos.Add(info);
                }
            }
            return infos;
        }

        /// <summary>
        /// ��ȡָ��Id�Ķ�����༯��
        /// </summary>
        /// <param name="tableInfo">�������Ϣ</param>
        /// <param name="ids">id�ַ���</param>
        /// <returns></returns>
        public List<Model.XYClassInfo> GetItems(Model.XYClassTableInfo tableInfo, string ids)
        {
            string cmdText = "Select " + tableInfo.IdFieldName + "," + tableInfo.NameFieldName + ","
                            + "(select count(" + tableInfo.IdFieldName + ") from " + tableInfo.TableName + " t2 where t2." + tableInfo.ParentIdFieldName + " = t1." + tableInfo.IdFieldName + ") as subids"
                            + " From " + tableInfo.TableName + " t1 "
                            + " Where " + tableInfo.IdFieldName + " in (" + ids + ")" + " order by orderid";

            List<Model.XYClassInfo> infos = new List<XYECOM.Model.XYClassInfo>();

            using (SqlDataReader reader = Core.Data.SqlHelper.ExecuteReader(cmdText))
            {
                while (reader.Read())
                {
                    Model.XYClassInfo info = new XYECOM.Model.XYClassInfo();

                    info.ClassId = Convert.ToInt64(reader[0]);
                    info.ClassName = reader.GetString(1);
                    info.HasSub = Core.MyConvert.GetInt32(reader[2].ToString()) > 0;

                    infos.Add(info);
                }
            }


            return infos;
        }

        /// <summary>
        /// �Ƿ�������
        /// </summary>
        /// <param name="tableInfo">��������</param>
        /// <param name="parentID">����Id</param>
        /// <param name="moduleName">ģ������</param>
        /// <returns></returns>
        public bool IsHasSubClass(Model.XYClassTableInfo tableInfo, long parentID, string moduleName)
        {
            string cmdText = "select count(1) from " + tableInfo.TableName + " where " + tableInfo.ParentIdFieldName + " = " + parentID;

            if (!tableInfo.ModuleFieldName.Equals("") && !moduleName.Equals("")) cmdText += " and " + tableInfo.ModuleFieldName + " = '" + moduleName + "'";

            object total = Core.Data.SqlHelper.ExecuteScalar(cmdText);

            if (total != null)
            {
                int _total = Core.MyConvert.GetInt32(total.ToString());

                if (_total > 0) return true;
            }

            return false;
        }

        /// <summary>
        /// ��������Ϣ����
        /// </summary>
        /// <param name="tableInfo"></param>
        /// <param name="parentID"></param>
        /// <param name="moduleName"></param>
        /// <returns></returns>
        public List<Model.XYClassInfo> GetItems(Model.XYClassTableInfo tableInfo, long parentID, string moduleName)
        {
            string cmdText = "Select " + tableInfo.IdFieldName + "," + tableInfo.NameFieldName + ","
                            + "(select count(" + tableInfo.IdFieldName + ") from " + tableInfo.TableName + " t2 where t2." + tableInfo.ParentIdFieldName + " = t1." + tableInfo.IdFieldName + ") as subids"
                            + " From " + tableInfo.TableName + " t1 "
                            + " Where " + tableInfo.ParentIdFieldName + " = " + parentID
                            + " and " + tableInfo.ModuleFieldName + "='" + moduleName + "'" + " order by orderid";

            List<Model.XYClassInfo> infos = new List<XYECOM.Model.XYClassInfo>();

            using (SqlDataReader reader = Core.Data.SqlHelper.ExecuteReader(cmdText))
            {
                while (reader.Read())
                {
                    Model.XYClassInfo info = new XYECOM.Model.XYClassInfo();

                    info.ClassId = Convert.ToInt64(reader[0]);
                    info.ClassName = reader.GetString(1);
                    info.HasSub = Convert.ToInt64(reader[2]) > 0;

                    infos.Add(info);
                }
            }

            return infos;
        }

        /// <summary>
        /// ��ȡ��Ϣ����
        /// </summary>
        /// <param name="tableInfo">�������Ϣ</param>
        /// <param name="typeId">����Id</param>
        /// <param name="modulename">ģ������</param>
        /// <param name="infoType">��Ϣ����</param>
        /// <param name="areaId">����Id</param>
        /// <param name="stime">��ʼʱ��</param>
        /// <param name="etime">����ʱ��</param>
        /// <param name="keyWord1">�ؼ���1</param>
        /// <param name="keyWord2">�ؼ���2</param>
        /// <returns></returns>
        public long GetInfoNum(Model.XYClassTableInfo tableInfo, string typeId, string modulename, XYECOM.Configuration.InfoType infoType, string areaId, string stime, string etime, string keyWord1, string keyWord2)
        {
            String strSql = "select count(*) from " + tableInfo.InfoTableName + " where 1=1 ";

            int _AreaId = Core.MyConvert.GetInt32(areaId);

            //�û����
            if (modulename != "news" && modulename != "job" && modulename != "exhibition")
            {
                strSql += " and UserAuditingState=1 ";
            }

            //���
            if ("exhibition" != modulename && modulename != "company")
            {
                strSql += " and AuditingState = 1 ";
            }

            //���
            if ("news" == modulename)
            {
                string[] arrID = typeId.Split(',');
                string tmpwhere = "";
                for (int i = 0; i < arrID.Length; i++)
                {
                    tmpwhere += 0 == i ? "" : " or ";
                    tmpwhere += " charindex('," + arrID[i] + ",',NT_ID) >0 ";
                }
                strSql += " and (" + tmpwhere + ") ";
            }
            else
            {
                if (modulename.Equals("company"))
                    strSql += " and (" + tableInfo.InfoTableTypeIDFieldName + " = " + typeId + " or charindex('," + typeId + ",',UT_FullId) > 0)";
                else
                    strSql += " and (" + tableInfo.InfoTableTypeIDFieldName + " = " + typeId + " or charindex('," + typeId + ",',FullId) >0 )";
            }

            //����
            strSql += "" == tableInfo.InfoTableIsSupplyFieldName ? " " : " and " + tableInfo.InfoTableIsSupplyFieldName + " = '1' ";
            //����ʱ�� ��Բ�Ʒ��
            strSql += "" == tableInfo.InfoTableEndTimeFieldName ? " " : " and " + tableInfo.InfoTableEndTimeFieldName + " > '" + DateTime.Now + "' ";

            //����(03-26 δ����?)
            //strSql += _AreaId <= 0 ? "" : " and (Area_ID = " + areaId + " Or charindex('," + areaId + ",',AreaFullID) > 0) ";
            strSql += _AreaId <= 0 ? "" : " and Area_ID in(" + new Area().GetSubIds(_AreaId) + ") ";

            //ѡ���ʱ���
            strSql += "" != stime && "" != etime ? " and " + tableInfo.InfoTableAddTimeFieldName + " between '" + stime + "' and '" + etime + "' " : "";
            //�ؼ���
            strSql += "" == keyWord1 ? "" : " and " + tableInfo.InfoTableTitleFieldName + " like'%" + keyWord1 + "%' ";
            strSql += "" == keyWord2 ? "" : " and " + tableInfo.InfoTableTitleFieldName + " like'%" + keyWord2 + "%' ";

            if ("" != tableInfo.InfoTableFlagFieldName)
            {
                List<XYECOM.Configuration.ModuleItemInfo> items = XYECOM.Configuration.Module.Instance.GetItem(modulename).Item;

                string itemwhere = "";
                foreach (XYECOM.Configuration.ModuleItemInfo item in items)
                {
                    if (item.InfoType == infoType)
                    {
                        if (itemwhere != "")
                        {
                            if (item.ID != 0)
                                itemwhere += " or " + tableInfo.InfoTableFlagFieldName + "=" + item.ID.ToString();
                        }
                        else
                        {
                            if (item.ID != 0)
                                itemwhere += " " + tableInfo.InfoTableFlagFieldName + "=" + item.ID.ToString();
                        }
                    }
                }
                strSql += "" == itemwhere ? "" : " and (" + itemwhere + ") ";
            }

            Object obj = XYECOM.Core.Data.SqlHelper.ExecuteScalar(strSql);

            return XYECOM.Core.MyConvert.GetInt32(obj.ToString());
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="flagname"></param>
        /// <param name="infoname"></param>
        /// <param name="oldnum"></param>
        /// <param name="newnum"></param>
        /// <returns></returns>
        public int UpdatesByID(String tablename, String flagname, String infoname, String oldnum, String newnum)
        {
            String strsql = "update " + tablename + " set " + flagname + " = " + newnum
                            + " where " + infoname + " in(select " + infoname + " from " + tablename + " where " + flagname + " = " + oldnum + ")";

            int i = XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(strsql);

            if (i > 0)
            {
                return i;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// ��ȡ��Ϣ����
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="fieldname"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int InfoNum(String tablename, String fieldname, String ids)
        {
            String strsql = "";
            if (tablename.Equals("n_news"))
            {
                strsql = "select count(" + fieldname + ") from " + tablename + " where " + fieldname + " like '%" + ids + "%'";
            }
            else if (tablename.Equals("XY_CompanyProductType"))
            {
                strsql = "select sum(" + fieldname + ") from " + tablename + " where id in(" + ids + ")";
            }
            else
            {
                strsql = "select count(" + fieldname + ") from " + tablename + " where " + fieldname + " in(" + ids + ")";
            }
            
            int i = XYECOM.Core.MyConvert.GetInt32(XYECOM.Core.Data.SqlHelper.ExecuteScalar(strsql).ToString());

            if (i > 0)
            {
                return i;
            }
            else
            {
                return 0;
            }
        }

        #region �Զ��������ȡ
        /// <summary>
        /// �Զ��������ȡ
        /// </summary>
        /// <param name="tableInfo"></param>
        /// <param name="parentID"></param>
        /// <param name="customParams"></param>
        /// <returns></returns>
        public List<Model.XYClassInfo> GetCustomParamsItems(Model.XYClassTableInfo tableInfo, long parentID, string customParams)
        {
            string strparams = GetParamsSql(tableInfo.TableName, customParams);

            string cmdText = "Select " + tableInfo.IdFieldName + "," + tableInfo.NameFieldName + ","
                            + "(select count(" + tableInfo.IdFieldName + ") from " + tableInfo.TableName + " t2 where t2." + tableInfo.ParentIdFieldName + " = t1." + tableInfo.IdFieldName + ") as subids"
                            + " From " + tableInfo.TableName + " t1 "
                            + " Where (" + (parentID == 0 ? (tableInfo.ParentIdFieldName + " is null" + " or " + tableInfo.ParentIdFieldName + "=0 ") : (tableInfo.ParentIdFieldName + " = " + parentID)) + ")" + strparams + " order by orderid";

            List<Model.XYClassInfo> infos = new List<XYECOM.Model.XYClassInfo>();

            using (SqlDataReader reader = Core.Data.SqlHelper.ExecuteReader(cmdText))
            {
                while (reader.Read())
                {
                    Model.XYClassInfo info = new XYECOM.Model.XYClassInfo();

                    info.ClassId = Convert.ToInt64(reader[0]);
                    info.ClassName = reader.GetString(1);
                    info.HasSub = Core.MyConvert.GetInt32(reader[2].ToString()) > 0;

                    infos.Add(info);
                }
            }
            return infos;
        }

        public List<Model.XYClassInfo> GetCustomParamsItems(Model.XYClassTableInfo tableInfo, long parentID, string moduleName, string customParams)
        {
            string strparams = GetParamsSql(tableInfo.TableName, customParams);

            string cmdText = "Select " + tableInfo.IdFieldName + "," + tableInfo.NameFieldName + ","
                            + "(select count(" + tableInfo.IdFieldName + ") from " + tableInfo.TableName + " t2 where t2." + tableInfo.ParentIdFieldName + " = t1." + tableInfo.IdFieldName + ") as subids"
                            + " From " + tableInfo.TableName + " t1 "
                            + " Where " + tableInfo.ParentIdFieldName + " = " + parentID
                            + " and " + tableInfo.ModuleFieldName + "='" + moduleName + "' " + strparams + "" + " order by orderid";

            List<Model.XYClassInfo> infos = new List<XYECOM.Model.XYClassInfo>();

            using (SqlDataReader reader = Core.Data.SqlHelper.ExecuteReader(cmdText))
            {
                while (reader.Read())
                {
                    Model.XYClassInfo info = new XYECOM.Model.XYClassInfo();

                    info.ClassId = Convert.ToInt64(reader[0]);
                    info.ClassName = reader.GetString(1);
                    info.HasSub = Convert.ToInt64(reader[2]) > 0;

                    infos.Add(info);
                }
            }

            return infos;
        }

        /// <summary>
        /// ƴ���Զ������SQL���
        /// </summary>
        /// <param name="custom"></param>
        /// <returns></returns>
        public static string GetParamsSql(string tableName, string custom)
        {
            string str = "";
            string[] strarr = custom.Split('|');

            tableName = tableName.ToLower();

            if (tableName.Equals("xy_companyproducttype"))
            {
                for (int i = 0; i < strarr.Length; i++)
                {
                    string[] many = strarr[i].Split(':');
                    if (many.Length == 2 && many[0].Equals("uid") && !("".Equals(many[1]) || "0".Equals(many[1])))
                    {
                        str += " and UserId=" + many[1] + " ";
                    }
                }
            }

            if (tableName.Equals("n_newstitleinfo"))
            {
                for (int i = 0; i < strarr.Length; i++)
                {
                    string[] many = strarr[i].Split(':');

                    if (many.Length != 2) continue;

                    if (many[0].Equals("contribut"))
                    {
                        if (many[1].Equals("0"))
                            str += " and NT_IsAllowContribut=1";
                        else
                            str += " and NT_IsAllowContribut=0";
                    }
                    if (many[0].Equals("hidden"))
                    {
                        if (many[1].Equals("0"))
                            str += " and NT_IsShow=1";
                        else
                            str += " and NT_IsShow=0";
                    }
                }
            }

            if (tableName.Equals("b_producttype"))
            {
                for (int i = 0; i < strarr.Length; i++)
                {
                    string[] many = strarr[i].Split(':');

                    if (many.Length != 2) continue;

                    if (many[0].Equals("tradeids"))
                    {
                        string tradeIds = many[1].Replace(",,", ",");

                        if (tradeIds.Equals("")) continue;

                        str += " and ( TradeId in(" + tradeIds + ") or TradeId = 0) ";
                    }
                }
            }

            if (tableName.Equals("xy_usernewstitleinfo"))
            {
                for (int i = 0; i < strarr.Length; i++)
                {
                    string[] many = strarr[i].Split(':');
                    if (many.Length == 2 && many[0].Equals("uid") && !("".Equals(many[1]) || "0".Equals(many[1])))
                    {
                        str += " and UserId=" + many[1] + " ";
                    }
                }
            }

            return str;
        }

        #endregion


        /// <summary>
        /// ���·����²�Ʒ����������
        /// </summary>
        /// <param name="srotType">��������</param>
        /// <param name="sortId">����Id</param>
        /// <returns></returns>
        public int UpdateInfoCount(string srotFlagName, long sortId)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@SortFlagName",srotFlagName),
                new SqlParameter("@SortId",sortId)
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateInfoCount", param);
        }

        #region �����������

        #region �޸����͵�λ��
        /// <summary>
        /// �޸����͵�λ��
        /// </summary>
        /// <param name="ename">ģ������</param>
        /// <param name="pt_id">����Id</param>
        /// <param name="type">�ƶ�����</param>
        /// <returns></returns>
        public static int UpdateOrder(string ename, string pt_id, int type)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ename",ename),
                new SqlParameter("@ID",pt_id),
                new SqlParameter("@type",type)
            };

            return XYECOM.Core.Data.SqlHelper.UspExecuteNoneQuery("[XYP_UpdateOrderid]", param);
        }
        #endregion


        /// <summary>
        /// ��ȡ������Ϣ��Fullid
        /// </summary>
        /// <param name="ename">ģ������</param>
        /// <param name="id">����Id</param>
        /// <returns></returns>
        public static string GetFullid(string ename, string id)
        {
            string fullids = "";

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Ename",ename),
                new SqlParameter("@id",id)
            };

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "usp_SelectGetFullid", param))
            {
                if (reader.Read())
                {
                    fullids = reader["fullid"].ToString();
                }
                return fullids;
            }
        }
        #endregion
    }
}
