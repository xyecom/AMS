using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// ����������ʵ����
    /// </summary>
    public class ServerInfo
    {
        private int _s_id;
        private string _s_name;
        private string _s_path;
        private string _s_url;
        private bool _S_IsCurrent;
        private bool _S_Flag;
        /// <summary>
        /// ���������
        /// </summary>
        public int S_ID
        {
            set { _s_id = value; }
            get { return _s_id; }
        }
        /// <summary>
        /// ����������
        /// </summary>
        public string S_Name
        {
            set { _s_name = value; }
            get { return _s_name; }
        }
        /// <summary>
        /// ����������·��
        /// </summary>
        public string S_Path
        {
            set { _s_path = value; }
            get { return _s_path; }
        }
        /// <summary>
        /// ����������·��
        /// </summary>
        public string S_URL
        {
            set { _s_url = value; }
            get { return _s_url; }
        }
        //�Ƿ���Ĭ�Ϸ�����
        public bool S_IsCurrent
        {
            set { _S_IsCurrent = value; }
            get { return _S_IsCurrent; }
        }
        //�Ƿ������ַ�����
        public bool S_Flag
        {
            get { return _S_Flag; }
            set { _S_Flag = value; }
        }
    }

}
