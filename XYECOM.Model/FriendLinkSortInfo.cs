using System;
using System.Collections.Generic;
using System.Text;


namespace XYECOM.Model
{
    #region ���������������ʵ����
     /// <summary>
     /// �������ӷ���ʵ����
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
        #region FriendLinkSort������
         /// <summary>
         /// ������������ID
         /// </summary>
        public int FS_ID
        {
            set { _fs_id = value; }
            get { return _fs_id; }
        }
         /// <summary>
         /// ����������������
         /// </summary>
        public string FS_Name
        {
            set { _fs_name = value; }
            get { return _fs_name; }
        }
         /// <summary>
         /// �����������ĸ�ID
         /// </summary>
        public int FS_PID
        {
            set { _fs_pid = value; }
            get { return _fs_pid; }
        }
         /// <summary>
         /// ������������˵��
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
