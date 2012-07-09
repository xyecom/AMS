using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace XYECOM.Web.xymanage.UserControl
{
    public partial class UploadFile : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                XYECOM.Page.Upload.UploadManage.InitUploadFile(ref ids, ref files, maxAmount, infoID, GetAttachmentItem);
            }
        }
        //更新数据
        public void Update()
        {
            XYECOM.Page.Upload.UploadManage.UploadFile(infoID);
        }

        private Model.AttachmentItem GetAttachmentItem
        {
            get
            {
                return XYECOM.Business.Attachment.GetAttachmentItem(tableName);
            }
        }

        private string tableName;

        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }
        private int maxAmount;

        public int MaxAmount
        {
            get { return maxAmount; }
            set { maxAmount = value; }
        }

        private Int64 infoID;

        public Int64 InfoID
        {
            get { return infoID; }
            set { infoID = value; }
        }

        private string ids;

        protected string Ids
        {
            get { return ids; }
            set { ids = value; }
        }

        private string files;

        protected string Files
        {
            get { return files; }
            set { files = value; }
        }
    }
}