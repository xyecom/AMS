using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 招商加盟分类实体类
    /// </summary>
    public class InviteBusinessTypeInfo
    {
        private Int64 _it_id;
        private string _it_name;
        private Int64 _it_parentid;
        private string _ModuleName;
        private string _FullId;
        private int _InfoCount;


        public InviteBusinessTypeInfo() { }
        /// <summary>
        /// 给定值得构造函数
        /// </summary>
        /// <param name="ctid"></param>
        /// <param name="ctname"></param>
        /// <param name="ctparentid"></param>
        /// <param name="ctbid"></param>
        /// <param name="mid"></param>
        public InviteBusinessTypeInfo(Int64 itid, string itname, Int64 itparentid, string moduleName,string fullId,int infoCount)
        {
            this._it_id = itid;
            this._it_name = itname;
            this._it_parentid = itparentid;
            this._ModuleName = moduleName;
            this._FullId = fullId;
            this._InfoCount = infoCount;
        }

        /// <summary>
        /// 合作类别的编号
        /// </summary>
        public Int64 IT_ID
        {
            set { _it_id = value; }
            get { return _it_id; }
        }

        /// <summary>
        /// 合作类别的名称
        /// </summary>
        public string IT_Name
        {
            set { _it_name = value; }
            get { return _it_name; }
        }

        /// <summary>
        /// 合作类别的父编号
        /// </summary>
        public Int64 IT_ParentID
        {
            set { _it_parentid = value; }
            get { return _it_parentid; }
        }
        /// <summary>
        /// 该类别使用的模块编号
        /// 默认为0,即为系统默认编号
        /// </summary>
        public string ModuleName
        {
            set { _ModuleName = value; }
            get { return _ModuleName; }
        }

        /// <summary>
        /// 完整父级Id列表
        /// </summary>
        public string FullId
        {
            get { return _FullId; }
            set { _FullId = value; }
        }

        /// <summary>
        /// 信息总数
        /// </summary>
        public int InfoCount
        {
            get { return _InfoCount; }
            set { _InfoCount = value; }
        }
    }
}
