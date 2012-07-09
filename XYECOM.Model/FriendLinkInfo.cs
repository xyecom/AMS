using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    #region ��������������
    /// <summary>
    /// ��������ʵ����
    /// </summary>
    public class FriendLinkInfo
    {
        private short _FL_ID;
        private bool _FL_Type;
        private string _FL_Font;
        private string _FL_URL;
        private string _FL_Alt;
        private bool _FL_Flag;
        private string _FL_AddDate;
        private int _FS_ID;

        public FriendLinkInfo()
        {
            _FL_ID = 0;
            _FL_Type = false;
            _FL_Font = "";
            _FL_URL = "";
            _FL_Alt = "";
            _FL_Flag = false;
            _FL_AddDate = "";
            _FS_ID = 0;
        }

         /// <summary>
         /// �������ӱ�����
         /// </summary>
        public short FL_ID
        {
            set { _FL_ID = value; }
            get { return _FL_ID; }
        }
         /// <summary>
         /// ������������
         /// </summary>
        public bool FL_Type
        {
            set { _FL_Type = value; }
            get { return _FL_Type; }
        }
         /// <summary>
         /// ������������
         /// </summary>
        public string FL_Font
        {
            set { _FL_Font = value; }
            get { return _FL_Font; }
        }
         /// <summary>
         /// �������ӵ�ַ
         /// </summary>
        public string FL_URL
        {
            set { _FL_URL = value; }
            get { return _FL_URL; }
        }
         /// <summary>
         /// ��������˵��
         /// </summary>
        public string FL_Alt
        {
            set { _FL_Alt = value; }
            get { return _FL_Alt; }
        }
         /// <summary>
         /// �Ƿ���ʾ����������
         /// </summary>
        public bool FL_Flag
        {
            set { _FL_Flag = value; }
            get { return _FL_Flag; }
        }
         /// <summary>
         /// �����������������
         /// </summary>
        public string FL_AddDate
        {
            set { _FL_AddDate = value; }
            get { return _FL_AddDate; }
        }
         /// <summary>
         /// �������������IDֵ
         /// </summary>
        public int FS_ID
        {
            set { _FS_ID = value; }
            get { return _FS_ID; }
        }
    }
    #endregion

}
