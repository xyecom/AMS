using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// ������Ϣʵ����
    /// </summary>
    public class MessageInfo
    {
        private long _m_id;
        private string _m_username;
        private string _m_moblie;
        private string _m_content;
        private bool _m_hasreply;
        private long _ur_id;
        private string _m_recvertype;
        private long _u_id;
        private string _m_phma;
        private string _m_fhm;
        private string _m_adress;
        private string _m_title;
        private string _m_email;
        private string _m_sendertype;
        private bool  _m_usertype;
        private string _m_companyname;
        private bool _m_sex;
        private int _clicknum;
        private string  _m_rtitle;
        private string  _m_rcontent;
        private bool   _m_restore;
        private System.Int32 _area_id;
        private string _province_name;
        private string _c_name;
        private string _area_name;
        private DateTime _M_AddTime;
        private long infoId;

        public MessageInfo()
        {
            _m_id = 0;
            _m_username = "";
            _m_moblie = "";
            _m_content = "";
            _m_hasreply = false;
            _ur_id = 0;
            _m_recvertype = "";
            _u_id = 0;
            _m_phma = "";
            _m_fhm = "";
            _m_adress = "";
            _m_title = "";
            _m_email = "";
            _m_sendertype = "";
            _m_usertype = false;
            _m_companyname = "";
            _m_sex = false;
            _clicknum = 0;
            _m_rtitle = "";
            _m_rcontent = "";
            _m_restore = false;
            _area_id = 0;
            _province_name = "";
            _c_name = "";
            _M_AddTime = DateTime.Now;
        }


        //����ʱ��
        public DateTime M_AddTime
        {
            get { return _M_AddTime; }
            set { _M_AddTime = value; }
        }
        /// <summary>
        /// ���Ա��
        /// </summary>
        public long M_ID
        {
            set { _m_id = value; }
            get { return _m_id; }
        }
        /// <summary>
        /// ��ϵ��
        /// </summary>
        public string M_UserName
        {
            set { _m_username = value; }
            get { return _m_username; }
        }
        /// <summary>
        /// ��ϵ�绰
        /// </summary>
        public string M_PHMa
        {
            set { _m_phma = value; }
            get { return _m_phma; }
        }
        /// <summary>
        /// �������
        /// </summary>
        public string M_FHM
        {
            set { _m_fhm = value; }
            get { return _m_fhm; }
        }
        /// <summary>
        /// ��ַ
        /// </summary>
        public string M_Adress
        {
            set { _m_adress = value; }
            get { return _m_adress; }
        }
        /// <summary>
        /// ��˾����ʡ����
        /// </summary>
        public string Province_Name
        {
            set { _province_name = value; }
            get { return _province_name; }
        }
        /// <summary>
        /// ��˾���ڵĳ���
        /// </summary>
        public string C_Name
        {
            set { _c_name = value; }
            get { return _c_name; }
        }
        //��������
        public string Area_Name
        {
            get { return _area_name; }
            set { _area_name = value; }
        }
        /// <summary>
        /// ���Ա���
        /// </summary>
        public string M_Title
        {
            set { _m_title = value; }
            get { return _m_title; }
        }
        /// <summary>
        /// �ֻ�
        /// </summary>
        public string M_Moblie
        {
            set { _m_moblie = value; }
            get { return _m_moblie; }
        }

        //���ر��
        public System.Int32 Area_ID
        {
            get { return _area_id; }
            set { _area_id = value; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string M_Content
        {
            set { _m_content = value; }
            get { return _m_content; }
        }
         /// <summary>
        /// �Ƿ�鿴
        /// </summary>
        public bool M_HasReply
        {
            set { _m_hasreply = value; }
            get { return _m_hasreply; }
        }
        /// <summary>
        /// �ظ��߱��
        /// </summary>
        public long UR_ID
        {
            set { _ur_id = value; }
            get { return _ur_id; }
        }
        /// <summary>
        /// �ظ�����
        /// </summary>
        public string M_RecverType
        {
            set { _m_recvertype = value; }
            get { return _m_recvertype; }
        }
        //�û����
        public long U_ID
        {
            set { _u_id = value; }
            get { return _u_id; }
        }
         //Email
        public string  M_Email
        {
            set { _m_email  = value; }
            get { return _m_email; }
        }
        //�յ���������
        public string M_SenderType
        {
            set { _m_sendertype  = value; }
            get { return _m_sendertype; }
        }
        //�û�����
        public bool  M_UserType
        {
            get { return _m_usertype; }
            set { _m_usertype = value; }
        }
        //��˾����
        public string M_CompanyName
        {
            get { return _m_companyname; }
            set { _m_companyname = value; }
        }
        //�������Ա�
        public bool M_Sex
        {
            get { return _m_sex; }
            set { _m_sex = value; }
        }
        //��������
        public int ClickNum
        {
            get { return _clicknum; }
            set { _clicknum = value; }
        }
        //�ظ�����
        public string M_RTitle
        {
            get { return _m_rtitle; }
            set { _m_rtitle = value; }
        }
        //�ظ�����
        public string M_RContent
        {
            get { return _m_rcontent; }
            set { _m_rcontent = value; }
        }
        //�Ƿ�ظ�
        public bool M_Restore
        {
            get { return _m_restore; }
            set { _m_restore = value; }
        }

        /// <summary>
        /// ��ϢId
        /// </summary>
        public long InfoId
        {
            get { return infoId; }
            set { infoId = value; }
        }
    }
}
