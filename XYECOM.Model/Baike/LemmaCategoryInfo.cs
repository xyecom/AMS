//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：LemmaCategory.cs
// author: 苟波涛
// create date：2009-12-10 20:32:46
//
//------------------------------------------------------------------------------
using System;
namespace XYECOM.Model
{
	public class LemmaCategoryInfo
	{
		#region Data

		/// <summary>
		/// 分类编号
		/// </summary>
		private int categoryId;
		
		/// <summary>
		/// 分类名称
		/// </summary>
		private string categoryName;
		
		/// <summary>
		/// 父级分类
		/// </summary>
		private int parentId;
		
		/// <summary>
		/// 说明
		/// </summary>
		private string description;
		
		/// <summary>
		/// 完整编号
		/// </summary>
		private string fullId;
		
		/// <summary>
		/// 排序编号
		/// </summary>
		private int orderId;

        /// <summary>
        /// 类别的路径 从顶级开始 不包括自身
        /// </summary>
        private string fullName = "";
		 
		#endregion
		
		#region Properties
		
		/// <summary>
		/// 分类编号
		/// </summary>
		public int CategoryId
		{
			get 
			{
				return this.categoryId;
			}
			set 
			{
				this.categoryId = value;
			}
		}

		/// <summary>
		/// 分类名称
		/// </summary>
		public string CategoryName
		{
			get 
			{
				return this.categoryName;
			}
			set 
			{
				this.categoryName = value;
			}
		}

		/// <summary>
		/// 父级分类
		/// </summary>
		public int ParentId
		{
			get 
			{
				return this.parentId;
			}
			set 
			{
				this.parentId = value;
			}
		}

		/// <summary>
		/// 说明
		/// </summary>
		public string Description
		{
			get 
			{
				return this.description;
			}
			set 
			{
				this.description = value;
			}
		}

		/// <summary>
		/// 完整编号
		/// </summary>
		public string FullId
		{
			get 
			{
				return this.fullId;
			}
			set 
			{
				this.fullId = value;
			}
		}

		/// <summary>
		/// 排序编号
		/// </summary>
		public int OrderId
		{
			get 
			{
				return this.orderId;
			}
			set 
			{
				this.orderId = value;
			}
		}

        /// <summary>
        /// 类别的路径 从顶级开始 不包括自身
        /// </summary>
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }
	
		#endregion
	}
}
