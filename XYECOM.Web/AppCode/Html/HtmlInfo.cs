using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Web.Html
{
    public class HtmlInfo
    {
        public HtmlInfo()
        {
            if (HtmlManage.TaskList.Count > 0)
                _PageIndex = HtmlManage.TaskList[HtmlManage.TaskList.Count - 1].PageIndex + 1;
            else
                _PageIndex = 1;
        }
        private int _PageIndex;
        
        public int PageIndex
        {
            get { return _PageIndex; }
        }

        public string PageType = "";

        public string PageModule = "";

        public bool IsDel = false;

        public bool NewOnly = false;

        public string PageName = "";

        public string PageHttpURL = "";

        public string PageClassID = "";

        public string PageBeginTime = "";

        public string PageEndTime = "";

        public string InfoIdList = "";
    }
}
