using System;
using System.Collections.Generic;
using System.Text;


namespace XYECOM.Model
{
    /// <summary>
    /// ������Ϣʵ����
    /// </summary>
    public class AttachmentInfo
    {
        private long attId;
        private long descTabId;
        private string descTabName;
        private string attPath;
        private string attFileFormat;
        private string attFileType;
        private int attIndex;
        private DateTime attPulishDate;
        private string attRemark;
        private int serverId;

        public AttachmentInfo()
        {
            attId = 0;
            descTabId = 0;
            descTabName = "";
            attPath = "";
            attFileFormat = "";
            attFileType = "";
            attIndex = 0;
            attPulishDate = DateTime.Now;
            attRemark = "";
            serverId = 0;
        }

        /// <summary>
        /// ��˱��
        /// </summary>
        public System.Int64 At_ID
        {
            set { attId = value; }
            get { return attId; }
        }
        /// <summary>
        /// Ŀ�����
        /// </summary>
        public System.Int64 DescTabID
        {
            set { descTabId = value; }
            get { return descTabId; }
        }
        /// <summary>
        /// Ŀ�������
        /// </summary>
        public string DescTabName
        {
            set { descTabName = value; }
            get { return descTabName; }
        }
        /// <summary>
        /// �洢λ��
        /// </summary>
        public string At_Path
        {
            set { attPath = value; }
            get { return attPath; }
        }
        /// <summary>
        /// �洢��ʽ
        /// </summary>
        public string At_FileFormat
        {
            set { attFileFormat = value; }
            get { return attFileFormat; }
        }
        /// <summary>
        /// �ļ�����
        /// </summary>
        public string At_FileType
        {
            set { attFileType = value; }
            get { return attFileType; }
        }
        /// <summary>
        /// �Ƿ�Ĭ��
        /// </summary>
        public int At_Index
        {
            set { attIndex = value; }
            get { return attIndex; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public DateTime At_PulishDate
        {
            set { attPulishDate = value; }
            get { return attPulishDate; }
        }
        /// <summary>
        /// ��ע
        /// </summary>
        public string At_Remark
        {
            set { attRemark = value; }
            get { return attRemark; }
        }
        /// <summary>
        /// ���������
        /// </summary>
        public int S_ID
        {
            set { serverId = value; }
            get { return serverId; }
        }

        /// <summary>
        /// ����ͼ�ַ���
        /// </summary>
        private string thumbnailImg;
        public string ThumbnailImg
        {
            get { return thumbnailImg; }
            set
            {
                thumbnailImg = value;
                if (!thumbnailImg.Equals(""))
                {
                    if (smallImg == null) smallImg = new ThumbnailImg();

                    smallImg.Images = thumbnailImg.Split('|');
                }
            }
        }

        private ThumbnailImg smallImg = null;
        /// <summary>
        /// ����ͼ������Ϣ
        /// </summary>
        public ThumbnailImg SmallImg
        {
            get
            {
                return smallImg;
            }
        }

        private ServerInfo server = null;
        /// <summary>
        /// ��������Ӧ�ķ�������Ϣ
        /// </summary>
        public ServerInfo Server
        {
            get { return server; }
            set
            {
                server = value;
                if (server != null)
                {
                    if (smallImg == null) smallImg = new ThumbnailImg();

                    smallImg.SURL = server.S_URL;
                }
            }
        }

        public string FullPath
        {
            get
            {
                string fullPath = string.Empty;
                if (this.server != null)
                {
                    fullPath += this.server.S_URL;
                }
                return fullPath + this.At_Path;
            }
        }
    }

}
