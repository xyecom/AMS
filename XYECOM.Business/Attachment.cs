using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace XYECOM.Business
{
    /// <summary>
    /// 附件信息业务类
    /// </summary>
    public class Attachment
    {
        private static readonly XYECOM.SQLServer.Attachment DAL = new XYECOM.SQLServer.Attachment();
        /// <summary>
        /// 添加附件信息
        /// </summary>
        /// <param name="ea">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Insert(XYECOM.Model.AttachmentInfo info, out long At_ID)
        {
            return DAL.Insert(info, out At_ID);
        }

        /// <summary>
        /// 修改附件信息
        /// </summary>
        /// <param name="ea">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Update(XYECOM.Model.AttachmentInfo info)
        {
            return DAL.Update(info);
        }
        /// <summary>
        /// 修改其他表中的附加信息在附件表中映射的纪录编号
        /// </summary>
        /// <param name="At_ID">附件信息的编号</param>
        /// <param name="DescTabID">原表中的编号（用于做映射）</param>
        /// <returns>受影响的行数</returns>
        public int Update(string At_ID, long DescTabID)
        {
            return DAL.Update(At_ID, DescTabID);
        }

        /// <summary>
        /// 更新相应的表中是否包含图片的字段
        /// 主要在删除附件时调用
        /// </summary>
        /// <param name="descTabName">信息表标识名称</param>
        /// <param name="descTabId">信息Id</param>
        /// <returns></returns>
        public int UpdateInfoIsHasImage(string descTabName, long descTabId)
        {
            if (string.IsNullOrEmpty(descTabName) || descTabId <= 0) return 0;

            return DAL.UpdateInfoIsHasImage(descTabName, descTabId);
        }

        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="At_ID">记录编号</param>
        /// <returns>一条记录</returns>
        public XYECOM.Model.AttachmentInfo GetItem(long At_ID)
        {
            return DAL.GetItem(At_ID);
        }

        /// <summary>
        /// 获取多条信息的所有图片附件
        /// </summary>
        /// <param name="DescTabId">信息Id</param>
        /// <param name="descTabName">表标识名称</param>
        /// <returns>多条信息所有图片附件集合</returns>
        public List<Model.AttachmentInfo> GetItems(long descTabId, string descTabName)
        {
            if (descTabId <= 0 || string.IsNullOrEmpty(descTabName)) return new List<XYECOM.Model.AttachmentInfo>();

            return DAL.GetItems(descTabId, descTabName);
        }

        /// <summary>
        /// 获取附件表的标识名称
        /// </summary>
        /// <returns>附件表的表示名称</returns>
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
            if (item == XYECOM.Model.AttachmentItem.ForeclosedInfo) return "ForeclosedInfo";
            if (item == XYECOM.Model.AttachmentItem.CreditInfo) return "CreditInfo";

            return "";
        }

        /// <summary>
        /// 根据模块信息获取模块附件的标识名称
        /// </summary>
        /// <param name="moduleName">模块名称</param>
        /// <returns>模块附件的标识名称</returns>
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
        /// 根据目标名称返回附件信息实体对象
        /// </summary>
        /// <param name="descTabName">目标表名称</param>
        /// <returns>附件信息实体对象</returns>
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
            if (descTabName.Equals("foreclosedinfo")) return XYECOM.Model.AttachmentItem.ForeclosedInfo;
            if (descTabName.Equals("creditinfo")) return XYECOM.Model.AttachmentItem.CreditInfo;
            return XYECOM.Model.AttachmentItem.Null;
        }
        /// <summary>
        /// 根据文件类型返回相应的文件
        /// </summary>
        /// <param name="fileType">文件类型</param>
        /// <returns>相应的文件</returns>
        public string GetFileTypeStr(Model.UploadFileType fileType)
        {
            if (fileType == XYECOM.Model.UploadFileType.File) return "file";

            if (fileType == XYECOM.Model.UploadFileType.Image) return "image";

            return "all";
        }

        /// <summary>
        /// 删除附件
        /// </summary>
        /// <param name="descTabId">信息Id</param>
        /// <param name="item">附件项</param>
        /// <returns>影响行数</returns>
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
        /// 删除指定信息Id集合所属的所有附件
        /// </summary>
        /// <param name="descTabIds">信息Id集,以,号分开</param>
        /// <param name="item">附件项</param>
        /// <param name="filtType">附件类型</param>
        /// <returns>影响行数</returns>
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
        /// 删除一条记录
        /// </summary>
        /// <param name="A_ID">记录编号</param>
        /// <returns>受影响的行数</returns>
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
        /// 删除多条数据
        /// </summary>
        /// <param name="At_IDs">Id集合</param>
        /// <returns>影响行数</returns>
        public int Delete(string At_IDs)
        {
            //edit by liujia 2008-10-16 增加了删除信息时删除对应的图片
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
        /// 删除所有无效数据
        /// </summary>
        /// <returns>影响行数</returns>
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
        /// 删除附件
        /// </summary>
        /// <param name="spath">文件在服务器中的路径</param>
        /// <param name="img">文件名称</param>
        /// <param name="thumbnailimg">极小图片</param>
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
        /// 获取多条记录
        /// </summary>
        /// <param name="DescTabID">信息Id</param>
        /// <param name="item">附件项</param>
        /// <returns>多条记录</returns>
        public DataTable GetDataTable(long DescTabID, Model.AttachmentItem item, Model.UploadFileType fileType)
        {
            if (DescTabID <= 0) return new DataTable();

            return DAL.GetDataTable(DescTabID, GetDescTableName(item), GetFileTypeStr(fileType));
        }
        /// <summary>
        /// 根据目标表名称和目标表编号返回附件信息实体对象
        /// </summary>
        /// <param name="DescTabName">目标表名称</param>
        /// <param name="DescTabID">目标表编号</param>
        /// <returns>附件信息实体对象</returns>
        public static XYECOM.Model.AttachmentInfo GetTop1Info(string DescTabName, string DescTabID)
        {
            if (DescTabName.Trim().Equals("") || DescTabID.Equals("")) return null;

            return DAL.GetTop1Info(DescTabName, DescTabID);
        }
        /// <summary>
        /// 根据附件项和目标表编号返回附件信息实体对象
        /// </summary>
        /// <param name="item">附件项</param>
        /// <param name="descTabID">目标表编号</param>
        /// <returns>返回附件信息实体对象</returns>
        public static XYECOM.Model.AttachmentInfo GetTop1Info(Model.AttachmentItem item, long descTabID)
        {
            string decsTabName = GetDescTableName(item);

            return GetTop1Info(decsTabName, descTabID.ToString());
        }

        /// <summary>
        /// 获取信息的默认图片地址
        /// </summary>
        /// <param name="DescTabName">目标表名称</param>
        /// <param name="DescTabID">目标表编号</param>
        /// <returns>根据目标表名称和目标表编号返回信息的默认图片地址</returns>
        public static string GetInfoDefaultImgHref(Model.AttachmentItem item, long descTabID)
        {
            XYECOM.Model.AttachmentInfo info = GetTop1Info(item, descTabID);

            if (info == null) return "/Common/Images/DefaultImg.gif";

            return info.Server.S_URL + info.At_Path;
        }

        /// <summary>
        /// 获取信息的默认图片地址
        /// </summary>
        /// <param name="DescTabName">目标表名称</param>
        /// <param name="DescTabID">目标表编号</param>
        /// <returns>信息的默认图片地址</returns>
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
        /// <summary>
        /// 根据表名和Id获取附近图片集合
        /// </summary>
        /// <param name="item"></param>
        /// <param name="descTabID"></param>
        /// <returns></returns>
        public static DataTable GetAllImgHref(Model.AttachmentItem item, long descTabID)
        {
            string decsTabName = GetDescTableName(item);
            return DAL.GetAllImgHref(decsTabName, descTabID);
        }
    }
}
