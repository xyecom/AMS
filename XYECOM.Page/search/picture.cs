using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace XYECOM.Page.search
{
    /// <summary>
    ///  ģ�� search/picture.htm ������
    /// </summary>
    public class picture : ForeBasePage
    {
        private string moduleName = "";
        private long infoId = 0;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

           
            if (System.Web.HttpContext.Current.Request.QueryString["flag"] != null)
            {   
                switch (XYECOM.Core.XYRequest.GetQueryString("flag"))
                {
                    case "selloffer":
                    case "buyoffer":
                        moduleName = "offer";
                        break;
                    case "sellmachining":
                    case "buymachining":
                        moduleName = "venture";
                        break;
                    case "sellinvestment":
                    case "buyinvestment":
                        moduleName = "investment";
                        break;
                    case "sellservice":
                    case "buyservice":
                        moduleName = "serivce";
                        break;
                    case "exhibition":
                        moduleName = "exhibition";
                        break;
                    case "brand":
                        moduleName = "brand";
                        break;
                }

                if (System.Web.HttpContext.Current.Request.QueryString["id"] != null)
                {
                    infoId= Core.MyConvert.GetInt64(XYECOM.Core.XYRequest.GetQueryString("id"));

                }
            }

            if (moduleName.Equals("") || infoId <= 0)
            {
                GotoMsgBoxPage("�����쳣������ʧ�ܣ�");
                return;
            }
        }
        /// <summary>
        /// ��ȡ��Ϣ����ͼƬ������������ʽ����
        /// </summary>
        /// <returns>��Ϣ����ͼƬ</returns>
        protected string[] GetImages()
        {
            return base.GetImages(moduleName, infoId);
        }
    }
}
