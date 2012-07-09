using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Page.brand
{
    /// <summary>
    /// ģ�� brand/index.htm ������
    /// </summary>
    public class index : ForeBasePage
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!pageinfo.IsPost)
            {
                XYECOM.Configuration.SEOInfo seoInfo= SEO.GetIndexPageSEO("brand");

                if (seoInfo != null)
                {
                    seo.Title = seoInfo.Title;
                    seo.Description = seoInfo.Description;
                    seo.Keywords = seoInfo.Keywords;
                    seo.Robots = seoInfo.IsRobots;
                }
                else
                {
                    seo.Title = "Ʒ����Ϣ";
                }


                if (SEO.IsAppendWebName)
                {
                    seo.Title = seo.Title + "_" + webInfo.WebName;
                    seo.Description = seo.Description + "," + webInfo.WebName;
                    seo.Keywords = seo.Keywords + "," + webInfo.WebName;
                }
            }
        }
    }
}
