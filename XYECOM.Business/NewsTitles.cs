using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace XYECOM.Business
{
    /// <summary>
    /// 新闻栏目业务类
    /// </summary>
    public class NewsTitles
    {
        private static readonly XYECOM.SQLServer.NewsTitles DAL = new XYECOM.SQLServer.NewsTitles();
        
        /// <summary>
        ///  添加新闻栏目信息
        /// </summary>
        /// <param name="nt">实体类NewsTitles</param>
        /// <param name="nt_id">所添加的新闻栏目的ID值</param>
        /// <returns>数字，大于或等于0表示添加成功</returns>
        public int Insert(XYECOM.Model.NewsTitlesInfo info, out int nt_id)
        {
            if (info == null)
            {
                nt_id = 0;
                return 0;
            }

            return DAL.Insert(info, out nt_id);
        }

        /// <summary>
        /// 修改指定的新闻栏目信息
        /// </summary>
        /// <param name="info">指定的栏目信息</param>
        /// <param name="subChannelAutoInheritCustomFolderValue">子栏目是否自动继承自定义文件夹属性</param>
        /// <param name="subDomain">子栏目继承域名</param>
        /// <returns>数字，大于或等于0表示修改成功</returns>
        public int Update(XYECOM.Model.NewsTitlesInfo info, bool subChannelAutoInheritCustomFolderValue, bool subDomain)
        {
            string subIds = XYECOM.Business.XYClass.GetSubIds("news", info.Id).Trim();
            XYECOM.Model.NewsTitlesInfo baseinfo = new XYECOM.Business.NewsTitles().GetItem(info.Id);

            //如果启用二级域名，则必须自定义文件夹
            if (subDomain)
            {
                if (!subIds.Equals(""))
                {
                    XYECOM.SQLServer.Utils.UpdateColumuByWhere("NT_TempletFolderAddress", info.TempletFolderAddress, "where NT_ID in(" + subIds + ")", "n_newsTitleInfo");

                    XYECOM.SQLServer.Utils.UpdateColumuByWhere("DomainName", info.DomainName, "where NT_ID in(" + subIds + ")", "n_newsTitleInfo");
                }
            }
            //当自定义栏目文件夹不为空时，将此属性自动继承为所有子栏目
            else if (subChannelAutoInheritCustomFolderValue)          
            {
                if (!subIds.Equals(""))
                {
                    XYECOM.SQLServer.Utils.UpdateColumuByWhere("NT_TempletFolderAddress", info.TempletFolderAddress, "where NT_ID in(" + subIds + ")", "n_newsTitleInfo");
                }
            }            

            return DAL.Update(info);
        }

        /// <summary>
        /// 删除指定的新闻栏目信息
        /// </summary>
        /// <param name="nt_ids">指定的新闻栏目编号字符串</param>
        /// <returns>数字，大于或等于0表示删除成功</returns>
        public int Delete(string nt_ids)
        {
            if (String.IsNullOrEmpty(nt_ids) || nt_ids.Trim().Equals("")) return 0;

            return DAL.Delete(nt_ids);
        }

        /// <summary>
        /// 根据指定的ID值获得该项新闻栏目名称
        /// </summary>
        /// <param name="ntid">新闻栏目对象</param>
        /// <returns>该新闻栏目的名称</returns>
        public Model.NewsTitlesInfo GetItem(int Id)
        {
            if (Id <= 0) return null;

            return DAL.GetItem(Id);
        }

        /// <summary>
        /// 根据二级域名得到新闻栏目信息
        /// </summary>
        /// <param name="domainname">二级域名</param>
        /// <returns>新闻栏目实体对象</returns>
        public Model.NewsTitlesInfo GetItemByDomainName(string domainname)
        {
            if (string.IsNullOrEmpty(domainname)) return null;

            return DAL.GetItemByDomainName(domainname);
        }

        /// <summary>
        /// 获取指定父Id的所有子栏目
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public List<Model.NewsTitlesInfo> GetItems(int parentId)
        {
            if (parentId <= 0) return new List<XYECOM.Model.NewsTitlesInfo>();

            return DAL.GetItems(parentId);
        }
    }
}
