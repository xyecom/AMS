using System;
using System.Collections.Generic;
using System.Text;


namespace XYECOM.Model
{
    /// <summary>
    /// 收藏信息实体类
    /// </summary>
    public class FavoriteInfo
    {
        private long  _fa_id;
        private long  _u_id;
        private long  _desctabid;
        private string _desctabname;
        private DateTime _at_pulishdate;

        public FavoriteInfo()
        {
            _fa_id = 0;
            _u_id = 0;
            _desctabid = 0;
            _desctabname = "";
            _at_pulishdate = DateTime.Now;
        }


        /// <summary>
        /// 收藏编号
        /// </summary>
        public long  Fa_ID
        {
            set { _fa_id = value; }
            get { return _fa_id; }
        }
        /// <summary>
        /// 发布者编号
        /// </summary>
        public long  U_ID
        {
            set { _u_id = value; }
            get { return _u_id; }
        }
        /// <summary>
        /// 目标表编号
        /// </summary>
        public long  DescTabID
        {
            set { _desctabid = value; }
            get { return _desctabid; }
        }
        /// <summary>
        /// 目标表名称
        /// </summary>
        public string DescTabName
        {
            set { _desctabname = value; }
            get { return _desctabname; }
        }
        /// <summary>
        /// 发布日期
        /// </summary>
        public DateTime At_PulishDate
        {
            set { _at_pulishdate = value; }
            get { return _at_pulishdate; }
        }
    }

}
