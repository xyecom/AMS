//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：TmpLemma.cs
// author: 苟波涛
// create date：2009-12-10 20:32:46
//
//------------------------------------------------------------------------------
using System;
namespace XYECOM.Model
{
	public class TmpLemmaInfo
	{
		#region Data

		/// <summary>
		/// 临时编号
		/// </summary>
		private long lemmaTmpId;
		
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
		/// 词条状态
		/// </summary>
		private int lemmaStatus;
		
		/// <summary>
		/// 创建者
		/// </summary>
		private string creator;
		
		/// <summary>
		/// 创建时间
		/// </summary>
		private DateTime createTime;
		
		/// <summary>
		/// 同义词
		/// </summary>
		private string synonyms;
		
		/// <summary>
		/// 英文翻译
		/// </summary>
		private string enName;
		
		/// <summary>
		/// 未通过原因
		/// </summary>
		private string failReason;
		
		/// <summary>
		/// 未通过时间
		/// </summary>
		private string failTime;
		
		/// <summary>
		/// 通过时间
		/// </summary>
		private string passTime;
		
		/// <summary>
		/// 修改时间
		/// </summary>
		private string modiyDate;
		
		/// <summary>
		/// 内容
		/// </summary>
		private string content;
		
		/// <summary>
		/// 图片
		/// </summary>
		private long picture;
		
		 
		#endregion
		
		#region Properties
		
		/// <summary>
		/// 临时编号
		/// </summary>
		public long LemmaTmpId
		{
			get 
			{
				return this.lemmaTmpId;
			}
			set 
			{
				this.lemmaTmpId = value;
			}
		}

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
		/// 词条状态
		/// </summary>
		public int LemmaStatus
		{
			get 
			{
				return this.lemmaStatus;
			}
			set 
			{
				this.lemmaStatus = value;
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
		/// 未通过原因
		/// </summary>
		public string FailReason
		{
			get 
			{
				return this.failReason;
			}
			set 
			{
				this.failReason = value;
			}
		}

		/// <summary>
		/// 未通过时间
		/// </summary>
		public string FailTime
		{
			get 
			{
				return this.failTime;
			}
			set 
			{
				this.failTime = value;
			}
		}

		/// <summary>
		/// 通过时间
		/// </summary>
		public string PassTime
		{
			get 
			{
				return this.passTime;
			}
			set 
			{
				this.passTime = value;
			}
		}

		/// <summary>
		/// 修改时间
		/// </summary>
		public string ModiyDate
		{
			get 
			{
				return this.modiyDate;
			}
			set 
			{
				this.modiyDate = value;
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

        private string modifier;

        /// <summary>
        /// 修改者
        /// </summary>
        public string Modifier
        {
            get { return modifier; }
            set { modifier = value; }
        }

        private string modifyReason;

        /// <summary>
        /// 修改原因
        /// </summary>
        public string ModifyReason
        {
            get { return modifyReason; }
            set { modifyReason = value; }
        }

        private int editTimes;

        public int EditTimes
        {
            get { return editTimes; }
            set { editTimes = value; }
        }

        private int browseTimes;

        public int BrowseTimes
        {
            get { return browseTimes; }
            set { browseTimes = value; }
        }

		#endregion
	}
}
