using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace XYECOM.Business
{
    /// <summary>
    /// ������Ϣҵ����
    /// </summary>
    public class Attachment
    {
        private static readonly XYECOM.SQLServer.Attachment DAL = new XYECOM.SQLServer.Attachment();
        /// <summary>
        /// ��Ӹ�����Ϣ
        /// </summary>
        /// <param name="ea">ʵ����</param>
        /// <returns>��Ӱ�������</returns>
        public int Insert(XYECOM.Model.AttachmentInfo info, out long At_ID)
        {
            return DAL.Insert(info, out At_ID);
        }

        /// <summary>
        /// �޸ĸ�����Ϣ
        /// </summary>
        /// <param name="ea">ʵ����</param>
        /// <returns>��Ӱ�������</returns>
        public int Update(XYECOM.Model.AttachmentInfo info)
        {
            return DAL.Update(info);
        }
        /// <summary>
        /// �޸��������еĸ�����Ϣ�ڸ�������ӳ��ļ�¼���
        /// </summary>
        /// <param name="At_ID">������Ϣ�ı��</param>
        /// <param name="DescTabID">ԭ���еı�ţ�������ӳ�䣩</param>
        /// <returns>��Ӱ�������</returns>
        public int Update(string At_ID, long DescTabID)
        {
            return DAL.Update(At_ID, DescTabID);
        }

        /// <summary>
        /// ������Ӧ�ı����Ƿ����ͼƬ���ֶ�
        /// ��Ҫ��ɾ������ʱ����
        /// </summary>
        /// <param name="descTabName">��Ϣ���ʶ����</param>
        /// <param name="descTabId">��ϢId</param>
        /// <returns></returns>
        public int UpdateInfoIsHasImage(string descTabName, long descTabId)
        {
            if (string.IsNullOrEmpty(descTabName) || descTabId <= 0) return 0;

            return DAL.UpdateInfoIsHasImage(descTabName, descTabId);
        }

        /// <summary>
        /// ��ȡһ����¼
        /// </summary>
        /// <param name="At_ID">��¼���</param>
        /// <returns>һ����¼</returns>
        public XYECOM.Model.AttachmentInfo GetItem(long At_ID)
        {
            return DAL.GetItem(At_ID);
        }

        /// <summary>
        /// ��ȡ������Ϣ������ͼƬ����
        /// </summary>
        /// <param name="DescTabId">��ϢId</param>
        /// <param name="descTabName">���ʶ����</param>
        /// <returns>������Ϣ����ͼƬ��������</returns>
        public List<Model.AttachmentInfo> GetItems(long descTabId, string descTabName)
        {
            if (descTabId <= 0 || string.IsNullOrEmpty(descTabName)) return new List<XYECOM.Model.AttachmentInfo>();

            return DAL.GetItems(descTabId, descTabName);
        }

        /// <summary>
        /// ��ȡ������ı�ʶ����
        /// </summary>
        /// <returns>������ı�ʾ����</returns>
        public static string GetDescTableName(XYECOM.Model.AttachmentItem item)
        {
            if (item == XYECOM.Model.AttachmentItem.Exhibition) return "i_showinfo";
            if (item == XYECOM.Model.AttachmentItem.Individual) return "u_individual";
            if (item == XYECOM.Model.AttachmentItem.Investment) return "i_invitebusinessmaninfo";
            if (item == XYECOM.Model.AttachmentItem.Venture) return "i_demand";
            if (item == XYECOM.Model.AttachmentItem.News) return "n_news";
            if (item == XYECOM.Model.AttachmentItem.Service) return "i_serviceinfo";
            if (item == XYECOM.Model.AttachmentItem.Supply) return "i_supply";
            if (item == XYECOM.Model.AttachmentItem.Topic) return "xy_topic";
            if (item == XYECOM.Model.AttachmentItem.User) return "u_user";
            if (item == XYECOM.Model.AttachmentItem.Certificate) return "U_Certificate";
            if (item == XYECOM.Model.AttachmentItem.FriendLink) return "b_FriendLink";
            if (item == XYECOM.Model.AttachmentItem.Banner) return "u_banner";
            if (item == XYECOM.Model.AttachmentItem.Logo) return "u_logo";
            if (item == XYECOM.Model.AttachmentItem.PartLabel) return "xy_partlabel";
            if (item == XYECOM.Model.AttachmentItem.BaikeImg) return "baike";
            if (item == XYECOM.Model.AttachmentItem.Gift) return "xy_gift";
            if (item == XYECOM.Model.AttachmentItem.ClassAds) return "XY_ClassAds";
            if (item == XYECOM.Model.AttachmentItem.CustomRanking) return "xy_rankinguserinfo";
            if (item == XYECOM.Model.AttachmentItem.xy_userbrand) return "xy_userbrand";
            if (item == XYECOM.Model.AttachmentItem.XY_Brand) return "xy_brand";
            if (item == XYECOM.Model.AttachmentItem.UserVideo) return "Video";
            if (item == XYECOM.Model.AttachmentItem.Slides) return "Slides";
            if (item == XYECOM.Model.AttachmentItem.TeamBuy) return "TeamBuy";
            return "";
        }

        /// <summary>
        /// ����ģ����Ϣ��ȡģ�鸽���ı�ʶ����
        /// </summary>
        /// <param name="moduleName">ģ������</param>
        /// <returns>ģ�鸽���ı�ʶ����</returns>
        public static string GetDescTabNameByModuleName(string moduleName)
        {
            XYECOM.Configuration.ModuleInfo module = XYECOM.Configuration.Module.Instance.GetItem(moduleName);

            if (module != null)
            {
                if (module.EName.Equals("offer") || module.PEName.Equals("offer"))
                {
                    return "i_supply";
                }

                if (module.EName.Equals("venture") || module.PEName.Equals("venture"))
                {
                    return "i_demand";
                }

                if (module.EName.Equals("investment") || module.PEName.Equals("investment"))
                {
                    return "i_invitebusinessmaninfo";
                }

                if (module.EName.Equals("service") || module.PEName.Equals("service"))
                {
                    return "i_serviceinfo";
                }
            }
            else
            {
                if (moduleName.Equals("certificate")) return "U_Certificate";
            }
            return moduleName;
        }
        /// <summary>
        /// ����Ŀ�����Ʒ��ظ�����Ϣʵ�����
        /// </summary>
        /// <param name="descTabName">Ŀ�������</param>
        /// <returns>������Ϣʵ�����</returns>
        public static XYECOM.Model.AttachmentItem GetAttachmentItem(string descTabName)
        {
            descTabName = descTabName.ToLower();

            if (descTabName.Equals("i_showinfo")) return XYECOM.Model.AttachmentItem.Exhibition;
            if (descTabName.Equals("u_individual")) return XYECOM.Model.AttachmentItem.Individual;
            if (descTabName.Equals("i_invitebusinessmaninfo")) return XYECOM.Model.AttachmentItem.Investment;
            if (descTabName.Equals("i_demand")) return XYECOM.Model.AttachmentItem.Venture;
            if (descTabName.Equals("n_news")) return XYECOM.Model.AttachmentItem.News;
            if (descTabName.Equals("i_serviceinfo")) return XYECOM.Model.AttachmentItem.Service;
            if (descTabName.Equals("i_supply")) return XYECOM.Model.AttachmentItem.Supply;
            if (descTabName.Equals("xy_topic")) return XYECOM.Model.AttachmentItem.Topic;
            if (descTabName.Equals("u_user")) return XYECOM.Model.AttachmentItem.User;
            if (descTabName.Equals("u_certificate")) return XYECOM.Model.AttachmentItem.Certificate;
            if (descTabName.Equals("b_friendlink")) return XYECOM.Model.AttachmentItem.FriendLink;
            if (descTabName.Equals("u_banner")) return XYECOM.Model.AttachmentItem.Banner;
            if (descTabName.Equals("u_logo")) return XYECOM.Model.AttachmentItem.Logo;
            if (descTabName.Equals("xy_partlabel")) return XYECOM.Model.AttachmentItem.PartLabel;
            if (descTabName.Equals("baike")) return XYECOM.Model.AttachmentItem.BaikeImg;
            if (descTabName.Equals("xy_gift")) return XYECOM.Model.AttachmentItem.Gift;
            if (descTabName.Equals("xy_classads")) return XYECOM.Model.AttachmentItem.ClassAds;
            if (descTabName.Equals("xy_rankinguserinfo")) return XYECOM.Model.AttachmentItem.CustomRanking;
            if (descTabName.Equals("xy_userbrand")) return XYECOM.Model.AttachmentItem.xy_userbrand;
            if (descTabName.Equals("xy_brand")) return XYECOM.Model.AttachmentItem.XY_Brand;
            if (descTabName.Equals("video")) return XYECOM.Model.AttachmentItem.UserVideo;
            if (descTabName.Equals("slides")) return XYECOM.Model.AttachmentItem.Slides;
            if (descTabName.Equals("teambuy")) return XYECOM.Model.AttachmentItem.TeamBuy;
            return XYECOM.Model.AttachmentItem.Null;
        }
        /// <summary>
        /// �����ļ����ͷ�����Ӧ���ļ�
        /// </summary>
        /// <param name="fileType">�ļ�����</param>
        /// <returns>��Ӧ���ļ�</returns>
        public string GetFileTypeStr(Model.UploadFileType fileType)
        {
            if (fileType == XYECOM.Model.UploadFileType.File) return "file";

            if (fileType == XYECOM.Model.UploadFileType.Image) return "image";

            return "all";
        }

        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="descTabId">��ϢId</param>
        /// <param name="item">������</param>
        /// <returns>Ӱ������</returns>
        public int Delete(long descTabId, Model.AttachmentItem item, Model.UploadFileType fileType)
        {
            DataTable infos = GetDataTable(descTabId, item, fileType);

            if (infos.Rows.Count <= 0) return 0;
            int result = 0;

            foreach (DataRow row in infos.Rows)
            {
                long atId = Core.MyConvert.GetInt64(row["At_id"].ToString());

                if (atId <= 0) continue;

                result += Delete(atId);
            }

            return result;
        }

        /// <summary>
        /// ɾ��ָ����ϢId�������������и���
        /// </summary>
        /// <param name="descTabIds">��ϢId��,��,�ŷֿ�</param>
        /// <param name="item">������</param>
        /// <param name="filtType">��������</param>
        /// <returns>Ӱ������</returns>
        public int Delete(string descTabIds, Model.AttachmentItem item, Model.UploadFileType fileType)
        {
            string[] idsArr = descTabIds.Split(',');

            long infoId = 0;

            int result = 0;

            foreach (string strInfoId in idsArr)
            {
                infoId = Core.MyConvert.GetInt64(strInfoId);

                if (infoId <= 0) continue;

                result = +Delete(infoId, item, fileType);
            }
            return result;
        }

        /// <summary>
        /// ɾ��һ����¼
        /// </summary>
        /// <param name="A_ID">��¼���</param>
        /// <returns>��Ӱ�������</returns>
        public int Delete(long At_ID)
        {
            XYECOM.Model.AttachmentInfo info = DAL.GetItem(At_ID);
            if (null != info)
            {
                XYECOM.Model.ServerInfo sconfig = new XYECOM.Business.Server().GetItem(info.S_ID);
                if (null != sconfig)
                {
                    DeleteFile(sconfig.S_Path, info.At_Path.Replace("/", @"\\"), info.ThumbnailImg.Replace("/", @"\\"));
                }
            }
            return DAL.Delete(At_ID);
        }

        /// <summary>
        /// ɾ����������
        /// </summary>
        /// <param name="At_IDs">Id����</param>
        /// <returns>Ӱ������</returns>
        public int Delete(string At_IDs)
        {
            //edit by liujia 2008-10-16 ������ɾ����Ϣʱɾ����Ӧ��ͼƬ
            DataTable dt = DAL.GetDataTable(At_IDs);
            foreach (DataRow dr in dt.Rows)
            {
                XYECOM.Model.ServerInfo sconfig = new XYECOM.Business.Server().GetItem(XYECOM.Core.MyConvert.GetInt32(dr["S_ID"].ToString()));
                if (null != sconfig)
                {
                    DeleteFile(sconfig.S_Path, dr["At_Path"].ToString().Replace("/", @"\"), dr["ThumbnailImg"].ToString().Replace("/", @"\"));
                }
            }
            return DAL.Delete(At_IDs);
        }

        /// <summary>
        /// ɾ��������Ч����
        /// </summary>
        /// <returns>Ӱ������</returns>
        public int DeleteAllTemp()
        {
            DataTable dt = DAL.GetAllTemp();

            foreach (DataRow dr in dt.Rows)
            {
                XYECOM.Model.ServerInfo sconfig = new XYECOM.Business.Server().GetItem(XYECOM.Core.MyConvert.GetInt32(dr["S_ID"].ToString()));
                if (null != sconfig)
                {
                    DeleteFile(sconfig.S_Path, dr["At_Path"].ToString().Replace("/", @"\"), dr["ThumbnailImg"].ToString().Replace("/", @"\"));
                }
            }

            return DAL.DeleteAllTemp();
        }
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="spath">�ļ��ڷ������е�·��</param>
        /// <param name="img">�ļ�����</param>
        /// <param name="thumbnailimg">��СͼƬ</param>
        private void DeleteFile(string spath, string img, string thumbnailimg)
        {
            XYECOM.Core.Utils.DeleteFile(spath + img);
            string[] arrfiles = thumbnailimg.Split('|');
            foreach (string ifile in arrfiles)
            {
                if ("" != ifile)
                    XYECOM.Core.Utils.DeleteFile(spath + ifile);
            }
        }

        /// <summary>
        /// ��ȡ������¼
        /// </summary>
        /// <param name="DescTabID">��ϢId</param>
        /// <param name="item">������</param>
        /// <returns>������¼</returns>
        public DataTable GetDataTable(long DescTabID, Model.AttachmentItem item, Model.UploadFileType fileType)
        {
            if (DescTabID <= 0) return new DataTable();

            return DAL.GetDataTable(DescTabID, GetDescTableName(item), GetFileTypeStr(fileType));
        }
        /// <summary>
        /// ����Ŀ������ƺ�Ŀ����ŷ��ظ�����Ϣʵ�����
        /// </summary>
        /// <param name="DescTabName">Ŀ�������</param>
        /// <param name="DescTabID">Ŀ�����</param>
        /// <returns>������Ϣʵ�����</returns>
        public static XYECOM.Model.AttachmentInfo GetTop1Info(string DescTabName, string DescTabID)
        {
            if (DescTabName.Trim().Equals("") || DescTabID.Equals("")) return null;

            return DAL.GetTop1Info(DescTabName, DescTabID);
        }
        /// <summary>
        /// ���ݸ������Ŀ����ŷ��ظ�����Ϣʵ�����
        /// </summary>
        /// <param name="item">������</param>
        /// <param name="descTabID">Ŀ�����</param>
        /// <returns>���ظ�����Ϣʵ�����</returns>
        public static XYECOM.Model.AttachmentInfo GetTop1Info(Model.AttachmentItem item, long descTabID)
        {
            string decsTabName = GetDescTableName(item);

            return GetTop1Info(decsTabName, descTabID.ToString());
        }

        /// <summary>
        /// ��ȡ��Ϣ��Ĭ��ͼƬ��ַ
        /// </summary>
        /// <param name="DescTabName">Ŀ�������</param>
        /// <param name="DescTabID">Ŀ�����</param>
        /// <returns>����Ŀ������ƺ�Ŀ����ŷ�����Ϣ��Ĭ��ͼƬ��ַ</returns>
        public static string GetInfoDefaultImgHref(Model.AttachmentItem item, long descTabID)
        {
            XYECOM.Model.AttachmentInfo info = GetTop1Info(item, descTabID);

            if (info == null) return "/Common/Images/DefaultImg.gif";

            return info.Server.S_URL + info.At_Path;
        }

        /// <summary>
        /// ��ȡ��Ϣ��Ĭ��ͼƬ��ַ
        /// </summary>
        /// <param name="DescTabName">Ŀ�������</param>
        /// <param name="DescTabID">Ŀ�����</param>
        /// <returns>��Ϣ��Ĭ��ͼƬ��ַ</returns>
        public static string GetInfoDefaultImgHref(Model.AttachmentItem item, long descTabID, string defaultImageUrl)
        {
            XYECOM.Model.AttachmentInfo info = GetTop1Info(item, descTabID);

            if (info == null) return defaultImageUrl;

            return info.Server.S_URL + info.At_Path;
        }

        public static Model.AttachmentInfo GetItemInfoOfVideo(int userid)
        {
            return DAL.GetItemInfoOfVideo(userid);
        }
    }
}
