using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// ��Ƹ��Ϣʵ����
    /// </summary>
    public class Engageinfo
    {
        private System.Int64 _ei_id;
        private int _p_id;
        private string _p_name;
        private string _ei_job;
        private string _ei_branch;
        private DateTime _ei_enddate;
        private string _ei_type;
        private string _ei_request;
        private string _ei_pay;
        private string _ei_eb;
        private string _ei_age;
        private string _ei_sex;
        private string _ei_experience;
        private string _ei_nationality;
        private System.Int64 _u_id;
        private DateTime _ei_adddate;
        private int _ei_clicknum;
        private int _ei_number;
        private bool _ei_puach;
        private System.Int32 _area_id;
        private Model.AreaInfo workAreaInfo = null;



        public Engageinfo()
        {
            _ei_id = 0;
            _p_id = 0;
            _p_name = "";
            _ei_job = "";
            _ei_branch = "";
            _ei_enddate = DateTime.Now;
            _ei_type = "";
            _ei_request = "";
            _ei_pay = "";
            _ei_eb = "";
            _ei_age = "";
            _ei_sex = "";
            _ei_experience = "";
            _ei_nationality = "";
            _u_id = 0;
            _ei_adddate = DateTime.Now;
            _ei_clicknum = 0;
            _ei_number = 0;
            _ei_puach = false;
            _area_id = 0;
        }

        /// <summary>
        /// ��Ƹ����
        /// </summary>
        public int Number
        {
            set { _ei_number = value; }
            get { return _ei_number; }
        }
        /// <summary>
        /// ��Ƹ���
        /// </summary>
        public System.Int64 JobId
        {
            set { _ei_id = value; }
            get { return _ei_id; }
        }
        /// <summary>
        /// ��Ƹ��λ���
        /// </summary>
        public int PostId
        {
            set { _p_id = value; }
            get { return _p_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PostName
        {
            set { _p_name = value; }
            get { return _p_name; }
        }

        /// <summary>
        ///ְλ���� 
        /// </summary>
        public string JobTitle
        {
            set { _ei_job = value; }
            get { return _ei_job; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string JobBranch
        {
            set { _ei_branch = value; }
            get { return _ei_branch; }
        }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime EndDate
        {
            set { _ei_enddate = value; }
            get { return _ei_enddate; }
        }
        /// <summary>
        /// ��Ƹ���ͣ�ȫְ����ְ�����ޣ�
        /// </summary>
        public string JobType
        {
            set { _ei_type = value; }
            get { return _ei_type; }
        }

        /// <summary>
        /// �������ڵ�Id
        /// </summary>
        public System.Int32 WorkAreaID
        {
            get { return _area_id; }
            set { _area_id = value; }

        }

        /// <summary>
        /// �������ڵ�����ϸ��Ϣ
        /// </summary>
        public Model.AreaInfo WorkAreaInfo
        {
            get { return workAreaInfo; }
            set { workAreaInfo = value; }
        }

        /// <summary>
        /// ����Ҫ��
        /// </summary>
        public string Request
        {
            set { _ei_request = value; }
            get { return _ei_request; }
        }
        /// <summary>
        /// н�ʸ���
        /// </summary>
        public string Pay
        {
            set { _ei_pay = value; }
            get { return _ei_pay; }
        }
        /// <summary>
        /// ѧ��
        /// </summary>
        public string Education
        {
            set { _ei_eb = value; }
            get { return _ei_eb; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string Age
        {
            set { _ei_age = value; }
            get { return _ei_age; }
        }
        /// <summary>
        /// �Ա�
        /// </summary>
        public string Sex
        {
            set { _ei_sex = value; }
            get { return _ei_sex; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string Experience
        {
            set { _ei_experience = value; }
            get { return _ei_experience; }
        }
        /// <summary>
        /// ����Ҫ��
        /// </summary>
        public string Nationality
        {
            set { _ei_nationality = value; }
            get { return _ei_nationality; }
        }
        /// <summary>
        /// �����߱��
        /// </summary>
        public System.Int64 UserId
        {
            set { _u_id = value; }
            get { return _u_id; }
        }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime AddDate
        {
            set { _ei_adddate = value; }
            get { return _ei_adddate; }
        }
        /// <summary>
        /// �鿴����
        /// </summary>
        public int ClickNum
        {
            set { _ei_clicknum = value; }
            get { return _ei_clicknum; }
        }
        //�Ƿ���ͣ
        public bool IsPause
        {
            get { return _ei_puach; }
            set { _ei_puach = value; }
        }
    }
}
