using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// �û�ע�������Ϣʵ����
    /// </summary>
    public class UserRegInfo
    {
        private int _u_id;
        private string _u_name;
        private string _u_password;
        private string _u_email;
        private string _u_question;
        private string _u_answer;
        private DateTime _u_regdate;
        private string _u_htmlpage;
        private int _u_clicknum;
        private int _UG_ID;
        private int _u_cred;
        private int _u_mark;
        private int _u_messagenum;
        private int _u_nomessgeNum;
        private bool _u_puach;
        private bool _u_vouch;
        private bool _u_flag;
        private string _u_tempname;
        private int _u_commonerr;
        private int _u_maliceerr;
        private int _u_information;
        private bool _u_activation;
        private string _u_activationcode;

        /// <summary>
        /// �û����
        /// </summary>
        public int UserId
        {
            set { _u_id = value; }
            get { return _u_id; }
        }
        /// <summary>
        /// �û�����
        /// </summary>
        public string LoginName
        {
            set { _u_name = value; }
            get { return _u_name; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string Password
        {
            set { _u_password = value; }
            get { return _u_password; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string Email
        {
            set { _u_email = value; }
            get { return _u_email; }
        }
        /// <summary>
        /// �ܱ�����
        /// </summary>
        public string Question
        {
            set { _u_question = value; }
            get { return _u_question; }
        }
        /// <summary>
        /// �ܱ���
        /// </summary>
        public string Answer
        {
            set { _u_answer = value; }
            get { return _u_answer; }
        }
        /// <summary>
        /// ע��ʱ��
        /// </summary>
        public DateTime RegDate
        {
            set { _u_regdate = value; }
            get { return _u_regdate; }
        }

        /// <summary>
        /// ��ǰ�ȼ��ڼ���
        /// </summary>
        public string Years
        {
            get
            {
                try
                {
                    return XYECOM.Core.Utils.GetYear(_u_regdate, DateTime.Now);
                }
                catch { return ""; }
            }
        }

        /// <summary>
        /// ����ҳ��ַ
        /// </summary>
        public string HTMLPage
        {
            set { _u_htmlpage = value; }
            get { return _u_htmlpage; }
        }
        /// <summary>
        /// �������
        /// </summary>
        public int ClickNum
        {
            set { _u_clicknum = value; }
            get { return _u_clicknum; }
        }
        /// <summary>
        /// ����?
        /// </summary>
        public int Mark
        {
            set { _u_mark = value; }
            get { return _u_mark; }
        }
        /// <summary>
        /// �û��ȼ����
        /// </summary>
        public int GradeId
        {
            set { _UG_ID = value; }
            get { return _UG_ID; }
        }
        /// <summary>
        /// �û�����?
        /// </summary>
        public int Cred
        {
            get { return _u_cred; }
            set { _u_cred = value; }
        }

        /// <summary>
        /// δ�鿴������
        /// </summary>
        public int NoMessgeNum
        {
            get { return _u_nomessgeNum; }
            set { _u_nomessgeNum = value; }

        }
        /// <summary>
        /// �ܹ���������
        /// </summary>
        public int MessageNum
        {
            get { return _u_messagenum; }
            set { _u_messagenum = value; }
        }

        /// <summary>
        /// �Ƿ���ͣ
        /// </summary>
        public bool IsPuach
        {
            get { return _u_puach; }
            set { _u_puach = value; }
        }
        /// <summary>
        /// �Ƿ��Ƽ�
        /// </summary>
        public bool IsVouch
        {
            get { return _u_vouch; }
            set { _u_vouch = value; }
        }

        /// <summary>
        /// ����ģ������
        /// </summary>
        public string TemplateName
        {
            set { _u_tempname = value; }
            get { return _u_tempname; }
        }

        /// <summary>
        /// ��ͨ���󴦷�����
        /// </summary>
        public int CommonErr
        {
            set { _u_commonerr = value; }
            get { return _u_commonerr; }
        }

        /// <summary>
        /// ������󴦷�����
        /// </summary>
        public int MaliceErr
        {
            set { _u_maliceerr = value; }
            get { return _u_maliceerr; }
        }

        /// <summary>
        /// �û�����������
        /// </summary>
        public int InFormation
        {
            set { _u_information = value; }
            get { return _u_information; }
        }

        /// <summary>
        /// �Ƿ񼤻�
        /// </summary>
        public bool IsActivation
        {
            get { return _u_activation; }
            set { _u_activation = value; }
        }
        /// <summary>
        /// ��������֤��ַ
        /// </summary>
        public string ActivationCode
        {
            get { return _u_activationcode; }
            set { _u_activationcode = value; }
        }        
        
        private Model.AuditingState _AuditingState = AuditingState.NoPass;

        /// <summary>
        /// �û����״̬��ö�٣�
        /// </summary>
        public Model.AuditingState AuditingState
        {
            get { return _AuditingState; }
            set { _AuditingState = value; }
        }


        private bool isHasImage;

        /// <summary>
        /// �Ƿ����ͼƬ
        /// </summary>
        public bool IsHasImage
        {
            get { return isHasImage; }
            set { isHasImage = value; }
        }

        public int AccountId
        {
            get;
            set;
        }

        public decimal CreditIntegral
        {
            get;
            set;
        }

        public Model.CreditLeavlInfo CreditLeavl
        {
            get;
            set;
        }

        #region AMS
        /// <summary>
        /// �Ƿ������˻�
        /// </summary>
        public bool IsPrimary
        {
            get;
            set;
        }
        /// <summary>
        /// ��������(��ʦ����
        /// </summary>
        public string LayerName
        {
            get;
            set;
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// �绰
        /// </summary>
        public string Telphone
        {
            get;
            set;
        }
        /// <summary>
        /// ������ϵ��ʽ
        /// </summary>
        public string OtherContact
        {
            get;
            set;
        }
        /// <summary>
        /// �Ա�0 �� 1Ů
        /// </summary>
        public bool Sex
        {
            get;
            set;
        }
        /// <summary>
        /// ���֤
        /// </summary>
        public string IdNumber
        {
            get;
            set;
        }
        /// <summary>
        /// ��ʦ֤
        /// </summary>
        public string LayerId
        {
            get;
            set;
        }
        /// <summary>
        /// ��������
        /// </summary>
        public int AreaId
        {
            get;
            set;
        }
        /// <summary>
        /// �Ƿ�����֤ר��
        /// </summary>
        public bool IsExport
        {
            get;
            set;
        }
        /// <summary>
        /// ��ҵ���ͣ���ҵ&����&��ʦ&����ʦ����	
        /// </summary>
        public int UserType
        {
            get;
            set;
        }
        /// <summary>
        /// ɾ��״̬
        /// </summary>
        public int DelState
        {
            get;
            set;
        }
        /// <summary>
        /// Ψһ��ʾ 
        /// </summary>
        public string IdentityNumber
        {
            get;
            set;
        }
        #endregion

        public long CompanyId { get; set; }

        public string PartManagerTel { get; set; }

        public string PartManagerName { get; set; }
    }
}
