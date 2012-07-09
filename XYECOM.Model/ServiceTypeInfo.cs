using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 服务分类实体类
    /// </summary>
    public class ServiceTypeInfo
    {
        private Int64 _st_id;
        private string _st_name;
        private Int64 _st_parentid;
        private string _ModuleName;
        private string _FullId;
        private int _InfoCount;

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public ServiceTypeInfo () {}
        /// <summary>
        /// 给定值得构造函数
        /// </summary>
        /// <param name="ctid"></param>
        /// <param name="ctname"></param>
        /// <param name="ctparentid"></param>
        /// <param name="ctbid"></param>
        /// <param name="mid"></param>
        public ServiceTypeInfo(Int64 stid, string stname, Int64 stparentid, string moduleName,string fullId,int infoCount)
        {
            this._st_id = stid;
            this._st_name = stname;
            this._st_parentid = stparentid;
            this._ModuleName = moduleName;
            this._FullId = fullId;
            this._InfoCount = infoCount;
        }

        /// <summary>
        /// 服务类别的编号
        /// </summary>
        public Int64 ST_ID
        {
            set { _st_id = value; }
            get { return _st_id; }
        }

        /// <summary>
        /// 服务类别的名称
        /// </summary>
        public string ST_Name
        {
            set { _st_name = value; }
            get { return _st_name; }
        }

        /// <summary>
        /// 服务类别的父编号
        /// </summary>
        public Int64 ST_ParentID
        {
            set { _st_parentid = value; }
            get { return _st_parentid; }
        }

        /// <summary>
        /// 该类别使用的模块编号
        /// 默认为0,即为系统默认编号,即为服务模板
        /// </summary>
        public string ModuleName
        {
            set { _ModuleName = value; }
            get { return _ModuleName; }
        }

        /// <summary>
        /// 父级Id列表
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
