using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Text;
using XYECOM.Model;

namespace XYECOM.Business
{
    /// <summary>
    /// �������ݴ���ͨ��ҵ����
    /// </summary>
    public class XYClass
    {
        private static readonly XYECOM.SQLServer.XYClass DAL = new XYECOM.SQLServer.XYClass();

        /// <summary>
        /// ��ȡ���༯��
        /// </summary>
        /// <param name="moduleName">ģ������</param>
        /// <param name="parentID">����Id</param>
        /// <returns></returns>
        public static List<XYClassInfo> GetSubItems(string moduleName, long parentID)
        {
            return GetSubItems(moduleName, parentID, string.Empty);
        }

        #region �Զ��������ȡ
        /// <summary>
        /// �Զ��������ȡ
        /// </summary>
        /// <param name="moduleName"></param>
        /// <param name="parentID"></param>
        /// <param name="customParams"></param>
        /// <returns></returns>
        public static List<XYClassInfo> GetSubItems(string moduleName, long parentID, string customParams)
        {
            XYClassTableInfo tableInfo = GetTableInfo(moduleName);

            if (null == tableInfo) return null;

            List<XYClassInfo> arr = new List<XYClassInfo>();

            if (tableInfo.ModuleFieldName.Equals(""))
            {
                arr = new XYECOM.SQLServer.XYClass().GetCustomParamsItems(tableInfo, parentID, customParams);
            }
            else
            {
                arr = new XYECOM.SQLServer.XYClass().GetCustomParamsItems(tableInfo, parentID, moduleName, customParams);
            }

            return arr;
        }


        #endregion

        /// <summary>
        /// ����id��ȡ�ö�������Ϣ
        /// </summary>
        /// <param name="moduleName"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        public static List<XYClassInfo> GetSubItems(string moduleName, string ids)
        {
            XYClassTableInfo tableInfo = GetTableInfo(moduleName);

            if (null == tableInfo) return null;

            return DAL.GetItems(tableInfo, ids);
        }

        /// <summary>
        /// ��ȡָ��ģ���µ����з���
        /// </summary>
        /// <param name="moduleName">ģ������</param>
        /// <returns></returns>
        public static List<XYClassInfo> GetItemsAll(string moduleName)
        {
            XYClassTableInfo tableInfo = GetTableInfo(moduleName);

            DataTable dt = null;
            if (tableInfo.ModuleFieldName.Equals(""))
                dt = DAL.GetItemsAll(tableInfo);
            else
                dt = DAL.GetItemsAll(tableInfo, moduleName);

            List<XYClassInfo> infolist = new List<XYClassInfo>();

            foreach (DataRow dr in dt.Select(tableInfo.ParentIdFieldName + " = 0"))
            {
                infolist.Add(GetInfo(tableInfo, dt, dr));
            }
            return infolist;
        }

        private static XYClassInfo GetInfo(Model.XYClassTableInfo tableInfo, DataTable dt, DataRow dr)
        {
            XYClassInfo info = new XYClassInfo();
            info.ClassId = Core.MyConvert.GetInt64(dr[0].ToString());
            info.ClassName = dr[1].ToString();
            info.HasSub = dt.Select(tableInfo.ParentIdFieldName + " = " + info.ClassId).Length > 0;
            if (info.HasSub)
            {
                foreach (DataRow dr2 in dt.Select(tableInfo.ParentIdFieldName + " = " + info.ClassId))
                {
                    info.childList.Add(GetInfo(tableInfo, dt, dr2));
                }
            }
            return info;
        }

        #region ��ȡ������Ϣ
        /// <summary>
        /// ��ȡ������Ϣ
        /// </summary>
        /// <param name="moduleName">ģ������</param>
        /// <param name="className">��������</param>
        /// <returns></returns>
        public static XYClassInfo GetItem(string moduleName, string className)
        {
            moduleName = moduleName.Trim();
            className = className.Trim();

            if (moduleName.Equals("") || className.Equals("")) return null;

            XYClassTableInfo tableInfo = GetTableInfo(moduleName);

            if (tableInfo == null) return null;

            XYClassInfo info = DAL.GetItem(tableInfo, className);

            return info;
        }

        /// <summary>
        /// ��ȡ������Ϣ
        /// </summary>
        /// <param name="moduleName">ģ������</param>
        /// <param name="classid">����Id</param>
        /// <returns></returns>
        public static XYClassInfo GetItem(string moduleName, Int64 classid)
        {
            moduleName = moduleName.Trim();

            if (moduleName.Equals("") || classid <= 0) return null;

            XYClassTableInfo tableInfo = GetTableInfo(moduleName);

            if (tableInfo == null) return null;

            XYClassInfo info = DAL.GetItem(tableInfo, classid);

            return info;
        }
        #endregion

        #region  ͨ��ģ�����ƺͷ���ID��ȡ���༯��
        /// <summary>
        /// ͨ��ģ�����ƺͷ���ID��ȡ���༯��  
        /// </summary>
        /// <param name="moduleName">ģ������</param>
        /// <param name="typeID">����ID</param>
        /// <param name="num">������Ϣ��Ŀ��</param>
        /// <returns></returns>
        public static List<Model.XYClassInfo> GetTypeByModuleNameAndTypeID(String moduleName, XYECOM.Configuration.InfoType infoType, int typeID, string areaID, string times, string keyWord)
        {
            XYECOM.Model.XYClassTableInfo tableInfo = Business.XYClass.GetTableInfo(moduleName);

            List<Model.XYClassInfo> infos = null;

            if (tableInfo.ModuleFieldName.Equals(""))
                infos = DAL.GetItems(tableInfo, typeID);
            else
                infos = DAL.GetItems(tableInfo, typeID, moduleName);

            string begin = "";
            string end = "";
            string strkey1 = keyWord;
            string strkey2 = "";
            if (keyWord.IndexOf(",") == 0)
            {
                strkey1 = strkey1.Replace(",", "");
            }
            else if (keyWord.IndexOf(",") > 0)
            {
                string[] tmparr = keyWord.Split(',');
                strkey1 = tmparr[0];
                strkey2 = tmparr[1];
            }
            if (times != "0" && times != "" && XYECOM.Core.Utils.IsNumber(times))
            {
                switch (times)
                {
                    case "1":
                        begin = DateTime.Now.ToShortDateString();
                        end = DateTime.Now.AddDays(1).ToShortDateString();
                        break;
                    case "3":
                        begin = DateTime.Now.AddDays(-3).ToShortDateString();
                        end = DateTime.Now.AddDays(1).ToShortDateString();
                        break;
                    case "7":
                        begin = DateTime.Now.AddDays(-7).ToShortDateString();
                        end = DateTime.Now.AddDays(1).ToShortDateString();
                        break;
                    case "15":
                        begin = DateTime.Now.AddDays(-15).ToShortDateString();
                        end = DateTime.Now.AddDays(1).ToShortDateString();
                        break;
                    case "30":
                        begin = DateTime.Now.AddDays(-30).ToShortDateString();
                        end = DateTime.Now.AddDays(1).ToShortDateString();
                        break;
                }
            }
            //����1���޸ĵ��������߼�����ȡ���������࣬��in��
            //if (areaID != "0" && areaID != "" && XYECOM.Core.Utils.IsNumber(areaID))
            //{
            //    areaIDList = new XYECOM.Business.Area().GetSubIds(XYECOM.Core.MyConvert.GetInt32(areaID));
            //}
            //����2���滻���������߼�����ȡ���������࣬��in��
            //foreach (Model.XYClassInfo info in infos)
            //{
            //    info.InfoNum = DAL.GetInfoNum(tableInfo, GetSubIds(moduleName, info.ClassId), moduleName, infoType, areaIDList, begin, end, strkey1, strkey2);
            //}

            foreach (Model.XYClassInfo info in infos)
            {
                info.InfoNum = DAL.GetInfoNum(tableInfo, info.ClassId.ToString(), moduleName, infoType, areaID, begin, end, strkey1, strkey2);
            }
            return infos;
        }
        #endregion

        #region ��ȡ�����Ӽ�ID
        /// <summary>
        /// ��ȡ�����Ӽ�ID
        /// </summary>
        /// <param name="moduleName">ģ������</param>
        /// <param name="parentID">���ID</param>
        /// <returns></returns>
        public static string GetSubIds(string moduleName, long parentID)
        {
            string ids = parentID.ToString();
            Model.XYClassTableInfo tableInfo = GetTableInfo(moduleName);

            List<Model.XYClassInfo> infos = null;

            if (tableInfo.ModuleFieldName.Equals(""))
                infos = DAL.GetItems(tableInfo, parentID);
            else
                infos = DAL.GetItems(tableInfo, parentID, moduleName);

            foreach (Model.XYClassInfo info in infos)
            {
                ids += "," + info.ClassId;

                if (IsHasSubClass(moduleName, info.ClassId))
                    ids += "," + GetSubIds(moduleName, info.ClassId);
            }

            if (ids.Length > 0)
            {
                string[] cols = Core.Utils.RepaceSpilthItem(ids.Split(','));

                return Core.Utils.ArrayToString(cols);
            }

            return ids;
        }

        /// <summary>
        /// ��ȡ�����Ӽ�ID
        /// </summary>
        /// <param name="moduleName">ģ������</param>
        /// <param name="parentIds">��Id���ϣ���,�Ÿ���</param>
        /// <returns></returns>
        public static string GetSubIds(string moduleName, string parentIds)
        {
            if (parentIds.Trim().Equals("")) return "";

            string[] ids = parentIds.Split(',');

            string strIds = "";

            foreach (string id in ids)
            {
                long _id = Core.MyConvert.GetInt64(id);

                if (_id <= 0) continue;

                strIds += GetSubIds(moduleName, _id);
            }

            return strIds;
        }
        #endregion

        #region ��ȡ���и�����Ϣ
        /// <summary>
        /// ��ȡ���и��༯��
        /// </summary>
        /// <param name="moduleName">ģ������</param>
        /// <param name="childId">����Id</param>
        /// <returns></returns>
        public static List<Model.XYClassInfo> GetParentClassInfos(string moduleName, long childId)
        {
            List<Model.XYClassInfo> infos = new List<XYClassInfo>();

            Model.XYClassTableInfo tableInfo = GetTableInfo(moduleName);

            //��ȡ��ǰ������Ϣ
            Model.XYClassInfo curClassInfo = null;

            if (tableInfo.ModuleFieldName.Equals(""))
                curClassInfo = DAL.GetItem(tableInfo, childId);
            else
                curClassInfo = DAL.GetItem(tableInfo, childId, moduleName);

            if (curClassInfo == null) return infos;
            infos.Add(curClassInfo);

            if (curClassInfo.ParentId != 0)
            {
                infos.AddRange(GetParentClassInfos(moduleName, curClassInfo.ParentId));
            }

            return infos;
        }
        #endregion

        #region ��ȡ�������Ķ���
        /// <summary>
        /// ��ȡ�������Ķ���
        /// </summary>
        /// <param name="moduleName"></param>
        /// <param name="childId"></param>
        /// <returns></returns>
        public static Model.XYClassInfo GetTopClassInfo(string moduleName, long childId)
        {
            Model.XYClassTableInfo tableInfo = GetTableInfo(moduleName);

            //��ȡ��ǰ������Ϣ
            Model.XYClassInfo curClassInfo = null;

            if (tableInfo.ModuleFieldName.Equals(""))
                curClassInfo = DAL.GetItem(tableInfo, childId);
            else
                curClassInfo = DAL.GetItem(tableInfo, childId, moduleName);

            if (curClassInfo == null) return curClassInfo;

            if (curClassInfo.ParentId != 0)
            {
                curClassInfo = GetTopClassInfo(moduleName, curClassInfo.ParentId);
            }

            return curClassInfo;
        }
        #endregion


        #region �жϵ�ǰģ�����Ƿ��Ѿ��з�����Ϣ����
        /// <summary>
        /// �жϵ�ǰģ�����Ƿ��Ѿ��з�����Ϣ����
        /// </summary>
        /// <param name="moduleName">ģ������</param>
        /// <param name="typeId">����Id</param>
        /// <returns></returns>
        public static bool IsHasSubClass(string moduleName, long typeId)
        {
            XYClassTableInfo tableInfo = GetTableInfo(moduleName);

            if (tableInfo == null) return false;

            return DAL.IsHasSubClass(tableInfo, typeId, moduleName);
        }
        #endregion

        #region ����ģ���ȡ XYClassTableInfo����
        /// <summary>
        /// ��ȡ�������Ϣ
        /// </summary>
        /// <param name="moduleName">ģ������</param>
        /// <returns></returns>
        public static Model.XYClassTableInfo GetTableInfo(string moduleName)
        {
            XYECOM.Configuration.ModuleInfo moduleInfo = XYECOM.Configuration.Module.Instance.GetItem(moduleName);

            XYClassTableInfo clsTableInfo = null;

            if (moduleInfo != null)
            {
                if ("offer".Equals(moduleInfo.EName) || ("offer").Equals(moduleInfo.PEName))
                {
                    clsTableInfo = new XYClassTableInfo("��Ʒ����", "b_ProductType", "PT_ID", "PT_Name", "PT_ParentID", "ModuleName", 1, "offer", "XYV_Supply", "PT_ID", "SD_Title", "SD_PublishDate", "SD_IsSupply", "SD_EndDate");
                    clsTableInfo.InfoTableFlagFieldName = "SD_Flag";
                }

                if ("investment".Equals(moduleInfo.EName) || "investment".Equals(moduleInfo.PEName))
                {
                    clsTableInfo = new XYClassTableInfo("������Ϣ����", "i_InviteBusinessType", "IT_ID", "IT_Name", "IT_ParentID", "ModuleName", 3, "investment", "XYV_InviteBusinessmanInfo", "IT_ID", "IBI_Title", "IBI_PublishDate", "IBI_Pause", "IBI_EndTime");
                    clsTableInfo.InfoTableFlagFieldName = "IBI_Sign";
                }

                if ("service".Equals(moduleInfo.EName) || "service".Equals(moduleInfo.PEName))
                {
                    clsTableInfo = new XYClassTableInfo("������Ϣ����", "i_ServiceType", "ST_ID", "ST_Name", "ST_ParentID", "ModuleName", 4, "service", "XYV_ServiceInfo", "ST_ID", "S_Title", "S_AddTime", "S_Pause", "S_EndTime");
                    clsTableInfo.InfoTableFlagFieldName = "S_Flag";
                }

                if ("venture".Equals(moduleInfo.EName.ToLower()))
                {
                    clsTableInfo = new XYClassTableInfo("����/Ͷ�ʷ���", "XY_VentureType", "Id", "TypeName", "ParentID", "", 0, "venturetype");
                }                
            }
            else
            {
                if ("exhibition".Equals(moduleName))
                {
                    clsTableInfo = new XYClassTableInfo("չ����Ϣ����", "i_showType", "SHT_ID", "SHT_Name", "SHT_ParentID", "", 0, "exhibition", "XYV_ShowInfo", "TypeId", "InfoTitle", "AddInfoTime", "", "EndTime");
                }

                if ("news".Equals(moduleName))
                {
                    clsTableInfo = new XYClassTableInfo("��Ѷ��Ϣ����", "n_NewsTitleInfo", "NT_ID", "NT_Name", "NT_PID", "", 0, "news", "XYV_News", "", "NT_ID", "NS_NewsName", "", "");
                }

                if ("job".Equals(moduleName))
                {
                    clsTableInfo = new XYClassTableInfo("��λ��Ϣ����", "b_post", "P_ID", "p_Name", "p_ParentID", "", 0, "job", "XYV_Engageinfo", "P_ID", "EI_Job", "EI_AddDate");
                }

                if ("company".Equals(moduleName))
                {
                    clsTableInfo = new XYClassTableInfo("��ҵ��Ϣ����", "b_userType", "ut_ID", "ut_type", "ut_PID", "", 0, "company", "XYV_UserInfo", "UT_ID", "UI_Name", "U_RegDate");
                }
                if ("area".Equals(moduleName.ToLower()))
                {
                    clsTableInfo = new XYClassTableInfo("��������", "xy_area", "ID", "Name", "ParentID", "", 0, "area");
                }

                if ("trade".Equals(moduleName.ToLower()))
                {
                    clsTableInfo = new XYClassTableInfo("��ҵ����", "xy_trade", "ID", "TradeName", "ParentId", "", 0, "trade");
                }

                if ("baike".Equals(moduleName.ToLower()))
                {
                    clsTableInfo = new XYClassTableInfo("�ٿƷ���", "XY_LemmaCategory", "CategoryId", "CategoryName", "ParentID", "", 0, "baike");
                }

                if ("companytype".Equals(moduleName.ToLower()))
                {
                    clsTableInfo = new XYClassTableInfo("��ҵ�Զ����Ʒ����", "XY_CompanyProductType", "Id", "PtName", "ParentID", "", 0, "companytype");
                }

                if ("usertitleinfo".Equals(moduleName.ToLower()))
                {
                    clsTableInfo = new XYClassTableInfo("�û���Ѷ����", "XY_UserNewsTitleInfo", "Id", "Name", "ParentID", "", 0, "usertitleinfo");
                }

                if ("venture".Equals(moduleName.ToLower()))
                {
                    clsTableInfo = new XYClassTableInfo("����/Ͷ�ʷ���", "XY_VentureType", "Id", "TypeName", "ParentID", "", 0, "venturetype");
                }
            }

            return clsTableInfo;
        }
        #endregion

        #region ���¶�������
        /// <summary>
        /// ���¶�������
        /// </summary>
        /// <param name="tablename">����</param>
        /// <param name="flagid">Ҫ���µ��ֶ�����</param>
        /// <param name="infoid">��Ϣ�ֶ�����</param>
        /// <param name="oldnum">Ҫ�����µķ���ID</param>
        /// <param name="newnum">���õ��·���ID</param>
        /// <returns></returns>
        public int UpdatesByID(String tablename, String flagid, String infoid, String oldnum, String newnum)
        {
            return DAL.UpdatesByID(tablename, flagid, infoid, oldnum, newnum);
        }
        #endregion

        #region  ��ȡ��������Ϣ������Ŀ��
        /// <summary>
        /// ��ȡ��������Ϣ������Ŀ��
        /// </summary>
        /// <param name="tablename">��Ϣ����</param>
        /// <param name="fieldname">��Ϣ��������ֶ�����</param>
        /// <param name="ids">����ID</param>
        /// <returns></returns>
        public int InfoNum(String tablename, String fieldname, String ids)
        {
            return DAL.InfoNum(tablename, fieldname, ids);
        }
        #endregion

        #region ���·����²�Ʒ����Ϣ�������

        /// <summary>
        /// ����ĳһ��ȫ��
        /// </summary>
        /// <param name="sortType"></param>
        /// <returns></returns>
        public static int UpdateInfoCount(Model.SortType sortType)
        {
            string sortFlagName = GetSortFlagName(sortType);

            if (sortType.Equals("")) return 0;

            return DAL.UpdateInfoCount(sortFlagName, 0);
        }

        /// <summary>
        /// ����ĳһ����ָ��Id�ķ���
        /// </summary>
        /// <param name="sortType"></param>
        /// <param name="sortId"></param>
        /// <returns></returns>
        public static int UpdateInfoCount(Model.SortType sortType, long sortId)
        {
            string sortFlagName = GetSortFlagName(sortType);

            if (sortType.Equals("")) return 0;

            if (sortId <= 0) return 0;

            return DAL.UpdateInfoCount(sortFlagName, sortId);
        }

        /// <summary>
        /// ��ȡ�����ʶ��
        /// </summary>
        /// <param name="sortType"></param>
        /// <returns></returns>
        private static string GetSortFlagName(Model.SortType sortType)
        {
            if (sortType == SortType.Offer) return "offer";

            if (sortType == SortType.Service) return "service";

            if (sortType == SortType.Venture) return "venture";

            if (sortType == SortType.Job) return "job";

            if (sortType == SortType.Investment) return "investment";

            if (sortType == SortType.Exhibition) return "exhibition";

            if (sortType == SortType.Company) return "company";

            if (sortType == SortType.Brand) return "brand";

            return "";
        }
        #endregion

        /// <summary>
        /// �޸�����λ��
        /// </summary>
        /// <param name="pt_id"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static int UpdateOrder(string ename, string id, int type)
        {
            if (string.IsNullOrEmpty(id))
                return -1;
            return XYECOM.SQLServer.XYClass.UpdateOrder(ename, id, type);
        }

        /// <summary>
        /// ��ȡ����Id
        /// </summary>
        /// <param name="ename"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetFullid(string ename, string id)
        {
            if (string.IsNullOrEmpty(ename))
                return "";
            return XYECOM.SQLServer.XYClass.GetFullid(ename, id);
        }

        /// <summary>
        /// �����û�ID��ȡ��Ŀ
        /// </summary>
        /// <param name="ename"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<XYClassInfo> GetSubItemsbyUserId(string moduleName, long parentID, string UserId)
        {
            return GetSubItems(moduleName, parentID, UserId);
        }
    }
}
