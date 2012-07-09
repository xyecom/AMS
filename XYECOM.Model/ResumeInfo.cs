using System;


namespace XYECOM.Model
{
    /// <summary>
    /// 简历信息实体类
    /// </summary>
    public class ResumeInfo
    {        
        private long _u_id;

        private DateTime _re_gyear;  
        private string _re_jobyear;     
        private string _re_school;
        private string _re_speciality;
        private string _re_schoolage;
        private string _re_resume;
        private DateTime _re_adddate;
        private string _re_experience;
        private string _re_intentjob;
        private string _re_intentadd;
        private string  _re_intentpay;
        /// <summary>
        /// 期望职位
        /// </summary>
        public string RE_Intentjob
        {
            set {_re_intentjob=value ;}
            get {return _re_intentjob ;}
        }
        /// <summary>
        /// 期望城市
        /// </summary>
        public string RE_Intentadd
         {
            set {_re_intentadd=value ;}
            get {return _re_intentadd ;}
        }
        /// <summary>
        /// 期望工资
        /// </summary>
        public string RE_Intentpay
         {
            set {_re_intentpay=value ;}
            get { return _re_intentpay;}
        }
        /// <summary>
        /// 工作经验
        /// </summary>
        public string RE_Experience
        {
            set {_re_experience=value ;}
            get {return _re_experience ;}
        }
        /// <summary>
        /// 用户ID
        /// </summary>
        public long U_ID
        {
            set { _u_id = value; }
            get { return _u_id; }
        }


        public DateTime RE_Gyear
        {
            set { _re_gyear=value;}
            get { return _re_gyear;}
        }

        /// <summary>
        /// 工作年限
        /// </summary>
        public string RE_JobYear
        {
            set { _re_jobyear = value; }
            get { return _re_jobyear; }
        }

        /// <summary>
        /// 毕业学校
        /// </summary>
        public string RE_School
        {
            set { _re_school = value; }
            get { return _re_school; }
        }
        /// <summary>
        /// 专业
        /// </summary>
        public string RE_Speciality
        {
            set { _re_speciality = value; }
            get { return _re_speciality; }
        }

        /// <summary>
        /// 最高学历
        /// </summary>
        public string RE_Schoolage
        {
            set { _re_schoolage = value; }
            get { return _re_schoolage; }
        }
        /// <summary>
        /// 自我介绍
        /// </summary>
        public string RE_Resume
        {
            set { _re_resume = value; }
            get { return _re_resume; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime RE_Adddate
        {
            set { _re_adddate = value; }
            get { return _re_adddate; }
        }

        private string re_htmlpage;
        /// <summary>
        /// 静态页面
        /// </summary>
        public string Re_htmlpage
        {
            get { return re_htmlpage; }
            set { re_htmlpage = value; }
        }

    }
}
