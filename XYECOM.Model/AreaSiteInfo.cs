using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// �ط�վ��Ϣʵ����
    /// </summary>
    public class AreaSiteInfo
    {
        private int siteId;
        /// <summary>
        /// �ط�վ��Id
        /// </summary>
        public int SiteId
        {
            get { return siteId; }
            set { siteId = value; }
        }

        private int areaId;
        /// <summary>
        /// �ط�վ������Ӧ�ĵ���Id
        /// </summary>
        public int AreaId
        {
            get { return areaId; }
            set { areaId = value; }
        }

        private string flagName;
        /// <summary>
        /// �ط�վ��ʾ����(�磺���Ͽ���Ϊhenan)
        /// </summary>
        public string FlagName
        {
            get { return flagName; }
            set { flagName = value; }
        }

        private bool isCostomTemplate;
        /// <summary>
        /// �Ƿ��Զ���ģ��
        /// </summary>
        public bool IsCostomTemplate
        {
            get { return isCostomTemplate; }
            set { isCostomTemplate = value; }
        }

    }
}
