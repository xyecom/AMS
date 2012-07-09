//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：Lemma.cs
// author: 苟波涛
// create date：2009-12-10 20:32:46
//
//------------------------------------------------------------------------------
using System;
namespace XYECOM.Model
{
    public class LemmaInfo : Attachment
	{
		#region Data

		/// <summary>
		/// 词条编号
		/// </summary>
		private long lemmaId;
		
		/// <summary>
		/// 词条名称
		/// </summary>
		private string lemmaName;
		
		/// <summary>
		/// 参考资料
		/// </summary>
		private string reference;
		
		/// <summary>
		/// 所属分类
		/// </summary>
		private string lemmaCategory;
		
		/// <summary>
		/// 扩展阅读
		/// </summary>
		private string extendRead;
		
		/// <summary>
		/// 创建者
		/// </summary>
		private string creator;
		
		/// <summary>
		/// 创建时间
		/// </summary>
		private DateTime createTime;
		
		/// <summary>
		/// 浏览次数
		/// </summary>
		private int browseTimes;
		
		/// <summary>
		/// 编辑次数
		/// </summary>
		private int editTimes;
		
		/// <summary>
		/// 是否是优秀词条
		/// </summary>
		private bool isBestLemma;
		
		/// <summary>
		/// 是否是推荐词条
		/// </summary>
		private bool isRecommend;
		
		/// <summary>
		/// 同义词
		/// </summary>
		private string synonyms;
		
		/// <summary>
		/// 英文翻译
		/// </summary>
		private string enName;
		
		/// <summary>
		/// 词条完善程度
		/// </summary>
		private int completeStatus;
		
		/// <summary>
		/// 内容
		/// </summary>
		private string content;
		
		/// <summary>
		/// 图片
		/// </summary>
		private long picture;
		
		/// <summary>
		/// 最近更新时间
		/// </summary>
		private string lastModiyTime;
		
		 
		#endregion
		
		#region Properties
		
		/// <summary>
		/// 词条编号
		/// </summary>
		public long LemmaId
		{
			get 
			{
				return this.lemmaId;
			}
			set 
			{
				this.lemmaId = value;
			}
		}

        public int curStatus;

        public int CurStatus 
        {
            get { return curStatus; }
            set { curStatus = value; }
        }

		/// <summary>
		/// 词条名称
		/// </summary>
		public string LemmaName
		{
			get 
			{
				return this.lemmaName;
			}
			set 
			{
				this.lemmaName = value;
			}
		}

		/// <summary>
		/// 参考资料
		/// </summary>
		public string Reference
		{
			get 
			{
				return this.reference;
			}
			set 
			{
				this.reference = value;
			}
		}

		/// <summary>
		/// 所属分类
		/// </summary>
		public string LemmaCategory
		{
			get 
			{
				return this.lemmaCategory;
			}
			set 
			{
				this.lemmaCategory = value;
			}
		}

		/// <summary>
		/// 扩展阅读
		/// </summary>
		public string ExtendRead
		{
			get 
			{
				return this.extendRead;
			}
			set 
			{
				this.extendRead = value;
			}
		}

		/// <summary>
		/// 创建者
		/// </summary>
		public string Creator
		{
			get 
			{
				return this.creator;
			}
			set 
			{
				this.creator = value;
			}
		}

		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime CreateTime
		{
			get 
			{
				return this.createTime;
			}
			set 
			{
				this.createTime = value;
			}
		}

		/// <summary>
		/// 浏览次数
		/// </summary>
		public int BrowseTimes
		{
			get 
			{
				return this.browseTimes;
			}
			set 
			{
				this.browseTimes = value;
			}
		}

		/// <summary>
		/// 编辑次数
		/// </summary>
		public int EditTimes
		{
			get 
			{
				return this.editTimes;
			}
			set 
			{
				this.editTimes = value;
			}
		}

		/// <summary>
		/// 是否是优秀词条
		/// </summary>
		public bool IsBestLemma
		{
			get 
			{
				return this.isBestLemma;
			}
			set 
			{
				this.isBestLemma = value;
			}
		}

		/// <summary>
		/// 是否是推荐词条
		/// </summary>
		public bool IsRecommend
		{
			get 
			{
				return this.isRecommend;
			}
			set 
			{
				this.isRecommend = value;
			}
		}

		/// <summary>
		/// 同义词
		/// </summary>
		public string Synonyms
		{
			get 
			{
				return this.synonyms;
			}
			set 
			{
				this.synonyms = value;
			}
		}

		/// <summary>
		/// 英文翻译
		/// </summary>
		public string EnName
		{
			get 
			{
				return this.enName;
			}
			set 
			{
				this.enName = value;
			}
		}

		/// <summary>
		/// 词条完善程度
		/// </summary>
		public int CompleteStatus
		{
			get 
			{
				return this.completeStatus;
			}
			set 
			{
				this.completeStatus = value;
			}
		}

		/// <summary>
		/// 内容
		/// </summary>
		public string Content
		{
			get 
			{
				return this.content;
			}
			set 
			{
				this.content = value;
			}
		}

		/// <summary>
		/// 图片
		/// </summary>
		public long Picture
		{
			get 
			{
				return this.picture;
			}
			set 
			{
				this.picture = value;
			}
		}

		/// <summary>
		/// 最近更新时间
		/// </summary>
		public string LastModiyTime
		{
			get 
			{
				return this.lastModiyTime;
			}
			set 
			{
				this.lastModiyTime = value;
			}
		}

        private string filePath;
        /// <summary>
        /// 图片的路径
        /// </summary>
        public string FilePath
        {
            get
            {
                if (AttachInfo.Count > 0)
                {
                    filePath = AttachInfo[0].Server.S_URL + AttachInfo[0].At_Path;
                }
                if (string.IsNullOrEmpty(filePath)) 
                {
                    filePath = "";
                }
                return filePath;
            }
            set
            {
                smallImg.DefaultFilePath = value;
                filePath = value;
            }
        }

        private ThumbnailImg smallImg = new ThumbnailImg();
        /// <summary>
        /// 存储小图片的数组
        /// </summary>
        public ThumbnailImg SmallImg
        {
            get
            {
                if (AttachInfo.Count > 0)
                {
                    smallImg.SURL = AttachInfo[0].Server.S_URL;
                    smallImg.Images = AttachInfo[0].ThumbnailImg.Split('|');
                    smallImg.DefaultFilePath = AttachInfo[0].Server.S_URL + AttachInfo[0].At_Path;
                }
                return smallImg;
            }
        }
	
		#endregion
	}
}
