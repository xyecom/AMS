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
    public partial class UploadImage : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                XYECOM.Page.Upload.UploadManage.Upload(ref ids, ref files, GetAttachmentItem, maxAmount, iswatermark, infoID, IsCreateThumbnailImg);
            }
        }

        //更新数据
        public void Update()
        {
            XYECOM.Page.Upload.UploadManage.Upload(ref ids, ref files, GetAttachmentItem, maxAmount, iswatermark, infoID, IsCreateThumbnailImg);
        }

        private Model.AttachmentItem GetAttachmentItem
        {
            get
            {
                return XYECOM.Business.Attachment.GetAttachmentItem(tableName);
            }
        }

        private bool isCreateThumbnailImg = true;

        public bool IsCreateThumbnailImg
        {
            get { return isCreateThumbnailImg; }
            set { isCreateThumbnailImg = value; }
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
        private bool iswatermark;

        public bool Iswatermark
        {
            get { return iswatermark; }
            set { iswatermark = value; }
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