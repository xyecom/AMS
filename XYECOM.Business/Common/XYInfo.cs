using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace XYECOM.Business
{
    public class XYInfo
    {
        private static readonly XYECOM.SQLServer.XYInfo DAL = new XYECOM.SQLServer.XYInfo();

        /// <summary>
        /// ˢ����Ϣ
        /// </summary>
        /// <param name="infoType">��Ϣ����</param>
        /// <param name="moduleName">ģ������</param>
        /// <param name="userId">�û�Id</param>
        /// <param name="infoId">��ϢId</param>
        /// <returns></returns>
        public static string RefreshInfo(XYECOM.Model.InfoType infoType, string moduleName, long userId, long infoId)
        {
            if (userId <= 0 || infoId <= 0 || moduleName.Equals(""))
                return "ˢ��ʧ�ܣ�������ˢ�£�";

            return DAL.RefreshInfo(infoType,moduleName,userId,infoId,XYECOM.Configuration.WebInfo.Instance.RefreshInfoAddWebMoney);
        }

        /// <summary>
        /// ��ȡ�����Ϣ
        /// </summary>
        /// <param name="moudleName"></param>
        /// <param name="userId"></param>
        /// <param name="topNumber"></param>
        /// <returns></returns>
        public static DataTable GetAboutInfo(string moduleName, long userId, int topNumber,long curInfoId)
        {
            XYECOM.Configuration.ModuleInfo module = XYECOM.Configuration.Module.Instance.GetItem(moduleName);

            XYECOM.Model.XYClassTableInfo tableInfo = XYClass.GetTableInfo(moduleName);

            if (module == null || tableInfo == null) return new DataTable();

            System.Data.DataTable table = DAL.GetAboutInfo(tableInfo, module, userId, topNumber, curInfoId);

            if (table == null || table.Rows.Count <= 0) return new DataTable();

            XYECOM.Model.AttachmentItem attItem = XYECOM.Model.AttachmentItem.Supply;

            if (module.EName.Equals("offer") || module.PEName.Equals("offer"))
            {
                attItem =  XYECOM.Model.AttachmentItem.Supply;
            }

            if (module.EName.Equals("venture") || module.PEName.Equals("venture"))
            {
                attItem= XYECOM.Model.AttachmentItem.Venture;
            }

            if (module.EName.Equals("investment") || module.PEName.Equals("investment"))
            {
                attItem = XYECOM.Model.AttachmentItem.Investment;
            }

            if (module.EName.Equals("service") || module.PEName.Equals("service"))
            {
                attItem =  XYECOM.Model.AttachmentItem.Service;
            }


            table.Columns.Add("image");
            table.Columns.Add("link");

            foreach (DataRow row in table.Rows)
            {
                row["image"] = GetAboutInfoImagePath(attItem, Core.MyConvert.GetInt64(row["infoId"].ToString()));
                if(row["htmlPage"].ToString().Equals(""))
                    row["link"] = GetAboutInfoLink(moduleName, row["infoId"].ToString());
                else
                    row["link"] = XYECOM.Configuration.WebInfo.Instance.WebDomain + row["HtmlPage"].ToString();
            }

            return table;
        }

        private static string GetAboutInfoLink(string moduleName,string infoId)
        {
            if (XYECOM.Configuration.WebInfo.Instance.IsBogusStatic)
            {
                return XYECOM.Configuration.WebInfo.Instance.WebDomain + "search/sell-"+moduleName + "-" + infoId + "."+ XYECOM.Configuration.WebInfo.Instance.WebSuffix;
            }
            else
            {
                return XYECOM.Configuration.WebInfo.Instance.WebDomain + "/search/sell." + XYECOM.Configuration.WebInfo.Instance.WebSuffix + "?flag=" + moduleName + "&infoid=" + infoId;
            }
        }

        private static string GetAboutInfoImagePath(Model.AttachmentItem item, long infoId)
        {
            return Business.Attachment.GetInfoDefaultImgHref(item, infoId);
        }

        //private static string CreateAboutHTML(System.Data.DataTable table,string moduleName,string idFieldName,string titleFileName,Model.AttachmentItem item)
        //{
        //    StringBuilder strAbout = new StringBuilder("");

        //    XYECOM.Configuration.WebInfo webInfo = XYECOM.Configuration.WebInfo.Instance;

        //    string infoImgHref = "";

        //    strAbout.Append("<ul>");
        //    foreach (System.Data.DataRow row in table.Rows)
        //    {
        //        infoImgHref = Business.Attachment.GetInfoDefaultImgHref(item, Core.MyConvert.GetInt64(row[idFieldName].ToString()));

        //        if (XYECOM.Configuration.WebInfo.Instance.IsBogusStatic)
        //        {
        //            strAbout.Append("<li>");
        //            strAbout.Append("<a href='/search/sell-").Append(moduleName).Append("-").Append(row[idFieldName] + "." + webInfo.WebSuffix).Append("' target='_blank' title='" + row[titleFileName].ToString() + "'>");
        //            strAbout.Append("<img src='").Append(infoImgHref).Append("' />");
        //            strAbout.Append("</a><br />");
        //            strAbout.Append("<a href='/search/sell-").Append(moduleName).Append("-").Append(row[idFieldName] + "." + webInfo.WebSuffix).Append("' target='_blank' title='" + row[titleFileName].ToString() + "'>");
        //            strAbout.Append(XYECOM.Core.Utils.IsLength(12, row[titleFileName].ToString()));
        //            strAbout.Append("</a>");
        //            strAbout.Append("</li>");
        //        }
        //        else
        //        {
        //            strAbout.Append("<li>");
        //            strAbout.Append("<a href='/search/sell." + webInfo.WebSuffix + "?flag=").Append(moduleName).Append("&infoid=").Append(row[idFieldName]).Append("' target='_blank' title='" + row[titleFileName].ToString() + "'>");
        //            strAbout.Append("<img src='").Append(infoImgHref).Append("' />");
        //            strAbout.Append("</a><br />");
        //            strAbout.Append("<a href='/search/sell." + webInfo.WebSuffix + "?flag=").Append(moduleName).Append("&infoid=").Append(row[idFieldName]).Append("' target='_blank' title='" + row[titleFileName].ToString() + "'>");
        //            strAbout.Append(XYECOM.Core.Utils.IsLength(12, row[titleFileName].ToString()));
        //            strAbout.Append("</a>");
        //            strAbout.Append("</li>");
        //        }
        //    }
        //    strAbout.Append("</ul>");

        //    return strAbout.ToString();
        //}

        #region ������Ϣ�������
        /// <summary>
        /// ������Ϣ�������
        /// </summary>
        /// <param name="infoId">��ϢId</param>
        /// <param name="moduleName">ģ������</param>
        /// <returns></returns>
        public static int UpdateBrowseCount(string infoId, string moduleName)
        {
            if (moduleName.Equals("company"))return XYECOM.Core.Function.Updateinfo(" where U_ID=" + infoId, "u_User", "U_ClickNum");

            if (moduleName == "investment") return XYECOM.Core.Function.Updateinfo(" where IBI_ID=" + infoId, "i_InviteBusinessmanInfo", "IBI_ClickNum");

            if (moduleName == "offer") return XYECOM.Core.Function.Updateinfo(" where SD_ID=" + infoId, "i_Supply", "SD_ClickNum");

            if (moduleName == "venture") return XYECOM.Core.Function.Updateinfo(" where SD_ID=" + infoId, "i_Demand", "SD_ClickNum");

            if (moduleName == "service") return XYECOM.Core.Function.Updateinfo(" where S_ID=" + infoId, "i_ServiceInfo", "S_ClickNum");

            if (moduleName == "job") return XYECOM.Core.Function.Updateinfo(" where EI_ID=" + infoId, "i_engageinfo", "EI_ClickNum");

            return 0;
        }
        #endregion


        /// <summary>
        /// �ؼ�����������ʹ��
        /// ͨ���ؼ����Զ�ƥ����Ϣ
        /// </summary>
        /// <param name="keyword">�ؼ���</param>
        /// <param name="moduleName">ģ������</param>
        /// <param name="parentModuleName">��ģ������</param>
        /// <param name="userId">�û�Id</param>
        /// <param name="sellFlags">��������Ϣ��ʶId</param>
        /// <returns></returns>
        public static DataTable AutomatchInfoByKeyword(string keyword, string moduleName, string parentModuleName, long userId, string sellFlags)
        {
            if (string.IsNullOrEmpty(keyword) 
                || keyword.Equals("")
                || userId <= 0
                || string.IsNullOrEmpty(moduleName)
                || string.IsNullOrEmpty(sellFlags))

                return new DataTable();

            if (string.IsNullOrEmpty(parentModuleName)) parentModuleName = moduleName;

            return DAL.AutomatchInfoByKeyword(keyword,moduleName,parentModuleName,userId,sellFlags);
        }

        /// <summary>
        /// ��ȡָ��Id����Ϣ
        /// ������Ϣ�ֶΣ�infoId,infoTitle��
        /// </summary>
        /// <param name="moduleName">ģ������</param>
        /// <param name="infoId">��ϢId</param>
        /// <returns></returns>
        public static DataTable GetDataById(string moduleName, long infoId)
        {
            XYECOM.Configuration.ModuleInfo module = XYECOM.Configuration.Module.Instance.GetItem(moduleName);

            XYECOM.Model.XYClassTableInfo tableInfo = XYClass.GetTableInfo(moduleName);

            if (module == null || tableInfo == null) return new DataTable();

            return DAL.GetDataById(tableInfo, module, infoId);
        }

        /// <summary>
        /// ��ȡָ��ģ����ָ����������Ϣ
        /// �������������ʹ��
        /// </summary>
        /// <param name="moduleName">ģ������</param>
        /// <param name="userId">�û�Id</param>
        /// <param name="topNumber">��������</param>
        /// <param name="infoTypeFlag">��Ϣ���ͱ�ʶ(sell/buy)</param>
        /// <returns></returns>
        public static DataTable GetDataByModuleAndUserId(string moduleName, long userId, int topNumber,string infoTypeFlag)
        {
            XYECOM.Configuration.ModuleInfo module = XYECOM.Configuration.Module.Instance.GetItem(moduleName);

            XYECOM.Model.XYClassTableInfo tableInfo = XYClass.GetTableInfo(moduleName);

            if (module == null || tableInfo == null) return new DataTable();

            string falgIds ="";

            if (!infoTypeFlag.Trim().Equals(""))
            {
                falgIds = module.SellIDs;
                if (infoTypeFlag.Equals("buy")) falgIds = module.BuyIDs;
            }

            return DAL.GetDataByModuleAndUserId(tableInfo, module, userId, topNumber, falgIds);
        }
        /// <summary>
        /// ��ȡ�û���������
        /// </summary>
        /// <param name="moduleName">ģ������</param>
        /// <param name="recordNumber"></param>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public static DataTable GetUserLastData(string moduleName, long userId, int isCommend)
        {
            if (string.IsNullOrEmpty(moduleName) || userId <= 0) return new DataTable();

            return DAL.GetUserLastData(moduleName, userId, isCommend);
        }
    }
}
