using System;
using System.Collections.Generic;
using System.Text;


namespace XYECOM.Model
{
    #region 定义友情链接类别实体类
     /// <summary>
     /// 友情链接分类实体类
     /// </summary>
    public class FriendLinkSortInfo
    {
        
        private int _fs_id;
        private string _fs_name;
        private int _fs_pid;
        private string _fs_alt;

        public FriendLinkSortInfo()
        {

            _fs_id = 0;
            _fs_name = "";
            _fs_pid = 0;
            _fs_alt = "";
        }
        #region FriendLinkSort的属性
         /// <summary>
         /// 友情链接类别的ID
         /// </summary>
        public int FS_ID
        {
            set { _fs_id = value; }
            get { return _fs_id; }
        }
         /// <summary>
         /// 友情链接类别的名称
         /// </summary>
        public string FS_Name
        {
            set { _fs_name = value; }
            get { return _fs_name; }
        }
         /// <summary>
         /// 友情链接类别的父ID
         /// </summary>
        public int FS_PID
        {
            set { _fs_pid = value; }
            get { return _fs_pid; }
        }
         /// <summary>
         /// 友情链接类别的说明
         /// </summary>
        public string FS_Alt
        {
            set { _fs_alt = value; }
            get { return _fs_alt; }
        }
        #endregion
    }
    #endregion

}
