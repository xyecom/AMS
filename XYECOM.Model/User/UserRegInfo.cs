using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 用户注册基本信息实体类
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
        /// 用户编号
        /// </summary>
        public int UserId
        {
            set { _u_id = value; }
            get { return _u_id; }
        }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string LoginName
        {
            set { _u_name = value; }
            get { return _u_name; }
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            set { _u_password = value; }
            get { return _u_password; }
        }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email
        {
            set { _u_email = value; }
            get { return _u_email; }
        }
        /// <summary>
        /// 密保问题
        /// </summary>
        public string Question
        {
            set { _u_question = value; }
            get { return _u_question; }
        }
        /// <summary>
        /// 密保答案
        /// </summary>
        public string Answer
        {
            set { _u_answer = value; }
            get { return _u_answer; }
        }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime RegDate
        {
            set { _u_regdate = value; }
            get { return _u_regdate; }
        }

        /// <summary>
        /// 当前等级第几年
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
        /// 生成页地址
        /// </summary>
        public string HTMLPage
        {
            set { _u_htmlpage = value; }
            get { return _u_htmlpage; }
        }
        /// <summary>
        /// 浏览次数
        /// </summary>
        public int ClickNum
        {
            set { _u_clicknum = value; }
            get { return _u_clicknum; }
        }
        /// <summary>
        /// 积分?
        /// </summary>
        public int Mark
        {
            set { _u_mark = value; }
            get { return _u_mark; }
        }
        /// <summary>
        /// 用户等级编号
        /// </summary>
        public int GradeId
        {
            set { _UG_ID = value; }
            get { return _UG_ID; }
        }
        /// <summary>
        /// 用户积分?
        /// </summary>
        public int Cred
        {
            get { return _u_cred; }
            set { _u_cred = value; }
        }

        /// <summary>
        /// 未查看的留言
        /// </summary>
        public int NoMessgeNum
        {
            get { return _u_nomessgeNum; }
            set { _u_nomessgeNum = value; }

        }
        /// <summary>
        /// 总共留言条数
        /// </summary>
        public int MessageNum
        {
            get { return _u_messagenum; }
            set { _u_messagenum = value; }
        }

        /// <summary>
        /// 是否暂停
        /// </summary>
        public bool IsPuach
        {
            get { return _u_puach; }
            set { _u_puach = value; }
        }
        /// <summary>
        /// 是否推荐
        /// </summary>
        public bool IsVouch
        {
            get { return _u_vouch; }
            set { _u_vouch = value; }
        }

        /// <summary>
        /// 网店模板名称
        /// </summary>
        public string TemplateName
        {
            set { _u_tempname = value; }
            get { return _u_tempname; }
        }

        /// <summary>
        /// 普通错误处罚次数
        /// </summary>
        public int CommonErr
        {
            set { _u_commonerr = value; }
            get { return _u_commonerr; }
        }

        /// <summary>
        /// 恶意错误处罚次数
        /// </summary>
        public int MaliceErr
        {
            set { _u_maliceerr = value; }
            get { return _u_maliceerr; }
        }

        /// <summary>
        /// 用户资料完善率
        /// </summary>
        public int InFormation
        {
            set { _u_information = value; }
            get { return _u_information; }
        }

        /// <summary>
        /// 是否激活
        /// </summary>
        public bool IsActivation
        {
            get { return _u_activation; }
            set { _u_activation = value; }
        }
        /// <summary>
        /// 激活码验证地址
        /// </summary>
        public string ActivationCode
        {
            get { return _u_activationcode; }
            set { _u_activationcode = value; }
        }        
        
        private Model.AuditingState _AuditingState = AuditingState.NoPass;

        /// <summary>
        /// 用户审核状态（枚举）
        /// </summary>
        public Model.AuditingState AuditingState
        {
            get { return _AuditingState; }
            set { _AuditingState = value; }
        }


        private bool isHasImage;

        /// <summary>
        /// 是否包含图片
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
        /// 是否是主账户
        /// </summary>
        public bool IsPrimary
        {
            get;
            set;
        }
        /// <summary>
        /// 部门名称(律师姓名
        /// </summary>
        public string LayerName
        {
            get;
            set;
        }
        /// <summary>
        /// 部门描述
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// 电话
        /// </summary>
        public string Telphone
        {
            get;
            set;
        }
        /// <summary>
        /// 其他联系方式
        /// </summary>
        public string OtherContact
        {
            get;
            set;
        }
        /// <summary>
        /// 性别0 男 1女
        /// </summary>
        public bool Sex
        {
            get;
            set;
        }
        /// <summary>
        /// 身份证
        /// </summary>
        public string IdNumber
        {
            get;
            set;
        }
        /// <summary>
        /// 律师证
        /// </summary>
        public string LayerId
        {
            get;
            set;
        }
        /// <summary>
        /// 所属地区
        /// </summary>
        public int AreaId
        {
            get;
            set;
        }
        /// <summary>
        /// 是否是认证专家
        /// </summary>
        public bool IsExport
        {
            get;
            set;
        }
        /// <summary>
        /// 企业类型（企业&个人&律师&非律师））	
        /// </summary>
        public int UserType
        {
            get;
            set;
        }
        /// <summary>
        /// 删除状态
        /// </summary>
        public int DelState
        {
            get;
            set;
        }
        /// <summary>
        /// 唯一标示 
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
