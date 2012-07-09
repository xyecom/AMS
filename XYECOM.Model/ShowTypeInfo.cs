using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 展会分类实体类
    /// </summary>
    public class ShowTypeInfo
    {
        private Int64 _sht_id;
        private string _sht_name;
        private Int64 _sht_parentid;
        private string _FullID;
        private int _InfoCount;
 
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public ShowTypeInfo() { }

        /// <summary>
        /// 给定值得构造函数
        /// </summary>
        /// <param name="ctid"></param>
        /// <param name="ctname"></param>
        /// <param name="ctparentid"></param>
        /// <param name="ctbid"></param>
        /// <param name="mid"></param>
        public ShowTypeInfo(Int64 shtid, string shtname, Int64 shtparentid,string fullId,int infoCount)
        {
            this._sht_id = shtid;
            this._sht_name = shtname;
            this._sht_parentid = shtparentid;
            this._FullID = fullId;
            this._InfoCount = infoCount;
        }

        /// <summary>
        /// 合作类别的编号
        /// </summary>
        public Int64 SHT_ID
        {
            set { _sht_id = value; }
            get { return _sht_id; }
        }

        /// <summary>
        /// 合作类别的名称
        /// </summary>
        public string SHT_Name
        {
            set { _sht_name = value; }
            get { return _sht_name; }
        }

        /// <summary>
        /// 合作类别的父编号
        /// </summary>
        public Int64 SHT_ParentID
        {
            set { _sht_parentid = value; }
            get { return _sht_parentid; }
        }

        /// <summary>
        /// 父级分类集合
        /// </summary>
        public string FullID
        {
            get { return _FullID; }
            set { _FullID = value; }
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
