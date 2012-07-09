using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 地方站信息实体类
    /// </summary>
    public class AreaSiteInfo
    {
        private int siteId;
        /// <summary>
        /// 地方站点Id
        /// </summary>
        public int SiteId
        {
            get { return siteId; }
            set { siteId = value; }
        }

        private int areaId;
        /// <summary>
        /// 地方站点所对应的地区Id
        /// </summary>
        public int AreaId
        {
            get { return areaId; }
            set { areaId = value; }
        }

        private string flagName;
        /// <summary>
        /// 地方站表示名称(如：河南可以为henan)
        /// </summary>
        public string FlagName
        {
            get { return flagName; }
            set { flagName = value; }
        }

        private bool isCostomTemplate;
        /// <summary>
        /// 是否自定义模板
        /// </summary>
        public bool IsCostomTemplate
        {
            get { return isCostomTemplate; }
            set { isCostomTemplate = value; }
        }

    }
}
